 <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1ReportViewer2.aspx.cs" Inherits="App_Test.WebForm1ReportViewer2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            Report Parameter :
        </div>
        <div class="col-sm-2">    
            <asp:TextBox ID="txtParameter" CssClass="form-control-sm" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnViewerReport" runat="server" CssClass="btn btn-sm btn-info" OnClick="btnViewerReport_Click" Text="Button" />
        </div>
      </div>
      <div class="row">
            <div class="col-sm-12">
  <rsweb:ReportViewer ID="ReportViewer1" Height="100%" Width="100%" runat="server"></rsweb:ReportViewer>
            </div>
        </div>
    
</asp:Content>
