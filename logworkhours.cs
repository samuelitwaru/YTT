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
   public class logworkhours : GXDataArea
   {
      public logworkhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public logworkhours( IGxContext context )
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
         dynavFormworkhourlogprojectid = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vFORMWORKHOURLOGPROJECTID") == 0 )
            {
               AV18EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18EmployeeId", StringUtil.LTrimStr( (decimal)(AV18EmployeeId), 10, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDSVvFORMWORKHOURLOGPROJECTID4A2( AV18EmployeeId) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_113 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_113"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_113_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_113_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_113_idx = GetPar( "sGXsfl_113_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10date = context.localUtil.ParseDateParm( GetPar( "date"));
         AV18EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            return "logworkhours_Execute" ;
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
         PA4A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4A2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("logworkhours.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDATE", context.localUtil.Format(AV10date, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18EmployeeId), 10, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_113", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_113), 8, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISLOGHOUROPEN", AV72IsLogHourOpen);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV86DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV86DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID_DATA", AV81EmployeeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID_DATA", AV81EmployeeId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWORKHOURLOG", AV60WorkHourLog);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWORKHOURLOG", AV60WorkHourLog);
         }
         GxWebStd.gx_hidden_field( context, "vOLDDATE", context.localUtil.DToC( AV73OldDate, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTLIST", AV90projectList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTLIST", AV90projectList);
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ISLOGHOUROPEN_Ontext", StringUtil.RTrim( Isloghouropen_Ontext));
         GxWebStd.gx_hidden_field( context, "ISLOGHOUROPEN_Offtext", StringUtil.RTrim( Isloghouropen_Offtext));
         GxWebStd.gx_hidden_field( context, "ISLOGHOUROPEN_Checkedvalue", StringUtil.RTrim( Isloghouropen_Checkedvalue));
         GxWebStd.gx_hidden_field( context, "ISLOGHOUROPEN_Enabled", StringUtil.BoolToStr( Isloghouropen_Enabled));
         GxWebStd.gx_hidden_field( context, "ISLOGHOUROPEN_Captionclass", StringUtil.RTrim( Isloghouropen_Captionclass));
         GxWebStd.gx_hidden_field( context, "ISLOGHOUROPEN_Captionstyle", StringUtil.RTrim( Isloghouropen_Captionstyle));
         GxWebStd.gx_hidden_field( context, "ISLOGHOUROPEN_Captionposition", StringUtil.RTrim( Isloghouropen_Captionposition));
         GxWebStd.gx_hidden_field( context, "ISLOGHOUROPEN_Visible", StringUtil.BoolToStr( Isloghouropen_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Cls", StringUtil.RTrim( Combo_employeeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_set", StringUtil.RTrim( Combo_employeeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Emptyitem", StringUtil.BoolToStr( Combo_employeeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE4A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4A2( ) ;
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
         return formatLink("logworkhours.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "LogWorkHours" ;
      }

      public override string GetPgmdesc( )
      {
         return "Log Hours" ;
      }

      protected void WB4A0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, divTablecontent_Width, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, divUnnamedtable1_Visible, divUnnamedtable1_Width, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divIsloghouropen_cell_Internalname, 1, 0, "px", 0, "px", divIsloghouropen_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Isloghouropen_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Isloghouropen_Internalname, "Open Time tracker ", " isLogHourOpenLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucIsloghouropen.SetProperty("Attribute", AV72IsLogHourOpen);
            ucIsloghouropen.SetProperty("OnText", Isloghouropen_Ontext);
            ucIsloghouropen.SetProperty("OffText", Isloghouropen_Offtext);
            ucIsloghouropen.SetProperty("CheckedValue", Isloghouropen_Checkedvalue);
            ucIsloghouropen.SetProperty("Enabled", Isloghouropen_Enabled);
            ucIsloghouropen.SetProperty("CaptionClass", Isloghouropen_Captionclass);
            ucIsloghouropen.SetProperty("CaptionStyle", Isloghouropen_Captionstyle);
            ucIsloghouropen.SetProperty("CaptionPosition", Isloghouropen_Captionposition);
            ucIsloghouropen.Render(context, "sdswitch", Isloghouropen_Internalname, "ISLOGHOUROPENContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", divUnnamedtable2_Height, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, divUnnamedtable11_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTtopentext_Internalname, "Time tracker is open for filling", "", "", lblTtopentext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TTOpenText TextBlock AttributeColorWarning", 0, "", lblTtopentext_Visible, 1, 0, 0, "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDate_Internalname, "date", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_113_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDate_Internalname, context.localUtil.Format(AV10date, "99/99/99"), context.localUtil.Format( AV10date, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LogWorkHours.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingLeft30", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledetailattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 hidden-xs hidden-sm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-11", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_employeeid_Internalname, "Employee Id", "", "", lblTextblockcombo_employeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_employeeid.SetProperty("Caption", Combo_employeeid_Caption);
            ucCombo_employeeid.SetProperty("Cls", Combo_employeeid_Cls);
            ucCombo_employeeid.SetProperty("EmptyItem", Combo_employeeid_Emptyitem);
            ucCombo_employeeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV86DDO_TitleSettingsIcons);
            ucCombo_employeeid.SetProperty("DropDownOptionsData", AV81EmployeeId_Data);
            ucCombo_employeeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_employeeid_Internalname, "COMBO_EMPLOYEEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFormworkhourlogdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFormworkhourlogdate_Internalname, "Date", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_113_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFormworkhourlogdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFormworkhourlogdate_Internalname, context.localUtil.Format(AV22FormWorkHourLogDate, "99/99/99"), context.localUtil.Format( AV22FormWorkHourLogDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFormworkhourlogdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFormworkhourlogdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LogWorkHours.htm");
            GxWebStd.gx_bitmap( context, edtavFormworkhourlogdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFormworkhourlogdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LogWorkHours.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavFormworkhourlogprojectid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavFormworkhourlogprojectid_Internalname, "Project", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_113_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavFormworkhourlogprojectid, dynavFormworkhourlogprojectid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0)), 1, dynavFormworkhourlogprojectid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavFormworkhourlogprojectid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_LogWorkHours.htm");
            dynavFormworkhourlogprojectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
            AssignProp("", false, dynavFormworkhourlogprojectid_Internalname, "Values", (string)(dynavFormworkhourlogprojectid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFormworkhourloghours_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFormworkhourloghours_Internalname, "Hours(HH)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFormworkhourloghours_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26FormWorkHourLogHours), 4, 0, ".", "")), StringUtil.LTrim( ((edtavFormworkhourloghours_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26FormWorkHourLogHours), "ZZZ9") : context.localUtil.Format( (decimal)(AV26FormWorkHourLogHours), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFormworkhourloghours_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFormworkhourloghours_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFormworkhourlogminutes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFormworkhourlogminutes_Internalname, "Minutes(MM)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFormworkhourlogminutes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28FormWorkHourLogMinutes), 4, 0, ".", "")), StringUtil.LTrim( ((edtavFormworkhourlogminutes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV28FormWorkHourLogMinutes), "ZZZ9") : context.localUtil.Format( (decimal)(AV28FormWorkHourLogMinutes), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFormworkhourlogminutes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFormworkhourlogminutes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFormworkhourlogdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFormworkhourlogdescription_Internalname, "Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_113_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavFormworkhourlogdescription_Internalname, AV23FormWorkHourLogDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", 0, 1, edtavFormworkhourlogdescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "2097152", 1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(113), 3, 0)+","+"null"+");", "Confirm", bttBtnsave_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSAVE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(113), 3, 0)+","+"null"+");", "Cancel", bttBtnuseraction1_Jsonclick, 7, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e114a1_client"+"'", TempTags, "", 2, "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", divUnnamedtable9_Height, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, divUnnamedtable10_Width, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Weekly Total", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeLabel AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWeeklytotal_Internalname, lblWeeklytotal_Caption, "", "", lblWeeklytotal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeLabel AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Daily Total", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeLabel AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDailytotal_Internalname, lblDailytotal_Caption, "", "", lblDailytotal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeLabel AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Monthly Total", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_LogWorkHours.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMonthlytotal_Internalname, lblMonthlytotal_Caption, "", "", lblMonthlytotal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_LogWorkHours.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", divUnnamedtable7_Height, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divListlogs_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridPadding HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl113( ) ;
         }
         if ( wbEnd == 113 )
         {
            wbEnd = 0;
            nRC_GXsfl_113 = (int)(nGXsfl_113_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployeeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18EmployeeId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18EmployeeId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmployeeid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LogWorkHours.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFormworkhourlogid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27FormWorkHourLogId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27FormWorkHourLogId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFormworkhourlogid_Jsonclick, 0, "Attribute", "", "", "", "", edtavFormworkhourlogid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LogWorkHours.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFormworkhourlogduration_Internalname, AV24FormWorkHourLogDuration, StringUtil.RTrim( context.localUtil.Format( AV24FormWorkHourLogDuration, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFormworkhourlogduration_Jsonclick, 0, "Attribute", "", "", "", "", edtavFormworkhourlogduration_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LogWorkHours.htm");
            /* User Defined Control */
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, "GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 113 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4A2( )
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
         Form.Meta.addItem("description", "Log Hours", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4A0( ) ;
      }

      protected void WS4A2( )
      {
         START4A2( ) ;
         EVT4A2( ) ;
      }

      protected void EVT4A2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VISLOGHOUROPEN.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_EMPLOYEEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_employeeid.Onoptionclicked */
                              E134A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Dosave' */
                              E144A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E154A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFORMWORKHOURLOGPROJECTID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E164A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) )
                           {
                              nGXsfl_113_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
                              SubsflControlProps_1132( ) ;
                              A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A119WorkHourLogDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtWorkHourLogDate_Internalname), 0));
                              A103ProjectName = cgiGet( edtProjectName_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A120WorkHourLogDuration = cgiGet( edtWorkHourLogDuration_Internalname);
                              A123WorkHourLogDescription = cgiGet( edtWorkHourLogDescription_Internalname);
                              A121WorkHourLogHour = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogHour_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A122WorkHourLogMinute = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogMinute_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              AV56update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV56update);
                              AV11delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV11delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E174A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1.Load */
                                    E184A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E194A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E204A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUPDATE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E214A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Date Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vDATE"), 0) != AV10date )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Employeeid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vEMPLOYEEID"), ".", ",") != Convert.ToDecimal( AV18EmployeeId )) )
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

      protected void WE4A2( )
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

      protected void PA4A2( )
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
               GX_FocusControl = edtavDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         GXVvFORMWORKHOURLOGPROJECTID_html4A2( AV18EmployeeId) ;
         /* End function dynload_actions */
      }

      protected void GXDSVvFORMWORKHOURLOGPROJECTID4A2( long AV18EmployeeId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDSVvFORMWORKHOURLOGPROJECTID_data4A2( AV18EmployeeId) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrldescr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrldescr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvFORMWORKHOURLOGPROJECTID_html4A2( long AV18EmployeeId )
      {
         long gxdynajaxvalue;
         GXDSVvFORMWORKHOURLOGPROJECTID_data4A2( AV18EmployeeId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavFormworkhourlogprojectid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavFormworkhourlogprojectid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavFormworkhourlogprojectid.ItemCount > 0 )
         {
            AV29FormWorkHourLogProjectId = (long)(Math.Round(NumberUtil.Val( dynavFormworkhourlogprojectid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29FormWorkHourLogProjectId", StringUtil.LTrimStr( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
         }
      }

      protected void GXDSVvFORMWORKHOURLOGPROJECTID_data4A2( long AV18EmployeeId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> gxcolvFORMWORKHOURLOGPROJECTID;
         SdtSDTEmployeeProject_SDTEmployeeProjectItem gxcolitemvFORMWORKHOURLOGPROJECTID;
         new dpemployeetologhoursprojects(context ).execute(  AV18EmployeeId, out  gxcolvFORMWORKHOURLOGPROJECTID) ;
         gxcolvFORMWORKHOURLOGPROJECTID.Sort("Projectname");
         int gxindex = 1;
         while ( gxindex <= gxcolvFORMWORKHOURLOGPROJECTID.Count )
         {
            gxcolitemvFORMWORKHOURLOGPROJECTID = ((SdtSDTEmployeeProject_SDTEmployeeProjectItem)gxcolvFORMWORKHOURLOGPROJECTID.Item(gxindex));
            gxdynajaxctrlcodr.Add(StringUtil.LTrimStr( (decimal)(gxcolitemvFORMWORKHOURLOGPROJECTID.gxTpr_Projectid), 10, 0));
            gxdynajaxctrldescr.Add(gxcolitemvFORMWORKHOURLOGPROJECTID.gxTpr_Projectname);
            gxindex = (int)(gxindex+1);
         }
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1132( ) ;
         while ( nGXsfl_113_idx <= nRC_GXsfl_113 )
         {
            sendrow_1132( ) ;
            nGXsfl_113_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_113_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1132( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        DateTime AV10date ,
                                        long AV18EmployeeId ,
                                        DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF4A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WORKHOURLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_EMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGDATE", GetSecureSignedToken( "", A119WorkHourLogDate, context));
         GxWebStd.gx_hidden_field( context, "WORKHOURLOGDATE", context.localUtil.Format(A119WorkHourLogDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGHOUR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WORKHOURLOGHOUR", StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGMINUTE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WORKHOURLOGMINUTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGDESCRIPTION", GetSecureSignedToken( "", A123WorkHourLogDescription, context));
         GxWebStd.gx_hidden_field( context, "WORKHOURLOGDESCRIPTION", A123WorkHourLogDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_PROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")));
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
         if ( dynavFormworkhourlogprojectid.ItemCount > 0 )
         {
            AV29FormWorkHourLogProjectId = (long)(Math.Round(NumberUtil.Val( dynavFormworkhourlogprojectid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29FormWorkHourLogProjectId", StringUtil.LTrimStr( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavFormworkhourlogprojectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
            AssignProp("", false, dynavFormworkhourlogprojectid_Internalname, "Values", dynavFormworkhourlogprojectid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavFormworkhourlogdate_Enabled = 0;
         AssignProp("", false, edtavFormworkhourlogdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFormworkhourlogdate_Enabled), 5, 0), true);
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF4A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 113;
         /* Execute user event: Refresh */
         E204A2 ();
         nGXsfl_113_idx = 1;
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_1132( ) ;
         bGXsfl_113_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1132( ) ;
            GXPagingFrom2 = (int)(((subGrid1_Rows==0) ? 0 : GRID1_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid1_Rows==0) ? 10000 : subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A102ProjectId ,
                                                 AV90projectList ,
                                                 A106EmployeeId ,
                                                 AV18EmployeeId ,
                                                 A119WorkHourLogDate ,
                                                 AV10date } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor H004A2 */
            pr_default.execute(0, new Object[] {AV18EmployeeId, AV10date, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_113_idx = 1;
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1132( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid1_Rows == 0 ) || ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               A122WorkHourLogMinute = H004A2_A122WorkHourLogMinute[0];
               A118WorkHourLogId = H004A2_A118WorkHourLogId[0];
               A121WorkHourLogHour = H004A2_A121WorkHourLogHour[0];
               A123WorkHourLogDescription = H004A2_A123WorkHourLogDescription[0];
               A120WorkHourLogDuration = H004A2_A120WorkHourLogDuration[0];
               A106EmployeeId = H004A2_A106EmployeeId[0];
               A103ProjectName = H004A2_A103ProjectName[0];
               A119WorkHourLogDate = H004A2_A119WorkHourLogDate[0];
               A102ProjectId = H004A2_A102ProjectId[0];
               A103ProjectName = H004A2_A103ProjectName[0];
               /* Execute user event: Grid1.Load */
               E184A2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 113;
            WB4A0( ) ;
         }
         bGXsfl_113_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4A2( )
      {
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGID"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_EMPLOYEEID"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGDATE"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, A119WorkHourLogDate, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGHOUR"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGMINUTE"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGDESCRIPTION"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, A123WorkHourLogDescription, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROJECTID"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV90projectList ,
                                              A106EmployeeId ,
                                              AV18EmployeeId ,
                                              A119WorkHourLogDate ,
                                              AV10date } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor H004A3 */
         pr_default.execute(1, new Object[] {AV18EmployeeId, AV10date});
         GRID1_nRecordCount = H004A3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         if ( subGrid1_Rows > 0 )
         {
            return subGrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         edtavFormworkhourlogdate_Enabled = 0;
         AssignProp("", false, edtavFormworkhourlogdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFormworkhourlogdate_Enabled), 5, 0), true);
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtProjectId_Enabled = 0;
         edtWorkHourLogDate_Enabled = 0;
         edtProjectName_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtWorkHourLogDuration_Enabled = 0;
         edtWorkHourLogDescription_Enabled = 0;
         edtWorkHourLogHour_Enabled = 0;
         edtWorkHourLogId_Enabled = 0;
         edtWorkHourLogMinute_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E174A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV86DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV81EmployeeId_Data);
            /* Read saved values. */
            nRC_GXsfl_113 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_113"), ".", ","), 18, MidpointRounding.ToEven));
            AV72IsLogHourOpen = StringUtil.StrToBool( cgiGet( "vISLOGHOUROPEN"));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Isloghouropen_Ontext = cgiGet( "ISLOGHOUROPEN_Ontext");
            Isloghouropen_Offtext = cgiGet( "ISLOGHOUROPEN_Offtext");
            Isloghouropen_Checkedvalue = cgiGet( "ISLOGHOUROPEN_Checkedvalue");
            Isloghouropen_Enabled = StringUtil.StrToBool( cgiGet( "ISLOGHOUROPEN_Enabled"));
            Isloghouropen_Captionclass = cgiGet( "ISLOGHOUROPEN_Captionclass");
            Isloghouropen_Captionstyle = cgiGet( "ISLOGHOUROPEN_Captionstyle");
            Isloghouropen_Captionposition = cgiGet( "ISLOGHOUROPEN_Captionposition");
            Isloghouropen_Visible = StringUtil.StrToBool( cgiGet( "ISLOGHOUROPEN_Visible"));
            Combo_employeeid_Cls = cgiGet( "COMBO_EMPLOYEEID_Cls");
            Combo_employeeid_Selectedvalue_set = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_set");
            Combo_employeeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Emptyitem"));
            Grid1_empowerer_Gridinternalname = cgiGet( "GRID1_EMPOWERER_Gridinternalname");
            Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavDate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"date"}), 1, "vDATE");
               GX_FocusControl = edtavDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10date = DateTime.MinValue;
               AssignAttri("", false, "AV10date", context.localUtil.Format(AV10date, "99/99/99"));
            }
            else
            {
               AV10date = context.localUtil.CToD( cgiGet( edtavDate_Internalname), 2);
               AssignAttri("", false, "AV10date", context.localUtil.Format(AV10date, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFormworkhourlogdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Work Hour Log Date"}), 1, "vFORMWORKHOURLOGDATE");
               GX_FocusControl = edtavFormworkhourlogdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22FormWorkHourLogDate = DateTime.MinValue;
               AssignAttri("", false, "AV22FormWorkHourLogDate", context.localUtil.Format(AV22FormWorkHourLogDate, "99/99/99"));
            }
            else
            {
               AV22FormWorkHourLogDate = context.localUtil.CToD( cgiGet( edtavFormworkhourlogdate_Internalname), 2);
               AssignAttri("", false, "AV22FormWorkHourLogDate", context.localUtil.Format(AV22FormWorkHourLogDate, "99/99/99"));
            }
            dynavFormworkhourlogprojectid.Name = dynavFormworkhourlogprojectid_Internalname;
            dynavFormworkhourlogprojectid.CurrentValue = cgiGet( dynavFormworkhourlogprojectid_Internalname);
            AV29FormWorkHourLogProjectId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavFormworkhourlogprojectid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29FormWorkHourLogProjectId", StringUtil.LTrimStr( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFormworkhourloghours_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFormworkhourloghours_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFORMWORKHOURLOGHOURS");
               GX_FocusControl = edtavFormworkhourloghours_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26FormWorkHourLogHours = 0;
               AssignAttri("", false, "AV26FormWorkHourLogHours", StringUtil.LTrimStr( (decimal)(AV26FormWorkHourLogHours), 4, 0));
            }
            else
            {
               AV26FormWorkHourLogHours = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavFormworkhourloghours_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26FormWorkHourLogHours", StringUtil.LTrimStr( (decimal)(AV26FormWorkHourLogHours), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFormworkhourlogminutes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFormworkhourlogminutes_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFORMWORKHOURLOGMINUTES");
               GX_FocusControl = edtavFormworkhourlogminutes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28FormWorkHourLogMinutes = 0;
               AssignAttri("", false, "AV28FormWorkHourLogMinutes", StringUtil.LTrimStr( (decimal)(AV28FormWorkHourLogMinutes), 4, 0));
            }
            else
            {
               AV28FormWorkHourLogMinutes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavFormworkhourlogminutes_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28FormWorkHourLogMinutes", StringUtil.LTrimStr( (decimal)(AV28FormWorkHourLogMinutes), 4, 0));
            }
            AV23FormWorkHourLogDescription = cgiGet( edtavFormworkhourlogdescription_Internalname);
            AssignAttri("", false, "AV23FormWorkHourLogDescription", AV23FormWorkHourLogDescription);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMPLOYEEID");
               GX_FocusControl = edtavEmployeeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18EmployeeId = 0;
               AssignAttri("", false, "AV18EmployeeId", StringUtil.LTrimStr( (decimal)(AV18EmployeeId), 10, 0));
            }
            else
            {
               AV18EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18EmployeeId", StringUtil.LTrimStr( (decimal)(AV18EmployeeId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFormworkhourlogid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFormworkhourlogid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFORMWORKHOURLOGID");
               GX_FocusControl = edtavFormworkhourlogid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27FormWorkHourLogId = 0;
               AssignAttri("", false, "AV27FormWorkHourLogId", StringUtil.LTrimStr( (decimal)(AV27FormWorkHourLogId), 10, 0));
            }
            else
            {
               AV27FormWorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavFormworkhourlogid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27FormWorkHourLogId", StringUtil.LTrimStr( (decimal)(AV27FormWorkHourLogId), 10, 0));
            }
            AV24FormWorkHourLogDuration = cgiGet( edtavFormworkhourlogduration_Internalname);
            AssignAttri("", false, "AV24FormWorkHourLogDuration", AV24FormWorkHourLogDuration);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vDATE"), 2) ) != DateTimeUtil.ResetTime ( AV10date ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vEMPLOYEEID"), ".", ",") != Convert.ToDecimal( AV18EmployeeId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E174A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E174A2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_int1 = AV25FormWorkHourLogEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV25FormWorkHourLogEmployeeId = GXt_int1;
         AV10date = Gx_date;
         AssignAttri("", false, "AV10date", context.localUtil.Format(AV10date, "99/99/99"));
         AV73OldDate = AV10date;
         AssignAttri("", false, "AV73OldDate", context.localUtil.Format(AV73OldDate, "99/99/99"));
         GXt_date2 = AV22FormWorkHourLogDate;
         new getlastworkhourlogdate(context ).execute(  AV25FormWorkHourLogEmployeeId, out  GXt_date2) ;
         AV22FormWorkHourLogDate = GXt_date2;
         AssignAttri("", false, "AV22FormWorkHourLogDate", context.localUtil.Format(AV22FormWorkHourLogDate, "99/99/99"));
         GXt_int1 = AV42LastLoggedProjectId;
         new getemployeelastloggedproject(context ).execute( out  GXt_int1) ;
         AV42LastLoggedProjectId = GXt_int1;
         if ( ( AV42LastLoggedProjectId > 0 ) && ( (0==AV20FormHourWorkLogId) ) )
         {
            AV29FormWorkHourLogProjectId = AV42LastLoggedProjectId;
            AssignAttri("", false, "AV29FormWorkHourLogProjectId", StringUtil.LTrimStr( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
         }
         /* Execute user subroutine: 'CHANGINGDATA' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_boolean3 = AV72IsLogHourOpen;
         new istimetrackeropen(context ).execute( out  GXt_boolean3) ;
         AV72IsLogHourOpen = GXt_boolean3;
         AssignAttri("", false, "AV72IsLogHourOpen", AV72IsLogHourOpen);
         lblTtopentext_Visible = (AV72IsLogHourOpen ? 1 : 0);
         AssignProp("", false, lblTtopentext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTtopentext_Visible), 5, 0), true);
         AV18EmployeeId = AV25FormWorkHourLogEmployeeId;
         AssignAttri("", false, "AV18EmployeeId", StringUtil.LTrimStr( (decimal)(AV18EmployeeId), 10, 0));
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         divTablecontent_Width = 1000;
         AssignProp("", false, divTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablecontent_Width), 9, 0), true);
         divUnnamedtable7_Height = 20;
         AssignProp("", false, divUnnamedtable7_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divUnnamedtable7_Height), 9, 0), true);
         divUnnamedtable10_Width = 300;
         AssignProp("", false, divUnnamedtable10_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divUnnamedtable10_Width), 9, 0), true);
         divUnnamedtable9_Height = 30;
         AssignProp("", false, divUnnamedtable9_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divUnnamedtable9_Height), 9, 0), true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = AV86DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4) ;
         AV86DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4;
         edtavEmployeeid_Visible = 0;
         AssignProp("", false, edtavEmployeeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployeeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         divUnnamedtable2_Height = 20;
         AssignProp("", false, divUnnamedtable2_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divUnnamedtable2_Height), 9, 0), true);
         divUnnamedtable1_Width = 280;
         AssignProp("", false, divUnnamedtable1_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divUnnamedtable1_Width), 9, 0), true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtavFormworkhourlogid_Visible = 0;
         AssignProp("", false, edtavFormworkhourlogid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFormworkhourlogid_Visible), 5, 0), true);
         edtavFormworkhourlogduration_Visible = 0;
         AssignProp("", false, edtavFormworkhourlogduration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFormworkhourlogduration_Visible), 5, 0), true);
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, "", false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         Form.Caption = "Log Hours";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADPROJECTSGRID' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E184A2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         if ( new istimetrackeropen(context).executeUdp( ) )
         {
            edtavUpdate_Visible = 1;
            edtavDelete_Visible = 1;
         }
         else
         {
            if ( DateTimeUtil.ResetTime ( A119WorkHourLogDate ) < DateTimeUtil.ResetTime ( DateTimeUtil.DAdd( Gx_date, (-2)) ) )
            {
               edtavUpdate_Visible = 0;
               edtavDelete_Visible = 0;
            }
         }
         AV56update = "<i class=\"fas fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV56update);
         AV11delete = "<i class=\"fas fa-xmark\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV11delete);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 113;
         }
         sendrow_1132( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_113_Refreshing )
         {
            DoAjaxLoad(113, Grid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E144A2( )
      {
         /* 'Dosave' Routine */
         returnInSub = false;
         AV21formIsValid = true;
         if ( (0==AV26FormWorkHourLogHours) && (0==AV28FormWorkHourLogMinutes) )
         {
            AV21formIsValid = false;
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Work hours/minutes are required",  "error",  "#"+edtavFormworkhourloghours_Internalname,  "true",  ""));
         }
         if ( ( AV26FormWorkHourLogHours > 23 ) || ( AV26FormWorkHourLogHours < 0 ) )
         {
            AV21formIsValid = false;
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Invalid hours'",  "error",  "#"+edtavFormworkhourloghours_Internalname,  "true",  ""));
         }
         if ( ( AV28FormWorkHourLogMinutes < 0 ) || ( AV28FormWorkHourLogMinutes > 59 ) )
         {
            AV21formIsValid = false;
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Invalid minutes",  "error",  "#"+edtavFormworkhourlogminutes_Internalname,  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23FormWorkHourLogDescription)) )
         {
            AV21formIsValid = false;
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Description cannot be empty",  "error",  "#"+edtavFormworkhourlogdescription_Internalname,  "true",  ""));
         }
         if ( AV21formIsValid )
         {
            AV60WorkHourLog.gxTpr_Workhourlogid = AV27FormWorkHourLogId;
            AV60WorkHourLog.gxTpr_Workhourlogdate = AV22FormWorkHourLogDate;
            AV60WorkHourLog.gxTpr_Workhourloghour = AV26FormWorkHourLogHours;
            AV60WorkHourLog.gxTpr_Workhourlogminute = AV28FormWorkHourLogMinutes;
            AV60WorkHourLog.gxTpr_Projectid = AV29FormWorkHourLogProjectId;
            AV60WorkHourLog.gxTpr_Employeeid = AV18EmployeeId;
            AV60WorkHourLog.gxTpr_Workhourlogdescription = AV23FormWorkHourLogDescription;
            if ( ( (0==AV26FormWorkHourLogHours) ) || ( AV26FormWorkHourLogHours == 0 ) )
            {
               if ( AV28FormWorkHourLogMinutes < 10 )
               {
                  AV60WorkHourLog.gxTpr_Workhourlogduration = "0:0"+StringUtil.Trim( StringUtil.Str( (decimal)(AV28FormWorkHourLogMinutes), 4, 0));
               }
               else
               {
                  AV60WorkHourLog.gxTpr_Workhourlogduration = "0:"+StringUtil.Trim( StringUtil.Str( (decimal)(AV28FormWorkHourLogMinutes), 4, 0));
               }
            }
            else
            {
               if ( AV28FormWorkHourLogMinutes < 10 )
               {
                  AV55trimmedhour = StringUtil.Trim( StringUtil.Str( (decimal)(AV26FormWorkHourLogHours), 4, 0));
                  AV60WorkHourLog.gxTpr_Workhourlogduration = AV55trimmedhour+":0"+StringUtil.Trim( StringUtil.Str( (decimal)(AV28FormWorkHourLogMinutes), 4, 0));
               }
               else
               {
                  AV55trimmedhour = StringUtil.Trim( StringUtil.Str( (decimal)(AV26FormWorkHourLogHours), 4, 0));
                  AV60WorkHourLog.gxTpr_Workhourlogduration = AV55trimmedhour+":"+StringUtil.Trim( StringUtil.Str( (decimal)(AV28FormWorkHourLogMinutes), 4, 0));
               }
            }
            if ( new istimetrackeropen(context).executeUdp( ) )
            {
               /* Execute user subroutine: 'INSERTRECORD' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( AV22FormWorkHourLogDate ) < DateTimeUtil.ResetTime ( DateTimeUtil.DAdd( Gx_date, (-2)) ) ) || ( DateTimeUtil.ResetTime ( AV22FormWorkHourLogDate ) > DateTimeUtil.ResetTime ( Gx_date ) ) )
               {
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "You cannot log hours on this date",  "error",  "#"+edtavFormworkhourlogdescription_Internalname,  "true",  ""));
               }
               else
               {
                  /* Execute user subroutine: 'INSERTRECORD' */
                  S152 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60WorkHourLog", AV60WorkHourLog);
      }

      protected void E134A2( )
      {
         /* Combo_employeeid_Onoptionclicked Routine */
         returnInSub = false;
         AV18EmployeeId = (long)(Math.Round(NumberUtil.Val( Combo_employeeid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV18EmployeeId", StringUtil.LTrimStr( (decimal)(AV18EmployeeId), 10, 0));
         /* Execute user subroutine: 'CLEARFORM' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'CHANGINGDATA' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
         dynload_actions( ) ;
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV6CheckRequiredFieldsResult = true;
         if ( (0==AV29FormWorkHourLogProjectId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Project", "", "", "", "", "", "", "", ""),  "error",  dynavFormworkhourlogprojectid_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23FormWorkHourLogDescription)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "",  "error",  edtavFormworkhourlogdescription_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
         }
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( new userhasrole(context).executeUdp(  "Manager") ) ) )
         {
            Isloghouropen_Visible = false;
            AssignProp("", false, Isloghouropen_Internalname, "Visible", StringUtil.BoolToStr( Isloghouropen_Visible), true);
            divIsloghouropen_cell_Class = "Invisible";
            AssignProp("", false, divIsloghouropen_cell_Internalname, "Class", divIsloghouropen_cell_Class, true);
         }
         else
         {
            Isloghouropen_Visible = true;
            AssignProp("", false, Isloghouropen_Internalname, "Visible", StringUtil.BoolToStr( Isloghouropen_Visible), true);
            divIsloghouropen_cell_Class = "col-xs-6 DataContentCell DscTop";
            AssignProp("", false, divIsloghouropen_cell_Internalname, "Class", divIsloghouropen_cell_Class, true);
         }
         if ( ! Isloghouropen_Visible )
         {
            divUnnamedtable1_Visible = 0;
            AssignProp("", false, divUnnamedtable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable1_Visible), 5, 0), true);
         }
         divUnnamedtable11_Visible = (((AV72IsLogHourOpen)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable11_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable11_Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         AV93GXV2 = 1;
         GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem5 = AV92GXV1;
         new dpemployeetologhours(context ).execute( out  GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem5) ;
         AV92GXV1 = GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem5;
         while ( AV93GXV2 <= AV92GXV1.Count )
         {
            AV87EmployeeId_DPItem = ((SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem)AV92GXV1.Item(AV93GXV2));
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(AV87EmployeeId_DPItem.gxTpr_Sdtemployeeid), 10, 0));
            AV7Combo_DataItem.gxTpr_Title = AV87EmployeeId_DPItem.gxTpr_Sdtemployeename;
            AV81EmployeeId_Data.Add(AV7Combo_DataItem, 0);
            AV93GXV2 = (int)(AV93GXV2+1);
         }
         AV81EmployeeId_Data.Sort("Title");
         Combo_employeeid_Selectedvalue_set = ((0==AV18EmployeeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV18EmployeeId), 10, 0)));
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
      }

      protected void E154A2( )
      {
         /* Date_Controlvaluechanged Routine */
         returnInSub = false;
         if ( (DateTime.MinValue==AV10date) )
         {
            AV10date = AV73OldDate;
            AssignAttri("", false, "AV10date", context.localUtil.Format(AV10date, "99/99/99"));
         }
         AV22FormWorkHourLogDate = AV10date;
         AssignAttri("", false, "AV22FormWorkHourLogDate", context.localUtil.Format(AV22FormWorkHourLogDate, "99/99/99"));
         AV73OldDate = AV10date;
         AssignAttri("", false, "AV73OldDate", context.localUtil.Format(AV73OldDate, "99/99/99"));
         new getweeklyhours(context ).execute(  AV10date,  AV18EmployeeId, out  AV57weeklyTotal, out  AV8DailyTotal, out  AV74MonthlyTotal) ;
         lblWeeklytotal_Caption = ": "+AV57weeklyTotal;
         AssignProp("", false, lblWeeklytotal_Internalname, "Caption", lblWeeklytotal_Caption, true);
         lblDailytotal_Caption = ": "+AV8DailyTotal;
         AssignProp("", false, lblDailytotal_Internalname, "Caption", lblDailytotal_Caption, true);
         lblMonthlytotal_Caption = ": "+AV74MonthlyTotal;
         AssignProp("", false, lblMonthlytotal_Internalname, "Caption", lblMonthlytotal_Caption, true);
         /* Execute user subroutine: 'CLEARFORM' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E214A2( )
      {
         /* Update_Click Routine */
         returnInSub = false;
         AV27FormWorkHourLogId = A118WorkHourLogId;
         AssignAttri("", false, "AV27FormWorkHourLogId", StringUtil.LTrimStr( (decimal)(AV27FormWorkHourLogId), 10, 0));
         AV18EmployeeId = A106EmployeeId;
         AssignAttri("", false, "AV18EmployeeId", StringUtil.LTrimStr( (decimal)(AV18EmployeeId), 10, 0));
         AV22FormWorkHourLogDate = A119WorkHourLogDate;
         AssignAttri("", false, "AV22FormWorkHourLogDate", context.localUtil.Format(AV22FormWorkHourLogDate, "99/99/99"));
         AV26FormWorkHourLogHours = A121WorkHourLogHour;
         AssignAttri("", false, "AV26FormWorkHourLogHours", StringUtil.LTrimStr( (decimal)(AV26FormWorkHourLogHours), 4, 0));
         AV28FormWorkHourLogMinutes = A122WorkHourLogMinute;
         AssignAttri("", false, "AV28FormWorkHourLogMinutes", StringUtil.LTrimStr( (decimal)(AV28FormWorkHourLogMinutes), 4, 0));
         AV23FormWorkHourLogDescription = A123WorkHourLogDescription;
         AssignAttri("", false, "AV23FormWorkHourLogDescription", AV23FormWorkHourLogDescription);
         AV29FormWorkHourLogProjectId = A102ProjectId;
         AssignAttri("", false, "AV29FormWorkHourLogProjectId", StringUtil.LTrimStr( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
         Combo_employeeid_Selectedvalue_set = StringUtil.Str( (decimal)(AV18EmployeeId), 10, 0);
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
         dynload_actions( ) ;
         /*  Sending Event outputs  */
         dynavFormworkhourlogprojectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
         AssignProp("", false, dynavFormworkhourlogprojectid_Internalname, "Values", dynavFormworkhourlogprojectid.ToJavascriptSource(), true);
      }

      protected void E194A2( )
      {
         /* Delete_Click Routine */
         returnInSub = false;
         AV60WorkHourLog.Load(A118WorkHourLogId);
         if ( AV27FormWorkHourLogId == AV60WorkHourLog.gxTpr_Workhourlogid )
         {
            /* Execute user subroutine: 'CLEARFORM' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV60WorkHourLog.Delete();
         if ( AV60WorkHourLog.Success() )
         {
            context.CommitDataStores("logworkhours",pr_default);
            gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
            /* Execute user subroutine: 'CHANGINGDATA' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  "Work hour log deleted successfully",  "success",  "",  "true",  ""));
         }
         else
         {
            context.RollbackDataStores("logworkhours",pr_default);
            AV5Messages = AV60WorkHourLog.GetMessages();
            AV94GXV3 = 1;
            while ( AV94GXV3 <= AV5Messages.Count )
            {
               AV47message = ((GeneXus.Utils.SdtMessages_Message)AV5Messages.Item(AV94GXV3));
               GX_msglist.addItem(AV47message.gxTpr_Description);
               AV94GXV3 = (int)(AV94GXV3+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60WorkHourLog", AV60WorkHourLog);
      }

      protected void E124A2( )
      {
         /* Isloghouropen_Controlvaluechanged Routine */
         returnInSub = false;
         new switchtimetracker(context ).execute(  AV72IsLogHourOpen) ;
         lblTtopentext_Visible = (AV72IsLogHourOpen ? 1 : 0);
         AssignProp("", false, lblTtopentext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTtopentext_Visible), 5, 0), true);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E204A2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_boolean3 = AV72IsLogHourOpen;
         new istimetrackeropen(context ).execute( out  GXt_boolean3) ;
         AV72IsLogHourOpen = GXt_boolean3;
         AssignAttri("", false, "AV72IsLogHourOpen", AV72IsLogHourOpen);
         lblTtopentext_Visible = (AV72IsLogHourOpen ? 1 : 0);
         AssignProp("", false, lblTtopentext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTtopentext_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E164A2( )
      {
         /* Formworkhourlogprojectid_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADPROJECTSGRID' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV90projectList", AV90projectList);
      }

      protected void S112( )
      {
         /* 'CHANGINGDATA' Routine */
         returnInSub = false;
         new getweeklyhours(context ).execute(  AV10date,  AV18EmployeeId, out  AV57weeklyTotal, out  AV8DailyTotal, out  AV74MonthlyTotal) ;
         lblWeeklytotal_Caption = ": "+AV57weeklyTotal;
         AssignProp("", false, lblWeeklytotal_Internalname, "Caption", lblWeeklytotal_Caption, true);
         lblDailytotal_Caption = ": "+AV8DailyTotal;
         AssignProp("", false, lblDailytotal_Internalname, "Caption", lblDailytotal_Caption, true);
         lblMonthlytotal_Caption = ": "+AV74MonthlyTotal;
         AssignProp("", false, lblMonthlytotal_Internalname, "Caption", lblMonthlytotal_Caption, true);
         GXt_SdtWWPDateRangePickerOptions6 = AV69WWPDateRangePickerOptions;
         new dpdateformat(context ).execute(  AV18EmployeeId, out  GXt_SdtWWPDateRangePickerOptions6) ;
         AV69WWPDateRangePickerOptions = GXt_SdtWWPDateRangePickerOptions6;
         this.executeExternalObjectMethod("", false, "WWPActions", "DateTimePicker_SetOptions", new Object[] {(string)edtavDate_Internalname,AV69WWPDateRangePickerOptions.ToJSonString(false, true)}, false);
      }

      protected void S162( )
      {
         /* 'CLEARFORM' Routine */
         returnInSub = false;
         AV27FormWorkHourLogId = 0;
         AssignAttri("", false, "AV27FormWorkHourLogId", StringUtil.LTrimStr( (decimal)(AV27FormWorkHourLogId), 10, 0));
         AV22FormWorkHourLogDate = AV10date;
         AssignAttri("", false, "AV22FormWorkHourLogDate", context.localUtil.Format(AV22FormWorkHourLogDate, "99/99/99"));
         AV26FormWorkHourLogHours = 0;
         AssignAttri("", false, "AV26FormWorkHourLogHours", StringUtil.LTrimStr( (decimal)(AV26FormWorkHourLogHours), 4, 0));
         AV28FormWorkHourLogMinutes = 0;
         AssignAttri("", false, "AV28FormWorkHourLogMinutes", StringUtil.LTrimStr( (decimal)(AV28FormWorkHourLogMinutes), 4, 0));
         AV23FormWorkHourLogDescription = "";
         AssignAttri("", false, "AV23FormWorkHourLogDescription", AV23FormWorkHourLogDescription);
         AV24FormWorkHourLogDuration = "";
         AssignAttri("", false, "AV24FormWorkHourLogDuration", AV24FormWorkHourLogDuration);
      }

      protected void S152( )
      {
         /* 'INSERTRECORD' Routine */
         returnInSub = false;
         if ( (0==AV27FormWorkHourLogId) )
         {
            AV60WorkHourLog.Insert();
         }
         else
         {
            AV60WorkHourLog.Update();
         }
         if ( AV60WorkHourLog.Success() )
         {
            context.CommitDataStores("logworkhours",pr_default);
            /* Execute user subroutine: 'CLEARFORM' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'CHANGINGDATA' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid1_refresh( subGrid1_Rows, AV10date, AV18EmployeeId, Gx_date) ;
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  "Work hour log saved successfully",  "success",  "",  "true",  ""));
         }
         else
         {
            context.RollbackDataStores("logworkhours",pr_default);
            AV5Messages = AV60WorkHourLog.GetMessages();
            AV95GXV4 = 1;
            while ( AV95GXV4 <= AV5Messages.Count )
            {
               AV47message = ((GeneXus.Utils.SdtMessages_Message)AV5Messages.Item(AV95GXV4));
               GX_msglist.addItem(AV47message.gxTpr_Description);
               AV95GXV4 = (int)(AV95GXV4+1);
            }
         }
      }

      protected void S142( )
      {
         /* 'LOADPROJECTSGRID' Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem7 = AV88projects;
         new dpemployeetologhoursprojects(context ).execute(  AV18EmployeeId, out  GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem7) ;
         AV88projects = GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem7;
         AV96GXV5 = 1;
         while ( AV96GXV5 <= AV88projects.Count )
         {
            AV89projectItem = ((SdtSDTEmployeeProject_SDTEmployeeProjectItem)AV88projects.Item(AV96GXV5));
            AV90projectList.Add(AV89projectItem.gxTpr_Projectid, 0);
            AV96GXV5 = (int)(AV96GXV5+1);
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
         PA4A2( ) ;
         WS4A2( ) ;
         WE4A2( ) ;
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
         AddStyleSheetFile("Switch/switch.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241222145517", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("logworkhours.js", "?20241222145520", false, true);
            context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
            context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1132( )
      {
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_113_idx;
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE_"+sGXsfl_113_idx;
         edtProjectName_Internalname = "PROJECTNAME_"+sGXsfl_113_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_113_idx;
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION_"+sGXsfl_113_idx;
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION_"+sGXsfl_113_idx;
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR_"+sGXsfl_113_idx;
         edtWorkHourLogId_Internalname = "WORKHOURLOGID_"+sGXsfl_113_idx;
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE_"+sGXsfl_113_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_113_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_113_idx;
      }

      protected void SubsflControlProps_fel_1132( )
      {
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_113_fel_idx;
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE_"+sGXsfl_113_fel_idx;
         edtProjectName_Internalname = "PROJECTNAME_"+sGXsfl_113_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_113_fel_idx;
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION_"+sGXsfl_113_fel_idx;
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION_"+sGXsfl_113_fel_idx;
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR_"+sGXsfl_113_fel_idx;
         edtWorkHourLogId_Internalname = "WORKHOURLOGID_"+sGXsfl_113_fel_idx;
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE_"+sGXsfl_113_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_113_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_113_fel_idx;
      }

      protected void sendrow_1132( )
      {
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_1132( ) ;
         WB4A0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_113_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_113_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_113_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDate_Internalname,context.localUtil.Format(A119WorkHourLogDate, "99/99/99"),context.localUtil.Format( A119WorkHourLogDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnAlignLeft",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectName_Internalname,StringUtil.RTrim( A103ProjectName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDuration_Internalname,(string)A120WorkHourLogDuration,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDuration_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDescription_Internalname,(string)A123WorkHourLogDescription,(string)A123WorkHourLogDescription,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)113,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogHour_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogHour_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogMinute_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogMinute_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_113_idx + "',113)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV56update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"","'"+""+"'"+",false,"+"'"+"EVUPDATE.CLICK."+sGXsfl_113_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_113_idx + "',113)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV11delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"","'"+""+"'"+",false,"+"'"+"EVDELETE.CLICK."+sGXsfl_113_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4A2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_113_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_113_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1132( ) ;
         }
         /* End function sendrow_1132 */
      }

      protected void init_web_controls( )
      {
         dynavFormworkhourlogprojectid.Name = "vFORMWORKHOURLOGPROJECTID";
         dynavFormworkhourlogprojectid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl113( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"113\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Project Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Project") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Employee Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Duration") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Work Hour Log Hour") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Work Hour Log Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Work Hour Log Minute") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A119WorkHourLogDate, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A103ProjectName)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A120WorkHourLogDuration));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A123WorkHourLogDescription));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV56update)));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV11delete)));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            Grid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         Isloghouropen_Internalname = "ISLOGHOUROPEN";
         divIsloghouropen_cell_Internalname = "ISLOGHOUROPEN_CELL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblTtopentext_Internalname = "TTOPENTEXT";
         divUnnamedtable11_Internalname = "UNNAMEDTABLE11";
         edtavDate_Internalname = "vDATE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         lblTextblockcombo_employeeid_Internalname = "TEXTBLOCKCOMBO_EMPLOYEEID";
         Combo_employeeid_Internalname = "COMBO_EMPLOYEEID";
         divTablesplittedemployeeid_Internalname = "TABLESPLITTEDEMPLOYEEID";
         edtavFormworkhourlogdate_Internalname = "vFORMWORKHOURLOGDATE";
         dynavFormworkhourlogprojectid_Internalname = "vFORMWORKHOURLOGPROJECTID";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         edtavFormworkhourloghours_Internalname = "vFORMWORKHOURLOGHOURS";
         edtavFormworkhourlogminutes_Internalname = "vFORMWORKHOURLOGMINUTES";
         edtavFormworkhourlogdescription_Internalname = "vFORMWORKHOURLOGDESCRIPTION";
         bttBtnsave_Internalname = "BTNSAVE";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         divUnnamedtable9_Internalname = "UNNAMEDTABLE9";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblWeeklytotal_Internalname = "WEEKLYTOTAL";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblDailytotal_Internalname = "DAILYTOTAL";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblMonthlytotal_Internalname = "MONTHLYTOTAL";
         divUnnamedtable10_Internalname = "UNNAMEDTABLE10";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         divTabledetailattributes_Internalname = "TABLEDETAILATTRIBUTES";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         edtProjectId_Internalname = "PROJECTID";
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE";
         edtProjectName_Internalname = "PROJECTNAME";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION";
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION";
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR";
         edtWorkHourLogId_Internalname = "WORKHOURLOGID";
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divListlogs_Internalname = "LISTLOGS";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavEmployeeid_Internalname = "vEMPLOYEEID";
         edtavFormworkhourlogid_Internalname = "vFORMWORKHOURLOGID";
         edtavFormworkhourlogduration_Internalname = "vFORMWORKHOURLOGDURATION";
         Grid1_empowerer_Internalname = "GRID1_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Enabled = 1;
         edtavUpdate_Visible = -1;
         edtWorkHourLogMinute_Jsonclick = "";
         edtWorkHourLogId_Jsonclick = "";
         edtWorkHourLogHour_Jsonclick = "";
         edtWorkHourLogDescription_Jsonclick = "";
         edtWorkHourLogDuration_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtProjectName_Jsonclick = "";
         edtWorkHourLogDate_Jsonclick = "";
         edtProjectId_Jsonclick = "";
         subGrid1_Class = "WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtWorkHourLogMinute_Enabled = 0;
         edtWorkHourLogId_Enabled = 0;
         edtWorkHourLogHour_Enabled = 0;
         edtWorkHourLogDescription_Enabled = 0;
         edtWorkHourLogDuration_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtProjectName_Enabled = 0;
         edtWorkHourLogDate_Enabled = 0;
         edtProjectId_Enabled = 0;
         edtavFormworkhourlogduration_Jsonclick = "";
         edtavFormworkhourlogduration_Visible = 1;
         edtavFormworkhourlogid_Jsonclick = "";
         edtavFormworkhourlogid_Visible = 1;
         edtavEmployeeid_Jsonclick = "";
         edtavEmployeeid_Visible = 1;
         divUnnamedtable7_Height = 0;
         lblMonthlytotal_Caption = "Monthly Total";
         lblDailytotal_Caption = "Daily Total";
         lblWeeklytotal_Caption = "WeeklyTotal";
         divUnnamedtable10_Width = 0;
         divUnnamedtable9_Height = 0;
         edtavFormworkhourlogdescription_Enabled = 1;
         edtavFormworkhourlogminutes_Jsonclick = "";
         edtavFormworkhourlogminutes_Enabled = 1;
         edtavFormworkhourloghours_Jsonclick = "";
         edtavFormworkhourloghours_Enabled = 1;
         dynavFormworkhourlogprojectid_Jsonclick = "";
         dynavFormworkhourlogprojectid.Enabled = 1;
         edtavFormworkhourlogdate_Jsonclick = "";
         edtavFormworkhourlogdate_Enabled = 1;
         Combo_employeeid_Caption = "";
         edtavDate_Jsonclick = "";
         edtavDate_Enabled = 1;
         lblTtopentext_Visible = 1;
         divUnnamedtable11_Visible = 1;
         divUnnamedtable2_Height = 0;
         divIsloghouropen_cell_Class = "col-xs-6";
         divUnnamedtable1_Visible = 1;
         divUnnamedtable1_Width = 0;
         divTablecontent_Width = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Combo_employeeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_employeeid_Cls = "ExtendedCombo Attribute";
         Isloghouropen_Visible = Convert.ToBoolean( -1);
         Isloghouropen_Captionposition = "Left";
         Isloghouropen_Captionstyle = "";
         Isloghouropen_Captionclass = " isLogHourOpenLabel";
         Isloghouropen_Enabled = Convert.ToBoolean( -1);
         Isloghouropen_Checkedvalue = "true";
         Isloghouropen_Offtext = "OFF";
         Isloghouropen_Ontext = "ON";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Log Hours";
         subGrid1_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Employeeid( )
      {
         AV29FormWorkHourLogProjectId = (long)(Math.Round(NumberUtil.Val( dynavFormworkhourlogprojectid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         GXVvFORMWORKHOURLOGPROJECTID_html4A2( AV18EmployeeId) ;
         dynload_actions( ) ;
         if ( dynavFormworkhourlogprojectid.ItemCount > 0 )
         {
            AV29FormWorkHourLogProjectId = (long)(Math.Round(NumberUtil.Val( dynavFormworkhourlogprojectid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavFormworkhourlogprojectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV29FormWorkHourLogProjectId", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29FormWorkHourLogProjectId), 10, 0, ".", "")));
         dynavFormworkhourlogprojectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29FormWorkHourLogProjectId), 10, 0));
         AssignProp("", false, dynavFormworkhourlogprojectid_Internalname, "Values", dynavFormworkhourlogprojectid.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"},{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"}]}""");
         setEventMetadata("GRID1.LOAD","""{"handler":"E184A2","iparms":[{"av":"A119WorkHourLogDate","fld":"WORKHOURLOGDATE","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("GRID1.LOAD",""","oparms":[{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV56update","fld":"vUPDATE"},{"av":"AV11delete","fld":"vDELETE"}]}""");
         setEventMetadata("'DOSAVE'","""{"handler":"E144A2","iparms":[{"av":"AV26FormWorkHourLogHours","fld":"vFORMWORKHOURLOGHOURS","pic":"ZZZ9"},{"av":"AV28FormWorkHourLogMinutes","fld":"vFORMWORKHOURLOGMINUTES","pic":"ZZZ9"},{"av":"AV23FormWorkHourLogDescription","fld":"vFORMWORKHOURLOGDESCRIPTION"},{"av":"AV27FormWorkHourLogId","fld":"vFORMWORKHOURLOGID","pic":"ZZZZZZZZZ9"},{"av":"AV60WorkHourLog","fld":"vWORKHOURLOG"},{"av":"AV22FormWorkHourLogDate","fld":"vFORMWORKHOURLOGDATE"},{"av":"dynavFormworkhourlogprojectid"},{"av":"AV29FormWorkHourLogProjectId","fld":"vFORMWORKHOURLOGPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"}]""");
         setEventMetadata("'DOSAVE'",""","oparms":[{"av":"AV60WorkHourLog","fld":"vWORKHOURLOG"},{"av":"AV27FormWorkHourLogId","fld":"vFORMWORKHOURLOGID","pic":"ZZZZZZZZZ9"},{"av":"AV22FormWorkHourLogDate","fld":"vFORMWORKHOURLOGDATE"},{"av":"AV26FormWorkHourLogHours","fld":"vFORMWORKHOURLOGHOURS","pic":"ZZZ9"},{"av":"AV28FormWorkHourLogMinutes","fld":"vFORMWORKHOURLOGMINUTES","pic":"ZZZ9"},{"av":"AV23FormWorkHourLogDescription","fld":"vFORMWORKHOURLOGDESCRIPTION"},{"av":"AV24FormWorkHourLogDuration","fld":"vFORMWORKHOURLOGDURATION"},{"av":"lblWeeklytotal_Caption","ctrl":"WEEKLYTOTAL","prop":"Caption"},{"av":"lblDailytotal_Caption","ctrl":"DAILYTOTAL","prop":"Caption"},{"av":"lblMonthlytotal_Caption","ctrl":"MONTHLYTOTAL","prop":"Caption"},{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"},{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E114A1","iparms":[{"av":"AV10date","fld":"vDATE"}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"av":"AV27FormWorkHourLogId","fld":"vFORMWORKHOURLOGID","pic":"ZZZZZZZZZ9"},{"av":"AV22FormWorkHourLogDate","fld":"vFORMWORKHOURLOGDATE"},{"av":"AV26FormWorkHourLogHours","fld":"vFORMWORKHOURLOGHOURS","pic":"ZZZ9"},{"av":"AV28FormWorkHourLogMinutes","fld":"vFORMWORKHOURLOGMINUTES","pic":"ZZZ9"},{"av":"AV23FormWorkHourLogDescription","fld":"vFORMWORKHOURLOGDESCRIPTION"},{"av":"AV24FormWorkHourLogDuration","fld":"vFORMWORKHOURLOGDURATION"}]}""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED","""{"handler":"E134A2","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"Combo_employeeid_Selectedvalue_get","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV27FormWorkHourLogId","fld":"vFORMWORKHOURLOGID","pic":"ZZZZZZZZZ9"},{"av":"AV22FormWorkHourLogDate","fld":"vFORMWORKHOURLOGDATE"},{"av":"AV26FormWorkHourLogHours","fld":"vFORMWORKHOURLOGHOURS","pic":"ZZZ9"},{"av":"AV28FormWorkHourLogMinutes","fld":"vFORMWORKHOURLOGMINUTES","pic":"ZZZ9"},{"av":"AV23FormWorkHourLogDescription","fld":"vFORMWORKHOURLOGDESCRIPTION"},{"av":"AV24FormWorkHourLogDuration","fld":"vFORMWORKHOURLOGDURATION"},{"av":"lblWeeklytotal_Caption","ctrl":"WEEKLYTOTAL","prop":"Caption"},{"av":"lblDailytotal_Caption","ctrl":"DAILYTOTAL","prop":"Caption"},{"av":"lblMonthlytotal_Caption","ctrl":"MONTHLYTOTAL","prop":"Caption"},{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"},{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"}]}""");
         setEventMetadata("VDATE.CONTROLVALUECHANGED","""{"handler":"E154A2","iparms":[{"av":"AV10date","fld":"vDATE"},{"av":"AV73OldDate","fld":"vOLDDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VDATE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV10date","fld":"vDATE"},{"av":"AV22FormWorkHourLogDate","fld":"vFORMWORKHOURLOGDATE"},{"av":"AV73OldDate","fld":"vOLDDATE"},{"av":"lblWeeklytotal_Caption","ctrl":"WEEKLYTOTAL","prop":"Caption"},{"av":"lblDailytotal_Caption","ctrl":"DAILYTOTAL","prop":"Caption"},{"av":"lblMonthlytotal_Caption","ctrl":"MONTHLYTOTAL","prop":"Caption"},{"av":"AV27FormWorkHourLogId","fld":"vFORMWORKHOURLOGID","pic":"ZZZZZZZZZ9"},{"av":"AV26FormWorkHourLogHours","fld":"vFORMWORKHOURLOGHOURS","pic":"ZZZ9"},{"av":"AV28FormWorkHourLogMinutes","fld":"vFORMWORKHOURLOGMINUTES","pic":"ZZZ9"},{"av":"AV23FormWorkHourLogDescription","fld":"vFORMWORKHOURLOGDESCRIPTION"},{"av":"AV24FormWorkHourLogDuration","fld":"vFORMWORKHOURLOGDURATION"}]}""");
         setEventMetadata("VUPDATE.CLICK","""{"handler":"E214A2","iparms":[{"av":"A118WorkHourLogId","fld":"WORKHOURLOGID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A119WorkHourLogDate","fld":"WORKHOURLOGDATE","hsh":true},{"av":"A121WorkHourLogHour","fld":"WORKHOURLOGHOUR","pic":"ZZZ9","hsh":true},{"av":"A122WorkHourLogMinute","fld":"WORKHOURLOGMINUTE","pic":"ZZZ9","hsh":true},{"av":"A123WorkHourLogDescription","fld":"WORKHOURLOGDESCRIPTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VUPDATE.CLICK",""","oparms":[{"av":"AV27FormWorkHourLogId","fld":"vFORMWORKHOURLOGID","pic":"ZZZZZZZZZ9"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV22FormWorkHourLogDate","fld":"vFORMWORKHOURLOGDATE"},{"av":"AV26FormWorkHourLogHours","fld":"vFORMWORKHOURLOGHOURS","pic":"ZZZ9"},{"av":"AV28FormWorkHourLogMinutes","fld":"vFORMWORKHOURLOGMINUTES","pic":"ZZZ9"},{"av":"AV23FormWorkHourLogDescription","fld":"vFORMWORKHOURLOGDESCRIPTION"},{"av":"dynavFormworkhourlogprojectid"},{"av":"AV29FormWorkHourLogProjectId","fld":"vFORMWORKHOURLOGPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("VDELETE.CLICK","""{"handler":"E194A2","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"A118WorkHourLogId","fld":"WORKHOURLOGID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV27FormWorkHourLogId","fld":"vFORMWORKHOURLOGID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VDELETE.CLICK",""","oparms":[{"av":"AV60WorkHourLog","fld":"vWORKHOURLOG"},{"av":"AV27FormWorkHourLogId","fld":"vFORMWORKHOURLOGID","pic":"ZZZZZZZZZ9"},{"av":"AV22FormWorkHourLogDate","fld":"vFORMWORKHOURLOGDATE"},{"av":"AV26FormWorkHourLogHours","fld":"vFORMWORKHOURLOGHOURS","pic":"ZZZ9"},{"av":"AV28FormWorkHourLogMinutes","fld":"vFORMWORKHOURLOGMINUTES","pic":"ZZZ9"},{"av":"AV23FormWorkHourLogDescription","fld":"vFORMWORKHOURLOGDESCRIPTION"},{"av":"AV24FormWorkHourLogDuration","fld":"vFORMWORKHOURLOGDURATION"},{"av":"lblWeeklytotal_Caption","ctrl":"WEEKLYTOTAL","prop":"Caption"},{"av":"lblDailytotal_Caption","ctrl":"DAILYTOTAL","prop":"Caption"},{"av":"lblMonthlytotal_Caption","ctrl":"MONTHLYTOTAL","prop":"Caption"},{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"},{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"}]}""");
         setEventMetadata("VISLOGHOUROPEN.CONTROLVALUECHANGED","""{"handler":"E124A2","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"}]""");
         setEventMetadata("VISLOGHOUROPEN.CONTROLVALUECHANGED",""","oparms":[{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"},{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"}]}""");
         setEventMetadata("VFORMWORKHOURLOGPROJECTID.CONTROLVALUECHANGED","""{"handler":"E164A2","iparms":[{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV90projectList","fld":"vPROJECTLIST"}]""");
         setEventMetadata("VFORMWORKHOURLOGPROJECTID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV90projectList","fld":"vPROJECTLIST"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("GRID1_FIRSTPAGE",""","oparms":[{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"},{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("GRID1_PREVPAGE",""","oparms":[{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"},{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("GRID1_NEXTPAGE",""","oparms":[{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"},{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10date","fld":"vDATE"},{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("GRID1_LASTPAGE",""","oparms":[{"av":"AV72IsLogHourOpen","fld":"vISLOGHOUROPEN"},{"av":"lblTtopentext_Visible","ctrl":"TTOPENTEXT","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_EMPLOYEEID","""{"handler":"Validv_Employeeid","iparms":[{"av":"AV18EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynavFormworkhourlogprojectid"},{"av":"AV29FormWorkHourLogProjectId","fld":"vFORMWORKHOURLOGPROJECTID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VALIDV_EMPLOYEEID",""","oparms":[{"av":"dynavFormworkhourlogprojectid"},{"av":"AV29FormWorkHourLogProjectId","fld":"vFORMWORKHOURLOGPROJECTID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_PROJECTID","""{"handler":"Valid_Projectid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV10date = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV72IsLogHourOpen = false;
         AV86DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV81EmployeeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV60WorkHourLog = new SdtWorkHourLog(context);
         AV73OldDate = DateTime.MinValue;
         AV90projectList = new GxSimpleCollection<long>();
         Combo_employeeid_Selectedvalue_set = "";
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucIsloghouropen = new GXUserControl();
         lblTtopentext_Jsonclick = "";
         TempTags = "";
         lblTextblockcombo_employeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         AV22FormWorkHourLogDate = DateTime.MinValue;
         AV23FormWorkHourLogDescription = "";
         bttBtnsave_Jsonclick = "";
         bttBtnuseraction1_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblWeeklytotal_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblDailytotal_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblMonthlytotal_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         AV24FormWorkHourLogDuration = "";
         ucGrid1_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A119WorkHourLogDate = DateTime.MinValue;
         A103ProjectName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         AV56update = "";
         AV11delete = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H004A2_A122WorkHourLogMinute = new short[1] ;
         H004A2_A118WorkHourLogId = new long[1] ;
         H004A2_A121WorkHourLogHour = new short[1] ;
         H004A2_A123WorkHourLogDescription = new string[] {""} ;
         H004A2_A120WorkHourLogDuration = new string[] {""} ;
         H004A2_A106EmployeeId = new long[1] ;
         H004A2_A103ProjectName = new string[] {""} ;
         H004A2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         H004A2_A102ProjectId = new long[1] ;
         H004A3_AGRID1_nRecordCount = new long[1] ;
         GXt_date2 = DateTime.MinValue;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Grid1Row = new GXWebRow();
         AV55trimmedhour = "";
         AV92GXV1 = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4");
         GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem5 = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4");
         AV87EmployeeId_DPItem = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(context);
         AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV57weeklyTotal = "";
         AV8DailyTotal = "";
         AV74MonthlyTotal = "";
         AV5Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV47message = new GeneXus.Utils.SdtMessages_Message(context);
         AV69WWPDateRangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         GXt_SdtWWPDateRangePickerOptions6 = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV88projects = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4");
         GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem7 = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4");
         AV89projectItem = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.logworkhours__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.logworkhours__default(),
            new Object[][] {
                new Object[] {
               H004A2_A122WorkHourLogMinute, H004A2_A118WorkHourLogId, H004A2_A121WorkHourLogHour, H004A2_A123WorkHourLogDescription, H004A2_A120WorkHourLogDuration, H004A2_A106EmployeeId, H004A2_A103ProjectName, H004A2_A119WorkHourLogDate, H004A2_A102ProjectId
               }
               , new Object[] {
               H004A3_AGRID1_nRecordCount
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavFormworkhourlogdate_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short AV26FormWorkHourLogHours ;
      private short AV28FormWorkHourLogMinutes ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_113 ;
      private int subGrid1_Rows ;
      private int nGXsfl_113_idx=1 ;
      private int divTablecontent_Width ;
      private int divUnnamedtable1_Visible ;
      private int divUnnamedtable1_Width ;
      private int divUnnamedtable2_Height ;
      private int divUnnamedtable11_Visible ;
      private int lblTtopentext_Visible ;
      private int edtavDate_Enabled ;
      private int edtavFormworkhourlogdate_Enabled ;
      private int edtavFormworkhourloghours_Enabled ;
      private int edtavFormworkhourlogminutes_Enabled ;
      private int edtavFormworkhourlogdescription_Enabled ;
      private int divUnnamedtable9_Height ;
      private int divUnnamedtable10_Width ;
      private int divUnnamedtable7_Height ;
      private int edtavEmployeeid_Visible ;
      private int edtavFormworkhourlogid_Visible ;
      private int edtavFormworkhourlogduration_Visible ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtProjectId_Enabled ;
      private int edtWorkHourLogDate_Enabled ;
      private int edtProjectName_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtWorkHourLogDuration_Enabled ;
      private int edtWorkHourLogDescription_Enabled ;
      private int edtWorkHourLogHour_Enabled ;
      private int edtWorkHourLogId_Enabled ;
      private int edtWorkHourLogMinute_Enabled ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV93GXV2 ;
      private int AV94GXV3 ;
      private int AV95GXV4 ;
      private int AV96GXV5 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV18EmployeeId ;
      private long AV29FormWorkHourLogProjectId ;
      private long AV27FormWorkHourLogId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private long AV25FormWorkHourLogEmployeeId ;
      private long AV42LastLoggedProjectId ;
      private long GXt_int1 ;
      private long AV20FormHourWorkLogId ;
      private long ZV29FormWorkHourLogProjectId ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_113_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Isloghouropen_Ontext ;
      private string Isloghouropen_Offtext ;
      private string Isloghouropen_Checkedvalue ;
      private string Isloghouropen_Captionclass ;
      private string Isloghouropen_Captionstyle ;
      private string Isloghouropen_Captionposition ;
      private string Combo_employeeid_Cls ;
      private string Combo_employeeid_Selectedvalue_set ;
      private string Grid1_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divIsloghouropen_cell_Internalname ;
      private string divIsloghouropen_cell_Class ;
      private string Isloghouropen_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtable11_Internalname ;
      private string lblTtopentext_Internalname ;
      private string lblTtopentext_Jsonclick ;
      private string edtavDate_Internalname ;
      private string TempTags ;
      private string edtavDate_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divTabledetailattributes_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string divTablesplittedemployeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Jsonclick ;
      private string Combo_employeeid_Caption ;
      private string Combo_employeeid_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string edtavFormworkhourlogdate_Internalname ;
      private string edtavFormworkhourlogdate_Jsonclick ;
      private string dynavFormworkhourlogprojectid_Internalname ;
      private string dynavFormworkhourlogprojectid_Jsonclick ;
      private string edtavFormworkhourloghours_Internalname ;
      private string edtavFormworkhourloghours_Jsonclick ;
      private string edtavFormworkhourlogminutes_Internalname ;
      private string edtavFormworkhourlogminutes_Jsonclick ;
      private string edtavFormworkhourlogdescription_Internalname ;
      private string bttBtnsave_Internalname ;
      private string bttBtnsave_Jsonclick ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string divUnnamedtable9_Internalname ;
      private string divUnnamedtable10_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblWeeklytotal_Internalname ;
      private string lblWeeklytotal_Caption ;
      private string lblWeeklytotal_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblDailytotal_Internalname ;
      private string lblDailytotal_Caption ;
      private string lblDailytotal_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string lblMonthlytotal_Internalname ;
      private string lblMonthlytotal_Caption ;
      private string lblMonthlytotal_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string divListlogs_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavEmployeeid_Internalname ;
      private string edtavEmployeeid_Jsonclick ;
      private string edtavFormworkhourlogid_Internalname ;
      private string edtavFormworkhourlogid_Jsonclick ;
      private string edtavFormworkhourlogduration_Internalname ;
      private string edtavFormworkhourlogduration_Jsonclick ;
      private string Grid1_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProjectId_Internalname ;
      private string edtWorkHourLogDate_Internalname ;
      private string A103ProjectName ;
      private string edtProjectName_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtWorkHourLogDuration_Internalname ;
      private string edtWorkHourLogDescription_Internalname ;
      private string edtWorkHourLogHour_Internalname ;
      private string edtWorkHourLogId_Internalname ;
      private string edtWorkHourLogMinute_Internalname ;
      private string AV56update ;
      private string edtavUpdate_Internalname ;
      private string AV11delete ;
      private string edtavDelete_Internalname ;
      private string gxwrpcisep ;
      private string AV57weeklyTotal ;
      private string sGXsfl_113_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtProjectId_Jsonclick ;
      private string edtWorkHourLogDate_Jsonclick ;
      private string edtProjectName_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtWorkHourLogDuration_Jsonclick ;
      private string edtWorkHourLogDescription_Jsonclick ;
      private string edtWorkHourLogHour_Jsonclick ;
      private string edtWorkHourLogId_Jsonclick ;
      private string edtWorkHourLogMinute_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV10date ;
      private DateTime Gx_date ;
      private DateTime AV73OldDate ;
      private DateTime AV22FormWorkHourLogDate ;
      private DateTime A119WorkHourLogDate ;
      private DateTime GXt_date2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV72IsLogHourOpen ;
      private bool Isloghouropen_Enabled ;
      private bool Isloghouropen_Visible ;
      private bool Combo_employeeid_Emptyitem ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_113_Refreshing=false ;
      private bool returnInSub ;
      private bool AV21formIsValid ;
      private bool AV6CheckRequiredFieldsResult ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string AV23FormWorkHourLogDescription ;
      private string A123WorkHourLogDescription ;
      private string AV24FormWorkHourLogDuration ;
      private string A120WorkHourLogDuration ;
      private string AV55trimmedhour ;
      private string AV8DailyTotal ;
      private string AV74MonthlyTotal ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucIsloghouropen ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucGrid1_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavFormworkhourlogprojectid ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV86DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV81EmployeeId_Data ;
      private SdtWorkHourLog AV60WorkHourLog ;
      private GxSimpleCollection<long> AV90projectList ;
      private IDataStoreProvider pr_default ;
      private short[] H004A2_A122WorkHourLogMinute ;
      private long[] H004A2_A118WorkHourLogId ;
      private short[] H004A2_A121WorkHourLogHour ;
      private string[] H004A2_A123WorkHourLogDescription ;
      private string[] H004A2_A120WorkHourLogDuration ;
      private long[] H004A2_A106EmployeeId ;
      private string[] H004A2_A103ProjectName ;
      private DateTime[] H004A2_A119WorkHourLogDate ;
      private long[] H004A2_A102ProjectId ;
      private long[] H004A3_AGRID1_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 ;
      private GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> AV92GXV1 ;
      private GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem5 ;
      private SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem AV87EmployeeId_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV7Combo_DataItem ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV5Messages ;
      private GeneXus.Utils.SdtMessages_Message AV47message ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV69WWPDateRangePickerOptions ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions6 ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> AV88projects ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem7 ;
      private SdtSDTEmployeeProject_SDTEmployeeProjectItem AV89projectItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class logworkhours__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class logworkhours__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H004A2( IGxContext context ,
                                           long A102ProjectId ,
                                           GxSimpleCollection<long> AV90projectList ,
                                           long A106EmployeeId ,
                                           long AV18EmployeeId ,
                                           DateTime A119WorkHourLogDate ,
                                           DateTime AV10date )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int8 = new short[5];
       Object[] GXv_Object9 = new Object[2];
       string sSelectString;
       string sFromString;
       string sOrderString;
       sSelectString = " T1.WorkHourLogMinute, T1.WorkHourLogId, T1.WorkHourLogHour, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.EmployeeId, T2.ProjectName, T1.WorkHourLogDate, T1.ProjectId";
       sFromString = " FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
       sOrderString = "";
       AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90projectList, "T1.ProjectId IN (", ")")+")");
       AddWhere(sWhereString, "(T1.EmployeeId = :AV18EmployeeId)");
       AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV10date)");
       sOrderString += " ORDER BY T1.WorkHourLogId DESC";
       scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
       GXv_Object9[0] = scmdbuf;
       GXv_Object9[1] = GXv_int8;
       return GXv_Object9 ;
    }

    protected Object[] conditional_H004A3( IGxContext context ,
                                           long A102ProjectId ,
                                           GxSimpleCollection<long> AV90projectList ,
                                           long A106EmployeeId ,
                                           long AV18EmployeeId ,
                                           DateTime A119WorkHourLogDate ,
                                           DateTime AV10date )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int10 = new short[2];
       Object[] GXv_Object11 = new Object[2];
       scmdbuf = "SELECT COUNT(*) FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
       AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90projectList, "T1.ProjectId IN (", ")")+")");
       AddWhere(sWhereString, "(T1.EmployeeId = :AV18EmployeeId)");
       AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV10date)");
       scmdbuf += sWhereString;
       GXv_Object11[0] = scmdbuf;
       GXv_Object11[1] = GXv_int10;
       return GXv_Object11 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H004A2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] );
             case 1 :
                   return conditional_H004A3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] );
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
        Object[] prmH004A2;
        prmH004A2 = new Object[] {
        new ParDef("AV18EmployeeId",GXType.Int64,10,0) ,
        new ParDef("AV10date",GXType.Date,8,0) ,
        new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo2",GXType.Int32,9,0)
        };
        Object[] prmH004A3;
        prmH004A3 = new Object[] {
        new ParDef("AV18EmployeeId",GXType.Int64,10,0) ,
        new ParDef("AV10date",GXType.Date,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("H004A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004A2,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004A3,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
