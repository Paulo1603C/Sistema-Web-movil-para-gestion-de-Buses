import { Injectable } from '@angular/core';

export interface IMenu {
  tittle: string,
  url: string,
  icon: string
}

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private listMenu: IMenu[] = [
    { tittle: 'Rutas', url: '/rutas', icon: 'bi bi-bus-front' },
    { tittle: 'Boletos', url: '/boletos', icon: 'bi bi-ticket-fill' },
  ];

  constructor() { }

  getMenu(): IMenu[] {
    return [...this.listMenu];
  }
  
  getMenuByUrl(url: string): IMenu {
    return this.listMenu.find(menu => menu.url.toLowerCase() === url.toLowerCase()) as IMenu;
  }
}
