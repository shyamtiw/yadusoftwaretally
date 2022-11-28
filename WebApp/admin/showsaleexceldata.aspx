<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="showsaleexceldata.aspx.cs" Inherits="WebApp.admin.showsaleexceldata" %>
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
</asp:Content>
