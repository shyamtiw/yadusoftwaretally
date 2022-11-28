<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="ImportDMSSaleRegister.aspx.cs" Inherits="WebApp.admin.ImportDMSSaleRegister" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

   

            <div class="row">
                <SG:Message runat="server" ID="MessageBox" />


                <div class="col-md-6">

                    <!-- general form elements disabled -->
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h3 class="box-title">Import Clam</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">


                            <div class="row">

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Import File</label>
                                        <a onclick=" showLeter()" href="#" class="btn-success">upload</a><br />
                                        <asp:TextBox runat="server" ID="StuclsIds" CssClass="form-control" Style="display: none;"
                                            AutoPostBack="true" OnTextChanged="StuclsIds_TextChanged"></asp:TextBox>
                                        <b>File Name:</b><asp:Literal runat="server" ID="FileName"></asp:Literal>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Import File Type</label>

                                        <asp:DropDownList runat="server" ID="ImportFileType" CssClass="form-control">
                                            <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Import Claim" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Import TCN" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="New Car Sale Register" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="New Car Sale Return" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="New Car Purchase Register" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="New Car Counter Sale Register" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="New Car Counter Sale Return" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="New Car Transfer_In" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="New Car Transfer_Out" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="Maruti Statement" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="Exchange Claim Report" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="ISL/RMK Claim Report" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="Maruti Statement" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="BSC Sale BASE 12-19" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="Service Performance" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="BI New Car Sale Register" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="BI New Car Sale Return" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="BI Pending Booking Register" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="BI Stock as on Date" Value="27"></asp:ListItem>
                                            <asp:ListItem Text="Consumer Offer" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="Scheme Target" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="Extranet Dispatch" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="Pending Indent" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="Non OMS Indent" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="Pending POS" Value="24"></asp:ListItem>
                                            <asp:ListItem Text="Daily Sales S/F Account" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="Daily Service S Account" Value="26"></asp:ListItem>
                                            <asp:ListItem Text="Employee KRA" Value="28"></asp:ListItem>
                                            <asp:ListItem Text="Import AutoDebit Register" Value="29"></asp:ListItem>
                                            <asp:ListItem Text="Import CreditCard Register" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="Import Excel Tally Purchase" Value="31"></asp:ListItem>
                                            <asp:ListItem Text="Import Customer" Value="32"></asp:ListItem>
                                            <asp:ListItem Text="Import  Transction" Value="33"></asp:ListItem>
                                            <asp:ListItem Text="Import Charges" Value="34"></asp:ListItem>


                                            



                                            <asp:ListItem Text="Import DMS Live Master" Value="35"></asp:ListItem>
                                            <asp:ListItem Text="Import  DMS FSC Income" Value="36"></asp:ListItem>
                                            <asp:ListItem Text="Import DMS FSC Expense" Value="37"></asp:ListItem>
                                            <asp:ListItem Text="Import DMS TallyValidationData" Value="38"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="box-footer">
                                <asp:Button runat="server" Text="Upload" OnClick="Upload" ID="saveAccountHead" ValidationGroup="head" CssClass="btn btn-primary" />
                            </div>
                        </div>

                    </div>
                </div>

            </div>


       
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">

    <script>
        var popup;
        function showLeter() {
            debugger;
            var left = (screen.width - 700) / 2; var top = (screen.height - 400) / 4;
            var popup = window.open("FileUploader.aspx", 'File Uploader', 'menubar=no;toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + 500 + ', height=' + 400 + ', top=' + top + ', left=' + left);
            popup.focus();
        }
        function showmodal(DoneRecored, unRecored, Errors) { debugger; $("#DoneRecored").html(DoneRecored); $("#unRecored").html(unRecored); $("#unRecored").html(Errors); $("#modal-info").modal("show"); }
    </script>


</asp:Content>

