import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavigationBarPatientComponent } from './navigation-bar-patient.component';

describe('NavigationBarPatientComponent', () => {
  let component: NavigationBarPatientComponent;
  let fixture: ComponentFixture<NavigationBarPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavigationBarPatientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavigationBarPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
