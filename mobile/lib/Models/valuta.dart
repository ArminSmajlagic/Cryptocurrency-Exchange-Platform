class Valuta{

  int valutaId=0;
  String naziv="";
  String oznaka="";
  double vrijednost=0.0;
  String iternval="";
  String datum="";
  double promjena=0.0;
  String logoUrl="";
  int rank=0;
  double lastHigh=0.0;
  int totalSuplay=0;
  int ponudaId=0;

  Valuta(
      {this.valutaId=0,
        this.naziv="",
        this.oznaka="",
        this.vrijednost=0.0,
        this.iternval="",
        this.datum="",
        this.promjena=0.0,
        this.logoUrl="",
        this.rank=0,
        this.lastHigh=0.0,
        this.ponudaId=0,
        this.totalSuplay=0});

  Valuta.fromJson(Map<String, dynamic> json) {
    valutaId = json['valuta_id'];
    naziv = json['naziv'];
    oznaka = json['oznaka'];
    vrijednost = json['vrijednost'].toDouble();
    iternval = json['iternval'];
    datum = json['datum'];
    promjena = json['promjena'].toDouble();
    logoUrl = json['logo_url'];
    rank = json['rank'];
    lastHigh = json['last_high'].toDouble(); 
    totalSuplay = json['total_suplay'];
    ponudaId = json['ponudaId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['valuta_id'] = this.valutaId;
    data['naziv'] = this.naziv;
    data['oznaka'] = this.oznaka;
    data['vrijednost'] = this.vrijednost;
    data['iternval'] = this.iternval;
    data['datum'] = this.datum;
    data['promjena'] = this.promjena;
    data['logo_url'] = this.logoUrl;
    data['rank'] = this.rank;
    data['last_high'] = this.lastHigh;
    data['total_suplay'] = this.totalSuplay;
    data['ponudaId'] = this.ponudaId;

    return data;
  }

}