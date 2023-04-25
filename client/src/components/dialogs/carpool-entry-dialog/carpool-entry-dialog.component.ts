import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CarpoolEntry } from 'src/models/interfaces/carpool-entry';

@Component({
  selector: 'app-carpool-entry-dialog',
  templateUrl: './carpool-entry-dialog.component.html',
  styleUrls: ['./carpool-entry-dialog.component.scss']
})
export class CarpoolEntryDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<CarpoolEntryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CarpoolEntry,
  )
  {
    if(this.data == null){
      this.data = {name: '', date: new Date().toISOString().split('T')[0]};
    }
  }

  public closeDialog(): void {
    this.dialogRef.close();
  }

}
