import {DateRange} from "./date-range.model";

enum Priority {
  DoctorPriority, TimePriority
}

enum Status{
  Pending, //kreiran, nije resen
  Canceled, //otkazan
  Finished //zavrsen
}
export class Appointment {
   id : number = 0;
   doctorId : number = 0;
   patientId : number = 0;
   range! : DateRange;
   priority! : Priority;
   status! : Status;

  public constructor(obj?: any) {
    if (obj) {
      this.id = obj.id;
      this.doctorId = obj.doctorId;
      this.patientId = obj.patientId;
      this.range = obj.range;
      this.priority = obj.priority;
      this.status = obj.status;
    }
  }
}
