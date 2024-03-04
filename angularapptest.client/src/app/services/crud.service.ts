import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { School } from "../models";
import { throwError } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CRUDService {

    constructor(private http: HttpClient) { }

    readonly baseURL = 'https://localhost:7283/crud';

    getSchool(id: string | number | null | undefined) {
        return this.http.get<{ message: string, school: School }>(`${this.baseURL}/?id=${id}`)
    }

    postSchool(thisForm: School) {
        return this.http.post(this.baseURL, thisForm);
    }

    putSchool(thisForm: School) {
        return this.http.put('/crud', thisForm);
    }

    deleteSchool(id: string | number | null | undefined) {
        return this.http.delete<{ message: string, school: School }>(`${this.baseURL}/?id=${id}`)
    }
    /*
      getEmployeeList(): Observable<any> {
        return this.http.get<any>(this.baseURL)
          .pipe(
            catchError(this.errorHandler)
          );
      }
    */
    errorHandler(error: any) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        return throwError(errorMessage);
    }
}
