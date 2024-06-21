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
   public class employeeww : GXDataArea
   {
      public employeeww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeeww( IGxContext context )
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
         chkEmployeeIsManager = new GXCheckbox();
         chkEmployeeIsActive = new GXCheckbox();
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
         AV20FilterFullText = GetPar( "FilterFullText");
         AV30ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV25ColumnsSelector);
         AV82Pgmname = GetPar( "Pgmname");
         AV66TFEmployeeName = GetPar( "TFEmployeeName");
         AV67TFEmployeeName_Sel = GetPar( "TFEmployeeName_Sel");
         AV37TFEmployeeEmail = GetPar( "TFEmployeeEmail");
         AV38TFEmployeeEmail_Sel = GetPar( "TFEmployeeEmail_Sel");
         AV43TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeIsManager_Sel"), "."), 18, MidpointRounding.ToEven));
         AV46TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeIsActive_Sel"), "."), 18, MidpointRounding.ToEven));
         AV47TFEmployeeVactionDays = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeVactionDays"), "."), 18, MidpointRounding.ToEven));
         AV48TFEmployeeVactionDays_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeVactionDays_To"), "."), 18, MidpointRounding.ToEven));
         AV49TFEmployeeBalance = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeBalance"), "."), 18, MidpointRounding.ToEven));
         AV50TFEmployeeBalance_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeBalance_To"), "."), 18, MidpointRounding.ToEven));
         A166ProjectManagerId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectManagerId"), "."), 18, MidpointRounding.ToEven));
         n166ProjectManagerId = false;
         AV96Udparg14 = (long)(Math.Round(NumberUtil.Val( GetPar( "Udparg14"), "."), 18, MidpointRounding.ToEven));
         A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV68ProjectIds);
         AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV18OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV58IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV60IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV65IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV82Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, AV47TFEmployeeVactionDays, AV48TFEmployeeVactionDays_To, AV49TFEmployeeBalance, AV50TFEmployeeBalance_To, A166ProjectManagerId, AV96Udparg14, A102ProjectId, AV68ProjectIds, AV17OrderedBy, AV18OrderedDsc, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
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
            return "employeeww_Execute" ;
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
         PA2V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2V2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("employeeww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG14", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV96Udparg14), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG14", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV96Udparg14), "9999999999"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTIDS", AV68ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTIDS", AV68ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTIDS", GetSecureSignedToken( "", AV68ProjectIds, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV60IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV60IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV20FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV28ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV28ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV9GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV63AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV63AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV51DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV51DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV25ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV25ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME", StringUtil.RTrim( AV66TFEmployeeName));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME_SEL", StringUtil.RTrim( AV67TFEmployeeName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEEMAIL", AV37TFEmployeeEmail);
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEEMAIL_SEL", AV38TFEmployeeEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEISMANAGER_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEISACTIVE_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEVACTIONDAYS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFEmployeeVactionDays), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEVACTIONDAYS_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFEmployeeVactionDays_To), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEBALANCE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49TFEmployeeBalance), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEBALANCE_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFEmployeeBalance_To), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROJECTMANAGERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A166ProjectManagerId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUDPARG14", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV96Udparg14), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG14", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV96Udparg14), "9999999999"), context));
         GxWebStd.gx_hidden_field( context, "PROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTIDS", AV68ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTIDS", AV68ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTIDS", GetSecureSignedToken( "", AV68ProjectIds, context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV18OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV60IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV60IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV15GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV15GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
            WE2V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2V2( ) ;
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
         return formatLink("employeeww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "EmployeeWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Employees" ;
      }

      protected void WB2V0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmployeeWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_EmployeeWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_EmployeeWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_23_2V2( true) ;
         }
         else
         {
            wb_table1_23_2V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_2V2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV55GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV56GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV9GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV63AGExportData);
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV51DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV51DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV25ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
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

      protected void START2V2( )
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
         Form.Meta.addItem("description", " Employees", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2V0( ) ;
      }

      protected void WS2V2( )
      {
         START2V2( ) ;
         EVT2V2( ) ;
      }

      protected void EVT2V2( )
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
                              E112V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E142V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E152V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E162V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E172V2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VINVITE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VINVITE.CLICK") == 0 ) )
                           {
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_412( ) ;
                              AV57Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
                              AV59Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV59Delete);
                              AV70Invite = cgiGet( edtavInvite_Internalname);
                              AssignAttri("", false, edtavInvite_Internalname, AV70Invite);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
                              A108EmployeeLastName = cgiGet( edtEmployeeLastName_Internalname);
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              A109EmployeeEmail = cgiGet( edtEmployeeEmail_Internalname);
                              A100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A101CompanyName = cgiGet( edtCompanyName_Internalname);
                              A110EmployeeIsManager = StringUtil.StrToBool( cgiGet( chkEmployeeIsManager_Internalname));
                              A111GAMUserGUID = cgiGet( edtGAMUserGUID_Internalname);
                              A112EmployeeIsActive = StringUtil.StrToBool( cgiGet( chkEmployeeIsActive_Internalname));
                              A146EmployeeVactionDays = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A147EmployeeBalance = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E182V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E192V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E202V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VINVITE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E212V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV20FilterFullText) != 0 )
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

      protected void WE2V2( )
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

      protected void PA2V2( )
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
                                       string AV20FilterFullText ,
                                       short AV30ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelector ,
                                       string AV82Pgmname ,
                                       string AV66TFEmployeeName ,
                                       string AV67TFEmployeeName_Sel ,
                                       string AV37TFEmployeeEmail ,
                                       string AV38TFEmployeeEmail_Sel ,
                                       short AV43TFEmployeeIsManager_Sel ,
                                       short AV46TFEmployeeIsActive_Sel ,
                                       short AV47TFEmployeeVactionDays ,
                                       short AV48TFEmployeeVactionDays_To ,
                                       short AV49TFEmployeeBalance ,
                                       short AV50TFEmployeeBalance_To ,
                                       long A166ProjectManagerId ,
                                       long AV96Udparg14 ,
                                       long A102ProjectId ,
                                       GxSimpleCollection<long> AV68ProjectIds ,
                                       short AV17OrderedBy ,
                                       bool AV18OrderedDsc ,
                                       bool AV58IsAuthorized_Update ,
                                       bool AV60IsAuthorized_Delete ,
                                       bool AV65IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_EMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
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
         RF2V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV82Pgmname = "EmployeeWW";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavInvite_Enabled = 0;
         AssignProp("", false, edtavInvite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInvite_Enabled), 5, 0), !bGXsfl_41_Refreshing);
      }

      protected void RF2V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E192V2 ();
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
                                                 A106EmployeeId ,
                                                 AV69EmployeeIds ,
                                                 AV83Employeewwds_3_filterfulltext ,
                                                 AV85Employeewwds_5_tfemployeename_sel ,
                                                 AV84Employeewwds_4_tfemployeename ,
                                                 AV87Employeewwds_7_tfemployeeemail_sel ,
                                                 AV86Employeewwds_6_tfemployeeemail ,
                                                 AV88Employeewwds_8_tfemployeeismanager_sel ,
                                                 AV89Employeewwds_9_tfemployeeisactive_sel ,
                                                 AV90Employeewwds_10_tfemployeevactiondays ,
                                                 AV91Employeewwds_11_tfemployeevactiondays_to ,
                                                 AV92Employeewwds_12_tfemployeebalance ,
                                                 AV93Employeewwds_13_tfemployeebalance_to ,
                                                 A148EmployeeName ,
                                                 A109EmployeeEmail ,
                                                 A146EmployeeVactionDays ,
                                                 A147EmployeeBalance ,
                                                 A110EmployeeIsManager ,
                                                 A112EmployeeIsActive ,
                                                 AV17OrderedBy ,
                                                 AV18OrderedDsc ,
                                                 AV80Udparg1 ,
                                                 A100CompanyId ,
                                                 AV81Udparg2 } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV83Employeewwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Employeewwds_3_filterfulltext), "%", "");
            lV83Employeewwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Employeewwds_3_filterfulltext), "%", "");
            lV83Employeewwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Employeewwds_3_filterfulltext), "%", "");
            lV83Employeewwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Employeewwds_3_filterfulltext), "%", "");
            lV84Employeewwds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV84Employeewwds_4_tfemployeename), 128, "%");
            lV86Employeewwds_6_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV86Employeewwds_6_tfemployeeemail), "%", "");
            /* Using cursor H002V2 */
            pr_default.execute(0, new Object[] {AV80Udparg1, AV81Udparg2, lV83Employeewwds_3_filterfulltext, lV83Employeewwds_3_filterfulltext, lV83Employeewwds_3_filterfulltext, lV83Employeewwds_3_filterfulltext, lV84Employeewwds_4_tfemployeename, AV85Employeewwds_5_tfemployeename_sel, lV86Employeewwds_6_tfemployeeemail, AV87Employeewwds_7_tfemployeeemail_sel, AV90Employeewwds_10_tfemployeevactiondays, AV91Employeewwds_11_tfemployeevactiondays_to, AV92Employeewwds_12_tfemployeebalance, AV93Employeewwds_13_tfemployeebalance_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_41_idx = 1;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A147EmployeeBalance = H002V2_A147EmployeeBalance[0];
               A146EmployeeVactionDays = H002V2_A146EmployeeVactionDays[0];
               A112EmployeeIsActive = H002V2_A112EmployeeIsActive[0];
               A111GAMUserGUID = H002V2_A111GAMUserGUID[0];
               A110EmployeeIsManager = H002V2_A110EmployeeIsManager[0];
               A101CompanyName = H002V2_A101CompanyName[0];
               A100CompanyId = H002V2_A100CompanyId[0];
               A109EmployeeEmail = H002V2_A109EmployeeEmail[0];
               A148EmployeeName = H002V2_A148EmployeeName[0];
               A108EmployeeLastName = H002V2_A108EmployeeLastName[0];
               A107EmployeeFirstName = H002V2_A107EmployeeFirstName[0];
               A106EmployeeId = H002V2_A106EmployeeId[0];
               A101CompanyName = H002V2_A101CompanyName[0];
               E202V2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 41;
            WB2V0( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2V2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV82Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV82Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG14", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV96Udparg14), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG14", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV96Udparg14), "9999999999"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTIDS", AV68ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTIDS", AV68ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTIDS", GetSecureSignedToken( "", AV68ProjectIds, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV60IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV60IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_EMPLOYEEID"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"), context));
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
         AV83Employeewwds_3_filterfulltext = AV20FilterFullText;
         AV84Employeewwds_4_tfemployeename = AV66TFEmployeeName;
         AV85Employeewwds_5_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV86Employeewwds_6_tfemployeeemail = AV37TFEmployeeEmail;
         AV87Employeewwds_7_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV88Employeewwds_8_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV89Employeewwds_9_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV90Employeewwds_10_tfemployeevactiondays = AV47TFEmployeeVactionDays;
         AV91Employeewwds_11_tfemployeevactiondays_to = AV48TFEmployeeVactionDays_To;
         AV92Employeewwds_12_tfemployeebalance = AV49TFEmployeeBalance;
         AV93Employeewwds_13_tfemployeebalance_to = AV50TFEmployeeBalance_To;
         AV80Udparg1 = new userhasrole(context).executeUdp(  "Manager");
         AV81Udparg2 = new getloggedinusercompanyid(context).executeUdp( );
         AV96Udparg14 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV69EmployeeIds ,
                                              AV83Employeewwds_3_filterfulltext ,
                                              AV85Employeewwds_5_tfemployeename_sel ,
                                              AV84Employeewwds_4_tfemployeename ,
                                              AV87Employeewwds_7_tfemployeeemail_sel ,
                                              AV86Employeewwds_6_tfemployeeemail ,
                                              AV88Employeewwds_8_tfemployeeismanager_sel ,
                                              AV89Employeewwds_9_tfemployeeisactive_sel ,
                                              AV90Employeewwds_10_tfemployeevactiondays ,
                                              AV91Employeewwds_11_tfemployeevactiondays_to ,
                                              AV92Employeewwds_12_tfemployeebalance ,
                                              AV93Employeewwds_13_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A146EmployeeVactionDays ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV80Udparg1 ,
                                              A100CompanyId ,
                                              AV81Udparg2 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV83Employeewwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Employeewwds_3_filterfulltext), "%", "");
         lV83Employeewwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Employeewwds_3_filterfulltext), "%", "");
         lV83Employeewwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Employeewwds_3_filterfulltext), "%", "");
         lV83Employeewwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Employeewwds_3_filterfulltext), "%", "");
         lV84Employeewwds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV84Employeewwds_4_tfemployeename), 128, "%");
         lV86Employeewwds_6_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV86Employeewwds_6_tfemployeeemail), "%", "");
         /* Using cursor H002V3 */
         pr_default.execute(1, new Object[] {AV80Udparg1, AV81Udparg2, lV83Employeewwds_3_filterfulltext, lV83Employeewwds_3_filterfulltext, lV83Employeewwds_3_filterfulltext, lV83Employeewwds_3_filterfulltext, lV84Employeewwds_4_tfemployeename, AV85Employeewwds_5_tfemployeename_sel, lV86Employeewwds_6_tfemployeeemail, AV87Employeewwds_7_tfemployeeemail_sel, AV90Employeewwds_10_tfemployeevactiondays, AV91Employeewwds_11_tfemployeevactiondays_to, AV92Employeewwds_12_tfemployeebalance, AV93Employeewwds_13_tfemployeebalance_to});
         GRID_nRecordCount = H002V3_AGRID_nRecordCount[0];
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
         AV83Employeewwds_3_filterfulltext = AV20FilterFullText;
         AV84Employeewwds_4_tfemployeename = AV66TFEmployeeName;
         AV85Employeewwds_5_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV86Employeewwds_6_tfemployeeemail = AV37TFEmployeeEmail;
         AV87Employeewwds_7_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV88Employeewwds_8_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV89Employeewwds_9_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV90Employeewwds_10_tfemployeevactiondays = AV47TFEmployeeVactionDays;
         AV91Employeewwds_11_tfemployeevactiondays_to = AV48TFEmployeeVactionDays_To;
         AV92Employeewwds_12_tfemployeebalance = AV49TFEmployeeBalance;
         AV93Employeewwds_13_tfemployeebalance_to = AV50TFEmployeeBalance_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV82Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, AV47TFEmployeeVactionDays, AV48TFEmployeeVactionDays_To, AV49TFEmployeeBalance, AV50TFEmployeeBalance_To, A166ProjectManagerId, AV96Udparg14, A102ProjectId, AV68ProjectIds, AV17OrderedBy, AV18OrderedDsc, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV83Employeewwds_3_filterfulltext = AV20FilterFullText;
         AV84Employeewwds_4_tfemployeename = AV66TFEmployeeName;
         AV85Employeewwds_5_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV86Employeewwds_6_tfemployeeemail = AV37TFEmployeeEmail;
         AV87Employeewwds_7_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV88Employeewwds_8_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV89Employeewwds_9_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV90Employeewwds_10_tfemployeevactiondays = AV47TFEmployeeVactionDays;
         AV91Employeewwds_11_tfemployeevactiondays_to = AV48TFEmployeeVactionDays_To;
         AV92Employeewwds_12_tfemployeebalance = AV49TFEmployeeBalance;
         AV93Employeewwds_13_tfemployeebalance_to = AV50TFEmployeeBalance_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV82Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, AV47TFEmployeeVactionDays, AV48TFEmployeeVactionDays_To, AV49TFEmployeeBalance, AV50TFEmployeeBalance_To, A166ProjectManagerId, AV96Udparg14, A102ProjectId, AV68ProjectIds, AV17OrderedBy, AV18OrderedDsc, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV83Employeewwds_3_filterfulltext = AV20FilterFullText;
         AV84Employeewwds_4_tfemployeename = AV66TFEmployeeName;
         AV85Employeewwds_5_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV86Employeewwds_6_tfemployeeemail = AV37TFEmployeeEmail;
         AV87Employeewwds_7_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV88Employeewwds_8_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV89Employeewwds_9_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV90Employeewwds_10_tfemployeevactiondays = AV47TFEmployeeVactionDays;
         AV91Employeewwds_11_tfemployeevactiondays_to = AV48TFEmployeeVactionDays_To;
         AV92Employeewwds_12_tfemployeebalance = AV49TFEmployeeBalance;
         AV93Employeewwds_13_tfemployeebalance_to = AV50TFEmployeeBalance_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV82Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, AV47TFEmployeeVactionDays, AV48TFEmployeeVactionDays_To, AV49TFEmployeeBalance, AV50TFEmployeeBalance_To, A166ProjectManagerId, AV96Udparg14, A102ProjectId, AV68ProjectIds, AV17OrderedBy, AV18OrderedDsc, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV83Employeewwds_3_filterfulltext = AV20FilterFullText;
         AV84Employeewwds_4_tfemployeename = AV66TFEmployeeName;
         AV85Employeewwds_5_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV86Employeewwds_6_tfemployeeemail = AV37TFEmployeeEmail;
         AV87Employeewwds_7_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV88Employeewwds_8_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV89Employeewwds_9_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV90Employeewwds_10_tfemployeevactiondays = AV47TFEmployeeVactionDays;
         AV91Employeewwds_11_tfemployeevactiondays_to = AV48TFEmployeeVactionDays_To;
         AV92Employeewwds_12_tfemployeebalance = AV49TFEmployeeBalance;
         AV93Employeewwds_13_tfemployeebalance_to = AV50TFEmployeeBalance_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV82Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, AV47TFEmployeeVactionDays, AV48TFEmployeeVactionDays_To, AV49TFEmployeeBalance, AV50TFEmployeeBalance_To, A166ProjectManagerId, AV96Udparg14, A102ProjectId, AV68ProjectIds, AV17OrderedBy, AV18OrderedDsc, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV83Employeewwds_3_filterfulltext = AV20FilterFullText;
         AV84Employeewwds_4_tfemployeename = AV66TFEmployeeName;
         AV85Employeewwds_5_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV86Employeewwds_6_tfemployeeemail = AV37TFEmployeeEmail;
         AV87Employeewwds_7_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV88Employeewwds_8_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV89Employeewwds_9_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV90Employeewwds_10_tfemployeevactiondays = AV47TFEmployeeVactionDays;
         AV91Employeewwds_11_tfemployeevactiondays_to = AV48TFEmployeeVactionDays_To;
         AV92Employeewwds_12_tfemployeebalance = AV49TFEmployeeBalance;
         AV93Employeewwds_13_tfemployeebalance_to = AV50TFEmployeeBalance_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV82Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, AV47TFEmployeeVactionDays, AV48TFEmployeeVactionDays_To, AV49TFEmployeeBalance, AV50TFEmployeeBalance_To, A166ProjectManagerId, AV96Udparg14, A102ProjectId, AV68ProjectIds, AV17OrderedBy, AV18OrderedDsc, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV82Pgmname = "EmployeeWW";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavInvite_Enabled = 0;
         AssignProp("", false, edtavInvite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInvite_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeFirstName_Enabled = 0;
         AssignProp("", false, edtEmployeeFirstName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeLastName_Enabled = 0;
         AssignProp("", false, edtEmployeeLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeLastName_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeName_Enabled = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeEmail_Enabled = 0;
         AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtCompanyId_Enabled = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtCompanyName_Enabled = 0;
         AssignProp("", false, edtCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyName_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         chkEmployeeIsManager.Enabled = 0;
         AssignProp("", false, chkEmployeeIsManager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsManager.Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtGAMUserGUID_Enabled = 0;
         AssignProp("", false, edtGAMUserGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGAMUserGUID_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         chkEmployeeIsActive.Enabled = 0;
         AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeVactionDays_Enabled = 0;
         AssignProp("", false, edtEmployeeVactionDays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeVactionDays_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeBalance_Enabled = 0;
         AssignProp("", false, edtEmployeeBalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV28ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV63AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV51DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV25ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ".", ","), 18, MidpointRounding.ToEven));
            AV55GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV56GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV9GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV20FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV20FilterFullText", AV20FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV20FilterFullText) != 0 )
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
         E182V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182V2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETEMPLOYEEIDSBYPROJECT' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 20;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV12HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV63AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV64AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV64AGExportDataItem.gxTpr_Title = "Excel";
         AV64AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV64AGExportDataItem.gxTpr_Eventkey = "Export";
         AV64AGExportDataItem.gxTpr_Isdivider = false;
         AV63AGExportData.Add(AV64AGExportDataItem, 0);
         AV52GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV53GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV52GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Employees";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV17OrderedBy < 1 )
         {
            AV17OrderedBy = 1;
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV51DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV51DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         Form.Caption = "Employees";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
      }

      protected void E192V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETEMPLOYEEIDSBYPROJECT' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV30ManageFiltersExecutionStep == 1 )
         {
            AV30ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV30ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV30ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV30ManageFiltersExecutionStep == 2 )
         {
            AV30ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV30ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV30ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV27Session.Get("EmployeeWWColumnsSelector"), "") != 0 )
         {
            AV23ColumnsSelectorXML = AV27Session.Get("EmployeeWWColumnsSelector");
            AV25ColumnsSelector.FromXml(AV23ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtEmployeeName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Visible), 5, 0), !bGXsfl_41_Refreshing);
         chkEmployeeIsManager.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkEmployeeIsManager_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkEmployeeIsManager.Visible), 5, 0), !bGXsfl_41_Refreshing);
         chkEmployeeIsActive.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkEmployeeIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeVactionDays_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeVactionDays_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeVactionDays_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtEmployeeBalance_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeBalance_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Visible), 5, 0), !bGXsfl_41_Refreshing);
         AV55GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV55GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV55GridCurrentPage), 10, 0));
         AV56GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV56GridPageCount", StringUtil.LTrimStr( (decimal)(AV56GridPageCount), 10, 0));
         GXt_char2 = AV9GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV82Pgmname, out  GXt_char2) ;
         AV9GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV9GridAppliedFilters", AV9GridAppliedFilters);
         AV83Employeewwds_3_filterfulltext = AV20FilterFullText;
         AV84Employeewwds_4_tfemployeename = AV66TFEmployeeName;
         AV85Employeewwds_5_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV86Employeewwds_6_tfemployeeemail = AV37TFEmployeeEmail;
         AV87Employeewwds_7_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV88Employeewwds_8_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV89Employeewwds_9_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV90Employeewwds_10_tfemployeevactiondays = AV47TFEmployeeVactionDays;
         AV91Employeewwds_11_tfemployeevactiondays_to = AV48TFEmployeeVactionDays_To;
         AV92Employeewwds_12_tfemployeebalance = AV49TFEmployeeBalance;
         AV93Employeewwds_13_tfemployeebalance_to = AV50TFEmployeeBalance_To;
         AV80Udparg1 = new userhasrole(context).executeUdp(  "Manager");
         AV81Udparg2 = new getloggedinusercompanyid(context).executeUdp( );
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ProjectIds", AV68ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E122V2( )
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
            AV54PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV54PageToGo) ;
         }
      }

      protected void E132V2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E152V2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            AV18OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
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
               AV66TFEmployeeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFEmployeeName", AV66TFEmployeeName);
               AV67TFEmployeeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFEmployeeName_Sel", AV67TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeEmail") == 0 )
            {
               AV37TFEmployeeEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFEmployeeEmail", AV37TFEmployeeEmail);
               AV38TFEmployeeEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFEmployeeEmail_Sel", AV38TFEmployeeEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeIsManager") == 0 )
            {
               AV43TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFEmployeeIsManager_Sel", StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeIsActive") == 0 )
            {
               AV46TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFEmployeeIsActive_Sel", StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeVactionDays") == 0 )
            {
               AV47TFEmployeeVactionDays = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFEmployeeVactionDays", StringUtil.LTrimStr( (decimal)(AV47TFEmployeeVactionDays), 4, 0));
               AV48TFEmployeeVactionDays_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFEmployeeVactionDays_To", StringUtil.LTrimStr( (decimal)(AV48TFEmployeeVactionDays_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeBalance") == 0 )
            {
               AV49TFEmployeeBalance = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV49TFEmployeeBalance", StringUtil.LTrimStr( (decimal)(AV49TFEmployeeBalance), 4, 0));
               AV50TFEmployeeBalance_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFEmployeeBalance_To", StringUtil.LTrimStr( (decimal)(AV50TFEmployeeBalance_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E202V2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV77GamUser.load( A111GAMUserGUID);
         AV78isActive = AV77GamUser.gxTpr_Isactive;
         AV57Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
         if ( AV58IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A106EmployeeId,10,0))}, new string[] {"Mode","EmployeeId"}) ;
         }
         AV59Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV59Delete);
         if ( AV60IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A106EmployeeId,10,0))}, new string[] {"Mode","EmployeeId"}) ;
         }
         AV70Invite = "Invite";
         AssignAttri("", false, edtavInvite_Internalname, AV70Invite);
         if ( ! AV78isActive )
         {
            edtavInvite_Class = "Attribute";
         }
         else
         {
            edtavInvite_Class = "Invisible";
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

      protected void E162V2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV23ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV25ColumnsSelector.FromJSonString(AV23ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "EmployeeWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV23ColumnsSelectorXML)) ? "" : AV25ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ProjectIds", AV68ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E112V2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
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
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("EmployeeWWFilters")),UrlEncode(StringUtil.RTrim(AV82Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV30ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV30ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV30ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("EmployeeWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV30ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV30ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV30ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV29ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "EmployeeWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV29ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV82Pgmname+"GridState",  AV29ManageFiltersXml) ;
               AV15GridState.FromXml(AV29ManageFiltersXml, null, "", "");
               AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
               AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ProjectIds", AV68ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
      }

      protected void E172V2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV65IsAuthorized_Insert )
         {
            CallWebObject(formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","EmployeeId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ProjectIds", AV68ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E142V2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV17OrderedBy), 4, 0))+":"+(AV18OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV25ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeName",  "",  "Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeIsManager",  "",  "Is Manager",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeIsActive",  "",  "Is Active",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeVactionDays",  "",  "Vacation Days",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeBalance",  "",  "Balance",  true,  "") ;
         GXt_char2 = AV24UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "EmployeeWWColumnsSelector", out  GXt_char2) ;
         AV24UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV24UserCustomValue)) ) )
         {
            AV26ColumnsSelectorAux.FromXml(AV24UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV26ColumnsSelectorAux, ref  AV25ColumnsSelector) ;
         }
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV58IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "employee_Update", out  GXt_boolean3) ;
         AV58IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV58IsAuthorized_Update", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         if ( ! ( AV58IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_41_Refreshing);
         }
         GXt_boolean3 = AV60IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "employee_Delete", out  GXt_boolean3) ;
         AV60IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV60IsAuthorized_Delete", AV60IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV60IsAuthorized_Delete, context));
         if ( ! ( AV60IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_41_Refreshing);
         }
         GXt_boolean3 = AV65IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "employee_Insert", out  GXt_boolean3) ;
         AV65IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV65IsAuthorized_Insert", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         if ( ! ( AV65IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV28ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "EmployeeWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV28ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV20FilterFullText = "";
         AssignAttri("", false, "AV20FilterFullText", AV20FilterFullText);
         AV66TFEmployeeName = "";
         AssignAttri("", false, "AV66TFEmployeeName", AV66TFEmployeeName);
         AV67TFEmployeeName_Sel = "";
         AssignAttri("", false, "AV67TFEmployeeName_Sel", AV67TFEmployeeName_Sel);
         AV37TFEmployeeEmail = "";
         AssignAttri("", false, "AV37TFEmployeeEmail", AV37TFEmployeeEmail);
         AV38TFEmployeeEmail_Sel = "";
         AssignAttri("", false, "AV38TFEmployeeEmail_Sel", AV38TFEmployeeEmail_Sel);
         AV43TFEmployeeIsManager_Sel = 0;
         AssignAttri("", false, "AV43TFEmployeeIsManager_Sel", StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0));
         AV46TFEmployeeIsActive_Sel = 0;
         AssignAttri("", false, "AV46TFEmployeeIsActive_Sel", StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0));
         AV47TFEmployeeVactionDays = 0;
         AssignAttri("", false, "AV47TFEmployeeVactionDays", StringUtil.LTrimStr( (decimal)(AV47TFEmployeeVactionDays), 4, 0));
         AV48TFEmployeeVactionDays_To = 0;
         AssignAttri("", false, "AV48TFEmployeeVactionDays_To", StringUtil.LTrimStr( (decimal)(AV48TFEmployeeVactionDays_To), 4, 0));
         AV49TFEmployeeBalance = 0;
         AssignAttri("", false, "AV49TFEmployeeBalance", StringUtil.LTrimStr( (decimal)(AV49TFEmployeeBalance), 4, 0));
         AV50TFEmployeeBalance_To = 0;
         AssignAttri("", false, "AV50TFEmployeeBalance_To", StringUtil.LTrimStr( (decimal)(AV50TFEmployeeBalance_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get(AV82Pgmname+"GridState"), "") == 0 )
         {
            AV15GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV82Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV27Session.Get(AV82Pgmname+"GridState"), null, "", "");
         }
         AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
         AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV15GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV15GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV94GXV1 = 1;
         while ( AV94GXV1 <= AV15GridState.gxTpr_Filtervalues.Count )
         {
            AV16GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV15GridState.gxTpr_Filtervalues.Item(AV94GXV1));
            if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV20FilterFullText = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20FilterFullText", AV20FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV66TFEmployeeName = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFEmployeeName", AV66TFEmployeeName);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV67TFEmployeeName_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFEmployeeName_Sel", AV67TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV37TFEmployeeEmail = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFEmployeeEmail", AV37TFEmployeeEmail);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV38TFEmployeeEmail_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFEmployeeEmail_Sel", AV38TFEmployeeEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV43TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFEmployeeIsManager_Sel", StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV46TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFEmployeeIsActive_Sel", StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEVACTIONDAYS") == 0 )
            {
               AV47TFEmployeeVactionDays = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFEmployeeVactionDays", StringUtil.LTrimStr( (decimal)(AV47TFEmployeeVactionDays), 4, 0));
               AV48TFEmployeeVactionDays_To = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFEmployeeVactionDays_To", StringUtil.LTrimStr( (decimal)(AV48TFEmployeeVactionDays_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEBALANCE") == 0 )
            {
               AV49TFEmployeeBalance = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV49TFEmployeeBalance", StringUtil.LTrimStr( (decimal)(AV49TFEmployeeBalance), 4, 0));
               AV50TFEmployeeBalance_To = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFEmployeeBalance_To", StringUtil.LTrimStr( (decimal)(AV50TFEmployeeBalance_To), 4, 0));
            }
            AV94GXV1 = (int)(AV94GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFEmployeeName_Sel)),  AV67TFEmployeeName_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmployeeEmail_Sel)),  AV38TFEmployeeEmail_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char5+"|"+((0==AV43TFEmployeeIsManager_Sel) ? "" : StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0))+"|"+((0==AV46TFEmployeeIsActive_Sel) ? "" : StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFEmployeeName)),  AV66TFEmployeeName, out  GXt_char5) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEmployeeEmail)),  AV37TFEmployeeEmail, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char2+"|||"+((0==AV47TFEmployeeVactionDays) ? "" : StringUtil.Str( (decimal)(AV47TFEmployeeVactionDays), 4, 0))+"|"+((0==AV49TFEmployeeBalance) ? "" : StringUtil.Str( (decimal)(AV49TFEmployeeBalance), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||||"+((0==AV48TFEmployeeVactionDays_To) ? "" : StringUtil.Str( (decimal)(AV48TFEmployeeVactionDays_To), 4, 0))+"|"+((0==AV50TFEmployeeBalance_To) ? "" : StringUtil.Str( (decimal)(AV50TFEmployeeBalance_To), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV15GridState.FromXml(AV27Session.Get(AV82Pgmname+"GridState"), null, "", "");
         AV15GridState.gxTpr_Orderedby = AV17OrderedBy;
         AV15GridState.gxTpr_Ordereddsc = AV18OrderedDsc;
         AV15GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20FilterFullText)),  0,  AV20FilterFullText,  AV20FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFEMPLOYEENAME",  "Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFEmployeeName)),  0,  AV66TFEmployeeName,  AV66TFEmployeeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFEmployeeName_Sel)),  AV67TFEmployeeName_Sel,  AV67TFEmployeeName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFEMPLOYEEEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEmployeeEmail)),  0,  AV37TFEmployeeEmail,  AV37TFEmployeeEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmployeeEmail_Sel)),  AV38TFEmployeeEmail_Sel,  AV38TFEmployeeEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFEMPLOYEEISMANAGER_SEL",  "Is Manager",  !(0==AV43TFEmployeeIsManager_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0)),  ((AV43TFEmployeeIsManager_Sel==1) ? "Checked" : "Unchecked"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFEMPLOYEEISACTIVE_SEL",  "Is Active",  !(0==AV46TFEmployeeIsActive_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0)),  ((AV46TFEmployeeIsActive_Sel==1) ? "Checked" : "Unchecked"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFEMPLOYEEVACTIONDAYS",  "Vacation Days",  !((0==AV47TFEmployeeVactionDays)&&(0==AV48TFEmployeeVactionDays_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFEmployeeVactionDays), 4, 0)),  ((0==AV47TFEmployeeVactionDays) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV47TFEmployeeVactionDays), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFEmployeeVactionDays_To), 4, 0)),  ((0==AV48TFEmployeeVactionDays_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV48TFEmployeeVactionDays_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFEMPLOYEEBALANCE",  "Balance",  !((0==AV49TFEmployeeBalance)&&(0==AV50TFEmployeeBalance_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV49TFEmployeeBalance), 4, 0)),  ((0==AV49TFEmployeeBalance) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV49TFEmployeeBalance), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFEmployeeBalance_To), 4, 0)),  ((0==AV50TFEmployeeBalance_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV50TFEmployeeBalance_To), "ZZZ9")))) ;
         AV15GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV15GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV82Pgmname+"GridState",  AV15GridState.ToXml(false, true, "", "")) ;
      }

      protected void S132( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13TrnContext.gxTpr_Callerobject = AV82Pgmname;
         AV13TrnContext.gxTpr_Callerondelete = true;
         AV13TrnContext.gxTpr_Callerurl = AV12HTTPRequest.ScriptName+"?"+AV12HTTPRequest.QueryString;
         AV13TrnContext.gxTpr_Transactionname = "Employee";
         AV27Session.Set("TrnContext", AV13TrnContext.ToXml(false, true, "", ""));
      }

      protected void S212( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new employeewwexport(context ).execute( out  AV21ExcelFilename, out  AV22ErrorMessage) ;
         if ( StringUtil.StrCmp(AV21ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV21ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV22ErrorMessage);
         }
      }

      protected void E212V2( )
      {
         /* Invite_Click Routine */
         returnInSub = false;
         new sendwelcomeemail(context ).execute(  A106EmployeeId,  "", out  AV79successMessage) ;
         GX_msglist.addItem(AV79successMessage);
      }

      protected void S112( )
      {
         /* 'GETEMPLOYEEIDSBYPROJECT' Routine */
         returnInSub = false;
         AV96Udparg14 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor H002V4 */
         pr_default.execute(2, new Object[] {AV96Udparg14});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A166ProjectManagerId = H002V4_A166ProjectManagerId[0];
            n166ProjectManagerId = H002V4_n166ProjectManagerId[0];
            A102ProjectId = H002V4_A102ProjectId[0];
            AV68ProjectIds.Add(A102ProjectId, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         GXt_objcol_int6 = AV69EmployeeIds;
         new getemployeeidsbyproject(context ).execute(  AV68ProjectIds, out  GXt_objcol_int6) ;
         AV69EmployeeIds = GXt_objcol_int6;
      }

      protected void wb_table1_23_2V2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV28ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_28_2V2( true) ;
         }
         else
         {
            wb_table2_28_2V2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_2V2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_2V2e( true) ;
         }
         else
         {
            wb_table1_23_2V2e( false) ;
         }
      }

      protected void wb_table2_28_2V2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV20FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV20FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_EmployeeWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_2V2e( true) ;
         }
         else
         {
            wb_table2_28_2V2e( false) ;
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
         PA2V2( ) ;
         WS2V2( ) ;
         WE2V2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20246211020059", true, true);
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
         context.AddJavascriptSource("employeeww.js", "?20246211020061", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_412( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_41_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_41_idx;
         edtavInvite_Internalname = "vINVITE_"+sGXsfl_41_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_41_idx;
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME_"+sGXsfl_41_idx;
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME_"+sGXsfl_41_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_41_idx;
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL_"+sGXsfl_41_idx;
         edtCompanyId_Internalname = "COMPANYID_"+sGXsfl_41_idx;
         edtCompanyName_Internalname = "COMPANYNAME_"+sGXsfl_41_idx;
         chkEmployeeIsManager_Internalname = "EMPLOYEEISMANAGER_"+sGXsfl_41_idx;
         edtGAMUserGUID_Internalname = "GAMUSERGUID_"+sGXsfl_41_idx;
         chkEmployeeIsActive_Internalname = "EMPLOYEEISACTIVE_"+sGXsfl_41_idx;
         edtEmployeeVactionDays_Internalname = "EMPLOYEEVACTIONDAYS_"+sGXsfl_41_idx;
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_41_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_41_fel_idx;
         edtavInvite_Internalname = "vINVITE_"+sGXsfl_41_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_41_fel_idx;
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME_"+sGXsfl_41_fel_idx;
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME_"+sGXsfl_41_fel_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_41_fel_idx;
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL_"+sGXsfl_41_fel_idx;
         edtCompanyId_Internalname = "COMPANYID_"+sGXsfl_41_fel_idx;
         edtCompanyName_Internalname = "COMPANYNAME_"+sGXsfl_41_fel_idx;
         chkEmployeeIsManager_Internalname = "EMPLOYEEISMANAGER_"+sGXsfl_41_fel_idx;
         edtGAMUserGUID_Internalname = "GAMUSERGUID_"+sGXsfl_41_fel_idx;
         chkEmployeeIsActive_Internalname = "EMPLOYEEISACTIVE_"+sGXsfl_41_fel_idx;
         edtEmployeeVactionDays_Internalname = "EMPLOYEEVACTIONDAYS_"+sGXsfl_41_fel_idx;
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         SubsflControlProps_412( ) ;
         WB2V0( ) ;
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
            TempTags = " " + ((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 42,'',false,'"+sGXsfl_41_idx+"',41)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV57Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,42);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 43,'',false,'"+sGXsfl_41_idx+"',41)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV59Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,43);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavInvite_Enabled!=0)&&(edtavInvite_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 44,'',false,'"+sGXsfl_41_idx+"',41)\"" : " ");
            ROClassString = edtavInvite_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavInvite_Internalname,StringUtil.RTrim( AV70Invite),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavInvite_Enabled!=0)&&(edtavInvite_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,44);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVINVITE.CLICK."+sGXsfl_41_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavInvite_Jsonclick,(short)5,(string)edtavInvite_Class,(string)"",(string)ROClassString,(string)"WWActionColumn",(string)"",(short)-1,(int)edtavInvite_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeFirstName_Internalname,StringUtil.RTrim( A107EmployeeFirstName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeFirstName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeLastName_Internalname,StringUtil.RTrim( A108EmployeeLastName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtEmployeeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)128,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEmployeeEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeEmail_Internalname,(string)A109EmployeeEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A109EmployeeEmail,(string)"",(string)"",(string)"",(string)edtEmployeeEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEmployeeEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCompanyId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCompanyId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCompanyName_Internalname,StringUtil.RTrim( A101CompanyName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkEmployeeIsManager.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "EMPLOYEEISMANAGER_" + sGXsfl_41_idx;
            chkEmployeeIsManager.Name = GXCCtl;
            chkEmployeeIsManager.WebTags = "";
            chkEmployeeIsManager.Caption = "";
            AssignProp("", false, chkEmployeeIsManager_Internalname, "TitleCaption", chkEmployeeIsManager.Caption, !bGXsfl_41_Refreshing);
            chkEmployeeIsManager.CheckedValue = "false";
            A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkEmployeeIsManager_Internalname,StringUtil.BoolToStr( A110EmployeeIsManager),(string)"",(string)"",chkEmployeeIsManager.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtGAMUserGUID_Internalname,(string)A111GAMUserGUID,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtGAMUserGUID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkEmployeeIsActive.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "EMPLOYEEISACTIVE_" + sGXsfl_41_idx;
            chkEmployeeIsActive.Name = GXCCtl;
            chkEmployeeIsActive.WebTags = "";
            chkEmployeeIsActive.Caption = "";
            AssignProp("", false, chkEmployeeIsActive_Internalname, "TitleCaption", chkEmployeeIsActive.Caption, !bGXsfl_41_Refreshing);
            chkEmployeeIsActive.CheckedValue = "false";
            A112EmployeeIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A112EmployeeIsActive));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkEmployeeIsActive_Internalname,StringUtil.BoolToStr( A112EmployeeIsActive),(string)"",(string)"",chkEmployeeIsActive.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtEmployeeVactionDays_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeVactionDays_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A146EmployeeVactionDays), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A146EmployeeVactionDays), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeVactionDays_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEmployeeVactionDays_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtEmployeeBalance_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeBalance_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A147EmployeeBalance), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A147EmployeeBalance), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeBalance_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEmployeeBalance_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes2V2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "EMPLOYEEISMANAGER_" + sGXsfl_41_idx;
         chkEmployeeIsManager.Name = GXCCtl;
         chkEmployeeIsManager.WebTags = "";
         chkEmployeeIsManager.Caption = "";
         AssignProp("", false, chkEmployeeIsManager_Internalname, "TitleCaption", chkEmployeeIsManager.Caption, !bGXsfl_41_Refreshing);
         chkEmployeeIsManager.CheckedValue = "false";
         A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
         GXCCtl = "EMPLOYEEISACTIVE_" + sGXsfl_41_idx;
         chkEmployeeIsActive.Name = GXCCtl;
         chkEmployeeIsActive.WebTags = "";
         chkEmployeeIsActive.Caption = "";
         AssignProp("", false, chkEmployeeIsActive_Internalname, "TitleCaption", chkEmployeeIsActive.Caption, !bGXsfl_41_Refreshing);
         chkEmployeeIsActive.CheckedValue = "false";
         A112EmployeeIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A112EmployeeIsActive));
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavInvite_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+((chkEmployeeIsManager.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Is Manager") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+((chkEmployeeIsActive.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Is Active") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeVactionDays_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Vacation Days") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeBalance_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Balance") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV57Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV59Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV70Invite)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavInvite_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavInvite_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EmployeeFirstName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A108EmployeeLastName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A109EmployeeEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A101CompanyName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A110EmployeeIsManager)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEmployeeIsManager.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A111GAMUserGUID));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A112EmployeeIsActive)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEmployeeIsActive.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A146EmployeeVactionDays), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeVactionDays_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A147EmployeeBalance), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeBalance_Visible), 5, 0, ".", "")));
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
         edtavInvite_Internalname = "vINVITE";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME";
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL";
         edtCompanyId_Internalname = "COMPANYID";
         edtCompanyName_Internalname = "COMPANYNAME";
         chkEmployeeIsManager_Internalname = "EMPLOYEEISMANAGER";
         edtGAMUserGUID_Internalname = "GAMUSERGUID";
         chkEmployeeIsActive_Internalname = "EMPLOYEEISACTIVE";
         edtEmployeeVactionDays_Internalname = "EMPLOYEEVACTIONDAYS";
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         edtEmployeeBalance_Jsonclick = "";
         edtEmployeeVactionDays_Jsonclick = "";
         chkEmployeeIsActive.Caption = "";
         edtGAMUserGUID_Jsonclick = "";
         chkEmployeeIsManager.Caption = "";
         edtCompanyName_Jsonclick = "";
         edtCompanyId_Jsonclick = "";
         edtEmployeeEmail_Jsonclick = "";
         edtEmployeeName_Jsonclick = "";
         edtEmployeeLastName_Jsonclick = "";
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtavInvite_Jsonclick = "";
         edtavInvite_Class = "Attribute";
         edtavInvite_Visible = -1;
         edtavInvite_Enabled = 1;
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtEmployeeBalance_Visible = -1;
         edtEmployeeVactionDays_Visible = -1;
         chkEmployeeIsActive.Visible = -1;
         chkEmployeeIsManager.Visible = -1;
         edtEmployeeEmail_Visible = -1;
         edtEmployeeName_Visible = -1;
         edtEmployeeBalance_Enabled = 0;
         edtEmployeeVactionDays_Enabled = 0;
         chkEmployeeIsActive.Enabled = 0;
         edtGAMUserGUID_Enabled = 0;
         chkEmployeeIsManager.Enabled = 0;
         edtCompanyName_Enabled = 0;
         edtCompanyId_Enabled = 0;
         edtEmployeeEmail_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtEmployeeLastName_Enabled = 0;
         edtEmployeeFirstName_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         subGrid_Sortable = 0;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;L;;;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "||||4.0|4.0";
         Ddo_grid_Datalistproc = "EmployeeWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked||";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues|FixedValues||";
         Ddo_grid_Includedatalist = "T|T|T|T||";
         Ddo_grid_Filterisrange = "||||T|T";
         Ddo_grid_Filtertype = "Character|Character|||Numeric|Numeric";
         Ddo_grid_Includefilter = "T|T|||T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7";
         Ddo_grid_Columnids = "6:EmployeeName|7:EmployeeEmail|10:EmployeeIsManager|12:EmployeeIsActive|13:EmployeeVactionDays|14:EmployeeBalance";
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
         Form.Caption = " Employees";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV96Udparg14',fld:'vUDPARG14',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtEmployeeEmail_Visible',ctrl:'EMPLOYEEEMAIL',prop:'Visible'},{av:'chkEmployeeIsManager.Visible',ctrl:'EMPLOYEEISMANAGER',prop:'Visible'},{av:'chkEmployeeIsActive.Visible',ctrl:'EMPLOYEEISACTIVE',prop:'Visible'},{av:'edtEmployeeVactionDays_Visible',ctrl:'EMPLOYEEVACTIONDAYS',prop:'Visible'},{av:'edtEmployeeBalance_Visible',ctrl:'EMPLOYEEBALANCE',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV9GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV28ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV15GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E122V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV96Udparg14',fld:'vUDPARG14',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E132V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV96Udparg14',fld:'vUDPARG14',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E152V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV96Udparg14',fld:'vUDPARG14',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E202V2',iparms:[{av:'A111GAMUserGUID',fld:'GAMUSERGUID',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV57Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV59Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'AV70Invite',fld:'vINVITE',pic:''},{av:'edtavInvite_Class',ctrl:'vINVITE',prop:'Class'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E162V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV96Udparg14',fld:'vUDPARG14',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtEmployeeEmail_Visible',ctrl:'EMPLOYEEEMAIL',prop:'Visible'},{av:'chkEmployeeIsManager.Visible',ctrl:'EMPLOYEEISMANAGER',prop:'Visible'},{av:'chkEmployeeIsActive.Visible',ctrl:'EMPLOYEEISACTIVE',prop:'Visible'},{av:'edtEmployeeVactionDays_Visible',ctrl:'EMPLOYEEVACTIONDAYS',prop:'Visible'},{av:'edtEmployeeBalance_Visible',ctrl:'EMPLOYEEBALANCE',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV9GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV28ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV15GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E112V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV96Udparg14',fld:'vUDPARG14',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV15GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV15GridState',fld:'vGRIDSTATE',pic:''},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtEmployeeEmail_Visible',ctrl:'EMPLOYEEEMAIL',prop:'Visible'},{av:'chkEmployeeIsManager.Visible',ctrl:'EMPLOYEEISMANAGER',prop:'Visible'},{av:'chkEmployeeIsActive.Visible',ctrl:'EMPLOYEEISACTIVE',prop:'Visible'},{av:'edtEmployeeVactionDays_Visible',ctrl:'EMPLOYEEVACTIONDAYS',prop:'Visible'},{av:'edtEmployeeBalance_Visible',ctrl:'EMPLOYEEBALANCE',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV9GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV28ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E172V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV96Udparg14',fld:'vUDPARG14',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtEmployeeEmail_Visible',ctrl:'EMPLOYEEEMAIL',prop:'Visible'},{av:'chkEmployeeIsManager.Visible',ctrl:'EMPLOYEEISMANAGER',prop:'Visible'},{av:'chkEmployeeIsActive.Visible',ctrl:'EMPLOYEEISACTIVE',prop:'Visible'},{av:'edtEmployeeVactionDays_Visible',ctrl:'EMPLOYEEVACTIONDAYS',prop:'Visible'},{av:'edtEmployeeBalance_Visible',ctrl:'EMPLOYEEBALANCE',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV9GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV28ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV15GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E142V2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV15GridState',fld:'vGRIDSTATE',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'AV15GridState',fld:'vGRIDSTATE',pic:''},{av:'AV17OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV20FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV30ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV25ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV82Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV66TFEmployeeName',fld:'vTFEMPLOYEENAME',pic:''},{av:'AV67TFEmployeeName_Sel',fld:'vTFEMPLOYEENAME_SEL',pic:''},{av:'AV37TFEmployeeEmail',fld:'vTFEMPLOYEEEMAIL',pic:''},{av:'AV38TFEmployeeEmail_Sel',fld:'vTFEMPLOYEEEMAIL_SEL',pic:''},{av:'AV43TFEmployeeIsManager_Sel',fld:'vTFEMPLOYEEISMANAGER_SEL',pic:'9'},{av:'AV46TFEmployeeIsActive_Sel',fld:'vTFEMPLOYEEISACTIVE_SEL',pic:'9'},{av:'AV47TFEmployeeVactionDays',fld:'vTFEMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'AV48TFEmployeeVactionDays_To',fld:'vTFEMPLOYEEVACTIONDAYS_TO',pic:'ZZZ9'},{av:'AV49TFEmployeeBalance',fld:'vTFEMPLOYEEBALANCE',pic:'ZZZ9'},{av:'AV50TFEmployeeBalance_To',fld:'vTFEMPLOYEEBALANCE_TO',pic:'ZZZ9'},{av:'A166ProjectManagerId',fld:'PROJECTMANAGERID',pic:'ZZZZZZZZZ9'},{av:'AV96Udparg14',fld:'vUDPARG14',pic:'9999999999',hsh:true},{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'AV68ProjectIds',fld:'vPROJECTIDS',pic:'',hsh:true},{av:'AV58IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV60IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("VINVITE.CLICK","{handler:'E212V2',iparms:[{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("VINVITE.CLICK",",oparms:[]}");
         setEventMetadata("VALID_COMPANYID","{handler:'Valid_Companyid',iparms:[]");
         setEventMetadata("VALID_COMPANYID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Employeebalance',iparms:[]");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV20FilterFullText = "";
         AV25ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV82Pgmname = "";
         AV66TFEmployeeName = "";
         AV67TFEmployeeName_Sel = "";
         AV37TFEmployeeEmail = "";
         AV38TFEmployeeEmail_Sel = "";
         AV68ProjectIds = new GxSimpleCollection<long>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV28ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV9GridAppliedFilters = "";
         AV63AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV57Update = "";
         AV59Delete = "";
         AV70Invite = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         A111GAMUserGUID = "";
         scmdbuf = "";
         lV83Employeewwds_3_filterfulltext = "";
         lV84Employeewwds_4_tfemployeename = "";
         lV86Employeewwds_6_tfemployeeemail = "";
         AV69EmployeeIds = new GxSimpleCollection<long>();
         AV83Employeewwds_3_filterfulltext = "";
         AV85Employeewwds_5_tfemployeename_sel = "";
         AV84Employeewwds_4_tfemployeename = "";
         AV87Employeewwds_7_tfemployeeemail_sel = "";
         AV86Employeewwds_6_tfemployeeemail = "";
         H002V2_A147EmployeeBalance = new short[1] ;
         H002V2_A146EmployeeVactionDays = new short[1] ;
         H002V2_A112EmployeeIsActive = new bool[] {false} ;
         H002V2_A111GAMUserGUID = new string[] {""} ;
         H002V2_A110EmployeeIsManager = new bool[] {false} ;
         H002V2_A101CompanyName = new string[] {""} ;
         H002V2_A100CompanyId = new long[1] ;
         H002V2_A109EmployeeEmail = new string[] {""} ;
         H002V2_A148EmployeeName = new string[] {""} ;
         H002V2_A108EmployeeLastName = new string[] {""} ;
         H002V2_A107EmployeeFirstName = new string[] {""} ;
         H002V2_A106EmployeeId = new long[1] ;
         H002V3_AGRID_nRecordCount = new long[1] ;
         AV12HTTPRequest = new GxHttpRequest( context);
         AV64AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV52GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV53GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV23ColumnsSelectorXML = "";
         AV77GamUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GridRow = new GXWebRow();
         AV29ManageFiltersXml = "";
         AV24UserCustomValue = "";
         AV26ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char2 = "";
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV21ExcelFilename = "";
         AV22ErrorMessage = "";
         AV79successMessage = "";
         H002V4_A166ProjectManagerId = new long[1] ;
         H002V4_n166ProjectManagerId = new bool[] {false} ;
         H002V4_A102ProjectId = new long[1] ;
         GXt_objcol_int6 = new GxSimpleCollection<long>();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeww__default(),
            new Object[][] {
                new Object[] {
               H002V2_A147EmployeeBalance, H002V2_A146EmployeeVactionDays, H002V2_A112EmployeeIsActive, H002V2_A111GAMUserGUID, H002V2_A110EmployeeIsManager, H002V2_A101CompanyName, H002V2_A100CompanyId, H002V2_A109EmployeeEmail, H002V2_A148EmployeeName, H002V2_A108EmployeeLastName,
               H002V2_A107EmployeeFirstName, H002V2_A106EmployeeId
               }
               , new Object[] {
               H002V3_AGRID_nRecordCount
               }
               , new Object[] {
               H002V4_A166ProjectManagerId, H002V4_n166ProjectManagerId, H002V4_A102ProjectId
               }
            }
         );
         AV82Pgmname = "EmployeeWW";
         /* GeneXus formulas. */
         AV82Pgmname = "EmployeeWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavInvite_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV30ManageFiltersExecutionStep ;
      private short AV43TFEmployeeIsManager_Sel ;
      private short AV46TFEmployeeIsActive_Sel ;
      private short AV47TFEmployeeVactionDays ;
      private short AV48TFEmployeeVactionDays_To ;
      private short AV49TFEmployeeBalance ;
      private short AV50TFEmployeeBalance_To ;
      private short AV17OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A146EmployeeVactionDays ;
      private short A147EmployeeBalance ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV88Employeewwds_8_tfemployeeismanager_sel ;
      private short AV89Employeewwds_9_tfemployeeisactive_sel ;
      private short AV90Employeewwds_10_tfemployeevactiondays ;
      private short AV91Employeewwds_11_tfemployeevactiondays_to ;
      private short AV92Employeewwds_12_tfemployeebalance ;
      private short AV93Employeewwds_13_tfemployeebalance_to ;
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
      private int edtavInvite_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtEmployeeLastName_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int edtEmployeeEmail_Enabled ;
      private int edtCompanyId_Enabled ;
      private int edtCompanyName_Enabled ;
      private int edtGAMUserGUID_Enabled ;
      private int edtEmployeeVactionDays_Enabled ;
      private int edtEmployeeBalance_Enabled ;
      private int edtEmployeeName_Visible ;
      private int edtEmployeeEmail_Visible ;
      private int edtEmployeeVactionDays_Visible ;
      private int edtEmployeeBalance_Visible ;
      private int AV54PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV94GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavInvite_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A166ProjectManagerId ;
      private long AV96Udparg14 ;
      private long A102ProjectId ;
      private long AV55GridCurrentPage ;
      private long AV56GridPageCount ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long GRID_nCurrentRecord ;
      private long AV81Udparg2 ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_41_idx="0001" ;
      private string AV82Pgmname ;
      private string AV66TFEmployeeName ;
      private string AV67TFEmployeeName_Sel ;
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
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV57Update ;
      private string edtavUpdate_Internalname ;
      private string AV59Delete ;
      private string edtavDelete_Internalname ;
      private string AV70Invite ;
      private string edtavInvite_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string A107EmployeeFirstName ;
      private string edtEmployeeFirstName_Internalname ;
      private string A108EmployeeLastName ;
      private string edtEmployeeLastName_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Internalname ;
      private string edtEmployeeEmail_Internalname ;
      private string edtCompanyId_Internalname ;
      private string A101CompanyName ;
      private string edtCompanyName_Internalname ;
      private string chkEmployeeIsManager_Internalname ;
      private string edtGAMUserGUID_Internalname ;
      private string chkEmployeeIsActive_Internalname ;
      private string edtEmployeeVactionDays_Internalname ;
      private string edtEmployeeBalance_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string lV84Employeewwds_4_tfemployeename ;
      private string AV85Employeewwds_5_tfemployeename_sel ;
      private string AV84Employeewwds_4_tfemployeename ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtavInvite_Class ;
      private string GXt_char5 ;
      private string GXt_char2 ;
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
      private string edtavInvite_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtEmployeeLastName_Jsonclick ;
      private string edtEmployeeName_Jsonclick ;
      private string edtEmployeeEmail_Jsonclick ;
      private string edtCompanyId_Jsonclick ;
      private string edtCompanyName_Jsonclick ;
      private string GXCCtl ;
      private string edtGAMUserGUID_Jsonclick ;
      private string edtEmployeeVactionDays_Jsonclick ;
      private string edtEmployeeBalance_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n166ProjectManagerId ;
      private bool AV18OrderedDsc ;
      private bool AV58IsAuthorized_Update ;
      private bool AV60IsAuthorized_Delete ;
      private bool AV65IsAuthorized_Insert ;
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
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool bGXsfl_41_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV80Udparg1 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV78isActive ;
      private bool GXt_boolean3 ;
      private string AV23ColumnsSelectorXML ;
      private string AV29ManageFiltersXml ;
      private string AV24UserCustomValue ;
      private string AV20FilterFullText ;
      private string AV37TFEmployeeEmail ;
      private string AV38TFEmployeeEmail_Sel ;
      private string AV9GridAppliedFilters ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private string lV83Employeewwds_3_filterfulltext ;
      private string lV86Employeewwds_6_tfemployeeemail ;
      private string AV83Employeewwds_3_filterfulltext ;
      private string AV87Employeewwds_7_tfemployeeemail_sel ;
      private string AV86Employeewwds_6_tfemployeeemail ;
      private string AV21ExcelFilename ;
      private string AV22ErrorMessage ;
      private string AV79successMessage ;
      private GxSimpleCollection<long> AV68ProjectIds ;
      private GxSimpleCollection<long> AV69EmployeeIds ;
      private GxSimpleCollection<long> GXt_objcol_int6 ;
      private IGxSession AV27Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkEmployeeIsManager ;
      private GXCheckbox chkEmployeeIsActive ;
      private IDataStoreProvider pr_default ;
      private short[] H002V2_A147EmployeeBalance ;
      private short[] H002V2_A146EmployeeVactionDays ;
      private bool[] H002V2_A112EmployeeIsActive ;
      private string[] H002V2_A111GAMUserGUID ;
      private bool[] H002V2_A110EmployeeIsManager ;
      private string[] H002V2_A101CompanyName ;
      private long[] H002V2_A100CompanyId ;
      private string[] H002V2_A109EmployeeEmail ;
      private string[] H002V2_A148EmployeeName ;
      private string[] H002V2_A108EmployeeLastName ;
      private string[] H002V2_A107EmployeeFirstName ;
      private long[] H002V2_A106EmployeeId ;
      private long[] H002V3_AGRID_nRecordCount ;
      private long[] H002V4_A166ProjectManagerId ;
      private bool[] H002V4_n166ProjectManagerId ;
      private long[] H002V4_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV12HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV28ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV63AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV53GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV15GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV16GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV26ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV64AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV51DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV52GAMSession ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV77GamUser ;
   }

   public class employeeww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002V2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV69EmployeeIds ,
                                             string AV83Employeewwds_3_filterfulltext ,
                                             string AV85Employeewwds_5_tfemployeename_sel ,
                                             string AV84Employeewwds_4_tfemployeename ,
                                             string AV87Employeewwds_7_tfemployeeemail_sel ,
                                             string AV86Employeewwds_6_tfemployeeemail ,
                                             short AV88Employeewwds_8_tfemployeeismanager_sel ,
                                             short AV89Employeewwds_9_tfemployeeisactive_sel ,
                                             short AV90Employeewwds_10_tfemployeevactiondays ,
                                             short AV91Employeewwds_11_tfemployeevactiondays_to ,
                                             short AV92Employeewwds_12_tfemployeebalance ,
                                             short AV93Employeewwds_13_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             short A146EmployeeVactionDays ,
                                             short A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool AV80Udparg1 ,
                                             long A100CompanyId ,
                                             long AV81Udparg2 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[17];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.EmployeeBalance, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeLastName, T1.EmployeeFirstName, T1.EmployeeId";
         sFromString = " FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         sOrderString = "";
         AddWhere(sWhereString, "(Not ( :AV80Udparg1) or ( T1.CompanyId = :AV81Udparg2))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Employeewwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.EmployeeName) like '%' || LOWER(:lV83Employeewwds_3_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV83Employeewwds_3_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'9999'), 2) like '%' || :lV83Employeewwds_3_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'9999'), 2) like '%' || :lV83Employeewwds_3_filterfulltext))");
         }
         else
         {
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Employeewwds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Employeewwds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.EmployeeName) like LOWER(:lV84Employeewwds_4_tfemployeename))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Employeewwds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV85Employeewwds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV85Employeewwds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV85Employeewwds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Employeewwds_7_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Employeewwds_6_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.EmployeeEmail) like LOWER(:lV86Employeewwds_6_tfemployeeemail))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Employeewwds_7_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV87Employeewwds_7_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV87Employeewwds_7_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV87Employeewwds_7_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( AV88Employeewwds_8_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV88Employeewwds_8_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( AV89Employeewwds_9_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV89Employeewwds_9_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (0==AV90Employeewwds_10_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV90Employeewwds_10_tfemployeevactiondays)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (0==AV91Employeewwds_11_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV91Employeewwds_11_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (0==AV92Employeewwds_12_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV92Employeewwds_12_tfemployeebalance)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (0==AV93Employeewwds_13_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV93Employeewwds_13_tfemployeebalance_to)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV17OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.EmployeeFirstName, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeName, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeName DESC, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeEmail";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeEmail DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeIsManager, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeIsManager DESC, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeIsActive, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeIsActive DESC, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeVactionDays, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeVactionDays DESC, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeBalance, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeBalance DESC, T1.EmployeeId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.EmployeeId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H002V3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV69EmployeeIds ,
                                             string AV83Employeewwds_3_filterfulltext ,
                                             string AV85Employeewwds_5_tfemployeename_sel ,
                                             string AV84Employeewwds_4_tfemployeename ,
                                             string AV87Employeewwds_7_tfemployeeemail_sel ,
                                             string AV86Employeewwds_6_tfemployeeemail ,
                                             short AV88Employeewwds_8_tfemployeeismanager_sel ,
                                             short AV89Employeewwds_9_tfemployeeisactive_sel ,
                                             short AV90Employeewwds_10_tfemployeevactiondays ,
                                             short AV91Employeewwds_11_tfemployeevactiondays_to ,
                                             short AV92Employeewwds_12_tfemployeebalance ,
                                             short AV93Employeewwds_13_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             short A146EmployeeVactionDays ,
                                             short A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool AV80Udparg1 ,
                                             long A100CompanyId ,
                                             long AV81Udparg2 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[14];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "(Not ( :AV80Udparg1) or ( T1.CompanyId = :AV81Udparg2))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Employeewwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.EmployeeName) like '%' || LOWER(:lV83Employeewwds_3_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV83Employeewwds_3_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'9999'), 2) like '%' || :lV83Employeewwds_3_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'9999'), 2) like '%' || :lV83Employeewwds_3_filterfulltext))");
         }
         else
         {
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Employeewwds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Employeewwds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.EmployeeName) like LOWER(:lV84Employeewwds_4_tfemployeename))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Employeewwds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV85Employeewwds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV85Employeewwds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV85Employeewwds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Employeewwds_7_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Employeewwds_6_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.EmployeeEmail) like LOWER(:lV86Employeewwds_6_tfemployeeemail))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Employeewwds_7_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV87Employeewwds_7_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV87Employeewwds_7_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV87Employeewwds_7_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( AV88Employeewwds_8_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV88Employeewwds_8_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( AV89Employeewwds_9_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV89Employeewwds_9_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (0==AV90Employeewwds_10_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV90Employeewwds_10_tfemployeevactiondays)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (0==AV91Employeewwds_11_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV91Employeewwds_11_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (0==AV92Employeewwds_12_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV92Employeewwds_12_tfemployeebalance)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (0==AV93Employeewwds_13_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV93Employeewwds_13_tfemployeebalance_to)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
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
                     return conditional_H002V2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] , (bool)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
               case 1 :
                     return conditional_H002V3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] , (bool)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002V4;
          prmH002V4 = new Object[] {
          new ParDef("AV96Udparg14",GXType.Int64,10,0)
          };
          Object[] prmH002V2;
          prmH002V2 = new Object[] {
          new ParDef("AV80Udparg1",GXType.Boolean,4,0) ,
          new ParDef("AV81Udparg2",GXType.Int64,10,0) ,
          new ParDef("lV83Employeewwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Employeewwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Employeewwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Employeewwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Employeewwds_4_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV85Employeewwds_5_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV86Employeewwds_6_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV87Employeewwds_7_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV90Employeewwds_10_tfemployeevactiondays",GXType.Int16,4,0) ,
          new ParDef("AV91Employeewwds_11_tfemployeevactiondays_to",GXType.Int16,4,0) ,
          new ParDef("AV92Employeewwds_12_tfemployeebalance",GXType.Int16,4,0) ,
          new ParDef("AV93Employeewwds_13_tfemployeebalance_to",GXType.Int16,4,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002V3;
          prmH002V3 = new Object[] {
          new ParDef("AV80Udparg1",GXType.Boolean,4,0) ,
          new ParDef("AV81Udparg2",GXType.Int64,10,0) ,
          new ParDef("lV83Employeewwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Employeewwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Employeewwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Employeewwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Employeewwds_4_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV85Employeewwds_5_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV86Employeewwds_6_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV87Employeewwds_7_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV90Employeewwds_10_tfemployeevactiondays",GXType.Int16,4,0) ,
          new ParDef("AV91Employeewwds_11_tfemployeevactiondays_to",GXType.Int16,4,0) ,
          new ParDef("AV92Employeewwds_12_tfemployeebalance",GXType.Int16,4,0) ,
          new ParDef("AV93Employeewwds_13_tfemployeebalance_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002V2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002V4", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV96Udparg14 ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002V4,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 128);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
