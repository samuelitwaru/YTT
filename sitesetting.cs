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
   public class sitesetting : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A100CompanyId) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_6-177934", 0) ;
            }
         }
         Form.Meta.addItem("description", "Site Setting", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSiteSettingId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sitesetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sitesetting( IGxContext context )
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
         chkIsLogHourOpen = new GXCheckbox();
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
            return "sitesetting_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         A161IsLogHourOpen = StringUtil.StrToBool( StringUtil.BoolToStr( A161IsLogHourOpen));
         AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Site Setting", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSiteSettingId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSiteSettingId_Internalname, "Setting Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSiteSettingId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A160SiteSettingId), 10, 0, ".", "")), StringUtil.LTrim( ((edtSiteSettingId_Enabled!=0) ? context.localUtil.Format( (decimal)(A160SiteSettingId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A160SiteSettingId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSiteSettingId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSiteSettingId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCompanyId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCompanyId_Internalname, "Company Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")), StringUtil.LTrim( ((edtCompanyId_Enabled!=0) ? context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCompanyId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkIsLogHourOpen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkIsLogHourOpen_Internalname, "Hour Open", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkIsLogHourOpen_Internalname, StringUtil.BoolToStr( A161IsLogHourOpen), "", "Hour Open", 1, chkIsLogHourOpen.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z160SiteSettingId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z160SiteSettingId"), ".", ","), 18, MidpointRounding.ToEven));
            Z161IsLogHourOpen = StringUtil.StrToBool( cgiGet( "Z161IsLogHourOpen"));
            Z100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSiteSettingId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSiteSettingId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SITESETTINGID");
               AnyError = 1;
               GX_FocusControl = edtSiteSettingId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A160SiteSettingId = 0;
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
            }
            else
            {
               A160SiteSettingId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSiteSettingId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMPANYID");
               AnyError = 1;
               GX_FocusControl = edtCompanyId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A100CompanyId = 0;
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            }
            else
            {
               A100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            }
            A161IsLogHourOpen = StringUtil.StrToBool( cgiGet( chkIsLogHourOpen_Internalname));
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A160SiteSettingId = (long)(Math.Round(NumberUtil.Val( GetPar( "SiteSettingId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0N25( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0N25( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption0N0( )
      {
      }

      protected void ZM0N25( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z161IsLogHourOpen = T000N3_A161IsLogHourOpen[0];
               Z100CompanyId = T000N3_A100CompanyId[0];
            }
            else
            {
               Z161IsLogHourOpen = A161IsLogHourOpen;
               Z100CompanyId = A100CompanyId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z160SiteSettingId = A160SiteSettingId;
            Z161IsLogHourOpen = A161IsLogHourOpen;
            Z100CompanyId = A100CompanyId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A161IsLogHourOpen) && ( Gx_BScreen == 0 ) )
         {
            A161IsLogHourOpen = false;
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0N25( )
      {
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
            A161IsLogHourOpen = T000N5_A161IsLogHourOpen[0];
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
            A100CompanyId = T000N5_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            ZM0N25( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0N25( ) ;
      }

      protected void OnLoadActions0N25( )
      {
      }

      protected void CheckExtendedTable0N25( )
      {
         nIsDirty_25 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000N4 */
         pr_default.execute(2, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0N25( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A100CompanyId )
      {
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0N25( )
      {
         /* Using cursor T000N7 */
         pr_default.execute(5, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N25( 2) ;
            RcdFound25 = 1;
            A160SiteSettingId = T000N3_A160SiteSettingId[0];
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
            A161IsLogHourOpen = T000N3_A161IsLogHourOpen[0];
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
            A100CompanyId = T000N3_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            Z160SiteSettingId = A160SiteSettingId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0N25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0N25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0N25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound25 = 0;
         /* Using cursor T000N8 */
         pr_default.execute(6, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A160SiteSettingId[0] < A160SiteSettingId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A160SiteSettingId[0] > A160SiteSettingId ) ) )
            {
               A160SiteSettingId = T000N8_A160SiteSettingId[0];
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000N9 */
         pr_default.execute(7, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000N9_A160SiteSettingId[0] > A160SiteSettingId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000N9_A160SiteSettingId[0] < A160SiteSettingId ) ) )
            {
               A160SiteSettingId = T000N9_A160SiteSettingId[0];
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSiteSettingId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0N25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A160SiteSettingId != Z160SiteSettingId )
               {
                  A160SiteSettingId = Z160SiteSettingId;
                  AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SITESETTINGID");
                  AnyError = 1;
                  GX_FocusControl = edtSiteSettingId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSiteSettingId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0N25( ) ;
                  GX_FocusControl = edtSiteSettingId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A160SiteSettingId != Z160SiteSettingId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSiteSettingId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0N25( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SITESETTINGID");
                     AnyError = 1;
                     GX_FocusControl = edtSiteSettingId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSiteSettingId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0N25( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A160SiteSettingId != Z160SiteSettingId )
         {
            A160SiteSettingId = Z160SiteSettingId;
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SITESETTINGID");
            AnyError = 1;
            GX_FocusControl = edtSiteSettingId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSiteSettingId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SITESETTINGID");
            AnyError = 1;
            GX_FocusControl = edtSiteSettingId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCompanyId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0N25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCompanyId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N25( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCompanyId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCompanyId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0N25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound25 != 0 )
            {
               ScanNext0N25( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCompanyId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N25( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0N25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {A160SiteSettingId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SiteSetting"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z161IsLogHourOpen != T000N2_A161IsLogHourOpen[0] ) || ( Z100CompanyId != T000N2_A100CompanyId[0] ) )
            {
               if ( Z161IsLogHourOpen != T000N2_A161IsLogHourOpen[0] )
               {
                  GXUtil.WriteLog("sitesetting:[seudo value changed for attri]"+"IsLogHourOpen");
                  GXUtil.WriteLogRaw("Old: ",Z161IsLogHourOpen);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A161IsLogHourOpen[0]);
               }
               if ( Z100CompanyId != T000N2_A100CompanyId[0] )
               {
                  GXUtil.WriteLog("sitesetting:[seudo value changed for attri]"+"CompanyId");
                  GXUtil.WriteLogRaw("Old: ",Z100CompanyId);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A100CompanyId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SiteSetting"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N25( )
      {
         if ( ! IsAuthorized("sitesetting_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N25( 0) ;
            CheckOptimisticConcurrency0N25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N10 */
                     pr_default.execute(8, new Object[] {A161IsLogHourOpen, A100CompanyId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000N11 */
                     pr_default.execute(9);
                     A160SiteSettingId = T000N11_A160SiteSettingId[0];
                     AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SiteSetting");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0N0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0N25( ) ;
            }
            EndLevel0N25( ) ;
         }
         CloseExtendedTableCursors0N25( ) ;
      }

      protected void Update0N25( )
      {
         if ( ! IsAuthorized("sitesetting_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N12 */
                     pr_default.execute(10, new Object[] {A161IsLogHourOpen, A100CompanyId, A160SiteSettingId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SiteSetting");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SiteSetting"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N25( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0N0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0N25( ) ;
         }
         CloseExtendedTableCursors0N25( ) ;
      }

      protected void DeferredUpdate0N25( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("sitesetting_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N25( ) ;
            AfterConfirm0N25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N13 */
                  pr_default.execute(11, new Object[] {A160SiteSettingId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SiteSetting");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound25 == 0 )
                        {
                           InitAll0N25( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0N0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N25( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0N25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("sitesetting",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("sitesetting",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N25( )
      {
         /* Using cursor T000N14 */
         pr_default.execute(12);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound25 = 1;
            A160SiteSettingId = T000N14_A160SiteSettingId[0];
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N25( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound25 = 1;
            A160SiteSettingId = T000N14_A160SiteSettingId[0];
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
         }
      }

      protected void ScanEnd0N25( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0N25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N25( )
      {
         edtSiteSettingId_Enabled = 0;
         AssignProp("", false, edtSiteSettingId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSiteSettingId_Enabled), 5, 0), true);
         edtCompanyId_Enabled = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
         chkIsLogHourOpen.Enabled = 0;
         AssignProp("", false, chkIsLogHourOpen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkIsLogHourOpen.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0N25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0N0( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sitesetting.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z160SiteSettingId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z160SiteSettingId), 10, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z161IsLogHourOpen", Z161IsLogHourOpen);
         GxWebStd.gx_hidden_field( context, "Z100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("sitesetting.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SiteSetting" ;
      }

      public override string GetPgmdesc( )
      {
         return "Site Setting" ;
      }

      protected void InitializeNonKey0N25( )
      {
         A100CompanyId = 0;
         AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         A161IsLogHourOpen = false;
         AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
         Z161IsLogHourOpen = false;
         Z100CompanyId = 0;
      }

      protected void InitAll0N25( )
      {
         A160SiteSettingId = 0;
         AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
         InitializeNonKey0N25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A161IsLogHourOpen = i161IsLogHourOpen;
         AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20245191563394", true, true);
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
         context.AddJavascriptSource("sitesetting.js", "?20245191563394", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtSiteSettingId_Internalname = "SITESETTINGID";
         edtCompanyId_Internalname = "COMPANYID";
         chkIsLogHourOpen_Internalname = "ISLOGHOUROPEN";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Site Setting";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkIsLogHourOpen.Enabled = 1;
         edtCompanyId_Jsonclick = "";
         edtCompanyId_Enabled = 1;
         edtSiteSettingId_Jsonclick = "";
         edtSiteSettingId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         chkIsLogHourOpen.Name = "ISLOGHOUROPEN";
         chkIsLogHourOpen.WebTags = "";
         chkIsLogHourOpen.Caption = "";
         AssignProp("", false, chkIsLogHourOpen_Internalname, "TitleCaption", chkIsLogHourOpen.Caption, true);
         chkIsLogHourOpen.CheckedValue = "false";
         if ( IsIns( ) && (false==A161IsLogHourOpen) )
         {
            A161IsLogHourOpen = false;
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCompanyId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Sitesettingid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A161IsLogHourOpen = StringUtil.StrToBool( StringUtil.BoolToStr( A161IsLogHourOpen));
         /*  Sending validation outputs */
         AssignAttri("", false, "A100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
         AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z160SiteSettingId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z160SiteSettingId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z161IsLogHourOpen", StringUtil.BoolToStr( Z161IsLogHourOpen));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Companyid( )
      {
         /* Using cursor T000N15 */
         pr_default.execute(13, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A161IsLogHourOpen',fld:'ISLOGHOUROPEN',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A161IsLogHourOpen',fld:'ISLOGHOUROPEN',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A161IsLogHourOpen',fld:'ISLOGHOUROPEN',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A161IsLogHourOpen',fld:'ISLOGHOUROPEN',pic:''}]}");
         setEventMetadata("VALID_SITESETTINGID","{handler:'Valid_Sitesettingid',iparms:[{av:'A160SiteSettingId',fld:'SITESETTINGID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A161IsLogHourOpen',fld:'ISLOGHOUROPEN',pic:''}]");
         setEventMetadata("VALID_SITESETTINGID",",oparms:[{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z160SiteSettingId'},{av:'Z100CompanyId'},{av:'Z161IsLogHourOpen'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A161IsLogHourOpen',fld:'ISLOGHOUROPEN',pic:''}]}");
         setEventMetadata("VALID_COMPANYID","{handler:'Valid_Companyid',iparms:[{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A161IsLogHourOpen',fld:'ISLOGHOUROPEN',pic:''}]");
         setEventMetadata("VALID_COMPANYID",",oparms:[{av:'A161IsLogHourOpen',fld:'ISLOGHOUROPEN',pic:''}]}");
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
         pr_default.close(1);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T000N5_A160SiteSettingId = new long[1] ;
         T000N5_A161IsLogHourOpen = new bool[] {false} ;
         T000N5_A100CompanyId = new long[1] ;
         T000N4_A100CompanyId = new long[1] ;
         T000N6_A100CompanyId = new long[1] ;
         T000N7_A160SiteSettingId = new long[1] ;
         T000N3_A160SiteSettingId = new long[1] ;
         T000N3_A161IsLogHourOpen = new bool[] {false} ;
         T000N3_A100CompanyId = new long[1] ;
         sMode25 = "";
         T000N8_A160SiteSettingId = new long[1] ;
         T000N9_A160SiteSettingId = new long[1] ;
         T000N2_A160SiteSettingId = new long[1] ;
         T000N2_A161IsLogHourOpen = new bool[] {false} ;
         T000N2_A100CompanyId = new long[1] ;
         T000N11_A160SiteSettingId = new long[1] ;
         T000N14_A160SiteSettingId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000N15_A100CompanyId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.sitesetting__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sitesetting__default(),
            new Object[][] {
                new Object[] {
               T000N2_A160SiteSettingId, T000N2_A161IsLogHourOpen, T000N2_A100CompanyId
               }
               , new Object[] {
               T000N3_A160SiteSettingId, T000N3_A161IsLogHourOpen, T000N3_A100CompanyId
               }
               , new Object[] {
               T000N4_A100CompanyId
               }
               , new Object[] {
               T000N5_A160SiteSettingId, T000N5_A161IsLogHourOpen, T000N5_A100CompanyId
               }
               , new Object[] {
               T000N6_A100CompanyId
               }
               , new Object[] {
               T000N7_A160SiteSettingId
               }
               , new Object[] {
               T000N8_A160SiteSettingId
               }
               , new Object[] {
               T000N9_A160SiteSettingId
               }
               , new Object[] {
               }
               , new Object[] {
               T000N11_A160SiteSettingId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N14_A160SiteSettingId
               }
               , new Object[] {
               T000N15_A100CompanyId
               }
            }
         );
         Z161IsLogHourOpen = false;
         A161IsLogHourOpen = false;
         i161IsLogHourOpen = false;
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound25 ;
      private short nIsDirty_25 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSiteSettingId_Enabled ;
      private int edtCompanyId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z160SiteSettingId ;
      private long Z100CompanyId ;
      private long A100CompanyId ;
      private long A160SiteSettingId ;
      private long ZZ160SiteSettingId ;
      private long ZZ100CompanyId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSiteSettingId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtSiteSettingId_Jsonclick ;
      private string edtCompanyId_Internalname ;
      private string edtCompanyId_Jsonclick ;
      private string chkIsLogHourOpen_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode25 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z161IsLogHourOpen ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A161IsLogHourOpen ;
      private bool i161IsLogHourOpen ;
      private bool ZZ161IsLogHourOpen ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkIsLogHourOpen ;
      private IDataStoreProvider pr_default ;
      private long[] T000N5_A160SiteSettingId ;
      private bool[] T000N5_A161IsLogHourOpen ;
      private long[] T000N5_A100CompanyId ;
      private long[] T000N4_A100CompanyId ;
      private long[] T000N6_A100CompanyId ;
      private long[] T000N7_A160SiteSettingId ;
      private long[] T000N3_A160SiteSettingId ;
      private bool[] T000N3_A161IsLogHourOpen ;
      private long[] T000N3_A100CompanyId ;
      private long[] T000N8_A160SiteSettingId ;
      private long[] T000N9_A160SiteSettingId ;
      private long[] T000N2_A160SiteSettingId ;
      private bool[] T000N2_A161IsLogHourOpen ;
      private long[] T000N2_A100CompanyId ;
      private long[] T000N11_A160SiteSettingId ;
      private long[] T000N14_A160SiteSettingId ;
      private long[] T000N15_A100CompanyId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class sitesetting__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class sitesetting__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000N5;
        prmT000N5 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N4;
        prmT000N4 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000N6;
        prmT000N6 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000N7;
        prmT000N7 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N3;
        prmT000N3 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N8;
        prmT000N8 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N9;
        prmT000N9 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N2;
        prmT000N2 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N10;
        prmT000N10 = new Object[] {
        new ParDef("IsLogHourOpen",GXType.Boolean,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000N11;
        prmT000N11 = new Object[] {
        };
        Object[] prmT000N12;
        prmT000N12 = new Object[] {
        new ParDef("IsLogHourOpen",GXType.Boolean,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N13;
        prmT000N13 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N14;
        prmT000N14 = new Object[] {
        };
        Object[] prmT000N15;
        prmT000N15 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000N2", "SELECT SiteSettingId, IsLogHourOpen, CompanyId FROM SiteSetting WHERE SiteSettingId = :SiteSettingId  FOR UPDATE OF SiteSetting NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N3", "SELECT SiteSettingId, IsLogHourOpen, CompanyId FROM SiteSetting WHERE SiteSettingId = :SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N4", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N5", "SELECT TM1.SiteSettingId, TM1.IsLogHourOpen, TM1.CompanyId FROM SiteSetting TM1 WHERE TM1.SiteSettingId = :SiteSettingId ORDER BY TM1.SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N6", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N7", "SELECT SiteSettingId FROM SiteSetting WHERE SiteSettingId = :SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N8", "SELECT SiteSettingId FROM SiteSetting WHERE ( SiteSettingId > :SiteSettingId) ORDER BY SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N9", "SELECT SiteSettingId FROM SiteSetting WHERE ( SiteSettingId < :SiteSettingId) ORDER BY SiteSettingId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N10", "SAVEPOINT gxupdate;INSERT INTO SiteSetting(IsLogHourOpen, CompanyId) VALUES(:IsLogHourOpen, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N10)
           ,new CursorDef("T000N11", "SELECT currval('SiteSettingId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N12", "SAVEPOINT gxupdate;UPDATE SiteSetting SET IsLogHourOpen=:IsLogHourOpen, CompanyId=:CompanyId  WHERE SiteSettingId = :SiteSettingId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N12)
           ,new CursorDef("T000N13", "SAVEPOINT gxupdate;DELETE FROM SiteSetting  WHERE SiteSettingId = :SiteSettingId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N13)
           ,new CursorDef("T000N14", "SELECT SiteSettingId FROM SiteSetting ORDER BY SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N15", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N15,1, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
