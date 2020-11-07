import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedFeedbackComponent } from './approved-feedback.component';

describe('ApprovedFeedbackComponent', () => {
  let component: ApprovedFeedbackComponent;
  let fixture: ComponentFixture<ApprovedFeedbackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApprovedFeedbackComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovedFeedbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
