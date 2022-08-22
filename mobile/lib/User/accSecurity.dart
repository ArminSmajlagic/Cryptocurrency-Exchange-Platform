import 'package:flutter/material.dart';
import 'package:mobile/Auth/verification.dart';
import 'package:mobile/User/privUpdate.dart';

class Security extends StatefulWidget {
  @override
  _securityState createState() => _securityState();
}

class _securityState extends State<Security> {
  var smsConf = false;
  var emailConf = false;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            backgroundColor: Colors.blue[100],
            title: const Text('Sigurnosne postavke',
                style: TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.w500,
                    fontSize: 25))),
        body: Container(
            child: Center(
          child: Column(
            children: [
              Container(
                margin: EdgeInsets.only(top: 70),
                padding: EdgeInsets.all(15),
                decoration: const BoxDecoration(
                  borderRadius: BorderRadius.all(Radius.circular(27)),
                  border: Border(
                    top: BorderSide(width: 4.0, color: Colors.blue),
                    left: BorderSide(width: 4.0, color: Colors.blue),
                    right: BorderSide(width: 4.0, color: Colors.blue),
                    bottom: BorderSide(width: 4.0, color: Colors.blue),
                  ),
                ),
                child: Icon(Icons.lock_outlined, size: 100, color: Colors.blue),
              ),
              Padding(padding: EdgeInsets.only(top: 40)),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Text("Confirmacija transackije putem SMSa"),
                  Checkbox(
                      value: smsConf,
                      onChanged: (bool? value) {
                        setState(() {
                          smsConf = !smsConf;
                        });
                      }),
                ],
              ),
              Padding(padding: EdgeInsets.only(top: 20)),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Text("Confirmacija transackije putem E-Maila"),
                  Checkbox(
                      value: emailConf,
                      onChanged: (bool? value) {
                        setState(() {
                          emailConf = !emailConf;
                        });
                      }),
                ],
              ),
              Padding(padding: EdgeInsets.only(top: 20)),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text("Account not verified",
                      style: TextStyle(color: Colors.red)),
                  Padding(padding: EdgeInsets.only(left: 15)),
                  SizedBox(
                      width: 90,
                      height: 30,
                      child: OutlinedButton(
                        style: ButtonStyle(
                          shape: MaterialStateProperty.all(
                            RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(10.0),
                            ),
                          ),
                        ),
                        onPressed: () => {
                          Navigator.of(context).push(MaterialPageRoute(
                              builder: (context) => Verification(
                                  mail: "_email.text", user_id: 0)))
                        },
                        child: Text("Verifikuj se", style: TextStyle()),
                      ))
                ],
              ),
              Padding(padding: EdgeInsets.only(top: 20)),
              SizedBox(
                  width: 250,
                  height: 30,
                  child: OutlinedButton(
                    style: ButtonStyle(
                      shape: MaterialStateProperty.all(
                        RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10.0),
                        ),
                      ),
                    ),
                    onPressed: () => {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => PrivacyUpdate()))
                    },
                    child: Text("Promjenite username ili password"),
                  )),
              Padding(padding: EdgeInsets.only(top: 40)),
              SizedBox(
                  width: 150,
                  height: 30,
                  child: OutlinedButton(
                    style: ButtonStyle(
                      shape: MaterialStateProperty.all(
                        RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10.0),
                        ),
                      ),
                    ),
                    onPressed: () => {print("Not implemented save changes")},
                    child: Text("Spremite promjene"),
                  ))
            ],
          ),
        )));
  }
}
