import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportsDialogComponent } from './reports-dialog.component';

describe('ReportsDialogComponent', () => {
  let component: ReportsDialogComponent;
  let fixture: ComponentFixture<ReportsDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportsDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
