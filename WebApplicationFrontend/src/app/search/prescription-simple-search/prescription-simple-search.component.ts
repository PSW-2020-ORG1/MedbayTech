import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Prescription } from 'src/app/model/prescription';
import { PrescriptionService } from 'src/app/service/prescription/prescription.service';

@Component({
  selector: 'app-prescription-simple-search',
  templateUrl: './prescription-simple-search.component.html',
  styleUrls: ['./prescription-simple-search.component.css']
})
export class PrescriptionSimpleSearchComponent implements OnInit {
  prescriptionForm: FormGroup;
  
  allPrescriptions: Prescription[] = new Array();

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  med = new FormControl('',[Validators.pattern("[A-Za-z]+")]);

  hour = new FormControl('',[Validators.pattern("[0123456789]{1}")]);

  constructor(private ps : PrescriptionService, private fb: FormBuilder) { }

  ngOnInit(): void {

    this.prescriptionForm = this.fb.group({});
  }

}
