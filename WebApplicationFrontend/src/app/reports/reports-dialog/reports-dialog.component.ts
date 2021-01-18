import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { AppointmentReport } from 'src/app/model/appointmentReport';

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
  generatePdf(data) {
    html2canvas(data, { allowTaint: true }).then(canvas => {
     let HTML_Width = canvas.width;
     let HTML_Height = canvas.height;
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
      pdf.save("report.pdf");
   });
 }
}