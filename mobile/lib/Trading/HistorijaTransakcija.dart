import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';
import 'package:mobile/Auth/Servis/authServis.dart';
import 'package:mobile/Models/narudzba.dart';
import 'package:mobile/Trading/narudzbeProvider.dart';
import 'package:mobile/Wallet/walletProvider.dart';

class HistorijaTransakcija extends StatefulWidget {
  int user_id = 0;
  HistorijaTransakcija({Key? key}) : super(key: key);
  @override
  State<StatefulWidget> createState() => _HistorijaTransakcijaState();
}

class _HistorijaTransakcijaState extends State<HistorijaTransakcija> {
  NarudzbaProvider? _narudzbaProvider = null;
  List<Narudzba> _narudzbe = [];
  List<Narudzba> _narudzbeFiltrirano = [];

  @override
  void initState() {
    super.initState();
    _narudzbaProvider = context.read<NarudzbaProvider>();
    LoadTransakcije();
  }

  void LoadTransakcije() async {
    var result =
        await _narudzbaProvider!.GetTransakcije(AuthServis.readUserId());
    setState(() {
      _narudzbe = result;
      _narudzbeFiltrirano = result;
    });
  }

  void filterChanged(int id) {}

  String dropdownvalue = 'Sve';
  var items = ['Sve','Kupovine', 'Prodaje'];
  TextEditingController _traziController = new TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Historija transakcija"),
      ),
      body: SingleChildScrollView(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Container(
              margin: EdgeInsets.only(top: 30, left: 20),
              width: 400,
              child: Text(
                "Historija transakcija (narudžbi)",
                style: TextStyle(fontWeight: FontWeight.w900, fontSize: 20),
                textAlign: TextAlign.center,
              ),
            ),
            Container(
              width: 500,
              height: 100,
              margin: EdgeInsets.only(top: 50, bottom: 50),
              child: Stack(
                children: [
                  Positioned(
                      left: 30,
                      top: 20,
                      child: Text(
                        "Pretraži narudžbe :",
                        style: TextStyle(fontWeight: FontWeight.w500),
                      )),
                  Positioned(
                    left: 20,
                    bottom: 0,
                    width: 200,
                    height: 40,
                    child: TextField(
                        controller: _traziController,
                        onChanged: (String value) {
                          trazi(value);
                        },
                        decoration: InputDecoration(
                          enabledBorder: OutlineInputBorder(
                              borderRadius:
                                  BorderRadius.all(Radius.circular(5)),
                              borderSide: BorderSide(
                                  width: 2,
                                  color: Color.fromRGBO(46, 131, 255, 1))),
                        )),
                  ),
                  Positioned(
                    right: 20,
                    bottom: 0,
                    width: 100,
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
                        trazi(_traziController.text);
                      },
                    ),
                  )
                ],
              ),
            ),
            Container(
                margin: EdgeInsets.only(left: 10, right: 10),
                decoration: BoxDecoration(
                  border: Border.all(
                    width: 1,
                  ),
                  borderRadius: BorderRadius.all(Radius.circular(10)),
                ),
                child: Table(
                  border: TableBorder.symmetric(
                    inside: BorderSide(width: 1),
                  ),
                  children: GetTableRows(),
                )),
          ],
        ),
      ),
    );
  }

  List<Column> GetTableColumns(List<String> columns) => columns
      .map(
        (x) => Column(
          children: [
            Center(
                child: Text(x, style: TextStyle(fontWeight: FontWeight.w400)))
          ],
        ),
      )
      .cast<Column>()
      .toList();

  List<TableRow> GetTableRows() {
    TableRow headerRow = TableRow(children: [
      Column(
        children: [
          Text("Naziv", style: TextStyle(fontWeight: FontWeight.w400))
        ],
      ),
      Column(
        children: [
          Text("Kolicina", style: TextStyle(fontWeight: FontWeight.w400))
        ],
      ),
      Column(
        children: [
          Text("Iznos (WCash)", style: TextStyle(fontWeight: FontWeight.w400))
        ],
      ),
      Column(
        children: [
          Text("Stanje", style: TextStyle(fontWeight: FontWeight.w400))
        ],
      ),
      Column(
        children: [
          Text("Vrijeme", style: TextStyle(fontWeight: FontWeight.w400))
        ],
      )
    ]);

    List<TableRow> rows = [headerRow];

    for (var e in _narudzbeFiltrirano) {
      var values = [
        e.valutaNaziv.toString(),
        e.kolicina.toString(),
        e.cijena.toString(),
        e.state.toString(),
        e.kreirana.toString()
      ];
      var columns = GetTableColumns(values);
      rows.add(TableRow(children: columns));
    }

    return rows;
  }

  void trazi(String value) {
    List<Narudzba> lista = [];
    setState(() {
      if (dropdownvalue == "Kupovine")
        lista = _narudzbe.where((element) => element.tip == 1).toList();
      else if (dropdownvalue == "Prodaje")
        lista = _narudzbe.where((element) => element.tip == 0).toList();
      else
        lista = _narudzbe;

      if (value != "")
        _narudzbeFiltrirano = lista
            .where((element) => element.valutaNaziv!
                .toLowerCase()
                .contains(value.toLowerCase()))
            .toList();
      else
        _narudzbeFiltrirano = lista;
    });
  }
}
