import { Injectable } from '@angular/core';

export interface IMenu{
  number: string,
  name: string,
  icon: string,
  url: string
}
@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private listRol1: IMenu[] = [
    {
      number: '1',name: 'Usuarios',icon: 'bi bi-person-fill-gear',url: '/usuarios'
    },
    {
      number: '4',name: 'Buses',icon: 'bi bi-bus-front',url: '/buses'
    },
    {
      number: '6',name: 'Asigna Frecuencia-Bus',icon: 'bi bi-signpost-split-fill',url: '/frecuenciabus'
    }
  ]
  private listRol2: IMenu[] = [
    {
      number: '5',name: 'Frecuencias',icon: 'bi bi-calendar-day',url: '/frecuencias'
    }
  ]
  private listRol3: IMenu[] = [
    {
      number: '1',name: 'Usuarios',icon: 'bi bi-person-fill-gear',url: '/usuarios'
    },
    {
      number: '2',name: 'Cooperativas',icon: 'bi bi-building',url: '/cooperativas'
    },
    {
      number: '3',name: 'Rutas',icon: 'bi bi-bezier2',url: '/rutas'
    },
    {
      number: '5',name: 'Frecuencias',icon: 'bi bi-calendar-day',url: '/frecuencias'
    }
  ]
  private listRol4: IMenu[] = [
    {
      number: '7',name: 'Validacion Pago',icon: 'bi bi-cash-coin',url: '/validarpago'
    }
  ]
  private listRol5: IMenu[] = [
   
  ]
  private listRol6: IMenu[] = [
    {
      number: '1',name: 'Usuarios',icon: 'bi bi-person-fill-gear',url: '/usuarios'
    },
    {
      number: '2',name: 'Cooperativas',icon: 'bi bi-building',url: '/cooperativas'
    },
    {
      number: '3',name: 'Rutas',icon: 'bi bi-bezier2',url: '/rutas'
    },
    {
      number: '4',name: 'Buses',icon: 'bi bi-bus-front',url: '/buses'
    },
    {
      number: '5',name: 'Frecuencias',icon: 'bi bi-calendar-day',url: '/frecuencias'
    },
    {
      number: '6',name: 'Asigna Frecuencia-Bus',icon: 'bi bi-signpost-split-fill',url: '/frecuenciabus'
    },
    {
      number: '7',name: 'Validacion Pago',icon: 'bi bi-cash-coin',url: '/validarpago'
    }
  ]

  constructor() { }

  getMenu(IdRol:string): IMenu[] {

    switch (IdRol) {
      case '1':
        return [...this.listRol1]
        break;
        case '2':
          return [...this.listRol2]
        break;
        case '3':
          return [...this.listRol3]
        break;
        case '4':
          return [...this.listRol4]
        break;
        case '5':
          return [...this.listRol5]
        break;
        case '6':
          return [...this.listRol6]
        break;
      default:
        return [...this.listRol5]
        break;
    }
    
  }

  getmenuByUrl(url: string,IdRol:string): IMenu{
    switch (IdRol) {
      case '1':
        return this.listRol1.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu
        break;
        case '2':
          return this.listRol2.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu
        break;
        case '3':
          return this.listRol3.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu
        break;
        case '4':
          return this.listRol4.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu
        break;
        case '5':
          return this.listRol5.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu
        break;
        case '6':
          return this.listRol6.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu
        break;
      default:
        return this.listRol6.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu
        break;
    }
    
  }
}
