export class Lugar {
    id: Number;
    nombre: string;
    latitud: Number;
    longitud: Number;
    canton: string;
    provincia: string;

    constructor(id: Number, nombre: string, latitud: Number, longitud: Number, canton: string, provincia: string) {
        this.id = id;
        this.nombre = nombre;
        this.latitud = latitud;
        this.longitud = longitud;
        this.canton = canton;
        this.provincia = provincia;
    }

}


