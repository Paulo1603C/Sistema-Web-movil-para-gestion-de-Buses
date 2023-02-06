import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import '../models/FrecuenciaBuses.dart';

class FrecuenciaBusesProviders extends ChangeNotifier{


  Future<FrecuenciaBuses?> getFrecuencia(int id) async{
    FrecuenciaBuses FB;
    final params = {"id":id.toString()};
    final url = Uri.http("movilmitog-001-site1.etempurl.com","api/Frecuencia", params);
    final headers = {'Content-Type':'application/json'};
    var response = await http.get(url,headers: headers);

    if( response.statusCode >=200 &&  response.statusCode < 300 ){
        return FB= FrecuenciaBuses.fromJson(response.body) ;
      }
    return null;
  }

}