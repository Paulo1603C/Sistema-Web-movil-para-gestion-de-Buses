import { Component, Input, OnInit } from '@angular/core';
import { IMenu, MenuService } from 'src/app/services/menu/menu.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {
  @Input() sideNavStatus: boolean = false

  list: IMenu[]

  constructor(private menuService:MenuService) { 
    this.list = this.menuService.getMenu();
   }

  ngOnInit(): void {
  }

}
