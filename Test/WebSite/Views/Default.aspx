﻿<%@ Page Language="C#" MasterPageFile="~/Views/default.master" %>
<asp:Content ContentPlaceHolderID="title" runat="server">Нереальный сайт MVC</asp:Content>
<asp:Content ContentPlaceHolderID="head" runat="server">
<% Ajax.Scripts.Include("~/resources/scripts/jquery.js");
   Ajax.Scripts.Block("onload").Append(() => { %> alert("maza-faza"); <% }); %>
   <style type="text/css" media="all">
	input[type=button], 
	input[type=submit],
	button {
		-moz-border-radius: 4px;
		-webkit-border-radius: 4px;
		-o-border-radius: 4px;
		-moz-box-shadow: 0 1px 0 rgba(255, 255, 255, 0.6), 
			0 0 0 1px rgba(255, 255, 255, 0.4) inset, 
			0 1px 0 rgba(255, 255, 255, 0.5) inset, 
			0 -5px 5px 0 rgba(255, 255, 255, 0.5) inset;
		-webkit-box-shadow: 0 1px 0 rgba(255, 255, 255, 0.6), 
			0 0 0 1px rgba(255, 255, 255, 0.4) inset, 
			0 1px 0 rgba(255, 255, 255, 0.5) inset, 
			0 -5px 5px 0 rgba(255, 255, 255, 0.5) inset;
		-o-box-shadow: 0 1px 0 rgba(255, 255, 255, 0.6), 
			0 0 0 1px rgba(255, 255, 255, 0.4) inset, 
			0 1px 0 rgba(255, 255, 255, 0.5) inset, 
			0 -5px 5px 0 rgba(255, 255, 255, 0.5) inset;
		background: #d0d0d0 url('/wahha-test/resources/button-overlay.png') repeat-x left center;
		border: 1px solid #bbb;
		color: #505050;
		font: normal 11px Verdana,Arial,Helvetica;
		text-shadow: 0 1px 0 #fff;
		padding: 2px 10px 4px;
		outline:none;
    }
    input[type=button]:hover, 
	input[type=submit]:hover,
	button:hover,
	input[type=button]:focus, 
	input[type=submit]:focus,
	button:focus {
    	border-color: #999;
    	background-color:#dadada;
    	color:#404040;
    }
    input[type=button]:active, 
	input[type=submit]:active,
	button:active {
    	border-color: #444;
    	background-color:#c5c5c5;
    	color:#555;
    	text-shadow: 0 -1px 0 #fff;
    	-moz-box-shadow: 0 1px 0 rgba(0, 0, 0, 0.2), 
    		0 0 2px 1px rgba(0, 0, 0, 0.2) inset, 
    		0 1px 2px rgba(0, 0, 0, 0.3) inset;
    	-webkit-box-shadow: 0 1px 0 rgba(0, 0, 0, 0.2), 
    		0 0 2px 1px rgba(0, 0, 0, 0.2) inset, 
    		0 1px 2px rgba(0, 0, 0, 0.3) inset;
    	-o-box-shadow: 0 1px 0 rgba(0, 0, 0, 0.2), 
    		0 0 2px 1px rgba(0, 0, 0, 0.2) inset, 
    		0 1px 2px rgba(0, 0, 0, 0.3) inset;
    }
    input[disabled],
    button[disabled],
    input[disabled]:hover,
    button[disabled]:hover,
    input[disabled]:active,
    button[disabled]:active {
    	background-color:#dadada;
    	border-color: #ccc;
    	color: #999;
    	text-shadow: 0 1px 0 #fff;
    	-moz-box-shadow: 0 1px 0 rgba(255, 255, 255, 0.7), 
    		0 0 0 1px rgba(255, 255, 255, 0.5) inset, 
    		0 1px 0 rgba(255, 255, 255, 0.6) inset;
		-webkit-box-shadow: 0 1px 0 rgba(255, 255, 255, 0.7), 
			0 0 0 1px rgba(255, 255, 255, 0.5) inset, 
			0 1px 0 rgba(255, 255, 255, 0.6) inset;
		-o-box-shadow: 0 1px 0 rgba(255, 255, 255, 0.7), 
			0 0 0 1px rgba(255, 255, 255, 0.5) inset, 
			0 1px 0 rgba(255, 255, 255, 0.6) inset;
    }
    .button-box {
    	margin: 15px 0;
    	border:1px solid #ddd;
    	padding: 15px;
    	background-color: #f4f4f4;
    }
    input.huge-button {
    	font-size:14px;
    	padding: 5px 15px 7px;
    }
   </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server">
    <div>
        &#8594;<a href="<%= Url.Route<MainController>(p => p.Section("caitlin-ryan", MainController.SectionType.Simple)) %>">Новости, однако</a>.
    </div>
	<div class="button-box">
		<input type="submit" value="Сохранить" class="huge-button" />
		<input type="button" value="Отменить" />
		<input type="button" value="Вернуться" disabled="disabled" />
	</div>
    <%= Html.Templates.Display("this") %>
    <% Html.Component<MegaController>(a => a.MessagesAsync(10)); %>
    <% Html.Component<MegaController>(a => a.SimpleAction()); %>
    <% Html.Component<SmallComponent>(a => a.WriteMessage("Мегакомпонент")); %>
    <% Html.Component<MainController>(a => a.SampleComponent(new Section("Maza"))); %>
</asp:Content>