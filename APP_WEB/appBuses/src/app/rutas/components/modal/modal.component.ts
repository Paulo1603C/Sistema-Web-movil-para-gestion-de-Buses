import { Component } from '@angular/core';
import { Lugar } from '../../model/lugarModel';
import { FormControl, FormGroup } from '@angular/forms';
import { RutaService } from 'src/app/services/api/ruta.service';
import { Router } from '@angular/router';
import { LugarService } from 'src/app/services/api/lugar.service';
import { Ruta } from '../../model/rutaModel';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  selectedLo?: number;
  selectedLd?: number;
  lugares?: Lugar[];

  rutaForm = new FormGroup({
    id: new FormControl(''),
    descripcion: new FormControl(''),
    selectedLo: new FormControl(''),
    selectedLd: new FormControl('')
  })
  constructor(private rutaService: RutaService,
    private lugarService: LugarService) {
  }
  id: Number = 0;
  descripcion: string = '';
  idLugarOrigen: Number = 0;
  lugarOrigen: string = '';
  idLugarDestino: Number = 0;
  lugarDestino: string = '';

  borrarCampos() {
    this.rutaForm.reset();
  }
  ngOnInit(): void {
    this.loadData()
  }


  onSubmit() {
    console.log(this.selectedLo);
    var ruta = new Ruta(this.id,
      this.descripcion,
      this.selectedLo!,
      this.lugarOrigen,
      this.selectedLd!,
      this.lugarDestino
    )
    console.log(ruta);
    this.rutaService.guardarRuta(ruta).subscribe(() => {
      this.borrarCampos();
      window.location.reload();
    }), (error: any) => {
      console.log(error)
    }

  }
  loadData(){
    this.lugarService.listaLugars().subscribe(data => {
      this.lugares = data
      console.log(data)
    }), (error:any) => {
      console.log('se imprime error'+error)
    }
  }
}
