
import 'package:buses_movil/providers/buses_providers.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import '../../models/Buses.dart';
import '../../rutas.dart';
import 'TravelInfromation.dart';


class TravelList extends StatefulWidget {
  TravelList({Key? key}) : super(key: key);

  @override
  State<TravelList> createState() => _TravelListState();
}

class _TravelListState extends State<TravelList> {
    
  List<Buses> _listaBuses=[];  

  TextEditingController dateController = TextEditingController();
  String? buscar;
  @override
  Widget build(BuildContext context) {
    _listaBuses=Provider.of<BusesProviders>(context).BusesListado;
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

    return ListView.builder(
      itemCount: _listaBuses.length,
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
                      Text( _listaBuses[index].coperativa.toString() ),
                      Image.asset( "images/bus.png",width: 100, height: 100, ),
                      Text( _listaBuses[index].fecha.toString() ),
                    ],
                  ),
                ),

                Expanded(child: 
                  Column(
                    children: [
                      Text( "Salida:" +_listaBuses[index].salida.toString() ),
                      Text( "Llegada: " +_listaBuses[index].estado.toString() ),
                      Text( _listaBuses[index].llegada.toString() ),
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
      Navigator.of(context).push(CustomRoute(widget: TravelInformation()));
    });
  }
}
