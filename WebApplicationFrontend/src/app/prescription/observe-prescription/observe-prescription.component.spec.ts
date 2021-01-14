import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObservePrescriptionComponent } from './observe-prescription.component';

describe('ObservePrescriptionComponent', () => {
  let component: ObservePrescriptionComponent;
  let fixture: ComponentFixture<ObservePrescriptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObservePrescriptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObservePrescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
