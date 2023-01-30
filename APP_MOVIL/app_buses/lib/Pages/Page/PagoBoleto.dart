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
