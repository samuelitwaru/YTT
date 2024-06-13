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
   public class leaverequestww : GXDataArea
   {
      public leaverequestww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Mesage )
      {
         this.AV73Mesage = aP0_Mesage;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbLeaveRequestStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mesage");
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
               gxfirstwebparm = GetFirstPar( "Mesage");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mesage");
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
               AV73Mesage = gxfirstwebparm;
               AssignAttri("", false, "AV73Mesage", AV73Mesage);
               GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Mesage, "")), context));
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
         nRC_GXsfl_41 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_41"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_41_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_41_idx = GetPar( "sGXsfl_41_idx");
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
         AV26ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21ColumnsSelector);
         AV83Pgmname = GetPar( "Pgmname");
         AV31TFLeaveTypeName = GetPar( "TFLeaveTypeName");
         AV32TFLeaveTypeName_Sel = GetPar( "TFLeaveTypeName_Sel");
         AV38TFLeaveRequestStartDate = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestStartDate"));
         AV39TFLeaveRequestStartDate_To = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestStartDate_To"));
         AV43TFLeaveRequestEndDate = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestEndDate"));
         AV44TFLeaveRequestEndDate_To = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestEndDate_To"));
         AV75TFLeaveRequestHalfDay = GetPar( "TFLeaveRequestHalfDay");
         AV80TFLeaveRequestHalfDayOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFLeaveRequestHalfDayOperator"), "."), 18, MidpointRounding.ToEven));
         AV76TFLeaveRequestHalfDay_Sel = GetPar( "TFLeaveRequestHalfDay_Sel");
         AV48TFLeaveRequestDuration = NumberUtil.Val( GetPar( "TFLeaveRequestDuration"), ".");
         AV49TFLeaveRequestDuration_To = NumberUtil.Val( GetPar( "TFLeaveRequestDuration_To"), ".");
         AV77TFLeaveRequestStatus = GetPar( "TFLeaveRequestStatus");
         AV78TFLeaveRequestStatusOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFLeaveRequestStatusOperator"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV51TFLeaveRequestStatus_Sels);
         AV52TFLeaveRequestDescription = GetPar( "TFLeaveRequestDescription");
         AV53TFLeaveRequestDescription_Sel = GetPar( "TFLeaveRequestDescription_Sel");
         AV54TFLeaveRequestRejectionReason = GetPar( "TFLeaveRequestRejectionReason");
         AV55TFLeaveRequestRejectionReason_Sel = GetPar( "TFLeaveRequestRejectionReason_Sel");
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV66IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV68IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV71IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         AV73Mesage = GetPar( "Mesage");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV83Pgmname, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV75TFLeaveRequestHalfDay, AV80TFLeaveRequestHalfDayOperator, AV76TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV77TFLeaveRequestStatus, AV78TFLeaveRequestStatusOperator, AV51TFLeaveRequestStatus_Sels, AV52TFLeaveRequestDescription, AV53TFLeaveRequestDescription_Sel, AV54TFLeaveRequestRejectionReason, AV55TFLeaveRequestRejectionReason_Sel, AV13OrderedBy, AV14OrderedDsc, AV66IsAuthorized_Update, AV68IsAuthorized_Delete, AV71IsAuthorized_Insert, AV73Mesage) ;
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
            return "leaverequestww_Execute" ;
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
         PA4C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4C2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leaverequestww.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV73Mesage))}, new string[] {"Mesage"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV66IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV66IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV68IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV68IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV71IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV71IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vMESAGE", AV73Mesage);
         GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Mesage, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV64GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV69AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV69AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV58DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV58DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTSTARTDATEAUXDATE", context.localUtil.DToC( AV40DDO_LeaveRequestStartDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTSTARTDATEAUXDATETO", context.localUtil.DToC( AV41DDO_LeaveRequestStartDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTENDDATEAUXDATE", context.localUtil.DToC( AV45DDO_LeaveRequestEndDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTENDDATEAUXDATETO", context.localUtil.DToC( AV46DDO_LeaveRequestEndDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFLEAVETYPENAME", StringUtil.RTrim( AV31TFLeaveTypeName));
         GxWebStd.gx_hidden_field( context, "vTFLEAVETYPENAME_SEL", StringUtil.RTrim( AV32TFLeaveTypeName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTARTDATE", context.localUtil.DToC( AV38TFLeaveRequestStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTARTDATE_TO", context.localUtil.DToC( AV39TFLeaveRequestStartDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTENDDATE", context.localUtil.DToC( AV43TFLeaveRequestEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTENDDATE_TO", context.localUtil.DToC( AV44TFLeaveRequestEndDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTHALFDAY", StringUtil.RTrim( AV75TFLeaveRequestHalfDay));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTHALFDAYOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80TFLeaveRequestHalfDayOperator), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTHALFDAY_SEL", StringUtil.RTrim( AV76TFLeaveRequestHalfDay_Sel));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDURATION", StringUtil.LTrim( StringUtil.NToC( AV48TFLeaveRequestDuration, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDURATION_TO", StringUtil.LTrim( StringUtil.NToC( AV49TFLeaveRequestDuration_To, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTATUS", StringUtil.RTrim( AV77TFLeaveRequestStatus));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTATUSOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78TFLeaveRequestStatusOperator), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFLEAVEREQUESTSTATUS_SELS", AV51TFLeaveRequestStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFLEAVEREQUESTSTATUS_SELS", AV51TFLeaveRequestStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDESCRIPTION", AV52TFLeaveRequestDescription);
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDESCRIPTION_SEL", AV53TFLeaveRequestDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTREJECTIONREASON", AV54TFLeaveRequestRejectionReason);
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTREJECTIONREASON_SEL", AV55TFLeaveRequestRejectionReason_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV66IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV66IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV68IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV68IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTATUS_SELSJSON", AV50TFLeaveRequestStatus_SelsJson);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV71IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV71IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vMESAGE", AV73Mesage);
         GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Mesage, "")), context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixedfilters", StringUtil.RTrim( Ddo_grid_Fixedfilters));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE4C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4C2( ) ;
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
         return formatLink("leaverequestww.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV73Mesage))}, new string[] {"Mesage"})  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveRequestWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Leave Request" ;
      }

      protected void WB4C0( )
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
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_23_4C2( true) ;
         }
         else
         {
            wb_table1_23_4C2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_4C2e( bool wbgen )
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
            StartGridControl41( ) ;
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            nRC_GXsfl_41 = (int)(nGXsfl_41_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV62GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV63GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV64GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV69AGExportData);
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("FixedFilters", Ddo_grid_Fixedfilters);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV58DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV58DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_leaverequeststartdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_leaverequeststartdateauxdatetext_Internalname, AV42DDO_LeaveRequestStartDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV42DDO_LeaveRequestStartDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_leaverequeststartdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestWW.htm");
            /* User Defined Control */
            ucTfleaverequeststartdate_rangepicker.SetProperty("Start Date", AV40DDO_LeaveRequestStartDateAuxDate);
            ucTfleaverequeststartdate_rangepicker.SetProperty("End Date", AV41DDO_LeaveRequestStartDateAuxDateTo);
            ucTfleaverequeststartdate_rangepicker.Render(context, "wwp.daterangepicker", Tfleaverequeststartdate_rangepicker_Internalname, "TFLEAVEREQUESTSTARTDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_leaverequestenddateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_leaverequestenddateauxdatetext_Internalname, AV47DDO_LeaveRequestEndDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV47DDO_LeaveRequestEndDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_leaverequestenddateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestWW.htm");
            /* User Defined Control */
            ucTfleaverequestenddate_rangepicker.SetProperty("Start Date", AV45DDO_LeaveRequestEndDateAuxDate);
            ucTfleaverequestenddate_rangepicker.SetProperty("End Date", AV46DDO_LeaveRequestEndDateAuxDateTo);
            ucTfleaverequestenddate_rangepicker.Render(context, "wwp.daterangepicker", Tfleaverequestenddate_rangepicker_Internalname, "TFLEAVEREQUESTENDDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 41 )
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

      protected void START4C2( )
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
         Form.Meta.addItem("description", " Leave Request", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4C0( ) ;
      }

      protected void WS4C2( )
      {
         START4C2( ) ;
         EVT4C2( ) ;
      }

      protected void EVT4C2( )
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
                              E114C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E144C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E154C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E164C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E174C2 ();
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
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_412( ) ;
                              AV65Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV65Update);
                              AV67Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV67Delete);
                              A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A125LeaveTypeName = cgiGet( edtLeaveTypeName_Internalname);
                              A128LeaveRequestDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestDate_Internalname), 0));
                              A129LeaveRequestStartDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestStartDate_Internalname), 0));
                              A130LeaveRequestEndDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestEndDate_Internalname), 0));
                              A173LeaveRequestHalfDay = cgiGet( edtLeaveRequestHalfDay_Internalname);
                              n173LeaveRequestHalfDay = false;
                              A131LeaveRequestDuration = context.localUtil.CToN( cgiGet( edtLeaveRequestDuration_Internalname), ".", ",");
                              cmbLeaveRequestStatus.Name = cmbLeaveRequestStatus_Internalname;
                              cmbLeaveRequestStatus.CurrentValue = cgiGet( cmbLeaveRequestStatus_Internalname);
                              A132LeaveRequestStatus = cgiGet( cmbLeaveRequestStatus_Internalname);
                              A133LeaveRequestDescription = cgiGet( edtLeaveRequestDescription_Internalname);
                              A134LeaveRequestRejectionReason = cgiGet( edtLeaveRequestRejectionReason_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E184C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E194C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E204C2 ();
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

      protected void WE4C2( )
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

      protected void PA4C2( )
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
         SubsflControlProps_412( ) ;
         while ( nGXsfl_41_idx <= nRC_GXsfl_41 )
         {
            sendrow_412( ) ;
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV16FilterFullText ,
                                       short AV26ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       string AV83Pgmname ,
                                       string AV31TFLeaveTypeName ,
                                       string AV32TFLeaveTypeName_Sel ,
                                       DateTime AV38TFLeaveRequestStartDate ,
                                       DateTime AV39TFLeaveRequestStartDate_To ,
                                       DateTime AV43TFLeaveRequestEndDate ,
                                       DateTime AV44TFLeaveRequestEndDate_To ,
                                       string AV75TFLeaveRequestHalfDay ,
                                       short AV80TFLeaveRequestHalfDayOperator ,
                                       string AV76TFLeaveRequestHalfDay_Sel ,
                                       decimal AV48TFLeaveRequestDuration ,
                                       decimal AV49TFLeaveRequestDuration_To ,
                                       string AV77TFLeaveRequestStatus ,
                                       short AV78TFLeaveRequestStatusOperator ,
                                       GxSimpleCollection<string> AV51TFLeaveRequestStatus_Sels ,
                                       string AV52TFLeaveRequestDescription ,
                                       string AV53TFLeaveRequestDescription_Sel ,
                                       string AV54TFLeaveRequestRejectionReason ,
                                       string AV55TFLeaveRequestRejectionReason_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV66IsAuthorized_Update ,
                                       bool AV68IsAuthorized_Delete ,
                                       bool AV71IsAuthorized_Insert ,
                                       string AV73Mesage )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4C2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_LEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "LEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")));
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
         RF4C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV83Pgmname = "LeaveRequestWW";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_41_Refreshing);
      }

      protected void RF4C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E194C2 ();
         nGXsfl_41_idx = 1;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         bGXsfl_41_Refreshing = true;
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
            SubsflControlProps_412( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A132LeaveRequestStatus ,
                                                 AV98Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                                 AV84Leaverequestwwds_2_filterfulltext ,
                                                 AV86Leaverequestwwds_4_tfleavetypename_sel ,
                                                 AV85Leaverequestwwds_3_tfleavetypename ,
                                                 AV87Leaverequestwwds_5_tfleaverequeststartdate ,
                                                 AV88Leaverequestwwds_6_tfleaverequeststartdate_to ,
                                                 AV89Leaverequestwwds_7_tfleaverequestenddate ,
                                                 AV90Leaverequestwwds_8_tfleaverequestenddate_to ,
                                                 AV93Leaverequestwwds_11_tfleaverequesthalfday_sel ,
                                                 AV91Leaverequestwwds_9_tfleaverequesthalfday ,
                                                 AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator ,
                                                 AV94Leaverequestwwds_12_tfleaverequestduration ,
                                                 AV95Leaverequestwwds_13_tfleaverequestduration_to ,
                                                 AV98Leaverequestwwds_16_tfleaverequeststatus_sels.Count ,
                                                 AV97Leaverequestwwds_15_tfleaverequeststatusoperator ,
                                                 AV100Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                                 AV99Leaverequestwwds_17_tfleaverequestdescription ,
                                                 AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                                 AV101Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                                 A125LeaveTypeName ,
                                                 A173LeaveRequestHalfDay ,
                                                 A131LeaveRequestDuration ,
                                                 A133LeaveRequestDescription ,
                                                 A134LeaveRequestRejectionReason ,
                                                 A129LeaveRequestStartDate ,
                                                 A130LeaveRequestEndDate ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A100CompanyId ,
                                                 AV103Udparg21 ,
                                                 A106EmployeeId ,
                                                 AV81Udparg1 } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
            lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
            lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
            lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
            lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
            lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
            lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
            lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
            lV85Leaverequestwwds_3_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV85Leaverequestwwds_3_tfleavetypename), 100, "%");
            lV91Leaverequestwwds_9_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV91Leaverequestwwds_9_tfleaverequesthalfday), 20, "%");
            lV99Leaverequestwwds_17_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV99Leaverequestwwds_17_tfleaverequestdescription), "%", "");
            lV101Leaverequestwwds_19_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV101Leaverequestwwds_19_tfleaverequestrejectionreason), "%", "");
            /* Using cursor H004C2 */
            pr_default.execute(0, new Object[] {AV103Udparg21, AV81Udparg1, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV85Leaverequestwwds_3_tfleavetypename, AV86Leaverequestwwds_4_tfleavetypename_sel, AV87Leaverequestwwds_5_tfleaverequeststartdate, AV88Leaverequestwwds_6_tfleaverequeststartdate_to, AV89Leaverequestwwds_7_tfleaverequestenddate, AV90Leaverequestwwds_8_tfleaverequestenddate_to, lV91Leaverequestwwds_9_tfleaverequesthalfday, AV93Leaverequestwwds_11_tfleaverequesthalfday_sel, AV94Leaverequestwwds_12_tfleaverequestduration, AV95Leaverequestwwds_13_tfleaverequestduration_to, lV99Leaverequestwwds_17_tfleaverequestdescription, AV100Leaverequestwwds_18_tfleaverequestdescription_sel, lV101Leaverequestwwds_19_tfleaverequestrejectionreason, AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_41_idx = 1;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A100CompanyId = H004C2_A100CompanyId[0];
               A106EmployeeId = H004C2_A106EmployeeId[0];
               A134LeaveRequestRejectionReason = H004C2_A134LeaveRequestRejectionReason[0];
               A133LeaveRequestDescription = H004C2_A133LeaveRequestDescription[0];
               A132LeaveRequestStatus = H004C2_A132LeaveRequestStatus[0];
               A131LeaveRequestDuration = H004C2_A131LeaveRequestDuration[0];
               A173LeaveRequestHalfDay = H004C2_A173LeaveRequestHalfDay[0];
               n173LeaveRequestHalfDay = H004C2_n173LeaveRequestHalfDay[0];
               A130LeaveRequestEndDate = H004C2_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = H004C2_A129LeaveRequestStartDate[0];
               A128LeaveRequestDate = H004C2_A128LeaveRequestDate[0];
               A125LeaveTypeName = H004C2_A125LeaveTypeName[0];
               A124LeaveTypeId = H004C2_A124LeaveTypeId[0];
               A127LeaveRequestId = H004C2_A127LeaveRequestId[0];
               A100CompanyId = H004C2_A100CompanyId[0];
               A125LeaveTypeName = H004C2_A125LeaveTypeName[0];
               E204C2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 41;
            WB4C0( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4C2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV66IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV66IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV68IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV68IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV71IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV71IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_LEAVEREQUESTID"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9"), context));
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
         AV84Leaverequestwwds_2_filterfulltext = AV16FilterFullText;
         AV85Leaverequestwwds_3_tfleavetypename = AV31TFLeaveTypeName;
         AV86Leaverequestwwds_4_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV87Leaverequestwwds_5_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV88Leaverequestwwds_6_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV89Leaverequestwwds_7_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV90Leaverequestwwds_8_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV91Leaverequestwwds_9_tfleaverequesthalfday = AV75TFLeaveRequestHalfDay;
         AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator = AV80TFLeaveRequestHalfDayOperator;
         AV93Leaverequestwwds_11_tfleaverequesthalfday_sel = AV76TFLeaveRequestHalfDay_Sel;
         AV94Leaverequestwwds_12_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV95Leaverequestwwds_13_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV96Leaverequestwwds_14_tfleaverequeststatus = AV77TFLeaveRequestStatus;
         AV97Leaverequestwwds_15_tfleaverequeststatusoperator = AV78TFLeaveRequestStatusOperator;
         AV98Leaverequestwwds_16_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV99Leaverequestwwds_17_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV100Leaverequestwwds_18_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV101Leaverequestwwds_19_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV98Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                              AV84Leaverequestwwds_2_filterfulltext ,
                                              AV86Leaverequestwwds_4_tfleavetypename_sel ,
                                              AV85Leaverequestwwds_3_tfleavetypename ,
                                              AV87Leaverequestwwds_5_tfleaverequeststartdate ,
                                              AV88Leaverequestwwds_6_tfleaverequeststartdate_to ,
                                              AV89Leaverequestwwds_7_tfleaverequestenddate ,
                                              AV90Leaverequestwwds_8_tfleaverequestenddate_to ,
                                              AV93Leaverequestwwds_11_tfleaverequesthalfday_sel ,
                                              AV91Leaverequestwwds_9_tfleaverequesthalfday ,
                                              AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator ,
                                              AV94Leaverequestwwds_12_tfleaverequestduration ,
                                              AV95Leaverequestwwds_13_tfleaverequestduration_to ,
                                              AV98Leaverequestwwds_16_tfleaverequeststatus_sels.Count ,
                                              AV97Leaverequestwwds_15_tfleaverequeststatusoperator ,
                                              AV100Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                              AV99Leaverequestwwds_17_tfleaverequestdescription ,
                                              AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                              AV101Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A100CompanyId ,
                                              AV103Udparg21 ,
                                              A106EmployeeId ,
                                              AV81Udparg1 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
         lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
         lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
         lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
         lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
         lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
         lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
         lV84Leaverequestwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext), "%", "");
         lV85Leaverequestwwds_3_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV85Leaverequestwwds_3_tfleavetypename), 100, "%");
         lV91Leaverequestwwds_9_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV91Leaverequestwwds_9_tfleaverequesthalfday), 20, "%");
         lV99Leaverequestwwds_17_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV99Leaverequestwwds_17_tfleaverequestdescription), "%", "");
         lV101Leaverequestwwds_19_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV101Leaverequestwwds_19_tfleaverequestrejectionreason), "%", "");
         /* Using cursor H004C3 */
         pr_default.execute(1, new Object[] {AV103Udparg21, AV81Udparg1, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV84Leaverequestwwds_2_filterfulltext, lV85Leaverequestwwds_3_tfleavetypename, AV86Leaverequestwwds_4_tfleavetypename_sel, AV87Leaverequestwwds_5_tfleaverequeststartdate, AV88Leaverequestwwds_6_tfleaverequeststartdate_to, AV89Leaverequestwwds_7_tfleaverequestenddate, AV90Leaverequestwwds_8_tfleaverequestenddate_to, lV91Leaverequestwwds_9_tfleaverequesthalfday, AV93Leaverequestwwds_11_tfleaverequesthalfday_sel, AV94Leaverequestwwds_12_tfleaverequestduration, AV95Leaverequestwwds_13_tfleaverequestduration_to, lV99Leaverequestwwds_17_tfleaverequestdescription, AV100Leaverequestwwds_18_tfleaverequestdescription_sel, lV101Leaverequestwwds_19_tfleaverequestrejectionreason, AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel});
         GRID_nRecordCount = H004C3_AGRID_nRecordCount[0];
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
         AV84Leaverequestwwds_2_filterfulltext = AV16FilterFullText;
         AV85Leaverequestwwds_3_tfleavetypename = AV31TFLeaveTypeName;
         AV86Leaverequestwwds_4_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV87Leaverequestwwds_5_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV88Leaverequestwwds_6_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV89Leaverequestwwds_7_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV90Leaverequestwwds_8_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV91Leaverequestwwds_9_tfleaverequesthalfday = AV75TFLeaveRequestHalfDay;
         AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator = AV80TFLeaveRequestHalfDayOperator;
         AV93Leaverequestwwds_11_tfleaverequesthalfday_sel = AV76TFLeaveRequestHalfDay_Sel;
         AV94Leaverequestwwds_12_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV95Leaverequestwwds_13_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV96Leaverequestwwds_14_tfleaverequeststatus = AV77TFLeaveRequestStatus;
         AV97Leaverequestwwds_15_tfleaverequeststatusoperator = AV78TFLeaveRequestStatusOperator;
         AV98Leaverequestwwds_16_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV99Leaverequestwwds_17_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV100Leaverequestwwds_18_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV101Leaverequestwwds_19_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV83Pgmname, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV75TFLeaveRequestHalfDay, AV80TFLeaveRequestHalfDayOperator, AV76TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV77TFLeaveRequestStatus, AV78TFLeaveRequestStatusOperator, AV51TFLeaveRequestStatus_Sels, AV52TFLeaveRequestDescription, AV53TFLeaveRequestDescription_Sel, AV54TFLeaveRequestRejectionReason, AV55TFLeaveRequestRejectionReason_Sel, AV13OrderedBy, AV14OrderedDsc, AV66IsAuthorized_Update, AV68IsAuthorized_Delete, AV71IsAuthorized_Insert, AV73Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV84Leaverequestwwds_2_filterfulltext = AV16FilterFullText;
         AV85Leaverequestwwds_3_tfleavetypename = AV31TFLeaveTypeName;
         AV86Leaverequestwwds_4_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV87Leaverequestwwds_5_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV88Leaverequestwwds_6_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV89Leaverequestwwds_7_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV90Leaverequestwwds_8_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV91Leaverequestwwds_9_tfleaverequesthalfday = AV75TFLeaveRequestHalfDay;
         AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator = AV80TFLeaveRequestHalfDayOperator;
         AV93Leaverequestwwds_11_tfleaverequesthalfday_sel = AV76TFLeaveRequestHalfDay_Sel;
         AV94Leaverequestwwds_12_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV95Leaverequestwwds_13_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV96Leaverequestwwds_14_tfleaverequeststatus = AV77TFLeaveRequestStatus;
         AV97Leaverequestwwds_15_tfleaverequeststatusoperator = AV78TFLeaveRequestStatusOperator;
         AV98Leaverequestwwds_16_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV99Leaverequestwwds_17_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV100Leaverequestwwds_18_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV101Leaverequestwwds_19_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV83Pgmname, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV75TFLeaveRequestHalfDay, AV80TFLeaveRequestHalfDayOperator, AV76TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV77TFLeaveRequestStatus, AV78TFLeaveRequestStatusOperator, AV51TFLeaveRequestStatus_Sels, AV52TFLeaveRequestDescription, AV53TFLeaveRequestDescription_Sel, AV54TFLeaveRequestRejectionReason, AV55TFLeaveRequestRejectionReason_Sel, AV13OrderedBy, AV14OrderedDsc, AV66IsAuthorized_Update, AV68IsAuthorized_Delete, AV71IsAuthorized_Insert, AV73Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV84Leaverequestwwds_2_filterfulltext = AV16FilterFullText;
         AV85Leaverequestwwds_3_tfleavetypename = AV31TFLeaveTypeName;
         AV86Leaverequestwwds_4_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV87Leaverequestwwds_5_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV88Leaverequestwwds_6_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV89Leaverequestwwds_7_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV90Leaverequestwwds_8_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV91Leaverequestwwds_9_tfleaverequesthalfday = AV75TFLeaveRequestHalfDay;
         AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator = AV80TFLeaveRequestHalfDayOperator;
         AV93Leaverequestwwds_11_tfleaverequesthalfday_sel = AV76TFLeaveRequestHalfDay_Sel;
         AV94Leaverequestwwds_12_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV95Leaverequestwwds_13_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV96Leaverequestwwds_14_tfleaverequeststatus = AV77TFLeaveRequestStatus;
         AV97Leaverequestwwds_15_tfleaverequeststatusoperator = AV78TFLeaveRequestStatusOperator;
         AV98Leaverequestwwds_16_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV99Leaverequestwwds_17_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV100Leaverequestwwds_18_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV101Leaverequestwwds_19_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV83Pgmname, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV75TFLeaveRequestHalfDay, AV80TFLeaveRequestHalfDayOperator, AV76TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV77TFLeaveRequestStatus, AV78TFLeaveRequestStatusOperator, AV51TFLeaveRequestStatus_Sels, AV52TFLeaveRequestDescription, AV53TFLeaveRequestDescription_Sel, AV54TFLeaveRequestRejectionReason, AV55TFLeaveRequestRejectionReason_Sel, AV13OrderedBy, AV14OrderedDsc, AV66IsAuthorized_Update, AV68IsAuthorized_Delete, AV71IsAuthorized_Insert, AV73Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV84Leaverequestwwds_2_filterfulltext = AV16FilterFullText;
         AV85Leaverequestwwds_3_tfleavetypename = AV31TFLeaveTypeName;
         AV86Leaverequestwwds_4_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV87Leaverequestwwds_5_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV88Leaverequestwwds_6_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV89Leaverequestwwds_7_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV90Leaverequestwwds_8_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV91Leaverequestwwds_9_tfleaverequesthalfday = AV75TFLeaveRequestHalfDay;
         AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator = AV80TFLeaveRequestHalfDayOperator;
         AV93Leaverequestwwds_11_tfleaverequesthalfday_sel = AV76TFLeaveRequestHalfDay_Sel;
         AV94Leaverequestwwds_12_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV95Leaverequestwwds_13_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV96Leaverequestwwds_14_tfleaverequeststatus = AV77TFLeaveRequestStatus;
         AV97Leaverequestwwds_15_tfleaverequeststatusoperator = AV78TFLeaveRequestStatusOperator;
         AV98Leaverequestwwds_16_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV99Leaverequestwwds_17_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV100Leaverequestwwds_18_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV101Leaverequestwwds_19_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV83Pgmname, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV75TFLeaveRequestHalfDay, AV80TFLeaveRequestHalfDayOperator, AV76TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV77TFLeaveRequestStatus, AV78TFLeaveRequestStatusOperator, AV51TFLeaveRequestStatus_Sels, AV52TFLeaveRequestDescription, AV53TFLeaveRequestDescription_Sel, AV54TFLeaveRequestRejectionReason, AV55TFLeaveRequestRejectionReason_Sel, AV13OrderedBy, AV14OrderedDsc, AV66IsAuthorized_Update, AV68IsAuthorized_Delete, AV71IsAuthorized_Insert, AV73Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV84Leaverequestwwds_2_filterfulltext = AV16FilterFullText;
         AV85Leaverequestwwds_3_tfleavetypename = AV31TFLeaveTypeName;
         AV86Leaverequestwwds_4_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV87Leaverequestwwds_5_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV88Leaverequestwwds_6_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV89Leaverequestwwds_7_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV90Leaverequestwwds_8_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV91Leaverequestwwds_9_tfleaverequesthalfday = AV75TFLeaveRequestHalfDay;
         AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator = AV80TFLeaveRequestHalfDayOperator;
         AV93Leaverequestwwds_11_tfleaverequesthalfday_sel = AV76TFLeaveRequestHalfDay_Sel;
         AV94Leaverequestwwds_12_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV95Leaverequestwwds_13_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV96Leaverequestwwds_14_tfleaverequeststatus = AV77TFLeaveRequestStatus;
         AV97Leaverequestwwds_15_tfleaverequeststatusoperator = AV78TFLeaveRequestStatusOperator;
         AV98Leaverequestwwds_16_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV99Leaverequestwwds_17_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV100Leaverequestwwds_18_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV101Leaverequestwwds_19_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV83Pgmname, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV75TFLeaveRequestHalfDay, AV80TFLeaveRequestHalfDayOperator, AV76TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV77TFLeaveRequestStatus, AV78TFLeaveRequestStatusOperator, AV51TFLeaveRequestStatus_Sels, AV52TFLeaveRequestDescription, AV53TFLeaveRequestDescription_Sel, AV54TFLeaveRequestRejectionReason, AV55TFLeaveRequestRejectionReason_Sel, AV13OrderedBy, AV14OrderedDsc, AV66IsAuthorized_Update, AV68IsAuthorized_Delete, AV71IsAuthorized_Insert, AV73Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV83Pgmname = "LeaveRequestWW";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestId_Enabled = 0;
         AssignProp("", false, edtLeaveRequestId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestId_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveTypeId_Enabled = 0;
         AssignProp("", false, edtLeaveTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveTypeId_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveTypeName_Enabled = 0;
         AssignProp("", false, edtLeaveTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveTypeName_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestDate_Enabled = 0;
         AssignProp("", false, edtLeaveRequestDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestStartDate_Enabled = 0;
         AssignProp("", false, edtLeaveRequestStartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestStartDate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestEndDate_Enabled = 0;
         AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestHalfDay_Enabled = 0;
         AssignProp("", false, edtLeaveRequestHalfDay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestHalfDay_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestDuration_Enabled = 0;
         AssignProp("", false, edtLeaveRequestDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         cmbLeaveRequestStatus.Enabled = 0;
         AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLeaveRequestStatus.Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestDescription_Enabled = 0;
         AssignProp("", false, edtLeaveRequestDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDescription_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestRejectionReason_Enabled = 0;
         AssignProp("", false, edtLeaveRequestRejectionReason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestRejectionReason_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E184C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV69AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV58DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ".", ","), 18, MidpointRounding.ToEven));
            AV62GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV63GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV64GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV40DDO_LeaveRequestStartDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTSTARTDATEAUXDATE"), 0);
            AV41DDO_LeaveRequestStartDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTSTARTDATEAUXDATETO"), 0);
            AV45DDO_LeaveRequestEndDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTENDDATEAUXDATE"), 0);
            AV46DDO_LeaveRequestEndDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTENDDATEAUXDATETO"), 0);
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Fixedfilters = cgiGet( "DDO_GRID_Fixedfilters");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Ddo_grid_Selectedfixedfilter = cgiGet( "DDO_GRID_Selectedfixedfilter");
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
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Selectedcolumnfixedfilter = cgiGet( "DDO_GRID_Selectedcolumnfixedfilter");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            AV42DDO_LeaveRequestStartDateAuxDateText = cgiGet( edtavDdo_leaverequeststartdateauxdatetext_Internalname);
            AssignAttri("", false, "AV42DDO_LeaveRequestStartDateAuxDateText", AV42DDO_LeaveRequestStartDateAuxDateText);
            AV47DDO_LeaveRequestEndDateAuxDateText = cgiGet( edtavDdo_leaverequestenddateauxdatetext_Internalname);
            AssignAttri("", false, "AV47DDO_LeaveRequestEndDateAuxDateText", AV47DDO_LeaveRequestEndDateAuxDateText);
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
         E184C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E184C2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV82Checking = AV79GAMUser.checkrole("Manager");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Mesage)) )
         {
            GX_msglist.addItem(AV73Mesage);
            AV73Mesage = "";
            AssignAttri("", false, "AV73Mesage", AV73Mesage);
            GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Mesage, "")), context));
         }
         AV74MsgVar = "Leave Request Deleted.";
         this.executeUsercontrolMethod("", false, "TFLEAVEREQUESTENDDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_leaverequestenddateauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFLEAVEREQUESTSTARTDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_leaverequeststartdateauxdatetext_Internalname});
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
         AV69AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV70AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV70AGExportDataItem.gxTpr_Title = "Excel";
         AV70AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV70AGExportDataItem.gxTpr_Eventkey = "Export";
         AV70AGExportDataItem.gxTpr_Isdivider = false;
         AV69AGExportData.Add(AV70AGExportDataItem, 0);
         AV59GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV60GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV59GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Leave Request";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV58DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV58DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E194C2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
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
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV23Session.Get("LeaveRequestWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("LeaveRequestWWColumnsSelector");
            AV21ColumnsSelector.FromXml(AV19ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtLeaveTypeName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveTypeName_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestStartDate_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestStartDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestStartDate_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestEndDate_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestHalfDay_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestHalfDay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestHalfDay_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestDuration_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Visible), 5, 0), !bGXsfl_41_Refreshing);
         cmbLeaveRequestStatus.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbLeaveRequestStatus.Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestDescription_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDescription_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtLeaveRequestRejectionReason_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestRejectionReason_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestRejectionReason_Visible), 5, 0), !bGXsfl_41_Refreshing);
         AV62GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV62GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV62GridCurrentPage), 10, 0));
         AV63GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV63GridPageCount", StringUtil.LTrimStr( (decimal)(AV63GridPageCount), 10, 0));
         GXt_char2 = AV64GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV83Pgmname, out  GXt_char2) ;
         AV64GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV64GridAppliedFilters", AV64GridAppliedFilters);
         edtLeaveRequestHalfDay_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtLeaveRequestHalfDay_Internalname, "Columnheaderclass", edtLeaveRequestHalfDay_Columnheaderclass, !bGXsfl_41_Refreshing);
         cmbLeaveRequestStatus_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Columnheaderclass", cmbLeaveRequestStatus_Columnheaderclass, !bGXsfl_41_Refreshing);
         AV84Leaverequestwwds_2_filterfulltext = AV16FilterFullText;
         AV85Leaverequestwwds_3_tfleavetypename = AV31TFLeaveTypeName;
         AV86Leaverequestwwds_4_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV87Leaverequestwwds_5_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV88Leaverequestwwds_6_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV89Leaverequestwwds_7_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV90Leaverequestwwds_8_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV91Leaverequestwwds_9_tfleaverequesthalfday = AV75TFLeaveRequestHalfDay;
         AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator = AV80TFLeaveRequestHalfDayOperator;
         AV93Leaverequestwwds_11_tfleaverequesthalfday_sel = AV76TFLeaveRequestHalfDay_Sel;
         AV94Leaverequestwwds_12_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV95Leaverequestwwds_13_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV96Leaverequestwwds_14_tfleaverequeststatus = AV77TFLeaveRequestStatus;
         AV97Leaverequestwwds_15_tfleaverequeststatusoperator = AV78TFLeaveRequestStatusOperator;
         AV98Leaverequestwwds_16_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV99Leaverequestwwds_17_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV100Leaverequestwwds_18_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV101Leaverequestwwds_19_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV103Udparg21 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124C2( )
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
            AV61PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV61PageToGo) ;
         }
      }

      protected void E134C2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E154C2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveTypeName") == 0 )
            {
               AV31TFLeaveTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFLeaveTypeName", AV31TFLeaveTypeName);
               AV32TFLeaveTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFLeaveTypeName_Sel", AV32TFLeaveTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestStartDate") == 0 )
            {
               AV38TFLeaveRequestStartDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 1);
               AssignAttri("", false, "AV38TFLeaveRequestStartDate", context.localUtil.Format(AV38TFLeaveRequestStartDate, "99/99/99"));
               AV39TFLeaveRequestStartDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 1);
               AssignAttri("", false, "AV39TFLeaveRequestStartDate_To", context.localUtil.Format(AV39TFLeaveRequestStartDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestEndDate") == 0 )
            {
               AV43TFLeaveRequestEndDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 1);
               AssignAttri("", false, "AV43TFLeaveRequestEndDate", context.localUtil.Format(AV43TFLeaveRequestEndDate, "99/99/99"));
               AV44TFLeaveRequestEndDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 1);
               AssignAttri("", false, "AV44TFLeaveRequestEndDate_To", context.localUtil.Format(AV44TFLeaveRequestEndDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestHalfDay") == 0 )
            {
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "1") == 0 )
               {
                  AV80TFLeaveRequestHalfDayOperator = 1;
                  AssignAttri("", false, "AV80TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV80TFLeaveRequestHalfDayOperator), 4, 0));
                  AV75TFLeaveRequestHalfDay = "";
                  AssignAttri("", false, "AV75TFLeaveRequestHalfDay", AV75TFLeaveRequestHalfDay);
                  AV76TFLeaveRequestHalfDay_Sel = "";
                  AssignAttri("", false, "AV76TFLeaveRequestHalfDay_Sel", AV76TFLeaveRequestHalfDay_Sel);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "2") == 0 )
               {
                  AV80TFLeaveRequestHalfDayOperator = 2;
                  AssignAttri("", false, "AV80TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV80TFLeaveRequestHalfDayOperator), 4, 0));
                  AV75TFLeaveRequestHalfDay = "";
                  AssignAttri("", false, "AV75TFLeaveRequestHalfDay", AV75TFLeaveRequestHalfDay);
                  AV76TFLeaveRequestHalfDay_Sel = "";
                  AssignAttri("", false, "AV76TFLeaveRequestHalfDay_Sel", AV76TFLeaveRequestHalfDay_Sel);
               }
               else
               {
                  AV80TFLeaveRequestHalfDayOperator = 0;
                  AssignAttri("", false, "AV80TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV80TFLeaveRequestHalfDayOperator), 4, 0));
                  AV75TFLeaveRequestHalfDay = Ddo_grid_Filteredtext_get;
                  AssignAttri("", false, "AV75TFLeaveRequestHalfDay", AV75TFLeaveRequestHalfDay);
                  AV76TFLeaveRequestHalfDay_Sel = Ddo_grid_Selectedvalue_get;
                  AssignAttri("", false, "AV76TFLeaveRequestHalfDay_Sel", AV76TFLeaveRequestHalfDay_Sel);
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestDuration") == 0 )
            {
               AV48TFLeaveRequestDuration = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV48TFLeaveRequestDuration", StringUtil.LTrimStr( AV48TFLeaveRequestDuration, 4, 1));
               AV49TFLeaveRequestDuration_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV49TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV49TFLeaveRequestDuration_To, 4, 1));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestStatus") == 0 )
            {
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "1") == 0 )
               {
                  AV78TFLeaveRequestStatusOperator = 1;
                  AssignAttri("", false, "AV78TFLeaveRequestStatusOperator", StringUtil.LTrimStr( (decimal)(AV78TFLeaveRequestStatusOperator), 4, 0));
                  AV77TFLeaveRequestStatus = "";
                  AssignAttri("", false, "AV77TFLeaveRequestStatus", AV77TFLeaveRequestStatus);
                  AV51TFLeaveRequestStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "2") == 0 )
               {
                  AV78TFLeaveRequestStatusOperator = 2;
                  AssignAttri("", false, "AV78TFLeaveRequestStatusOperator", StringUtil.LTrimStr( (decimal)(AV78TFLeaveRequestStatusOperator), 4, 0));
                  AV77TFLeaveRequestStatus = "";
                  AssignAttri("", false, "AV77TFLeaveRequestStatus", AV77TFLeaveRequestStatus);
                  AV51TFLeaveRequestStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "3") == 0 )
               {
                  AV78TFLeaveRequestStatusOperator = 3;
                  AssignAttri("", false, "AV78TFLeaveRequestStatusOperator", StringUtil.LTrimStr( (decimal)(AV78TFLeaveRequestStatusOperator), 4, 0));
                  AV77TFLeaveRequestStatus = "";
                  AssignAttri("", false, "AV77TFLeaveRequestStatus", AV77TFLeaveRequestStatus);
                  AV51TFLeaveRequestStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               }
               else
               {
                  AV78TFLeaveRequestStatusOperator = 0;
                  AssignAttri("", false, "AV78TFLeaveRequestStatusOperator", StringUtil.LTrimStr( (decimal)(AV78TFLeaveRequestStatusOperator), 4, 0));
                  AV50TFLeaveRequestStatus_SelsJson = Ddo_grid_Selectedvalue_get;
                  AssignAttri("", false, "AV50TFLeaveRequestStatus_SelsJson", AV50TFLeaveRequestStatus_SelsJson);
                  AV51TFLeaveRequestStatus_Sels.FromJSonString(AV50TFLeaveRequestStatus_SelsJson, null);
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestDescription") == 0 )
            {
               AV52TFLeaveRequestDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV52TFLeaveRequestDescription", AV52TFLeaveRequestDescription);
               AV53TFLeaveRequestDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFLeaveRequestDescription_Sel", AV53TFLeaveRequestDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestRejectionReason") == 0 )
            {
               AV54TFLeaveRequestRejectionReason = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFLeaveRequestRejectionReason", AV54TFLeaveRequestRejectionReason);
               AV55TFLeaveRequestRejectionReason_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFLeaveRequestRejectionReason_Sel", AV55TFLeaveRequestRejectionReason_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFLeaveRequestStatus_Sels", AV51TFLeaveRequestStatus_Sels);
      }

      private void E204C2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV65Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV65Update);
         if ( AV66IsAuthorized_Update )
         {
            if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 )
            {
               edtavUpdate_Link = formatLink("leaverequest.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A127LeaveRequestId,10,0))}, new string[] {"Mode","LeaveRequestId"}) ;
               edtavUpdate_Class = "Attribute";
            }
            else
            {
               edtavUpdate_Link = "";
               edtavUpdate_Class = "Invisible";
            }
         }
         AV67Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV67Delete);
         if ( AV68IsAuthorized_Delete )
         {
            if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 )
            {
               edtavDelete_Link = formatLink("leaverequest.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A127LeaveRequestId,10,0))}, new string[] {"Mode","LeaveRequestId"}) ;
               edtavDelete_Class = "Attribute";
            }
            else
            {
               edtavDelete_Link = "";
               edtavDelete_Class = "Invisible";
            }
         }
         if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Morning") == 0 )
         {
            edtLeaveRequestHalfDay_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Afternoon") == 0 )
         {
            edtLeaveRequestHalfDay_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else
         {
            edtLeaveRequestHalfDay_Columnclass = "WWColumn";
         }
         if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 )
         {
            cmbLeaveRequestStatus_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Approved") == 0 )
         {
            cmbLeaveRequestStatus_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Rejected") == 0 )
         {
            cmbLeaveRequestStatus_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            cmbLeaveRequestStatus_Columnclass = "WWColumn hidden-xs";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 41;
         }
         sendrow_412( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_41_Refreshing )
         {
            DoAjaxLoad(41, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E164C2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "LeaveRequestWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E114C2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("LeaveRequestWWFilters")),UrlEncode(StringUtil.RTrim(AV83Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("LeaveRequestWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "LeaveRequestWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV25ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV83Pgmname+"GridState",  AV25ManageFiltersXml) ;
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
               S192 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFLeaveRequestStatus_Sels", AV51TFLeaveRequestStatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E174C2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV71IsAuthorized_Insert )
         {
            CallWebObject(formatLink("leaverequest.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","LeaveRequestId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E144C2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFLeaveRequestStatus_Sels", AV51TFLeaveRequestStatus_Sels);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "LeaveTypeName",  "",  "Leave Type",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "LeaveRequestStartDate",  "",  "Start Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "LeaveRequestEndDate",  "",  "End Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "LeaveRequestHalfDay",  "",  "Half Day",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "LeaveRequestDuration",  "",  "Duration",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "LeaveRequestStatus",  "",  "Status",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "LeaveRequestDescription",  "",  "Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "LeaveRequestRejectionReason",  "",  "Rejection Reason",  true,  "") ;
         GXt_char2 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "LeaveRequestWWColumnsSelector", out  GXt_char2) ;
         AV20UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomValue)) ) )
         {
            AV22ColumnsSelectorAux.FromXml(AV20UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV22ColumnsSelectorAux, ref  AV21ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV66IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequest_Update", out  GXt_boolean3) ;
         AV66IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV66IsAuthorized_Update", AV66IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV66IsAuthorized_Update, context));
         if ( ! ( AV66IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_41_Refreshing);
         }
         GXt_boolean3 = AV68IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequest_Delete", out  GXt_boolean3) ;
         AV68IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV68IsAuthorized_Delete", AV68IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV68IsAuthorized_Delete, context));
         if ( ! ( AV68IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_41_Refreshing);
         }
         GXt_boolean3 = AV71IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequest_Insert", out  GXt_boolean3) ;
         AV71IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV71IsAuthorized_Insert", AV71IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV71IsAuthorized_Insert, context));
         if ( ! ( AV71IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV24ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "LeaveRequestWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV31TFLeaveTypeName = "";
         AssignAttri("", false, "AV31TFLeaveTypeName", AV31TFLeaveTypeName);
         AV32TFLeaveTypeName_Sel = "";
         AssignAttri("", false, "AV32TFLeaveTypeName_Sel", AV32TFLeaveTypeName_Sel);
         AV38TFLeaveRequestStartDate = DateTime.MinValue;
         AssignAttri("", false, "AV38TFLeaveRequestStartDate", context.localUtil.Format(AV38TFLeaveRequestStartDate, "99/99/99"));
         AV39TFLeaveRequestStartDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV39TFLeaveRequestStartDate_To", context.localUtil.Format(AV39TFLeaveRequestStartDate_To, "99/99/99"));
         AV43TFLeaveRequestEndDate = DateTime.MinValue;
         AssignAttri("", false, "AV43TFLeaveRequestEndDate", context.localUtil.Format(AV43TFLeaveRequestEndDate, "99/99/99"));
         AV44TFLeaveRequestEndDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV44TFLeaveRequestEndDate_To", context.localUtil.Format(AV44TFLeaveRequestEndDate_To, "99/99/99"));
         AV75TFLeaveRequestHalfDay = "";
         AssignAttri("", false, "AV75TFLeaveRequestHalfDay", AV75TFLeaveRequestHalfDay);
         AV76TFLeaveRequestHalfDay_Sel = "";
         AssignAttri("", false, "AV76TFLeaveRequestHalfDay_Sel", AV76TFLeaveRequestHalfDay_Sel);
         AV80TFLeaveRequestHalfDayOperator = 0;
         AssignAttri("", false, "AV80TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV80TFLeaveRequestHalfDayOperator), 4, 0));
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         AV48TFLeaveRequestDuration = 0;
         AssignAttri("", false, "AV48TFLeaveRequestDuration", StringUtil.LTrimStr( AV48TFLeaveRequestDuration, 4, 1));
         AV49TFLeaveRequestDuration_To = 0;
         AssignAttri("", false, "AV49TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV49TFLeaveRequestDuration_To, 4, 1));
         AV51TFLeaveRequestStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV78TFLeaveRequestStatusOperator = 0;
         AssignAttri("", false, "AV78TFLeaveRequestStatusOperator", StringUtil.LTrimStr( (decimal)(AV78TFLeaveRequestStatusOperator), 4, 0));
         AV52TFLeaveRequestDescription = "";
         AssignAttri("", false, "AV52TFLeaveRequestDescription", AV52TFLeaveRequestDescription);
         AV53TFLeaveRequestDescription_Sel = "";
         AssignAttri("", false, "AV53TFLeaveRequestDescription_Sel", AV53TFLeaveRequestDescription_Sel);
         AV54TFLeaveRequestRejectionReason = "";
         AssignAttri("", false, "AV54TFLeaveRequestRejectionReason", AV54TFLeaveRequestRejectionReason);
         AV55TFLeaveRequestRejectionReason_Sel = "";
         AssignAttri("", false, "AV55TFLeaveRequestRejectionReason_Sel", AV55TFLeaveRequestRejectionReason_Sel);
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
         if ( StringUtil.StrCmp(AV23Session.Get(AV83Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV83Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV83Pgmname+"GridState"), null, "", "");
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
         S192 ();
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

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV104GXV1 = 1;
         while ( AV104GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV104GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV31TFLeaveTypeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFLeaveTypeName", AV31TFLeaveTypeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV32TFLeaveTypeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFLeaveTypeName_Sel", AV32TFLeaveTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV38TFLeaveRequestStartDate = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 1);
               AssignAttri("", false, "AV38TFLeaveRequestStartDate", context.localUtil.Format(AV38TFLeaveRequestStartDate, "99/99/99"));
               AV39TFLeaveRequestStartDate_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 1);
               AssignAttri("", false, "AV39TFLeaveRequestStartDate_To", context.localUtil.Format(AV39TFLeaveRequestStartDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV43TFLeaveRequestEndDate = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 1);
               AssignAttri("", false, "AV43TFLeaveRequestEndDate", context.localUtil.Format(AV43TFLeaveRequestEndDate, "99/99/99"));
               AV44TFLeaveRequestEndDate_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 1);
               AssignAttri("", false, "AV44TFLeaveRequestEndDate_To", context.localUtil.Format(AV44TFLeaveRequestEndDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV80TFLeaveRequestHalfDayOperator = AV12GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV80TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV80TFLeaveRequestHalfDayOperator), 4, 0));
               if ( AV80TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV75TFLeaveRequestHalfDay = AV12GridStateFilterValue.gxTpr_Value;
                  AssignAttri("", false, "AV75TFLeaveRequestHalfDay", AV75TFLeaveRequestHalfDay);
               }
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV76TFLeaveRequestHalfDay_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFLeaveRequestHalfDay_Sel", AV76TFLeaveRequestHalfDay_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV48TFLeaveRequestDuration = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV48TFLeaveRequestDuration", StringUtil.LTrimStr( AV48TFLeaveRequestDuration, 4, 1));
               AV49TFLeaveRequestDuration_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV49TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV49TFLeaveRequestDuration_To, 4, 1));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS") == 0 )
            {
               AV78TFLeaveRequestStatusOperator = AV12GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV78TFLeaveRequestStatusOperator", StringUtil.LTrimStr( (decimal)(AV78TFLeaveRequestStatusOperator), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS_SEL") == 0 )
            {
               AV50TFLeaveRequestStatus_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFLeaveRequestStatus_SelsJson", AV50TFLeaveRequestStatus_SelsJson);
               AV51TFLeaveRequestStatus_Sels.FromJSonString(AV50TFLeaveRequestStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV52TFLeaveRequestDescription = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFLeaveRequestDescription", AV52TFLeaveRequestDescription);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV53TFLeaveRequestDescription_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFLeaveRequestDescription_Sel", AV53TFLeaveRequestDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON") == 0 )
            {
               AV54TFLeaveRequestRejectionReason = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFLeaveRequestRejectionReason", AV54TFLeaveRequestRejectionReason);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON_SEL") == 0 )
            {
               AV55TFLeaveRequestRejectionReason_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFLeaveRequestRejectionReason_Sel", AV55TFLeaveRequestRejectionReason_Sel);
            }
            AV104GXV1 = (int)(AV104GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFLeaveTypeName_Sel)),  AV32TFLeaveTypeName_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFLeaveRequestHalfDay_Sel)),  AV76TFLeaveRequestHalfDay_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV51TFLeaveRequestStatus_Sels.Count==0),  AV50TFLeaveRequestStatus_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFLeaveRequestDescription_Sel)),  AV53TFLeaveRequestDescription_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFLeaveRequestRejectionReason_Sel)),  AV55TFLeaveRequestRejectionReason_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|||"+GXt_char5+"||"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFLeaveTypeName)),  AV31TFLeaveTypeName, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  !(0==AV80TFLeaveRequestHalfDayOperator)||String.IsNullOrEmpty(StringUtil.RTrim( AV75TFLeaveRequestHalfDay)),  AV75TFLeaveRequestHalfDay, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFLeaveRequestDescription)),  AV52TFLeaveRequestDescription, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFLeaveRequestRejectionReason)),  AV54TFLeaveRequestRejectionReason, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+((DateTime.MinValue==AV38TFLeaveRequestStartDate) ? "" : context.localUtil.DToC( AV38TFLeaveRequestStartDate, 1, "/"))+"|"+((DateTime.MinValue==AV43TFLeaveRequestEndDate) ? "" : context.localUtil.DToC( AV43TFLeaveRequestEndDate, 1, "/"))+"|"+GXt_char7+"|"+((Convert.ToDecimal(0)==AV48TFLeaveRequestDuration) ? "" : StringUtil.Str( AV48TFLeaveRequestDuration, 4, 1))+"||"+GXt_char6+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((DateTime.MinValue==AV39TFLeaveRequestStartDate_To) ? "" : context.localUtil.DToC( AV39TFLeaveRequestStartDate_To, 1, "/"))+"|"+((DateTime.MinValue==AV44TFLeaveRequestEndDate_To) ? "" : context.localUtil.DToC( AV44TFLeaveRequestEndDate_To, 1, "/"))+"||"+((Convert.ToDecimal(0)==AV49TFLeaveRequestDuration_To) ? "" : StringUtil.Str( AV49TFLeaveRequestDuration_To, 4, 1))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         Ddo_grid_Selectedfixedfilter = "|||"+((AV80TFLeaveRequestHalfDayOperator!=1) ? "" : "1")+((AV80TFLeaveRequestHalfDayOperator!=2) ? "" : "2")+"||"+((AV78TFLeaveRequestStatusOperator!=1) ? "" : "1")+((AV78TFLeaveRequestStatusOperator!=2) ? "" : "2")+((AV78TFLeaveRequestStatusOperator!=3) ? "" : "3")+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV83Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFLEAVETYPENAME",  "Leave Type",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFLeaveTypeName)),  0,  AV31TFLeaveTypeName,  AV31TFLeaveTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFLeaveTypeName_Sel)),  AV32TFLeaveTypeName_Sel,  AV32TFLeaveTypeName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFLEAVEREQUESTSTARTDATE",  "Start Date",  !((DateTime.MinValue==AV38TFLeaveRequestStartDate)&&(DateTime.MinValue==AV39TFLeaveRequestStartDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV38TFLeaveRequestStartDate, 1, "/")),  ((DateTime.MinValue==AV38TFLeaveRequestStartDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFLeaveRequestStartDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV39TFLeaveRequestStartDate_To, 1, "/")),  ((DateTime.MinValue==AV39TFLeaveRequestStartDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFLeaveRequestStartDate_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFLEAVEREQUESTENDDATE",  "End Date",  !((DateTime.MinValue==AV43TFLeaveRequestEndDate)&&(DateTime.MinValue==AV44TFLeaveRequestEndDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV43TFLeaveRequestEndDate, 1, "/")),  ((DateTime.MinValue==AV43TFLeaveRequestEndDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFLeaveRequestEndDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV44TFLeaveRequestEndDate_To, 1, "/")),  ((DateTime.MinValue==AV44TFLeaveRequestEndDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFLeaveRequestEndDate_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFLEAVEREQUESTHALFDAY",  "Half Day",  !(String.IsNullOrEmpty(StringUtil.RTrim( AV75TFLeaveRequestHalfDay))&&(0==AV80TFLeaveRequestHalfDayOperator)),  AV80TFLeaveRequestHalfDayOperator,  AV75TFLeaveRequestHalfDay,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV80TFLeaveRequestHalfDayOperator+1), 10, 0)), AV75TFLeaveRequestHalfDay, "Morning", "Afternoon", "", "", "", "", "", ""),  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFLeaveRequestHalfDay_Sel)),  AV76TFLeaveRequestHalfDay_Sel,  AV76TFLeaveRequestHalfDay_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFLEAVEREQUESTDURATION",  "Duration",  !((Convert.ToDecimal(0)==AV48TFLeaveRequestDuration)&&(Convert.ToDecimal(0)==AV49TFLeaveRequestDuration_To)),  0,  StringUtil.Trim( StringUtil.Str( AV48TFLeaveRequestDuration, 4, 1)),  ((Convert.ToDecimal(0)==AV48TFLeaveRequestDuration) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFLeaveRequestDuration, "Z9.9"))),  true,  StringUtil.Trim( StringUtil.Str( AV49TFLeaveRequestDuration_To, 4, 1)),  ((Convert.ToDecimal(0)==AV49TFLeaveRequestDuration_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV49TFLeaveRequestDuration_To, "Z9.9")))) ;
         AV72AuxText = ((AV51TFLeaveRequestStatus_Sels.Count==1) ? "["+AV51TFLeaveRequestStatus_Sels.GetString(1)+"]" : "multiple values");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFLEAVEREQUESTSTATUS",  "Status",  !(String.IsNullOrEmpty(StringUtil.RTrim( AV77TFLeaveRequestStatus))&&(0==AV78TFLeaveRequestStatusOperator)),  AV78TFLeaveRequestStatusOperator,  AV77TFLeaveRequestStatus,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV78TFLeaveRequestStatusOperator+1), 10, 0)), AV77TFLeaveRequestStatus, "Pending", "Approved", "Rejected", "", "", "", "", ""),  false,  "",  "",  !(AV51TFLeaveRequestStatus_Sels.Count==0),  AV51TFLeaveRequestStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV72AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV72AuxText, "[Pending]", "Pending"), "[Approved]", "Approved"), "[Rejected]", "Rejected"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFLEAVEREQUESTDESCRIPTION",  "Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFLeaveRequestDescription)),  0,  AV52TFLeaveRequestDescription,  AV52TFLeaveRequestDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFLeaveRequestDescription_Sel)),  AV53TFLeaveRequestDescription_Sel,  AV53TFLeaveRequestDescription_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFLEAVEREQUESTREJECTIONREASON",  "Rejection Reason",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFLeaveRequestRejectionReason)),  0,  AV54TFLeaveRequestRejectionReason,  AV54TFLeaveRequestRejectionReason,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFLeaveRequestRejectionReason_Sel)),  AV55TFLeaveRequestRejectionReason_Sel,  AV55TFLeaveRequestRejectionReason_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV83Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV83Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "LeaveRequest";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S202( )
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
         new leaverequestwwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
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

      protected void wb_table1_23_4C2( bool wbgen )
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
            wb_table2_28_4C2( true) ;
         }
         else
         {
            wb_table2_28_4C2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_4C2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_4C2e( true) ;
         }
         else
         {
            wb_table1_23_4C2e( false) ;
         }
      }

      protected void wb_table2_28_4C2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_LeaveRequestWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_4C2e( true) ;
         }
         else
         {
            wb_table2_28_4C2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV73Mesage = (string)getParm(obj,0);
         AssignAttri("", false, "AV73Mesage", AV73Mesage);
         GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Mesage, "")), context));
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
         PA4C2( ) ;
         WS4C2( ) ;
         WE4C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20246131153319", true, true);
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
         context.AddJavascriptSource("leaverequestww.js", "?20246131153320", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_412( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_41_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_41_idx;
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID_"+sGXsfl_41_idx;
         edtLeaveTypeId_Internalname = "LEAVETYPEID_"+sGXsfl_41_idx;
         edtLeaveTypeName_Internalname = "LEAVETYPENAME_"+sGXsfl_41_idx;
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE_"+sGXsfl_41_idx;
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE_"+sGXsfl_41_idx;
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE_"+sGXsfl_41_idx;
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY_"+sGXsfl_41_idx;
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION_"+sGXsfl_41_idx;
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS_"+sGXsfl_41_idx;
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION_"+sGXsfl_41_idx;
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON_"+sGXsfl_41_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_41_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_41_fel_idx;
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID_"+sGXsfl_41_fel_idx;
         edtLeaveTypeId_Internalname = "LEAVETYPEID_"+sGXsfl_41_fel_idx;
         edtLeaveTypeName_Internalname = "LEAVETYPENAME_"+sGXsfl_41_fel_idx;
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE_"+sGXsfl_41_fel_idx;
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE_"+sGXsfl_41_fel_idx;
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE_"+sGXsfl_41_fel_idx;
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY_"+sGXsfl_41_fel_idx;
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION_"+sGXsfl_41_fel_idx;
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS_"+sGXsfl_41_fel_idx;
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION_"+sGXsfl_41_fel_idx;
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON_"+sGXsfl_41_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         SubsflControlProps_412( ) ;
         WB4C0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_41_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_41_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_41_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = edtavUpdate_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV65Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)edtavUpdate_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = edtavDelete_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV67Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)edtavDelete_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A124LeaveTypeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveTypeName_Internalname,StringUtil.RTrim( A125LeaveTypeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtLeaveTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDate_Internalname,context.localUtil.Format(A128LeaveRequestDate, "99/99/99"),context.localUtil.Format( A128LeaveRequestDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestStartDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestStartDate_Internalname,context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"),context.localUtil.Format( A129LeaveRequestStartDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestStartDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtLeaveRequestStartDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestEndDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestEndDate_Internalname,context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"),context.localUtil.Format( A130LeaveRequestEndDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestEndDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtLeaveRequestEndDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveRequestHalfDay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestHalfDay_Internalname,StringUtil.RTrim( A173LeaveRequestHalfDay),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestHalfDay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtLeaveRequestHalfDay_Columnclass,(string)edtLeaveRequestHalfDay_Columnheaderclass,(int)edtLeaveRequestHalfDay_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestDuration_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDuration_Internalname,StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")),StringUtil.LTrim( context.localUtil.Format( A131LeaveRequestDuration, "Z9.9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDuration_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtLeaveRequestDuration_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbLeaveRequestStatus.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbLeaveRequestStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "LEAVEREQUESTSTATUS_" + sGXsfl_41_idx;
               cmbLeaveRequestStatus.Name = GXCCtl;
               cmbLeaveRequestStatus.WebTags = "";
               cmbLeaveRequestStatus.addItem("Pending", "Pending", 0);
               cmbLeaveRequestStatus.addItem("Approved", "Approved", 0);
               cmbLeaveRequestStatus.addItem("Rejected", "Rejected", 0);
               if ( cmbLeaveRequestStatus.ItemCount > 0 )
               {
                  A132LeaveRequestStatus = cmbLeaveRequestStatus.getValidValue(A132LeaveRequestStatus);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbLeaveRequestStatus,(string)cmbLeaveRequestStatus_Internalname,StringUtil.RTrim( A132LeaveRequestStatus),(short)1,(string)cmbLeaveRequestStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbLeaveRequestStatus.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbLeaveRequestStatus_Columnclass,(string)cmbLeaveRequestStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbLeaveRequestStatus.CurrentValue = StringUtil.RTrim( A132LeaveRequestStatus);
            AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Values", (string)(cmbLeaveRequestStatus.ToJavascriptSource()), !bGXsfl_41_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveRequestDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDescription_Internalname,(string)A133LeaveRequestDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtLeaveRequestDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveRequestRejectionReason_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestRejectionReason_Internalname,(string)A134LeaveRequestRejectionReason,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestRejectionReason_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtLeaveRequestRejectionReason_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4C2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "LEAVEREQUESTSTATUS_" + sGXsfl_41_idx;
         cmbLeaveRequestStatus.Name = GXCCtl;
         cmbLeaveRequestStatus.WebTags = "";
         cmbLeaveRequestStatus.addItem("Pending", "Pending", 0);
         cmbLeaveRequestStatus.addItem("Approved", "Approved", 0);
         cmbLeaveRequestStatus.addItem("Rejected", "Rejected", 0);
         if ( cmbLeaveRequestStatus.ItemCount > 0 )
         {
            A132LeaveRequestStatus = cmbLeaveRequestStatus.getValidValue(A132LeaveRequestStatus);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl41( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"41\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUpdate_Class+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDelete_Class+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Leave Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestStartDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Start Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestEndDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "End Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestHalfDay_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Half Day") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestDuration_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Duration") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbLeaveRequestStatus.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestRejectionReason_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Rejection Reason") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV65Update)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUpdate_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV67Delete)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDelete_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A125LeaveTypeName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveTypeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A128LeaveRequestDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestStartDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestEndDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A173LeaveRequestHalfDay)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtLeaveRequestHalfDay_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtLeaveRequestHalfDay_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestHalfDay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestDuration_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A132LeaveRequestStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbLeaveRequestStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbLeaveRequestStatus_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbLeaveRequestStatus.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A133LeaveRequestDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A134LeaveRequestRejectionReason));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestRejectionReason_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
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
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID";
         edtLeaveTypeId_Internalname = "LEAVETYPEID";
         edtLeaveTypeName_Internalname = "LEAVETYPENAME";
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE";
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE";
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE";
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY";
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION";
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS";
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION";
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_leaverequeststartdateauxdatetext_Internalname = "vDDO_LEAVEREQUESTSTARTDATEAUXDATETEXT";
         Tfleaverequeststartdate_rangepicker_Internalname = "TFLEAVEREQUESTSTARTDATE_RANGEPICKER";
         divDdo_leaverequeststartdateauxdates_Internalname = "DDO_LEAVEREQUESTSTARTDATEAUXDATES";
         edtavDdo_leaverequestenddateauxdatetext_Internalname = "vDDO_LEAVEREQUESTENDDATEAUXDATETEXT";
         Tfleaverequestenddate_rangepicker_Internalname = "TFLEAVEREQUESTENDDATE_RANGEPICKER";
         divDdo_leaverequestenddateauxdates_Internalname = "DDO_LEAVEREQUESTENDDATEAUXDATES";
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
         edtEmployeeId_Jsonclick = "";
         edtLeaveRequestRejectionReason_Jsonclick = "";
         edtLeaveRequestDescription_Jsonclick = "";
         cmbLeaveRequestStatus_Jsonclick = "";
         cmbLeaveRequestStatus_Columnclass = "WWColumn hidden-xs";
         edtLeaveRequestDuration_Jsonclick = "";
         edtLeaveRequestHalfDay_Jsonclick = "";
         edtLeaveRequestHalfDay_Columnclass = "WWColumn";
         edtLeaveRequestEndDate_Jsonclick = "";
         edtLeaveRequestStartDate_Jsonclick = "";
         edtLeaveRequestDate_Jsonclick = "";
         edtLeaveTypeName_Jsonclick = "";
         edtLeaveTypeId_Jsonclick = "";
         edtLeaveRequestId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Class = "Attribute";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Class = "Attribute";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         cmbLeaveRequestStatus_Columnheaderclass = "";
         edtLeaveRequestHalfDay_Columnheaderclass = "";
         edtLeaveRequestRejectionReason_Visible = -1;
         edtLeaveRequestDescription_Visible = -1;
         cmbLeaveRequestStatus.Visible = -1;
         edtLeaveRequestDuration_Visible = -1;
         edtLeaveRequestHalfDay_Visible = -1;
         edtLeaveRequestEndDate_Visible = -1;
         edtLeaveRequestStartDate_Visible = -1;
         edtLeaveTypeName_Visible = -1;
         edtEmployeeId_Enabled = 0;
         edtLeaveRequestRejectionReason_Enabled = 0;
         edtLeaveRequestDescription_Enabled = 0;
         cmbLeaveRequestStatus.Enabled = 0;
         edtLeaveRequestDuration_Enabled = 0;
         edtLeaveRequestHalfDay_Enabled = 0;
         edtLeaveRequestEndDate_Enabled = 0;
         edtLeaveRequestStartDate_Enabled = 0;
         edtLeaveRequestDate_Enabled = 0;
         edtLeaveTypeName_Enabled = 0;
         edtLeaveTypeId_Enabled = 0;
         edtLeaveRequestId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_leaverequestenddateauxdatetext_Jsonclick = "";
         edtavDdo_leaverequeststartdateauxdatetext_Jsonclick = "";
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;L;;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "||||4.1|||";
         Ddo_grid_Fixedfilters = "|||1:Morning:fa fa-circle FontColorIconInfo FontColorIconSmall ConditionalFormattingFilterIcon,2:Afternoon:fa fa-circle FontColorIconWarning FontColorIconSmall ConditionalFormattingFilterIcon||1:Pending:fa fa-circle FontColorIconWarning FontColorIconSmall ConditionalFormattingFilterIcon,2:Approved:fa fa-circle FontColorIconSuccess FontColorIconSmall ConditionalFormattingFilterIcon,3:Rejected:fa fa-circle FontColorIconDanger FontColorIconSmall ConditionalFormattingFilterIcon||";
         Ddo_grid_Datalistproc = "LeaveRequestWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||Pending:Pending,Approved:Approved,Rejected:Rejected||";
         Ddo_grid_Allowmultipleselection = "|||||T||";
         Ddo_grid_Datalisttype = "Dynamic|||Dynamic||FixedValues|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|||T||T|T|T";
         Ddo_grid_Filterisrange = "|P|P||T|||";
         Ddo_grid_Filtertype = "Character|Date|Date|Character|Numeric||Character|Character";
         Ddo_grid_Includefilter = "T|T|T|T|T||T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "4:LeaveTypeName|6:LeaveRequestStartDate|7:LeaveRequestEndDate|8:LeaveRequestHalfDay|9:LeaveRequestDuration|10:LeaveRequestStatus|11:LeaveRequestDescription|12:LeaveRequestRejectionReason";
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
         Form.Caption = " Leave Request";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV73Mesage',fld:'vMESAGE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtLeaveTypeName_Visible',ctrl:'LEAVETYPENAME',prop:'Visible'},{av:'edtLeaveRequestStartDate_Visible',ctrl:'LEAVEREQUESTSTARTDATE',prop:'Visible'},{av:'edtLeaveRequestEndDate_Visible',ctrl:'LEAVEREQUESTENDDATE',prop:'Visible'},{av:'edtLeaveRequestHalfDay_Visible',ctrl:'LEAVEREQUESTHALFDAY',prop:'Visible'},{av:'edtLeaveRequestDuration_Visible',ctrl:'LEAVEREQUESTDURATION',prop:'Visible'},{av:'cmbLeaveRequestStatus'},{av:'edtLeaveRequestDescription_Visible',ctrl:'LEAVEREQUESTDESCRIPTION',prop:'Visible'},{av:'edtLeaveRequestRejectionReason_Visible',ctrl:'LEAVEREQUESTREJECTIONREASON',prop:'Visible'},{av:'AV62GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV63GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV64GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtLeaveRequestHalfDay_Columnheaderclass',ctrl:'LEAVEREQUESTHALFDAY',prop:'Columnheaderclass'},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E124C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV73Mesage',fld:'vMESAGE',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E134C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV73Mesage',fld:'vMESAGE',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E154C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV73Mesage',fld:'vMESAGE',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Selectedcolumnfixedfilter',ctrl:'DDO_GRID',prop:'SelectedColumnFixedFilter'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV50TFLeaveRequestStatus_SelsJson',fld:'vTFLEAVEREQUESTSTATUS_SELSJSON',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E204C2',iparms:[{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'cmbLeaveRequestStatus'},{av:'A132LeaveRequestStatus',fld:'LEAVEREQUESTSTATUS',pic:''},{av:'A127LeaveRequestId',fld:'LEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Class',ctrl:'vUPDATE',prop:'Class'},{av:'AV67Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Class',ctrl:'vDELETE',prop:'Class'},{av:'edtLeaveRequestHalfDay_Columnclass',ctrl:'LEAVEREQUESTHALFDAY',prop:'Columnclass'},{av:'cmbLeaveRequestStatus'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E164C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV73Mesage',fld:'vMESAGE',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtLeaveTypeName_Visible',ctrl:'LEAVETYPENAME',prop:'Visible'},{av:'edtLeaveRequestStartDate_Visible',ctrl:'LEAVEREQUESTSTARTDATE',prop:'Visible'},{av:'edtLeaveRequestEndDate_Visible',ctrl:'LEAVEREQUESTENDDATE',prop:'Visible'},{av:'edtLeaveRequestHalfDay_Visible',ctrl:'LEAVEREQUESTHALFDAY',prop:'Visible'},{av:'edtLeaveRequestDuration_Visible',ctrl:'LEAVEREQUESTDURATION',prop:'Visible'},{av:'cmbLeaveRequestStatus'},{av:'edtLeaveRequestDescription_Visible',ctrl:'LEAVEREQUESTDESCRIPTION',prop:'Visible'},{av:'edtLeaveRequestRejectionReason_Visible',ctrl:'LEAVEREQUESTREJECTIONREASON',prop:'Visible'},{av:'AV62GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV63GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV64GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtLeaveRequestHalfDay_Columnheaderclass',ctrl:'LEAVEREQUESTHALFDAY',prop:'Columnheaderclass'},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E114C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV73Mesage',fld:'vMESAGE',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV50TFLeaveRequestStatus_SelsJson',fld:'vTFLEAVEREQUESTSTATUS_SELSJSON',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'Ddo_grid_Selectedfixedfilter',ctrl:'DDO_GRID',prop:'SelectedFixedFilter'},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV50TFLeaveRequestStatus_SelsJson',fld:'vTFLEAVEREQUESTSTATUS_SELSJSON',pic:''},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtLeaveTypeName_Visible',ctrl:'LEAVETYPENAME',prop:'Visible'},{av:'edtLeaveRequestStartDate_Visible',ctrl:'LEAVEREQUESTSTARTDATE',prop:'Visible'},{av:'edtLeaveRequestEndDate_Visible',ctrl:'LEAVEREQUESTENDDATE',prop:'Visible'},{av:'edtLeaveRequestHalfDay_Visible',ctrl:'LEAVEREQUESTHALFDAY',prop:'Visible'},{av:'edtLeaveRequestDuration_Visible',ctrl:'LEAVEREQUESTDURATION',prop:'Visible'},{av:'cmbLeaveRequestStatus'},{av:'edtLeaveRequestDescription_Visible',ctrl:'LEAVEREQUESTDESCRIPTION',prop:'Visible'},{av:'edtLeaveRequestRejectionReason_Visible',ctrl:'LEAVEREQUESTREJECTIONREASON',prop:'Visible'},{av:'AV62GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV63GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV64GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtLeaveRequestHalfDay_Columnheaderclass',ctrl:'LEAVEREQUESTHALFDAY',prop:'Columnheaderclass'},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E174C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV73Mesage',fld:'vMESAGE',pic:'',hsh:true},{av:'A127LeaveRequestId',fld:'LEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtLeaveTypeName_Visible',ctrl:'LEAVETYPENAME',prop:'Visible'},{av:'edtLeaveRequestStartDate_Visible',ctrl:'LEAVEREQUESTSTARTDATE',prop:'Visible'},{av:'edtLeaveRequestEndDate_Visible',ctrl:'LEAVEREQUESTENDDATE',prop:'Visible'},{av:'edtLeaveRequestHalfDay_Visible',ctrl:'LEAVEREQUESTHALFDAY',prop:'Visible'},{av:'edtLeaveRequestDuration_Visible',ctrl:'LEAVEREQUESTDURATION',prop:'Visible'},{av:'cmbLeaveRequestStatus'},{av:'edtLeaveRequestDescription_Visible',ctrl:'LEAVEREQUESTDESCRIPTION',prop:'Visible'},{av:'edtLeaveRequestRejectionReason_Visible',ctrl:'LEAVEREQUESTREJECTIONREASON',prop:'Visible'},{av:'AV62GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV63GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV64GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtLeaveRequestHalfDay_Columnheaderclass',ctrl:'LEAVEREQUESTHALFDAY',prop:'Columnheaderclass'},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E144C2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV50TFLeaveRequestStatus_SelsJson',fld:'vTFLEAVEREQUESTSTATUS_SELSJSON',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFLeaveTypeName',fld:'vTFLEAVETYPENAME',pic:''},{av:'AV32TFLeaveTypeName_Sel',fld:'vTFLEAVETYPENAME_SEL',pic:''},{av:'AV38TFLeaveRequestStartDate',fld:'vTFLEAVEREQUESTSTARTDATE',pic:''},{av:'AV39TFLeaveRequestStartDate_To',fld:'vTFLEAVEREQUESTSTARTDATE_TO',pic:''},{av:'AV43TFLeaveRequestEndDate',fld:'vTFLEAVEREQUESTENDDATE',pic:''},{av:'AV44TFLeaveRequestEndDate_To',fld:'vTFLEAVEREQUESTENDDATE_TO',pic:''},{av:'AV75TFLeaveRequestHalfDay',fld:'vTFLEAVEREQUESTHALFDAY',pic:''},{av:'AV80TFLeaveRequestHalfDayOperator',fld:'vTFLEAVEREQUESTHALFDAYOPERATOR',pic:'ZZZ9'},{av:'AV76TFLeaveRequestHalfDay_Sel',fld:'vTFLEAVEREQUESTHALFDAY_SEL',pic:''},{av:'AV48TFLeaveRequestDuration',fld:'vTFLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'AV49TFLeaveRequestDuration_To',fld:'vTFLEAVEREQUESTDURATION_TO',pic:'Z9.9'},{av:'AV77TFLeaveRequestStatus',fld:'vTFLEAVEREQUESTSTATUS',pic:''},{av:'AV78TFLeaveRequestStatusOperator',fld:'vTFLEAVEREQUESTSTATUSOPERATOR',pic:'ZZZ9'},{av:'AV51TFLeaveRequestStatus_Sels',fld:'vTFLEAVEREQUESTSTATUS_SELS',pic:''},{av:'AV52TFLeaveRequestDescription',fld:'vTFLEAVEREQUESTDESCRIPTION',pic:''},{av:'AV53TFLeaveRequestDescription_Sel',fld:'vTFLEAVEREQUESTDESCRIPTION_SEL',pic:''},{av:'AV54TFLeaveRequestRejectionReason',fld:'vTFLEAVEREQUESTREJECTIONREASON',pic:''},{av:'AV55TFLeaveRequestRejectionReason_Sel',fld:'vTFLEAVEREQUESTREJECTIONREASON_SEL',pic:''},{av:'AV66IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV68IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV71IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV73Mesage',fld:'vMESAGE',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV50TFLeaveRequestStatus_SelsJson',fld:'vTFLEAVEREQUESTSTATUS_SELSJSON',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Selectedfixedfilter',ctrl:'DDO_GRID',prop:'SelectedFixedFilter'}]}");
         setEventMetadata("VALID_LEAVETYPEID","{handler:'Valid_Leavetypeid',iparms:[]");
         setEventMetadata("VALID_LEAVETYPEID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Employeeid',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         wcpOAV73Mesage = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Selectedcolumnfixedfilter = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV83Pgmname = "";
         AV31TFLeaveTypeName = "";
         AV32TFLeaveTypeName_Sel = "";
         AV38TFLeaveRequestStartDate = DateTime.MinValue;
         AV39TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV43TFLeaveRequestEndDate = DateTime.MinValue;
         AV44TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV75TFLeaveRequestHalfDay = "";
         AV76TFLeaveRequestHalfDay_Sel = "";
         AV77TFLeaveRequestStatus = "";
         AV51TFLeaveRequestStatus_Sels = new GxSimpleCollection<string>();
         AV52TFLeaveRequestDescription = "";
         AV53TFLeaveRequestDescription_Sel = "";
         AV54TFLeaveRequestRejectionReason = "";
         AV55TFLeaveRequestRejectionReason_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV64GridAppliedFilters = "";
         AV69AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV40DDO_LeaveRequestStartDateAuxDate = DateTime.MinValue;
         AV41DDO_LeaveRequestStartDateAuxDateTo = DateTime.MinValue;
         AV45DDO_LeaveRequestEndDateAuxDate = DateTime.MinValue;
         AV46DDO_LeaveRequestEndDateAuxDateTo = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV50TFLeaveRequestStatus_SelsJson = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_grid_Selectedfixedfilter = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV42DDO_LeaveRequestStartDateAuxDateText = "";
         ucTfleaverequeststartdate_rangepicker = new GXUserControl();
         AV47DDO_LeaveRequestEndDateAuxDateText = "";
         ucTfleaverequestenddate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV65Update = "";
         AV67Delete = "";
         A125LeaveTypeName = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         A132LeaveRequestStatus = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         AV98Leaverequestwwds_16_tfleaverequeststatus_sels = new GxSimpleCollection<string>();
         scmdbuf = "";
         lV84Leaverequestwwds_2_filterfulltext = "";
         lV85Leaverequestwwds_3_tfleavetypename = "";
         lV91Leaverequestwwds_9_tfleaverequesthalfday = "";
         lV99Leaverequestwwds_17_tfleaverequestdescription = "";
         lV101Leaverequestwwds_19_tfleaverequestrejectionreason = "";
         AV84Leaverequestwwds_2_filterfulltext = "";
         AV86Leaverequestwwds_4_tfleavetypename_sel = "";
         AV85Leaverequestwwds_3_tfleavetypename = "";
         AV87Leaverequestwwds_5_tfleaverequeststartdate = DateTime.MinValue;
         AV88Leaverequestwwds_6_tfleaverequeststartdate_to = DateTime.MinValue;
         AV89Leaverequestwwds_7_tfleaverequestenddate = DateTime.MinValue;
         AV90Leaverequestwwds_8_tfleaverequestenddate_to = DateTime.MinValue;
         AV93Leaverequestwwds_11_tfleaverequesthalfday_sel = "";
         AV91Leaverequestwwds_9_tfleaverequesthalfday = "";
         AV100Leaverequestwwds_18_tfleaverequestdescription_sel = "";
         AV99Leaverequestwwds_17_tfleaverequestdescription = "";
         AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel = "";
         AV101Leaverequestwwds_19_tfleaverequestrejectionreason = "";
         H004C2_A100CompanyId = new long[1] ;
         H004C2_A106EmployeeId = new long[1] ;
         H004C2_A134LeaveRequestRejectionReason = new string[] {""} ;
         H004C2_A133LeaveRequestDescription = new string[] {""} ;
         H004C2_A132LeaveRequestStatus = new string[] {""} ;
         H004C2_A131LeaveRequestDuration = new decimal[1] ;
         H004C2_A173LeaveRequestHalfDay = new string[] {""} ;
         H004C2_n173LeaveRequestHalfDay = new bool[] {false} ;
         H004C2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         H004C2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         H004C2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         H004C2_A125LeaveTypeName = new string[] {""} ;
         H004C2_A124LeaveTypeId = new long[1] ;
         H004C2_A127LeaveRequestId = new long[1] ;
         AV96Leaverequestwwds_14_tfleaverequeststatus = "";
         H004C3_AGRID_nRecordCount = new long[1] ;
         AV79GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV74MsgVar = "";
         AV8HTTPRequest = new GxHttpRequest( context);
         AV70AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV59GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV60GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV19ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         AV20UserCustomValue = "";
         AV22ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV72AuxText = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestww__default(),
            new Object[][] {
                new Object[] {
               H004C2_A100CompanyId, H004C2_A106EmployeeId, H004C2_A134LeaveRequestRejectionReason, H004C2_A133LeaveRequestDescription, H004C2_A132LeaveRequestStatus, H004C2_A131LeaveRequestDuration, H004C2_A173LeaveRequestHalfDay, H004C2_n173LeaveRequestHalfDay, H004C2_A130LeaveRequestEndDate, H004C2_A129LeaveRequestStartDate,
               H004C2_A128LeaveRequestDate, H004C2_A125LeaveTypeName, H004C2_A124LeaveTypeId, H004C2_A127LeaveRequestId
               }
               , new Object[] {
               H004C3_AGRID_nRecordCount
               }
            }
         );
         AV83Pgmname = "LeaveRequestWW";
         /* GeneXus formulas. */
         AV83Pgmname = "LeaveRequestWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV80TFLeaveRequestHalfDayOperator ;
      private short AV78TFLeaveRequestStatusOperator ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator ;
      private short AV97Leaverequestwwds_15_tfleaverequeststatusoperator ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_41 ;
      private int nGXsfl_41_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV98Leaverequestwwds_16_tfleaverequeststatus_sels_Count ;
      private int edtLeaveRequestId_Enabled ;
      private int edtLeaveTypeId_Enabled ;
      private int edtLeaveTypeName_Enabled ;
      private int edtLeaveRequestDate_Enabled ;
      private int edtLeaveRequestStartDate_Enabled ;
      private int edtLeaveRequestEndDate_Enabled ;
      private int edtLeaveRequestHalfDay_Enabled ;
      private int edtLeaveRequestDuration_Enabled ;
      private int edtLeaveRequestDescription_Enabled ;
      private int edtLeaveRequestRejectionReason_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtLeaveTypeName_Visible ;
      private int edtLeaveRequestStartDate_Visible ;
      private int edtLeaveRequestEndDate_Visible ;
      private int edtLeaveRequestHalfDay_Visible ;
      private int edtLeaveRequestDuration_Visible ;
      private int edtLeaveRequestDescription_Visible ;
      private int edtLeaveRequestRejectionReason_Visible ;
      private int AV61PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV104GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV62GridCurrentPage ;
      private long AV63GridPageCount ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long GRID_nCurrentRecord ;
      private long A100CompanyId ;
      private long AV103Udparg21 ;
      private long AV81Udparg1 ;
      private long GRID_nRecordCount ;
      private decimal AV48TFLeaveRequestDuration ;
      private decimal AV49TFLeaveRequestDuration_To ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV94Leaverequestwwds_12_tfleaverequestduration ;
      private decimal AV95Leaverequestwwds_13_tfleaverequestduration_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Selectedcolumnfixedfilter ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_41_idx="0001" ;
      private string AV83Pgmname ;
      private string AV31TFLeaveTypeName ;
      private string AV32TFLeaveTypeName_Sel ;
      private string AV75TFLeaveRequestHalfDay ;
      private string AV76TFLeaveRequestHalfDay_Sel ;
      private string AV77TFLeaveRequestStatus ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Fixedfilters ;
      private string Ddo_grid_Format ;
      private string Ddo_grid_Selectedfixedfilter ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
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
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
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
      private string divDdo_leaverequeststartdateauxdates_Internalname ;
      private string edtavDdo_leaverequeststartdateauxdatetext_Internalname ;
      private string edtavDdo_leaverequeststartdateauxdatetext_Jsonclick ;
      private string Tfleaverequeststartdate_rangepicker_Internalname ;
      private string divDdo_leaverequestenddateauxdates_Internalname ;
      private string edtavDdo_leaverequestenddateauxdatetext_Internalname ;
      private string edtavDdo_leaverequestenddateauxdatetext_Jsonclick ;
      private string Tfleaverequestenddate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV65Update ;
      private string edtavUpdate_Internalname ;
      private string AV67Delete ;
      private string edtavDelete_Internalname ;
      private string edtLeaveRequestId_Internalname ;
      private string edtLeaveTypeId_Internalname ;
      private string A125LeaveTypeName ;
      private string edtLeaveTypeName_Internalname ;
      private string edtLeaveRequestDate_Internalname ;
      private string edtLeaveRequestStartDate_Internalname ;
      private string edtLeaveRequestEndDate_Internalname ;
      private string A173LeaveRequestHalfDay ;
      private string edtLeaveRequestHalfDay_Internalname ;
      private string edtLeaveRequestDuration_Internalname ;
      private string cmbLeaveRequestStatus_Internalname ;
      private string A132LeaveRequestStatus ;
      private string edtLeaveRequestDescription_Internalname ;
      private string edtLeaveRequestRejectionReason_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string lV85Leaverequestwwds_3_tfleavetypename ;
      private string lV91Leaverequestwwds_9_tfleaverequesthalfday ;
      private string AV86Leaverequestwwds_4_tfleavetypename_sel ;
      private string AV85Leaverequestwwds_3_tfleavetypename ;
      private string AV93Leaverequestwwds_11_tfleaverequesthalfday_sel ;
      private string AV91Leaverequestwwds_9_tfleaverequesthalfday ;
      private string AV96Leaverequestwwds_14_tfleaverequeststatus ;
      private string edtLeaveRequestHalfDay_Columnheaderclass ;
      private string cmbLeaveRequestStatus_Columnheaderclass ;
      private string edtavUpdate_Link ;
      private string edtavUpdate_Class ;
      private string edtavDelete_Link ;
      private string edtavDelete_Class ;
      private string edtLeaveRequestHalfDay_Columnclass ;
      private string cmbLeaveRequestStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtLeaveRequestId_Jsonclick ;
      private string edtLeaveTypeId_Jsonclick ;
      private string edtLeaveTypeName_Jsonclick ;
      private string edtLeaveRequestDate_Jsonclick ;
      private string edtLeaveRequestStartDate_Jsonclick ;
      private string edtLeaveRequestEndDate_Jsonclick ;
      private string edtLeaveRequestHalfDay_Jsonclick ;
      private string edtLeaveRequestDuration_Jsonclick ;
      private string GXCCtl ;
      private string cmbLeaveRequestStatus_Jsonclick ;
      private string edtLeaveRequestDescription_Jsonclick ;
      private string edtLeaveRequestRejectionReason_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV38TFLeaveRequestStartDate ;
      private DateTime AV39TFLeaveRequestStartDate_To ;
      private DateTime AV43TFLeaveRequestEndDate ;
      private DateTime AV44TFLeaveRequestEndDate_To ;
      private DateTime AV40DDO_LeaveRequestStartDateAuxDate ;
      private DateTime AV41DDO_LeaveRequestStartDateAuxDateTo ;
      private DateTime AV45DDO_LeaveRequestEndDateAuxDate ;
      private DateTime AV46DDO_LeaveRequestEndDateAuxDateTo ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime AV87Leaverequestwwds_5_tfleaverequeststartdate ;
      private DateTime AV88Leaverequestwwds_6_tfleaverequeststartdate_to ;
      private DateTime AV89Leaverequestwwds_7_tfleaverequestenddate ;
      private DateTime AV90Leaverequestwwds_8_tfleaverequestenddate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV66IsAuthorized_Update ;
      private bool AV68IsAuthorized_Delete ;
      private bool AV71IsAuthorized_Insert ;
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
      private bool n173LeaveRequestHalfDay ;
      private bool bGXsfl_41_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV82Checking ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string AV50TFLeaveRequestStatus_SelsJson ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV73Mesage ;
      private string wcpOAV73Mesage ;
      private string AV16FilterFullText ;
      private string AV52TFLeaveRequestDescription ;
      private string AV53TFLeaveRequestDescription_Sel ;
      private string AV54TFLeaveRequestRejectionReason ;
      private string AV55TFLeaveRequestRejectionReason_Sel ;
      private string AV64GridAppliedFilters ;
      private string AV42DDO_LeaveRequestStartDateAuxDateText ;
      private string AV47DDO_LeaveRequestEndDateAuxDateText ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string lV84Leaverequestwwds_2_filterfulltext ;
      private string lV99Leaverequestwwds_17_tfleaverequestdescription ;
      private string lV101Leaverequestwwds_19_tfleaverequestrejectionreason ;
      private string AV84Leaverequestwwds_2_filterfulltext ;
      private string AV100Leaverequestwwds_18_tfleaverequestdescription_sel ;
      private string AV99Leaverequestwwds_17_tfleaverequestdescription ;
      private string AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel ;
      private string AV101Leaverequestwwds_19_tfleaverequestrejectionreason ;
      private string AV74MsgVar ;
      private string AV72AuxText ;
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
      private GXUserControl ucTfleaverequeststartdate_rangepicker ;
      private GXUserControl ucTfleaverequestenddate_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV79GAMUser ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbLeaveRequestStatus ;
      private IDataStoreProvider pr_default ;
      private long[] H004C2_A100CompanyId ;
      private long[] H004C2_A106EmployeeId ;
      private string[] H004C2_A134LeaveRequestRejectionReason ;
      private string[] H004C2_A133LeaveRequestDescription ;
      private string[] H004C2_A132LeaveRequestStatus ;
      private decimal[] H004C2_A131LeaveRequestDuration ;
      private string[] H004C2_A173LeaveRequestHalfDay ;
      private bool[] H004C2_n173LeaveRequestHalfDay ;
      private DateTime[] H004C2_A130LeaveRequestEndDate ;
      private DateTime[] H004C2_A129LeaveRequestStartDate ;
      private DateTime[] H004C2_A128LeaveRequestDate ;
      private string[] H004C2_A125LeaveTypeName ;
      private long[] H004C2_A124LeaveTypeId ;
      private long[] H004C2_A127LeaveRequestId ;
      private long[] H004C3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GxSimpleCollection<string> AV51TFLeaveRequestStatus_Sels ;
      private GxSimpleCollection<string> AV98Leaverequestwwds_16_tfleaverequeststatus_sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV69AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV60GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV70AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV58DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV59GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class leaverequestww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004C2( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV98Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                             string AV84Leaverequestwwds_2_filterfulltext ,
                                             string AV86Leaverequestwwds_4_tfleavetypename_sel ,
                                             string AV85Leaverequestwwds_3_tfleavetypename ,
                                             DateTime AV87Leaverequestwwds_5_tfleaverequeststartdate ,
                                             DateTime AV88Leaverequestwwds_6_tfleaverequeststartdate_to ,
                                             DateTime AV89Leaverequestwwds_7_tfleaverequestenddate ,
                                             DateTime AV90Leaverequestwwds_8_tfleaverequestenddate_to ,
                                             string AV93Leaverequestwwds_11_tfleaverequesthalfday_sel ,
                                             string AV91Leaverequestwwds_9_tfleaverequesthalfday ,
                                             short AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator ,
                                             decimal AV94Leaverequestwwds_12_tfleaverequestduration ,
                                             decimal AV95Leaverequestwwds_13_tfleaverequestduration_to ,
                                             int AV98Leaverequestwwds_16_tfleaverequeststatus_sels_Count ,
                                             short AV97Leaverequestwwds_15_tfleaverequeststatusoperator ,
                                             string AV100Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                             string AV99Leaverequestwwds_17_tfleaverequestdescription ,
                                             string AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                             string AV101Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             long A100CompanyId ,
                                             long AV103Udparg21 ,
                                             long A106EmployeeId ,
                                             long AV81Udparg1 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[27];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.CompanyId, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestStatus, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDate, T2.LeaveTypeName, T1.LeaveTypeId, T1.LeaveRequestId";
         sFromString = " FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T2.CompanyId = :AV103Udparg21)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV81Udparg1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV84Leaverequestwwds_2_filterfulltext) or ( 'pending' like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext)))");
         }
         else
         {
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
            GXv_int9[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Leaverequestwwds_4_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Leaverequestwwds_3_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV85Leaverequestwwds_3_tfleavetypename))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Leaverequestwwds_4_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV86Leaverequestwwds_4_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV86Leaverequestwwds_4_tfleavetypename_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV86Leaverequestwwds_4_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV87Leaverequestwwds_5_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV87Leaverequestwwds_5_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Leaverequestwwds_6_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV88Leaverequestwwds_6_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Leaverequestwwds_7_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV89Leaverequestwwds_7_tfleaverequestenddate)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Leaverequestwwds_8_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV90Leaverequestwwds_8_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Leaverequestwwds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Leaverequestwwds_9_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV91Leaverequestwwds_9_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Leaverequestwwds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV93Leaverequestwwds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV93Leaverequestwwds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV93Leaverequestwwds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV94Leaverequestwwds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV94Leaverequestwwds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV95Leaverequestwwds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV95Leaverequestwwds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( AV98Leaverequestwwds_16_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV98Leaverequestwwds_16_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV97Leaverequestwwds_15_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV97Leaverequestwwds_15_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV97Leaverequestwwds_15_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Leaverequestwwds_18_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Leaverequestwwds_17_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV99Leaverequestwwds_17_tfleaverequestdescription))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Leaverequestwwds_18_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV100Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV100Leaverequestwwds_18_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( StringUtil.StrCmp(AV100Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Leaverequestwwds_19_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV101Leaverequestwwds_19_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( StringUtil.StrCmp(AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.LeaveRequestId DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.LeaveTypeName, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.LeaveTypeName DESC, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestStartDate, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestStartDate DESC, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestEndDate, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestEndDate DESC, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestHalfDay, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestHalfDay DESC, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDuration, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDuration DESC, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestStatus, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestStatus DESC, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDescription, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDescription DESC, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestRejectionReason, T1.LeaveRequestId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestRejectionReason DESC, T1.LeaveRequestId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.LeaveRequestId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H004C3( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV98Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                             string AV84Leaverequestwwds_2_filterfulltext ,
                                             string AV86Leaverequestwwds_4_tfleavetypename_sel ,
                                             string AV85Leaverequestwwds_3_tfleavetypename ,
                                             DateTime AV87Leaverequestwwds_5_tfleaverequeststartdate ,
                                             DateTime AV88Leaverequestwwds_6_tfleaverequeststartdate_to ,
                                             DateTime AV89Leaverequestwwds_7_tfleaverequestenddate ,
                                             DateTime AV90Leaverequestwwds_8_tfleaverequestenddate_to ,
                                             string AV93Leaverequestwwds_11_tfleaverequesthalfday_sel ,
                                             string AV91Leaverequestwwds_9_tfleaverequesthalfday ,
                                             short AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator ,
                                             decimal AV94Leaverequestwwds_12_tfleaverequestduration ,
                                             decimal AV95Leaverequestwwds_13_tfleaverequestduration_to ,
                                             int AV98Leaverequestwwds_16_tfleaverequeststatus_sels_Count ,
                                             short AV97Leaverequestwwds_15_tfleaverequeststatusoperator ,
                                             string AV100Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                             string AV99Leaverequestwwds_17_tfleaverequestdescription ,
                                             string AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                             string AV101Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             long A100CompanyId ,
                                             long AV103Udparg21 ,
                                             long A106EmployeeId ,
                                             long AV81Udparg1 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[24];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV103Udparg21)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV81Udparg1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Leaverequestwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV84Leaverequestwwds_2_filterfulltext) or ( 'pending' like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV84Leaverequestwwds_2_filterfulltext)))");
         }
         else
         {
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
            GXv_int11[8] = 1;
            GXv_int11[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Leaverequestwwds_4_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Leaverequestwwds_3_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV85Leaverequestwwds_3_tfleavetypename))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Leaverequestwwds_4_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV86Leaverequestwwds_4_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV86Leaverequestwwds_4_tfleavetypename_sel))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( StringUtil.StrCmp(AV86Leaverequestwwds_4_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV87Leaverequestwwds_5_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV87Leaverequestwwds_5_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Leaverequestwwds_6_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV88Leaverequestwwds_6_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Leaverequestwwds_7_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV89Leaverequestwwds_7_tfleaverequestenddate)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Leaverequestwwds_8_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV90Leaverequestwwds_8_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Leaverequestwwds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Leaverequestwwds_9_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV91Leaverequestwwds_9_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Leaverequestwwds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV93Leaverequestwwds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV93Leaverequestwwds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( StringUtil.StrCmp(AV93Leaverequestwwds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV92Leaverequestwwds_10_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV94Leaverequestwwds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV94Leaverequestwwds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV95Leaverequestwwds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV95Leaverequestwwds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( AV98Leaverequestwwds_16_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV98Leaverequestwwds_16_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV97Leaverequestwwds_15_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV97Leaverequestwwds_15_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV97Leaverequestwwds_15_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Leaverequestwwds_18_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Leaverequestwwds_17_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV99Leaverequestwwds_17_tfleaverequestdescription))");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Leaverequestwwds_18_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV100Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV100Leaverequestwwds_18_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( StringUtil.StrCmp(AV100Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Leaverequestwwds_19_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV101Leaverequestwwds_19_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( StringUtil.StrCmp(AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
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
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H004C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
               case 1 :
                     return conditional_H004C3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
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
          Object[] prmH004C2;
          prmH004C2 = new Object[] {
          new ParDef("AV103Udparg21",GXType.Int64,10,0) ,
          new ParDef("AV81Udparg1",GXType.Int64,10,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Leaverequestwwds_3_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV86Leaverequestwwds_4_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV87Leaverequestwwds_5_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV88Leaverequestwwds_6_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV89Leaverequestwwds_7_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV90Leaverequestwwds_8_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV91Leaverequestwwds_9_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV93Leaverequestwwds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV94Leaverequestwwds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV95Leaverequestwwds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV99Leaverequestwwds_17_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV100Leaverequestwwds_18_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV101Leaverequestwwds_19_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004C3;
          prmH004C3 = new Object[] {
          new ParDef("AV103Udparg21",GXType.Int64,10,0) ,
          new ParDef("AV81Udparg1",GXType.Int64,10,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Leaverequestwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Leaverequestwwds_3_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV86Leaverequestwwds_4_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV87Leaverequestwwds_5_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV88Leaverequestwwds_6_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV89Leaverequestwwds_7_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV90Leaverequestwwds_8_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV91Leaverequestwwds_9_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV93Leaverequestwwds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV94Leaverequestwwds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV95Leaverequestwwds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV99Leaverequestwwds_17_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV100Leaverequestwwds_18_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV101Leaverequestwwds_19_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV102Leaverequestwwds_20_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004C2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004C3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                ((long[]) buf[13])[0] = rslt.getLong(13);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
