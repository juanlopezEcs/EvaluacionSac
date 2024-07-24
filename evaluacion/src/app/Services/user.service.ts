import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

interface User {
  id?: number;
  firstName: string;
  lastName: string;
  email: string;
  dateOfBirth: string;
}

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient) { }

  private apiUrl = "http://localhost:5100/api/";

  loggin(data:User): Observable<User[]> {
    const url = `${this.apiUrl}Loggin/Loggin`;
    return this.http.post<User[]>(url,data)
      .pipe(
        catchError(this.handleError<User[]>('getUsers', []))
      );
  }

  getUsers(): Observable<User[]> {
    const url = `${this.apiUrl}user/Getuser`;
    const headers = new HttpHeaders().set('Accept', 'text/plain');
    return this.http.get<User[]>(url, { headers })
      .pipe(
        catchError(this.handleError<User[]>('getUsers', []))
      );
  }

  createUsers(data:User): Observable<User[]> {
    return this.http.post<User[]>(this.apiUrl+"user/PostUser",data)
      .pipe(
        catchError(this.handleError<User[]>('getUsers', []))
      );
  }

  // Manejar errores
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

}
