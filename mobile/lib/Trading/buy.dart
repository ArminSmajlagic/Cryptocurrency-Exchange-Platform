import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';
import 'package:mobile/Models/valuta.dart';
import 'package:mobile/Trading/narudzbeProvider.dart';

import '../Models/narudzba.dart';

class BuyScreen extends StatefulWidget {
  Valuta? valuta = null;

  BuyScreen({required this.valuta,Key? key}) : super(key: key);
  
  @override
  State<StatefulWidget> createState() => _KupiState(valuta: this.valuta);
}

class _KupiState extends State<StatefulWidget>{

  Valuta? valuta = null;
  _KupiState({required this.valuta});
  Narudzba _narudzba = new Narudzba();
  NarudzbaProvider? _narudzbaProvider = null;

  TextEditingController _valutaIznos = new TextEditingController();
  TextEditingController _wcashIznos = new TextEditingController();
  TextEditingController _valuta = new TextEditingController();
  @override
  void initState(){
    _narudzbaProvider = context.read<NarudzbaProvider>();
    _valuta.text = valuta!.naziv;
  }

  @override
  Widget build(BuildContext context) {
        return Scaffold(
      appBar: AppBar(
        title: Text("Kupi valutu"),
      ),
      body: SingleChildScrollView(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Container(
              margin: EdgeInsets.only(top: 30, left: 20),
              width: 220,
              child: Text(
                "Kupovina kripto valute",
                style: TextStyle(fontWeight: FontWeight.w900, fontSize: 22),
                textAlign: TextAlign.center,
              ),
            ),
            Column(children: [
              Container(
                margin: EdgeInsets.only(top: 50),
                width: 400,
                height: 100,
                child: Stack(
                  alignment: Alignment.topLeft,
                  children: [
                    Container(
                      child: Text(
                        "Kripto valuta",
                        style: TextStyle(fontSize: 20),
                      ),
                      margin: EdgeInsets.only(left: 30, top: 0, bottom: 40),
                    ),
                    Positioned(
                      left: 20,
                      top: 40,
                      width: 200,
                      child: TextField(   
                        enabled: false,                                           
                        controller: _valuta,
                        decoration: InputDecoration(
                          filled: true,
                          fillColor: Color.fromRGBO(0, 102, 255, .2),
                          enabledBorder: OutlineInputBorder(
                              borderRadius:
                                  BorderRadius.all(Radius.circular(5)),
                              borderSide: BorderSide(
                                  width: 2,
                                  color: Color.fromRGBO(46, 131, 255, 1))),
                        ),
                      ),
                    ),
                    Positioned(
                      top: 28,
                      right: 5,
                      child: Row(
                        children: [                        
                          Container(
                            child: Text(
                              "Ovo je valuta koju kupujete.",
                              textAlign: TextAlign.center,
                            ),
                            width: 150,
                            margin: EdgeInsets.only(left: 20),
                          )
                        ],
                      ),
                    ),
                  ],
                ),
              ),
              Container(
                margin: EdgeInsets.only(top: 30),
                width: 400,
                height: 100,
                child: Stack(
                  alignment: Alignment.topLeft,
                  children: [
                    Container(
                      child: Text(
                        "Količina valute",
                        style: TextStyle(fontSize: 20),
                      ),
                      margin: EdgeInsets.only(left: 30, top: 0, bottom: 40),
                    ),
                    Positioned(
                      left: 20,
                      top: 40,
                      width: 200,
                      child: TextField(
                       onChanged: (String value){
                        updateWCashValue();
                       },
                       controller: _valutaIznos,
                       decoration: InputDecoration(
                          filled: true,
                          fillColor: Color.fromRGBO(0, 102, 255, .2),
                          hintText: "Količina valute",
                          enabledBorder: OutlineInputBorder(
                              borderRadius:
                                  BorderRadius.all(Radius.circular(5)),
                              borderSide: BorderSide(
                                  width: 2,
                                  color: Color.fromRGBO(46, 131, 255, 1))),
                        ),
                      ),
                    ),
                    Positioned(
                        width: 150,
                        right: 10,
                        top: 40,
                        child: Text(
                          "Unesite željenu količinu valute koju kupujete.",
                          textAlign: TextAlign.center,
                        )),
                  ],
                ),
              ),
              Container(
                margin: EdgeInsets.only(top: 30),
                width: 400,
                height: 100,
                child: Stack(
                  alignment: Alignment.topLeft,
                  children: [
                    Container(
                      child: Text(
                        "Iznos u WCash-u",
                        style: TextStyle(fontSize: 20),
                      ),
                      margin: EdgeInsets.only(left: 30, top: 0, bottom: 40),
                    ),
                    Positioned(
                      left: 20,
                      top: 40,
                      width: 200,
                      child: TextField(
                       enabled: false,                                           
                       controller: _wcashIznos,
                       decoration: InputDecoration(
                          filled: true,
                          fillColor: Color.fromRGBO(0, 102, 255, .2),
                          hintText: "Iznos valute u WCash-u",
                          enabledBorder: OutlineInputBorder(
                              borderRadius:
                                  BorderRadius.all(Radius.circular(5)),
                              borderSide: BorderSide(
                                  width: 2,
                                  color: Color.fromRGBO(46, 131, 255, 1))),
                        ),
                      ),
                    ),
                    Positioned(
                        width: 150,
                        right: 10,
                        top: 40,
                        child: Text(
                          "Ovoliko WCash-a ce se skinuti iz vašeg kripto novčanika po izvršenju narudžbe.",
                          textAlign: TextAlign.center,
                        )),
                  ],
                ),
              ),
              SizedBox(height: 40),
              Text("Sve kupovine i prodaje se vrše u in-app kreditu (WCash-u)"),
              SizedBox(height: 40),
              OutlinedButton(
                child: Container(
                  padding: EdgeInsets.all(10),
                  child: Text("Potvrdi Kupovinu",
                      style: TextStyle(
                          fontWeight: FontWeight.w400,
                          fontSize: 20,
                          color: Colors.black)),
                ),
                onPressed: () {
                  kupiValutu();
                },
                style: ButtonStyle(
                    shape: MaterialStateProperty.all(
                      RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(10.0),
                      ),
                    ),
                    side: MaterialStateProperty.all(BorderSide(
                        color: Colors.blue,
                        width: 2.0,
                        style: BorderStyle.solid))),
              ),
              Center(
                child: Container(
                  width: 200,
                  margin: EdgeInsets.only(top: 80),
                  child: Text(
                    "For user support contact us vi email.example@mail.com",
                    style: TextStyle(color: Colors.lightBlue),
                    textAlign: TextAlign.center,
                  ),
                ),
              )
            ])
          ],
        ),
      ),
    );
  }
  
  void kupiValutu() async{
    var narudzba = new Narudzba();
    narudzba.kolicina = double.parse(_valutaIznos.text);
    narudzba.cijena = double.parse(_wcashIznos.text);
    narudzba.valutaId = valuta!.valutaId;
    narudzba.tip = 1;

    await _narudzbaProvider!.Buy(narudzba);

    Navigator.of(context).pop();
  }
  
  void updateWCashValue() {
    setState(() {
      _wcashIznos.text = (valuta!.vrijednost*double.parse(_valutaIznos.text)).toString();
    });
  }
}