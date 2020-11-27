import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Report } from 'src/app/model/report';
import { ReportService } from 'src/app/service/report/report.service';

@Component({
  selector: 'app-report-simple-search',
  templateUrl: './report-simple-search.component.html',
  styleUrls: ['./report-simple-search.component.css']
})
export class ReportSimpleSearchComponent implements OnInit {

  reportForm: FormGroup;

  public allReports : Report[] = new Array();

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  doc = new FormControl('',[Validators.pattern("[A-Za-z]+")]);

  diag = new FormControl('',[Validators.pattern("[A-Za-z]+")]);

  treatments = new FormControl('',[Validators.pattern("[A-Za-z]+")]);

  constructor(private rs : ReportService, private fb : FormBuilder) { }

  ngOnInit(): void {
    this.reportForm = this.fb.group({
    });
  }

  onSubmit() {
    this.rs.getSimpleSearchResults(this.reportForm.value.doc, new Date(this.reportForm.value.range.start.getTime() - this.reportForm.value.range.start.getTimezoneOffset() * 60000),
       new Date(this.reportForm.value.range.end.getTime() - this.reportForm.value.range.end.getTimezoneOffset() * 60000),
        this.reportForm.value.treatments).subscribe(
        data => {
          this.allReports = data;
        }
    ) 
  }

}
