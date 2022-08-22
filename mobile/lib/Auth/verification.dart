import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/Auth/Servis/AuthProvider.dart';
import 'package:mobile/Models/AuthRequest/verificationRequest.dart';
import 'dart:convert' as convert;

import 'package:mobile/routing.dart';
import 'package:provider/provider.dart';

class Verification extends StatefulWidget {
  final String mail;
  final int user_id;
  final String sms= '+*****6789';//not set on backend


  Verification({Key? key, required this.mail, required this.user_id}) : super(key: key);

  @override
  _VerificationState createState() => _VerificationState(mail: mail,user_id: user_id);

}
class _VerificationState extends State<Verification>{
  AuthProvider? _authProvider = null;

  final _code = new TextEditingController();

  final int user_id;
  final String mail;

  _VerificationState({required this.mail, required this.user_id});
  
  @override
  void initState(){
    super.initState();
    _authProvider = context.read<AuthProvider>();
  }

  void verify() async{
    var client = http.Client();
    var uri = "https://localhost:7291/auth_api/Auth/Verify/Email";

    var request = new VerificationRequest();
    request.code = _code.text;
    request.id = user_id;


    var resp = await _authProvider!.verify(request);

    if(resp){
      Navigator.pushReplacement(context,MaterialPageRoute<void>(
          builder: (BuildContext context) => RouterPage(ruta:0))
      );
    }else{
      throw Exception('Unexpected error occured in method loadUser !');
    }

  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            backgroundColor: Colors.blue[100],
            title: const Text('Verification',
                style: TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.w500,
                    fontSize: 25))),
        body: Container(
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
                child: Column(children: [
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
                          controller: _code,
                          decoration: InputDecoration(
                            border: OutlineInputBorder(
                              borderRadius: BorderRadius.all(Radius.circular(10)),
                            ),
                            labelText: "Unesite vaš kod ovdje",
                            hintText: "5-Digit code"
                          ),
                        )),
                  ),

                  Padding(
                      padding: EdgeInsets.only(bottom: 5, top: 15),
                      child: Text(
                        "Kod ste primili na",
                        style: TextStyle(fontSize: 12),
                        textAlign: TextAlign.center,
                      )),
                  Padding(
                      padding: EdgeInsets.only(top: 5,bottom: 15),
                      child: Text(
                        mail,
                        style: TextStyle(fontSize: 12),
                        textAlign: TextAlign.center,
                      )),
                  Padding(
                      padding:
                      EdgeInsets.only(top: 30, bottom: 0, left: 20, right: 20),
                      child: SizedBox(
                          width: 130,
                          height: 40,
                          child: OutlinedButton(

                            style: ButtonStyle(
                            shape: MaterialStateProperty.all(
                              RoundedRectangleBorder(
                               borderRadius: BorderRadius.circular(10.0),
                              ),
                              ),
                            ),

                            onPressed: () => {verify()},
                            child: Text("Verifikuj se",
                                style: TextStyle(
                                    fontWeight: FontWeight.w300, fontSize: 20, color: Colors.blue)),
                          ))),
                  Padding(
                      padding: EdgeInsets.only(bottom: 20, top: 50),
                      child: Text(
                        "Qui nobis reprehenderit explicabo voluptate. Voluptates molestiae in molestias aut sit vel est aut. +000 000 000",
                        textAlign: TextAlign.center,
                        style: TextStyle(fontSize: 12, color: Colors.lightBlue),
                      )),
            ]))));
  }
}
