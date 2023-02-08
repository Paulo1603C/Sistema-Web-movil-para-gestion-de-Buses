# Documentación Desarrollador
## Aplicación Movil - Cliente
### Clases
* Login
    * logInMarin.dart
* Page
    * PagoBoleto.dart
    * scaffoldWithNavBar.dart
    * TicketPayment.dart
    * TicketReport.dart
    * TravelIformation.dart
    * TravelList.dart
    * User.dart
* providers
    * buses_providers.dart
    * UserProviders.dart
* color_schemas.g.dart
* main.dart
* models
    * Buses.dart
    * User.dart

## Programacion
La clase Buses Cuenta con 5 atributos que son coperativa, estado, salida, llegada, fecha. Se usa la palabra required para que sean obligarotios para que funcione el metodo.
``` Swift
class Buses {
  String? coperativa;
  String? estado;
  String? salida;
  String? llegada;
  String? fecha;

  Buses( {required this.coperativa, required this.estado, required this.salida, required this.llegada, required this.fecha} );
```
-------------------------------------------------
 La clase User Cuenta con 2 atributos que son name,pass . Se usa la palabra required para que sean obligarotios usar los atributos para que funcione
``` Swift
class User{
  String name;
  String pass;

  User({ required this.name, required this.pass })
  ```
-------------------------------- 
Este código es una clase en Dart que define un widget en Flutter llamado "LogIn". Es un widget de estado, lo que significa que su apariencia y comportamiento pueden cambiar a lo largo del tiempo.

La clase "LogIn" tiene un constructor opcional que acepta un parámetro "key". Luego, llama al constructor de la superclase "StatefulWidget" con el parámetro "key".

El método "createState" devuelve una nueva instancia de la clase interna "_LogInState", que es el estado asociado con el widget "LogIn". Esta clase es responsable de mantener el estado de la interfaz de usuario y controlar cualquier cambio en el mismo.
``` Swift
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';


class LogIn extends StatefulWidget {
  LogIn({Key? key}) : super(key: key);

  @override
  State<LogIn> createState() => _LogInState();
}
``` 
---
Este código define una clase _LogInState que extiende la clase State para un widget LogIn. La clase _LogInState tiene dos controladores de texto _nombre y _contrasena para controlar los valores de los campos de texto de nombre de usuario y contraseña, respectivamente.

Además, hay dos variables de cadena _usu y _con para almacenar los valores de nombre de usuario y contraseña, respectivamente. La clase _LogInState implementa el método build que construye y devuelve un widget para mostrar una página de inicio de sesión con una barra de navegación, un fondo de color, una lista de vistas y varios elementos de formulario.

Estos elementos incluyen: una imagen de logo, un título de bienvenida, un subtítulo para ingresar credenciales, dos campos de texto para nombre de usuario y contraseña, y un botón para iniciar sesión. Al presionar el botón de inicio de sesión, se verifica si los campos de nombre de usuario y contraseña están vacíos. Si no están vacíos, se navega a una nueva página /travellist usando GoRouter.of(context).go('/travellist').

