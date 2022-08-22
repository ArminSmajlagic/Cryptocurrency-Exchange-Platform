import 'dart:convert';
import 'dart:io';

import 'package:flutter/foundation.dart';
import 'package:http/http.dart' as http;
import 'package:http/io_client.dart';
import 'package:mobile/Auth/Servis/authServis.dart';

abstract class BaseProvider<T> with ChangeNotifier{
  String? _server;
  String? _endpoint;

  BaseProvider(String endpoint){
    _endpoint = endpoint;
    _server = const String.fromEnvironment("baseUrl",defaultValue: "https://rs2seminarski.herokuapp.com");
  }

  Future<List<T>> GetAll() async{
    var url = Uri.parse("$_server/$_endpoint");

    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.get(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization":token,
      "Client":"mobile",
      "Role":"Trader"
    });



    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);
      
      try {
        var data = body.map((x)=> fromJson(x)).cast<T>().toList();
        return data;
        
      } catch (e) {
        throw Exception(e.toString());

      }
    }else
      throw Exception("GetAll http call for $_endpoint has failed!");
  }

  Future<T> GetById(id, [dynamic additionalData]) async{
    var url = Uri.parse("$_server/$_endpoint/$id");
    
    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.get(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization":token,
      "Role":"Trader",
      "Client":"mobile"
    });

    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);

      return fromJson(body);

    }else
      throw Exception("GetAll http call for $_endpoint has failed!");
  }

  Future<T?> Update(data,id) async{
    var url = Uri.parse("$_server/$_endpoint/$id");

    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.put(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization":token,
      "Role":"Trader",
      "Client":"mobile"
    },body: jsonEncode(data));

    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);
      var data = body.map((x)=> fromJson(x)).cast<T>();
      return data;
    }else
      throw Exception("GetAll http call for $_endpoint has failed!");
  }

  Future<T?> Insert(data) async{
    var url = Uri.parse("$_server/$_endpoint");

    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.post(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization":token,
      "Role":"Trader",
      "Client":"mobile"
    },body: jsonEncode(data));

    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);
      var data = body.map((x)=> fromJson(x)).cast<T>();
      return data;
    }else
      throw Exception("GetAll http call for $_endpoint has failed!");
  }

  T fromJson(entity){
    throw Exception("Override this method!");
  }
}