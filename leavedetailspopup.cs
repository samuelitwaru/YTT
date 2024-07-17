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
   public class leavedetailspopup : GXDataArea
   {
      public leavedetailspopup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leavedetailspopup( IGxContext context )
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
         cmbavLeaverequest_leaverequeststatus = new GXCombobox();
         radavLeaverequest_leavetypevacationleave = new GXRadio();
         chkavLeaverequest_holidays__isapplicable = new GXCheckbox();
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
         nRC_GXsfl_94 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_94"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_94_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_94_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_94_idx = GetPar( "sGXsfl_94_idx");
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
         AV12TrnMode = GetPar( "TrnMode");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV8LeaveRequest);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19LeaveRequestHolidaysDeleted);
         AV8LeaveRequest.gxTpr_Leavetypevacationleave = GetNextPar( );
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
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
         PA3O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3O2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leavedetailspopup.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Leaverequest", AV8LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Leaverequest", AV8LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_94", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_94), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVEREQUESTHOLIDAYSDELETED", AV19LeaveRequestHolidaysDeleted);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVEREQUESTHOLIDAYSDELETED", AV19LeaveRequestHolidaysDeleted);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV14CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV11Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV11Messages);
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nEOF), 1, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVEREQUEST", AV8LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVEREQUEST", AV8LeaveRequest);
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
            WE3O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3O2( ) ;
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
         return formatLink("leavedetailspopup.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveDetailsPopup" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Details Popup" ;
      }

      protected void WB3O0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestid_Internalname, "Request Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), 10, 0, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_leaverequestid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leaverequestid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leavetypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leavetypeid_Internalname, "Leave Type Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_94_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leavetypeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leavetypeid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leavetypeid_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveDetailsPopup.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leavetypename_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leavetypename), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Leavetypename, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leavetypename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leavetypename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveDetailsPopup.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_94_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestdate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestdate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequestdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveDetailsPopup.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_94_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequeststartdate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequeststartdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequeststartdate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequeststartdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveDetailsPopup.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_94_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestenddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestenddate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestenddate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestenddate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestenddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequestenddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveDetailsPopup.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequesthalfday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequesthalfday_Internalname, "Half Day", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_94_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequesthalfday_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequesthalfday), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequesthalfday, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequesthalfday_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leaverequesthalfday_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestduration_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestduration_Internalname, "Request Duration", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_94_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestduration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8LeaveRequest.gxTpr_Leaverequestduration, 4, 1, ".", "")), StringUtil.LTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestduration, "Z9.9")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestduration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leaverequestduration_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLeaverequest_leaverequeststatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLeaverequest_leaverequeststatus_Internalname, "Request Status", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_94_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLeaverequest_leaverequeststatus, cmbavLeaverequest_leaverequeststatus_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus), 1, cmbavLeaverequest_leaverequeststatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavLeaverequest_leaverequeststatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 0, "HLP_LeaveDetailsPopup.htm");
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", (string)(cmbavLeaverequest_leaverequeststatus.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_94_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestdescription_Internalname, AV8LeaveRequest.gxTpr_Leaverequestdescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", 0, 1, edtavLeaverequest_leaverequestdescription_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestrejectionreason_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Rejection Reason", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_94_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, AV8LeaveRequest.gxTpr_Leaverequestrejectionreason, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", 0, 1, edtavLeaverequest_leaverequestrejectionreason_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeeid_Internalname, "Employee Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_94_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Employeeid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8LeaveRequest.gxTpr_Employeeid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeeid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeeid_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeename_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Employeename), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeename, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeebalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeebalance_Internalname, "Employee Balance", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8LeaveRequest.gxTpr_Employeebalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_employeebalance_Enabled!=0) ? context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeebalance, "Z9.9") : context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeebalance, "Z9.9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeebalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavLeaverequest_leavetypevacationleave_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Leave Type Vacation Leave", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_94_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leavetypevacationleave, radavLeaverequest_leavetypevacationleave_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leavetypevacationleave), "", 1, radavLeaverequest_leavetypevacationleave.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leavetypevacationleave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "HLP_LeaveDetailsPopup.htm");
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
            StartGridControl94( ) ;
         }
         if ( wbEnd == 94 )
         {
            wbEnd = 0;
            nRC_GXsfl_94 = (int)(nGXsfl_94_idx-1);
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridlevel_holidaysContainer.AddObjectProperty("GRIDLEVEL_HOLIDAYS_nEOF", GRIDLEVEL_HOLIDAYS_nEOF);
               Gridlevel_holidaysContainer.AddObjectProperty("GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage", GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
               AV35GXV16 = nGXsfl_94_idx;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ButtonAddGridLineCell", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "ButtonAddNewRow";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddgridlinegridlevel_holidays_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(94), 2, 0)+","+"null"+");", "[[New row]]", bttBtnaddgridlinegridlevel_holidays_Jsonclick, 5, "[[New row]]", "", StyleString, ClassString, bttBtnaddgridlinegridlevel_holidays_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADDGRIDLINEGRIDLEVEL_HOLIDAYS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveDetailsPopup.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(94), 2, 0)+","+"null"+");", "Confirm", bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveDetailsPopup.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(94), 2, 0)+","+"null"+");", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveDetailsPopup.htm");
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
            ucGridlevel_holidays_empowerer.Render(context, "wwp.gridempowerer", Gridlevel_holidays_empowerer_Internalname, "GRIDLEVEL_HOLIDAYS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 94 )
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
                  AV35GXV16 = nGXsfl_94_idx;
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

      protected void START3O2( )
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
         Form.Meta.addItem("description", "Leave Details Popup", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3O0( ) ;
      }

      protected void WS3O2( )
      {
         START3O2( ) ;
         EVT3O2( ) ;
      }

      protected void EVT3O2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOADDGRIDLINEGRIDLEVEL_HOLIDAYS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAddGridLineGridLevel_Holidays' */
                              E113O2 ();
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
                                    E123O2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "GRIDLEVEL_HOLIDAYS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 39), "VDELETEGRIDLINEGRIDLEVEL_HOLIDAYS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 39), "VDELETEGRIDLINEGRIDLEVEL_HOLIDAYS.CLICK") == 0 ) )
                           {
                              nGXsfl_94_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
                              SubsflControlProps_942( ) ;
                              AV35GXV16 = (int)(nGXsfl_94_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
                              if ( ( AV8LeaveRequest.gxTpr_Holidays.Count >= AV35GXV16 ) && ( AV35GXV16 > 0 ) )
                              {
                                 AV8LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16));
                                 AV9DeleteGridLineGridLevel_Holidays = cgiGet( edtavDeletegridlinegridlevel_holidays_Internalname);
                                 AssignAttri("", false, edtavDeletegridlinegridlevel_holidays_Internalname, AV9DeleteGridLineGridLevel_Holidays);
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
                                    E133O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E143O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_HOLIDAYS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E153O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETEGRIDLINEGRIDLEVEL_HOLIDAYS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E163O2 ();
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

      protected void WE3O2( )
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

      protected void PA3O2( )
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
               GX_FocusControl = edtavLeaverequest_leaverequestid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridlevel_holidays_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_942( ) ;
         while ( nGXsfl_94_idx <= nRC_GXsfl_94 )
         {
            sendrow_942( ) ;
            nGXsfl_94_idx = ((subGridlevel_holidays_Islastpage==1)&&(nGXsfl_94_idx+1>subGridlevel_holidays_fnc_Recordsperpage( )) ? 1 : nGXsfl_94_idx+1);
            sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
            SubsflControlProps_942( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_holidaysContainer)) ;
         /* End function gxnrGridlevel_holidays_newrow */
      }

      protected void gxgrGridlevel_holidays_refresh( int subGridlevel_holidays_Rows ,
                                                     string AV12TrnMode ,
                                                     SdtLeaveRequest AV8LeaveRequest ,
                                                     GxSimpleCollection<short> AV19LeaveRequestHolidaysDeleted ,
                                                     string GXV15 )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDLEVEL_HOLIDAYS_nCurrentRecord = 0;
         RF3O2( ) ;
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
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV8LeaveRequest.gxTpr_Leaverequeststatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", cmbavLeaverequest_leaverequeststatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavLeaverequest_leaverequestid_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestid_Enabled), 5, 0), true);
         edtavLeaverequest_leavetypename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leavetypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Enabled), 5, 0), true);
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         edtavLeaverequest_employeebalance_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
         radavLeaverequest_leavetypevacationleave.Enabled = 0;
         AssignProp("", false, radavLeaverequest_leavetypevacationleave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leavetypevacationleave.Enabled), 5, 0), true);
         edtavDeletegridlinegridlevel_holidays_Enabled = 0;
         AssignProp("", false, edtavDeletegridlinegridlevel_holidays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeletegridlinegridlevel_holidays_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavLeaverequest_holidays__holidayname_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_holidays__holidayname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_holidays__holidayname_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavLeaverequest_holidays__holidaystartdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_holidays__holidaystartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_holidays__holidaystartdate_Enabled), 5, 0), !bGXsfl_94_Refreshing);
      }

      protected void RF3O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_holidaysContainer.ClearRows();
         }
         wbStart = 94;
         /* Execute user event: Refresh */
         E143O2 ();
         nGXsfl_94_idx = 1;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_942( ) ;
         bGXsfl_94_Refreshing = true;
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
            SubsflControlProps_942( ) ;
            E153O2 ();
            if ( ( subGridlevel_holidays_Islastpage == 0 ) && ( GRIDLEVEL_HOLIDAYS_nCurrentRecord > 0 ) && ( GRIDLEVEL_HOLIDAYS_nGridOutOfScope == 0 ) && ( nGXsfl_94_idx == 1 ) )
            {
               GRIDLEVEL_HOLIDAYS_nCurrentRecord = 0;
               GRIDLEVEL_HOLIDAYS_nGridOutOfScope = 1;
               subgridlevel_holidays_firstpage( ) ;
               E153O2 ();
            }
            wbEnd = 94;
            WB3O0( ) ;
         }
         bGXsfl_94_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3O2( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
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
         return AV8LeaveRequest.gxTpr_Holidays.Count ;
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
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
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
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
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
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
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
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
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
            gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavLeaverequest_leaverequestid_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestid_Enabled), 5, 0), true);
         edtavLeaverequest_leavetypename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leavetypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Enabled), 5, 0), true);
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         edtavLeaverequest_employeebalance_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
         radavLeaverequest_leavetypevacationleave.Enabled = 0;
         AssignProp("", false, radavLeaverequest_leavetypevacationleave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leavetypevacationleave.Enabled), 5, 0), true);
         edtavDeletegridlinegridlevel_holidays_Enabled = 0;
         AssignProp("", false, edtavDeletegridlinegridlevel_holidays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeletegridlinegridlevel_holidays_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavLeaverequest_holidays__holidayname_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_holidays__holidayname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_holidays__holidayname_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavLeaverequest_holidays__holidaystartdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_holidays__holidaystartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_holidays__holidaystartdate_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLEAVEREQUEST"), AV8LeaveRequest);
            ajax_req_read_hidden_sdt(cgiGet( "Leaverequest"), AV8LeaveRequest);
            /* Read saved values. */
            nRC_GXsfl_94 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_94"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDLEVEL_HOLIDAYS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_HOLIDAYS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGridlevel_holidays_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_HOLIDAYS_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Rows), 6, 0, ".", "")));
            Gridlevel_holidays_empowerer_Gridinternalname = cgiGet( "GRIDLEVEL_HOLIDAYS_EMPOWERER_Gridinternalname");
            nRC_GXsfl_94 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_94"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_94_fel_idx = 0;
            while ( nGXsfl_94_fel_idx < nRC_GXsfl_94 )
            {
               nGXsfl_94_fel_idx = ((subGridlevel_holidays_Islastpage==1)&&(nGXsfl_94_fel_idx+1>subGridlevel_holidays_fnc_Recordsperpage( )) ? 1 : nGXsfl_94_fel_idx+1);
               sGXsfl_94_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_942( ) ;
               AV35GXV16 = (int)(nGXsfl_94_fel_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
               if ( ( AV8LeaveRequest.gxTpr_Holidays.Count >= AV35GXV16 ) && ( AV35GXV16 > 0 ) )
               {
                  AV8LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16));
                  AV9DeleteGridLineGridLevel_Holidays = cgiGet( edtavDeletegridlinegridlevel_holidays_Internalname);
               }
            }
            if ( nGXsfl_94_fel_idx == 0 )
            {
               nGXsfl_94_idx = 1;
               sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
               SubsflControlProps_942( ) ;
            }
            nGXsfl_94_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTID");
               GX_FocusControl = edtavLeaverequest_leaverequestid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestid = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leavetypeid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leavetypeid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVETYPEID");
               GX_FocusControl = edtavLeaverequest_leavetypeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leavetypeid = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavLeaverequest_leavetypeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            AV8LeaveRequest.gxTpr_Leavetypename = cgiGet( edtavLeaverequest_leavetypename_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestdate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 2);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Start Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequeststartdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequeststartdate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequeststartdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request End Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTENDDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestenddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestenddate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestenddate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2);
            }
            AV8LeaveRequest.gxTpr_Leaverequesthalfday = cgiGet( edtavLeaverequest_leaverequesthalfday_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTDURATION");
               GX_FocusControl = edtavLeaverequest_leaverequestduration_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestduration = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestduration = context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",");
            }
            cmbavLeaverequest_leaverequeststatus.Name = cmbavLeaverequest_leaverequeststatus_Internalname;
            cmbavLeaverequest_leaverequeststatus.CurrentValue = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequestdescription = cgiGet( edtavLeaverequest_leaverequestdescription_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequestrejectionreason = cgiGet( edtavLeaverequest_leaverequestrejectionreason_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeeid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeeid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_EMPLOYEEID");
               GX_FocusControl = edtavLeaverequest_employeeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Employeeid = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Employeeid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavLeaverequest_employeeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            AV8LeaveRequest.gxTpr_Employeename = cgiGet( edtavLeaverequest_employeename_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_EMPLOYEEBALANCE");
               GX_FocusControl = edtavLeaverequest_employeebalance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Employeebalance = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Employeebalance = context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",");
            }
            AV8LeaveRequest.gxTpr_Leavetypevacationleave = cgiGet( radavLeaverequest_leavetypevacationleave_Internalname);
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
         E133O2 ();
         if (returnInSub) return;
      }

      protected void E133O2( )
      {
         /* Start Routine */
         returnInSub = false;
         GX_msglist.addItem("Not shoing!");
         new logtofile(context ).execute(  ">>>>>>>>>>>"+"DSP") ;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV13LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Insert") ) || ( ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Update") ) || ( ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "INS") != 0 )
            {
               AV8LeaveRequest.Load(AV16LeaveRequestId);
               gx_BV94 = true;
               AV13LoadSuccess = AV8LeaveRequest.Success();
               if ( ! AV13LoadSuccess )
               {
                  AV11Messages = AV8LeaveRequest.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
               {
                  edtavLeaverequest_leavetypeid_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypeid_Enabled), 5, 0), true);
                  edtavLeaverequest_leaverequestdate_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leaverequestdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdate_Enabled), 5, 0), true);
                  edtavLeaverequest_leaverequeststartdate_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
                  edtavLeaverequest_leaverequestenddate_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
                  edtavLeaverequest_leaverequesthalfday_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequesthalfday_Enabled), 5, 0), true);
                  edtavLeaverequest_leaverequestduration_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
                  cmbavLeaverequest_leaverequeststatus.Enabled = 0;
                  AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLeaverequest_leaverequeststatus.Enabled), 5, 0), true);
                  edtavLeaverequest_leaverequestdescription_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
                  edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
                  edtavLeaverequest_employeeid_Enabled = 0;
                  AssignProp("", false, edtavLeaverequest_employeeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeeid_Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV13LoadSuccess = false;
            CallWebObject(formatLink("gamnotauthorized.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( AV13LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirm deletion.");
            }
         }
         divTablecontent_Width = 500;
         AssignProp("", false, divTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablecontent_Width), 9, 0), true);
         Gridlevel_holidays_empowerer_Gridinternalname = subGridlevel_holidays_Internalname;
         ucGridlevel_holidays_empowerer.SendProperty(context, "", false, Gridlevel_holidays_empowerer_Internalname, "GridInternalName", Gridlevel_holidays_empowerer_Gridinternalname);
         subGridlevel_holidays_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_holidays_Rows), 6, 0, ".", "")));
      }

      protected void E143O2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         edtavDeletegridlinegridlevel_holidays_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavDeletegridlinegridlevel_holidays_Internalname, "Columnheaderclass", edtavDeletegridlinegridlevel_holidays_Columnheaderclass, !bGXsfl_94_Refreshing);
         edtavLeaverequest_holidays__holidayid_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavLeaverequest_holidays__holidayid_Internalname, "Columnheaderclass", edtavLeaverequest_holidays__holidayid_Columnheaderclass, !bGXsfl_94_Refreshing);
         edtavLeaverequest_holidays__holidayname_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavLeaverequest_holidays__holidayname_Internalname, "Columnheaderclass", edtavLeaverequest_holidays__holidayname_Columnheaderclass, !bGXsfl_94_Refreshing);
         edtavLeaverequest_holidays__holidaystartdate_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavLeaverequest_holidays__holidaystartdate_Internalname, "Columnheaderclass", edtavLeaverequest_holidays__holidaystartdate_Columnheaderclass, !bGXsfl_94_Refreshing);
         chkavLeaverequest_holidays__isapplicable_Columnheaderclass = "WWColumn";
         AssignProp("", false, chkavLeaverequest_holidays__isapplicable_Internalname, "Columnheaderclass", chkavLeaverequest_holidays__isapplicable_Columnheaderclass, !bGXsfl_94_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E153O2( )
      {
         /* Gridlevel_holidays_Load Routine */
         returnInSub = false;
         AV35GXV16 = 1;
         while ( AV35GXV16 <= AV8LeaveRequest.gxTpr_Holidays.Count )
         {
            AV8LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16));
            AV15LineDeleted = (bool)(((AV19LeaveRequestHolidaysDeleted.IndexOf((short)(AV8LeaveRequest.gxTpr_Holidays.IndexOf(AV8LeaveRequest.gxTpr_Holidays.CurrentItem)))>0)));
            edtavLeaverequest_holidays__holidayid_Enabled = (((StringUtil.StrCmp(AV12TrnMode, "INS")==0)||(StringUtil.StrCmp(AV12TrnMode, "UPD")==0))&&(!AV15LineDeleted)&&StringUtil.Contains( AV8LeaveRequest.gxTpr_Holidays.CurrentItem.ToXml(false, true, "", ""), "<Mode>INS</Mode>") ? 1 : 0);
            chkavLeaverequest_holidays__isapplicable.Enabled = (((StringUtil.StrCmp(AV12TrnMode, "INS")==0)||(StringUtil.StrCmp(AV12TrnMode, "UPD")==0))&&(!AV15LineDeleted) ? 1 : 0);
            AV9DeleteGridLineGridLevel_Holidays = "<i class=\"TrnGridDelete fa fa-times\"></i>";
            AssignAttri("", false, edtavDeletegridlinegridlevel_holidays_Internalname, AV9DeleteGridLineGridLevel_Holidays);
            if ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) )
            {
               edtavDeletegridlinegridlevel_holidays_Class = "Attribute";
            }
            else
            {
               edtavDeletegridlinegridlevel_holidays_Class = "Invisible";
            }
            edtavDeletegridlinegridlevel_holidays_Columnclass = (AV15LineDeleted ? "WWIconActionColumn WWColumnLineThrough WWColumnLineThroughFirstColumn" : "WWIconActionColumn");
            edtavLeaverequest_holidays__holidayid_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            edtavLeaverequest_holidays__holidayname_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            edtavLeaverequest_holidays__holidaystartdate_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            chkavLeaverequest_holidays__isapplicable_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 94;
            }
            if ( ( subGridlevel_holidays_Islastpage == 1 ) || ( subGridlevel_holidays_Rows == 0 ) || ( ( GRIDLEVEL_HOLIDAYS_nCurrentRecord >= GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage ) && ( GRIDLEVEL_HOLIDAYS_nCurrentRecord < GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage + subGridlevel_holidays_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_942( ) ;
            }
            GRIDLEVEL_HOLIDAYS_nEOF = (short)(((GRIDLEVEL_HOLIDAYS_nCurrentRecord<GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage+subGridlevel_holidays_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_HOLIDAYS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_HOLIDAYS_nEOF), 1, 0, ".", "")));
            GRIDLEVEL_HOLIDAYS_nCurrentRecord = (long)(GRIDLEVEL_HOLIDAYS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_94_Refreshing )
            {
               DoAjaxLoad(94, Gridlevel_holidaysRow);
            }
            AV35GXV16 = (int)(AV35GXV16+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E113O2( )
      {
         AV35GXV16 = (int)(nGXsfl_94_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
         if ( ( AV35GXV16 > 0 ) && ( AV8LeaveRequest.gxTpr_Holidays.Count >= AV35GXV16 ) )
         {
            AV8LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16));
         }
         /* 'DoAddGridLineGridLevel_Holidays' Routine */
         returnInSub = false;
         AV17LeaveRequestHolidaysItem = new SdtLeaveRequest_Holidays(context);
         AV8LeaveRequest.gxTpr_Holidays.Add(AV17LeaveRequestHolidaysItem, 0);
         gx_BV94 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_942( ) ;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E123O2 ();
         if (returnInSub) return;
      }

      protected void E123O2( )
      {
         AV35GXV16 = (int)(nGXsfl_94_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
         if ( ( AV35GXV16 > 0 ) && ( AV8LeaveRequest.gxTpr_Holidays.Count >= AV35GXV16 ) )
         {
            AV8LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV12TrnMode, "DLT") != 0 )
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S132 ();
            if (returnInSub) return;
         }
         if ( ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) || AV14CheckRequiredFieldsResult )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
            {
               AV8LeaveRequest.Delete();
               gx_BV94 = true;
            }
            else
            {
               AV19LeaveRequestHolidaysDeleted.Sort("");
               while ( AV19LeaveRequestHolidaysDeleted.Count > 0 )
               {
                  AV8LeaveRequest.gxTpr_Holidays.RemoveItem((int)(AV19LeaveRequestHolidaysDeleted.GetNumeric(AV19LeaveRequestHolidaysDeleted.Count)));
                  gx_BV94 = true;
                  AV19LeaveRequestHolidaysDeleted.RemoveItem(AV19LeaveRequestHolidaysDeleted.Count);
               }
               AV8LeaveRequest.Save();
               gx_BV94 = true;
            }
            if ( AV8LeaveRequest.Success() )
            {
               /* Execute user subroutine: 'AFTER_TRN' */
               S142 ();
               if (returnInSub) return;
            }
            else
            {
               AV11Messages = AV8LeaveRequest.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19LeaveRequestHolidaysDeleted", AV19LeaveRequestHolidaysDeleted);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_942( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11Messages", AV11Messages);
      }

      protected void E163O2( )
      {
         AV35GXV16 = (int)(nGXsfl_94_idx+GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage);
         if ( ( AV35GXV16 > 0 ) && ( AV8LeaveRequest.gxTpr_Holidays.Count >= AV35GXV16 ) )
         {
            AV8LeaveRequest.gxTpr_Holidays.CurrentItem = ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16));
         }
         /* Deletegridlinegridlevel_holidays_Click Routine */
         returnInSub = false;
         AV18Index = (short)(AV8LeaveRequest.gxTpr_Holidays.IndexOf(AV8LeaveRequest.gxTpr_Holidays.CurrentItem));
         if ( AV19LeaveRequestHolidaysDeleted.IndexOf(AV18Index) > 0 )
         {
            AV19LeaveRequestHolidaysDeleted.RemoveItem(AV19LeaveRequestHolidaysDeleted.IndexOf(AV18Index));
         }
         else
         {
            AV19LeaveRequestHolidaysDeleted.Add(AV18Index, 0);
         }
         gxgrGridlevel_holidays_refresh( subGridlevel_holidays_Rows, AV12TrnMode, AV8LeaveRequest, AV19LeaveRequestHolidaysDeleted, AV8LeaveRequest.gxTpr_Leavetypevacationleave) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19LeaveRequestHolidaysDeleted", AV19LeaveRequestHolidaysDeleted);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) ) )
         {
            bttBtnaddgridlinegridlevel_holidays_Visible = 0;
            AssignProp("", false, bttBtnaddgridlinegridlevel_holidays_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaddgridlinegridlevel_holidays_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV40GXV21 = 1;
         while ( AV40GXV21 <= AV11Messages.Count )
         {
            AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV40GXV21));
            GX_msglist.addItem(AV10Message.gxTpr_Description);
            AV40GXV21 = (int)(AV40GXV21+1);
         }
      }

      protected void S142( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("leavedetailspopup",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV14CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
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
         PA3O2( ) ;
         WS3O2( ) ;
         WE3O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202471614174158", true, true);
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
         context.AddJavascriptSource("leavedetailspopup.js", "?202471614174158", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_942( )
      {
         edtavDeletegridlinegridlevel_holidays_Internalname = "vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS_"+sGXsfl_94_idx;
         edtavLeaverequest_holidays__holidayid_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYID_"+sGXsfl_94_idx;
         edtavLeaverequest_holidays__holidayname_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME_"+sGXsfl_94_idx;
         edtavLeaverequest_holidays__holidaystartdate_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE_"+sGXsfl_94_idx;
         chkavLeaverequest_holidays__isapplicable_Internalname = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE_"+sGXsfl_94_idx;
      }

      protected void SubsflControlProps_fel_942( )
      {
         edtavDeletegridlinegridlevel_holidays_Internalname = "vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS_"+sGXsfl_94_fel_idx;
         edtavLeaverequest_holidays__holidayid_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYID_"+sGXsfl_94_fel_idx;
         edtavLeaverequest_holidays__holidayname_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME_"+sGXsfl_94_fel_idx;
         edtavLeaverequest_holidays__holidaystartdate_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE_"+sGXsfl_94_fel_idx;
         chkavLeaverequest_holidays__isapplicable_Internalname = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE_"+sGXsfl_94_fel_idx;
      }

      protected void sendrow_942( )
      {
         SubsflControlProps_942( ) ;
         WB3O0( ) ;
         if ( ( subGridlevel_holidays_Rows * 1 == 0 ) || ( nGXsfl_94_idx <= subGridlevel_holidays_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_94_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_94_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDeletegridlinegridlevel_holidays_Enabled!=0)&&(edtavDeletegridlinegridlevel_holidays_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 95,'',false,'"+sGXsfl_94_idx+"',94)\"" : " ");
            ROClassString = edtavDeletegridlinegridlevel_holidays_Class;
            Gridlevel_holidaysRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeletegridlinegridlevel_holidays_Internalname,StringUtil.RTrim( AV9DeleteGridLineGridLevel_Holidays),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDeletegridlinegridlevel_holidays_Enabled!=0)&&(edtavDeletegridlinegridlevel_holidays_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,95);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVDELETEGRIDLINEGRIDLEVEL_HOLIDAYS.CLICK."+sGXsfl_94_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDeletegridlinegridlevel_holidays_Jsonclick,(short)5,(string)edtavDeletegridlinegridlevel_holidays_Class,(string)"",(string)ROClassString,(string)edtavDeletegridlinegridlevel_holidays_Columnclass,(string)edtavDeletegridlinegridlevel_holidays_Columnheaderclass,(short)-1,(int)edtavDeletegridlinegridlevel_holidays_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)94,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavLeaverequest_holidays__holidayid_Enabled!=0)&&(edtavLeaverequest_holidays__holidayid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 96,'',false,'"+sGXsfl_94_idx+"',94)\"" : " ");
            ROClassString = "Attribute";
            Gridlevel_holidaysRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLeaverequest_holidays__holidayid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16)).gxTpr_Holidayid), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16)).gxTpr_Holidayid), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavLeaverequest_holidays__holidayid_Enabled!=0)&&(edtavLeaverequest_holidays__holidayid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,96);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLeaverequest_holidays__holidayid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavLeaverequest_holidays__holidayid_Columnclass,(string)edtavLeaverequest_holidays__holidayid_Columnheaderclass,(short)-1,(int)edtavLeaverequest_holidays__holidayid_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridlevel_holidaysRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLeaverequest_holidays__holidayname_Internalname,StringUtil.RTrim( ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16)).gxTpr_Holidayname),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLeaverequest_holidays__holidayname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavLeaverequest_holidays__holidayname_Columnclass,(string)edtavLeaverequest_holidays__holidayname_Columnheaderclass,(short)-1,(int)edtavLeaverequest_holidays__holidayname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridlevel_holidaysRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLeaverequest_holidays__holidaystartdate_Internalname,context.localUtil.Format(((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16)).gxTpr_Holidaystartdate, "99/99/99"),context.localUtil.Format( ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16)).gxTpr_Holidaystartdate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLeaverequest_holidays__holidaystartdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavLeaverequest_holidays__holidaystartdate_Columnclass,(string)edtavLeaverequest_holidays__holidaystartdate_Columnheaderclass,(short)-1,(int)edtavLeaverequest_holidays__holidaystartdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = " " + ((chkavLeaverequest_holidays__isapplicable.Enabled!=0)&&(chkavLeaverequest_holidays__isapplicable.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 99,'',false,'"+sGXsfl_94_idx+"',94)\"" : " ");
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE_" + sGXsfl_94_idx;
            chkavLeaverequest_holidays__isapplicable.Name = GXCCtl;
            chkavLeaverequest_holidays__isapplicable.WebTags = "";
            chkavLeaverequest_holidays__isapplicable.Caption = "";
            AssignProp("", false, chkavLeaverequest_holidays__isapplicable_Internalname, "TitleCaption", chkavLeaverequest_holidays__isapplicable.Caption, !bGXsfl_94_Refreshing);
            chkavLeaverequest_holidays__isapplicable.CheckedValue = "false";
            Gridlevel_holidaysRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavLeaverequest_holidays__isapplicable_Internalname,StringUtil.BoolToStr( ((SdtLeaveRequest_Holidays)AV8LeaveRequest.gxTpr_Holidays.Item(AV35GXV16)).gxTpr_Isapplicable),(string)"",(string)"",(short)-1,chkavLeaverequest_holidays__isapplicable.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)chkavLeaverequest_holidays__isapplicable_Columnclass,(string)chkavLeaverequest_holidays__isapplicable_Columnheaderclass,TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavLeaverequest_holidays__isapplicable.Enabled!=0)&&(chkavLeaverequest_holidays__isapplicable.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,99);\"" : " ")});
            send_integrity_lvl_hashes3O2( ) ;
            Gridlevel_holidaysContainer.AddRow(Gridlevel_holidaysRow);
            nGXsfl_94_idx = ((subGridlevel_holidays_Islastpage==1)&&(nGXsfl_94_idx+1>subGridlevel_holidays_fnc_Recordsperpage( )) ? 1 : nGXsfl_94_idx+1);
            sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
            SubsflControlProps_942( ) ;
         }
         /* End function sendrow_942 */
      }

      protected void init_web_controls( )
      {
         cmbavLeaverequest_leaverequeststatus.Name = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         cmbavLeaverequest_leaverequeststatus.WebTags = "";
         cmbavLeaverequest_leaverequeststatus.addItem("Pending", "Pending", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Approved", "Approved", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Rejected", "Rejected", 0);
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV8LeaveRequest.gxTpr_Leaverequeststatus);
         }
         radavLeaverequest_leavetypevacationleave.Name = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         radavLeaverequest_leavetypevacationleave.WebTags = "";
         radavLeaverequest_leavetypevacationleave.addItem("No", "No", 0);
         radavLeaverequest_leavetypevacationleave.addItem("Yes", "Yes", 0);
         GXCCtl = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE_" + sGXsfl_94_idx;
         chkavLeaverequest_holidays__isapplicable.Name = GXCCtl;
         chkavLeaverequest_holidays__isapplicable.WebTags = "";
         chkavLeaverequest_holidays__isapplicable.Caption = "";
         AssignProp("", false, chkavLeaverequest_holidays__isapplicable_Internalname, "TitleCaption", chkavLeaverequest_holidays__isapplicable.Caption, !bGXsfl_94_Refreshing);
         chkavLeaverequest_holidays__isapplicable.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl94( )
      {
         if ( Gridlevel_holidaysContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Gridlevel_holidaysContainer"+"DivS\" data-gxgridid=\"94\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDeletegridlinegridlevel_holidays_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Holiday Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Holiday Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Holiday Start Date") ;
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
            Gridlevel_holidaysColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV9DeleteGridLineGridLevel_Holidays)));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavDeletegridlinegridlevel_holidays_Columnclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavDeletegridlinegridlevel_holidays_Columnheaderclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDeletegridlinegridlevel_holidays_Class));
            Gridlevel_holidaysColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeletegridlinegridlevel_holidays_Enabled), 5, 0, ".", "")));
            Gridlevel_holidaysContainer.AddColumnProperties(Gridlevel_holidaysColumn);
            Gridlevel_holidaysColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavLeaverequest_holidays__holidayid_Columnclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavLeaverequest_holidays__holidayid_Columnheaderclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLeaverequest_holidays__holidayid_Enabled), 5, 0, ".", "")));
            Gridlevel_holidaysContainer.AddColumnProperties(Gridlevel_holidaysColumn);
            Gridlevel_holidaysColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavLeaverequest_holidays__holidayname_Columnclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavLeaverequest_holidays__holidayname_Columnheaderclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLeaverequest_holidays__holidayname_Enabled), 5, 0, ".", "")));
            Gridlevel_holidaysContainer.AddColumnProperties(Gridlevel_holidaysColumn);
            Gridlevel_holidaysColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavLeaverequest_holidays__holidaystartdate_Columnclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavLeaverequest_holidays__holidaystartdate_Columnheaderclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLeaverequest_holidays__holidaystartdate_Enabled), 5, 0, ".", "")));
            Gridlevel_holidaysContainer.AddColumnProperties(Gridlevel_holidaysColumn);
            Gridlevel_holidaysColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( chkavLeaverequest_holidays__isapplicable_Columnclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( chkavLeaverequest_holidays__isapplicable_Columnheaderclass));
            Gridlevel_holidaysColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavLeaverequest_holidays__isapplicable.Enabled), 5, 0, ".", "")));
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
         edtavLeaverequest_leaverequestid_Internalname = "LEAVEREQUEST_LEAVEREQUESTID";
         edtavLeaverequest_leavetypeid_Internalname = "LEAVEREQUEST_LEAVETYPEID";
         edtavLeaverequest_leavetypename_Internalname = "LEAVEREQUEST_LEAVETYPENAME";
         edtavLeaverequest_leaverequestdate_Internalname = "LEAVEREQUEST_LEAVEREQUESTDATE";
         edtavLeaverequest_leaverequeststartdate_Internalname = "LEAVEREQUEST_LEAVEREQUESTSTARTDATE";
         edtavLeaverequest_leaverequestenddate_Internalname = "LEAVEREQUEST_LEAVEREQUESTENDDATE";
         edtavLeaverequest_leaverequesthalfday_Internalname = "LEAVEREQUEST_LEAVEREQUESTHALFDAY";
         edtavLeaverequest_leaverequestduration_Internalname = "LEAVEREQUEST_LEAVEREQUESTDURATION";
         cmbavLeaverequest_leaverequeststatus_Internalname = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         edtavLeaverequest_leaverequestdescription_Internalname = "LEAVEREQUEST_LEAVEREQUESTDESCRIPTION";
         edtavLeaverequest_leaverequestrejectionreason_Internalname = "LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON";
         edtavLeaverequest_employeeid_Internalname = "LEAVEREQUEST_EMPLOYEEID";
         edtavLeaverequest_employeename_Internalname = "LEAVEREQUEST_EMPLOYEENAME";
         edtavLeaverequest_employeebalance_Internalname = "LEAVEREQUEST_EMPLOYEEBALANCE";
         radavLeaverequest_leavetypevacationleave_Internalname = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         edtavDeletegridlinegridlevel_holidays_Internalname = "vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS";
         edtavLeaverequest_holidays__holidayid_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYID";
         edtavLeaverequest_holidays__holidayname_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME";
         edtavLeaverequest_holidays__holidaystartdate_Internalname = "LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE";
         chkavLeaverequest_holidays__isapplicable_Internalname = "LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE";
         bttBtnaddgridlinegridlevel_holidays_Internalname = "BTNADDGRIDLINEGRIDLEVEL_HOLIDAYS";
         divTableleaflevel_holidays_Internalname = "TABLELEAFLEVEL_HOLIDAYS";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablecontent_Internalname = "TABLECONTENT";
         divRighttable_Internalname = "RIGHTTABLE";
         divMaintable_Internalname = "MAINTABLE";
         divTablemain_Internalname = "TABLEMAIN";
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
         chkavLeaverequest_holidays__isapplicable_Columnheaderclass = "";
         chkavLeaverequest_holidays__isapplicable_Columnclass = "WWColumn";
         chkavLeaverequest_holidays__isapplicable.Visible = -1;
         chkavLeaverequest_holidays__isapplicable.Enabled = 1;
         edtavLeaverequest_holidays__holidaystartdate_Jsonclick = "";
         edtavLeaverequest_holidays__holidaystartdate_Columnheaderclass = "";
         edtavLeaverequest_holidays__holidaystartdate_Columnclass = "WWColumn";
         edtavLeaverequest_holidays__holidaystartdate_Enabled = 0;
         edtavLeaverequest_holidays__holidayname_Jsonclick = "";
         edtavLeaverequest_holidays__holidayname_Columnheaderclass = "";
         edtavLeaverequest_holidays__holidayname_Columnclass = "WWColumn";
         edtavLeaverequest_holidays__holidayname_Enabled = 0;
         edtavLeaverequest_holidays__holidayid_Jsonclick = "";
         edtavLeaverequest_holidays__holidayid_Columnheaderclass = "";
         edtavLeaverequest_holidays__holidayid_Columnclass = "WWColumn";
         edtavLeaverequest_holidays__holidayid_Visible = -1;
         edtavLeaverequest_holidays__holidayid_Enabled = 1;
         edtavDeletegridlinegridlevel_holidays_Jsonclick = "";
         edtavDeletegridlinegridlevel_holidays_Columnclass = "WWIconActionColumn";
         edtavDeletegridlinegridlevel_holidays_Class = "Attribute";
         edtavDeletegridlinegridlevel_holidays_Visible = -1;
         edtavDeletegridlinegridlevel_holidays_Enabled = 1;
         subGridlevel_holidays_Class = "WorkWith";
         subGridlevel_holidays_Backcolorstyle = 0;
         edtavDeletegridlinegridlevel_holidays_Columnheaderclass = "";
         edtavLeaverequest_employeeid_Enabled = 1;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 1;
         edtavLeaverequest_leaverequestdescription_Enabled = 1;
         cmbavLeaverequest_leaverequeststatus.Enabled = 1;
         edtavLeaverequest_leaverequestduration_Enabled = 1;
         edtavLeaverequest_leaverequesthalfday_Enabled = 1;
         edtavLeaverequest_leaverequestenddate_Enabled = 1;
         edtavLeaverequest_leaverequeststartdate_Enabled = 1;
         edtavLeaverequest_leaverequestdate_Enabled = 1;
         edtavLeaverequest_leavetypeid_Enabled = 1;
         edtavLeaverequest_holidays__holidaystartdate_Enabled = -1;
         edtavLeaverequest_holidays__holidayname_Enabled = -1;
         edtavLeaverequest_employeebalance_Enabled = -1;
         edtavLeaverequest_employeename_Enabled = -1;
         edtavLeaverequest_leavetypename_Enabled = -1;
         edtavLeaverequest_leaverequestid_Enabled = -1;
         bttBtnaddgridlinegridlevel_holidays_Visible = 1;
         radavLeaverequest_leavetypevacationleave_Jsonclick = "";
         radavLeaverequest_leavetypevacationleave.Enabled = 1;
         edtavLeaverequest_employeebalance_Jsonclick = "";
         edtavLeaverequest_employeebalance_Enabled = 0;
         edtavLeaverequest_employeename_Jsonclick = "";
         edtavLeaverequest_employeename_Enabled = 0;
         edtavLeaverequest_employeeid_Jsonclick = "";
         edtavLeaverequest_employeeid_Enabled = 1;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 1;
         edtavLeaverequest_leaverequestdescription_Enabled = 1;
         cmbavLeaverequest_leaverequeststatus_Jsonclick = "";
         cmbavLeaverequest_leaverequeststatus.Enabled = 1;
         edtavLeaverequest_leaverequestduration_Jsonclick = "";
         edtavLeaverequest_leaverequestduration_Enabled = 1;
         edtavLeaverequest_leaverequesthalfday_Jsonclick = "";
         edtavLeaverequest_leaverequesthalfday_Enabled = 1;
         edtavLeaverequest_leaverequestenddate_Jsonclick = "";
         edtavLeaverequest_leaverequestenddate_Enabled = 1;
         edtavLeaverequest_leaverequeststartdate_Jsonclick = "";
         edtavLeaverequest_leaverequeststartdate_Enabled = 1;
         edtavLeaverequest_leaverequestdate_Jsonclick = "";
         edtavLeaverequest_leaverequestdate_Enabled = 1;
         edtavLeaverequest_leavetypename_Jsonclick = "";
         edtavLeaverequest_leavetypename_Enabled = 0;
         edtavLeaverequest_leavetypeid_Jsonclick = "";
         edtavLeaverequest_leavetypeid_Enabled = 1;
         edtavLeaverequest_leaverequestid_Jsonclick = "";
         edtavLeaverequest_leaverequestid_Enabled = 0;
         divTablecontent_Width = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Leave Details Popup";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV15',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavDeletegridlinegridlevel_holidays_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYID',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE',prop:'Columnheaderclass'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS.LOAD","{handler:'E153O2',iparms:[{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS.LOAD",",oparms:[{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYID',prop:'Enabled'},{ctrl:'LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE',prop:'Enabled'},{av:'AV9DeleteGridLineGridLevel_Holidays',fld:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',pic:''},{av:'edtavDeletegridlinegridlevel_holidays_Class',ctrl:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Class'},{av:'edtavDeletegridlinegridlevel_holidays_Columnclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Columnclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYID',prop:'Columnclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME',prop:'Columnclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE',prop:'Columnclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE',prop:'Columnclass'}]}");
         setEventMetadata("'DOADDGRIDLINEGRIDLEVEL_HOLIDAYS'","{handler:'E113O2',iparms:[{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV15',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true}]");
         setEventMetadata("'DOADDGRIDLINEGRIDLEVEL_HOLIDAYS'",",oparms:[{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94}]}");
         setEventMetadata("ENTER","{handler:'E123O2',iparms:[{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV14CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'AV11Messages',fld:'vMESSAGES',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV15',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV11Messages',fld:'vMESSAGES',pic:''},{av:'AV14CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''}]}");
         setEventMetadata("VDELETEGRIDLINEGRIDLEVEL_HOLIDAYS.CLICK","{handler:'E163O2',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV15',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("VDELETEGRIDLINEGRIDLEVEL_HOLIDAYS.CLICK",",oparms:[{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'edtavDeletegridlinegridlevel_holidays_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYID',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE',prop:'Columnheaderclass'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_FIRSTPAGE","{handler:'subgridlevel_holidays_firstpage',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV15',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_FIRSTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_holidays_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYID',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE',prop:'Columnheaderclass'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_PREVPAGE","{handler:'subgridlevel_holidays_previouspage',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV15',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_PREVPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_holidays_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYID',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE',prop:'Columnheaderclass'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_NEXTPAGE","{handler:'subgridlevel_holidays_nextpage',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV15',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_NEXTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_holidays_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYID',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE',prop:'Columnheaderclass'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_LASTPAGE","{handler:'subgridlevel_holidays_lastpage',iparms:[{av:'GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage'},{av:'GRIDLEVEL_HOLIDAYS_nEOF'},{av:'subGridlevel_holidays_Rows',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'Rows'},{av:'AV8LeaveRequest',fld:'vLEAVEREQUEST',pic:''},{av:'nRC_GXsfl_94',ctrl:'GRIDLEVEL_HOLIDAYS',prop:'GridRC',grid:94},{av:'AV19LeaveRequestHolidaysDeleted',fld:'vLEAVEREQUESTHOLIDAYSDELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true},{av:'radavLeaverequest_leavetypevacationleave'},{av:'GXV15',fld:'LEAVEREQUEST_LEAVETYPEVACATIONLEAVE',pic:''}]");
         setEventMetadata("GRIDLEVEL_HOLIDAYS_LASTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_holidays_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYID',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYNAME',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__HOLIDAYSTARTDATE',prop:'Columnheaderclass'},{ctrl:'LEAVEREQUEST_HOLIDAYS__ISAPPLICABLE',prop:'Columnheaderclass'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_HOLIDAYS',prop:'Visible'}]}");
         setEventMetadata("VALIDV_GXV9","{handler:'Validv_Gxv9',iparms:[]");
         setEventMetadata("VALIDV_GXV9",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv20',iparms:[]");
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
         AV12TrnMode = "";
         AV8LeaveRequest = new SdtLeaveRequest(context);
         AV19LeaveRequestHolidaysDeleted = new GxSimpleCollection<short>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Gridlevel_holidays_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         Gridlevel_holidaysContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtnaddgridlinegridlevel_holidays_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucGridlevel_holidays_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9DeleteGridLineGridLevel_Holidays = "";
         Gridlevel_holidaysRow = new GXWebRow();
         AV17LeaveRequestHolidaysItem = new SdtLeaveRequest_Holidays(context);
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridlevel_holidays_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Gridlevel_holidaysColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leavedetailspopup__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavedetailspopup__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavLeaverequest_leaverequestid_Enabled = 0;
         edtavLeaverequest_leavetypename_Enabled = 0;
         edtavLeaverequest_employeename_Enabled = 0;
         edtavLeaverequest_employeebalance_Enabled = 0;
         radavLeaverequest_leavetypevacationleave.Enabled = 0;
         edtavDeletegridlinegridlevel_holidays_Enabled = 0;
         edtavLeaverequest_holidays__holidayname_Enabled = 0;
         edtavLeaverequest_holidays__holidaystartdate_Enabled = 0;
      }

      private short GRIDLEVEL_HOLIDAYS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridlevel_holidays_Backcolorstyle ;
      private short AV18Index ;
      private short nGXWrapped ;
      private short subGridlevel_holidays_Backstyle ;
      private short subGridlevel_holidays_Titlebackstyle ;
      private short subGridlevel_holidays_Allowselection ;
      private short subGridlevel_holidays_Allowhovering ;
      private short subGridlevel_holidays_Allowcollapsing ;
      private short subGridlevel_holidays_Collapsed ;
      private int nRC_GXsfl_94 ;
      private int subGridlevel_holidays_Rows ;
      private int nGXsfl_94_idx=1 ;
      private int divTablecontent_Width ;
      private int edtavLeaverequest_leaverequestid_Enabled ;
      private int edtavLeaverequest_leavetypeid_Enabled ;
      private int edtavLeaverequest_leavetypename_Enabled ;
      private int edtavLeaverequest_leaverequestdate_Enabled ;
      private int edtavLeaverequest_leaverequeststartdate_Enabled ;
      private int edtavLeaverequest_leaverequestenddate_Enabled ;
      private int edtavLeaverequest_leaverequesthalfday_Enabled ;
      private int edtavLeaverequest_leaverequestduration_Enabled ;
      private int edtavLeaverequest_leaverequestdescription_Enabled ;
      private int edtavLeaverequest_leaverequestrejectionreason_Enabled ;
      private int edtavLeaverequest_employeeid_Enabled ;
      private int edtavLeaverequest_employeename_Enabled ;
      private int edtavLeaverequest_employeebalance_Enabled ;
      private int AV35GXV16 ;
      private int bttBtnaddgridlinegridlevel_holidays_Visible ;
      private int subGridlevel_holidays_Islastpage ;
      private int edtavDeletegridlinegridlevel_holidays_Enabled ;
      private int edtavLeaverequest_holidays__holidayname_Enabled ;
      private int edtavLeaverequest_holidays__holidaystartdate_Enabled ;
      private int GRIDLEVEL_HOLIDAYS_nGridOutOfScope ;
      private int nGXsfl_94_fel_idx=1 ;
      private int edtavLeaverequest_holidays__holidayid_Enabled ;
      private int nGXsfl_94_bak_idx=1 ;
      private int AV40GXV21 ;
      private int idxLst ;
      private int subGridlevel_holidays_Backcolor ;
      private int subGridlevel_holidays_Allbackcolor ;
      private int edtavDeletegridlinegridlevel_holidays_Visible ;
      private int edtavLeaverequest_holidays__holidayid_Visible ;
      private int subGridlevel_holidays_Titlebackcolor ;
      private int subGridlevel_holidays_Selectedindex ;
      private int subGridlevel_holidays_Selectioncolor ;
      private int subGridlevel_holidays_Hoveringcolor ;
      private long GRIDLEVEL_HOLIDAYS_nFirstRecordOnPage ;
      private long GRIDLEVEL_HOLIDAYS_nCurrentRecord ;
      private long GRIDLEVEL_HOLIDAYS_nRecordCount ;
      private long AV16LeaveRequestId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_94_idx="0001" ;
      private string AV12TrnMode ;
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
      private string edtavLeaverequest_leaverequestid_Internalname ;
      private string edtavLeaverequest_leaverequestid_Jsonclick ;
      private string edtavLeaverequest_leavetypeid_Internalname ;
      private string TempTags ;
      private string edtavLeaverequest_leavetypeid_Jsonclick ;
      private string edtavLeaverequest_leavetypename_Internalname ;
      private string edtavLeaverequest_leavetypename_Jsonclick ;
      private string edtavLeaverequest_leaverequestdate_Internalname ;
      private string edtavLeaverequest_leaverequestdate_Jsonclick ;
      private string edtavLeaverequest_leaverequeststartdate_Internalname ;
      private string edtavLeaverequest_leaverequeststartdate_Jsonclick ;
      private string edtavLeaverequest_leaverequestenddate_Internalname ;
      private string edtavLeaverequest_leaverequestenddate_Jsonclick ;
      private string edtavLeaverequest_leaverequesthalfday_Internalname ;
      private string edtavLeaverequest_leaverequesthalfday_Jsonclick ;
      private string edtavLeaverequest_leaverequestduration_Internalname ;
      private string edtavLeaverequest_leaverequestduration_Jsonclick ;
      private string cmbavLeaverequest_leaverequeststatus_Internalname ;
      private string cmbavLeaverequest_leaverequeststatus_Jsonclick ;
      private string edtavLeaverequest_leaverequestdescription_Internalname ;
      private string edtavLeaverequest_leaverequestrejectionreason_Internalname ;
      private string edtavLeaverequest_employeeid_Internalname ;
      private string edtavLeaverequest_employeeid_Jsonclick ;
      private string edtavLeaverequest_employeename_Internalname ;
      private string edtavLeaverequest_employeename_Jsonclick ;
      private string edtavLeaverequest_employeebalance_Internalname ;
      private string edtavLeaverequest_employeebalance_Jsonclick ;
      private string radavLeaverequest_leavetypevacationleave_Internalname ;
      private string radavLeaverequest_leavetypevacationleave_Jsonclick ;
      private string divTableleaflevel_holidays_Internalname ;
      private string sStyleString ;
      private string subGridlevel_holidays_Internalname ;
      private string bttBtnaddgridlinegridlevel_holidays_Internalname ;
      private string bttBtnaddgridlinegridlevel_holidays_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Gridlevel_holidays_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV9DeleteGridLineGridLevel_Holidays ;
      private string edtavDeletegridlinegridlevel_holidays_Internalname ;
      private string edtavLeaverequest_holidays__holidayname_Internalname ;
      private string edtavLeaverequest_holidays__holidaystartdate_Internalname ;
      private string sGXsfl_94_fel_idx="0001" ;
      private string edtavDeletegridlinegridlevel_holidays_Columnheaderclass ;
      private string edtavLeaverequest_holidays__holidayid_Columnheaderclass ;
      private string edtavLeaverequest_holidays__holidayid_Internalname ;
      private string edtavLeaverequest_holidays__holidayname_Columnheaderclass ;
      private string edtavLeaverequest_holidays__holidaystartdate_Columnheaderclass ;
      private string chkavLeaverequest_holidays__isapplicable_Columnheaderclass ;
      private string chkavLeaverequest_holidays__isapplicable_Internalname ;
      private string edtavDeletegridlinegridlevel_holidays_Class ;
      private string edtavDeletegridlinegridlevel_holidays_Columnclass ;
      private string edtavLeaverequest_holidays__holidayid_Columnclass ;
      private string edtavLeaverequest_holidays__holidayname_Columnclass ;
      private string edtavLeaverequest_holidays__holidaystartdate_Columnclass ;
      private string chkavLeaverequest_holidays__isapplicable_Columnclass ;
      private string subGridlevel_holidays_Class ;
      private string subGridlevel_holidays_Linesclass ;
      private string ROClassString ;
      private string edtavDeletegridlinegridlevel_holidays_Jsonclick ;
      private string edtavLeaverequest_holidays__holidayid_Jsonclick ;
      private string edtavLeaverequest_holidays__holidayname_Jsonclick ;
      private string edtavLeaverequest_holidays__holidaystartdate_Jsonclick ;
      private string GXCCtl ;
      private string subGridlevel_holidays_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_94_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV13LoadSuccess ;
      private bool gx_BV94 ;
      private bool gx_refresh_fired ;
      private bool AV15LineDeleted ;
      private GxSimpleCollection<short> AV19LeaveRequestHolidaysDeleted ;
      private GXWebGrid Gridlevel_holidaysContainer ;
      private GXWebRow Gridlevel_holidaysRow ;
      private GXWebColumn Gridlevel_holidaysColumn ;
      private GXUserControl ucGridlevel_holidays_empowerer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavLeaverequest_leaverequeststatus ;
      private GXRadio radavLeaverequest_leavetypevacationleave ;
      private GXCheckbox chkavLeaverequest_holidays__isapplicable ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GXWebForm Form ;
      private SdtLeaveRequest AV8LeaveRequest ;
      private SdtLeaveRequest_Holidays AV17LeaveRequestHolidaysItem ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
   }

   public class leavedetailspopup__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leavedetailspopup__default : DataStoreHelperBase, IDataStoreHelper
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
