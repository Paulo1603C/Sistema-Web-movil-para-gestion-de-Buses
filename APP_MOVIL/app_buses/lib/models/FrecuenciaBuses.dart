// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';


class FrecuenciaBuses {

  int? id;
  int? idRuta;
  String? ruta;
  int? idCooperativa;
  String? cooperativa;
  String? horaSalida;
  String? horaArribo;
  String? habilitado;
  String? idUsuarioH;
  String? usuarioH;
  String? diaSemana;
  double? precio;
  FrecuenciaBuses({
    this.id,
    this.idRuta,
    this.ruta,
    this.idCooperativa,
    this.cooperativa,
    this.horaSalida,
    this.horaArribo,
    this.habilitado,
    this.idUsuarioH,
    this.usuarioH,
    this.diaSemana,
    this.precio,
  });
  


  FrecuenciaBuses copyWith({
    int? id,
    int? idRuta,
    String? ruta,
    int? idCooperativa,
    String? cooperativa,
    String? horaSalida,
    String? horaArribo,
    String? habilitado,
    String? idUsuarioH,
    String? usuarioH,
    String? diaSemana,
    double? precio,
  }) {
    return FrecuenciaBuses(
      id: id ?? this.id,
      idRuta: idRuta ?? this.idRuta,
      ruta: ruta ?? this.ruta,
      idCooperativa: idCooperativa ?? this.idCooperativa,
      cooperativa: cooperativa ?? this.cooperativa,
      horaSalida: horaSalida ?? this.horaSalida,
      horaArribo: horaArribo ?? this.horaArribo,
      habilitado: habilitado ?? this.habilitado,
      idUsuarioH: idUsuarioH ?? this.idUsuarioH,
      usuarioH: usuarioH ?? this.usuarioH,
      diaSemana: diaSemana ?? this.diaSemana,
      precio: precio ?? this.precio,
    );
  }

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'idRuta': idRuta,
      'ruta': ruta,
      'idCooperativa': idCooperativa,
      'cooperativa': cooperativa,
      'horaSalida': horaSalida,
      'horaArribo': horaArribo,
      'habilitado': habilitado,
      'idUsuarioH': idUsuarioH,
      'usuarioH': usuarioH,
      'diaSemana': diaSemana,
      'precio': precio,
    };
  }

  factory FrecuenciaBuses.fromMap(Map<String, dynamic> map) {
    return FrecuenciaBuses(
      id: map['id'] != null ? map['id'] as int : null,
      idRuta: map['idRuta'] != null ? map['idRuta'] as int : null,
      ruta: map['ruta'] != null ? map['ruta'] as String : null,
      idCooperativa: map['idCooperativa'] != null ? map['idCooperativa'] as int : null,
      cooperativa: map['cooperativa'] != null ? map['cooperativa'] as String : null,
      horaSalida: map['horaSalida'] != null ? map['horaSalida'] as String : null,
      horaArribo: map['horaArribo'] != null ? map['horaArribo'] as String : null,
      habilitado: map['habilitado'] != null ? map['habilitado'] as String : null,
      idUsuarioH: map['idUsuarioH'] != null ? map['idUsuarioH'] as String : null,
      usuarioH: map['usuarioH'] != null ? map['usuarioH'] as String : null,
      diaSemana: map['diaSemana'] != null ? map['diaSemana'] as String : null,
      precio: map['precio'] != null ? map['precio'] as double : null,
    );
  }

  String toJson() => json.encode(toMap());

  factory FrecuenciaBuses.fromJson(String source) => FrecuenciaBuses.fromMap(json.decode(source) as Map<String, dynamic>);

  @override
  String toString() {
    return 'FrecuenciaBuses(id: $id, idRuta: $idRuta, ruta: $ruta, idCooperativa: $idCooperativa, cooperativa: $cooperativa, horaSalida: $horaSalida, horaArribo: $horaArribo, habilitado: $habilitado, idUsuarioH: $idUsuarioH, usuarioH: $usuarioH, diaSemana: $diaSemana, precio: $precio)';
  }

  @override
  bool operator ==(covariant FrecuenciaBuses other) {
    if (identical(this, other)) return true;
  
    return 
      other.id == id &&
      other.idRuta == idRuta &&
      other.ruta == ruta &&
      other.idCooperativa == idCooperativa &&
      other.cooperativa == cooperativa &&
      other.horaSalida == horaSalida &&
      other.horaArribo == horaArribo &&
      other.habilitado == habilitado &&
      other.idUsuarioH == idUsuarioH &&
      other.usuarioH == usuarioH &&
      other.diaSemana == diaSemana &&
      other.precio == precio;
  }

  @override
  int get hashCode {
    return id.hashCode ^
      idRuta.hashCode ^
      ruta.hashCode ^
      idCooperativa.hashCode ^
      cooperativa.hashCode ^
      horaSalida.hashCode ^
      horaArribo.hashCode ^
      habilitado.hashCode ^
      idUsuarioH.hashCode ^
      usuarioH.hashCode ^
      diaSemana.hashCode ^
      precio.hashCode;
  }
}
