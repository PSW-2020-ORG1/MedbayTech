import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObserveAppointmentComponent } from './observe-appointment.component';

describe('ObserveAppointmentComponent', () => {
  let component: ObserveAppointmentComponent;
  let fixture: ComponentFixture<ObserveAppointmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObserveAppointmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObserveAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
