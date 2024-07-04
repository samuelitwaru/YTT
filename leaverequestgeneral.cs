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
   public class leaverequestgeneral : GXWebComponent
   {
      public leaverequestgeneral( )
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

      public leaverequestgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId )
      {
         this.A127LeaveRequestId = aP0_LeaveRequestId;
         executePrivate();
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
         dynLeaveTypeId = new GXCombobox();
         dynEmployeeId = new GXCombobox();
         radLeaveRequestHalfDay = new GXRadio();
         cmbLeaveRequestStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "LeaveRequestId");
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
                  A127LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A127LeaveRequestId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LEAVETYPEID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLALEAVETYPEID4E2( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"EMPLOYEEID") == 0 )
               {
                  AV16Employeecompany = NumberUtil.Val( GetPar( "Employeecompany"), ".");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAEMPLOYEEID4E2( AV16Employeecompany) ;
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
                  gxfirstwebparm = GetFirstPar( "LeaveRequestId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "LeaveRequestId");
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
            PA4E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV15Pgmname = "LeaveRequestGeneral";
               GXALEAVETYPEID_html4E2( ) ;
               WS4E2( ) ;
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
            context.SendWebValue( "Leave Request General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leaverequestgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A127LeaveRequestId,10,0))}, new string[] {"LeaveRequestId"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA127LeaveRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA127LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vEMPLOYEECOMPANY", StringUtil.LTrim( StringUtil.NToC( AV16Employeecompany, 10, 2, ".", "")));
      }

      protected void RenderHtmlCloseForm4E2( )
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
         return "LeaveRequestGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Request General" ;
      }

      protected void WB4E0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "leaverequestgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblock_Internalname, "", "", "", lblTransactiondetail_textblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeSizeLarge", 0, "", 1, 1, 0, 0, "HLP_LeaveRequestGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLeaveTypeId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynLeaveTypeId_Internalname, "Leave Types", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynLeaveTypeId, dynLeaveTypeId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0)), 1, dynLeaveTypeId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynLeaveTypeId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_LeaveRequestGeneral.htm");
            dynLeaveTypeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0));
            AssignProp(sPrefix, false, dynLeaveTypeId_Internalname, "Values", (string)(dynLeaveTypeId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEmployeeid_cell_Internalname, 1, 0, "px", 0, "px", divEmployeeid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynEmployeeId.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynEmployeeId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynEmployeeId_Internalname, "Employees", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynEmployeeId, dynEmployeeId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0)), 1, dynEmployeeId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", dynEmployeeId.Visible, dynEmployeeId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_LeaveRequestGeneral.htm");
            dynEmployeeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AssignProp(sPrefix, false, dynEmployeeId_Internalname, "Values", (string)(dynEmployeeId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestStartDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLeaveRequestStartDate_Internalname, "Start Date", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtLeaveRequestStartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtLeaveRequestStartDate_Internalname, context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"), context.localUtil.Format( A129LeaveRequestStartDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestStartDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLeaveRequestStartDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestGeneral.htm");
            GxWebStd.gx_bitmap( context, edtLeaveRequestStartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLeaveRequestStartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequestGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestEndDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLeaveRequestEndDate_Internalname, "End Date", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtLeaveRequestEndDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtLeaveRequestEndDate_Internalname, context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"), context.localUtil.Format( A130LeaveRequestEndDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestEndDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLeaveRequestEndDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestGeneral.htm");
            GxWebStd.gx_bitmap( context, edtLeaveRequestEndDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLeaveRequestEndDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequestGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radLeaveRequestHalfDay_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Half Day", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_radio_ctrl( context, radLeaveRequestHalfDay, radLeaveRequestHalfDay_Internalname, StringUtil.RTrim( A173LeaveRequestHalfDay), "", 1, 0, 0, 0, StyleString, ClassString, "", "", 0, radLeaveRequestHalfDay_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "HLP_LeaveRequestGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLeaveRequestDescription_Internalname, "Leave Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtLeaveRequestDescription_Internalname, A133LeaveRequestDescription, "", "", 0, 1, edtLeaveRequestDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LeaveRequestGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e114e1_client"+"'", TempTags, "", 2, "HLP_LeaveRequestGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e124e1_client"+"'", TempTags, "", 2, "HLP_LeaveRequestGeneral.htm");
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
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLeaveRequestId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestId_Jsonclick, 0, "Attribute", "", "", "", "", edtLeaveRequestId_Visible, 0, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LeaveRequestGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtLeaveRequestDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtLeaveRequestDate_Internalname, context.localUtil.Format(A128LeaveRequestDate, "99/99/99"), context.localUtil.Format( A128LeaveRequestDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestDate_Jsonclick, 0, "Attribute", "", "", "", "", edtLeaveRequestDate_Visible, 0, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestGeneral.htm");
            GxWebStd.gx_bitmap( context, edtLeaveRequestDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtLeaveRequestDate_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequestGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLeaveRequestDuration_Internalname, StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")), StringUtil.LTrim( context.localUtil.Format( A131LeaveRequestDuration, "Z9.9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestDuration_Jsonclick, 0, "Attribute", "", "", "", "", edtLeaveRequestDuration_Visible, 0, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestGeneral.htm");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbLeaveRequestStatus, cmbLeaveRequestStatus_Internalname, StringUtil.RTrim( A132LeaveRequestStatus), 1, cmbLeaveRequestStatus_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", cmbLeaveRequestStatus.Visible, 0, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_LeaveRequestGeneral.htm");
            cmbLeaveRequestStatus.CurrentValue = StringUtil.RTrim( A132LeaveRequestStatus);
            AssignProp(sPrefix, false, cmbLeaveRequestStatus_Internalname, "Values", (string)(cmbLeaveRequestStatus.ToJavascriptSource()), true);
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtLeaveRequestRejectionReason_Internalname, A134LeaveRequestRejectionReason, "", "", 0, edtLeaveRequestRejectionReason_Visible, 0, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LeaveRequestGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4E2( )
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
            Form.Meta.addItem("description", "Leave Request General", 0) ;
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
               STRUP4E0( ) ;
            }
         }
      }

      protected void WS4E2( )
      {
         START4E2( ) ;
         EVT4E2( ) ;
      }

      protected void EVT4E2( )
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
                                 STRUP4E0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E134E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E144E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4E0( ) ;
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
                                 STRUP4E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WE4E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4E2( ) ;
            }
         }
      }

      protected void PA4E2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLALEAVETYPEID4E2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALEAVETYPEID_data4E2( ) ;
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

      protected void GXALEAVETYPEID_html4E2( )
      {
         long gxdynajaxvalue;
         GXDLALEAVETYPEID_data4E2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynLeaveTypeId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynLeaveTypeId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynLeaveTypeId.ItemCount > 0 )
         {
            A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( dynLeaveTypeId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
         }
      }

      protected void GXDLALEAVETYPEID_data4E2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004E2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H004E2_A100CompanyId[0] == new getloggedinusercompanyid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H004E2_A124LeaveTypeId[0]), 10, 0, ".", "")));
               gxdynajaxctrldescr.Add(StringUtil.RTrim( H004E2_A125LeaveTypeName[0]));
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLAEMPLOYEEID4E2( decimal AV16Employeecompany )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAEMPLOYEEID_data4E2( AV16Employeecompany) ;
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

      protected void GXAEMPLOYEEID_html4E2( decimal AV16Employeecompany )
      {
         long gxdynajaxvalue;
         GXDLAEMPLOYEEID_data4E2( AV16Employeecompany) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEmployeeId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEmployeeId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynEmployeeId.ItemCount > 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( dynEmployeeId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
      }

      protected void GXDLAEMPLOYEEID_data4E2( decimal AV16Employeecompany )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004E3 */
         pr_default.execute(1, new Object[] {AV16Employeecompany});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H004E3_A106EmployeeId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H004E3_A148EmployeeName[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXALEAVETYPEID_html4E2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynLeaveTypeId.ItemCount > 0 )
         {
            A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( dynLeaveTypeId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLeaveTypeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0));
            AssignProp(sPrefix, false, dynLeaveTypeId_Internalname, "Values", dynLeaveTypeId.ToJavascriptSource(), true);
         }
         if ( dynEmployeeId.ItemCount > 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( dynEmployeeId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEmployeeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AssignProp(sPrefix, false, dynEmployeeId_Internalname, "Values", dynEmployeeId.ToJavascriptSource(), true);
         }
         A173LeaveRequestHalfDay = StringUtil.RTrim( A173LeaveRequestHalfDay);
         n173LeaveRequestHalfDay = false;
         AssignAttri(sPrefix, false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
         if ( cmbLeaveRequestStatus.ItemCount > 0 )
         {
            A132LeaveRequestStatus = cmbLeaveRequestStatus.getValidValue(A132LeaveRequestStatus);
            AssignAttri(sPrefix, false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbLeaveRequestStatus.CurrentValue = StringUtil.RTrim( A132LeaveRequestStatus);
            AssignProp(sPrefix, false, cmbLeaveRequestStatus_Internalname, "Values", cmbLeaveRequestStatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "LeaveRequestGeneral";
      }

      protected void RF4E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004E4 */
            pr_default.execute(2, new Object[] {A127LeaveRequestId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A134LeaveRequestRejectionReason = H004E4_A134LeaveRequestRejectionReason[0];
               AssignAttri(sPrefix, false, "A134LeaveRequestRejectionReason", A134LeaveRequestRejectionReason);
               A132LeaveRequestStatus = H004E4_A132LeaveRequestStatus[0];
               AssignAttri(sPrefix, false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
               A131LeaveRequestDuration = H004E4_A131LeaveRequestDuration[0];
               AssignAttri(sPrefix, false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
               A128LeaveRequestDate = H004E4_A128LeaveRequestDate[0];
               AssignAttri(sPrefix, false, "A128LeaveRequestDate", context.localUtil.Format(A128LeaveRequestDate, "99/99/99"));
               A133LeaveRequestDescription = H004E4_A133LeaveRequestDescription[0];
               AssignAttri(sPrefix, false, "A133LeaveRequestDescription", A133LeaveRequestDescription);
               A173LeaveRequestHalfDay = H004E4_A173LeaveRequestHalfDay[0];
               n173LeaveRequestHalfDay = H004E4_n173LeaveRequestHalfDay[0];
               AssignAttri(sPrefix, false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
               A130LeaveRequestEndDate = H004E4_A130LeaveRequestEndDate[0];
               AssignAttri(sPrefix, false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
               A129LeaveRequestStartDate = H004E4_A129LeaveRequestStartDate[0];
               AssignAttri(sPrefix, false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
               A106EmployeeId = H004E4_A106EmployeeId[0];
               AssignAttri(sPrefix, false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               A124LeaveTypeId = H004E4_A124LeaveTypeId[0];
               AssignAttri(sPrefix, false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
               GXALEAVETYPEID_html4E2( ) ;
               /* Execute user event: Load */
               E144E2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            WB4E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4E2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "LeaveRequestGeneral";
         GXALEAVETYPEID_html4E2( ) ;
         dynLeaveTypeId.Enabled = 0;
         AssignProp(sPrefix, false, dynLeaveTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLeaveTypeId.Enabled), 5, 0), true);
         dynEmployeeId.Enabled = 0;
         AssignProp(sPrefix, false, dynEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Enabled), 5, 0), true);
         edtLeaveRequestStartDate_Enabled = 0;
         AssignProp(sPrefix, false, edtLeaveRequestStartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestStartDate_Enabled), 5, 0), true);
         edtLeaveRequestEndDate_Enabled = 0;
         AssignProp(sPrefix, false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
         radLeaveRequestHalfDay.Enabled = 0;
         AssignProp(sPrefix, false, radLeaveRequestHalfDay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveRequestHalfDay.Enabled), 5, 0), true);
         edtLeaveRequestDescription_Enabled = 0;
         AssignProp(sPrefix, false, edtLeaveRequestDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDescription_Enabled), 5, 0), true);
         edtLeaveRequestId_Enabled = 0;
         AssignProp(sPrefix, false, edtLeaveRequestId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestId_Enabled), 5, 0), true);
         edtLeaveRequestDate_Enabled = 0;
         AssignProp(sPrefix, false, edtLeaveRequestDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDate_Enabled), 5, 0), true);
         edtLeaveRequestDuration_Enabled = 0;
         AssignProp(sPrefix, false, edtLeaveRequestDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Enabled), 5, 0), true);
         cmbLeaveRequestStatus.Enabled = 0;
         AssignProp(sPrefix, false, cmbLeaveRequestStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLeaveRequestStatus.Enabled), 5, 0), true);
         edtLeaveRequestRejectionReason_Enabled = 0;
         AssignProp(sPrefix, false, edtLeaveRequestRejectionReason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestRejectionReason_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E134E2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA127LeaveRequestId"), ".", ","), 18, MidpointRounding.ToEven));
            AV13IsAuthorized_Delete = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_DELETE"));
            AV12IsAuthorized_Update = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_UPDATE"));
            /* Read variables values. */
            dynLeaveTypeId.CurrentValue = cgiGet( dynLeaveTypeId_Internalname);
            A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynLeaveTypeId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
            dynEmployeeId.CurrentValue = cgiGet( dynEmployeeId_Internalname);
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynEmployeeId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            A129LeaveRequestStartDate = context.localUtil.CToD( cgiGet( edtLeaveRequestStartDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
            A130LeaveRequestEndDate = context.localUtil.CToD( cgiGet( edtLeaveRequestEndDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
            A173LeaveRequestHalfDay = cgiGet( radLeaveRequestHalfDay_Internalname);
            n173LeaveRequestHalfDay = false;
            AssignAttri(sPrefix, false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
            A133LeaveRequestDescription = cgiGet( edtLeaveRequestDescription_Internalname);
            AssignAttri(sPrefix, false, "A133LeaveRequestDescription", A133LeaveRequestDescription);
            A128LeaveRequestDate = context.localUtil.CToD( cgiGet( edtLeaveRequestDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A128LeaveRequestDate", context.localUtil.Format(A128LeaveRequestDate, "99/99/99"));
            A131LeaveRequestDuration = context.localUtil.CToN( cgiGet( edtLeaveRequestDuration_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
            cmbLeaveRequestStatus.CurrentValue = cgiGet( cmbLeaveRequestStatus_Internalname);
            A132LeaveRequestStatus = cgiGet( cmbLeaveRequestStatus_Internalname);
            AssignAttri(sPrefix, false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
            A134LeaveRequestRejectionReason = cgiGet( edtLeaveRequestRejectionReason_Internalname);
            AssignAttri(sPrefix, false, "A134LeaveRequestRejectionReason", A134LeaveRequestRejectionReason);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXALEAVETYPEID_html4E2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E134E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E134E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E144E2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtLeaveRequestId_Visible = 0;
         AssignProp(sPrefix, false, edtLeaveRequestId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestId_Visible), 5, 0), true);
         edtLeaveRequestDate_Visible = 0;
         AssignProp(sPrefix, false, edtLeaveRequestDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDate_Visible), 5, 0), true);
         edtLeaveRequestDuration_Visible = 0;
         AssignProp(sPrefix, false, edtLeaveRequestDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Visible), 5, 0), true);
         cmbLeaveRequestStatus.Visible = 0;
         AssignProp(sPrefix, false, cmbLeaveRequestStatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbLeaveRequestStatus.Visible), 5, 0), true);
         edtLeaveRequestRejectionReason_Visible = 0;
         AssignProp(sPrefix, false, edtLeaveRequestRejectionReason_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestRejectionReason_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequest_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequest_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         if ( ! ( ( AV14Checking == Convert.ToDecimal( true )) ) )
         {
            dynEmployeeId.Visible = 0;
            AssignProp(sPrefix, false, dynEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Visible), 5, 0), true);
            divEmployeeid_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divEmployeeid_cell_Internalname, "Class", divEmployeeid_cell_Class, true);
         }
         else
         {
            dynEmployeeId.Visible = 1;
            AssignProp(sPrefix, false, dynEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Visible), 5, 0), true);
            divEmployeeid_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp(sPrefix, false, divEmployeeid_cell_Internalname, "Class", divEmployeeid_cell_Class, true);
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV15Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "LeaveRequest";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A127LeaveRequestId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
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
         PA4E2( ) ;
         WS4E2( ) ;
         WE4E2( ) ;
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
         sCtrlA127LeaveRequestId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4E2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "leaverequestgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4E2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A127LeaveRequestId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
         }
         wcpOA127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA127LeaveRequestId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A127LeaveRequestId != wcpOA127LeaveRequestId ) ) )
         {
            setjustcreated();
         }
         wcpOA127LeaveRequestId = A127LeaveRequestId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA127LeaveRequestId = cgiGet( sPrefix+"A127LeaveRequestId_CTRL");
         if ( StringUtil.Len( sCtrlA127LeaveRequestId) > 0 )
         {
            A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA127LeaveRequestId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
         }
         else
         {
            A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A127LeaveRequestId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA4E2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4E2( ) ;
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
         WS4E2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A127LeaveRequestId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA127LeaveRequestId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A127LeaveRequestId_CTRL", StringUtil.RTrim( sCtrlA127LeaveRequestId));
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
         WE4E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247415494712", true, true);
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
         context.AddJavascriptSource("leaverequestgeneral.js", "?20247415494713", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynLeaveTypeId.Name = "LEAVETYPEID";
         dynLeaveTypeId.WebTags = "";
         dynEmployeeId.Name = "EMPLOYEEID";
         dynEmployeeId.WebTags = "";
         radLeaveRequestHalfDay.Name = "LEAVEREQUESTHALFDAY";
         radLeaveRequestHalfDay.WebTags = "";
         radLeaveRequestHalfDay.addItem("", "None", 0);
         radLeaveRequestHalfDay.addItem("Morning", "Morning", 0);
         radLeaveRequestHalfDay.addItem("Afternoon", "Afternoon", 0);
         cmbLeaveRequestStatus.Name = "LEAVEREQUESTSTATUS";
         cmbLeaveRequestStatus.WebTags = "";
         cmbLeaveRequestStatus.addItem("Pending", "Pending", 0);
         cmbLeaveRequestStatus.addItem("Approved", "Approved", 0);
         cmbLeaveRequestStatus.addItem("Rejected", "Rejected", 0);
         if ( cmbLeaveRequestStatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTransactiondetail_textblock_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCK";
         dynLeaveTypeId_Internalname = sPrefix+"LEAVETYPEID";
         dynEmployeeId_Internalname = sPrefix+"EMPLOYEEID";
         divEmployeeid_cell_Internalname = sPrefix+"EMPLOYEEID_CELL";
         edtLeaveRequestStartDate_Internalname = sPrefix+"LEAVEREQUESTSTARTDATE";
         edtLeaveRequestEndDate_Internalname = sPrefix+"LEAVEREQUESTENDDATE";
         radLeaveRequestHalfDay_Internalname = sPrefix+"LEAVEREQUESTHALFDAY";
         edtLeaveRequestDescription_Internalname = sPrefix+"LEAVEREQUESTDESCRIPTION";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtLeaveRequestId_Internalname = sPrefix+"LEAVEREQUESTID";
         edtLeaveRequestDate_Internalname = sPrefix+"LEAVEREQUESTDATE";
         edtLeaveRequestDuration_Internalname = sPrefix+"LEAVEREQUESTDURATION";
         cmbLeaveRequestStatus_Internalname = sPrefix+"LEAVEREQUESTSTATUS";
         edtLeaveRequestRejectionReason_Internalname = sPrefix+"LEAVEREQUESTREJECTIONREASON";
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
         edtLeaveRequestRejectionReason_Enabled = 0;
         cmbLeaveRequestStatus.Enabled = 0;
         edtLeaveRequestDuration_Enabled = 0;
         edtLeaveRequestDate_Enabled = 0;
         edtLeaveRequestId_Enabled = 0;
         radLeaveRequestHalfDay.Enabled = 0;
         edtLeaveRequestRejectionReason_Visible = 1;
         cmbLeaveRequestStatus_Jsonclick = "";
         cmbLeaveRequestStatus.Visible = 1;
         edtLeaveRequestDuration_Jsonclick = "";
         edtLeaveRequestDuration_Visible = 1;
         edtLeaveRequestDate_Jsonclick = "";
         edtLeaveRequestDate_Visible = 1;
         edtLeaveRequestId_Jsonclick = "";
         edtLeaveRequestId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtLeaveRequestDescription_Enabled = 0;
         radLeaveRequestHalfDay_Jsonclick = "";
         edtLeaveRequestEndDate_Jsonclick = "";
         edtLeaveRequestEndDate_Enabled = 0;
         edtLeaveRequestStartDate_Jsonclick = "";
         edtLeaveRequestStartDate_Enabled = 0;
         dynEmployeeId_Jsonclick = "";
         dynEmployeeId.Enabled = 0;
         dynEmployeeId.Visible = 1;
         divEmployeeid_cell_Class = "col-xs-12 col-sm-6";
         dynLeaveTypeId_Jsonclick = "";
         dynLeaveTypeId.Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A127LeaveRequestId',fld:'LEAVEREQUESTID',pic:'ZZZZZZZZZ9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E114E1',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A127LeaveRequestId',fld:'LEAVEREQUESTID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E124E1',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A127LeaveRequestId',fld:'LEAVEREQUESTID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_LEAVEREQUESTID","{handler:'Valid_Leaverequestid',iparms:[]");
         setEventMetadata("VALID_LEAVEREQUESTID",",oparms:[]}");
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
         sPrefix = "";
         AV15Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         lblTransactiondetail_textblock_Jsonclick = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         A173LeaveRequestHalfDay = "";
         A133LeaveRequestDescription = "";
         TempTags = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A134LeaveRequestRejectionReason = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H004E2_A124LeaveTypeId = new long[1] ;
         H004E2_A125LeaveTypeName = new string[] {""} ;
         H004E2_A100CompanyId = new long[1] ;
         H004E3_A106EmployeeId = new long[1] ;
         H004E3_A148EmployeeName = new string[] {""} ;
         H004E3_A100CompanyId = new long[1] ;
         H004E4_A127LeaveRequestId = new long[1] ;
         H004E4_A134LeaveRequestRejectionReason = new string[] {""} ;
         H004E4_A132LeaveRequestStatus = new string[] {""} ;
         H004E4_A131LeaveRequestDuration = new decimal[1] ;
         H004E4_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         H004E4_A133LeaveRequestDescription = new string[] {""} ;
         H004E4_A173LeaveRequestHalfDay = new string[] {""} ;
         H004E4_n173LeaveRequestHalfDay = new bool[] {false} ;
         H004E4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         H004E4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         H004E4_A106EmployeeId = new long[1] ;
         H004E4_A124LeaveTypeId = new long[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA127LeaveRequestId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestgeneral__default(),
            new Object[][] {
                new Object[] {
               H004E2_A124LeaveTypeId, H004E2_A125LeaveTypeName, H004E2_A100CompanyId
               }
               , new Object[] {
               H004E3_A106EmployeeId, H004E3_A148EmployeeName, H004E3_A100CompanyId
               }
               , new Object[] {
               H004E4_A127LeaveRequestId, H004E4_A134LeaveRequestRejectionReason, H004E4_A132LeaveRequestStatus, H004E4_A131LeaveRequestDuration, H004E4_A128LeaveRequestDate, H004E4_A133LeaveRequestDescription, H004E4_A173LeaveRequestHalfDay, H004E4_n173LeaveRequestHalfDay, H004E4_A130LeaveRequestEndDate, H004E4_A129LeaveRequestStartDate,
               H004E4_A106EmployeeId, H004E4_A124LeaveTypeId
               }
            }
         );
         AV15Pgmname = "LeaveRequestGeneral";
         /* GeneXus formulas. */
         AV15Pgmname = "LeaveRequestGeneral";
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
      private int edtLeaveRequestStartDate_Enabled ;
      private int edtLeaveRequestEndDate_Enabled ;
      private int edtLeaveRequestDescription_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtLeaveRequestId_Visible ;
      private int edtLeaveRequestDate_Visible ;
      private int edtLeaveRequestDuration_Visible ;
      private int edtLeaveRequestRejectionReason_Visible ;
      private int gxdynajaxindex ;
      private int edtLeaveRequestId_Enabled ;
      private int edtLeaveRequestDate_Enabled ;
      private int edtLeaveRequestDuration_Enabled ;
      private int edtLeaveRequestRejectionReason_Enabled ;
      private int idxLst ;
      private long A127LeaveRequestId ;
      private long wcpOA127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private decimal AV16Employeecompany ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV14Checking ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV15Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string lblTransactiondetail_textblock_Internalname ;
      private string lblTransactiondetail_textblock_Jsonclick ;
      private string dynLeaveTypeId_Internalname ;
      private string dynLeaveTypeId_Jsonclick ;
      private string divEmployeeid_cell_Internalname ;
      private string divEmployeeid_cell_Class ;
      private string dynEmployeeId_Internalname ;
      private string dynEmployeeId_Jsonclick ;
      private string edtLeaveRequestStartDate_Internalname ;
      private string edtLeaveRequestStartDate_Jsonclick ;
      private string edtLeaveRequestEndDate_Internalname ;
      private string edtLeaveRequestEndDate_Jsonclick ;
      private string radLeaveRequestHalfDay_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string A173LeaveRequestHalfDay ;
      private string radLeaveRequestHalfDay_Jsonclick ;
      private string edtLeaveRequestDescription_Internalname ;
      private string TempTags ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtLeaveRequestId_Internalname ;
      private string edtLeaveRequestId_Jsonclick ;
      private string edtLeaveRequestDate_Internalname ;
      private string edtLeaveRequestDate_Jsonclick ;
      private string edtLeaveRequestDuration_Internalname ;
      private string edtLeaveRequestDuration_Jsonclick ;
      private string cmbLeaveRequestStatus_Internalname ;
      private string A132LeaveRequestStatus ;
      private string cmbLeaveRequestStatus_Jsonclick ;
      private string edtLeaveRequestRejectionReason_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string sCtrlA127LeaveRequestId ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A128LeaveRequestDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n173LeaveRequestHalfDay ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLeaveTypeId ;
      private GXCombobox dynEmployeeId ;
      private GXRadio radLeaveRequestHalfDay ;
      private GXCombobox cmbLeaveRequestStatus ;
      private IDataStoreProvider pr_default ;
      private long[] H004E2_A124LeaveTypeId ;
      private string[] H004E2_A125LeaveTypeName ;
      private long[] H004E2_A100CompanyId ;
      private long[] H004E3_A106EmployeeId ;
      private string[] H004E3_A148EmployeeName ;
      private long[] H004E3_A100CompanyId ;
      private long[] H004E4_A127LeaveRequestId ;
      private string[] H004E4_A134LeaveRequestRejectionReason ;
      private string[] H004E4_A132LeaveRequestStatus ;
      private decimal[] H004E4_A131LeaveRequestDuration ;
      private DateTime[] H004E4_A128LeaveRequestDate ;
      private string[] H004E4_A133LeaveRequestDescription ;
      private string[] H004E4_A173LeaveRequestHalfDay ;
      private bool[] H004E4_n173LeaveRequestHalfDay ;
      private DateTime[] H004E4_A130LeaveRequestEndDate ;
      private DateTime[] H004E4_A129LeaveRequestStartDate ;
      private long[] H004E4_A106EmployeeId ;
      private long[] H004E4_A124LeaveTypeId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class leaverequestgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH004E2;
          prmH004E2 = new Object[] {
          };
          Object[] prmH004E3;
          prmH004E3 = new Object[] {
          new ParDef("AV16Employeecompany",GXType.Number,10,2)
          };
          Object[] prmH004E4;
          prmH004E4 = new Object[] {
          new ParDef("LeaveRequestId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004E2", "SELECT LeaveTypeId, LeaveTypeName, CompanyId FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004E2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004E3", "SELECT EmployeeId, EmployeeName, CompanyId FROM Employee WHERE :AV16Employeecompany = CompanyId ORDER BY EmployeeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004E3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004E4", "SELECT LeaveRequestId, LeaveRequestRejectionReason, LeaveRequestStatus, LeaveRequestDuration, LeaveRequestDate, LeaveRequestDescription, LeaveRequestHalfDay, LeaveRequestEndDate, LeaveRequestStartDate, EmployeeId, LeaveTypeId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId ORDER BY LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004E4,1, GxCacheFrequency.OFF ,true,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
