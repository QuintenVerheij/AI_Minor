import 'package:flutter/material.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:pose_estimation_app/screens/auth/register.dart';
import 'package:pose_estimation_app/services/auth.dart';

class LoginPage extends StatefulWidget {
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final _auth = AuthService();
  final emailAddressController = TextEditingController();
  final passwordController = TextEditingController();

  void signIn() async{
    await _auth.signinWithEmailAndPassword(passwordController.text, emailAddressController.text);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Sign in")
      ),
      body: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            TextField(controller: emailAddressController, decoration: InputDecoration(hintText: "Email address"),),
            TextField(controller: passwordController, decoration: InputDecoration(hintText: "Password"),),
            RaisedButton(onPressed: signIn, child: Text("Sign in")),
            FlatButton(onPressed: ()=>{
              Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => RegisterPage()))
            }, child: Text("Register")),
            Divider(),
            RaisedButton(onPressed: ()=>_auth.signinWithGoogle(), child: Text("Sign in with Google"),)
          ],),
      ),
    );
  }
}