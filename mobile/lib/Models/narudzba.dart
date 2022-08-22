class Narudzba {
  String? kreirana;
  int? userId;
  int? valutaId;
  int? tip;
  double? kolicina;
  double? cijena;
  String? state;
  String? userIme;
  String? valutaNaziv;

  Narudzba(
      {this.valutaNaziv,
      this.userIme,
      this.kreirana,
      this.userId,
      this.valutaId,
      this.kolicina,
      this.cijena,
      this.state});

  Narudzba.fromJson(Map<String, dynamic> json) {
    kreirana = json['kreirana'];
    userId = json['userId'];
    valutaId = json['valutaId'];
    kolicina = json['kolicina'].toDouble();
    cijena = json['cijena'].toDouble();
    state = json['state'];
    tip = json['tip'];
    userIme = json['userIme'];
    valutaNaziv = json['valutaNaziv'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['kreirana'] = this.kreirana;
    data['userId'] = this.userId;
    data['valutaId'] = this.valutaId;
    data['kolicina'] = this.kolicina;
    data['cijena'] = this.cijena;
    data['state'] = this.state;
    data['tip'] = this.tip;
    data['valutaNaziv'] = this.valutaNaziv;
    data['userIme'] = this.userIme;
    return data;
  }
}