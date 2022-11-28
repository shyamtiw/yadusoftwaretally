<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jsoneditore.aspx.cs" Inherits="WebApp.admin.jsoneditore" %>



<!DOCTYPE HTML>
<html lang="en">
<head>
    <title>Edit</title>
    <!-- when using the mode "code", it's important to specify charset utf-8 -->
    <meta charset="utf-8">
 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsoneditor/9.1.4/jsoneditor.min.css" integrity="sha512-N0PmzxwgSgtjyhzCl8NK+jGEd41pKXKaPi0QZViL7or0QlUts1hqQAOPEGsCPP2ls7F0Ai+bHmsnRPRhLCANrg==" crossorigin="anonymous" />
   <script src="https://cdnjs.cloudflare.com/ajax/libs/jsoneditor/9.1.4/jsoneditor.min.js" integrity="sha512-pvpySIgvROk4BnMa/D8hHT8gKyzZFc5thbVy1/kJf7/6HYzFcKXfO/VNFQ8Lan9mwl/AZpcATw2787SanshU0A==" crossorigin="anonymous"></script>
</head>
<body>
   <form runat="server" id="forms">
       <asp:HiddenField runat="server" ID="Val" />
   </form>
    <div id="jsoneditor" style="width: 400px; height: 400px;"></div>
 
    <script>
        // create the editor
        const container = document.getElementById("jsoneditor")
        const options = {}
        const editor = new JSONEditor(container, options)
 
        // set json
        var ss = document.getElementById('<%=Val.ClientID %>').value;
        const initialJson = JSON.parse(ss);
        editor.set(initialJson)
 
        // get json
        const updatedJson = editor.get()
    </script> 
</body>
</html>