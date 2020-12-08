import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AvailableAppointments } from 'src/app/model/availableAppointments';
import { ScheduleAppointment } from 'src/app/model/scheduleAppointment';
import { SearchDoctor } from 'src/app/model/searchDoctor';
import { Specialization } from 'src/app/model/specialization';
import { SpecializationId } from 'src/app/model/specializationId';
import { AppointmentService } from 'src/app/service/appointment/appointment.service';
import { DoctorServiceService } from 'src/app/service/doctor/doctor-service.service';
import { SpecializationService } from 'src/app/service/specialization/specialization.service';

@Component({
  selector: 'app-scheduling',
  templateUrl: './scheduling.component.html',
  styleUrls: ['./scheduling.component.css']
})
export class SchedulingComponent implements OnInit {

  dateFormGroup : FormGroup;
  specializationFormGroup : FormGroup;
  doctorFormGroup : FormGroup;
  doctor : string;
  specializationId: SpecializationId;
  isOptional = false;

  availableAppointments : AvailableAppointments[] = new Array();
  scheduleAppointment : ScheduleAppointment;

  searchDoctors : SearchDoctor[] = new Array();
  specializations : Specialization[] = new Array();

  displayedColumns : string[] = ['position', 'Date', 'Time', '#'];

  constructor(private doctorService : DoctorServiceService, private appointmentService : AppointmentService, private specializationService : SpecializationService, private toastr : ToastrService) { }

  ngOnInit(): void {
    this.dateFormGroup = new FormGroup({
      'date' : new FormControl(null, Validators.required)
    })

    this.specializationFormGroup = new FormGroup({
      'specialization' : new FormControl(null, Validators.required)
    })

    this.doctorFormGroup = new FormGroup({
      'chosenDoctor': new FormControl(null, Validators.required)
    })
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

}
