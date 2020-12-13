import { Component, OnInit } from '@angular/core';
import { MaliciousPatient } from 'src/app/model/maliciousPatient';
import { UpdatePatientBlockedStatus } from 'src/app/model/updatePatientBlockedStatus';
import { PatientService } from 'src/app/service/patient/patient.service';

@Component({
  selector: 'app-block-malicious-users',
  templateUrl: './block-malicious-users.component.html',
  styleUrls: ['./block-malicious-users.component.css']
})
export class BlockMaliciousUsersComponent implements OnInit {

  selectedRow: number;
  public maliciousPatients: MaliciousPatient[] = new Array();
  
 

  constructor(private service: PatientService) {
    this.getMaliciousPatients();
    this.maliciousPatients = this.maliciousPatients.map(item => ({
      ...item,
      isSelected: false,
      clicked: false
    }));
   }

  ngOnInit(): void {
    
  }

  updateStatus(patientId) { 
    this.service.updatePatientStatus(new UpdatePatientBlockedStatus(patientId)).subscribe();
    //location.reload();
  }

  getMaliciousPatients(){
    this.service.getAllMaliciousPatients().subscribe(data => 
      {
        this.maliciousPatients = data
      });
  }

 

}
