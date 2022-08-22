import 'package:flutter/material.dart';
import 'package:mobile/Auth/Servis/AuthProvider.dart';
import 'package:provider/provider.dart';
import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:mobile/BaseProvider.dart';
import 'package:mobile/Models/valuta.dart';
import 'package:mobile/Trading/narudzbeProvider.dart';
import 'package:mobile/Valuta/ValutaProvider.dart';
import 'package:mobile/User/accChange.dart';
import 'package:mobile/User/accSecurity.dart';
import 'package:mobile/User/account.dart';
import 'package:mobile/User/noAcc.dart';
import 'package:mobile/User/privUpdate.dart';
import 'package:mobile/User/userProvider.dart';
import 'package:mobile/Wallet/walletProvider.dart';
import 'Auth/login.dart';
import './Auth/register.dart';
import './Auth/verification.dart';
import 'Valuta/PonudeProvider.dart';
import 'home.dart';
import 'package:flutter/foundation.dart';


//flutter run -d chrome --web-port=1234

import 'routing.dart';
//void main() => runApp(MyApp());
void main() => runApp(MultiProvider(
  providers: [
    ChangeNotifierProvider(create: (_) => ValutaProvider()),
    ChangeNotifierProvider(create: (_) => UserProvider()),
    ChangeNotifierProvider(create: (_) => PonudeProvider()),
    ChangeNotifierProvider(create: (_) => WalletProvider()),
    ChangeNotifierProvider(create: (_) => NarudzbaProvider()),
    ChangeNotifierProvider(create: (_) => AuthProvider()),
  ],
  child: MyApp(),
));


class MyApp extends StatelessWidget {
  MyApp({Key? key}) : super(key: key);
  final AuthServis authservis = new AuthServis();

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: RouterPage(ruta:0),
      routes: {
        '/home':(context)=>Home(),
        '/login':(context)=>Login(),
        '/register':(context)=>Register(),
        '/verification':(context)=>Verification(mail: "can not navigate from here. this is main",user_id: 0),
        //account
        '/acc':(context)=>Account(),
        '/noAcc':(context)=>NoAccount(),
        '/accChange':(context)=>AccountChange(),
        '/security':(context)=>Security(),
        '/privacy':(context)=>PrivacyUpdate(),
      },
    );
  }
}
