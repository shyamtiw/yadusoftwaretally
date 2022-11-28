<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="Insuranceupdatepayment.aspx.cs" Inherits="WebApp.admin.Insuranceupdatepayment" %>

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
                    <h1>Update Payment
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
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Update Payment
                      </a>
                                            </h4>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Payment Receipt Branch</label>
                                                    <asp:DropDownList runat="server" ID="BranchId" CssClass="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="BranchId" runat="server" ForeColor="Red" InitialValue="Select"
                                                        ErrorMessage="Please select Payment Receipt Branch" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Payment Mode</label>
                                                    <asp:DropDownList runat="server" ID="MasterId" CssClass="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="MasterId" runat="server" ForeColor="Red" InitialValue="Select"
                                                        ErrorMessage="Please select Payment Mode" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Receipt No</label>
                                                    <asp:TextBox runat="server" ID="ReceiptNo" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ReceiptNo" runat="server" ForeColor="Red"
                                                        ErrorMessage="Please enter ReceiptNo" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Receipt Date</label>
                                                    <asp:TextBox runat="server" ID="ReceiptDate" CssClass="form-control Date"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ReceiptDate" runat="server" ForeColor="Red"
                                                        ErrorMessage="Please enter Receipt Date" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Receipt Amount</label>
                                                    <asp:TextBox runat="server" ID="ReceiptAmount" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ReceiptAmount" runat="server" ForeColor="Red"
                                                        ErrorMessage="Please enter Receipt Amount" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Premium Amount</label>
                                                    <asp:Label runat="server" ID="PremiumAmount" CssClass="form-control"></asp:Label>

                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Balance Amount</label>
                                                    <asp:Label runat="server" ID="BalanceAmount" CssClass="form-control" ForeColor="Red"></asp:Label>

                                                </div>

                                            </div>



                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Attach Receipt</label>
                                                    <div class="input-group input-group-sm">
                                                        <asp:FileUpload runat="server" ID="Fileupload" CssClass="form-control" />

                                                        <span class="input-group-btn">
                                                            <asp:Button runat="server" ID="savelocation" ValidationGroup="ok" CssClass="btn btn-primary" Text="Submit" OnClick="savelocation_Click" />

                                                        </span>
                                                    </div>

                                                </div>

                                            </div>

                                               <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>Remark</label>
                                                    <asp:TextBox runat="server" ID="Remark" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                  
                                                </div>

                                            </div>


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

                                                                <asp:TemplateField HeaderText="ReceiptNo">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ReceiptNo")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Receipt Date">
                                                                    <ItemTemplate>
                                                                        <%# Convert.ToDateTime( Eval("ReceiptDate")).ToString("dd/MM/yyyy")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Receipt Date">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ReceiptAmount")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Action">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="Editfamily" PostBackUrl='<%# Eval("InsuranceupdatepaymentId","Insuranceupdatepayment.aspx?InsuranceupdatepaymentId={0}&&InsuranceIndividualId="+Request.QueryString["InsuranceIndividualId"]+"") %>' CssClass="label label-sm label-warning" Text="Edit"></asp:LinkButton>

                                                                        <a href='<%# Eval("Fileupload","../upload/{0}")%>' download><i class="fa fa-file"></i></a>

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

        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="savelocation" />
        </Triggers>
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
</asp:Content>
