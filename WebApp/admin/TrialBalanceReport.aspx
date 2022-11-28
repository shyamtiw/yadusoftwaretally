<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="TrialBalanceReport.aspx.cs" Inherits="WebApp.admin.TrialBalanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <style>
        .t01 th, td {
            border-right: 1px solid black;
            border-collapse: collapse;
            padding: 12px !important;
            font-size: 15px;
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
    Trial Balance
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


                                <div class="col-md-6" style="display:none">
                                    <label>Branch</label>
                                    <asp:ListBox ID="BranchId" runat="server" SelectionMode="Multiple" CssClass="form-control" ></asp:ListBox>
                                </div>
                                 <div class="col-md-6">
                                    <label>Branch</label>
                                   <asp:DropDownList runat="server" ID="LocationId" CssClass="form-control"></asp:DropDownList>
                                </div>
                               
                                <div class="col-md-3">
                                    <label>as on date</label>
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="ToDate" CssClass="form-control"  Enabled="false"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton runat="server" ID="btnsearchdata" CssClass="btn btn-warning btn-flat" OnClick="btnsearchdata_Click"><i class="fa fa-fw fa-search"></i></asp:LinkButton>

                                        </span>
                                    </div>

                                </div>

                                  </div>
                            <hr />
                             
                                <div class="row">
                                    <div class="col-md-12">
                                        <div>
                                            <div style="overflow-x: auto;">
                                               <%-- <dx:ASPxTreeList runat="server" ID="DataList"></dx:ASPxTreeList>--%>

                                              
                                                <table id="example-basic"   class="t01 t02 TreeListData" style="width:95%">
                                                    <tr>
                                                        <th>Particular</th>
                                                        
                                                        <th><asp:Literal  runat="server" ID="AmountTh" Text=""></asp:Literal></th>
                                                    </tr>

                                                   
                                                    <asp:Literal runat="server" ID="Data"></asp:Literal>
                                                </table>
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
    <%--  <script>
    $("#employees").dxTreeList({
        dataSource: employees,
        rootValue: -1,
        keyExpr: "ID",
        parentIdExpr: "Head_ID",
        columns: [{
            dataField: "Title",
            caption: "Position"
        }, "Full_Name", "City", "State", "Mobile_Phone", {
            dataField: "Hire_Date",
            dataType: "date"
        }],
        expandedRowKeys: [1],
        showRowLines: true,
        showBorders: true,
        columnAutoWidth: true
    });
    </script>--%>
     
     
</asp:Content>
