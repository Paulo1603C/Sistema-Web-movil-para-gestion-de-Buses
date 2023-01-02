import 'package:flutter/material.dart';

class LonIn extends StatefulWidget {
  LonIn({Key? key}) : super(key: key);

  @override
  State<LonIn> createState() => _LonInState();
}

class _LonInState extends State<LonIn> {
  String _nombre = "";
  String _contrasena = "";

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
            vertical: 50.0,
          ),
          children: [
            Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                CircleAvatar(
                  radius: 100.1,
                  backgroundColor: Colors.transparent,
                  backgroundImage: AssetImage('images/logo.jpg'),
                ),
                Text(
                  'Bienvenido',
                  style: TextStyle(
                    fontFamily: 'Verdana',
                    fontWeight: FontWeight.bold,
                    fontSize: 30.0,
                  ),
                ),
                SizedBox(height: 5.0,),
                Text(
                  'Ingrese sus credenciales',
                  style: TextStyle(
                    fontFamily: 'Verdana',
                    fontSize: 18.0,
                    color: Colors.blue
                  ),
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
      enableInteractiveSelection: false,
      autofocus: true,
      textCapitalization: TextCapitalization.characters,
      decoration: InputDecoration(
        labelText: 'User',
        suffixIcon: Icon(Icons.verified_user),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(20.0)),
      ),
      onSubmitted: (valor) {
        _nombre = valor;
        print(_nombre);
      },
    );
  }

  Widget _inputPasword() {
    return TextField(
      enableInteractiveSelection: false,
      obscureText: true,
      decoration: InputDecoration(
        labelText: 'Contaseña',
        suffixIcon: Icon(Icons.lock_outlined),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(20.0)),
      ),
      onSubmitted: (valor) {
        _contrasena = valor;
        print(_contrasena);
      },
    );
  }

  Widget _btnLogIn() {
    return Container(
      width: double.infinity,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
      ),
      child: FlatButton(
        color: Colors.blue,
        padding: EdgeInsets.symmetric(
          horizontal: 20.0,
          vertical: 15.0,
        ),
        child: Text(
          'Ingresar',
          style: TextStyle(
              color: Colors.white,
              fontFamily: 'Verdana',
              fontWeight: FontWeight.bold,
              fontSize: 30.0),
        ),
        onPressed: () {},
      ),
    );
  }
}
