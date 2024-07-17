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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class gx0090 : GXDataArea
   {
      public gx0090( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0090( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pWWPNotificationId )
      {
         this.AV12pWWPNotificationId = 0 ;
         executePrivate();
         aP0_pWWPNotificationId=this.AV12pWWPNotificationId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCwwpnotificationisread = new GXCheckbox();
         chkWWPNotificationIsRead = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pWWPNotificationId");
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
               gxfirstwebparm = GetFirstPar( "pWWPNotificationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pWWPNotificationId");
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
               AV12pWWPNotificationId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV12pWWPNotificationId), 10, 0));
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
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
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
         AV6cWWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPNotificationId"), "."), 18, MidpointRounding.ToEven));
         AV7cWWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
         AV8cWWPNotificationCreated = context.localUtil.ParseDTimeParm( GetPar( "cWWPNotificationCreated"));
         AV9cWWPNotificationIcon = GetPar( "cWWPNotificationIcon");
         AV10cWWPNotificationIsRead = StringUtil.StrToBool( GetPar( "cWWPNotificationIsRead"));
         AV11cWWPUserExtendedId = GetPar( "cWWPUserExtendedId");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPNotificationId, AV7cWWPNotificationDefinitionId, AV8cWWPNotificationCreated, AV9cWWPNotificationIcon, AV10cWWPNotificationIsRead, AV11cWWPUserExtendedId) ;
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
            return "gx0090_Execute" ;
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
         PA5I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5I2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pWWPNotificationId,10,0))}, new string[] {"pWWPNotificationId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cWWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONCREATED", context.localUtil.TToC( AV8cWWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONICON", AV9cWWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONISREAD", StringUtil.BoolToStr( AV10cWWPNotificationIsRead));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPUSEREXTENDEDID", StringUtil.RTrim( AV11cWWPUserExtendedId));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pWWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpnotificationidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpnotificationdefinitionidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONICONFILTERCONTAINER_Class", StringUtil.RTrim( divWwpnotificationiconfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONISREADFILTERCONTAINER_Class", StringUtil.RTrim( divWwpnotificationisreadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpuserextendedidfiltercontainer_Class));
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
            WE5I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5I2( ) ;
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
         return formatLink("wwpbaseobjects.notifications.common.gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pWWPNotificationId,10,0))}, new string[] {"pWWPNotificationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.Gx0090" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List WWP_Notification" ;
      }

      protected void WB5I0( )
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
            GxWebStd.gx_div_start( context, divWwpnotificationidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpnotificationidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationidfilter_Internalname, "Notification Id", "", "", lblLblwwpnotificationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e115i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpnotificationid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPNotificationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCwwpnotificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cWWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cWWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpnotificationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpnotificationid_Visible, edtavCwwpnotificationid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divWwpnotificationdefinitionidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpnotificationdefinitionidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationdefinitionidfilter_Internalname, "Notification Definition Id", "", "", lblLblwwpnotificationdefinitionidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e125i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpnotificationdefinitionid_Internalname, "Notification Definition Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpnotificationdefinitionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cWWPNotificationDefinitionId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCwwpnotificationdefinitionid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cWWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cWWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpnotificationdefinitionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpnotificationdefinitionid_Visible, edtavCwwpnotificationdefinitionid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divWwpnotificationcreatedfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationcreatedfilter_Internalname, "Notification Created Date", "", "", lblLblwwpnotificationcreatedfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpnotificationcreated_Internalname, "Notification Created Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpnotificationcreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpnotificationcreated_Internalname, context.localUtil.TToC( AV8cWWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( AV8cWWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpnotificationcreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpnotificationcreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divWwpnotificationiconfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpnotificationiconfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationiconfilter_Internalname, "Notification Icon", "", "", lblLblwwpnotificationiconfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e135i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpnotificationicon_Internalname, "Notification Icon", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpnotificationicon_Internalname, AV9cWWPNotificationIcon, StringUtil.RTrim( context.localUtil.Format( AV9cWWPNotificationIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpnotificationicon_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpnotificationicon_Visible, edtavCwwpnotificationicon_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divWwpnotificationisreadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpnotificationisreadfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationisreadfilter_Internalname, "Notification Is Read", "", "", lblLblwwpnotificationisreadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e145i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCwwpnotificationisread_Internalname, "Notification Is Read", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCwwpnotificationisread_Internalname, StringUtil.BoolToStr( AV10cWWPNotificationIsRead), "", "Notification Is Read", chkavCwwpnotificationisread.Visible, chkavCwwpnotificationisread.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            GxWebStd.gx_div_start( context, divWwpuserextendedidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpuserextendedidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpuserextendedidfilter_Internalname, "User Id", "", "", lblLblwwpuserextendedidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e155i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpuserextendedid_Internalname, "User Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpuserextendedid_Internalname, StringUtil.RTrim( AV11cWWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( AV11cWWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpuserextendedid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpuserextendedid_Visible, edtavCwwpuserextendedid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e165i1_client"+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 74 )
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

      protected void START5I2( )
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
         Form.Meta.addItem("description", "Selection List WWP_Notification", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5I0( ) ;
      }

      protected void WS5I2( )
      {
         START5I2( ) ;
         EVT5I2( ) ;
      }

      protected void EVT5I2( )
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
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A22WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A23WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A24WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname), 0);
                              A82WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( chkWWPNotificationIsRead_Internalname));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E175I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E185I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cwwpnotificationid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONID"), ".", ",") != Convert.ToDecimal( AV6cWWPNotificationId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpnotificationdefinitionid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONDEFINITIONID"), ".", ",") != Convert.ToDecimal( AV7cWWPNotificationDefinitionId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpnotificationcreated Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPNOTIFICATIONCREATED"), 0) != AV8cWWPNotificationCreated )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpnotificationicon Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPNOTIFICATIONICON"), AV9cWWPNotificationIcon) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpnotificationisread Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCWWPNOTIFICATIONISREAD")) != AV10cWWPNotificationIsRead )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpuserextendedid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDID"), AV11cWWPUserExtendedId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E195I2 ();
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

      protected void WE5I2( )
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

      protected void PA5I2( )
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cWWPNotificationId ,
                                        long AV7cWWPNotificationDefinitionId ,
                                        DateTime AV8cWWPNotificationCreated ,
                                        string AV9cWWPNotificationIcon ,
                                        bool AV10cWWPNotificationIsRead ,
                                        string AV11cWWPUserExtendedId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF5I2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPNOTIFICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")));
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
         AV10cWWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cWWPNotificationIsRead));
         AssignAttri("", false, "AV10cWWPNotificationIsRead", AV10cWWPNotificationIsRead);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cWWPNotificationDefinitionId ,
                                                 AV8cWWPNotificationCreated ,
                                                 AV9cWWPNotificationIcon ,
                                                 AV10cWWPNotificationIsRead ,
                                                 AV11cWWPUserExtendedId ,
                                                 A23WWPNotificationDefinitionId ,
                                                 A24WWPNotificationCreated ,
                                                 A76WWPNotificationIcon ,
                                                 A82WWPNotificationIsRead ,
                                                 A7WWPUserExtendedId ,
                                                 AV6cWWPNotificationId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            lV9cWWPNotificationIcon = StringUtil.Concat( StringUtil.RTrim( AV9cWWPNotificationIcon), "%", "");
            lV11cWWPUserExtendedId = StringUtil.PadR( StringUtil.RTrim( AV11cWWPUserExtendedId), 40, "%");
            /* Using cursor H005I2 */
            pr_default.execute(0, new Object[] {AV6cWWPNotificationId, AV7cWWPNotificationDefinitionId, AV8cWWPNotificationCreated, lV9cWWPNotificationIcon, AV10cWWPNotificationIsRead, lV11cWWPUserExtendedId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A7WWPUserExtendedId = H005I2_A7WWPUserExtendedId[0];
               n7WWPUserExtendedId = H005I2_n7WWPUserExtendedId[0];
               A76WWPNotificationIcon = H005I2_A76WWPNotificationIcon[0];
               A82WWPNotificationIsRead = H005I2_A82WWPNotificationIsRead[0];
               A24WWPNotificationCreated = H005I2_A24WWPNotificationCreated[0];
               A23WWPNotificationDefinitionId = H005I2_A23WWPNotificationDefinitionId[0];
               A22WWPNotificationId = H005I2_A22WWPNotificationId[0];
               /* Execute user event: Load */
               E185I2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB5I0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5I2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPNOTIFICATIONID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9"), context));
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
                                              AV7cWWPNotificationDefinitionId ,
                                              AV8cWWPNotificationCreated ,
                                              AV9cWWPNotificationIcon ,
                                              AV10cWWPNotificationIsRead ,
                                              AV11cWWPUserExtendedId ,
                                              A23WWPNotificationDefinitionId ,
                                              A24WWPNotificationCreated ,
                                              A76WWPNotificationIcon ,
                                              A82WWPNotificationIsRead ,
                                              A7WWPUserExtendedId ,
                                              AV6cWWPNotificationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV9cWWPNotificationIcon = StringUtil.Concat( StringUtil.RTrim( AV9cWWPNotificationIcon), "%", "");
         lV11cWWPUserExtendedId = StringUtil.PadR( StringUtil.RTrim( AV11cWWPUserExtendedId), 40, "%");
         /* Using cursor H005I3 */
         pr_default.execute(1, new Object[] {AV6cWWPNotificationId, AV7cWWPNotificationDefinitionId, AV8cWWPNotificationCreated, lV9cWWPNotificationIcon, AV10cWWPNotificationIsRead, lV11cWWPUserExtendedId});
         GRID1_nRecordCount = H005I3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPNotificationId, AV7cWWPNotificationDefinitionId, AV8cWWPNotificationCreated, AV9cWWPNotificationIcon, AV10cWWPNotificationIsRead, AV11cWWPUserExtendedId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPNotificationId, AV7cWWPNotificationDefinitionId, AV8cWWPNotificationCreated, AV9cWWPNotificationIcon, AV10cWWPNotificationIsRead, AV11cWWPUserExtendedId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPNotificationId, AV7cWWPNotificationDefinitionId, AV8cWWPNotificationCreated, AV9cWWPNotificationIcon, AV10cWWPNotificationIsRead, AV11cWWPUserExtendedId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPNotificationId, AV7cWWPNotificationDefinitionId, AV8cWWPNotificationCreated, AV9cWWPNotificationIcon, AV10cWWPNotificationIsRead, AV11cWWPUserExtendedId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPNotificationId, AV7cWWPNotificationDefinitionId, AV8cWWPNotificationCreated, AV9cWWPNotificationIcon, AV10cWWPNotificationIsRead, AV11cWWPUserExtendedId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         chkWWPNotificationIsRead.Enabled = 0;
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationIsRead.Enabled), 5, 0), !bGXsfl_74_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E175I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPNOTIFICATIONID");
               GX_FocusControl = edtavCwwpnotificationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cWWPNotificationId = 0;
               AssignAttri("", false, "AV6cWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV6cWWPNotificationId), 10, 0));
            }
            else
            {
               AV6cWWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV6cWWPNotificationId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationdefinitionid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationdefinitionid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPNOTIFICATIONDEFINITIONID");
               GX_FocusControl = edtavCwwpnotificationdefinitionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cWWPNotificationDefinitionId = 0;
               AssignAttri("", false, "AV7cWWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(AV7cWWPNotificationDefinitionId), 10, 0));
            }
            else
            {
               AV7cWWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpnotificationdefinitionid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cWWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(AV7cWWPNotificationDefinitionId), 10, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpnotificationcreated_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Notification Created Date"}), 1, "vCWWPNOTIFICATIONCREATED");
               GX_FocusControl = edtavCwwpnotificationcreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cWWPNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV8cWWPNotificationCreated", context.localUtil.TToC( AV8cWWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               AV8cWWPNotificationCreated = context.localUtil.CToT( cgiGet( edtavCwwpnotificationcreated_Internalname));
               AssignAttri("", false, "AV8cWWPNotificationCreated", context.localUtil.TToC( AV8cWWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            AV9cWWPNotificationIcon = cgiGet( edtavCwwpnotificationicon_Internalname);
            AssignAttri("", false, "AV9cWWPNotificationIcon", AV9cWWPNotificationIcon);
            AV10cWWPNotificationIsRead = StringUtil.StrToBool( cgiGet( chkavCwwpnotificationisread_Internalname));
            AssignAttri("", false, "AV10cWWPNotificationIsRead", AV10cWWPNotificationIsRead);
            AV11cWWPUserExtendedId = cgiGet( edtavCwwpuserextendedid_Internalname);
            AssignAttri("", false, "AV11cWWPUserExtendedId", AV11cWWPUserExtendedId);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONID"), ".", ",") != Convert.ToDecimal( AV6cWWPNotificationId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONDEFINITIONID"), ".", ",") != Convert.ToDecimal( AV7cWWPNotificationDefinitionId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPNOTIFICATIONCREATED")) != AV8cWWPNotificationCreated )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPNOTIFICATIONICON"), AV9cWWPNotificationIcon) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCWWPNOTIFICATIONISREAD")) != AV10cWWPNotificationIsRead )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPUSEREXTENDEDID"), AV11cWWPUserExtendedId) != 0 )
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
         E175I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E175I2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "WWP_Notification", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E185I2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E195I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E195I2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pWWPNotificationId = A22WWPNotificationId;
         AssignAttri("", false, "AV12pWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV12pWWPNotificationId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pWWPNotificationId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pWWPNotificationId"});
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
         AV12pWWPNotificationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV12pWWPNotificationId), 10, 0));
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
         PA5I2( ) ;
         WS5I2( ) ;
         WE5I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202471712101281", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/gx0090.js", "?202471712101281", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_74_idx;
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_74_idx;
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED_"+sGXsfl_74_idx;
         chkWWPNotificationIsRead_Internalname = "WWPNOTIFICATIONISREAD_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_74_fel_idx;
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_74_fel_idx;
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED_"+sGXsfl_74_fel_idx;
         chkWWPNotificationIsRead_Internalname = "WWPNOTIFICATIONISREAD_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB5I0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationDefinitionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtWWPNotificationCreated_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtWWPNotificationCreated_Internalname, "Link", edtWWPNotificationCreated_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationCreated_Internalname,context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "),context.localUtil.Format( A24WWPNotificationCreated, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWWPNotificationCreated_Link,(string)"",(string)"",(string)"",(string)edtWWPNotificationCreated_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)27,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_DateTimeMillis",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "WWPNOTIFICATIONISREAD_" + sGXsfl_74_idx;
            chkWWPNotificationIsRead.Name = GXCCtl;
            chkWWPNotificationIsRead.WebTags = "";
            chkWWPNotificationIsRead.Caption = "";
            AssignProp("", false, chkWWPNotificationIsRead_Internalname, "TitleCaption", chkWWPNotificationIsRead.Caption, !bGXsfl_74_Refreshing);
            chkWWPNotificationIsRead.CheckedValue = "false";
            A82WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A82WWPNotificationIsRead));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkWWPNotificationIsRead_Internalname,StringUtil.BoolToStr( A82WWPNotificationIsRead),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            send_integrity_lvl_hashes5I2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         chkavCwwpnotificationisread.Name = "vCWWPNOTIFICATIONISREAD";
         chkavCwwpnotificationisread.WebTags = "";
         chkavCwwpnotificationisread.Caption = "";
         AssignProp("", false, chkavCwwpnotificationisread_Internalname, "TitleCaption", chkavCwwpnotificationisread.Caption, true);
         chkavCwwpnotificationisread.CheckedValue = "false";
         AV10cWWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cWWPNotificationIsRead));
         AssignAttri("", false, "AV10cWWPNotificationIsRead", AV10cWWPNotificationIsRead);
         GXCCtl = "WWPNOTIFICATIONISREAD_" + sGXsfl_74_idx;
         chkWWPNotificationIsRead.Name = GXCCtl;
         chkWWPNotificationIsRead.WebTags = "";
         chkWWPNotificationIsRead.Caption = "";
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "TitleCaption", chkWWPNotificationIsRead.Caption, !bGXsfl_74_Refreshing);
         chkWWPNotificationIsRead.CheckedValue = "false";
         A82WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A82WWPNotificationIsRead));
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Definition Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Is Read") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " ")));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtWWPNotificationCreated_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A82WWPNotificationIsRead)));
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
         lblLblwwpnotificationidfilter_Internalname = "LBLWWPNOTIFICATIONIDFILTER";
         edtavCwwpnotificationid_Internalname = "vCWWPNOTIFICATIONID";
         divWwpnotificationidfiltercontainer_Internalname = "WWPNOTIFICATIONIDFILTERCONTAINER";
         lblLblwwpnotificationdefinitionidfilter_Internalname = "LBLWWPNOTIFICATIONDEFINITIONIDFILTER";
         edtavCwwpnotificationdefinitionid_Internalname = "vCWWPNOTIFICATIONDEFINITIONID";
         divWwpnotificationdefinitionidfiltercontainer_Internalname = "WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER";
         lblLblwwpnotificationcreatedfilter_Internalname = "LBLWWPNOTIFICATIONCREATEDFILTER";
         edtavCwwpnotificationcreated_Internalname = "vCWWPNOTIFICATIONCREATED";
         divWwpnotificationcreatedfiltercontainer_Internalname = "WWPNOTIFICATIONCREATEDFILTERCONTAINER";
         lblLblwwpnotificationiconfilter_Internalname = "LBLWWPNOTIFICATIONICONFILTER";
         edtavCwwpnotificationicon_Internalname = "vCWWPNOTIFICATIONICON";
         divWwpnotificationiconfiltercontainer_Internalname = "WWPNOTIFICATIONICONFILTERCONTAINER";
         lblLblwwpnotificationisreadfilter_Internalname = "LBLWWPNOTIFICATIONISREADFILTER";
         chkavCwwpnotificationisread_Internalname = "vCWWPNOTIFICATIONISREAD";
         divWwpnotificationisreadfiltercontainer_Internalname = "WWPNOTIFICATIONISREADFILTERCONTAINER";
         lblLblwwpuserextendedidfilter_Internalname = "LBLWWPUSEREXTENDEDIDFILTER";
         edtavCwwpuserextendedid_Internalname = "vCWWPUSEREXTENDEDID";
         divWwpuserextendedidfiltercontainer_Internalname = "WWPUSEREXTENDEDIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         chkWWPNotificationIsRead_Internalname = "WWPNOTIFICATIONISREAD";
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
         chkavCwwpnotificationisread.Caption = "Notification Is Read";
         chkWWPNotificationIsRead.Caption = "";
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Link = "";
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         chkWWPNotificationIsRead.Enabled = 0;
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationDefinitionId_Enabled = 0;
         edtWWPNotificationId_Enabled = 0;
         edtavCwwpuserextendedid_Jsonclick = "";
         edtavCwwpuserextendedid_Enabled = 1;
         edtavCwwpuserextendedid_Visible = 1;
         chkavCwwpnotificationisread.Enabled = 1;
         chkavCwwpnotificationisread.Visible = 1;
         edtavCwwpnotificationicon_Jsonclick = "";
         edtavCwwpnotificationicon_Enabled = 1;
         edtavCwwpnotificationicon_Visible = 1;
         edtavCwwpnotificationcreated_Jsonclick = "";
         edtavCwwpnotificationcreated_Enabled = 1;
         edtavCwwpnotificationdefinitionid_Jsonclick = "";
         edtavCwwpnotificationdefinitionid_Enabled = 1;
         edtavCwwpnotificationdefinitionid_Visible = 1;
         edtavCwwpnotificationid_Jsonclick = "";
         edtavCwwpnotificationid_Enabled = 1;
         edtavCwwpnotificationid_Visible = 1;
         divWwpuserextendedidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpnotificationisreadfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpnotificationiconfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpnotificationdefinitionidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpnotificationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List WWP_Notification";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'AV8cWWPNotificationCreated',fld:'vCWWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV9cWWPNotificationIcon',fld:'vCWWPNOTIFICATIONICON',pic:''},{av:'AV11cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:''},{av:'AV10cWWPNotificationIsRead',fld:'vCWWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E165I1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLWWPNOTIFICATIONIDFILTER.CLICK","{handler:'E115I1',iparms:[{av:'divWwpnotificationidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPNOTIFICATIONIDFILTER.CLICK",",oparms:[{av:'divWwpnotificationidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpnotificationid_Visible',ctrl:'vCWWPNOTIFICATIONID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPNOTIFICATIONDEFINITIONIDFILTER.CLICK","{handler:'E125I1',iparms:[{av:'divWwpnotificationdefinitionidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPNOTIFICATIONDEFINITIONIDFILTER.CLICK",",oparms:[{av:'divWwpnotificationdefinitionidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONDEFINITIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpnotificationdefinitionid_Visible',ctrl:'vCWWPNOTIFICATIONDEFINITIONID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPNOTIFICATIONICONFILTER.CLICK","{handler:'E135I1',iparms:[{av:'divWwpnotificationiconfiltercontainer_Class',ctrl:'WWPNOTIFICATIONICONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPNOTIFICATIONICONFILTER.CLICK",",oparms:[{av:'divWwpnotificationiconfiltercontainer_Class',ctrl:'WWPNOTIFICATIONICONFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpnotificationicon_Visible',ctrl:'vCWWPNOTIFICATIONICON',prop:'Visible'}]}");
         setEventMetadata("LBLWWPNOTIFICATIONISREADFILTER.CLICK","{handler:'E145I1',iparms:[{av:'divWwpnotificationisreadfiltercontainer_Class',ctrl:'WWPNOTIFICATIONISREADFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPNOTIFICATIONISREADFILTER.CLICK",",oparms:[{av:'divWwpnotificationisreadfiltercontainer_Class',ctrl:'WWPNOTIFICATIONISREADFILTERCONTAINER',prop:'Class'},{av:'chkavCwwpnotificationisread.Visible',ctrl:'vCWWPNOTIFICATIONISREAD',prop:'Visible'}]}");
         setEventMetadata("LBLWWPUSEREXTENDEDIDFILTER.CLICK","{handler:'E155I1',iparms:[{av:'divWwpuserextendedidfiltercontainer_Class',ctrl:'WWPUSEREXTENDEDIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPUSEREXTENDEDIDFILTER.CLICK",",oparms:[{av:'divWwpuserextendedidfiltercontainer_Class',ctrl:'WWPUSEREXTENDEDIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpuserextendedid_Visible',ctrl:'vCWWPUSEREXTENDEDID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E195I2',iparms:[{av:'A22WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pWWPNotificationId',fld:'vPWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'AV8cWWPNotificationCreated',fld:'vCWWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV9cWWPNotificationIcon',fld:'vCWWPNOTIFICATIONICON',pic:''},{av:'AV11cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:''},{av:'AV10cWWPNotificationIsRead',fld:'vCWWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'AV8cWWPNotificationCreated',fld:'vCWWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV9cWWPNotificationIcon',fld:'vCWWPNOTIFICATIONICON',pic:''},{av:'AV11cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:''},{av:'AV10cWWPNotificationIsRead',fld:'vCWWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'AV8cWWPNotificationCreated',fld:'vCWWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV9cWWPNotificationIcon',fld:'vCWWPNOTIFICATIONICON',pic:''},{av:'AV11cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:''},{av:'AV10cWWPNotificationIsRead',fld:'vCWWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cWWPNotificationDefinitionId',fld:'vCWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'AV8cWWPNotificationCreated',fld:'vCWWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'AV9cWWPNotificationIcon',fld:'vCWWPNOTIFICATIONICON',pic:''},{av:'AV11cWWPUserExtendedId',fld:'vCWWPUSEREXTENDEDID',pic:''},{av:'AV10cWWPNotificationIsRead',fld:'vCWWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpnotificationisread',iparms:[]");
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
         AV8cWWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AV9cWWPNotificationIcon = "";
         AV11cWWPUserExtendedId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblwwpnotificationidfilter_Jsonclick = "";
         TempTags = "";
         lblLblwwpnotificationdefinitionidfilter_Jsonclick = "";
         lblLblwwpnotificationcreatedfilter_Jsonclick = "";
         lblLblwwpnotificationiconfilter_Jsonclick = "";
         lblLblwwpnotificationisreadfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblwwpuserextendedidfilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV14Linkselection_GXI = "";
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV9cWWPNotificationIcon = "";
         lV11cWWPUserExtendedId = "";
         A76WWPNotificationIcon = "";
         A7WWPUserExtendedId = "";
         H005I2_A7WWPUserExtendedId = new string[] {""} ;
         H005I2_n7WWPUserExtendedId = new bool[] {false} ;
         H005I2_A76WWPNotificationIcon = new string[] {""} ;
         H005I2_A82WWPNotificationIsRead = new bool[] {false} ;
         H005I2_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         H005I2_A23WWPNotificationDefinitionId = new long[1] ;
         H005I2_A22WWPNotificationId = new long[1] ;
         H005I3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.gx0090__default(),
            new Object[][] {
                new Object[] {
               H005I2_A7WWPUserExtendedId, H005I2_n7WWPUserExtendedId, H005I2_A76WWPNotificationIcon, H005I2_A82WWPNotificationIsRead, H005I2_A24WWPNotificationCreated, H005I2_A23WWPNotificationDefinitionId, H005I2_A22WWPNotificationId
               }
               , new Object[] {
               H005I3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCwwpnotificationid_Enabled ;
      private int edtavCwwpnotificationid_Visible ;
      private int edtavCwwpnotificationdefinitionid_Enabled ;
      private int edtavCwwpnotificationdefinitionid_Visible ;
      private int edtavCwwpnotificationcreated_Enabled ;
      private int edtavCwwpnotificationicon_Visible ;
      private int edtavCwwpnotificationicon_Enabled ;
      private int edtavCwwpuserextendedid_Visible ;
      private int edtavCwwpuserextendedid_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pWWPNotificationId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cWWPNotificationId ;
      private long AV7cWWPNotificationDefinitionId ;
      private long A22WWPNotificationId ;
      private long A23WWPNotificationDefinitionId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divWwpnotificationidfiltercontainer_Class ;
      private string divWwpnotificationdefinitionidfiltercontainer_Class ;
      private string divWwpnotificationiconfiltercontainer_Class ;
      private string divWwpnotificationisreadfiltercontainer_Class ;
      private string divWwpuserextendedidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV11cWWPUserExtendedId ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divWwpnotificationidfiltercontainer_Internalname ;
      private string lblLblwwpnotificationidfilter_Internalname ;
      private string lblLblwwpnotificationidfilter_Jsonclick ;
      private string edtavCwwpnotificationid_Internalname ;
      private string TempTags ;
      private string edtavCwwpnotificationid_Jsonclick ;
      private string divWwpnotificationdefinitionidfiltercontainer_Internalname ;
      private string lblLblwwpnotificationdefinitionidfilter_Internalname ;
      private string lblLblwwpnotificationdefinitionidfilter_Jsonclick ;
      private string edtavCwwpnotificationdefinitionid_Internalname ;
      private string edtavCwwpnotificationdefinitionid_Jsonclick ;
      private string divWwpnotificationcreatedfiltercontainer_Internalname ;
      private string lblLblwwpnotificationcreatedfilter_Internalname ;
      private string lblLblwwpnotificationcreatedfilter_Jsonclick ;
      private string edtavCwwpnotificationcreated_Internalname ;
      private string edtavCwwpnotificationcreated_Jsonclick ;
      private string divWwpnotificationiconfiltercontainer_Internalname ;
      private string lblLblwwpnotificationiconfilter_Internalname ;
      private string lblLblwwpnotificationiconfilter_Jsonclick ;
      private string edtavCwwpnotificationicon_Internalname ;
      private string edtavCwwpnotificationicon_Jsonclick ;
      private string divWwpnotificationisreadfiltercontainer_Internalname ;
      private string lblLblwwpnotificationisreadfilter_Internalname ;
      private string lblLblwwpnotificationisreadfilter_Jsonclick ;
      private string chkavCwwpnotificationisread_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divWwpuserextendedidfiltercontainer_Internalname ;
      private string lblLblwwpuserextendedidfilter_Internalname ;
      private string lblLblwwpuserextendedidfilter_Jsonclick ;
      private string edtavCwwpuserextendedid_Internalname ;
      private string edtavCwwpuserextendedid_Jsonclick ;
      private string divGridtable_Internalname ;
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
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationCreated_Internalname ;
      private string chkWWPNotificationIsRead_Internalname ;
      private string scmdbuf ;
      private string lV11cWWPUserExtendedId ;
      private string A7WWPUserExtendedId ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationCreated_Link ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string GXCCtl ;
      private string subGrid1_Header ;
      private DateTime AV8cWWPNotificationCreated ;
      private DateTime A24WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10cWWPNotificationIsRead ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool A82WWPNotificationIsRead ;
      private bool gxdyncontrolsrefreshing ;
      private bool n7WWPUserExtendedId ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV9cWWPNotificationIcon ;
      private string AV14Linkselection_GXI ;
      private string lV9cWWPNotificationIcon ;
      private string A76WWPNotificationIcon ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCwwpnotificationisread ;
      private GXCheckbox chkWWPNotificationIsRead ;
      private IDataStoreProvider pr_default ;
      private string[] H005I2_A7WWPUserExtendedId ;
      private bool[] H005I2_n7WWPUserExtendedId ;
      private string[] H005I2_A76WWPNotificationIcon ;
      private bool[] H005I2_A82WWPNotificationIsRead ;
      private DateTime[] H005I2_A24WWPNotificationCreated ;
      private long[] H005I2_A23WWPNotificationDefinitionId ;
      private long[] H005I2_A22WWPNotificationId ;
      private long[] H005I3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pWWPNotificationId ;
      private GXWebForm Form ;
   }

   public class gx0090__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005I2( IGxContext context ,
                                             long AV7cWWPNotificationDefinitionId ,
                                             DateTime AV8cWWPNotificationCreated ,
                                             string AV9cWWPNotificationIcon ,
                                             bool AV10cWWPNotificationIsRead ,
                                             string AV11cWWPUserExtendedId ,
                                             long A23WWPNotificationDefinitionId ,
                                             DateTime A24WWPNotificationCreated ,
                                             string A76WWPNotificationIcon ,
                                             bool A82WWPNotificationIsRead ,
                                             string A7WWPUserExtendedId ,
                                             long AV6cWWPNotificationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " WWPUserExtendedId, WWPNotificationIcon, WWPNotificationIsRead, WWPNotificationCreated, WWPNotificationDefinitionId, WWPNotificationId";
         sFromString = " FROM WWP_Notification";
         sOrderString = "";
         AddWhere(sWhereString, "(WWPNotificationId >= :AV6cWWPNotificationId)");
         if ( ! (0==AV7cWWPNotificationDefinitionId) )
         {
            AddWhere(sWhereString, "(WWPNotificationDefinitionId >= :AV7cWWPNotificationDefinitionId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cWWPNotificationCreated) )
         {
            AddWhere(sWhereString, "(WWPNotificationCreated >= :AV8cWWPNotificationCreated)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cWWPNotificationIcon)) )
         {
            AddWhere(sWhereString, "(WWPNotificationIcon like :lV9cWWPNotificationIcon)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (false==AV10cWWPNotificationIsRead) )
         {
            AddWhere(sWhereString, "(WWPNotificationIsRead >= :AV10cWWPNotificationIsRead)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cWWPUserExtendedId)) )
         {
            AddWhere(sWhereString, "(WWPUserExtendedId like :lV11cWWPUserExtendedId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY WWPNotificationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H005I3( IGxContext context ,
                                             long AV7cWWPNotificationDefinitionId ,
                                             DateTime AV8cWWPNotificationCreated ,
                                             string AV9cWWPNotificationIcon ,
                                             bool AV10cWWPNotificationIsRead ,
                                             string AV11cWWPUserExtendedId ,
                                             long A23WWPNotificationDefinitionId ,
                                             DateTime A24WWPNotificationCreated ,
                                             string A76WWPNotificationIcon ,
                                             bool A82WWPNotificationIsRead ,
                                             string A7WWPUserExtendedId ,
                                             long AV6cWWPNotificationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM WWP_Notification";
         AddWhere(sWhereString, "(WWPNotificationId >= :AV6cWWPNotificationId)");
         if ( ! (0==AV7cWWPNotificationDefinitionId) )
         {
            AddWhere(sWhereString, "(WWPNotificationDefinitionId >= :AV7cWWPNotificationDefinitionId)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cWWPNotificationCreated) )
         {
            AddWhere(sWhereString, "(WWPNotificationCreated >= :AV8cWWPNotificationCreated)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cWWPNotificationIcon)) )
         {
            AddWhere(sWhereString, "(WWPNotificationIcon like :lV9cWWPNotificationIcon)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (false==AV10cWWPNotificationIsRead) )
         {
            AddWhere(sWhereString, "(WWPNotificationIsRead >= :AV10cWWPNotificationIsRead)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cWWPUserExtendedId)) )
         {
            AddWhere(sWhereString, "(WWPUserExtendedId like :lV11cWWPUserExtendedId)");
         }
         else
         {
            GXv_int3[5] = 1;
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
                     return conditional_H005I2(context, (long)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] );
               case 1 :
                     return conditional_H005I3(context, (long)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] );
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
          Object[] prmH005I2;
          prmH005I2 = new Object[] {
          new ParDef("AV6cWWPNotificationId",GXType.Int64,10,0) ,
          new ParDef("AV7cWWPNotificationDefinitionId",GXType.Int64,10,0) ,
          new ParDef("AV8cWWPNotificationCreated",GXType.DateTime2,10,12) ,
          new ParDef("lV9cWWPNotificationIcon",GXType.VarChar,100,0) ,
          new ParDef("AV10cWWPNotificationIsRead",GXType.Boolean,4,0) ,
          new ParDef("lV11cWWPUserExtendedId",GXType.Char,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005I3;
          prmH005I3 = new Object[] {
          new ParDef("AV6cWWPNotificationId",GXType.Int64,10,0) ,
          new ParDef("AV7cWWPNotificationDefinitionId",GXType.Int64,10,0) ,
          new ParDef("AV8cWWPNotificationCreated",GXType.DateTime2,10,12) ,
          new ParDef("lV9cWWPNotificationIcon",GXType.VarChar,100,0) ,
          new ParDef("AV10cWWPNotificationIsRead",GXType.Boolean,4,0) ,
          new ParDef("lV11cWWPUserExtendedId",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005I2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005I3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4, true);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
