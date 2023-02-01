export class Bus {

    id: Number;
    idCooperativa: Number;
    cooperativa: string;
    numero: string;
    anio: Number;
    ramvCpn: string;
    modeloCar: string;
    marcaCh: string;
    transporte: string;
    pisos: Number;
    capacidad: Number;
    puertas: Number;
    rutaImagen: string

    constructor(id: Number, idCooperativa: Number, cooperativa: string, numero: string, anio: Number, ramvCpn: string, modeloCar: string, marcaCh: string, transporte: string, pisos: Number, capacidad: Number, puertas: Number, rutaImagen: string) {
        this.id = id;
        this.idCooperativa = idCooperativa;
        this.cooperativa = cooperativa;
        this.numero = numero;
        this.anio = anio;
        this.ramvCpn = ramvCpn;
        this.modeloCar = modeloCar;
        this.marcaCh = marcaCh;
        this.transporte = transporte;
        this.pisos = pisos;
        this.capacidad = capacidad;
        this.puertas = puertas;
        this.rutaImagen = rutaImagen;
    }

}