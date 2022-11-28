﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app-Exchange-detail.aspx.cs" Inherits="WebApp.mobile.app_Exchange_detail" %>

<!doctype html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Pre Sales Module</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
</head>

<body class="bg-white">

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
          <div>Exchange Detail</div>
                <div>BKG No : - <asp:Literal runat="server" ID="Trans_Id"></asp:Literal>  </div>
        </div>
        <div class="right">
            <a href="javascript:;" class="headerButton" data-bs-toggle="modal" data-bs-target="#DialogBasic">
                <ion-icon name="trash-outline"></ion-icon>
            </a>
        </div>
    </div>
    <!-- * App Header -->

    <!-- Dialog Basic -->
    <div class="modal fade dialogbox" id="DialogBasic" data-bs-backdrop="static" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Delete</h5>
                </div>
                <div class="modal-body">
                    Are you sure?
                </div>
                <div class="modal-footer">
                    <div class="btn-inline">
                        <a href="#" class="btn btn-text-secondary" data-bs-dismiss="modal">CANCEL</a>
                        <a href="#" class="btn btn-text-primary" data-bs-dismiss="modal">DELETE</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- * Dialog Basic -->

    <!-- App Capsule -->
    <div id="appCapsule" class="full-height">

        <div class="section mt-2 mb-2">

            <ul class="listview flush transparent simple-listview no-space mt-3">
                <li>
				   <a href="#" data-bs-toggle="modal" data-bs-target="#OldVehDtlActionSheet">
                            <strong>Veh. Reg. No.</strong>
                        </a>
					
                    <h3 class="m-0"><asp:Literal runat="server" ID="Veh_Regn_No"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Chassis No.</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Veh_Chas_No"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Engine No</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Veh_Engn_No"></asp:Literal></h3>
                </li>
				<li>
                   <a href="#" data-bs-toggle="modal" data-bs-target="#ExchTypeActionSheet">
                            <strong>Exchange Type</strong>
                        </a>
					
					<h3 class="m-0"><asp:Literal runat="server" ID="Exch_Type"></asp:Literal></h3>
                </li>
				<li>
				 <a href="#" data-bs-toggle="modal" data-bs-target="#EvaluatorActionSheet">
                            <strong>Evaluator Name</strong>
                        </a>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Evaluator_Name"></asp:Literal></h3>
                </li>
				<li>
					<a href="#" data-bs-toggle="modal" data-bs-target="#ModelVariantActionSheet">
                            <strong>Model Variant</strong>
                        </a>
					                   
				   <h3 class="m-0"><asp:Literal runat="server" ID="Model_Variant"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Mfg Year</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="MFG_Year"></asp:Literal></h3>
                </li>
				<li>
                    <strong>KM Run</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="KMS_Run"></asp:Literal></h3>
                </li>
				<li>
				<a href="#" data-bs-toggle="modal" data-bs-target="#OldVehCostActionSheet">
                            <strong>Purchase Amount</strong>
                        </a>
                   <h3 class="m-0"><asp:Literal runat="server" ID="Purc_Amt"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Exchange Bonus Amount</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Exch_Offer"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Loan Paid</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Loan_Paid"></asp:Literal></h3>
                </li>
				<li>
                    <strong>3rd Party Insurance</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Insurance_3P"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Net Amount</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Net_Amt"></asp:Literal></h3>
                </li>
				<li>
				<a href="#" data-bs-toggle="modal" data-bs-target="#RFCostActionSheet">
                            <strong>Proposed RF Cost</strong>
                        </a>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Prop_RF"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Actual RF Cost</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Actual_RF"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Remarks</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Remarks"></asp:Literal></h3>
                </li>
            </ul>


        </div>

    </div>
    <!-- * App Capsule -->

<!-- Old Vehicle Detail Discount Sheet -->
        <div class="modal fade action-sheet" id="OldVehDtlActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Old Vehicle Detail</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                            <div class="form-group basic">
                                    <label class="label"><strong>Old Vehicle Reg. Number</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1"></span>
                                        <input type="text" class="form-control" placeholder="Enter Vehicle Reg. Number"
                                            value="">
                                    </div>
							</div>	
							 <div class="form-group basic">
                                    <label class="label"><strong>Old Vehicle Chassis Num</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1"></span>
                                        <input type="text" class="form-control" placeholder="Enter Vehicle Chassis Number"
                                            value="">
                                    </div>
							</div>
							<div class="form-group basic">
                                    <label class="label"><strong>Old Vehicle Engine Num</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1"></span>
                                        <input type="text" class="form-control" placeholder="Enter Vehicle Engine Number"
                                            value="">
                                    </div>
							</div>		
									 <div class="form-group basic">
                                    <button type="button" class="btn btn-primary btn-block btn-lg"
                                        data-bs-dismiss="modal">Submit Breakup</button>
                               
                                </div>
                           </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Post Sales Discount Sheet -->
 <!-- Exchange Type Action Sheet -->
        <div class="modal fade action-sheet" id="ExchTypeActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Exchange Type Master</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                                <div class="form-group basic">
                                    <div class="input-wrapper">
                                        <label class="label" for="account2d">Exchnage Type List</label>
                                        <select class="form-control custom-select" id="account2d">
                                            <option value="0">True Value</option>
                                            <option value="1">Non True Value</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <button type="button" class="btn btn-primary btn-block btn-lg"
                                        data-bs-dismiss="modal">Submit</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Exchnage Type Action Sheet -->
		
