import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { Job } from 'src/app/Shared/Models/Job';
import { Login } from 'src/app/Shared/Models/Login';
import { Register } from 'src/app/Shared/Models/Register';
import { User } from 'src/app/Shared/Models/User';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable();

  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  public isLoggedIn = this.isLoggedInSubject.asObservable();

  jwtHelper = new JwtHelperService();

  constructor(private http:HttpClient) { }

  Register(registerData:Register):Observable<boolean> {
    // let headers = new HttpHeaders();
    // headers = headers.set('Ocp-Apim-Subscription-Key', 'ea23037be2ba416a9c9c368c243d2f0a');
    return this.http.post<boolean>("https://mvcapigateway.azure-api.net/authentication/api/Account/Register", registerData, {
      headers: {'Ocp-Apim-Subscription-Key':environment.subscriptionKey_new}
      // end with c510
    });
  }

  Login(loginData:Login):Observable<boolean>{
    return this.http.post<boolean>("https://mvcapigateway.azure-api.net/authentication/api/Account/Login", loginData, {
      headers: {'Ocp-Apim-Subscription-Key':environment.subscriptionKey_new}
    }).pipe(map((response: any) => {
      if (response) {
        localStorage.setItem('token', response.token);
        this.populateUserInfoFromToken();
        return true;
      }else{
        return false;
      }
    }));
  }

  Logout(){
    localStorage.removeItem('token');
    this.currentUserSubject.next({} as User);
    this.isLoggedInSubject.next(false);
  }

  populateUserInfoFromToken(){
    var tokenValue = localStorage.getItem('token');

    if (tokenValue && !this.jwtHelper.isTokenExpired(tokenValue)) {
      const decodedToken = this.jwtHelper.decodeToken(tokenValue);
      this.isLoggedInSubject.next(true);
      const newUser:User = {
        email: decodedToken.email,
        firstName: decodedToken.firstName,
        lastName: decodedToken.lastName,
        password: decodedToken.password
      };

      this.currentUserSubject.next(newUser);
    }
  }

  ValidateJWTToken() {
    var tokenValue = localStorage.getItem('token');

    if (tokenValue && !this.jwtHelper.isTokenExpired(tokenValue)) {
      // const decodedToken = this.jwtHelper.decodeToken(tokenValue);
      this.populateUserInfoFromToken();
    }
  }
}
