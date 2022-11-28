<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="Perameter.aspx.cs" Inherits="WebApp.schooladmin.Perameter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
    Master Deatils
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">
    <SG:Message ID="MessageBox" runat="server" />
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
                    <!-- general form elements disabled -->
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h4 class="box-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Parent Master
                      </a>
                            </h4>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox runat="server" ID="ParentName" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ParentName" runat="server" ForeColor="Red"
                                        ErrorMessage="Please enter Parent Name" Display="Dynamic"
                                        ValidationGroup="Mainok"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                        </div>

                        <div class="box-footer">
                            <asp:Button runat="server" ID="savelocation" ValidationGroup="Mainok" CssClass="btn btn-primary" Text="Submit" OnClick="savelocation_Click" />

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:GridView ID="gvlocation" runat="server" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" Width="98%" align="center">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ParentName">
                                                <ItemTemplate>
                                                    <%# Eval("ParentName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="Editfamily" PostBackUrl='<%# Eval("MasterParentId","Perameter.aspx?MasterParentId={0}") %>' CssClass="label label-sm label-warning" Text="Edit"></asp:LinkButton>

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
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h4 class="box-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Master
                      </a>
                            </h4>
                        </div>
                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Parent Id</label>
                                    <asp:DropDownList runat="server" ID="MasterParentId" CssClass="form-control" OnSelectedIndexChanged="MasterParentId_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="MasterParentId" runat="server" ForeColor="Red" InitialValue="Select"
                                        ErrorMessage="Please enter Code" Display="Dynamic"
                                        ValidationGroup="ok"></asp:RequiredFieldValidator>


                                </div>

                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Code</label>
                                    <asp:TextBox runat="server" ID="Code" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox runat="server" ID="Names" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Names" runat="server" ForeColor="Red"
                                        ErrorMessage="Please enter Code" Display="Dynamic"
                                        ValidationGroup="ok"></asp:RequiredFieldValidator>

                                </div>

                            </div>



                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Description</label>
                                    <asp:TextBox runat="server" ID="Description" CssClass="form-control"></asp:TextBox>

                                </div>

                            </div>

                        </div>

                        <div class="box-footer">
                            <asp:Button runat="server" ID="saveClass" ValidationGroup="ok" CssClass="btn btn-primary" Text="Submit" OnClick="saveClass_Click" />

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:GridView ID="gvclass" runat="server" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" Width="98%" align="center">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                    <%# Eval("Code")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <%# Eval("Name")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="Editfamily" PostBackUrl='<%# Eval("MasterId","Perameter.aspx?MasterId={0}") %>' CssClass="label label-sm label-warning" Text="Edit"></asp:LinkButton>

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

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
