import 'package:flutter/material.dart';

import 'PagoBanco.dart';

class CompraAsientos extends StatelessWidget {
  List data = [];

  CompraAsientos({Key? key, required this.data}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Información Compra'),
        ),
        body: Center(
          child: Container(
            padding: EdgeInsets.symmetric(vertical: 10, horizontal: 20),
            child: Row(
              children: [
                Container(
                  padding: EdgeInsets.symmetric(horizontal: 10),
                  color: Color.fromRGBO(255, 250, 240, 1),
                  child: Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Column(
                      children: [
                        Text(
                          "INFORMACIPÓN DE ASIENTOS SELECIONADOS",
                          style: TextStyle(fontFamily: "VERDANA", fontSize: 20,fontWeight: FontWeight.bold),
                        ),
                  
                        Text("USTED A SELECIONADO LOS SIEGUINETES ASIENTOS",style: TextStyle(color: Colors.redAccent),),
                                  
                        SizedBox(
                          height: 20,
                        ),
                                  
                        //CARGAR INFORMACION
                        Expanded(child: listaCompra())
                      ],
                    ),
                  ),
                ),
                Expanded(
                  child: Container(
                    color: Color.fromRGBO(253, 245, 230, 1),
                    padding: EdgeInsets.symmetric(horizontal: 10),
                    child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        "METODOS DE PAGO",
                        style: TextStyle(fontFamily: "VERDANA", fontSize: 20,fontWeight: FontWeight.bold),
                      ),
                      SizedBox(height: 20,),
                  
                      //boton Paypal
                      _btnPaypal(context),
                  
                      SizedBox(height: 20,),
                      //boton Banco
                      _btnBanco(context),
                  
                    ],
                                  ),
                  ))
              ],
            ),
          ),
        ));
  }

  Container listaCompra() {
    return Container(
      height: 400,
      width: 300,
      child: GridView.count(
        crossAxisCount: 2,
        children: List.generate(data.length, (index) {
          return Container(
            margin: EdgeInsets.all(4),
            child: Container(
              padding: EdgeInsets.symmetric(vertical: 5, horizontal: 6),
              color: Color.fromRGBO(245, 245, 245, 1),
              child: Center(
                child: Text(
                  "Asiento: " + data[index],
                  style: TextStyle(
                      color: Color.fromRGBO(0, 0, 139, 1),
                      fontFamily: "VERDANA",
                      fontSize: 18),
                ),
              ),
            ),
          );
        }),
      ),
    );
  }

  Widget _btnPaypal(BuildContext context) {
    return Container(
      height: 60,
      width: 350,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
      ),
      child: ElevatedButton(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Image.asset('assets/images/paypal.png'),
        ),
        onPressed: () {},
      ),
    );
  }

  Widget _btnBanco(BuildContext context) {
    return Container(
      height: 60,
      width: 350,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
      ),
      child: ElevatedButton(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Image.asset('assets/images/visa.png'),
        ),
        onPressed: () {
          Navigator.of(context)
            .push(MaterialPageRoute(builder: (context) => PagoBoleto()));
        },
      ),
    );
  }

}
