gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.notifications.common.gx0090",!1,function(){var n,t;this.ServerClass="wwpbaseobjects.notifications.common.gx0090";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.notifications.common.gx0090.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV12pWWPNotificationId=gx.fn.getIntegerValue("vPWWPNOTIFICATIONID",",")};this.e165i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e115i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("WWPNOTIFICATIONIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("WWPNOTIFICATIONIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCWWPNOTIFICATIONID","Visible",!0)):(gx.fn.setCtrlProperty("WWPNOTIFICATIONIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCWWPNOTIFICATIONID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONIDFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPNOTIFICATIONID","Visible")',ctrl:"vCWWPNOTIFICATIONID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e125i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCWWPNOTIFICATIONDEFINITIONID","Visible",!0)):(gx.fn.setCtrlProperty("WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCWWPNOTIFICATIONDEFINITIONID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:"vCWWPNOTIFICATIONDEFINITIONID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e135i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("WWPNOTIFICATIONICONFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("WWPNOTIFICATIONICONFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCWWPNOTIFICATIONICON","Visible",!0)):(gx.fn.setCtrlProperty("WWPNOTIFICATIONICONFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCWWPNOTIFICATIONICON","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONICONFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONICONFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPNOTIFICATIONICON","Visible")',ctrl:"vCWWPNOTIFICATIONICON",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e145i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("WWPNOTIFICATIONISREADFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("WWPNOTIFICATIONISREADFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCWWPNOTIFICATIONISREAD","Visible",!0)):(gx.fn.setCtrlProperty("WWPNOTIFICATIONISREADFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCWWPNOTIFICATIONISREAD","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONISREADFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONISREADFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPNOTIFICATIONISREAD","Visible")',ctrl:"vCWWPNOTIFICATIONISREAD",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e155i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("WWPUSEREXTENDEDIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("WWPUSEREXTENDEDIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCWWPUSEREXTENDEDID","Visible",!0)):(gx.fn.setCtrlProperty("WWPUSEREXTENDEDIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCWWPUSEREXTENDEDID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("WWPUSEREXTENDEDIDFILTERCONTAINER","Class")',ctrl:"WWPUSEREXTENDEDIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPUSEREXTENDEDID","Visible")',ctrl:"vCWWPUSEREXTENDEDID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e195i2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e205i1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,75,76,77,78,79,80,81,82];this.GXLastCtrlId=82;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",74,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.notifications.common.gx0090",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",75,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(22,76,"WWPNOTIFICATIONID","Id","","WWPNotificationId","int",0,"px",10,10,"end",null,[],22,"WWPNotificationId",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(23,77,"WWPNOTIFICATIONDEFINITIONID","Notification Definition Id","","WWPNotificationDefinitionId","int",0,"px",10,10,"end",null,[],23,"WWPNotificationDefinitionId",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(24,78,"WWPNOTIFICATIONCREATED","Created Date","","WWPNotificationCreated","dtime",0,"px",27,26,"end",null,[],24,"WWPNotificationCreated",!0,12,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addCheckBox(82,79,"WWPNOTIFICATIONISREAD","Is Read","","WWPNotificationIsRead","boolean","true","false",null,!0,!1,0,"px","WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"WWPNOTIFICATIONIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLWWPNOTIFICATIONIDFILTER",format:1,grid:0,evt:"e115i1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCWWPNOTIFICATIONID",fmt:0,gxz:"ZV6cWWPNotificationId",gxold:"OV6cWWPNotificationId",gxvar:"AV6cWWPNotificationId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cWWPNotificationId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cWWPNotificationId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCWWPNOTIFICATIONID",gx.O.AV6cWWPNotificationId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cWWPNotificationId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCWWPNOTIFICATIONID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLWWPNOTIFICATIONDEFINITIONIDFILTER",format:1,grid:0,evt:"e125i1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCWWPNOTIFICATIONDEFINITIONID",fmt:0,gxz:"ZV7cWWPNotificationDefinitionId",gxold:"OV7cWWPNotificationDefinitionId",gxvar:"AV7cWWPNotificationDefinitionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cWWPNotificationDefinitionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cWWPNotificationDefinitionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCWWPNOTIFICATIONDEFINITIONID",gx.O.AV7cWWPNotificationDefinitionId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cWWPNotificationDefinitionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCWWPNOTIFICATIONDEFINITIONID",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"WWPNOTIFICATIONCREATEDFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLWWPNOTIFICATIONCREATEDFILTER",format:1,grid:0,ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"dtime",len:10,dec:12,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCWWPNOTIFICATIONCREATED",fmt:0,gxz:"ZV8cWWPNotificationCreated",gxold:"OV8cWWPNotificationCreated",gxvar:"AV8cWWPNotificationCreated",dp:{f:-1,st:!0,wn:!1,mf:!0,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cWWPNotificationCreated=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cWWPNotificationCreated=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCWWPNOTIFICATIONCREATED",gx.O.AV8cWWPNotificationCreated,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cWWPNotificationCreated=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("vCWWPNOTIFICATIONCREATED")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"WWPNOTIFICATIONICONFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLWWPNOTIFICATIONICONFILTER",format:1,grid:0,evt:"e135i1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCWWPNOTIFICATIONICON",fmt:0,gxz:"ZV9cWWPNotificationIcon",gxold:"OV9cWWPNotificationIcon",gxvar:"AV9cWWPNotificationIcon",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cWWPNotificationIcon=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cWWPNotificationIcon=n)},v2c:function(){gx.fn.setControlValue("vCWWPNOTIFICATIONICON",gx.O.AV9cWWPNotificationIcon,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cWWPNotificationIcon=this.val())},val:function(){return gx.fn.getControlValue("vCWWPNOTIFICATIONICON")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"WWPNOTIFICATIONISREADFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLWWPNOTIFICATIONISREADFILTER",format:1,grid:0,evt:"e145i1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCWWPNOTIFICATIONISREAD",fmt:0,gxz:"ZV10cWWPNotificationIsRead",gxold:"OV10cWWPNotificationIsRead",gxvar:"AV10cWWPNotificationIsRead",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV10cWWPNotificationIsRead=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10cWWPNotificationIsRead=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vCWWPNOTIFICATIONISREAD",gx.O.AV10cWWPNotificationIsRead,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cWWPNotificationIsRead=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vCWWPNOTIFICATIONISREAD")},nac:gx.falseFn,values:["true","false"]};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"WWPUSEREXTENDEDIDFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLWWPUSEREXTENDEDIDFILTER",format:1,grid:0,evt:"e155i1_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCWWPUSEREXTENDEDID",fmt:0,gxz:"ZV11cWWPUserExtendedId",gxold:"OV11cWWPUserExtendedId",gxvar:"AV11cWWPUserExtendedId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cWWPUserExtendedId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11cWWPUserExtendedId=n)},v2c:function(){gx.fn.setControlValue("vCWWPUSEREXTENDEDID",gx.O.AV11cWWPUserExtendedId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cWWPUserExtendedId=this.val())},val:function(){return gx.fn.getControlValue("vCWWPUSEREXTENDEDID")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"GRIDTABLE",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTNTOGGLE",grid:0,evt:"e165i1_client"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[75]={id:75,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(74),gx.O.AV5LinkSelection,gx.O.AV14Linkselection_GXI)},c2v:function(n){gx.O.AV14Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(74))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(74))},gxvar_GXI:"AV14Linkselection_GXI",nac:gx.falseFn};n[76]={id:76,lvl:2,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONID",fmt:0,gxz:"Z22WWPNotificationId",gxold:"O22WWPNotificationId",gxvar:"A22WWPNotificationId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A22WWPNotificationId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z22WWPNotificationId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("WWPNOTIFICATIONID",n||gx.fn.currentGridRowImpl(74),gx.O.A22WWPNotificationId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A22WWPNotificationId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("WWPNOTIFICATIONID",n||gx.fn.currentGridRowImpl(74),",")},nac:gx.falseFn};n[77]={id:77,lvl:2,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONID",fmt:0,gxz:"Z23WWPNotificationDefinitionId",gxold:"O23WWPNotificationDefinitionId",gxvar:"A23WWPNotificationDefinitionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A23WWPNotificationDefinitionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z23WWPNotificationDefinitionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("WWPNOTIFICATIONDEFINITIONID",n||gx.fn.currentGridRowImpl(74),gx.O.A23WWPNotificationDefinitionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A23WWPNotificationDefinitionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("WWPNOTIFICATIONDEFINITIONID",n||gx.fn.currentGridRowImpl(74),",")},nac:gx.falseFn};n[78]={id:78,lvl:2,type:"dtime",len:10,dec:12,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONCREATED",fmt:0,gxz:"Z24WWPNotificationCreated",gxold:"O24WWPNotificationCreated",gxvar:"A24WWPNotificationCreated",dp:{f:0,st:!0,wn:!1,mf:!0,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A24WWPNotificationCreated=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z24WWPNotificationCreated=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("WWPNOTIFICATIONCREATED",n||gx.fn.currentGridRowImpl(74),gx.O.A24WWPNotificationCreated,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A24WWPNotificationCreated=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("WWPNOTIFICATIONCREATED",n||gx.fn.currentGridRowImpl(74))},nac:gx.falseFn};n[79]={id:79,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONISREAD",fmt:0,gxz:"Z82WWPNotificationIsRead",gxold:"O82WWPNotificationIsRead",gxvar:"A82WWPNotificationIsRead",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A82WWPNotificationIsRead=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z82WWPNotificationIsRead=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("WWPNOTIFICATIONISREAD",n||gx.fn.currentGridRowImpl(74),gx.O.A82WWPNotificationIsRead,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A82WWPNotificationIsRead=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("WWPNOTIFICATIONISREAD",n||gx.fn.currentGridRowImpl(74))},nac:gx.falseFn,values:["true","false"]};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"BTN_CANCEL",grid:0,evt:"e205i1_client"};this.AV6cWWPNotificationId=0;this.ZV6cWWPNotificationId=0;this.OV6cWWPNotificationId=0;this.AV7cWWPNotificationDefinitionId=0;this.ZV7cWWPNotificationDefinitionId=0;this.OV7cWWPNotificationDefinitionId=0;this.AV8cWWPNotificationCreated=gx.date.nullDate();this.ZV8cWWPNotificationCreated=gx.date.nullDate();this.OV8cWWPNotificationCreated=gx.date.nullDate();this.AV9cWWPNotificationIcon="";this.ZV9cWWPNotificationIcon="";this.OV9cWWPNotificationIcon="";this.AV10cWWPNotificationIsRead=!1;this.ZV10cWWPNotificationIsRead=!1;this.OV10cWWPNotificationIsRead=!1;this.AV11cWWPUserExtendedId="";this.ZV11cWWPUserExtendedId="";this.OV11cWWPUserExtendedId="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z22WWPNotificationId=0;this.O22WWPNotificationId=0;this.Z23WWPNotificationDefinitionId=0;this.O23WWPNotificationDefinitionId=0;this.Z24WWPNotificationCreated=gx.date.nullDate();this.O24WWPNotificationCreated=gx.date.nullDate();this.Z82WWPNotificationIsRead=!1;this.O82WWPNotificationIsRead=!1;this.AV6cWWPNotificationId=0;this.AV7cWWPNotificationDefinitionId=0;this.AV8cWWPNotificationCreated=gx.date.nullDate();this.AV9cWWPNotificationIcon="";this.AV10cWWPNotificationIsRead=!1;this.AV11cWWPUserExtendedId="";this.AV12pWWPNotificationId=0;this.A7WWPUserExtendedId="";this.A76WWPNotificationIcon="";this.AV5LinkSelection="";this.A22WWPNotificationId=0;this.A23WWPNotificationDefinitionId=0;this.A24WWPNotificationCreated=gx.date.nullDate();this.A82WWPNotificationIsRead=!1;this.Events={e195i2_client:["ENTER",!0],e205i1_client:["CANCEL",!0],e165i1_client:["'TOGGLE'",!1],e115i1_client:["LBLWWPNOTIFICATIONIDFILTER.CLICK",!1],e125i1_client:["LBLWWPNOTIFICATIONDEFINITIONIDFILTER.CLICK",!1],e135i1_client:["LBLWWPNOTIFICATIONICONFILTER.CLICK",!1],e145i1_client:["LBLWWPNOTIFICATIONISREADFILTER.CLICK",!1],e155i1_client:["LBLWWPUSEREXTENDEDIDFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cWWPNotificationId",fld:"vCWWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"},{av:"AV7cWWPNotificationDefinitionId",fld:"vCWWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"AV8cWWPNotificationCreated",fld:"vCWWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"},{av:"AV9cWWPNotificationIcon",fld:"vCWWPNOTIFICATIONICON",pic:""},{av:"AV11cWWPUserExtendedId",fld:"vCWWPUSEREXTENDEDID",pic:""},{av:"AV10cWWPNotificationIsRead",fld:"vCWWPNOTIFICATIONISREAD",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLWWPNOTIFICATIONIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONIDFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONIDFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPNOTIFICATIONID","Visible")',ctrl:"vCWWPNOTIFICATIONID",prop:"Visible"}]];this.EvtParms["LBLWWPNOTIFICATIONDEFINITIONIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:"vCWWPNOTIFICATIONDEFINITIONID",prop:"Visible"}]];this.EvtParms["LBLWWPNOTIFICATIONICONFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONICONFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONICONFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONICONFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONICONFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPNOTIFICATIONICON","Visible")',ctrl:"vCWWPNOTIFICATIONICON",prop:"Visible"}]];this.EvtParms["LBLWWPNOTIFICATIONISREADFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONISREADFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONISREADFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONISREADFILTERCONTAINER","Class")',ctrl:"WWPNOTIFICATIONISREADFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPNOTIFICATIONISREAD","Visible")',ctrl:"vCWWPNOTIFICATIONISREAD",prop:"Visible"}]];this.EvtParms["LBLWWPUSEREXTENDEDIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("WWPUSEREXTENDEDIDFILTERCONTAINER","Class")',ctrl:"WWPUSEREXTENDEDIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("WWPUSEREXTENDEDIDFILTERCONTAINER","Class")',ctrl:"WWPUSEREXTENDEDIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCWWPUSEREXTENDEDID","Visible")',ctrl:"vCWWPUSEREXTENDEDID",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A22WWPNotificationId",fld:"WWPNOTIFICATIONID",pic:"ZZZZZZZZZ9",hsh:!0}],[{av:"AV12pWWPNotificationId",fld:"vPWWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cWWPNotificationId",fld:"vCWWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"},{av:"AV7cWWPNotificationDefinitionId",fld:"vCWWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"AV8cWWPNotificationCreated",fld:"vCWWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"},{av:"AV9cWWPNotificationIcon",fld:"vCWWPNOTIFICATIONICON",pic:""},{av:"AV11cWWPUserExtendedId",fld:"vCWWPUSEREXTENDEDID",pic:""},{av:"AV10cWWPNotificationIsRead",fld:"vCWWPNOTIFICATIONISREAD",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cWWPNotificationId",fld:"vCWWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"},{av:"AV7cWWPNotificationDefinitionId",fld:"vCWWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"AV8cWWPNotificationCreated",fld:"vCWWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"},{av:"AV9cWWPNotificationIcon",fld:"vCWWPNOTIFICATIONICON",pic:""},{av:"AV11cWWPUserExtendedId",fld:"vCWWPUSEREXTENDEDID",pic:""},{av:"AV10cWWPNotificationIsRead",fld:"vCWWPNOTIFICATIONISREAD",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cWWPNotificationId",fld:"vCWWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"},{av:"AV7cWWPNotificationDefinitionId",fld:"vCWWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"AV8cWWPNotificationCreated",fld:"vCWWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"},{av:"AV9cWWPNotificationIcon",fld:"vCWWPNOTIFICATIONICON",pic:""},{av:"AV11cWWPUserExtendedId",fld:"vCWWPUSEREXTENDEDID",pic:""},{av:"AV10cWWPNotificationIsRead",fld:"vCWWPNOTIFICATIONISREAD",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cWWPNotificationId",fld:"vCWWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"},{av:"AV7cWWPNotificationDefinitionId",fld:"vCWWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"AV8cWWPNotificationCreated",fld:"vCWWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"},{av:"AV9cWWPNotificationIcon",fld:"vCWWPNOTIFICATIONICON",pic:""},{av:"AV11cWWPUserExtendedId",fld:"vCWWPUSEREXTENDEDID",pic:""},{av:"AV10cWWPNotificationIsRead",fld:"vCWWPNOTIFICATIONISREAD",pic:""}],[]];this.setVCMap("AV12pWWPNotificationId","vPWWPNOTIFICATIONID",0,"int",10,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpbaseobjects.notifications.common.gx0090)})