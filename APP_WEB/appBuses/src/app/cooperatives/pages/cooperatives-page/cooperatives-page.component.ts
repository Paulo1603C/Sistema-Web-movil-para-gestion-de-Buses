import { Component, OnInit} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { cooperative } from '../../models/cooperative.model';
import { CooperativeService } from '../../service/cooperative.service';

@Component({
  selector: 'app-cooperatives-page',
  templateUrl: './cooperatives-page.component.html',
  styleUrls: ['./cooperatives-page.component.css']
})
export class CooperativesPageComponent implements OnInit{
  sideNavStatus: boolean = false
  cooperativesForm = new FormGroup({
    id: new FormControl(''),
    nombre: new FormControl(''),
    representante: new FormControl(''),
    telefono: new FormControl(''),
    correo: new FormControl(''),
    paginaWeb: new FormControl('')
  })

  dataCooperatives: any[] = []
  listFields:string[] = ['ID','Nombre','Representante','Teléfono','Correo','Pagina Web'] 
  columns: any[] = [
    {field: 'id', title: 'ID'},
    { field: 'nombre', title: 'Nombre' },
    {field: 'representante', title: 'Representante'},
    {field: 'telefono', title: 'Teléfono'},
    {field: 'correo', title: 'Correo'},
    {field: 'paginaWeb', title: 'Pagina Web'}
  ];

  constructor(private cooperativeService: CooperativeService) { 
    this.loadCooperatives()
  }

  ngOnInit(): void {
  }

  loadCooperatives(){
    this.cooperativeService.loadCooperatives().subscribe(data => {
      this.dataCooperatives = data
      console.log(data)
    }), (error:any) => {
      console.log(error)
    }
  }

  id:number = 0
  nombre:string = ''
  representante:string = ''
  telefono:string = ''
  correo: string = ''
  paginaWeb:string = ''
  

  borrarCampos(){
    this.cooperativesForm.reset()
  }

  onSubmit(){
    const Cooperative = {
      nombre: this.nombre,
      representante: this.representante,
      telefono: `${this.telefono}`,
      correo: this.correo,
      paginaWeb: this.paginaWeb
    }
    console.log(Cooperative)
    this.cooperativeService.saveCooperatives(Cooperative).subscribe(res => {
      console.log(res)
      this.loadCooperatives()
      this.borrarCampos()
    }), (error: any) => {
      console.log(error)
    }
  }

  deleteCooperative(rowId: string) {
    console.log(rowId)
    this.cooperativeService.deleteCooperatives(rowId).subscribe(() => {
      this.loadCooperatives();
    });
  }
}
