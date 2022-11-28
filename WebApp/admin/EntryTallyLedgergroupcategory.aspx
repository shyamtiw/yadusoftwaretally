<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="EntryTallyLedgergroupcategory.aspx.cs" Inherits="WebApp.admin.EntryTallyLedgergroupcategory" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
    Ledger Mapping Master
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>

            <div class="row">
                <SG:Message runat="server" ID="MessageBox" />


                <div class="col-md-12">

                    <!-- general form elements disabled -->
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h3 class="box-title">Data List</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">



                            <div class="row">


                                <div class="col-md-3">
                                    <label>Parent</label>
                                    <asp:DropDownList runat="server" ID="ParentId" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ParentId_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <label>Group</label>
                                    <div class="input-group">
                                        <asp:DropDownList runat="server" ID="GroupId" CssClass="form-control"></asp:DropDownList>
                                        <span class="input-group-btn">
                                            <asp:LinkButton runat="server" ID="Searchid" CssClass="btn btn-warning btn-flat" OnClick="Searchid_Click"><i class="fa fa-fw fa-search"></i></asp:LinkButton>

                                        </span>
                                    </div>

                                </div>
                                <div class="col-md-2">
                                    <label>Category One</label>
                                    <asp:DropDownList runat="server" ID="Category1" CssClass="form-control" onchange="onchangecategory1()"></asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <label>Category Two</label>
                                    <asp:DropDownList runat="server" ID="Category2" CssClass="form-control" onchange="onchangecategory2()"></asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <label>Category Three</label>

                                    <div class="input-group">
                                        <asp:DropDownList runat="server" ID="Category3" CssClass="form-control" onchange="onchangecategory3()"></asp:DropDownList>
                                        <span class="input-group-btn">
                                            <asp:LinkButton title="Save Data" runat="server" ID="savedata" CssClass="btn  btn-success btn-flat" OnClick="savedata_Click"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                        </span>
                                    </div>

                                </div>



                                <hr />
                                <hr />
                                <hr />

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <div style="text-align: right; padding: 5px;">

                                                <input id="myInput" type="text" placeholder="Search..">
                                            </div>

                                            <div class="table-responsive">
                                                <asp:GridView ID="gvlocation" OnRowDataBound="gvlocation_RowDataBound" Style='width: 99%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="false" Width="98%" align="center">
                                                    <Columns>




                                                        <asp:TemplateField HeaderText="Ledger Name">
                                                            <ItemTemplate>


                                                                <asp:HiddenField runat="server" ID="AutoId" Value='<%# Eval("AutoId")%>' />
                                                                <asp:HiddenField runat="server" ID="Category1" Value='<%# Eval("Category1")%>' />
                                                                <asp:HiddenField runat="server" ID="Category2" Value='<%# Eval("Category2")%>' />
                                                                <asp:HiddenField runat="server" ID="Category3" Value='<%# Eval("Category3")%>' />

                                                                <%# Eval("ledgerName")%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Category1">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="dllCategory1" CssClass="form-control"></asp:DropDownList>


                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Category2">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="dllCategory2" CssClass="form-control"></asp:DropDownList>


                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Category3">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="dllCategory3" CssClass="form-control"></asp:DropDownList>


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
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
    <script>



        $(document).ready(function () {
            $('#<%=gvlocation.ClientID %>').prepend($("<thead></thead>").append($('#<%=gvlocation.ClientID %>').find("tr:first")));
            $("#myInput").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#<%=gvlocation.ClientID %> tbody").find("tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });


        function onchangecategory1() {

            var cate1 = document.getElementById("<%=Category1.ClientID%>").value;
            var table = document.getElementById("<%=gvlocation.ClientID%>");
            debugger;
            for (var i = 0; i < table.rows.length; i++) {
                var Ids = "#FromContener_gvlocation_dllCategory1_" + i.toString();
                $(Ids).val(cate1).trigger("change");

            }
        }


        function onchangecategory2() {

            var cate1 = document.getElementById("<%=Category2.ClientID%>").value;
            var table = document.getElementById("<%=gvlocation.ClientID%>");
            debugger;
            for (var i = 0; i < table.rows.length; i++) {
                var Ids = "#FromContener_gvlocation_dllCategory2_" + i.toString();
                $(Ids).val(cate1).trigger("change");

            }
        }

        function onchangecategory3() {

            var cate1 = document.getElementById("<%=Category3.ClientID%>").value;
            var table = document.getElementById("<%=gvlocation.ClientID%>");
            debugger;
            for (var i = 0; i < table.rows.length; i++) {
                var Ids = "#FromContener_gvlocation_dllCategory3_" + i.toString();
                $(Ids).val(cate1).trigger("change");

            }
        }

    </script>
</asp:Content>
