<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="truevalueICM.aspx.cs" Inherits="WebApp.admin.truevalueICM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t02 th {
            background-color: navy;
            color: white;
        }

        td {
            padding: 1px;
        }

        input:focus {
            background-color: lightgray;
        }

        select:focus {
            background-color: lightgray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
    True Value CRM
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>
            <SG:Message runat="server" ID="MessageBox" />
            <div class="row">
                <div class="col-md-10">
                    <div class="row">
                        <div class="col-md-6" style="padding: 0px 0px 0px 0px;">
                            <!-- Horizontal Form -->
                            <div class="box box-info">
                                <div class="box-header with-border">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="padding-right: 10px">
                                                <asp:Button runat="server" ID="Button2" Text="Save" CssClass="btn btn-block btn-success btn-flat" /></td>
                                            <td style="padding-right: 10px">
                                                <asp:Button runat="server" ID="Button3" Text="Update" CssClass="btn btn-block btn-warning btn-flat" /></td>
                                            <td style="padding-right: 10px">
                                                <asp:Button runat="server" ID="Button1" Text="Print" CssClass="btn btn-block btn-info btn-flat" /></td>
                                            <td style="padding-right: 10px">
                                                <asp:Button runat="server" ID="Button5" Text="Delete" CssClass="btn btn-block btn-default btn-flat" /></td>
                                            <td style="padding-right: 10px">
                                                <asp:Button runat="server" ID="Button4" Text="Cancel" CssClass="btn btn-block btn-danger btn-flat" /></td>
                                        </tr>
                                    </table>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->

                                <div class="box-body">

                                    <table style="width: 100%">
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>

                                        </tr>

                                        <tr>
                                            <td style="width: 20%">Customer Name</td>
                                            <td colspan="4" style="width: 80%">
                                                <asp:TextBox runat="server" ID="CUSTOMERNAME" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="width: 20%">Address</td>
                                            <td colspan="4" style="width: 80%">
                                                <asp:TextBox runat="server" ID="ADDRESS" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td style="width: 20%">CITY</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="CITY" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">State</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="STATE" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="width: 20%">Pin</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="PIN" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Pan</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="PAN" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td style="width: 20%">Email</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="EMAIL" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Mobile</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="Mobile" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td style="width: 20%">Customer GSTIN</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="CUSTOMERGSTIN" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Pos</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="PLACEOFSUPPLY" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>



                                        <tr>
                                            <td style="width: 20%">Dealer GST No.</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="DEALERGSTNO" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Selling Dealer</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="SELLINGDEALER" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>



                                        <tr>
                                            <td style="width: 20%">ENQ. Source</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="ENQSOURCE" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Vehicle Category</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="VEHICLECATEGORY" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr style="background-color: yellow">
                                            <td style="width: 20%">Cert. Status</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="CERTSTATUS" Style="width: 100%;" BackColor="Yellow"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Sales Executive</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="SALESEXECUTIVE" Style="width: 100%;" BackColor="Yellow"></asp:TextBox>
                                            </td>

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

                        <div class="col-md-6" style="padding: 0px 0px 0px 0px;">
                            <!-- Horizontal Form -->
                            <div class="box box-info">
                                <div class="box-header with-border" style="padding-top: 26px!important;">
                                    <center>    <h4 class="box-title"><b>Sale/Income Invoice</b></h4></center>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->

                                <div class="box-body">

                                    <table style="width: 100%">
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>

                                        </tr>

                                        <tr>
                                            <td style="width: 20%">Invoice No</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="INVOICENO" Style="width: 100%;"></asp:TextBox>
                                            </td>


                                            <td style="width: 20%">INVOICE DATE</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="INVOICEDATE" CssClass="Date" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td style="width: 20%">Booking No</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="BookingNo" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Booking Date</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="BOOKINGDATE" CssClass="Date" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="width: 20%">Manufacture</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="MANUFACTURE" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Model</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="MODEL" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td style="width: 20%">Variant</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="VARIANT" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Color</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="COLOUR" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td style="width: 20%">HSN</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="HSN" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">MFG. Year</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="MFGYEAR" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>



                                        <tr>
                                            <td style="width: 20%">Chassis Id</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="CHASSISID" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Engine No.</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="ENGINENO" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>



                                        <tr>

                                            <td style="width: 20%">Reg. No.</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="REGNO" Style="width: 100%;"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%">Vin. No.</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="VINNO" Style="width: 100%;"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr style="background-color: yellow">

                                            <td style="width: 20%">RC Transfer By</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="RCTRANSFERBY" Style="width: 100%;" BackColor="Yellow"></asp:TextBox>
                                            </td>

                                            <td style="width: 20%">RC Transfer Date</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="RCTRANSFERDATE" Style="width: 100%;" BackColor="Yellow"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr style="background-color: yellow">

                                            <td style="width: 20%">RC Transfer Amt.</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="RCTRANSFERAMT" Style="width: 100%;" BackColor="Yellow"></asp:TextBox>
                                            </td>

                                            <td style="width: 20%">RC Security Amt.</td>
                                            <td style="width: 30%">
                                                <asp:TextBox runat="server" ID="RCSECURITYAMT" Style="width: 100%;" BackColor="Yellow"></asp:TextBox>
                                            </td>

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
                    <div class="row">
                        <div class="col-md-12">
                            <div class="box box-success box-solid">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Recipt Details</h3>


                                    <!-- /.box-tools -->
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">

                                    <div class="box-body">

                                        <table style="width: 100%">
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>

                                            </tr>

                                         

                                            <tr>
                                                <td style="width: 10%">Branch</td>
                                                <td style="width: 15%">
                                                   <asp:DropDownList runat="server" ID="BranchId" Style="width: 100%;"></asp:DropDownList>
                                                </td>
                                                <td style="width: 10%">Pay. Mode</td>
                                                <td style="width: 15%">
                                                     <asp:DropDownList runat="server" ID="MasterId" Style="width: 100%;"></asp:DropDownList>
                                                </td>

                                           
                                                <td style="width: 10%">Recipt No.</td>
                                                <td style="width: 15%">
                                                    <asp:TextBox runat="server" ID="ReciptNo" Style="width: 100%;"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%">Recipt Date</td>
                                                <td style="width: 15%">
                                                    <asp:TextBox runat="server" ID="ReciptDate" Style="width: 100%;"></asp:TextBox>
                                                </td>

                                            </tr>

                                               <tr>
                                                <td style="width: 10%">Recipt Amt.</td>
                                                <td style="width: 15%">
                                                 <asp:TextBox runat="server" ID="ReciptAmount" Style="width: 100%;"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%">Recipt Img.</td>
                                                <td style="width: 15%">
                                                    <asp:FileUpload runat="server"  ID="FileImg"  Style="width: 100%; border:solid 1px;" />
                                                </td>

                                           
                                                <td style="width: 10%">Remark</td>
                                                <td style="width: 40%" colspan="4">
                                                    

                                                    <div class="input-group input-group-sm"  style="width: 100%;">
                                                        <asp:TextBox runat="server" ID="remark" Style="width: 100%;"></asp:TextBox>

                                                        <span class="input-group-btn">
                                                           <asp:Button   runat="server" ID="AddRecipt" Text="Add."  CssClass="btn btn-primary"/>

                                                        </span>
                                                    </div>
                                                </td>
                                                 
                                              
                                            </tr>
                                        </table>
                                    </div>
                                    <!-- /.box-body -->
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                <div class="col-md-2" style="padding: 0px 0px 0px 0px;">
                    <div class="col-md-12" style="padding: 0px 0px 0px 0px;">
                        <!-- Horizontal Form -->
                        <div class="box box-info box-solid">
                            <div class="box-header with-border">
                                <h3 class="box-title">Summery</h3>


                                <!-- /.box-tools -->
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <table style="width: 100%">
                                    <tr>
                                        <td></td>
                                        <td></td>


                                    </tr>

                                    <tr>
                                        <td style="width: 50%">Sale Price</td>
                                        <td style="width: 50%">
                                            <asp:TextBox runat="server" ID="SALEPRICE" Style="width: 100%;"></asp:TextBox>
                                        </td>

                                    </tr>



                                    <tr>
                                        <td style="width: 25%">Taxable</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="TAXABLE" Style="width: 100%;"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 25%">SGST Amount</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="Tot_SGST" Style="width: 100%;"></asp:TextBox>
                                        </td>

                                    </tr>


                                    <tr>
                                        <td style="width: 25%">CGST Amt.</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="CGST" Style="width: 100%;"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 25%">SGST Amt.</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="SGST" Style="width: 100%;"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 25%">IGST Amt.</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="IGST" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">Cess.</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="CESS" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">Inv.Amt.</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="INVAmount" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">RF.Expenses</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="RFEXPENSES" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">Insu. Charges</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="INSURANCECHARGES" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">Reg. Charges</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="REGESTRATIONCHARGES" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Trans. Charges</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="TRANSFERCHARGES" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Other. Charges</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="OTHERCHARGES" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">Sale Amt.</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="TOTALSALEAMT" Style="width: 100%;"></asp:TextBox>
                                        </td>
                                    </tr>


                                     <tr>
                                        <td style="width: 25%">Receipt Amt.</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="ReceiptAmount" Style="width: 100%;" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">Balance Amt.</td>
                                        <td style="width: 75%">
                                            <asp:TextBox runat="server" ID="BalanceAmt" Style="width: 100%;" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>

                                </table>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                        <!-- general form elements disabled -->

                        <!-- /.box -->
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
</asp:Content>
