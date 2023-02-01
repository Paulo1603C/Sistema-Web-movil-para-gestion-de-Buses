import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AsientoService } from 'src/app/services/api/asiento.service';
import { ModalComponent } from '../../components/modal/modal.component';
import { Asiento } from '../../model/asientoModel';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-page-asiento',
  templateUrl: './page-asiento.component.html',
  styleUrls: ['./page-asiento.component.css']
})
export class PageAsientoComponent {
  sideNavStatus: boolean = false
  data: Asiento[] = []
  IdBus:Number=0;
  IdAsiento:Number=998;
  listFields: string[] = ['bus', 'orden', 'descripcion',  'categoria']


  columns: any[] = [
    { field: 'bus', title: '' },
    { field: 'orden', title: '' },
    { field: 'descripcion', title: '' },
    { field: 'categoria', title: '' }
  ];
  constructor(private asientoService: AsientoService,
    private rutaActiva: ActivatedRoute,
    private modalService: NgbModal,
    private dialog:MatDialog,
    private snackBar:MatSnackBar,
  ) {
    
  }
  
  ngOnInit(): void {
    
    if(this.rutaActiva.params){
      this.rutaActiva.params.subscribe(
        (params: Params) => {
          this.IdBus=params['IdBus'];
          console.log("Id del bus es:"+this.IdBus);
          this.loadData()
        }
      );
    }
  }

  loadData() {
    this.asientoService.listaAsientosPorIdBus(this.IdBus).subscribe(data => {
      this.data = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  deleteData(rowId: Number) {
    
  }
  
  abrir(IdAsiento:Number){
    const options = {
      panelClass: 'panel-container',
      disableClose:true,
      data: IdAsiento
    }
    const reference: MatDialogRef<ModalComponent> = this.dialog.open(ModalComponent,options)

    reference.afterClosed().subscribe((response)=>{
      if(!response){return}
      if(response.id)
      {
        const asiento={...response}
        this.asientoService.actualizarAsiento(response.id, asiento).subscribe(()=>
        {
          this.loadData();
        this.showMessage('Registro Actualizado')
        })
        
      }else{
        const asiento={...response}
        this.asientoService.guardarAsiento(asiento).subscribe(()=>{
        this.showMessage('Registro Exitoso')
        })
        
      }
      
    })
  }
  showMessage(message:string, duration:number=5000){
    this.snackBar.open(message,'',{duration})
  }

}
