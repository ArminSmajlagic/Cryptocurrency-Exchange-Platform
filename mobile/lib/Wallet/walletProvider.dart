import 'dart:convert';
import 'dart:convert' as convert;

import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/foundation.dart';

import '../Models/Wallet.dart';
import '../Models/assets.dart';
import '../Models/walletTransakcija.dart';

class WalletProvider with ChangeNotifier{
    String? _server;

  Wallet? wallet = null;
  List<WalletImovina>? imovina = null;

  WalletProvider() : super(){
    _server = const String.fromEnvironment("baseUrl",defaultValue: "https://rs2seminarski.herokuapp.com");
  }



  Future<Wallet> GetWallet([dynamic additionalData]) async{

    var id =AuthServis.readUserId().toString();

    var url = Uri.parse(_server!+"/Wallet/$id/getWalletData");
    
    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.get(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization" : token,
      "Client":"mobile",
      "Role":"Trader"
    });

    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);
      print(body);
      wallet = Wallet.fromJson(body);
      print(wallet!.id);

      return wallet!;
    }else
      throw Exception("Method GetWallet (geting id wallet) failed :(_-_---__-");

  }

  Future<List<WalletImovina>> GetImovina([dynamic additionalData]) async{

    var id = wallet?.id.toString();

    var url = Uri.parse(_server!+"/Wallet/$id/GetCryptoAssets/");
    
    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.get(url,headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization" : token,
      "Client":"mobile",
      "Role":"Trader"
    });

    if(respons.statusCode == 200) {

      var body = jsonDecode(respons.body);
      print(body);

      imovina = body.map((x)=>WalletImovina.fromJson(x)).cast<WalletImovina>().toList();

      return imovina!;

    }else
      throw Exception("Method GetWallet (geting id wallet) failed :(_-_---__-");
  }

  Future Deposit(WalletTransakcija transakcija) async{


    transakcija.walletId = wallet?.id;

    var body = transakcija.toJson(transakcija);

    var url = Uri.parse(_server!+"/Wallet/DodajWalletTransakciju");
    
    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.post(url,body:convert.json.encode(body),headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization" : token,
      "Client":"mobile",
      "Role":"Trader"
    });

    if(respons.statusCode == 200) {
      
      var body = jsonDecode(respons.body);
      print(body);

    }else
      throw Exception("Method Deposit (geting id wallet) failed :(_-_---__-");
  }

  Future Withdraw(WalletTransakcija transakcija) async{

    transakcija.walletId = wallet?.id;
    
    var body = transakcija.toJson(transakcija);

    var url = Uri.parse(_server!+"/Wallet/DodajWalletTransakciju");
    
    var token = "Bearer " + await AuthServis.readToken();

    var respons = await http.post(url,body:convert.json.encode(body),headers: {
      "content-type": "application/json",
      "accept": "plain/text",
      "Authorization" : token,
      "Client":"mobile",
      "Role":"Trader"
    });

    if(respons.statusCode == 200) {
      var body = jsonDecode(respons.body);
      print(body);
    }else
      throw Exception("Method Depozit (geting id wallet) failed :(_-_---__-");
  }
}