
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../Pages/Page/User.dart';
import '../models/Buses.dart';

class UserProviders extends ChangeNotifier{

  User? user;

  Future<void> getBuses() async {
    List<Buses> listBuses=[];
    try{
      
      var response = await http.post( Uri.parse('http://movilmitog-001-site1.etempurl.com/api/Bus' ), body: {'userName': 'DToapanta', 'password': '0990'} );

      print('Response status: ${response.statusCode}');
      print('Response body: ${response.body}');
      
    }finally{

    }
    
  }
 
}