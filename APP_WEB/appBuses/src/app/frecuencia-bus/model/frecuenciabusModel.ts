export class Frecuenciabus {

    id: Number;
    idFrecuencia: Number;
    frecuencia: string; 
    idBus: Number;
    bus: string;
    habilitado: boolean;
    idUsuarioH: Number;
    usuarioH: string;

    constructor(id: Number, idFrecuencia: Number, frecuencia: string, idBus: Number, bus: string, habilitado: boolean, idUsuarioH: Number, usuarioH: string) {
        this.id = id;
        this.idFrecuencia = idFrecuencia;
        this.frecuencia = frecuencia;
        this.idBus = idBus;
        this.bus = bus;
        this.habilitado = habilitado;
        this.idUsuarioH = idUsuarioH;
        this.usuarioH = usuarioH;
    }

}