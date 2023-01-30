import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/Buses.dart';
import '../../providers/buses_providers.dart';
import 'PagoBoleto.dart';

class TravelInformation extends StatefulWidget {
  TravelInformation({Key? key}) : super(key: key);

  @override
  State<TravelInformation> createState() => _TravelInformationState();
}

class _TravelInformationState extends State<TravelInformation> {
  List<Buses> _listaBuses = [];

  @override
  Widget build(BuildContext context) {
    //carga la lista
    _listaBuses = Provider.of<BusesProviders>(context).BusesListado;
    return Scaffold(
      appBar: AppBar(
        title: Text("Información de Viajes"),
      ),
      body: Column(
        children: [
          infoBus(),
          estadoAsientos(),
        ],
      ),
      floatingActionButton: botonCompra(context),
    );
  }

  Widget infoBus() {
    return Card(
      color: Color.fromRGBO(255, 250, 240, 1),
      child: Padding(
        padding: EdgeInsets.all(8.0),
        child: Row(
          children: [
            Expanded(
              child: Image.asset(
                "assets/images/bus.png",
                width: 110,
                height: 110,
              ),
            ),
            Expanded(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text("Frecuencia: " + _listaBuses[0].salida.toString(),style:TextStyle(fontFamily: "VERDANA"),),
                  Text("Hora de salida: " + _listaBuses[0].estado.toString(),style:TextStyle(fontFamily: "VERDANA")),
                  Text("Fecha: " + _listaBuses[0].llegada.toString(),style:TextStyle(fontFamily: "VERDANA")),
                  Text("Bus: " + _listaBuses[0].llegada.toString(),style:TextStyle(fontFamily: "VERDANA")),
                  Text("Coperativa: " + _listaBuses[0].llegada.toString(),style:TextStyle(fontFamily: "VERDANA")),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget estadoAsientos() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Row(
              children: [
                Image.asset(
                  "assets/images/noDisponible.png",
                  width: 110,
                  height: 110,
                ),
                Text("No disponible",style: TextStyle(fontSize: 18.0,fontFamily: "Baguet Script"),),
              ],
            ),
            Row(
              children: [
                Image.asset(
                  "assets/images/disponible.png",
                  width: 110,
                  height: 110,
                ),
                Text("Disponible",style: TextStyle(fontSize: 18.0,fontFamily: "Baguet Script"),),
              ],
            ),
          ],
        ),
        
        
      ],
    );
  }

  Widget asientosBus() {
    return Row(
      children: [
        //fila 1 de asientos
        Expanded(
          child: GridView.count(
            crossAxisCount: 3,
            children: [
              Container(color: Colors.black),
              Container(color: Colors.black),
            ]
          ),
        ),
        //fila 2 de asientos
        Expanded(
          child: GridView.count(
            crossAxisCount: 3,
            children: [
              Container(color: Colors.black),
              Container(color: Colors.black),
            ]
          ),
        ),
      ],
    );
  }


  Widget botonCompra(BuildContext context){
    return FloatingActionButton(
      onPressed: (){
      //metodo hacia la nueva pantalla
      Navigator.of(context)
          .push(MaterialPageRoute(builder: (context) => PagoBoleto()));
      },  
      child: Icon( Icons.local_mall ),
    );
  }
}
