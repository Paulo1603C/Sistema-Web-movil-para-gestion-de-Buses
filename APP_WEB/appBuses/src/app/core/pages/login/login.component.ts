import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { environment } from 'src/environments/environments';
import { User } from '../../models/user.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  url = environment.baseUrl
  login = false
  token = ''

  userForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  })

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  usuario : User = {
    username: '',
    password: ''
  }
  username:string = ''
  password:string = ''

  onSubmit(){
    this.userService.authentication(new User(this.username, this.password)).subscribe(data => {
      this.token = data.token
      this.login = false;
      localStorage.setItem('IdUsuario', data.usuario.id);
      localStorage.setItem('token', data.token);
      this.router.navigate(['/inicio'])
    }),(error:any) => {
      console.log(error)
    }
    if(this.token == ''){
      this.login = true
    }
  }
}
