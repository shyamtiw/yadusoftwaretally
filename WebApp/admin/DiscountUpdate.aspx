<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="DiscountUpdate.aspx.cs" Inherits="WebApp.admin.DiscountUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t01 th, td {
            border: 1px solid black;
            border: 1px solid black;
            border-collapse: collapse;
            padding: 2px 2px 2px 2px !important;
            font-size: 13px;
        }

        .t02 th {
            background-color: #3c8dbc;
            color: white;
        }

        .t03 tr {
            height: 20px !important
        }

        .inputcs {
            height: 24px !important;
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
                                    <!-- general form elements disabled -->
                                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                                            <h4 class="box-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Update Discount
                                                </a>
                                            </h4>
                                        </div>
                                        <div class="row" style="padding: 10px 10px 10px 10px;">



                                            <div class="col-md-12">
                                                <div class="form-group">

                                                    <%--  <div class="t01 t02">--%>
                                                    <table>
                                                        <tr>
                                                            <td>

                                                                <table class="t02 t01 table table-hover t03">
                                                                    <thead>
                                                                        <tr>

                                                                            <th>Head</th>
                                                                            <th style="width: 60px; padding: 2px 3px 2px 2px;">As per MSIL</th>
                                                                            <th style="width: 60px; padding: 2px 3px 2px 2px;">Offer Value</th>
                                                                            <th style="width: 60px; padding: 2px 3px 2px 2px;">Difference</th>
                                                                            <th style="width: 60px; padding: 2px 3px 2px 2px;">Before Tax</th>
                                                                            <th style="width: 60px; padding: 2px 3px 2px 2px;">MSIL Share</th>
                                                                            <th style="width: 60px; padding: 2px 3px 2px 2px;">Deal. Share</th>
                                                                            <th style="width: 100px; padding: 2px 3px 2px 2px;">Scheme Details</th>
                                                                            <th style="width: 70px; padding: 2px 3px 2px 2px;">Valid From</th>
                                                                            <th style="width: 70px; padding: 2px 3px 2px 2px;">Valid Upto</th>
                                                                            <th style="width: 70px; padding: 2px 3px 2px 2px;">MI Due Date</th>
                                                                            <th style="width: 100px; padding: 2px 3px 2px 2px;">Remarks</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <asp:Repeater runat="server" ID="MSCLRepiter">
                                                                            <ItemTemplate>



                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:HiddenField runat="server" ID="AutoId" Value='<%# Eval("AutoId") %>'></asp:HiddenField>
                                                                                        <asp:HiddenField runat="server" ID="HiddenField1" Value='<%# Eval("Calc") %>'></asp:HiddenField>
                                                                                        <asp:HiddenField runat="server" ID="FinanceId" Value='<%# Eval("FinanceId") %>'></asp:HiddenField>
                                                                                        <asp:Label runat="server" ID="Head" Text='<%# Eval("Head") %>'></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="AsperMSIL" CssClass="form-control inputcs" Text='<%# Eval("AsperMSIL") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="OfferValue" oninput='<%#  string.Concat("calculateChangeOffer(this,", Eval("Calc"),")") %>' CssClass="form-control inputcs" Text='<%# Eval("OfferValue") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="Difference" CssClass="form-control inputcs" Text='<%# Eval("Difference") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="BeforeTax" CssClass="form-control inputcs" Text='<%# Eval("BeforeTax") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="MSILShare" CssClass="form-control inputcs" Text='<%# Eval("MSILShare") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="DealerShare" CssClass="form-control inputcs" Text='<%# Eval("DealerShare") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="SchemeDetails" CssClass="form-control inputcs" Text='<%# Eval("SchemeDetails") %>' Style="width: 100px; padding: 2px 3px 2px 2px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="ValidFrom" CssClass="form-control inputcs Date" Text='<%# Eval("ValidFrom") %>' Style="width: 70px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="ValidUpto" CssClass="form-control inputcs Date" Text='<%# Eval("ValidUpto") %>' Style="width: 70px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="MIDueDate" CssClass="form-control inputcs Date" Text='<%# Eval("MIDueDate") %>' Style="width: 70px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="Remarks" Text='<%# Eval("Remarks") %>' CssClass="form-control inputcs" Style="width: 100px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:HiddenField runat="server" ID="BreackuphideData" />
                                                                <center><h4> Offer Breackup:<asp:Label runat="server" ForeColor="Red" ID="Breackup"></asp:Label> </h4></center>
                                                            </td>
                                                            <tr>
                                                                <td>

                                                                    <table class="t02 t01 table table-hover t03">

                                                                        <tbody>
                                                                            <asp:Repeater runat="server" ID="RipRepiter">
                                                                                <ItemTemplate>



                                                                                    <tr>
                                                                                        <td>

                                                                                            
                                                                                            
                                                                                            <asp:HiddenField runat="server" ID="LOC_CD" Value='<%# Eval("LOC_CD") %>'></asp:HiddenField>
                                                                                            <asp:HiddenField runat="server" ID="TRANS_ID" Value='<%# Eval("TRANS_ID") %>'></asp:HiddenField>
                                                                                            <asp:HiddenField runat="server" ID="utd" Value='<%# Eval("utd") %>'></asp:HiddenField>
                                                                                            

                                                                                            <asp:HiddenField runat="server" ID="AutoId" Value='<%# Eval("AutoId") %>'></asp:HiddenField>
                                                                                            <asp:HiddenField runat="server" ID="Calc" Value='<%# Eval("Calc") %>'></asp:HiddenField>
                                                                                            <asp:HiddenField runat="server" ID="FinanceId" Value='<%# Eval("FinanceId") %>'></asp:HiddenField>
                                                                                            <asp:Label runat="server" ID="Head" Text='<%# Eval("Head") %>'></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="AsperMSIL" CssClass="form-control inputcs" Text='<%# Eval("AsperMSIL") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="OfferValue" oninput='<%#  string.Concat("calculate(this,", Eval("Calc"),")") %>' CssClass="form-control inputcs Rips" Text='<%# Eval("OfferValue") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="Difference" CssClass="form-control inputcs" Text='<%# Eval("Difference") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="BeforeTax" CssClass="form-control inputcs" Text='<%# Eval("BeforeTax") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="MSILShare" CssClass="form-control inputcs" Text='<%# Eval("MSILShare") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="DealerShare" CssClass="form-control inputcs" Text='<%# Eval("DealerShare") %>' Style="width: 60px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="SchemeDetails" CssClass="form-control inputcs" Text='<%# Eval("SchemeDetails") %>' Style="width: 100px; padding: 2px 3px 2px 2px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="ValidFrom" CssClass="form-control inputcs Date" Text='<%# Eval("ValidFrom") %>' Style="width: 70px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="ValidUpto" CssClass="form-control inputcs Date" Text='<%# Eval("ValidUpto") %>' Style="width: 70px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="MIDueDate" CssClass="form-control inputcs Date" Text='<%# Eval("MIDueDate") %>' Style="width: 70px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="Remarks" Text='<%# Eval("Remarks") %>' CssClass="form-control inputcs" Style="width: 100px; padding: 0px 0px 0px 0px;"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>

                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </tbody>
                                                                    </table>


                                                                </td>
                                                            </tr>

                                                        <tr>
                                                            <td>
                                                                <center>

                                                                     <div style="width:200px">
                                                                <table>
                                                                    <tr>
                                                                    <td>
                                                              <asp:Button runat="server" CssClass="btn btn-block btn-primary btn-flat" ID="sendemail" Text="Submit" OnClick="sendemail_Click"></asp:Button>
                                                                        </td>
                                                                    <td>
                                                             <a  onclick="FileShow()" class="btn btn-info"   >Approval Attachment</a>
                                                                        </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>

                                                            
                                                                </center>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <%--//</div>--%>
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
        function calculateChangeOffer(objdata, LocationId) {
            debugger;
            if (LocationId == 2) {
                $("#<%=Breackup.ClientID%>").html(objdata.value)

                var els = document.getElementsByClassName("Rips");
                $("#<%=BreackuphideData.ClientID%>").val(objdata.value);
                for (var i = 0; i < els.length; i++) {


                    els[i].value = "0";
                }

            }
        }

        function calculate(objdata, LocationId) {
            var Breackup = $("#<%=Breackup.ClientID%>").html().length > 0 ? parseFloat($("#<%=Breackup.ClientID%>").html()) : 0;
            var BreackuprealTimeData = $("#<%=BreackuphideData.ClientID%>").val().length > 0 ? parseFloat($("#<%=BreackuphideData.ClientID%>").val()) : 0;

            var els = document.getElementsByClassName("Rips");
            var SumElement = 0;
            for (var i = 0; i < els.length; i++) {


                SumElement = SumElement + (els[i].value.length > 0 ? parseFloat(els[i].value) : 0);
            }

            if (SumElement <= BreackuprealTimeData) {
                $("#<%=Breackup.ClientID%>").html(
                    (BreackuprealTimeData - SumElement).toString())
            }
            else {


                objdata.value = "0";
                var elss = document.getElementsByClassName("Rips");
                var SumElements = 0;
                for (var i = 0; i < elss.length; i++) {
                    SumElements = SumElements + (elss[i].value.length > 0 ? parseFloat(elss[i].value) : 0);
                }
                //SumElements = SumElements + (objdata.value.length > 0 ? parseFloat(objdata.value) : 0);

                $("#<%=Breackup.ClientID%>").html(
                    (BreackuprealTimeData - SumElements).toString())

                alert("Breakup Cannot More than Consumer offer");
            }
        }

        function FileShow() {
            var popup;
            debugger;
            var wird = parseInt(((screen.width * 40) / 100.00).toFixed(0));
            var left = (screen.width - wird) / 2; var top = (screen.height - 500) / 4;
            var Url = "DiscountDocuments.aspx?ReciptId=" + GetParameterValues("ReciptId");
            var popup = window.open(Url, "Discount Documents", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + wird + ', height=' + 500 + ', top=' + top + ', left=' + left);
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
