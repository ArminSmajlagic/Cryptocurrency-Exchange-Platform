import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:provider/provider.dart';
import 'package:mobile/Auth/Servis/authServis.dart';
import 'dart:convert' as convert;

import 'package:mobile/Models/ponuda.dart';
import 'package:mobile/Models/valuta.dart';
import 'package:mobile/Valuta/PonudeProvider.dart';
import 'package:mobile/Valuta/ValutaProvider.dart';
import 'package:mobile/Valuta/detljiValute.dart';

class Trade extends StatefulWidget {
  @override
  _TradeState createState() => _TradeState();
}

class _TradeState extends State<Trade> {
  List<Ponuda> _ponude = [];
  List<Valuta> _valuteFiltrirano = [];
  List<Valuta> _valute = [];
  List<Valuta> _valuteCBF = [];

  ValutaProvider? _valutaProvider = null;
  PonudeProvider? _ponudeProvider = null;

  @override
  void initState() {
    super.initState();

    _valutaProvider = context.read<ValutaProvider>();
    _ponudeProvider = context.read<PonudeProvider>();

    loadValuteCBF();
    loadValute();
    loadCategories();

    if (_valuteCBF.length > 1) loadPageData(1);
  }

  Future loadValute() async {
    var tempData = await _valutaProvider?.GetAll();

    setState(() {
      _valute = tempData!;
      _valuteFiltrirano = _valute;
    });
  }

  Future loadValuteCBF() async {
    var tempData1 = await _ponudeProvider?.GetCBFOptimized();

    setState(() {
      _valuteCBF = tempData1!;
    });
  }

  Future loadCategories() async {
    var tempData = await _ponudeProvider?.GetAll();

    setState(() {
      _ponude = tempData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    double c_width = MediaQuery.of(context).size.width * 0.8;

    return Scaffold(
        appBar: AppBar(
            backgroundColor: Colors.blue[100],
            title: const Text('Crypto Trading',
                style: TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.w500,
                    fontSize: 25))),
        body: Container(
            child: ListView(
          children: [
            Container(
              child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: getPonudeWidgets()),
              padding: EdgeInsets.only(bottom: 15),
              margin: EdgeInsets.only(top: 20, bottom: 25),
              decoration: BoxDecoration(
                  border: Border(
                bottom: BorderSide(width: 2.0, color: Colors.lightBlueAccent),
              )),
            ),
            Column(
              children: getValuteWidgets(c_width),
              mainAxisAlignment: MainAxisAlignment.center,
            ),
          ],
        )));
  }

  loadPageData(int id) {
    setState(() {
      if (id == 1){
        if(!_valuteCBF.isEmpty){
          _valuteFiltrirano = _valuteCBF;
        }
        else{
          var temp = _valute;
          temp.sort((a,b)=> a.rank.compareTo(b.rank));
          _valuteFiltrirano = temp;
        }
      }
      else{
        _valuteFiltrirano =
            _valute.where((element) => element.ponudaId == id).toList();
      }
    });
  }

  List<Widget> getPonudeWidgets() {
    List<Widget> ponude = [];

    if (_ponude.length == 0) {
      return [Text("Loading ponude...")];
    }

    ponude = _ponude
        .map((e) => GestureDetector(
              child: Container(
                margin: EdgeInsets.only(left: 20),
                child: OutlinedButton(
                    style: ButtonStyle(
                      shape: MaterialStateProperty.all(
                        RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10.0),
                        ),
                      ),
                    ),
                    onPressed: () => {loadPageData(e.id)},
                    child: Text(
                      e.category.toUpperCase(),
                      style: TextStyle(fontSize: 18),
                    )),
              ),
            ))
        .cast<Widget>()
        .toList();

    return ponude;
  }

  List<Widget> getValuteWidgets(double c_width) {
    List<Widget> valute = [];

    if (_valuteFiltrirano.length == 0) {
      return [Text("Loading valute...")];
    }

    valute = _valuteFiltrirano
        .map((e) => GestureDetector(
              child: Container(
                  width: c_width,
                  height: 120,
                  margin: EdgeInsets.only(top: 10),
                  decoration: BoxDecoration(
                      border:
                          Border.all(width: 2, color: Colors.lightBlueAccent),
                      borderRadius: BorderRadius.all(Radius.circular(25))),
                  child: Container(
                      child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Column(
                              children: [
                                Text(
                                  e.naziv.length > 8
                                      ? e.naziv.substring(0, 8) + ".."
                                      : e.naziv,
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 17),
                                ),
                                Text(
                                  e.oznaka.toUpperCase() + "/" + "USD",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 17),
                                ),
                              ],
                            ),
                            Padding(padding: EdgeInsets.only(left: 10)),
                            Center(
                              child: Image.network(
                                e.logoUrl,
                                height: 40.0,
                                width: 40.0,
                                errorBuilder: (BuildContext context, Object obj,
                                    StackTrace? trace) {
                                  return Image.asset(
                                    'assets/cryptoImages/crypto.png',
                                    height: 40.0,
                                    width: 40.0,
                                  );
                                  //return Text("failed");
                                },
                              ),
                            ),
                            Column(
                              children: [
                                Text(
                                  "Vrijednost: ",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 12),
                                ),
                                Text(
                                  e.vrijednost.toString() + " USD",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 12),
                                ),
                              ],
                            )
                          ]),
                    ],
                  ))),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => DetaljiValute(valuta: e)),
                );
              },
            ))
        .cast<Widget>()
        .toList();

    return valute;
  }
}
