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
   public class wcleavedetails : GXWebComponent
   {
      public wcleavedetails( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wcleavedetails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TrnMode ,
                           ref long aP1_LeaveRequestId )
      {
         this.AV17TrnMode = aP0_TrnMode;
         this.AV10LeaveRequestId = aP1_LeaveRequestId;
         executePrivate();
         aP0_TrnMode=this.AV17TrnMode;
         aP1_LeaveRequestId=this.AV10LeaveRequestId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         radavVacation = new GXRadio();
         cmbavLeaverequest_leaverequeststatus = new GXCombobox();
         radavLeaverequest_leavetypevacationleave = new GXRadio();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV17TrnMode = GetPar( "TrnMode");
                  AssignAttri(sPrefix, false, "AV17TrnMode", AV17TrnMode);
                  AV10LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV10LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV10LeaveRequestId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV17TrnMode,(long)AV10LeaveRequestId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA5E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavLeaverequest_employeename_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
               radavVacation.Enabled = 0;
               AssignProp(sPrefix, false, radavVacation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavVacation.Enabled), 5, 0), true);
               edtavLeaverequest_leavetypename_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leavetypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdate_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequeststartdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestenddate_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestduration_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
               cmbavLeaverequest_leaverequeststatus.Enabled = 0;
               AssignProp(sPrefix, false, cmbavLeaverequest_leaverequeststatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLeaverequest_leaverequeststatus.Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestdescription_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
               edtavLeaverequest_employeebalance_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
               WS5E2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Details") ;
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
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcleavedetails.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17TrnMode)),UrlEncode(StringUtil.LTrimStr(AV10LeaveRequestId,10,0))}, new string[] {"TrnMode","LeaveRequestId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Leaverequest", AV9LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Leaverequest", AV9LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV17TrnMode", StringUtil.RTrim( wcpOAV17TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV10LeaveRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV10LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRNMODE", StringUtil.RTrim( AV17TrnMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLEAVEREQUEST", AV9LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLEAVEREQUEST", AV9LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Title", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Title", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Comment", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Comment));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Bodycontentinternalname", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Result));
      }

      protected void RenderHtmlCloseForm5E2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WCLeaveDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return "Details" ;
      }

      protected void WB5E0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcleavedetails.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNewtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeename_Internalname, StringUtil.RTrim( AV9LeaveRequest.gxTpr_Employeename), StringUtil.RTrim( context.localUtil.Format( AV9LeaveRequest.gxTpr_Employeename, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WCLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavVacation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Deduct from vacation days", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavVacation, radavVacation_Internalname, StringUtil.RTrim( AV20Vacation), "", 1, radavVacation.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavVacation_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "HLP_WCLeaveDetails.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leavetypename_Internalname, StringUtil.RTrim( AV9LeaveRequest.gxTpr_Leavetypename), StringUtil.RTrim( context.localUtil.Format( AV9LeaveRequest.gxTpr_Leavetypename, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leavetypename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leavetypename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WCLeaveDetails.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestdate_Internalname, context.localUtil.Format(AV9LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), context.localUtil.Format( AV9LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCLeaveDetails.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequestdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WCLeaveDetails.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequeststartdate_Internalname, context.localUtil.Format(AV9LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), context.localUtil.Format( AV9LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequeststartdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequeststartdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCLeaveDetails.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequeststartdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WCLeaveDetails.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestenddate_Internalname, context.localUtil.Format(AV9LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), context.localUtil.Format( AV9LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestenddate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestenddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCLeaveDetails.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestenddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequestenddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WCLeaveDetails.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestduration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9LeaveRequest.gxTpr_Leaverequestduration, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_leaverequestduration_Enabled!=0) ? context.localUtil.Format( AV9LeaveRequest.gxTpr_Leaverequestduration, "Z9.9") : context.localUtil.Format( AV9LeaveRequest.gxTpr_Leaverequestduration, "Z9.9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestduration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leaverequestduration_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCLeaveDetails.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavLeaverequest_leaverequeststatus, cmbavLeaverequest_leaverequeststatus_Internalname, StringUtil.RTrim( AV9LeaveRequest.gxTpr_Leaverequeststatus), 1, cmbavLeaverequest_leaverequeststatus_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavLeaverequest_leaverequeststatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_WCLeaveDetails.htm");
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV9LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp(sPrefix, false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", (string)(cmbavLeaverequest_leaverequeststatus.ToJavascriptSource()), true);
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
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestdescription_Internalname, AV9LeaveRequest.gxTpr_Leaverequestdescription, "", "", 0, 1, edtavLeaverequest_leaverequestdescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WCLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeebalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeebalance_Internalname, "Balance", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9LeaveRequest.gxTpr_Employeebalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_employeebalance_Enabled!=0) ? context.localUtil.Format( AV9LeaveRequest.gxTpr_Employeebalance, "Z9.9") : context.localUtil.Format( AV9LeaveRequest.gxTpr_Employeebalance, "Z9.9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeebalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLeaverequest_leaverequestrejectionreason_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
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
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, AV9LeaveRequest.gxTpr_Leaverequestrejectionreason, "", "", 0, 1, edtavLeaverequest_leaverequestrejectionreason_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WCLeaveDetails.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnapprovebutton_Internalname, "", "Approve", bttBtnapprovebutton_Jsonclick, 7, "Approve", "", StyleString, ClassString, bttBtnapprovebutton_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e115e1_client"+"'", TempTags, "", 2, "HLP_WCLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial RedButton";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrejectbutton_Internalname, "", "Reject", bttBtnrejectbutton_Jsonclick, 7, "Reject", "", StyleString, ClassString, bttBtnrejectbutton_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e125e1_client"+"'", TempTags, "", 2, "HLP_WCLeaveDetails.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leavetypevacationleave, radavLeaverequest_leavetypevacationleave_Internalname, StringUtil.RTrim( AV9LeaveRequest.gxTpr_Leavetypevacationleave), "", radavLeaverequest_leavetypevacationleave.Visible, 1, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leavetypevacationleave_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "HLP_WCLeaveDetails.htm");
            wb_table1_86_5E2( true) ;
         }
         else
         {
            wb_table1_86_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_86_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_91_5E2( true) ;
         }
         else
         {
            wb_table2_91_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_91_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_dvelop_confirmpanel_rejectbutton_body_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ConfirmComment";
            StyleString = "";
            ClassString = "ConfirmComment";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDvelop_confirmpanel_rejectbutton_comment_Internalname, AV6DVelop_ConfirmPanel_RejectButton_Comment, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", 0, 1, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "Reason for rejection", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WCLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5E2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP5E0( ) ;
            }
         }
      }

      protected void WS5E2( )
      {
         START5E2( ) ;
         EVT5E2( ) ;
      }

      protected void EVT5E2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E135E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E145E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E155E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E165E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E175E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavLeaverequest_employeename_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE5E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5E2( ) ;
            }
         }
      }

      protected void PA5E2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavLeaverequest_employeename_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         AV20Vacation = StringUtil.RTrim( AV20Vacation);
         AssignAttri(sPrefix, false, "AV20Vacation", AV20Vacation);
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV9LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV9LeaveRequest.gxTpr_Leaverequeststatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV9LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp(sPrefix, false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", cmbavLeaverequest_leaverequeststatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         radavVacation.Enabled = 0;
         AssignProp(sPrefix, false, radavVacation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavVacation.Enabled), 5, 0), true);
         edtavLeaverequest_leavetypename_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leavetypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
         cmbavLeaverequest_leaverequeststatus.Enabled = 0;
         AssignProp(sPrefix, false, cmbavLeaverequest_leaverequeststatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLeaverequest_leaverequeststatus.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_employeebalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
      }

      protected void RF5E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E165E2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E175E2 ();
            WB5E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5E2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         radavVacation.Enabled = 0;
         AssignProp(sPrefix, false, radavVacation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavVacation.Enabled), 5, 0), true);
         edtavLeaverequest_leavetypename_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leavetypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
         cmbavLeaverequest_leaverequeststatus.Enabled = 0;
         AssignProp(sPrefix, false, cmbavLeaverequest_leaverequeststatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLeaverequest_leaverequeststatus.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_employeebalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E155E2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLEAVEREQUEST"), AV9LeaveRequest);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Leaverequest"), AV9LeaveRequest);
            /* Read saved values. */
            wcpOAV17TrnMode = cgiGet( sPrefix+"wcpOAV17TrnMode");
            wcpOAV10LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10LeaveRequestId"), ".", ","), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_approvebutton_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Title");
            Dvelop_confirmpanel_approvebutton_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Confirmationtext");
            Dvelop_confirmpanel_approvebutton_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Yesbuttoncaption");
            Dvelop_confirmpanel_approvebutton_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Nobuttoncaption");
            Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Cancelbuttoncaption");
            Dvelop_confirmpanel_approvebutton_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Yesbuttonposition");
            Dvelop_confirmpanel_approvebutton_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Confirmtype");
            Dvelop_confirmpanel_rejectbutton_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Title");
            Dvelop_confirmpanel_rejectbutton_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Confirmationtext");
            Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Yesbuttoncaption");
            Dvelop_confirmpanel_rejectbutton_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Nobuttoncaption");
            Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Cancelbuttoncaption");
            Dvelop_confirmpanel_rejectbutton_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Yesbuttonposition");
            Dvelop_confirmpanel_rejectbutton_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Confirmtype");
            Dvelop_confirmpanel_rejectbutton_Comment = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Comment");
            Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Bodycontentinternalname");
            Dvelop_confirmpanel_approvebutton_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON_Result");
            Dvelop_confirmpanel_rejectbutton_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON_Result");
            /* Read variables values. */
            AV9LeaveRequest.gxTpr_Employeename = cgiGet( edtavLeaverequest_employeename_Internalname);
            AV20Vacation = cgiGet( radavVacation_Internalname);
            AssignAttri(sPrefix, false, "AV20Vacation", AV20Vacation);
            AV9LeaveRequest.gxTpr_Leavetypename = cgiGet( edtavLeaverequest_leavetypename_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestdate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9LeaveRequest.gxTpr_Leaverequestdate = DateTime.MinValue;
            }
            else
            {
               AV9LeaveRequest.gxTpr_Leaverequestdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 2);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Start Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequeststartdate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9LeaveRequest.gxTpr_Leaverequeststartdate = DateTime.MinValue;
            }
            else
            {
               AV9LeaveRequest.gxTpr_Leaverequeststartdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request End Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTENDDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestenddate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9LeaveRequest.gxTpr_Leaverequestenddate = DateTime.MinValue;
            }
            else
            {
               AV9LeaveRequest.gxTpr_Leaverequestenddate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2);
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTDURATION");
               GX_FocusControl = edtavLeaverequest_leaverequestduration_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9LeaveRequest.gxTpr_Leaverequestduration = 0;
            }
            else
            {
               AV9LeaveRequest.gxTpr_Leaverequestduration = context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",");
            }
            cmbavLeaverequest_leaverequeststatus.CurrentValue = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV9LeaveRequest.gxTpr_Leaverequeststatus = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV9LeaveRequest.gxTpr_Leaverequestdescription = cgiGet( edtavLeaverequest_leaverequestdescription_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_EMPLOYEEBALANCE");
               GX_FocusControl = edtavLeaverequest_employeebalance_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9LeaveRequest.gxTpr_Employeebalance = 0;
            }
            else
            {
               AV9LeaveRequest.gxTpr_Employeebalance = context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",");
            }
            AV9LeaveRequest.gxTpr_Leaverequestrejectionreason = cgiGet( edtavLeaverequest_leaverequestrejectionreason_Internalname);
            AV9LeaveRequest.gxTpr_Leavetypevacationleave = cgiGet( radavLeaverequest_leavetypevacationleave_Internalname);
            AV6DVelop_ConfirmPanel_RejectButton_Comment = cgiGet( edtavDvelop_confirmpanel_rejectbutton_comment_Internalname);
            AssignAttri(sPrefix, false, "AV6DVelop_ConfirmPanel_RejectButton_Comment", AV6DVelop_ConfirmPanel_RejectButton_Comment);
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
         E155E2 ();
         if (returnInSub) return;
      }

      protected void E155E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV9LeaveRequest.Load(AV10LeaveRequestId);
         AV20Vacation = AV9LeaveRequest.gxTpr_Leavetypevacationleave;
         AssignAttri(sPrefix, false, "AV20Vacation", AV20Vacation);
         Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname = edtavDvelop_confirmpanel_rejectbutton_comment_Internalname;
         ucDvelop_confirmpanel_rejectbutton.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_rejectbutton_Internalname, "BodyContentInternalName", Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname);
         radavLeaverequest_leavetypevacationleave.Visible = 0;
         AssignProp(sPrefix, false, radavLeaverequest_leavetypevacationleave_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leavetypevacationleave.Visible), 5, 0), true);
      }

      protected void E165E2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E135E2( )
      {
         /* Dvelop_confirmpanel_approvebutton_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_approvebutton_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION APPROVEBUTTON' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9LeaveRequest", AV9LeaveRequest);
      }

      protected void E145E2( )
      {
         /* Dvelop_confirmpanel_rejectbutton_Close Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Dvelop_confirmpanel_rejectbutton_Result, "Yes") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV6DVelop_ConfirmPanel_RejectButton_Comment)) )
         {
            /* Execute user subroutine: 'DO ACTION REJECTBUTTON' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9LeaveRequest", AV9LeaveRequest);
      }

      protected void S112( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( new userhasrole(context).executeUdp(  "Manager") && ( StringUtil.StrCmp(AV9LeaveRequest.gxTpr_Leaverequeststatus, "Pending") == 0 ) || new userhasrole(context).executeUdp(  "Project Manager") && ( StringUtil.StrCmp(AV9LeaveRequest.gxTpr_Leaverequeststatus, "Pending") == 0 ) ) )
         {
            bttBtnapprovebutton_Visible = 0;
            AssignProp(sPrefix, false, bttBtnapprovebutton_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnapprovebutton_Visible), 5, 0), true);
         }
         if ( ! ( new userhasrole(context).executeUdp(  "Manager") && ( StringUtil.StrCmp(AV9LeaveRequest.gxTpr_Leaverequeststatus, "Pending") == 0 ) || new userhasrole(context).executeUdp(  "Project Manager") && ( StringUtil.StrCmp(AV9LeaveRequest.gxTpr_Leaverequeststatus, "Pending") == 0 ) ) )
         {
            bttBtnrejectbutton_Visible = 0;
            AssignProp(sPrefix, false, bttBtnrejectbutton_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnrejectbutton_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'DO ACTION APPROVEBUTTON' Routine */
         returnInSub = false;
         AV9LeaveRequest.gxTpr_Leaverequeststatus = "Approved";
         if ( AV9LeaveRequest.Update() )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            AV7Employee.Load(AV9LeaveRequest.gxTpr_Employeeid);
            AV11LeaveType.Load(AV9LeaveRequest.gxTpr_Leavetypeid);
            if ( StringUtil.StrCmp(AV11LeaveType.gxTpr_Leavetypevacationleave, "Yes") == 0 )
            {
               AV7Employee.gxTpr_Employeebalance = (decimal)(AV7Employee.gxTpr_Employeebalance-AV9LeaveRequest.gxTpr_Leaverequestduration);
            }
            if ( AV7Employee.Update() )
            {
               GXt_char1 = AV11LeaveType.gxTpr_Leavetypename + " approved";
               GXt_char2 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Approved</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV7Employee.gxTpr_Employeename + ",</p>" + "<p>We are pleased to inform you that your leave request has been approved. </p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV9LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p>" + "<p>End Date: <b>" + context.localUtil.DToC( AV9LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p>" + "<p>Description: <b>" + AV9LeaveRequest.gxTpr_Leaverequestdescription + "</b></p><p>If you have any questions or need further assistance, please do not hesitate to contact us.</p><p>Best Regards,</p><p>Yukon Time Tracker Team</p></div></div>";
               new sendemail(context).executeSubmit(  AV7Employee.gxTpr_Employeeemail, ref  GXt_char1, ref  GXt_char2) ;
               context.CommitDataStores("wcleavedetails",pr_default);
               context.DoAjaxRefreshCmp(sPrefix);
               GX_msglist.addItem("Leave Approved Successfully");
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
               context.setWebReturnParms(new Object[] {(string)AV17TrnMode,(long)AV10LeaveRequestId});
               context.setWebReturnParmsMetadata(new Object[] {"AV17TrnMode","AV10LeaveRequestId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
               new sdsendpushnotifications(context ).execute(  "Leave Request Approved",  "Your leave request made on "+context.localUtil.DToC( AV9LeaveRequest.gxTpr_Leaverequestdate, 2, "/")+" has been approved",  AV9LeaveRequest.gxTpr_Employeeid) ;
            }
            else
            {
               context.RollbackDataStores("wcleavedetails",pr_default);
            }
         }
         else
         {
            context.RollbackDataStores("wcleavedetails",pr_default);
            GX_msglist.addItem(AV9LeaveRequest.GetMessages().ToJSonString(false));
         }
      }

      protected void S132( )
      {
         /* 'DO ACTION REJECTBUTTON' Routine */
         returnInSub = false;
         AV9LeaveRequest.gxTpr_Leaverequeststatus = "Rejected";
         AV9LeaveRequest.gxTpr_Leaverequestrejectionreason = AV6DVelop_ConfirmPanel_RejectButton_Comment;
         if ( AV9LeaveRequest.Update() )
         {
            AV7Employee.Load(AV9LeaveRequest.gxTpr_Employeeid);
            AV11LeaveType.Load(AV9LeaveRequest.gxTpr_Leavetypeid);
            GXt_char2 = AV11LeaveType.gxTpr_Leavetypename + " rejected";
            GXt_char1 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Rejected</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV7Employee.gxTpr_Employeename + ",</p>" + "<p>We regret to inform you that your leave request has been rejected. </p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV9LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p>" + "<p>EndDate: <b>" + context.localUtil.DToC( AV9LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p>" + "<p>Reason for Rejection: <b>" + AV9LeaveRequest.gxTpr_Leaverequestrejectionreason + "</b></p><p>If you have any concerns or need clarification, please reach out to us.</p><p> Best Regards</p><p>The Yukon Time Tracker Team</p></div></div>";
            new sendemail(context).executeSubmit(  AV7Employee.gxTpr_Employeeemail, ref  GXt_char2, ref  GXt_char1) ;
            new logtofile(context ).execute(  "rejected") ;
            context.CommitDataStores("wcleavedetails",pr_default);
            GX_msglist.addItem("Leave Rejected Successfully");
            new sdsendpushnotifications(context ).execute(  "Leave Request Rejected",  "Your leave request made on "+context.localUtil.DToC( AV9LeaveRequest.gxTpr_Leaverequestdate, 2, "/")+" has been rejected",  AV9LeaveRequest.gxTpr_Employeeid) ;
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
            context.setWebReturnParms(new Object[] {(string)AV17TrnMode,(long)AV10LeaveRequestId});
            context.setWebReturnParmsMetadata(new Object[] {"AV17TrnMode","AV10LeaveRequestId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            context.RollbackDataStores("wcleavedetails",pr_default);
            GX_msglist.addItem(AV9LeaveRequest.GetMessages().ToJSonString(false));
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E175E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_91_5E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_rejectbutton_Internalname, tblTabledvelop_confirmpanel_rejectbutton_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_rejectbutton.SetProperty("Title", Dvelop_confirmpanel_rejectbutton_Title);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("ConfirmationText", Dvelop_confirmpanel_rejectbutton_Confirmationtext);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("YesButtonCaption", Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("NoButtonCaption", Dvelop_confirmpanel_rejectbutton_Nobuttoncaption);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("YesButtonPosition", Dvelop_confirmpanel_rejectbutton_Yesbuttonposition);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("ConfirmType", Dvelop_confirmpanel_rejectbutton_Confirmtype);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("Comment", Dvelop_confirmpanel_rejectbutton_Comment);
            ucDvelop_confirmpanel_rejectbutton.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_rejectbutton_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTONContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_91_5E2e( true) ;
         }
         else
         {
            wb_table2_91_5E2e( false) ;
         }
      }

      protected void wb_table1_86_5E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_approvebutton_Internalname, tblTabledvelop_confirmpanel_approvebutton_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_approvebutton.SetProperty("Title", Dvelop_confirmpanel_approvebutton_Title);
            ucDvelop_confirmpanel_approvebutton.SetProperty("ConfirmationText", Dvelop_confirmpanel_approvebutton_Confirmationtext);
            ucDvelop_confirmpanel_approvebutton.SetProperty("YesButtonCaption", Dvelop_confirmpanel_approvebutton_Yesbuttoncaption);
            ucDvelop_confirmpanel_approvebutton.SetProperty("NoButtonCaption", Dvelop_confirmpanel_approvebutton_Nobuttoncaption);
            ucDvelop_confirmpanel_approvebutton.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption);
            ucDvelop_confirmpanel_approvebutton.SetProperty("YesButtonPosition", Dvelop_confirmpanel_approvebutton_Yesbuttonposition);
            ucDvelop_confirmpanel_approvebutton.SetProperty("ConfirmType", Dvelop_confirmpanel_approvebutton_Confirmtype);
            ucDvelop_confirmpanel_approvebutton.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_approvebutton_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTONContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_86_5E2e( true) ;
         }
         else
         {
            wb_table1_86_5E2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17TrnMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV17TrnMode", AV17TrnMode);
         AV10LeaveRequestId = Convert.ToInt64(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV10LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV10LeaveRequestId), 10, 0));
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
         PA5E2( ) ;
         WS5E2( ) ;
         WE5E2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV17TrnMode = (string)((string)getParm(obj,0));
         sCtrlAV10LeaveRequestId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA5E2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcleavedetails", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5E2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV17TrnMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV17TrnMode", AV17TrnMode);
            AV10LeaveRequestId = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV10LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV10LeaveRequestId), 10, 0));
         }
         wcpOAV17TrnMode = cgiGet( sPrefix+"wcpOAV17TrnMode");
         wcpOAV10LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10LeaveRequestId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV17TrnMode, wcpOAV17TrnMode) != 0 ) || ( AV10LeaveRequestId != wcpOAV10LeaveRequestId ) ) )
         {
            setjustcreated();
         }
         wcpOAV17TrnMode = AV17TrnMode;
         wcpOAV10LeaveRequestId = AV10LeaveRequestId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV17TrnMode = cgiGet( sPrefix+"AV17TrnMode_CTRL");
         if ( StringUtil.Len( sCtrlAV17TrnMode) > 0 )
         {
            AV17TrnMode = cgiGet( sCtrlAV17TrnMode);
            AssignAttri(sPrefix, false, "AV17TrnMode", AV17TrnMode);
         }
         else
         {
            AV17TrnMode = cgiGet( sPrefix+"AV17TrnMode_PARM");
         }
         sCtrlAV10LeaveRequestId = cgiGet( sPrefix+"AV10LeaveRequestId_CTRL");
         if ( StringUtil.Len( sCtrlAV10LeaveRequestId) > 0 )
         {
            AV10LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV10LeaveRequestId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV10LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV10LeaveRequestId), 10, 0));
         }
         else
         {
            AV10LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV10LeaveRequestId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA5E2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS5E2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV17TrnMode_PARM", StringUtil.RTrim( AV17TrnMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV17TrnMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV17TrnMode_CTRL", StringUtil.RTrim( sCtrlAV17TrnMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10LeaveRequestId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10LeaveRequestId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10LeaveRequestId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10LeaveRequestId_CTRL", StringUtil.RTrim( sCtrlAV10LeaveRequestId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE5E2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247615441144", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wcleavedetails.js", "?20247615441145", false, true);
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
         radavVacation.Name = "vVACATION";
         radavVacation.WebTags = "";
         radavVacation.addItem("No", "No", 0);
         radavVacation.addItem("Yes", "Yes", 0);
         cmbavLeaverequest_leaverequeststatus.Name = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         cmbavLeaverequest_leaverequeststatus.WebTags = "";
         cmbavLeaverequest_leaverequeststatus.addItem("Pending", "Pending", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Approved", "Approved", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Rejected", "Rejected", 0);
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
         }
         radavLeaverequest_leavetypevacationleave.Name = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         radavLeaverequest_leavetypevacationleave.WebTags = "";
         radavLeaverequest_leavetypevacationleave.addItem("No", "No", 0);
         radavLeaverequest_leavetypevacationleave.addItem("Yes", "Yes", 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavLeaverequest_employeename_Internalname = sPrefix+"LEAVEREQUEST_EMPLOYEENAME";
         radavVacation_Internalname = sPrefix+"vVACATION";
         edtavLeaverequest_leavetypename_Internalname = sPrefix+"LEAVEREQUEST_LEAVETYPENAME";
         edtavLeaverequest_leaverequestdate_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTDATE";
         edtavLeaverequest_leaverequeststartdate_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTSTARTDATE";
         edtavLeaverequest_leaverequestenddate_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTENDDATE";
         edtavLeaverequest_leaverequestduration_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTDURATION";
         cmbavLeaverequest_leaverequeststatus_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTSTATUS";
         edtavLeaverequest_leaverequestdescription_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION";
         edtavLeaverequest_employeebalance_Internalname = sPrefix+"LEAVEREQUEST_EMPLOYEEBALANCE";
         edtavLeaverequest_leaverequestrejectionreason_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON";
         divLeaverequest_leaverequestrejectionreason_cell_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON_CELL";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         bttBtnapprovebutton_Internalname = sPrefix+"BTNAPPROVEBUTTON";
         bttBtnrejectbutton_Internalname = sPrefix+"BTNREJECTBUTTON";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divNewtable_Internalname = sPrefix+"NEWTABLE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         radavLeaverequest_leavetypevacationleave_Internalname = sPrefix+"LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         Dvelop_confirmpanel_approvebutton_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_APPROVEBUTTON";
         tblTabledvelop_confirmpanel_approvebutton_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_APPROVEBUTTON";
         Dvelop_confirmpanel_rejectbutton_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_REJECTBUTTON";
         tblTabledvelop_confirmpanel_rejectbutton_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_REJECTBUTTON";
         edtavDvelop_confirmpanel_rejectbutton_comment_Internalname = sPrefix+"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT";
         divDiv_dvelop_confirmpanel_rejectbutton_body_Internalname = sPrefix+"DIV_DVELOP_CONFIRMPANEL_REJECTBUTTON_BODY";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         radavLeaverequest_leavetypevacationleave_Jsonclick = "";
         radavLeaverequest_leavetypevacationleave.Visible = 1;
         bttBtnrejectbutton_Visible = 1;
         bttBtnapprovebutton_Visible = 1;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         edtavLeaverequest_employeebalance_Jsonclick = "";
         edtavLeaverequest_employeebalance_Enabled = 0;
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
         radavVacation_Jsonclick = "";
         radavVacation.Enabled = 1;
         edtavLeaverequest_employeename_Jsonclick = "";
         edtavLeaverequest_employeename_Enabled = 0;
         Dvelop_confirmpanel_rejectbutton_Comment = "Required";
         Dvelop_confirmpanel_rejectbutton_Confirmtype = "1";
         Dvelop_confirmpanel_rejectbutton_Yesbuttonposition = "left";
         Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_rejectbutton_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_rejectbutton_Confirmationtext = "Are you sure you want to reject leave?";
         Dvelop_confirmpanel_rejectbutton_Title = "Reject leave";
         Dvelop_confirmpanel_approvebutton_Confirmtype = "1";
         Dvelop_confirmpanel_approvebutton_Yesbuttonposition = "left";
         Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_approvebutton_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_approvebutton_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_approvebutton_Confirmationtext = "Are you sure you want to approve this leave?";
         Dvelop_confirmpanel_approvebutton_Title = "Approve leave";
         edtavLeaverequest_leaverequestrejectionreason_Enabled = -1;
         edtavLeaverequest_employeebalance_Enabled = -1;
         edtavLeaverequest_leaverequestdescription_Enabled = -1;
         cmbavLeaverequest_leaverequeststatus.Enabled = -1;
         edtavLeaverequest_leaverequestduration_Enabled = -1;
         edtavLeaverequest_leaverequestenddate_Enabled = -1;
         edtavLeaverequest_leaverequeststartdate_Enabled = -1;
         edtavLeaverequest_leaverequestdate_Enabled = -1;
         edtavLeaverequest_leavetypename_Enabled = -1;
         edtavLeaverequest_employeename_Enabled = -1;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV9LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'radavVacation'},{av:'AV20Vacation',fld:'vVACATION',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV11',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'BTNAPPROVEBUTTON',prop:'Visible'},{ctrl:'BTNREJECTBUTTON',prop:'Visible'}]}");
         setEventMetadata("'DOAPPROVEBUTTON'","{handler:'E115E1',iparms:[]");
         setEventMetadata("'DOAPPROVEBUTTON'",",oparms:[]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE","{handler:'E135E2',iparms:[{av:'Dvelop_confirmpanel_approvebutton_Result',ctrl:'DVELOP_CONFIRMPANEL_APPROVEBUTTON',prop:'Result'},{av:'AV9LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'AV10LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9'},{av:'AV17TrnMode',fld:'vTRNMODE',pic:''}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE",",oparms:[{av:'AV9LeaveRequest',fld:'vLEAVEREQUEST',pic:''}]}");
         setEventMetadata("'DOREJECTBUTTON'","{handler:'E125E1',iparms:[]");
         setEventMetadata("'DOREJECTBUTTON'",",oparms:[{av:'AV6DVelop_ConfirmPanel_RejectButton_Comment',fld:'vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT',pic:''}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE","{handler:'E145E2',iparms:[{av:'Dvelop_confirmpanel_rejectbutton_Result',ctrl:'DVELOP_CONFIRMPANEL_REJECTBUTTON',prop:'Result'},{av:'AV6DVelop_ConfirmPanel_RejectButton_Comment',fld:'vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT',pic:''},{av:'AV9LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'AV10LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9'},{av:'AV17TrnMode',fld:'vTRNMODE',pic:''}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE",",oparms:[{av:'AV9LeaveRequest',fld:'vLEAVEREQUEST',pic:''}]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
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
         wcpOAV17TrnMode = "";
         Dvelop_confirmpanel_approvebutton_Result = "";
         Dvelop_confirmpanel_rejectbutton_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV9LeaveRequest = new SdtLeaveRequest(context);
         Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV20Vacation = "";
         bttBtnapprovebutton_Jsonclick = "";
         bttBtnrejectbutton_Jsonclick = "";
         AV6DVelop_ConfirmPanel_RejectButton_Comment = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         ucDvelop_confirmpanel_rejectbutton = new GXUserControl();
         AV7Employee = new SdtEmployee(context);
         AV11LeaveType = new SdtLeaveType(context);
         GXt_char2 = "";
         GXt_char1 = "";
         sStyleString = "";
         ucDvelop_confirmpanel_approvebutton = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV17TrnMode = "";
         sCtrlAV10LeaveRequestId = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wcleavedetails__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcleavedetails__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavLeaverequest_employeename_Enabled = 0;
         radavVacation.Enabled = 0;
         edtavLeaverequest_leavetypename_Enabled = 0;
         edtavLeaverequest_leaverequestdate_Enabled = 0;
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         cmbavLeaverequest_leaverequeststatus.Enabled = 0;
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         edtavLeaverequest_employeebalance_Enabled = 0;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
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
      private int edtavLeaverequest_employeebalance_Enabled ;
      private int edtavLeaverequest_leaverequestrejectionreason_Enabled ;
      private int bttBtnapprovebutton_Visible ;
      private int bttBtnrejectbutton_Visible ;
      private int idxLst ;
      private long AV10LeaveRequestId ;
      private long wcpOAV10LeaveRequestId ;
      private string AV17TrnMode ;
      private string wcpOAV17TrnMode ;
      private string Dvelop_confirmpanel_approvebutton_Result ;
      private string Dvelop_confirmpanel_rejectbutton_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavLeaverequest_employeename_Internalname ;
      private string radavVacation_Internalname ;
      private string edtavLeaverequest_leavetypename_Internalname ;
      private string edtavLeaverequest_leaverequestdate_Internalname ;
      private string edtavLeaverequest_leaverequeststartdate_Internalname ;
      private string edtavLeaverequest_leaverequestenddate_Internalname ;
      private string edtavLeaverequest_leaverequestduration_Internalname ;
      private string cmbavLeaverequest_leaverequeststatus_Internalname ;
      private string edtavLeaverequest_leaverequestdescription_Internalname ;
      private string edtavLeaverequest_employeebalance_Internalname ;
      private string edtavLeaverequest_leaverequestrejectionreason_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvelop_confirmpanel_approvebutton_Title ;
      private string Dvelop_confirmpanel_approvebutton_Confirmationtext ;
      private string Dvelop_confirmpanel_approvebutton_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_approvebutton_Nobuttoncaption ;
      private string Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_approvebutton_Yesbuttonposition ;
      private string Dvelop_confirmpanel_approvebutton_Confirmtype ;
      private string Dvelop_confirmpanel_rejectbutton_Title ;
      private string Dvelop_confirmpanel_rejectbutton_Confirmationtext ;
      private string Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_rejectbutton_Nobuttoncaption ;
      private string Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_rejectbutton_Yesbuttonposition ;
      private string Dvelop_confirmpanel_rejectbutton_Confirmtype ;
      private string Dvelop_confirmpanel_rejectbutton_Comment ;
      private string Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divNewtable_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavLeaverequest_employeename_Jsonclick ;
      private string TempTags ;
      private string AV20Vacation ;
      private string radavVacation_Jsonclick ;
      private string edtavLeaverequest_leavetypename_Jsonclick ;
      private string edtavLeaverequest_leaverequestdate_Jsonclick ;
      private string edtavLeaverequest_leaverequeststartdate_Jsonclick ;
      private string edtavLeaverequest_leaverequestenddate_Jsonclick ;
      private string edtavLeaverequest_leaverequestduration_Jsonclick ;
      private string cmbavLeaverequest_leaverequeststatus_Jsonclick ;
      private string edtavLeaverequest_employeebalance_Jsonclick ;
      private string divLeaverequest_leaverequestrejectionreason_cell_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string bttBtnapprovebutton_Internalname ;
      private string bttBtnapprovebutton_Jsonclick ;
      private string bttBtnrejectbutton_Internalname ;
      private string bttBtnrejectbutton_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string radavLeaverequest_leavetypevacationleave_Internalname ;
      private string radavLeaverequest_leavetypevacationleave_Jsonclick ;
      private string divDiv_dvelop_confirmpanel_rejectbutton_body_Internalname ;
      private string edtavDvelop_confirmpanel_rejectbutton_comment_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string Dvelop_confirmpanel_rejectbutton_Internalname ;
      private string GXt_char2 ;
      private string GXt_char1 ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_rejectbutton_Internalname ;
      private string tblTabledvelop_confirmpanel_approvebutton_Internalname ;
      private string Dvelop_confirmpanel_approvebutton_Internalname ;
      private string sCtrlAV17TrnMode ;
      private string sCtrlAV10LeaveRequestId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV6DVelop_ConfirmPanel_RejectButton_Comment ;
      private GXUserControl ucDvelop_confirmpanel_rejectbutton ;
      private GXUserControl ucDvelop_confirmpanel_approvebutton ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_TrnMode ;
      private long aP1_LeaveRequestId ;
      private GXRadio radavVacation ;
      private GXCombobox cmbavLeaverequest_leaverequeststatus ;
      private GXRadio radavLeaverequest_leavetypevacationleave ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private SdtEmployee AV7Employee ;
      private SdtLeaveRequest AV9LeaveRequest ;
      private SdtLeaveType AV11LeaveType ;
   }

   public class wcleavedetails__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wcleavedetails__default : DataStoreHelperBase, IDataStoreHelper
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
