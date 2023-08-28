import {DateRange} from "./date-range.model";

export class SearchAppointmentResultDTO {
  doctorId: string = "";
  date!: DateRange;
  fullName: string = "";


  public constructor(obj?: any) {
    if (obj) {
      this.doctorId = obj.doctorId;
      this.date = obj.date;
      this.fullName = obj.fullName;
    }
  }
}

