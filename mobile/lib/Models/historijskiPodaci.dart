class HistorijskiPodaci{
  int? id;
  String? date;
  double? high;
  double? open;
  double? low;
  double? close;
  int? volume;
  int? marketCap;
  int? valutaId;

  HistorijskiPodaci(
      {this.id,
      this.date,
      this.high,
      this.open,
      this.low,
      this.close,
      this.volume,
      this.marketCap,
      this.valutaId});

  HistorijskiPodaci.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    date = json['date'];
    high = json['high'];
    open = json['open'];
    low = json['low'];
    close = json['close'];
    volume = json['volume'];
    marketCap = json['market_cap'];
    valutaId = json['valutaId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['date'] = this.date;
    data['high'] = this.high;
    data['open'] = this.open;
    data['low'] = this.low;
    data['close'] = this.close;
    data['volume'] = this.volume;
    data['market_cap'] = this.marketCap;
    data['valutaId'] = this.valutaId;
    return data;
  }
}