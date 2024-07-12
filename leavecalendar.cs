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
   public class leavecalendar : GXDataArea
   {
      public leavecalendar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leavecalendar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavCompanylocationid = new GXCombobox();
         dynavProjectid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPROJECTID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPROJECTID562( ) ;
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            return "fullcalendar_Execute" ;
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
         PA562( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START562( ) ;
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
         context.AddJavascriptSource("UserControls/UCToolTipRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCVISTimelineRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leavecalendar.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISPROJECTMANAGER", AV29IsProjectManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISPROJECTMANAGER", GetSecureSignedToken( "", AV29IsProjectManager, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33Udparg1), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33Udparg1), "9999999999"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vDATERANGE", context.localUtil.DToC( AV10DateRange, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGE_TO", context.localUtil.DToC( AV16DateRange_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDATERANGE_RANGEPICKEROPTIONS", AV17DateRange_RangePickerOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDATERANGE_RANGEPICKEROPTIONS", AV17DateRange_RangePickerOptions);
         }
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25LeaveRequestId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEIDS", AV28EmployeeIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEIDS", AV28EmployeeIds);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVEEVENTS", AV6LeaveEvents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVEEVENTS", AV6LeaveEvents);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVEEVENTGROUPS", AV7LeaveEventGroups);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVEEVENTGROUPS", AV7LeaveEventGroups);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISPROJECTMANAGER", AV29IsProjectManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISPROJECTMANAGER", GetSecureSignedToken( "", AV29IsProjectManager, context));
         GxWebStd.gx_hidden_field( context, "PROJECTMANAGERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A166ProjectManagerId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33Udparg1), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33Udparg1), "9999999999"), context));
         GxWebStd.gx_hidden_field( context, "PROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTIDS", AV27ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTIDS", AV27ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "UCVISTIMELINE1_Events", StringUtil.RTrim( Ucvistimeline1_Events));
         GxWebStd.gx_hidden_field( context, "UCVISTIMELINE1_Groups", StringUtil.RTrim( Ucvistimeline1_Groups));
         GxWebStd.gx_hidden_field( context, "UCVISTIMELINE1_Leavetypes", StringUtil.RTrim( Ucvistimeline1_Leavetypes));
         GxWebStd.gx_hidden_field( context, "UCVISTIMELINE1_Startdate", StringUtil.RTrim( Ucvistimeline1_Startdate));
         GxWebStd.gx_hidden_field( context, "UCVISTIMELINE1_Stopdate", StringUtil.RTrim( Ucvistimeline1_Stopdate));
         GxWebStd.gx_hidden_field( context, "USERACTION1_MODAL_Width", StringUtil.RTrim( Useraction1_modal_Width));
         GxWebStd.gx_hidden_field( context, "USERACTION1_MODAL_Title", StringUtil.RTrim( Useraction1_modal_Title));
         GxWebStd.gx_hidden_field( context, "USERACTION1_MODAL_Confirmtype", StringUtil.RTrim( Useraction1_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "USERACTION1_MODAL_Bodytype", StringUtil.RTrim( Useraction1_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "UCVISTIMELINE1_Item", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucvistimeline1_Item), 9, 0, ".", "")));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE562( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT562( ) ;
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
         return formatLink("leavecalendar.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveCalendar" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Calendar" ;
      }

      protected void WB560( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 800, "px", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:3fr 20fr 20fr 20fr 37fr;grid-template-rows:auto;grid-column-gap:2px;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;align-items:center;", "div");
            /* User Defined Control */
            ucUsercontrol1.Render(context, "uctooltip", Usercontrol1_Internalname, "USERCONTROL1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableaterange_rangetext_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdaterange_rangetext_Internalname, "Date Range", "", "", lblTextblockdaterange_rangetext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_LeaveCalendar.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDaterange_rangetext_Internalname, "Date Range_Range Text", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDaterange_rangetext_Internalname, AV15DateRange_RangeText, StringUtil.RTrim( context.localUtil.Format( AV15DateRange_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDaterange_rangetext_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavDaterange_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveCalendar.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablecompanylocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcompanylocationid_Internalname, "Location", "", "", lblTextblockcompanylocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_LeaveCalendar.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCompanylocationid_Internalname, "Company Location Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCompanylocationid, dynavCompanylocationid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11CompanyLocationId), 10, 0)), 1, dynavCompanylocationid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCompanylocationid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_LeaveCalendar.htm");
            dynavCompanylocationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11CompanyLocationId), 10, 0));
            AssignProp("", false, dynavCompanylocationid_Internalname, "Values", (string)(dynavCompanylocationid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableprojectid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockprojectid_Internalname, "Project", "", "", lblTextblockprojectid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_LeaveCalendar.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProjectid_Internalname, "Project Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProjectid, dynavProjectid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26ProjectId), 10, 0)), 1, dynavProjectid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavProjectid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_LeaveCalendar.htm");
            dynavProjectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26ProjectId), 10, 0));
            AssignProp("", false, dynavProjectid_Internalname, "Values", (string)(dynavProjectid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:flex-end;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreport_Internalname, "", "Report", bttBtnreport_Jsonclick, 5, "Report", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveCalendar.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcvistimeline1.Render(context, "ucvistimeline", Ucvistimeline1_Internalname, "UCVISTIMELINE1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "", "Popup", bttBtnuseraction1_Jsonclick, 7, "Popup", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11561_client"+"'", TempTags, "", 2, "HLP_LeaveCalendar.htm");
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
            /* User Defined Control */
            ucDaterange_rangepicker.SetProperty("Start Date", AV10DateRange);
            ucDaterange_rangepicker.SetProperty("End Date", AV16DateRange_To);
            ucDaterange_rangepicker.SetProperty("PickerOptions", AV17DateRange_RangePickerOptions);
            ucDaterange_rangepicker.Render(context, "wwp.daterangepicker", Daterange_rangepicker_Internalname, "DATERANGE_RANGEPICKERContainer");
            wb_table1_54_562( true) ;
         }
         else
         {
            wb_table1_54_562( false) ;
         }
         return  ;
      }

      protected void wb_table1_54_562e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0060"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0060"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START562( )
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
         Form.Meta.addItem("description", "Leave Calendar", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP560( ) ;
      }

      protected void WS562( )
      {
         START562( ) ;
         EVT562( ) ;
      }

      protected void EVT562( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DATERANGE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "USERACTION1_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E14562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReport' */
                              E15562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPROJECTID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCOMPANYLOCATIONID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.LEAVEREQUESTSTATUSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E19562 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 60 )
                        {
                           OldWwpaux_wc = cgiGet( "W0060");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0060", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE562( )
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

      protected void PA562( )
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
               GX_FocusControl = edtavDaterange_rangetext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvCOMPANYLOCATIONID561( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCOMPANYLOCATIONID_data561( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvCOMPANYLOCATIONID_html561( )
      {
         long gxdynajaxvalue;
         GXDLVvCOMPANYLOCATIONID_data561( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCompanylocationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV11CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV11CompanyLocationId), 10, 0));
         }
      }

      protected void GXDLVvCOMPANYLOCATIONID_data561( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00562 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00562_A157CompanyLocationId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00562_A158CompanyLocationName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvPROJECTID562( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPROJECTID_data562( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvPROJECTID_html562( )
      {
         long gxdynajaxvalue;
         GXDLVvPROJECTID_data562( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProjectid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavProjectid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPROJECTID_data562( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00563 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            if ( H00563_A166ProjectManagerId[0] == new getloggedinemployeeid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00563_A102ProjectId[0]), 10, 0, ".", "")));
               gxdynajaxctrldescr.Add(StringUtil.RTrim( H00563_A103ProjectName[0]));
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvPROJECTID_html562( ) ;
            dynavCompanylocationid.Name = "vCOMPANYLOCATIONID";
            dynavCompanylocationid.WebTags = "";
            dynavCompanylocationid.removeAllItems();
            /* Using cursor H00564 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00564_A157CompanyLocationId[0]), 10, 0)), H00564_A158CompanyLocationName[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavCompanylocationid.ItemCount > 0 )
            {
               AV11CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV11CompanyLocationId), 10, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV11CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV11CompanyLocationId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCompanylocationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11CompanyLocationId), 10, 0));
            AssignProp("", false, dynavCompanylocationid_Internalname, "Values", dynavCompanylocationid.ToJavascriptSource(), true);
         }
         if ( dynavProjectid.ItemCount > 0 )
         {
            AV26ProjectId = (long)(Math.Round(NumberUtil.Val( dynavProjectid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26ProjectId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26ProjectId", StringUtil.LTrimStr( (decimal)(AV26ProjectId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProjectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26ProjectId), 10, 0));
            AssignProp("", false, dynavProjectid_Internalname, "Values", dynavProjectid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF562( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void RF562( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E19562 ();
            WB560( ) ;
         }
      }

      protected void send_integrity_lvl_hashes562( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISPROJECTMANAGER", AV29IsProjectManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISPROJECTMANAGER", GetSecureSignedToken( "", AV29IsProjectManager, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33Udparg1), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33Udparg1), "9999999999"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         GXVvPROJECTID_html562( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP560( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14562 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDATERANGE_RANGEPICKEROPTIONS"), AV17DateRange_RangePickerOptions);
            /* Read saved values. */
            AV10DateRange = context.localUtil.CToD( cgiGet( "vDATERANGE"), 0);
            AV16DateRange_To = context.localUtil.CToD( cgiGet( "vDATERANGE_TO"), 0);
            AV25LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vLEAVEREQUESTID"), ".", ","), 18, MidpointRounding.ToEven));
            Ucvistimeline1_Events = cgiGet( "UCVISTIMELINE1_Events");
            Ucvistimeline1_Groups = cgiGet( "UCVISTIMELINE1_Groups");
            Ucvistimeline1_Leavetypes = cgiGet( "UCVISTIMELINE1_Leavetypes");
            Ucvistimeline1_Startdate = cgiGet( "UCVISTIMELINE1_Startdate");
            Ucvistimeline1_Stopdate = cgiGet( "UCVISTIMELINE1_Stopdate");
            Useraction1_modal_Width = cgiGet( "USERACTION1_MODAL_Width");
            Useraction1_modal_Title = cgiGet( "USERACTION1_MODAL_Title");
            Useraction1_modal_Confirmtype = cgiGet( "USERACTION1_MODAL_Confirmtype");
            Useraction1_modal_Bodytype = cgiGet( "USERACTION1_MODAL_Bodytype");
            /* Read variables values. */
            AV15DateRange_RangeText = cgiGet( edtavDaterange_rangetext_Internalname);
            AssignAttri("", false, "AV15DateRange_RangeText", AV15DateRange_RangeText);
            dynavCompanylocationid.CurrentValue = cgiGet( dynavCompanylocationid_Internalname);
            AV11CompanyLocationId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavCompanylocationid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV11CompanyLocationId), 10, 0));
            dynavProjectid.CurrentValue = cgiGet( dynavProjectid_Internalname);
            AV26ProjectId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavProjectid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26ProjectId", StringUtil.LTrimStr( (decimal)(AV26ProjectId), 10, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvPROJECTID_html562( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E14562 ();
         if (returnInSub) return;
      }

      protected void E14562( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_int1 = AV18CompanyId;
         new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
         AV18CompanyId = GXt_int1;
         AssignAttri("", false, "AV18CompanyId", StringUtil.LTrimStr( (decimal)(AV18CompanyId), 10, 0));
         GXt_boolean2 = AV29IsProjectManager;
         new userhasrole(context ).execute(  "Project Manager", out  GXt_boolean2) ;
         AV29IsProjectManager = GXt_boolean2;
         AssignAttri("", false, "AV29IsProjectManager", AV29IsProjectManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISPROJECTMANAGER", GetSecureSignedToken( "", AV29IsProjectManager, context));
         if ( ! (0==AV18CompanyId) && ! AV29IsProjectManager )
         {
            /* Using cursor H00565 */
            pr_default.execute(3, new Object[] {AV18CompanyId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A100CompanyId = H00565_A100CompanyId[0];
               A157CompanyLocationId = H00565_A157CompanyLocationId[0];
               AV11CompanyLocationId = A157CompanyLocationId;
               AssignAttri("", false, "AV11CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV11CompanyLocationId), 10, 0));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            dynavCompanylocationid.Enabled = 0;
            AssignProp("", false, dynavCompanylocationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavCompanylocationid.Enabled), 5, 0), true);
         }
         GXt_objcol_SdtSDTLeaveType3 = AV23SDTLeaveTypes;
         new dpleavetype(context ).execute(  AV11CompanyLocationId, out  GXt_objcol_SdtSDTLeaveType3) ;
         AV23SDTLeaveTypes = GXt_objcol_SdtSDTLeaveType3;
         Ucvistimeline1_Leavetypes = AV23SDTLeaveTypes.ToJSonString(false);
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "leavetypes", Ucvistimeline1_Leavetypes);
         AV10DateRange = DateTimeUtil.DAdd( Gx_date, (-1*(DateTimeUtil.Dow( Gx_date)-1)));
         AssignAttri("", false, "AV10DateRange", context.localUtil.Format(AV10DateRange, "99/99/99"));
         AV16DateRange_To = DateTimeUtil.DAdd( AV10DateRange, (13));
         AssignAttri("", false, "AV16DateRange_To", context.localUtil.Format(AV16DateRange_To, "99/99/99"));
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_char4 = "";
         new formatdatetime(context ).execute(  AV10DateRange,  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Startdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "startDate", Ucvistimeline1_Startdate);
         GXt_char4 = "";
         new formatdatetime(context ).execute(  AV16DateRange_To,  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Stopdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "stopDate", Ucvistimeline1_Stopdate);
         Ucvistimeline1_Events = AV6LeaveEvents.ToJSonString(false);
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "events", Ucvistimeline1_Events);
         Ucvistimeline1_Groups = AV7LeaveEventGroups.ToJSonString(false);
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "groups", Ucvistimeline1_Groups);
         Ucvistimeline1_Leavetypes = AV23SDTLeaveTypes.ToJSonString(false);
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "leavetypes", Ucvistimeline1_Leavetypes);
         this.executeUsercontrolMethod("", false, "DATERANGE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDaterange_rangetext_Internalname});
         GXt_SdtWWPDateRangePickerOptions5 = AV17DateRange_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions5) ;
         AV17DateRange_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions5;
      }

      protected void E13562( )
      {
         /* Useraction1_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E15562( )
      {
         /* 'DoReport' Routine */
         returnInSub = false;
         new employeeleavereport(context ).execute(  AV11CompanyLocationId, ref  AV28EmployeeIds, ref  AV10DateRange, out  AV21ExcelFilename, out  AV20ErrorMessage) ;
         AssignAttri("", false, "AV10DateRange", context.localUtil.Format(AV10DateRange, "99/99/99"));
         if ( StringUtil.StrCmp(AV21ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV21ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV20ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28EmployeeIds", AV28EmployeeIds);
      }

      protected void E16562( )
      {
         /* Projectid_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_char4 = "";
         new formatdatetime(context ).execute(  DateTimeUtil.DAdd( AV10DateRange, (1)),  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Startdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "startDate", Ucvistimeline1_Startdate);
         GXt_char4 = "";
         new formatdatetime(context ).execute(  AV16DateRange_To,  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Stopdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "stopDate", Ucvistimeline1_Stopdate);
         this.executeUsercontrolMethod("", false, "UCVISTIMELINE1Container", "Refresh", "", new Object[] {AV6LeaveEvents.ToJSonString(false),AV7LeaveEventGroups.ToJSonString(false)});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28EmployeeIds", AV28EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ProjectIds", AV27ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6LeaveEvents", AV6LeaveEvents);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7LeaveEventGroups", AV7LeaveEventGroups);
      }

      protected void E12562( )
      {
         /* Daterange_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         if ( (DateTime.MinValue==AV10DateRange) && (DateTime.MinValue==AV16DateRange_To) )
         {
            AV10DateRange = Gx_date;
            AssignAttri("", false, "AV10DateRange", context.localUtil.Format(AV10DateRange, "99/99/99"));
            AV16DateRange_To = Gx_date;
            AssignAttri("", false, "AV16DateRange_To", context.localUtil.Format(AV16DateRange_To, "99/99/99"));
         }
         AssignAttri("", false, "AV10DateRange", context.localUtil.Format(AV10DateRange, "99/99/99"));
         AssignAttri("", false, "AV16DateRange_To", context.localUtil.Format(AV16DateRange_To, "99/99/99"));
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_char4 = "";
         new formatdatetime(context ).execute(  DateTimeUtil.DAdd( AV10DateRange, (1)),  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Startdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "startDate", Ucvistimeline1_Startdate);
         GXt_char4 = "";
         new formatdatetime(context ).execute(  AV16DateRange_To,  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Stopdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "stopDate", Ucvistimeline1_Stopdate);
         this.executeUsercontrolMethod("", false, "UCVISTIMELINE1Container", "Refresh", "", new Object[] {AV6LeaveEvents.ToJSonString(false),AV7LeaveEventGroups.ToJSonString(false)});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28EmployeeIds", AV28EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ProjectIds", AV27ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6LeaveEvents", AV6LeaveEvents);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7LeaveEventGroups", AV7LeaveEventGroups);
      }

      protected void E17562( )
      {
         /* Companylocationid_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTLeaveType3 = AV23SDTLeaveTypes;
         new dpleavetype(context ).execute(  AV11CompanyLocationId, out  GXt_objcol_SdtSDTLeaveType3) ;
         AV23SDTLeaveTypes = GXt_objcol_SdtSDTLeaveType3;
         Ucvistimeline1_Leavetypes = AV23SDTLeaveTypes.ToJSonString(false);
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "leavetypes", Ucvistimeline1_Leavetypes);
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_char4 = "";
         new formatdatetime(context ).execute(  DateTimeUtil.DAdd( AV10DateRange, (1)),  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Startdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "startDate", Ucvistimeline1_Startdate);
         GXt_char4 = "";
         new formatdatetime(context ).execute(  AV16DateRange_To,  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Stopdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "stopDate", Ucvistimeline1_Stopdate);
         this.executeUsercontrolMethod("", false, "UCVISTIMELINE1Container", "Refresh", "", new Object[] {AV6LeaveEvents.ToJSonString(false),AV7LeaveEventGroups.ToJSonString(false)});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28EmployeeIds", AV28EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ProjectIds", AV27ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6LeaveEvents", AV6LeaveEvents);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7LeaveEventGroups", AV7LeaveEventGroups);
      }

      protected void E18562( )
      {
         /* General\GlobalEvents_Leaverequeststatuschanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_char4 = "";
         new formatdatetime(context ).execute(  DateTimeUtil.DAdd( AV10DateRange, (1)),  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Startdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "startDate", Ucvistimeline1_Startdate);
         GXt_char4 = "";
         new formatdatetime(context ).execute(  AV16DateRange_To,  "YYYY-MM-DD", out  GXt_char4) ;
         Ucvistimeline1_Stopdate = GXt_char4;
         ucUcvistimeline1.SendProperty(context, "", false, Ucvistimeline1_Internalname, "stopDate", Ucvistimeline1_Stopdate);
         this.executeUsercontrolMethod("", false, "UCVISTIMELINE1Container", "Refresh", "", new Object[] {AV6LeaveEvents.ToJSonString(false),AV7LeaveEventGroups.ToJSonString(false)});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28EmployeeIds", AV28EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ProjectIds", AV27ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6LeaveEvents", AV6LeaveEvents);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7LeaveEventGroups", AV7LeaveEventGroups);
      }

      protected void S112( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         AV28EmployeeIds.Clear();
         AV27ProjectIds.Clear();
         if ( ! (0==AV26ProjectId) )
         {
            AV27ProjectIds.Add(AV26ProjectId, 0);
            GXt_objcol_int6 = AV28EmployeeIds;
            new getemployeeidsbyproject(context ).execute(  AV27ProjectIds, out  GXt_objcol_int6) ;
            AV28EmployeeIds = GXt_objcol_int6;
         }
         else
         {
            if ( AV29IsProjectManager )
            {
               /* Execute user subroutine: 'GETEMPLOYEEIDSBYPROJECT' */
               S122 ();
               if (returnInSub) return;
            }
         }
         GXt_objcol_SdtSDTLeaveEvent7 = AV6LeaveEvents;
         new dpleaveevent(context ).execute(  AV10DateRange,  AV16DateRange_To,  AV11CompanyLocationId,  AV28EmployeeIds, out  GXt_objcol_SdtSDTLeaveEvent7) ;
         AV6LeaveEvents = GXt_objcol_SdtSDTLeaveEvent7;
         GXt_objcol_SdtSDTLeaveEventGroup8 = AV7LeaveEventGroups;
         new dpleaveeventgroup(context ).execute(  AV10DateRange,  AV16DateRange_To,  AV11CompanyLocationId,  AV28EmployeeIds, out  GXt_objcol_SdtSDTLeaveEventGroup8) ;
         AV7LeaveEventGroups = GXt_objcol_SdtSDTLeaveEventGroup8;
      }

      protected void S122( )
      {
         /* 'GETEMPLOYEEIDSBYPROJECT' Routine */
         returnInSub = false;
         AV33Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor H00566 */
         pr_default.execute(4, new Object[] {AV33Udparg1});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A166ProjectManagerId = H00566_A166ProjectManagerId[0];
            n166ProjectManagerId = H00566_n166ProjectManagerId[0];
            A102ProjectId = H00566_A102ProjectId[0];
            AV27ProjectIds.Add(A102ProjectId, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         GXt_objcol_int6 = AV28EmployeeIds;
         new getemployeeidsbyproject(context ).execute(  AV27ProjectIds, out  GXt_objcol_int6) ;
         AV28EmployeeIds = GXt_objcol_int6;
      }

      protected void nextLoad( )
      {
      }

      protected void E19562( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_54_562( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableuseraction1_modal_Internalname, tblTableuseraction1_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucUseraction1_modal.SetProperty("Width", Useraction1_modal_Width);
            ucUseraction1_modal.SetProperty("Title", Useraction1_modal_Title);
            ucUseraction1_modal.SetProperty("ConfirmType", Useraction1_modal_Confirmtype);
            ucUseraction1_modal.SetProperty("BodyType", Useraction1_modal_Bodytype);
            ucUseraction1_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Useraction1_modal_Internalname, "USERACTION1_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"USERACTION1_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_54_562e( true) ;
         }
         else
         {
            wb_table1_54_562e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA562( ) ;
         WS562( ) ;
         WE562( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202471213385912", true, true);
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
         context.AddJavascriptSource("leavecalendar.js", "?202471213385913", false, true);
         context.AddJavascriptSource("UserControls/UCToolTipRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCVISTimelineRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavCompanylocationid.Name = "vCOMPANYLOCATIONID";
         dynavCompanylocationid.WebTags = "";
         dynavCompanylocationid.removeAllItems();
         /* Using cursor H00567 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00567_A157CompanyLocationId[0]), 10, 0)), H00567_A158CompanyLocationName[0], 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV11CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV11CompanyLocationId), 10, 0));
         }
         dynavProjectid.Name = "vPROJECTID";
         dynavProjectid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablecontent_Internalname = "TABLECONTENT";
         Usercontrol1_Internalname = "USERCONTROL1";
         lblTextblockdaterange_rangetext_Internalname = "TEXTBLOCKDATERANGE_RANGETEXT";
         edtavDaterange_rangetext_Internalname = "vDATERANGE_RANGETEXT";
         divUnnamedtableaterange_rangetext_Internalname = "UNNAMEDTABLEATERANGE_RANGETEXT";
         lblTextblockcompanylocationid_Internalname = "TEXTBLOCKCOMPANYLOCATIONID";
         dynavCompanylocationid_Internalname = "vCOMPANYLOCATIONID";
         divUnnamedtablecompanylocationid_Internalname = "UNNAMEDTABLECOMPANYLOCATIONID";
         lblTextblockprojectid_Internalname = "TEXTBLOCKPROJECTID";
         dynavProjectid_Internalname = "vPROJECTID";
         divUnnamedtableprojectid_Internalname = "UNNAMEDTABLEPROJECTID";
         bttBtnreport_Internalname = "BTNREPORT";
         divTable1_Internalname = "TABLE1";
         Ucvistimeline1_Internalname = "UCVISTIMELINE1";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         divMaintable_Internalname = "MAINTABLE";
         Daterange_rangepicker_Internalname = "DATERANGE_RANGEPICKER";
         Useraction1_modal_Internalname = "USERACTION1_MODAL";
         tblTableuseraction1_modal_Internalname = "TABLEUSERACTION1_MODAL";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         dynavProjectid_Jsonclick = "";
         dynavProjectid.Enabled = 1;
         dynavCompanylocationid_Jsonclick = "";
         dynavCompanylocationid.Enabled = 1;
         edtavDaterange_rangetext_Jsonclick = "";
         edtavDaterange_rangetext_Enabled = 1;
         Ucvistimeline1_Item = 0;
         Useraction1_modal_Bodytype = "WebComponent";
         Useraction1_modal_Confirmtype = "";
         Useraction1_modal_Title = "Details";
         Useraction1_modal_Width = "600";
         Ucvistimeline1_Stopdate = "";
         Ucvistimeline1_Startdate = "";
         Ucvistimeline1_Leavetypes = "";
         Ucvistimeline1_Groups = "";
         Ucvistimeline1_Events = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Leave Calendar";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynavProjectid'},{av:'AV26ProjectId',fld:'vPROJECTID',pic:'ZZZZZZZZZ9'},{av:'dynavCompanylocationid'},{av:'AV11CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:'ZZZZZZZZZ9'},{av:'AV29IsProjectManager',fld:'vISPROJECTMANAGER',pic:'',hsh:true},{av:'AV33Udparg1',fld:'vUDPARG1',pic:'9999999999',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUSERACTION1'","{handler:'E11561',iparms:[]");
         setEventMetadata("'DOUSERACTION1'",",oparms:[]}");
         setEventMetadata("USERACTION1_MODAL.CLOSE","{handler:'E13562',iparms:[]");
         setEventMetadata("USERACTION1_MODAL.CLOSE",",oparms:[]}");
         setEventMetadata("'DOREPORT'","{handler:'E15562',iparms:[{av:'dynavCompanylocationid'},{av:'AV11CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:'ZZZZZZZZZ9'},{av:'AV28EmployeeIds',fld:'vEMPLOYEEIDS',pic:''},{av:'AV10DateRange',fld:'vDATERANGE',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV10DateRange',fld:'vDATERANGE',pic:''},{av:'AV28EmployeeIds',fld:'vEMPLOYEEIDS',pic:''}]}");
         setEventMetadata("VPROJECTID.CONTROLVALUECHANGED","{handler:'E16562',iparms:[{av:'AV10DateRange',fld:'vDATERANGE',pic:''},{av:'AV16DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV6LeaveEvents',fld:'vLEAVEEVENTS',pic:''},{av:'AV7LeaveEventGroups',fld:'vLEAVEEVENTGROUPS',pic:''},{av:'dynavProjectid'},{av:'AV26ProjectId',fld:'vPROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV29IsProjectManager',fld:'vISPROJECTMANAGER',pic:'',hsh:true},{av:'dynavCompanylocationid'},{av:'AV11CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:'ZZZZZZZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV33Udparg1',fld:'vUDPARG1',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV27ProjectIds',fld:'vPROJECTIDS',pic:''}]");
         setEventMetadata("VPROJECTID.CONTROLVALUECHANGED",",oparms:[{av:'Ucvistimeline1_Startdate',ctrl:'UCVISTIMELINE1',prop:'startDate'},{av:'Ucvistimeline1_Stopdate',ctrl:'UCVISTIMELINE1',prop:'stopDate'},{av:'AV28EmployeeIds',fld:'vEMPLOYEEIDS',pic:''},{av:'AV27ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV6LeaveEvents',fld:'vLEAVEEVENTS',pic:''},{av:'AV7LeaveEventGroups',fld:'vLEAVEEVENTGROUPS',pic:''}]}");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED","{handler:'E12562',iparms:[{av:'AV10DateRange',fld:'vDATERANGE',pic:''},{av:'AV16DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'AV6LeaveEvents',fld:'vLEAVEEVENTS',pic:''},{av:'AV7LeaveEventGroups',fld:'vLEAVEEVENTGROUPS',pic:''},{av:'dynavProjectid'},{av:'AV26ProjectId',fld:'vPROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV29IsProjectManager',fld:'vISPROJECTMANAGER',pic:'',hsh:true},{av:'dynavCompanylocationid'},{av:'AV11CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:'ZZZZZZZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV33Udparg1',fld:'vUDPARG1',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV27ProjectIds',fld:'vPROJECTIDS',pic:''}]");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED",",oparms:[{av:'AV10DateRange',fld:'vDATERANGE',pic:''},{av:'AV16DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'Ucvistimeline1_Startdate',ctrl:'UCVISTIMELINE1',prop:'startDate'},{av:'Ucvistimeline1_Stopdate',ctrl:'UCVISTIMELINE1',prop:'stopDate'},{av:'AV28EmployeeIds',fld:'vEMPLOYEEIDS',pic:''},{av:'AV27ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV6LeaveEvents',fld:'vLEAVEEVENTS',pic:''},{av:'AV7LeaveEventGroups',fld:'vLEAVEEVENTGROUPS',pic:''}]}");
         setEventMetadata("VCOMPANYLOCATIONID.CONTROLVALUECHANGED","{handler:'E17562',iparms:[{av:'dynavCompanylocationid'},{av:'AV11CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:'ZZZZZZZZZ9'},{av:'AV10DateRange',fld:'vDATERANGE',pic:''},{av:'AV16DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV6LeaveEvents',fld:'vLEAVEEVENTS',pic:''},{av:'AV7LeaveEventGroups',fld:'vLEAVEEVENTGROUPS',pic:''},{av:'dynavProjectid'},{av:'AV26ProjectId',fld:'vPROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV29IsProjectManager',fld:'vISPROJECTMANAGER',pic:'',hsh:true},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV33Udparg1',fld:'vUDPARG1',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV27ProjectIds',fld:'vPROJECTIDS',pic:''}]");
         setEventMetadata("VCOMPANYLOCATIONID.CONTROLVALUECHANGED",",oparms:[{av:'Ucvistimeline1_Leavetypes',ctrl:'UCVISTIMELINE1',prop:'leavetypes'},{av:'Ucvistimeline1_Startdate',ctrl:'UCVISTIMELINE1',prop:'startDate'},{av:'Ucvistimeline1_Stopdate',ctrl:'UCVISTIMELINE1',prop:'stopDate'},{av:'AV28EmployeeIds',fld:'vEMPLOYEEIDS',pic:''},{av:'AV27ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV6LeaveEvents',fld:'vLEAVEEVENTS',pic:''},{av:'AV7LeaveEventGroups',fld:'vLEAVEEVENTGROUPS',pic:''}]}");
         setEventMetadata("GLOBALEVENTS.LEAVEREQUESTSTATUSCHANGED","{handler:'E18562',iparms:[{av:'AV10DateRange',fld:'vDATERANGE',pic:''},{av:'AV16DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV6LeaveEvents',fld:'vLEAVEEVENTS',pic:''},{av:'AV7LeaveEventGroups',fld:'vLEAVEEVENTGROUPS',pic:''},{av:'dynavProjectid'},{av:'AV26ProjectId',fld:'vPROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV29IsProjectManager',fld:'vISPROJECTMANAGER',pic:'',hsh:true},{av:'dynavCompanylocationid'},{av:'AV11CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:'ZZZZZZZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV33Udparg1',fld:'vUDPARG1',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV27ProjectIds',fld:'vPROJECTIDS',pic:''}]");
         setEventMetadata("GLOBALEVENTS.LEAVEREQUESTSTATUSCHANGED",",oparms:[{av:'Ucvistimeline1_Startdate',ctrl:'UCVISTIMELINE1',prop:'startDate'},{av:'Ucvistimeline1_Stopdate',ctrl:'UCVISTIMELINE1',prop:'stopDate'},{av:'AV28EmployeeIds',fld:'vEMPLOYEEIDS',pic:''},{av:'AV27ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV6LeaveEvents',fld:'vLEAVEEVENTS',pic:''},{av:'AV7LeaveEventGroups',fld:'vLEAVEEVENTGROUPS',pic:''}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gx_date = DateTime.MinValue;
         GXKey = "";
         AV10DateRange = DateTime.MinValue;
         AV16DateRange_To = DateTime.MinValue;
         AV17DateRange_RangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV28EmployeeIds = new GxSimpleCollection<long>();
         AV6LeaveEvents = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4");
         AV7LeaveEventGroups = new GXBaseCollection<SdtSDTLeaveEventGroup>( context, "SDTLeaveEventGroup", "YTT_version4");
         AV27ProjectIds = new GxSimpleCollection<long>();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucUsercontrol1 = new GXUserControl();
         lblTextblockdaterange_rangetext_Jsonclick = "";
         TempTags = "";
         AV15DateRange_RangeText = "";
         lblTextblockcompanylocationid_Jsonclick = "";
         lblTextblockprojectid_Jsonclick = "";
         bttBtnreport_Jsonclick = "";
         ucUcvistimeline1 = new GXUserControl();
         bttBtnuseraction1_Jsonclick = "";
         ucDaterange_rangepicker = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00562_A157CompanyLocationId = new long[1] ;
         H00562_A158CompanyLocationName = new string[] {""} ;
         H00563_A102ProjectId = new long[1] ;
         H00563_A103ProjectName = new string[] {""} ;
         H00563_A166ProjectManagerId = new long[1] ;
         H00563_n166ProjectManagerId = new bool[] {false} ;
         H00564_A157CompanyLocationId = new long[1] ;
         H00564_A158CompanyLocationName = new string[] {""} ;
         H00565_A100CompanyId = new long[1] ;
         H00565_A157CompanyLocationId = new long[1] ;
         AV23SDTLeaveTypes = new GXBaseCollection<SdtSDTLeaveType>( context, "SDTLeaveType", "YTT_version4");
         GXt_SdtWWPDateRangePickerOptions5 = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV21ExcelFilename = "";
         AV20ErrorMessage = "";
         GXt_objcol_SdtSDTLeaveType3 = new GXBaseCollection<SdtSDTLeaveType>( context, "SDTLeaveType", "YTT_version4");
         GXt_char4 = "";
         GXt_objcol_SdtSDTLeaveEvent7 = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4");
         GXt_objcol_SdtSDTLeaveEventGroup8 = new GXBaseCollection<SdtSDTLeaveEventGroup>( context, "SDTLeaveEventGroup", "YTT_version4");
         H00566_A166ProjectManagerId = new long[1] ;
         H00566_n166ProjectManagerId = new bool[] {false} ;
         H00566_A102ProjectId = new long[1] ;
         GXt_objcol_int6 = new GxSimpleCollection<long>();
         sStyleString = "";
         ucUseraction1_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H00567_A157CompanyLocationId = new long[1] ;
         H00567_A158CompanyLocationName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavecalendar__default(),
            new Object[][] {
                new Object[] {
               H00562_A157CompanyLocationId, H00562_A158CompanyLocationName
               }
               , new Object[] {
               H00563_A102ProjectId, H00563_A103ProjectName, H00563_A166ProjectManagerId, H00563_n166ProjectManagerId
               }
               , new Object[] {
               H00564_A157CompanyLocationId, H00564_A158CompanyLocationName
               }
               , new Object[] {
               H00565_A100CompanyId, H00565_A157CompanyLocationId
               }
               , new Object[] {
               H00566_A166ProjectManagerId, H00566_n166ProjectManagerId, H00566_A102ProjectId
               }
               , new Object[] {
               H00567_A157CompanyLocationId, H00567_A158CompanyLocationName
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Ucvistimeline1_Item ;
      private int edtavDaterange_rangetext_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV33Udparg1 ;
      private long AV25LeaveRequestId ;
      private long A166ProjectManagerId ;
      private long A102ProjectId ;
      private long AV11CompanyLocationId ;
      private long AV26ProjectId ;
      private long AV18CompanyId ;
      private long GXt_int1 ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ucvistimeline1_Events ;
      private string Ucvistimeline1_Groups ;
      private string Ucvistimeline1_Leavetypes ;
      private string Ucvistimeline1_Startdate ;
      private string Ucvistimeline1_Stopdate ;
      private string Useraction1_modal_Width ;
      private string Useraction1_modal_Title ;
      private string Useraction1_modal_Confirmtype ;
      private string Useraction1_modal_Bodytype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTable1_Internalname ;
      private string Usercontrol1_Internalname ;
      private string divUnnamedtableaterange_rangetext_Internalname ;
      private string lblTextblockdaterange_rangetext_Internalname ;
      private string lblTextblockdaterange_rangetext_Jsonclick ;
      private string edtavDaterange_rangetext_Internalname ;
      private string TempTags ;
      private string edtavDaterange_rangetext_Jsonclick ;
      private string divUnnamedtablecompanylocationid_Internalname ;
      private string lblTextblockcompanylocationid_Internalname ;
      private string lblTextblockcompanylocationid_Jsonclick ;
      private string dynavCompanylocationid_Internalname ;
      private string dynavCompanylocationid_Jsonclick ;
      private string divUnnamedtableprojectid_Internalname ;
      private string lblTextblockprojectid_Internalname ;
      private string lblTextblockprojectid_Jsonclick ;
      private string dynavProjectid_Internalname ;
      private string dynavProjectid_Jsonclick ;
      private string bttBtnreport_Internalname ;
      private string bttBtnreport_Jsonclick ;
      private string Ucvistimeline1_Internalname ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Daterange_rangepicker_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string GXt_char4 ;
      private string sStyleString ;
      private string tblTableuseraction1_modal_Internalname ;
      private string Useraction1_modal_Internalname ;
      private DateTime Gx_date ;
      private DateTime AV10DateRange ;
      private DateTime AV16DateRange_To ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV29IsProjectManager ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean2 ;
      private bool n166ProjectManagerId ;
      private string AV15DateRange_RangeText ;
      private string AV21ExcelFilename ;
      private string AV20ErrorMessage ;
      private GxSimpleCollection<long> AV28EmployeeIds ;
      private GxSimpleCollection<long> AV27ProjectIds ;
      private GxSimpleCollection<long> GXt_objcol_int6 ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucUsercontrol1 ;
      private GXUserControl ucUcvistimeline1 ;
      private GXUserControl ucDaterange_rangepicker ;
      private GXUserControl ucUseraction1_modal ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCompanylocationid ;
      private GXCombobox dynavProjectid ;
      private IDataStoreProvider pr_default ;
      private long[] H00562_A157CompanyLocationId ;
      private string[] H00562_A158CompanyLocationName ;
      private long[] H00563_A102ProjectId ;
      private string[] H00563_A103ProjectName ;
      private long[] H00563_A166ProjectManagerId ;
      private bool[] H00563_n166ProjectManagerId ;
      private long[] H00564_A157CompanyLocationId ;
      private string[] H00564_A158CompanyLocationName ;
      private long[] H00565_A100CompanyId ;
      private long[] H00565_A157CompanyLocationId ;
      private long[] H00566_A166ProjectManagerId ;
      private bool[] H00566_n166ProjectManagerId ;
      private long[] H00566_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H00567_A157CompanyLocationId ;
      private string[] H00567_A158CompanyLocationName ;
      private GXBaseCollection<SdtSDTLeaveEventGroup> AV7LeaveEventGroups ;
      private GXBaseCollection<SdtSDTLeaveEventGroup> GXt_objcol_SdtSDTLeaveEventGroup8 ;
      private GXBaseCollection<SdtSDTLeaveEvent> AV6LeaveEvents ;
      private GXBaseCollection<SdtSDTLeaveEvent> GXt_objcol_SdtSDTLeaveEvent7 ;
      private GXBaseCollection<SdtSDTLeaveType> AV23SDTLeaveTypes ;
      private GXBaseCollection<SdtSDTLeaveType> GXt_objcol_SdtSDTLeaveType3 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV17DateRange_RangePickerOptions ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions5 ;
   }

   public class leavecalendar__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00562;
          prmH00562 = new Object[] {
          };
          Object[] prmH00563;
          prmH00563 = new Object[] {
          };
          Object[] prmH00564;
          prmH00564 = new Object[] {
          };
          Object[] prmH00565;
          prmH00565 = new Object[] {
          new ParDef("AV18CompanyId",GXType.Int64,10,0)
          };
          Object[] prmH00566;
          prmH00566 = new Object[] {
          new ParDef("AV33Udparg1",GXType.Int64,10,0)
          };
          Object[] prmH00567;
          prmH00567 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00562", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00562,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00563", "SELECT ProjectId, ProjectName, ProjectManagerId FROM Project ORDER BY ProjectName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00563,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00564", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00564,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00565", "SELECT CompanyId, CompanyLocationId FROM Company WHERE CompanyId = :AV18CompanyId ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00565,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00566", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV33Udparg1 ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00566,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00567", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00567,0, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
