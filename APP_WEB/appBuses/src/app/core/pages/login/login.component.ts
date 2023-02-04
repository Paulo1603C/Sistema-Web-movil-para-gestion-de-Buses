import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ToastService } from 'src/app/services/others/toast.service';
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
  token = ''

  userForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  })

  constructor(private userService: UserService, private router: Router, public toastService:ToastService) { }

  ngOnInit(): void {
  }

  usuario : User = {
    username: '',
    password: ''
  }
  username:string = ''
  password:string = ''

  onSubmit(){
    this.userService.authentication(new User(this.username, this.password)).subscribe((data) => {
      this.token = data.token
      localStorage.setItem('IdUsuario', data.usuario.id);
      localStorage.setItem('IdRol', data.usuario.idRol);
      localStorage.setItem('token', data.token);
      this.toastService.show('Bienvenido '+data.usuario.nombre+' ' +data.usuario.apellido);
      this.router.navigate(['/inicio'])
    },(error:any) => {
      this.toastService.show(error.error.result, {
        classname: 'bg-danger text-light',
        delay: 5000,
      });
      console.log(error)
    });

  }
}
