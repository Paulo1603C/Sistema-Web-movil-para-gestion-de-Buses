export class Categoria {
    id: Number;
    descripcion: string;
    idCooperativa: Number;
    cooperativa: string;

    constructor(id: Number, descripcion: string, idCooperativa: Number, cooperativa: string) {
        this.id = id;
        this.descripcion = descripcion;
        this.idCooperativa = idCooperativa;
        this.cooperativa = cooperativa;
    }
}


