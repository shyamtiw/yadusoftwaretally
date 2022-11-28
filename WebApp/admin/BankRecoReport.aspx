<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="BankRecoReport.aspx.cs" Inherits="WebApp.admin.BankRecoReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 2px 2px 2px 2px;
            font-size: 11px;
        }

        .t02 th {
            background-color: navy;
            color: white;
        }

        .disn {
            display: none;
        }

        .disy {
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
    Bank Reco Report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">


    <div class="row">
        <SG:Message runat="server" ID="MessageBox" />


        <div class="col-md-12">

            <!-- general form elements disabled -->
            <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                    <h3 class="box-title">Data List</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">



                    


                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                            <div class="input-group">
                                                <asp:Label runat="server" ID="InfoReport" CssClass="form-control" Text="" ForeColor="Navy" Font-Bold="true" ></asp:Label>
                                            </div>
                                        </div>
                                    <div class="col-md-6">
                                        <div style="text-align: right; padding: 5px;">

                                            <div class="input-group">
                                                <input id="myInput" type="text" placeholder="Search..">

                                                <span class="input-group-btn">
                                                    <a class="btn btn-primary btn-flat" onclick="Print_Click()">Export</a>

                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="table-responsive">
                                    <asp:GridView ID="gvlocation" Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                        <Columns>

                                            <asp:TemplateField HeaderText="SR.NO">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ledg code">
                                                <ItemTemplate>
                                                    <%# Eval("ledg_code") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank Acc. No.">
                                                <ItemTemplate>
                                                    <%# Eval("Bank_Ac_No") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank Name">
                                                <ItemTemplate>
                                                    <%# Eval("Bank_Name") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Account Type">
                                                <ItemTemplate>
                                                    <%# Eval("Account_Type") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Accounting_Branch">
                                                <ItemTemplate>
                                                    <%# Eval("Accounting_Branch") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Last Reco Date">
                                                <ItemTemplate>
                                                    <%# Convert.ToDateTime( Eval("Last_Reco_Date")).ToString("dd/MM/yyyy") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Navy-GEN_Bank_Bal" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <%#  WebApp.LIBS.Common.ConvertDecimal(Eval("Navy-GEN_Bank_Bal")).ToString("#,##0.00;-#,##0.00;0.00") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Navy-GEN Reco_Bal" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <%#  WebApp.LIBS.Common.ConvertDecimal(Eval("Navy-GEN_Reco_Bal")).ToString("#,##0.00;-#,##0.00;0.00") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                            <asp:TemplateField HeaderText="Actual Bank Balance" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <%# WebApp.LIBS.Common.ConvertDecimal(Eval("ActualBankBalance")).ToString("#,##0.00;-#,##0.00;0.00") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                           

                                              <asp:TemplateField HeaderText="Differences" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <%# (WebApp.LIBS.Common.ConvertDecimal(Eval("ActualBankBalance"))- WebApp.LIBS.Common.ConvertDecimal(Eval("Navy-GEN_Reco_Bal"))).ToString("#,##0.00;-#,##0.00;0.00") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Record Exists
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>


    <asp:Literal runat="server" ID="UpdatePanels"></asp:Literal>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
    <script src="js/jquery.table2excel.js"></script>
    <script>
        function showLeter(str) {
            var popup;
            debugger;
            var wird = parseInt(((screen.width * 75) / 100.00).toFixed(0));
            var left = (screen.width - wird) / 2; var top = (screen.height - 500) / 4;

            var popup = window.open(str, "Responce", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + wird + ', height=' + 500 + ', top=' + top + ', left=' + left);
            popup.focus();
        }


        function Print_Click() {

            var table = $('#<%=gvlocation.ClientID %>').prepend($("<thead></thead>").prev($('#<%=gvlocation.ClientID %>').find("tr:first")));
            if (table && table.length) {
                debugger;
                $(table).table2excel({

                    name: "Data",
                    filename: "Export_Notredeem " + new Date().toISOString().replace(/[\-\:\.]/g, "") + ".xls",
                    fileext: ".xls",
                    exclude_img: true,
                    exclude_links: true,
                    exclude_inputs: true,
                    preserveColors: true
                });
            }
        }


        $(document).ready(function () {
            $('#<%=gvlocation.ClientID %>').prepend($("<thead></thead>").append($('#<%=gvlocation.ClientID %>').find("tr:first")));
            $("#myInput").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#<%=gvlocation.ClientID %> tbody").find("tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });

    </script>


</asp:Content>
