import 'package:flutter/material.dart';


class CompraAsientos extends StatelessWidget {
  List data = [];

  CompraAsientos({Key? key, required this.data}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Second Screen'),
      ),
      body:  Column(
          children: [
            //Text("INFORMACION DE ASIENTOS SELECIONADOS", style: TextStyle(fontFamily:"VERDANA",fontSize: 20),),
            ListView.builder(
              itemCount: data.length,
              itemBuilder: (context, index) {
                return Center(
                  child: Card(
                    child: Text(data[index]),
                  ),
                );
              }
            ),

            //formas de pago

            //FormasPago(),
          ],
        )
    );
  }

  Widget FormasPago(){
    return Column(
      children: [
        _btnBanco(),
      ],
    );
  }

  Widget _btnBanco() {
    return Container(
      width: double.infinity,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
      ),
      child: ElevatedButton(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Image.asset('assets/images/paypal.png'),
        ),
        onPressed: () {
          
        },
      ),
    );
  }


}

