import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { AccountCreationCommand } from "../models/accountCreationCommand";


@Injectable({ providedIn: 'root' })
export class AccountService {

  private accountUrl = 'account';
  private baseUrl: string;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;    
  }

  createAccount(command: AccountCreationCommand): Observable<string> {
    var url = this.baseUrl + this.accountUrl;
    return this.http
      .post<string>(url, command, this.httpOptions)
      .pipe(
        tap((accountId: string) => this.log(`created account w/ id=${accountId}`)),
        catchError(this.handleError<string>('createAccount'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    console.error(message);
  }
}
