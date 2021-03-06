import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from '../models/customer';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {
  customer: Customer;

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService,
  ) { }

  ngOnInit() {
    this.getCustomer();
  }

  getCustomer(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.customerService.getCustomer(id)
      .subscribe(customer => this.customer = customer);
  }
}
