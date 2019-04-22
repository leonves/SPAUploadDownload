import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { AvisoService } from '../services/aviso.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {
  constructor(private router: Router,
    private avisoService: AvisoService) { }

  canActivate(): boolean {

  if (localStorage.getItem('user')) {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user.email === 'admin@admin.com' && user.password === '123') {
      return true;
    }else if(user.email === 'comum@comum.com' && user.password === '123') {
      return true;
    }
     else {
      this.avisoService.avisar("Usuário não cadastrado.");
      this.router.navigate(['/login']);
      return false;
    }
  }else{
    this.router.navigate(['/login']);
  }
  }
}
