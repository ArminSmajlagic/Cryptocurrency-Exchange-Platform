import 'package:mobile/BaseProvider.dart';
import 'package:mobile/Models/user.dart';

class UserProvider extends BaseProvider<User>{
  UserProvider() : super("user");

  @override
  User fromJson(entity){
    return User.fromJson(entity);
  }  
}