import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Report } from 'src/app/model/report';
import { ReportSearch } from 'src/app/model/report'
import { ReportService } from 'src/app/service/report/report.service';

@Component({
  selector: 'app-report-simple-search',
  templateUrl: './report-simple-search.component.html',
  styleUrls: ['./report-simple-search.component.css']
})
export class ReportSimpleSearchComponent implements OnInit {

  reportForm: FormGroup;

  allReports : Report[];

  doctor : string;
  startDate : Date;
  endDate : Date;
  type : string;

  reportSearch : ReportSearch;
  report : Report;

  constructor(private rs : ReportService) { }

  ngOnInit(): void {
    this.reportForm = new FormGroup({
      'doctor' : new FormControl('', [Validators.pattern("^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$")]),
      'startDate' : new FormControl(new Date(1970, 1, 1)),
      'endDate' : new FormControl(new Date(2070, 12, 31)),
      'type' : new FormControl('', [Validators.pattern("^[A-ZŠĐŽČĆ][a-zšđćčžA-ZŠĐŽČĆ ]*$")])
    }) 
  }

  onSubmit() {
    console.log('cao');
    this.rs.getSimpleSearchResults(this.createSearch()).subscribe(
        data => {
          this.allReports = data;
        }
    ) 
  }

  createSearch() : ReportSearch {
    this.doctor = this.reportForm.value.doctor;
    this.startDate = new Date(this.reportForm.value.startDate.getTime() - this.reportForm.value.startDate.getTimezoneOffset() * 60000);
    this.endDate = new Date(this.reportForm.value.endDate.getTime() - this.reportForm.value.endDate.getTimezoneOffset() * 60000);
    this.type = this.reportForm.value.type;

    this.reportSearch = new ReportSearch(this.doctor, this.startDate, this.endDate, this.type);

    return this.reportSearch;
  }

  changeToEmptyString() {

  }
}
