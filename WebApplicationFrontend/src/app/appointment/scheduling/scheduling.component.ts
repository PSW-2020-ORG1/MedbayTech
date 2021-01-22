import { AppointmentEventType } from './../../model/event/appointmentEventType';
import { start } from 'repl';
import { EventService } from './../../service/event/event.service';
import { Component, OnInit, ViewEncapsulation  } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppointmentScheduling } from 'src/app/model/appointmentScheduling';
import { AvailableAppointments } from 'src/app/model/availableAppointments';
import { ScheduleAppointment } from 'src/app/model/scheduleAppointment';
import { SearchDoctor } from 'src/app/model/searchDoctor';
import { Specialization } from 'src/app/model/specialization';
import { SpecializationId } from 'src/app/model/specializationId';
import { AppointmentService } from 'src/app/service/appointment/appointment.service';
import { DoctorServiceService } from 'src/app/service/doctor/doctor-service.service';
import { SpecializationService } from 'src/app/service/specialization/specialization.service';
import { AppointmentEvent } from 'src/app/model/event/appointmentEvent';
import { OnDestroy } from '@angular/core';

@Component({
  selector: 'app-scheduling',
  templateUrl: './scheduling.component.html',
  styleUrls: ['./scheduling.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SchedulingComponent implements OnInit, OnDestroy {

  dateFormGroup : FormGroup;
  specializationFormGroup : FormGroup;
  doctorFormGroup : FormGroup;
  doctor : string;
  specializationId: SpecializationId;
  isOptional = false;
  isEditable = true;

  availableAppointments : AvailableAppointments[] = new Array();
  scheduleAppointment : ScheduleAppointment;
  appointmentScheduling : AppointmentScheduling;

  searchDoctors : SearchDoctor[] = new Array();
  specializations : Specialization[] = new Array();

  appointmentEvent : AppointmentEvent;

  route : string;

  sessionId : string;

  displayedColumns : string[] = ['position', 'Date', 'Time', '#'];

  constructor(private doctorService : DoctorServiceService, private appointmentService : AppointmentService, private specializationService : SpecializationService, private toastr : ToastrService, private eventService : EventService, private router : Router) {
    
   }
  ngOnDestroy(): void {
    this.createQuitEvent();
  }

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
    this.route = this.router.url;
    this.getSpecializations();
    this.sessionId = this.makeid();
    this.createStartEvent();  
    
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
  }

  getAvailableAppointments() {
    var date = new Date(this.dateFormGroup.value.date.getTime() - this.dateFormGroup.value.date.getTimezoneOffset() * 60000);
    var doctor = this.doctor;

    this.appointmentScheduling = new AppointmentScheduling(doctor, date);

    this.appointmentService.getAvailableByDate(this.appointmentScheduling).subscribe(data => {
      this.availableAppointments = data;
    })
  }

  schedule(appointment) {
    console.log(this.doctor)
    this.scheduleAppointment = new ScheduleAppointment(appointment.start, appointment.end , "", this.doctor);
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

  makeid() : string {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
  
    for (var i = 0; i < possible.length; i++)
      text += possible.charAt(Math.floor(Math.random() * possible.length));
  
    return text;
  }

  showSessionId() {
    console.log(this.sessionId);
  }

  createQuitEvent() {
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.Quit, this.sessionId);
    this.postEvent();
  }
  createStartEvent(){
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.Started, this.sessionId);
    this.postEvent();
  }
  createFromStartedToSelectSpecializationEvent() {
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.FromStartedToSelectSpecialization, this.sessionId);
    this.postEvent()
  }
  createFromSelectSpecializationToStarted() {
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.FromSelectSpecializationToStarted, this.sessionId);
    this.postEvent();
  }
  createFromSelectSpecializationToSelectDoctor() {
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.FromSelectSpecializationToSelectDoctor, this.sessionId);
    this.postEvent();
  }
  createFromSelectDoctorToSelectSpecialization() {
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.FromSelectDoctorToSelectSpecialization, this.sessionId);
    this.postEvent();
  }
  createFromSelectDoctorToSelectAppointment() {
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.FromSelectDoctorToSelectAppointment, this.sessionId);
    this.postEvent();
  }
  createFromSelectAppointmentToSelectDoctor() {
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.FromSelectAppointmentToSelectDoctor, this.sessionId);
    this.postEvent();
  }
  createCreatedEvent() {
    this.appointmentEvent = new AppointmentEvent(AppointmentEventType.Created, this.sessionId);
    this.postEvent();
  }
  postEvent() {
    this.eventService.postEvent(this.appointmentEvent).subscribe();
  }


}
