import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Appointment } from 'src/app/model/appointment';
import { AppointmentReport } from 'src/app/model/appointmentReport';
import { CancelAppointment } from 'src/app/model/cancelAppointment';
import { GetAppointment } from 'src/app/model/getAppointment';
import { ObservePrescriptionComponent, ObservePrescriptionComponentDialog } from 'src/app/prescription/observe-prescription/observe-prescription.component';
import { AppointmentService } from 'src/app/service/appointment/appointment.service';
import { ReportService } from 'src/app/service/report/report.service';

@Component({
  selector: 'app-observe-appointment',
  templateUrl: './observe-appointment.component.html',
  styleUrls: ['./observe-appointment.component.css']
})
export class ObserveAppointmentComponent implements OnInit {

  public surveyableAppointments : GetAppointment[] = new Array();
  public allOtherAppointments : GetAppointment[] = new Array();
  public allCancelableAppointments : GetAppointment[] = new Array();
  public report : AppointmentReport;

  constructor(private appointmentService : AppointmentService, public dialog:ObservePrescriptionComponent,private reportService : ReportService) { }

  ngOnInit(): void {
    this.loadSurveyableAppointments();
    this.loadAllOtherAppointments();
    this.loadCancelableAppointments();
  }
  test(startTime,doctorId) {
    this.reportService.getAppointmentReport(new Appointment(startTime,doctorId)).subscribe(data =>
      {
        this.report = data;
      });
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
  cancelAppointment(appointmentId){
    this.appointmentService.cancelAppointment(new CancelAppointment(appointmentId)).subscribe(
      res => {
        this.loadCancelableAppointments();
        this.loadSurveyableAppointments();
        this.loadAllOtherAppointments();
        alert(res);
      },
      error => {
        this.loadCancelableAppointments();
        this.loadSurveyableAppointments();
        this.loadAllOtherAppointments();
        alert(error);
      }
      );
    
  }
  
  saveAppointment(appointment : GetAppointment){
    localStorage.setItem('appointment',JSON.stringify(appointment.id));
  }
}
