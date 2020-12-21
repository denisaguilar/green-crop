import { Component, OnInit } from '@angular/core';
import { AccountCreationCommand } from '../models/accountCreationCommand'
import { Customer } from '../models/customer';
import { AccountService } from '../services/account.service';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  customers: Customer[];
  selectedCustomerId: string;

  constructor(
    private accountService: AccountService,
    private customerService: CustomerService
  ) { }

  ngOnInit() {
    this.getCustomers();
    this.selectedCustomerId = this.customers[0].id
  }

  create(initialCredit: number): void {
    var command: AccountCreationCommand = {
      customerId: this.selectedCustomerId,
      initialCredit: initialCredit
    }
    this.accountService.createAccount(command)
      .subscribe();
  }

  getCustomers(): void {
    this.customerService.getCustomers()
      .subscribe(customers => this.customers = customers);
  }
}
