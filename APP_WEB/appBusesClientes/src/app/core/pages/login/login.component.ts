import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { environment } from 'src/environments/environments';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  url = environment.baseUrl
  login = false
  token = ''

  userForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  })

  constructor(private userService: UserService, private router: Router) {
  }

  ngOnInit(): void {
  }
  username:string = ''
  password:string = ''

  onSubmit(){
    const user = {
      username: this.username,
      password: this.password
    }
    this.userService.authentication(user).subscribe(data => {
      this.token = data.token
      this.login = false;
      environment.user = this.username
      console.log(environment.user)

      this.router.navigate(['/'])
    }),(error:any) => {
      console.log(error)
    }
    if(this.token == ''){
      this.login = true
    }
  }
}
