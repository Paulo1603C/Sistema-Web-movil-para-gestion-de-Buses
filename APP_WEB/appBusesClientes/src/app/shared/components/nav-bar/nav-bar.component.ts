import { Component, OnInit } from '@angular/core';
import { IMenu, MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit{
  
  url = ''
  listMenu:IMenu[];

  constructor(private menuService:MenuService) { 
    this.listMenu = this.menuService.getMenu();
   }

   ngOnInit(): void {
    console.log(this.listMenu)
  }
}
