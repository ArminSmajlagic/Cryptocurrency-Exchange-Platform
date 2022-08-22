class Ponuda {
  int id=0;
  String category="";

  Ponuda({this.id=0,this.category=""});

  Ponuda.fromJson(Map<String, dynamic> json){
    category=json['category'];
    id=json['id'];
  }
}