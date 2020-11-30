import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { MedicalRecord } from '../model/medicalRecord';
import { MedicalRecordService } from '../service/medicalRecord/medicalRecord.service';

@Component({
  selector: 'app-medical-record',
  templateUrl: './medical-record.component.html',
  styleUrls: ['./medical-record.component.css']
})
export class MedicalRecordComponent implements OnInit {

  public medicalRecord : MedicalRecord;
  public imageUrl : any;
  public unsafeImageUrl : any;

  constructor(private medicalRecordService : MedicalRecordService, private sanitizer : DomSanitizer) { }

  ngOnInit(): void { 
    this.loadMedicalRecord();
  }

  loadMedicalRecord() {
    this.medicalRecordService.getMedicalRecordByPatientId().subscribe(data =>
      {
        this.medicalRecord = data;
        this.imageUrl = data.img;
      });
  }

}
