import {DateRange} from "./date-range.model";

export class ViewAppointmentByPatientDTO {
  doctor: string = "";
  date!: DateRange;
  appointmentId : string = "";

  public constructor(Doctor: string = "", Date: DateRange, AppointmentId: string = ""
  ) {
    this.doctor = Doctor;
    this.date = Date;
    this.appointmentId = AppointmentId;

  }
}
