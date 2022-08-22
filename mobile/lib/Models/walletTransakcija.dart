class WalletTransakcija{
  int? walletId;
  DateTime? vrijeme_obavljanja;
  double? kolicina_transakcije;
  double? wcash;
  String? naziv_valute;
  int? tip_transakcije_id;
  int? tip_metode_id;

  WalletTransakcija(){
    
  }

  WalletTransakcija.fromJson(Map<String, dynamic> json){
    walletId = json['walletId'];
    vrijeme_obavljanja = json['vrijeme_obavljanja'];
    kolicina_transakcije = json['kolicina_transakcije'].toDouble();
    wcash = json['wcash'].toDouble();
    naziv_valute = json['naziv_valute'];
    tip_transakcije_id = json['tip_transakcije_id'];
    tip_metode_id = json['tip_metode_id'];
  }

  Map<String, dynamic> toJson(WalletTransakcija walletTransakcija){
    final Map<String, dynamic> data = new Map<String, dynamic>();

    data['walletId'] = walletId;
    data['wcash'] = wcash;
    data['kolicina_transakcije']=kolicina_transakcije;
    data['naziv_valute'] =  naziv_valute;
    data['tip_transakcije_id'] = tip_transakcije_id ;
    data['tip_metode_id'] = tip_metode_id ;

    return data;
  }

}