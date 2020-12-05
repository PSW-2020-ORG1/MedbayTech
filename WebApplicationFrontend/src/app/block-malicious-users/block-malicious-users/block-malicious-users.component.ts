import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-block-malicious-users',
  templateUrl: './block-malicious-users.component.html',
  styleUrls: ['./block-malicious-users.component.css']
})
export class BlockMaliciousUsersComponent implements OnInit {

  selectedRow: number;
  
  dataSource = [{ id: "3012235234123", username: "stefan23", name: "Stefan", surname: "Petrovic"},
                { id: "2351235212421", username: "marko998", name: "Marko", surname: "Markovic"}];

  constructor() {
    this.dataSource = this.dataSource.map(item => ({
      ...item,
      isSelected: false,
      clicked: false
    }));
   }

  ngOnInit(): void {
  }

 

}
