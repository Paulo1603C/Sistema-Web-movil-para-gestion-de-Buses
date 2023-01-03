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