import { CanActivateChildFn } from '@angular/router';
import { AccountService } from '../Services/account.service';
import { inject } from '@angular/core';

let LoggedIn:boolean = false;
// push Route Guards to tomorrow
//constructor(private accountService:AccountService)

export const loginGuard: CanActivateChildFn = (childRoute, state) => {
  
  inject(AccountService).isLoggedIn.subscribe(data => {
    LoggedIn = data;
  });

  if (LoggedIn){
    return true;
  }
  else {
    return false;
  }

};