Además, también se utilizan dos controllers para los campos de texto: _nombre y _contraseña. Estos controllers permiten obtener y manipular el texto que se ingresa en los campos. También hay una función llamada _verContraseña que podría usarse para mostrar o ocultar la contraseña, aunque en este caso solo se está imprimiendo un mensaje en la consola. En resumen, este código implementa una página de inicio de sesión que permite a los usuarios ingresar su nombre de usuario y contraseña para iniciar sesión y navegar a una página diferente.
``` Swift
class _LogInState extends State<LogIn> {
  final _nombre = TextEditingController();
  final _contrasena = TextEditingController();

  String _usu = '';
  String _con = '';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('LogIn'),
        ),
        backgroundColor: Color.fromARGB(255, 231, 237, 240),
        body: ListView(
          padding: EdgeInsets.symmetric(
            horizontal: 30.0,
            vertical: 5.0,
          ),
          children: [
            Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                CircleAvatar(
                  radius: 110.1,
                  backgroundColor: Colors.transparent,
                  child: Image.asset('assets/images/logo.jpg'),
                  //backgroundImage: ,
                ),
                Text(
                  'Bienvenido',
                  style: TextStyle(
                    fontFamily: 'Verdana',
                    fontWeight: FontWeight.bold,
                    fontSize: 30.0,
                  ),
                ),
                SizedBox(
                  height: 5.0,
                ),
                Text(
                  'Ingrese sus credenciales',
                  style: TextStyle(
                      fontFamily: 'Verdana',
                      fontSize: 18.0,
                      color: Colors.deepPurple),
                ),
                SizedBox(height: 18.0),
                _inputUser(),
                SizedBox(height: 18.0),
                _inputPasword(),
                SizedBox(height: 18.0),
                _btnLogIn(),
              ],
            )
          ],
        ));
  }

  Widget _inputUser() {
    return TextField(
      controller: _nombre,
      enableInteractiveSelection: false,
      autofocus: true,
      textCapitalization: TextCapitalization.characters,
      decoration: InputDecoration(
        labelText: 'User',
        suffixIcon: Icon(Icons.person),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(20.0)),
      ),
    );
  }

  Widget _inputPasword() {
    return TextField(
      controller: _contrasena,
      enableInteractiveSelection: false,
      obscureText: true,
      decoration: InputDecoration(
        labelText: 'Contaseña',
        suffixIcon: IconButton(
          onPressed: (() {
            _verContrasena();
          }),
          icon: Icon(Icons.remove_red_eye_sharp),
        ),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(20.0)),
      ),
    );
  }

  Widget _btnLogIn() {
    return Container(
      width: double.infinity,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
      ),
      child: ElevatedButton(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Text(
            'Ingresar',
            style: TextStyle(
                //color: Colors.white,
                fontFamily: 'Verdana',
                fontWeight: FontWeight.bold,
                fontSize: 30.0),
          ),
        ),
        onPressed: () {
          //
          _usu = _nombre.text;
          _con = _contrasena.text;
          if (_usu == '' || _con == '') {
            print("vacio");
          } else {
            GoRouter.of(context).go('/travellist');
          }
        },
      ),
    );
  }

  _verContrasena() {
    setState(() {
      print('ver contraseña');
    });
  }




}
  ```
Este código es una clase Flutter llamada PagoBoleto que representa una pantalla para realizar un pago de boleto. La clase extende de StatefulWidget porque su contenido es susceptible de cambiar.

La clase contiene un método build que devuelve la vista que se mostrará en la pantalla. La vista contiene una barra de navegación AppBar con el título "Pago de Boleto", un Column que contiene una imagen de logo de una tarjeta de crédito y un formulario de pago. El formulario de pago contiene cuatro TextFields para ingresar información de la tarjeta de crédito y un botón flotante FloatingActionButton que navega a una nueva página al presionarlo.

La nueva página se navega mediante GoRouter.of(context).go("/ticketreport"), que es un método de la biblioteca go_router. Este método toma el contexto actual y navega a la ruta "/ticketreport", que probablemente representa la página siguiente después del pago exitoso.

``` Swift
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'TicketReport.dart';

class PagoBoleto extends StatefulWidget {
  PagoBoleto({Key? key}) : super(key: key);

  @override
  State<PagoBoleto> createState() => _PagoBoletoState();
}

class _PagoBoletoState extends State<PagoBoleto> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Pago de Boleto"),
      ),
      body: Column(
        children: [
          imgFormasPago(),

          SizedBox(height: 20,),

          formularioPago(),
        ],
      ),
      floatingActionButton: botonCompra(context),
    );
    ;
  }

  Widget formularioPago() {
    return Container(
      padding: EdgeInsets.symmetric(vertical: 15.0, horizontal: 20.0),
      child: Form(
          child: Column(
        children: [
          TextField(
            enableInteractiveSelection: false,
            obscureText: true,
            decoration: InputDecoration(
              prefixIcon: Icon(Icons.person),
              hintText: "Nombre y Apellido",
              isDense: true,
              border:
                  OutlineInputBorder(borderRadius: BorderRadius.circular(18.0)),
            ),
          ),
          SizedBox(
            height: 10,
          ),
          TextField(
            enableInteractiveSelection: false,
            obscureText: true,
            decoration: InputDecoration(
              prefixIcon: Icon(Icons.credit_card),
              hintText: "Numero de tarjeta",
              isDense: true,
              border:
                  OutlineInputBorder(borderRadius: BorderRadius.circular(18.0)),
            ),
          ),
          SizedBox(
            height: 10,
          ),
          Row(
            children: [
              Expanded(
                child: TextField(
                  enableInteractiveSelection: false,
                  obscureText: true,
                  decoration: InputDecoration(
                    prefixIcon: Icon(Icons.calendar_month),
                    hintText: "MM/AA",
                    isDense: true,
                    border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(18.0)),
                  ),
                ),
              ),
              SizedBox(
                width: 20,
              ),
              Expanded(
                child: TextField(
                  enableInteractiveSelection: false,
                  obscureText: true,
                  decoration: InputDecoration(
                    prefixIcon: Icon(Icons.shopping_bag),
                    hintText: "CVC",
                    isDense: true,
                    border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(18.0)),
                  ),
                ),
              )
            ],
          )
        ],
      )),
    );
  }

  Widget imgFormasPago() {
    return Container(
      child: Row(
        children: [
          Expanded(
            child: Image.asset(
              "assets/images/mc.png",
              width: 65,
              height: 65,
            ),
          ),
        ],
      ),
    );
  }

  Widget botonCompra(BuildContext context) {
    return FloatingActionButton(
      onPressed: () {
        //metodo hacia la nueva pantalla
        GoRouter.of(context).go("/ticketreport");
      },
      child: Icon(Icons.paid_sharp),
    );
  }
}
```
---------
Este código implementa un componente Navegacion en Flutter, que muestra una barra de navegación en la parte inferior de la pantalla. Este componente usa el paquete go_router para cambiar entre diferentes rutas o páginas de la aplicación.

