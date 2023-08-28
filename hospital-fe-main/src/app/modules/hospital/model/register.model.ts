
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

  public constructor(name : string = '', surname:string = '', email:string = '', password:string='', phoneNumber:string = '', doctorId:number = 0) {

      this.name = name;
      this.surname = surname;
      this.email = email;
      this.password = password;
      this.phoneNumber = phoneNumber;
      this.doctorId = doctorId;

  }
}
