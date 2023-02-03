import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  @Input() data:any;
  @Input() columns!:any[];

  @Output() onDelete: EventEmitter<any> = new EventEmitter(); 
  @Output() onEdit: EventEmitter<any> = new EventEmitter(); 
  @Output() onAbrir: EventEmitter<any> = new EventEmitter(); 
  
  pageActual: number = 1;
  
  constructor() { }

  ngOnInit(): void {
  }
 abrir(rowId:number){
  this.onAbrir.emit(rowId);
 }
 editRow(rowId:number){
  this.onEdit.emit(rowId);
 }
  deleteRow(rowId:number): void{
    Swal.fire({
      title: 'Esta Seguro de eliminar el registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, Eliminarlo!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.onDelete.emit(rowId); 
        Swal.fire(
          'Eliminado!',
          'El registro a sido eliminado.',
        )
      }
    })    
  }
}
