import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatRadioModule} from '@angular/material/radio';
import { stringify } from 'querystring';
import { Prescription } from 'src/app/model/prescriptionSearch';
import { PrescriptionService } from 'src/app/service/prescription/prescription.service';

const ELEMENT_DATA: Prescription[] = [
  {medication: 'Brufen', hourlyIntake: "8", andOr:"AND"},
  {medication: 'Paracetamol', hourlyIntake: "2", andOr:"AND"},
  {medication: 'Amoksicilin', hourlyIntake: "5", andOr: "Li"},
  {medication: 'Febricet', hourlyIntake: "6", andOr: "Be"},
  

];

@Component({
  selector: 'app-prescription-search',
  templateUrl: './prescription-search.component.html',
  styleUrls: ['./prescription-search.component.css']
})
export class PrescriptionSearchComponent implements OnInit {

  prescriptionForm: FormGroup;
  
  allPrescriptions: Prescription[] = new Array();
  

  Id: number;
  FirstOperand: string;
  AndOr: string;
  SecondOperand: string;
  ReservationPeriodStart: Date;
  ReservationPeriodEnd: Date;
  displayedColumns: string[] = ['medicine', 'hourly intake'];
  dataSource = ELEMENT_DATA;

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

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  range2 = new FormGroup({
    start2: new FormControl(),
    end2: new FormControl()
  });

 
  constructor(private ps: PrescriptionService,private fb: FormBuilder) {
   

   }

  ngOnInit(): void {
    this.prescriptionForm = this.fb.group({
      selectedOption: [this.options[0]],
      radios: [],
      medField: new FormControl('',[Validators.required,
        Validators.pattern("[A-Za-z]+")]),
      hourField: new FormControl('',[Validators.required,
        Validators.pattern("([1-9]|1[0-9]|2[0-4])")]),
      duplicates: this.fb.array([])
    });

    

    
    //this.addCreds();
  }

  onSearch():void {
    const selects = this.prescriptionForm.get('selectedOption').value;
    
    this.Id = 0;
    
    if(selects == "Search by medicine")
      this.FirstOperand = this.prescriptionForm.value.medField;
    else if(selects == "Search by hourly intake")
      this.FirstOperand = this.prescriptionForm.value.hourField;
    else
      this.FirstOperand = "";
    
    if(this.prescriptionForm.get('duplicates')['length']>0){
      const selects2 = this.prescriptionForm.get('duplicates.0').value.selectedOption2;
      this.AndOr = this.getRadio();
    
      if(selects2 == "Search by medicine")
        this.SecondOperand = this.prescriptionForm.get('duplicates.0').value.medField2;
      else if(selects2 == "Search by hourly intake")
        this.SecondOperand = this.prescriptionForm.get('duplicates.0').value.hourField2;
      else
        this.SecondOperand = "";
    
    }
    else{
      this.SecondOperand = "";
      this.AndOr = "AND";
    }
    
    
    
      
    console.log(console.log(this.prescriptionForm.get('medField').errors));
  }

  private getRadio () : string {
    const selects = this.prescriptionForm.get('duplicates.0').value.radios2;
    if(selects == "and"){
      return "AND";
    }
    else if(selects == "or"){
      return "OR";
    }
    return "AND";
  }


  addDuplicates() {
    const dups = this.prescriptionForm.get('duplicates') as FormArray;
    dups.push(this.fb.group({
      selectedOption2: [this.options2[0]],
      radios2: [],
      medField2: new FormControl('',[Validators.required,
        Validators.pattern("[A-Za-z]+")]),
      hourField2: new FormControl('',[Validators.required,
        Validators.pattern("([1-9]|1[0-9]|2[0-4])")])
    }));
    console.log( this.prescriptionForm.get('duplicates.0').get('medField2'));
  }


  removeDuplicates(i:number){
    const dups = (this.prescriptionForm.get('duplicates')as FormArray);
    dups.removeAt(i);
    
  }

  // loadAllFeedback() {
  //   this.ps.getAllPrescriptions().subscribe(data => 
  //     {
  //       this.allPrescriptions = data
  //     });
  // }
}
