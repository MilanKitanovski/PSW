
enum Gender {
  Male, Female
}
export class Register {
  name! : string;
  surname! : string;
  email!:string;
  password!:string;
  phoneNumber!:string;
  doctorId!: number;
  gender!: Gender;

  public constructor(obj?: any) {
    if (obj) {
      this.name = obj.name;
      this.surname = obj.surname;
      this.email = obj.email;
      this.password = obj.password;
      this.phoneNumber = obj.phoneNumber;
      this.doctorId = obj.doctorId;
      this.gender = obj.gender;
    }
  }
}
