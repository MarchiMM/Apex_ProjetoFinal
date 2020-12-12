export class Taxation {

  constructor () {
    this.id = 0;
    this.taxDescription = '';
    this.percentage = 0;
    this.effectiveDate = new Date();
    this.expirationDate = new Date();
  }

  id: number;
  taxDescription: string;
  percentage: number;
  effectiveDate: Date;
  expirationDate: Date;
}
