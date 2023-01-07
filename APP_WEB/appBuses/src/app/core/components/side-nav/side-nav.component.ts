import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent {
  @Input() sideNavStatus: boolean = false
  list = [
      {
        number: '1',
        name: 'Cooperativas',
        icon: 'bi bi-building'
      },
      {
        number: '2',
        name: 'Buses',
        icon: 'bi bi-bus-front'
      },
      {
        number: '3',
        name: 'Frecuencias',
        icon: 'bi bi-signpost-split-fill'
      }
    ]
}
