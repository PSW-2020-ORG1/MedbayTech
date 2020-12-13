import { ToastrService } from 'ngx-toastr';
import { ScheduleAppointment } from './../../model/scheduleAppointment';
import { AppointmentService } from './../../service/appointment/appointment.service';
import { AvailableAppointments } from './../../model/availableAppointments';
import { SpecializationId } from './../../model/specializationId';
import { SpecializationService } from './../../service/specialization/specialization.service';
import { DoctorServiceService } from './../../service/doctor/doctor-service.service';
import { SearchDoctor } from './../../model/searchDoctor';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormGroupName } from '@angular/forms';
import { Specialization } from 'src/app/model/specialization';
import { AppointmentRecommendation } from 'src/app/model/appointmentRecommendation';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.css']
})
export class RecommendationComponent implements OnInit {

  intervalFormGroup : FormGroup;
  doctorFormGroup : FormGroup;
  priorityFormGroup : FormGroup;
  isOptional = false;
  doctor : string;
  specializationId : SpecializationId;

  searchDoctors : SearchDoctor[] = new Array();
  specializations : Specialization[] = new Array();

  availableAppointments : AvailableAppointments[] = new Array();

  appointmentRecommendation : AppointmentRecommendation;

  scheduleAppointment : ScheduleAppointment;

  displayedColumns: string[] = ['position', 'Date', 'Time', '#'];

  constructor(private doctorService : DoctorServiceService, private appointmentService : AppointmentService, private specializationService : SpecializationService, private toastr : ToastrService) { }

  ngOnInit(): void {
    this.intervalFormGroup = new FormGroup({
      'startInterval' : new FormControl(null, [Validators.required]),
      'endInterval' : new FormControl(null, [Validators.required]),
    });
    this.doctorFormGroup = new FormGroup({
      'choosenDoctor' : new FormControl(null, [Validators.required]),
      'specialization' : new FormControl(null, [Validators.required])
    });
   // this.getSearchDoctors();
   this.getSpecializations();
  }

  getSearchDoctors() {
    this.doctorService.getAllDoctors().subscribe(data => {
      this.searchDoctors = data});
  }

  getDoctorsBySpecialization(specializationId : number) {
    this.doctorService.getDoctorsBySpecialization(specializationId).subscribe(data => {
      this.searchDoctors = data;
    });
  }

  getDoctor(event) {
    this.doctor = event.value;
    console.log(this.doctor);
  }

  getSpecializations() {
    this.specializationService.getAll().subscribe(data => {
      this.specializations = data;
    });
  }

  selectSpecialization(event) {
    this.specializationId = new SpecializationId(event.value);
    console.log(this.specializationId.specializationId);
    this.getDoctorsBySpecialization(event.value)
  }

  submit() {
    this.getAvailableAppointments();
    console.log("Start: " + this.intervalFormGroup.value.startInterval);
    console.log("End: " + this.intervalFormGroup.value.endInterval);
    console.log("Choosen doctor: " + this.doctor);


  }

  getAvailableAppointments() {
    var start = new Date(this.intervalFormGroup.value.startInterval.getTime() - this.intervalFormGroup.value.startInterval.getTimezoneOffset() * 60000)
    var end = new Date(this.intervalFormGroup.value.endInterval.getTime() - this.intervalFormGroup.value.endInterval.getTimezoneOffset() * 60000)
    var doctor = this.doctor;

    this.appointmentRecommendation = new AppointmentRecommendation(start, end, doctor, 0);
    
    this.appointmentService.getAvailableByDateRange(this.appointmentRecommendation).subscribe(data => {
      this.availableAppointments = data;
    });
  }

  schedule(appointment) {
    var doctor = this.doctorFormGroup.value.choosenDoctor;
    this.scheduleAppointment = new ScheduleAppointment(appointment.start, appointment.end , "", doctor);
    this.appointmentService.scheduleAppointment(this.scheduleAppointment).subscribe(
      res => {
        this.toastr.success(res);
        this.getAvailableAppointments();
      },
      error => {
        this.toastr.error(error.error);
      }
    );
  }
}
