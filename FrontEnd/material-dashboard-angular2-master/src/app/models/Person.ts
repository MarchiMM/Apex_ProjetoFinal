import { Company } from "./Company";

export class Person {

  constructor () {
    this.id = 0;
    this.type = '';
    this.personType = '';
    this.name = '';
    this.cpf = '';
    this.cnpj = '';
    this.companyId = 0;
    this.company = new Company();
    this.address = '';
    this.phoneNumber = '';
    this.email = '';
  }

  id: number;
  type: string;
  personType: string;
  name: string;
  cpf: string;
  cnpj: string;
  companyId: number;
  company: Company;
  address: string;
  phoneNumber: string;
  email: string;
}
