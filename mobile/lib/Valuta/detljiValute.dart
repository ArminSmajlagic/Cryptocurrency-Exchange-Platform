import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert' as convert;
import 'package:line_chart/charts/line-chart.widget.dart';
import 'package:line_chart/model/line-chart.model.dart';
import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:provider/provider.dart';
import 'package:mobile/Models/detaljiValuteReport.dart';

import 'package:mobile/Models/ponuda.dart';
import 'package:mobile/Models/valuta.dart';
import 'package:mobile/Trading/sell.dart';
import 'package:mobile/Valuta/ValutaProvider.dart';

import '../Models/historijskiPodaci.dart';
import '../Trading/buy.dart';
import '../routing.dart';

class DetaljiValute extends StatefulWidget {
  int valuta_id = 0;
  Valuta valuta;

  DetaljiValute({required this.valuta}) {
    valuta_id = valuta.valutaId;
  }

  @override
  _DetaljiValuteState createState() => _DetaljiValuteState(valuta: valuta);
}

enum filteri { H, D, M, Q, Y }

class _DetaljiValuteState extends State<DetaljiValute> {
  ValutaProvider? _valutaProvider;
  KriptoReport? report = null;
  List<LineChartModel> chartData = [];
  String chartDataNullMessage = "";
  @override
  void initState() {
    super.initState();
    _valutaProvider = context.read<ValutaProvider>();

    loadData();
  }

  Valuta valuta;
  bool firstTime = true;
  _DetaljiValuteState({required this.valuta});

  void changeFilter(var filter) {
    print(filter);
  }

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width * 0.7;
    double chartWidth = MediaQuery.of(context).size.width;
    // double height = MediaQuery.of(context).size.width*0.2;
    Paint circlePaint = Paint()..color = Colors.black;

    Paint insideCirclePaint = Paint()..color = Colors.white;

