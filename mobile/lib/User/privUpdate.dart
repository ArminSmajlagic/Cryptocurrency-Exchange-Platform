import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class PrivacyUpdate extends StatefulWidget {
  @override
  _privUpdate createState() => _privUpdate();
}

class _privUpdate extends State<PrivacyUpdate> {
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
        child: Text("Not implmented!"),
      ),
    );
  }
}
