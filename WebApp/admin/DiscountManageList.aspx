<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="DiscountManageList.aspx.cs" Inherits="WebApp.admin.DiscountManageList" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .Pager span {
            color: #333;
            background-color: #F7F7F7;
            font-weight: bold;
            text-align: center;
            display: inline-block;
            width: 20px;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #ccc;
        }

        .Pager a {
            text-align: center;
            display: inline-block;
            width: 20px;
            border: 1px solid #ccc;
            color: #fff;
            /*color: #333;*/
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }
    </style>


    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 2px 2px 2px 2px;
            font-size: 13px;
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

     <SG:Message ID="MessageBox" runat="server" />
    
        <div class="row">
            
            <div class="col-xs-12">
                <div class="box">
                  <div class="box-header with-border"   style="background: #0b0336!important; background-color: #0b0336!important;">
            <h3 class="box-title" style="color:white">Data List</h3>
        </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <div class="row">
                   
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Branch</label>
                        <asp:DropDownList runat="server" ID="BranchId" class="form-control"></asp:DropDownList>
                    </div>

                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label>Staus</label>
                        <asp:DropDownList runat="server" ID="Status" class="form-control">
                              <asp:ListItem Text="All" Value="All"> </asp:ListItem>
                            <asp:ListItem Text="Pending" Value="Pending">

                            </asp:ListItem>
                            
                              <asp:ListItem Text="Complete" Value="Complete">

                            </asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>


                <div class="col-md-2">
                    <div class="form-group">
                        <label>From Date</label>
                        
                        <asp:TextBox runat="server" ID="FromDate" placeholder="From Date"  CssClass="form-control"  TextMode="Date"></asp:TextBox>
                    </div>

                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label>To Date</label>
                        <asp:TextBox runat="server" ID="ToDate" placeholder="To Date"  CssClass="form-control"  TextMode="Date"></asp:TextBox>
                        
                    </div>

                </div>
                <div class="col-md-3">
                    
                        <label>Search</label>
                        <div class="input-group">
                           <table>
                               <tr>
                                   <td style="width:70%"><input type="text" name="message" placeholder="Search....." id="txtSearch" class="form-control"></td>
                                   <td style="width:10%">  <a class="btn btn-primary" id="searchdata"><i class="fa fa-search"></i></a></td>
                                   <td style="width:10%">
                                       
                                       <asp:LinkButton runat="server" ID="refreshData"  CssClass="btn btn-primary"  OnClick="refreshData_Click"><i class="fa fa-refresh"></i></asp:LinkButton>
                                       </td>
                                    <td style="width:10%">
                                       
                                       <asp:LinkButton runat="server" ID="updatependingdata" title="Update All Pending Data"  CssClass="btn btn-danger"  OnClick="updatependingdata_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                                       </td>
                               </tr>
                           </table>
                            
                        </div>

                    

                </div>





            </div>

                       
                        <table id="gvCustomers" class="t02 t01 table table-hover">
                            <tr>
                                <th>Branch</th>
                                <th>Inv No</th>
                                <th>Inv Date</th>
                                <th>Customer Name</th>
                                <th>ModelName</th>
                                <th>Executive</th>
                                <th>CustId</th>
                                <th>Status</th>
                                <th>Action</th>

                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table></div>
                 
                    <div class="box-footer clearfix" style="background-color: navy;">
                        <div class="Pager pagination pagination-sm no-margin pull-right divcolor" style="color: white;"></div>
                    </div>


                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>



        </div>
    <asp:Panel runat="server" ID="PleaseWait">

        <div style="z-index: 10001;" class="windowbackground">
                <div class="progressbar breadcrumb">
                    <img alt="Loading..." src="../images/ajax-loader.gif"><br>
                     Please Wait Database is update...
                </div>
            </div>
    </asp:Panel>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
        <script src="javascript/ASPSnippets_Pager.min.js"></script>

    <script>

        $(function () {
            var now = new Date();
            var month = (now.getMonth() + 1);
            var day = now.getDate();
            if (month < 10)
                month = "0" + month;
            if (day < 10)
                day = "0" + day;
            var today = now.getFullYear() + '-' + month + '-' + day;
            $('#<%=FromDate.ClientID%>').val(today);
            $('#<%=ToDate.ClientID%>').val(today);

            GetCustomers(1);
        });


        $("#searchdata").on("click", function () {
            GetCustomers(parseInt(1));
        });
        $(".Pager").on("click", '.page', function () {

            GetCustomers(parseInt($(this).attr('page')));
        });
        function SearchTerm() {
            return jQuery.trim($("[id*=txtSearch]").val());
        };
        function SearchFromDate() {
            return jQuery.trim($("#<%=FromDate.ClientID%>").val());
        };
        function SearchToDate() {
            return jQuery.trim($("#<%=ToDate.ClientID%>").val());
        };
      
        
        function GetCustomers(pageIndex, name) {

            var obj = {};
            obj.pageIndex = $.trim(pageIndex);
            obj.name = $.trim(SearchTerm());
            obj.FromDate = $.trim(SearchFromDate());
            obj.ToDate = $.trim(SearchToDate());
            obj.BranchId = $.trim($("#<%=BranchId.ClientID%>").val());
            obj.Status = $.trim($("#<%=Status.ClientID%>").val());


            $.ajax({
                type: "POST",
                url: "DiscountManageList.aspx/GetCustomers",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        var row;
        function OnSuccess(response) {
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var customers = xml.find("Customers");
            if (row == null) {
                row = $("[id*=gvCustomers] tr:last-child").clone(true);
            }
            $("[id*=gvCustomers] tr").not($("[id*=gvCustomers] tr:first-child")).remove();

            if (customers.length > 0) {
                $.each(customers, function () {
                    var customer = $(this);
                    $("td", row).eq(0).html($(this).find("BranchId").text());
                    $("td", row).eq(1).html($(this).find("DMSINVNo").text());
                    $("td", row).eq(2).html($(this).find("DelvOn").text());
                    $("td", row).eq(3).html($(this).find("CustomerName").text());
                    $("td", row).eq(4).html($(this).find("ModelName").text());
                    $("td", row).eq(5).html($(this).find("ErpExecutive").text());
                    $("td", row).eq(6).html($(this).find("CustId").text());
                    $("td", row).eq(7).html($(this).find("Status").text());
                    $("td", row).eq(8).html($(this).find("Action").text());
                    $("[id*=gvCustomers]").append(row);
                    row = $("[id*=gvCustomers] tr:last-child").clone(true);
                });
                var pager = xml.find("Pager");
                $(".Pager").ASPSnippets_Pager({
                    ActiveCssClass: "current",
                    PagerCssClass: "pager",
                    PageIndex: parseInt(pager.find("PageIndex").text()),
                    PageSize: parseInt(pager.find("PageSize").text()),
                    RecordCount: parseInt(pager.find("RecordCount").text())
                });
                $(".ContactName").each(function () {
                    var searchPattern = new RegExp('(' + SearchTerm() + ')', 'ig');
                    $(this).html($(this).text());
                });
            } else {
                var empty_row = row.clone(true);
                $("td:first-child", empty_row).attr("colspan", $("td", row).length);
                $("td:first-child", empty_row).attr("align", "center");

                $("td:first-child", empty_row).html("No records found for the search criteria.");
                $("td", empty_row).not($("td:first-child", empty_row)).remove();
                $("[id*=gvCustomers]").append(empty_row);
            }
        };
        function printinvoice(str) {
            var popup;
            debugger;
            var wird = parseInt(((screen.width * 72) / 100.00).toFixed(0));
            var left = (screen.width - wird) / 2; var top = (screen.height - 650) / 4;

            var popup = window.open("DiscountUpdate.aspx?ReciptId=" + str.toString() + "", "Print Receipt", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + wird + ', height=' + 650 + ', top=' + top + ', left=' + left);
            popup.focus();
        }

       



    </script>


</asp:Content>
