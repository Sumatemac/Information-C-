<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1Input.aspx.cs" Inherits="App_Test.WebForm1Input" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div class="row">
                <div class="col-sm-12">
                    <b>ทดสอบ</b><hr />
                </div>
            </div> 
            <div class="row">
                <div class="col-sm-2">ชื่อ</div>
                <div class="col-sm-2"><asp:TextBox ID="txtName"   Font-Size="Small" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
                <div class="col-sm-2">นามสกุล</div>
                <div class="col-sm-2"><asp:TextBox ID="txtLastName"  Font-Size="Small" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                         
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">วันเกิด</div>
                <div class="col-sm-2"> <asp:TextBox ID="txtBD"  Font-Size="Small" CssClass="form-control form-control-sm" AutoPostBack="true" OnTextChanged="txtBD_TextChanged" runat="server"></asp:TextBox>
                     <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtBD"
                            TargetControlID="txtBD" Format="dd/MM/yyyy" />
                </div>
                <div class="col-sm-2">เบอร์โทร</div>
                <div class="col-sm-2"><asp:TextBox ID="txtTel"  Font-Size="Small" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" BackColor="#0066FF" ForeColor="White" Font-Size="Small"
                        Text="Save" OnClick= "btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Visible="false" OnClientClick="return confirm('คุณต้องการแก้ไขข้อมูลหรือไม่'); " BackColor="#0066FF" Font-Size="Small" ForeColor="White"
                        Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Visible="false" OnClientClick="return confirm('คุณต้องการลบข้อมูลหรือไม่');" BackColor="#FF3300" Font-Size="Small" ForeColor="White"
                        Text="Delete" OnClick= "btnDelete_Click" />
                    <asp:Button ID="btnPrintPDF" runat="server" CssClass="btn btn-info" Font-Size="Small" ForeColor="White"
                        Text="Print PDF" OnClick="btnPrintPDF_Click" />
                    <asp:Button ID="btnReportViewer" runat="server" CssClass="btn btn-info" Font-Size="Small" ForeColor="White"
                        Text="ReportViewer" OnClick="btnReportViewer_Click" />
                    <asp:Button ID="btnReportViewer2" runat="server" CssClass="btn btn-info" Font-Size="Small" ForeColor="White"
                        Text="Send Parameter From Webform" OnClick="btnReportViewer2_Click" />
                    <asp:Button ID="btnAutomail" runat="server" CssClass="btn btn-info" Font-Size="Small" ForeColor="Red"
                        Text="Automail" OnClick="btnAutomail_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <b>ทดสอบ insert and  update ข้อมูลใน Gridview </b><hr />
                </div>
            </div> 
            <div class="row"> <%--เริ่ม พาท2--%>
                <div class="col-sm-12">
                    <asp:GridView ID="gvInsert" runat="server" AutoGenerateColumns="False" ShowFooter="true" CssClass="padGrid ShowGridtd gv table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Bind("id") %>'></asp:Label>
                                    <asp:TextBox ID="txtName" ReadOnly="true" runat="server" BorderStyle="None"  Text='<%# Bind("Name") %>'></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SurName">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLastName" ReadOnly="true" runat="server" BorderStyle="None" Text='<%# Bind("LastName") %>'></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BirthDay">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBD" ReadOnly="true" runat="server" BorderStyle="None" Text='<%# Bind("BD","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                   <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="txtBD"
                            TargetControlID="txtBD" Format="dd/MM/yyyy" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtBD" runat="server"></asp:TextBox>
                                       <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="txtBD"
                            TargetControlID="txtBD" Format="dd/MM/yyyy" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone Number" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTel" ReadOnly="true" runat="server" BorderStyle="None" Text='<%# Bind("Tel") %>'></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtTel" MaxLength="10" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditDetail" runat="server" OnClick="btnEditDetail_Click" CssClass="buttonEditGv"
                                        ForeColor="White"> Edit </asp:LinkButton>
                                    <asp:LinkButton ID="btnUpdateDetail" runat="server" OnClick="btnUpdateDetail_Click" CssClass="buttonEditGv"
                                        ForeColor="White" Visible="false">Update</asp:LinkButton>
                                    <asp:LinkButton ID="btnCancelDetail" runat="server" OnClick="btnCancelDetail_Click" CssClass="buttonCancelGv"
                                        ForeColor="White" Visible="false">Cancel</asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnAddNew" runat="server" Text="Insert" OnClick="btnAddNew_Click" CssClass="btn-edit btn buttonEditGv" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDeleteDetail" runat="server" CssClass="buttonDeleteGv" OnClick="btnDeleteDetail_Click"
                                        ForeColor="White" OnClientClick="return confirm('คุณต้องการลบข้อมูลหรือไม่'); ">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#99ccff" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="padGrid ShowGridtd gv table-hover ">
                        </asp:GridView>
                </div>
            </div> <%--สิ้นสุด--%>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
