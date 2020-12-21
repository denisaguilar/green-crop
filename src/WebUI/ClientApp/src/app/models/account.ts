import { Transaction } from "./Transaction";

export class Account {
  id: string;
  balance: number;
  transactions: Transaction[];
}
