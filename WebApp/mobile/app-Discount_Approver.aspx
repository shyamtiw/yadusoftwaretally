<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app-Discount_Approver.aspx.cs" Inherits="WebApp.mobile.app_Discount_Approver" %>

<!doctype html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Discount Approval</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
</head>

<body class="bg-white">

    <form runat="server" id="FinancePag1">
        <asp:ScriptManager runat="server" ID="dataset" EnablePageMethods="true"></asp:ScriptManager>
        <!-- loader -->
        <div id="loader">
            <img src="assets/img/logo-icon.png" alt="icon" class="loading-icon">
        </div>
        <!-- * loader -->

        <!-- App Header -->
        <div class="appHeader">
            <div class="left">
                <a href="#" class="headerButton goBack">
                    <ion-icon name="chevron-back-outline"></ion-icon>
                </a>
            </div>
            <div class="pageTitle">
                <div>Discount Approval </div>
                <div>
                    BKG No : -
                    <asp:Literal runat="server" ID="Trans_Id"></asp:Literal>
                </div>
            </div>
        </div>
        <!-- * App Header -->

        <!-- App Capsule -->
        <div id="appCapsule" class="full-height">

            <asp:UpdatePanel runat="server" ID="updatedata" UpdateMode="Always">
                <ContentTemplate>
                    <SG:MessageMobile runat="server" ID="Message"></SG:MessageMobile>
                    <div class="section mt-2 mb-2">
                        <div class="card">
                            <div class="card-body">

                                <div class="form-group boxed">
                                    <div class="input-wrapper">
                                        <label class="label" for="text4b">Discount Amount</label>

                                        <asp:TextBox runat="server" ID="Requestamt" CssClass="form-control" Placeholder="Input  Discount Amount"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" Font-Bold="true" Font-Size="Smaller" ControlToValidate="Requestamt" ValidationGroup="ok" runat="server" ErrorMessage="Please input"></asp:RequiredFieldValidator>
                                        <i class="clear-input">
                                            <ion-icon name="close-circle" role="img" class="md hydrated" aria-label="close circle"></ion-icon>
                                        </i>
                                    </div>
                                </div>

                                <div class="form-group boxed">
                                    <div class="input-wrapper">
                                        <label class="label" for="text4b">Request Status</label>

                                        <asp:DropDownList runat="server" ID="RequestStatus" CssClass="form-control custom-select" AutoPostBack="true" OnSelectedIndexChanged="RequestStatus_SelectedIndexChanged">
                                            <asp:ListItem Value="2">Recommed</asp:ListItem>
                                            <asp:ListItem Value="3">Reject</asp:ListItem>
                                            <asp:ListItem Value="4">Approve</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" Font-Bold="true" Font-Size="Smaller" InitialValue="Select" ControlToValidate="RequestStatus" ValidationGroup="ok" runat="server" ErrorMessage="Please input"></asp:RequiredFieldValidator>

                                        <i class="clear-input">
                                            <ion-icon name="close-circle" role="img" class="md hydrated" aria-label="close circle"></ion-icon>
                                        </i>
                                    </div>
                                </div>

                                <div class="form-group boxed">
                                    <div class="input-wrapper">
                                        <label class="label" for="text4b">Remarks</label>

                                        <asp:TextBox runat="server"  list="browsers" ID="RequestRemark" CssClass="form-control" Placeholder="Input  Reason for Discount"></asp:TextBox>

                                         

                                        <datalist id="browsers">
                                            <option value="EXCHANGE SUPPORT">
                                            <option value="DEAL BREAK PASCO">
                                            <option value="DEAL BREAK PREM">
                                            <option value="DEAL BREAK OTHER OEM">
                                            <option value="OBLIGATION CASES">
                                            <option value="RELETIVE CASES">
                                            <option value="MODELAMA EMPLOYEE">
                                            <option value="PMC EMPLOYEE">
                                            <option value="MSIL EMPLOYEE">
                                            <option value="LEASING">
                                            <option value="CORPORATE ">
                                        </datalist>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" Font-Bold="true" Font-Size="Smaller" ControlToValidate="RequestRemark" ValidationGroup="ok" runat="server" ErrorMessage="Please input"></asp:RequiredFieldValidator>

                                        <i class="clear-input">
                                            <ion-icon name="close-circle" role="img" class="md hydrated" aria-label="close circle"></ion-icon>
                                        </i>
                                    </div>
                                </div>

                                <div class="form-group boxed">
                                    <div class="input-wrapper">
                                        <label class="label" for="text4b">Request Send to</label>

                                        <asp:DropDownList runat="server" ID="EmployeeName" CssClass="form-control custom-select"></asp:DropDownList>


                                        <i class="clear-input">
                                            <ion-icon name="close-circle" role="img" class="md hydrated" aria-label="close circle"></ion-icon>
                                        </i>
                                    </div>
                                </div>




                                <asp:LinkButton runat="server" ID="submit" CssClass="btn btn-primary btn-sm btn-block" ValidationGroup="ok" OnClick="submit_Click">Send Request</asp:LinkButton>
                            </div>
                        </div>
                             <div class="card">
                        <div class="table-responsive">
                            <table class="table bg-success">

                                <tbody>
                                    <tr>
                                        <th scope="row"><strong style="color:white">Insurance Type</strong></th>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="Insu_Typex"></asp:Literal></h4>
                                        </td>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="Insu_Amt"></asp:Literal></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row"><strong style="color:white">Extended Warranty</strong></th>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="EW_Type"></asp:Literal></h4>
                                        </td>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="EW_Amt"></asp:Literal></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row"><strong style="color:white">MSGA/GNA</strong></th>
                                        <td> </td>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="MSGA_AMT"></asp:Literal></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row"><strong style="color:white">Maruti Suzuki Reward</strong></th>
                                          <td> </td>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="MSR_AMT"></asp:Literal></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row"><strong style="color:white">Fasttag</strong></th>
                                          <td> </td>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="FasTag_Amt"></asp:Literal></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row"><strong style="color:white">Road Tax</strong></th>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="RTO_Type"></asp:Literal></h4>
                                        </td>
                                        <td>
                                            <h4 class="m-0"  style="color:white">
                                                <asp:Literal runat="server" ID="RTO_Amt"></asp:Literal></h4>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- * App Capsule -->


        <!-- App Bottom Menu -->
        <div class="appBottomMenu">
            <a href="/app-transaction-detail.aspx?loc_code=<%= Request.QueryString["Loc_CD"] %>&&SOB_No=<%= Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="pie-chart-outline"></ion-icon>
                    <h4 class="m-0">Customer Detail</h4>
                </div>
            </a>
            <a href="app-Vehicle-detail.aspx?loc_code=<%= Request.QueryString["Loc_CD"] %>&&SOB_No=<%=  Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="apps-outline"></ion-icon>
                    <h4 class="m-0">Vehicle</h4>
                </div>
            </a>
            <a href="app-Cost-detail.aspx?loc_code=<%= Request.QueryString["Loc_CD"] %>&&SOB_No=<%=  Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="apps-outline"></ion-icon>
                    <h4 class="m-0">Cost</h4>
                </div>
            </a><a href="app-Discount_Approver.aspx" class="item">
                <div class="col">
                    <ion-icon name="pie-chart-outline"></ion-icon>
                    <h4 class="m-0">Home</h4>
                </div>
            </a>
        </div>
        <!-- * App Bottom Menu -->
    </form>


    <!-- Android Add to Home Action Sheet -->

    <script src="assets/js/lib/jquery-3.4.1.min.js"></script>
    <!-- Bootstrap-->
    <script src="assets/js/lib/popper.min.js"></script>
    <script src="assets/js/lib/bootstrap.bundle.min.js"></script>
    <!-- Ionicons -->
    <script src="https://unpkg.com/ionicons@5.4.0/dist/ionicons.js"></script>
    <%--<script src="https://unpkg.com/ionicons@4.5.10-0/dist/ionicons.js"></script>--%>
    <!-- Splide -->
    <script src="assets/js/plugins/splide/splide.min.js"></script>
    <!-- Base Js File -->
    <script src="assets/js/base.js"></script>

    <script type="text/javascript">



        Sys.Application.add_load(BindEventsto);

        function BindEventsto() {

            debugger;
            $("div.messageBox").delay(5000).slideUp();
        }
    </script>
</body>


</html>
