import { Component, Inject, ViewEncapsulation } from '@angular/core';
import { AsientoService } from 'src/app/services/api/asiento.service';
import { PageAsientoComponent } from '../../pages/page-asiento/page-asiento.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormControl, FormGroup } from '@angular/forms';
import { Asiento } from '../../model/asientoModel';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ModalComponent {
  idCategoria?: number;
  categorias = [
    { id: 1, nombre: 'Normal' },
    { id: 2, nombre: 'VIP' },
  ];

  title = ''
  group!: FormGroup
  asiento?: Asiento;
  Idasiento:string='';
  constructor(private reference: MatDialogRef<ModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private asientoService: AsientoService) {
    this.title = data ? 'EDICIÓN' : 'NUEVO'
    this.Idasiento=data;
    
  }

  ngOnInit(): void {
    this.cargarAsiento(this.Idasiento);
    
    
  }
  cargarAsiento(IdAsiento: string) {
    this.asientoService.obtenerAsientoPorId(IdAsiento).subscribe(data => {
      this.asiento = data
      this.loadForm()
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
    id: Number=0;
    idBus: Number=0;
    bus: string='';
    orden: Number=0;
    descripcion: string='';
    categoria: string='';
  loadForm() {
    this.group = new FormGroup({
      id: new FormControl(this.asiento?.id),
      idBus: new FormControl(this.asiento?.idBus),
      bus: new FormControl(this.asiento?.bus),
      orden: new FormControl(this.asiento?.orden),
      descripcion: new FormControl(this.asiento?.descripcion),
      idCategoria: new FormControl(this.asiento?.idCategoria),


    })
  }

  onSubmit() {
    const record = this.group.value
    this.reference.close(record)
  }


}
