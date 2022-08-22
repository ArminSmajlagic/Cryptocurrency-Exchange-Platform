import 'package:flutter/material.dart';
import 'package:mobile/Auth/login.dart';
import 'package:mobile/Auth/register.dart';

class NoAccount extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            backgroundColor: Colors.blue[100],
            title: const Text('No Account',
                style: TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.w500,
                    fontSize: 25))),
        body: Container(
            child: Column(
          children: [
            Container(
              margin: EdgeInsets.only(top: 50),
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
                padding:
                    EdgeInsets.only(top: 20, left: 20, right: 20, bottom: 20),
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
              ),
            ),
            Padding(
                padding: EdgeInsets.only(top: 100, bottom: 40),
                child: Text(
                  "Izgleda da niste prijavljeni.",
                  style: TextStyle(fontSize: 35, color: Colors.lightBlue),
                  textAlign: TextAlign.center,
                )),
            Column(children: [
              SizedBox(
                  width: 200,
                  height: 90,
                  child: Padding(
                    padding: EdgeInsets.only(bottom: 40),
                    child: OutlinedButton(
                      style: ButtonStyle(
                        shape: MaterialStateProperty.all(
                          RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                        ),
                      ),
                      onPressed: () => {
                        Navigator.of(context).push(
                            MaterialPageRoute(builder: (context) => Login()))
                      },
                      child: Text("Prijavite se"),
                    ),
                  )),
              SizedBox(
                  width: 200,
                  height: 90,
                  child: Padding(
                    padding: EdgeInsets.only(bottom: 40),
                    child: OutlinedButton(
                      style: ButtonStyle(
                        shape: MaterialStateProperty.all(
                          RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                        ),
                      ),
                      onPressed: () => {
                        Navigator.of(context).push(
                            MaterialPageRoute(builder: (context) => Register()))
                      },
                      child: Text("Registruj se"),
                    ),
                  ))
            ])
          ],
        )));
  }
}
