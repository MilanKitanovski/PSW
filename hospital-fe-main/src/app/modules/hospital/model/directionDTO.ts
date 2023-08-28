export class DirectionDTO {
  directionId: number = 0;
  spetialization: number = 0;

  public constructor(  directionId: number = 0, spetialization: number = 0 ) {
    this.directionId = directionId;
    this.spetialization = spetialization;
  }
}
