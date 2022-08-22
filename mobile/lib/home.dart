import 'package:flutter/material.dart';
import 'package:mobile/Valuta/trade.dart';
import 'package:mobile/routing.dart';

class Home extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    double c_width = MediaQuery.of(context).size.width * 0.8;
    double btn_width = MediaQuery.of(context).size.width * 0.7;

    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.blue[100],
        title: const Text('Home',
            style: TextStyle(
                color: Colors.white,
                fontWeight: FontWeight.w500,
                fontSize: 25)),
      ),
      body: Container(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.center, 
              children: [
              Container(
                  margin: EdgeInsets.only(top: 70),
                  decoration: const BoxDecoration(
                    borderRadius: BorderRadius.all(Radius.circular(27)),
                    border: Border(
                      top: BorderSide(width: 4.0, color: Colors.blue),
                      left: BorderSide(width: 4.0, color: Colors.blue),
                      right: BorderSide(width: 4.0, color: Colors.blue),
                      bottom: BorderSide(width: 4.0, color: Colors.blue),
                    ),
                  ),
                  child: Padding(
                    padding: EdgeInsets.only(
                        top: 20, left: 20, right: 20, bottom: 20),
                    child: Text(
                      "Logo",
                      style: TextStyle(
                        fontSize: 50,
                        color: Colors.blue,
                        fontFamily: "Inter",
                        fontWeight: FontWeight.w100,
                        fontStyle: FontStyle.italic,
                      ),
                    ),
                  )),
            ]),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Container(
                  width: c_width,
                  margin: EdgeInsets.only(left: 10, right: 10, top: 50),
                  child: Text(
                    "U Logo možete da kupujete & prodajete vaše digitalne posjede.",
                    textAlign: TextAlign.center,
                    style: TextStyle(fontSize: 18, fontWeight: FontWeight.w500),
                  ),
                ),
              ],
            ),
            Container(
              width: c_width,
              margin: EdgeInsets.only(left: 10, right: 10, top: 30),
              child: Text(
                "Logo je najlakši, najbrži i najsigurnij naćin kupovine i prodaje vaših kripto valuta.",
                textAlign: TextAlign.center,
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.w400),
              ),
            ),
            Padding(
                padding:
                    EdgeInsets.only(top: 70, bottom: 0, left: 20, right: 20),
                child: SizedBox(
                    width: btn_width,
                    height: 50,
                    child: OutlinedButton(
                      style: ButtonStyle(
                        shape: MaterialStateProperty.all(
                          RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                        ),
                      ),
                      onPressed: () => {
                        Navigator.of(context).pushReplacement(MaterialPageRoute(
                            builder: (context) => RouterPage(ruta: 1,)))
                      },
                      child: Text("Zapoćnite vaše putovanje",
                          style: TextStyle(
                              fontWeight: FontWeight.w500, fontSize: 18)),
                    ))),
          ],
        ),
      ),
    );
  }
}
