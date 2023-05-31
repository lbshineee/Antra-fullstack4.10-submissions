import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Job } from 'src/app/Shared/Models/Job';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  // how to make http request with HttpClient
  constructor(private http: HttpClient) { }

  getAllJobs():Observable<Job[]> {
    let headers = new HttpHeaders();
    headers = headers.set('Ocp-Apim-Subscription-Key', '8ab900c3d6614465b6bd6f361174c510');
    return this.http.get<Job[]>("https://recruitingapigateway.azure-api.net/recruiting/api/Jobs", {
      headers: {'Ocp-Apim-Subscription-Key':'8ab900c3d6614465b6bd6f361174c510'}
    });
  }
}
