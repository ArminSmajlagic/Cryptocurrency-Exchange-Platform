import 'package:provider/provider.dart';
import 'package:flutter/material.dart';

import 'package:flutter/material.dart';
import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:mobile/Auth/login.dart';
import 'package:mobile/Models/user.dart';
import 'package:mobile/User/accChange.dart';
import 'package:mobile/User/accSecurity.dart';
import 'package:mobile/User/userProvider.dart';
import 'package:mobile/Wallet/wallet.dart';
import 'package:http/http.dart' as http;
import 'dart:convert' as convert;

import 'package:mobile/routing.dart';

class Account extends StatefulWidget {
  

    @override
  _AccountState createState() => _AccountState();
}

class _AccountState extends State<Account>{
  
  User user = new User(); 
  String username = "";
  UserProvider? _userProvider = null;

  String? _server;

  
  @override
  void initState(){
    super.initState();
    _server = const String.fromEnvironment("baseUrl",defaultValue: "https://rs2seminarski.herokuapp.com");

    _userProvider = context.read<UserProvider>();

    loadUser();
  }



  Future loadUser() async {

    var user_id = AuthServis.readUserId();

    var respons = await _userProvider!.GetById(user_id);


    setState(() {
      user = respons;
    });


  }

  @override
  Widget build(BuildContext context) {
    void Logout() async {
      var client = http.Client();
      var url = _server!+"/auth_api/Auth/Logout/" +
          AuthServis.user_id.toString();

      //test code
      // AuthServis.removeUser();
      // Navigator.pushReplacement(context,MaterialPageRoute<void>(
      //     builder: (BuildContext context) => RouterPage(ruta:4))
      // );
      //
      var response = await client.post(Uri.parse(url));

      if (response.statusCode == 200) {
        AuthServis.removeUser();


        Navigator.push(
            context,
            MaterialPageRoute<void>(
                builder: (BuildContext context) => RouterPage(ruta: 4)));
      } else {
        throw Exception('Unexpected error occured in method logout !');
      }
    }


    return Scaffold(
        appBar: AppBar(
            backgroundColor: Colors.blue[100],
            title: const Text('Korisnički detalji',
                style: TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.w500,
                    fontSize: 25))),
        body: Container(
          child: Center(
              child: Column(children: [
            Container(
                margin: EdgeInsets.only(left: 50, right: 50, top: 30),
                decoration: const BoxDecoration(
                  borderRadius: BorderRadius.all(Radius.circular(27)),
                  border: Border(
                    top: BorderSide(width: 4.0, color: Colors.blue),
                    left: BorderSide(width: 4.0, color: Colors.blue),
                    right: BorderSide(width: 4.0, color: Colors.blue),
                    bottom: BorderSide(width: 4.0, color: Colors.blue),
                  ),
                ),
                child:  Column(
                        children: [
                          Container(
                              margin: EdgeInsets.only(top: 20),
                              child: Icon(
                                Icons.account_circle,
                                color: Colors.lightBlue,
                                size: 100,
                              )),
                          Container(
                            margin: EdgeInsets.only(top: 20),
                            child: Text(
                              "Detalji korisnika",
                              style: TextStyle(
                                  fontSize: 20,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.lightBlue),
                            ),
                          ),
                          // Container(
                          //   margin: EdgeInsets.only(top: 10),
                          //   child: Row(
                          //       mainAxisAlignment: MainAxisAlignment.center,
                          //       children: [
                          //         Text("Username :  "),
                          //         Text(username)
                          //       ]),
                          // ),
                          Container(
                            margin: EdgeInsets.only(top: 5),
                            child: Row(
                                mainAxisAlignment: MainAxisAlignment.center,
                                children: [
                                  Text("Ime prezime :  "),
                                  Text(user.imePrezime==""?"Loading...":user.imePrezime),
                                ]),
                          ),
                          Container(
                            margin: EdgeInsets.only(top: 5),
                            child: Row(
                                mainAxisAlignment: MainAxisAlignment.center,
                                children: [
                                  Text("Email :  "),
                                  Text(user.email==""?"Loading...":user.email),
                                ]),
                          ),
                          Container(
                            margin: EdgeInsets.only(top: 5),
                            child: Row(
                                mainAxisAlignment: MainAxisAlignment.center,
                                children: [
                                  Text("Država :  "),
                                  Text(user.drzava==""?"Loading...":user.drzava),
                                ]),
                          ),
                          Container(
                            margin: EdgeInsets.only(top: 5),
                            child: Row(
                                mainAxisAlignment: MainAxisAlignment.center,
                                children: [
                                  Text("Broj telefona :  "),
                                  Text(user.brojTelefona==""?"Loading...":user.brojTelefona),
                                ]),
                          ),
                          Container(
                              margin: EdgeInsets.only(top: 5, bottom: 20),
                              child: Row(
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: [
                                    Text("Balans :  "),
                                    Text(user.stanjeWalleta==0?"Loading...":user.stanjeWalleta.toStringAsFixed(3)),
                                  ])),
                          SizedBox(
                              width: 200,
                              height: 90,
                              child: Padding(
                                padding: EdgeInsets.only(bottom: 40),
                                child: OutlinedButton(
                                  style: ButtonStyle(
                                    shape: MaterialStateProperty.all(
                                      RoundedRectangleBorder(
                                        borderRadius:
                                            BorderRadius.circular(10.0),
                                      ),
                                    ),
                                  ),
                                  onPressed: () => {
                                    Navigator.of(context).push(
                                        MaterialPageRoute(
                                            builder: (context) => WalletScreen()))
                                  },
                                  child: Text("Pogledajte vaš wallet"),
                                ),
                              )),
                          // SizedBox(
                          //     width: 200,
                          //     height: 90,
                          //     child: Padding(
                          //       padding: EdgeInsets.only(bottom: 40),
                          //       child: OutlinedButton(
                          //         style: ButtonStyle(
                          //           shape: MaterialStateProperty.all(
                          //             RoundedRectangleBorder(
                          //               borderRadius:
                          //                   BorderRadius.circular(10.0),
                          //             ),
                          //           ),
                          //         ),
                          //         onPressed: () => {
                          //           Navigator.of(context).push(
                          //               MaterialPageRoute(
                          //                   builder: (context) => Security()))
                          //         },
                          //         child: Text(
                          //           "Provjerite vaše sigurnosne postavke",
                          //           textAlign: TextAlign.center,
                          //         ),
                          //       ),
                          //     )),
                          SizedBox(
                              width: 200,
                              height: 90,
                              child: Padding(
                                padding: EdgeInsets.only(bottom: 40),
                                child: OutlinedButton(
                                  style: ButtonStyle(
                                    shape: MaterialStateProperty.all(
                                      RoundedRectangleBorder(
                                        borderRadius:
                                            BorderRadius.circular(10.0),
                                      ),
                                    ),
                                  ),
                                  onPressed: () => {
                                    Navigator.of(context).push(
                                        MaterialPageRoute(
                                            builder: (context) =>
                                                AccountChange()))
                                  },
                                  child: Text(
                                      "Promjenite vaše personalne podatke",
                                      textAlign: TextAlign.center),
                                ),
                              )),
                          SizedBox(
                              width: 80,
                              height: 90,
                              child: Container(
                                margin: EdgeInsets.only(bottom: 20),
                                padding: EdgeInsets.only(bottom: 20),
                                child: OutlinedButton(
                                  style: ButtonStyle(
                                    shape: MaterialStateProperty.all(
                                      RoundedRectangleBorder(
                                        borderRadius:
                                            BorderRadius.circular(10.0),
                                      ),
                                    ),
                                  ),
                                  onPressed: () => {Logout()},
                                  child: Text("Logout",
                                      textAlign: TextAlign.center),
                                ),
                              ))
                        ],
                      )
                      // } else{
                      //   return Text("${snapshot.error}");
                      // }
                    )
          ])),
        ));
  }
  
  @override
  State<StatefulWidget> createState() {
    // TODO: implement createState
    throw UnimplementedError();
  }
}
