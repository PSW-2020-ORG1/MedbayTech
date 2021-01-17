import { Component, Inject, Injectable, OnInit } from '@angular/core';
import {MatDialog, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Appointment } from 'src/app/model/appointment';
import { AppointmentReport } from 'src/app/model/appointmentReport';
import { ReportService } from 'src/app/service/report/report.service';
import { AppointmentPrescription } from 'src/app/model/appointmentPrescription';
import { PrescriptionService } from 'src/app/service/prescription/prescription.service';

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

  generatePdf(data) {
    html2canvas(data, { allowTaint: true }).then(canvas => {
     let HTML_Width = canvas.width*3/4;
     let HTML_Height = canvas.height*3/4;
     let top_left_margin = 15;
     let PDF_Width = HTML_Width + (top_left_margin * 2);
     let PDF_Height = (PDF_Width * 1.5) + (top_left_margin * 2);
     let canvas_image_width = HTML_Width;
     let canvas_image_height = HTML_Height;
     let totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;
     canvas.getContext('2d');
     let imgData = canvas.toDataURL("image/jpeg", 1.0);
     let pdf = new jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
     pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);
     for (let i = 1; i <= totalPDFPages; i++) {
       pdf.addPage([PDF_Width, PDF_Height], 'p');
       pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height * i) + (top_left_margin * 4), canvas_image_width, canvas_image_height);
     }
      pdf.save("prescriptions.pdf");
   });
 }
}
