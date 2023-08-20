export class DateRange {
  startTime!: Date;
  endTIme! : Date;

  public constructor(obj?: any) {
    if (obj) {
      this.startTime = obj.startTime;
      this.endTIme = obj.endTIme;
    }
  }
}
