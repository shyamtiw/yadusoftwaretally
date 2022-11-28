<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="EntryformExcel.aspx.cs" Inherits="WebApp.admin.EntryformExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    th {
        background-color:navy;
        color:white;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>

            <div class="row">
                <SG:Message runat="server" ID="MessageBox" />


                <div class="col-md-12">

                    <!-- general form elements disabled -->
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h3 class="box-title">Entry From</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">


                            <div class="row">

                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Document Type</label>

                                        <asp:TextBox runat="server" ID="DocumentType" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Document No</label>

                                        <asp:TextBox runat="server" ID="DocumentNo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Document Date</label>

                                        <asp:TextBox runat="server" ID="DocumentDate" CssClass="form-control Date"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Supply Type</label>

                                        <asp:TextBox runat="server" ID="SupplyTypeCode" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Reverse Charge</label>

                                        <asp:TextBox runat="server" ID="ReverseCharge" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Tax Type</label>

                                        <asp:TextBox runat="server" ID="TaxType" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="row">


                                <div class="col-md-12">


                                    <div class="nav-tabs-custom">
                                        <ul class="nav nav-tabs">
                                            <li class="active"><a href="#tab_1" data-toggle="tab" aria-expanded="true">Seller Detail & Buyer Detail</a></li>
                                            <li class=""><a href="#tab_2" data-toggle="tab" aria-expanded="false">Tab 2</a></li>



                                        </ul>
                                        <div class="tab-content">
                                            <div class="tab-pane active" id="tab_1">
                                                <div class="row">

                                                    <div class="col-md-4" style="padding: 0px 0px 0px 0px;">
                                                        <!-- Horizontal Form -->
                                                        <div class="box box-info">
                                                            <div class="box-header with-border">
                                                                <h3 class="box-title">Seller Detail</h3>
                                                            </div>
                                                            <!-- /.box-header -->
                                                            <!-- form start -->

                                                            <div class="box-body">

                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td></td>
                                                                        <td></td>


                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 25%">SellerGSTN</td>
                                                                        <td style="width: 75%">
                                                                            <asp:TextBox runat="server" ID="SellerGSTN" Style="width: 100%;"></asp:TextBox></td>
                                                                        <tr>
                                                                            <td style="width: 25%">SellerLegalName</td>
                                                                            <td style="width: 75%">
                                                                                <asp:TextBox runat="server" ID="SellerLegalName" Style="width: 100%;"></asp:TextBox></td>
                                                                            <tr>
                                                                                <td style="width: 25%">SellerTradeName</td>
                                                                                <td style="width: 75%">
                                                                                    <asp:TextBox runat="server" ID="SellerTradeName" Style="width: 100%;"></asp:TextBox></td>
                                                                                <tr>
                                                                                    <td style="width: 25%">SellerPOS</td>
                                                                                    <td style="width: 75%">
                                                                                        <asp:TextBox runat="server" ID="SellerPOS" Style="width: 100%;"></asp:TextBox></td>
                                                                                    <tr>
                                                                                        <td style="width: 25%">SellerAddr1</td>
                                                                                        <td style="width: 75%">
                                                                                            <asp:TextBox runat="server" ID="SellerAddr1" Style="width: 100%;"></asp:TextBox></td>
                                                                                        <tr>
                                                                                            <td style="width: 25%">SellerAddr2</td>
                                                                                            <td style="width: 75%">
                                                                                                <asp:TextBox runat="server" ID="SellerAddr2" Style="width: 100%;"></asp:TextBox></td>
                                                                                            <tr>
                                                                                                <td style="width: 25%">SellerLocation</td>
                                                                                                <td style="width: 75%">
                                                                                                    <asp:TextBox runat="server" ID="SellerLocation" Style="width: 100%;"></asp:TextBox></td>
                                                                                                <tr>
                                                                                                    <td style="width: 25%">SellerPINCode</td>
                                                                                                    <td style="width: 75%">
                                                                                                        <asp:TextBox runat="server" ID="SellerPINCode" Style="width: 100%;"></asp:TextBox></td>
                                                                                                    <tr>
                                                                                                        <td style="width: 25%">SellerState</td>
                                                                                                        <td style="width: 75%">
                                                                                                            <asp:TextBox runat="server" ID="SellerState" Style="width: 100%;"></asp:TextBox></td>
                                                                                                        <tr>
                                                                                                            <td style="width: 25%">SellerPhoneNumber</td>
                                                                                                            <td style="width: 75%">
                                                                                                                <asp:TextBox runat="server" ID="SellerPhoneNumber" Style="width: 100%;"></asp:TextBox></td>
                                                                                                            <tr>
                                                                                                                <td style="width: 25%">SellerEmailID</td>
                                                                                                                <td style="width: 75%">
                                                                                                                    <asp:TextBox runat="server" ID="SellerEmailID" Style="width: 100%;"></asp:TextBox></td>
                                                                                                            </tr>






                                                                </table>
                                                                <!-- /.box-body -->

                                                                <!-- /.box-footer -->
                                                            </div>
                                                        </div>
                                                        <!-- /.box -->
                                                        <!-- general form elements disabled -->

                                                        <!-- /.box -->
                                                    </div>
                                                    <div class="col-md-4" style="padding: 0px 0px 0px 0px;">
                                                        <!-- Horizontal Form -->
                                                        <div class="box box-info">
                                                            <div class="box-header with-border">
                                                                <h3 class="box-title">Buyer Detail</h3>
                                                            </div>
                                                            <!-- /.box-header -->
                                                            <!-- form start -->

                                                            <div class="box-body">

                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td></td>
                                                                        <td></td>


                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 25%">BuyerGSTN</td>
                                                                        <td style="width: 75%">
                                                                            <asp:TextBox runat="server" ID="BuyerGSTN" Style="width: 100%;"></asp:TextBox></td>
                                                                        <tr>
                                                                            <td style="width: 25%">BuyerLegalName</td>
                                                                            <td style="width: 75%">
                                                                                <asp:TextBox runat="server" ID="BuyerLegalName" Style="width: 100%;"></asp:TextBox></td>
                                                                            <tr>
                                                                                <td style="width: 25%">BuyerTradeName</td>
                                                                                <td style="width: 75%">
                                                                                    <asp:TextBox runat="server" ID="BuyerTradeName" Style="width: 100%;"></asp:TextBox></td>
                                                                                <tr>
                                                                                    <td style="width: 25%">BuyerPOS</td>
                                                                                    <td style="width: 75%">
                                                                                        <asp:TextBox runat="server" ID="BuyerPOS" Style="width: 100%;"></asp:TextBox></td>
                                                                                    <tr>
                                                                                        <td style="width: 25%">BuyerAddr1</td>
                                                                                        <td style="width: 75%">
                                                                                            <asp:TextBox runat="server" ID="BuyerAddr1" Style="width: 100%;"></asp:TextBox></td>
                                                                                        <tr>
                                                                                            <td style="width: 25%">BuyerAddr2</td>
                                                                                            <td style="width: 75%">
                                                                                                <asp:TextBox runat="server" ID="BuyerAddr2" Style="width: 100%;"></asp:TextBox></td>
                                                                                            <tr>
                                                                                                <td style="width: 25%">BuyerLocation</td>
                                                                                                <td style="width: 75%">
                                                                                                    <asp:TextBox runat="server" ID="BuyerLocation" Style="width: 100%;"></asp:TextBox></td>
                                                                                                <tr>
                                                                                                    <td style="width: 25%">BuyerPINCode</td>
                                                                                                    <td style="width: 75%">
                                                                                                        <asp:TextBox runat="server" ID="BuyerPINCode" Style="width: 100%;"></asp:TextBox></td>
                                                                                                    <tr>
                                                                                                        <td style="width: 25%">BuyerState</td>
                                                                                                        <td style="width: 75%">
                                                                                                            <asp:TextBox runat="server" ID="BuyerState" Style="width: 100%;"></asp:TextBox></td>
                                                                                                        <tr>
                                                                                                            <td style="width: 25%">BuyerPhoneNumber</td>
                                                                                                            <td style="width: 75%">
                                                                                                                <asp:TextBox runat="server" ID="BuyerPhoneNumber" Style="width: 100%;"></asp:TextBox></td>
                                                                                                            <tr>
                                                                                                                <td style="width: 25%">BuyerEmailID</td>
                                                                                                                <td style="width: 75%">
                                                                                                                    <asp:TextBox runat="server" ID="BuyerEmailID" Style="width: 100%;"></asp:TextBox></td>
                                                                                                            </tr>





                                                                </table>
                                                                <!-- /.box-body -->

                                                                <!-- /.box-footer -->
                                                            </div>
                                                        </div>
                                                        <!-- /.box -->
                                                        <!-- general form elements disabled -->

                                                        <!-- /.box -->
                                                    </div>



                                                    <div class="col-md-4" style="padding: 0px 0px 0px 0px;">
                                                        <!-- Horizontal Form -->
                                                        <div class="box box-info">
                                                            <div class="box-header with-border">
                                                                <h3 class="box-title">Value Detail</h3>
                                                            </div>
                                                            <!-- /.box-header -->
                                                            <!-- form start -->

                                                            <div class="box-body">

                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>


                                                                    <tr>
                                                                        <td style="width: 25%">Total Taxable Value</td>
                                                                        <td style="width: 75%">
                                                                            <asp:TextBox runat="server" ID="TotalTaxableValue" Style="width: 100%;"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 25%">SGSTAmt1</td>
                                                                        <td style="width: 75%">
                                                                            <asp:TextBox runat="server" ID="SGSTAmt1" Style="width: 100%;"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 25%">CGSTAmt1</td>
                                                                        <td style="width: 75%">
                                                                            <asp:TextBox runat="server" ID="CGSTAmt1" Style="width: 100%;"></asp:TextBox></td>
                                                                        <tr>
                                                                            <td style="width: 25%">IGSTAmt1</td>
                                                                            <td style="width: 75%">
                                                                                <asp:TextBox runat="server" ID="IGSTAmt1" Style="width: 100%;"></asp:TextBox></td>
                                                                            <tr>
                                                                                <td style="width: 25%">CessAmount</td>
                                                                                <td style="width: 75%">
                                                                                    <asp:TextBox runat="server" ID="CessAmount" Style="width: 100%;"></asp:TextBox></td>
                                                                                <tr>
                                                                                    <td style="width: 25%">StateCessAmount</td>
                                                                                    <td style="width: 75%">
                                                                                        <asp:TextBox runat="server" ID="StateCessAmount" Style="width: 100%;"></asp:TextBox></td>
                                                                                    <tr>
                                                                                        <td style="width: 25%">Discount1</td>
                                                                                        <td style="width: 75%">
                                                                                            <asp:TextBox runat="server" ID="Discount1" Style="width: 100%;"></asp:TextBox></td>
                                                                                        <tr>
                                                                                            <td style="width: 25%">OtherCharges1</td>
                                                                                            <td style="width: 75%">
                                                                                                <asp:TextBox runat="server" ID="OtherCharges1" Style="width: 100%;"></asp:TextBox></td>
                                                                                            <tr>
                                                                                                <td style="width: 25%">RoundOff</td>
                                                                                                <td style="width: 75%">
                                                                                                    <asp:TextBox runat="server" ID="RoundOff" Style="width: 100%;"></asp:TextBox></td>
                                                                                                <tr>
                                                                                                    <td style="width: 25%">TotalInvoiceValue</td>
                                                                                                    <td style="width: 75%">
                                                                                                        <asp:TextBox runat="server" ID="TotalInvoiceValue" Style="width: 100%;"></asp:TextBox></td>
                                                                                                    <tr>
                                                                                                        <td style="width: 25%">Total INV Val in Add Cur </td>
                                                                                                        <td style="width: 75%">
                                                                                                            <asp:TextBox runat="server" ID="TotalInvoiceValueinAdditionalCurrency" Style="width: 100%;"></asp:TextBox></td>
                                                                                                    </tr>



                                                                </table>
                                                                <!-- /.box-body -->

                                                                <!-- /.box-footer -->
                                                            </div>
                                                        </div>
                                                        <!-- /.box -->
                                                        <!-- general form elements disabled -->

                                                        <!-- /.box -->
                                                    </div>


                                                </div>
                                            </div>
                                            <!-- /.tab-pane -->
                                            <div class="tab-pane" id="tab_2">
                                                <div class="col-md-4" style="padding: 0px 0px 0px 0px;">
                                                    <!-- Horizontal Form -->
                                                    <div class="box box-info">
                                                        <div class="box-header with-border">
                                                            <h3 class="box-title">Dispatch Detail</h3>
                                                        </div>
                                                        <!-- /.box-header -->
                                                        <!-- form start -->

                                                        <div class="box-body">

                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>


                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 25%">DispatchName</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="DispatchName" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">DispatchAddr1</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="DispatchAddr1" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">DispatchAddr2</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="DispatchAddr2" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">DispatchLocation</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="DispatchLocation" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">DispatchPINCode</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="DispatchPINCode" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">DispatchState</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="DispatchState" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>






                                                            </table>
                                                            <!-- /.box-body -->

                                                            <!-- /.box-footer -->
                                                        </div>
                                                    </div>
                                                    <!-- /.box -->
                                                    <!-- general form elements disabled -->

                                                    <!-- /.box -->
                                                </div>


                                                <div class="col-md-4" style="padding: 0px 0px 0px 0px;">
                                                    <!-- Horizontal Form -->
                                                    <div class="box box-info">
                                                        <div class="box-header with-border">
                                                            <h3 class="box-title">Shipping Detail</h3>
                                                        </div>
                                                        <!-- /.box-header -->
                                                        <!-- form start -->

                                                        <div class="box-body">

                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>


                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 25%">ShippingGSTN</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="ShippingGSTN" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">ShippingLegalName</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="ShippingLegalName" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">ShippingTradeName</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="ShippingTradeName" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">ShippingAddr1</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="ShippingAddr1" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">ShippingAddr2</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="ShippingAddr2" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">ShippingLocation</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="ShippingLocation" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">ShippingPINCode</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="ShippingPINCode" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">ShippingState</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox runat="server" ID="ShippingState" Style="width: 100%;"></asp:TextBox></td>
                                                                </tr>





                                                            </table>
                                                            <!-- /.box-body -->

                                                            <!-- /.box-footer -->
                                                        </div>
                                                    </div>
                                                    <!-- /.box -->
                                                    <!-- general form elements disabled -->

                                                    <!-- /.box -->
                                                </div>

                                                <div class="col-md-4" style="padding: 0px 0px 0px 0px;">
                                                    <!-- Horizontal Form -->
                                                    <div class="box box-info">
                                                        <div class="box-header with-border">
                                                            <h3 class="box-title">Payment Detail</h3>
                                                        </div>
                                                        <!-- /.box-header -->
                                                        <!-- form start -->

                                                        <div class="box-body">

                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>


                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 25%">PayeeName</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox ID="PayeeName" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                    </td>
                                                                <tr>
                                                                    <td style="width: 25%">AccountNumber</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox ID="AccountNumber" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">Mode</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox ID="Mode" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">BranchIFSCCode</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox ID="BranchIFSCCode" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">TermofPayment</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox ID="TermofPayment" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">PaymentInstuction</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox ID="PaymentInstuction" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 25%">CreditTransfer</td>
                                                                    <td style="width: 75%">
                                                                        <asp:TextBox ID="CreditTransfer" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                    </td>
                                                                    <tr>
                                                                        <td style="width: 25%">DirectDebit</td>
                                                                        <td style="width: 75%">
                                                                            <asp:TextBox ID="DirectDebit" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 25%">CreditDays</td>
                                                                        <td style="width: 75%">
                                                                            <asp:TextBox ID="CreditDays" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 25%">PaidedAmount</td>
                                                                        <td style="width: 75%">
                                                                            <asp:TextBox ID="PaidedAmount" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                        </td>
                                                                        <tr>
                                                                            <td style="width: 25%">DueAmount</td>
                                                                            <td style="width: 75%">
                                                                                <asp:TextBox ID="DueAmount" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 25%">Remarks</td>
                                                                            <td style="width: 75%">
                                                                                <asp:TextBox ID="Remarks" runat="server" Style="width: 100%;"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </tr>
                                                                </tr>





                                                            </table>
                                                            <!-- /.box-body -->

                                                            <!-- /.box-footer -->
                                                        </div>
                                                    </div>
                                                    <!-- /.box -->
                                                    <!-- general form elements disabled -->

                                                    <!-- /.box -->
                                                </div>


                                            </div>
                                            <!-- /.tab-pane -->

                                            <!-- /.tab-pane -->
                                        </div>
                                        <!-- /.tab-content -->
                                    </div>

                                </div>



                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <asp:GridView ID="gvlocation" runat="server" AutoGenerateColumns="false" Width="100%" align="center">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SlNo">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="SlNo" Text='<%# Eval("SlNo")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PrdDesc">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="PrdDesc" Text='<%# Eval("PrdDesc")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IsServc">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="IsServc" Text='<%# Eval("IsServc")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="HsnCd">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="HsnCd" Text='<%# Eval("HsnCd")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Barcde">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="Barcde" Text='<%# Eval("Barcde")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="Qty" Text='<%# Eval("Qty")%>'  oninput="calulationGrid()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="FreeQty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="FreeQty" Text='<%# Eval("FreeQty")%>' oninput="calulationGrid()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="Unit" Text='<%# Eval("Unit")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="UnitPrice">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="UnitPrice" Text='<%# Eval("UnitPrice")%>' oninput="calulationGrid()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="TotAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="TotAmt" Text='<%# Eval("TotAmt")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Discount">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="Discount" Text='<%# Eval("Discount")%>' oninput="calulationGrid()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PreTaxVal">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="PreTaxVal" Text='<%# Eval("PreTaxVal")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="AssAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="AssAmt" Text='<%# Eval("AssAmt")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GstRt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="GstRt" Text='<%# Eval("GstRt")%>' oninput="calulationGrid()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IgstAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="IgstAmt" Text='<%# Eval("IgstAmt")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CgstAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="CgstAmt" Text='<%# Eval("CgstAmt")%>' ></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SgstAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="SgstAmt" Text='<%# Eval("SgstAmt")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CesRt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="CesRt" Text='<%# Eval("CesRt")%>' oninput="calulationGrid()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CesAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="CesAmt" Text='<%# Eval("CesAmt")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CesNonAdvlAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="CesNonAdvlAmt" Text='<%# Eval("CesNonAdvlAmt")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="StateCesRt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="StateCesRt" Text='<%# Eval("StateCesRt")%>' oninput="calulationGrid()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="StateCesAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="StateCesAmt" Text='<%# Eval("StateCesAmt")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="StateCesNonAdvlAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="StateCesNonAdvlAmt" Text='<%# Eval("StateCesNonAdvlAmt")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="OthChrg">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="OthChrg" Text='<%# Eval("OthChrg")%>' oninput="calulationGrid()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="TotItemVal">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="TotItemVal" Text='<%# Eval("TotItemVal")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="OrdLineRef">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="OrdLineRef" Text='<%# Eval("OrdLineRef")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="OrgCntry">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="OrgCntry" Text='<%# Eval("OrgCntry")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PrdSlNo">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" ID="PrdSlNo" Text='<%# Eval("PrdSlNo")%>'></asp:TextBox>
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
                            <div class="box-footer">
                                <asp:Button runat="server" Text="Save Data" ID="saveAccountHead" ValidationGroup="head" CssClass="btn btn-primary" OnClick="saveAccountHead_Click" />
                                <asp:Button runat="server" Text="Add New Row" ID="AddNew" ValidationGroup="head" CssClass="btn btn-danger" OnClick="Button1_Click" />

                            </div>
                        </div>

                    </div>
                </div>

            </div>


        </ContentTemplate>


    </asp:UpdatePanel>
       <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="z-index: 10001;" class="windowbackground">
                <div class="progressbar breadcrumb">
                    <img alt="Loading..." src="../images/ajax-loader.gif"><br>
                    Please Wait...
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">

    <script>
        function calulationGrid() {

            var objgrid = document.getElementById('<%=  gvlocation.ClientID %>');
            var SellerState = document.getElementById('<%=  SellerState.ClientID %>').value;
            var BuyerState = document.getElementById('<%=  BuyerState.ClientID %>').value;


            var TTotalAssAmt = 0;
            var TSGSTAmt = 0;
            var TCGSTAmt = 0;
            var TIGSTAmt = 0;
            var TCessAmount = 0;
            var tDiscount = 0;
            var TOtherCharges = 0;


            var  GrandTotal = 0;
            for (var i = 1; i < objgrid.rows.length; i++) {
             
                var Qty = objgrid.rows[i].cells[5].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[5].getElementsByTagName('input')[0].value) : 0;
                var FreeQty = objgrid.rows[i].cells[6].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[6].getElementsByTagName('input')[0].value) : 0;
             
                var UnitPrice = objgrid.rows[i].cells[8].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[8].getElementsByTagName('input')[0].value) : 0;
                var TotAmt = objgrid.rows[i].cells[9].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[9].getElementsByTagName('input')[0].value) : 0;
                TotAmt= RoundMath(((Qty - FreeQty) * UnitPrice));
                objgrid.rows[i].cells[9].getElementsByTagName('input')[0].value = TotAmt.toFixed(2);

                var Discount = objgrid.rows[i].cells[10].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[10].getElementsByTagName('input')[0].value) : 0;

                var PreTaxVal = objgrid.rows[i].cells[11].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[11].getElementsByTagName('input')[0].value) : 0;

                PreTaxVal = RoundMath(TotAmt - Discount);
                objgrid.rows[i].cells[11].getElementsByTagName('input')[0].value = PreTaxVal;
                objgrid.rows[i].cells[12].getElementsByTagName('input')[0].value = PreTaxVal;
                
                
                

                var GstRt = objgrid.rows[i].cells[13].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[13].getElementsByTagName('input')[0].value) : 0;
              
                var CgstAmt = 0;
                var SgstAmt = 0;
                var IgstAmt = 0;
                if (parseInt(SellerState) ==parseInt(  BuyerState)) {
                    var CS = RoundMath(((PreTaxVal * GstRt) / 100) / 2)
                    objgrid.rows[i].cells[15].getElementsByTagName('input')[0].value = CS.toFixed(2);
                    objgrid.rows[i].cells[16].getElementsByTagName('input')[0].value = CS.toFixed(2);
                    objgrid.rows[i].cells[14].getElementsByTagName('input')[0].value = "0";
                    CgstAmt = CS;
                    SgstAmt = CS;
                }
                else {
                    var CS = RoundMath(((PreTaxVal * GstRt) / 100))
                    objgrid.rows[i].cells[14].getElementsByTagName('input')[0].value = CS.toFixed(2);
                    objgrid.rows[i].cells[16].getElementsByTagName('input')[0].value = "0";
                    objgrid.rows[i].cells[15].getElementsByTagName('input')[0].value = "0";
                    IgstAmt = CS;
                }

            
                
              
                var CesRt = objgrid.rows[i].cells[17].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[17].getElementsByTagName('input')[0].value) : 0;

                var CesAmt = 0;
                CesAmt = RoundMath(((PreTaxVal * CesRt) / 100))
                objgrid.rows[i].cells[18].getElementsByTagName('input')[0].value = CesAmt.toFixed(2)
                var CesNonAdvlAmt = objgrid.rows[i].cells[19].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[19].getElementsByTagName('input')[0].value) : 0;
                var StateCesRt = objgrid.rows[i].cells[20].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[20].getElementsByTagName('input')[0].value) : 0;
                var StateCesAmt = objgrid.rows[i].cells[21].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[21].getElementsByTagName('input')[0].value) : 0;
                var StateCesNonAdvlAmt = objgrid.rows[i].cells[22].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[22].getElementsByTagName('input')[0].value) : 0;
                var OthChrg = objgrid.rows[i].cells[23].getElementsByTagName('input')[0].value.length > 0 ? parseFloat(objgrid.rows[i].cells[23].getElementsByTagName('input')[0].value) : 0;
                var TotItemVal = (PreTaxVal + CgstAmt + SgstAmt + IgstAmt + CesAmt + OthChrg)
                objgrid.rows[i].cells[24].getElementsByTagName('input')[0].value = TotItemVal.toFixed(2);
                GrandTotal = GrandTotal + (TotItemVal);
                TTotalAssAmt = TTotalAssAmt + PreTaxVal;
                TSGSTAmt = TSGSTAmt + SgstAmt;
                TCGSTAmt = TCGSTAmt + CgstAmt;
                TIGSTAmt = TIGSTAmt + IgstAmt;
                TCessAmount = TCessAmount + CesAmt;
                TOtherCharges = TOtherCharges + OthChrg;
                tDiscount = tDiscount + Discount;
               
            }
           
            document.getElementById('<%=TotalTaxableValue.ClientID%>').value = RoundMath(TTotalAssAmt).toFixed(2);
            document.getElementById('<%=SGSTAmt1.ClientID%>').value = RoundMath(TSGSTAmt).toFixed(2);
            document.getElementById('<%=CGSTAmt1.ClientID%>').value = RoundMath(TCGSTAmt).toFixed(2);
            document.getElementById('<%=IGSTAmt1.ClientID%>').value = RoundMath(TIGSTAmt).toFixed(2);
            document.getElementById('<%=CessAmount.ClientID%>').value = RoundMath(TCessAmount).toFixed(2);
            document.getElementById('<%=OtherCharges1.ClientID%>').value = RoundMath(TOtherCharges).toFixed(2);
            document.getElementById('<%=Discount1.ClientID%>').value = RoundMath(tDiscount).toFixed(2);

           

            var TotalValuesSend = RoundF(GrandTotal);
            document.getElementById('<%=RoundOff.ClientID%>').value = (GrandTotal - RoundF(GrandTotal)).toFixed(2)
            document.getElementById('<%=TotalInvoiceValue.ClientID%>').value = TotalValuesSend;
            
            
            
        }



        function  RoundMath(value)
        {

            var pow = Math.pow(10, 2);

            return parseFloat((Math.trunc(parseFloat(value) * pow + Math.sign(parseFloat(value)) * 0.5) / pow));
        }

     function RoundF( value)
        {
            var  decimalpoint = Math.abs(value - Math.floor(value));
        if (decimalpoint > 0.5)
        {
            return parseInt( Math.round(value));
        }
        else
        { return parseInt( Math.floor(value)); }
        }

    </script>
</asp:Content>
