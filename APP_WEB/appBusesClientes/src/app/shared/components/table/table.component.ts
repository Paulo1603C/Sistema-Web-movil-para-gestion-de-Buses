import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent {
  @Input() data:any
  @Input() columns!:any[]
  @Input() url!:string
  
  
  constructor() { }

  ngOnInit(): void {
  }
}
