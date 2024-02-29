import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable, map } from 'rxjs';
import { CarpoolEntry, CarpoolEntryService } from 'src/apis/generated';
import { CarpoolEntryDialogComponent } from 'src/components/dialogs/carpool-entry-dialog/carpool-entry-dialog.component';
import { DeletionDialogComponent } from 'src/components/dialogs/deletion-dialog/deletion-dialog.component';
import { DataConverterModule } from 'src/utils/data-converter.module';

@Component({
  selector: 'app-carpool-group',
  templateUrl: './carpool-group.component.html',
  styleUrls: ['./carpool-group.component.scss']
})
export class CarpoolGroupComponent implements OnInit {

  public carpoolData!: CarpoolEntry[];
  public displayedColumns: string[] = ['date', 'name', 'actions'];
  public recommendedDriver = "TEST DRIVER";

  constructor(public dialog: MatDialog,
    public carpoolEntryApi: CarpoolEntryService,
    public http: HttpClient,
    public dataConverter: DataConverterModule) {}

  public ngOnInit(): void {
    this.initCarpoolData().subscribe(result => {
      this.carpoolData = result;
    });
  }

  public addEntry(): void {
    /*const entryDialog = this.dialog.open(CarpoolEntryDialogComponent);

    entryDialog.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
    });*/
    /*this.carpoolEntryApi.apiCarpoolEntryGet().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
    });*/

    /*const entryDialog = this.dialog.open(CarpoolEntryDialogComponent);

    entryDialog.afterClosed().subscribe(dialogResult => {
      if(dialogResult){
        this.carpoolEntryApi.apiCarpoolEntryIdPut(selectedRow.id as number).subscribe(result => {
          console.log(result);
          this.refreshCarpoolData();
        });
      }
    });*/
  }

  public editEntry(selectedRow: CarpoolEntry): void {
    const entryDialog = this.dialog.open(CarpoolEntryDialogComponent, {
      data: {name: selectedRow.name, date: selectedRow.date},
    });

    entryDialog.afterClosed().subscribe(dialogResult => {
      if(dialogResult){
        console.info("Edited value returned.");
        console.log(dialogResult);
        this.carpoolEntryApi.apiCarpoolEntryIdPut(selectedRow.id!, dialogResult).subscribe(() => {
          console.info("Editing successful.");
          this.refreshCarpoolData();
        });
      }else{
        console.info("Deletion cancelled.");
      }
    });

  }

  public deleteEntry(selectedRow: CarpoolEntry): void {
    const deletionDialog = this.dialog.open(DeletionDialogComponent);

    deletionDialog.afterClosed().subscribe(dialogResult => {
      if(dialogResult)
      {
        console.info("Deletion accepted.");
        this.carpoolEntryApi.apiCarpoolEntryIdDelete(selectedRow.id!).subscribe(() => {
          console.info("Deletion successful.");
          this.refreshCarpoolData();
        });
      }else{
        console.info("Deletion cancelled.");
      }
    });
  }

  private initCarpoolData() : Observable<CarpoolEntry[]> {
    return this.carpoolEntryApi.apiCarpoolEntryGet().pipe(map(results => {
      return this.dataConverter.cleanCarpoolDates(results);
    }));
  }

  private refreshCarpoolData() {
    this.initCarpoolData().subscribe(result => {
      this.carpoolData = result;
    });
  }

}
