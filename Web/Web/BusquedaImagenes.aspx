<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="BusquedaImagenes.aspx.cs" Inherits="Web.BusquedaImagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="grid" style="margin-bottom: 20px; width: 100%">
     <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
             <asp:GridView 
                    ID="GridViewOne"
                    runat="server"
                    CssClass="datatable"
                    CellPadding="0" 
                    CellSpacing="0"
                    GridLines="Both"
                    AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField HeaderText="Imagen" DataField="Campo-del-DataSource">
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Autor" >
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Título" >
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Ver detalles" >
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Ver comentarios" >
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Añadir comentario" >
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Likes" >
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Dar like" >
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Fecha" >
                        <ItemStyle Width="11%"></ItemStyle>
                    </asp:BoundField>

                </Columns>
                <RowStyle CssClass="even"/>
                <HeaderStyle CssClass="header" />
                <AlternatingRowStyle CssClass="odd"/>
             </asp:GridView>
         </ContentTemplate>
     </asp:UpdatePanel>
 </div>
<div style="margin-bottom: 20px">
	<div class="field" align="right" style="font-size: large; float:left; width:49%">
		<asp:Button ID="Anterior" runat="server" Text="Anterior"/>
	</div>
    <div class="field" align="left" style="font-size: large; float:right; width:49%">
		<asp:Button ID="Siguiente" runat="server" Text="Suiguiente"/>
	</div>
</div>
</asp:Content>