<!-- Evaluator List  Action Sheet -->
        <div class="modal fade action-sheet" id="EvaluatorActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Evaluator Master</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                                <div class="form-group basic">
                                    <div class="input-wrapper">
                                        <label class="label" for="account2d">Evaluator List</label>
                                        <select class="form-control custom-select" id="account2d">
                                            <option value="0">Murli Prasad</option>
                                            <option value="1">Sachin Tendulkar</option>
											<option value="1">Virat Kohli</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <button type="button" class="btn btn-primary btn-block btn-lg"
                                        data-bs-dismiss="modal">Submit</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Exchnage Type Action Sheet -->
		

<!-- Model Variant Detail Discount Sheet -->
        <div class="modal fade action-sheet" id="ModelVariantActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Model Detail</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                            <div class="form-group basic">
                                    <label class="label"><strong>Model/Variant Name</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1"></span>
                                        <input type="text" class="form-control" placeholder="Enter Model/Variant Detail"
                                            value="">
                                    </div>
							</div>	
							 <div class="form-group basic">
                                    <label class="label"><strong>Year of Manufacture</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1"></span>
                                        <input type="text" class="form-control" placeholder="Enter Vehicle Year of Manufacture"
                                            value="">
                                    </div>
							</div>
							<div class="form-group basic">
                                    <label class="label"><strong>KMS Run</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1"></span>
                                        <input type="text" class="form-control" placeholder="Enter Old Vehicle Kms Run"
                                            value="">
                                    </div>
							</div>		
									 <div class="form-group basic">
                                    <button type="button" class="btn btn-primary btn-block btn-lg"
                                        data-bs-dismiss="modal">Submit Breakup</button>
                               
                                </div>
                           </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Model Variant Sheet -->

		<!-- Old Vehicle Cost Detail Sheet -->
        <div class="modal fade action-sheet" id="OldVehCostActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Purchase Amount</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                            <div class="form-group basic">
                                    <label class="label"><strong>Purchase Amount</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
                                    </div>
							</div>	
							<div class="form-group basic">
                                    <label class="label"><strong>Exchange Bonus Amount</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
                                    </div>
							</div>
							<div class="form-group basic">
                                    <label class="label"><strong>Loan Amount Paid</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
                                    </div>
							</div>	
							<div class="form-group basic">
                                    <label class="label"><strong>3rd Party Insurance Amt</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
                                    </div>
							</div>										
									 <div class="form-group basic">
                                    <button type="button" class="btn btn-primary btn-block btn-lg"
                                        data-bs-dismiss="modal">Submit Breakup</button>
                          
                                </div>
                           </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Old Vehicle Cost Detail Sheet -->

	<!-- Ref  Cost Detail Sheet -->
        <div class="modal fade action-sheet" id="RFCostActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Refurbishment Cost</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                            <div class="form-group basic">
                                    <label class="label"><strong>Proposed RF Cost</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
                                    </div>
							</div>	
							<div class="form-group basic">
                                    <label class="label"><strong>Actual RF Amount</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
                                    </div>
							</div>
							<div class="form-group basic">
                                    <label class="label"><strong>Remarks</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1"></span>
                                        <input type="text" class="form-control" placeholder="Enter Remarks"
                                            value="">
                                    </div>
							</div>
							<div class="form-group basic">
                                    <button type="button" class="btn btn-primary btn-block btn-lg"
                                        data-bs-dismiss="modal">Submit Breakup</button>
                          
                                </div>
                           </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Ref Cost Detail Sheet -->

 <!-- App Bottom Menu -->
    <div class="appBottomMenu">
        <a href="app-transaction-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="pie-chart-outline"></ion-icon>
				<h4 class="m-0">Customer Detail</h4>
            </div>
        </a>
        <a href="app-Financer-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="document-text-outline"></ion-icon>
				<h4 class="m-0">Finance</h4>
            </div>
        </a>
        <a href="app-Vehicle-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="apps-outline"></ion-icon>
				<h4 class="m-0">Vehicle</h4>
            </div>
        </a>
        <a href="app-Cost-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="card-outline"></ion-icon>
				<h4 class="m-0">Costing</h4>
            </div>
        </a>
        <a href="app-Exchange-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="settings-outline"></ion-icon>
				<h4 class="m-0">Exchange</h4>
            </div>
        </a>
		 <a href="app-Shipping-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="settings-outline"></ion-icon>
                <h4 class="m-0">Shipping</h4>
            </div>
        </a>
		 <a href="app-Discount_Approval.aspx" class="item">
            <div class="col">
                <ion-icon name="settings-outline"></ion-icon>
				<h4 class="m-0">Approval</h4>
            </div>
        </a>
		 <a href="index.aspx" class="item">
            <div class="col">
                <ion-icon name="pie-chart-outline"></ion-icon>
				<h4 class="m-0">Home</h4>
            </div>
        </a>
    </div>
    <!-- * App Bottom Menu -->


 
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



</body>



</html>
