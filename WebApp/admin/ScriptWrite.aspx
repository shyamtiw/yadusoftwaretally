<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="ScriptWrite.aspx.cs" Inherits="WebApp.admin.ScriptWrite" %>

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
    Auto VYN Support
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">


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
                            <div class="form-group">
                                <label>Master Data</label>
                                <asp:DropDownList runat="server" ID="MasterData" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="MasterData_SelectedIndexChanged">
                                </asp:DropDownList>

                            </div>
                        </div>

                        <div class="col-md-9">
                            <div class="form-group">
                                <label>Required Parameter </label>
                                <asp:Label runat="server" ID="Perameter" CssClass="form-control"></asp:Label>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Parameter 1</label>
                                <asp:TextBox runat="server" ID="Para1" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Parameter 2</label>
                                <asp:TextBox runat="server" ID="Para2" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Parameter 3</label>
                                <asp:TextBox runat="server" ID="Para3" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                         <div class="col-md-3">
                            <div class="form-group">
                                <label> </label>
                                <asp:Button runat="server" ID="SaveData" CssClass="btn btn-success" Text="Execution"  OnClick="GetData_Click"/>

                            </div>
                        </div>


                       


                    </div>


                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="row">
                                      <div class="col-md-6"> </div>
                                    <div class="col-md-6">
                                        <div style="text-align: right; padding: 5px;">

                                            <div class="input-group">
                                                <input id="myInput" type="text" placeholder="Search..">

                                                <span class="input-group-btn">
                                                    <a class="btn btn-primary btn-flat" onclick="Print_Click()">Export</a>

                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:Panel runat="server" ID="Table">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvlocation" Style='width: 100%' CssClass='t02 t01' HeaderStyle-BackColor="LightBlue" runat="server" AutoGenerateColumns="true" Width="98%" align="center">
                                            <Columns>

                                            </Columns>
                                            <EmptyDataTemplate>
                                                No Record Exists
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="Excute">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Response</label>
                                                <asp:TextBox runat="server" ID="responce" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    </div>
    


    <asp:Literal runat="server" ID="UpdatePanels"></asp:Literal>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
    <script src="js/jquery.table2excel.js"></script>
    <script>
      


        function Print_Click() {

            var table = $('#<%=gvlocation.ClientID %>').prepend($("<thead></thead>").prev($('#<%=gvlocation.ClientID %>').find("tr:first")));
            if (table && table.length) {
                debugger;
                $(table).table2excel({

                    name: "Data",
                    filename: "Export_ " + new Date().toISOString().replace(/[\-\:\.]/g, "") + ".xls",
                    fileext: ".xls",
                    exclude_img: true,
                    exclude_links: true,
                    exclude_inputs: true,
                    preserveColors: true
                });
            }
        }


        $(document).ready(function () {
            $('#<%=gvlocation.ClientID %>').prepend($("<thead></thead>").append($('#<%=gvlocation.ClientID %>').find("tr:first")));
            $("#myInput").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#<%=gvlocation.ClientID %> tbody").find("tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });

    </script>


</asp:Content>
