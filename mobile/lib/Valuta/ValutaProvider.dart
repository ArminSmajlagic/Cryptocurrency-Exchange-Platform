
import 'dart:convert';

import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:mobile/BaseProvider.dart';
import 'package:mobile/Models/historijskiPodaci.dart';
import 'package:mobile/Models/valuta.dart';
import 'package:http/http.dart' as http;


import 'package:mobile/Trading/HistorijaTransakcija.dart';

import '../Models/detaljiValuteReport.dart';

class ValutaProvider extends BaseProvider<Valuta>{
  String? _server;



 ValutaProvider():super("Valuta"){

  _server = const String.fromEnvironment("baseUrl",defaultValue: "https://rs2seminarski.herokuapp.com");
 }


  Future<KriptoReport> GetStats(int id) async{
  var url = Uri.parse(_server!+"/Valuta/$id/Stats");
    
    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.get(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Client":"mobile",
      "Role":"Trader"
      // "Authorization":token
    });

    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);

      return KriptoReport.fromJson(body);

    }else
      throw Exception("GetStats http call has failed!");  }

  Future<List<HistorijskiPodaci>> GetChartData(int id) async{
  var url = Uri.parse(_server!+"/Valuta/$id/history");
    
    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.get(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Client":"mobile",
      "Role":"Trader"
      // "Authorization":token
    });

    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);

      return body.map((x)=>HistorijskiPodaci.fromJson(x)).cast<HistorijskiPodaci>().toList();
    }else
      throw Exception("GetChartData http call has failed!");  }

  @override
  Valuta fromJson(entity){
    return Valuta.fromJson(entity);
  }
}