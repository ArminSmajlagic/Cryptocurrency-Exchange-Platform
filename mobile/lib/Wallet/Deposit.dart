import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:mobile/Wallet/wallet.dart';
import 'package:provider/provider.dart';
import 'package:mobile/Trading/narudzbeProvider.dart';
import 'package:mobile/Wallet/walletProvider.dart';

import '../Models/Wallet.dart';
import '../Models/narudzba.dart';
import '../Models/walletTransakcija.dart';

class DepostiScreen extends StatefulWidget {
  DepostiScreen({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() => _DepositState();
}

class _DepositState extends State<StatefulWidget> {
  Narudzba? narudzba = null;
  WalletProvider? _walletProvider = null;
  TextEditingController _iznosFiat = new TextEditingController();
  TextEditingController _wcashIznos = new TextEditingController();

  @override
  void initState() {
    super.initState();
    _walletProvider = context.read<WalletProvider>();
  }

  void izvrsiDepozit() async {
    int metodaId = 1;
    WalletTransakcija transakcija = WalletTransakcija();

    transakcija.vrijeme_obavljanja = DateTime.now();
    transakcija.kolicina_transakcije = double.parse(_iznosFiat.text);
    transakcija.naziv_valute = dropdownvalue;
    transakcija.tip_transakcije_id = 0;
    transakcija.tip_metode_id = metodaId;
    transakcija.wcash =  double.parse(_wcashIznos.text);
    
    await _walletProvider!.Deposit(transakcija);

    Navigator.of(context).pop();

  }

  // Initial Selected Value
  String dropdownvalue = 'USD';

  // List of items in our dropdown menu
  var items = [
    'USD',
    'EUR',
    'KM',
    'Pound',
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Deposit"),
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
                "Deposit (Uplata) u kripto novčanik",
                style: TextStyle(fontWeight: FontWeight.w900, fontSize: 22),
                textAlign: TextAlign.center,
              ),
            ),
            Column(children: [
              Container(
                margin: EdgeInsets.only(top: 100),
                width: 400,
                height: 100,
                child: Stack(
                  alignment: Alignment.topLeft,
                  children: [
                    Container(
                      child: Text(
                        "Fiat valuta",
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
                          fiatChanged();
                          
                        },
                        controller: _iznosFiat,
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
                            width: 70,
                            margin: EdgeInsets.only(right: 0),
                            child: DropdownButton(
                              // Initial Value
                              value: dropdownvalue,
                              // Down Arrow Icon
                              icon: const Icon(Icons.keyboard_arrow_down),

                              // Array list of items
                              items: items.map((String items) {
                                return DropdownMenuItem(
                                  value: items,
                                  child: Text(items),
                                );
                              }).toList(),
                              // After selecting the desired option,it will
                              // change button value to selected value
                              onChanged: (String? newValue) {
                                setState(() {
                                  dropdownvalue = newValue!;
                                });
                              },
                            ),
                          ),
                          Container(
                            child: Text(
                              "Odaberite fiat valutu te potom unesite željenu količinu te valute koju želite uplatiti.",
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
                        "WCash",
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
                          hintText: "Iznos WCash-a valute",
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
                          "Ovo polje govori koliko iznosi vaša uplata u WCashu-u.",
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
                  child: Text("Potvrdi uplatu",
                      style: TextStyle(
                          fontWeight: FontWeight.w400,
                          fontSize: 20,
                          color: Colors.black)),
                ),
                onPressed: () {
                  izvrsiDepozit();
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
  
  void fiatChanged() {

    double value = 0;
    if(dropdownvalue=="USD"){
      value = double.parse(_iznosFiat.text);
    }
    else if(dropdownvalue=="EUR")
    {
      value = double.parse(_iznosFiat.text) * 1.1;
    }
    else if(dropdownvalue=="KM"){
      value = double.parse(_iznosFiat.text) * 0.5;
    }
    else if(dropdownvalue=="Pound"){
      value = double.parse(_iznosFiat.text) * 1.3;
    }

      setState(() {
        
        _wcashIznos.text = value.toString();
      });
  }
}
