import 'dart:io';
import 'package:flutter/cupertino.dart';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../models/Buses.dart';

class BusesProviders extends ChangeNotifier{

  List<Buses> _listBuses= [];

  Future<void> getBuses() async {
    List<Buses> listBuses=[];
    try{
      var response = await http.get( Uri.parse('http://movilmitog-001-site1.etempurl.com/api/Bus' ));
      var decodeBuses = jsonDecode(response.body) as List;
      decodeBuses.forEach((busess) { 
        listBuses.add( Buses(coperativa: busess['cooperativa'], estado: busess['cooperativa'], salida: busess['cooperativa'], llegada: busess['transporte'], fecha: busess['modeloCar']));
      });
      
      _listBuses = listBuses;
      print("Busess imprexion");
      print(_listBuses[0]);
    }finally{
    }
  }

  List<Buses> get BusesListado{
    return _listBuses;
  }
 
}