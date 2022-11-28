<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="DiscountDocuments.aspx.cs" Inherits="WebApp.admin.DiscountDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 2px 2px 2px 2px;
            font-size: 11px;
        }

        .t02 th {
            background-color: navy;
            color: white;
        }

        .disn {
            display: none;
        }

        .disy {
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formahndler" runat="server">
    <SG:Message ID="MessageBox" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>

            <div class="content-wrapper" style="background-color: white;">
              

                <section class="content">




                            <div class="row" style="padding-left: 15px;padding-right: 15px;">
                                <div class="col-md-12">
                                    <!-- general form elements disabled -->
                                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                                            <h4 class="box-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Add Document
                      </a>
                                            </h4>
                                        </div>
                                        <div class="row">


                                            


                                            <div class="col-md-8">
                                                <div class="form-group">
                                                    <label>Document Name</label>
                                                    <asp:TextBox runat="server" ID="DocumentName" CssClass="form-control" ></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DocumentName" runat="server" ForeColor="Red" 
                                                            ErrorMessage="Please Fill Document Name" Display="Dynamic"
                                                            ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>









                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label>File</label>
                                                    <div class="input-group input-group-sm">
                                                        <asp:FileUpload runat="server" ID="MasterId" CssClass="form-control"></asp:FileUpload>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="MasterId" runat="server" ForeColor="Red" 
                                                            ErrorMessage="Please select File" Display="Dynamic"
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
                                                        <asp:GridView ID="gvlocation" OnRowCommand="gvlocation_RowCommand" runat="server" CssClass="t01 t02"   AutoGenerateColumns="false" Width="98%" align="center">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Title">
                                                                    <ItemTemplate>
                                                                        <%# Eval("TitleData")%>
                                                                    <asp:HiddenField runat="server" ID="RealName" Value='<%# Eval("RealName")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 

                                                                <asp:TemplateField HeaderText="Action">
                                                                    <ItemTemplate>
                                                                         <a href='<%# Eval("FileName","../upload/{0}")%>' class='label label-sm label-success' download><span class="glyphicon glyphicon-download-alt"></span></a>
                                                                        <asp:LinkButton OnClientClick="return confirm('Are you sure to delete file ');" runat="server"  ID="DeleteData"  class='label label-sm label-danger'  CommandName="DeleteFile" CommandArgument='<%#  Eval("RealName") %>'><span class="glyphicon glyphicon-remove"></asp:LinkButton>
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
