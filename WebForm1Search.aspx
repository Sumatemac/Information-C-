<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1Search.aspx.cs" Inherits="App_Test.WebForm1Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
        <div class="col-sm-12">
            <h2>Search </h2>
            <hr />
        </div>
    </div>
        <div class="row">
        <div class="col-sm-1">
            Search :
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtSearch" Font-Size="Small" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" BackColor="#0066FF" ForeColor="White" Font-Size="Small"
                Text="Search" OnClick ="btnSearch_Click"/>
        </div>
    </div>
        <div class="row">
        <div class="col-sm-6" >
            Droupdown
            <asp:DropDownList ID="DroupDownList1" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
        </div>
     </div>        
    <div class="row">
        <div class="col-sm-12">
           <asp:GridView ID="gvSearch" runat="server" ShowFooter="false" Width="100%" EmptyDataText="ไม่พบข้อมูล" AutoGenerateColumns="False" CssClass="padGrid ShowGridtd gv table-hover">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkSelect" runat="server" Text="Select" OnClick="linkSelect_Click" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อ-นามสกุล" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Bind("id") %>'></asp:Label>
                            <asp:Label ID="lblAName" runat="server" Text='<%# Bind("AName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วันเกิด">
                        <ItemTemplate>
                            <asp:Label ID="lblBD" runat="server" Text='<%# Bind("BD","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="เบอร์โทรศัพท์" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblTel" runat="server" Text='<%# Bind("Tel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#99ccff" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