El componente Navegacion es un StatefulWidget y tiene una propiedad child que permite especificar un widget hijo que se mostrará en el cuerpo de la pantalla.

La barra de navegación se define usando un BottomNavigationBar y se compone de tres elementos: "Buses", "Tickets" y "User". Cada elemento es un objeto BottomNavigationBarItem que tiene un ícono y una etiqueta asociada.

El estado de la barra de navegación se guarda en la variable _pagActual, que indica el índice del elemento seleccionado en la barra. Cada vez que se toca un elemento en la barra, se llama a la función cambioPagina que se encarga de actualizar la variable _pagActual y cambiar a la ruta correspondiente usando GoRouter.of(context).go().

La aplicación tiene tres rutas diferentes: /travellist, /ticketreport y /user, que corresponden a las páginas de "Buses", "Tickets" y "User".
``` Swift
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
```
---------
Este código define una clase de widget de Flutter llamada "TravelPayment". Esta clase es un widget de tipo "StatefulWidget" lo que significa que mantiene un estado interno que puede cambiar dinámicamente durante la ejecución de la aplicación.

La clase "_TravelPaymentState" es la clase correspondiente al estado del widget "TravelPayment". La función "build" de esta clase define la estructura visual de la página. En este caso, se devuelve un "Container" que contiene un "Text" con el mensaje "Travel Payment" y con un estilo determinado.
``` Swift
import 'package:flutter/material.dart';

class TravelPayment extends StatefulWidget {
  TravelPayment({Key? key}) : super(key: key);

  @override
  State<TravelPayment> createState() => _TravelPaymentState();
}

class _TravelPaymentState extends State<TravelPayment> {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: Text("Travel Payment",
        style: TextStyle(
          fontFamily: "verdana",
          fontSize: 25.0
        ),  
    ),
    );
  }
}
```

---------
Este código es una clase TicketReport en Flutter que extiende de StatefulWidget y define una clase _TicketReportState que es la clase de estado correspondiente para esta clase. La clase TicketReport es un widget que se usa para mostrar un informe sobre los boletos.

El método build en la clase _TicketReportState se utiliza para crear la interfaz de usuario para la clase TicketReport. En este caso, se devuelve un Scaffold con un AppBar que muestra un título de "Reporte del Boleto".
``` Swift
import 'package:flutter/material.dart';

class TicketReport extends StatefulWidget {
  TicketReport({Key? key}) : super(key: key);

  @override
  State<TicketReport> createState() => _TicketReportState();
}

class _TicketReportState extends State<TicketReport> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar:  AppBar(
        title: Text("Reprote del Boleto"),
      ),
    );
  }
}
```

---------
El código presenta una clase llamada TravelInformation que es un widget de la aplicación de Flutter. La clase utiliza el patrón de diseño StatefulWidget ya que el contenido de la pantalla puede cambiar en tiempo de ejecución.

La clase TravelInformation tiene una clase anidada llamada _TravelInformationState que extiende State<TravelInformation> y sobreescribe el método build que devuelve la vista de la pantalla.

La vista de la pantalla está compuesta por una barra de título AppBar, un cuerpo Column que contiene dos widgets, y un botón flotante FloatingActionButton.

