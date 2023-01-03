import 'package:flutter/material.dart';

class TravelList extends StatefulWidget {
  TravelList({Key? key}) : super(key: key);

  @override
  State<TravelList> createState() => _TravelListState();
}

class _TravelListState extends State<TravelList> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar:  AppBar(
        title: Text("Listado de Viajes"),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Container(),
          ListView(),
        ],
      ),
    );
  }
}