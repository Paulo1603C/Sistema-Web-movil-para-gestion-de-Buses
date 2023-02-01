import { Component, OnInit, Input } from '@angular/core';
import { IMenu, MenuService } from 'src/app/services/menu.service';
import { environment } from 'src/environments/environments';
import {usuario} from 'src/app/variables'

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit{
  @Input() usuario: any
  url = ''
  login = 'login'
  user = ''
  listMenu:IMenu[];

  constructor(private menuService:MenuService) { 
    this.listMenu = this.menuService.getMenu();
    console.log(this.user)
   }

   ngOnInit(): void {
    console.log(this.listMenu)
  }
}
