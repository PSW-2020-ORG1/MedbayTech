import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Prescription, PrescriptionSearch } from 'src/app/model/prescription';
import { PrescriptionService } from 'src/app/service/prescription/prescription.service';

@Component({
  selector: 'app-prescription-simple-search',
  templateUrl: './prescription-simple-search.component.html',
  styleUrls: ['./prescription-simple-search.component.css']
})
export class PrescriptionSimpleSearchComponent implements OnInit {
  prescriptionForm: FormGroup;
  
  allPrescriptions: Prescription[];

  medicine : string;
  hourlyIntake : number;
  startDate : Date;
  endDate : Date;

  prescriptionSearch : PrescriptionSearch;
  prescription : Prescription;

  displayedColumns : string[] = ['medicine', 'hourlyIntake', 'date' ];

  constructor(private ps : PrescriptionService) { }

  ngOnInit(): void {
    this.prescriptionForm = new FormGroup({
      'medicine' : new FormControl('', [Validators.pattern("^[a-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'hourlyIntake' : new FormControl(6, [Validators.pattern("^[0-9]{1,2}")]),
      'startDate' : new FormControl(new Date()),
      'endDate' : new FormControl(new Date())
    })
  }

  onSubmit() {
    this.ps.getSimpleSearchResults(this.createSearch()).subscribe(
        data => {
          this.allPrescriptions = data;
        }
    ) 
  }

  createSearch() : PrescriptionSearch {
    this.medicine = this.prescriptionForm.value.medicine;
    this.hourlyIntake = this.prescriptionForm.value.hourlyIntake;
    this.startDate = new Date(this.prescriptionForm.value.startDate.getTime() - this.prescriptionForm.value.startDate.getTimezoneOffset() * 60000);
    this.endDate = new Date(this.prescriptionForm.value.endDate.getTime() - this.prescriptionForm.value.endDate.getTimezoneOffset() * 60000);

    this.prescriptionSearch = new PrescriptionSearch(this.medicine, this.hourlyIntake, this.startDate, this.endDate);

    return this.prescriptionSearch;
  }
}
