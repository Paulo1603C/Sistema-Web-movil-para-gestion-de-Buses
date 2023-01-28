import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import '../../models/Buses.dart';
import 'TravelInfromation.dart';
import 'package:http/http.dart' as http;

class TravelList extends StatefulWidget {
  TravelList({Key? key}) : super(key: key);

  @override
  State<TravelList> createState() => _TravelListState();
}

class _TravelListState extends State<TravelList> {
  Future<List<Buses>> listBuses() async {
      String url = 'https://actividadesuta.000webhostapp.com/Consulta.php';
      var response = await http.get(Uri.parse(url));

      if (response.statusCode == 200) {
        //var data = jsonDecode(response.body);
        print(response.body);
      }

      throw Exception('Error al obtener los datos de la API');
    }

     @override
    void initState() {
      super.initState();
      listBuses();
    }


  TextEditingController dateController = TextEditingController();
  String? buscar;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Listado de Viajes"),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        mainAxisSize: MainAxisSize.max,
        children: [
          Container(
            padding: EdgeInsets.symmetric(
              vertical: 20.0,
            ),
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
            child:_listaItems(context),
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
              if( picketDate == null ){
                print("no hay fecha");
              }else{

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
    List items = ["Coperativas", "Buses", "Otros"];
    String? selectedValue = "Coperativas";

    return DropdownButton(
      hint: Text("Seleccione un item"),
      items: items.map((value) {
        return DropdownMenuItem(value: selectedValue, child: Text(value));
      }).toList(),
      onChanged: (String? newValue) {
        setState(() {
          selectedValue = newValue;
        });
      },
      onTap: () {},
    );
  }

//plantilla para cargar el listado de los buses
  Widget _listadoBuses(BuildContext context) {

    List<Buses> listaBuses2 = [];  

    

   

    List<Buses> listaBuses = [
      Buses( "Coperativa", "Quito", "Ambato", "22/02/15-22:10","Disponible" ),
      Buses( "Coperativa", "Quito", "Ambato", "22/02/15-22:10","Lleno" ),
      Buses( "Coperativa", "Quito", "Ambato", "22/02/15-22:10","Disponible" ),
      Buses( "Coperativa", "Quito", "Ambato", "22/02/15-22:10","Lleno" ),
    ];

    return ListView.builder(
      itemCount: listaBuses.length,
      itemBuilder: (context, index) {
        return Card(
          child: Padding(
            padding: EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(child: 
                  Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children: [
                      Text( listaBuses[index].coperativa.toString() ),
                      Image.asset( "images/bus.png",width: 100, height: 100, ),
                      Text( listaBuses[index].fecha.toString() ),
                    ],
                  ),
                ),

                Expanded(child: 
                  Column(
                    children: [
                      Text( "Salida:" +listaBuses[index].salida.toString() ),
                      Text( "Llegada: " +listaBuses[index].estado.toString() ),
                      Text( listaBuses[index].llegada.toString() ),
                      Card(
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Text("5.55"),
                            SizedBox(width: 8.0,),
                            IconButton(
                              onPressed: (){
                                _screenTravleInformation();
                              }, 
                              icon: Icon( Icons.arrow_forward ),
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
    );
  }

  _screenTravleInformation(){
    setState(() {
      Navigator.of(context).push(MaterialPageRoute(builder: (context)=> TravelInformation() ));
    });
  }
}

