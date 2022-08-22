class WalletImovina {
  int? id;
  String? naziv_valute;
  int? valuta_id;
  double? kolicina_valute;
  int? walletId;

  WalletImovina.fromJson(Map<String, dynamic> json){
    naziv_valute = json['naziv_valute'];
    kolicina_valute = json['kolicina_valute'].toDouble();
    valuta_id = json['valuta_id'];
    walletId = json['walletId'];
    id = json['id'];
  }
  
}