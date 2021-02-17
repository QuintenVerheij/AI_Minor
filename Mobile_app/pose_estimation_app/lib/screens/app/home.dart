import 'dart:async';

import 'package:flutter/material.dart';
import 'package:pose_estimation_app/services/auth.dart';
import 'package:webview_flutter/webview_flutter.dart';

class HomePage extends StatefulWidget {
  HomePage({Key key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  Completer<WebViewController> _controller = Completer<WebViewController>();

  final _auth = AuthService();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Pose estimation"),
        actions: [
          IconButton(icon: Icon(Icons.exit_to_app), onPressed: ()=>_auth.signOut())
        ],
      ),
       body: WebView(
         initialUrl: "https://google.com",
         javascriptMode: JavascriptMode.unrestricted,
         onWebViewCreated: (WebViewController controller){
           _controller.complete(controller);
         },
       ),
    );
  }
}