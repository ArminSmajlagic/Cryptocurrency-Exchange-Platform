import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:mobile/Wallet/walletProvider.dart';
import 'package:mobile/Trading/HistorijaTransakcija.dart';

import '../Models/Wallet.dart';
import '../Models/assets.dart';
import 'Deposit.dart';
import 'Withdraw.dart';

class WalletScreen extends StatefulWidget {
  const WalletScreen({Key? key}) : super(key: key);

  @override
  State<WalletScreen> createState() => _WalletState();
}

class _WalletState extends State<WalletScreen> {
  Wallet? wallet = null;
  List<WalletImovina>? imovina = null;
  var valute = ["Bitcoin/", "Etherium/", "WCash/", "Cardadno/", "Shiba Inu./"];
  WalletProvider? _walletProvider = null;
  String _wCash = "loading";
  @override
  void initState() {
    super.initState();

    _walletProvider = context.read<WalletProvider>();

    loadWalletData();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            backgroundColor: Colors.blue[100],
            title: const Text('Wallet',
                style: TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.w500,
                    fontSize: 25))),
        body: SingleChildScrollView(
          child: Column(
            children: [
              Container(
                height: 250,
                child: Center(
                    child: Column(
                  children: [
                    Center(
                      child: Text(
                        "Vaša digitalna imovina",
                        style: TextStyle(
                            fontSize: 20,
                            fontWeight: FontWeight.bold,
                            color: Colors.blue),
                      ),
                    ),
                    Container(
                        margin: EdgeInsets.only(top: 50),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceAround,
                          children: [
                            Column(children: getWalletTop()),
                            Column(
                              children: getWalletBot(),
                            ),
                          ],
                        ))
                  ],
                )),
                margin: EdgeInsets.all(30),
                decoration: const BoxDecoration(
                  borderRadius: BorderRadius.all(Radius.circular(27)),
                  border: Border(
                    top: BorderSide(width: 4.0, color: Colors.blue),
                    left: BorderSide(width: 4.0, color: Colors.blue),
                    right: BorderSide(width: 4.0, color: Colors.blue),
                    bottom: BorderSide(width: 4.0, color: Colors.blue),
                  ),
                ),
              ),
              OutlinedButton(
                onPressed: () {
                  Navigator.of(context).push(
                      MaterialPageRoute(builder: (context) => DepostiScreen()));
                },
                child: Padding(
                  child: Text("Uplata",
                      style:
                          TextStyle(fontWeight: FontWeight.w400, fontSize: 20)),
                  padding:
                      EdgeInsets.only(left: 10, right: 10, top: 5, bottom: 5),
                ),
                style: ButtonStyle(
                  shape: MaterialStateProperty.all(
                    RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10.0),
                    ),
                  ),
                ),
              ),
              SizedBox(height: 20),
              OutlinedButton(
                onPressed: () {
                  Navigator.of(context).push(MaterialPageRoute(
                      builder: (context) => WithdrawScreen()));
                },
                child: Padding(
                  child: Text("Isplata",
                      style:
                          TextStyle(fontWeight: FontWeight.w400, fontSize: 20)),
                  padding:
                      EdgeInsets.only(left: 10, right: 10, top: 5, bottom: 5),
                ),
                style: ButtonStyle(
                  shape: MaterialStateProperty.all(
                    RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10.0),
                    ),
                  ),
                ),
              ),
              SizedBox(height: 20),
              OutlinedButton(
                onPressed: () {
                  Navigator.of(context).push(MaterialPageRoute(
                      builder: (context) => HistorijaTransakcija()));
                },
                child: Padding(
                  child: Text("Historija transakcija",
                      style:
                          TextStyle(fontWeight: FontWeight.w400, fontSize: 20)),
                  padding:
                      EdgeInsets.only(left: 10, right: 10, top: 5, bottom: 5),
                ),
                style: ButtonStyle(
                  shape: MaterialStateProperty.all(
                    RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10.0),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ));
  }

  void loadWalletData() async {
    var tempData1 = await _walletProvider!.GetWallet();
    var tempData2 = await _walletProvider!.GetImovina();

    setState(() {
      wallet = tempData1;
      imovina = tempData2;

      imovina!.forEach((element) {
        for (int i = 0; i < 5; i++)
          if (element.naziv_valute! + "/" == valute[i]) {
            var last = valute[i].indexOf('/');
            valute[i] = valute[i].substring(0, last) +
                " : " +
                element.kolicina_valute!.toStringAsFixed(3);
          }
      });

      valute.forEach((element) {
        if (element.contains("/")) {
          var last = element.indexOf('/');
          var zeroValue = element.substring(
                0,
                last,
              ) +
              " : 0";
          valute[valute.indexOf(element)] = zeroValue;
        }
      });
    });
  }

  List<Widget> getWalletTop() {

    if(valute[0].contains("/"))
      return [Text("Loading...")];

    return [
      Text(
        valute[0],
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 20),
      ),
      SizedBox(
        height: 20,
      ),
      Text(
        valute[1],
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 20),
      ),
      SizedBox(
        height: 20,
      ),
      Text(
        valute[2],
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 20),
      )
    ];
  }

  List<Widget> getWalletBot() {

    if(valute[0].contains("/"))
      return [Text("Loading...")];

    return [
      Text(
        valute[3],
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 20),
      ),
      SizedBox(
        height: 20,
      ),
      Text(
        valute[4],
        style: TextStyle(fontWeight: FontWeight.w500, fontSize: 20),
      )
    ];
  }
}
