import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  imageObject: Array<object> = [{
    thumbImage: 'assets/apoteka1.jpg',
    alt: 'alt of image',
  },
  {
    thumbImage: 'assets/apoteka2.jpg',
    alt: 'alt of image',
  },
  {
    thumbImage: 'assets/apoteka3.jpg',
    alt: 'alt of image',
  },
  {
    thumbImage: 'assets/apoteka4.jpg',
    alt: 'alt of image',
  }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
