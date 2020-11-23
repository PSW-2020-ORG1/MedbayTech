import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-report-search',
  templateUrl: './report-search.component.html',
  styleUrls: ['./report-search.component.css']
})
export class ReportSearchComponent implements OnInit {

  reportForm: FormGroup;

  options = [
    'Search by doctor',
    'Search by diagnosis',
    'Search by date of examination',
    'Search by allergens'
  ];

  options2 = [
    'Search by doctor',
    'Search by diagnosis',
    'Search by date of examination',
    'Search by type of examination'
  ];

  options3 = [
    'Search by doctor',
    'Search by diagnosis',
    'Search by date of examination',
    'Search by type of examination'
  ];
  
  options4 = [
    'Search by doctor',
    'Search by diagnosis',
    'Search by date of examination',
    'Search by type of examination'
  ];

  selectedOption: string;
  selectedOption2: string;
  selectedOption3: string;
  selectedOption4: string;

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

  doc = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  diag = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  allergens = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  doc2 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  diag2 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  allergens2 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  doc3 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  diag3 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  allergens3 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  doc4 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  diag4 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  allergens4 = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  

  constructor(private fb:FormBuilder) { }

  ngOnInit(): void {
    this.reportForm = this.fb.group({
      selectedOption: [this.options[0]],
      radios: [],
      duplicates: this.fb.array([])
    });

  }

  addDuplicates() {
    const dups = this.reportForm.get('duplicates') as FormArray;
    dups.push(this.fb.group({
      selectedOption2: [this.options[0]],
      radios2: []
    }));
    console.log(this.reportForm.get('duplicates.0').value);
  }

  removeDuplicates(i:number){
    const dups = (this.reportForm.get('duplicates')as FormArray);
    dups.removeAt(i);
    
  }

}
