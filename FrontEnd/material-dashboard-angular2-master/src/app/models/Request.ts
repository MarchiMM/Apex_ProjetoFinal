import { Equipment } from "./Equipment";
import { Person } from "./Person";

export class Request {

  constructor () {
    this.id = 0;
    this.status = '';
    this.personId = 0;
    this.person = new Person();
    this.equipmentId = 0;
    this.equipment = new Equipment();
    this.demand = '';
    this.serviceDescription = '';
    this.value = 0;
  }

  id: number;
  status: string;
  personId: number;
  person: Person;
  equipmentId: number;
  equipment: Equipment;
  demand: string;
  serviceDescription: string;
  value: number;
}