﻿<%@ Control Language="C#" %>
<img src="/TestSite/error.png" style="width: 7em; height: 7em" title="<%= Html.Encode(ViewData["Message"].ToString()) %>" alt="error" />