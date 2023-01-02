import 'package:flutter/material.dart';


class LogIn extends StatelessWidget {
  const LogIn({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('LogIn'),
      ),

      floatingActionButton: FloatingActionButton(
        child: Icon(Icons.logout),
        onPressed:(){
          //regresa  a la pagina anterior
          Navigator.pop(context);
        } ,),
    );
  }
}
