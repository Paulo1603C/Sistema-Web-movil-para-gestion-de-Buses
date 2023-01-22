import 'package:flutter/material.dart';

class TravelInformation extends StatefulWidget {
  TravelInformation({Key? key}) : super(key: key);

  @override
  State<TravelInformation> createState() => _TravelInformationState();
}

class _TravelInformationState extends State<TravelInformation> {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: Text(
        "User",
        style: TextStyle(fontFamily: "verdana", fontSize: 25.0),
      ),
    );
  }
}
