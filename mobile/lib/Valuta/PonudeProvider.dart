import 'dart:convert';

import 'package:mobile/BaseProvider.dart';
import 'package:mobile/Models/ponuda.dart';
import 'package:mobile/Models/valuta.dart';
import 'package:http/http.dart' as http;

import '../Auth/Servis/authServis.dart';

class PonudeProvider extends BaseProvider<Ponuda>{
  String? _server;

  PonudeProvider() : super("Ponuda"){
    _server = const String.fromEnvironment("baseUrl",defaultValue: "https://rs2seminarski.herokuapp.com");
  }

  Future<List<Valuta>> GetCBFOptimized() async {

  if(AuthServis.user_id==0)
    return [];

  var id = AuthServis.readUserId();
  
  var url = Uri.parse(_server!+"/Valuta/CBF/$id");
    
    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.get(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization":token,
      "Client":"mobile",
      "Role":"Trader"
    });

    if(respons.statusCode == 200) {
      print("ok");
      var body = jsonDecode(respons.body);
      var result = body.map((x)=>Valuta.fromJson(x)).cast<Valuta>().toList();
      return result;
    }else
      throw Exception("GetCBFOptimized http call has failed!"); 
    }

    

  @override
  Ponuda fromJson(entity){
    return Ponuda.fromJson(entity);
  }  
}