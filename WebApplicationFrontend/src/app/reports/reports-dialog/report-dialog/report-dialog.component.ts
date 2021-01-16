import { Component, Inject, Injectable, OnInit } from '@angular/core';
import {MatDialog, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Appointment } from 'src/app/model/appointment';
import { AppointmentReport } from 'src/app/model/appointmentReport';
import { ReportService } from 'src/app/service/report/report.service';
import { ReportsDialogComponent } from '../reports-dialog.component';


@Injectable({
  providedIn: 'root'
})
export class ReportDialogComponent {

  constructor(public dialog: MatDialog,private reportService : ReportService) {}

  openDialog(report): void {
     this.dialog.open(ReportsDialogComponent, {
        width: '350px',
        data: { reportAppointment : report}
    });
  }

}

