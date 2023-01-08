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
            child: Container(
              child: listaItems(),
            ),
          ),
        ],
      ),
    );
  }

  Widget buscardor() {
    return TextField(
      enableInteractiveSelection: false,
      obscureText: true,
      decoration: InputDecoration(
        labelText: 'Buscar',
        suffixIcon: IconButton(
          onPressed: (){
            _metodoBuscar();
          },
          icon: Icon( Icons.search) ),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(15.0)),
      ),
    );
  }

  Widget moreOptionBuscar() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        Expanded(child: itemComboBox()),
        SizedBox(width: 50.0,),
        Expanded(child: buscadorFecha())
      ],
    );
  }

  Widget listaItems() {
    return ListView(
      children: [
        Column(
          mainAxisAlignment: MainAxisAlignment.center, 
          children: [
            Text(
              'Bienvenido',
              style: TextStyle(
                fontFamily: 'Verdana',
                fontWeight: FontWeight.bold,
                fontSize: 30.0,
              ),
            ),
        ]
        ),
      ],
    );
  }

  _metodoBuscar(){
    setState(() {
      print("object;");
    });
  }

  Widget buscadorFecha(){
    return TextField(
      enableInteractiveSelection: false,
      autofocus: true,
      decoration: InputDecoration(
        hintText:"12/12/2023",
        isDense: true,
        suffix: IconButton(
          onPressed: (){}, 
          icon: Icon(Icons.calendar_month),
        ),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(15.0)),
      ),
    );
  }

  Widget itemComboBox(){
    List items = ["Coperativas","Buses","Otros"];
    String? selectedValue = "Coperativas";

    return DropdownButton(
      hint: Text("Seleccione un item"),
      items: items.map( ( value ){
        return DropdownMenuItem(
          value: selectedValue,
          child: Text(value))
        ;
      } ).toList(), 
      onChanged:( String? newValue ){
        setState(() {
          selectedValue = newValue;
        });
      },
      onTap: (){},
    );
  }
}
