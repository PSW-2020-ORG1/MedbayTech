import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptionSimpleSearchComponent } from './prescription-simple-search.component';

describe('PrescriptionSimpleSearchComponent', () => {
  let component: PrescriptionSimpleSearchComponent;
  let fixture: ComponentFixture<PrescriptionSimpleSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrescriptionSimpleSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrescriptionSimpleSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
