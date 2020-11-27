import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatRadioModule} from '@angular/material/radio';
import { stringify } from 'querystring';
import { Prescription } from 'src/app/model/prescriptionSearch';
import { PrescriptionService } from 'src/app/service/prescription/prescription.service';


@Component({
  selector: 'app-prescription-search',
  templateUrl: './prescription-search.component.html',
  styleUrls: ['./prescription-search.component.css']
})
export class PrescriptionSearchComponent implements OnInit {

  prescriptionForm: FormGroup;
  
  allPrescriptions: Prescription[] = new Array();
  

  Id: number;
  Medicine: string;
  AndOr: boolean;
  HourlyIntake: number;
  ReservationPeriodStart: Date;
  ReservationPeriodEnd: Date;

  options = [
    'Search by medicine',
    'Search by hourly intake',
    'Search by reservation period'
  ];

  options2 = [
    'Search by medicine',
    'Search by hourly intake',
    'Search by reservation period'
  ];

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  range2 = new FormGroup({
    start2: new FormControl(),
    end2: new FormControl()
  });

  med = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  hour = new FormControl('',[Validators.required,
    Validators.pattern("[0123456789]{1}")]
  );

  med2 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  hour2 = new FormControl('',[Validators.required,
    Validators.pattern("[0123456789]{1}")]
  );
  
  constructor(private ps: PrescriptionService,private fb: FormBuilder) {
   

   }

  ngOnInit(): void {
    this.prescriptionForm = this.fb.group({
      selectedOption: [this.options[0]],
      radios: [],
      medField: ['',[Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      hourField: ['',[Validators.required,
        Validators.pattern("[0123456789]{1}")]],
      duplicates: this.fb.array([])
    });

    


    //this.addCreds();
  }

  onSearch():void {
    const selects = this.prescriptionForm.get('selectedOption').value;
    const selects2 = this.prescriptionForm.get('duplicates.0').value.selectedOption2;
    this.Id = 0;
    this.AndOr = this.getRadio();
    if(selects == "Search by medicine")
      this.Medicine = this.prescriptionForm.value.medField;
    else if(selects == "Search by hourly intake")
      this.HourlyIntake = this.prescriptionForm.value.hourField;

    if(selects2 == "Search by medicine")
      this.Medicine = this.prescriptionForm.get('duplicates.0').value.medField2;
    else if(selects2 == "Search by hourly intake")
      this.HourlyIntake = this.prescriptionForm.get('duplicates.0').value.hourField2;
    
  }

  private getRadio () : boolean {
    const selects = this.prescriptionForm.get('duplicates.0').value.radios2;
    if(selects == "and"){
      return true;
    }
    return false;
  }


  addDuplicates() {
    const dups = this.prescriptionForm.get('duplicates') as FormArray;
    dups.push(this.fb.group({
      selectedOption2: [this.options2[0]],
      radios2: [],
      medField2: ['',[Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      hourField2: ['',[Validators.required,
        Validators.pattern("[0123456789]{1}")]]
    }));
    console.log( this.prescriptionForm.get('duplicates.0').value.hourField2);
  }


  removeDuplicates(i:number){
    const dups = (this.prescriptionForm.get('duplicates')as FormArray);
    dups.removeAt(i);
    
  }

  loadAllFeedback() {
    this.ps.getAllPrescriptions().subscribe(data => 
      {
        this.allPrescriptions = data
      });
  }
}
