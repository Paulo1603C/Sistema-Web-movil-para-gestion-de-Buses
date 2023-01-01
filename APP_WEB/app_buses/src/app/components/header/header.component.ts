import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  @Output() sideNavToggle = new EventEmitter<boolean>();
  menuStatus: boolean = false

  SideNavToggle(){
    this.menuStatus = !this.menuStatus
    this.sideNavToggle.emit(this.menuStatus)
  }
}
