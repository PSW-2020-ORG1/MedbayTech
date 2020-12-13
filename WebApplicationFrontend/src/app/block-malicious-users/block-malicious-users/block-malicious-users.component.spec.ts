import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlockMaliciousUsersComponent } from './block-malicious-users.component';

describe('BlockMaliciousUsersComponent', () => {
  let component: BlockMaliciousUsersComponent;
  let fixture: ComponentFixture<BlockMaliciousUsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlockMaliciousUsersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BlockMaliciousUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
