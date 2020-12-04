import { SpecializationId } from './../../model/specializationId';
import { SpecializationService } from './../../service/specialization/specialization.service';
import { DoctorServiceService } from './../../service/doctor/doctor-service.service';
import { SearchDoctor } from './../../model/searchDoctor';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Specialization } from 'src/app/model/specialization';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.css']
})
export class RecommendationComponent implements OnInit {

  intervalFormGroup : FormGroup;
  doctorFormGroup : FormGroup;
  priorityFormGroup : FormGroup;
  isOptional = false;
  doctor : string;
  specializationId : SpecializationId;

  searchDoctors : SearchDoctor[] = new Array();
  specializations : Specialization[] = new Array();

  constructor(private doctorService : DoctorServiceService, private specializationService : SpecializationService) { }

  ngOnInit(): void {
    this.intervalFormGroup = new FormGroup({
      'startInterval' : new FormControl(null, [Validators.required]),
      'endInterval' : new FormControl(null, [Validators.required]),
    });
    this.doctorFormGroup = new FormGroup({
      'choosenDoctor' : new FormControl(null, [Validators.required]),
      'specialization' : new FormControl(null, [Validators.required])
    });
   // this.getSearchDoctors();
   this.getSpecializations();
  }

  getSearchDoctors() {
    this.doctorService.getAllDoctors().subscribe(data => {
      this.searchDoctors = data});
  }

  getDoctorsBySpecialization(specializationId : number) {
    this.doctorService.getDoctorsBySpecialization(specializationId).subscribe(data => {
      this.searchDoctors = data;
    });
  }

  getDoctor(event) {
    this.doctor = event.value;
    console.log(this.doctor);
  }

  getSpecializations() {
    this.specializationService.getAll().subscribe(data => {
      this.specializations = data;
    });
  }

  selectSpecialization(event) {
    this.specializationId = new SpecializationId(event.value);
    console.log(this.specializationId.specializationId);
    this.getDoctorsBySpecialization(event.value)
  }

}
