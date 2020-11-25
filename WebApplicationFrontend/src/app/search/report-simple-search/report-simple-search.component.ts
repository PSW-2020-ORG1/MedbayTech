import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-report-simple-search',
  templateUrl: './report-simple-search.component.html',
  styleUrls: ['./report-simple-search.component.css']
})
export class ReportSimpleSearchComponent implements OnInit {

  reportForm: FormGroup;

  options = [
    'Search by doctor',
    'Search by diagnosis',
    'Search by date of examination',
    'Search by allergens'
  ];

  selectedOption: string;

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
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

  constructor(private fb : FormBuilder) { }

  ngOnInit(): void {
    this.reportForm = this.fb.group({
      selectedOption: [this.options[0]]
    });
  }

}
