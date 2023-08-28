import {DateRange} from "./date-range.model";

export class SearchAppointmentDTO {
  doctorId!: string ;
  range! : DateRange;


  public constructor(range : DateRange) {
      this.range = range;
    }

}
