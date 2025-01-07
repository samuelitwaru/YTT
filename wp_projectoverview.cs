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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID", AV12ProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID", AV12ProjectId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID", AV13CompanyLocationId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID", AV13CompanyLocationId);
         }
         GxWebStd.gx_hidden_field( context, "COMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTOSHOWPROJECTIDCOLLECTION", AV38ToShowProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTOSHOWPROJECTIDCOLLECTION", AV38ToShowProjectIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "PROJECTNAME", StringUtil.RTrim( A103ProjectName));
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
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentemployeeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentemployeeid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentprojectid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentprojectid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
                              E11642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_companylocationid.Onoptionclicked */
                              E12642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_EMPLOYEEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_employeeid.Onoptionclicked */
                              E13642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DATERANGE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Daterange_rangepicker.Daterangechanged */
                              E14642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E15642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportExcel' */
                              E16642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSHOWLEAVETOTAL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17642 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E18642 ();
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
      }

      protected void RF642( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E18642 ();
            WB640( ) ;
         }
      }

      protected void send_integrity_lvl_hashes642( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP640( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15642 ();
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
            Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
            Combo_companylocationid_Selectedvalue_get = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_get");
            Combo_projectid_Selectedvalue_get = cgiGet( "COMBO_PROJECTID_Selectedvalue_get");
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
         E15642 ();
         if (returnInSub) return;
      }

      protected void E15642( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11DateRange = context.localUtil.YMDToD( 2024, 1, 1);
         AssignAttri("", false, "AV11DateRange", context.localUtil.Format(AV11DateRange, "99/99/99"));
         AV21DateRange_To = context.localUtil.YMDToD( 2024, 12, 31);
         AssignAttri("", false, "AV21DateRange_To", context.localUtil.Format(AV21DateRange_To, "99/99/99"));
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         this.executeUsercontrolMethod("", false, "DATERANGE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDaterange_rangetext_Internalname});
         GXt_SdtWWPDateRangePickerOptions2 = AV22DateRange_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions2) ;
         AV22DateRange_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions2;
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCOMPANYLOCATIONID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S142 ();
         if (returnInSub) return;
      }

      protected void E16642( )
      {
         /* 'DoExportExcel' Routine */
         returnInSub = false;
         new prc_exportprojectoverview(context ).execute(  AV11DateRange,  AV21DateRange_To,  AV14EmployeeId,  AV12ProjectId,  AV13CompanyLocationId,  AV10ShowLeaveTotal,  AV25SDT_EmployeeProjectMatrixCollection, out  AV26Filename, out  AV27ErrorMessage) ;
         new logtofile(context ).execute(  ">>>>>>"+AV26Filename) ;
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

      protected void E13642( )
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

      protected void E12642( )
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

      protected void E11642( )
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

      protected void S142( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         AV19EmployeeId_Data.Clear();
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV37ToShowEmployeeIdCollection ,
                                              AV37ToShowEmployeeIdCollection.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor H00642 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = H00642_A106EmployeeId[0];
            A148EmployeeName = H00642_A148EmployeeName[0];
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AV17Combo_DataItem.gxTpr_Title = A148EmployeeName;
            AV19EmployeeId_Data.Add(AV17Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_employeeid_Selectedvalue_set = AV14EmployeeId.ToJSonString(false);
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCOMPANYLOCATIONID' Routine */
         returnInSub = false;
         /* Using cursor H00643 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A157CompanyLocationId = H00643_A157CompanyLocationId[0];
            A158CompanyLocationName = H00643_A158CompanyLocationName[0];
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0));
            AV17Combo_DataItem.gxTpr_Title = A158CompanyLocationName;
            AV18CompanyLocationId_Data.Add(AV17Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_companylocationid_Selectedvalue_set = AV13CompanyLocationId.ToJSonString(false);
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedValue_set", Combo_companylocationid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         AV15ProjectId_Data.Clear();
         new logtofile(context ).execute(  AV38ToShowProjectIdCollection.ToJSonString(false)) ;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV38ToShowProjectIdCollection } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor H00644 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A102ProjectId = H00644_A102ProjectId[0];
            A103ProjectName = H00644_A103ProjectName[0];
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
            AV17Combo_DataItem.gxTpr_Title = A103ProjectName;
            AV15ProjectId_Data.Add(AV17Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_projectid_Selectedvalue_set = AV12ProjectId.ToJSonString(false);
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
      }

      protected void E14642( )
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

      protected void E17642( )
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

      protected void S112( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETEMPLOYEESTOSHOW' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETPROJECTSTOSHOW' */
         S162 ();
         if (returnInSub) return;
         GXt_objcol_SdtSDT_EmployeeProjectMatrix3 = AV25SDT_EmployeeProjectMatrixCollection;
         new prc_employeeprojectmatrixreport(context ).execute(  AV11DateRange,  AV21DateRange_To,  AV12ProjectId,  AV13CompanyLocationId,  AV14EmployeeId,  AV10ShowLeaveTotal, out  AV36OverallTotalHours, out  GXt_objcol_SdtSDT_EmployeeProjectMatrix3) ;
         AV25SDT_EmployeeProjectMatrixCollection = GXt_objcol_SdtSDT_EmployeeProjectMatrix3;
         GXt_char4 = "";
         new formattime(context ).execute(  AV36OverallTotalHours, out  GXt_char4) ;
         Usercontrol1_Formattedoveralltotalhours = GXt_char4;
         ucUsercontrol1.SendProperty(context, "", false, Usercontrol1_Internalname, "FormattedOverallTotalHours", Usercontrol1_Formattedoveralltotalhours);
      }

      protected void S152( )
      {
         /* 'GETEMPLOYEESTOSHOW' Routine */
         returnInSub = false;
         AV37ToShowEmployeeIdCollection.Clear();
         GXt_objcol_int5 = AV37ToShowEmployeeIdCollection;
         new getemployeeidsbyproject(context ).execute(  AV12ProjectId, out  GXt_objcol_int5) ;
         AV37ToShowEmployeeIdCollection = GXt_objcol_int5;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV13CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor H00645 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A100CompanyId = H00645_A100CompanyId[0];
            A157CompanyLocationId = H00645_A157CompanyLocationId[0];
            A106EmployeeId = H00645_A106EmployeeId[0];
            A157CompanyLocationId = H00645_A157CompanyLocationId[0];
            AV37ToShowEmployeeIdCollection.Add(A106EmployeeId, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'GETPROJECTSTOSHOW' Routine */
         returnInSub = false;
         AV38ToShowProjectIdCollection.Clear();
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV14EmployeeId ,
                                              AV14EmployeeId.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor H00646 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A106EmployeeId = H00646_A106EmployeeId[0];
            /* Using cursor H00647 */
            pr_default.execute(5, new Object[] {A106EmployeeId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A102ProjectId = H00647_A102ProjectId[0];
               AV38ToShowProjectIdCollection.Add(A102ProjectId, 0);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S122 ();
         if (returnInSub) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E18642( )
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20251717383168", true, true);
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
         context.AddJavascriptSource("wp_projectoverview.js", "?20251717383168", false, true);
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
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         Usercontrol1_Internalname = "USERCONTROL1";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divOverviewtable_Internalname = "OVERVIEWTABLE";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Daterange_rangepicker_Internalname = "DATERANGE_RANGEPICKER";
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
         chkavShowleavetotal.Enabled = 1;
         Combo_employeeid_Caption = "";
         Combo_companylocationid_Caption = "";
         Combo_projectid_Caption = "";
         edtavDaterange_rangetext_Jsonclick = "";
         edtavDaterange_rangetext_Enabled = 1;
         Usercontrol1_Currentprojectid = 0;
         Usercontrol1_Currentemployeeid = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"}]}""");
         setEventMetadata("'DOEXPORTEXCEL'","""{"handler":"E16642","iparms":[{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"}]}""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED","""{"handler":"E13642","iparms":[{"av":"Combo_employeeid_Selectedvalue_get","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_get"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"}]""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED","""{"handler":"E12642","iparms":[{"av":"Combo_companylocationid_Selectedvalue_get","ctrl":"COMBO_COMPANYLOCATIONID","prop":"SelectedValue_get"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"}]""");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED","""{"handler":"E11642","iparms":[{"av":"Combo_projectid_Selectedvalue_get","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_get"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"}]""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED","""{"handler":"E14642","iparms":[{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"}]""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED",""","oparms":[{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("VSHOWLEAVETOTAL.CONTROLVALUECHANGED","""{"handler":"E17642","iparms":[{"av":"AV10ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"AV11DateRange","fld":"vDATERANGE"},{"av":"AV21DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12ProjectId","fld":"vPROJECTID"},{"av":"AV13CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14EmployeeId","fld":"vEMPLOYEEID"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"}]""");
         setEventMetadata("VSHOWLEAVETOTAL.CONTROLVALUECHANGED",""","oparms":[{"av":"Usercontrol1_Showleavetotal","ctrl":"USERCONTROL1","prop":"ShowLeaveTotal"},{"av":"AV25SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV37ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV38ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV19EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV15ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
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
         GXKey = "";
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15ProjectId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18CompanyLocationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV19EmployeeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV25SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         AV11DateRange = DateTime.MinValue;
         AV21DateRange_To = DateTime.MinValue;
         AV22DateRange_RangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV14EmployeeId = new GxSimpleCollection<long>();
         AV12ProjectId = new GxSimpleCollection<long>();
         AV13CompanyLocationId = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         AV37ToShowEmployeeIdCollection = new GxSimpleCollection<long>();
         AV38ToShowProjectIdCollection = new GxSimpleCollection<long>();
         A103ProjectName = "";
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
         ucUsercontrol1 = new GXUserControl();
         ucDaterange_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_SdtWWPDateRangePickerOptions2 = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV26Filename = "";
         AV27ErrorMessage = "";
         H00642_A106EmployeeId = new long[1] ;
         H00642_A148EmployeeName = new string[] {""} ;
         AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00643_A157CompanyLocationId = new long[1] ;
         H00643_A158CompanyLocationName = new string[] {""} ;
         A158CompanyLocationName = "";
         H00644_A102ProjectId = new long[1] ;
         H00644_A103ProjectName = new string[] {""} ;
         GXt_objcol_SdtSDT_EmployeeProjectMatrix3 = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         GXt_char4 = "";
         GXt_objcol_int5 = new GxSimpleCollection<long>();
         H00645_A100CompanyId = new long[1] ;
         H00645_A157CompanyLocationId = new long[1] ;
         H00645_A106EmployeeId = new long[1] ;
         H00646_A106EmployeeId = new long[1] ;
         H00647_A106EmployeeId = new long[1] ;
         H00647_A102ProjectId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_projectoverview__default(),
            new Object[][] {
                new Object[] {
               H00642_A106EmployeeId, H00642_A148EmployeeName
               }
               , new Object[] {
               H00643_A157CompanyLocationId, H00643_A158CompanyLocationName
               }
               , new Object[] {
               H00644_A102ProjectId, H00644_A103ProjectName
               }
               , new Object[] {
               H00645_A100CompanyId, H00645_A157CompanyLocationId, H00645_A106EmployeeId
               }
               , new Object[] {
               H00646_A106EmployeeId
               }
               , new Object[] {
               H00647_A106EmployeeId, H00647_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
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
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Usercontrol1_Currentemployeeid ;
      private int Usercontrol1_Currentprojectid ;
      private int edtavDaterange_rangetext_Enabled ;
      private int AV37ToShowEmployeeIdCollection_Count ;
      private int AV14EmployeeId_Count ;
      private int idxLst ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long AV36OverallTotalHours ;
      private long A100CompanyId ;
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
      private string divUnnamedtable3_Internalname ;
      private string Usercontrol1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Daterange_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A158CompanyLocationName ;
      private string GXt_char4 ;
      private DateTime AV11DateRange ;
      private DateTime AV21DateRange_To ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
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
      private string AV20DateRange_RangeText ;
      private string AV26Filename ;
      private string AV27ErrorMessage ;
      private GXUserControl ucCombo_projectid ;
      private GXUserControl ucCombo_companylocationid ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucUsercontrol1 ;
      private GXUserControl ucDaterange_rangepicker ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavShowleavetotal ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15ProjectId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18CompanyLocationId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV19EmployeeId_Data ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> AV25SDT_EmployeeProjectMatrixCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV22DateRange_RangePickerOptions ;
      private GxSimpleCollection<long> AV14EmployeeId ;
      private GxSimpleCollection<long> AV12ProjectId ;
      private GxSimpleCollection<long> AV13CompanyLocationId ;
      private GxSimpleCollection<long> AV37ToShowEmployeeIdCollection ;
      private GxSimpleCollection<long> AV38ToShowProjectIdCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions2 ;
      private IDataStoreProvider pr_default ;
      private long[] H00642_A106EmployeeId ;
      private string[] H00642_A148EmployeeName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV17Combo_DataItem ;
      private long[] H00643_A157CompanyLocationId ;
      private string[] H00643_A158CompanyLocationName ;
      private long[] H00644_A102ProjectId ;
      private string[] H00644_A103ProjectName ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> GXt_objcol_SdtSDT_EmployeeProjectMatrix3 ;
      private GxSimpleCollection<long> GXt_objcol_int5 ;
      private long[] H00645_A100CompanyId ;
      private long[] H00645_A157CompanyLocationId ;
      private long[] H00645_A106EmployeeId ;
      private long[] H00646_A106EmployeeId ;
      private long[] H00647_A106EmployeeId ;
      private long[] H00647_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_projectoverview__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00642( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV37ToShowEmployeeIdCollection ,
                                             int AV37ToShowEmployeeIdCollection_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
         if ( AV37ToShowEmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV37ToShowEmployeeIdCollection, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00644( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV38ToShowProjectIdCollection )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT ProjectId, ProjectName FROM Project";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV38ToShowProjectIdCollection, "ProjectId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProjectName";
         GXv_Object8[0] = scmdbuf;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H00645( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV13CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13CompanyLocationId, "T2.CompanyLocationId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object10[0] = scmdbuf;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00646( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV14EmployeeId ,
                                             int AV14EmployeeId_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT EmployeeId FROM Employee";
         if ( AV14EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV14EmployeeId, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeId";
         GXv_Object12[0] = scmdbuf;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00642(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
               case 2 :
                     return conditional_H00644(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 3 :
                     return conditional_H00645(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 4 :
                     return conditional_H00646(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00643;
          prmH00643 = new Object[] {
          };
          Object[] prmH00647;
          prmH00647 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH00642;
          prmH00642 = new Object[] {
          };
          Object[] prmH00644;
          prmH00644 = new Object[] {
          };
          Object[] prmH00645;
          prmH00645 = new Object[] {
          };
          Object[] prmH00646;
          prmH00646 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00642", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00642,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00643", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00643,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00644", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00644,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00645", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00645,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00646", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00646,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00647", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00647,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
