import 'package:app_buses/color_schemes.g.dart';
import 'package:app_buses/providers/buses_providers.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'Pages/Page/TicketReport.dart';
import 'Pages/Page/TravelList.dart';
import 'Pages/Page/User.dart';
import 'Pages/Page/scaffoldWithNavBar.dart';
import 'Pages/logIn/logInMain.dart';
import 'package:go_router/go_router.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(
        create: (ctx) => BusesProviders(),
      ),
    ],
    child: MyApp(),
  ));
}

class MyApp extends StatefulWidget {
  MyApp({Key? key}) : super(key: key);

  @override
  State<MyApp> createState() => _MyAppState();
}

final GlobalKey<NavigatorState> _rootNavigatorKey = GlobalKey<NavigatorState>();
final GlobalKey<NavigatorState> _shellNavigatorKey = GlobalKey<NavigatorState>();
final GoRouter _router = GoRouter(
    navigatorKey: _rootNavigatorKey,
    initialLocation: '/login',
    routes: [
      GoRoute(
          path: '/login',
          builder: (context, state) {
            return LogIn();
          }),
      ShellRoute(
          navigatorKey: _shellNavigatorKey,
          builder: (context, state, child) {
            return Navegacion(child: child);
          },
          routes: [
            GoRoute(
                path: '/travellist',
                builder: (context, state) {
                  return TravelList();
                }),
            GoRoute(
                path: '/ticketreport',
                builder: (context, state) {
                  return TicketReport();
                }),
            GoRoute(
                path: '/user',
                builder: (context, state) {
                  return User();
                }),
          ])
    ]);

class _MyAppState extends State<MyApp> {
  @override
  void initState() {
    super.initState();
    Provider.of<BusesProviders>(context, listen: false).getBuses();
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        useMaterial3: true,
        //colorSchemeSeed: Colors.cyan,
        colorScheme: lightColorScheme
        //primarySwatch: Colors.blue,
      ),
      //home: LonIn());
      routerConfig: _router,
    );
  }
}
