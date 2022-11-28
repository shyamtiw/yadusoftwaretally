<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="approvoucher.aspx.cs" Inherits="WebApp.admin.approvoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            //document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }
    </script>
    <style>
        .ui-autocomplete {
            cursor: pointer !important;
            overflow-y: scroll !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
    Approve  Voucher
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <SG:Message runat="server" ID="Message" />
            <div class="row">
                <div class="col-md-12">

                    <div class="box box-info">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-gift"></i>
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>

                            </div>
                        </div>
                        <div class="box-body">
                            <!-- BEGIN FORM-->

                            <div class="form-body">
                                <div class="form-horizontal" style="width: 98%">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">Vocuher Type</label>
                                                <div class="col-md-9">


                                                    <asp:DropDownList ID="CreatorVocuherType" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" Font-Bold="true" Font-Size="Smaller" InitialValue="Select" ControlToValidate="CreatorVocuherType" ValidationGroup="ok" runat="server" ErrorMessage="Please input"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">Select Branch</label>
                                                <div class="col-md-9">


                                                    <asp:DropDownList ID="CreatorInterBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" Font-Bold="true" Font-Size="Smaller" InitialValue="Select" ControlToValidate="CreatorInterBranch" ValidationGroup="ok" runat="server" ErrorMessage="Please input"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">Vocher No</label>
                                                <div class="col-md-9">
                                                    <asp:TextBox runat="server" ID="CreatorVocherNo" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" Font-Bold="true" Font-Size="Smaller" ControlToValidate="CreatorVocherNo" ValidationGroup="ok" runat="server" ErrorMessage="Please input"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">Vocher Date</label>
                                                <div class="col-md-9">
                                                    <asp:TextBox runat="server" ID="CreatorVocuherDate" CssClass="form-control Date"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" Font-Bold="true" Font-Size="Smaller" ControlToValidate="CreatorVocuherDate" ValidationGroup="ok" runat="server" ErrorMessage="Please input"></asp:RequiredFieldValidator>


                                                </div>
                                            </div>
                                        </div>




                                    </div>
                                    <div class="row">

                                        <asp:UpdatePanel runat="server" ID="sada">
                                            <ContentTemplate>

                                                <!-- /.box-header -->




                                                <div class="row">

                                                    <div class="col-md-12">
                                                        <div class="box box-success box-solid">
                                                            <div class="box-header with-border">
                                                                <h3 class="box-title">Voucher Ledger Enrty</h3>

                                                                <div class="box-tools pull-right">
                                                                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                                </div>
                                                                <!-- /.box-tools -->
                                                            </div>
                                                            <div class="box-body">
                                                                <div class="table-responsive">

                                                                    <table class="table" id="maintable" style="width: 100%">

                                                                        <thead>
                                                                            <tr>




                                                                                <th style="width: 55%">Ledger</th>
                                                                                <th style="width: 10%">DR</th>
                                                                                <th style="width: 10%">CR</th>

                                                                                <th style="width: 15%">Ref.Type</th>
                                                                                <th style="width: 10%">Ref.No</th>
                                                                                <th style="width: 10%">Ref.Amount</th>


                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <asp:Repeater runat="server" ID="loopitem" OnItemDataBound="loopitem_ItemDataBound">
                                                                                <ItemTemplate>
                                                                                    <tr>

                                                                                        <td>
                                                                                            <asp:TextBox list='<%# string.Format("dataLedger{0}", Container.ItemIndex )%>' runat="server" ID="Ledger" CssClass="form-control" Text='<%#Eval("Ledger") %>' oninput='<%# string.Format("filldata({0},this)", Container.ItemIndex )%>'></asp:TextBox>
                                                                                            <datalist id="<%# string.Format("dataLedger{0}", Container.ItemIndex )%>">
                                                                                            </datalist>


                                                                                        </td>


                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="DrAmt" CssClass="form-control dr" Text='<%#Eval("DrAmt") %>' oninput="RecalculateRepeater()"> </asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="CrAmt" CssClass="form-control cr" Text='<%#Eval("CrAmt") %>' oninput="RecalculateRepeater()"></asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:DropDownList runat="server" ID="RefrenceType" CssClass="form-control"></asp:DropDownList>
                                                                                            <asp:HiddenField runat="server" ID="RefrenceTypeid" Value='<%#Eval("RefrenceType") %>' />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="RefrenceNo" CssClass="form-control" Text='<%#Eval("RefrenceNo") %>'></asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="RefrenceAmount" CssClass="form-control" Text='<%#Eval("RefrenceAmount") %>'></asp:TextBox></td>

                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>

                                                                        </tbody>
                                                                    </table>
                                                                    <div>
                                                                        <table style="width: 100%">
                                                                            <tr>

                                                                                <td style="width: 80%">
                                                                                    <center> <asp:LinkButton runat="server" ID="addnew"  OnClick="addnew_Click"  class="btn btn-info savedata" >Add Rows</asp:LinkButton></center>
                                                                                </td>
                                                                                <td style="width: 20%">

                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>Approver Voucher Total</td>
                                                                                            <td>:</td>
                                                                                            <td><strong>
                                                                                                <asp:Label BackColor="WhiteSmoke" runat="server" ID="TotalAmount"></asp:Label></strong><br />
                                                                                                <div style="display: none">
                                                                                                    <asp:TextBox runat="server" ID="tbTotalAmount"></asp:TextBox>
                                                                                                </div>
                                                                                            </td>
                                                                                            </tr>
                                                                                        <tr>
                                                                                            <td>Creator Voucher Total</td>
                                                                                            <td>:</td>
                                                                                            <td><strong>
                                                                                                <asp:Label BackColor="WhiteSmoke" runat="server" ID="CreatorVoucherTotal"></asp:Label></strong></td>
                                                                                            </tr><tr>
                                                                                            <td>Diffrence</td>
                                                                                            <td>:</td>
                                                                                            <td><strong>
                                                                                                <asp:Label BackColor="WhiteSmoke" runat="server" ID="Diffrence"></asp:Label></strong></td>


                                                                                        </tr>
                                                                                    </table>


                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>


                                    </div>
                                    <!-- END FORM-->
                                </div>
                            </div>

                        </div>
                        <div class="box-footer">
                            <asp:Button runat="server" ID="savedata" class="btn btn-success" Text="Sumbit" OnClick="savedata_Click" ValidationGroup="ok" />
                        </div>
                    </div>

                </div>


            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
        <ProgressTemplate>
            <div style="z-index: 10001;" class="windowbackground">
                <div class="progressbar breadcrumb">
                    <img alt="Loading..." src="./img/ajax-loader.gif"><br>
                    Please Wait...
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
<asp:Content ID="Content2s" ContentPlaceHolderID="Script" runat="server">



    <script type="text/javascript">
        $(document).ready(function () {
            var TotalAmount = document.getElementById('<%=tbTotalAmount.ClientID %>').value.length > 0 ? parseFloat(document.getElementById('<%=tbTotalAmount .ClientID %>').value) : 0;
            var CreatorVoucherTotal = document.getElementById('<%=CreatorVoucherTotal .ClientID %>').innerHTML.length > 0 ? parseFloat(document.getElementById('<%=CreatorVoucherTotal .ClientID %>').innerHTML) : 0;
            document.getElementById('<%=Diffrence.ClientID %>').innerHTML = (CreatorVoucherTotal - TotalAmount).toString();
        });

        function RecalculateRepeater() {
            //Total SPAN in DOM    
            debugger;
            var dritem = document.getElementsByClassName('dr');
            var l = dritem.length;
            var sumdr = 0;
            //Iteration of SPAN in DOM    
            for (var i = 0; i < l; i++) {

                sumdr += Number(dritem[i].value);

            }
            //Cr Total

            var Critem = document.getElementsByClassName('cr');
            var l = Critem.length;
            var sumcr = 0;
            //Iteration of SPAN in DOM    
            for (var i = 0; i < l; i++) {

                /*do stuff to current spans[i] here*/
                sumcr += Number(Critem[i].value);

            }

            document.getElementById('<%=tbTotalAmount.ClientID %>').value = (sumdr - sumcr).toString();
            document.getElementById('<%=TotalAmount .ClientID %>').innerHTML = (sumdr - sumcr).toString();

            var TotalAmount = document.getElementById('<%=tbTotalAmount.ClientID %>').value.length > 0 ? parseFloat(document.getElementById('<%=tbTotalAmount .ClientID %>').value) : 0;
            var CreatorVoucherTotal = document.getElementById('<%=CreatorVoucherTotal .ClientID %>').innerHTML.length > 0 ? parseFloat(document.getElementById('<%=CreatorVoucherTotal .ClientID %>').innerHTML) : 0;
            document.getElementById('<%=Diffrence.ClientID %>').innerHTML = (CreatorVoucherTotal - TotalAmount).toString();

        }
        function filldata(index, obj) {

            var ur = "dataLedger" + index;
            debugger;


            $.ajax({
                url: "../SearchLeadger.asmx/GetCountryNames",
                method: "post",
                contentType: "application/json;charset=utf-8",
                data: '{"term": "' + obj.value + '"}',

                dataType: 'json',
                success: function (data) {
                    debugger;
                    var responcedata = data.d;

                    var list = document.getElementById(ur);

                    list.innerHTML = '';


                    responcedata.forEach(function (item) {

                        var option = document.createElement('option');
                        option.value = item;
                        list.appendChild(option);
                    });


                },
                error: function (err) {

                }
            });

            //$(ur).autocomplete({
            //    source: function (request, responce) {
            //        $.ajax({
            //            url: "../SearchLeadger.asmx/GetCountryNames",
            //            method: "post",
            //            contentType: "application/json;charset=utf-8",
            //            data: JSON.stringify({ term: request.term }),
            //            dataType: 'json',
            //            success: function (data) {
            //                responce(data.d);
            //            },
            //            error: function (err) {

            //            }
            //        });
            //    }
            //});



        }

    </script>

</asp:Content>
