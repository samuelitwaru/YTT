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
   public class workhourloglist : GXDataArea
   {
      public workhourloglist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourloglist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate )
      {
         this.AV52EmployeeId = aP0_EmployeeId;
         this.AV50FromDate = aP1_FromDate;
         this.AV51ToDate = aP2_ToDate;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "EmployeeId");
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
               gxfirstwebparm = GetFirstPar( "EmployeeId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "EmployeeId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
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
               AV52EmployeeId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52EmployeeId", StringUtil.LTrimStr( (decimal)(AV52EmployeeId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52EmployeeId), "ZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV50FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
                  AssignAttri("", false, "AV50FromDate", context.localUtil.Format(AV50FromDate, "99/99/99"));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFROMDATE", GetSecureSignedToken( "", AV50FromDate, context));
                  AV51ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
                  AssignAttri("", false, "AV51ToDate", context.localUtil.Format(AV51ToDate, "99/99/99"));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTODATE", GetSecureSignedToken( "", AV51ToDate, context));
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV52EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
         AV50FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV51ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         AV26ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21ColumnsSelector);
         AV53Pgmname = GetPar( "Pgmname");
         AV27TFEmployeeName = GetPar( "TFEmployeeName");
         AV28TFEmployeeName_Sel = GetPar( "TFEmployeeName_Sel");
         AV29TFProjectName = GetPar( "TFProjectName");
         AV30TFProjectName_Sel = GetPar( "TFProjectName_Sel");
         AV31TFWorkHourLogDate = context.localUtil.ParseDateParm( GetPar( "TFWorkHourLogDate"));
         AV32TFWorkHourLogDate_To = context.localUtil.ParseDateParm( GetPar( "TFWorkHourLogDate_To"));
         AV36TFWorkHourLogDuration = GetPar( "TFWorkHourLogDuration");
         AV37TFWorkHourLogDuration_Sel = GetPar( "TFWorkHourLogDuration_Sel");
         AV38TFWorkHourLogDescription = GetPar( "TFWorkHourLogDescription");
         AV39TFWorkHourLogDescription_Sel = GetPar( "TFWorkHourLogDescription_Sel");
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV52EmployeeId, AV50FromDate, AV51ToDate, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV53Pgmname, AV27TFEmployeeName, AV28TFEmployeeName_Sel, AV29TFProjectName, AV30TFProjectName_Sel, AV31TFWorkHourLogDate, AV32TFWorkHourLogDate_To, AV36TFWorkHourLogDuration, AV37TFWorkHourLogDuration_Sel, AV38TFWorkHourLogDescription, AV39TFWorkHourLogDescription_Sel, AV13OrderedBy, AV14OrderedDsc) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "workhourloglist_Execute" ;
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
         PA492( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START492( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workhourloglist.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV52EmployeeId,10,0)),UrlEncode(DateTimeUtil.FormatDateParm(AV50FromDate)),UrlEncode(DateTimeUtil.FormatDateParm(AV51ToDate))}, new string[] {"EmployeeId","FromDate","ToDate"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vFROMDATE", context.localUtil.DToC( AV50FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vFROMDATE", GetSecureSignedToken( "", AV50FromDate, context));
         GxWebStd.gx_hidden_field( context, "vTODATE", context.localUtil.DToC( AV51ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODATE", GetSecureSignedToken( "", AV51ToDate, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV46GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV47AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV47AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV40DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV40DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_WORKHOURLOGDATEAUXDATE", context.localUtil.DToC( AV33DDO_WorkHourLogDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_WORKHOURLOGDATEAUXDATETO", context.localUtil.DToC( AV34DDO_WorkHourLogDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME", StringUtil.RTrim( AV27TFEmployeeName));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME_SEL", StringUtil.RTrim( AV28TFEmployeeName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROJECTNAME", StringUtil.RTrim( AV29TFProjectName));
         GxWebStd.gx_hidden_field( context, "vTFPROJECTNAME_SEL", StringUtil.RTrim( AV30TFProjectName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDATE", context.localUtil.DToC( AV31TFWorkHourLogDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDATE_TO", context.localUtil.DToC( AV32TFWorkHourLogDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDURATION", AV36TFWorkHourLogDuration);
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDURATION_SEL", AV37TFWorkHourLogDuration_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDESCRIPTION", AV38TFWorkHourLogDescription);
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDESCRIPTION_SEL", AV39TFWorkHourLogDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vFROMDATE", context.localUtil.DToC( AV50FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vFROMDATE", GetSecureSignedToken( "", AV50FromDate, context));
         GxWebStd.gx_hidden_field( context, "vTODATE", context.localUtil.DToC( AV51ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODATE", GetSecureSignedToken( "", AV51ToDate, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
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
            WE492( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT492( ) ;
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
         return formatLink("workhourloglist.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV52EmployeeId,10,0)),UrlEncode(DateTimeUtil.FormatDateParm(AV50FromDate)),UrlEncode(DateTimeUtil.FormatDateParm(AV51ToDate))}, new string[] {"EmployeeId","FromDate","ToDate"})  ;
      }

      public override string GetPgmname( )
      {
         return "WorkHourLogList" ;
      }

      public override string GetPgmdesc( )
      {
         return " Work Hour Log" ;
      }

      protected void WB490( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkHourLogList.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkHourLogList.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_21_492( true) ;
         }
         else
         {
            wb_table1_21_492( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_492e( bool wbgen )
      {
         if ( wbgen )
         {
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl39( ) ;
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV44GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV45GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV46GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV47AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV40DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV40DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_workhourlogdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_workhourlogdateauxdatetext_Internalname, AV35DDO_WorkHourLogDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV35DDO_WorkHourLogDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_workhourlogdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkHourLogList.htm");
            /* User Defined Control */
            ucTfworkhourlogdate_rangepicker.SetProperty("Start Date", AV33DDO_WorkHourLogDateAuxDate);
            ucTfworkhourlogdate_rangepicker.SetProperty("End Date", AV34DDO_WorkHourLogDateAuxDateTo);
            ucTfworkhourlogdate_rangepicker.Render(context, "wwp.daterangepicker", Tfworkhourlogdate_rangepicker_Internalname, "TFWORKHOURLOGDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START492( )
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
         Form.Meta.addItem("description", " Work Hour Log", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP490( ) ;
      }

      protected void WS492( )
      {
         START492( ) ;
         EVT492( ) ;
      }

      protected void EVT492( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11492 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12492 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13492 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14492 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E15492 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16492 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              A103ProjectName = cgiGet( edtProjectName_Internalname);
                              A118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A119WorkHourLogDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtWorkHourLogDate_Internalname), 0));
                              A120WorkHourLogDuration = cgiGet( edtWorkHourLogDuration_Internalname);
                              A121WorkHourLogHour = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogHour_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A122WorkHourLogMinute = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogMinute_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A123WorkHourLogDescription = cgiGet( edtWorkHourLogDescription_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
                              A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17492 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18492 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E19492 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE492( )
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

      protected void PA492( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV16FilterFullText ,
                                       long AV52EmployeeId ,
                                       DateTime AV50FromDate ,
                                       DateTime AV51ToDate ,
                                       short AV26ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       string AV53Pgmname ,
                                       string AV27TFEmployeeName ,
                                       string AV28TFEmployeeName_Sel ,
                                       string AV29TFProjectName ,
                                       string AV30TFProjectName_Sel ,
                                       DateTime AV31TFWorkHourLogDate ,
                                       DateTime AV32TFWorkHourLogDate_To ,
                                       string AV36TFWorkHourLogDuration ,
                                       string AV37TFWorkHourLogDuration_Sel ,
                                       string AV38TFWorkHourLogDescription ,
                                       string AV39TFWorkHourLogDescription_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF492( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF492( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV53Pgmname = "WorkHourLogList";
      }

      protected void RF492( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E18492 ();
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_392( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV54Workhourloglistds_1_filterfulltext ,
                                                 AV56Workhourloglistds_3_tfemployeename_sel ,
                                                 AV55Workhourloglistds_2_tfemployeename ,
                                                 AV58Workhourloglistds_5_tfprojectname_sel ,
                                                 AV57Workhourloglistds_4_tfprojectname ,
                                                 AV59Workhourloglistds_6_tfworkhourlogdate ,
                                                 AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                                 AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                                 AV61Workhourloglistds_8_tfworkhourlogduration ,
                                                 AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                                 AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                                 AV52EmployeeId ,
                                                 AV50FromDate ,
                                                 AV51ToDate ,
                                                 A148EmployeeName ,
                                                 A103ProjectName ,
                                                 A120WorkHourLogDuration ,
                                                 A123WorkHourLogDescription ,
                                                 A119WorkHourLogDate ,
                                                 A106EmployeeId ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
            lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
            lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
            lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
            lV55Workhourloglistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename), 128, "%");
            lV57Workhourloglistds_4_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname), 100, "%");
            lV61Workhourloglistds_8_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration), "%", "");
            lV63Workhourloglistds_10_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription), "%", "");
            /* Using cursor H00492 */
            pr_default.execute(0, new Object[] {lV54Workhourloglistds_1_filterfulltext, lV54Workhourloglistds_1_filterfulltext, lV54Workhourloglistds_1_filterfulltext, lV54Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_2_tfemployeename, AV56Workhourloglistds_3_tfemployeename_sel, lV57Workhourloglistds_4_tfprojectname, AV58Workhourloglistds_5_tfprojectname_sel, AV59Workhourloglistds_6_tfworkhourlogdate, AV60Workhourloglistds_7_tfworkhourlogdate_to, lV61Workhourloglistds_8_tfworkhourlogduration, AV62Workhourloglistds_9_tfworkhourlogduration_sel, lV63Workhourloglistds_10_tfworkhourlogdescription, AV64Workhourloglistds_11_tfworkhourlogdescription_sel, AV52EmployeeId, AV50FromDate, AV51ToDate, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A102ProjectId = H00492_A102ProjectId[0];
               A107EmployeeFirstName = H00492_A107EmployeeFirstName[0];
               A106EmployeeId = H00492_A106EmployeeId[0];
               A123WorkHourLogDescription = H00492_A123WorkHourLogDescription[0];
               A122WorkHourLogMinute = H00492_A122WorkHourLogMinute[0];
               A121WorkHourLogHour = H00492_A121WorkHourLogHour[0];
               A120WorkHourLogDuration = H00492_A120WorkHourLogDuration[0];
               A119WorkHourLogDate = H00492_A119WorkHourLogDate[0];
               A118WorkHourLogId = H00492_A118WorkHourLogId[0];
               A103ProjectName = H00492_A103ProjectName[0];
               A148EmployeeName = H00492_A148EmployeeName[0];
               A103ProjectName = H00492_A103ProjectName[0];
               A107EmployeeFirstName = H00492_A107EmployeeFirstName[0];
               A148EmployeeName = H00492_A148EmployeeName[0];
               E19492 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB490( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes492( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV54Workhourloglistds_1_filterfulltext = AV16FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV27TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV28TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV29TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV30TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV31TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV32TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV36TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV37TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV38TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV39TFWorkHourLogDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Workhourloglistds_1_filterfulltext ,
                                              AV56Workhourloglistds_3_tfemployeename_sel ,
                                              AV55Workhourloglistds_2_tfemployeename ,
                                              AV58Workhourloglistds_5_tfprojectname_sel ,
                                              AV57Workhourloglistds_4_tfprojectname ,
                                              AV59Workhourloglistds_6_tfworkhourlogdate ,
                                              AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                              AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                              AV61Workhourloglistds_8_tfworkhourlogduration ,
                                              AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                              AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                              AV52EmployeeId ,
                                              AV50FromDate ,
                                              AV51ToDate ,
                                              A148EmployeeName ,
                                              A103ProjectName ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A119WorkHourLogDate ,
                                              A106EmployeeId ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
         lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
         lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
         lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
         lV55Workhourloglistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename), 128, "%");
         lV57Workhourloglistds_4_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname), 100, "%");
         lV61Workhourloglistds_8_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration), "%", "");
         lV63Workhourloglistds_10_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription), "%", "");
         /* Using cursor H00493 */
         pr_default.execute(1, new Object[] {lV54Workhourloglistds_1_filterfulltext, lV54Workhourloglistds_1_filterfulltext, lV54Workhourloglistds_1_filterfulltext, lV54Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_2_tfemployeename, AV56Workhourloglistds_3_tfemployeename_sel, lV57Workhourloglistds_4_tfprojectname, AV58Workhourloglistds_5_tfprojectname_sel, AV59Workhourloglistds_6_tfworkhourlogdate, AV60Workhourloglistds_7_tfworkhourlogdate_to, lV61Workhourloglistds_8_tfworkhourlogduration, AV62Workhourloglistds_9_tfworkhourlogduration_sel, lV63Workhourloglistds_10_tfworkhourlogdescription, AV64Workhourloglistds_11_tfworkhourlogdescription_sel, AV52EmployeeId, AV50FromDate, AV51ToDate});
         GRID_nRecordCount = H00493_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV54Workhourloglistds_1_filterfulltext = AV16FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV27TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV28TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV29TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV30TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV31TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV32TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV36TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV37TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV38TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV39TFWorkHourLogDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV52EmployeeId, AV50FromDate, AV51ToDate, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV53Pgmname, AV27TFEmployeeName, AV28TFEmployeeName_Sel, AV29TFProjectName, AV30TFProjectName_Sel, AV31TFWorkHourLogDate, AV32TFWorkHourLogDate_To, AV36TFWorkHourLogDuration, AV37TFWorkHourLogDuration_Sel, AV38TFWorkHourLogDescription, AV39TFWorkHourLogDescription_Sel, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV54Workhourloglistds_1_filterfulltext = AV16FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV27TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV28TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV29TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV30TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV31TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV32TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV36TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV37TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV38TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV39TFWorkHourLogDescription_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV52EmployeeId, AV50FromDate, AV51ToDate, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV53Pgmname, AV27TFEmployeeName, AV28TFEmployeeName_Sel, AV29TFProjectName, AV30TFProjectName_Sel, AV31TFWorkHourLogDate, AV32TFWorkHourLogDate_To, AV36TFWorkHourLogDuration, AV37TFWorkHourLogDuration_Sel, AV38TFWorkHourLogDescription, AV39TFWorkHourLogDescription_Sel, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV54Workhourloglistds_1_filterfulltext = AV16FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV27TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV28TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV29TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV30TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV31TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV32TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV36TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV37TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV38TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV39TFWorkHourLogDescription_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV52EmployeeId, AV50FromDate, AV51ToDate, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV53Pgmname, AV27TFEmployeeName, AV28TFEmployeeName_Sel, AV29TFProjectName, AV30TFProjectName_Sel, AV31TFWorkHourLogDate, AV32TFWorkHourLogDate_To, AV36TFWorkHourLogDuration, AV37TFWorkHourLogDuration_Sel, AV38TFWorkHourLogDescription, AV39TFWorkHourLogDescription_Sel, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV54Workhourloglistds_1_filterfulltext = AV16FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV27TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV28TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV29TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV30TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV31TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV32TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV36TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV37TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV38TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV39TFWorkHourLogDescription_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV52EmployeeId, AV50FromDate, AV51ToDate, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV53Pgmname, AV27TFEmployeeName, AV28TFEmployeeName_Sel, AV29TFProjectName, AV30TFProjectName_Sel, AV31TFWorkHourLogDate, AV32TFWorkHourLogDate_To, AV36TFWorkHourLogDuration, AV37TFWorkHourLogDuration_Sel, AV38TFWorkHourLogDescription, AV39TFWorkHourLogDescription_Sel, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV54Workhourloglistds_1_filterfulltext = AV16FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV27TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV28TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV29TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV30TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV31TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV32TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV36TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV37TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV38TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV39TFWorkHourLogDescription_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV52EmployeeId, AV50FromDate, AV51ToDate, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV53Pgmname, AV27TFEmployeeName, AV28TFEmployeeName_Sel, AV29TFProjectName, AV30TFProjectName_Sel, AV31TFWorkHourLogDate, AV32TFWorkHourLogDate_To, AV36TFWorkHourLogDuration, AV37TFWorkHourLogDuration_Sel, AV38TFWorkHourLogDescription, AV39TFWorkHourLogDescription_Sel, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV53Pgmname = "WorkHourLogList";
         edtEmployeeName_Enabled = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtProjectName_Enabled = 0;
         AssignProp("", false, edtProjectName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectName_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogId_Enabled = 0;
         AssignProp("", false, edtWorkHourLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogId_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogDate_Enabled = 0;
         AssignProp("", false, edtWorkHourLogDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDate_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogDuration_Enabled = 0;
         AssignProp("", false, edtWorkHourLogDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDuration_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogHour_Enabled = 0;
         AssignProp("", false, edtWorkHourLogHour_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogHour_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogMinute_Enabled = 0;
         AssignProp("", false, edtWorkHourLogMinute_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogMinute_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogDescription_Enabled = 0;
         AssignProp("", false, edtWorkHourLogDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDescription_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtEmployeeFirstName_Enabled = 0;
         AssignProp("", false, edtEmployeeFirstName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtProjectId_Enabled = 0;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP490( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17492 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV47AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV40DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ".", ","), 18, MidpointRounding.ToEven));
            AV44GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV45GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV46GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV33DDO_WorkHourLogDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_WORKHOURLOGDATEAUXDATE"), 0);
            AV34DDO_WorkHourLogDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_WORKHOURLOGDATEAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            AV35DDO_WorkHourLogDateAuxDateText = cgiGet( edtavDdo_workhourlogdateauxdatetext_Internalname);
            AssignAttri("", false, "AV35DDO_WorkHourLogDateAuxDateText", AV35DDO_WorkHourLogDateAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E17492 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17492( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         this.executeUsercontrolMethod("", false, "TFWORKHOURLOGDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_workhourlogdateauxdatetext_Internalname});
         subGrid_Rows = 20;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV47AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV48AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV48AGExportDataItem.gxTpr_Title = "Excel";
         AV48AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV48AGExportDataItem.gxTpr_Eventkey = "Export";
         AV48AGExportDataItem.gxTpr_Isdivider = false;
         AV47AGExportData.Add(AV48AGExportDataItem, 0);
         AV41GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV42GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV41GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Work Hour Log";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV40DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV40DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E18492( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV26ManageFiltersExecutionStep == 1 )
         {
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV26ManageFiltersExecutionStep == 2 )
         {
            AV26ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV23Session.Get("WorkHourLogListColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("WorkHourLogListColumnsSelector");
            AV21ColumnsSelector.FromXml(AV19ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtEmployeeName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtProjectName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProjectName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProjectName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogDate_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWorkHourLogDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDate_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogDuration_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWorkHourLogDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDuration_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtWorkHourLogDescription_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWorkHourLogDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDescription_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV44GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV44GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV44GridCurrentPage), 10, 0));
         AV45GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV45GridPageCount", StringUtil.LTrimStr( (decimal)(AV45GridPageCount), 10, 0));
         GXt_char2 = AV46GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV53Pgmname, out  GXt_char2) ;
         AV46GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV46GridAppliedFilters", AV46GridAppliedFilters);
         AV54Workhourloglistds_1_filterfulltext = AV16FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV27TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV28TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV29TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV30TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV31TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV32TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV36TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV37TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV38TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV39TFWorkHourLogDescription_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12492( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV43PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV43PageToGo) ;
         }
      }

      protected void E13492( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15492( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeName") == 0 )
            {
               AV27TFEmployeeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFEmployeeName", AV27TFEmployeeName);
               AV28TFEmployeeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFEmployeeName_Sel", AV28TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProjectName") == 0 )
            {
               AV29TFProjectName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFProjectName", AV29TFProjectName);
               AV30TFProjectName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFProjectName_Sel", AV30TFProjectName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDate") == 0 )
            {
               AV31TFWorkHourLogDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 1);
               AssignAttri("", false, "AV31TFWorkHourLogDate", context.localUtil.Format(AV31TFWorkHourLogDate, "99/99/99"));
               AV32TFWorkHourLogDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 1);
               AssignAttri("", false, "AV32TFWorkHourLogDate_To", context.localUtil.Format(AV32TFWorkHourLogDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDuration") == 0 )
            {
               AV36TFWorkHourLogDuration = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV36TFWorkHourLogDuration", AV36TFWorkHourLogDuration);
               AV37TFWorkHourLogDuration_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFWorkHourLogDuration_Sel", AV37TFWorkHourLogDuration_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDescription") == 0 )
            {
               AV38TFWorkHourLogDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV38TFWorkHourLogDescription", AV38TFWorkHourLogDescription);
               AV39TFWorkHourLogDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFWorkHourLogDescription_Sel", AV39TFWorkHourLogDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E19492( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 39;
         }
         sendrow_392( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, GridRow);
         }
      }

      protected void E16492( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "WorkHourLogListColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11492( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("WorkHourLogListFilters")),UrlEncode(StringUtil.RTrim(AV53Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("WorkHourLogListFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WorkHourLogListFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV25ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV11GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E14492( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "EmployeeName",  "",  "Employee Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ProjectName",  "",  "Project Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "WorkHourLogDate",  "",  "Log Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "WorkHourLogDuration",  "",  "Log Duration",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "WorkHourLogDescription",  "",  "Log Description",  true,  "") ;
         GXt_char2 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WorkHourLogListColumnsSelector", out  GXt_char2) ;
         AV20UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomValue)) ) )
         {
            AV22ColumnsSelectorAux.FromXml(AV20UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV22ColumnsSelectorAux, ref  AV21ColumnsSelector) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV24ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WorkHourLogListFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFEmployeeName = "";
         AssignAttri("", false, "AV27TFEmployeeName", AV27TFEmployeeName);
         AV28TFEmployeeName_Sel = "";
         AssignAttri("", false, "AV28TFEmployeeName_Sel", AV28TFEmployeeName_Sel);
         AV29TFProjectName = "";
         AssignAttri("", false, "AV29TFProjectName", AV29TFProjectName);
         AV30TFProjectName_Sel = "";
         AssignAttri("", false, "AV30TFProjectName_Sel", AV30TFProjectName_Sel);
         AV31TFWorkHourLogDate = DateTime.MinValue;
         AssignAttri("", false, "AV31TFWorkHourLogDate", context.localUtil.Format(AV31TFWorkHourLogDate, "99/99/99"));
         AV32TFWorkHourLogDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV32TFWorkHourLogDate_To", context.localUtil.Format(AV32TFWorkHourLogDate_To, "99/99/99"));
         AV36TFWorkHourLogDuration = "";
         AssignAttri("", false, "AV36TFWorkHourLogDuration", AV36TFWorkHourLogDuration);
         AV37TFWorkHourLogDuration_Sel = "";
         AssignAttri("", false, "AV37TFWorkHourLogDuration_Sel", AV37TFWorkHourLogDuration_Sel);
         AV38TFWorkHourLogDescription = "";
         AssignAttri("", false, "AV38TFWorkHourLogDescription", AV38TFWorkHourLogDescription);
         AV39TFWorkHourLogDescription_Sel = "";
         AssignAttri("", false, "AV39TFWorkHourLogDescription_Sel", AV39TFWorkHourLogDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV53Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV53Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV53Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV65GXV1 = 1;
         while ( AV65GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV65GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV27TFEmployeeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFEmployeeName", AV27TFEmployeeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV28TFEmployeeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFEmployeeName_Sel", AV28TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV29TFProjectName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFProjectName", AV29TFProjectName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV30TFProjectName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFProjectName_Sel", AV30TFProjectName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV31TFWorkHourLogDate = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 1);
               AssignAttri("", false, "AV31TFWorkHourLogDate", context.localUtil.Format(AV31TFWorkHourLogDate, "99/99/99"));
               AV32TFWorkHourLogDate_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 1);
               AssignAttri("", false, "AV32TFWorkHourLogDate_To", context.localUtil.Format(AV32TFWorkHourLogDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV36TFWorkHourLogDuration = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFWorkHourLogDuration", AV36TFWorkHourLogDuration);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV37TFWorkHourLogDuration_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFWorkHourLogDuration_Sel", AV37TFWorkHourLogDuration_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV38TFWorkHourLogDescription = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFWorkHourLogDescription", AV38TFWorkHourLogDescription);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV39TFWorkHourLogDescription_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFWorkHourLogDescription_Sel", AV39TFWorkHourLogDescription_Sel);
            }
            AV65GXV1 = (int)(AV65GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEmployeeName_Sel)),  AV28TFEmployeeName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFProjectName_Sel)),  AV30TFProjectName_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWorkHourLogDuration_Sel)),  AV37TFWorkHourLogDuration_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFWorkHourLogDescription_Sel)),  AV39TFWorkHourLogDescription_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"||"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFEmployeeName)),  AV27TFEmployeeName, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProjectName)),  AV29TFProjectName, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWorkHourLogDuration)),  AV36TFWorkHourLogDuration, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWorkHourLogDescription)),  AV38TFWorkHourLogDescription, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+((DateTime.MinValue==AV31TFWorkHourLogDate) ? "" : context.localUtil.DToC( AV31TFWorkHourLogDate, 1, "/"))+"|"+GXt_char4+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV32TFWorkHourLogDate_To) ? "" : context.localUtil.DToC( AV32TFWorkHourLogDate_To, 1, "/"))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV53Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFEMPLOYEENAME",  "Employee Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFEmployeeName)),  0,  AV27TFEmployeeName,  AV27TFEmployeeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEmployeeName_Sel)),  AV28TFEmployeeName_Sel,  AV28TFEmployeeName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROJECTNAME",  "Project Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProjectName)),  0,  AV29TFProjectName,  AV29TFProjectName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFProjectName_Sel)),  AV30TFProjectName_Sel,  AV30TFProjectName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFWORKHOURLOGDATE",  "Log Date",  !((DateTime.MinValue==AV31TFWorkHourLogDate)&&(DateTime.MinValue==AV32TFWorkHourLogDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV31TFWorkHourLogDate, 1, "/")),  ((DateTime.MinValue==AV31TFWorkHourLogDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV31TFWorkHourLogDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV32TFWorkHourLogDate_To, 1, "/")),  ((DateTime.MinValue==AV32TFWorkHourLogDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV32TFWorkHourLogDate_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFWORKHOURLOGDURATION",  "Log Duration",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWorkHourLogDuration)),  0,  AV36TFWorkHourLogDuration,  AV36TFWorkHourLogDuration,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWorkHourLogDuration_Sel)),  AV37TFWorkHourLogDuration_Sel,  AV37TFWorkHourLogDuration_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFWORKHOURLOGDESCRIPTION",  "Log Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWorkHourLogDescription)),  0,  AV38TFWorkHourLogDescription,  AV38TFWorkHourLogDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFWorkHourLogDescription_Sel)),  AV39TFWorkHourLogDescription_Sel,  AV39TFWorkHourLogDescription_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV53Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "WorkHourLog";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S192( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new workhourloglistexport(context ).execute(  AV52EmployeeId,  AV50FromDate,  AV51ToDate, out  AV17ExcelFilename, out  AV18ErrorMessage) ;
         if ( StringUtil.StrCmp(AV17ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV17ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV18ErrorMessage);
         }
      }

      protected void wb_table1_21_492( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV24ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_26_492( true) ;
         }
         else
         {
            wb_table2_26_492( false) ;
         }
         return  ;
      }

      protected void wb_table2_26_492e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_492e( true) ;
         }
         else
         {
            wb_table1_21_492e( false) ;
         }
      }

      protected void wb_table2_26_492( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WorkHourLogList.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_26_492e( true) ;
         }
         else
         {
            wb_table2_26_492e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV52EmployeeId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV52EmployeeId", StringUtil.LTrimStr( (decimal)(AV52EmployeeId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52EmployeeId), "ZZZZZZZZZ9"), context));
         AV50FromDate = (DateTime)getParm(obj,1);
         AssignAttri("", false, "AV50FromDate", context.localUtil.Format(AV50FromDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_vFROMDATE", GetSecureSignedToken( "", AV50FromDate, context));
         AV51ToDate = (DateTime)getParm(obj,2);
         AssignAttri("", false, "AV51ToDate", context.localUtil.Format(AV51ToDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODATE", GetSecureSignedToken( "", AV51ToDate, context));
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
         PA492( ) ;
         WS492( ) ;
         WE492( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20245238432863", true, true);
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
         context.AddJavascriptSource("workhourloglist.js", "?20245238432864", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_39_idx;
         edtProjectName_Internalname = "PROJECTNAME_"+sGXsfl_39_idx;
         edtWorkHourLogId_Internalname = "WORKHOURLOGID_"+sGXsfl_39_idx;
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE_"+sGXsfl_39_idx;
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION_"+sGXsfl_39_idx;
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR_"+sGXsfl_39_idx;
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE_"+sGXsfl_39_idx;
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION_"+sGXsfl_39_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_39_idx;
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME_"+sGXsfl_39_idx;
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_39_fel_idx;
         edtProjectName_Internalname = "PROJECTNAME_"+sGXsfl_39_fel_idx;
         edtWorkHourLogId_Internalname = "WORKHOURLOGID_"+sGXsfl_39_fel_idx;
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE_"+sGXsfl_39_fel_idx;
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION_"+sGXsfl_39_fel_idx;
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR_"+sGXsfl_39_fel_idx;
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE_"+sGXsfl_39_fel_idx;
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION_"+sGXsfl_39_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_39_fel_idx;
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME_"+sGXsfl_39_fel_idx;
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         SubsflControlProps_392( ) ;
         WB490( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_39_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEmployeeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)128,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProjectName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectName_Internalname,StringUtil.RTrim( A103ProjectName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProjectName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWorkHourLogDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDate_Internalname,context.localUtil.Format(A119WorkHourLogDate, "99/99/99"),context.localUtil.Format( A119WorkHourLogDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWorkHourLogDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWorkHourLogDuration_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDuration_Internalname,(string)A120WorkHourLogDuration,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDuration_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWorkHourLogDuration_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogHour_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogHour_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogMinute_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogMinute_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWorkHourLogDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDescription_Internalname,(string)A123WorkHourLogDescription,(string)A123WorkHourLogDescription,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWorkHourLogDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)39,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeFirstName_Internalname,StringUtil.RTrim( A107EmployeeFirstName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeFirstName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes492( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl39( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"39\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Employee Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProjectName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Project Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWorkHourLogDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWorkHourLogDuration_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Duration") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWorkHourLogDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A103ProjectName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A119WorkHourLogDate, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWorkHourLogDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A120WorkHourLogDuration));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWorkHourLogDuration_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A123WorkHourLogDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWorkHourLogDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EmployeeFirstName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         edtProjectName_Internalname = "PROJECTNAME";
         edtWorkHourLogId_Internalname = "WORKHOURLOGID";
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE";
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION";
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR";
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE";
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME";
         edtProjectId_Internalname = "PROJECTID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_workhourlogdateauxdatetext_Internalname = "vDDO_WORKHOURLOGDATEAUXDATETEXT";
         Tfworkhourlogdate_rangepicker_Internalname = "TFWORKHOURLOGDATE_RANGEPICKER";
         divDdo_workhourlogdateauxdates_Internalname = "DDO_WORKHOURLOGDATEAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtProjectId_Jsonclick = "";
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtWorkHourLogDescription_Jsonclick = "";
         edtWorkHourLogMinute_Jsonclick = "";
         edtWorkHourLogHour_Jsonclick = "";
         edtWorkHourLogDuration_Jsonclick = "";
         edtWorkHourLogDate_Jsonclick = "";
         edtWorkHourLogId_Jsonclick = "";
         edtProjectName_Jsonclick = "";
         edtEmployeeName_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtWorkHourLogDescription_Visible = -1;
         edtWorkHourLogDuration_Visible = -1;
         edtWorkHourLogDate_Visible = -1;
         edtProjectName_Visible = -1;
         edtEmployeeName_Visible = -1;
         edtProjectId_Enabled = 0;
         edtEmployeeFirstName_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtWorkHourLogDescription_Enabled = 0;
         edtWorkHourLogMinute_Enabled = 0;
         edtWorkHourLogHour_Enabled = 0;
         edtWorkHourLogDuration_Enabled = 0;
         edtWorkHourLogDate_Enabled = 0;
         edtWorkHourLogId_Enabled = 0;
         edtProjectName_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_workhourlogdateauxdatetext_Jsonclick = "";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "WorkHourLogListGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|T||T|T";
         Ddo_grid_Filterisrange = "||P||";
         Ddo_grid_Filtertype = "Character|Character|Date|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5";
         Ddo_grid_Columnids = "0:EmployeeName|1:ProjectName|3:WorkHourLogDate|4:WorkHourLogDuration|7:WorkHourLogDescription";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Work Hour Log";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV52EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV50FromDate',fld:'vFROMDATE',pic:'',hsh:true},{av:'AV51ToDate',fld:'vTODATE',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtProjectName_Visible',ctrl:'PROJECTNAME',prop:'Visible'},{av:'edtWorkHourLogDate_Visible',ctrl:'WORKHOURLOGDATE',prop:'Visible'},{av:'edtWorkHourLogDuration_Visible',ctrl:'WORKHOURLOGDURATION',prop:'Visible'},{av:'edtWorkHourLogDescription_Visible',ctrl:'WORKHOURLOGDESCRIPTION',prop:'Visible'},{av:'AV44GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV45GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV46GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12492',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV52EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV50FromDate',fld:'vFROMDATE',pic:'',hsh:true},{av:'AV51ToDate',fld:'vTODATE',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13492',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV52EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV50FromDate',fld:'vFROMDATE',pic:'',hsh:true},{av:'AV51ToDate',fld:'vTODATE',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E15492',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV52EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV50FromDate',fld:'vFROMDATE',pic:'',hsh:true},{av:'AV51ToDate',fld:'vTODATE',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E19492',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E16492',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV52EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV50FromDate',fld:'vFROMDATE',pic:'',hsh:true},{av:'AV51ToDate',fld:'vTODATE',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtProjectName_Visible',ctrl:'PROJECTNAME',prop:'Visible'},{av:'edtWorkHourLogDate_Visible',ctrl:'WORKHOURLOGDATE',prop:'Visible'},{av:'edtWorkHourLogDuration_Visible',ctrl:'WORKHOURLOGDURATION',prop:'Visible'},{av:'edtWorkHourLogDescription_Visible',ctrl:'WORKHOURLOGDESCRIPTION',prop:'Visible'},{av:'AV44GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV45GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV46GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11492',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV52EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV50FromDate',fld:'vFROMDATE',pic:'',hsh:true},{av:'AV51ToDate',fld:'vTODATE',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtProjectName_Visible',ctrl:'PROJECTNAME',prop:'Visible'},{av:'edtWorkHourLogDate_Visible',ctrl:'WORKHOURLOGDATE',prop:'Visible'},{av:'edtWorkHourLogDuration_Visible',ctrl:'WORKHOURLOGDURATION',prop:'Visible'},{av:'edtWorkHourLogDescription_Visible',ctrl:'WORKHOURLOGDESCRIPTION',prop:'Visible'},{av:'AV44GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV45GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV46GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14492',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV52EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV50FromDate',fld:'vFROMDATE',pic:'',hsh:true},{av:'AV51ToDate',fld:'vTODATE',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV52EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV50FromDate',fld:'vFROMDATE',pic:'',hsh:true},{av:'AV51ToDate',fld:'vTODATE',pic:'',hsh:true},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV28TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV29TFProjectName',fld:'vTFPROJECTNAME',pic:''},{av:'AV30TFProjectName_Sel',fld:'vTFPROJECTNAME_SEL',pic:''},{av:'AV31TFWorkHourLogDate',fld:'vTFWORKHOURLOGDATE',pic:''},{av:'AV32TFWorkHourLogDate_To',fld:'vTFWORKHOURLOGDATE_TO',pic:''},{av:'AV36TFWorkHourLogDuration',fld:'vTFWORKHOURLOGDURATION',pic:''},{av:'AV37TFWorkHourLogDuration_Sel',fld:'vTFWORKHOURLOGDURATION_SEL',pic:''},{av:'AV38TFWorkHourLogDescription',fld:'vTFWORKHOURLOGDESCRIPTION',pic:''},{av:'AV39TFWorkHourLogDescription_Sel',fld:'vTFWORKHOURLOGDESCRIPTION_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("VALID_EMPLOYEEID","{handler:'Valid_Employeeid',iparms:[]");
         setEventMetadata("VALID_EMPLOYEEID",",oparms:[]}");
         setEventMetadata("VALID_PROJECTID","{handler:'Valid_Projectid',iparms:[]");
         setEventMetadata("VALID_PROJECTID",",oparms:[]}");
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
         wcpOAV50FromDate = DateTime.MinValue;
         wcpOAV51ToDate = DateTime.MinValue;
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV53Pgmname = "";
         AV27TFEmployeeName = "";
         AV28TFEmployeeName_Sel = "";
         AV29TFProjectName = "";
         AV30TFProjectName_Sel = "";
         AV31TFWorkHourLogDate = DateTime.MinValue;
         AV32TFWorkHourLogDate_To = DateTime.MinValue;
         AV36TFWorkHourLogDuration = "";
         AV37TFWorkHourLogDuration_Sel = "";
         AV38TFWorkHourLogDescription = "";
         AV39TFWorkHourLogDescription_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46GridAppliedFilters = "";
         AV47AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV33DDO_WorkHourLogDateAuxDate = DateTime.MinValue;
         AV34DDO_WorkHourLogDateAuxDateTo = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV35DDO_WorkHourLogDateAuxDateText = "";
         ucTfworkhourlogdate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A148EmployeeName = "";
         A103ProjectName = "";
         A119WorkHourLogDate = DateTime.MinValue;
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         scmdbuf = "";
         lV54Workhourloglistds_1_filterfulltext = "";
         lV55Workhourloglistds_2_tfemployeename = "";
         lV57Workhourloglistds_4_tfprojectname = "";
         lV61Workhourloglistds_8_tfworkhourlogduration = "";
         lV63Workhourloglistds_10_tfworkhourlogdescription = "";
         AV54Workhourloglistds_1_filterfulltext = "";
         AV56Workhourloglistds_3_tfemployeename_sel = "";
         AV55Workhourloglistds_2_tfemployeename = "";
         AV58Workhourloglistds_5_tfprojectname_sel = "";
         AV57Workhourloglistds_4_tfprojectname = "";
         AV59Workhourloglistds_6_tfworkhourlogdate = DateTime.MinValue;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = DateTime.MinValue;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = "";
         AV61Workhourloglistds_8_tfworkhourlogduration = "";
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = "";
         AV63Workhourloglistds_10_tfworkhourlogdescription = "";
         H00492_A102ProjectId = new long[1] ;
         H00492_A107EmployeeFirstName = new string[] {""} ;
         H00492_A106EmployeeId = new long[1] ;
         H00492_A123WorkHourLogDescription = new string[] {""} ;
         H00492_A122WorkHourLogMinute = new short[1] ;
         H00492_A121WorkHourLogHour = new short[1] ;
         H00492_A120WorkHourLogDuration = new string[] {""} ;
         H00492_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         H00492_A118WorkHourLogId = new long[1] ;
         H00492_A103ProjectName = new string[] {""} ;
         H00492_A148EmployeeName = new string[] {""} ;
         H00493_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV48AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV41GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV42GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV19ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         AV20UserCustomValue = "";
         AV22ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourloglist__default(),
            new Object[][] {
                new Object[] {
               H00492_A102ProjectId, H00492_A107EmployeeFirstName, H00492_A106EmployeeId, H00492_A123WorkHourLogDescription, H00492_A122WorkHourLogMinute, H00492_A121WorkHourLogHour, H00492_A120WorkHourLogDuration, H00492_A119WorkHourLogDate, H00492_A118WorkHourLogId, H00492_A103ProjectName,
               H00492_A148EmployeeName
               }
               , new Object[] {
               H00493_AGRID_nRecordCount
               }
            }
         );
         AV53Pgmname = "WorkHourLogList";
         /* GeneXus formulas. */
         AV53Pgmname = "WorkHourLogList";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtEmployeeName_Enabled ;
      private int edtProjectName_Enabled ;
      private int edtWorkHourLogId_Enabled ;
      private int edtWorkHourLogDate_Enabled ;
      private int edtWorkHourLogDuration_Enabled ;
      private int edtWorkHourLogHour_Enabled ;
      private int edtWorkHourLogMinute_Enabled ;
      private int edtWorkHourLogDescription_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtProjectId_Enabled ;
      private int edtEmployeeName_Visible ;
      private int edtProjectName_Visible ;
      private int edtWorkHourLogDate_Visible ;
      private int edtWorkHourLogDuration_Visible ;
      private int edtWorkHourLogDescription_Visible ;
      private int AV43PageToGo ;
      private int AV65GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV52EmployeeId ;
      private long wcpOAV52EmployeeId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44GridCurrentPage ;
      private long AV45GridPageCount ;
      private long A118WorkHourLogId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV53Pgmname ;
      private string AV27TFEmployeeName ;
      private string AV28TFEmployeeName_Sel ;
      private string AV29TFProjectName ;
      private string AV30TFProjectName_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_workhourlogdateauxdates_Internalname ;
      private string edtavDdo_workhourlogdateauxdatetext_Internalname ;
      private string edtavDdo_workhourlogdateauxdatetext_Jsonclick ;
      private string Tfworkhourlogdate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Internalname ;
      private string A103ProjectName ;
      private string edtProjectName_Internalname ;
      private string edtWorkHourLogId_Internalname ;
      private string edtWorkHourLogDate_Internalname ;
      private string edtWorkHourLogDuration_Internalname ;
      private string edtWorkHourLogHour_Internalname ;
      private string edtWorkHourLogMinute_Internalname ;
      private string edtWorkHourLogDescription_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string A107EmployeeFirstName ;
      private string edtEmployeeFirstName_Internalname ;
      private string edtProjectId_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string lV55Workhourloglistds_2_tfemployeename ;
      private string lV57Workhourloglistds_4_tfprojectname ;
      private string AV56Workhourloglistds_3_tfemployeename_sel ;
      private string AV55Workhourloglistds_2_tfemployeename ;
      private string AV58Workhourloglistds_5_tfprojectname_sel ;
      private string AV57Workhourloglistds_4_tfprojectname ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtEmployeeName_Jsonclick ;
      private string edtProjectName_Jsonclick ;
      private string edtWorkHourLogId_Jsonclick ;
      private string edtWorkHourLogDate_Jsonclick ;
      private string edtWorkHourLogDuration_Jsonclick ;
      private string edtWorkHourLogHour_Jsonclick ;
      private string edtWorkHourLogMinute_Jsonclick ;
      private string edtWorkHourLogDescription_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtProjectId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV50FromDate ;
      private DateTime AV51ToDate ;
      private DateTime wcpOAV50FromDate ;
      private DateTime wcpOAV51ToDate ;
      private DateTime AV31TFWorkHourLogDate ;
      private DateTime AV32TFWorkHourLogDate_To ;
      private DateTime AV33DDO_WorkHourLogDateAuxDate ;
      private DateTime AV34DDO_WorkHourLogDateAuxDateTo ;
      private DateTime A119WorkHourLogDate ;
      private DateTime AV59Workhourloglistds_6_tfworkhourlogdate ;
      private DateTime AV60Workhourloglistds_7_tfworkhourlogdate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A123WorkHourLogDescription ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV36TFWorkHourLogDuration ;
      private string AV37TFWorkHourLogDuration_Sel ;
      private string AV38TFWorkHourLogDescription ;
      private string AV39TFWorkHourLogDescription_Sel ;
      private string AV46GridAppliedFilters ;
      private string AV35DDO_WorkHourLogDateAuxDateText ;
      private string A120WorkHourLogDuration ;
      private string lV54Workhourloglistds_1_filterfulltext ;
      private string lV61Workhourloglistds_8_tfworkhourlogduration ;
      private string lV63Workhourloglistds_10_tfworkhourlogdescription ;
      private string AV54Workhourloglistds_1_filterfulltext ;
      private string AV62Workhourloglistds_9_tfworkhourlogduration_sel ;
      private string AV61Workhourloglistds_8_tfworkhourlogduration ;
      private string AV64Workhourloglistds_11_tfworkhourlogdescription_sel ;
      private string AV63Workhourloglistds_10_tfworkhourlogdescription ;
      private string AV17ExcelFilename ;
      private string AV18ErrorMessage ;
      private IGxSession AV23Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfworkhourlogdate_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H00492_A102ProjectId ;
      private string[] H00492_A107EmployeeFirstName ;
      private long[] H00492_A106EmployeeId ;
      private string[] H00492_A123WorkHourLogDescription ;
      private short[] H00492_A122WorkHourLogMinute ;
      private short[] H00492_A121WorkHourLogHour ;
      private string[] H00492_A120WorkHourLogDuration ;
      private DateTime[] H00492_A119WorkHourLogDate ;
      private long[] H00492_A118WorkHourLogId ;
      private string[] H00492_A103ProjectName ;
      private string[] H00492_A148EmployeeName ;
      private long[] H00493_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV47AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV42GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV48AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV40DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV41GAMSession ;
   }

   public class workhourloglist__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00492( IGxContext context ,
                                             string AV54Workhourloglistds_1_filterfulltext ,
                                             string AV56Workhourloglistds_3_tfemployeename_sel ,
                                             string AV55Workhourloglistds_2_tfemployeename ,
                                             string AV58Workhourloglistds_5_tfprojectname_sel ,
                                             string AV57Workhourloglistds_4_tfprojectname ,
                                             DateTime AV59Workhourloglistds_6_tfworkhourlogdate ,
                                             DateTime AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                             string AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                             string AV61Workhourloglistds_8_tfworkhourlogduration ,
                                             string AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                             string AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                             long AV52EmployeeId ,
                                             DateTime AV50FromDate ,
                                             DateTime AV51ToDate ,
                                             string A148EmployeeName ,
                                             string A103ProjectName ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             DateTime A119WorkHourLogDate ,
                                             long A106EmployeeId ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[20];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ProjectId, T3.EmployeeFirstName, T1.EmployeeId, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDuration, T1.WorkHourLogDate, T1.WorkHourLogId, T2.ProjectName, T3.EmployeeName";
         sFromString = " FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T3.EmployeeName) like '%' || LOWER(:lV54Workhourloglistds_1_filterfulltext)) or ( LOWER(T2.ProjectName) like '%' || LOWER(:lV54Workhourloglistds_1_filterfulltext)) or ( LOWER(T1.WorkHourLogDuration) like '%' || LOWER(:lV54Workhourloglistds_1_filterfulltext)) or ( LOWER(T1.WorkHourLogDescription) like '%' || LOWER(:lV54Workhourloglistds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV55Workhourloglistds_2_tfemployeename))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV56Workhourloglistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.ProjectName) like LOWER(:lV57Workhourloglistds_4_tfprojectname))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV58Workhourloglistds_5_tfprojectname_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( ! (DateTime.MinValue==AV59Workhourloglistds_6_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV59Workhourloglistds_6_tfworkhourlogdate)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Workhourloglistds_7_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV60Workhourloglistds_7_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDuration) like LOWER(:lV61Workhourloglistds_8_tfworkhourlogduration))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV62Workhourloglistds_9_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDescription) like LOWER(:lV63Workhourloglistds_10_tfworkhourlogdescription))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV64Workhourloglistds_11_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV52EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV52EmployeeId)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV50FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV50FromDate)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV51ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV51ToDate)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDate, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDate DESC, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.EmployeeName, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.EmployeeName DESC, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ProjectName, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ProjectName DESC, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDuration, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDuration DESC, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDescription, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDescription DESC, T1.WorkHourLogId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.WorkHourLogId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H00493( IGxContext context ,
                                             string AV54Workhourloglistds_1_filterfulltext ,
                                             string AV56Workhourloglistds_3_tfemployeename_sel ,
                                             string AV55Workhourloglistds_2_tfemployeename ,
                                             string AV58Workhourloglistds_5_tfprojectname_sel ,
                                             string AV57Workhourloglistds_4_tfprojectname ,
                                             DateTime AV59Workhourloglistds_6_tfworkhourlogdate ,
                                             DateTime AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                             string AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                             string AV61Workhourloglistds_8_tfworkhourlogduration ,
                                             string AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                             string AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                             long AV52EmployeeId ,
                                             DateTime AV50FromDate ,
                                             DateTime AV51ToDate ,
                                             string A148EmployeeName ,
                                             string A103ProjectName ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             DateTime A119WorkHourLogDate ,
                                             long A106EmployeeId ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[17];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((WorkHourLog T1 INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId) INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.EmployeeName) like '%' || LOWER(:lV54Workhourloglistds_1_filterfulltext)) or ( LOWER(T3.ProjectName) like '%' || LOWER(:lV54Workhourloglistds_1_filterfulltext)) or ( LOWER(T1.WorkHourLogDuration) like '%' || LOWER(:lV54Workhourloglistds_1_filterfulltext)) or ( LOWER(T1.WorkHourLogDescription) like '%' || LOWER(:lV54Workhourloglistds_1_filterfulltext)))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeName) like LOWER(:lV55Workhourloglistds_2_tfemployeename))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV56Workhourloglistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.ProjectName) like LOWER(:lV57Workhourloglistds_4_tfprojectname))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV58Workhourloglistds_5_tfprojectname_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         if ( ! (DateTime.MinValue==AV59Workhourloglistds_6_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV59Workhourloglistds_6_tfworkhourlogdate)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Workhourloglistds_7_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV60Workhourloglistds_7_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDuration) like LOWER(:lV61Workhourloglistds_8_tfworkhourlogduration))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV62Workhourloglistds_9_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDescription) like LOWER(:lV63Workhourloglistds_10_tfworkhourlogdescription))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV64Workhourloglistds_11_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV52EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV52EmployeeId)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV50FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV50FromDate)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV51ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV51ToDate)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00492(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (long)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
               case 1 :
                     return conditional_H00493(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (long)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00492;
          prmH00492 = new Object[] {
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_2_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV56Workhourloglistds_3_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV57Workhourloglistds_4_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV58Workhourloglistds_5_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("AV59Workhourloglistds_6_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV60Workhourloglistds_7_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV61Workhourloglistds_8_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV62Workhourloglistds_9_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV63Workhourloglistds_10_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV64Workhourloglistds_11_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV52EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV50FromDate",GXType.Date,8,0) ,
          new ParDef("AV51ToDate",GXType.Date,8,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00493;
          prmH00493 = new Object[] {
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_2_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV56Workhourloglistds_3_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV57Workhourloglistds_4_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV58Workhourloglistds_5_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("AV59Workhourloglistds_6_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV60Workhourloglistds_7_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV61Workhourloglistds_8_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV62Workhourloglistds_9_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV63Workhourloglistds_10_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV64Workhourloglistds_11_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV52EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV50FromDate",GXType.Date,8,0) ,
          new ParDef("AV51ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00492", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00492,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00493", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00493,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((string[]) buf[10])[0] = rslt.getString(11, 128);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
