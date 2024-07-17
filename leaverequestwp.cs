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
   public class leaverequestwp : GXDataArea
   {
      public leaverequestwp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestwp( IGxContext context )
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
         dynavLeaverequest_employeeid = new GXCombobox();
         dynavLeaverequest_leavetypeid = new GXCombobox();
         radavLeaverequest_leaverequesthalfday = new GXRadio();
         dynavLeaverequest_holidays__holidayid = new GXCombobox();
         chkavLeaverequest_holidays__isapplicable = new GXCheckbox();
         cmbavLeaverequest_leaverequeststatus = new GXCombobox();
         radavLeaverequest_leavetypevacationleave = new GXRadio();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_holidays") == 0 )
            {
               gxnrGridlevel_holidays_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridlevel_holidays") == 0 )
            {
               gxgrGridlevel_holidays_refresh_invoke( ) ;
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

      protected void gxnrGridlevel_holidays_newrow_invoke( )
      {
         nRC_GXsfl_58 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_58"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_58_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_58_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_58_idx = GetPar( "sGXsfl_58_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_holidays_newrow( ) ;
         /* End function gxnrGridlevel_holidays_newrow_invoke */
      }

      protected void gxgrGridlevel_holidays_refresh_invoke( )
      {
         subGridlevel_holidays_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlevel_holidays_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavLeaverequest_leavetypeid.FromJSonString( GetNextPar( ));
         AV7LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         dynavLeaverequest_employeeid.FromJSonString( GetNextPar( ));
         AV7LeaveRequest.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AV7LeaveRequest.gxTpr_Leaverequesthalfday = GetNextPar( );
         AV7LeaveRequest.gxTpr_Leavetypevacationleave = GetNextPar( );
         AV11TrnMode = GetPar( "TrnMode");
         AV15LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridlevel_holidays_refresh_invoke */
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
         PA5G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5G2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leaverequestwp.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11TrnMode)),UrlEncode(StringUtil.LTrimStr(AV15LeaveRequestId,10,0))}, new string[] {"TrnMode","LeaveRequestId"}) +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Leaverequest", AV7LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Leaverequest", AV7LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_58", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_58), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vSTARTDATE", context.localUtil.DToC( AV20StartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vSTARTDATE_TO", context.localUtil.DToC( AV22StartDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV13CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV10Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV10Messages);
         }
         GxWebStd.gx_hidden_field( context, "HOLIDAYSTARTDATE", context.localUtil.DToC( A115HolidayStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "HOLIDAYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A113HolidayId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHOLIDAY", AV19Holiday);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHOLIDAY", AV19Holiday);
         }
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nEOF), 1, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVEREQUEST", AV7LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVEREQUEST", AV7LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridlevel_holidays_empowerer_Gridinternalname));
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
            WE5G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5G2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("leaverequestwp.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11TrnMode)),UrlEncode(StringUtil.LTrimStr(AV15LeaveRequestId,10,0))}, new string[] {"TrnMode","LeaveRequestId"})  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveRequestWP" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Request WP" ;
      }

      protected void WB5G0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3 hidden-xs hidden-sm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLefttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, divTablecontent_Width, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavLeaverequest_employeeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLeaverequest_employeeid_Internalname, "Employee Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_58_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLeaverequest_employeeid, dynavLeaverequest_employeeid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Employeeid), 10, 0)), 1, dynavLeaverequest_employeeid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavLeaverequest_employeeid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 0, "HLP_LeaveRequestWP.htm");
            dynavLeaverequest_employeeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Employeeid), 10, 0));
            AssignProp("", false, dynavLeaverequest_employeeid_Internalname, "Values", (string)(dynavLeaverequest_employeeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavLeaverequest_leavetypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLeaverequest_leavetypeid_Internalname, "Leave Type Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_58_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLeaverequest_leavetypeid, dynavLeaverequest_leavetypeid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Leavetypeid), 10, 0)), 1, dynavLeaverequest_leavetypeid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavLeaverequest_leavetypeid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_LeaveRequestWP.htm");
            dynavLeaverequest_leavetypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Leavetypeid), 10, 0));
            AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Values", (string)(dynavLeaverequest_leavetypeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavStartdate_rangetext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStartdate_rangetext_Internalname, "Start Date", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStartdate_rangetext_Internalname, AV21StartDate_RangeText, StringUtil.RTrim( context.localUtil.Format( AV21StartDate_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStartdate_rangetext_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavStartdate_rangetext_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavLeaverequest_leaverequesthalfday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Half Day", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leaverequesthalfday, radavLeaverequest_leaverequesthalfday_Internalname, StringUtil.RTrim( AV7LeaveRequest.gxTpr_Leaverequesthalfday), "", 1, radavLeaverequest_leaverequesthalfday.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leaverequesthalfday_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDuration_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDuration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV23Duration, 4, 1, ".", "")), StringUtil.LTrim( ((edtavDuration_Enabled!=0) ? context.localUtil.Format( AV23Duration, "Z9.9") : context.localUtil.Format( AV23Duration, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDuration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDuration_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestdescription_Internalname, "Request Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_58_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestdescription_Internalname, AV7LeaveRequest.gxTpr_Leaverequestdescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtavLeaverequest_leaverequestdescription_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeebalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeebalance_Internalname, "Employee Balance", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7LeaveRequest.gxTpr_Employeebalance, 4, 1, ".", "")), StringUtil.LTrim( context.localUtil.Format( AV7LeaveRequest.gxTpr_Employeebalance, "Z9.9")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeebalance_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestWP.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleaflevel_holidays_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridlevel_holidaysContainer.SetWrapped(nGXWrapped);
            StartGridControl58( ) ;
         }
         if ( wbEnd == 58 )
         {
            wbEnd = 0;
            nRC_GXsfl_58 = (int)(nGXsfl_58_idx-1);
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridlevel_holidaysContainer.AddObjectProperty("GRIDLEVEL_HOLIDAYS_nEOF", GRIDLEVEL_HOLIDAYS_nEOF);
               Gridlevel_holidaysContainer.AddObjectProperty("GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
               AV29GXV6 = nGXsfl_58_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Gridlevel_holidaysContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_holidays", Gridlevel_holidaysContainer, subGridlevel_holidays_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridlevel_holidaysContainerData", Gridlevel_holidaysContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridlevel_holidaysContainerData"+"V", Gridlevel_holidaysContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_holidaysContainerData"+"V"+"\" value='"+Gridlevel_holidaysContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(58), 2, 0)+","+"null"+");", "Confirm", bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(58), 2, 0)+","+"null"+");", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3 hidden-xs hidden-sm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRighttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            ucStartdate_rangepicker.SetProperty("Start Date", AV20StartDate);
            ucStartdate_rangepicker.SetProperty("End Date", AV22StartDate_To);
            ucStartdate_rangepicker.Render(context, "wwp.daterangepicker", Startdate_rangepicker_Internalname, "STARTDATE_RANGEPICKERContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7LeaveRequest.gxTpr_Leaverequestid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7LeaveRequest.gxTpr_Leaverequestid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestWP.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leavetypename_Internalname, StringUtil.RTrim( AV7LeaveRequest.gxTpr_Leavetypename), StringUtil.RTrim( context.localUtil.Format( AV7LeaveRequest.gxTpr_Leavetypename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leavetypename_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leavetypename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestWP.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_58_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestdate_Internalname, context.localUtil.Format(AV7LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), context.localUtil.Format( AV7LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestdate_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestdate_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavLeaverequest_leaverequestdate_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequestWP.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_58_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequeststartdate_Internalname, context.localUtil.Format(AV7LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), context.localUtil.Format( AV7LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequeststartdate_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequeststartdate_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavLeaverequest_leaverequeststartdate_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequestWP.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_58_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestenddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestenddate_Internalname, context.localUtil.Format(AV7LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), context.localUtil.Format( AV7LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestenddate_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestenddate_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestWP.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestenddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavLeaverequest_leaverequestenddate_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequestWP.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestduration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7LeaveRequest.gxTpr_Leaverequestduration, 4, 1, ".", "")), StringUtil.LTrim( context.localUtil.Format( AV7LeaveRequest.gxTpr_Leaverequestduration, "Z9.9")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestduration_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestduration_Visible, 1, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestWP.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_58_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLeaverequest_leaverequeststatus, cmbavLeaverequest_leaverequeststatus_Internalname, StringUtil.RTrim( AV7LeaveRequest.gxTpr_Leaverequeststatus), 1, cmbavLeaverequest_leaverequeststatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavLeaverequest_leaverequeststatus.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "", true, 0, "HLP_LeaveRequestWP.htm");
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV7LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", (string)(cmbavLeaverequest_leaverequeststatus.ToJavascriptSource()), true);
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_58_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, AV7LeaveRequest.gxTpr_Leaverequestrejectionreason, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", 0, edtavLeaverequest_leaverequestrejectionreason_Visible, 1, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LeaveRequestWP.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeename_Internalname, StringUtil.RTrim( AV7LeaveRequest.gxTpr_Employeename), StringUtil.RTrim( context.localUtil.Format( AV7LeaveRequest.gxTpr_Employeename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeename_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_employeename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestWP.htm");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_58_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leavetypevacationleave, radavLeaverequest_leavetypevacationleave_Internalname, StringUtil.RTrim( AV7LeaveRequest.gxTpr_Leavetypevacationleave), "", radavLeaverequest_leavetypevacationleave.Visible, 1, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leavetypevacationleave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "HLP_LeaveRequestWP.htm");
            /* User Defined Control */
            ucGridlevel_holidays_empowerer.Render(context, "wwp.gridempowerer", Gridlevel_holidays_empowerer_Internalname, "GRIDLEVEL_HOLIDAYS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 58 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridlevel_holidaysContainer.AddObjectProperty("GRIDLEVEL_HOLIDAYS_nEOF", GRIDLEVEL_HOLIDAYS_nEOF);
                  Gridlevel_holidaysContainer.AddObjectProperty("GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
                  AV29GXV6 = nGXsfl_58_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Gridlevel_holidaysContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_holidays", Gridlevel_holidaysContainer, subGridlevel_holidays_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridlevel_holidaysContainerData", Gridlevel_holidaysContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridlevel_holidaysContainerData"+"V", Gridlevel_holidaysContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_holidaysContainerData"+"V"+"\" value='"+Gridlevel_holidaysContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5G2( )
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
         Form.Meta.addItem("description", "Leave Request WP", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5G0( ) ;
      }

      protected void WS5G2( )
      {
         START5G2( ) ;
         EVT5G2( ) ;
      }

      protected void EVT5G2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "STARTDATE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E115G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E125G2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E135G2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_HOLIDAYSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDLEVEL_HOLIDAYSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridlevel_holidays_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridlevel_holidays_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridlevel_holidays_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridlevel_holidays_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "GRIDLEVEL_HOLIDAYS.LOAD") == 0 ) )
                           {
                              nGXsfl_58_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
                              SubsflControlProps_582( ) ;
                              AV29GXV6 = (int)(nGXsfl_58_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
                              if ( ( AV7LeaveRequest.gxTpr_Holidays.Count >= AV29GXV6 ) && ( AV29GXV6 > 0 ) )
                              {
                                 AV7LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E145G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_HOLIDAYS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E155G2 ();
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

      protected void WE5G2( )
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

      protected void PA5G2( )
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
               GX_FocusControl = dynavLeaverequest_employeeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVLEAVEREQUEST_LEAVETYPEID5G1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVLEAVEREQUEST_LEAVETYPEID_data5G1( ) ;
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

      protected void GXVLEAVEREQUEST_LEAVETYPEID_html5G1( )
      {
         long gxdynajaxvalue;
         GXDLVLEAVEREQUEST_LEAVETYPEID_data5G1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLeaverequest_leavetypeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
            AV7LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVLEAVEREQUEST_LEAVETYPEID_data5G1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H005G2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005G2_A124LeaveTypeId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H005G2_A125LeaveTypeName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVLEAVEREQUEST_EMPLOYEEID5G1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVLEAVEREQUEST_EMPLOYEEID_data5G1( ) ;
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

      protected void GXVLEAVEREQUEST_EMPLOYEEID_html5G1( )
      {
         long gxdynajaxvalue;
         GXDLVLEAVEREQUEST_EMPLOYEEID_data5G1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLeaverequest_employeeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLeaverequest_employeeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLeaverequest_employeeid.ItemCount > 0 )
         {
            AV7LeaveRequest.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_employeeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Employeeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVLEAVEREQUEST_EMPLOYEEID_data5G1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H005G3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005G3_A106EmployeeId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H005G3_A148EmployeeName[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGridlevel_holidays_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_582( ) ;
         while ( nGXsfl_58_idx <= nRC_GXsfl_58 )
         {
            sendrow_582( ) ;
            nGXsfl_58_idx = ((subGridlevel_holidays_Islastpage==1)&&(nGXsfl_58_idx+1>subGridlevel_holidays_fnc_Recordsperpage( )) ? 1 : nGXsfl_58_idx+1);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
            SubsflControlProps_582( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_holidaysContainer)) ;
         /* End function gxnrGridlevel_holidays_newrow */
      }

      protected void gxgrGridlevel_holidays_refresh( int subGridlevel_holidays_Rows ,
                                                     long GXV2 ,
                                                     long GXV1 ,
                                                     string GXV3 ,
                                                     string GXV18 ,
                                                     string AV11TrnMode ,
                                                     long AV15LeaveRequestId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDLEVEL_HOLIDAYS_nCurrentRecord = 0;
         RF5G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridlevel_holidays_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavLeaverequest_leavetypeid.Name = "LEAVEREQUEST_LEAVETYPEID";
            dynavLeaverequest_leavetypeid.WebTags = "";
            dynavLeaverequest_leavetypeid.removeAllItems();
            /* Using cursor H005G4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005G4_A124LeaveTypeId[0]), 10, 0)), H005G4_A125LeaveTypeName[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
            {
               AV7LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
            }
            dynavLeaverequest_employeeid.Name = "LEAVEREQUEST_EMPLOYEEID";
            dynavLeaverequest_employeeid.WebTags = "";
            dynavLeaverequest_employeeid.removeAllItems();
            /* Using cursor H005G5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavLeaverequest_employeeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005G5_A106EmployeeId[0]), 10, 0)), H005G5_A148EmployeeName[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavLeaverequest_employeeid.ItemCount > 0 )
            {
               AV7LeaveRequest.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_employeeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Employeeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLeaverequest_employeeid.ItemCount > 0 )
         {
            AV7LeaveRequest.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_employeeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Employeeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLeaverequest_employeeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Employeeid), 10, 0));
            AssignProp("", false, dynavLeaverequest_employeeid_Internalname, "Values", dynavLeaverequest_employeeid.ToJavascriptSource(), true);
         }
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
            AV7LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLeaverequest_leavetypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Leavetypeid), 10, 0));
            AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Values", dynavLeaverequest_leavetypeid.ToJavascriptSource(), true);
         }
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV7LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV7LeaveRequest.gxTpr_Leaverequeststatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV7LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", cmbavLeaverequest_leaverequeststatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavDuration_Enabled = 0;
         AssignProp("", false, edtavDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDuration_Enabled), 5, 0), true);
         dynavLeaverequest_holidays__holidayid.Enabled = 0;
         AssignProp("", false, dynavLeaverequest_holidays__holidayid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_holidays__holidayid.Enabled), 5, 0), !bGXsfl_58_Refreshing);
      }

      protected void RF5G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_holidaysContainer.ClearRows();
         }
         wbStart = 58;
         nGXsfl_58_idx = 1;
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_582( ) ;
         bGXsfl_58_Refreshing = true;
         Gridlevel_holidaysContainer.AddObjectProperty("GridName", "Gridlevel_holidays");
         Gridlevel_holidaysContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_holidaysContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_holidaysContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_holidaysContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_holidaysContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_holidaysContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_holidaysContainer.PageSize = subGridlevel_holidays_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_582( ) ;
            E155G2 ();
            if ( ( subGridlevel_holidays_Islastpage == 0 ) && ( GRIDLEVEL_HOLIDAYS_nCurrentRecord > 0 ) && ( GRIDLEVEL_HOLIDAYS_nGridOutOfScope == 0 ) && ( nGXsfl_58_idx == 1 ) )
            {
               GRIDLEVEL_HOLIDAYS_nCurrentRecord = 0;
               GRIDLEVEL_HOLIDAYS_nGridOutOfScope = 1;
               subgridlevel_holidays_firstpage( ) ;
               E155G2 ();
            }
            wbEnd = 58;
            WB5G0( ) ;
         }
         bGXsfl_58_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5G2( )
      {
      }

      protected int subGridlevel_holidays_fnc_Pagecount( )
      {
         GRIDLEVEL_HOLIDAYS_nRecordCount = subGridlevel_holidays_fnc_Recordcount( );
         if ( ((int)((GRIDLEVEL_HOLIDAYS_nRecordCount) % (subGridlevel_holidays_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_HOLIDAYS_nRecordCount/ (decimal)(subGridlevel_holidays_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_HOLIDAYS_nRecordCount/ (decimal)(subGridlevel_holidays_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridlevel_holidays_fnc_Recordcount( )
      {
         return AV7LeaveRequest.gxTpr_Holidays.Count ;
      }

      protected int subGridlevel_holidays_fnc_Recordsperpage( )
      {
         if ( subGridlevel_holidays_Rows > 0 )
         {
            return subGridlevel_holidays_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridlevel_holidays_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage/ (decimal)(subGridlevel_holidays_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridlevel_holidays_firstpage( )
      {
         GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlevel_holidays_nextpage( )
      {
         GRIDLEVEL_HOLIDAYS_nRecordCount = subGridlevel_holidays_fnc_Recordcount( );
         if ( ( GRIDLEVEL_HOLIDAYS_nRecordCount >= subGridlevel_holidays_fnc_Recordsperpage( ) ) && ( GRIDLEVEL_HOLIDAYS_nEOF == 0 ) )
         {
            GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = (long)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage+subGridlevel_holidays_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridlevel_holidaysContainer.AddObjectProperty("GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDLEVEL_HOLIDAYS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridlevel_holidays_previouspage( )
      {
         if ( GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage >= subGridlevel_holidays_fnc_Recordsperpage( ) )
         {
            GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = (long)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage-subGridlevel_holidays_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlevel_holidays_lastpage( )
      {
         GRIDLEVEL_HOLIDAYS_nRecordCount = subGridlevel_holidays_fnc_Recordcount( );
         if ( GRIDLEVEL_HOLIDAYS_nRecordCount > subGridlevel_holidays_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDLEVEL_HOLIDAYS_nRecordCount) % (subGridlevel_holidays_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = (long)(GRIDLEVEL_HOLIDAYS_nRecordCount-subGridlevel_holidays_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = (long)(GRIDLEVEL_HOLIDAYS_nRecordCount-((int)((GRIDLEVEL_HOLIDAYS_nRecordCount) % (subGridlevel_holidays_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridlevel_holidays_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = (long)(subGridlevel_holidays_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavDuration_Enabled = 0;
         AssignProp("", false, edtavDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDuration_Enabled), 5, 0), true);
         dynavLeaverequest_holidays__holidayid.Enabled = 0;
         AssignProp("", false, dynavLeaverequest_holidays__holidayid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_holidays__holidayid.Enabled), 5, 0), !bGXsfl_58_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E145G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLEAVEREQUEST"), AV7LeaveRequest);
            ajax_req_read_hidden_sdt(cgiGet( "Leaverequest"), AV7LeaveRequest);
            /* Read saved values. */
            nRC_GXsfl_58 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_58"), ".", ","), 18, MidpointRounding.ToEven));
            AV20StartDate = context.localUtil.CToD( cgiGet( "vSTARTDATE"), 0);
            AV22StartDate_To = context.localUtil.CToD( cgiGet( "vSTARTDATE_TO"), 0);
            GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDLEVEL_HOLIDAYS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_HOLIDAYS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGridlevel_holidays_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_HOLIDAYS_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Rows), 6, 0, ".", "")));
            Gridlevel_holidays_empowerer_Gridinternalname = cgiGet( "GRIDLEVEL_HOLIDAYS_EMPOWERER_Gridinternalname");
            nRC_GXsfl_58 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_58"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_58_fel_idx = 0;
            while ( nGXsfl_58_fel_idx < nRC_GXsfl_58 )
            {
               nGXsfl_58_fel_idx = ((subGridlevel_holidays_Islastpage==1)&&(nGXsfl_58_fel_idx+1>subGridlevel_holidays_fnc_Recordsperpage( )) ? 1 : nGXsfl_58_fel_idx+1);
               sGXsfl_58_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_582( ) ;
               AV29GXV6 = (int)(nGXsfl_58_fel_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
               if ( ( AV7LeaveRequest.gxTpr_Holidays.Count >= AV29GXV6 ) && ( AV29GXV6 > 0 ) )
               {
                  AV7LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6));
               }
            }
            if ( nGXsfl_58_fel_idx == 0 )
            {
               nGXsfl_58_idx = 1;
               sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
               SubsflControlProps_582( ) ;
            }
            nGXsfl_58_fel_idx = 1;
            /* Read variables values. */
            dynavLeaverequest_employeeid.Name = dynavLeaverequest_employeeid_Internalname;
            dynavLeaverequest_employeeid.CurrentValue = cgiGet( dynavLeaverequest_employeeid_Internalname);
            AV7LeaveRequest.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavLeaverequest_employeeid_Internalname), "."), 18, MidpointRounding.ToEven));
            dynavLeaverequest_leavetypeid.Name = dynavLeaverequest_leavetypeid_Internalname;
            dynavLeaverequest_leavetypeid.CurrentValue = cgiGet( dynavLeaverequest_leavetypeid_Internalname);
            AV7LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavLeaverequest_leavetypeid_Internalname), "."), 18, MidpointRounding.ToEven));
            AV21StartDate_RangeText = cgiGet( edtavStartdate_rangetext_Internalname);
            AssignAttri("", false, "AV21StartDate_RangeText", AV21StartDate_RangeText);
            AV7LeaveRequest.gxTpr_Leaverequesthalfday = cgiGet( radavLeaverequest_leaverequesthalfday_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDuration_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDuration_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDURATION");
               GX_FocusControl = edtavDuration_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23Duration = 0;
               AssignAttri("", false, "AV23Duration", StringUtil.LTrimStr( AV23Duration, 4, 1));
            }
            else
            {
               AV23Duration = context.localUtil.CToN( cgiGet( edtavDuration_Internalname), ".", ",");
               AssignAttri("", false, "AV23Duration", StringUtil.LTrimStr( AV23Duration, 4, 1));
            }
            AV7LeaveRequest.gxTpr_Leaverequestdescription = cgiGet( edtavLeaverequest_leaverequestdescription_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_EMPLOYEEBALANCE");
               GX_FocusControl = edtavLeaverequest_employeebalance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7LeaveRequest.gxTpr_Employeebalance = 0;
            }
            else
            {
               AV7LeaveRequest.gxTpr_Employeebalance = context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",");
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTID");
               GX_FocusControl = edtavLeaverequest_leaverequestid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7LeaveRequest.gxTpr_Leaverequestid = 0;
            }
            else
            {
               AV7LeaveRequest.gxTpr_Leaverequestid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            AV7LeaveRequest.gxTpr_Leavetypename = cgiGet( edtavLeaverequest_leavetypename_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7LeaveRequest.gxTpr_Leaverequestdate = DateTime.MinValue;
            }
            else
            {
               AV7LeaveRequest.gxTpr_Leaverequestdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 2);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Start Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequeststartdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7LeaveRequest.gxTpr_Leaverequeststartdate = DateTime.MinValue;
            }
            else
            {
               AV7LeaveRequest.gxTpr_Leaverequeststartdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request End Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTENDDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestenddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7LeaveRequest.gxTpr_Leaverequestenddate = DateTime.MinValue;
            }
            else
            {
               AV7LeaveRequest.gxTpr_Leaverequestenddate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2);
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTDURATION");
               GX_FocusControl = edtavLeaverequest_leaverequestduration_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7LeaveRequest.gxTpr_Leaverequestduration = 0;
            }
            else
            {
               AV7LeaveRequest.gxTpr_Leaverequestduration = context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",");
            }
            cmbavLeaverequest_leaverequeststatus.Name = cmbavLeaverequest_leaverequeststatus_Internalname;
            cmbavLeaverequest_leaverequeststatus.CurrentValue = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV7LeaveRequest.gxTpr_Leaverequeststatus = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV7LeaveRequest.gxTpr_Leaverequestrejectionreason = cgiGet( edtavLeaverequest_leaverequestrejectionreason_Internalname);
            AV7LeaveRequest.gxTpr_Employeename = cgiGet( edtavLeaverequest_employeename_Internalname);
            AV7LeaveRequest.gxTpr_Leavetypevacationleave = cgiGet( radavLeaverequest_leavetypevacationleave_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E145G2 ();
         if (returnInSub) return;
      }

      protected void E145G2( )
      {
         /* Start Routine */
         returnInSub = false;
         new logtofile(context ).execute(  ">>>>>>>>>>>"+"DSP"+">>>"+AV11TrnMode) ;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV12LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Insert") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Update") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "INS") != 0 )
            {
               AV7LeaveRequest.Load(AV15LeaveRequestId);
               gx_BV58 = true;
               AV12LoadSuccess = AV7LeaveRequest.Success();
               if ( ! AV12LoadSuccess )
               {
                  AV10Messages = AV7LeaveRequest.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
               {
                  dynavLeaverequest_employeeid.Enabled = 0;
                  AssignProp("", false, dynavLeaverequest_employeeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_employeeid.Enabled), 5, 0), true);
                  dynavLeaverequest_leavetypeid.Enabled = 0;
                  AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
                  edtavStartdate_rangetext_Enabled = 0;
                  AssignProp("", false, edtavStartdate_rangetext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStartdate_rangetext_Enabled), 5, 0), true);
                  radavLeaverequest_leaverequesthalfday.Enabled = 0;
                  AssignProp("", false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
                  edtavLeaverequest_leaverequestdescription_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
                  edtavLeaverequest_employeebalance_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
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
         divTablecontent_Width = 500;
         AssignProp("", false, divTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablecontent_Width), 9, 0), true);
         this.executeUsercontrolMethod("", false, "STARTDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavStartdate_rangetext_Internalname});
         edtavLeaverequest_leaverequestid_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestid_Visible), 5, 0), true);
         edtavLeaverequest_leavetypename_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leavetypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Visible), 5, 0), true);
         edtavLeaverequest_leaverequestdate_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdate_Visible), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequeststartdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Visible), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestenddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Visible), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestduration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Visible), 5, 0), true);
         cmbavLeaverequest_leaverequeststatus.Visible = 0;
         AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLeaverequest_leaverequeststatus.Visible), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Visible), 5, 0), true);
         edtavLeaverequest_employeename_Visible = 0;
         AssignProp("", false, edtavLeaverequest_employeename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Visible), 5, 0), true);
         radavLeaverequest_leavetypevacationleave.Visible = 0;
         AssignProp("", false, radavLeaverequest_leavetypevacationleave_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leavetypevacationleave.Visible), 5, 0), true);
         Gridlevel_holidays_empowerer_Gridinternalname = subGridlevel_holidays_Internalname;
         ucGridlevel_holidays_empowerer.SendProperty(context, "", false, Gridlevel_holidays_empowerer_Internalname, "GridInternalName", Gridlevel_holidays_empowerer_Gridinternalname);
         subGridlevel_holidays_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Rows), 6, 0, ".", "")));
      }

      private void E155G2( )
      {
         /* Gridlevel_holidays_Load Routine */
         returnInSub = false;
         AV29GXV6 = 1;
         while ( AV29GXV6 <= AV7LeaveRequest.gxTpr_Holidays.Count )
         {
            AV7LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 58;
            }
            if ( ( subGridlevel_holidays_Islastpage == 1 ) || ( subGridlevel_holidays_Rows == 0 ) || ( ( GRIDLEVEL_HOLIDAYS_nCurrentRecord >= GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage ) && ( GRIDLEVEL_HOLIDAYS_nCurrentRecord < GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage + subGridlevel_holidays_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_582( ) ;
            }
            GRIDLEVEL_HOLIDAYS_nEOF = (short)(((GRIDLEVEL_HOLIDAYS_nCurrentRecord<GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage+subGridlevel_holidays_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nEOF), 1, 0, ".", "")));
            GRIDLEVEL_HOLIDAYS_nCurrentRecord = (long)(GRIDLEVEL_HOLIDAYS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_58_Refreshing )
            {
               DoAjaxLoad(58, Gridlevel_holidaysRow);
            }
            AV29GXV6 = (int)(AV29GXV6+1);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E125G2 ();
         if (returnInSub) return;
      }

      protected void E125G2( )
      {
         AV29GXV6 = (int)(nGXsfl_58_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
         if ( ( AV29GXV6 > 0 ) && ( AV7LeaveRequest.gxTpr_Holidays.Count >= AV29GXV6 ) )
         {
            AV7LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV11TrnMode, "DLT") != 0 )
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S122 ();
            if (returnInSub) return;
         }
         if ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) || AV13CheckRequiredFieldsResult )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
            {
               AV7LeaveRequest.Delete();
               gx_BV58 = true;
            }
            else
            {
               AV7LeaveRequest.Save();
               gx_BV58 = true;
            }
            if ( AV7LeaveRequest.Success() )
            {
               /* Execute user subroutine: 'AFTER_TRN' */
               S132 ();
               if (returnInSub) return;
            }
            else
            {
               AV10Messages = AV7LeaveRequest.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7LeaveRequest", AV7LeaveRequest);
         nGXsfl_58_bak_idx = nGXsfl_58_idx;
         gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         nGXsfl_58_idx = nGXsfl_58_bak_idx;
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_582( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Messages", AV10Messages);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV42GXV19 = 1;
         while ( AV42GXV19 <= AV10Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV10Messages.Item(AV42GXV19));
            GX_msglist.addItem(AV9Message.gxTpr_Description);
            AV42GXV19 = (int)(AV42GXV19+1);
         }
      }

      protected void S132( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("leaverequestwp",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV13CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV13CheckRequiredFieldsResult", AV13CheckRequiredFieldsResult);
      }

      protected void E115G2( )
      {
         AV29GXV6 = (int)(nGXsfl_58_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
         if ( ( AV29GXV6 > 0 ) && ( AV7LeaveRequest.gxTpr_Holidays.Count >= AV29GXV6 ) )
         {
            AV7LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6));
         }
         /* Startdate_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         AV7LeaveRequest.gxTpr_Leaverequeststartdate = AV20StartDate;
         AV7LeaveRequest.gxTpr_Leaverequestenddate = AV22StartDate_To;
         if ( DateTimeUtil.ResetTime ( AV20StartDate ) != DateTimeUtil.ResetTime ( AV22StartDate_To ) )
         {
            AV7LeaveRequest.gxTv_SdtLeaveRequest_Leaverequesthalfday_SetNull();
         }
         /* Execute user subroutine: 'LOADHOLIDAYS' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7LeaveRequest", AV7LeaveRequest);
         nGXsfl_58_bak_idx = nGXsfl_58_idx;
         gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         nGXsfl_58_idx = nGXsfl_58_bak_idx;
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_582( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Holiday", AV19Holiday);
      }

      protected void E135G2( )
      {
         AV29GXV6 = (int)(nGXsfl_58_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
         if ( ( AV29GXV6 > 0 ) && ( AV7LeaveRequest.gxTpr_Holidays.Count >= AV29GXV6 ) )
         {
            AV7LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6));
         }
         /* Leaverequest_leaverequeststartdate_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADHOLIDAYS' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7LeaveRequest", AV7LeaveRequest);
         nGXsfl_58_bak_idx = nGXsfl_58_idx;
         gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV7LeaveRequest.gxTpr_Leavetypeid, AV7LeaveRequest.gxTpr_Employeeid, AV7LeaveRequest.gxTpr_Leaverequesthalfday, AV7LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode, AV15LeaveRequestId) ;
         nGXsfl_58_idx = nGXsfl_58_bak_idx;
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_582( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Holiday", AV19Holiday);
      }

      protected void S142( )
      {
         /* 'LOADHOLIDAYS' Routine */
         returnInSub = false;
         AV7LeaveRequest.gxTpr_Holidays.Clear();
         gx_BV58 = true;
         /* Using cursor H005G6 */
         pr_default.execute(4, new Object[] {AV20StartDate, AV22StartDate_To});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A115HolidayStartDate = H005G6_A115HolidayStartDate[0];
            A113HolidayId = H005G6_A113HolidayId[0];
            AV19Holiday.gxTpr_Holidayid = A113HolidayId;
            AV19Holiday.gxTpr_Isapplicable = true;
            AV7LeaveRequest.gxTpr_Holidays.Add(AV19Holiday, 0);
            gx_BV58 = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
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
         PA5G2( ) ;
         WS5G2( ) ;
         WE5G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202471616194683", true, true);
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
         context.AddJavascriptSource("leaverequestwp.js", "?202471616194683", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_582( )
      {
         dynavLeaverequest_holidays__holidayid_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYID_"+sGXsfl_58_idx;
         chkavLeaverequest_holidays__isapplicable_Internalname = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE_"+sGXsfl_58_idx;
      }

      protected void SubsflControlProps_fel_582( )
      {
         dynavLeaverequest_holidays__holidayid_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYID_"+sGXsfl_58_fel_idx;
         chkavLeaverequest_holidays__isapplicable_Internalname = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE_"+sGXsfl_58_fel_idx;
      }

      protected void sendrow_582( )
      {
         SubsflControlProps_582( ) ;
         WB5G0( ) ;
         if ( ( subGridlevel_holidays_Rows * 1 == 0 ) || ( nGXsfl_58_idx <= subGridlevel_holidays_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridlevel_holidaysRow = GXWebRow.GetNew(context,Gridlevel_holidaysContainer);
            if ( subGridlevel_holidays_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridlevel_holidays_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridlevel_holidays_Class, "") != 0 )
               {
                  subGridlevel_holidays_Linesclass = subGridlevel_holidays_Class+"Odd";
               }
            }
            else if ( subGridlevel_holidays_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridlevel_holidays_Backstyle = 0;
               subGridlevel_holidays_Backcolor = subGridlevel_holidays_Allbackcolor;
               if ( StringUtil.StrCmp(subGridlevel_holidays_Class, "") != 0 )
               {
                  subGridlevel_holidays_Linesclass = subGridlevel_holidays_Class+"Uniform";
               }
            }
            else if ( subGridlevel_holidays_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridlevel_holidays_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridlevel_holidays_Class, "") != 0 )
               {
                  subGridlevel_holidays_Linesclass = subGridlevel_holidays_Class+"Odd";
               }
               subGridlevel_holidays_Backcolor = (int)(0x0);
            }
            else if ( subGridlevel_holidays_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridlevel_holidays_Backstyle = 1;
               if ( ((int)((nGXsfl_58_idx) % (2))) == 0 )
               {
                  subGridlevel_holidays_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlevel_holidays_Class, "") != 0 )
                  {
                     subGridlevel_holidays_Linesclass = subGridlevel_holidays_Class+"Even";
                  }
               }
               else
               {
                  subGridlevel_holidays_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlevel_holidays_Class, "") != 0 )
                  {
                     subGridlevel_holidays_Linesclass = subGridlevel_holidays_Class+"Odd";
                  }
               }
            }
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_58_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynavLeaverequest_holidays__holidayid.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "LEAVEREQUEST_HOLIDAYS__HOLIDAYID_" + sGXsfl_58_idx;
               dynavLeaverequest_holidays__holidayid.Name = GXCCtl;
               dynavLeaverequest_holidays__holidayid.WebTags = "";
               dynavLeaverequest_holidays__holidayid.removeAllItems();
               /* Using cursor H005G7 */
               pr_default.execute(5);
               while ( (pr_default.getStatus(5) != 101) )
               {
                  dynavLeaverequest_holidays__holidayid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005G7_A113HolidayId[0]), 10, 0)), H005G7_A114HolidayName[0], 0);
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               if ( dynavLeaverequest_holidays__holidayid.ItemCount > 0 )
               {
                  if ( ( AV29GXV6 > 0 ) && ( AV7LeaveRequest.gxTpr_Holidays.Count >= AV29GXV6 ) && (0==((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Holidayid) )
                  {
                     ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Holidayid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_holidays__holidayid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Holidayid), 10, 0))), "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
            /* ComboBox */
            Gridlevel_holidaysRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavLeaverequest_holidays__holidayid,(string)dynavLeaverequest_holidays__holidayid_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Holidayid), 10, 0)),(short)1,(string)dynavLeaverequest_holidays__holidayid_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynavLeaverequest_holidays__holidayid.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynavLeaverequest_holidays__holidayid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Holidayid), 10, 0));
            AssignProp("", false, dynavLeaverequest_holidays__holidayid_Internalname, "Values", (string)(dynavLeaverequest_holidays__holidayid.ToJavascriptSource()), !bGXsfl_58_Refreshing);
            /* Subfile cell */
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = " " + ((chkavLeaverequest_holidays__isapplicable.Enabled!=0)&&(chkavLeaverequest_holidays__isapplicable.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 60,'',false,'"+sGXsfl_58_idx+"',58)\"" : " ");
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE_" + sGXsfl_58_idx;
            chkavLeaverequest_holidays__isapplicable.Name = GXCCtl;
            chkavLeaverequest_holidays__isapplicable.WebTags = "";
            chkavLeaverequest_holidays__isapplicable.Caption = "";
            AssignProp("", false, chkavLeaverequest_holidays__isapplicable_Internalname, "TitleCaption", chkavLeaverequest_holidays__isapplicable.Caption, !bGXsfl_58_Refreshing);
            chkavLeaverequest_holidays__isapplicable.CheckedValue = "false";
            Gridlevel_holidaysRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavLeaverequest_holidays__isapplicable_Internalname,StringUtil.BoolToStr( ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Isapplicable),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavLeaverequest_holidays__isapplicable.Enabled!=0)&&(chkavLeaverequest_holidays__isapplicable.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,60);\"" : " ")});
            send_integrity_lvl_hashes5G2( ) ;
            Gridlevel_holidaysContainer.AddRow(Gridlevel_holidaysRow);
            nGXsfl_58_idx = ((subGridlevel_holidays_Islastpage==1)&&(nGXsfl_58_idx+1>subGridlevel_holidays_fnc_Recordsperpage( )) ? 1 : nGXsfl_58_idx+1);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
            SubsflControlProps_582( ) ;
         }
         /* End function sendrow_582 */
      }

      protected void init_web_controls( )
      {
         dynavLeaverequest_employeeid.Name = "LEAVEREQUEST_EMPLOYEEID";
         dynavLeaverequest_employeeid.WebTags = "";
         dynavLeaverequest_employeeid.removeAllItems();
         /* Using cursor H005G8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            dynavLeaverequest_employeeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005G8_A106EmployeeId[0]), 10, 0)), H005G8_A148EmployeeName[0], 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( dynavLeaverequest_employeeid.ItemCount > 0 )
         {
            AV7LeaveRequest.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_employeeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Employeeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         dynavLeaverequest_leavetypeid.Name = "LEAVEREQUEST_LEAVETYPEID";
         dynavLeaverequest_leavetypeid.WebTags = "";
         dynavLeaverequest_leavetypeid.removeAllItems();
         /* Using cursor H005G9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005G9_A124LeaveTypeId[0]), 10, 0)), H005G9_A125LeaveTypeName[0], 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
            AV7LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         radavLeaverequest_leaverequesthalfday.Name = "LEAVEREQUEST_LEAVEREQUESTHALFDAY";
         radavLeaverequest_leaverequesthalfday.WebTags = "";
         radavLeaverequest_leaverequesthalfday.addItem("", "None", 0);
         radavLeaverequest_leaverequesthalfday.addItem("Morning", "Morning", 0);
         radavLeaverequest_leaverequesthalfday.addItem("Afternoon", "Afternoon", 0);
         GXCCtl = "LEAVEREQUEST_HOLIDAYS__HOLIDAYID_" + sGXsfl_58_idx;
         dynavLeaverequest_holidays__holidayid.Name = GXCCtl;
         dynavLeaverequest_holidays__holidayid.WebTags = "";
         dynavLeaverequest_holidays__holidayid.removeAllItems();
         /* Using cursor H005G10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            dynavLeaverequest_holidays__holidayid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005G10_A113HolidayId[0]), 10, 0)), H005G10_A114HolidayName[0], 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( dynavLeaverequest_holidays__holidayid.ItemCount > 0 )
         {
            if ( ( AV29GXV6 > 0 ) && ( AV7LeaveRequest.gxTpr_Holidays.Count >= AV29GXV6 ) && (0==((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Holidayid) )
            {
               ((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Holidayid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_holidays__holidayid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(((SdtLeaveRequest_Holidays)AV7LeaveRequest.gxTpr_Holidays.Item(AV29GXV6)).gxTpr_Holidayid), 10, 0))), "."), 18, MidpointRounding.ToEven));
            }
         }
         GXCCtl = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE_" + sGXsfl_58_idx;
         chkavLeaverequest_holidays__isapplicable.Name = GXCCtl;
         chkavLeaverequest_holidays__isapplicable.WebTags = "";
         chkavLeaverequest_holidays__isapplicable.Caption = "";
         AssignProp("", false, chkavLeaverequest_holidays__isapplicable_Internalname, "TitleCaption", chkavLeaverequest_holidays__isapplicable.Caption, !bGXsfl_58_Refreshing);
         chkavLeaverequest_holidays__isapplicable.CheckedValue = "false";
         cmbavLeaverequest_leaverequeststatus.Name = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         cmbavLeaverequest_leaverequeststatus.WebTags = "";
         cmbavLeaverequest_leaverequeststatus.addItem("Pending", "Pending", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Approved", "Approved", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Rejected", "Rejected", 0);
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV7LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV7LeaveRequest.gxTpr_Leaverequeststatus);
         }
         radavLeaverequest_leavetypevacationleave.Name = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         radavLeaverequest_leavetypevacationleave.WebTags = "";
         radavLeaverequest_leavetypevacationleave.addItem("No", "No", 0);
         radavLeaverequest_leavetypevacationleave.addItem("Yes", "Yes", 0);
         /* End function init_web_controls */
      }

      protected void StartGridControl58( )
      {
         if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Gridlevel_holidaysContainer"+"DivS\" data-gxgridid=\"58\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridlevel_holidays_Internalname, subGridlevel_holidays_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridlevel_holidays_Backcolorstyle == 0 )
            {
               subGridlevel_holidays_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridlevel_holidays_Class) > 0 )
               {
                  subGridlevel_holidays_Linesclass = subGridlevel_holidays_Class+"Title";
               }
            }
            else
            {
               subGridlevel_holidays_Titlebackstyle = 1;
               if ( subGridlevel_holidays_Backcolorstyle == 1 )
               {
                  subGridlevel_holidays_Titlebackcolor = subGridlevel_holidays_Allbackcolor;
                  if ( StringUtil.Len( subGridlevel_holidays_Class) > 0 )
                  {
                     subGridlevel_holidays_Linesclass = subGridlevel_holidays_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridlevel_holidays_Class) > 0 )
                  {
                     subGridlevel_holidays_Linesclass = subGridlevel_holidays_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Holiday Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Applicable") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridlevel_holidaysContainer.AddObjectProperty("GridName", "Gridlevel_holidays");
         }
         else
         {
            Gridlevel_holidaysContainer.AddObjectProperty("GridName", "Gridlevel_holidays");
            Gridlevel_holidaysContainer.AddObjectProperty("Header", subGridlevel_holidays_Header);
            Gridlevel_holidaysContainer.AddObjectProperty("Class", "WorkWith");
            Gridlevel_holidaysContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Backcolorstyle), 1, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("CmpContext", "");
            Gridlevel_holidaysContainer.AddObjectProperty("InMasterPage", "false");
            Gridlevel_holidaysColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_holidaysColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavLeaverequest_holidays__holidayid.Enabled), 5, 0, ".", "")));
            Gridlevel_holidaysContainer.AddColumnProperties(Gridlevel_holidaysColumn);
            Gridlevel_holidaysColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_holidaysContainer.AddColumnProperties(Gridlevel_holidaysColumn);
            Gridlevel_holidaysContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Selectedindex), 4, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Allowselection), 1, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Selectioncolor), 9, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Allowhovering), 1, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Hoveringcolor), 9, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Allowcollapsing), 1, 0, ".", "")));
            Gridlevel_holidaysContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         dynavLeaverequest_employeeid_Internalname = "LEAVEREQUEST_EMPLOYEEID";
         dynavLeaverequest_leavetypeid_Internalname = "LEAVEREQUEST_LEAVETYPEID";
         edtavStartdate_rangetext_Internalname = "vSTARTDATE_RANGETEXT";
         radavLeaverequest_leaverequesthalfday_Internalname = "LEAVEREQUEST_LEAVEREQUESTHALFDAY";
         edtavDuration_Internalname = "vDURATION";
         edtavLeaverequest_leaverequestdescription_Internalname = "LEAVEREQUEST_LEAVEREQUESTDESCRIPTION";
         edtavLeaverequest_employeebalance_Internalname = "LEAVEREQUEST_EMPLOYEEBALANCE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         dynavLeaverequest_holidays__holidayid_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYID";
         chkavLeaverequest_holidays__isapplicable_Internalname = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE";
         divTableleaflevel_holidays_Internalname = "TABLELEAFLEVEL_HOLIDAYS";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablecontent_Internalname = "TABLECONTENT";
         divRighttable_Internalname = "RIGHTTABLE";
         divMaintable_Internalname = "MAINTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         Startdate_rangepicker_Internalname = "STARTDATE_RANGEPICKER";
         edtavLeaverequest_leaverequestid_Internalname = "LEAVEREQUEST_LEAVEREQUESTID";
         edtavLeaverequest_leavetypename_Internalname = "LEAVEREQUEST_LEAVETYPENAME";
         edtavLeaverequest_leaverequestdate_Internalname = "LEAVEREQUEST_LEAVEREQUESTDATE";
         edtavLeaverequest_leaverequeststartdate_Internalname = "LEAVEREQUEST_LEAVEREQUESTSTARTDATE";
         edtavLeaverequest_leaverequestenddate_Internalname = "LEAVEREQUEST_LEAVEREQUESTENDDATE";
         edtavLeaverequest_leaverequestduration_Internalname = "LEAVEREQUEST_LEAVEREQUESTDURATION";
         cmbavLeaverequest_leaverequeststatus_Internalname = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         edtavLeaverequest_leaverequestrejectionreason_Internalname = "LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON";
         edtavLeaverequest_employeename_Internalname = "LEAVEREQUEST_EMPLOYEENAME";
         radavLeaverequest_leavetypevacationleave_Internalname = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         Gridlevel_holidays_empowerer_Internalname = "GRIDLEVEL_HOLIDAYS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_holidays_Internalname = "GRIDLEVEL_HOLIDAYS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_holidays_Allowcollapsing = 0;
         subGridlevel_holidays_Allowselection = 0;
         subGridlevel_holidays_Header = "";
         chkavLeaverequest_holidays__isapplicable.Caption = "";
         chkavLeaverequest_holidays__isapplicable.Visible = -1;
         chkavLeaverequest_holidays__isapplicable.Enabled = 1;
         dynavLeaverequest_holidays__holidayid_Jsonclick = "";
         dynavLeaverequest_holidays__holidayid.Enabled = 0;
         subGridlevel_holidays_Class = "WorkWith";
         subGridlevel_holidays_Backcolorstyle = 0;
         edtavLeaverequest_employeebalance_Enabled = 1;
         edtavLeaverequest_leaverequestdescription_Enabled = 1;
         dynavLeaverequest_leavetypeid.Enabled = 1;
         dynavLeaverequest_employeeid.Enabled = 1;
         dynavLeaverequest_holidays__holidayid.Enabled = -1;
         radavLeaverequest_leavetypevacationleave_Jsonclick = "";
         radavLeaverequest_leavetypevacationleave.Visible = 1;
         edtavLeaverequest_employeename_Jsonclick = "";
         edtavLeaverequest_employeename_Visible = 1;
         edtavLeaverequest_leaverequestrejectionreason_Visible = 1;
         cmbavLeaverequest_leaverequeststatus_Jsonclick = "";
         cmbavLeaverequest_leaverequeststatus.Visible = 1;
         edtavLeaverequest_leaverequestduration_Jsonclick = "";
         edtavLeaverequest_leaverequestduration_Visible = 1;
         edtavLeaverequest_leaverequestenddate_Jsonclick = "";
         edtavLeaverequest_leaverequestenddate_Visible = 1;
         edtavLeaverequest_leaverequeststartdate_Jsonclick = "";
         edtavLeaverequest_leaverequeststartdate_Visible = 1;
         edtavLeaverequest_leaverequestdate_Jsonclick = "";
         edtavLeaverequest_leaverequestdate_Visible = 1;
         edtavLeaverequest_leavetypename_Jsonclick = "";
         edtavLeaverequest_leavetypename_Visible = 1;
         edtavLeaverequest_leaverequestid_Jsonclick = "";
         edtavLeaverequest_leaverequestid_Visible = 1;
         edtavLeaverequest_employeebalance_Jsonclick = "";
         edtavLeaverequest_employeebalance_Enabled = 1;
         edtavLeaverequest_leaverequestdescription_Enabled = 1;
         edtavDuration_Jsonclick = "";
         edtavDuration_Enabled = 1;
         radavLeaverequest_leaverequesthalfday_Jsonclick = "";
         radavLeaverequest_leaverequesthalfday.Enabled = 1;
         edtavStartdate_rangetext_Jsonclick = "";
         edtavStartdate_rangetext_Enabled = 1;
         dynavLeaverequest_leavetypeid_Jsonclick = "";
         dynavLeaverequest_leavetypeid.Enabled = 1;
         dynavLeaverequest_employeeid_Jsonclick = "";
         dynavLeaverequest_employeeid.Enabled = 1;
         divTablecontent_Width = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Leave Request WP";
         subGridlevel_holidays_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'dynavLeaverequest_leavetypeid'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'dynavLeaverequest_employeeid'},{av:'GXV1',fld:'LEAVEREQUEST_EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'radavLeaverequest_leaverequesthalfday'},{av:'GXV3',fld:'LEAVEREQUEST_LEAVEREQUESTHALFDAY',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV18',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''},{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS.LOAD","{handler:'E155G2',iparms:[]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS.LOAD",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E125G2',iparms:[{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV13CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'AV10Messages',fld:'vMESSAGES',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'dynavLeaverequest_leavetypeid'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'dynavLeaverequest_employeeid'},{av:'GXV1',fld:'LEAVEREQUEST_EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'radavLeaverequest_leaverequesthalfday'},{av:'GXV3',fld:'LEAVEREQUEST_LEAVEREQUESTHALFDAY',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV18',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'AV10Messages',fld:'vMESSAGES',pic:''},{av:'AV13CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''}]}");
         setEventMetadata("STARTDATE_RANGEPICKER.DATERANGECHANGED","{handler:'E115G2',iparms:[{av:'AV20StartDate',fld:'vSTARTDATE',pic:''},{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'AV22StartDate_To',fld:'vSTARTDATE_TO',pic:''},{av:'A115HolidayStartDate',fld:'HOLIDAYSTARTDATE',pic:''},{av:'A113HolidayId',fld:'HOLIDAYID',pic:'ZZZZZZZZZ9'},{av:'AV19Holiday',fld:'vHOLIDAY',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'dynavLeaverequest_leavetypeid'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'dynavLeaverequest_employeeid'},{av:'GXV1',fld:'LEAVEREQUEST_EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'radavLeaverequest_leaverequesthalfday'},{av:'GXV3',fld:'LEAVEREQUEST_LEAVEREQUESTHALFDAY',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV18',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''},{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("STARTDATE_RANGEPICKER.DATERANGECHANGED",",oparms:[{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'AV19Holiday',fld:'vHOLIDAY',pic:''}]}");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED","{handler:'E135G2',iparms:[{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'A115HolidayStartDate',fld:'HOLIDAYSTARTDATE',pic:''},{av:'AV20StartDate',fld:'vSTARTDATE',pic:''},{av:'AV22StartDate_To',fld:'vSTARTDATE_TO',pic:''},{av:'A113HolidayId',fld:'HOLIDAYID',pic:'ZZZZZZZZZ9'},{av:'AV19Holiday',fld:'vHOLIDAY',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'dynavLeaverequest_leavetypeid'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'dynavLeaverequest_employeeid'},{av:'GXV1',fld:'LEAVEREQUEST_EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'radavLeaverequest_leaverequesthalfday'},{av:'GXV3',fld:'LEAVEREQUEST_LEAVEREQUESTHALFDAY',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV18',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''},{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED",",oparms:[{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'AV19Holiday',fld:'vHOLIDAY',pic:''}]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_FIRSTPAGE","{handler:'subgridlevel_holidays_firstpage',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynavLeaverequest_leavetypeid'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'dynavLeaverequest_employeeid'},{av:'GXV1',fld:'LEAVEREQUEST_EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'radavLeaverequest_leaverequesthalfday'},{av:'GXV3',fld:'LEAVEREQUEST_LEAVEREQUESTHALFDAY',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV18',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_PREVPAGE","{handler:'subgridlevel_holidays_previouspage',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynavLeaverequest_leavetypeid'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'dynavLeaverequest_employeeid'},{av:'GXV1',fld:'LEAVEREQUEST_EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'radavLeaverequest_leaverequesthalfday'},{av:'GXV3',fld:'LEAVEREQUEST_LEAVEREQUESTHALFDAY',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV18',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_NEXTPAGE","{handler:'subgridlevel_holidays_nextpage',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynavLeaverequest_leavetypeid'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'dynavLeaverequest_employeeid'},{av:'GXV1',fld:'LEAVEREQUEST_EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'radavLeaverequest_leaverequesthalfday'},{av:'GXV3',fld:'LEAVEREQUEST_LEAVEREQUESTHALFDAY',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV18',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_LASTPAGE","{handler:'subgridlevel_holidays_lastpage',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'AV7LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_58',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:58},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV11TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV15LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynavLeaverequest_leavetypeid'},{av:'GXV2',fld:'LEAVEREQUEST_LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'dynavLeaverequest_employeeid'},{av:'GXV1',fld:'LEAVEREQUEST_EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'radavLeaverequest_leaverequesthalfday'},{av:'GXV3',fld:'LEAVEREQUEST_LEAVEREQUESTHALFDAY',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV18',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_GXV15","{handler:'Validv_Gxv15',iparms:[]");
         setEventMetadata("VALIDV_GXV15",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv8',iparms:[]");
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
         wcpOAV11TrnMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7LeaveRequest = new SdtLeaveRequest(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV20StartDate = DateTime.MinValue;
         AV22StartDate_To = DateTime.MinValue;
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A115HolidayStartDate = DateTime.MinValue;
         AV19Holiday = new SdtLeaveRequest_Holidays(context);
         Gridlevel_holidays_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV21StartDate_RangeText = "";
         Gridlevel_holidaysContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucStartdate_rangepicker = new GXUserControl();
         ucGridlevel_holidays_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H005G2_A124LeaveTypeId = new long[1] ;
         H005G2_A125LeaveTypeName = new string[] {""} ;
         H005G3_A106EmployeeId = new long[1] ;
         H005G3_A148EmployeeName = new string[] {""} ;
         H005G4_A124LeaveTypeId = new long[1] ;
         H005G4_A125LeaveTypeName = new string[] {""} ;
         H005G5_A106EmployeeId = new long[1] ;
         H005G5_A148EmployeeName = new string[] {""} ;
         Gridlevel_holidaysRow = new GXWebRow();
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         H005G6_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         H005G6_A113HolidayId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridlevel_holidays_Linesclass = "";
         GXCCtl = "";
         H005G7_A113HolidayId = new long[1] ;
         H005G7_A114HolidayName = new string[] {""} ;
         H005G8_A106EmployeeId = new long[1] ;
         H005G8_A148EmployeeName = new string[] {""} ;
         H005G9_A124LeaveTypeId = new long[1] ;
         H005G9_A125LeaveTypeName = new string[] {""} ;
         H005G10_A113HolidayId = new long[1] ;
         H005G10_A114HolidayName = new string[] {""} ;
         Gridlevel_holidaysColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leaverequestwp__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestwp__default(),
            new Object[][] {
                new Object[] {
               H005G2_A124LeaveTypeId, H005G2_A125LeaveTypeName
               }
               , new Object[] {
               H005G3_A106EmployeeId, H005G3_A148EmployeeName
               }
               , new Object[] {
               H005G4_A124LeaveTypeId, H005G4_A125LeaveTypeName
               }
               , new Object[] {
               H005G5_A106EmployeeId, H005G5_A148EmployeeName
               }
               , new Object[] {
               H005G6_A115HolidayStartDate, H005G6_A113HolidayId
               }
               , new Object[] {
               H005G7_A113HolidayId, H005G7_A114HolidayName
               }
               , new Object[] {
               H005G8_A106EmployeeId, H005G8_A148EmployeeName
               }
               , new Object[] {
               H005G9_A124LeaveTypeId, H005G9_A125LeaveTypeName
               }
               , new Object[] {
               H005G10_A113HolidayId, H005G10_A114HolidayName
               }
            }
         );
         /* GeneXus formulas. */
         edtavDuration_Enabled = 0;
         dynavLeaverequest_holidays__holidayid.Enabled = 0;
      }

      private short GRIDLEVEL_HOLIDAYS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridlevel_holidays_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGridlevel_holidays_Backstyle ;
      private short subGridlevel_holidays_Titlebackstyle ;
      private short subGridlevel_holidays_Allowselection ;
      private short subGridlevel_holidays_Allowhovering ;
      private short subGridlevel_holidays_Allowcollapsing ;
      private short subGridlevel_holidays_Collapsed ;
      private int nRC_GXsfl_58 ;
      private int subGridlevel_holidays_Rows ;
      private int nGXsfl_58_idx=1 ;
      private int divTablecontent_Width ;
      private int edtavStartdate_rangetext_Enabled ;
      private int edtavDuration_Enabled ;
      private int edtavLeaverequest_leaverequestdescription_Enabled ;
      private int edtavLeaverequest_employeebalance_Enabled ;
      private int AV29GXV6 ;
      private int edtavLeaverequest_leaverequestid_Visible ;
      private int edtavLeaverequest_leavetypename_Visible ;
      private int edtavLeaverequest_leaverequestdate_Visible ;
      private int edtavLeaverequest_leaverequeststartdate_Visible ;
      private int edtavLeaverequest_leaverequestenddate_Visible ;
      private int edtavLeaverequest_leaverequestduration_Visible ;
      private int edtavLeaverequest_leaverequestrejectionreason_Visible ;
      private int edtavLeaverequest_employeename_Visible ;
      private int gxdynajaxindex ;
      private int subGridlevel_holidays_Islastpage ;
      private int GRIDLEVEL_HOLIDAYS_nGridOutOfScope ;
      private int nGXsfl_58_fel_idx=1 ;
      private int nGXsfl_58_bak_idx=1 ;
      private int AV42GXV19 ;
      private int idxLst ;
      private int subGridlevel_holidays_Backcolor ;
      private int subGridlevel_holidays_Allbackcolor ;
      private int subGridlevel_holidays_Titlebackcolor ;
      private int subGridlevel_holidays_Selectedindex ;
      private int subGridlevel_holidays_Selectioncolor ;
      private int subGridlevel_holidays_Hoveringcolor ;
      private long AV15LeaveRequestId ;
      private long wcpOAV15LeaveRequestId ;
      private long GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage ;
      private long A113HolidayId ;
      private long GRIDLEVEL_HOLIDAYS_nCurrentRecord ;
      private long GRIDLEVEL_HOLIDAYS_nRecordCount ;
      private decimal AV23Duration ;
      private string AV11TrnMode ;
      private string wcpOAV11TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_58_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gridlevel_holidays_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divMaintable_Internalname ;
      private string divLefttable_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string dynavLeaverequest_employeeid_Internalname ;
      private string TempTags ;
      private string dynavLeaverequest_employeeid_Jsonclick ;
      private string dynavLeaverequest_leavetypeid_Internalname ;
      private string dynavLeaverequest_leavetypeid_Jsonclick ;
      private string edtavStartdate_rangetext_Internalname ;
      private string edtavStartdate_rangetext_Jsonclick ;
      private string radavLeaverequest_leaverequesthalfday_Internalname ;
      private string radavLeaverequest_leaverequesthalfday_Jsonclick ;
      private string edtavDuration_Internalname ;
      private string edtavDuration_Jsonclick ;
      private string edtavLeaverequest_leaverequestdescription_Internalname ;
      private string edtavLeaverequest_employeebalance_Internalname ;
      private string edtavLeaverequest_employeebalance_Jsonclick ;
      private string divTableleaflevel_holidays_Internalname ;
      private string sStyleString ;
      private string subGridlevel_holidays_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Startdate_rangepicker_Internalname ;
      private string edtavLeaverequest_leaverequestid_Internalname ;
      private string edtavLeaverequest_leaverequestid_Jsonclick ;
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
      private string edtavLeaverequest_leaverequestrejectionreason_Internalname ;
      private string edtavLeaverequest_employeename_Internalname ;
      private string edtavLeaverequest_employeename_Jsonclick ;
      private string radavLeaverequest_leavetypevacationleave_Internalname ;
      private string radavLeaverequest_leavetypevacationleave_Jsonclick ;
      private string Gridlevel_holidays_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string dynavLeaverequest_holidays__holidayid_Internalname ;
      private string sGXsfl_58_fel_idx="0001" ;
      private string chkavLeaverequest_holidays__isapplicable_Internalname ;
      private string subGridlevel_holidays_Class ;
      private string subGridlevel_holidays_Linesclass ;
      private string GXCCtl ;
      private string dynavLeaverequest_holidays__holidayid_Jsonclick ;
      private string subGridlevel_holidays_Header ;
      private DateTime AV20StartDate ;
      private DateTime AV22StartDate_To ;
      private DateTime A115HolidayStartDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_58_Refreshing=false ;
      private bool returnInSub ;
      private bool AV12LoadSuccess ;
      private bool gx_BV58 ;
      private string AV21StartDate_RangeText ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Gridlevel_holidaysContainer ;
      private GXWebRow Gridlevel_holidaysRow ;
      private GXWebColumn Gridlevel_holidaysColumn ;
      private GXUserControl ucStartdate_rangepicker ;
      private GXUserControl ucGridlevel_holidays_empowerer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLeaverequest_employeeid ;
      private GXCombobox dynavLeaverequest_leavetypeid ;
      private GXRadio radavLeaverequest_leaverequesthalfday ;
      private GXCombobox dynavLeaverequest_holidays__holidayid ;
      private GXCheckbox chkavLeaverequest_holidays__isapplicable ;
      private GXCombobox cmbavLeaverequest_leaverequeststatus ;
      private GXRadio radavLeaverequest_leavetypevacationleave ;
      private IDataStoreProvider pr_default ;
      private long[] H005G2_A124LeaveTypeId ;
      private string[] H005G2_A125LeaveTypeName ;
      private long[] H005G3_A106EmployeeId ;
      private string[] H005G3_A148EmployeeName ;
      private long[] H005G4_A124LeaveTypeId ;
      private string[] H005G4_A125LeaveTypeName ;
      private long[] H005G5_A106EmployeeId ;
      private string[] H005G5_A148EmployeeName ;
      private DateTime[] H005G6_A115HolidayStartDate ;
      private long[] H005G6_A113HolidayId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H005G7_A113HolidayId ;
      private string[] H005G7_A114HolidayName ;
      private long[] H005G8_A106EmployeeId ;
      private string[] H005G8_A148EmployeeName ;
      private long[] H005G9_A124LeaveTypeId ;
      private string[] H005G9_A125LeaveTypeName ;
      private long[] H005G10_A113HolidayId ;
      private string[] H005G10_A114HolidayName ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GXWebForm Form ;
      private SdtLeaveRequest AV7LeaveRequest ;
      private SdtLeaveRequest_Holidays AV19Holiday ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
   }

   public class leaverequestwp__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leaverequestwp__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH005G2;
        prmH005G2 = new Object[] {
        };
        Object[] prmH005G3;
        prmH005G3 = new Object[] {
        };
        Object[] prmH005G4;
        prmH005G4 = new Object[] {
        };
        Object[] prmH005G5;
        prmH005G5 = new Object[] {
        };
        Object[] prmH005G6;
        prmH005G6 = new Object[] {
        new ParDef("AV20StartDate",GXType.Date,8,0) ,
        new ParDef("AV22StartDate_To",GXType.Date,8,0)
        };
        Object[] prmH005G7;
        prmH005G7 = new Object[] {
        };
        Object[] prmH005G8;
        prmH005G8 = new Object[] {
        };
        Object[] prmH005G9;
        prmH005G9 = new Object[] {
        };
        Object[] prmH005G10;
        prmH005G10 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H005G2", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005G3", "SELECT EmployeeId, EmployeeName FROM Employee ORDER BY EmployeeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G3,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005G4", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G4,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005G5", "SELECT EmployeeId, EmployeeName FROM Employee ORDER BY EmployeeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G5,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005G6", "SELECT HolidayStartDate, HolidayId FROM Holiday WHERE (HolidayStartDate >= :AV20StartDate) AND (HolidayStartDate < :AV22StartDate_To) ORDER BY HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G6,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H005G7", "SELECT HolidayId, HolidayName FROM Holiday ORDER BY HolidayName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G7,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005G8", "SELECT EmployeeId, EmployeeName FROM Employee ORDER BY EmployeeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G8,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005G9", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G9,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005G10", "SELECT HolidayId, HolidayName FROM Holiday ORDER BY HolidayName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G10,0, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
     }
  }

}

}
