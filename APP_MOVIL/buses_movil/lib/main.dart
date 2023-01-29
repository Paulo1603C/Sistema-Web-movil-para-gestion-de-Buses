
import 'package:buses_movil/providers/buses_providers.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import '../../models/Buses.dart';
import 'Pages/logIn/logInMain.dart';

void main() {
  runApp( MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (ctx)=>BusesProviders(), ),
    ],
    child: MyApp(),
    ) );
}

class MyApp extends StatefulWidget {
  MyApp({Key? key}) : super(key: key);

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
    
    @override
      void initState(){
        super.initState();
        Provider.of<BusesProviders>(context, listen: false).getBuses();
    }

  @override
  Widget build(BuildContext context) {
    

    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: LonIn()
    );
  }
}

