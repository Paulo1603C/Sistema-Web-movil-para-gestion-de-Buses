
import 'dart:convert';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../Pages/Page/User.dart';
import '../models/Buses.dart';

class UserProviders extends ChangeNotifier{

  User? user;

  Future<bool> getLogIn(String user, String con) async {
    List<Buses> listBuses=[];
    final url = Uri.http("movilmitog-001-site1.etempurl.com","/api/Login/Validar");
    final body = jsonEncode({'userName': user, 'password': con});
    final headers = {'Content-Type':'application/json'};
    try{
      
      var response = await http.post( url, body:body,headers: headers );  
          print('Response status: ${response.statusCode}');
          print('Response body: ${response.body}');
      if( response.statusCode >=200 &&  response.statusCode < 300 ){
        return true;
      }


      return false;
      
    }catch( e ){
      rethrow;
    }
    
  } 
 
}