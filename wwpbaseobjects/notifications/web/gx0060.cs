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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class gx0060 : GXDataArea
   {
      public gx0060( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0060( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pWWPWebNotificationId )
      {
         this.AV13pWWPWebNotificationId = 0 ;
         executePrivate();
         aP0_pWWPWebNotificationId=this.AV13pWWPWebNotificationId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCwwpwebnotificationstatus = new GXCombobox();
         cmbWWPWebNotificationStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pWWPWebNotificationId");
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
               gxfirstwebparm = GetFirstPar( "pWWPWebNotificationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pWWPWebNotificationId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pWWPWebNotificationId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pWWPWebNotificationId", StringUtil.LTrimStr( (decimal)(AV13pWWPWebNotificationId), 10, 0));
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
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
         AV6cWWPWebNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPWebNotificationId"), "."), 18, MidpointRounding.ToEven));
         AV7cWWPWebNotificationTitle = GetPar( "cWWPWebNotificationTitle");
         AV8cWWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPNotificationId"), "."), 18, MidpointRounding.ToEven));
         cmbavCwwpwebnotificationstatus.FromJSonString( GetNextPar( ));
         AV9cWWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( GetPar( "cWWPWebNotificationStatus"), "."), 18, MidpointRounding.ToEven));
         AV10cWWPWebNotificationCreated = context.localUtil.ParseDTimeParm( GetPar( "cWWPWebNotificationCreated"));
         AV11cWWPWebNotificationScheduled = context.localUtil.ParseDTimeParm( GetPar( "cWWPWebNotificationScheduled"));
         AV12cWWPWebNotificationProcessed = context.localUtil.ParseDTimeParm( GetPar( "cWWPWebNotificationProcessed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPWebNotificationId, AV7cWWPWebNotificationTitle, AV8cWWPNotificationId, AV9cWWPWebNotificationStatus, AV10cWWPWebNotificationCreated, AV11cWWPWebNotificationScheduled, AV12cWWPWebNotificationProcessed) ;
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
            return "gx0060_Execute" ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA5H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5H2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.web.gx0060.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pWWPWebNotificationId,10,0))}, new string[] {"pWWPWebNotificationId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPWEBNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPWebNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPWEBNOTIFICATIONTITLE", AV7cWWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cWWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPWEBNOTIFICATIONSTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cWWPWebNotificationStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPWEBNOTIFICATIONCREATED", context.localUtil.TToC( AV10cWWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPWEBNOTIFICATIONSCHEDULED", context.localUtil.TToC( AV11cWWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPWEBNOTIFICATIONPROCESSED", context.localUtil.TToC( AV12cWWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPWWPWEBNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pWWPWebNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "WWPWEBNOTIFICATIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpwebnotificationidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPWEBNOTIFICATIONTITLEFILTERCONTAINER_Class", StringUtil.RTrim( divWwpwebnotificationtitlefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpnotificationidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPWEBNOTIFICATIONSTATUSFILTERCONTAINER_Class", StringUtil.RTrim( divWwpwebnotificationstatusfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE5H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5H2( ) ;
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
         return formatLink("wwpbaseobjects.notifications.web.gx0060.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pWWPWebNotificationId,10,0))}, new string[] {"pWWPWebNotificationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Web.Gx0060" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List WWP_WebNotification" ;
      }

      protected void WB5H0( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpwebnotificationidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpwebnotificationidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpwebnotificationidfilter_Internalname, "Web Notification Id", "", "", lblLblwwpwebnotificationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e115h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpwebnotificationid_Internalname, "Web Notification Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpwebnotificationid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPWebNotificationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCwwpwebnotificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cWWPWebNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cWWPWebNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpwebnotificationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpwebnotificationid_Visible, edtavCwwpwebnotificationid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divWwpwebnotificationtitlefiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpwebnotificationtitlefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpwebnotificationtitlefilter_Internalname, "Web Notification Title", "", "", lblLblwwpwebnotificationtitlefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e125h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpwebnotificationtitle_Internalname, "Web Notification Title", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpwebnotificationtitle_Internalname, AV7cWWPWebNotificationTitle, StringUtil.RTrim( context.localUtil.Format( AV7cWWPWebNotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpwebnotificationtitle_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpwebnotificationtitle_Visible, edtavCwwpwebnotificationtitle_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divWwpnotificationidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpnotificationidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationidfilter_Internalname, "Notification Id", "", "", lblLblwwpnotificationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e135h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpnotificationid_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpnotificationid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cWWPNotificationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCwwpnotificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cWWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cWWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpnotificationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpnotificationid_Visible, edtavCwwpnotificationid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divWwpwebnotificationstatusfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpwebnotificationstatusfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpwebnotificationstatusfilter_Internalname, "Web Notification Status", "", "", lblLblwwpwebnotificationstatusfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e145h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCwwpwebnotificationstatus_Internalname, "Web Notification Status", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCwwpwebnotificationstatus, cmbavCwwpwebnotificationstatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9cWWPWebNotificationStatus), 4, 0)), 1, cmbavCwwpwebnotificationstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCwwpwebnotificationstatus.Visible, cmbavCwwpwebnotificationstatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            cmbavCwwpwebnotificationstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9cWWPWebNotificationStatus), 4, 0));
            AssignProp("", false, cmbavCwwpwebnotificationstatus_Internalname, "Values", (string)(cmbavCwwpwebnotificationstatus.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divWwpwebnotificationcreatedfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpwebnotificationcreatedfilter_Internalname, "Web Notification Created", "", "", lblLblwwpwebnotificationcreatedfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpwebnotificationcreated_Internalname, "Web Notification Created", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpwebnotificationcreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpwebnotificationcreated_Internalname, context.localUtil.TToC( AV10cWWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( AV10cWWPWebNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpwebnotificationcreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpwebnotificationcreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divWwpwebnotificationscheduledfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpwebnotificationscheduledfilter_Internalname, "Web Notification Scheduled", "", "", lblLblwwpwebnotificationscheduledfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpwebnotificationscheduled_Internalname, "Web Notification Scheduled", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpwebnotificationscheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpwebnotificationscheduled_Internalname, context.localUtil.TToC( AV11cWWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( AV11cWWPWebNotificationScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpwebnotificationscheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpwebnotificationscheduled_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divWwpwebnotificationprocessedfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpwebnotificationprocessedfilter_Internalname, "Web Notification Processed", "", "", lblLblwwpwebnotificationprocessedfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpwebnotificationprocessed_Internalname, "Web Notification Processed", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpwebnotificationprocessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpwebnotificationprocessed_Internalname, context.localUtil.TToC( AV12cWWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( AV12cWWPWebNotificationProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpwebnotificationprocessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpwebnotificationprocessed_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e155h1_client"+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/Gx0060.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
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

      protected void START5H2( )
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
         Form.Meta.addItem("description", "Selection List WWP_WebNotification", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5H0( ) ;
      }

      protected void WS5H2( )
      {
         START5H2( ) ;
         EVT5H2( ) ;
      }

      protected void EVT5H2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A47WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A42WWPWebNotificationTitle = cgiGet( edtWWPWebNotificationTitle_Internalname);
                              A22WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n22WWPNotificationId = false;
                              cmbWWPWebNotificationStatus.Name = cmbWWPWebNotificationStatus_Internalname;
                              cmbWWPWebNotificationStatus.CurrentValue = cgiGet( cmbWWPWebNotificationStatus_Internalname);
                              A54WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPWebNotificationStatus_Internalname), "."), 18, MidpointRounding.ToEven));
                              A45WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPWebNotificationCreated_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E165H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E175H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cwwpwebnotificationid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPWEBNOTIFICATIONID"), ".", ",") != Convert.ToDecimal( AV6cWWPWebNotificationId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpwebnotificationtitle Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPWEBNOTIFICATIONTITLE"), AV7cWWPWebNotificationTitle) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpnotificationid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONID"), ".", ",") != Convert.ToDecimal( AV8cWWPNotificationId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpwebnotificationstatus Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPWEBNOTIFICATIONSTATUS"), ".", ",") != Convert.ToDecimal( AV9cWWPWebNotificationStatus )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpwebnotificationcreated Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPWEBNOTIFICATIONCREATED"), 0) != AV10cWWPWebNotificationCreated )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpwebnotificationscheduled Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPWEBNOTIFICATIONSCHEDULED"), 0) != AV11cWWPWebNotificationScheduled )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpwebnotificationprocessed Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPWEBNOTIFICATIONPROCESSED"), 0) != AV12cWWPWebNotificationProcessed )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E185H2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE5H2( )
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

      protected void PA5H2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cWWPWebNotificationId ,
                                        string AV7cWWPWebNotificationTitle ,
                                        long AV8cWWPNotificationId ,
                                        short AV9cWWPWebNotificationStatus ,
                                        DateTime AV10cWWPWebNotificationCreated ,
                                        DateTime AV11cWWPWebNotificationScheduled ,
                                        DateTime AV12cWWPWebNotificationProcessed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF5H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPWEBNOTIFICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A47WWPWebNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPWEBNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A47WWPWebNotificationId), 10, 0, ".", "")));
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
         if ( cmbavCwwpwebnotificationstatus.ItemCount > 0 )
         {
            AV9cWWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbavCwwpwebnotificationstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9cWWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9cWWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(AV9cWWPWebNotificationStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCwwpwebnotificationstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9cWWPWebNotificationStatus), 4, 0));
            AssignProp("", false, cmbavCwwpwebnotificationstatus_Internalname, "Values", cmbavCwwpwebnotificationstatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cWWPWebNotificationTitle ,
                                                 AV8cWWPNotificationId ,
                                                 AV9cWWPWebNotificationStatus ,
                                                 AV10cWWPWebNotificationCreated ,
                                                 AV11cWWPWebNotificationScheduled ,
                                                 AV12cWWPWebNotificationProcessed ,
                                                 A42WWPWebNotificationTitle ,
                                                 A22WWPNotificationId ,
                                                 A54WWPWebNotificationStatus ,
                                                 A45WWPWebNotificationCreated ,
                                                 A58WWPWebNotificationScheduled ,
                                                 A55WWPWebNotificationProcessed ,
                                                 AV6cWWPWebNotificationId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.LONG
                                                 }
            });
            lV7cWWPWebNotificationTitle = StringUtil.Concat( StringUtil.RTrim( AV7cWWPWebNotificationTitle), "%", "");
            /* Using cursor H005H2 */
            pr_default.execute(0, new Object[] {AV6cWWPWebNotificationId, lV7cWWPWebNotificationTitle, AV8cWWPNotificationId, AV9cWWPWebNotificationStatus, AV10cWWPWebNotificationCreated, AV11cWWPWebNotificationScheduled, AV12cWWPWebNotificationProcessed, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A55WWPWebNotificationProcessed = H005H2_A55WWPWebNotificationProcessed[0];
               A58WWPWebNotificationScheduled = H005H2_A58WWPWebNotificationScheduled[0];
               A45WWPWebNotificationCreated = H005H2_A45WWPWebNotificationCreated[0];
               A54WWPWebNotificationStatus = H005H2_A54WWPWebNotificationStatus[0];
               A22WWPNotificationId = H005H2_A22WWPNotificationId[0];
               n22WWPNotificationId = H005H2_n22WWPNotificationId[0];
               A42WWPWebNotificationTitle = H005H2_A42WWPWebNotificationTitle[0];
               A47WWPWebNotificationId = H005H2_A47WWPWebNotificationId[0];
               /* Execute user event: Load */
               E175H2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB5H0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5H2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPWEBNOTIFICATIONID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A47WWPWebNotificationId), "ZZZZZZZZZ9"), context));
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
                                              AV7cWWPWebNotificationTitle ,
                                              AV8cWWPNotificationId ,
                                              AV9cWWPWebNotificationStatus ,
                                              AV10cWWPWebNotificationCreated ,
                                              AV11cWWPWebNotificationScheduled ,
                                              AV12cWWPWebNotificationProcessed ,
                                              A42WWPWebNotificationTitle ,
                                              A22WWPNotificationId ,
                                              A54WWPWebNotificationStatus ,
                                              A45WWPWebNotificationCreated ,
                                              A58WWPWebNotificationScheduled ,
                                              A55WWPWebNotificationProcessed ,
                                              AV6cWWPWebNotificationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV7cWWPWebNotificationTitle = StringUtil.Concat( StringUtil.RTrim( AV7cWWPWebNotificationTitle), "%", "");
         /* Using cursor H005H3 */
         pr_default.execute(1, new Object[] {AV6cWWPWebNotificationId, lV7cWWPWebNotificationTitle, AV8cWWPNotificationId, AV9cWWPWebNotificationStatus, AV10cWWPWebNotificationCreated, AV11cWWPWebNotificationScheduled, AV12cWWPWebNotificationProcessed});
         GRID1_nRecordCount = H005H3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPWebNotificationId, AV7cWWPWebNotificationTitle, AV8cWWPNotificationId, AV9cWWPWebNotificationStatus, AV10cWWPWebNotificationCreated, AV11cWWPWebNotificationScheduled, AV12cWWPWebNotificationProcessed) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPWebNotificationId, AV7cWWPWebNotificationTitle, AV8cWWPNotificationId, AV9cWWPWebNotificationStatus, AV10cWWPWebNotificationCreated, AV11cWWPWebNotificationScheduled, AV12cWWPWebNotificationProcessed) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPWebNotificationId, AV7cWWPWebNotificationTitle, AV8cWWPNotificationId, AV9cWWPWebNotificationStatus, AV10cWWPWebNotificationCreated, AV11cWWPWebNotificationScheduled, AV12cWWPWebNotificationProcessed) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPWebNotificationId, AV7cWWPWebNotificationTitle, AV8cWWPNotificationId, AV9cWWPWebNotificationStatus, AV10cWWPWebNotificationCreated, AV11cWWPWebNotificationScheduled, AV12cWWPWebNotificationProcessed) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPWebNotificationId, AV7cWWPWebNotificationTitle, AV8cWWPNotificationId, AV9cWWPWebNotificationStatus, AV10cWWPWebNotificationCreated, AV11cWWPWebNotificationScheduled, AV12cWWPWebNotificationProcessed) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtWWPWebNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtWWPWebNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationTitle_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         cmbWWPWebNotificationStatus.Enabled = 0;
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPWebNotificationStatus.Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtWWPWebNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationCreated_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E165H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpwebnotificationid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpwebnotificationid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPWEBNOTIFICATIONID");
               GX_FocusControl = edtavCwwpwebnotificationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cWWPWebNotificationId = 0;
               AssignAttri("", false, "AV6cWWPWebNotificationId", StringUtil.LTrimStr( (decimal)(AV6cWWPWebNotificationId), 10, 0));
            }
            else
            {
               AV6cWWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpwebnotificationid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cWWPWebNotificationId", StringUtil.LTrimStr( (decimal)(AV6cWWPWebNotificationId), 10, 0));
            }
            AV7cWWPWebNotificationTitle = cgiGet( edtavCwwpwebnotificationtitle_Internalname);
            AssignAttri("", false, "AV7cWWPWebNotificationTitle", AV7cWWPWebNotificationTitle);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPNOTIFICATIONID");
               GX_FocusControl = edtavCwwpnotificationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cWWPNotificationId = 0;
               AssignAttri("", false, "AV8cWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV8cWWPNotificationId), 10, 0));
            }
            else
            {
               AV8cWWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV8cWWPNotificationId), 10, 0));
            }
            cmbavCwwpwebnotificationstatus.Name = cmbavCwwpwebnotificationstatus_Internalname;
            cmbavCwwpwebnotificationstatus.CurrentValue = cgiGet( cmbavCwwpwebnotificationstatus_Internalname);
            AV9cWWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavCwwpwebnotificationstatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9cWWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(AV9cWWPWebNotificationStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpwebnotificationcreated_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Created"}), 1, "vCWWPWEBNOTIFICATIONCREATED");
               GX_FocusControl = edtavCwwpwebnotificationcreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cWWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV10cWWPWebNotificationCreated", context.localUtil.TToC( AV10cWWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               AV10cWWPWebNotificationCreated = context.localUtil.CToT( cgiGet( edtavCwwpwebnotificationcreated_Internalname));
               AssignAttri("", false, "AV10cWWPWebNotificationCreated", context.localUtil.TToC( AV10cWWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpwebnotificationscheduled_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Scheduled"}), 1, "vCWWPWEBNOTIFICATIONSCHEDULED");
               GX_FocusControl = edtavCwwpwebnotificationscheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cWWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV11cWWPWebNotificationScheduled", context.localUtil.TToC( AV11cWWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               AV11cWWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( edtavCwwpwebnotificationscheduled_Internalname));
               AssignAttri("", false, "AV11cWWPWebNotificationScheduled", context.localUtil.TToC( AV11cWWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpwebnotificationprocessed_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Processed"}), 1, "vCWWPWEBNOTIFICATIONPROCESSED");
               GX_FocusControl = edtavCwwpwebnotificationprocessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cWWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV12cWWPWebNotificationProcessed", context.localUtil.TToC( AV12cWWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               AV12cWWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( edtavCwwpwebnotificationprocessed_Internalname));
               AssignAttri("", false, "AV12cWWPWebNotificationProcessed", context.localUtil.TToC( AV12cWWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPWEBNOTIFICATIONID"), ".", ",") != Convert.ToDecimal( AV6cWWPWebNotificationId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPWEBNOTIFICATIONTITLE"), AV7cWWPWebNotificationTitle) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONID"), ".", ",") != Convert.ToDecimal( AV8cWWPNotificationId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPWEBNOTIFICATIONSTATUS"), ".", ",") != Convert.ToDecimal( AV9cWWPWebNotificationStatus )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPWEBNOTIFICATIONCREATED")) != AV10cWWPWebNotificationCreated )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPWEBNOTIFICATIONSCHEDULED")) != AV11cWWPWebNotificationScheduled )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPWEBNOTIFICATIONPROCESSED")) != AV12cWWPWebNotificationProcessed )
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
         E165H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E165H2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "WWP_WebNotification", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E175H2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E185H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E185H2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pWWPWebNotificationId = A47WWPWebNotificationId;
         AssignAttri("", false, "AV13pWWPWebNotificationId", StringUtil.LTrimStr( (decimal)(AV13pWWPWebNotificationId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pWWPWebNotificationId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pWWPWebNotificationId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pWWPWebNotificationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pWWPWebNotificationId", StringUtil.LTrimStr( (decimal)(AV13pWWPWebNotificationId), 10, 0));
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
         PA5H2( ) ;
         WS5H2( ) ;
         WE5H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481416571434", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/web/gx0060.js", "?202481416571434", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtWWPWebNotificationId_Internalname = "WWPWEBNOTIFICATIONID_"+sGXsfl_84_idx;
         edtWWPWebNotificationTitle_Internalname = "WWPWEBNOTIFICATIONTITLE_"+sGXsfl_84_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_84_idx;
         cmbWWPWebNotificationStatus_Internalname = "WWPWEBNOTIFICATIONSTATUS_"+sGXsfl_84_idx;
         edtWWPWebNotificationCreated_Internalname = "WWPWEBNOTIFICATIONCREATED_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtWWPWebNotificationId_Internalname = "WWPWEBNOTIFICATIONID_"+sGXsfl_84_fel_idx;
         edtWWPWebNotificationTitle_Internalname = "WWPWEBNOTIFICATIONTITLE_"+sGXsfl_84_fel_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_84_fel_idx;
         cmbWWPWebNotificationStatus_Internalname = "WWPWEBNOTIFICATIONSTATUS_"+sGXsfl_84_fel_idx;
         edtWWPWebNotificationCreated_Internalname = "WWPWEBNOTIFICATIONCREATED_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB5H0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A47WWPWebNotificationId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPWebNotificationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A47WWPWebNotificationId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A47WWPWebNotificationId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPWebNotificationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtWWPWebNotificationTitle_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A47WWPWebNotificationId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtWWPWebNotificationTitle_Internalname, "Link", edtWWPWebNotificationTitle_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPWebNotificationTitle_Internalname,(string)A42WWPWebNotificationTitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWWPWebNotificationTitle_Link,(string)"",(string)"",(string)"",(string)edtWWPWebNotificationTitle_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWWPWebNotificationStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WWPWEBNOTIFICATIONSTATUS_" + sGXsfl_84_idx;
               cmbWWPWebNotificationStatus.Name = GXCCtl;
               cmbWWPWebNotificationStatus.WebTags = "";
               cmbWWPWebNotificationStatus.addItem("1", "Pending", 0);
               cmbWWPWebNotificationStatus.addItem("2", "Sent", 0);
               cmbWWPWebNotificationStatus.addItem("3", "Error", 0);
               if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
               {
                  A54WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPWebNotificationStatus,(string)cmbWWPWebNotificationStatus_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0)),(short)1,(string)cmbWWPWebNotificationStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0));
            AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", (string)(cmbWWPWebNotificationStatus.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPWebNotificationCreated_Internalname,context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "),context.localUtil.Format( A45WWPWebNotificationCreated, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPWebNotificationCreated_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)27,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_DateTimeMillis",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes5H2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCwwpwebnotificationstatus.Name = "vCWWPWEBNOTIFICATIONSTATUS";
         cmbavCwwpwebnotificationstatus.WebTags = "";
         cmbavCwwpwebnotificationstatus.addItem("1", "Pending", 0);
         cmbavCwwpwebnotificationstatus.addItem("2", "Sent", 0);
         cmbavCwwpwebnotificationstatus.addItem("3", "Error", 0);
         if ( cmbavCwwpwebnotificationstatus.ItemCount > 0 )
         {
            AV9cWWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbavCwwpwebnotificationstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9cWWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9cWWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(AV9cWWPWebNotificationStatus), 4, 0));
         }
         GXCCtl = "WWPWEBNOTIFICATIONSTATUS_" + sGXsfl_84_idx;
         cmbWWPWebNotificationStatus.Name = GXCCtl;
         cmbWWPWebNotificationStatus.WebTags = "";
         cmbWWPWebNotificationStatus.addItem("1", "Pending", 0);
         cmbWWPWebNotificationStatus.addItem("2", "Sent", 0);
         cmbWWPWebNotificationStatus.addItem("3", "Error", 0);
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A54WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Title") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Created") ;
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
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A47WWPWebNotificationId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A42WWPWebNotificationTitle));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtWWPWebNotificationTitle_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A54WWPWebNotificationStatus), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " ")));
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
         lblLblwwpwebnotificationidfilter_Internalname = "LBLWWPWEBNOTIFICATIONIDFILTER";
         edtavCwwpwebnotificationid_Internalname = "vCWWPWEBNOTIFICATIONID";
         divWwpwebnotificationidfiltercontainer_Internalname = "WWPWEBNOTIFICATIONIDFILTERCONTAINER";
         lblLblwwpwebnotificationtitlefilter_Internalname = "LBLWWPWEBNOTIFICATIONTITLEFILTER";
         edtavCwwpwebnotificationtitle_Internalname = "vCWWPWEBNOTIFICATIONTITLE";
         divWwpwebnotificationtitlefiltercontainer_Internalname = "WWPWEBNOTIFICATIONTITLEFILTERCONTAINER";
         lblLblwwpnotificationidfilter_Internalname = "LBLWWPNOTIFICATIONIDFILTER";
         edtavCwwpnotificationid_Internalname = "vCWWPNOTIFICATIONID";
         divWwpnotificationidfiltercontainer_Internalname = "WWPNOTIFICATIONIDFILTERCONTAINER";
         lblLblwwpwebnotificationstatusfilter_Internalname = "LBLWWPWEBNOTIFICATIONSTATUSFILTER";
         cmbavCwwpwebnotificationstatus_Internalname = "vCWWPWEBNOTIFICATIONSTATUS";
         divWwpwebnotificationstatusfiltercontainer_Internalname = "WWPWEBNOTIFICATIONSTATUSFILTERCONTAINER";
         lblLblwwpwebnotificationcreatedfilter_Internalname = "LBLWWPWEBNOTIFICATIONCREATEDFILTER";
         edtavCwwpwebnotificationcreated_Internalname = "vCWWPWEBNOTIFICATIONCREATED";
         divWwpwebnotificationcreatedfiltercontainer_Internalname = "WWPWEBNOTIFICATIONCREATEDFILTERCONTAINER";
         lblLblwwpwebnotificationscheduledfilter_Internalname = "LBLWWPWEBNOTIFICATIONSCHEDULEDFILTER";
         edtavCwwpwebnotificationscheduled_Internalname = "vCWWPWEBNOTIFICATIONSCHEDULED";
         divWwpwebnotificationscheduledfiltercontainer_Internalname = "WWPWEBNOTIFICATIONSCHEDULEDFILTERCONTAINER";
         lblLblwwpwebnotificationprocessedfilter_Internalname = "LBLWWPWEBNOTIFICATIONPROCESSEDFILTER";
         edtavCwwpwebnotificationprocessed_Internalname = "vCWWPWEBNOTIFICATIONPROCESSED";
         divWwpwebnotificationprocessedfiltercontainer_Internalname = "WWPWEBNOTIFICATIONPROCESSEDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtWWPWebNotificationId_Internalname = "WWPWEBNOTIFICATIONID";
         edtWWPWebNotificationTitle_Internalname = "WWPWEBNOTIFICATIONTITLE";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         cmbWWPWebNotificationStatus_Internalname = "WWPWEBNOTIFICATIONSTATUS";
         edtWWPWebNotificationCreated_Internalname = "WWPWEBNOTIFICATIONCREATED";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
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
         edtWWPWebNotificationCreated_Jsonclick = "";
         cmbWWPWebNotificationStatus_Jsonclick = "";
         edtWWPNotificationId_Jsonclick = "";
         edtWWPWebNotificationTitle_Jsonclick = "";
         edtWWPWebNotificationTitle_Link = "";
         edtWWPWebNotificationId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtWWPWebNotificationCreated_Enabled = 0;
         cmbWWPWebNotificationStatus.Enabled = 0;
         edtWWPNotificationId_Enabled = 0;
         edtWWPWebNotificationTitle_Enabled = 0;
         edtWWPWebNotificationId_Enabled = 0;
         edtavCwwpwebnotificationprocessed_Jsonclick = "";
         edtavCwwpwebnotificationprocessed_Enabled = 1;
         edtavCwwpwebnotificationscheduled_Jsonclick = "";
         edtavCwwpwebnotificationscheduled_Enabled = 1;
         edtavCwwpwebnotificationcreated_Jsonclick = "";
         edtavCwwpwebnotificationcreated_Enabled = 1;
         cmbavCwwpwebnotificationstatus_Jsonclick = "";
         cmbavCwwpwebnotificationstatus.Visible = 1;
         cmbavCwwpwebnotificationstatus.Enabled = 1;
         edtavCwwpnotificationid_Jsonclick = "";
         edtavCwwpnotificationid_Enabled = 1;
         edtavCwwpnotificationid_Visible = 1;
         edtavCwwpwebnotificationtitle_Jsonclick = "";
         edtavCwwpwebnotificationtitle_Enabled = 1;
         edtavCwwpwebnotificationtitle_Visible = 1;
         edtavCwwpwebnotificationid_Jsonclick = "";
         edtavCwwpwebnotificationid_Enabled = 1;
         edtavCwwpwebnotificationid_Visible = 1;
         divWwpwebnotificationstatusfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpnotificationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpwebnotificationtitlefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpwebnotificationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List WWP_WebNotification";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPWebNotificationId',fld:'vCWWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPWebNotificationTitle',fld:'vCWWPWEBNOTIFICATIONTITLE',pic:''},{av:'AV8cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'cmbavCwwpwebnotificationstatus'},{av:'AV9cWWPWebNotificationStatus',fld:'vCWWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'AV10cWWPWebNotificationCreated',fld:'vCWWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV11cWWPWebNotificationScheduled',fld:'vCWWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'AV12cWWPWebNotificationProcessed',fld:'vCWWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E155H1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLWWPWEBNOTIFICATIONIDFILTER.CLICK","{handler:'E115H1',iparms:[{av:'divWwpwebnotificationidfiltercontainer_Class',ctrl:'WWPWEBNOTIFICATIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPWEBNOTIFICATIONIDFILTER.CLICK",",oparms:[{av:'divWwpwebnotificationidfiltercontainer_Class',ctrl:'WWPWEBNOTIFICATIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpwebnotificationid_Visible',ctrl:'vCWWPWEBNOTIFICATIONID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPWEBNOTIFICATIONTITLEFILTER.CLICK","{handler:'E125H1',iparms:[{av:'divWwpwebnotificationtitlefiltercontainer_Class',ctrl:'WWPWEBNOTIFICATIONTITLEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPWEBNOTIFICATIONTITLEFILTER.CLICK",",oparms:[{av:'divWwpwebnotificationtitlefiltercontainer_Class',ctrl:'WWPWEBNOTIFICATIONTITLEFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpwebnotificationtitle_Visible',ctrl:'vCWWPWEBNOTIFICATIONTITLE',prop:'Visible'}]}");
         setEventMetadata("LBLWWPNOTIFICATIONIDFILTER.CLICK","{handler:'E135H1',iparms:[{av:'divWwpnotificationidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPNOTIFICATIONIDFILTER.CLICK",",oparms:[{av:'divWwpnotificationidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpnotificationid_Visible',ctrl:'vCWWPNOTIFICATIONID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPWEBNOTIFICATIONSTATUSFILTER.CLICK","{handler:'E145H1',iparms:[{av:'divWwpwebnotificationstatusfiltercontainer_Class',ctrl:'WWPWEBNOTIFICATIONSTATUSFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPWEBNOTIFICATIONSTATUSFILTER.CLICK",",oparms:[{av:'divWwpwebnotificationstatusfiltercontainer_Class',ctrl:'WWPWEBNOTIFICATIONSTATUSFILTERCONTAINER',prop:'Class'},{av:'cmbavCwwpwebnotificationstatus'}]}");
         setEventMetadata("ENTER","{handler:'E185H2',iparms:[{av:'A47WWPWebNotificationId',fld:'WWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pWWPWebNotificationId',fld:'vPWWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPWebNotificationId',fld:'vCWWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPWebNotificationTitle',fld:'vCWWPWEBNOTIFICATIONTITLE',pic:''},{av:'AV8cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'cmbavCwwpwebnotificationstatus'},{av:'AV9cWWPWebNotificationStatus',fld:'vCWWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'AV10cWWPWebNotificationCreated',fld:'vCWWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV11cWWPWebNotificationScheduled',fld:'vCWWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'AV12cWWPWebNotificationProcessed',fld:'vCWWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPWebNotificationId',fld:'vCWWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPWebNotificationTitle',fld:'vCWWPWEBNOTIFICATIONTITLE',pic:''},{av:'AV8cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'cmbavCwwpwebnotificationstatus'},{av:'AV9cWWPWebNotificationStatus',fld:'vCWWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'AV10cWWPWebNotificationCreated',fld:'vCWWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV11cWWPWebNotificationScheduled',fld:'vCWWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'AV12cWWPWebNotificationProcessed',fld:'vCWWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPWebNotificationId',fld:'vCWWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPWebNotificationTitle',fld:'vCWWPWEBNOTIFICATIONTITLE',pic:''},{av:'AV8cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'cmbavCwwpwebnotificationstatus'},{av:'AV9cWWPWebNotificationStatus',fld:'vCWWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'AV10cWWPWebNotificationCreated',fld:'vCWWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV11cWWPWebNotificationScheduled',fld:'vCWWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'AV12cWWPWebNotificationProcessed',fld:'vCWWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPWebNotificationId',fld:'vCWWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPWebNotificationTitle',fld:'vCWWPWEBNOTIFICATIONTITLE',pic:''},{av:'AV8cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'cmbavCwwpwebnotificationstatus'},{av:'AV9cWWPWebNotificationStatus',fld:'vCWWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'AV10cWWPWebNotificationCreated',fld:'vCWWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV11cWWPWebNotificationScheduled',fld:'vCWWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'AV12cWWPWebNotificationProcessed',fld:'vCWWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPWEBNOTIFICATIONSTATUS","{handler:'Validv_Cwwpwebnotificationstatus',iparms:[]");
         setEventMetadata("VALIDV_CWWPWEBNOTIFICATIONSTATUS",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpwebnotificationcreated',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cWWPWebNotificationTitle = "";
         AV10cWWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         AV11cWWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         AV12cWWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblwwpwebnotificationidfilter_Jsonclick = "";
         TempTags = "";
         lblLblwwpwebnotificationtitlefilter_Jsonclick = "";
         lblLblwwpnotificationidfilter_Jsonclick = "";
         lblLblwwpwebnotificationstatusfilter_Jsonclick = "";
         lblLblwwpwebnotificationcreatedfilter_Jsonclick = "";
         lblLblwwpwebnotificationscheduledfilter_Jsonclick = "";
         lblLblwwpwebnotificationprocessedfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV15Linkselection_GXI = "";
         A42WWPWebNotificationTitle = "";
         A45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV7cWWPWebNotificationTitle = "";
         A58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         H005H2_A55WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         H005H2_A58WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         H005H2_A45WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         H005H2_A54WWPWebNotificationStatus = new short[1] ;
         H005H2_A22WWPNotificationId = new long[1] ;
         H005H2_n22WWPNotificationId = new bool[] {false} ;
         H005H2_A42WWPWebNotificationTitle = new string[] {""} ;
         H005H2_A47WWPWebNotificationId = new long[1] ;
         H005H3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.gx0060__default(),
            new Object[][] {
                new Object[] {
               H005H2_A55WWPWebNotificationProcessed, H005H2_A58WWPWebNotificationScheduled, H005H2_A45WWPWebNotificationCreated, H005H2_A54WWPWebNotificationStatus, H005H2_A22WWPNotificationId, H005H2_n22WWPNotificationId, H005H2_A42WWPWebNotificationTitle, H005H2_A47WWPWebNotificationId
               }
               , new Object[] {
               H005H3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV9cWWPWebNotificationStatus ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A54WWPWebNotificationStatus ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCwwpwebnotificationid_Enabled ;
      private int edtavCwwpwebnotificationid_Visible ;
      private int edtavCwwpwebnotificationtitle_Visible ;
      private int edtavCwwpwebnotificationtitle_Enabled ;
      private int edtavCwwpnotificationid_Enabled ;
      private int edtavCwwpnotificationid_Visible ;
      private int edtavCwwpwebnotificationcreated_Enabled ;
      private int edtavCwwpwebnotificationscheduled_Enabled ;
      private int edtavCwwpwebnotificationprocessed_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPWebNotificationId_Enabled ;
      private int edtWWPWebNotificationTitle_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPWebNotificationCreated_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pWWPWebNotificationId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cWWPWebNotificationId ;
      private long AV8cWWPNotificationId ;
      private long A47WWPWebNotificationId ;
      private long A22WWPNotificationId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divWwpwebnotificationidfiltercontainer_Class ;
      private string divWwpwebnotificationtitlefiltercontainer_Class ;
      private string divWwpnotificationidfiltercontainer_Class ;
      private string divWwpwebnotificationstatusfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divWwpwebnotificationidfiltercontainer_Internalname ;
      private string lblLblwwpwebnotificationidfilter_Internalname ;
      private string lblLblwwpwebnotificationidfilter_Jsonclick ;
      private string edtavCwwpwebnotificationid_Internalname ;
      private string TempTags ;
      private string edtavCwwpwebnotificationid_Jsonclick ;
      private string divWwpwebnotificationtitlefiltercontainer_Internalname ;
      private string lblLblwwpwebnotificationtitlefilter_Internalname ;
      private string lblLblwwpwebnotificationtitlefilter_Jsonclick ;
      private string edtavCwwpwebnotificationtitle_Internalname ;
      private string edtavCwwpwebnotificationtitle_Jsonclick ;
      private string divWwpnotificationidfiltercontainer_Internalname ;
      private string lblLblwwpnotificationidfilter_Internalname ;
      private string lblLblwwpnotificationidfilter_Jsonclick ;
      private string edtavCwwpnotificationid_Internalname ;
      private string edtavCwwpnotificationid_Jsonclick ;
      private string divWwpwebnotificationstatusfiltercontainer_Internalname ;
      private string lblLblwwpwebnotificationstatusfilter_Internalname ;
      private string lblLblwwpwebnotificationstatusfilter_Jsonclick ;
      private string cmbavCwwpwebnotificationstatus_Internalname ;
      private string cmbavCwwpwebnotificationstatus_Jsonclick ;
      private string divWwpwebnotificationcreatedfiltercontainer_Internalname ;
      private string lblLblwwpwebnotificationcreatedfilter_Internalname ;
      private string lblLblwwpwebnotificationcreatedfilter_Jsonclick ;
      private string edtavCwwpwebnotificationcreated_Internalname ;
      private string edtavCwwpwebnotificationcreated_Jsonclick ;
      private string divWwpwebnotificationscheduledfiltercontainer_Internalname ;
      private string lblLblwwpwebnotificationscheduledfilter_Internalname ;
      private string lblLblwwpwebnotificationscheduledfilter_Jsonclick ;
      private string edtavCwwpwebnotificationscheduled_Internalname ;
      private string edtavCwwpwebnotificationscheduled_Jsonclick ;
      private string divWwpwebnotificationprocessedfiltercontainer_Internalname ;
      private string lblLblwwpwebnotificationprocessedfilter_Internalname ;
      private string lblLblwwpwebnotificationprocessedfilter_Jsonclick ;
      private string edtavCwwpwebnotificationprocessed_Internalname ;
      private string edtavCwwpwebnotificationprocessed_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtWWPWebNotificationId_Internalname ;
      private string edtWWPWebNotificationTitle_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string cmbWWPWebNotificationStatus_Internalname ;
      private string edtWWPWebNotificationCreated_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtWWPWebNotificationId_Jsonclick ;
      private string edtWWPWebNotificationTitle_Link ;
      private string edtWWPWebNotificationTitle_Jsonclick ;
      private string edtWWPNotificationId_Jsonclick ;
      private string GXCCtl ;
      private string cmbWWPWebNotificationStatus_Jsonclick ;
      private string edtWWPWebNotificationCreated_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV10cWWPWebNotificationCreated ;
      private DateTime AV11cWWPWebNotificationScheduled ;
      private DateTime AV12cWWPWebNotificationProcessed ;
      private DateTime A45WWPWebNotificationCreated ;
      private DateTime A58WWPWebNotificationScheduled ;
      private DateTime A55WWPWebNotificationProcessed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n22WWPNotificationId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cWWPWebNotificationTitle ;
      private string AV15Linkselection_GXI ;
      private string A42WWPWebNotificationTitle ;
      private string lV7cWWPWebNotificationTitle ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCwwpwebnotificationstatus ;
      private GXCombobox cmbWWPWebNotificationStatus ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H005H2_A55WWPWebNotificationProcessed ;
      private DateTime[] H005H2_A58WWPWebNotificationScheduled ;
      private DateTime[] H005H2_A45WWPWebNotificationCreated ;
      private short[] H005H2_A54WWPWebNotificationStatus ;
      private long[] H005H2_A22WWPNotificationId ;
      private bool[] H005H2_n22WWPNotificationId ;
      private string[] H005H2_A42WWPWebNotificationTitle ;
      private long[] H005H2_A47WWPWebNotificationId ;
      private long[] H005H3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pWWPWebNotificationId ;
      private GXWebForm Form ;
   }

   public class gx0060__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005H2( IGxContext context ,
                                             string AV7cWWPWebNotificationTitle ,
                                             long AV8cWWPNotificationId ,
                                             short AV9cWWPWebNotificationStatus ,
                                             DateTime AV10cWWPWebNotificationCreated ,
                                             DateTime AV11cWWPWebNotificationScheduled ,
                                             DateTime AV12cWWPWebNotificationProcessed ,
                                             string A42WWPWebNotificationTitle ,
                                             long A22WWPNotificationId ,
                                             short A54WWPWebNotificationStatus ,
                                             DateTime A45WWPWebNotificationCreated ,
                                             DateTime A58WWPWebNotificationScheduled ,
                                             DateTime A55WWPWebNotificationProcessed ,
                                             long AV6cWWPWebNotificationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " WWPWebNotificationProcessed, WWPWebNotificationScheduled, WWPWebNotificationCreated, WWPWebNotificationStatus, WWPNotificationId, WWPWebNotificationTitle, WWPWebNotificationId";
         sFromString = " FROM WWP_WebNotification";
         sOrderString = "";
         AddWhere(sWhereString, "(WWPWebNotificationId >= :AV6cWWPWebNotificationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cWWPWebNotificationTitle)) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationTitle like :lV7cWWPWebNotificationTitle)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cWWPNotificationId) )
         {
            AddWhere(sWhereString, "(WWPNotificationId >= :AV8cWWPNotificationId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cWWPWebNotificationStatus) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationStatus >= :AV9cWWPWebNotificationStatus)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cWWPWebNotificationCreated) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationCreated >= :AV10cWWPWebNotificationCreated)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cWWPWebNotificationScheduled) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationScheduled >= :AV11cWWPWebNotificationScheduled)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cWWPWebNotificationProcessed) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationProcessed >= :AV12cWWPWebNotificationProcessed)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY WWPWebNotificationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H005H3( IGxContext context ,
                                             string AV7cWWPWebNotificationTitle ,
                                             long AV8cWWPNotificationId ,
                                             short AV9cWWPWebNotificationStatus ,
                                             DateTime AV10cWWPWebNotificationCreated ,
                                             DateTime AV11cWWPWebNotificationScheduled ,
                                             DateTime AV12cWWPWebNotificationProcessed ,
                                             string A42WWPWebNotificationTitle ,
                                             long A22WWPNotificationId ,
                                             short A54WWPWebNotificationStatus ,
                                             DateTime A45WWPWebNotificationCreated ,
                                             DateTime A58WWPWebNotificationScheduled ,
                                             DateTime A55WWPWebNotificationProcessed ,
                                             long AV6cWWPWebNotificationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM WWP_WebNotification";
         AddWhere(sWhereString, "(WWPWebNotificationId >= :AV6cWWPWebNotificationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cWWPWebNotificationTitle)) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationTitle like :lV7cWWPWebNotificationTitle)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cWWPNotificationId) )
         {
            AddWhere(sWhereString, "(WWPNotificationId >= :AV8cWWPNotificationId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cWWPWebNotificationStatus) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationStatus >= :AV9cWWPWebNotificationStatus)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cWWPWebNotificationCreated) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationCreated >= :AV10cWWPWebNotificationCreated)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cWWPWebNotificationScheduled) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationScheduled >= :AV11cWWPWebNotificationScheduled)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cWWPWebNotificationProcessed) )
         {
            AddWhere(sWhereString, "(WWPWebNotificationProcessed >= :AV12cWWPWebNotificationProcessed)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005H2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (short)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H005H3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (short)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH005H2;
          prmH005H2 = new Object[] {
          new ParDef("AV6cWWPWebNotificationId",GXType.Int64,10,0) ,
          new ParDef("lV7cWWPWebNotificationTitle",GXType.VarChar,40,0) ,
          new ParDef("AV8cWWPNotificationId",GXType.Int64,10,0) ,
          new ParDef("AV9cWWPWebNotificationStatus",GXType.Int16,4,0) ,
          new ParDef("AV10cWWPWebNotificationCreated",GXType.DateTime2,10,12) ,
          new ParDef("AV11cWWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
          new ParDef("AV12cWWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005H3;
          prmH005H3 = new Object[] {
          new ParDef("AV6cWWPWebNotificationId",GXType.Int64,10,0) ,
          new ParDef("lV7cWWPWebNotificationTitle",GXType.VarChar,40,0) ,
          new ParDef("AV8cWWPNotificationId",GXType.Int64,10,0) ,
          new ParDef("AV9cWWPWebNotificationStatus",GXType.Int16,4,0) ,
          new ParDef("AV10cWWPWebNotificationCreated",GXType.DateTime2,10,12) ,
          new ParDef("AV11cWWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
          new ParDef("AV12cWWPWebNotificationProcessed",GXType.DateTime2,10,12)
          };
          def= new CursorDef[] {
              new CursorDef("H005H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005H2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005H3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
