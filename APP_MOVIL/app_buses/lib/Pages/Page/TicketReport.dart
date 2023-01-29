import 'package:flutter/material.dart';

class TicketReport extends StatefulWidget {
  TicketReport({Key? key}) : super(key: key);

  @override
  State<TicketReport> createState() => _TicketReportState();
}

class _TicketReportState extends State<TicketReport> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar:  AppBar(
        title: Text("Reprote del Boleto"),
      ),
    );
  }
}