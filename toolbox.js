gx.evt.autoSkip=!1;gx.define("toolbox",!1,function(){var t,n;this.ServerClass="toolbox";this.PackageName="GeneXus.Programs";this.ServerFullClass="toolbox.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.e125s2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e135s2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5];this.GXLastCtrlId=5;this.UCGRAPEJS1Container=gx.uc.getNew(this,6,0,"UCGrapeJS","UCGRAPEJS1Container","Ucgrapejs1","UCGRAPEJS1");n=this.UCGRAPEJS1Container;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};this.Events={e125s2_client:["ENTER",!0],e135s2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.ENTER=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(this.toolbox)})