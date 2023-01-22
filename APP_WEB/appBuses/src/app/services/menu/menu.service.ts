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
      name: 'Cooperativas',
      icon: 'bi bi-building',
      url: '/cooperativas'
    },
    {
      number: '2',
      name: 'Buses',
      icon: 'bi bi-bus-front',
      url: '/buses'
    },
    {
      number: '3',
      name: 'Frecuencias',
      icon: 'bi bi-signpost-split-fill',
      url: '/frecuencias'
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
