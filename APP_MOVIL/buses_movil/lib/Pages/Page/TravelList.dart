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
      enableInteractiveSelection: false,
      autofocus: true,
      decoration: InputDecoration(
        hintText: "12/12/2023",
        isDense: true,
        suffix: IconButton(
          onPressed: () {},
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
    List<Buses> listaBuses = [
      Buses('ABB-569', 'James'),
      Buses('TVO-6658', 'MENDEZ'),
      Buses('CVV-9999', 'REYES'),
      Buses('CFG-1245', 'FREIRE'),
    ];

    return ListView.builder(
      itemCount: listaBuses.length,
      itemBuilder: (context, index) {
        return Card(
          child: Padding(
            padding: EdgeInsets.all(15.0),
            child: Row(
              children: [
                Container(
                  padding: EdgeInsets.symmetric(
                    horizontal: 2.0,
                    vertical: 2.0
                  ),
                  child: Column(
                    children: [
                      Text("Coperativa"),
                      SizedBox(height: 5.0,),
                      Image.asset(""),
                      SizedBox(height: 5.0,),
                      Text("Disponible"),//esto buiene de BD;
                      
                    ],
                  ),
                  ),
            
                Container(
                  padding: EdgeInsets.symmetric(
                    horizontal: 2.0,
                    vertical: 2.0
                  ),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(listaBuses[index].placa.toString()),
                      Text(listaBuses[index].Conductor.toString()),
                    ],
                  ),
                ),
              ],
            ) ,
          ),
        );
      },
    );
  }
}

//clase buses
class Buses {
  String? placa;
  String? Conductor;

  Buses(placa, coductor) {
    this.placa = placa;
    this.Conductor = coductor;
  }
}
