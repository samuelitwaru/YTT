using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class details : GXDataArea
   {
      public details( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public details( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           long aP1_LeaveRequestId )
      {
         this.AV11TrnMode = aP0_TrnMode;
         this.AV15LeaveRequestId = aP1_LeaveRequestId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         radavLeaverequest_leavetypevacationleave = new GXRadio();
         cmbavLeaverequest_leaverequeststatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV11TrnMode = gxfirstwebparm;
               AssignAttri("", false, "AV11TrnMode", AV11TrnMode);
               GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV15LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV15LeaveRequestId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "leavedetailspopup_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA4M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4M2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 312140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 312140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 312140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 312140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 312140), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 312140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("details.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11TrnMode)),UrlEncode(StringUtil.LTrimStr(AV15LeaveRequestId,10,0))}, new string[] {"TrnMode","LeaveRequestId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Leaverequest", AV8LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Leaverequest", AV8LeaveRequest);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Employee", AV16Employee);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Employee", AV16Employee);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVEREQUEST", AV8LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVEREQUEST", AV8LeaveRequest);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEE", AV16Employee);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEE", AV16Employee);
         }
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4M2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("details.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11TrnMode)),UrlEncode(StringUtil.LTrimStr(AV15LeaveRequestId,10,0))}, new string[] {"TrnMode","LeaveRequestId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Details" ;
      }

      public override string GetPgmdesc( )
      {
         return "Details" ;
      }

      protected void WB4M0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeename_Internalname, "Employee Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeename_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Employeename), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeename, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeename_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavLeaverequest_leavetypevacationleave_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Leave Type Vacation Leave", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leavetypevacationleave, radavLeaverequest_leavetypevacationleave_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leavetypevacationleave), "", 1, radavLeaverequest_leavetypevacationleave.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leavetypevacationleave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leavetypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leavetypename_Internalname, "Leave Type Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leavetypename_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leavetypename), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Leavetypename, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leavetypename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leavetypename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestdate_Internalname, "Request Date", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestdate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequestdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Details.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequeststartdate_Internalname, "Start Date", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequeststartdate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequeststartdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequeststartdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequeststartdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Details.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestenddate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestenddate_Internalname, "End Date", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestenddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestenddate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestenddate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestenddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestenddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequestenddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Details.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestduration_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestduration_Internalname, "Request Duration", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestduration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8LeaveRequest.gxTpr_Leaverequestduration, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_leaverequestduration_Enabled!=0) ? context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestduration, "Z9.9") : context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestduration, "Z9.9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestduration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leaverequestduration_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLeaverequest_leaverequeststatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLeaverequest_leaverequeststatus_Internalname, "Request Status", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLeaverequest_leaverequeststatus, cmbavLeaverequest_leaverequeststatus_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus), 1, cmbavLeaverequest_leaverequeststatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavLeaverequest_leaverequeststatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_Details.htm");
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", (string)(cmbavLeaverequest_leaverequeststatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestdescription_Internalname, "Request Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestdescription_Internalname, AV8LeaveRequest.gxTpr_Leaverequestdescription, "", "", 0, 1, edtavLeaverequest_leaverequestdescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestrejectionreason_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Rejection Reason", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, AV8LeaveRequest.gxTpr_Leaverequestrejectionreason, "", "", 0, 1, edtavLeaverequest_leaverequestrejectionreason_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployee_employeebalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployee_employeebalance_Internalname, "Vacation Days Left", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavEmployee_employeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Employee.gxTpr_Employeebalance), 4, 0, ".", "")), StringUtil.LTrim( ((edtavEmployee_employeebalance_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16Employee.gxTpr_Employeebalance), "ZZZ9") : context.localUtil.Format( (decimal)(AV16Employee.gxTpr_Employeebalance), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_employeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployee_employeebalance_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnapprovebutton_Internalname, "", "Approve", bttBtnapprovebutton_Jsonclick, 5, "Approve", "", StyleString, ClassString, bttBtnapprovebutton_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOAPPROVEBUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leavetypeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leavetypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leavetypeid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4M2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_6-177934", 0) ;
            }
         }
         Form.Meta.addItem("description", "Details", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4M0( ) ;
      }

      protected void WS4M2( )
      {
         START4M2( ) ;
         EVT4M2( ) ;
      }

      protected void EVT4M2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E114M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E124M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOAPPROVEBUTTON'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoApproveButton' */
                              E134M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E144M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4M2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA4M2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavLeaverequest_employeename_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV8LeaveRequest.gxTpr_Leaverequeststatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", cmbavLeaverequest_leaverequeststatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         radavLeaverequest_leavetypevacationleave.Enabled = 0;
         AssignProp("", false, radavLeaverequest_leavetypevacationleave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leavetypevacationleave.Enabled), 5, 0), true);
         edtavLeaverequest_leavetypename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leavetypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
         cmbavLeaverequest_leaverequeststatus.Enabled = 0;
         AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLeaverequest_leaverequeststatus.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
         edtavEmployee_employeebalance_Enabled = 0;
         AssignProp("", false, edtavEmployee_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeebalance_Enabled), 5, 0), true);
      }

      protected void RF4M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E124M2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E144M2 ();
            WB4M0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4M2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         radavLeaverequest_leavetypevacationleave.Enabled = 0;
         AssignProp("", false, radavLeaverequest_leavetypevacationleave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leavetypevacationleave.Enabled), 5, 0), true);
         edtavLeaverequest_leavetypename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leavetypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
         cmbavLeaverequest_leaverequeststatus.Enabled = 0;
         AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLeaverequest_leaverequeststatus.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
         edtavEmployee_employeebalance_Enabled = 0;
         AssignProp("", false, edtavEmployee_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeebalance_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLEAVEREQUEST"), AV8LeaveRequest);
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEE"), AV16Employee);
            ajax_req_read_hidden_sdt(cgiGet( "Leaverequest"), AV8LeaveRequest);
            ajax_req_read_hidden_sdt(cgiGet( "Employee"), AV16Employee);
            /* Read saved values. */
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            /* Read variables values. */
            AV8LeaveRequest.gxTpr_Employeename = cgiGet( edtavLeaverequest_employeename_Internalname);
            AV8LeaveRequest.gxTpr_Leavetypevacationleave = cgiGet( radavLeaverequest_leavetypevacationleave_Internalname);
            AV8LeaveRequest.gxTpr_Leavetypename = cgiGet( edtavLeaverequest_leavetypename_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestdate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 1);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Start Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequeststartdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequeststartdate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequeststartdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 1);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request End Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTENDDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestenddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestenddate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestenddate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 1);
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTDURATION");
               GX_FocusControl = edtavLeaverequest_leaverequestduration_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestduration = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestduration = context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",");
            }
            cmbavLeaverequest_leaverequeststatus.CurrentValue = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequestdescription = cgiGet( edtavLeaverequest_leaverequestdescription_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequestrejectionreason = cgiGet( edtavLeaverequest_leaverequestrejectionreason_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployee_employeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployee_employeebalance_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEE_EMPLOYEEBALANCE");
               GX_FocusControl = edtavEmployee_employeebalance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16Employee.gxTpr_Employeebalance = 0;
            }
            else
            {
               AV16Employee.gxTpr_Employeebalance = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmployee_employeebalance_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTID");
               GX_FocusControl = edtavLeaverequest_leaverequestid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestid = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leavetypeid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leavetypeid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVETYPEID");
               GX_FocusControl = edtavLeaverequest_leavetypeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leavetypeid = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavLeaverequest_leavetypeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E114M2 ();
         if (returnInSub) return;
      }

      protected void E114M2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8LeaveRequest.Load(AV15LeaveRequestId);
         AV16Employee.Load(AV8LeaveRequest.gxTpr_Employeeid);
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV12LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Insert") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Update") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "INS") != 0 )
            {
               AV8LeaveRequest.Load(AV15LeaveRequestId);
               AV12LoadSuccess = AV8LeaveRequest.Success();
               if ( ! AV12LoadSuccess )
               {
                  AV10Messages = AV8LeaveRequest.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) )
               {
               }
            }
         }
         else
         {
            AV12LoadSuccess = false;
            CallWebObject(formatLink("gamnotauthorized.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( AV12LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirm deletion.");
            }
         }
         edtavLeaverequest_leaverequestid_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestid_Visible), 5, 0), true);
         edtavLeaverequest_leavetypeid_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leavetypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypeid_Visible), 5, 0), true);
      }

      protected void E124M2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E134M2( )
      {
         /* 'DoApproveButton' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8LeaveRequest.gxTpr_Leaverequeststatus, "Approved") == 0 )
         {
            GX_msglist.addItem("Leave request is aready approved");
         }
         else
         {
            AV8LeaveRequest.gxTpr_Leaverequeststatus = "Approved";
            if ( AV8LeaveRequest.Update() )
            {
               AV17LeaveType.Load(AV8LeaveRequest.gxTpr_Leavetypeid);
               if ( StringUtil.StrCmp(AV17LeaveType.gxTpr_Leavetypevacationleave, "Yes") == 0 )
               {
                  AV16Employee.gxTpr_Employeebalance = (short)(AV16Employee.gxTpr_Employeebalance-AV8LeaveRequest.gxTpr_Leaverequestduration);
               }
               if ( AV16Employee.Update() )
               {
                  GXt_char1 = AV17LeaveType.gxTpr_Leavetypename + " approved";
                  GXt_char2 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Approved</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV16Employee.gxTpr_Employeename + ",</p>" + "<p>We are pleased to inform you that your leave request has been approved. </p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV8LeaveRequest.gxTpr_Leaverequeststartdate, 1, "/") + "</b></p>" + "<p>End Date: <b>" + context.localUtil.DToC( AV8LeaveRequest.gxTpr_Leaverequestenddate, 1, "/") + "</b></p>" + "<p>Description: <b>" + AV8LeaveRequest.gxTpr_Leaverequestdescription + "</b></p><p>If you have any questions or need further assistance, please do not hesitate to contact us.</p><p>Best Regards,</p><p>Yukon Time Tracker Team</p></div></div>";
                  new sendemail(context).executeSubmit(  AV16Employee.gxTpr_Employeeemail, ref  GXt_char1, ref  GXt_char2) ;
                  context.CommitDataStores("details",pr_default);
                  GX_msglist.addItem("Leave Approved Successfully");
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
               else
               {
                  context.RollbackDataStores("details",pr_default);
               }
            }
            else
            {
               context.RollbackDataStores("details",pr_default);
               GX_msglist.addItem("Error!");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16Employee", AV16Employee);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( new userhasrole(context).executeUdp(  "Manager") && ! ( StringUtil.StrCmp(AV8LeaveRequest.gxTpr_Leaverequeststatus, "Approved") == 0 ) ) )
         {
            bttBtnapprovebutton_Visible = 0;
            AssignProp("", false, bttBtnapprovebutton_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnapprovebutton_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV31GXV14 = 1;
         while ( AV31GXV14 <= AV10Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV10Messages.Item(AV31GXV14));
            GX_msglist.addItem(AV9Message.gxTpr_Description);
            AV31GXV14 = (int)(AV31GXV14+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E144M2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV11TrnMode", AV11TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         AV15LeaveRequestId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV15LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV15LeaveRequestId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA4M2( ) ;
         WS4M2( ) ;
         WE4M2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20246189543098", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("details.js", "?20246189543099", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         radavLeaverequest_leavetypevacationleave.Name = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         radavLeaverequest_leavetypevacationleave.WebTags = "";
         radavLeaverequest_leavetypevacationleave.addItem("No", "No", 0);
         radavLeaverequest_leavetypevacationleave.addItem("Yes", "Yes", 0);
         cmbavLeaverequest_leaverequeststatus.Name = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         cmbavLeaverequest_leaverequeststatus.WebTags = "";
         cmbavLeaverequest_leaverequeststatus.addItem("Pending", "Pending", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Approved", "Approved", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Rejected", "Rejected", 0);
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV8LeaveRequest.gxTpr_Leaverequeststatus);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavLeaverequest_employeename_Internalname = "LEAVEREQUEST_EMPLOYEENAME";
         radavLeaverequest_leavetypevacationleave_Internalname = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         edtavLeaverequest_leavetypename_Internalname = "LEAVEREQUEST_LEAVETYPENAME";
         edtavLeaverequest_leaverequestdate_Internalname = "LEAVEREQUEST_LEAVEREQUESTDATE";
         edtavLeaverequest_leaverequeststartdate_Internalname = "LEAVEREQUEST_LEAVEREQUESTSTARTDATE";
         edtavLeaverequest_leaverequestenddate_Internalname = "LEAVEREQUEST_LEAVEREQUESTENDDATE";
         edtavLeaverequest_leaverequestduration_Internalname = "LEAVEREQUEST_LEAVEREQUESTDURATION";
         cmbavLeaverequest_leaverequeststatus_Internalname = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         edtavLeaverequest_leaverequestdescription_Internalname = "LEAVEREQUEST_LEAVEREQUESTDESCRIPTION";
         edtavLeaverequest_leaverequestrejectionreason_Internalname = "LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON";
         edtavEmployee_employeebalance_Internalname = "EMPLOYEE_EMPLOYEEBALANCE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtncancel_Internalname = "BTNCANCEL";
         bttBtnapprovebutton_Internalname = "BTNAPPROVEBUTTON";
         divTablemain_Internalname = "TABLEMAIN";
         edtavLeaverequest_leaverequestid_Internalname = "LEAVEREQUEST_LEAVEREQUESTID";
         edtavLeaverequest_leavetypeid_Internalname = "LEAVEREQUEST_LEAVETYPEID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavEmployee_employeebalance_Enabled = -1;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = -1;
         edtavLeaverequest_leaverequestdescription_Enabled = -1;
         cmbavLeaverequest_leaverequeststatus.Enabled = -1;
         edtavLeaverequest_leaverequestduration_Enabled = -1;
         edtavLeaverequest_leaverequestenddate_Enabled = -1;
         edtavLeaverequest_leaverequeststartdate_Enabled = -1;
         edtavLeaverequest_leaverequestdate_Enabled = -1;
         edtavLeaverequest_leavetypename_Enabled = -1;
         edtavLeaverequest_employeename_Enabled = -1;
         edtavLeaverequest_leavetypeid_Jsonclick = "";
         edtavLeaverequest_leavetypeid_Visible = 1;
         edtavLeaverequest_leaverequestid_Jsonclick = "";
         edtavLeaverequest_leaverequestid_Visible = 1;
         bttBtnapprovebutton_Visible = 1;
         edtavEmployee_employeebalance_Jsonclick = "";
         edtavEmployee_employeebalance_Enabled = 0;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         cmbavLeaverequest_leaverequeststatus_Jsonclick = "";
         cmbavLeaverequest_leaverequeststatus.Enabled = 0;
         edtavLeaverequest_leaverequestduration_Jsonclick = "";
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         edtavLeaverequest_leaverequestenddate_Jsonclick = "";
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         edtavLeaverequest_leaverequeststartdate_Jsonclick = "";
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         edtavLeaverequest_leaverequestdate_Jsonclick = "";
         edtavLeaverequest_leaverequestdate_Enabled = 0;
         edtavLeaverequest_leavetypename_Jsonclick = "";
         edtavLeaverequest_leavetypename_Enabled = 0;
         radavLeaverequest_leavetypevacationleave_Jsonclick = "";
         radavLeaverequest_leavetypevacationleave.Enabled = 1;
         edtavLeaverequest_employeename_Jsonclick = "";
         edtavLeaverequest_employeename_Enabled = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Details";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''},{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'BTNAPPROVEBUTTON',prop:'Visible'}]}");
         setEventMetadata("'DOAPPROVEBUTTON'","{handler:'E134M2',iparms:[{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'AV16Employee',fld:'vEMPLOYEE',pic:''}]");
         setEventMetadata("'DOAPPROVEBUTTON'",",oparms:[{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'AV16Employee',fld:'vEMPLOYEE',pic:''}]}");
         setEventMetadata("VALIDV_GXV8","{handler:'Validv_Gxv8',iparms:[]");
         setEventMetadata("VALIDV_GXV8",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         wcpOAV11TrnMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV8LeaveRequest = new SdtLeaveRequest(context);
         AV16Employee = new SdtEmployee(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         bttBtncancel_Jsonclick = "";
         bttBtnapprovebutton_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17LeaveType = new SdtLeaveType(context);
         GXt_char1 = "";
         GXt_char2 = "";
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.details__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.details__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavLeaverequest_employeename_Enabled = 0;
         radavLeaverequest_leavetypevacationleave.Enabled = 0;
         edtavLeaverequest_leavetypename_Enabled = 0;
         edtavLeaverequest_leaverequestdate_Enabled = 0;
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         cmbavLeaverequest_leaverequeststatus.Enabled = 0;
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         edtavEmployee_employeebalance_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavLeaverequest_employeename_Enabled ;
      private int edtavLeaverequest_leavetypename_Enabled ;
      private int edtavLeaverequest_leaverequestdate_Enabled ;
      private int edtavLeaverequest_leaverequeststartdate_Enabled ;
      private int edtavLeaverequest_leaverequestenddate_Enabled ;
      private int edtavLeaverequest_leaverequestduration_Enabled ;
      private int edtavLeaverequest_leaverequestdescription_Enabled ;
      private int edtavLeaverequest_leaverequestrejectionreason_Enabled ;
      private int edtavEmployee_employeebalance_Enabled ;
      private int bttBtnapprovebutton_Visible ;
      private int edtavLeaverequest_leaverequestid_Visible ;
      private int edtavLeaverequest_leavetypeid_Visible ;
      private int AV31GXV14 ;
      private int idxLst ;
      private long AV15LeaveRequestId ;
      private long wcpOAV15LeaveRequestId ;
      private string AV11TrnMode ;
      private string wcpOAV11TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavLeaverequest_employeename_Internalname ;
      private string edtavLeaverequest_employeename_Jsonclick ;
      private string radavLeaverequest_leavetypevacationleave_Internalname ;
      private string TempTags ;
      private string radavLeaverequest_leavetypevacationleave_Jsonclick ;
      private string edtavLeaverequest_leavetypename_Internalname ;
      private string edtavLeaverequest_leavetypename_Jsonclick ;
      private string edtavLeaverequest_leaverequestdate_Internalname ;
      private string edtavLeaverequest_leaverequestdate_Jsonclick ;
      private string edtavLeaverequest_leaverequeststartdate_Internalname ;
      private string edtavLeaverequest_leaverequeststartdate_Jsonclick ;
      private string edtavLeaverequest_leaverequestenddate_Internalname ;
      private string edtavLeaverequest_leaverequestenddate_Jsonclick ;
      private string edtavLeaverequest_leaverequestduration_Internalname ;
      private string edtavLeaverequest_leaverequestduration_Jsonclick ;
      private string cmbavLeaverequest_leaverequeststatus_Internalname ;
      private string cmbavLeaverequest_leaverequeststatus_Jsonclick ;
      private string edtavLeaverequest_leaverequestdescription_Internalname ;
      private string edtavLeaverequest_leaverequestrejectionreason_Internalname ;
      private string edtavEmployee_employeebalance_Internalname ;
      private string edtavEmployee_employeebalance_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtnapprovebutton_Internalname ;
      private string bttBtnapprovebutton_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLeaverequest_leaverequestid_Internalname ;
      private string edtavLeaverequest_leaverequestid_Jsonclick ;
      private string edtavLeaverequest_leavetypeid_Internalname ;
      private string edtavLeaverequest_leavetypeid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12LoadSuccess ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXRadio radavLeaverequest_leavetypevacationleave ;
      private GXCombobox cmbavLeaverequest_leaverequeststatus ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GXWebForm Form ;
      private SdtLeaveRequest AV8LeaveRequest ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private SdtEmployee AV16Employee ;
      private SdtLeaveType AV17LeaveType ;
   }

   public class details__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class details__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
