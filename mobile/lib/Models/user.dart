class User {
  String imePrezime = "";
  double stanjeWalleta= 0;
  String email = "";
  String brojTelefona = "";
  String drzava = "";
  String? username = "";

  User({
        this.imePrezime="",
        this.stanjeWalleta=0.0,
        this.email="",
        this.brojTelefona="",
        this.drzava="",
        this.username="",
  });

  User.fromJson(Map<String, dynamic> json) {
    imePrezime = json['ime_prezime'];
    stanjeWalleta = json['stanje_walleta'].toDouble();
    email = json['email'];
    brojTelefona = json['broj_telefona'];
    drzava = json['drzava'];
    username = json['username'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['ime_prezime'] = this.imePrezime;
    data['stanje_walleta'] = this.stanjeWalleta;
    data['email'] = this.email;
    data['broj_telefona'] = this.brojTelefona;
    data['drzava'] = this.drzava;
    data['username'] = this.username;
    return data;
  }

  Map<String, dynamic> putUserToJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['ime_prezime'] = this.imePrezime;
    data['email'] = this.email;
    data['broj_telefona'] = this.brojTelefona;
    data['drzava'] = this.drzava;
    return data;
  }
}