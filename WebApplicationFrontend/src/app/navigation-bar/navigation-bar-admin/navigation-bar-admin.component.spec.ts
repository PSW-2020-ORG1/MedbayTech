import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavigationBarAdminComponent } from './navigation-bar-admin.component';

describe('NavigationBarAdminComponent', () => {
  let component: NavigationBarAdminComponent;
  let fixture: ComponentFixture<NavigationBarAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavigationBarAdminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavigationBarAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
