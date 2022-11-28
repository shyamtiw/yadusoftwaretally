<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="CouponStatusSpecificCustomer.aspx.cs" Inherits="WebApp.admin.CouponStatusSpecificCustomer" %>

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
    <SG:Message ID="MessageBox" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>

            <div class="content-wrapper" style="background-color: white;">
                <!-- Content Header (Page header) -->

                <section class="content-header">
                    <h1>Coupon Status
                    </h1>
                    <ol class="breadcrumb">

                        <li><a href="#">Home<i class="fa fa-dashboard"></i></a></li>





                    </ol>
                </section>

                <section class="content">




                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <!-- general form elements disabled -->
                                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                                            <h4 class="box-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Coupon Status
                      </a>
                                            </h4>
                                        </div>



                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gvlocation" runat="server" CssClass="t01 t02" AutoGenerateColumns="false" Width="98%" align="center">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Code">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Code")%>
                                                                        <asp:HiddenField runat="server" ID="EmailId" Value='<%# Eval("EmailId")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mobile No.">
                                                                    <ItemTemplate>
                                                                        <%# Eval("MobNo")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Coupon">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Master")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Issue Status">
                                                                    <ItemTemplate>
                                                                        Issue By: <%# Eval("CreatedBy")%><br />
                                                                        Date: <%# Convert.ToDateTime( Eval("IssueDate")).ToString("dd/MM/yyyy")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Approve Status">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApproveStatus")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Redeem Status">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Redeem")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Status">
                                                                    <ItemTemplate>

                                                                        <%# Convert.ToBoolean( Eval("IsApprove"))==false?Convert.ToBoolean( Eval("IsReject"))?"<span style='color:red'>Reject</span>":"<span class='lable' style='color:yellow'>Pending</span>":(WebApp.LIBS.Common.ConvertBool( Eval("IsRedeem"))?"<span class='lable' style='color:red'>Redeem</span>": Eval("InsuranceCouponId","<a class='label label-danger' onclick='showmodaldata({0},"+Eval("MobNo","\"{0}\"")+","+ (Container.DataItemIndex + 1)+")'>Redeem Now</a>")) %>
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
                    </div>
                </section>
            </div>









            <div id="stack1" class="modal fade" tabindex="-1" data-width="400">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                            <h5 class="modal-title">Redeem Form</h5>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">

                                    <div class="portlet box green">

                                        <div class="portlet-body form">
                                            <!-- BEGIN FORM-->

                                            <div class="form-body">
                                                <div class="form-horizontal" style="width: 98%">
                                                    <div class="row">

                                                        <div class="col-md-12">

                                                            <div class="form-group">
                                                                <label class="control-label col-md-3">OTP</label>
                                                                <div class="col-md-9">


                                                                    <input type="text" id="OTPFrom" class="form-control" />

                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-12">

                                                            <div class="form-group">
                                                                <label class="control-label col-md-3">Invoice No</label>
                                                                <div class="col-md-9">
                                                                    <input type="hidden" id="InsuranceCouponId" />
                                                                    <input type="hidden" id="MobNo" />

                                                                    <input type="hidden" id="index" />
                                                                    <input type="text" id="InvoiceNo" class="form-control" />


                                                                </div>
                                                            </div>

                                                        </div>



                                                    </div>


                                                    <div class="box-footer pull-right">
                                                        <a onclick="SaveData()" class="btn  btn-info">Redeem Now</a>



                                                    </div>




                                                </div>
                                                <!-- END FORM-->
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">

                            <button type="button" data-dismiss="modal" class="btn dark btn-outline">Close</button>

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
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script>
        function showmodaldata(id, MobNo, index) {
            $("#InsuranceCouponId").val(id);
            $("#MobNo").val(MobNo);
            $("#index").val(index);

            SendOTP()
            $("#stack1").modal("show");



        }

        function SendOTP() {
            $.ajax({

                type: "POST",
                url: 'CouponStatusSpecificCustomer.aspx/sendopt',
                data: '{"MobileNo":"' + document.getElementById("MobNo").value + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (obj, textstatus) {
                    var data = obj.d.split('<>');
                    if (data[0] == "1") {
                        alert("Send OTP on register Phone No.");

                    }
                    else if (data[0] == "3") {
                        window.location = data[1];

                    }
                    else {
                        alert(data[1]);

                    }

                },
                error: function (obj, textstatus) {

                }
            });

        }



        function SaveData() {

            debugger;
            if (document.getElementById("OTPFrom").value.length > 0 && document.getElementById("InvoiceNo").value.length > 0) {
                $.ajax({

                    type: "POST",
                    url: 'CouponStatusSpecificCustomer.aspx/savedata',
                    data: '{"OTP":"' + document.getElementById("OTPFrom").value + '","InvoiceNo":"' + document.getElementById("InvoiceNo").value + '","Id":"' + document.getElementById("InsuranceCouponId").value + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (obj, textstatus) {
                        var data = obj.d.split('<>');
                        if (data[0] == "1") {
                            var DIndex = document.getElementById("index").value;
                            var myTable = document.getElementById('<%=gvlocation.ClientID %>');
                            myTable.rows[DIndex].cells[6].innerHTML = data[1];
                            myTable.rows[DIndex].cells[7].innerHTML = '<span style="color:red">Redeem</span>';
                            $("#stack1").modal("hide");
                            alert("Coupon Successfully Redeem");

                        }
                        else {
                            alert(data[1]);

                        }

                    },
                    error: function (obj, textstatus) {

                    }
                });
            }
            else {
                alert("please input data");
            }
        }



    </script>

    <script type="text/javascript">
        $(window).on("beforeunload", function (e) {
            e.preventDefault(e);

            var txtName = window.opener.document.getElementById("FromContener_StuclsIds");
            txtName.value = (Math.random()).toString();
            txtName.onchange();


            window.close();

        })
    </script>


</asp:Content>
