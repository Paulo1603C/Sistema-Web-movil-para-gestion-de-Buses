import 'package:flutter/material.dart';

import 'TicketReport.dart';
import 'TravelList.dart';
import 'User.dart';

class Navegacion extends StatefulWidget {
  Navegacion({Key? key}) : super(key: key);

  @override
  State<Navegacion> createState() => _NavegacionState();
}

class _NavegacionState extends State<Navegacion> {
  int _pagActual=0;
  List<Widget> _paginas=[
    TravelList(),
    TicketReport(),
    User(),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.symmetric(
          horizontal:20.0,
          vertical: 20.0
        ),
        child: _paginas[_pagActual],
      ),
      bottomNavigationBar: botonesNavegacion(),
    );
    
  }

  Widget botonesNavegacion(){
    return BottomNavigationBar(
        onTap: ( index ){
          cambioPagina(index);
        },
        currentIndex:_pagActual,
        items: [
          BottomNavigationBarItem(
            icon: Icon(Icons.directions_bus),
            label: "Buses"
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.airplane_ticket),
            label: "Tickets"
          ),
          BottomNavigationBarItem(
            icon: Icon( Icons.person),
            label: 'User',  
          ),
        ],
      );
  }

  void cambioPagina( int index ){
    setState((  ){
      _pagActual = index;
    });
  }
}

