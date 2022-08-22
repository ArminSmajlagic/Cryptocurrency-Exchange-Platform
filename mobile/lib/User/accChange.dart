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

class AccountChange extends StatefulWidget {
  @override
  _AccountState createState() => _AccountState();
}

class _AccountState extends State<AccountChange> {
  User user = new User();
  String username = "";
  UserProvider? _userProvider = null;

  @override
  void initState() {
    super.initState();

    _userProvider = context.read<UserProvider>();

    loadUser();
  }

  Future loadUser() async {
    var user_id = AuthServis.readUserId();

    var respons = await _userProvider!.GetById(user_id);

    setState(() {
      user = respons;
      name.text = user.imePrezime;
      country.text = user.drzava;
      mail.text = user.email;
      number.text = user.brojTelefona;
    });
  }

  final name = TextEditingController();
  final country = TextEditingController();
  final number = TextEditingController();
  final mail = TextEditingController();

  var client = http.Client();

  @override
  Widget build(BuildContext context) {

    void saveChanges() async {
      var id = AuthServis.readUserId();
      String url = "https://localhost:7291/main_vi_api/UserWrite/" +
          id.toString();
      Map<String, String> headers = {'Content-Type': 'application/json'};

      var obj = {
        'ime_prezime': name.text,
        'email': mail.text,
        'drzava': country.text,
        'broj_telefona': number.text
      };

      var token = "Bearer " + await AuthServis.readToken();

      var response = await client
          .post(Uri.parse(url), body: convert.json.encode(obj), headers: {
        "content-type": "application/json",
        "accept": "plain/text",
        "Authorization": token,
        "Client":"mobile",
        "Role":"Trader"
      });

      if (response.statusCode == 200) {
        Navigator.of(context).pop();
        Navigator.pushReplacement(
            context,
            MaterialPageRoute<void>(
                builder: (BuildContext context) => RouterPage(ruta: 0)));
      } else {
        throw Exception(
            'Unexpected error occured in method accChange.saveChanges !');
      }

    }

    return Scaffold(
      appBar: AppBar(
          backgroundColor: Colors.blue[100],
          title: const Text('Promjena detalja racuna',
              style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.w500,
                  fontSize: 25))),
      body: Center(
        child: Container(
          child: Column(
            children: [
              Container(
                  margin: EdgeInsets.only(top: 20),
                  child: SizedBox(
                      width: 300,
                      child: TextField(
                          decoration: InputDecoration(
                              border: OutlineInputBorder(
                                  borderRadius:
                                      BorderRadius.all(Radius.circular(10))),
                              labelText: "Ime prezime"),
                          controller: name))),
              Container(
                  margin: EdgeInsets.only(top: 20),
                  child: SizedBox(
                      width: 300,
                      child: TextField(
                        decoration: InputDecoration(
                            border: OutlineInputBorder(
                                borderRadius:
                                    BorderRadius.all(Radius.circular(10))),
                            labelText: "Email"),
                        controller: mail,
                      ))),
              Container(
                  margin: EdgeInsets.only(top: 20),
                  child: SizedBox(
                      width: 300,
                      child: TextField(
                          decoration: InputDecoration(
                              border: OutlineInputBorder(
                                  borderRadius:
                                      BorderRadius.all(Radius.circular(10))),
                              labelText: "Država"),
                          controller: country))),
              Container(
                  margin: EdgeInsets.only(top: 20),
                  child: SizedBox(
                      width: 300,
                      child: TextField(
                          decoration: InputDecoration(
                              border: OutlineInputBorder(
                                  borderRadius:
                                      BorderRadius.all(Radius.circular(10))),
                              labelText: "Broj telefona"),
                          controller: number))),
              SizedBox(
                  width: 200,
                  height: 70,
                  child: Container(
                    margin: EdgeInsets.only(top: 30),
                    child: OutlinedButton(
                      style: ButtonStyle(
                        shape: MaterialStateProperty.all(
                          RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                        ),
                      ),
                      onPressed: () => saveChanges(),
                      child: Text("Spremite vaše promjene",
                          textAlign: TextAlign.center),
                    ),
                  ))
            ],
          ),
        ),
      ),
    );
  }
}
