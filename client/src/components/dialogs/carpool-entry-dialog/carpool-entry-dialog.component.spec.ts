import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarpoolEntryDialogComponent } from './carpool-entry-dialog.component';

describe('CarpoolEntryDialogComponent', () => {
  let component: CarpoolEntryDialogComponent;
  let fixture: ComponentFixture<CarpoolEntryDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarpoolEntryDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarpoolEntryDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
