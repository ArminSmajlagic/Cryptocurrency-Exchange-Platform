import 'package:flutter/cupertino.dart';
import 'dart:convert';
import 'dart:convert' as convert;
import 'package:http/http.dart' as http;
import 'package:flutter/foundation.dart';

import 'package:mobile/Auth/Servis/authServis.dart';

import '../Models/narudzba.dart';

class NarudzbaProvider with ChangeNotifier{
  String? _server;

  NarudzbaProvider() : super(){
    _server = const String.fromEnvironment("baseUrl",defaultValue: "https://rs2seminarski.herokuapp.com");
  }

  Future<Narudzba> Buy(Narudzba entity) async{
    entity.userId = AuthServis.readUserId();

    var body = entity.toJson();

    print(body);

    var url = Uri.parse(_server!+"/Narudzba");

    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.post(url, 
    body:convert.json.encode(body),
    headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization" : token,
      "Client":"mobile",
      "Role":"Trader"
    });


    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);

      return Narudzba.fromJson(body);
    }else
      throw Exception("Method Buy (geting id wallet) failed :(_-_---__-");
  }

    Future<Narudzba> Sell(Narudzba entity) async{
    var url = Uri.parse(_server!+"/Narudzba");

    var token = "Bearer " + await AuthServis.readToken();
    entity.userId = await AuthServis.readUserId();

    var body = entity.toJson();
    var respons = await http.post(url, 
    body:convert.json.encode(body),
    headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization" : token,
      "Client":"mobile",
      "Role":"Trader"
    });


    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);

      return Narudzba.fromJson(body);
    }else
      throw Exception("Method Sell (geting id wallet) failed :(_-_---__-");
  }

    Future<List<Narudzba>> GetTransakcije(int id) async{
    var url = Uri.parse(_server!+"/Narudzba/Forms/$id");

    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.get(url, 
    headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization" : token,
      "Client":"mobile",
      "Role":"Trader"
    });


    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);
      var data = body.map((x)=>Narudzba.fromJson(x)).cast<Narudzba>().toList();
      notifyListeners();
      return data;
    }else
      throw Exception("Method Sell (geting id wallet) failed :(_-_---__-");
  }
}