El primer widget en el cuerpo Column es una tarjeta Card llamada infoBus que muestra información sobre un autobús. La información se obtiene a través del proveedor de datos BusesProviders que es una clase que contiene una lista de objetos de tipo Buses.

El segundo widget en el cuerpo Column es estadoAsientos que muestra dos imágenes y textos para indicar el estado de los asientos del autobús.

El botón flotante FloatingActionButton tiene una acción asociada con su presión, que navegará a una nueva pantalla llamada PagoBoleto.

En resumen, el código presenta una pantalla que muestra información sobre un viaje en autobús y permite al usuario navegar a una nueva pantalla para comprar un boleto.
``` Swift
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
```
El código que proporcionó es una aplicación Flutter que muestra una lista de viajes en autobús. Utiliza un TextField para la búsqueda y un DropdownButton para filtrar los viajes por tipo de vehículo ("Coperativas", "Buses", "Otros"). La función de búsqueda y la función de filtrado aún no se han implementado. El código utiliza un widget Scaffold para proporcionar una estructura básica de diseño, con una barra de aplicaciones y un cuerpo que consta de una barra de búsqueda y una lista de viajes en autobús. Los viajes en autobús se obtienen de una clase BusesProviders que se accede a través del paquete Provider. Los viajes se muestran en un widget ListView.
---------
``` Swift
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
        mainAxisAlignment: MainAxisAlignment.start,
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
    return ListView.builder(
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
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(_listaBuses[index].coperativa.toString()),
                      Image.asset(
                        "assets/images/bus.png",
                        width: 100,
                        height: 100,
                      ),
                      Text(_listaBuses[index].fecha.toString()),
                    ],
                  ),
                ),
                Expanded(
                  child: Column(
                    children: [
                      Text("Salida:" + _listaBuses[index].salida.toString()),
                      Text("Llegada: " + _listaBuses[index].estado.toString()),
                      Text(_listaBuses[index].llegada.toString()),
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
    );
  }

  _screenTravleInformation() {
    setState(() {
      Navigator.of(context)
          .push(MaterialPageRoute(builder: (context) => TravelInformation()));
    });
  }
}
```

---------
Este código es una aplicación Flutter que muestra la pantalla de información de un usuario. Utiliza un widget Scaffold para proporcionar una estructura básica de la interfaz de usuario, con una barra de aplicaciones y un cuerpo que consiste en un título.

La clase User es un StatefulWidget que extiende de la clase base StatefulWidget de Flutter. La clase _UserState es una clase que extiende de State<User> y es responsable de la construcción de la interfaz de usuario a través del método build.

El método build crea una instancia de Scaffold y establece la barra de aplicaciones con un título "Información User". La estructura resultante proporciona una base para la pantalla de información de usuario.
``` Swift
import 'package:flutter/material.dart';


class User extends StatefulWidget {
  User({Key? key}) : super(key: key);

  @override
  State<User> createState() => _UserState();
}

class _UserState extends State<User> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar:  AppBar(
        title: Text("Información User"),
      ),
    );
  }
}
```
---------
Este código es una clase que se llama "BusesProviders" en Flutter. La clase hereda de la clase "ChangeNotifier" que se encuentra en el paquete "material.dart". La clase tiene una lista de objetos "Buses" llamada "_listBuses" que se utiliza para almacenar información sobre los autobuses.

La clase tiene un método "getBuses" que se utiliza para obtener información de una API externa a través de una llamada "GET" utilizando el paquete "http". La respuesta se decodifica y se almacena en una lista de objetos "Buses". La información decodificada se asigna a la lista "_listBuses" y se imprime en la consola.

Además, la clase tiene un getter "BusesListado" que se utiliza para obtener la lista "_listBuses". La clase "BusesProviders" es un proveedor que se puede utilizar para proporcionar acceso a información sobre autobuses a otras partes de la aplicación.
``` Swift
import 'dart:io';
import 'package:flutter/cupertino.dart';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../models/Buses.dart';

class BusesProviders extends ChangeNotifier{

  List<Buses> _listBuses= [];

  Future<void> getBuses() async {
    List<Buses> listBuses=[];
    try{
      var response = await http.get( Uri.parse('http://movilmitog-001-site1.etempurl.com/api/Bus' ));
      var decodeBuses = jsonDecode(response.body) as List;
      decodeBuses.forEach((busess) { 
        listBuses.add( Buses(coperativa: busess['cooperativa'], estado: busess['cooperativa'], salida: busess['cooperativa'], llegada: busess['transporte'], fecha: busess['modeloCar']));
      });
      
      _listBuses = listBuses;
      print("Busess imprexion");
      print(_listBuses[0]);
    }finally{
    }
  }

  List<Buses> get BusesListado{
    return _listBuses;
  }
 
}
```
---------
Este código es una clase llamada "UserProviders" que extiende la clase "ChangeNotifier" de la biblioteca "flutter/material.dart". La clase "UserProviders" se utiliza para manejar la información del usuario.

