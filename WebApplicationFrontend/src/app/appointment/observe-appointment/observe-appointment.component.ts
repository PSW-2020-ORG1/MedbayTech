import { Component, OnInit } from '@angular/core';
import { CancelAppointment } from 'src/app/model/cancelAppointment';
import { GetAppointment } from 'src/app/model/getAppointment';
import { AppointmentService } from 'src/app/service/appointment/appointment.service';

@Component({
  selector: 'app-observe-appointment',
  templateUrl: './observe-appointment.component.html',
  styleUrls: ['./observe-appointment.component.css']
})
export class ObserveAppointmentComponent implements OnInit {

  public surveyableAppointments : GetAppointment[] = new Array();
  public allOtherAppointments : GetAppointment[] = new Array();
  public allCancelableAppointments : GetAppointment[] = new Array();

  constructor(private appointmentService : AppointmentService) { }

  ngOnInit(): void {
    this.loadSurveyableAppointments();
    this.loadAllOtherAppointments();
    this.loadCancelableAppointments();
  }

  loadSurveyableAppointments(){
    this.appointmentService.getSurveyableAppointments().subscribe(data =>
      {
        this.surveyableAppointments = data;
      });
  }
  loadAllOtherAppointments(){
    this.appointmentService.getAllOtherAppointments().subscribe(data =>
      {
        this.allOtherAppointments = data;
      });
  }
  loadCancelableAppointments(){
    this.appointmentService.getAllCancelableAppointments().subscribe(data =>
      {
        this.allCancelableAppointments = data;
      });
  }
  cancelAppointment(appointmentId,element){
    this.appointmentService.cancelAppointment(new CancelAppointment(appointmentId)).subscribe(data =>
      {
      this.loadCancelableAppointments();
      this.loadSurveyableAppointments();
      this.loadAllOtherAppointments();
      });
    
  }
  saveAppointment(appointment : GetAppointment){
    localStorage.setItem('appointment',JSON.stringify(appointment.id));
  }
}
