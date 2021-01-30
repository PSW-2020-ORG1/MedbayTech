import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AppointmentReport } from 'src/app/model/appointmentReport';
import pdfMake from "pdfmake/build/pdfmake";

@Component({
  selector: 'app-reports-dialog',
  templateUrl: './reports-dialog.component.html',
  styleUrls: ['./reports-dialog.component.css']
})
export class ReportsDialogComponent implements OnInit {

  public report : AppointmentReport;
  constructor(
    public dialogRef: MatDialogRef<ReportsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AppointmentReport) {}
 
    ngOnInit(): void
    {
      this.report = this.data.reportAppointment;
    }
  
  openPDF(){
    var datepipe = new DatePipe('en-US');
    let docDefinition = {
      content: [
      {
        text: "REPORTS",
        fontSize: 16,
        alignment: 'center',
        color: '#047886',
        marginBottom: 15
      },
      {
        text: this.report.type,
        fontSize: 14,
        alignment: 'center'
      },
      {
        table: {
          headerRows: 1,
          bold: true,
          widths: ['*', 'auto'],
          body: [
            [{text:'Diagnosis',bold: true}, {text:'Symptoms',bold:true}],
            ...this.report.diagnosis.map(p => ([p.name, p.symptoms])),
            
          ]
        }
      },
      {
        text: "Doctor:" + " " +this.report.doctorName  + " " +this.report.doctorSurname,
        fontSize: 12
      },
      {
        text: "Date:" + " " + datepipe.transform(this.report.startTime.toLocaleString(),'dd.MM.yyyy'),
        fontSize: 12,
      },
      ]
    }
    pdfMake.createPdf(docDefinition).open();     
  
  }
}

