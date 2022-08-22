import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/Auth/Servis/AuthProvider.dart';
import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:mobile/Auth/verification.dart';
import 'package:mobile/Models/AuthRequest/registerRequest.dart';
import 'dart:convert' as convert;

import 'package:mobile/routing.dart';
import 'package:provider/provider.dart';

class Register extends StatefulWidget {

  @override
  _RegisterState createState() => _RegisterState();
}


class _RegisterState extends State<Register>{
  AuthProvider? _authProvider = null;

  final _username = new TextEditingController();
  final _password = new TextEditingController();
  final _email = new TextEditingController();
  final _drzava = new TextEditingController();
  final _broj_telefona = new TextEditingController();
  final _ime_prezime = new TextEditingController();

  final _godine = new TextEditingController();
  final _ponovoLozinka = new TextEditingController();

  @override
  void initState(){
    super.initState();
    _authProvider = context.read<AuthProvider>();
  }
  
  void register() async{
    var client = http.Client();

    var url = "https://localhost:7291/auth_api/Auth/Register";

    var registerRequest = new RegisterRequest();
    registerRequest.username = _username.text;
    registerRequest.password = _password.text;
    registerRequest.email = _email.text;
    registerRequest.brojtelefona = _broj_telefona.text;
    registerRequest.drzava = _drzava.text;
    registerRequest.ime_prezime = _ime_prezime.text;

    var response = false;

    if(_ponovoLozinka.text==_password.text&&_username.text!=""&&_ime_prezime.text!=""&&_password.text!=""&&_email.text!=""&&_drzava.text!="") {
      response = await _authProvider!.register(registerRequest);
    }else{
      print("Unos nije validan!");
        _username.text="";
        _password.text="";
        _ponovoLozinka.text="";
      return;
    }

    if (response) {
      Navigator.of(context).pop();
      Navigator.pushReplacement(context,MaterialPageRoute<void>(
          builder: (BuildContext context) => Verification(mail: _email.text,user_id: AuthServis.user_id))
      );      
    } else {
      _username.text="";
      _password.text="";
      _ponovoLozinka.text="";
      throw Exception('Unexpected error occured in method register !');
    }
  }
  
  

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
          backgroundColor: Colors.blue[100],
          title: const Text('Register',
              style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.w500,
                  fontSize: 25))),
      body: Container(
        // margin: const EdgeInsets.only(
        //     left: 50.0, right: 50.0, top: 0, bottom: 0),
        // decoration: const BoxDecoration(
        //   borderRadius: BorderRadius.all(Radius.circular(27)),
        //   border: Border(
        //     top: BorderSide(width: 4.0, color: Colors.blue),
        //     left: BorderSide(width: 4.0, color: Colors.blue),
        //     right: BorderSide(width: 4.0, color: Colors.blue),
        //     bottom: BorderSide(width: 4.0, color: Colors.blue),
        //   ),
        // ),
        child: Container(
          child: ListView.builder(
              itemCount: 1,
              itemBuilder: (context, index){
                return new Column(
                  children: [
                    Container(
                      margin: EdgeInsets.only(top: 50),
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
                        padding:
                        EdgeInsets.only(top: 20, left: 20, right: 20, bottom: 20),
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
                      ),
                    ),
                    Padding(
                      padding: EdgeInsets.only(top: 40, left: 20, right: 20),
                      child: SizedBox(
                          width: 300,
                          child: TextField(
                            controller: _ime_prezime,
                            decoration: InputDecoration(
                              border: OutlineInputBorder(
                                borderRadius: BorderRadius.all(Radius.circular(10)),
                              ),
                              labelText: "Ime i Prezime",
                            ),
                          )),
                    ),
                    Padding(
                        padding: EdgeInsets.only(bottom: 20, top: 10),
                        child: Text(
                          "Unesite vaše ime i prezime.",
                          style: TextStyle(fontSize: 12),
                        )),
                    Padding(
                      padding: EdgeInsets.only(left: 20, right: 20),
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
                          "Lozinka treba da se podudara sa lozinkom iznad",
                          style: TextStyle(fontSize: 12),
                        )),
                    Padding(
                      padding: EdgeInsets.only(left: 20, right: 20),
                      child: SizedBox(
                          width: 300,
                          child: TextField(
                            obscureText: true,
                            controller: _ponovoLozinka,
                            decoration: InputDecoration(
                                border: OutlineInputBorder(
                                    borderRadius:
                                    BorderRadius.all(Radius.circular(10))),
                                labelText: "Ponovi Lozinka"),
                          )),
                    ),
                    Padding(
                        padding: EdgeInsets.only(bottom: 20, top: 10),
                        child: Text(
                          "Lozinka treba da sadrži mala i velika slova",
                          style: TextStyle(fontSize: 12),
                        )),
                    Padding(
                      padding: EdgeInsets.only(left: 20, right: 20),
                      child: SizedBox(
                          width: 300,
                          child: TextField(
                            controller: _email,
                            decoration: InputDecoration(
                                hintText: "primjer@email.com",
                                border: OutlineInputBorder(
                                    borderRadius:
                                    BorderRadius.all(Radius.circular(10))),
                                labelText: "Email"),
                          )),
                    ),
                    Padding(
                        padding: EdgeInsets.only(bottom: 20, top: 10),
                        child: Text(
                          "Unesite vašu email adresu",
                          style: TextStyle(fontSize: 12),
                        )),
                    Padding(
                      padding: EdgeInsets.only(left: 20, right: 20),
                      child: SizedBox(
                          width: 300,
                          child: TextField(
                            controller: _broj_telefona,
                            decoration: InputDecoration(
                                hintText: "+367000000",
                                border: OutlineInputBorder(
                                    borderRadius:
                                    BorderRadius.all(Radius.circular(10))),
                                labelText: "Broj telefona"),
                          )),
                    ),
                    Padding(
                        padding: EdgeInsets.only(bottom: 20, top: 10),
                        child: Text(
                          "Unesite vašu broj telefona.",
                          style: TextStyle(fontSize: 12),
                        )),
                    Padding(
                      padding: EdgeInsets.only(left: 20, right: 20),
                      child: SizedBox(
                          width: 300,
                          child: TextField(
                            controller: _drzava,
                            decoration: InputDecoration(
                                hintText: "npr. SAD",
                                border: OutlineInputBorder(
                                    borderRadius:
                                    BorderRadius.all(Radius.circular(10))),
                                labelText: "Država"),
                          )),
                    ),
                    Padding(
                        padding: EdgeInsets.only(bottom: 20, top: 10),
                        child: Text(
                          "Unesite državu u kojoj boravite",
                          style: TextStyle(fontSize: 12),
                        )),
                    Padding(
                      padding: EdgeInsets.only(left: 20, right: 20),
                      child: SizedBox(
                          width: 300,
                          child: TextField(
                            controller: _godine,
                            decoration: InputDecoration(
                              hintText: "mm/dd/yyyy",
                                border: OutlineInputBorder(
                                    borderRadius:
                                    BorderRadius.all(Radius.circular(10))),
                                labelText: "Godine"),

                          )),
                    ),
                    Padding(
                        padding: EdgeInsets.only(bottom: 20, top: 10),
                        child: Text(
                          "Unesite vaš datum rođenja",
                          style: TextStyle(fontSize: 12),
                        )),
                    Padding(
                        padding:
                        EdgeInsets.only(top: 30, bottom: 0, left: 20, right: 20),
                        child: SizedBox(
                            width: 130,
                            height: 40,
                            child: OutlinedButton(
                            onPressed: () => {register()},
                            style: ButtonStyle(
                              shape: MaterialStateProperty.all(
                                RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(10.0),
                                ),
                              ),
                            ),
                            child: const Text("Registracija",
                                style: TextStyle(fontSize: 20, color: Colors.blue,fontWeight: FontWeight.w300),
                                textAlign: TextAlign.center),
                          ),
                        )
                    ),

                    Padding(
                        padding: EdgeInsets.only(bottom: 20, top: 50,left: 50.0, right: 50.0),
                        child: Text(
                          "Qui nobis reprehenderit explicabo voluptate. Voluptates molestiae in molestias aut sit vel est aut. +000 000 000",
                          textAlign: TextAlign.center,
                          style: TextStyle(fontSize: 12, color: Colors.lightBlue),
                        )),
                  ],
                );
              }
          ),
        ),
      ),
    );
  }
}
