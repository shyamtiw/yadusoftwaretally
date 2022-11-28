<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="ECoupanEntry.aspx.cs" Inherits="WebApp.admin.ECoupanEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">


    <SG:Message ID="MessageBox" runat="server" />

    <div class="content-wrapper" style="background-color: white;">
        <!-- Content Header (Page header) -->

        <section class="content-header">
            <h1>Coupon Entry
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
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">E Coupen
                      </a>
                                    </h4>
                                </div>
                                <div class="box-body">
                                    <div class="row">


                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Customer Name</label>
                                                <asp:TextBox runat="server" ID="CustomerNames" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="CustomerNames" runat="server" ForeColor="Red"
                                                    ErrorMessage="Please enter Customer Name" Display="Dynamic"
                                                    ValidationGroup="ok"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>


                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Customer Mobile No.</label>
                                                <asp:TextBox runat="server" ID="CustomerMobileNo" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Email Id</label>
                                                <asp:TextBox runat="server" ID="EmailNos" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Vehicle Reg No</label>
                                                <asp:TextBox runat="server" ID="VehicleRegnNo" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>

                                    </div>
                                </div>
                                <div class="box-footer">
                                    <asp:Button runat="server" ID="savelocation" ValidationGroup="ok" CssClass="btn btn-primary" Text="Submit" OnClick="savelocation_Click" />
                                </div>
                                


                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>
    </div>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
