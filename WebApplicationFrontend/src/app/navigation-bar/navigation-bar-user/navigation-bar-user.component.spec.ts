import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavigationBarUserComponent } from './navigation-bar-user.component';

describe('NavigationBarUserComponent', () => {
  let component: NavigationBarUserComponent;
  let fixture: ComponentFixture<NavigationBarUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavigationBarUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavigationBarUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
