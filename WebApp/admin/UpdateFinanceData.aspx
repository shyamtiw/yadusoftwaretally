<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="UpdateFinanceData.aspx.cs" Inherits="WebApp.admin.UpdateFinanceData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        .t02 th {
            background-color: #3c8dbc;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formahndler" runat="server">
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>
             <SG:Message ID="MessageBox" runat="server" />
            <div class="content-wrapper" style="background-color: white;">
                <!-- Content Header (Page header) -->

                <section class="content">




                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">





          <!-- nav-tabs-custom -->
        </div>



                                    <!-- general form elements disabled -->
                                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                                            <h4 class="box-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne"> Update Finance Entry
                      </a>
                                            </h4>
                                        </div>



                                        
                                        <div class="row" style="padding-left:10px!important;padding-right:10px!important">
                                             

                                        
                                    <div class="nav-tabs-custom" style="padding-left:10px!important;padding-right:10px!important">
            <ul class="nav nav-tabs">
              <li class="active"><a href="#tab_1" data-toggle="tab" aria-expanded="true">Finance</a></li>
              <li class=""><a href="#tab_2" data-toggle="tab" aria-expanded="false">Loan Disb</a></li>
              <li class=""><a href="#tab_3" data-toggle="tab" aria-expanded="false">Payout Disb</a></li>
             
              <li class="pull-right"><a href="#" class="text-muted"><i class="fa fa-gear"></i></a></li>
            </ul>
            <div class="tab-content">
              <div class="tab-pane active" id="tab_1">
              
                   <div class="row" style="padding-left:10px!important;padding-right:10px!important">
                                              <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Delivery Date.</label>
                                                    <asp:TextBox runat="server" ID="DeliveryDate" CssClass="form-control Date"></asp:TextBox>

                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>LoanType</label>
                                                    <asp:DropDownList runat="server" ID="LoanType" CssClass="form-control" onchange=" PayTypedata()">
                                                        <asp:ListItem Text="Self" Value="Self"></asp:ListItem>
                                                        <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                        <asp:ListItem Text="Bank Source" Value="Bank Source"></asp:ListItem>
                                                        <asp:ListItem Text="In-House" Value="In-House"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>

                                            </div>
                                           
                                             <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Financer Name</label>
                                                    <asp:DropDownList runat="server" ID="Hypo" CssClass="form-control" >
                                                        
                                                    </asp:DropDownList>

                                                </div>

                                            </div>
                                                 <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Financer Branch</label>
                                                    <asp:TextBox runat="server" ID="hypoBranch" CssClass="form-control"></asp:TextBox>

                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Do.No.</label>
                                                    <asp:TextBox runat="server" ID="DoNo" CssClass="form-control" oninput="DoNoIn()"></asp:TextBox>

                                                </div>

                                            </div>
                           <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Do Date</label>
                                                    <asp:TextBox runat="server" ID="DoDate" CssClass="form-control Date" oninput="DoDateIn()"></asp:TextBox>

                                                </div>

                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Do Amt</label>
                                                    <asp:TextBox runat="server" ID="DoAmt" CssClass="form-control" oninput="CalcPayout()"></asp:TextBox>

                                                </div>

                                            </div>
                                             <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>PF Charg.</label>
                                                    <asp:TextBox runat="server" ID="PfCharg" CssClass="form-control" oninput="CalcPayout()"></asp:TextBox>

                                                </div>

                                            </div>

                                             <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Net Do Amt</label>
                                                   <asp:Label runat="server" ID="NetDoAmt" CssClass="form-control"  ></asp:Label>

                                                </div>

                                            </div>

                                           

                                            
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Pay Out</label>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 25%; border: 0px solid black!important">
                                                                <asp:TextBox runat="server" ID="Payoutpercent" oninput="CalcPayout()" placeholder="%" CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 75%; border: 0px solid black!important">
                                                                <asp:TextBox runat="server" oninput="CalcPayoutAmount()" ID="PayoutpercentAmount" placeholder="Pay Out Amt." CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>GST Amt.</label>
                                                    <asp:TextBox runat="server" ID="GSTAmount" CssClass="form-control" oninput="CalcAmountGSTAmout()"></asp:TextBox>

                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>FinalAmout</label>
                                                    <asp:TextBox runat="server" ID="FinalAmout" oninput="ReCalculation(this)" CssClass="form-control"></asp:TextBox>

                                                </div>

                                            </div>
                                             <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>DSE Payout</label>
                                                    <asp:TextBox runat="server" ID="DSEPayout" CssClass="form-control"></asp:TextBox>

                                                </div>

                                            </div>

                        <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Rate Of Interest</label>
                                                    <asp:TextBox runat="server" ID="ROI" CssClass="form-control"></asp:TextBox>

                                                </div>

                                            </div>
                                <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>MSSF</label>
                                                    <asp:DropDownList runat="server" ID="MSSF" CssClass="form-control" onchange=" PayTypedata()">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                        
                                                    </asp:DropDownList>

                                                </div>

                                            </div>
                       <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Actual Rate</label>
                                                    <asp:TextBox runat="server" ID="ActualRate" CssClass="form-control" oninput="CalculationActualRate(this)"></asp:TextBox>

                                                </div>

                                            </div>

              </div>
               
              <!-- /.tab-pane -->
                </div>
              <div class="tab-pane" id="tab_2">
            
                  <div class="row" style="padding-left:10px!important;padding-right:10px!important">
                                             

                      <%--//ReadOnly--%>
                      <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Do.No.</label>
                                                    <asp:Label runat="server" ID="DoNoT" CssClass="form-control" BackColor="WhiteSmoke"   ></asp:Label>

                                                </div>

                                            </div>
                           <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Do Date</label>
                                                    <asp:Label runat="server" ID="DoDateT" CssClass="form-control" BackColor="WhiteSmoke"  ></asp:Label>

                                                </div>

                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Do Amt</label>
                                                   <asp:Label runat="server" ID="DoAmtT" CssClass="form-control" BackColor="WhiteSmoke" ></asp:Label>

                                                </div>

                                            </div>
                                             <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>PF Charg.</label>
                                                           <asp:Label runat="server" ID="PfChargT" CssClass="form-control" BackColor="WhiteSmoke"  ></asp:Label>

                                                </div>

                                            </div>

                                             <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Net Do Amt</label>
                                                   <asp:Label runat="server" ID="NetDoAmtT" CssClass="form-control" BackColor="WhiteSmoke"  ></asp:Label>

                                                </div>

                                            </div>
                      <%--//ReadOnly--%>
                      <hr />


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Loan Disbursement Amount</label>
                                                    <asp:TextBox runat="server" ID="DisbursementAmount" CssClass="form-control"></asp:TextBox>

                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Loan Disbursement Date</label>
                                                    <asp:TextBox runat="server" ID="DisbursementDate" CssClass="form-control Date"></asp:TextBox>

                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Bank Name</label>
                                                    <asp:TextBox runat="server" ID="BankName" CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Account Number</label>
                                                    <asp:TextBox runat="server" ID="AccountNumber" CssClass="form-control"></asp:TextBox>

                                                </div>

                                            </div>
                      </div>
                
              </div>
              <!-- /.tab-pane -->
              <div class="tab-pane" id="tab_3">
               <div class="row" style="padding-left:10px!important;padding-right:10px!important">
                                             
                   <%--readonly--%>

                   <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Pay Out</label>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 25%; border: 0px solid black!important">
                                                                <asp:Label runat="server" ID="PayoutpercentT"    placeholder="%" CssClass="form-control"  BackColor="WhiteSmoke"></asp:Label>
                                                            </td>
                                                            <td style="width: 75%; border: 0px solid black!important">
                                                                <asp:Label runat="server"   ID="PayoutpercentAmountT" placeholder="Pay Out Amt." CssClass="form-control"  BackColor="WhiteSmoke" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>GST Amt.</label>
                                                    <asp:Label runat="server" ID="GSTAmountT" CssClass="form-control"   BackColor="WhiteSmoke"></asp:Label>

                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>FinalAmout</label>
                                                    <asp:Label runat="server" ID="FinalAmoutT" CssClass="form-control"  BackColor="WhiteSmoke"></asp:Label>

                                                </div>

                                            </div>
                                             <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>DSE Payout</label>
                                                    <asp:Label runat="server" ID="DSEPayoutT" CssClass="form-control"  BackColor="WhiteSmoke"></asp:Label>

                                                </div>

                                            </div>
                   <%--readonly--%>





                    <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Payout Disbursement Amount </label>
                                                    <asp:TextBox runat="server" ID="DisbursementAmountPayout" oninput="CalcShortCalc()" CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>
                    <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Payout Disbursement Date </label>
                                                    <asp:TextBox runat="server" ID="DisbursementDatePayout"  CssClass="form-control Date"></asp:TextBox>

                                                </div>

                                            </div>
                    <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Payout BankName</label>
                                                    <asp:TextBox runat="server" ID="BankNamePayout"  CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>
                    <div class="col-md-3">
                                                <div class="form-group">
                                                    <label> Payout Account Number </label>
                                                    <asp:TextBox runat="server" ID="AccountNumberPayout"  CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>



                                               <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>TDS Amount.</label>
                                                    <asp:TextBox runat="server" ID="TDSAmount" oninput="CalcShortCalc()" CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>
                                               <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Short Credited.</label>
                                                    <asp:TextBox runat="server" ID="ShortCredited" oninput="CalcShortCalc()" CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>
                                         

  <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>PDD Charges.</label>
                                                    <asp:TextBox runat="server" ID="PDDCharges" CssClass="form-control " oninput="CalcShortCalc()"></asp:TextBox>

                                                </div>

                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Received Amt.</label>
                                                    <asp:TextBox runat="server" ID="ReceivedAmount" CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Credit Ref.</label>
                                                    <asp:TextBox runat="server" ID="CreditRef" CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>


                                            
                  
 <%-- <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>DO Attachment</label>
                                                    
                                                    <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control "></asp:TextBox>

                                                </div>

                                            </div>--%>





                                            <div class="col-md-6">
                                                <div class="form-group">
                                                  <asp:Label  runat="server" ID="RemarkLabel" Text="Remark"></asp:Label>
                                                        <asp:TextBox runat="server" ID="Remark" CssClass="form-control"></asp:TextBox>
                                                </div>

                                            </div>


                


                                        </div>
              </div>

                

              <!-- /.tab-pane -->
            </div>
                                        
            <!-- /.tab-content -->
          </div>

                                             <div class="col-md-12">
                                                 <center>
                                                            <div style="width:200px">
                                                                <table>
                                                                    <tr>
                                                                    <td>
                                                             <asp:Button runat="server" ID="savelocation" OnClientClick="return check()" CssClass="btn btn-primary" OnClick="savelocation_Click" Text="Submit" />
                                                                        </td>
                                                                    <td>
                                                             <a  onclick="FileShow()" class="btn btn-info"   > DO Attachment</a>
                                                                        </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                </center>
                       
                 </div>

