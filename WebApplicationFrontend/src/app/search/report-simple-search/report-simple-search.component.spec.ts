import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportSimpleSearchComponent } from './report-simple-search.component';

describe('ReportSimpleSearchComponent', () => {
  let component: ReportSimpleSearchComponent;
  let fixture: ComponentFixture<ReportSimpleSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportSimpleSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportSimpleSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
