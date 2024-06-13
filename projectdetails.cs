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
   public class projectdetails : GXDataArea
   {
      public projectdetails( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public projectdetails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_OneProjectId )
      {
         this.AV22OneProjectId = aP0_OneProjectId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "OneProjectId");
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
               gxfirstwebparm = GetFirstPar( "OneProjectId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "OneProjectId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegrid1") == 0 )
            {
               gxnrFreestylegrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegrid1") == 0 )
            {
               gxgrFreestylegrid1_refresh_invoke( ) ;
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
               AV22OneProjectId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22OneProjectId", StringUtil.LTrimStr( (decimal)(AV22OneProjectId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vONEPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22OneProjectId), "ZZZ9"), context));
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

      protected void gxnrFreestylegrid1_newrow_invoke( )
      {
         nRC_GXsfl_20 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_20"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_20_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_20_idx = GetPar( "sGXsfl_20_idx");
         edtEmployeeName_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_20_Refreshing);
         edtEmployeeId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), !bGXsfl_20_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegrid1_newrow( ) ;
         /* End function gxnrFreestylegrid1_newrow_invoke */
      }

      protected void gxgrFreestylegrid1_refresh_invoke( )
      {
         AV22OneProjectId = (short)(Math.Round(NumberUtil.Val( GetPar( "OneProjectId"), "."), 18, MidpointRounding.ToEven));
         edtEmployeeName_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_20_Refreshing);
         edtEmployeeId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), !bGXsfl_20_Refreshing);
         AV15FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV16ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid1_refresh( AV22OneProjectId, AV15FromDate, AV16ToDate) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid1_refresh_invoke */
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
            return GAMSecurityLevel.SecurityLow ;
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
         PA4Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4Y2( ) ;
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("projectdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV22OneProjectId,4,0))}, new string[] {"OneProjectId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vONEPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22OneProjectId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vONEPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22OneProjectId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vFROMDATE", context.localUtil.DToC( AV15FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTODATE", context.localUtil.DToC( AV16ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vONEPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22OneProjectId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vONEPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22OneProjectId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vDATERANGE", context.localUtil.DToC( AV21DateRange, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGE_TO", context.localUtil.DToC( AV26DateRange_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID", AV14ProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID", AV14ProjectId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID", AV12CompanyLocationId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID", AV12CompanyLocationId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID", AV13EmployeeId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID", AV13EmployeeId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vINPROJECTID", AV32InProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vINPROJECTID", AV32InProjectId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vINEMPLOYEEID", AV31InEmployeeId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vINEMPLOYEEID", AV31InEmployeeId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vINCOMPANYLOCATIONID", AV30InCompanyLocationId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vINCOMPANYLOCATIONID", AV30InCompanyLocationId);
         }
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Name", StringUtil.RTrim( Innewwindow1_Name));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "EMPLOYEENAME_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeId_Visible), 5, 0, ".", "")));
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
         if ( ! ( WebComp_Wcreportsworkhourlogdetails == null ) )
         {
            WebComp_Wcreportsworkhourlogdetails.componentjscripts();
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
            WE4Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4Y2( ) ;
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
         return formatLink("projectdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV22OneProjectId,4,0))}, new string[] {"OneProjectId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ProjectDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return "Project Details" ;
      }

      protected void WB4Y0( )
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "btn-group";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportexcel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");", "Export", bttBtnexportexcel_Jsonclick, 5, "Export", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProjectDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            StartGridControl20( ) ;
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
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
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Freestylegrid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4Y2( )
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
         Form.Meta.addItem("description", "Project Details", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4Y0( ) ;
      }

      protected void WS4Y2( )
      {
         START4Y2( ) ;
         EVT4Y2( ) ;
      }

      protected void EVT4Y2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportExcel' */
                              E114Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.REPORTSFILTERCHANAGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124Y2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOEXPORTSELF'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "'DOEXPORTPARENT'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'DOEXPORTTOP'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_202( ) ;
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E134Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E144Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTSELF'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExportSelf' */
                                    E154Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTPARENT'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExportParent' */
                                    E164Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTTOP'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExportTop' */
                                    E174Y2 ();
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
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 24 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0024" + sEvtType;
                           OldWcreportsworkhourlogdetails = cgiGet( sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcreportsworkhourlogdetails) == 0 ) || ( StringUtil.StrCmp(OldWcreportsworkhourlogdetails, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcreportsworkhourlogdetails, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcreportsworkhourlogdetails";
                              WebComp_GX_Process_Component = OldWcreportsworkhourlogdetails;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess("W0024", sEvtType, sEvt);
                           }
                           nGXsfl_20_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcreportsworkhourlogdetails";
                           WebComp_GX_Process_Component = OldWcreportsworkhourlogdetails;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4Y2( )
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

      protected void PA4Y2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFreestylegrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_202( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_202( ) ;
            nGXsfl_20_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_20_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid1Container)) ;
         /* End function gxnrFreestylegrid1_newrow */
      }

      protected void gxgrFreestylegrid1_refresh( short AV22OneProjectId ,
                                                 DateTime AV15FromDate ,
                                                 DateTime AV16ToDate )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID1_nCurrentRecord = 0;
         RF4Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFreestylegrid1_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid1Container.ClearRows();
         }
         wbStart = 20;
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         bGXsfl_20_Refreshing = true;
         Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         Freestylegrid1Container.AddObjectProperty("CmpContext", "");
         Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
         Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
         Freestylegrid1Container.PageSize = subFreestylegrid1_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
               {
                  WebComp_Wcreportsworkhourlogdetails.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_202( ) ;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A157CompanyLocationId ,
                                                 AV12CompanyLocationId ,
                                                 A106EmployeeId ,
                                                 AV13EmployeeId ,
                                                 AV12CompanyLocationId.Count ,
                                                 AV13EmployeeId.Count ,
                                                 AV15FromDate ,
                                                 AV16ToDate ,
                                                 A119WorkHourLogDate ,
                                                 A102ProjectId ,
                                                 AV22OneProjectId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H004Y2 */
            pr_default.execute(0, new Object[] {AV22OneProjectId, AV15FromDate, AV16ToDate});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A100CompanyId = H004Y2_A100CompanyId[0];
               A102ProjectId = H004Y2_A102ProjectId[0];
               A119WorkHourLogDate = H004Y2_A119WorkHourLogDate[0];
               A157CompanyLocationId = H004Y2_A157CompanyLocationId[0];
               A106EmployeeId = H004Y2_A106EmployeeId[0];
               A148EmployeeName = H004Y2_A148EmployeeName[0];
               A100CompanyId = H004Y2_A100CompanyId[0];
               A148EmployeeName = H004Y2_A148EmployeeName[0];
               A157CompanyLocationId = H004Y2_A157CompanyLocationId[0];
               E144Y2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 20;
            WB4Y0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4Y2( )
      {
      }

      protected int subFreestylegrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtEmployeeName_Enabled = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E134Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_20"), ".", ","), 18, MidpointRounding.ToEven));
            Innewwindow1_Name = cgiGet( "INNEWWINDOW1_Name");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            /* Read variables values. */
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
         E134Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E134Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSESSIONVARIABLES' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_int1 = AV17LoggedInEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV17LoggedInEmployeeId = GXt_int1;
         GXt_boolean2 = AV19IsManager;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean2) ;
         AV19IsManager = GXt_boolean2;
         edtEmployeeName_Visible = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_20_Refreshing);
         edtEmployeeId_Visible = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), !bGXsfl_20_Refreshing);
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E144Y2( )
      {
         /* Freestylegrid1_Load Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcreportsworkhourlogdetails = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcreportsworkhourlogdetails_Component), StringUtil.Lower( "ReportsWorkHourLogDetails")) != 0 )
         {
            WebComp_Wcreportsworkhourlogdetails = getWebComponent(GetType(), "GeneXus.Programs", "reportsworkhourlogdetails", new Object[] {context} );
            WebComp_Wcreportsworkhourlogdetails.ComponentInit();
            WebComp_Wcreportsworkhourlogdetails.Name = "ReportsWorkHourLogDetails";
            WebComp_Wcreportsworkhourlogdetails_Component = "ReportsWorkHourLogDetails";
         }
         if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
         {
            WebComp_Wcreportsworkhourlogdetails.setjustcreated();
            WebComp_Wcreportsworkhourlogdetails.componentprepare(new Object[] {(string)"W0024",(string)sGXsfl_20_idx,(long)A106EmployeeId,(string)A148EmployeeName,(DateTime)AV15FromDate,(DateTime)AV16ToDate,(short)AV22OneProjectId});
            WebComp_Wcreportsworkhourlogdetails.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 20;
         }
         sendrow_202( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
         {
            DoAjaxLoad(20, Freestylegrid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E114Y2( )
      {
         /* 'DoExportExcel' Routine */
         returnInSub = false;
         new exportdetailedreport(context ).execute( ref  AV21DateRange, ref  AV26DateRange_To, ref  AV14ProjectId, ref  AV12CompanyLocationId, ref  AV13EmployeeId, out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         AssignAttri("", false, "AV21DateRange", context.localUtil.Format(AV21DateRange, "99/99/99"));
         AssignAttri("", false, "AV26DateRange_To", context.localUtil.Format(AV26DateRange_To, "99/99/99"));
         Innewwindow1_Target = AV35ExcelFilename;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Name = "_parent";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Name", Innewwindow1_Name);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13EmployeeId", AV13EmployeeId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId", AV14ProjectId);
      }

      protected void E154Y2( )
      {
         /* 'DoExportSelf' Routine */
         returnInSub = false;
         new exportdetailedreport(context ).execute( ref  AV21DateRange, ref  AV26DateRange_To, ref  AV14ProjectId, ref  AV12CompanyLocationId, ref  AV13EmployeeId, out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         AssignAttri("", false, "AV21DateRange", context.localUtil.Format(AV21DateRange, "99/99/99"));
         AssignAttri("", false, "AV26DateRange_To", context.localUtil.Format(AV26DateRange_To, "99/99/99"));
         Innewwindow1_Target = AV35ExcelFilename;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Name = "_self";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Name", Innewwindow1_Name);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13EmployeeId", AV13EmployeeId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId", AV14ProjectId);
      }

      protected void E164Y2( )
      {
         /* 'DoExportParent' Routine */
         returnInSub = false;
         new exportdetailedreport(context ).execute( ref  AV21DateRange, ref  AV26DateRange_To, ref  AV14ProjectId, ref  AV12CompanyLocationId, ref  AV13EmployeeId, out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         AssignAttri("", false, "AV21DateRange", context.localUtil.Format(AV21DateRange, "99/99/99"));
         AssignAttri("", false, "AV26DateRange_To", context.localUtil.Format(AV26DateRange_To, "99/99/99"));
         Innewwindow1_Target = AV35ExcelFilename;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Name = "_parent";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Name", Innewwindow1_Name);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13EmployeeId", AV13EmployeeId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId", AV14ProjectId);
      }

      protected void E174Y2( )
      {
         /* 'DoExportTop' Routine */
         returnInSub = false;
         new exportdetailedreport(context ).execute( ref  AV21DateRange, ref  AV26DateRange_To, ref  AV14ProjectId, ref  AV12CompanyLocationId, ref  AV13EmployeeId, out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         AssignAttri("", false, "AV21DateRange", context.localUtil.Format(AV21DateRange, "99/99/99"));
         AssignAttri("", false, "AV26DateRange_To", context.localUtil.Format(AV26DateRange_To, "99/99/99"));
         Innewwindow1_Target = AV35ExcelFilename;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Name = "_top";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Name", Innewwindow1_Name);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13EmployeeId", AV13EmployeeId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId", AV14ProjectId);
      }

      protected void E124Y2( )
      {
         /* General\GlobalEvents_Reportsfilterchanaged Routine */
         returnInSub = false;
         AV21DateRange = AV15FromDate;
         AssignAttri("", false, "AV21DateRange", context.localUtil.Format(AV21DateRange, "99/99/99"));
         AV26DateRange_To = AV16ToDate;
         AssignAttri("", false, "AV26DateRange_To", context.localUtil.Format(AV26DateRange_To, "99/99/99"));
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         gxgrFreestylegrid1_refresh( AV22OneProjectId, AV15FromDate, AV16ToDate) ;
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'EMITGLOBALEVENT' Routine */
         returnInSub = false;
         if ( ( AV37View == Convert.ToDecimal( 2 )) )
         {
            this.executeExternalObjectMethod("", false, "GlobalEvents", "ReportsFilterChanaged", new Object[] {(GxSimpleCollection<long>)AV12CompanyLocationId,(GxSimpleCollection<long>)AV13EmployeeId,(GxSimpleCollection<long>)AV14ProjectId,(DateTime)AV21DateRange,(DateTime)AV26DateRange_To}, true);
         }
      }

      protected void S122( )
      {
         /* 'UPDATESESSIONVARIABLES' Routine */
         returnInSub = false;
         AV34WebSession.Set("CompanyLocationId", AV12CompanyLocationId.ToJSonString(false));
         AV34WebSession.Set("EmployeeId", AV13EmployeeId.ToJSonString(false));
         AV34WebSession.Set("OneProjectId", StringUtil.Str( (decimal)(AV22OneProjectId), 4, 0));
         AV34WebSession.Set("FromDate", context.localUtil.DToC( AV15FromDate, 1, "/"));
         AV34WebSession.Set("ToDate", context.localUtil.DToC( AV16ToDate, 1, "/"));
      }

      protected void S112( )
      {
         /* 'GETSESSIONVARIABLES' Routine */
         returnInSub = false;
         AV12CompanyLocationId.FromJSonString(AV34WebSession.Get("CompanyLocationId"), null);
         AV13EmployeeId.FromJSonString(AV34WebSession.Get("EmployeeId"), null);
         AV15FromDate = context.localUtil.CToD( AV34WebSession.Get("FromDate"), 1);
         AssignAttri("", false, "AV15FromDate", context.localUtil.Format(AV15FromDate, "99/99/99"));
         AV16ToDate = context.localUtil.CToD( AV34WebSession.Get("ToDate"), 1);
         AssignAttri("", false, "AV16ToDate", context.localUtil.Format(AV16ToDate, "99/99/99"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV22OneProjectId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV22OneProjectId", StringUtil.LTrimStr( (decimal)(AV22OneProjectId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vONEPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22OneProjectId), "ZZZ9"), context));
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
         PA4Y2( ) ;
         WS4Y2( ) ;
         WE4Y2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcreportsworkhourlogdetails == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
            {
               WebComp_Wcreportsworkhourlogdetails.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202461311235486", true, true);
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
         context.AddJavascriptSource("projectdetails.js", "?202461311235486", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_20_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_20_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         SubsflControlProps_202( ) ;
         WB4Y0( ) ;
         Freestylegrid1Row = GXWebRow.GetNew(context,Freestylegrid1Container);
         if ( subFreestylegrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            subFreestylegrid1_Backcolor = subFreestylegrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Uniform";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
            subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylegrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_20_idx) % (2))) == 0 )
            {
               subFreestylegrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Even";
               }
            }
            else
            {
               subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_20_idx+"\">") ;
         }
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFreestylegrid1layouttable_Internalname+"_"+sGXsfl_20_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, "W0024"+sGXsfl_20_idx, StringUtil.RTrim( WebComp_Wcreportsworkhourlogdetails_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+"gxHTMLWrpW0024"+sGXsfl_20_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_20_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( "W0024"+sGXsfl_20_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
                     {
                        WebComp_Wcreportsworkhourlogdetails.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcreportsworkhourlogdetails), StringUtil.Lower( WebComp_Wcreportsworkhourlogdetails_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0024"+sGXsfl_20_idx);
               }
               WebComp_Wcreportsworkhourlogdetails.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcreportsworkhourlogdetails), StringUtil.Lower( WebComp_Wcreportsworkhourlogdetails_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Wcreportsworkhourlogdetails_Component = "";
         WebComp_Wcreportsworkhourlogdetails.componentjscripts();
         Freestylegrid1Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcreportsworkhourlogdetails"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreestylegrid1_Internalname+"_"+sGXsfl_20_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,(string)"Employee Name",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtEmployeeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)128,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,(string)"Employee Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtEmployeeId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("table");
         }
         /* End of table */
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes4Y2( ) ;
         /* End of Columns property logic. */
         Freestylegrid1Container.AddRow(Freestylegrid1Row);
         nGXsfl_20_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_20_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         /* End function sendrow_202 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl20( )
      {
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"DivS\" data-gxgridid=\"20\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid1_Internalname, subFreestylegrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Freestylegrid1Container = new GXWebGrid( context);
            }
            else
            {
               Freestylegrid1Container.Clear();
            }
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
            Freestylegrid1Container.AddObjectProperty("Header", subFreestylegrid1_Header);
            Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("CmpContext", "");
            Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeId_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectedindex), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowselection), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectioncolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowhovering), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Hoveringcolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowcollapsing), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnexportexcel_Internalname = "BTNEXPORTEXCEL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         tblUnnamedtablecontentfsfreestylegrid1_Internalname = "UNNAMEDTABLECONTENTFSFREESTYLEGRID1";
         divFreestylegrid1layouttable_Internalname = "FREESTYLEGRID1LAYOUTTABLE";
         divTablecontent_Internalname = "TABLECONTENT";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFreestylegrid1_Internalname = "FREESTYLEGRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subFreestylegrid1_Allowcollapsing = 0;
         edtEmployeeId_Jsonclick = "";
         edtEmployeeName_Jsonclick = "";
         subFreestylegrid1_Class = "FreeStyleGrid";
         edtEmployeeId_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         subFreestylegrid1_Backcolorstyle = 0;
         Innewwindow1_Target = "";
         Innewwindow1_Name = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Project Details";
         edtEmployeeId_Visible = 1;
         edtEmployeeName_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'FREESTYLEGRID1_nFirstRecordOnPage'},{av:'FREESTYLEGRID1_nEOF'},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtEmployeeId_Visible',ctrl:'EMPLOYEEID',prop:'Visible'},{av:'AV15FromDate',fld:'vFROMDATE',pic:''},{av:'AV16ToDate',fld:'vTODATE',pic:''},{av:'AV22OneProjectId',fld:'vONEPROJECTID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("FREESTYLEGRID1.LOAD","{handler:'E144Y2',iparms:[{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'A148EmployeeName',fld:'EMPLOYEENAME',pic:''},{av:'AV15FromDate',fld:'vFROMDATE',pic:''},{av:'AV16ToDate',fld:'vTODATE',pic:''},{av:'AV22OneProjectId',fld:'vONEPROJECTID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("FREESTYLEGRID1.LOAD",",oparms:[{ctrl:'WCREPORTSWORKHOURLOGDETAILS'}]}");
         setEventMetadata("'DOEXPORTEXCEL'","{handler:'E114Y2',iparms:[{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV14ProjectId',fld:'vPROJECTID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''}]");
         setEventMetadata("'DOEXPORTEXCEL'",",oparms:[{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV14ProjectId',fld:'vPROJECTID',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Name',ctrl:'INNEWWINDOW1',prop:'Name'}]}");
         setEventMetadata("'DOEXPORTSELF'","{handler:'E154Y2',iparms:[{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV14ProjectId',fld:'vPROJECTID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''}]");
         setEventMetadata("'DOEXPORTSELF'",",oparms:[{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV14ProjectId',fld:'vPROJECTID',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Name',ctrl:'INNEWWINDOW1',prop:'Name'}]}");
         setEventMetadata("'DOEXPORTPARENT'","{handler:'E164Y2',iparms:[{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV14ProjectId',fld:'vPROJECTID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''}]");
         setEventMetadata("'DOEXPORTPARENT'",",oparms:[{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV14ProjectId',fld:'vPROJECTID',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Name',ctrl:'INNEWWINDOW1',prop:'Name'}]}");
         setEventMetadata("'DOEXPORTTOP'","{handler:'E174Y2',iparms:[{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV14ProjectId',fld:'vPROJECTID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''}]");
         setEventMetadata("'DOEXPORTTOP'",",oparms:[{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV14ProjectId',fld:'vPROJECTID',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''},{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Name',ctrl:'INNEWWINDOW1',prop:'Name'}]}");
         setEventMetadata("GLOBALEVENTS.REPORTSFILTERCHANAGED","{handler:'E124Y2',iparms:[{av:'FREESTYLEGRID1_nFirstRecordOnPage'},{av:'FREESTYLEGRID1_nEOF'},{av:'AV22OneProjectId',fld:'vONEPROJECTID',pic:'ZZZ9',hsh:true},{av:'edtEmployeeName_Visible',ctrl:'EMPLOYEENAME',prop:'Visible'},{av:'edtEmployeeId_Visible',ctrl:'EMPLOYEEID',prop:'Visible'},{av:'AV15FromDate',fld:'vFROMDATE',pic:''},{av:'AV16ToDate',fld:'vTODATE',pic:''},{av:'AV32InProjectId',fld:'vINPROJECTID',pic:''},{av:'AV31InEmployeeId',fld:'vINEMPLOYEEID',pic:''},{av:'AV30InCompanyLocationId',fld:'vINCOMPANYLOCATIONID',pic:''},{av:'AV12CompanyLocationId',fld:'vCOMPANYLOCATIONID',pic:''},{av:'AV13EmployeeId',fld:'vEMPLOYEEID',pic:''}]");
         setEventMetadata("GLOBALEVENTS.REPORTSFILTERCHANAGED",",oparms:[{av:'AV21DateRange',fld:'vDATERANGE',pic:''},{av:'AV26DateRange_To',fld:'vDATERANGE_TO',pic:''}]}");
         setEventMetadata("VALID_EMPLOYEEID","{handler:'Valid_Employeeid',iparms:[]");
         setEventMetadata("VALID_EMPLOYEEID",",oparms:[]}");
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
         AV15FromDate = DateTime.MinValue;
         AV16ToDate = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV21DateRange = DateTime.MinValue;
         AV26DateRange_To = DateTime.MinValue;
         AV14ProjectId = new GxSimpleCollection<long>();
         AV12CompanyLocationId = new GxSimpleCollection<long>();
         AV13EmployeeId = new GxSimpleCollection<long>();
         AV32InProjectId = new GxSimpleCollection<long>();
         AV31InEmployeeId = new GxSimpleCollection<long>();
         AV30InCompanyLocationId = new GxSimpleCollection<long>();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnexportexcel_Jsonclick = "";
         Freestylegrid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucInnewwindow1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A148EmployeeName = "";
         OldWcreportsworkhourlogdetails = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         WebComp_Wcreportsworkhourlogdetails_Component = "";
         scmdbuf = "";
         A119WorkHourLogDate = DateTime.MinValue;
         H004Y2_A100CompanyId = new long[1] ;
         H004Y2_A102ProjectId = new long[1] ;
         H004Y2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         H004Y2_A157CompanyLocationId = new long[1] ;
         H004Y2_A106EmployeeId = new long[1] ;
         H004Y2_A148EmployeeName = new string[] {""} ;
         Freestylegrid1Row = new GXWebRow();
         AV35ExcelFilename = "";
         AV36ErrorMessage = "";
         AV34WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreestylegrid1_Linesclass = "";
         ROClassString = "";
         subFreestylegrid1_Header = "";
         Freestylegrid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.projectdetails__default(),
            new Object[][] {
                new Object[] {
               H004Y2_A100CompanyId, H004Y2_A102ProjectId, H004Y2_A119WorkHourLogDate, H004Y2_A157CompanyLocationId, H004Y2_A106EmployeeId, H004Y2_A148EmployeeName
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcreportsworkhourlogdetails = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV22OneProjectId ;
      private short wcpOAV22OneProjectId ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subFreestylegrid1_Backcolorstyle ;
      private short FREESTYLEGRID1_nEOF ;
      private short nGXWrapped ;
      private short subFreestylegrid1_Backstyle ;
      private short subFreestylegrid1_Allowselection ;
      private short subFreestylegrid1_Allowhovering ;
      private short subFreestylegrid1_Allowcollapsing ;
      private short subFreestylegrid1_Collapsed ;
      private int edtEmployeeName_Visible ;
      private int edtEmployeeId_Visible ;
      private int nRC_GXsfl_20 ;
      private int nGXsfl_20_idx=1 ;
      private int nGXsfl_20_webc_idx=0 ;
      private int subFreestylegrid1_Islastpage ;
      private int AV12CompanyLocationId_Count ;
      private int AV13EmployeeId_Count ;
      private int edtEmployeeName_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int idxLst ;
      private int subFreestylegrid1_Backcolor ;
      private int subFreestylegrid1_Allbackcolor ;
      private int subFreestylegrid1_Selectedindex ;
      private int subFreestylegrid1_Selectioncolor ;
      private int subFreestylegrid1_Hoveringcolor ;
      private long A106EmployeeId ;
      private long FREESTYLEGRID1_nCurrentRecord ;
      private long A157CompanyLocationId ;
      private long A102ProjectId ;
      private long FREESTYLEGRID1_nFirstRecordOnPage ;
      private long A100CompanyId ;
      private long AV17LoggedInEmployeeId ;
      private long GXt_int1 ;
      private decimal AV37View ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_20_idx="0001" ;
      private string edtEmployeeName_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Innewwindow1_Name ;
      private string Innewwindow1_Target ;
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
      private string sStyleString ;
      private string subFreestylegrid1_Internalname ;
      private string Innewwindow1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A148EmployeeName ;
      private string OldWcreportsworkhourlogdetails ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string WebComp_Wcreportsworkhourlogdetails_Component ;
      private string scmdbuf ;
      private string sGXsfl_20_fel_idx="0001" ;
      private string subFreestylegrid1_Class ;
      private string subFreestylegrid1_Linesclass ;
      private string divFreestylegrid1layouttable_Internalname ;
      private string tblUnnamedtablecontentfsfreestylegrid1_Internalname ;
      private string ROClassString ;
      private string edtEmployeeName_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string subFreestylegrid1_Header ;
      private DateTime AV15FromDate ;
      private DateTime AV16ToDate ;
      private DateTime AV21DateRange ;
      private DateTime AV26DateRange_To ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19IsManager ;
      private bool GXt_boolean2 ;
      private bool bDynCreated_Wcreportsworkhourlogdetails ;
      private string AV35ExcelFilename ;
      private string AV36ErrorMessage ;
      private GxSimpleCollection<long> AV14ProjectId ;
      private GxSimpleCollection<long> AV12CompanyLocationId ;
      private GxSimpleCollection<long> AV13EmployeeId ;
      private GxSimpleCollection<long> AV32InProjectId ;
      private GxSimpleCollection<long> AV31InEmployeeId ;
      private GxSimpleCollection<long> AV30InCompanyLocationId ;
      private GXWebComponent WebComp_Wcreportsworkhourlogdetails ;
      private GXWebGrid Freestylegrid1Container ;
      private GXWebRow Freestylegrid1Row ;
      private GXWebColumn Freestylegrid1Column ;
      private GXUserControl ucInnewwindow1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private long[] H004Y2_A100CompanyId ;
      private long[] H004Y2_A102ProjectId ;
      private DateTime[] H004Y2_A119WorkHourLogDate ;
      private long[] H004Y2_A157CompanyLocationId ;
      private long[] H004Y2_A106EmployeeId ;
      private string[] H004Y2_A148EmployeeName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV34WebSession ;
      private GXWebForm Form ;
   }

   public class projectdetails__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004Y2( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV12CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV13EmployeeId ,
                                             int AV12CompanyLocationId_Count ,
                                             int AV13EmployeeId_Count ,
                                             DateTime AV15FromDate ,
                                             DateTime AV16ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             long A102ProjectId ,
                                             short AV22OneProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS CompanyId, NULL AS ProjectId, NULL AS WorkHourLogDate, NULL AS CompanyLocationId, EmployeeId, EmployeeName FROM ( SELECT T2.CompanyId, T1.ProjectId, T1.WorkHourLogDate, T3.CompanyLocationId, T1.EmployeeId, T2.EmployeeName FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId)";
         AddWhere(sWhereString, "(T1.ProjectId = :AV22OneProjectId)");
         if ( AV12CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12CompanyLocationId, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV13EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV15FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV15FromDate)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV16ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV16ToDate)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeName";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY EmployeeName";
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
                     return conditional_H004Y2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (short)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004Y2;
          prmH004Y2 = new Object[] {
          new ParDef("AV22OneProjectId",GXType.Int16,4,0) ,
          new ParDef("AV15FromDate",GXType.Date,8,0) ,
          new ParDef("AV16ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 128);
                return;
       }
    }

 }

}
