import { Component, Inject, Injectable, OnInit } from '@angular/core';
import {MatDialog, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Appointment } from 'src/app/model/appointment';
import { AppointmentReport } from 'src/app/model/appointmentReport';
import { ReportService } from 'src/app/service/report/report.service';
import { AppointmentPrescription } from 'src/app/model/appointmentPrescription';
import { PrescriptionService } from 'src/app/service/prescription/prescription.service';
import pdfMake from "pdfmake/build/pdfmake";  
import pdfFonts from "pdfmake/build/vfs_fonts";  
import { DatePipe } from '@angular/common';
pdfMake.vfs = pdfFonts.pdfMake.vfs; 

@Injectable({
  providedIn: 'root'
})
export class ObservePrescriptionComponent {

  constructor(public dialog: MatDialog) {}
  openDialog(prescription): void {
    this.dialog.open(ObservePrescriptionComponentDialog, {
      width: '400px',
      data: { appointmentPrescription : prescription}
   });
 }

}

@Component({
  selector: 'app-observe-prescription-dialog',
  templateUrl: './observe-prescription-dialog.component.html',
})
export class ObservePrescriptionComponentDialog implements OnInit{

  public prescriptions : AppointmentPrescription[] = new Array();
  constructor(
    public dialogRef: MatDialogRef<ObservePrescriptionComponentDialog>,
    @Inject(MAT_DIALOG_DATA) public data: AppointmentPrescription) {}
 
  ngOnInit(): void
  {
    this.prescriptions = this.data.appointmentPrescription;
    console.log(this.prescriptions.length);
  }

 openPDF(){
    var datepipe = new DatePipe('en-US');
    let docDefinition = {
      content: [
      {
        text: "PRESCRIPTIONS",
        fontSize: 16,
        alignment: 'center',
        color: '#047886',
        marginBottom: 15
      },
      {
        table: {
          headerRows: 1,
          bold: true,
          widths: ['*', 'auto', 'auto', 'auto'],
          body: [
            [{text:'Medication',bold: true}, {text:'Hourly intake',bold:true}, {text: 'Take medication from',bold:true}, {text:'Take medication to',bold:true}],
            ...this.prescriptions.map(p => ([p.medication, p.hourlyIntake, datepipe.transform(p.validFrom.toLocaleString(),'dd.MM.yyyy'), datepipe.transform(p.validTo.toLocaleString(),'dd.MM.yyyy')])),
            
          ]
        }
      }
      ]
    }
    pdfMake.createPdf(docDefinition).open();     
   
  }
}
