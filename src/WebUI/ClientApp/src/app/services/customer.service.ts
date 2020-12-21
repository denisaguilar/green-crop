import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customerUrl = 'customers';
  private baseUrl: string;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getCustomers(): Observable<Customer[]> {
    const url = this.baseUrl + this.customerUrl;
    return this.http.get<Customer[]>(url).pipe(
      tap(_ => this.notify('fetched customers')),
      catchError(this.handleError<Customer[]>('getCustomers', []))
    );
  }

  getCustomer(id: string): Observable<Customer> {
    const url = this.baseUrl + this.customerUrl + "/" + id;
    return this.http.get<Customer>(url).pipe(
      tap((resp: Customer) => this.notify(`fetched consumer with id ${JSON.stringify(resp)}`)),
      catchError(this.handleError<Customer>(`getCustomer id = ${id}`))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.notify(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private notify(message: string) {
    console.log(message);
  }
}
