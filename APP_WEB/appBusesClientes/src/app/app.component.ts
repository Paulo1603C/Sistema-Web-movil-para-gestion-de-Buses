import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environments';
import {usuario} from 'src/app/variables'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'appBusesClientes';
  usuario = usuario
  user = ''

  constructor(){
    this.validarUser()
  }

  ngOnInit(): void {
    this.validarUser()
  }

  validarUser(){
    if (usuario == '') {
      this.user = 'Iniciar Sesión'
    }else{
      this.user = usuario
    }
    console.log(this.user)
  }
}
