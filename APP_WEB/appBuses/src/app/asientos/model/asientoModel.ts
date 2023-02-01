export class Asiento {

    id: Number;
    idBus: Number;
    bus: string;
    orden: Number;
    descripcion: string;
    idCategoria: Number;
    categoria: string;

    constructor(id: Number, idBus: Number, bus: string, orden: Number, descripcion: string, idCategoria: Number, categoria: string) {
        this.id = id;
        this.idBus = idBus;
        this.bus = bus;
        this.orden = orden;
        this.descripcion = descripcion;
        this.idCategoria = idCategoria;
        this.categoria = categoria;
    }

}


