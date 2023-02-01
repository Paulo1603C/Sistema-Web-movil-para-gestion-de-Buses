import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/Buses.dart';
import '../../providers/buses_providers.dart';
import 'PagoBanco.dart';
import 'informacionCompra.dart';

class TravelInformation extends StatefulWidget {
  TravelInformation({Key? key}) : super(key: key);

  @override
  State<TravelInformation> createState() => _TravelInformationState();
}

class _TravelInformationState extends State<TravelInformation> {
  List<Buses> _listaBuses = [];
  List asientosSelect = [];

  @override
  Widget build(BuildContext context) {
    //carga la lista
    _listaBuses = Provider.of<BusesProviders>(context).BusesListado;
    return Scaffold(
      appBar: AppBar(
        title: Text("Información de Viajes"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            infoBus(),
            estadoAsientos(),
            asientosBus(),
          ],
        ),
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
                  Text(
                    "Frecuencia: " + _listaBuses[0].salida.toString(),
                    style: TextStyle(fontFamily: "VERDANA"),
                  ),
                  Text("Hora de salida: " + _listaBuses[0].estado.toString(),
                      style: TextStyle(fontFamily: "VERDANA")),
                  Text("Fecha: " + _listaBuses[0].llegada.toString(),
                      style: TextStyle(fontFamily: "VERDANA")),
                  Text("Bus: " + _listaBuses[0].llegada.toString(),
                      style: TextStyle(fontFamily: "VERDANA")),
                  Text("Coperativa: " + _listaBuses[0].llegada.toString(),
                      style: TextStyle(fontFamily: "VERDANA")),
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
                Text(
                  "No disponible",
                  style: TextStyle(fontSize: 18.0, fontFamily: "Baguet Script"),
                ),
              ],
            ),
            Row(
              children: [
                Image.asset(
                  "assets/images/disponible.png",
                  width: 110,
                  height: 110,
                ),
                Text(
                  "Disponible",
                  style: TextStyle(fontSize: 18.0, fontFamily: "Baguet Script"),
                ),
              ],
            ),
          ],
        ),
      ],
    );
  }

  Widget asientosBus() {
    int? _selectedIndex = 0;

    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        //fila 1 de asientos
        Container(
          height: 200,
          width: 100,
          child: GridView.count(
            crossAxisCount: 2,
            children: List.generate(24, (index) {
              return Container(
                color: _selectedIndex == index
                    ? Colors.redAccent
                    : Colors.greenAccent,
                margin: EdgeInsets.all(4),
                child: InkWell(
                  onTap: () {
                    _selectedIndex = index;
                    asientosSelect.add(_selectedIndex.toString() + "a");
                    print(asientosSelect);
                  },
                  child: Container(
                    child: Center(
                      child: Text(index.toString() + "a"),
                    ),
                  ),
                ),
              );
            }),
          ),
        ),
        //fila 2 de asientos
        SizedBox(
          width: 50,
        ),

        //Expanded(
        Container(
          height: 200,
          width: 100,
          child: GridView.count(
            crossAxisCount: 2,
            children: List.generate(24, (index) {
              return Container(
                color:
                    _selectedIndex == index ? Colors.redAccent : Colors.greenAccent,
                margin: EdgeInsets.all(4),
                child: InkWell(
                  onTap: () {
                    _selectedIndex = index;
                    asientosSelect.add(_selectedIndex.toString() + "b");
                    print(asientosSelect);
                  },
                  child: Center(
                    child: Text(index.toString() + "b"),
                  ),
                ),
              );
            }),
          ),
        )
      ],
    );
  }

  Widget botonCompra(BuildContext context) {
    return FloatingActionButton(
      onPressed: () {
        //metodo hacia la nueva pantalla
        //metodo hacia la nueva pantalla
        if (asientosSelect.length == 0) {
          _showAlertDialog();
        } else {
          Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => CompraAsientos(data: asientosSelect)));
        }
      },
      child: Icon(Icons.local_mall),
    );
  }

  void _showAlertDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Sin infirmación para compra'),
          content:
              Text('Selecione sus asientos de prefecrencia antes de continuar'),
          actions: <Widget>[
            ElevatedButton(
              child: Text('Aceptar'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
}
