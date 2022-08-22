import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:mobile/Auth/register.dart';
import 'package:mobile/home.dart';

class Router {
  Route<dynamic> generateRoute(RouteSettings settings) {
    switch (settings.name) {
      case '/':
        return MaterialPageRoute(builder: (_) => Home());
      case '/register':
        return MaterialPageRoute(builder: (_) => Register());
      default:
        return MaterialPageRoute(
            builder: (_) => Scaffold(
              body: Center(
                  child: Text('No route defined for ${settings.name}')),
            ));
    }
  }
}