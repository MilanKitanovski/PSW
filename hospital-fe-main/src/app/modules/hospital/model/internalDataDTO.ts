import {DateRange} from "./date-range.model";

export class InternalDataDTO {
  bloodPressure: string = "";
  bloodSugar: number = 0;
  fats: number = 0;
  weight: number = 0;
  menstrual!: DateRange

  public constructor(bloodP: string = "", bloodS: number = 0, fat: number = 0, weight: number = 0, menstrual: DateRange) {
    this.bloodPressure = bloodP;
    this.bloodSugar = bloodS;
    this.fats = fat;
    this.weight = weight;
    this.menstrual = menstrual;
  }


}
