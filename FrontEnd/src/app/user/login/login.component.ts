import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user = {}

  constructor(private router: Router) { }

  signin() {
    localStorage.setItem('user', JSON.stringify(this.user));
    this.router.navigate(['/inicio']);
    console.log(localStorage.getItem('user'));
  }

  ngOnInit() {
    localStorage.clear();
  }

}
