import { Component, OnInit } from '@angular/core';
import { MedicalRecord } from '../model/medicalRecord';
import { MedicalRecordService } from '../service/medicalRecord/medicalRecord.service';

@Component({
  selector: 'app-medical-record',
  templateUrl: './medical-record.component.html',
  styleUrls: ['./medical-record.component.css']
})
export class MedicalRecordComponent implements OnInit {

  public medicalRecord : MedicalRecord;

  constructor(private medicalRecordService : MedicalRecordService) { }

  ngOnInit(): void { 
    this.loadMedicalRecord();
  }

  loadMedicalRecord() {
    this.medicalRecordService.getMedicalRecordByPatientId().subscribe(data =>
      {
        this.medicalRecord = data;
      });
  }

}