    Paint linePaint = Paint()
      ..strokeWidth = 3
      ..style = PaintingStyle.stroke
      ..color = Colors.black;
    return Scaffold(
        appBar: AppBar(
          title: Text(valuta.oznaka + " Trading"),
        ),
        body: SingleChildScrollView(
          child: Container(
            margin: EdgeInsets.only(top: 20, bottom: 20, left: 10, right: 10),
            decoration: const BoxDecoration(
              borderRadius: BorderRadius.all(Radius.circular(10)),
              border: Border(
                top: BorderSide(width: 4.0, color: Colors.blue),
                left: BorderSide(width: 4.0, color: Colors.blue),
                right: BorderSide(width: 4.0, color: Colors.blue),
                bottom: BorderSide(width: 4.0, color: Colors.blue),
              ),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Row(mainAxisAlignment: MainAxisAlignment.center, children: [
                  Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      SizedBox(height: 30),
                      Text(
                        valutaNazivPipe(valuta.naziv) +
                            " (" +
                            valuta.oznaka +
                            ")" +
                            "\n" +
                            '\$ ' +
                            valuta.vrijednost.toString(),
                        style: TextStyle(
                            fontSize: 23, fontWeight: FontWeight.bold),
                      ),
                    ],
                  ),
                  Padding(padding: EdgeInsets.only(left: 20)),
                  Container(
                      margin: EdgeInsets.only(top: 20),
                      child: Image(
                        image: NetworkImage(valuta.logoUrl),
                        height: 80.0,
                        width: 80.0,
                        errorBuilder: (BuildContext context, Object obj,
                            StackTrace? trace) {
                          return Image.asset(
                            'assets/cryptoImages/crypto.png',
                            height: 80.0,
                            width: 80.0,
                          );
                        },
                      )),
                ]),
                SizedBox(height: 30),
                Text(chartDataNullMessage + "\n", textAlign: TextAlign.center),
                Text(
                  "Ponašanje cijene kroz vrijeme",
                  style: TextStyle(fontSize: 17, fontWeight: FontWeight.bold),
                ),
                SizedBox(height: 20),
                Container(
                  height: 235,
                  decoration: BoxDecoration(
                    color: Color.fromARGB(255, 255, 255, 255),
                    borderRadius: BorderRadius.all(Radius.circular(10)),
                    border: Border(
                      top: BorderSide(width: 2.0, color: Colors.black),
                      left: BorderSide(width: 2.0, color: Colors.black),
                      right: BorderSide(width: 2.0, color: Colors.black),
                      bottom: BorderSide(width: 2.0, color: Colors.black),
                    ),
                  ),
                  width: MediaQuery.of(context).size.width * 0.8,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      LineChart(
                        width: chartWidth,
                        height: 220,
                        data: chartData,
                        linePaint: linePaint,
                        // circlePaint: circlePaint,
                        showPointer: true,
                        // showCircles: true,
                        customDraw: (Canvas canvas, Size size) {},
                        linePointerDecoration: BoxDecoration(
                          color: Colors.black,
                        ),
                        pointerDecoration: BoxDecoration(
                          shape: BoxShape.circle,
                          color: Colors.black,
                        ),
                        // insideCirclePaint: insideCirclePaint,
                      ),
                    ],
                  ),
                ),
                SizedBox(height: 20),
                Text(
                  "Statistika kriptovalute",
                  style: TextStyle(fontSize: 17, fontWeight: FontWeight.bold),
                ),
                Container(
                    decoration: const BoxDecoration(
                      color: Color.fromARGB(255, 199, 230, 255),
                      borderRadius: BorderRadius.all(Radius.circular(10)),
                      border: Border(
                        top: BorderSide(
                            width: 4.0,
                            color: Color.fromARGB(255, 19, 149, 255)),
                        left: BorderSide(
                            width: 4.0,
                            color: Color.fromARGB(255, 19, 149, 255)),
                        right: BorderSide(
                            width: 4.0,
                            color: Color.fromARGB(255, 19, 149, 255)),
                        bottom: BorderSide(
                            width: 4.0,
                            color: Color.fromARGB(255, 19, 149, 255)),
                      ),
                    ),
                    margin: EdgeInsets.only(top: 30, left: 10, right: 10),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceAround,
                      children: [
                        Column(
                          children: getStatistikaWidgetTop(),
                        ),
                        Column(children: getStatistikaWidgetBottom()),
                      ],
                    )),
                SizedBox(
                  height: 50,
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    SizedBox(
                      width: 100,
                      child: Container(
                        padding: EdgeInsets.all(10),
                        child: OutlinedButton(
                          onPressed: () {
                            if (AuthServis.user_id != 0) {
                              Navigator.of(context).push(MaterialPageRoute(
                                  builder: (context) =>
                                      BuyScreen(valuta: valuta)));
                            } else {
                              Navigator.of(context).pushReplacement(
                                  MaterialPageRoute(
                                      builder: (context) =>
                                          RouterPage(ruta: 3)));
                            }
                          },
                          child: Text(
                            "Kupi",
                            textAlign: TextAlign.center,
                            style: TextStyle(fontWeight: FontWeight.bold),
                          ),
                          style: ButtonStyle(
                            shape: MaterialStateProperty.all(
                              RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(10.0),
                              ),
                            ),
                          ),
                        ),
                      ),
                    ),
                    SizedBox(width: 40),
                    SizedBox(
                      width: 100,
                      child: Container(
                        padding: EdgeInsets.all(10),
                        child: OutlinedButton(
                          onPressed: () => {
                            if (AuthServis.user_id != 0)
                              {
                                Navigator.of(context).push(MaterialPageRoute(
                                    builder: (context) =>
                                        SellScreen(valuta: valuta)))
                              }
                            else
                              {
                                Navigator.of(context).pushReplacement(
                                    MaterialPageRoute(
                                        builder: (context) =>
                                            RouterPage(ruta: 3)))
                              }
                          },
                          child: Text("Prodaj",
                              textAlign: TextAlign.center,
                              style: TextStyle(fontWeight: FontWeight.bold)),
                          style: ButtonStyle(
                            shape: MaterialStateProperty.all(
                              RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(10.0),
                              ),
                            ),
                          ),
                        ),
                      ),
                    ),
                    SizedBox(height: 20),
                  ],
                )
              ],
            ),
          ),
        ));
  }

  loadData() async {
    var result1 = await _valutaProvider!.GetStats(valuta.valutaId);
    var result2 = await _valutaProvider!.GetChartData(valuta.valutaId);
    DateTime? date = null;
    setState(() {
      report = result1;

      if (result2.length == 0) {
        chartDataNullMessage =
            "Valuta ne posjeduje historijske podatke - (Nema chart i statistiku)";
      }

      result2.forEach((element) => {
            date = DateTime.tryParse(
                mjeseci.indexOf(element.date!.substring(0, 3)).toString() +
                    "/" +
                    element.date!.substring(4, 6) +
                    "/" +
                    element.date!.substring(7, 10)),
            chartData.add(LineChartModel(
                amount: element.close, date: DateTime.tryParse(element.date!)))
          });
    });
  }

  List<Widget> getStatistikaWidgetTop() {
    if (report == null) {
      return [Text("Loading ")];
    }

    return [
      Text(
        "Open AVG. : " + report!.openAvg!.toStringAsFixed(2),
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
      ),
      SizedBox(
        height: 15,
      ),
      Text(
        "Close AVG. : " + report!.closeAvg!.toStringAsFixed(2),
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
      ),
      SizedBox(
        height: 15,
      ),
      Text(
        "LOW AVG. : " + report!.lowAvg!.toStringAsFixed(2),
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
      ),
      SizedBox(
        height: 15,
      ),
      Text(
        "High AVG. : " + report!.highAvg!.toStringAsFixed(2),
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
      ),
    ];
  }

  List<Widget> getStatistikaWidgetBottom() {
    if (report == null) {
      return [Text("statistika...")];
    }

    return [
      Text(
        "Rank : " + report!.rank!.toString(),
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
      ),
      SizedBox(
        height: 15,
      ),
      Text(
        "Market cap :" + report!.cap!.toStringAsFixed(2),
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
      ),
      SizedBox(
        height: 15,
      ),
      Text(
        "Volume : " + report!.volume!.toStringAsFixed(2),
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
      ),
    ];
  }

  String valutaNazivPipe(String naziv){
    if(naziv.length>15){
      return naziv.substring(0,12)+"...";
    }

    return naziv;
  }

  List<String> mjeseci = [
    'Jan',
    'Feb',
    'Mar',
    'Apr',
    'May',
    'Jun',
    'Jul',
    'Aug',
    'Sep',
    'Oct',
    'Nov',
    'Dec',
  ];
}
