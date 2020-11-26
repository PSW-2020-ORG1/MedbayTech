import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-report-simple-search',
  templateUrl: './report-simple-search.component.html',
  styleUrls: ['./report-simple-search.component.css']
})
export class ReportSimpleSearchComponent implements OnInit {

  reportForm: FormGroup;

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  doc = new FormControl('',[Validators.pattern("[A-Za-z]+")]);

  diag = new FormControl('',[Validators.pattern("[A-Za-z]+")]);

  treatments = new FormControl('',[Validators.pattern("[A-Za-z]+")]);

  constructor(private fb : FormBuilder) { }

  ngOnInit(): void {
    this.reportForm = this.fb.group({
    });
  }

}
