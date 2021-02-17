import 'package:flutter/material.dart';
import 'package:pose_estimation_app/screens/auth/login.dart';
import 'package:pose_estimation_app/services/auth.dart';

class RegisterPage extends StatefulWidget {
  @override
  _RegisterPageState createState() => _RegisterPageState();
}

class _RegisterPageState extends State<RegisterPage> {
  final _auth = AuthService();
  final emailAddressController = TextEditingController();
  final passwordController = TextEditingController();

  void register(context) async{
    bool result = await _auth.registerWithEmailPassword(passwordController.text, emailAddressController.text);
    if(result){
      Navigator.pushReplacement(context, MaterialPageRoute(builder: (context)=>LoginPage()));
    }
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Register")
      ),
      body: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            TextField(controller: emailAddressController, decoration: InputDecoration(hintText: "Email address"),),
            TextField(controller: passwordController, decoration: InputDecoration(hintText: "Password"),),
            RaisedButton(onPressed: ()=>register(context), child: Text("Register")),
          ],),
      ),
    );
  }
}