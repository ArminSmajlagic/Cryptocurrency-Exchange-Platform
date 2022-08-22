import 'dart:io';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/io_client.dart';
import 'package:mobile/Auth/Servis/AuthProvider.dart';
import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:mobile/Auth/register.dart';
import 'package:http/http.dart' as http;
import 'dart:convert' as convert;

import 'package:mobile/main.dart';
import 'package:mobile/routing.dart';
import 'package:provider/provider.dart';

import '../Models/AuthRequest/loginRequest.dart';

//import 'package:flutter_icons/flutter_icons.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  final _username = new TextEditingController();
  final _password = new TextEditingController();
  AuthProvider? _authProvider = null;

  @override
  void initState(){
    super.initState();
    _authProvider = context.read<AuthProvider>();
  }

  void login() async{

    var response = await _authProvider!.login(LoginRequest(_username.text, _password.text));

    if(response){
        Navigator.of(context).pop();
        Navigator.pushReplacement(context,MaterialPageRoute<void>(
            builder: (BuildContext context) => RouterPage(ruta:0))
        );
    }
    else
    {
        _username.text="";
        _password.text="";
    }

  }

  @override
  Widget build(BuildContext context) {

    return Scaffold(
      body: 
        SingleChildScrollView (
          child: Container(
        margin: const EdgeInsets.only(
            left: 50.0, right: 50.0, top: 50, bottom: 100),
        // decoration: const BoxDecoration(
        //   borderRadius: BorderRadius.all(Radius.circular(27)),
        //   border: Border(
        //     top: BorderSide(width: 4.0, color: Colors.blue),
        //     left: BorderSide(width: 4.0, color: Colors.blue),
        //     right: BorderSide(width: 4.0, color: Colors.blue),
        //     bottom: BorderSide(width: 4.0, color: Colors.blue),
        //   ),
        // ),
        child: Center(
          child: Column(
            children: [
              Container(
                  decoration: const BoxDecoration(
                    borderRadius: BorderRadius.all(Radius.circular(27)),
                    border: Border(
                      top: BorderSide(width: 4.0, color: Colors.blue),
                      left: BorderSide(width: 4.0, color: Colors.blue),
                      right: BorderSide(width: 4.0, color: Colors.blue),
                      bottom: BorderSide(width: 4.0, color: Colors.blue),
                    ),
                  ),
                  child: Padding(
                    padding: EdgeInsets.only(
                        top: 20, left: 20, right: 20, bottom: 20),
                    child: Text(
                      "Logo",
                      style: TextStyle(
                        fontSize: 50,
                        color: Colors.blue,
                        fontFamily: "Inter",
                        fontWeight: FontWeight.w100,
                        fontStyle: FontStyle.italic,
                      ),
                    ),
                  )),
              Padding(
                padding: EdgeInsets.only(top: 40, left: 20, right: 20),
                child: SizedBox(
                    width: 300,
                    child: TextField(
                      controller: _username,
                      decoration: InputDecoration(
                        border: OutlineInputBorder(
                          borderRadius: BorderRadius.all(Radius.circular(10)),
                        ),
                        labelText: "Korisnicko ime",
                      ),
                    )),
              ),
              Padding(
                  padding: EdgeInsets.only(bottom: 20, top: 10),
                  child: Text(
                    "Unesite korisnicko ime malim slovima",
                    style: TextStyle(fontSize: 12),
                  )),
              Padding(
                padding: EdgeInsets.only(left: 20, right: 20),
                child: SizedBox(
                    width: 300,
                    child: TextField(
                      obscureText: true,
                      controller: _password,
                      decoration: InputDecoration(
                          border: OutlineInputBorder(
                              borderRadius:
                                  BorderRadius.all(Radius.circular(10))),
                          labelText: "Lozinka"),
                    )),
              ),
              Padding(
                  padding: EdgeInsets.only(bottom: 20, top: 10),
                  child: Text(
                    "Lozinka treba da sadrži mala i velika slova",
                    style: TextStyle(fontSize: 12),
                  )),
              Padding(
                  padding:
                      EdgeInsets.only(top: 30, bottom: 0, left: 20, right: 20),
                  child: SizedBox(
                      width: 130,
                      height: 40,
                      child: OutlinedButton(
                        onPressed: () => login(),
                        style: ButtonStyle(
                          shape: MaterialStateProperty.all(
                            RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(10.0),
                            ),
                          ),
                        ),
                        child: const Text("Prijavi se",
                            style: TextStyle(fontSize: 20, color: Colors.blue,fontWeight: FontWeight.w300),
                            textAlign: TextAlign.center),
                      ),
                  )
              ),

               SizedBox(
                 width: 200,
                 child: Padding(
                     padding: EdgeInsets.only(bottom: 20, top: 50),
                     child: Text(
                       "Support : Qui nobis reprehenderit explicabo voluptate. Voluptates molestiae in molestias aut sit vel est aut. +000 000 000",
                       textAlign: TextAlign.center,
                       style: TextStyle(fontSize: 12, color: Colors.lightBlue),
                     )),
             ),
              GestureDetector(
                  child: Text(
                    "Nemate računa?\n Klik na ovaj tekst će vas odvesti na registracijsku formu?",
                    style: TextStyle(
                      color: Colors.blue,
                      fontSize: 13
                    ),
                    textAlign: TextAlign.center,
                  ),
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => Register()),
                    );
                  })
            ],
          ),
        ),
      ),
    )
    );
  }
}
