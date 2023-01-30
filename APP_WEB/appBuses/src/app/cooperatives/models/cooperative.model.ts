export class cooperative{
    id?: number;
    nombre: string;
    representante: string;
    telefono: string;
    correo: string;
    paginaWeb: string;

    constructor(nombre: string, representante: string, telefono: string, correo: string, paginaWeb: string){
        this.nombre = nombre;
        this.representante = representante;
        this.telefono = telefono;
        this.correo = correo;
        this.paginaWeb = paginaWeb;
    }

}