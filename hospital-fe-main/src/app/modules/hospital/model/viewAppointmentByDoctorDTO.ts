import {DateRange} from "./date-range.model";

export class ViewAppointmentByDoctorDTO {
  patient: string = "";
  date!: DateRange;


  public constructor(Patient: string = "", Date: DateRange
) {
      this.patient = Patient;
      this.date = Date;

  }
}
