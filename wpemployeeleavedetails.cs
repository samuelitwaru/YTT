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
   public class wpemployeeleavedetails : GXDataArea
   {
      public wpemployeeleavedetails( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpemployeeleavedetails( IGxContext context )
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
         dynavCompanylocationid = new GXCombobox();
         dynavProjectid = new GXCombobox();
         dynavEmployeeid = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPROJECTID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPROJECTID5T2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vEMPLOYEEID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvEMPLOYEEID5T2( ) ;
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
            return "wpemployeeleavedetails_Execute" ;
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
         PA5T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5T2( ) ;
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
         context.AddJavascriptSource("UserControls/UCLeavePivotTableRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpemployeeleavedetails.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVETYPECOLLECTION", AV8LeaveTypeCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVETYPECOLLECTION", AV8LeaveTypeCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTEMPLOYEELEAVEDETAILSCOLLECTION", AV7SDTEmployeeLeaveDetailsCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTEMPLOYEELEAVEDETAILSCOLLECTION", AV7SDTEmployeeLeaveDetailsCollection);
         }
         GxWebStd.gx_hidden_field( context, "vDATERANGE", context.localUtil.DToC( AV13DateRange, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGE_TO", context.localUtil.DToC( AV15DateRange_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDATERANGE_RANGEPICKEROPTIONS", AV16DateRange_RangePickerOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDATERANGE_RANGEPICKEROPTIONS", AV16DateRange_RangePickerOptions);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEIDCOLLECTION", AV22EmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEIDCOLLECTION", AV22EmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "LEAVETYPENAME", StringUtil.RTrim( A125LeaveTypeName));
         GxWebStd.gx_hidden_field( context, "COMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LEAVETYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEENAME", StringUtil.RTrim( A148EmployeeName));
         GxWebStd.gx_hidden_field( context, "COMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LEAVEPIVOTTABLE_Leavetypeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Leavepivottable_Leavetypeid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LEAVEPIVOTTABLE_Employeeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Leavepivottable_Employeeid), 9, 0, ".", "")));
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
            WE5T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5T2( ) ;
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
         return formatLink("wpemployeeleavedetails.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPEmployeeLeaveDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Overview" ;
      }

      protected void WB5T0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:50fr 50fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 850, "px", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:25fr 25fr 25fr 25fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MaxWidth-200 DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableaterange_rangetext_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdaterange_rangetext_Internalname, "Date Range", "", "", lblTextblockdaterange_rangetext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPEmployeeLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDaterange_rangetext_Internalname, "Date Range_Range Text", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDaterange_rangetext_Internalname, AV14DateRange_RangeText, StringUtil.RTrim( context.localUtil.Format( AV14DateRange_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDaterange_rangetext_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavDaterange_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPEmployeeLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MaxWidth-200 DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablecompanylocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcompanylocationid_Internalname, "Location", "", "", lblTextblockcompanylocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPEmployeeLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCompanylocationid_Internalname, "Company Location Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCompanylocationid, dynavCompanylocationid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12CompanyLocationId), 10, 0)), 1, dynavCompanylocationid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCompanylocationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_WPEmployeeLeaveDetails.htm");
            dynavCompanylocationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12CompanyLocationId), 10, 0));
            AssignProp("", false, dynavCompanylocationid_Internalname, "Values", (string)(dynavCompanylocationid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MaxWidth-200 DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableprojectid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockprojectid_Internalname, "Project", "", "", lblTextblockprojectid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPEmployeeLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProjectid_Internalname, "Project Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProjectid, dynavProjectid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11ProjectId), 10, 0)), 1, dynavProjectid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavProjectid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_WPEmployeeLeaveDetails.htm");
            dynavProjectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11ProjectId), 10, 0));
            AssignProp("", false, dynavProjectid_Internalname, "Values", (string)(dynavProjectid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MaxWidth-200 DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockemployeeid_Internalname, "Employee", "", "", lblTextblockemployeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPEmployeeLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEmployeeid_Internalname, "Employee Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEmployeeid, dynavEmployeeid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10EmployeeId), 10, 0)), 1, dynavEmployeeid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEmployeeid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_WPEmployeeLeaveDetails.htm");
            dynavEmployeeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10EmployeeId), 10, 0));
            AssignProp("", false, dynavEmployeeid_Internalname, "Values", (string)(dynavEmployeeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:flex-end;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreport_Internalname, "", "Report", bttBtnreport_Jsonclick, 5, "Report", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPEmployeeLeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucLeavepivottable.SetProperty("LeaveTypeCollection", AV8LeaveTypeCollection);
            ucLeavepivottable.SetProperty("SDTEmployeeLeaveDetailsCollection", AV7SDTEmployeeLeaveDetailsCollection);
            ucLeavepivottable.Render(context, "ucleavepivottable", Leavepivottable_Internalname, "LEAVEPIVOTTABLEContainer");
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
            ucDaterange_rangepicker.SetProperty("Start Date", AV13DateRange);
            ucDaterange_rangepicker.SetProperty("End Date", AV15DateRange_To);
            ucDaterange_rangepicker.SetProperty("PickerOptions", AV16DateRange_RangePickerOptions);
            ucDaterange_rangepicker.Render(context, "wwp.daterangepicker", Daterange_rangepicker_Internalname, "DATERANGE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5T2( )
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
         Form.Meta.addItem("description", "Leave Overview", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5T0( ) ;
      }

      protected void WS5T2( )
      {
         START5T2( ) ;
         EVT5T2( ) ;
      }

      protected void EVT5T2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DATERANGE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Daterange_rangepicker.Daterangechanged */
                              E115T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E125T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReport' */
                              E135T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCOMPANYLOCATIONID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E145T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPROJECTID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E155T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VEMPLOYEEID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E165T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E175T2 ();
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

      protected void WE5T2( )
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

      protected void PA5T2( )
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

      protected void GXDLVvCOMPANYLOCATIONID5T1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCOMPANYLOCATIONID_data5T1( ) ;
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

      protected void GXVvCOMPANYLOCATIONID_html5T1( )
      {
         long gxdynajaxvalue;
         GXDLVvCOMPANYLOCATIONID_data5T1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCompanylocationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV12CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV12CompanyLocationId), 10, 0));
         }
      }

      protected void GXDLVvCOMPANYLOCATIONID_data5T1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H005T2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005T2_A157CompanyLocationId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H005T2_A158CompanyLocationName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvPROJECTID5T2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPROJECTID_data5T2( ) ;
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

      protected void GXVvPROJECTID_html5T2( )
      {
         long gxdynajaxvalue;
         GXDLVvPROJECTID_data5T2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProjectid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavProjectid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPROJECTID_data5T2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H005T3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005T3_A102ProjectId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H005T3_A103ProjectName[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvEMPLOYEEID5T2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvEMPLOYEEID_data5T2( ) ;
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

      protected void GXVvEMPLOYEEID_html5T2( )
      {
         long gxdynajaxvalue;
         GXDLVvEMPLOYEEID_data5T2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEmployeeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavEmployeeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavEmployeeid.ItemCount > 0 )
         {
            AV10EmployeeId = (long)(Math.Round(NumberUtil.Val( dynavEmployeeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10EmployeeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10EmployeeId", StringUtil.LTrimStr( (decimal)(AV10EmployeeId), 10, 0));
         }
      }

      protected void GXDLVvEMPLOYEEID_data5T2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV23EmployeeIds } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor H005T4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005T4_A106EmployeeId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H005T4_A148EmployeeName[0]));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvPROJECTID_html5T2( ) ;
            GXVvEMPLOYEEID_html5T2( ) ;
            dynavCompanylocationid.Name = "vCOMPANYLOCATIONID";
            dynavCompanylocationid.WebTags = "";
            dynavCompanylocationid.removeAllItems();
            /* Using cursor H005T5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005T5_A157CompanyLocationId[0]), 10, 0)), H005T5_A158CompanyLocationName[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavCompanylocationid.ItemCount > 0 )
            {
               AV12CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV12CompanyLocationId), 10, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV12CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV12CompanyLocationId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCompanylocationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12CompanyLocationId), 10, 0));
            AssignProp("", false, dynavCompanylocationid_Internalname, "Values", dynavCompanylocationid.ToJavascriptSource(), true);
         }
         if ( dynavProjectid.ItemCount > 0 )
         {
            AV11ProjectId = (long)(Math.Round(NumberUtil.Val( dynavProjectid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11ProjectId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11ProjectId", StringUtil.LTrimStr( (decimal)(AV11ProjectId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProjectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11ProjectId), 10, 0));
            AssignProp("", false, dynavProjectid_Internalname, "Values", dynavProjectid.ToJavascriptSource(), true);
         }
         if ( dynavEmployeeid.ItemCount > 0 )
         {
            AV10EmployeeId = (long)(Math.Round(NumberUtil.Val( dynavEmployeeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10EmployeeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10EmployeeId", StringUtil.LTrimStr( (decimal)(AV10EmployeeId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEmployeeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10EmployeeId), 10, 0));
            AssignProp("", false, dynavEmployeeid_Internalname, "Values", dynavEmployeeid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5T2( ) ;
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

      protected void RF5T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E175T2 ();
            WB5T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5T2( )
      {
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         GXVvPROJECTID_html5T2( ) ;
         GXVvEMPLOYEEID_html5T2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E125T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLEAVETYPECOLLECTION"), AV8LeaveTypeCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTEMPLOYEELEAVEDETAILSCOLLECTION"), AV7SDTEmployeeLeaveDetailsCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vDATERANGE_RANGEPICKEROPTIONS"), AV16DateRange_RangePickerOptions);
            /* Read saved values. */
            AV13DateRange = context.localUtil.CToD( cgiGet( "vDATERANGE"), 0);
            AV15DateRange_To = context.localUtil.CToD( cgiGet( "vDATERANGE_TO"), 0);
            /* Read variables values. */
            AV14DateRange_RangeText = cgiGet( edtavDaterange_rangetext_Internalname);
            AssignAttri("", false, "AV14DateRange_RangeText", AV14DateRange_RangeText);
            dynavCompanylocationid.CurrentValue = cgiGet( dynavCompanylocationid_Internalname);
            AV12CompanyLocationId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavCompanylocationid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV12CompanyLocationId), 10, 0));
            dynavProjectid.CurrentValue = cgiGet( dynavProjectid_Internalname);
            AV11ProjectId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavProjectid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11ProjectId", StringUtil.LTrimStr( (decimal)(AV11ProjectId), 10, 0));
            dynavEmployeeid.CurrentValue = cgiGet( dynavEmployeeid_Internalname);
            AV10EmployeeId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavEmployeeid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10EmployeeId", StringUtil.LTrimStr( (decimal)(AV10EmployeeId), 10, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvPROJECTID_html5T2( ) ;
            GXVvEMPLOYEEID_html5T2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E125T2 ();
         if (returnInSub) return;
      }

      protected void E125T2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV13DateRange = context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), DateTimeUtil.Month( Gx_date), 1);
         AssignAttri("", false, "AV13DateRange", context.localUtil.Format(AV13DateRange, "99/99/99"));
         AV15DateRange_To = DateTimeUtil.DateEndOfMonth( AV13DateRange);
         AssignAttri("", false, "AV15DateRange_To", context.localUtil.Format(AV15DateRange_To, "99/99/99"));
         AV13DateRange = context.localUtil.YMDToD( 2024, 1, 1);
         AssignAttri("", false, "AV13DateRange", context.localUtil.Format(AV13DateRange, "99/99/99"));
         AV15DateRange_To = context.localUtil.YMDToD( 2024, 12, 31);
         AssignAttri("", false, "AV15DateRange_To", context.localUtil.Format(AV15DateRange_To, "99/99/99"));
         /* Execute user subroutine: 'SETUPACCORDINGTOROLE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'POPULATEPROJECTIDS' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'POPULATECOMPANYLOCATIONIDS' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'POPULATEEMPLOYEEIDS' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S152 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "DATERANGE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDaterange_rangetext_Internalname});
         GXt_SdtWWPDateRangePickerOptions1 = AV16DateRange_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions1) ;
         AV16DateRange_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions1;
      }

      protected void E135T2( )
      {
         /* 'DoReport' Routine */
         returnInSub = false;
         new employeeleavedetailsexport(context ).execute(  AV12CompanyLocationId, ref  AV22EmployeeIdCollection, ref  AV13DateRange, ref  AV7SDTEmployeeLeaveDetailsCollection, out  AV25ExcelFilename, out  AV26ErrorMessage) ;
         AssignAttri("", false, "AV13DateRange", context.localUtil.Format(AV13DateRange, "99/99/99"));
         if ( StringUtil.StrCmp(AV25ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV25ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV26ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTEmployeeLeaveDetailsCollection", AV7SDTEmployeeLeaveDetailsCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22EmployeeIdCollection", AV22EmployeeIdCollection);
      }

      protected void E115T2( )
      {
         /* Daterange_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETDATA' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22EmployeeIdCollection", AV22EmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTEmployeeLeaveDetailsCollection", AV7SDTEmployeeLeaveDetailsCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveTypeCollection", AV8LeaveTypeCollection);
      }

      protected void E145T2( )
      {
         /* Companylocationid_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'POPULATEEMPLOYEEIDS' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27EmployeeIdsByProject", AV27EmployeeIdsByProject);
         dynavEmployeeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10EmployeeId), 10, 0));
         AssignProp("", false, dynavEmployeeid_Internalname, "Values", dynavEmployeeid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22EmployeeIdCollection", AV22EmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTEmployeeLeaveDetailsCollection", AV7SDTEmployeeLeaveDetailsCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveTypeCollection", AV8LeaveTypeCollection);
      }

      protected void E155T2( )
      {
         /* Projectid_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'POPULATEEMPLOYEEIDS' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27EmployeeIdsByProject", AV27EmployeeIdsByProject);
         dynavEmployeeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10EmployeeId), 10, 0));
         AssignProp("", false, dynavEmployeeid_Internalname, "Values", dynavEmployeeid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22EmployeeIdCollection", AV22EmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTEmployeeLeaveDetailsCollection", AV7SDTEmployeeLeaveDetailsCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveTypeCollection", AV8LeaveTypeCollection);
      }

      protected void E165T2( )
      {
         /* Employeeid_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'POPULATEEMPLOYEEIDS' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27EmployeeIdsByProject", AV27EmployeeIdsByProject);
         dynavEmployeeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10EmployeeId), 10, 0));
         AssignProp("", false, dynavEmployeeid_Internalname, "Values", dynavEmployeeid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22EmployeeIdCollection", AV22EmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTEmployeeLeaveDetailsCollection", AV7SDTEmployeeLeaveDetailsCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveTypeCollection", AV8LeaveTypeCollection);
      }

      protected void S152( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         if ( ! (0==AV10EmployeeId) )
         {
            AV22EmployeeIdCollection.Clear();
            AV22EmployeeIdCollection.Add(AV10EmployeeId, 0);
         }
         GXt_objcol_SdtSDTEmployeeLeaveDetails2 = AV7SDTEmployeeLeaveDetailsCollection;
         new employeeleavedetailsreport(context ).execute(  AV13DateRange,  AV15DateRange_To,  AV22EmployeeIdCollection,  AV12CompanyLocationId, out  GXt_objcol_SdtSDTEmployeeLeaveDetails2) ;
         AV7SDTEmployeeLeaveDetailsCollection = GXt_objcol_SdtSDTEmployeeLeaveDetails2;
         AV8LeaveTypeCollection.Clear();
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV12CompanyLocationId ,
                                              A100CompanyId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H005T6 */
         pr_default.execute(4, new Object[] {AV12CompanyLocationId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A100CompanyId = H005T6_A100CompanyId[0];
            A124LeaveTypeId = H005T6_A124LeaveTypeId[0];
            A125LeaveTypeName = H005T6_A125LeaveTypeName[0];
            AV9LeaveType = new SdtLeaveType(context);
            AV9LeaveType.gxTpr_Leavetypeid = A124LeaveTypeId;
            AV9LeaveType.gxTpr_Leavetypename = A125LeaveTypeName;
            AV8LeaveTypeCollection.Add(AV9LeaveType, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S122( )
      {
         /* 'POPULATEPROJECTIDS' Routine */
         returnInSub = false;
         dynavProjectid.removeAllItems();
         dynavProjectid.addItem("0", "Select Project", 0);
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV30UserProjectIdCollection ,
                                              AV30UserProjectIdCollection.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor H005T7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A102ProjectId = H005T7_A102ProjectId[0];
            A103ProjectName = H005T7_A103ProjectName[0];
            dynavProjectid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0)), A103ProjectName, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S132( )
      {
         /* 'POPULATECOMPANYLOCATIONIDS' Routine */
         returnInSub = false;
         dynavCompanylocationid.removeAllItems();
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV32UserCompanyLocationId ,
                                              A157CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H005T8 */
         pr_default.execute(6, new Object[] {AV32UserCompanyLocationId});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A157CompanyLocationId = H005T8_A157CompanyLocationId[0];
            A158CompanyLocationName = H005T8_A158CompanyLocationName[0];
            dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0)), A158CompanyLocationName, 0);
            AV12CompanyLocationId = A157CompanyLocationId;
            AssignAttri("", false, "AV12CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV12CompanyLocationId), 10, 0));
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S142( )
      {
         /* 'POPULATEEMPLOYEEIDS' Routine */
         returnInSub = false;
         AV23EmployeeIds.Clear();
         if ( ! (0==AV11ProjectId) )
         {
            AV24ProjectIds.Clear();
            AV24ProjectIds.Add(AV11ProjectId, 0);
            GXt_objcol_int3 = AV27EmployeeIdsByProject;
            new getemployeeidsbyproject(context ).execute(  AV24ProjectIds, out  GXt_objcol_int3) ;
            AV27EmployeeIdsByProject = GXt_objcol_int3;
         }
         else
         {
            AV27EmployeeIdsByProject.Clear();
         }
         dynavEmployeeid.removeAllItems();
         AV22EmployeeIdCollection.Clear();
         dynavEmployeeid.addItem("0", "Select Employee", 0);
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV27EmployeeIdsByProject ,
                                              AV27EmployeeIdsByProject.Count ,
                                              A157CompanyLocationId ,
                                              AV12CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H005T9 */
         pr_default.execute(7, new Object[] {AV12CompanyLocationId});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A100CompanyId = H005T9_A100CompanyId[0];
            A106EmployeeId = H005T9_A106EmployeeId[0];
            A157CompanyLocationId = H005T9_A157CompanyLocationId[0];
            A148EmployeeName = H005T9_A148EmployeeName[0];
            A157CompanyLocationId = H005T9_A157CompanyLocationId[0];
            dynavEmployeeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0)), A148EmployeeName, 0);
            AV22EmployeeIdCollection.Add(A106EmployeeId, 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void S112( )
      {
         /* 'SETUPACCORDINGTOROLE' Routine */
         returnInSub = false;
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AV40Udparg1 = new getloggedinemployeeid(context).executeUdp( );
            /* Using cursor H005T10 */
            pr_default.execute(8, new Object[] {AV40Udparg1});
            while ( (pr_default.getStatus(8) != 101) )
            {
               A106EmployeeId = H005T10_A106EmployeeId[0];
               /* Using cursor H005T11 */
               pr_default.execute(9, new Object[] {A106EmployeeId});
               while ( (pr_default.getStatus(9) != 101) )
               {
                  A102ProjectId = H005T11_A102ProjectId[0];
                  AV30UserProjectIdCollection.Add(A102ProjectId, 0);
                  pr_default.readNext(9);
               }
               pr_default.close(9);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(8);
         }
         else if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            GXt_int4 = AV32UserCompanyLocationId;
            new getloggedinusercompanyid(context ).execute( out  GXt_int4) ;
            AV32UserCompanyLocationId = GXt_int4;
            AssignAttri("", false, "AV32UserCompanyLocationId", StringUtil.LTrimStr( (decimal)(AV32UserCompanyLocationId), 10, 0));
         }
         else
         {
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E175T2( )
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
         PA5T2( ) ;
         WS5T2( ) ;
         WE5T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249239504712", true, true);
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
         context.AddJavascriptSource("wpemployeeleavedetails.js", "?20249239504712", false, true);
         context.AddJavascriptSource("UserControls/UCLeavePivotTableRender.js", "", false, true);
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
         dynavCompanylocationid.Name = "vCOMPANYLOCATIONID";
         dynavCompanylocationid.WebTags = "";
         dynavCompanylocationid.removeAllItems();
         /* Using cursor H005T12 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005T12_A157CompanyLocationId[0]), 10, 0)), H005T12_A158CompanyLocationName[0], 0);
            pr_default.readNext(10);
         }
         pr_default.close(10);
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV12CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV12CompanyLocationId), 10, 0));
         }
         dynavProjectid.Name = "vPROJECTID";
         dynavProjectid.WebTags = "";
         dynavEmployeeid.Name = "vEMPLOYEEID";
         dynavEmployeeid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockdaterange_rangetext_Internalname = "TEXTBLOCKDATERANGE_RANGETEXT";
         edtavDaterange_rangetext_Internalname = "vDATERANGE_RANGETEXT";
         divUnnamedtableaterange_rangetext_Internalname = "UNNAMEDTABLEATERANGE_RANGETEXT";
         lblTextblockcompanylocationid_Internalname = "TEXTBLOCKCOMPANYLOCATIONID";
         dynavCompanylocationid_Internalname = "vCOMPANYLOCATIONID";
         divUnnamedtablecompanylocationid_Internalname = "UNNAMEDTABLECOMPANYLOCATIONID";
         lblTextblockprojectid_Internalname = "TEXTBLOCKPROJECTID";
         dynavProjectid_Internalname = "vPROJECTID";
         divUnnamedtableprojectid_Internalname = "UNNAMEDTABLEPROJECTID";
         lblTextblockemployeeid_Internalname = "TEXTBLOCKEMPLOYEEID";
         dynavEmployeeid_Internalname = "vEMPLOYEEID";
         divUnnamedtableemployeeid_Internalname = "UNNAMEDTABLEEMPLOYEEID";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         bttBtnreport_Internalname = "BTNREPORT";
         divTable1_Internalname = "TABLE1";
         Leavepivottable_Internalname = "LEAVEPIVOTTABLE";
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
         dynavEmployeeid_Jsonclick = "";
         dynavEmployeeid.Enabled = 1;
         dynavProjectid_Jsonclick = "";
         dynavProjectid.Enabled = 1;
         dynavCompanylocationid_Jsonclick = "";
         dynavCompanylocationid.Enabled = 1;
         edtavDaterange_rangetext_Jsonclick = "";
         edtavDaterange_rangetext_Enabled = 1;
         Leavepivottable_Employeeid = 0;
         Leavepivottable_Leavetypeid = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Leave Overview";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"dynavProjectid"},{"av":"AV11ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"dynavEmployeeid"},{"av":"AV10EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynavCompanylocationid"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOREPORT'","""{"handler":"E135T2","iparms":[{"av":"dynavCompanylocationid"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"AV13DateRange","fld":"vDATERANGE"},{"av":"AV7SDTEmployeeLeaveDetailsCollection","fld":"vSDTEMPLOYEELEAVEDETAILSCOLLECTION"}]""");
         setEventMetadata("'DOREPORT'",""","oparms":[{"av":"AV7SDTEmployeeLeaveDetailsCollection","fld":"vSDTEMPLOYEELEAVEDETAILSCOLLECTION"},{"av":"AV13DateRange","fld":"vDATERANGE"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"}]}""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED","""{"handler":"E115T2","iparms":[{"av":"dynavEmployeeid"},{"av":"AV10EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV13DateRange","fld":"vDATERANGE"},{"av":"AV15DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"dynavCompanylocationid"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A125LeaveTypeName","fld":"LEAVETYPENAME"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A124LeaveTypeId","fld":"LEAVETYPEID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED",""","oparms":[{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"AV7SDTEmployeeLeaveDetailsCollection","fld":"vSDTEMPLOYEELEAVEDETAILSCOLLECTION"},{"av":"AV8LeaveTypeCollection","fld":"vLEAVETYPECOLLECTION"}]}""");
         setEventMetadata("VCOMPANYLOCATIONID.CONTROLVALUECHANGED","""{"handler":"E145T2","iparms":[{"av":"dynavProjectid"},{"av":"AV11ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"dynavCompanylocationid"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynavEmployeeid"},{"av":"AV10EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV13DateRange","fld":"vDATERANGE"},{"av":"AV15DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"A125LeaveTypeName","fld":"LEAVETYPENAME"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A124LeaveTypeId","fld":"LEAVETYPEID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VCOMPANYLOCATIONID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV27EmployeeIdsByProject","fld":"vEMPLOYEEIDSBYPROJECT"},{"av":"dynavEmployeeid"},{"av":"AV10EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"AV7SDTEmployeeLeaveDetailsCollection","fld":"vSDTEMPLOYEELEAVEDETAILSCOLLECTION"},{"av":"AV8LeaveTypeCollection","fld":"vLEAVETYPECOLLECTION"}]}""");
         setEventMetadata("VPROJECTID.CONTROLVALUECHANGED","""{"handler":"E155T2","iparms":[{"av":"dynavProjectid"},{"av":"AV11ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"dynavCompanylocationid"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynavEmployeeid"},{"av":"AV10EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV13DateRange","fld":"vDATERANGE"},{"av":"AV15DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"A125LeaveTypeName","fld":"LEAVETYPENAME"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A124LeaveTypeId","fld":"LEAVETYPEID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VPROJECTID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV27EmployeeIdsByProject","fld":"vEMPLOYEEIDSBYPROJECT"},{"av":"dynavEmployeeid"},{"av":"AV10EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"AV7SDTEmployeeLeaveDetailsCollection","fld":"vSDTEMPLOYEELEAVEDETAILSCOLLECTION"},{"av":"AV8LeaveTypeCollection","fld":"vLEAVETYPECOLLECTION"}]}""");
         setEventMetadata("VEMPLOYEEID.CONTROLVALUECHANGED","""{"handler":"E165T2","iparms":[{"av":"dynavProjectid"},{"av":"AV11ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"dynavCompanylocationid"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynavEmployeeid"},{"av":"AV10EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV13DateRange","fld":"vDATERANGE"},{"av":"AV15DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"A125LeaveTypeName","fld":"LEAVETYPENAME"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A124LeaveTypeId","fld":"LEAVETYPEID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VEMPLOYEEID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV27EmployeeIdsByProject","fld":"vEMPLOYEEIDSBYPROJECT"},{"av":"dynavEmployeeid"},{"av":"AV10EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV22EmployeeIdCollection","fld":"vEMPLOYEEIDCOLLECTION"},{"av":"AV7SDTEmployeeLeaveDetailsCollection","fld":"vSDTEMPLOYEELEAVEDETAILSCOLLECTION"},{"av":"AV8LeaveTypeCollection","fld":"vLEAVETYPECOLLECTION"}]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV8LeaveTypeCollection = new GXBCCollection<SdtLeaveType>( context, "LeaveType", "YTT_version4");
         AV7SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4");
         AV13DateRange = DateTime.MinValue;
         AV15DateRange_To = DateTime.MinValue;
         AV16DateRange_RangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV22EmployeeIdCollection = new GxSimpleCollection<long>();
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblockdaterange_rangetext_Jsonclick = "";
         TempTags = "";
         AV14DateRange_RangeText = "";
         lblTextblockcompanylocationid_Jsonclick = "";
         lblTextblockprojectid_Jsonclick = "";
         lblTextblockemployeeid_Jsonclick = "";
         bttBtnreport_Jsonclick = "";
         ucLeavepivottable = new GXUserControl();
         ucDaterange_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H005T2_A157CompanyLocationId = new long[1] ;
         H005T2_A158CompanyLocationName = new string[] {""} ;
         H005T3_A102ProjectId = new long[1] ;
         H005T3_A103ProjectName = new string[] {""} ;
         AV23EmployeeIds = new GxSimpleCollection<long>();
         H005T4_A106EmployeeId = new long[1] ;
         H005T4_A148EmployeeName = new string[] {""} ;
         H005T5_A157CompanyLocationId = new long[1] ;
         H005T5_A158CompanyLocationName = new string[] {""} ;
         Gx_date = DateTime.MinValue;
         GXt_SdtWWPDateRangePickerOptions1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         AV25ExcelFilename = "";
         AV26ErrorMessage = "";
         AV27EmployeeIdsByProject = new GxSimpleCollection<long>();
         GXt_objcol_SdtSDTEmployeeLeaveDetails2 = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4");
         H005T6_A100CompanyId = new long[1] ;
         H005T6_A124LeaveTypeId = new long[1] ;
         H005T6_A125LeaveTypeName = new string[] {""} ;
         AV9LeaveType = new SdtLeaveType(context);
         AV30UserProjectIdCollection = new GxSimpleCollection<long>();
         H005T7_A102ProjectId = new long[1] ;
         H005T7_A103ProjectName = new string[] {""} ;
         A103ProjectName = "";
         H005T8_A157CompanyLocationId = new long[1] ;
         H005T8_A158CompanyLocationName = new string[] {""} ;
         A158CompanyLocationName = "";
         AV24ProjectIds = new GxSimpleCollection<long>();
         GXt_objcol_int3 = new GxSimpleCollection<long>();
         H005T9_A100CompanyId = new long[1] ;
         H005T9_A106EmployeeId = new long[1] ;
         H005T9_A157CompanyLocationId = new long[1] ;
         H005T9_A148EmployeeName = new string[] {""} ;
         H005T10_A106EmployeeId = new long[1] ;
         H005T11_A106EmployeeId = new long[1] ;
         H005T11_A102ProjectId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H005T12_A157CompanyLocationId = new long[1] ;
         H005T12_A158CompanyLocationName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpemployeeleavedetails__default(),
            new Object[][] {
                new Object[] {
               H005T2_A157CompanyLocationId, H005T2_A158CompanyLocationName
               }
               , new Object[] {
               H005T3_A102ProjectId, H005T3_A103ProjectName
               }
               , new Object[] {
               H005T4_A106EmployeeId, H005T4_A148EmployeeName
               }
               , new Object[] {
               H005T5_A157CompanyLocationId, H005T5_A158CompanyLocationName
               }
               , new Object[] {
               H005T6_A100CompanyId, H005T6_A124LeaveTypeId, H005T6_A125LeaveTypeName
               }
               , new Object[] {
               H005T7_A102ProjectId, H005T7_A103ProjectName
               }
               , new Object[] {
               H005T8_A157CompanyLocationId, H005T8_A158CompanyLocationName
               }
               , new Object[] {
               H005T9_A100CompanyId, H005T9_A106EmployeeId, H005T9_A157CompanyLocationId, H005T9_A148EmployeeName
               }
               , new Object[] {
               H005T10_A106EmployeeId
               }
               , new Object[] {
               H005T11_A106EmployeeId, H005T11_A102ProjectId
               }
               , new Object[] {
               H005T12_A157CompanyLocationId, H005T12_A158CompanyLocationName
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
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
      private int Leavepivottable_Leavetypeid ;
      private int Leavepivottable_Employeeid ;
      private int edtavDaterange_rangetext_Enabled ;
      private int gxdynajaxindex ;
      private int AV30UserProjectIdCollection_Count ;
      private int AV27EmployeeIdsByProject_Count ;
      private int idxLst ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long AV12CompanyLocationId ;
      private long AV11ProjectId ;
      private long AV10EmployeeId ;
      private long A102ProjectId ;
      private long AV32UserCompanyLocationId ;
      private long AV40Udparg1 ;
      private long GXt_int4 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divUnnamedtableaterange_rangetext_Internalname ;
      private string lblTextblockdaterange_rangetext_Internalname ;
      private string lblTextblockdaterange_rangetext_Jsonclick ;
      private string edtavDaterange_rangetext_Internalname ;
      private string TempTags ;
      private string edtavDaterange_rangetext_Jsonclick ;
      private string divUnnamedtablecompanylocationid_Internalname ;
      private string lblTextblockcompanylocationid_Internalname ;
      private string lblTextblockcompanylocationid_Jsonclick ;
      private string dynavCompanylocationid_Internalname ;
      private string dynavCompanylocationid_Jsonclick ;
      private string divUnnamedtableprojectid_Internalname ;
      private string lblTextblockprojectid_Internalname ;
      private string lblTextblockprojectid_Jsonclick ;
      private string dynavProjectid_Internalname ;
      private string dynavProjectid_Jsonclick ;
      private string divUnnamedtableemployeeid_Internalname ;
      private string lblTextblockemployeeid_Internalname ;
      private string lblTextblockemployeeid_Jsonclick ;
      private string dynavEmployeeid_Internalname ;
      private string dynavEmployeeid_Jsonclick ;
      private string bttBtnreport_Internalname ;
      private string bttBtnreport_Jsonclick ;
      private string Leavepivottable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Daterange_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string A103ProjectName ;
      private string A158CompanyLocationName ;
      private DateTime AV13DateRange ;
      private DateTime AV15DateRange_To ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV14DateRange_RangeText ;
      private string AV25ExcelFilename ;
      private string AV26ErrorMessage ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucLeavepivottable ;
      private GXUserControl ucDaterange_rangepicker ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCompanylocationid ;
      private GXCombobox dynavProjectid ;
      private GXCombobox dynavEmployeeid ;
      private GXBCCollection<SdtLeaveType> AV8LeaveTypeCollection ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> AV7SDTEmployeeLeaveDetailsCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV16DateRange_RangePickerOptions ;
      private GxSimpleCollection<long> AV22EmployeeIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] H005T2_A157CompanyLocationId ;
      private string[] H005T2_A158CompanyLocationName ;
      private long[] H005T3_A102ProjectId ;
      private string[] H005T3_A103ProjectName ;
      private GxSimpleCollection<long> AV23EmployeeIds ;
      private long[] H005T4_A106EmployeeId ;
      private string[] H005T4_A148EmployeeName ;
      private long[] H005T5_A157CompanyLocationId ;
      private string[] H005T5_A158CompanyLocationName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions1 ;
      private GxSimpleCollection<long> AV27EmployeeIdsByProject ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> GXt_objcol_SdtSDTEmployeeLeaveDetails2 ;
      private long[] H005T6_A100CompanyId ;
      private long[] H005T6_A124LeaveTypeId ;
      private string[] H005T6_A125LeaveTypeName ;
      private SdtLeaveType AV9LeaveType ;
      private GxSimpleCollection<long> AV30UserProjectIdCollection ;
      private long[] H005T7_A102ProjectId ;
      private string[] H005T7_A103ProjectName ;
      private long[] H005T8_A157CompanyLocationId ;
      private string[] H005T8_A158CompanyLocationName ;
      private GxSimpleCollection<long> AV24ProjectIds ;
      private GxSimpleCollection<long> GXt_objcol_int3 ;
      private long[] H005T9_A100CompanyId ;
      private long[] H005T9_A106EmployeeId ;
      private long[] H005T9_A157CompanyLocationId ;
      private string[] H005T9_A148EmployeeName ;
      private long[] H005T10_A106EmployeeId ;
      private long[] H005T11_A106EmployeeId ;
      private long[] H005T11_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H005T12_A157CompanyLocationId ;
      private string[] H005T12_A158CompanyLocationName ;
   }

   public class wpemployeeleavedetails__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005T4( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV23EmployeeIds )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV23EmployeeIds, "EmployeeId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
         GXv_Object5[0] = scmdbuf;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H005T6( IGxContext context ,
                                             long AV12CompanyLocationId ,
                                             long A100CompanyId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[1];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT CompanyId, LeaveTypeId, LeaveTypeName FROM LeaveType";
         if ( ! (0==AV12CompanyLocationId) )
         {
            AddWhere(sWhereString, "(CompanyId = :AV12CompanyLocationId)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LeaveTypeName";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H005T7( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV30UserProjectIdCollection ,
                                             int AV30UserProjectIdCollection_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT ProjectId, ProjectName FROM Project";
         if ( AV30UserProjectIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV30UserProjectIdCollection, "ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProjectName";
         GXv_Object9[0] = scmdbuf;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H005T8( IGxContext context ,
                                             long AV32UserCompanyLocationId ,
                                             long A157CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[1];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation";
         if ( ! (0==AV32UserCompanyLocationId) )
         {
            AddWhere(sWhereString, "(CompanyLocationId = :AV32UserCompanyLocationId)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationId";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_H005T9( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV27EmployeeIdsByProject ,
                                             int AV27EmployeeIdsByProject_Count ,
                                             long A157CompanyLocationId ,
                                             long AV12CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[1];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId, T1.EmployeeName FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "(T2.CompanyLocationId = :AV12CompanyLocationId)");
         if ( AV27EmployeeIdsByProject_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV27EmployeeIdsByProject, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H005T4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 4 :
                     return conditional_H005T6(context, (long)dynConstraints[0] , (long)dynConstraints[1] );
               case 5 :
                     return conditional_H005T7(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
               case 6 :
                     return conditional_H005T8(context, (long)dynConstraints[0] , (long)dynConstraints[1] );
               case 7 :
                     return conditional_H005T9(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005T2;
          prmH005T2 = new Object[] {
          };
          Object[] prmH005T3;
          prmH005T3 = new Object[] {
          };
          Object[] prmH005T5;
          prmH005T5 = new Object[] {
          };
          Object[] prmH005T10;
          prmH005T10 = new Object[] {
          new ParDef("AV40Udparg1",GXType.Int64,10,0)
          };
          Object[] prmH005T11;
          prmH005T11 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH005T12;
          prmH005T12 = new Object[] {
          };
          Object[] prmH005T4;
          prmH005T4 = new Object[] {
          };
          Object[] prmH005T6;
          prmH005T6 = new Object[] {
          new ParDef("AV12CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmH005T7;
          prmH005T7 = new Object[] {
          };
          Object[] prmH005T8;
          prmH005T8 = new Object[] {
          new ParDef("AV32UserCompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmH005T9;
          prmH005T9 = new Object[] {
          new ParDef("AV12CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005T2", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005T3", "SELECT ProjectId, ProjectName FROM Project ORDER BY ProjectName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005T4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005T5", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005T6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005T7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005T8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005T9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005T10", "SELECT EmployeeId FROM Employee WHERE EmployeeId = :AV40Udparg1 ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H005T11", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005T12", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T12,0, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}