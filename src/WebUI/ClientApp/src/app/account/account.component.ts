import { Component, OnInit } from '@angular/core';
import { AccountCreationCommand } from '../models/accountCreationCommand'
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  constructor(private accountService: AccountService) { }

  ngOnInit() {
  }

  create(customerId: string, initialCredit: number): void {
    var command: AccountCreationCommand = {
      customerId: customerId,
      initialCredit: initialCredit
    }
    this.accountService.createAccount(command)
      .subscribe(accountId => {
        console.log("Account created: " + accountId)
      })
  }
}
