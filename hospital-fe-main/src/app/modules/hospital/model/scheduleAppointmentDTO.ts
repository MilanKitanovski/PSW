import {DateRange} from "./date-range.model";

enum Status{
  Pending, //kreiran, nije resen
  Canceled, //otkazan
  Finished //zavrsen
}

export class ScheduleAppointmentDTO {
  doctorId: string = "";
  range!: DateRange;


  public constructor(doctor: string = "",  rangee: DateRange) {
      this.doctorId = doctor;
      this.range = rangee;
  }
}
