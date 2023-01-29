import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'TicketReport.dart';
import 'TravelList.dart';
import 'User.dart';

class Navegacion extends StatefulWidget {
  Navegacion({Key? key, required this.child }) : super(key: key);
  final Widget child;
  @override
  State<Navegacion> createState() => _NavegacionState();
}

class _NavegacionState extends State<Navegacion> {
  int _pagActual=0;


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: widget.child,
      bottomNavigationBar:  BottomNavigationBar(
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
      ),
    );
    
  }


  void cambioPagina( int index ){
    switch (index) {
      case 0:
        GoRouter.of(context).go("/travellist"); 
        break;
      case 1:
        GoRouter.of(context).go("/ticketreport");
        break;
      case 2:
        GoRouter.of(context).go("/user");
        break;
      default:
    }
    setState(() => _pagActual =index);
  }

}