</div>
                                        



                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </section>
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
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script>
        function CalcPayout() {
            var DoAmts = $("#<%=DoAmt.ClientID%>").val().length > 0 ? parseFloat($("#<%=DoAmt.ClientID%>").val()) : 0;
            var PfCharg = $("#<%=PfCharg.ClientID%>").val().length > 0 ? parseFloat($("#<%=PfCharg.ClientID%>").val()) : 0;
            var Payoutpercent = $("#<%=Payoutpercent.ClientID%>").val().length > 0 ? parseFloat($("#<%=Payoutpercent.ClientID%>").val()) : 0;
            var PayoutCharge = ((DoAmts - PfCharg) * Payoutpercent) / 100.00;
            $("#<%=PayoutpercentAmount.ClientID%>").val(PayoutCharge.toFixed(0))
            var PayoutChargeAmt = $("#<%=PayoutpercentAmount.ClientID%>").val().length > 0 ? parseFloat($("#<%=PayoutpercentAmount.ClientID%>").val()) : 0;
            $("#<%=GSTAmount.ClientID%>").val((((PayoutChargeAmt) * 18.00) / 100.00).toFixed(0))
            var GSTAmount = $("#<%=GSTAmount.ClientID%>").val().length > 0 ? parseFloat($("#<%=GSTAmount.ClientID%>").val()) : 0;
            $("#<%=FinalAmout.ClientID%>").val((PayoutChargeAmt + GSTAmount).toFixed(0))
            $("#<%=NetDoAmt.ClientID%>").html((DoAmts - PfCharg))


            $("#<%=PfChargT.ClientID%>").html($("#<%=PfCharg.ClientID%>").val());
            $("#<%=DoAmtT.ClientID%>").html($("#<%=DoAmt.ClientID%>").val());
            $("#<%=NetDoAmtT.ClientID%>").html($("#<%=NetDoAmt.ClientID%>").html());

            
        }


        function CalcPayoutAmount() {
            var DoAmts = $("#<%=DoAmt.ClientID%>").val().length > 0 ? parseFloat($("#<%=DoAmt.ClientID%>").val()) : 0;
            var PfCharg = $("#<%=PfCharg.ClientID%>").val().length > 0 ? parseFloat($("#<%=PfCharg.ClientID%>").val()) : 0;

            var PayoutChargeAmt = $("#<%=PayoutpercentAmount.ClientID%>").val().length > 0 ? parseFloat($("#<%=PayoutpercentAmount.ClientID%>").val()) : 0;
            $("#<%=GSTAmount.ClientID%>").val((((PayoutChargeAmt) * 18.00) / 100.00).toFixed(0))
            var GSTAmount = $("#<%=GSTAmount.ClientID%>").val().length > 0 ? parseFloat($("#<%=GSTAmount.ClientID%>").val()) : 0;
            $("#<%=FinalAmout.ClientID%>").val(( PayoutChargeAmt + GSTAmount).toFixed(0))

        }



        function CalcAmountGSTAmout() {
            var DoAmts = $("#<%=DoAmt.ClientID%>").val().length > 0 ? parseFloat($("#<%=DoAmt.ClientID%>").val()) : 0;
            var PfCharg = $("#<%=PfCharg.ClientID%>").val().length > 0 ? parseFloat($("#<%=PfCharg.ClientID%>").val()) : 0;

            var PayoutChargeAmt = $("#<%=PayoutpercentAmount.ClientID%>").val().length > 0 ? parseFloat($("#<%=PayoutpercentAmount.ClientID%>").val()) : 0;

            var GSTAmount = $("#<%=GSTAmount.ClientID%>").val().length > 0 ? parseFloat($("#<%=GSTAmount.ClientID%>").val()) : 0;
            $("#<%=FinalAmout.ClientID%>").val(( PayoutChargeAmt + GSTAmount).toFixed(0))

        }

        $(document).ready(function () {
            PayTypedata();
        });

        function PayTypedata() {
            var value = document.getElementById("<%=LoanType.ClientID%>").value;
          
            if (value != "In-House") {

                document.getElementById('<%=DoAmt.ClientID %>').value = "";
                document.getElementById('<%=PfCharg.ClientID %>').value = "";
                document.getElementById('<%=DoNo.ClientID %>').value = "";
                document.getElementById('<%=Payoutpercent.ClientID %>').value = "";
                document.getElementById('<%=PayoutpercentAmount.ClientID %>').value = "";
                document.getElementById('<%=GSTAmount.ClientID %>').value = "";
                document.getElementById('<%=FinalAmout.ClientID %>').value = "";

                document.getElementById('<%=DisbursementAmount.ClientID %>').value = "";
                document.getElementById('<%=DisbursementDate.ClientID %>').value = "";
                document.getElementById('<%=BankName.ClientID %>').value = "";
                document.getElementById('<%=AccountNumber.ClientID %>').value = "";
                document.getElementById('<%=ReceivedAmount.ClientID %>').value = "";

                document.getElementById('<%=DSEPayout.ClientID %>').value = "";
                document.getElementById('<%=TDSAmount.ClientID %>').value = "";
                document.getElementById('<%=ShortCredited.ClientID %>').value = "";

                document.getElementById('<%=DoDate.ClientID %>').value = "";
                
                document.getElementById('<%=PDDCharges.ClientID %>').value = "";

          

                document.getElementById('<%=DoAmt.ClientID %>').disabled = true;
                document.getElementById('<%=PfCharg.ClientID %>').disabled = true;
                document.getElementById('<%=DoNo.ClientID %>').disabled = true;
                document.getElementById('<%=Payoutpercent.ClientID %>').disabled = true;
                document.getElementById('<%=PayoutpercentAmount.ClientID %>').disabled = true;
                document.getElementById('<%=GSTAmount.ClientID %>').disabled = true;
                document.getElementById('<%=FinalAmout.ClientID %>').disabled = true;

                document.getElementById('<%=DisbursementAmount.ClientID %>').disabled = true;
                document.getElementById('<%=DisbursementDate.ClientID %>').disabled = true;
                document.getElementById('<%=BankName.ClientID %>').disabled = true;
                document.getElementById('<%=AccountNumber.ClientID %>').disabled = true;
                document.getElementById('<%=ReceivedAmount.ClientID %>').disabled = true;

                document.getElementById('<%=DSEPayout.ClientID %>').disabled = true;
                document.getElementById('<%=TDSAmount.ClientID %>').disabled = true;
                document.getElementById('<%=ShortCredited.ClientID %>').disabled = true;
                document.getElementById('<%=hypoBranch.ClientID %>').disabled = true;

                document.getElementById('<%=DoDate.ClientID %>').disabled = true;
                
                document.getElementById('<%=PDDCharges.ClientID %>').disabled = true;


                if (value != "Cash") {
                    document.getElementById('<%=Hypo.ClientID %>').value = "Select";
                    document.getElementById('<%=hypoBranch.ClientID %>').value = "";

                    document.getElementById('<%=hypoBranch.ClientID %>').disabled = false;
                }


            } 
            
            else {

                var DoAmts = $("#<%=DoAmt.ClientID%>").val().length > 0 ? parseFloat($("#<%=DoAmt.ClientID%>").val()) : 0;
                var PfCharg = $("#<%=PfCharg.ClientID%>").val().length > 0 ? parseFloat($("#<%=PfCharg.ClientID%>").val()) : 0;
                $("#<%=NetDoAmt.ClientID%>").html((DoAmts - PfCharg))
                $("#<%=NetDoAmtT.ClientID%>").html($("#<%=NetDoAmt.ClientID%>").html());

                document.getElementById('<%=DoAmt.ClientID %>').disabled = false;
                document.getElementById('<%=PfCharg.ClientID %>').disabled = false;
                document.getElementById('<%=DoNo.ClientID %>').disabled = false;
                document.getElementById('<%=Payoutpercent.ClientID %>').disabled = false;
                document.getElementById('<%=PayoutpercentAmount.ClientID %>').disabled = false;
                document.getElementById('<%=GSTAmount.ClientID %>').disabled = false;
                document.getElementById('<%=FinalAmout.ClientID %>').disabled = false;
                document.getElementById('<%=DisbursementAmount.ClientID %>').disabled = false;
                document.getElementById('<%=DisbursementDate.ClientID %>').disabled = false;
                document.getElementById('<%=BankName.ClientID %>').disabled = false;
                document.getElementById('<%=AccountNumber.ClientID %>').disabled = false;
                document.getElementById('<%=ReceivedAmount.ClientID %>').disabled = false;
                document.getElementById('<%=DSEPayout.ClientID %>').disabled = false;
                document.getElementById('<%=TDSAmount.ClientID %>').disabled = false;
                document.getElementById('<%=ShortCredited.ClientID %>').disabled = false;
                document.getElementById('<%=hypoBranch.ClientID %>').disabled = false;
                document.getElementById('<%=DoDate.ClientID %>').disabled = false;
                document.getElementById('<%=PDDCharges.ClientID %>').disabled = false;
            }



        }


        function CalcShortCalc() {
            var FinalAmout = $("#<%=FinalAmout.ClientID%>").val().length > 0 ? parseFloat($("#<%=FinalAmout.ClientID%>").val()) : 0;
            var DisbursementAmount = $("#<%=DisbursementAmountPayout.ClientID%>").val().length > 0 ? parseFloat($("#<%=DisbursementAmountPayout.ClientID%>").val()) : 0;
            var TDSAmount = $("#<%=TDSAmount.ClientID%>").val().length > 0 ? parseFloat($("#<%=TDSAmount.ClientID%>").val()) : 0;
            var ShortCredited = $("#<%=ShortCredited.ClientID%>").val().length > 0 ? parseFloat($("#<%=ShortCredited.ClientID%>").val()) : 0;
            var PDDCharges = $("#<%=PDDCharges.ClientID%>").val().length > 0 ? parseFloat($("#<%=PDDCharges.ClientID%>").val()) : 0;
            

            if (ShortCredited > 0) {
                $("#<%=RemarkLabel.ClientID%>").html("Remark* ")
            }
            else {

                $("#<%=RemarkLabel.ClientID%>").html("Remark")
            }
            $("#<%=ReceivedAmount.ClientID%>").val((DisbursementAmount - (  TDSAmount + ShortCredited + PDDCharges)).toString());

        }

        function CalculationActualRate(objs) {

            var ActualRate = $("#<%=ActualRate.ClientID%>").val().length > 0 ? parseFloat($("#<%=ActualRate.ClientID%>").val()) : 0;
            var payamout = (ActualRate / 1.18).toFixed(3);
            $("#<%=Payoutpercent.ClientID%>").val(payamout);
            
            CalcPayout();
        }

        function check() {
          
                if ((TDSAmount > 0 || ShortCredited > 0)) {
                    if ($("#<%=Remark.ClientID%>").val().length > 0) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return true;
                }
                
            
        }

        function DoNoIn() {
            $("#<%=DoNoT.ClientID%>").html(
                $("#<%=DoNo.ClientID%>").val());
        }
        function DoDateIn() {
            $("#<%=DoDateT.ClientID%>").html(
                $("#<%=DoDate.ClientID%>").val());
        }

        function ReCalculation(obj)
        {
            debugger;

            var FinalAmout = $("#<%=FinalAmout.ClientID%>").val().length > 0 ? parseFloat($("#<%=FinalAmout.ClientID%>").val()) : 0;
            var DoAmts = $("#<%=DoAmt.ClientID%>").val().length > 0 ? parseFloat($("#<%=DoAmt.ClientID%>").val()) : 0;
            var PfCharg = $("#<%=PfCharg.ClientID%>").val().length > 0 ? parseFloat($("#<%=PfCharg.ClientID%>").val()) : 0;


            var GSTAmt = FinalAmout - (FinalAmout / 1.18)
            var PAyAmount = (FinalAmout / 1.18);
            $("#<%=GSTAmount.ClientID%>").val(GSTAmt.toFixed(0));
            $("#<%=GSTAmountT.ClientID%>").html(GSTAmt.toFixed(0));

            $("#<%=PayoutpercentAmount.ClientID%>").val(PAyAmount.toFixed(0));
            $("#<%=PayoutpercentAmountT.ClientID%>").html(PAyAmount.toFixed(0));

            var percentPaymount = ((PAyAmount / (DoAmts - PfCharg))*100.00).toFixed(3);
            $("#<%=Payoutpercent.ClientID%>").val(percentPaymount.toString());
            $("#<%=PayoutpercentT.ClientID%>").html(percentPaymount.toString());

           // $("#<%=FinalAmout.ClientID%>").val((parseFloat($("#<%=PayoutpercentAmount.ClientID%>").val()) + parseFloat($("#<%=GSTAmount.ClientID%>").val())).toFixed(0));


        }

        function printinvoice(str) {
            var popup;
            debugger;
            var wird = parseInt(((screen.width * 72) / 100.00).toFixed(0));
            var left = (screen.width - wird) / 2; var top = (screen.height - 650) / 4;

            var popup = window.open("DiscountUpdate.aspx?ReciptId=" + str.toString() + "", "Print Receipt", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + wird + ', height=' + 650 + ', top=' + top + ', left=' + left);
            popup.focus();
        }

        function FileShow() {
            var popup;
            debugger;
            var wird = parseInt(((screen.width * 40) / 100.00).toFixed(0));
            var left = (screen.width - wird) / 2; var top = (screen.height - 500) / 4;
            var Url = "FinanaceDocument.aspx?ReciptId=" + GetParameterValues("ReceiptId");
            var popup = window.open(Url, "Finance Documents", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + wird + ', height=' + 500 + ', top=' + top + ', left=' + left);
            popup.focus();
        }


        function GetParameterValues(param) {
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < url.length; i++) {
                var urlparam = url[i].split('=');
                if (urlparam[0] == param) {
                    return urlparam[1];
                }
            }
        }
       

    </script>
</asp:Content>