La clase tiene una propiedad "user" de tipo "User" que es opcional. También tiene un método "getBuses" que hace una solicitud HTTP POST a una URL específica y envía algunos datos de inicio de sesión. La respuesta a la solicitud se imprime en la consola para verificar su estado y su cuerpo.

La clase "UserProviders" es una clase de proveedor que proporciona un punto central para acceder y manejar la información del usuario en la aplicación. Al extender la clase "ChangeNotifier", "UserProviders" también proporciona una forma de notificar a otros widgets interesados en los cambios en la información del usuario.
``` Swift
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../Pages/Page/User.dart';
import '../models/Buses.dart';

class UserProviders extends ChangeNotifier{

  User? user;

  Future<void> getBuses() async {
    List<Buses> listBuses=[];
    try{
      
      var response = await http.post( Uri.parse('http://movilmitog-001-site1.etempurl.com/api/Bus' ), body: {'userName': 'DToapanta', 'password': '0990'} );

      print('Response status: ${response.statusCode}');
      print('Response body: ${response.body}');
      
    }finally{

    }
    
  }
 
}
```
---------
Este código define dos objetos ColorScheme, lightColorScheme y darkColorScheme. Estos objetos ColorScheme se utilizan para definir los colores de la interfaz de usuario de una aplicación de Flutter, dependiendo de si la brillantez de la aplicación se establece en Brightness.light o Brightness.dark.

Cada objeto ColorScheme contiene un conjunto de colores nombrados que se pueden usar para dar estilo a diversos elementos de la IU, como texto, botones y fondos. Por ejemplo, primary se usa para definir el color principal de la aplicación, mientras que onPrimary se usa para definir el color del texto colocado encima del color principal.

En este código, tanto el esquema de colores claro como el oscuro definen una gama de colores que se utilizan para dar estilo a diversos elementos de la IU de la aplicación. Los colores exactos que se utilizan en los esquemas se determinan por los valores RGB definidos para cada color.
``` Swift
import 'package:flutter/material.dart';

const lightColorScheme = ColorScheme(
  brightness: Brightness.light,
  primary: Color(0xFF3252D1),
  onPrimary: Color(0xFFFFFFFF),
  primaryContainer: Color(0xFFDDE1FF),
  onPrimaryContainer: Color(0xFF001356),
  secondary: Color(0xFF5A5D72),
  onSecondary: Color(0xFFFFFFFF),
  secondaryContainer: Color(0xFFDFE1F9),
  onSecondaryContainer: Color(0xFF171B2C),
  tertiary: Color(0xFF76546E),
  onTertiary: Color(0xFFFFFFFF),
  tertiaryContainer: Color(0xFFFFD7F3),
  onTertiaryContainer: Color(0xFF2C1229),
  error: Color(0xFFBA1A1A),
  errorContainer: Color(0xFFFFDAD6),
  onError: Color(0xFFFFFFFF),
  onErrorContainer: Color(0xFF410002),
  background: Color(0xFFFEFBFF),
  onBackground: Color(0xFF1B1B1F),
  surface: Color(0xFFFEFBFF),
  onSurface: Color(0xFF1B1B1F),
  surfaceVariant: Color(0xFFE2E1EC),
  onSurfaceVariant: Color(0xFF45464F),
  outline: Color(0xFF767680),
  onInverseSurface: Color(0xFFF3F0F4),
  inverseSurface: Color(0xFF303034),
  inversePrimary: Color(0xFFB9C3FF),
  shadow: Color(0xFF000000),
  surfaceTint: Color(0xFF3252D1),
  outlineVariant: Color(0xFFC6C5D0),
  scrim: Color(0xFF000000),
);

const darkColorScheme = ColorScheme(
  brightness: Brightness.dark,
  primary: Color(0xFFB9C3FF),
  onPrimary: Color(0xFF002388),
  primaryContainer: Color(0xFF0B36B9),
  onPrimaryContainer: Color(0xFFDDE1FF),
  secondary: Color(0xFFC3C5DD),
  onSecondary: Color(0xFF2C2F42),
  secondaryContainer: Color(0xFF424659),
  onSecondaryContainer: Color(0xFFDFE1F9),
  tertiary: Color(0xFFE5BAD9),
  onTertiary: Color(0xFF44263E),
  tertiaryContainer: Color(0xFF5C3C56),
  onTertiaryContainer: Color(0xFFFFD7F3),
  error: Color(0xFFFFB4AB),
  errorContainer: Color(0xFF93000A),
  onError: Color(0xFF690005),
  onErrorContainer: Color(0xFFFFDAD6),
  background: Color(0xFF1B1B1F),
  onBackground: Color(0xFFE4E1E6),
  surface: Color(0xFF1B1B1F),
  onSurface: Color(0xFFE4E1E6),
  surfaceVariant: Color(0xFF45464F),
  onSurfaceVariant: Color(0xFFC6C5D0),
  outline: Color(0xFF90909A),
  onInverseSurface: Color(0xFF1B1B1F),
  inverseSurface: Color(0xFFE4E1E6),
  inversePrimary: Color(0xFF3252D1),
  shadow: Color(0xFF000000),
  surfaceTint: Color(0xFFB9C3FF),
  outlineVariant: Color(0xFF45464F),
  scrim: Color(0xFF000000),
);
```
---------
Este código es una aplicación en Flutter que utiliza una estructura de proveedor y router para manejar la navegación y estado de la aplicación.

