
export class ViewReportsPatientDTO {
  diagnosis: string = "";
  treatment: string = "";

  public constructor(Diagnosis: string = "", Treatment: string = "") {
    this.diagnosis = Diagnosis;
    this.treatment = Treatment;
  }


}
