<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="otpverification.aspx.cs" Inherits="WebApp.mobile.otpverification" %>

<html lang="en" class="ios device-pixel-ratio-0 device-desktop device-windows">
<head>
   <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Navy-GEN - Automobile Digital Cloud</title>
    <link rel="stylesheet" href="assets/css/style.css">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/apple-touch-icon.png">
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="shortcut icon" href="assets/img/favicon.png">
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
            <h1>OTP Verification</h1>
            <h4>Enter OTP Received on Mobile/Email</h4>
        </div>
        <div class="section mt-2 mb-5 p-3">
            <form  id="forms"  runat="server" style="background-color:white">
                 <asp:Literal runat="server" ID="message"></asp:Literal>

                <div class="form-group basic">
                    <div class="input-wrapper">
                    
                        <label class="label" for="email1">OTP</label>
                        <asp:TextBox runat="server" ID="email" CssClass="form-control" placeholder="Input OTP" TextMode="Password"></asp:TextBox>
                        
                    </div>
                </div>

                <div class="form-button-group">
                    <asp:Button  CssClass="btn btn-submit btn-primary w-100" runat="server" ID="Button1" Text="Verify" OnClick="Logindata_Click"></asp:Button>
                    
                </div>

            </form>
        </div>

    </div>



   <!-- Jquery -->
    <script src="assets/js/lib/jquery-3.4.1.min.js"></script>
    <!-- Bootstrap-->
    <script src="assets/js/lib/popper.min.js"></script>
    <script src="assets/js/lib/bootstrap.min.js"></script>
    <!-- Ionicons -->
  <script src="https://unpkg.com/ionicons@4.5.10-0/dist/ionicons.js"></script>
    <!-- Owl Carousel -->
    <script src="assets/js/plugins/owl-carousel/owl.carousel.min.js"></script>
    <!-- Base Js File -->
    <script src="assets/js/base.js"></script>

</body>
</html>

