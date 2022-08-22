import 'dart:convert' as convert;

//import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class AuthServis {
  static int user_id = 0;
  static String token = "";
  // Create storage
  //static final storage = new FlutterSecureStorage();

  // Write value
  static void storeToken(String value,int id) async {
    user_id = id;
    token = value;
  }

  //read token
  static Future<String> readToken() async{
    return token;
  }

  //read token
  static int readUserId() {
    return user_id;
  }

  static void removeUser() async{
    token="";
    print("Key removed");
    user_id=0;
    print("user removed");

  }
 

}