import { Injectable } from "@angular/core";
import { environment } from "../environments/environments";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { TestEmp } from "../Model/test.model";

@Injectable({providedIn: 'root'})

export class emplyeeServices{

  baseUrl : string = environment.baseApiUrl;

  constructor(private http: HttpClient)
  {

  }

  getAllTest2() : Observable<TestEmp>{
      return this.http.get<TestEmp>(this.baseUrl + '/api/subcription');
  }

  getAllTest() : Observable<string>{
    return this.http.get(this.baseUrl + '/api/subcription',
                                                {responseType: 'text'})
}

}
