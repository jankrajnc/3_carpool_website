import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef } from '@angular/material/dialog';
import { MaterialModule } from 'src/assets/material.module';

import { DeletionDialogComponent } from './deletion-dialog.component';

describe('DeletionDialogComponent', () => {
  let component: DeletionDialogComponent;
  let fixture: ComponentFixture<DeletionDialogComponent>;
  let dialogMock = {
    close: jasmine.createSpy('close')
    };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeletionDialogComponent ],
      imports: [MaterialModule],
      providers: [{ provide: MatDialogRef, useValue: dialogMock }]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeletionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should close the dialog when Cancel is clicked', () => {
    const cancelButton = fixture.nativeElement.querySelector('button:first-child');
    cancelButton.click();
    expect(dialogMock.close).toHaveBeenCalledWith(false);
  });

  it('should close the dialog when Delete is clicked', () => {
    const deleteButton = fixture.nativeElement.querySelector('button:last-child');
    deleteButton.click();
    expect(dialogMock.close).toHaveBeenCalledWith(true);
  });

});
