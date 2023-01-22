import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { environment } from 'src/environments/environments';
import { Login } from '../../models/login.model';
import { ServicesService } from '../../services/services.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  url = environment.baseUrl;
  group!: FormGroup;
  loginVar?: Login;
  constructor(private login: ServicesService) {}

  ngOnInit(): void {
       this.loadForm();
  }
  validateLogin() {
    this.loginVar = new Login(
      this.group.value.userName,
      this.group.value.password
    );
    this.login.validateLogin(this.loginVar).subscribe(() => {
      alert('Registro exitoso')
    });

  }
  loadForm() {
    this.group = new FormGroup({
      userName: new FormControl(),
      password: new FormControl(),
    });
  }
}
