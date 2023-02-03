export class Usuario{
    id: Number;
    nombre: string;
    apellido: string;
    tipoIdentificacion: string;
    numeroIdentificacion: string;
    telefono: string;
    correo: string;
    direccion: string;
    usuario: string;
    password: string;
    idRol: Number;
    rol: string;
    
    constructor(id: Number, nombre: string, apellido: string, tipoIdentificacion: string, numeroIdentificacion: string, telefono: string, correo: string, direccion: string, usuario: string, password: string, idRol: Number, rol: string){
    
        this.id=id;
        this.nombre=nombre;
        this.apellido=apellido;
        this.tipoIdentificacion=tipoIdentificacion;
        this.numeroIdentificacion=numeroIdentificacion;
        this.telefono=telefono;
        this.correo=correo;
        this.direccion=direccion;
        this.usuario=usuario;
        this.password=password;
        this.idRol=idRol;
        this.rol=rol;
    }
    

}