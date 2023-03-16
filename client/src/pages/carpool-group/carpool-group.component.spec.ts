import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarpoolGroupComponent } from './carpool-group.component';

describe('CarpoolGroupComponent', () => {
  let component: CarpoolGroupComponent;
  let fixture: ComponentFixture<CarpoolGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarpoolGroupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarpoolGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
