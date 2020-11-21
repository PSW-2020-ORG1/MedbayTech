import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {MatRadioModule} from '@angular/material/radio';


@Component({
  selector: 'app-prescription-search',
  templateUrl: './prescription-search.component.html',
  styleUrls: ['./prescription-search.component.css']
})
export class PrescriptionSearchComponent implements OnInit {

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

  med = new FormControl('',[Validators.required,
    Validators.pattern("[A-Za-z]+")]
  );

  hour = new FormControl('',[Validators.required,
    Validators.pattern("/\b(0?[1-9]|1[0-9]|2[0-5])\b/g")]
  );
  
  constructor() { }

  ngOnInit(): void {
  }

  
}
