
<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="E_AddInsuranceCoupon.aspx.cs" Inherits="WebApp.admin.E_AddInsuranceCoupon" %>

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
                    <h1>Add Coupon
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
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Add Coupon
                      </a>
                                            </h4>
                                        </div>
                                        <div class="row">


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Issue Date</label>
                                                    <asp:TextBox runat="server" ID="IssueDate" CssClass="form-control Date"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="IssueDate" runat="server" ForeColor="Red"
                                                        ErrorMessage="Please enter Issue Date" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Valid Upto</label>
                                                    <asp:TextBox runat="server" ID="ExpiryDateofPolicy" CssClass="form-control Date" ></asp:TextBox>

                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Vehicle No</label>
                                                    <asp:TextBox runat="server" ID="VehicleNo" CssClass="form-control" Enabled="false"></asp:TextBox>

                                                </div>

                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Customer Name</label>
                                                    <asp:TextBox runat="server" ID="CustomerName" CssClass="form-control" Enabled="false"></asp:TextBox>

                                                </div>

                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Mobile No</label>
                                                    <asp:TextBox runat="server" ID="MobNo" CssClass="form-control"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="MobNo" runat="server" ForeColor="Red"
                                                        ErrorMessage="Please input MobNo" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                           
                                             <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Email ID</label>
                                                    <asp:TextBox runat="server" ID="EmailId" CssClass="form-control" ></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="EmailId" runat="server" ForeColor="Red"
                                                        ErrorMessage="Please input EmailId" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>MI Advisor Name</label>
                                                    <asp:TextBox runat="server" ID="MIAdvisorName" CssClass="form-control" ></asp:TextBox>

                                                </div>

                                            </div>









                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Coupon</label>
                                                    <div class="input-group input-group-sm">
                                                        <asp:DropDownList runat="server" ID="MasterId" CssClass="form-control"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="MasterId" runat="server" ForeColor="Red" InitialValue="Select"
                                                            ErrorMessage="Please select Coupon" Display="Dynamic"
                                                            ValidationGroup="ok"></asp:RequiredFieldValidator>

                                                        <span class="input-group-btn">
                                                            <asp:Button runat="server" ID="savelocation" ValidationGroup="ok" CssClass="btn btn-primary" Text="Submit" OnClick="savelocation_Click" />

                                                        </span>
                                                    </div>


                                                </div>

                                            </div>









                                        </div>


                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gvlocation" runat="server" CssClass="t01 t02" OnRowCommand="gvsession_RowCommand" AutoGenerateColumns="false" Width="98%" align="center">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Code">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Code")%>
                                                                        <asp:HiddenField runat="server" ID="EmailId"  Value='<%# Eval("EmailId")%>'/>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mobile No.">
                                                                    <ItemTemplate>
                                                                        <%# Eval("MobNo")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Issue Date">
                                                                    <ItemTemplate>
                                                                        <%# Convert.ToDateTime( Eval("IssueDate")).ToString("dd/MM/yyyy")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Coupon">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Master.Name")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Action">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="ck"  Visible='<%# WebApp.LIBS.Common.ConvertBool( Eval("IsApprove"))?true:false %>'/>
                                                                        <%# WebApp.LIBS.Common.ConvertBool( Eval("IsApprove"))==false?WebApp.LIBS.Common.ConvertBool( Eval("IsReject"))?"<span style='color:red'>Reject</span>":"<span style='color:red'>Pending</span>":"" %>
                                                                        <asp:HiddenField ID="InsuranceCouponId" runat="server" Value='<%# Eval("InsuranceCouponId") %>' />
                                                                        <%-- <a onclick='<%# Eval("InsuranceCouponId","updatestation({0})") %>' href="#" class='label label-sm label-success' >Send Coupon</a>--%>
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
                                               <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <table class="table table-bordered text-center">
                                                        <tbody>
                                                            <tr>
                                                                

                                                                <td style="width:33%">
                                                                       <asp:Button runat="server"  CssClass="btn btn-block btn-primary btn-flat" ID="sendemail" Text="Send Email" OnClick="Button1_Click"></asp:Button>
                                                              
                                                                </td>
                                                                <td style="width:33%">
                                                                <asp:Button runat="server"  CssClass="btn btn-block btn-default btn-flat" ID="WhatsApp" Text="Send Whats App" OnClick="WhatsApp_Click"></asp:Button>
                                                                        
                                                                </td>
                                                                <td style="width:33%">
                                                                    <asp:Button runat="server"  CssClass="btn btn-block btn-info btn-flat" ID="PrintData" Text="Print" OnClick="PrintData_Click"></asp:Button>
                                                                    
                                                                </td>



                                                            </tr>
                                                        </tbody>
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
        function updatestation(Id) {

            $.ajax({
                type: "POST",
                url: "AddInsuranceCoupon.aspx/sendwa",
                data: '{"Id":"' + Id + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response.d);
                }
            });

        }
    </script>
</asp:Content>