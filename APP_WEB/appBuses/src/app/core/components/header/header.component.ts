import { Component, EventEmitter, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  @Output() sideNavToggle = new EventEmitter<boolean>();
  menuStatus: boolean = false

  constructor() { }

  ngOnInit(): void {
  }
  
  SideNavToggle(){
    this.menuStatus = !this.menuStatus
    this.sideNavToggle.emit(this.menuStatus)
  }
}
