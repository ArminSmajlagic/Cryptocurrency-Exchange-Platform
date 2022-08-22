class Wallet {
  int? kreditnaId;
  int? userId;
  int? id;


  Wallet.fromJson(Map<String, dynamic> json){
    kreditnaId = json['kreditnaId'];
    userId = json['userId'];
    id = json['id'];
  }


}