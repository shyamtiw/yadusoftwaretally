<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="ShowEInvoiceData.aspx.cs" Inherits="WebApp.admin.ShowEInvoiceData" EnableEventValidation="false" %>

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
        .disn {
            display:none;
        }
        .disy {
            display:block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">


    <div class="row">
        <SG:Message runat="server" ID="MessageBox" />


        <div class="col-md-12">

            <!-- general form elements disabled -->
            <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                    <h3 class="box-title">Invoice</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">


                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:DropDownList runat="server" ID="GodownId" CssClass="form-control">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Voucher Type</label>
                                <asp:DropDownList runat="server" ID="VoucherId" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>QR Status</label>
                                <asp:DropDownList runat="server" ID="QrStatus" CssClass="form-control">

                                    <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                    <asp:ListItem Text="IRN Generated" Value="IRN Generated"></asp:ListItem>
                                    <asp:ListItem Text="Erroneous Case" Value="Erroneous Case"></asp:ListItem>
                                    <asp:ListItem Text="IRN Pending" Value="IRN Pending"></asp:ListItem>
                                    <asp:ListItem Text="Cancelled" Value="Cancelled"></asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>



                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label>From Date </label>
                                <asp:TextBox runat="server" ID="FromDate" CssClass="form-control Date"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>To Date </label>
                                <asp:TextBox runat="server" ID="ToDate" CssClass="form-control Date"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-3">
                                    <label style="color: white">To Date </label>
                                    <asp:Button runat="server" ID="GetData" Text="Get Data" CssClass="btn btn-info" OnClick="GetData_Click" />
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">To Date </label>
                                    <asp:Button runat="server" ID="GenrateIron" Text="Generate IRN" CssClass="btn btn-success" OnClick="GenrateIron_Click" />
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">To Date </label>
                                    <asp:Button runat="server" ID="Cancel" Text="Cancel" CssClass="btn btn-danger" OnClick="Cancel_Click" />
                                </div>
                                 <div class="col-md-3">
                                    <label style="color: white">To Date </label>
                                    <asp:Button runat="server" ID="Excel" Text="Export" CssClass="btn btn-danger" OnClick="Excel_Click" />
                                </div>

                            </div>
                        </div>


                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:GridView ID="gvlocation" Height="150px" Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server" OnRowDataBound="gvlocation_RowDataBound" AutoGenerateColumns="false" Width="98%" align="center">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="selectall" onclick="checkAll(this)" />

                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="selectall" />
                                                <asp:HiddenField runat="server" ID="EInvoiceDataExcelId" Value='<%# Eval("EInvoiceDataExcelId")%>' />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SR.NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="VoucherType">
                                            <ItemTemplate>

                                                <%# Eval("VoucherType")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <%# Eval("DocShow")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <%#  Convert.ToDateTime( Eval("DocumentDate")).ToString("dd/MM/yyyy")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <%# Eval("BuyerLegalName")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GSTIN">
                                            <ItemTemplate>
                                                <%# Eval("BuyerGSTN")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="Status" Text='<%# Eval("Status")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Response">
                                            <ItemTemplate>
                                                <%# Eval("Key")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="Editfamily" PostBackUrl='<%# Eval("EInvoiceDataExcelId","EntryformExcel.aspx?EInvoiceDataExcelId={0}") %>' CssClass="label label-sm label-warning" Text="Edit"></asp:LinkButton>

                                                <a onclick='<%# Eval("EInvoiceDataExcelId","printinvoice({0})") %>' class='label label-sm label-info <%# Eval("Status").ToString()=="IRN Generated"?"disy":"disn" %>' >Print</a>
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

                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">

                                <div class="col-md-2">
                                    <div class="form-group">

                                        <table style="width: 100%">
                                            <tr style="background-color: white">
                                                <td style="width: 75%; border-collapse: collapse; border: 1px solid black; padding: 1px 1px 1px 1px; text-align: right"><b>eInvoice Count</b></td>
                                                <td style="width: 25%; border-collapse: collapse; border: 1px solid black; text-align: right">
                                                    <asp:Literal runat="server" ID="TotalInvoice"></asp:Literal></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">

                                        <table style="width: 100%">
                                            <tr style="background-color: orange">
                                                <td style="width: 75%; border-collapse: collapse; border: 1px solid black; padding: 1px 1px 1px 1px; text-align: right"><b>Pending Invoice</b></td>
                                                <td style="width: 25%; border-collapse: collapse; border: 1px solid black; text-align: right">
                                                    <asp:Literal runat="server" ID="Pending"></asp:Literal></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>

                                <div class="col-md-2">
                                    <div class="form-group">

                                        <table style="width: 100%">
                                            <tr style="background-color: #c1ffc0">
                                                <td style="width: 75%; border-collapse: collapse; border: 1px solid black; padding: 1px 1px 1px 1px; text-align: right"><b>IRN Generated</b></td>
                                                <td style="width: 25%; border-collapse: collapse; border: 1px solid black; text-align: right">
                                                    <asp:Literal runat="server" ID="IRNGeneratedTotal"></asp:Literal></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>


                                <div class="col-md-2">
                                    <div class="form-group">

                                        <table style="width: 100%">
                                            <tr style="background-color: silver">
                                                <td style="width: 75%; border-collapse: collapse; border: 1px solid black; padding: 1px 1px 1px 1px; text-align: right"><b>Erroneous</b></td>
                                                <td style="width: 25%; border-collapse: collapse; border: 1px solid black; text-align: right">
                                                    <asp:Literal runat="server" ID="ErroneousTotal"></asp:Literal></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">

                                        <table style="width: 65%">
                                            <tr style="background-color: #fd0100">
                                                <td style="width: 75%; border-collapse: collapse; border: 1px solid black; padding: 1px 1px 1px 1px; text-align: right"><b>Cancelled eInvoice</b></td>
                                                <td style="width: 25%; border-collapse: collapse; border: 1px solid black; text-align: right">
                                                    <asp:Literal runat="server" ID="Cancelled"></asp:Literal></td>
                                            </tr>
                                        </table>
                                    </div>
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
    <script>
          function showLeter(str) {
              var popup;
              var left = (screen.width - 450) / 2; var top = (screen.height - 500) / 4;

              var popup = window.open(str, "Responce", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + 450 + ', height=' + 400 + ', top=' + top + ', left=' + left);
              popup.focus();
          }

          function showLeterQrCode(str) {
              var popup;
              var left = (screen.width - 450) / 2; var top = (screen.height - 500) / 4;

              var popup = window.open(str, "QR Code", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + 450 + ', height=' + 400 + ', top=' + top + ', left=' + left);
              popup.focus();
          }

          function printinvoice(str) {
              var popup;
              var left = (screen.width) / 2; var top = (screen.height) / 4;

              var popup = window.open("print/printinvoice.aspx?id=" + str + "", "Print Invoice", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=' + top + ', left=' + left);
              popup.focus();
          }



    </script>
</asp:Content>
