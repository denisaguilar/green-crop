import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { AccountCreationCommand } from "../models/accountCreationCommand";
import { AccountCreationResponse } from "../models/accountCreationResponse";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private accountUrl = 'accounts';
  private baseUrl: string;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  createAccount(command: AccountCreationCommand): Observable<AccountCreationResponse> {
    var url = this.baseUrl + this.accountUrl;
    return this.http
      .post<AccountCreationResponse>(url, command, this.httpOptions)
      .pipe(
        tap((resp: AccountCreationResponse) => this.notify(`Account created with id ${resp.id}`)),
        catchError(this.handleError<AccountCreationResponse>('createAccount'))
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
