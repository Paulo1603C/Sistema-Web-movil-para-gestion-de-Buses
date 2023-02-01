export class Frecuencia {

    id: Number;
    idRuta: Number;
    ruta: string;
    idCooperativa: Number;
    cooperativa: string;
    horaSalida: string;
    horaArribo: string;
    habilitado: boolean;
    idUsuarioH: Number;
    usuarioH: string;
    diaSemana: string;
    precio: Number;
    constructor(id: Number, idRuta: Number, ruta: string, idCooperativa: Number, cooperativa: string, horaSalida: string, horaArribo: string, habilitado: boolean, idUsuarioH: Number, usuarioH: string, diaSemana: string, precio: Number) {
        this.id = id;
        this.idRuta = idRuta;
        this.ruta = ruta;
        this.idCooperativa = idCooperativa;
        this.cooperativa = cooperativa;
        this.horaSalida = horaSalida;
        this.horaArribo = horaArribo;
        this.habilitado = habilitado;
        this.idUsuarioH = idUsuarioH;
        this.usuarioH = usuarioH;
        this.diaSemana = diaSemana;
        this.precio = precio;
    }

}