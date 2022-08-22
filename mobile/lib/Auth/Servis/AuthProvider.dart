import 'package:flutter/cupertino.dart';
import 'dart:io';
import 'package:http/http.dart' as http;
import 'package:http/io_client.dart';
import 'package:mobile/Models/AuthRequest/loginRequest.dart';
import 'package:mobile/Models/AuthRequest/registerRequest.dart';
import 'package:mobile/Models/AuthRequest/verificationRequest.dart';
import 'dart:convert' as convert;

import 'authServis.dart';

class AuthProvider with ChangeNotifier{
  String? _server;



  AuthProvider(){
   _server = const String.fromEnvironment("baseUrl",defaultValue: "https://rs2seminarski.herokuapp.com");
  }

  Future<bool> login(LoginRequest request) async{
    var url = _server! + "/auth_api/Auth/Login";
    var loginRequest = {'username':request.username,'lozinka':request.password};
    var uri = Uri.parse(url);

    var response = await http.post(uri,body: convert.json.encode(loginRequest),headers:  {
      "content-type" : "application/json",
      "accept" : "plain/text",
      "Client":"mobile",
      "Role":"Trader"
    });


    if (response.statusCode == 200) {
      if(convert.json.decode(response.body)['value']!=null) {
        AuthServis.storeToken(convert.json.decode(response.body)['value'], convert.json.decode(response.body)['user_id']);
        return true;
      }else {
        return false;
      }
    } else {
      print('Unexpected error occured in method login !');

      return false;
    }
  }
  //registracija

  Future<bool> register(RegisterRequest request) async{
    var url = _server! + "/auth_api/Auth/Register";


    var registerRequest = {
      'username':request.username,
      'lozinka':request.password,
      'ime_prezime':request.ime_prezime,
      'email':request.email,
      'broj_telefona':request.brojtelefona,
      'drzava':request.drzava,
      'spol': 1
    };

    var response = await http.post(
        Uri.parse(url), body: convert.json.encode(registerRequest), headers: {
        "content-type": "application/json",
        "accept": "plain/text",
        "Client":"mobile",
        "Role":"Trader"
      });

    if (response.statusCode == 200) {
      if(convert.json.decode(response.body)['value']!=null) {
        AuthServis.storeToken(convert.json.decode(response.body)['value'], convert.json.decode(response.body)['user_id']);
        return true;
      }else {
        return false;
      }
    } else {
      print('Unexpected error occured in method register !');
      return false;
    }
  }
  //verifiakcija
Future<bool> verify(VerificationRequest request) async{
    var url = _server! + "/auth_api/Auth/Verify/Email";

    var confReq = {
      "code":request.code,
      "user_id":request.id
    };

    var resp = await http.post(Uri.parse(url),body: convert.json.encode(confReq),headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Client":"mobile",
      "Role":"Trader"
    });

    if(resp.statusCode==200){
      return true;
    }else{
      print('Unexpected error occured in method loadUser !');
      return false;
    }

  }
  //logout
}