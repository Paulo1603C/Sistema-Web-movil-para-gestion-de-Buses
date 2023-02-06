

import 'package:flutter/material.dart';
import 'package:qr_flutter/qr_flutter.dart';

class TicketReport extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Código QR'),
      ),
      body: Center(
        child: QrImage(
          data: 'Codigo validado',
        ),
      ),
    );
  }
}

