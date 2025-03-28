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
   public class wp_projectoverview : GXDataArea
   {
      public wp_projectoverview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_projectoverview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
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
            return "wp_projectoverview_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
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
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA642( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START642( ) ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1918140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1918140), false, true);
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
         context.AddJavascriptSource("UserControls/UC_PivotTableRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_projectoverview.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_OPENPROJECTDETAILS", AV47IsAuthorized_OpenProjectDetails);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_OPENPROJECTDETAILS", GetSecureSignedToken( "", AV47IsAuthorized_OpenProjectDetails, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSEREMPLOYEEIDCOLLECTION", AV43UserEmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSEREMPLOYEEIDCOLLECTION", AV43UserEmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSEREMPLOYEEIDCOLLECTION", GetSecureSignedToken( "", AV43UserEmployeeIdCollection, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSERPROJECTIDCOLLECTION", AV44UserProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSERPROJECTIDCOLLECTION", AV44UserProjectIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERPROJECTIDCOLLECTION", GetSecureSignedToken( "", AV44UserProjectIdCollection, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID_DATA", AV15ProjectId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID_DATA", AV15ProjectId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID_DATA", AV18CompanyLocationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID_DATA", AV18CompanyLocationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID_DATA", AV19EmployeeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID_DATA", AV19EmployeeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION", AV25SDT_EmployeeProjectMatrixCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION", AV25SDT_EmployeeProjectMatrixCollection);
         }
         GxWebStd.gx_hidden_field( context, "vDATERANGE", context.localUtil.DToC( AV11DateRange, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGE_TO", context.localUtil.DToC( AV21DateRange_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDATERANGE_RANGEPICKEROPTIONS", AV22DateRange_RangePickerOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDATERANGE_RANGEPICKEROPTIONS", AV22DateRange_RangePickerOptions);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_OPENPROJECTDETAILS", AV47IsAuthorized_OpenProjectDetails);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_OPENPROJECTDETAILS", GetSecureSignedToken( "", AV47IsAuthorized_OpenProjectDetails, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48CurrentProjectId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID", AV12ProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID", AV12ProjectId);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49CurrentEmployeeId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID", AV14EmployeeId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID", AV14EmployeeId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID", AV13CompanyLocationId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID", AV13CompanyLocationId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSEREMPLOYEEIDCOLLECTION", AV43UserEmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSEREMPLOYEEIDCOLLECTION", AV43UserEmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSEREMPLOYEEIDCOLLECTION", GetSecureSignedToken( "", AV43UserEmployeeIdCollection, context));
         GxWebStd.gx_hidden_field( context, "COMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSERPROJECTIDCOLLECTION", AV44UserProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSERPROJECTIDCOLLECTION", AV44UserProjectIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERPROJECTIDCOLLECTION", GetSecureSignedToken( "", AV44UserProjectIdCollection, context));
         GxWebStd.gx_hidden_field( context, "PROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEENAME", StringUtil.RTrim( A148EmployeeName));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTOSHOWEMPLOYEEIDCOLLECTION", AV37ToShowEmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTOSHOWEMPLOYEEIDCOLLECTION", AV37ToShowEmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "PROJECTNAME", StringUtil.RTrim( A103ProjectName));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTOSHOWPROJECTIDCOLLECTION", AV38ToShowProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTOSHOWPROJECTIDCOLLECTION", AV38ToShowProjectIdCollection);
         }
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
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Showleavetotal", StringUtil.BoolToStr( Usercontrol1_Showleavetotal));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Formattedoveralltotalhours", StringUtil.RTrim( Usercontrol1_Formattedoveralltotalhours));
         GxWebStd.gx_hidden_field( context, "OPENPROJECTDETAILS_MODAL_Width", StringUtil.RTrim( Openprojectdetails_modal_Width));
         GxWebStd.gx_hidden_field( context, "OPENPROJECTDETAILS_MODAL_Title", StringUtil.RTrim( Openprojectdetails_modal_Title));
         GxWebStd.gx_hidden_field( context, "OPENPROJECTDETAILS_MODAL_Confirmtype", StringUtil.RTrim( Openprojectdetails_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "OPENPROJECTDETAILS_MODAL_Bodytype", StringUtil.RTrim( Openprojectdetails_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "OPENEMPLOYEEDETAILS_MODAL_Width", StringUtil.RTrim( Openemployeedetails_modal_Width));
         GxWebStd.gx_hidden_field( context, "OPENEMPLOYEEDETAILS_MODAL_Title", StringUtil.RTrim( Openemployeedetails_modal_Title));
         GxWebStd.gx_hidden_field( context, "OPENEMPLOYEEDETAILS_MODAL_Confirmtype", StringUtil.RTrim( Openemployeedetails_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "OPENEMPLOYEEDETAILS_MODAL_Bodytype", StringUtil.RTrim( Openemployeedetails_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentemployeeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentemployeeid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentprojectid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentprojectid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentemployeeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentemployeeid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentprojectid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentprojectid), 9, 0, ".", "")));
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
            WE642( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT642( ) ;
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
         return formatLink("wp_projectoverview.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_ProjectOverview" ;
      }

      public override string GetPgmdesc( )
      {
         return "Project Overview" ;
      }

      protected void WB640( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, divTablemain_Visible, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:row-reverse;justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportexcel_Internalname, "", "Export", bttBtnexportexcel_Jsonclick, 5, "Export", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ProjectOverview.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingLeft10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOverviewtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "CellMarginLeftRight3", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDaterange_rangetext_Internalname, AV20DateRange_RangeText, StringUtil.RTrim( context.localUtil.Format( AV20DateRange_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDaterange_rangetext_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavDaterange_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProjectOverview.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_projectid_Internalname, "Project", "", "", lblTextblockcombo_projectid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProjectOverview.htm");
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
            ucCombo_projectid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucCombo_projectid.SetProperty("DropDownOptionsData", AV15ProjectId_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_companylocationid_Internalname, "Location", "", "", lblTextblockcombo_companylocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProjectOverview.htm");
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
            ucCombo_companylocationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucCombo_companylocationid.SetProperty("DropDownOptionsData", AV18CompanyLocationId_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_employeeid_Internalname, "Employee", "", "", lblTextblockcombo_employeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProjectOverview.htm");
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
            ucCombo_employeeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucCombo_employeeid.SetProperty("DropDownOptionsData", AV19EmployeeId_Data);
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
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:row-reverse;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableshowleavetotal_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockshowleavetotal_Internalname, "Show Leave Total", "", "", lblTextblockshowleavetotal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProjectOverview.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavShowleavetotal_Internalname, "Show Leave Total", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavShowleavetotal_Internalname, StringUtil.BoolToStr( AV10ShowLeaveTotal), "", "Show Leave Total", 1, chkavShowleavetotal.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, divUnnamedtable4_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnopenprojectdetails_Internalname, "", "OpenProjectDetails", bttBtnopenprojectdetails_Jsonclick, 5, "OpenProjectDetails", "", StyleString, ClassString, bttBtnopenprojectdetails_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOOPENPROJECTDETAILS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ProjectOverview.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnopenemployeedetails_Internalname, "", "OpenEmployeeDetails", bttBtnopenemployeedetails_Jsonclick, 7, "OpenEmployeeDetails", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11641_client"+"'", TempTags, "", 2, "HLP_WP_ProjectOverview.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUsercontrol1.SetProperty("SDT_EmployeeProjectMatrixCollection", AV25SDT_EmployeeProjectMatrixCollection);
            ucUsercontrol1.Render(context, "uc_pivottable", Usercontrol1_Internalname, "USERCONTROL1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            ucDaterange_rangepicker.SetProperty("Start Date", AV11DateRange);
            ucDaterange_rangepicker.SetProperty("End Date", AV21DateRange_To);
            ucDaterange_rangepicker.SetProperty("PickerOptions", AV22DateRange_RangePickerOptions);
            ucDaterange_rangepicker.Render(context, "wwp.daterangepicker", Daterange_rangepicker_Internalname, "DATERANGE_RANGEPICKERContainer");
            wb_table1_79_642( true) ;
         }
         else
         {
            wb_table1_79_642( false) ;
         }
         return  ;
      }

      protected void wb_table1_79_642e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_84_642( true) ;
         }
         else
         {
            wb_table2_84_642( false) ;
         }
         return  ;
      }

      protected void wb_table2_84_642e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0090"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0090"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0090"+"");
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

      protected void START642( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Project Overview", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP640( ) ;
      }

      protected void WS642( )
      {
         START642( ) ;
         EVT642( ) ;
      }

      protected void EVT642( )
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
                              /* Execute user event: Combo_projectid.Onoptionclicked */
                              E12642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_companylocationid.Onoptionclicked */
                              E13642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_EMPLOYEEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_employeeid.Onoptionclicked */
                              E14642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "USERCONTROL1.EMPLOYEECLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Usercontrol1.Employeeclicked */
                              E15642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "USERCONTROL1.PROJECTCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Usercontrol1.Projectclicked */
                              E16642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DATERANGE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Daterange_rangepicker.Daterangechanged */
                              E17642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "OPENPROJECTDETAILS_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Openprojectdetails_modal.Close */
                              E18642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "OPENEMPLOYEEDETAILS_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Openemployeedetails_modal.Close */
                              E19642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "OPENEMPLOYEEDETAILS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Openemployeedetails_modal.Onloadcomponent */
                              E20642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E21642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E22642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOOPENPROJECTDETAILS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoOpenProjectDetails' */
                              E23642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportExcel' */
                              E24642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSHOWLEAVETOTAL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E26642 ();
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
                        if ( nCmpId == 90 )
                        {
                           OldWwpaux_wc = cgiGet( "W0090");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0090", "", sEvt);
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

      protected void WE642( )
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

      protected void PA642( )
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
         AV10ShowLeaveTotal = StringUtil.StrToBool( StringUtil.BoolToStr( AV10ShowLeaveTotal));
         AssignAttri("", false, "AV10ShowLeaveTotal", AV10ShowLeaveTotal);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF642( ) ;
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

      protected void RF642( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E22642 ();
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
            E26642 ();
            WB640( ) ;
         }
      }

      protected void send_integrity_lvl_hashes642( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_OPENPROJECTDETAILS", AV47IsAuthorized_OpenProjectDetails);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_OPENPROJECTDETAILS", GetSecureSignedToken( "", AV47IsAuthorized_OpenProjectDetails, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSEREMPLOYEEIDCOLLECTION", AV43UserEmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSEREMPLOYEEIDCOLLECTION", AV43UserEmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSEREMPLOYEEIDCOLLECTION", GetSecureSignedToken( "", AV43UserEmployeeIdCollection, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSERPROJECTIDCOLLECTION", AV44UserProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSERPROJECTIDCOLLECTION", AV44UserProjectIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERPROJECTIDCOLLECTION", GetSecureSignedToken( "", AV44UserProjectIdCollection, context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP640( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E21642 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID_DATA"), AV15ProjectId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCOMPANYLOCATIONID_DATA"), AV18CompanyLocationId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV19EmployeeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"), AV25SDT_EmployeeProjectMatrixCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vDATERANGE_RANGEPICKEROPTIONS"), AV22DateRange_RangePickerOptions);
            /* Read saved values. */
            AV11DateRange = context.localUtil.CToD( cgiGet( "vDATERANGE"), 0);
            AV21DateRange_To = context.localUtil.CToD( cgiGet( "vDATERANGE_TO"), 0);
            AV48CurrentProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCURRENTPROJECTID"), ".", ","), 18, MidpointRounding.ToEven));
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
            Usercontrol1_Showleavetotal = StringUtil.StrToBool( cgiGet( "USERCONTROL1_Showleavetotal"));
            Usercontrol1_Formattedoveralltotalhours = cgiGet( "USERCONTROL1_Formattedoveralltotalhours");
            Openprojectdetails_modal_Width = cgiGet( "OPENPROJECTDETAILS_MODAL_Width");
            Openprojectdetails_modal_Title = cgiGet( "OPENPROJECTDETAILS_MODAL_Title");
            Openprojectdetails_modal_Confirmtype = cgiGet( "OPENPROJECTDETAILS_MODAL_Confirmtype");
            Openprojectdetails_modal_Bodytype = cgiGet( "OPENPROJECTDETAILS_MODAL_Bodytype");
            Openemployeedetails_modal_Width = cgiGet( "OPENEMPLOYEEDETAILS_MODAL_Width");
            Openemployeedetails_modal_Title = cgiGet( "OPENEMPLOYEEDETAILS_MODAL_Title");
            Openemployeedetails_modal_Confirmtype = cgiGet( "OPENEMPLOYEEDETAILS_MODAL_Confirmtype");
            Openemployeedetails_modal_Bodytype = cgiGet( "OPENEMPLOYEEDETAILS_MODAL_Bodytype");
            Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
            Combo_companylocationid_Selectedvalue_get = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_get");
            Combo_projectid_Selectedvalue_get = cgiGet( "COMBO_PROJECTID_Selectedvalue_get");
            Usercontrol1_Currentemployeeid = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USERCONTROL1_Currentemployeeid"), ".", ","), 18, MidpointRounding.ToEven));
            Usercontrol1_Currentprojectid = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USERCONTROL1_Currentprojectid"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV20DateRange_RangeText = cgiGet( edtavDaterange_rangetext_Internalname);
            AssignAttri("", false, "AV20DateRange_RangeText", AV20DateRange_RangeText);
            AV10ShowLeaveTotal = StringUtil.StrToBool( cgiGet( chkavShowleavetotal_Internalname));
            AssignAttri("", false, "AV10ShowLeaveTotal", AV10ShowLeaveTotal);
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
         E21642 ();
         if (returnInSub) return;
      }

      protected void E21642( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11DateRange = context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), DateTimeUtil.Month( Gx_date), 1);
         AssignAttri("", false, "AV11DateRange", context.localUtil.Format(AV11DateRange, "99/99/99"));
         AV21DateRange_To = DateTimeUtil.DateEndOfMonth( Gx_date);
         AssignAttri("", false, "AV21DateRange_To", context.localUtil.Format(AV21DateRange_To, "99/99/99"));
         GXt_boolean1 = AV39IsProjectManager;
         new userhasrole(context ).execute(  "Project Manager", out  GXt_boolean1) ;
         AV39IsProjectManager = GXt_boolean1;
         GXt_boolean1 = AV42IsManager;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean1) ;
         AV42IsManager = GXt_boolean1;
         if ( AV42IsManager )
         {
            AV52Udparg1 = new getloggedinusercompanyid(context).executeUdp( );
            /* Using cursor H00642 */
            pr_default.execute(0, new Object[] {AV52Udparg1});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A100CompanyId = H00642_A100CompanyId[0];
               A106EmployeeId = H00642_A106EmployeeId[0];
               AV43UserEmployeeIdCollection.Add(A106EmployeeId, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( AV39IsProjectManager )
         {
            AV54Udparg2 = new getloggedinemployeeid(context).executeUdp( );
            /* Using cursor H00643 */
            pr_default.execute(1, new Object[] {AV54Udparg2});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A166ProjectManagerId = H00643_A166ProjectManagerId[0];
               n166ProjectManagerId = H00643_n166ProjectManagerId[0];
               A102ProjectId = H00643_A102ProjectId[0];
               AV44UserProjectIdCollection.Add(A102ProjectId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            GXt_objcol_int2 = AV43UserEmployeeIdCollection;
            new getemployeeidsbyproject(context ).execute(  AV44UserProjectIdCollection, out  GXt_objcol_int2) ;
            AV43UserEmployeeIdCollection = GXt_objcol_int2;
         }
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         this.executeUsercontrolMethod("", false, "DATERANGE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDaterange_rangetext_Internalname});
         GXt_SdtWWPDateRangePickerOptions4 = AV22DateRange_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions4) ;
         AV22DateRange_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions4;
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCOMPANYLOCATIONID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S152 ();
         if (returnInSub) return;
      }

      protected void E22642( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E23642( )
      {
         /* 'DoOpenProjectDetails' Routine */
         returnInSub = false;
         if ( AV47IsAuthorized_OpenProjectDetails )
         {
            this.executeUsercontrolMethod("", false, "OPENPROJECTDETAILS_MODALContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
      }

      protected void E18642( )
      {
         /* Openprojectdetails_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E20642( )
      {
         /* Openemployeedetails_modal_Onloadcomponent Routine */
         returnInSub = false;
         new logtofile(context ).execute(  ">>>>"+AV12ProjectId.ToJSonString(false)) ;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkHourLogList")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workhourloglist", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkHourLogList";
            WebComp_Wwpaux_wc_Component = "WorkHourLogList";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0090",(string)"",(long)AV49CurrentEmployeeId,(GxSimpleCollection<long>)AV12ProjectId,(DateTime)AV11DateRange,(DateTime)AV21DateRange_To});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0090"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E19642( )
      {
         /* Openemployeedetails_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E24642( )
      {
         /* 'DoExportExcel' Routine */
         returnInSub = false;
         new prc_exportprojectoverview(context ).execute(  AV11DateRange,  AV21DateRange_To,  AV14EmployeeId,  AV12ProjectId,  AV13CompanyLocationId,  AV10ShowLeaveTotal,  AV25SDT_EmployeeProjectMatrixCollection, out  AV26Filename, out  AV27ErrorMessage) ;
         if ( StringUtil.StrCmp(AV26Filename, "") != 0 )
         {
            CallWebObject(formatLink(AV26Filename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV27ErrorMessage);
         }
      }

      protected void E14642( )
      {
         /* Combo_employeeid_Onoptionclicked Routine */
         returnInSub = false;
         AV14EmployeeId.FromJSonString(Combo_employeeid_Selectedvalue_get, null);
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14EmployeeId", AV14EmployeeId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25SDT_EmployeeProjectMatrixCollection", AV25SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37ToShowEmployeeIdCollection", AV37ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ToShowProjectIdCollection", AV38ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19EmployeeId_Data", AV19EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProjectId_Data", AV15ProjectId_Data);
      }

      protected void E13642( )
      {
         /* Combo_companylocationid_Onoptionclicked Routine */
         returnInSub = false;
         AV13CompanyLocationId.FromJSonString(Combo_companylocationid_Selectedvalue_get, null);
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13CompanyLocationId", AV13CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25SDT_EmployeeProjectMatrixCollection", AV25SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37ToShowEmployeeIdCollection", AV37ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ToShowProjectIdCollection", AV38ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19EmployeeId_Data", AV19EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProjectId_Data", AV15ProjectId_Data);
      }

      protected void E12642( )
      {
         /* Combo_projectid_Onoptionclicked Routine */
         returnInSub = false;
         AV12ProjectId.FromJSonString(Combo_projectid_Selectedvalue_get, null);
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12ProjectId", AV12ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25SDT_EmployeeProjectMatrixCollection", AV25SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37ToShowEmployeeIdCollection", AV37ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ToShowProjectIdCollection", AV38ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19EmployeeId_Data", AV19EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProjectId_Data", AV15ProjectId_Data);
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV47IsAuthorized_OpenProjectDetails;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean1) ;
         AV47IsAuthorized_OpenProjectDetails = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_OpenProjectDetails", AV47IsAuthorized_OpenProjectDetails);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_OPENPROJECTDETAILS", GetSecureSignedToken( "", AV47IsAuthorized_OpenProjectDetails, context));
         if ( ! ( AV47IsAuthorized_OpenProjectDetails ) )
         {
            bttBtnopenprojectdetails_Visible = 0;
            AssignProp("", false, bttBtnopenprojectdetails_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnopenprojectdetails_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divTablemain_Visible = (((1==1)) ? 1 : 0);
         AssignProp("", false, divTablemain_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemain_Visible), 5, 0), true);
         divUnnamedtable4_Visible = (((1==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable4_Visible), 5, 0), true);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         AV19EmployeeId_Data.Clear();
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV37ToShowEmployeeIdCollection ,
                                              AV37ToShowEmployeeIdCollection.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor H00644 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A106EmployeeId = H00644_A106EmployeeId[0];
            A148EmployeeName = H00644_A148EmployeeName[0];
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AV17Combo_DataItem.gxTpr_Title = A148EmployeeName;
            AV19EmployeeId_Data.Add(AV17Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_employeeid_Selectedvalue_set = AV14EmployeeId.ToJSonString(false);
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCOMPANYLOCATIONID' Routine */
         returnInSub = false;
         /* Using cursor H00645 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A157CompanyLocationId = H00645_A157CompanyLocationId[0];
            A158CompanyLocationName = H00645_A158CompanyLocationName[0];
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0));
            AV17Combo_DataItem.gxTpr_Title = A158CompanyLocationName;
            AV18CompanyLocationId_Data.Add(AV17Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_companylocationid_Selectedvalue_set = AV13CompanyLocationId.ToJSonString(false);
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedValue_set", Combo_companylocationid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         AV15ProjectId_Data.Clear();
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV38ToShowProjectIdCollection } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor H00646 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A102ProjectId = H00646_A102ProjectId[0];
            A103ProjectName = H00646_A103ProjectName[0];
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
            AV17Combo_DataItem.gxTpr_Title = A103ProjectName;
            AV15ProjectId_Data.Add(AV17Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_projectid_Selectedvalue_set = AV12ProjectId.ToJSonString(false);
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
      }

      protected void E17642( )
      {
         /* Daterange_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25SDT_EmployeeProjectMatrixCollection", AV25SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37ToShowEmployeeIdCollection", AV37ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ToShowProjectIdCollection", AV38ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19EmployeeId_Data", AV19EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProjectId_Data", AV15ProjectId_Data);
      }

      protected void E25642( )
      {
         /* Showleavetotal_Controlvaluechanged Routine */
         returnInSub = false;
         Usercontrol1_Showleavetotal = AV10ShowLeaveTotal;
         ucUsercontrol1.SendProperty(context, "", false, Usercontrol1_Internalname, "ShowLeaveTotal", StringUtil.BoolToStr( Usercontrol1_Showleavetotal));
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "USERCONTROL1Container", "Refresh", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25SDT_EmployeeProjectMatrixCollection", AV25SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37ToShowEmployeeIdCollection", AV37ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ToShowProjectIdCollection", AV38ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19EmployeeId_Data", AV19EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProjectId_Data", AV15ProjectId_Data);
      }

      protected void E15642( )
      {
         /* Usercontrol1_Employeeclicked Routine */
         returnInSub = false;
         AV49CurrentEmployeeId = Usercontrol1_Currentemployeeid;
         AssignAttri("", false, "AV49CurrentEmployeeId", StringUtil.LTrimStr( (decimal)(AV49CurrentEmployeeId), 10, 0));
         new logtofile(context ).execute(  ">>>>"+AV12ProjectId.ToJSonString(false)) ;
         this.executeUsercontrolMethod("", false, "OPENEMPLOYEEDETAILS_MODALContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E16642( )
      {
         /* Usercontrol1_Projectclicked Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S172 ();
         if (returnInSub) return;
         AV48CurrentProjectId = Usercontrol1_Currentprojectid;
         AssignAttri("", false, "AV48CurrentProjectId", StringUtil.LTrimStr( (decimal)(AV48CurrentProjectId), 10, 0));
         this.executeUsercontrolMethod("", false, "OPENPROJECTDETAILS_MODALContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETEMPLOYEESTOSHOW' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETPROJECTSTOSHOW' */
         S192 ();
         if (returnInSub) return;
         GXt_objcol_SdtSDT_EmployeeProjectMatrix5 = AV25SDT_EmployeeProjectMatrixCollection;
         new prc_employeeprojectmatrixreport(context ).execute(  AV11DateRange,  AV21DateRange_To,  AV12ProjectId,  AV13CompanyLocationId,  AV14EmployeeId,  AV43UserEmployeeIdCollection,  AV10ShowLeaveTotal, out  AV36OverallTotalHours, out  GXt_objcol_SdtSDT_EmployeeProjectMatrix5) ;
         AV25SDT_EmployeeProjectMatrixCollection = GXt_objcol_SdtSDT_EmployeeProjectMatrix5;
         GXt_char6 = "";
         new formattime(context ).execute(  AV36OverallTotalHours, out  GXt_char6) ;
         Usercontrol1_Formattedoveralltotalhours = GXt_char6;
         ucUsercontrol1.SendProperty(context, "", false, Usercontrol1_Internalname, "FormattedOverallTotalHours", Usercontrol1_Formattedoveralltotalhours);
      }

      protected void S182( )
      {
         /* 'GETEMPLOYEESTOSHOW' Routine */
         returnInSub = false;
         if ( AV43UserEmployeeIdCollection.Count > 0 )
         {
            AV37ToShowEmployeeIdCollection = AV43UserEmployeeIdCollection;
         }
         else
         {
            AV37ToShowEmployeeIdCollection.Clear();
            GXt_objcol_int2 = AV37ToShowEmployeeIdCollection;
            new getemployeeidsbyproject(context ).execute(  AV12ProjectId, out  GXt_objcol_int2) ;
            AV37ToShowEmployeeIdCollection = GXt_objcol_int2;
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 A157CompanyLocationId ,
                                                 AV13CompanyLocationId } ,
                                                 new int[]{
                                                 TypeConstants.LONG
                                                 }
            });
            /* Using cursor H00647 */
            pr_default.execute(5);
            while ( (pr_default.getStatus(5) != 101) )
            {
               A100CompanyId = H00647_A100CompanyId[0];
               A157CompanyLocationId = H00647_A157CompanyLocationId[0];
               A106EmployeeId = H00647_A106EmployeeId[0];
               A157CompanyLocationId = H00647_A157CompanyLocationId[0];
               AV37ToShowEmployeeIdCollection.Add(A106EmployeeId, 0);
               pr_default.readNext(5);
            }
            pr_default.close(5);
         }
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S192( )
      {
         /* 'GETPROJECTSTOSHOW' Routine */
         returnInSub = false;
         if ( AV44UserProjectIdCollection.Count > 0 )
         {
            AV38ToShowProjectIdCollection = AV44UserProjectIdCollection;
         }
         else
         {
            AV38ToShowProjectIdCollection.Clear();
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 A106EmployeeId ,
                                                 AV14EmployeeId ,
                                                 AV14EmployeeId.Count } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.INT
                                                 }
            });
            /* Using cursor H00648 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               A106EmployeeId = H00648_A106EmployeeId[0];
               /* Using cursor H00649 */
               pr_default.execute(7, new Object[] {A106EmployeeId});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A102ProjectId = H00649_A102ProjectId[0];
                  AV38ToShowProjectIdCollection.Add(A102ProjectId, 0);
                  pr_default.readNext(7);
               }
               pr_default.close(7);
               pr_default.readNext(6);
            }
            pr_default.close(6);
         }
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S172( )
      {
         /* 'UPDATESESSIONVARIABLES' Routine */
         returnInSub = false;
         AV46WebSession.Set("CompanyLocationId", AV13CompanyLocationId.ToJSonString(false));
         AV46WebSession.Set("EmployeeId", AV14EmployeeId.ToJSonString(false));
         AV46WebSession.Set("ProjectId", AV12ProjectId.ToJSonString(false));
         AV46WebSession.Set("FromDate", context.localUtil.DToC( AV11DateRange, 2, "/"));
         AV46WebSession.Set("ToDate", context.localUtil.DToC( AV21DateRange_To, 2, "/"));
         AV46WebSession.Set("ShowLeaveTotal", StringUtil.BoolToStr( AV10ShowLeaveTotal));
      }

      protected void nextLoad( )
      {
      }

      protected void E26642( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_84_642( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableopenemployeedetails_modal_Internalname, tblTableopenemployeedetails_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucOpenemployeedetails_modal.SetProperty("Width", Openemployeedetails_modal_Width);
            ucOpenemployeedetails_modal.SetProperty("Title", Openemployeedetails_modal_Title);
            ucOpenemployeedetails_modal.SetProperty("ConfirmType", Openemployeedetails_modal_Confirmtype);
            ucOpenemployeedetails_modal.SetProperty("BodyType", Openemployeedetails_modal_Bodytype);
            ucOpenemployeedetails_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Openemployeedetails_modal_Internalname, "OPENEMPLOYEEDETAILS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"OPENEMPLOYEEDETAILS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_84_642e( true) ;
         }
         else
         {
            wb_table2_84_642e( false) ;
         }
      }

      protected void wb_table1_79_642( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableopenprojectdetails_modal_Internalname, tblTableopenprojectdetails_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucOpenprojectdetails_modal.SetProperty("Width", Openprojectdetails_modal_Width);
            ucOpenprojectdetails_modal.SetProperty("Title", Openprojectdetails_modal_Title);
            ucOpenprojectdetails_modal.SetProperty("ConfirmType", Openprojectdetails_modal_Confirmtype);
            ucOpenprojectdetails_modal.SetProperty("BodyType", Openprojectdetails_modal_Bodytype);
            ucOpenprojectdetails_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Openprojectdetails_modal_Internalname, "OPENPROJECTDETAILS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"OPENPROJECTDETAILS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_79_642e( true) ;
         }
         else
         {
            wb_table1_79_642e( false) ;
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
         PA642( ) ;
         WS642( ) ;
         WE642( ) ;
         cleanup();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20253287523442", true, true);
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
         context.AddJavascriptSource("wp_projectoverview.js", "?20253287523442", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_PivotTableRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavShowleavetotal.Name = "vSHOWLEAVETOTAL";
         chkavShowleavetotal.WebTags = "";
         chkavShowleavetotal.Caption = "Show Leave Total";
         AssignProp("", false, chkavShowleavetotal_Internalname, "TitleCaption", chkavShowleavetotal.Caption, true);
         chkavShowleavetotal.CheckedValue = "false";
         AV10ShowLeaveTotal = StringUtil.StrToBool( StringUtil.BoolToStr( AV10ShowLeaveTotal));
         AssignAttri("", false, "AV10ShowLeaveTotal", AV10ShowLeaveTotal);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnexportexcel_Internalname = "BTNEXPORTEXCEL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
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
         bttBtnopenprojectdetails_Internalname = "BTNOPENPROJECTDETAILS";
         bttBtnopenemployeedetails_Internalname = "BTNOPENEMPLOYEEDETAILS";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         Usercontrol1_Internalname = "USERCONTROL1";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divOverviewtable_Internalname = "OVERVIEWTABLE";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Daterange_rangepicker_Internalname = "DATERANGE_RANGEPICKER";
         Openprojectdetails_modal_Internalname = "OPENPROJECTDETAILS_MODAL";
         tblTableopenprojectdetails_modal_Internalname = "TABLEOPENPROJECTDETAILS_MODAL";
         Openemployeedetails_modal_Internalname = "OPENEMPLOYEEDETAILS_MODAL";
         tblTableopenemployeedetails_modal_Internalname = "TABLEOPENEMPLOYEEDETAILS_MODAL";
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
         chkavShowleavetotal.Caption = "Show Leave Total";
         bttBtnopenprojectdetails_Visible = 1;
         divUnnamedtable4_Visible = 1;
         chkavShowleavetotal.Enabled = 1;
         Combo_employeeid_Caption = "";
         Combo_companylocationid_Caption = "";
         Combo_projectid_Caption = "";
         edtavDaterange_rangetext_Jsonclick = "";
         edtavDaterange_rangetext_Enabled = 1;
         divTablemain_Visible = 1;
         Usercontrol1_Currentprojectid = 0;
         Usercontrol1_Currentemployeeid = 0;
         Openemployeedetails_modal_Bodytype = "WebComponent";
         Openemployeedetails_modal_Confirmtype = "";
         Openemployeedetails_modal_Title = " Work Hour Log";
         Openemployeedetails_modal_Width = "1240";
         Openprojectdetails_modal_Bodytype = "WebComponent";
         Openprojectdetails_modal_Confirmtype = "";
         Openprojectdetails_modal_Title = "Project Details";
         Openprojectdetails_modal_Width = "1240";
         Usercontrol1_Formattedoveralltotalhours = "";
         Usercontrol1_Showleavetotal = Convert.ToBoolean( 0);
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
         Form.Caption = "Project Overview";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"AV47IsAuthorized_OpenProjectDetails","fld":"vISAUTHORIZED_OPENPROJECTDETAILS","hsh":true},{"av":"AV43UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV44UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV47IsAuthorized_OpenProjectDetails","fld":"vISAUTHORIZED_OPENPROJECTDETAILS","hsh":true},{"ctrl":"BTNOPENPROJECTDETAILS","prop":"Visible"}]}""");
         setEventMetadata("'DOOPENPROJECTDETAILS'","""{"handler":"E23642","iparms":[{"av":"AV47IsAuthorized_OpenProjectDetails","fld":"vISAUTHORIZED_OPENPROJECTDETAILS","hsh":true}]}""");
         setEventMetadata("OPENPROJECTDETAILS_MODAL.CLOSE","""{"handler":"E18642","iparms":[]}""");
         setEventMetadata("'DOOPENEMPLOYEEDETAILS'","""{"handler":"E11641","iparms":[]}""");
         setEventMetadata("OPENEMPLOYEEDETAILS_MODAL.ONLOADCOMPONENT","""{"handler":"E20642","iparms":[{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV49CurrentEmployeeId","fld":"vCURRENTEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"}]""");
         setEventMetadata("OPENEMPLOYEEDETAILS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("OPENEMPLOYEEDETAILS_MODAL.CLOSE","""{"handler":"E19642","iparms":[]}""");
         setEventMetadata("'DOEXPORTEXCEL'","""{"handler":"E24642","iparms":[{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"}]}""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED","""{"handler":"E14642","iparms":[{"av":"Combo_employeeid_Selectedvalue_get","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_get"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV43UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED","""{"handler":"E13642","iparms":[{"av":"Combo_companylocationid_Selectedvalue_get","ctrl":"COMBO_COMPANYLOCATIONID","prop":"SelectedValue_get"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV43UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED","""{"handler":"E12642","iparms":[{"av":"Combo_projectid_Selectedvalue_get","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_get"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV43UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED","""{"handler":"E17642","iparms":[{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV43UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED",""","oparms":[{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("VSHOWLEAVETOTAL.CONTROLVALUECHANGED","""{"handler":"E25642","iparms":[{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV43UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("VSHOWLEAVETOTAL.CONTROLVALUECHANGED",""","oparms":[{"av":"Usercontrol1_Showleavetotal","ctrl":"USERCONTROL1","prop":"ShowLeaveTotal"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("USERCONTROL1.EMPLOYEECLICKED","""{"handler":"E15642","iparms":[{"av":"Usercontrol1_Currentemployeeid","ctrl":"USERCONTROL1","prop":"CurrentEmployeeId"},{"av":"AV12ProjectId","fld":"vPROJECTID"}]""");
         setEventMetadata("USERCONTROL1.EMPLOYEECLICKED",""","oparms":[{"av":"AV49CurrentEmployeeId","fld":"vCURRENTEMPLOYEEID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("USERCONTROL1.PROJECTCLICKED","""{"handler":"E16642","iparms":[{"av":"Usercontrol1_Currentprojectid","ctrl":"USERCONTROL1","prop":"CurrentProjectId"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"}]""");
         setEventMetadata("USERCONTROL1.PROJECTCLICKED",""","oparms":[{"av":"AV48CurrentProjectId","fld":"vCURRENTPROJECTID","pic":"ZZZZZZZZZ9"}]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
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
         AV43UserEmployeeIdCollection = new GxSimpleCollection<long>();
         AV44UserProjectIdCollection = new GxSimpleCollection<long>();
         GXKey = "";
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15ProjectId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18CompanyLocationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV19EmployeeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV25SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         AV11DateRange = DateTime.MinValue;
         AV21DateRange_To = DateTime.MinValue;
         AV22DateRange_RangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV12ProjectId = new GxSimpleCollection<long>();
         AV14EmployeeId = new GxSimpleCollection<long>();
         AV13CompanyLocationId = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         AV37ToShowEmployeeIdCollection = new GxSimpleCollection<long>();
         A103ProjectName = "";
         AV38ToShowProjectIdCollection = new GxSimpleCollection<long>();
         Combo_projectid_Selectedvalue_set = "";
         Combo_companylocationid_Selectedvalue_set = "";
         Combo_employeeid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnexportexcel_Jsonclick = "";
         AV20DateRange_RangeText = "";
         lblTextblockcombo_projectid_Jsonclick = "";
         ucCombo_projectid = new GXUserControl();
         lblTextblockcombo_companylocationid_Jsonclick = "";
         ucCombo_companylocationid = new GXUserControl();
         lblTextblockcombo_employeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         lblTextblockshowleavetotal_Jsonclick = "";
         bttBtnopenprojectdetails_Jsonclick = "";
         bttBtnopenemployeedetails_Jsonclick = "";
         ucUsercontrol1 = new GXUserControl();
         ucDaterange_rangepicker = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Gx_date = DateTime.MinValue;
         H00642_A100CompanyId = new long[1] ;
         H00642_A106EmployeeId = new long[1] ;
         H00643_A166ProjectManagerId = new long[1] ;
         H00643_n166ProjectManagerId = new bool[] {false} ;
         H00643_A102ProjectId = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_SdtWWPDateRangePickerOptions4 = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV26Filename = "";
         AV27ErrorMessage = "";
         H00644_A106EmployeeId = new long[1] ;
         H00644_A148EmployeeName = new string[] {""} ;
         AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00645_A157CompanyLocationId = new long[1] ;
         H00645_A158CompanyLocationName = new string[] {""} ;
         A158CompanyLocationName = "";
         H00646_A102ProjectId = new long[1] ;
         H00646_A103ProjectName = new string[] {""} ;
         GXt_objcol_SdtSDT_EmployeeProjectMatrix5 = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         GXt_char6 = "";
         GXt_objcol_int2 = new GxSimpleCollection<long>();
         H00647_A100CompanyId = new long[1] ;
         H00647_A157CompanyLocationId = new long[1] ;
         H00647_A106EmployeeId = new long[1] ;
         H00648_A106EmployeeId = new long[1] ;
         H00649_A106EmployeeId = new long[1] ;
         H00649_A102ProjectId = new long[1] ;
         AV46WebSession = context.GetSession();
         sStyleString = "";
         ucOpenemployeedetails_modal = new GXUserControl();
         ucOpenprojectdetails_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_projectoverview__default(),
            new Object[][] {
                new Object[] {
               H00642_A100CompanyId, H00642_A106EmployeeId
               }
               , new Object[] {
               H00643_A166ProjectManagerId, H00643_n166ProjectManagerId, H00643_A102ProjectId
               }
               , new Object[] {
               H00644_A106EmployeeId, H00644_A148EmployeeName
               }
               , new Object[] {
               H00645_A157CompanyLocationId, H00645_A158CompanyLocationName
               }
               , new Object[] {
               H00646_A102ProjectId, H00646_A103ProjectName
               }
               , new Object[] {
               H00647_A100CompanyId, H00647_A157CompanyLocationId, H00647_A106EmployeeId
               }
               , new Object[] {
               H00648_A106EmployeeId
               }
               , new Object[] {
               H00649_A106EmployeeId, H00649_A102ProjectId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
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
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Usercontrol1_Currentemployeeid ;
      private int Usercontrol1_Currentprojectid ;
      private int divTablemain_Visible ;
      private int edtavDaterange_rangetext_Enabled ;
      private int divUnnamedtable4_Visible ;
      private int bttBtnopenprojectdetails_Visible ;
      private int AV37ToShowEmployeeIdCollection_Count ;
      private int AV14EmployeeId_Count ;
      private int idxLst ;
      private long AV48CurrentProjectId ;
      private long AV49CurrentEmployeeId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long AV52Udparg1 ;
      private long A100CompanyId ;
      private long AV54Udparg2 ;
      private long A166ProjectManagerId ;
      private long AV36OverallTotalHours ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string Combo_companylocationid_Selectedvalue_get ;
      private string Combo_projectid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A148EmployeeName ;
      private string A103ProjectName ;
      private string Combo_projectid_Cls ;
      private string Combo_projectid_Selectedvalue_set ;
      private string Combo_projectid_Multiplevaluestype ;
      private string Combo_companylocationid_Cls ;
      private string Combo_companylocationid_Selectedvalue_set ;
      private string Combo_companylocationid_Multiplevaluestype ;
      private string Combo_employeeid_Cls ;
      private string Combo_employeeid_Selectedvalue_set ;
      private string Combo_employeeid_Multiplevaluestype ;
      private string Usercontrol1_Formattedoveralltotalhours ;
      private string Openprojectdetails_modal_Width ;
      private string Openprojectdetails_modal_Title ;
      private string Openprojectdetails_modal_Confirmtype ;
      private string Openprojectdetails_modal_Bodytype ;
      private string Openemployeedetails_modal_Width ;
      private string Openemployeedetails_modal_Title ;
      private string Openemployeedetails_modal_Confirmtype ;
      private string Openemployeedetails_modal_Bodytype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string bttBtnexportexcel_Internalname ;
      private string bttBtnexportexcel_Jsonclick ;
      private string divTablecontent_Internalname ;
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
      private string divUnnamedtable2_Internalname ;
      private string divUnnamedtableshowleavetotal_Internalname ;
      private string lblTextblockshowleavetotal_Internalname ;
      private string lblTextblockshowleavetotal_Jsonclick ;
      private string chkavShowleavetotal_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string bttBtnopenprojectdetails_Internalname ;
      private string bttBtnopenprojectdetails_Jsonclick ;
      private string bttBtnopenemployeedetails_Internalname ;
      private string bttBtnopenemployeedetails_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string Usercontrol1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Daterange_rangepicker_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A158CompanyLocationName ;
      private string GXt_char6 ;
      private string sStyleString ;
      private string tblTableopenemployeedetails_modal_Internalname ;
      private string Openemployeedetails_modal_Internalname ;
      private string tblTableopenprojectdetails_modal_Internalname ;
      private string Openprojectdetails_modal_Internalname ;
      private DateTime AV11DateRange ;
      private DateTime AV21DateRange_To ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV47IsAuthorized_OpenProjectDetails ;
      private bool Combo_projectid_Allowmultipleselection ;
      private bool Combo_projectid_Includeonlyselectedoption ;
      private bool Combo_projectid_Emptyitem ;
      private bool Combo_companylocationid_Allowmultipleselection ;
      private bool Combo_companylocationid_Includeonlyselectedoption ;
      private bool Combo_companylocationid_Emptyitem ;
      private bool Combo_employeeid_Allowmultipleselection ;
      private bool Combo_employeeid_Includeonlyselectedoption ;
      private bool Combo_employeeid_Emptyitem ;
      private bool Usercontrol1_Showleavetotal ;
      private bool wbLoad ;
      private bool AV10ShowLeaveTotal ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV39IsProjectManager ;
      private bool AV42IsManager ;
      private bool n166ProjectManagerId ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string AV20DateRange_RangeText ;
      private string AV26Filename ;
      private string AV27ErrorMessage ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucCombo_projectid ;
      private GXUserControl ucCombo_companylocationid ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucUsercontrol1 ;
      private GXUserControl ucDaterange_rangepicker ;
      private GXUserControl ucOpenemployeedetails_modal ;
      private GXUserControl ucOpenprojectdetails_modal ;
      private IGxSession AV46WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavShowleavetotal ;
      private GxSimpleCollection<long> AV43UserEmployeeIdCollection ;
      private GxSimpleCollection<long> AV44UserProjectIdCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15ProjectId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18CompanyLocationId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV19EmployeeId_Data ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> AV25SDT_EmployeeProjectMatrixCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV22DateRange_RangePickerOptions ;
      private GxSimpleCollection<long> AV12ProjectId ;
      private GxSimpleCollection<long> AV14EmployeeId ;
      private GxSimpleCollection<long> AV13CompanyLocationId ;
      private GxSimpleCollection<long> AV37ToShowEmployeeIdCollection ;
      private GxSimpleCollection<long> AV38ToShowProjectIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] H00642_A100CompanyId ;
      private long[] H00642_A106EmployeeId ;
      private long[] H00643_A166ProjectManagerId ;
      private bool[] H00643_n166ProjectManagerId ;
      private long[] H00643_A102ProjectId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions4 ;
      private long[] H00644_A106EmployeeId ;
      private string[] H00644_A148EmployeeName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV17Combo_DataItem ;
      private long[] H00645_A157CompanyLocationId ;
      private string[] H00645_A158CompanyLocationName ;
      private long[] H00646_A102ProjectId ;
      private string[] H00646_A103ProjectName ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> GXt_objcol_SdtSDT_EmployeeProjectMatrix5 ;
      private GxSimpleCollection<long> GXt_objcol_int2 ;
      private long[] H00647_A100CompanyId ;
      private long[] H00647_A157CompanyLocationId ;
      private long[] H00647_A106EmployeeId ;
      private long[] H00648_A106EmployeeId ;
      private long[] H00649_A106EmployeeId ;
      private long[] H00649_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_projectoverview__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00644( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV37ToShowEmployeeIdCollection ,
                                             int AV37ToShowEmployeeIdCollection_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
         if ( AV37ToShowEmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV37ToShowEmployeeIdCollection, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
         GXv_Object7[0] = scmdbuf;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00646( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV38ToShowProjectIdCollection )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT ProjectId, ProjectName FROM Project";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV38ToShowProjectIdCollection, "ProjectId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProjectName";
         GXv_Object9[0] = scmdbuf;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H00647( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV13CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13CompanyLocationId, "T2.CompanyLocationId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object11[0] = scmdbuf;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H00648( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV14EmployeeId ,
                                             int AV14EmployeeId_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT EmployeeId FROM Employee";
         if ( AV14EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV14EmployeeId, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeId";
         GXv_Object13[0] = scmdbuf;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H00644(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
               case 4 :
                     return conditional_H00646(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 5 :
                     return conditional_H00647(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 6 :
                     return conditional_H00648(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00642;
          prmH00642 = new Object[] {
          new ParDef("AV52Udparg1",GXType.Int64,10,0)
          };
          Object[] prmH00643;
          prmH00643 = new Object[] {
          new ParDef("AV54Udparg2",GXType.Int64,10,0)
          };
          Object[] prmH00645;
          prmH00645 = new Object[] {
          };
          Object[] prmH00649;
          prmH00649 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH00644;
          prmH00644 = new Object[] {
          };
          Object[] prmH00646;
          prmH00646 = new Object[] {
          };
          Object[] prmH00647;
          prmH00647 = new Object[] {
          };
          Object[] prmH00648;
          prmH00648 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00642", "SELECT CompanyId, EmployeeId FROM Employee WHERE CompanyId = :AV52Udparg1 ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00642,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00643", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV54Udparg2 ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00643,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00644", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00644,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00645", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00645,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00646", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00646,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00647", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00647,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00648", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00648,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00649", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00649,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
