import 'package:flutter/material.dart';
import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:mobile/Valuta/trade.dart';
import 'package:mobile/User/account.dart';
import 'package:mobile/User/noAcc.dart';
import 'package:mobile/Wallet/wallet.dart';
import './Auth/Login.dart';
import './Auth/register.dart';
import './Auth/verification.dart';
import 'home.dart';

class RouterPage extends StatefulWidget {
  int ruta;
  var _appState;

  RouterPage({Key? key,required this.ruta}) : super(key: key){
      _appState = _AppState(curentPage: ruta);
  }
  @override
  _AppState createState() => _appState;
}

class _AppState extends State<RouterPage> {
  int curentPage;
  int curentPageTabNav = 0;

  _AppState({required this.curentPage}){
    if(curentPage<4){
      display = _tabNavPages;
    }
    else{
      display = _pages;
    }
  }

  List display= [];

  List _pages = [
    Home(),
    Trade(),
    WalletScreen(),
    //NoAccount() if user not loged in or registered
    Account(),
    Login(),
    Register(),
    Verification(mail: "can not navigate from here. this is routing",user_id: 0),
    NoAccount(),
  ];

  List _tabNavPages=[
    Home(),
    Trade(),
    WalletScreen(),
    NoAccount(),// if user not loged in or registered
    Account(),
  ];
  void _updatePage(int i) {
    //logic for account or no-account goes here
    setState(() {
      if(i<4){
        display = _tabNavPages;
      }
      else{
        display = _pages;
      }
      if(AuthServis.user_id!=0 && i==3)
        curentPage = 4;
      else if(AuthServis.user_id==0 && i==2)
        curentPage = 3;
      else
        curentPage = i;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      bottomNavigationBar: BottomNavigationBar(
        showUnselectedLabels: true,
        items: [
          BottomNavigationBarItem(icon: Icon(Icons.home),label: 'Home',backgroundColor: Colors.blue[100],),
          BottomNavigationBarItem(icon: Icon(Icons.currency_bitcoin),label: 'Trade',backgroundColor: Colors.blue[100]),
          BottomNavigationBarItem(icon: Icon(Icons.account_balance_wallet),label: 'Wallet',backgroundColor: Colors.blue[100]),
          BottomNavigationBarItem(icon: Icon(Icons.account_circle),label: 'User',backgroundColor: Colors.blue[100]),
        ],
        onTap: _updatePage,
        type: BottomNavigationBarType.fixed,
        selectedItemColor: Colors.grey,
      ),
      body: display[curentPage],
    );
  }
}
