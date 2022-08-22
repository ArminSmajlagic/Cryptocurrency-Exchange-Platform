import 'package:mobile/Auth/login.dart';

class LoginRequest{
  String? username;
  String? password;

  LoginRequest(String username, String password){
    this.username=username;
    this.password=password;
  }
}