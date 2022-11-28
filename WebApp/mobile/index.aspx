<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApp.mobile.index" %>

<html lang="en" class="ios device-pixel-ratio-0 device-desktop device-windows">
<head>
   <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Navy-GEN - Automobile Digital Cloud</title>
       <meta name="apple-mobile-web-app-capable" content="yes">

    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" href="assets/css/style.css">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/apple-touch-icon.png">
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="shortcut icon" href="assets/img/favicon.png">
    
        <link rel="manifest" crossorigin="use-credentials" href="manifest.webmanifest"/>
</head>



    
<body class="bg-light">

    <!-- loader -->
    <div id="loader">
        <img src="assets/img/logo-icon.png" alt="icon" class="loading-icon">
    </div>
    <!-- * loader -->

    <!-- App Header -->
    <div class="appHeader no-border">
        <div class="left">
            <a href="javascript:;" class="headerButton goBack">
                <ion-icon name="chevron-back-outline"></ion-icon>
            </a>
        </div>
        <div class="pageTitle"></div>
        <div class="right">
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">

        <div class="section mt-2 text-center">
            <h1>Log in</h1>
            <h4>Fill the form to log in</h4>
        </div>
        <div class="section mt-2 mb-5 p-3">
            <form  id="forms"  runat="server" style="background-color:white">
                 <asp:Literal runat="server" ID="message"></asp:Literal>

                <div class="form-group basic">
                    <div class="input-wrapper">
                        <label class="label" for="email1">User Name</label>
                        <asp:TextBox runat="server" ID="email" CssClass="form-control" placeholder="exampale@gmail.com"></asp:TextBox>
                        <i class="clear-input"><ion-icon name="close-circle"></ion-icon></i>
                    </div>
                </div>

                <div class="form-group basic">
                    <div class="input-wrapper">
                        <label class="label" for="password1">Password</label>
                        <asp:TextBox runat="server" ID="password" CssClass="form-control" placeholder="********" TextMode="Password"></asp:TextBox>
                        <i class="clear-input"><ion-icon name="close-circle"></ion-icon></i>
                    </div>
                </div>

                <div class="form-button-group">
                    <asp:Button  CssClass="btn btn-primary btn-block btn-lg" runat="server" ID="Logindata" Text="Login" OnClick="Logindata_Click"></asp:Button>
                    
                </div>

            </form>
        </div>

    </div>


    <!-- Android Add to Home Action Sheet -->

    <script src="assets/js/lib/jquery-3.4.1.min.js"></script>
    <!-- Bootstrap-->
    <script src="assets/js/lib/popper.min.js"></script>
    <script src="assets/js/lib/bootstrap.bundle.min.js"></script>
    <!-- Ionicons -->
    <script src="https://unpkg.com/ionicons@5.4.0/dist/ionicons.js"></script>
    <%--<script src="https://unpkg.com/ionicons@4.5.10-0/dist/ionicons.js"></script>--%>
    <!-- Splide -->
    <script src="assets/js/plugins/splide/splide.min.js"></script>
    <!-- Base Js File -->
    <script src="assets/js/base.js"></script>
    <script src="./index.js" type="module">  </script>
</body>
</html>
