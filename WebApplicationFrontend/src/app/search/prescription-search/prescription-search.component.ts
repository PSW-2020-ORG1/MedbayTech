import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {MatRadioModule} from '@angular/material/radio';
import { PrescriptionSearch } from 'src/app/model/prescriptionSearch';
import { PrescriptionService } from 'src/app/service/prescription/prescription.service';


@Component({
  selector: 'app-prescription-search',
  templateUrl: './prescription-search.component.html',
  styleUrls: ['./prescription-search.component.css']
})
export class PrescriptionSearchComponent implements OnInit {

  prescriptionForm: FormGroup;
  
  allPrescriptions: PrescriptionSearch[] = new Array();
  
  

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

  options3 = [
    'Search by medicine',
    'Search by hourly intake',
    'Search by reservation period'
  ];
  
  options4 = [
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

  range3 = new FormGroup({
    start3: new FormControl(),
    end3: new FormControl()
  });

  range4 = new FormGroup({
    start4: new FormControl(),
    end4: new FormControl()
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

  med3 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  hour3 = new FormControl('',[Validators.required,
    Validators.pattern("[0123456789]{1}")]
  );

  med4 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  hour4 = new FormControl('',[Validators.required,
    Validators.pattern("[0123456789]{1}")]
  );
  
  constructor(private ps: PrescriptionService,private fb: FormBuilder) {
   

   }

  ngOnInit(): void {
    this.prescriptionForm = this.fb.group({
      selectedOption: [this.options[0]],
      radios: [],
      duplicates: this.fb.array([])
    });

    //this.addCreds();
  }

 


  addDuplicates() {
    const dups = this.prescriptionForm.get('duplicates') as FormArray;
    dups.push(this.fb.group({
      selectedOption2: [this.options[0]],
      radios2: []
    }));
    console.log(this.prescriptionForm.get('duplicates'));
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
