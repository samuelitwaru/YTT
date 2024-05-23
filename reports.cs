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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class reports : GXDataArea
   {
      public reports( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reports( IGxContext context )
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
         chkavShowleavetotal = new GXCheckbox();
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
            return "reports_Execute" ;
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
         PA452( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START452( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/PivotTableRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reports.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISMANAGER", AV52IsManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISMANAGER", GetSecureSignedToken( "", AV52IsManager, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEIDS", AV51EmployeeIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEIDS", AV51EmployeeIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEIDS", GetSecureSignedToken( "", AV51EmployeeIds, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID_DATA", AV17ProjectId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID_DATA", AV17ProjectId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID_DATA", AV22CompanyLocationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID_DATA", AV22CompanyLocationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID_DATA", AV14EmployeeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID_DATA", AV14EmployeeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPROJECTS", AV19SDTProjects);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPROJECTS", AV19SDTProjects);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTEMPLOYEEPROJECTHOURSCOLLECTION", AV5SDTEmployeeProjectHoursCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTEMPLOYEEPROJECTHOURSCOLLECTION", AV5SDTEmployeeProjectHoursCollection);
         }
         GxWebStd.gx_hidden_field( context, "vDATERANGE", context.localUtil.DToC( AV8DateRange, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGE_TO", context.localUtil.DToC( AV11DateRange_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDATERANGE_RANGEPICKEROPTIONS", AV9DateRange_RangePickerOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDATERANGE_RANGEPICKEROPTIONS", AV9DateRange_RangePickerOptions);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID", AV16ProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID", AV16ProjectId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID", AV21CompanyLocationId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID", AV21CompanyLocationId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID", AV13EmployeeId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID", AV13EmployeeId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTIDS", AV50ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTIDS", AV50ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, "vTOTALFORMATTEDWORKTIME", StringUtil.RTrim( AV41TotalFormattedWorkTime));
         GxWebStd.gx_hidden_field( context, "vTOTALFORMATTEDTIME", StringUtil.RTrim( AV61TotalFormattedTime));
         GxWebStd.gx_hidden_field( context, "vEXCELFILENAME", AV38ExcelFilename);
         GxWebStd.gx_hidden_field( context, "vERRORMESSAGE", AV37ErrorMessage);
         GxWebStd.gx_hidden_field( context, "vMSG", StringUtil.RTrim( Gx_msg));
         GxWebStd.gx_boolean_hidden_field( context, "vISMANAGER", AV52IsManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISMANAGER", GetSecureSignedToken( "", AV52IsManager, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEIDS", AV51EmployeeIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEIDS", AV51EmployeeIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEIDS", GetSecureSignedToken( "", AV51EmployeeIds, context));
         GxWebStd.gx_hidden_field( context, "EMPLOYEENAME", StringUtil.RTrim( A148EmployeeName));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Cls", StringUtil.RTrim( Combo_projectid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_set", StringUtil.RTrim( Combo_projectid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Allowmultipleselection", StringUtil.BoolToStr( Combo_projectid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_projectid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Emptyitem", StringUtil.BoolToStr( Combo_projectid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Multiplevaluestype", StringUtil.RTrim( Combo_projectid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Cls", StringUtil.RTrim( Combo_companylocationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Allowmultipleselection", StringUtil.BoolToStr( Combo_companylocationid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_companylocationid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Emptyitem", StringUtil.BoolToStr( Combo_companylocationid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Multiplevaluestype", StringUtil.RTrim( Combo_companylocationid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Cls", StringUtil.RTrim( Combo_employeeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_set", StringUtil.RTrim( Combo_employeeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Allowmultipleselection", StringUtil.BoolToStr( Combo_employeeid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_employeeid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Emptyitem", StringUtil.BoolToStr( Combo_employeeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Multiplevaluestype", StringUtil.RTrim( Combo_employeeid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "PIVOTTABLE1_Totalformattedworktime", StringUtil.RTrim( Pivottable1_Totalformattedworktime));
         GxWebStd.gx_hidden_field( context, "PIVOTTABLE1_Totalformattedtime", StringUtil.RTrim( Pivottable1_Totalformattedtime));
         GxWebStd.gx_hidden_field( context, "PIVOTTABLE1_Showleavetotal", StringUtil.BoolToStr( Pivottable1_Showleavetotal));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "PIVOTTABLE1_Totalformattedworktime", StringUtil.RTrim( Pivottable1_Totalformattedworktime));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "PIVOTTABLE1_Totalformattedworktime", StringUtil.RTrim( Pivottable1_Totalformattedworktime));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
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
            WE452( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT452( ) ;
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
         return formatLink("reports.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Reports" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reports" ;
      }

      protected void WB450( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:row-reverse;justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportexcel_Internalname, "", "Export", bttBtnexportexcel_Jsonclick, 5, "Export", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reports.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOverviewtable_Internalname, divOverviewtable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDaterange_rangetext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDaterange_rangetext_Internalname, "Date Range", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDaterange_rangetext_Internalname, AV10DateRange_RangeText, StringUtil.RTrim( context.localUtil.Format( AV10DateRange_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDaterange_rangetext_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavDaterange_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Reports.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedprojectid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_projectid_Internalname, "Project", "", "", lblTextblockcombo_projectid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reports.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_projectid.SetProperty("Caption", Combo_projectid_Caption);
            ucCombo_projectid.SetProperty("Cls", Combo_projectid_Cls);
            ucCombo_projectid.SetProperty("AllowMultipleSelection", Combo_projectid_Allowmultipleselection);
            ucCombo_projectid.SetProperty("IncludeOnlySelectedOption", Combo_projectid_Includeonlyselectedoption);
            ucCombo_projectid.SetProperty("EmptyItem", Combo_projectid_Emptyitem);
            ucCombo_projectid.SetProperty("MultipleValuesType", Combo_projectid_Multiplevaluestype);
            ucCombo_projectid.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_projectid.SetProperty("DropDownOptionsData", AV17ProjectId_Data);
            ucCombo_projectid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_projectid_Internalname, "COMBO_PROJECTIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcompanylocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_companylocationid_Internalname, "Location", "", "", lblTextblockcombo_companylocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reports.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_companylocationid.SetProperty("Caption", Combo_companylocationid_Caption);
            ucCombo_companylocationid.SetProperty("Cls", Combo_companylocationid_Cls);
            ucCombo_companylocationid.SetProperty("AllowMultipleSelection", Combo_companylocationid_Allowmultipleselection);
            ucCombo_companylocationid.SetProperty("IncludeOnlySelectedOption", Combo_companylocationid_Includeonlyselectedoption);
            ucCombo_companylocationid.SetProperty("EmptyItem", Combo_companylocationid_Emptyitem);
            ucCombo_companylocationid.SetProperty("MultipleValuesType", Combo_companylocationid_Multiplevaluestype);
            ucCombo_companylocationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_companylocationid.SetProperty("DropDownOptionsData", AV22CompanyLocationId_Data);
            ucCombo_companylocationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_companylocationid_Internalname, "COMBO_COMPANYLOCATIONIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_employeeid_Internalname, "Employee", "", "", lblTextblockcombo_employeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reports.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_employeeid.SetProperty("Caption", Combo_employeeid_Caption);
            ucCombo_employeeid.SetProperty("Cls", Combo_employeeid_Cls);
            ucCombo_employeeid.SetProperty("AllowMultipleSelection", Combo_employeeid_Allowmultipleselection);
            ucCombo_employeeid.SetProperty("IncludeOnlySelectedOption", Combo_employeeid_Includeonlyselectedoption);
            ucCombo_employeeid.SetProperty("EmptyItem", Combo_employeeid_Emptyitem);
            ucCombo_employeeid.SetProperty("MultipleValuesType", Combo_employeeid_Multiplevaluestype);
            ucCombo_employeeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_employeeid.SetProperty("DropDownOptionsData", AV14EmployeeId_Data);
            ucCombo_employeeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_employeeid_Internalname, "COMBO_EMPLOYEEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:row-reverse;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableshowleavetotal_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockshowleavetotal_Internalname, "Show Leave Total", "", "", lblTextblockshowleavetotal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reports.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavShowleavetotal_Internalname, "Show Leave Total", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavShowleavetotal_Internalname, StringUtil.BoolToStr( AV56ShowLeaveTotal), "", "Show Leave Total", chkavShowleavetotal.Visible, chkavShowleavetotal.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(57, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,57);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPivottable1.SetProperty("SDTProjects", AV19SDTProjects);
            ucPivottable1.SetProperty("SDTEmployeeProjectHoursCollection", AV5SDTEmployeeProjectHoursCollection);
            ucPivottable1.SetProperty("TotalFormattedWorkTime", Pivottable1_Totalformattedworktime);
            ucPivottable1.SetProperty("ShowLeaveTotal", Pivottable1_Showleavetotal);
            ucPivottable1.Render(context, "pivottable", Pivottable1_Internalname, "PIVOTTABLE1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divDetailtable_Internalname, divDetailtable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            /* User Defined Control */
            ucDaterange_rangepicker.SetProperty("Start Date", AV8DateRange);
            ucDaterange_rangepicker.SetProperty("End Date", AV11DateRange_To);
            ucDaterange_rangepicker.SetProperty("PickerOptions", AV9DateRange_RangePickerOptions);
            ucDaterange_rangepicker.Render(context, "wwp.daterangepicker", Daterange_rangepicker_Internalname, "DATERANGE_RANGEPICKERContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavView_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54View), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV54View), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavView_Jsonclick, 0, "Attribute", "", "", "", "", edtavView_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Reports.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START452( )
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
         Form.Meta.addItem("description", "Reports", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP450( ) ;
      }

      protected void WS452( )
      {
         START452( ) ;
         EVT452( ) ;
      }

      protected void EVT452( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROJECTID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_EMPLOYEEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DATERANGE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E15452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportExcel' */
                              E16452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VVIEW.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSHOWLEAVETOTAL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E19452 ();
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

      protected void WE452( )
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

      protected void PA452( )
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
         AV56ShowLeaveTotal = StringUtil.StrToBool( StringUtil.BoolToStr( AV56ShowLeaveTotal));
         AssignAttri("", false, "AV56ShowLeaveTotal", AV56ShowLeaveTotal);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF452( ) ;
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

      protected void RF452( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E19452 ();
            WB450( ) ;
         }
      }

      protected void send_integrity_lvl_hashes452( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISMANAGER", AV52IsManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISMANAGER", GetSecureSignedToken( "", AV52IsManager, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEIDS", AV51EmployeeIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEIDS", AV51EmployeeIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEIDS", GetSecureSignedToken( "", AV51EmployeeIds, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP450( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15452 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV12DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID_DATA"), AV17ProjectId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCOMPANYLOCATIONID_DATA"), AV22CompanyLocationId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV14EmployeeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTPROJECTS"), AV19SDTProjects);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTEMPLOYEEPROJECTHOURSCOLLECTION"), AV5SDTEmployeeProjectHoursCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vDATERANGE_RANGEPICKEROPTIONS"), AV9DateRange_RangePickerOptions);
            /* Read saved values. */
            AV8DateRange = context.localUtil.CToD( cgiGet( "vDATERANGE"), 0);
            AV11DateRange_To = context.localUtil.CToD( cgiGet( "vDATERANGE_TO"), 0);
            Combo_projectid_Cls = cgiGet( "COMBO_PROJECTID_Cls");
            Combo_projectid_Selectedvalue_set = cgiGet( "COMBO_PROJECTID_Selectedvalue_set");
            Combo_projectid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Allowmultipleselection"));
            Combo_projectid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeonlyselectedoption"));
            Combo_projectid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Emptyitem"));
            Combo_projectid_Multiplevaluestype = cgiGet( "COMBO_PROJECTID_Multiplevaluestype");
            Combo_companylocationid_Cls = cgiGet( "COMBO_COMPANYLOCATIONID_Cls");
            Combo_companylocationid_Selectedvalue_set = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_set");
            Combo_companylocationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Allowmultipleselection"));
            Combo_companylocationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Includeonlyselectedoption"));
            Combo_companylocationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Emptyitem"));
            Combo_companylocationid_Multiplevaluestype = cgiGet( "COMBO_COMPANYLOCATIONID_Multiplevaluestype");
            Combo_employeeid_Cls = cgiGet( "COMBO_EMPLOYEEID_Cls");
            Combo_employeeid_Selectedvalue_set = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_set");
            Combo_employeeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Allowmultipleselection"));
            Combo_employeeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Includeonlyselectedoption"));
            Combo_employeeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Emptyitem"));
            Combo_employeeid_Multiplevaluestype = cgiGet( "COMBO_EMPLOYEEID_Multiplevaluestype");
            Pivottable1_Totalformattedworktime = cgiGet( "PIVOTTABLE1_Totalformattedworktime");
            Pivottable1_Totalformattedtime = cgiGet( "PIVOTTABLE1_Totalformattedtime");
            Pivottable1_Showleavetotal = StringUtil.StrToBool( cgiGet( "PIVOTTABLE1_Showleavetotal"));
            Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
            Pivottable1_Totalformattedworktime = cgiGet( "PIVOTTABLE1_Totalformattedworktime");
            Combo_companylocationid_Selectedvalue_get = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_get");
            Combo_projectid_Selectedvalue_get = cgiGet( "COMBO_PROJECTID_Selectedvalue_get");
            /* Read variables values. */
            AV10DateRange_RangeText = cgiGet( edtavDaterange_rangetext_Internalname);
            AssignAttri("", false, "AV10DateRange_RangeText", AV10DateRange_RangeText);
            AV56ShowLeaveTotal = StringUtil.StrToBool( cgiGet( chkavShowleavetotal_Internalname));
            AssignAttri("", false, "AV56ShowLeaveTotal", AV56ShowLeaveTotal);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavView_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavView_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVIEW");
               GX_FocusControl = edtavView_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV54View = 0;
               AssignAttri("", false, "AV54View", StringUtil.LTrimStr( (decimal)(AV54View), 4, 0));
            }
            else
            {
               AV54View = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavView_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV54View", StringUtil.LTrimStr( (decimal)(AV54View), 4, 0));
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
         E15452 ();
         if (returnInSub) return;
      }

      protected void E15452( )
      {
         /* Start Routine */
         returnInSub = false;
         AV54View = 1;
         AssignAttri("", false, "AV54View", StringUtil.LTrimStr( (decimal)(AV54View), 4, 0));
         AV56ShowLeaveTotal = false;
         AssignAttri("", false, "AV56ShowLeaveTotal", AV56ShowLeaveTotal);
         GXt_int1 = AV44LoggedInEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV44LoggedInEmployeeId = GXt_int1;
         AssignAttri("", false, "AV44LoggedInEmployeeId", StringUtil.LTrimStr( (decimal)(AV44LoggedInEmployeeId), 10, 0));
         AV8DateRange = context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), DateTimeUtil.Month( Gx_date)-1, 1);
         AssignAttri("", false, "AV8DateRange", context.localUtil.Format(AV8DateRange, "99/99/99"));
         AV11DateRange_To = DateTimeUtil.DateEndOfMonth( AV8DateRange);
         AssignAttri("", false, "AV11DateRange_To", context.localUtil.Format(AV11DateRange_To, "99/99/99"));
         GXt_boolean2 = AV52IsManager;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean2) ;
         AV52IsManager = GXt_boolean2;
         AssignAttri("", false, "AV52IsManager", AV52IsManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISMANAGER", GetSecureSignedToken( "", AV52IsManager, context));
         GXt_boolean2 = AV53IsProjectManager;
         new userhasrole(context ).execute(  "Project Manager", out  GXt_boolean2) ;
         AV53IsProjectManager = GXt_boolean2;
         AssignAttri("", false, "AV53IsProjectManager", AV53IsProjectManager);
         if ( AV53IsProjectManager )
         {
            /* Execute user subroutine: 'GETEMPLOYEEIDSBYPROJECT' */
            S112 ();
            if (returnInSub) return;
         }
         if ( ! (0==AV44LoggedInEmployeeId) )
         {
            /* Using cursor H00452 */
            pr_default.execute(0, new Object[] {AV44LoggedInEmployeeId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A100CompanyId = H00452_A100CompanyId[0];
               A106EmployeeId = H00452_A106EmployeeId[0];
               A157CompanyLocationId = H00452_A157CompanyLocationId[0];
               A157CompanyLocationId = H00452_A157CompanyLocationId[0];
               AV49EmployeeCompanyLocationId = A157CompanyLocationId;
               AssignAttri("", false, "AV49EmployeeCompanyLocationId", StringUtil.LTrimStr( (decimal)(AV49EmployeeCompanyLocationId), 10, 0));
               AV21CompanyLocationId.Add(A157CompanyLocationId, 0);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "PIVOTTABLE1Container", "Refresh", "", new Object[] {(GXBaseCollection<SdtSDTProject>)AV19SDTProjects,(GXBaseCollection<SdtSDTEmployeeProjectHours>)AV5SDTEmployeeProjectHoursCollection});
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV12DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV12DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         this.executeUsercontrolMethod("", false, "DATERANGE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDaterange_rangetext_Internalname});
         GXt_SdtWWPDateRangePickerOptions4 = AV9DateRange_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions4) ;
         AV9DateRange_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions4;
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCOMPANYLOCATIONID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S162 ();
         if (returnInSub) return;
         edtavView_Visible = 0;
         AssignProp("", false, edtavView_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavView_Visible), 5, 0), true);
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'EMITGLOBALEVENT' */
         S182 ();
         if (returnInSub) return;
      }

      protected void E16452( )
      {
         /* 'DoExportExcel' Routine */
         returnInSub = false;
         if ( AV54View == 1 )
         {
            new exportexceltable(context ).execute( ref  AV8DateRange, ref  AV11DateRange_To, ref  AV16ProjectId, ref  AV21CompanyLocationId, ref  AV13EmployeeId, ref  AV50ProjectIds, ref  AV5SDTEmployeeProjectHoursCollection, ref  AV41TotalFormattedWorkTime, ref  AV61TotalFormattedTime, out  AV38ExcelFilename, out  AV37ErrorMessage) ;
         }
         else
         {
            new exportdetailedreport(context ).execute( ref  AV8DateRange, ref  AV11DateRange_To, ref  AV16ProjectId, ref  AV21CompanyLocationId, ref  AV13EmployeeId, out  AV38ExcelFilename, out  AV37ErrorMessage) ;
            AssignAttri("", false, "AV8DateRange", context.localUtil.Format(AV8DateRange, "99/99/99"));
            AssignAttri("", false, "AV11DateRange_To", context.localUtil.Format(AV11DateRange_To, "99/99/99"));
            AssignAttri("", false, "AV38ExcelFilename", AV38ExcelFilename);
            AssignAttri("", false, "AV37ErrorMessage", AV37ErrorMessage);
         }
         if ( StringUtil.StrCmp(AV38ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV38ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV37ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5SDTEmployeeProjectHoursCollection", AV5SDTEmployeeProjectHoursCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ProjectIds", AV50ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13EmployeeId", AV13EmployeeId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21CompanyLocationId", AV21CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ProjectId", AV16ProjectId);
      }

      protected void E13452( )
      {
         /* Combo_employeeid_Onoptionclicked Routine */
         returnInSub = false;
         AV13EmployeeId.FromJSonString(Combo_employeeid_Selectedvalue_get, null);
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'EMITGLOBALEVENT' */
         S182 ();
         if (returnInSub) return;
         context.DoAjaxRefresh();
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "PIVOTTABLE1Container", "Refresh", "", new Object[] {(GXBaseCollection<SdtSDTProject>)AV19SDTProjects,(GXBaseCollection<SdtSDTEmployeeProjectHours>)AV5SDTEmployeeProjectHoursCollection});
         AV13EmployeeId.FromJSonString(Combo_employeeid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13EmployeeId", AV13EmployeeId);
      }

      protected void E12452( )
      {
         /* Combo_companylocationid_Onoptionclicked Routine */
         returnInSub = false;
         AV21CompanyLocationId.FromJSonString(Combo_companylocationid_Selectedvalue_get, null);
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'EMITGLOBALEVENT' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "PIVOTTABLE1Container", "Refresh", "", new Object[] {(GXBaseCollection<SdtSDTProject>)AV19SDTProjects,(GXBaseCollection<SdtSDTEmployeeProjectHours>)AV5SDTEmployeeProjectHoursCollection});
         AV21CompanyLocationId.FromJSonString(Combo_companylocationid_Selectedvalue_get, null);
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21CompanyLocationId", AV21CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14EmployeeId_Data", AV14EmployeeId_Data);
      }

      protected void E11452( )
      {
         /* Combo_projectid_Onoptionclicked Routine */
         returnInSub = false;
         AV16ProjectId.FromJSonString(Combo_projectid_Selectedvalue_get, null);
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'EMITGLOBALEVENT' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "PIVOTTABLE1Container", "Refresh", "", new Object[] {(GXBaseCollection<SdtSDTProject>)AV19SDTProjects,(GXBaseCollection<SdtSDTEmployeeProjectHours>)AV5SDTEmployeeProjectHoursCollection});
         AV16ProjectId.FromJSonString(Combo_projectid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ProjectId", AV16ProjectId);
      }

      protected void S162( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divOverviewtable_Visible = (((AV54View==1)) ? 1 : 0);
         AssignProp("", false, divOverviewtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divOverviewtable_Visible), 5, 0), true);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV51EmployeeIds ,
                                              AV51EmployeeIds.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor H00453 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A106EmployeeId = H00453_A106EmployeeId[0];
            A148EmployeeName = H00453_A148EmployeeName[0];
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AV7Combo_DataItem.gxTpr_Title = A148EmployeeName;
            AV14EmployeeId_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_employeeid_Selectedvalue_set = AV13EmployeeId.ToJSonString(false);
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOCOMPANYLOCATIONID' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV49EmployeeCompanyLocationId ,
                                              AV52IsManager ,
                                              AV53IsProjectManager ,
                                              A157CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         /* Using cursor H00454 */
         pr_default.execute(2, new Object[] {AV49EmployeeCompanyLocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A157CompanyLocationId = H00454_A157CompanyLocationId[0];
            A158CompanyLocationName = H00454_A158CompanyLocationName[0];
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0));
            AV7Combo_DataItem.gxTpr_Title = A158CompanyLocationName;
            AV22CompanyLocationId_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_companylocationid_Selectedvalue_set = AV21CompanyLocationId.ToJSonString(false);
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedValue_set", Combo_companylocationid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV50ProjectIds ,
                                              AV50ProjectIds.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor H00455 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A102ProjectId = H00455_A102ProjectId[0];
            A103ProjectName = H00455_A103ProjectName[0];
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
            AV7Combo_DataItem.gxTpr_Title = A103ProjectName;
            AV17ProjectId_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_projectid_Selectedvalue_set = AV16ProjectId.ToJSonString(false);
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
      }

      protected void E14452( )
      {
         /* Daterange_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S172 ();
         if (returnInSub) return;
         if ( (DateTime.MinValue==AV8DateRange) && (DateTime.MinValue==AV11DateRange_To) )
         {
            AV8DateRange = Gx_date;
            AssignAttri("", false, "AV8DateRange", context.localUtil.Format(AV8DateRange, "99/99/99"));
            AV11DateRange_To = Gx_date;
            AssignAttri("", false, "AV11DateRange_To", context.localUtil.Format(AV11DateRange_To, "99/99/99"));
         }
         AssignAttri("", false, "AV8DateRange", context.localUtil.Format(AV8DateRange, "99/99/99"));
         AssignAttri("", false, "AV11DateRange_To", context.localUtil.Format(AV11DateRange_To, "99/99/99"));
         /* Execute user subroutine: 'EMITGLOBALEVENT' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "PIVOTTABLE1Container", "Refresh", "", new Object[] {(GXBaseCollection<SdtSDTProject>)AV19SDTProjects,(GXBaseCollection<SdtSDTEmployeeProjectHours>)AV5SDTEmployeeProjectHoursCollection});
         /*  Sending Event outputs  */
      }

      protected void E17452( )
      {
         /* View_Controlvaluechanged Routine */
         returnInSub = false;
         if ( AV54View == 1 )
         {
            divDetailtable_Visible = 0;
            AssignProp("", false, divDetailtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDetailtable_Visible), 5, 0), true);
            divOverviewtable_Visible = 1;
            AssignProp("", false, divOverviewtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divOverviewtable_Visible), 5, 0), true);
            chkavShowleavetotal.Visible = 1;
            AssignProp("", false, chkavShowleavetotal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavShowleavetotal.Visible), 5, 0), true);
         }
         else
         {
            divDetailtable_Visible = 1;
            AssignProp("", false, divDetailtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDetailtable_Visible), 5, 0), true);
            divOverviewtable_Visible = 0;
            AssignProp("", false, divOverviewtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divOverviewtable_Visible), 5, 0), true);
            chkavShowleavetotal.Visible = 0;
            AssignProp("", false, chkavShowleavetotal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavShowleavetotal.Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'EMITGLOBALEVENT' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E18452( )
      {
         /* Showleavetotal_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "PIVOTTABLE1Container", "Refresh", "", new Object[] {(GXBaseCollection<SdtSDTProject>)AV19SDTProjects,(GXBaseCollection<SdtSDTEmployeeProjectHours>)AV5SDTEmployeeProjectHoursCollection});
         Pivottable1_Showleavetotal = AV56ShowLeaveTotal;
         ucPivottable1.SendProperty(context, "", false, Pivottable1_Internalname, "ShowLeaveTotal", StringUtil.BoolToStr( Pivottable1_Showleavetotal));
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         if ( ( AV52IsManager ) && ( AV21CompanyLocationId.Count == 0 ) )
         {
         }
         else
         {
            GXt_char5 = AV6blank;
            new employeeprojectmatrixreport(context ).execute( ref  AV8DateRange, ref  AV11DateRange_To, ref  AV16ProjectId, ref  AV21CompanyLocationId, ref  AV13EmployeeId, ref  AV51EmployeeIds, ref  AV50ProjectIds, out  AV19SDTProjects, out  AV5SDTEmployeeProjectHoursCollection, out  AV41TotalFormattedWorkTime, out  AV61TotalFormattedTime) ;
            AV6blank = GXt_char5;
            Pivottable1_Totalformattedworktime = AV41TotalFormattedWorkTime;
            ucPivottable1.SendProperty(context, "", false, Pivottable1_Internalname, "TotalFormattedWorkTime", Pivottable1_Totalformattedworktime);
            Pivottable1_Totalformattedtime = AV61TotalFormattedTime;
            ucPivottable1.SendProperty(context, "", false, Pivottable1_Internalname, "TotalFormattedTime", Pivottable1_Totalformattedtime);
            /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
            S172 ();
            if (returnInSub) return;
         }
      }

      protected void S112( )
      {
         /* 'GETEMPLOYEEIDSBYPROJECT' Routine */
         returnInSub = false;
         AV70Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor H00456 */
         pr_default.execute(4, new Object[] {AV70Udparg1});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A166ProjectManagerId = H00456_A166ProjectManagerId[0];
            n166ProjectManagerId = H00456_n166ProjectManagerId[0];
            A102ProjectId = H00456_A102ProjectId[0];
            AV50ProjectIds.Add(A102ProjectId, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         GXt_objcol_int6 = AV51EmployeeIds;
         new getemployeeidsbyproject(context ).execute(  AV50ProjectIds, out  GXt_objcol_int6) ;
         AV51EmployeeIds = GXt_objcol_int6;
      }

      protected void S172( )
      {
         /* 'UPDATESESSIONVARIABLES' Routine */
         returnInSub = false;
         AV58WebSession.Set("CompanyLocationId", AV21CompanyLocationId.ToJSonString(false));
         AV58WebSession.Set("EmployeeId", AV13EmployeeId.ToJSonString(false));
         AV58WebSession.Set("ProjectId", AV16ProjectId.ToJSonString(false));
         AV58WebSession.Set("FromDate", context.localUtil.DToC( AV8DateRange, 1, "/"));
         AV58WebSession.Set("ToDate", context.localUtil.DToC( AV11DateRange_To, 1, "/"));
         AV58WebSession.Set("ShowLeaveTotal", StringUtil.BoolToStr( AV56ShowLeaveTotal));
         AV58WebSession.Set("TotalFormattedWorkTime", Pivottable1_Totalformattedworktime);
         AV58WebSession.Set("TotalFormattedTime", AV61TotalFormattedTime);
      }

      protected void S182( )
      {
         /* 'EMITGLOBALEVENT' Routine */
         returnInSub = false;
         if ( AV54View == 2 )
         {
            this.executeExternalObjectMethod("", false, "GlobalEvents", "ReportsFilterChanaged", new Object[] {(GxSimpleCollection<long>)AV21CompanyLocationId,(GxSimpleCollection<long>)AV13EmployeeId,(GxSimpleCollection<long>)AV16ProjectId,(DateTime)AV8DateRange,(DateTime)AV11DateRange_To}, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E19452( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA452( ) ;
         WS452( ) ;
         WE452( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20245238431355", true, true);
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
         context.AddJavascriptSource("reports.js", "?20245238431357", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/PivotTableRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavShowleavetotal.Name = "vSHOWLEAVETOTAL";
         chkavShowleavetotal.WebTags = "";
         chkavShowleavetotal.Caption = "";
         AssignProp("", false, chkavShowleavetotal_Internalname, "TitleCaption", chkavShowleavetotal.Caption, true);
         chkavShowleavetotal.CheckedValue = "false";
         AV56ShowLeaveTotal = StringUtil.StrToBool( StringUtil.BoolToStr( AV56ShowLeaveTotal));
         AssignAttri("", false, "AV56ShowLeaveTotal", AV56ShowLeaveTotal);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnexportexcel_Internalname = "BTNEXPORTEXCEL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtavDaterange_rangetext_Internalname = "vDATERANGE_RANGETEXT";
         lblTextblockcombo_projectid_Internalname = "TEXTBLOCKCOMBO_PROJECTID";
         Combo_projectid_Internalname = "COMBO_PROJECTID";
         divTablesplittedprojectid_Internalname = "TABLESPLITTEDPROJECTID";
         lblTextblockcombo_companylocationid_Internalname = "TEXTBLOCKCOMBO_COMPANYLOCATIONID";
         Combo_companylocationid_Internalname = "COMBO_COMPANYLOCATIONID";
         divTablesplittedcompanylocationid_Internalname = "TABLESPLITTEDCOMPANYLOCATIONID";
         lblTextblockcombo_employeeid_Internalname = "TEXTBLOCKCOMBO_EMPLOYEEID";
         Combo_employeeid_Internalname = "COMBO_EMPLOYEEID";
         divTablesplittedemployeeid_Internalname = "TABLESPLITTEDEMPLOYEEID";
         divTable1_Internalname = "TABLE1";
         lblTextblockshowleavetotal_Internalname = "TEXTBLOCKSHOWLEAVETOTAL";
         chkavShowleavetotal_Internalname = "vSHOWLEAVETOTAL";
         divUnnamedtableshowleavetotal_Internalname = "UNNAMEDTABLESHOWLEAVETOTAL";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         Pivottable1_Internalname = "PIVOTTABLE1";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         divOverviewtable_Internalname = "OVERVIEWTABLE";
         divDetailtable_Internalname = "DETAILTABLE";
         divMaintable_Internalname = "MAINTABLE";
         Daterange_rangepicker_Internalname = "DATERANGE_RANGEPICKER";
         edtavView_Internalname = "vVIEW";
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
         chkavShowleavetotal.Caption = "Show Leave Total";
         edtavView_Jsonclick = "";
         edtavView_Visible = 1;
         divDetailtable_Visible = 1;
         chkavShowleavetotal.Enabled = 1;
         chkavShowleavetotal.Visible = 1;
         Combo_employeeid_Caption = "";
         Combo_companylocationid_Caption = "";
         Combo_projectid_Caption = "";
         edtavDaterange_rangetext_Jsonclick = "";
         edtavDaterange_rangetext_Enabled = 1;
         divOverviewtable_Visible = 1;
         Pivottable1_Showleavetotal = Convert.ToBoolean( -1);
         Pivottable1_Totalformattedtime = "";
         Pivottable1_Totalformattedworktime = "&TotalFormattedWorkTime";
         Combo_employeeid_Multiplevaluestype = "Tags";
         Combo_employeeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_employeeid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_employeeid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_employeeid_Cls = "ExtendedCombo BlobContentAttribute";
         Combo_companylocationid_Multiplevaluestype = "Tags";
         Combo_companylocationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_companylocationid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_companylocationid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_companylocationid_Cls = "ExtendedCombo BlobContentAttribute";
         Combo_projectid_Multiplevaluestype = "Tags";
         Combo_projectid_Emptyitem = Convert.ToBoolean( 0);
         Combo_projectid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_projectid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_projectid_Cls = "ExtendedCombo BlobContentAttribute";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Reports";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV56ShowLeaveTotal',fld:'vSHOWLEAVETOTAL',pic:''},{av:'AV52IsManager',fld:'vISMANAGER',pic:'',hsh:true},{av:'AV51EmployeeIds',fld:'vEMPLOYEEIDS',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOEXPORTEXCEL'","{handler:'E16452',iparms:[{av:'AV54View',fld:'vVIEW',pic:'ZZZ9'},{av:'AV8DateRange',fld:'vDATERANGE',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV50ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV5SDTEmployeeProjectHoursCollection',fld:'vSDTEMPLOYEEPROJECTHOURSCOLLECTION',pic:''},{av:'AV41TotalFormattedWorkTime',fld:'vTOTALFORMATTEDWORKTIME',pic:''},{av:'AV61TotalFormattedTime',fld:'vTOTALFORMATTEDTIME',pic:''},{av:'AV38ExcelFilename',fld:'vEXCELFILENAME',pic:''},{av:'AV37ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'Gx_msg',fld:'vMSG',pic:''}]");
         setEventMetadata("'DOEXPORTEXCEL'",",oparms:[{av:'Gx_msg',fld:'vMSG',pic:''},{av:'AV61TotalFormattedTime',fld:'vTOTALFORMATTEDTIME',pic:''},{av:'AV41TotalFormattedWorkTime',fld:'vTOTALFORMATTEDWORKTIME',pic:''},{av:'AV5SDTEmployeeProjectHoursCollection',fld:'vSDTEMPLOYEEPROJECTHOURSCOLLECTION',pic:''},{av:'AV50ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV37ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV38ExcelFilename',fld:'vEXCELFILENAME',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV8DateRange',fld:'vDATERANGE',pic:''}]}");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED","{handler:'E13452',iparms:[{av:'Combo_employeeid_Selectedvalue_get',ctrl:'COMBO_EMPLOYEEID',prop:'SelectedValue_get'},{av:'AV19SDTProjects',fld:'vSDTPROJECTS',pic:''},{av:'AV5SDTEmployeeProjectHoursCollection',fld:'vSDTEMPLOYEEPROJECTHOURSCOLLECTION',pic:''},{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'AV8DateRange',fld:'vDATERANGE',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV56ShowLeaveTotal',fld:'vSHOWLEAVETOTAL',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'AV61TotalFormattedTime',fld:'vTOTALFORMATTEDTIME',pic:''},{av:'AV54View',fld:'vVIEW',pic:'ZZZ9'},{av:'AV52IsManager',fld:'vISMANAGER',pic:'',hsh:true},{av:'AV51EmployeeIds',fld:'vEMPLOYEEIDS',pic:'',hsh:true},{av:'AV50ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV41TotalFormattedWorkTime',fld:'vTOTALFORMATTEDWORKTIME',pic:''}]");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED",",oparms:[{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'Pivottable1_Totalformattedtime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedTime'}]}");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED","{handler:'E12452',iparms:[{av:'Combo_companylocationid_Selectedvalue_get',ctrl:'COMBO_COMPANYLOCATIONID',prop:'SelectedValue_get'},{av:'AV19SDTProjects',fld:'vSDTPROJECTS',pic:''},{av:'AV5SDTEmployeeProjectHoursCollection',fld:'vSDTEMPLOYEEPROJECTHOURSCOLLECTION',pic:''},{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'AV8DateRange',fld:'vDATERANGE',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV56ShowLeaveTotal',fld:'vSHOWLEAVETOTAL',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'AV61TotalFormattedTime',fld:'vTOTALFORMATTEDTIME',pic:''},{av:'AV54View',fld:'vVIEW',pic:'ZZZ9'},{av:'AV52IsManager',fld:'vISMANAGER',pic:'',hsh:true},{av:'AV51EmployeeIds',fld:'vEMPLOYEEIDS',pic:'',hsh:true},{av:'AV50ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV41TotalFormattedWorkTime',fld:'vTOTALFORMATTEDWORKTIME',pic:''},{av:'A148EmployeeName',fld:'EMPLOYEENAME',pic:''},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'AV14EmployeeId_Data',fld:'vEMPLOYEEID_DATA',pic:''}]");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED",",oparms:[{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'Pivottable1_Totalformattedtime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedTime'},{av:'AV14EmployeeId_Data',fld:'vEMPLOYEEID_DATA',pic:''},{av:'Combo_employeeid_Selectedvalue_set',ctrl:'COMBO_EMPLOYEEID',prop:'SelectedValue_set'}]}");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED","{handler:'E11452',iparms:[{av:'Combo_projectid_Selectedvalue_get',ctrl:'COMBO_PROJECTID',prop:'SelectedValue_get'},{av:'AV19SDTProjects',fld:'vSDTPROJECTS',pic:''},{av:'AV5SDTEmployeeProjectHoursCollection',fld:'vSDTEMPLOYEEPROJECTHOURSCOLLECTION',pic:''},{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'AV8DateRange',fld:'vDATERANGE',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV56ShowLeaveTotal',fld:'vSHOWLEAVETOTAL',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'AV61TotalFormattedTime',fld:'vTOTALFORMATTEDTIME',pic:''},{av:'AV54View',fld:'vVIEW',pic:'ZZZ9'},{av:'AV52IsManager',fld:'vISMANAGER',pic:'',hsh:true},{av:'AV51EmployeeIds',fld:'vEMPLOYEEIDS',pic:'',hsh:true},{av:'AV50ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV41TotalFormattedWorkTime',fld:'vTOTALFORMATTEDWORKTIME',pic:''}]");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED",",oparms:[{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'Pivottable1_Totalformattedtime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedTime'}]}");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED","{handler:'E14452',iparms:[{av:'AV8DateRange',fld:'vDATERANGE',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'AV19SDTProjects',fld:'vSDTPROJECTS',pic:''},{av:'AV5SDTEmployeeProjectHoursCollection',fld:'vSDTEMPLOYEEPROJECTHOURSCOLLECTION',pic:''},{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'AV56ShowLeaveTotal',fld:'vSHOWLEAVETOTAL',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'AV61TotalFormattedTime',fld:'vTOTALFORMATTEDTIME',pic:''},{av:'AV54View',fld:'vVIEW',pic:'ZZZ9'},{av:'AV52IsManager',fld:'vISMANAGER',pic:'',hsh:true},{av:'AV51EmployeeIds',fld:'vEMPLOYEEIDS',pic:'',hsh:true},{av:'AV50ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV41TotalFormattedWorkTime',fld:'vTOTALFORMATTEDWORKTIME',pic:''}]");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED",",oparms:[{av:'AV8DateRange',fld:'vDATERANGE',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'Pivottable1_Totalformattedtime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedTime'}]}");
         setEventMetadata("VVIEW.CONTROLVALUECHANGED","{handler:'E17452',iparms:[{av:'AV54View',fld:'vVIEW',pic:'ZZZ9'},{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'AV8DateRange',fld:'vDATERANGE',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV52IsManager',fld:'vISMANAGER',pic:'',hsh:true},{av:'AV51EmployeeIds',fld:'vEMPLOYEEIDS',pic:'',hsh:true},{av:'AV50ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV19SDTProjects',fld:'vSDTPROJECTS',pic:''},{av:'AV5SDTEmployeeProjectHoursCollection',fld:'vSDTEMPLOYEEPROJECTHOURSCOLLECTION',pic:''},{av:'AV41TotalFormattedWorkTime',fld:'vTOTALFORMATTEDWORKTIME',pic:''},{av:'AV61TotalFormattedTime',fld:'vTOTALFORMATTEDTIME',pic:''},{av:'AV56ShowLeaveTotal',fld:'vSHOWLEAVETOTAL',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'}]");
         setEventMetadata("VVIEW.CONTROLVALUECHANGED",",oparms:[{av:'divDetailtable_Visible',ctrl:'DETAILTABLE',prop:'Visible'},{av:'divOverviewtable_Visible',ctrl:'OVERVIEWTABLE',prop:'Visible'},{av:'chkavShowleavetotal.Visible',ctrl:'vSHOWLEAVETOTAL',prop:'Visible'},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'Pivottable1_Totalformattedtime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedTime'}]}");
         setEventMetadata("VSHOWLEAVETOTAL.CONTROLVALUECHANGED","{handler:'E18452',iparms:[{av:'AV19SDTProjects',fld:'vSDTPROJECTS',pic:''},{av:'AV5SDTEmployeeProjectHoursCollection',fld:'vSDTEMPLOYEEPROJECTHOURSCOLLECTION',pic:''},{av:'AV56ShowLeaveTotal',fld:'vSHOWLEAVETOTAL',pic:''},{av:'AV52IsManager',fld:'vISMANAGER',pic:'',hsh:true},{av:'AV21CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV8DateRange',fld:'vDATERANGE',pic:''},{av:'AV11DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV16ProjectId',fld:'vPROJECTID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV51EmployeeIds',fld:'vEMPLOYEEIDS',pic:'',hsh:true},{av:'AV50ProjectIds',fld:'vPROJECTIDS',pic:''},{av:'AV41TotalFormattedWorkTime',fld:'vTOTALFORMATTEDWORKTIME',pic:''},{av:'AV61TotalFormattedTime',fld:'vTOTALFORMATTEDTIME',pic:''},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'}]");
         setEventMetadata("VSHOWLEAVETOTAL.CONTROLVALUECHANGED",",oparms:[{av:'Pivottable1_Showleavetotal',ctrl:'PIVOTTABLE1',prop:'ShowLeaveTotal'},{av:'Pivottable1_Totalformattedworktime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedWorkTime'},{av:'Pivottable1_Totalformattedtime',ctrl:'PIVOTTABLE1',prop:'TotalFormattedTime'}]}");
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
         Combo_employeeid_Selectedvalue_get = "";
         Combo_companylocationid_Selectedvalue_get = "";
         Combo_projectid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV51EmployeeIds = new GxSimpleCollection<long>();
         Gx_date = DateTime.MinValue;
         GXKey = "";
         AV12DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17ProjectId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV22CompanyLocationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV14EmployeeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV19SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         AV5SDTEmployeeProjectHoursCollection = new GXBaseCollection<SdtSDTEmployeeProjectHours>( context, "SDTEmployeeProjectHours", "YTT_version4");
         AV8DateRange = DateTime.MinValue;
         AV11DateRange_To = DateTime.MinValue;
         AV9DateRange_RangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV16ProjectId = new GxSimpleCollection<long>();
         AV21CompanyLocationId = new GxSimpleCollection<long>();
         AV13EmployeeId = new GxSimpleCollection<long>();
         AV50ProjectIds = new GxSimpleCollection<long>();
         AV41TotalFormattedWorkTime = "";
         AV61TotalFormattedTime = "";
         AV38ExcelFilename = "";
         AV37ErrorMessage = "";
         Gx_msg = "";
         A148EmployeeName = "";
         Combo_projectid_Selectedvalue_set = "";
         Combo_companylocationid_Selectedvalue_set = "";
         Combo_employeeid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnexportexcel_Jsonclick = "";
         AV10DateRange_RangeText = "";
         lblTextblockcombo_projectid_Jsonclick = "";
         ucCombo_projectid = new GXUserControl();
         lblTextblockcombo_companylocationid_Jsonclick = "";
         ucCombo_companylocationid = new GXUserControl();
         lblTextblockcombo_employeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         lblTextblockshowleavetotal_Jsonclick = "";
         ucPivottable1 = new GXUserControl();
         ucDaterange_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00452_A100CompanyId = new long[1] ;
         H00452_A106EmployeeId = new long[1] ;
         H00452_A157CompanyLocationId = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_SdtWWPDateRangePickerOptions4 = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         H00453_A106EmployeeId = new long[1] ;
         H00453_A148EmployeeName = new string[] {""} ;
         AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00454_A157CompanyLocationId = new long[1] ;
         H00454_A158CompanyLocationName = new string[] {""} ;
         A158CompanyLocationName = "";
         H00455_A102ProjectId = new long[1] ;
         H00455_A103ProjectName = new string[] {""} ;
         A103ProjectName = "";
         AV6blank = "";
         GXt_char5 = "";
         H00456_A166ProjectManagerId = new long[1] ;
         H00456_n166ProjectManagerId = new bool[] {false} ;
         H00456_A102ProjectId = new long[1] ;
         GXt_objcol_int6 = new GxSimpleCollection<long>();
         AV58WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reports__default(),
            new Object[][] {
                new Object[] {
               H00452_A100CompanyId, H00452_A106EmployeeId, H00452_A157CompanyLocationId
               }
               , new Object[] {
               H00453_A106EmployeeId, H00453_A148EmployeeName
               }
               , new Object[] {
               H00454_A157CompanyLocationId, H00454_A158CompanyLocationName
               }
               , new Object[] {
               H00455_A102ProjectId, H00455_A103ProjectName
               }
               , new Object[] {
               H00456_A166ProjectManagerId, H00456_n166ProjectManagerId, H00456_A102ProjectId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
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
      private short AV54View ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divOverviewtable_Visible ;
      private int edtavDaterange_rangetext_Enabled ;
      private int divDetailtable_Visible ;
      private int edtavView_Visible ;
      private int AV51EmployeeIds_Count ;
      private int AV50ProjectIds_Count ;
      private int idxLst ;
      private long A106EmployeeId ;
      private long AV44LoggedInEmployeeId ;
      private long GXt_int1 ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long AV49EmployeeCompanyLocationId ;
      private long A102ProjectId ;
      private long AV70Udparg1 ;
      private long A166ProjectManagerId ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string Pivottable1_Totalformattedworktime ;
      private string Combo_companylocationid_Selectedvalue_get ;
      private string Combo_projectid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV41TotalFormattedWorkTime ;
      private string AV61TotalFormattedTime ;
      private string Gx_msg ;
      private string A148EmployeeName ;
      private string Combo_projectid_Cls ;
      private string Combo_projectid_Selectedvalue_set ;
      private string Combo_projectid_Multiplevaluestype ;
      private string Combo_companylocationid_Cls ;
      private string Combo_companylocationid_Selectedvalue_set ;
      private string Combo_companylocationid_Multiplevaluestype ;
      private string Combo_employeeid_Cls ;
      private string Combo_employeeid_Selectedvalue_set ;
      private string Combo_employeeid_Multiplevaluestype ;
      private string Pivottable1_Totalformattedtime ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnexportexcel_Internalname ;
      private string bttBtnexportexcel_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string divOverviewtable_Internalname ;
      private string divTable1_Internalname ;
      private string edtavDaterange_rangetext_Internalname ;
      private string edtavDaterange_rangetext_Jsonclick ;
      private string divTablesplittedprojectid_Internalname ;
      private string lblTextblockcombo_projectid_Internalname ;
      private string lblTextblockcombo_projectid_Jsonclick ;
      private string Combo_projectid_Caption ;
      private string Combo_projectid_Internalname ;
      private string divTablesplittedcompanylocationid_Internalname ;
      private string lblTextblockcombo_companylocationid_Internalname ;
      private string lblTextblockcombo_companylocationid_Jsonclick ;
      private string Combo_companylocationid_Caption ;
      private string Combo_companylocationid_Internalname ;
      private string divTablesplittedemployeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Jsonclick ;
      private string Combo_employeeid_Caption ;
      private string Combo_employeeid_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtableshowleavetotal_Internalname ;
      private string lblTextblockshowleavetotal_Internalname ;
      private string lblTextblockshowleavetotal_Jsonclick ;
      private string chkavShowleavetotal_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string Pivottable1_Internalname ;
      private string divDetailtable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Daterange_rangepicker_Internalname ;
      private string edtavView_Internalname ;
      private string edtavView_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string A158CompanyLocationName ;
      private string A103ProjectName ;
      private string AV6blank ;
      private string GXt_char5 ;
      private DateTime Gx_date ;
      private DateTime AV8DateRange ;
      private DateTime AV11DateRange_To ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV52IsManager ;
      private bool Combo_projectid_Allowmultipleselection ;
      private bool Combo_projectid_Includeonlyselectedoption ;
      private bool Combo_projectid_Emptyitem ;
      private bool Combo_companylocationid_Allowmultipleselection ;
      private bool Combo_companylocationid_Includeonlyselectedoption ;
      private bool Combo_companylocationid_Emptyitem ;
      private bool Combo_employeeid_Allowmultipleselection ;
      private bool Combo_employeeid_Includeonlyselectedoption ;
      private bool Combo_employeeid_Emptyitem ;
      private bool Pivottable1_Showleavetotal ;
      private bool wbLoad ;
      private bool AV56ShowLeaveTotal ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV53IsProjectManager ;
      private bool GXt_boolean2 ;
      private bool n166ProjectManagerId ;
      private string AV38ExcelFilename ;
      private string AV37ErrorMessage ;
      private string AV10DateRange_RangeText ;
      private GxSimpleCollection<long> AV51EmployeeIds ;
      private GxSimpleCollection<long> AV16ProjectId ;
      private GxSimpleCollection<long> AV21CompanyLocationId ;
      private GxSimpleCollection<long> AV13EmployeeId ;
      private GxSimpleCollection<long> AV50ProjectIds ;
      private GxSimpleCollection<long> GXt_objcol_int6 ;
      private GXUserControl ucCombo_projectid ;
      private GXUserControl ucCombo_companylocationid ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucPivottable1 ;
      private GXUserControl ucDaterange_rangepicker ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavShowleavetotal ;
      private IDataStoreProvider pr_default ;
      private long[] H00452_A100CompanyId ;
      private long[] H00452_A106EmployeeId ;
      private long[] H00452_A157CompanyLocationId ;
      private long[] H00453_A106EmployeeId ;
      private string[] H00453_A148EmployeeName ;
      private long[] H00454_A157CompanyLocationId ;
      private string[] H00454_A158CompanyLocationName ;
      private long[] H00455_A102ProjectId ;
      private string[] H00455_A103ProjectName ;
      private long[] H00456_A166ProjectManagerId ;
      private bool[] H00456_n166ProjectManagerId ;
      private long[] H00456_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV58WebSession ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> AV5SDTEmployeeProjectHoursCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17ProjectId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22CompanyLocationId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14EmployeeId_Data ;
      private GXBaseCollection<SdtSDTProject> AV19SDTProjects ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV7Combo_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV9DateRange_RangePickerOptions ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV12DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
   }

   public class reports__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00453( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV51EmployeeIds ,
                                             int AV51EmployeeIds_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
         if ( AV51EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV51EmployeeIds, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
         GXv_Object7[0] = scmdbuf;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00454( IGxContext context ,
                                             long AV49EmployeeCompanyLocationId ,
                                             bool AV52IsManager ,
                                             bool AV53IsProjectManager ,
                                             long A157CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[1];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation";
         if ( ! (0==AV49EmployeeCompanyLocationId) && ( AV52IsManager ) && ! AV53IsProjectManager )
         {
            AddWhere(sWhereString, "(CompanyLocationId = :AV49EmployeeCompanyLocationId)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationName";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00455( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV50ProjectIds ,
                                             int AV50ProjectIds_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT ProjectId, ProjectName FROM Project";
         if ( AV50ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50ProjectIds, "ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProjectName";
         GXv_Object11[0] = scmdbuf;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H00453(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
               case 2 :
                     return conditional_H00454(context, (long)dynConstraints[0] , (bool)dynConstraints[1] , (bool)dynConstraints[2] , (long)dynConstraints[3] );
               case 3 :
                     return conditional_H00455(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00452;
          prmH00452 = new Object[] {
          new ParDef("AV44LoggedInEmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH00456;
          prmH00456 = new Object[] {
          new ParDef("AV70Udparg1",GXType.Int64,10,0)
          };
          Object[] prmH00453;
          prmH00453 = new Object[] {
          };
          Object[] prmH00454;
          prmH00454 = new Object[] {
          new ParDef("AV49EmployeeCompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmH00455;
          prmH00455 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00452", "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T1.EmployeeId = :AV44LoggedInEmployeeId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00452,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00453", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00453,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00454", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00454,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00455", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00455,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00456", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV70Udparg1 ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00456,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 128);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