La función main ejecuta la aplicación utilizando el widget MultiProvider, que proporciona una instancia compartida de BusesProviders a través de toda la aplicación.

La clase MyApp es el widget principal de la aplicación y extiende de StatefulWidget para permitir que su estado sea actualizado en tiempo de ejecución. En su estado, se inicializa una instancia de BusesProviders y se obtienen los datos de los buses.

La clave global _rootNavigatorKey se utiliza para controlar el estado del navegador principal de la aplicación y _shellNavigatorKey controla el estado del navegador secundario. El objeto _router utiliza estas claves para establecer la ubicación inicial de la aplicación en "/login" y las rutas de navegación.

Las rutas incluyen la página de inicio de sesión, la lista de viajes, el informe de billetes y la página de usuario. Cada una de estas páginas se construye utilizando un widget GoRoute o ShellRoute.

Finalmente, en la función build se devuelve una instancia de MaterialApp, que utiliza el tema definido y la configuración de router para mostrar la aplicación en la pantalla.
``` Swift
import 'package:app_buses/color_schemes.g.dart';
import 'package:app_buses/providers/buses_providers.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'Pages/Page/TicketReport.dart';
import 'Pages/Page/TravelList.dart';
import 'Pages/Page/User.dart';
import 'Pages/Page/scaffoldWithNavBar.dart';
import 'Pages/logIn/logInMain.dart';
import 'package:go_router/go_router.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(
        create: (ctx) => BusesProviders(),
      ),
    ],
    child: MyApp(),
  ));
}

class MyApp extends StatefulWidget {
  MyApp({Key? key}) : super(key: key);

  @override
  State<MyApp> createState() => _MyAppState();
}

final GlobalKey<NavigatorState> _rootNavigatorKey = GlobalKey<NavigatorState>();
final GlobalKey<NavigatorState> _shellNavigatorKey = GlobalKey<NavigatorState>();
final GoRouter _router = GoRouter(
    navigatorKey: _rootNavigatorKey,
    initialLocation: '/login',
    routes: [
      GoRoute(
          path: '/login',
          builder: (context, state) {
            return LogIn();
          }),
      ShellRoute(
          navigatorKey: _shellNavigatorKey,
          builder: (context, state, child) {
            return Navegacion(child: child);
          },
          routes: [
            GoRoute(
                path: '/travellist',
                builder: (context, state) {
                  return TravelList();
                }),
            GoRoute(
                path: '/ticketreport',
                builder: (context, state) {
                  return TicketReport();
                }),
            GoRoute(
                path: '/user',
                builder: (context, state) {
                  return User();
                }),
          ])
    ]);

class _MyAppState extends State<MyApp> {
  @override
  void initState() {
    super.initState();
    Provider.of<BusesProviders>(context, listen: false).getBuses();
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        useMaterial3: true,
        //colorSchemeSeed: Colors.cyan,
        colorScheme: lightColorScheme
        //primarySwatch: Colors.blue,
      ),
      //home: LonIn());
      routerConfig: _router,
    );
  }
}
```
