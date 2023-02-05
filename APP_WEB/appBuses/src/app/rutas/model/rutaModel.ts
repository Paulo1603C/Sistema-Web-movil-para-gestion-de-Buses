export class Ruta {
    id: Number;
    descripcion: string;
    idLugarOrigen: Number;
    lugarOrigen: string;
    idLugarDestino: Number;
    lugarDestino: string;



    constructor(id: Number, descripcion: string, idLugarOrigen: Number, lugarOrigen: string, idLugarDestino: Number, lugarDestino: string) 
    {
        this.id = id;
        this.descripcion = descripcion;
        this.idLugarOrigen = idLugarOrigen;
        this.lugarOrigen = lugarOrigen;
        this.idLugarDestino = idLugarDestino;
        this.lugarDestino = lugarDestino;
    }

}