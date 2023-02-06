
import 'package:flutter/cupertino.dart';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../models/Buses.dart';

class BusesProviders extends ChangeNotifier{

  List<Buses> _listBuses= [];

  Future<void> getBuses({String? destino, String? fecha}) async {
    List<Buses> listBuses=[];
    try{
      final url = Uri.http("movilmitog-001-site1.etempurl.com","/buscar");
      final body = jsonEncode( {"origen": null,"destino": destino,"fecha": fecha,"cooperativa": null,"categoria": null}) ;
      final headers = {'Content-Type':'application/json'};
      var response = await http.post( url, body:body, headers: headers );

      var decodeBuses = jsonDecode(response.body) as List;
      decodeBuses.forEach((busess) { 
        listBuses.add( Buses( id: busess['idCooperativa'], coperativa: busess['cooperativa'], estado: busess['ramvCpn'], salida: busess['origen'], llegada: busess['destino'], fecha: busess['fecha'], precio: busess['precio'] ));
      });
      
      _listBuses = listBuses;
      notifyListeners();
      print("Busess imprexion");
      print(response.body);
    }catch(e){
      print(e);
    }
  }

  List<Buses> get BusesListado{
    return _listBuses;
  }
 
}