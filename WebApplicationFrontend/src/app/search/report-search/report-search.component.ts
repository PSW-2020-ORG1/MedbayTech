import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Report } from 'src/app/model/reportSearch';

const ELEMENT_DATA: Report[] = [
  {doctorName: 'Jovan', doctorSurname: 'Jovanovic', dateOfExamination: '5/31/2020', allergens: 'Prasina', diagnosis: 'Povisena temperatura i kasalj', andOr: 'AND'},
  {doctorName: 'Bogdan', doctorSurname: 'Bogdanovic', dateOfExamination: '5/31/2020', allergens: 'Polen', diagnosis: 'Povisena temperatura i kasalj', andOr: 'AND'},
  {doctorName: 'Stefan', doctorSurname: 'Stefanovic', dateOfExamination: '5/31/2020', allergens: 'Ambrozija', diagnosis: 'Povisena temperatura i kasalj', andOr: 'AND'},
  {doctorName: 'Petar', doctorSurname: 'Petrovic', dateOfExamination: '5/31/2020', allergens: '', diagnosis: 'Povisena temperatura i kasalj', andOr: 'AND'},
  

];

@Component({
  selector: 'app-report-search',
  templateUrl: './report-search.component.html',
  styleUrls: ['./report-search.component.css']
})
export class ReportSearchComponent implements OnInit {

  reportForm: FormGroup;
  dataSource = ELEMENT_DATA;
  displayedColumns: string[] = ['doctorName', 'doctorSurname', 'diagnosis', 'allergens', 'date'];

  options = [
    'Search by doctor name',
    'Search by doctor surname',
    'Search by diagnosis',
    'Search by date of examination',
    'Search by allergens'
  ];

  options2 = [
    'Search by doctor name',
    'Search by doctor surname',
    'Search by diagnosis',
    'Search by date of examination',
    'Search by type of examination'
  ];


  
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  range2 = new FormGroup({
    start2: new FormControl(),
    end2: new FormControl()
  });

 
  constructor(private fb:FormBuilder) { }

  ngOnInit(): void {
    this.reportForm = this.fb.group({
      selectedOption: [this.options[0]],
      radios: [],
      docName: ['',[Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      docSurname: ['', [Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      diag: ['', [Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      allergens: ['', [Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      duplicates: this.fb.array([])
    });

  }

  addDuplicates() {
    const dups = this.reportForm.get('duplicates') as FormArray;
    dups.push(this.fb.group({
      selectedOption2: [this.options2[0]],
      radios2: [],
      docName2: ['', [Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      docSurname2: ['', [Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      diag2: ['', [Validators.required,
        Validators.pattern("[A-Za-z]+")]],
      allergens2: ['', [Validators.required,
        Validators.pattern("[A-Za-z]+")]]
    }));
    console.log(this.reportForm.get('duplicates.0').value);
  }

  removeDuplicates(i:number){
    const dups = (this.reportForm.get('duplicates')as FormArray);
    dups.removeAt(i);
    
  }

}
