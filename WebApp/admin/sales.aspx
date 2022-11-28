<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="sales.aspx.cs" Inherits="WebApp.admin.sales" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">
    <SG:Message ID="MessageBox" runat="server" />

    <div class="row">
        <div class="col-md-12">

            <div class="box box-success box-solid " style="border: 3px solid #0b0336!important;">
                <div class="box-header with-border"  style="background: #0b0336!important;background-color: #0b0336!important;">
                    <h3 class="box-title">Filter </h3>

                    <div class="box-tools pull-right">

                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Scheme</label>
                                <asp:DropDownList runat="server" ID="Scheme" CssClass="form-control"></asp:DropDownList>

                            </div>

                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Channel</label>
                                <asp:DropDownList runat="server" ID="Channel" CssClass="form-control"></asp:DropDownList>

                            </div>

                        </div>




                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Godown</label>
                                <asp:DropDownList runat="server" ID="GodownId" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>



                    </div>
                    <div class="box-footer">

                        <table>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="savecompnay" CssClass="btn btn-primary" Text="Get Data"  OnClick="savecompnay_Click"/>
                                </td>

                            </tr>
                        </table>

                    </div>

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
            </div>


        </div>
      



    </div>




</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">

    <script>
        function showLeter(str) {
            var popup;
            var left = (screen.width - 700) / 2; var top = (screen.height - 400) / 4;
            var popup = window.open(str, 'Scheme Month wise Data', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + 700 + ', height=' + 400 + ', top=' + top + ', left=' + left);
            popup.focus();
        }
    </script>
</asp:Content>
