import 'package:flutter/material.dart';

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
      body: Text("datos")
    );
    ;
  }
}
