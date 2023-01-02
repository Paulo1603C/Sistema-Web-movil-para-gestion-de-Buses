import 'package:flutter/material.dart';

class LonIn extends StatefulWidget {
  LonIn({Key? key}) : super(key: key);

  @override
  State<LonIn> createState() => _LonInState();
}

class _LonInState extends State<LonIn> {
  
  String _nombre="";
  String _contrasena="";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('LogIn'),
      ),
      backgroundColor: Colors.blueGrey[100],
      body: ListView(
        padding: EdgeInsets.symmetric(
          horizontal:30.0,
          vertical: 50.0,
        ),
        children: [
          Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              CircleAvatar(
                radius: 100.1,
                backgroundColor: Colors.grey,
                backgroundImage: AssetImage('images/logo.png'),
              ),
              Text('LogIn',
                style: TextStyle(
                  fontFamily: 'Verdana',
                  fontSize: 50.0,
                ),
              ),
              Divider(
                height: 18.0,
              ),
              TextField(
                enableInteractiveSelection: false,
                autofocus: true,
                textCapitalization: TextCapitalization.characters,
                decoration: InputDecoration(
                  labelText: 'User',
                  suffixIcon: Icon(
                    Icons.verified_user
                  ),
                  border:OutlineInputBorder(
                    borderRadius: BorderRadius.circular(20.0)
                  ),
                ),
                onSubmitted: (valor){
                  _nombre = valor;
                  print(_nombre);
                },
              ),
              Divider(
                height: 18.0,
              ),
              TextField(
                enableInteractiveSelection: false,
                obscureText: true,
                decoration: InputDecoration(
                  labelText: 'Contaseña',
                  suffixIcon: Icon( Icons.lock_outlined),
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(20.0)
                  ),
                ),
                onSubmitted: (valor){
                  _contrasena = valor;
                  print(_contrasena);
                },
              ),
              Divider(
                height: 18.0,
              ),
              SizedBox(
                child: FlatButton(
                  color: Colors.lightBlueAccent,
                  padding: EdgeInsets.symmetric(
                    horizontal:20.0,
                    vertical: 15.0,
                  ),
                  hoverColor: Colors.lightBlue,
                  onPressed: (){},
                  child: Text('Sing In',
                    style: TextStyle(
                      color: Colors.white70,
                      fontFamily: 'Verdana',
                      fontSize: 30.0
                    ),
                  ),
                ),
              ),
            ],
          )
        ],
      )
    
    );
  }
}

