<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="IMUserImport.aspx.cs" Inherits="WebApp.admin.IMUserImport" %>

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
                            <h3 class="box-title">Import Data</h3>
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

