import 'package:flutter/material.dart';

class TravelInformation extends StatefulWidget {
  TravelInformation({Key? key}) : super(key: key);

  @override
  State<TravelInformation> createState() => _TravelInformationState();
}

class _TravelInformationState extends State<TravelInformation> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Información de Viajes"),
      ),
      body:Column(
        children: [
          Text("Provando"),
        ],
      ),
    );
  }
}
