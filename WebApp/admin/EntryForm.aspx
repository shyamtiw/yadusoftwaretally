<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="EntryForm.aspx.cs" Inherits="WebApp.admin.EntryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style>
     

        .t02 th {
            background-color: navy;
            color: white;
        }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>
            <SG:Message runat="server" ID="MessageBox" />
            <div class="row">
                <div class="col-md-5" style="padding: 0px 0px 0px 0px;">
                    <!-- Horizontal Form -->
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding-right:10px"><asp:Button runat="server" ID="Button2" Text="Save"     CssClass="btn btn-block btn-success btn-flat"/></td>
                                    <td  style="padding-right:10px"><asp:Button runat="server" ID="Button3" Text="Update"   CssClass="btn btn-block btn-warning btn-flat"/></td>
                                    <td  style="padding-right:10px"><asp:Button runat="server" ID="Button1" Text="Print"    CssClass="btn btn-block btn-info btn-flat"/></td>
                                     <td  style="padding-right:10px"><asp:Button runat="server" ID="Button5" Text="Delete"   CssClass="btn btn-block btn-default btn-flat"/></td>
                                    <td  style="padding-right:10px"><asp:Button runat="server" ID="Button4" Text="Cancel"   CssClass="btn btn-block btn-danger btn-flat"/></td>
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
                                    <td style="width: 25%">Book Name</td>
                                    <td colspan="4">
                                        <asp:TextBox runat="server" ID="Tran_Type" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 25%">Vch/Inv. No.</td>
                                    <td style="width: 33%">
                                        <asp:TextBox runat="server" ID="Bill_No" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                    <td style="width: 9%">Vch/Date</td>
                                    <td style="width: 33%" colspan="2">
                                        <asp:TextBox runat="server" ID="Bill_Date" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 25%">GST Vch/Inv. No.</td>
                                    <td style="width: 33%">
                                        <asp:TextBox runat="server" ID="Bill_No2" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                    <td style="width: 42%" colspan="3">
                                        <asp:TextBox runat="server" ID="TextBox4" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>


                                <tr>
                                    <td style="width: 25%">Customer Acc</td>
                                    <td colspan="3" style="width: 100%">
                                        <asp:TextBox runat="server" ID="Ledger_Name" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                    <td style="width: 10%">
                                   <asp:LinkButton runat="server" ID="asdd"> <li class="fa fa-repeat"></li></asp:LinkButton>
                                        
                                    </td>

                                </tr>



                                <tr>
                                    <td style="width: 25%">Print Dis. Name</td>
                                    <td colspan="4" style="width: 100%">
                                        <asp:TextBox runat="server" ID="Ledger_Name2" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="width: 25%">Ref. No.</td>
                                    <td style="width: 33%">
                                        <asp:TextBox runat="server" ID="Sale_Type" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                    <td style="width: 9%">Ref. Date</td>
                                    <td style="width: 33%" colspan="2">
                                        <asp:TextBox runat="server" ID="Ref_Dt" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>

                                <tr>
                                    <td style="width: 25%">Narration</td>
                                    <td colspan="4">
                                        <asp:TextBox runat="server" ID="Narration" Style="width: 100%;" TextMode="MultiLine"></asp:TextBox>
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

                <div class="col-md-5" style="padding: 0px 0px 0px 0px;">
                    <!-- Horizontal Form -->
                    <div class="box box-info">
                        <div class="box-header with-border">
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
                                    <td style="width: 25%">Place Of Supply</td>
                                    <td colspan="4">
                                        <asp:TextBox runat="server" ID="State_Code" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 25%">Registration Type</td>
                                    <td colspan="4">
                                        <asp:DropDownList runat="server" ID="RE_Type" Style="width: 100%;"></asp:DropDownList>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 25%">Customer GSTN</td>
                                    <td colspan="4">
                                        <asp:TextBox runat="server" ID="GST" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>

                                <tr>
                                    <td style="width: 25%">Reverse Charge</td>
                                    <td colspan="4">
                                        <asp:DropDownList runat="server" ID="IsRCM" Style="width: 100%;"></asp:DropDownList>
                                    </td>

                                </tr>


                                <tr>
                                    <td style="width: 50%; border-right: solid; border-width: 2px" colspan="2">Other Expenses/Disc./TDS/Rnd Off </td>
                                    <td style="width: 25%; border-right: solid; border-width: 2px; text-align: center">%</td>
                                    <td style="width: 25%; border-right: solid; border-width: 2px; text-align: center">Amount</td>


                                </tr>

                                <tr>
                                    <td style="width: 50%;" colspan="2">
                                        <asp:TextBox runat="server" ID="Exp_Ledg4" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:TextBox runat="server" ID="Exp_Perc4" Style="width: 100%;"></asp:TextBox></td>
                                    <td style="width: 25%;">
                                        <asp:TextBox runat="server" ID="Exp_Amt4" Style="width: 100%;"></asp:TextBox></td>


                                </tr>
                                <tr>
                                    <td style="width: 50%;" colspan="2">
                                        <asp:TextBox runat="server" ID="Exp_Ledg5" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:TextBox runat="server" ID="Exp_Perc5" Style="width: 100%;"></asp:TextBox></td>
                                    <td style="width: 25%;">
                                        <asp:TextBox runat="server" ID="Exp_Amt5" Style="width: 100%;"></asp:TextBox></td>


                                </tr>
                                <tr>
                                    <td style="width: 50%;" colspan="2">
                                        <asp:TextBox runat="server" ID="Exp_Ledg6" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:TextBox runat="server" ID="Exp_Perc6" Style="width: 100%;"></asp:TextBox></td>
                                    <td style="width: 25%;">
                                        <asp:TextBox runat="server" ID="Exp_Amt6" Style="width: 100%;"></asp:TextBox></td>


                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox runat="server" ID="sdasd" Text="Show TDS Section" Font-Size="XX-Small" />
                                    </td>

                                    <td>
                                        <asp:CheckBox runat="server" TextAlign="Right" ID="CheckBox1" Text="Print Narration" Font-Size="XX-Small" />
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="CheckBox2" Text="Print Ref.No as Inv No." Font-Size="XX-Small" />
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="CheckBox3" Text="Allow Auto Round Off" Font-Size="XX-Small" />
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


                <div class="col-md-2" style="padding: 0px 0px 0px 0px;">
                    <!-- Horizontal Form -->
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <h3 class="box-title"> </h3>
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
                                    <td style="width: 50%">Taxable Item</td>
                                    <td style="width: 50%">
                                        <asp:TextBox runat="server" ID="Tot_Taxable" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>



                                <tr>
                                    <td style="width: 25%">CGST Amount</td>
                                    <td style="width: 75%">
                                        <asp:TextBox runat="server" ID="Tot_CGST" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>

                                <tr>
                                    <td style="width: 25%">SGST Amount</td>
                                    <td style="width: 75%">
                                        <asp:TextBox runat="server" ID="Tot_SGST" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>


                                <tr>
                                    <td style="width: 25%">IGST Amount</td>
                                    <td style="width: 75%">
                                        <asp:TextBox runat="server" ID="Tot_IGST" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 25%">CESS Amount</td>
                                    <td style="width: 75%">
                                        <asp:TextBox runat="server" ID="Tot_CESS" Style="width: 100%;"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 25%">Dis(-)</td>
                                    <td style="width: 75%">
                                        <asp:TextBox runat="server" ID="Tot_Dis" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%">Total Inv.</td>
                                    <td style="width: 75%">
                                        <asp:TextBox runat="server" ID="Tot_TotalInv" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%">Expenses</td>
                                    <td style="width: 75%">
                                        <asp:TextBox runat="server" ID="Tot_Expenses" Style="width: 100%;"></asp:TextBox>
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
                    <div class="table-responsive">
                    <table class="table t01 t02"  style="height:0px">
                        <tr>
                              <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">SN.</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Posting Ledger</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Item Name</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Branch Location</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Cost Center</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Category</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Item Type</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">HSN/SAC</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Qty</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Uom</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Unit Rate</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Disc%</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Dis AMT.</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Basic.</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Assessable Value.</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">CGST</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Amount</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">SGST</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Amount</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">IGST</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Amount</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">CESS</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Amount</th>
                            <th style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">Net Amount</th>
                        </tr>
                        <tr>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox30" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox31" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox32" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox33" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox34" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox35" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox36" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox37" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox38" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox39" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox40" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox41" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox42" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox43" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox44" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox45" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox46" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox47" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox48" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox49" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox50" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox51" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox52" Style="width: 100%;"></asp:TextBox></td>
                            <td  style="border: 1px solid black;border-collapse: collapse;white-space:nowrap; width: 99%">
                                <asp:TextBox runat="server" ID="TextBox53" Style="width: 100%;"></asp:TextBox></td>
                        </tr>
                    </table>
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
