<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>STEEROID</h1>
        <p class="lead">This is a Web application test site.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    <hr />

    <div class="row">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Results coming from Service Bus</h3>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btnTrigger" runat="server" Text="Test event" OnClientClick="RunSample();" />
                        <input type="text" id ="txtRefId" value="ref123" />
                        <div id="sampleResult">
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnTrigger" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>


    </div>



    <div class="row">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Results coming from Service Bus</h3>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Test Button" OnClick="btnAdd_Click" />
                        <hr />
                        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <EmptyDataTemplate>
                                No Results.
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetResults" TypeName="WebApplicationTest._Repo.DbManager"></asp:ObjectDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnRefresh" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>


    </div>
    <script type="text/javascript">
        window.onload = function () {
            setInterval(function () {
                document.getElementById("<%=btnRefresh.ClientID %>").click();
            }, 5000);
        };
        function RunSample() {
            var refId = $("#txtRefId").val();
            var url = window.location.origin + "/api/steer?refId=" + refId ;
            $.get(url, function (data) {
                $("#sampleResult").text(data);                
            });
        }
       

    </script>
</asp:Content>
