import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import '../../models/Buses.dart';
import '../../providers/buses_providers.dart';
import 'TravelInfromation.dart';

class TravelList extends StatefulWidget {
  TravelList({Key? key}) : super(key: key);

  @override
  State<TravelList> createState() => _TravelListState();
}

class _TravelListState extends State<TravelList> {
  List<Buses> _listaBuses = [];

  TextEditingController dateController = TextEditingController();
  String? buscar;
  @override
  Widget build(BuildContext context) {
    _listaBuses = Provider.of<BusesProviders>(context).BusesListado;
    return Scaffold(
      appBar: AppBar(
        title: Text("Listado de Viajes"),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        mainAxisSize: MainAxisSize.max,
        children: [
          Container(
            padding: EdgeInsets.symmetric(vertical: 15.0, horizontal: 10.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              mainAxisSize: MainAxisSize.min,
              children: [
                buscardor(),
                SizedBox(
                  height: 6.0,
                ),
                moreOptionBuscar(),
              ],
            ),
          ),
          Expanded(
            child: _listaItems(context),
          ),
        ],
      ),
    );
  }

//input para buscar
  Widget buscardor() {
    return TextField(
      enableInteractiveSelection: false,
      obscureText: true,
      decoration: InputDecoration(
        labelText: 'Buscar',
        suffixIcon: IconButton(
            onPressed: () {
              _metodoBuscar();
            },
            icon: Icon(Icons.search)),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(15.0)),
      ),
    );
  }

//inputs para mas opciones de busqueda
  Widget moreOptionBuscar() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        Expanded(child: itemComboBox()),
        SizedBox(
          width: 50.0,
        ),
        Expanded(child: buscadorFecha())
      ],
    );
  }

//metodo cargara la lista de items buses;
  Widget _listaItems(BuildContext context) {
    return Container(
      child: _listadoBuses(context),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(50),
      ),
    );
  }

//medoto buscar
  _metodoBuscar() {
    setState(() {
      print("object;");
    });
  }

//widget calendart
  Widget buscadorFecha() {
    return TextField(
      controller: dateController,
      enableInteractiveSelection: false,
      autofocus: true,
      decoration: InputDecoration(
        hintText: "12/12/2023",
        isDense: true,
        suffix: IconButton(
          onPressed: () async {
            DateTime? picketDate = await showDatePicker(
                context: context,
                initialDate: DateTime.now(),
                firstDate: DateTime(2000),
                lastDate: DateTime(2101));
            if (picketDate == null) {
              print("no hay fecha");
            } else {
              String formatoDate = DateFormat('yyyy-MM-dd').format(picketDate);
              setState(() {
                dateController.text = formatoDate.toString();
              });
            }
          },
          icon: Icon(Icons.calendar_month),
        ),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(15.0)),
      ),
    );
  }

//devuelve un combo box
  Widget itemComboBox() {
    String? selectedColor = "Coperativas";

    return DropdownButton<String>(
      value: selectedColor,
      items: <String>["Coperativas", "Buses", "Otros"]
          .map<DropdownMenuItem<String>>((String value) {
        return DropdownMenuItem<String>(
          value: value,
          child: Text(value),
        );
      }).toList(),
      onChanged: ( String? newValue) {
        setState(() {
          selectedColor = newValue;
        });
      },
    );
  }

//plantilla para cargar el listado de los buses
  Widget _listadoBuses(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(10.0),
      child: ListView.builder(
        itemCount: _listaBuses.length,
        itemBuilder: (context, index) {
          return Card(
            color: Color.fromRGBO(255, 250, 240, 1),
            child: Padding(
              padding: EdgeInsets.all(8.0),
              child: Row(
                children: [
                  Expanded(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        Text(_listaBuses[index].coperativa.toString()),
                        Image.asset(
                          "assets/images/bus.png",
                          width: 100,
                          height: 100,
                        ),
                        //Text(_listaBuses[index].estado.toString()),
                        Container(
                          padding: EdgeInsets.all(10),
                          child: Card( child: Text("Disponible"), ),
                        )
                        
                      ],
                    ),
                  ),
                  Expanded(
                    child: Column(
                      children: [
                        Text("Salida:" + _listaBuses[index].salida.toString()),
                        Text("Llegada: " + _listaBuses[index].llegada.toString()),
                        Text("22/02/2023-9:00"),
                        Card(
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              Text("5.55"),
                              SizedBox(
                                width: 8.0,
                              ),
                              IconButton(
                                color: Color.fromARGB(255, 95, 75, 3),
                                onPressed: () {
                                  _screenTravleInformation();
                                },
                                icon: Icon(Icons.arrow_forward),
                              )
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          );
        },
      ),
    );
  }

  _screenTravleInformation() {
    setState(() {
      Navigator.of(context)
          .push(MaterialPageRoute(builder: (context) => TravelInformation()));
    });
  }
}
