<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printinvoice.aspx.cs" Inherits="WebApp.admin.print.printinvoice" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>eInvoice</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <!-- css files -->

    <link href="css/common_style.css" rel="stylesheet">
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/font-awesome/css/all.css" rel="stylesheet">
    <style>
        .homeprofileiconul {
            flex-direction: row;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
    
    <form  class="InvoiceNumberform" runat="server" id="dsadsa">
        
  
        <div>
            <div class="form-row">
                <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12 printheading">
                    <h4 class="formtitle">
                        e-Invoice Print
                    </h4>
                </div>
               
            </div>
            <div class="divError">

            </div>
            <div class="divInvoiceNumber justify-content-center align-items-center" id="divInvoiceNumber" style="display: none;">
                <div class="divmodeofPrint col-sm-12 col-md-12 col-lg-12 col-xl-12 col-12 text-center mt-2 mb-2 font-weight-bold">
                    <label class="mr-3"> Based On :</label>
                    <input type="radio" class="PrintOption" name="PrintOption" value="ACK">  Ack No. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="radio" class="PrintOption" name="PrintOption"  value="IRN">  IRN
                </div>
                <div class="divAckNo justify-content-center align-items-center form-inline" style="display: none;">
                    <label class="mr-1 font-weight-bolder"> Enter Ack. No. :</label>
                    <input type="text" class="txtinvoiceNumber invoicenumberfield form-control" id="txtinvoiceNumber" maxlength="20" onkeypress="return isNumberKey(event)" name="InvoiceView.InvoiceDetails.EInvNo" value="172110134088842">
                    <button class="btngo btn btn-primary ml-2 mr-2" id="btngo" name="submit" value="Print">Go</button>
                    <a class="btn btn-danger" href="/Home/MainMenu"> Exit</a>
                </div>
                <div class="divIRN justify-content-center align-items-center form-inline" style="display: none;">
                    <label class="mr-1 font-weight-bolder"> Enter IRN. :</label>
                    <input type="text" class="txtinvoiceNumber form-control" id="IRNtxtinvoiceNumber" maxlength="66" name="InvoiceView.InvoiceDetails.Irn" value="63186bdb23f2a41796ed0d79e139aa1c0cd1b143bf4fc63cebd184114cf2383b">
                    <button class="btngo btn btn-primary ml-2 mr-2" id="btngo" name="submit" value="Print">Go</button>
                    <a class="btn btn-danger" href="/Home/MainMenu"> Exit</a>
                </div>
            </div>

            <div id="divInvoicePrint" class="divInvoicePrint" style="display: flex;">
            


<div class="container-fluid maindivprint">
    <div class="printdetailsdiv">
        <div class="ScrollDivPrint">
                <div class="divHeading form-row mb-1">
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-8 col-8 p-1 mt-xl-3 mt-lg-3 mt-md-3 mt-sm-3">
                        <h3 class="govtofindiatxt font-weight-bold mt-xl-5 mt-lg-5 mt-md-5 mt-sm-4 pt-3"><span><asp:Literal runat="server" ID="compnaynameGst"></asp:Literal></span></h3>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-4 col-4 text-right p-1">
                        <div id="plBarCodeNew"><asp:Literal runat="server" ID="RQIMG"></asp:Literal></div>
                    </div>
                </div>
            <input type="hidden" id="hdnEwbErrorMsg" name="InfoDtlsErrorMessage" value="">
            <div class="card">
                <div class="card-header">
                    <strong>1.e-Invoice Details</strong>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-xl-4 col-lg-5 col-md-4 col-sm-4 p-1">
                            <label class="mt-2 mr-1" style="float:left;"><strong>IRN :</strong></label><div class="text-wrap"><asp:Literal runat="server" ID="IRN"></asp:Literal></div>
                        </div>
                        <div class="col-xl-4 col-lg-3 col-md-4 col-sm-4 mt-2 p-1">
                            <label class="font-weight-bold ml-xl-5 pl-xl-4"><span class="mr-xl-5 pr-xl-3">Ack. No  </span> <span class="mr-2">:</span></label> <asp:Literal runat="server" ID="AckNo"></asp:Literal>
                        </div>
                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 mt-2 p-1">
                            <label class="font-weight-bold ml-xl-4 pl-xl-3"><span class="mr-xl-1 pr-xl-5 mr-lg-3 pr-lg-4">Ack. Date</span><span class="mr-2"> :</span> </label> <asp:Literal runat="server" ID="AckDt"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header">
                    <strong>2.Transaction Details</strong>
                </div>
                <div class="card-body">
                    <div class="row mb-2">
                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 p-1">
                            <input type="hidden" value="N">
                                <label class="font-weight-bold"><span class="mr-xl-5 pr-xl-3">Category </span><span class="mr-2">: </span></label> <asp:Literal runat="server" ID="SupplyTypeCode"></asp:Literal>
                        </div>
                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 p-1">
                            <label class="ml-xl-5 pl-xl-3 ml-lg-4 pl-lg-5 font-weight-bold"><span class="mr-xl-2 pr-xl-3">Document No</span> <span class="mr-2">:</span></label>  <asp:Literal runat="server" ID="DocumentNo"></asp:Literal>
                        </div>
                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 p-1">
                                <div class="IgstOnIntra">
                                        <label class="ml-xl-4 pl-xl-2 font-weight-bold"><span class="mr-xl-3">IGST on INTRA</span><span class="mr-xl-2"> : </span><span><asp:Literal runat="server" ID="IGSTIntra"></asp:Literal></span></label>
                                </div>

                        </div>
                    </div>
                    <hr class="mt-1 mb-1">
                    <div class="row mb-2">
                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 p-1">
                            <input type="hidden" value="INV">
                            <label class="font-weight-bold"><span class="mr-xl-2 pr-xl-1">Document Type </span><span class="mr-2">:</span> </label> <asp:Literal runat="server" ID="DocumentType"></asp:Literal>
                        </div>

                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 p-1">
                            <label class="font-weight-bold ml-xl-3 pl-xl-5 ml-lg-4 pl-lg-5"><span class="pr-xl-2"> Document Date </span><span class="mr-2">: </span></label> <asp:Literal runat="server" ID="DocumentDate"></asp:Literal>
                        </div>

                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 p-1">

                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header">
                    <strong>3.Party Details </strong>
                </div>
                <div class="card-body">

                    <div class="row mb-0">
                            <div class="DivBfrom col-sm-6 border-right p-1">
                                <h6 class="mb-0"><strong>Seller </strong></h6>

                                <p><label for="SellerDtls.Gstin">GSTIN : </label> <asp:Literal runat="server" ID="SellerGSTNNO"></asp:Literal></p>
                                <p>
                                    <asp:Literal runat="server" ID="SelllerCompanyName"></asp:Literal> <br>
                                    <asp:Literal runat="server" ID="SellerAddress"></asp:Literal>
                                    
                                    
                                </p>
                            </div>
                            <div class="divBto col-sm-6 p-1">
                                <h6 class="mb-0"><strong>Purchaser </strong></h6>
                                <p><label>GSTIN :</label> <asp:Literal runat="server" ID="BuyerGSTN"></asp:Literal> </p>
                                <p>
                                    <asp:Literal runat="server" ID="BuyerLegalName"></asp:Literal> <br>
                                    <asp:Literal runat="server" ID="BuyerAddr1"></asp:Literal>
                            </div>
                    </div>
                    <div class="divDisShip row mb-0">
                            <div class="divDis col-sm-6 border-right p-1">
                                <h6 class="mb-0"><strong>Dispatcher </strong></h6>
                                <p>
                                    <asp:Literal runat="server" ID="SelllerCompanyName2"></asp:Literal> <br>
                                    <asp:Literal runat="server" ID="SellerAddress2"></asp:Literal>
                                    
                                </p>
                            </div>
                            <div class="divShip col-sm-6 p-1">
                                <h6 class="mb-0"><strong>Shipping </strong></h6>
                                <p><label for="SellerDtls.Gstin">GSTIN : </label> <asp:Literal runat="server" ID="BuyerGSTN2"></asp:Literal></p>
                                <p>
                                     <asp:Literal runat="server" ID="BuyerLegalName2"></asp:Literal> <br>
                                 <asp:Literal runat="server" ID="BuyerAddr2"></asp:Literal>
                                </p>
                            </div>
                    </div>

                </div>
            </div>

            <div class="card">
                <div class="card-header">
                    <strong>4.Goods Details</strong>
                </div>
                <div class="card-body">

                    <div class="row mb-0 mt-0">
                        <div class="col-xl-12 table-responsive p-1">
                                    <table class="table table-striped table-bordered table-responsive-sm" id="tblItems">
                                        <thead>
                                            <tr>
                                                <th scope="col">SlNo</th>
                                                <th scope="col">Product Description</th>
                                                <th scope="col">HSN Code</th>
                                                <th scope="col">Quantity</th>
                                                <th scope="col">Unit</th>
                                                <th scope="col">
                                                    Unit  Price(Rs)
                                                </th>
                                                <th>
                                                    Discount(Rs)
                                                </th>
                                                <th scope="col">
                                                    Taxable <br>
                                                    Amount(Rs)
                                                </th>
                                                <th scope="col">
                                                    Tax Rate (GST+Cess|<br>
                                                    State Cess+Cess Non.Advol)
                                                </th>
                                                <th>
                                                    Other<br>
                                                    charges(Rs)
                                                </th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server"  ID="rptItems">
                                                <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("SlNo")  %></td>
                                                    <td> <%# Eval("PrdDesc")  %></td>
                                                    <td> <%# Eval("HsnCd")  %> </td>
                                                    <td> <%# Eval("Qty")  %>  </td>
                                                    <td>  <%# Eval("Unit")  %>  </td>
                                                    <td class="text-right">  <%# Eval("UnitPrice")  %></td>
                                                    <td class="text-right"> <%# Eval("Discount")  %> </td>
                                                    <td class="text-right"><%# Eval("AssAmt")  %> </td>
                                                    <td class="text-right">
                                                        <%# Eval("GstRt")  %> +0.00|<br>
                                                        0.00+0
                                                    </td>
                                                    <td class="text-right"> <%# Eval("OthChrg")  %></td>
                                                    <td class="text-right"><%# Eval("TotItemVal")  %></td>
                                                </tr>
                                            </ItemTemplate>
                                           </asp:Repeater>
                                        </tbody>
                                    </table>
                        </div>
                    </div>

                    <div class="row mb-0 mt-0">
                        <div class="col-xl-12 table-responsive p-1">
                            <table border="0" class="table table-striped  table-bordered">
                                <tbody><tr>
                                    <th><label for="ValDtls.AssVal"> Tax'ble Amt </label>  </th>
                                    <th><label for="ValDtls.CgstVal"> CGST <br>Amt </label> </th>
                                    <th><label for="ValDtls.SgstVal"> SGST <br>Amt  </label></th>
                                    <th> <label for="ValDtls.IgstVal">IGST <br>Amt  </label> </th>
                                    <th><label for="ValDtls.CesVal"> CESS <br>Amt </label></th>
                                    <th><label for="ValDtls.StCesVal"> State CESS <br>Amt </label></th>
                                    <th><label> Discount </label> </th>
                                    <th><label> Other<br> Charges </label> </th>
                                    <th><label for="ValDtls.RndOffAmt"> Round off <br>Amt </label></th>
                                    <th><label for="ValDtls.TotInvVal">Total Inv.<br> Amt </label></th>
                                </tr>
                                <tr>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="TotalTaxableValue"></asp:Literal> </td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="CGSTAmt1"></asp:Literal></td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="SGSTAmt1"></asp:Literal></td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="IGSTAmt1"></asp:Literal></td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="CessAmount"></asp:Literal></td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="StateCessAmount"></asp:Literal></td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="Discount1"></asp:Literal></td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="OtherCharges1"></asp:Literal> </td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="RoundOff"></asp:Literal></td>
                                    <td style="text-align:right"><asp:Literal runat="server" ID="TotalInvoiceValue"></asp:Literal></td>
                                </tr>
                            </tbody></table>
                        </div>

                    </div>


                </div>
            </div>

            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-8 col-lg-6 col-xl-6 col-12 col-md-5 p-1">
                            <div class="form-inline">
                                <label for="SellerDtls.Gstin" class="font-weight-bold"><span class="pr-xl-1 pr-lg-1 pr-md-2 pr-sm-1">Generated By</span> <span class="mr-2">: </span></label>
                                <asp:Literal runat="server" ID="commstgst2"></asp:Literal>
                            </div>
                            <div class="form-inline" id="DivPrint"><label class=" font-weight-bold"><span class="mr-xl-3 pr-xl-3 mr-lg-3 pr-lg-3 mr-md-1 pr-md-1 mr-sm-3 pr-sm-3">Print Date</span> <span class="mr-2">:</span></label>   <asp:Literal runat="server" ID="printdate"></asp:Literal></div>
                        </div>

                        <div class="DivBarCode col-sm-4 col-lg-2 col-xl-2 col-12 col-md-3 p-1">
                           
                        </div>
                                <div class="col-sm-12 col-lg-4 col-xl-4 col-12 col-md-4 text-right p-1">
                                    <img src="img/e-sign.png" class="mr-5">
                                    <div>
                                        Digitally Signed by NIC-IRP <br> on:
                                        <span style="text-decoration:underline;">
                                            <asp:Literal runat="server" ID="AckDt2"></asp:Literal>
                                        </span>
                                    </div>
                                </div>
                    </div>
                </div>
            </div>
                    <div class="divConfirm form-row" style="display: none;">
                        <div class="col-sm-12 col-lg-12 col-lg-12 col-xs-12 text-sm-right p-1">
                            <button type="submit" name="submit" class="btn btn-primary" value="Save">Confirm</button>
                            <button class="btnBack btn btn-danger" id="btnBack">Back</button>
                        </div>
                    </div>
        </div>
    </div>
    <br>
    <br>
            <div class="divPrintBtn form-row printpagebtns text-right">
                    <div class="col-sm-12 col-lg-6 col-xl-6 col-12 col-md-12 form-inline ml-auto p-1">
                        <button class="btnPrint btn btn-info btnprintview mr-2" onclick="window.print(); return false;" id="btnPrint">Print <i class="fa fa-print"></i></button>
                               
                    </div>

                <br>
                <br>
            </div>
    <br>
</div>


            </div>
            <br>
            <div class="container-fluid divCancelReason" id="divCancelReason" style="display: none;">
                <div class="row justify-content-center align-items-center">
                    <div class="col-12 col-xl-6 col-sm-8 col-md-8 col-lg-6">
                        <div class="card divcancelcard">
                            <div class="card-body mt-3 mb-2">
                                <div class="form-row">
                                    <div class="col-sm-4 col-lg-4 col-xl-4 col-md-4 col-xs-12">
                                        <label class="mt-2"><strong>Cancel Reason :</strong></label>
                                    </div>
                                    <div class="col-sm-8 col-lg-8 col-xl-8 col-md-8 col-xs-12">
                                        <select id="selBToStcd" class="form-control input-validation-error" data-val="true" data-val-regex="The field Cancel Reason must match the regular expression '([1-4]{1})?'." data-val-regex-pattern="([1-4]{1})?" data-val-required="The Cancel Reason field is required." name="InvoiceCancelDetails.CnlRsn"></select>
                                        <span class="text-danger field-validation-error" data-valmsg-for="InvoiceCancelDetails.CnlRsn" data-valmsg-replace="true">The Cancel Reason field is required.</span>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-sm-4 col-lg-4 col-xl-4 col-md-4 col-xs-12">
                                        <label class="mt-2"><strong>Remarks :</strong></label>
                                    </div>
                                    <div class="col-sm-8 col-lg-8 col-xl-8 col-md-8 col-xs-12">
                                        <textarea class="form-control txtCnlRemarak input-validation-error" data-val="true" data-val-required="The Cancel Remark field is required." id="InvoiceCancelDetails_CnlRem" name="InvoiceCancelDetails.CnlRem"></textarea>
                                    </div>
                                </div>
                                <br>
                                <div class="form-row">
                                    <div class="col-sm-12 col-lg-12 col-xl-12 col-xs-12 text-center">
                                        <button class="btn btn-primary" name="submit" value="Cancel" id="btnSubmit">Submit</button>
                                        <a class="btn btn-danger" href="/Home/MainMenu"> Exit</a>
                                    </div>
                                </div>
                            </div>
                        </div><br><br><br>
                    </div>
                </div>
            </div>
        </div>
    <input name="__RequestVerificationToken" type="hidden" value="CfDJ8CcB8UXa_RBHgrn_8bB29nkj9ybToRJga31bO8ptEwxZ7DR_wKh6PYPfT3TWrL9uqiMl8hdhiS3dFFF2Gs2jsVQ3B710UgBZCHR3fjIIJkUJWr8g5--Bk1fHdzPyuzNaQ92q3FVD-TjriF7dGw0KZZRYXy4zzXQRlGgym-gCpmYE2UbaflNwbTnXLdukGkee6Q"></form>


        <script src="js/jquery.js"></script>
    <script src="js/bootstrap.js"></script>

    

    <link href="css/eInvoicePrint.css" rel="stylesheet">
    <script src="js/ValidateInvoice.js"></script>
    <link href="css/Print.css" rel="stylesheet" media="print">
    <script src="js/jqueryui/jquery-ui.js"></script>
    <script src="js/qrcode.js"></script>
    <script src="js/jquery-barcode.min.js"></script>
    <link href="js/jqueryui/jquery-ui.css" rel="stylesheet">

</div>
</body>
</html>
