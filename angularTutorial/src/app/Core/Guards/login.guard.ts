import { CanActivateChildFn } from '@angular/router';
import { AccountService } from '../Services/account.service';

var LoggedIn:boolean = false;
// push Route Guards to tomorrow
//constructor(private accountService:AccountService)

export const loginGuard: CanActivateChildFn = (childRoute, state) => {
  
  
  return true;
};
