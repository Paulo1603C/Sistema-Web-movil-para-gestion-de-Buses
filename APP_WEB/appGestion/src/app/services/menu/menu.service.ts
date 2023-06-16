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

  private list: IMenu[] = [
    {
      number: '1',
      name: 'Usuarios',
      icon: 'bi bi-person-fill-gear',
      url: '/usuarios'
    },
    {
      number: '2',
      name: 'Cooperativas',
      icon: 'bi bi-building',
      url: '/cooperativas'
    },
    {
      number: '3',
      name: 'Rutas',
      icon: 'bi bi-bezier2',
      url: '/rutas'
    },
    {
      number: '4',
      name: 'Buses',
      icon: 'bi bi-bus-front',
      url: '/buses'
    },
    {
      number: '5',
      name: 'Frecuencias',
      icon: 'bi bi-calendar-day',
      url: '/frecuencias'
    },
    {
      number: '6',
      name: 'Asigna Frecuencia-Bus',
      icon: 'bi bi-signpost-split-fill',
      url: '/frecuenciabus'
    },
    {
      number: '7',
      name: 'Validacion Pago',
      icon: 'bi bi-cash-coin',
      url: '/validarpago'
    }
  ]

  constructor() { }

  getMenu(): IMenu[] {
    return [...this.list]
  }

  getmenuByUrl(url: string): IMenu{
    return this.list.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu
  }
}
