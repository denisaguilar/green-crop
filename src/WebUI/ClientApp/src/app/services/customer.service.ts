import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Customer } from '../models/customer';
import { NotifierService } from './notifier.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customerUrl = 'customers';
  private baseUrl: string;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, private notifier: NotifierService, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getCustomers(): Observable<Customer[]> {
    const url = this.baseUrl + this.customerUrl;
    return this.http.get<Customer[]>(url).pipe(
      tap(_ => this.notifier.add('fetched customers')),
      catchError(this.handleError<Customer[]>('getCustomers', []))
    );
  }

  getCustomer(id: string): Observable<Customer> {
    const url = this.baseUrl + this.customerUrl + "/" + id;
    return this.http.get<Customer>(url).pipe(
      tap((resp: Customer) => this.notifier.add(`fetched customer with id ${resp.id}`)),
      catchError(this.handleError<Customer>(`getCustomer id = ${id}`))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.notifier.add(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
