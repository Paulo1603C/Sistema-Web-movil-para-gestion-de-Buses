import 'package:app_buses/providers/UserProviders.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:provider/provider.dart';

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
          onPressed: _verContrasena,
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
        onPressed: () async {
          //
          _usu = _nombre.text;
          _con = _contrasena.text;
          if (_usu != '' || _con != '') {

            if ( await Provider.of<UserProviders>(context,listen: false).getLogIn(_usu, _con) ) {
              GoRouter.of(context).go('/travellist');
            } else {
              _showAlertDialog();
            }
          } else {
            _showAlertDialog2();
          }
        },
      ),
    );
  }

  _showAlertDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Sin Informacion '),
          content: Text('NO se encontro el usuario'),
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

  _verContrasena() {}

  _showAlertDialog2() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Informacion Incompleta'),
          content: Text('Complete los campos necesarios para continuar'),
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
