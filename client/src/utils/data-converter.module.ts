import { NgModule } from "@angular/core";
import { CarpoolEntry } from "src/apis/generated/model/models";

@NgModule({})

export class DataConverterModule {

  public cleanCarpoolDates(carpoolEntries: CarpoolEntry[]) : CarpoolEntry[] {
    carpoolEntries.forEach((x) => {
      x.date = this.cleanDate(x.date!);
    });
    return carpoolEntries;
  }

  private cleanDate(dirtyDate: string){
    return dirtyDate.split('T')[0];
  }

}
