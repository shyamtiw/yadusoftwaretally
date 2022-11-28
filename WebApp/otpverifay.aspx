

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="otpverifay.aspx.cs" Inherits="WebApp.otpverifay" %>



<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>AUTO-VYN  Cloud | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/iCheck/square/blue.css">


    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition login-page" style="background: #ffffff;">
    <div class="login-box" style="margin: 1% auto!important;">
        <%--<div class="login-logo">
            <a href="#"><b>AUTO-VYN  Cloud </b></a>
        </div>--%>
        <!-- /.login-logo -->
        <div class="login-box-body">
            <h3 class="login-box-msg">AUTO-VYN  Cloud</h3>

            <form runat="server" id="form1">
                <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                    <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                      <center>  <h3 class="box-title" style="text-align:center">Enter OTP</h3></center>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        
                 <asp:TextBox runat="server" ID="OTP" CssClass="form-control" TextMode="Password"></asp:TextBox>

                </div>

                <div class="row">
                    <div class="col-xs-8">
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <asp:Button runat="server" ID="loginbtn" Text="Login In" class="btn btn-primary btn-block btn-flat" OnClick="loginbtn_Click" />
                    </div>
                    <!-- /.col -->
                </div>
                    
                </div>
            
            </form>


        </div>
        <center>
          <img src="default.png"  height="250" width="250"/></center>
        <!-- /.login-box-body -->
    </div>
    <!-- /.login-box -->

        

    <!-- jQuery 3 -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
</body>
</html>