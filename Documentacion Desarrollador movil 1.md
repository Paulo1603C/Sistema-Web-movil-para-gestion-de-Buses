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

 La clase User Cuenta con 2 atributos que son name,pass . Se usa la palabra required para que sean obligarotios usar los atributos para que funcione
``` Swift
class User{
  String name;
  String pass;

  User({ required this.name, required this.pass })
  ```
 
``` Swift
 import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';


class LogIn extends StatefulWidget {
  LogIn({Key? key}) : super(key: key);

  @override
  State<LogIn> createState() => _LogInState();
}

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


``` Swift
mport 'package:flutter/material.dart';
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
