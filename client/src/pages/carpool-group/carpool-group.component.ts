import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CarpoolEntryDialogComponent } from 'src/components/dialogs/carpool-entry-dialog/carpool-entry-dialog.component';
import { DeletionDialogComponent } from 'src/components/dialogs/deletion-dialog/deletion-dialog.component';
import { CarpoolEntry } from 'src/models/interfaces/carpool-entry';

const CARPOOL_ENTRY_DATA: CarpoolEntry[] = [
  {date: new Date("2023-02-22"), name: 'Grega'},
  {date: new Date("2023-02-23"), name: 'Jan'},
  {date: new Date("2023-02-24"), name: 'Martin'},
];

@Component({
  selector: 'app-carpool-group',
  templateUrl: './carpool-group.component.html',
  styleUrls: ['./carpool-group.component.scss']
})
export class CarpoolGroupComponent {

  constructor(public dialog: MatDialog) {}

  public displayedColumns: string[] = ['date', 'name', 'actions'];
  public dataSource = CARPOOL_ENTRY_DATA;

  public editEntry(selectedRow: CarpoolEntry): void{
    console.log(selectedRow);
    const entryDialog = this.dialog.open(CarpoolEntryDialogComponent, {
      data: {name: selectedRow.name, date: selectedRow.date},
    });

    entryDialog.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
    });
  }

  public deleteEntry(selectedRow: CarpoolEntry): void{
    console.log(selectedRow);
    const deletionDialog = this.dialog.open(DeletionDialogComponent);

    deletionDialog.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(`Dialog result: ${result}`);
      if(result == true){
        console.log('test');
      }
    });
  }

  public addEntry(): void {
    const entryDialog = this.dialog.open(CarpoolEntryDialogComponent);

    entryDialog.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
    });
  }

}
