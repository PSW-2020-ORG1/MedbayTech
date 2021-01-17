import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Appointment } from 'src/app/model/appointment';
import { AppointmentPrescription } from 'src/app/model/appointmentPrescription';
import { AppointmentReport } from 'src/app/model/appointmentReport';
import { CancelAppointment } from 'src/app/model/cancelAppointment';
import { GetAppointment } from 'src/app/model/getAppointment';
import { ObservePrescriptionComponent, ObservePrescriptionComponentDialog } from 'src/app/prescription/observe-prescription/observe-prescription.component';
import { ReportDialogComponent } from 'src/app/reports/reports-dialog/report-dialog/report-dialog.component';
import { AppointmentService } from 'src/app/service/appointment/appointment.service';
import { PrescriptionService } from 'src/app/service/prescription/prescription.service';
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
  public prescriptions : AppointmentPrescription[] = new Array();

  constructor(private appointmentService : AppointmentService, public dialog:ObservePrescriptionComponent,public dialogReport: ReportDialogComponent,
    private reportService : ReportService, private prescriptionService : PrescriptionService) { }

  ngOnInit(): void {
    this.loadSurveyableAppointments();
    this.loadAllOtherAppointments();
    this.loadCancelableAppointments();
  }
  async test(startTime,doctorId){
    
    const data = await this.reportService.getAppointmentReport(new Appointment(startTime,doctorId)).toPromise();
    this.report = data;

  }

  async getAppointmentPrescriptions(startTime, doctorId){
    const data = await this.prescriptionService.getAppointmentPrescription(new Appointment(startTime,doctorId)).toPromise();
    this.prescriptions = data;
  }

  async openPrescriptionDialog(startTime, doctorId){
    await this.getAppointmentPrescriptions(startTime,doctorId);
    this.dialog.openDialog(this.prescriptions);
  }

  async otherMethod(startTime,doctorId){
    await this.test(startTime,doctorId);
    this.dialogReport.openDialog(this.report);
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
