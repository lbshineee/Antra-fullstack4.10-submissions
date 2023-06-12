import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Job } from 'src/app/Shared/Models/Job';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  // how to make http request with HttpClient
  constructor(private http: HttpClient) { }

  getAllJobs():Observable<Job[]> {
    let headers = new HttpHeaders();
    //headers = headers.set('Ocp-Apim-Subscription-Key', 'ea23037be2ba416a9c9c368c243d2f0a');
    // return this.http.get<Job[]>("https://hrm2023apigateway.azure-api.net/recruiting/api/Jobs", {
    //   headers: {'Ocp-Apim-Subscription-Key':'ea23037be2ba416a9c9c368c243d2f0a'}
    // });

    return this.http.get<Job[]>("https://hrm2023apigateway.azure-api.net/recruiting/api/Jobs", {
      headers: {'Ocp-Apim-Subscription-Key':environment.subscriptionKey_new}
    });
  }
}
