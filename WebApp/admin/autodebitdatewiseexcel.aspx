<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="autodebitdatewiseexcel.aspx.cs" Inherits="WebApp.admin.autodebitdatewiseexcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        .t02 th {
            background-color: navy;
            color: white;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formahndler" runat="server">

    <div class="col-md-12">

        

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                  <div class="table-responsive">
                             <asp:Literal runat="server" ID="ShowData"></asp:Literal>
                                      </div>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.box-body -->
          


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
      <script>
        function showLeter(str) {
            var popup;
            var left = (screen.width - 700) / 2; var top = (screen.height - 400) / 4;
            var popup = window.open(str, 'Scheme Month wise Data Excel Format', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no,fullscreen=yes, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=' + top + ', left=' + left);
            popup.focus();
        }
    </script>
</asp:Content>