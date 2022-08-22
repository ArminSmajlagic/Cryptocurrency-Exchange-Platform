class KriptoReport{

  double? openAvg;
  double? closeAvg;
  double? lowAvg;
  double? highAvg;
  int? rank;
  double? cap;
  double? volume;

  KriptoReport(
      {this.openAvg,
      this.closeAvg,
      this.lowAvg,
      this.highAvg,
      this.rank,
      this.cap,
      this.volume});

  KriptoReport.fromJson(Map<String, dynamic> json) {
    openAvg = json['openAvg'].toDouble();
    closeAvg = json['closeAvg'].toDouble();
    lowAvg = json['lowAvg'].toDouble();
    highAvg = json['highAvg'].toDouble();
    rank = json['rank'];
    cap = json['cap'].toDouble();
    volume = json['volume'].toDouble();
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['openAvg'] = this.openAvg;
    data['closeAvg'] = this.closeAvg;
    data['lowAvg'] = this.lowAvg;
    data['highAvg'] = this.highAvg;
    data['rank'] = this.rank;
    data['cap'] = this.cap;
    data['volume'] = this.volume;
    return data;
  }
}