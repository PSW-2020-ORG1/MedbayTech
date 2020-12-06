import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-scheduling',
  templateUrl: './scheduling.component.html',
  styleUrls: ['./scheduling.component.css']
})
export class SchedulingComponent implements OnInit {

  dateFormGroup : FormGroup;
  doctorFormGroup : FormGroup;
  doctor : string;
  specializatonId: number;

  constructor() { }

  ngOnInit(): void {
  }

}
