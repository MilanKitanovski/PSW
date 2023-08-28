import {DateRange} from "./date-range.model";

enum Priority {
  octorPriority, TimePriority
}
enum Specialization{
  Dermatolog,
  Opsta_praksa,
  Kardiolog,
  Fizijatar
}

export class SpecializationSearchAppointmentDTO {
  priority: Priority;
  specialization: Specialization;
  doctorId : string = '';
  range!: DateRange;

  public constructor(doctor: string = "", rangee: DateRange) {
    this.doctorId = doctor;
    this.range = rangee;
  }
}
