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
   public class employee : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action20") == 0 )
         {
            A109EmployeeEmail = GetPar( "EmployeeEmail");
            AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
            A107EmployeeFirstName = GetPar( "EmployeeFirstName");
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A108EmployeeLastName = GetPar( "EmployeeLastName");
            AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_20_0F16( A109EmployeeEmail, A107EmployeeFirstName, A108EmployeeLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action21") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_21_0F16( A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action22") == 0 )
         {
            A109EmployeeEmail = GetPar( "EmployeeEmail");
            AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_22_0F16( A109EmployeeEmail) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action23") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_23_0F16( A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel6"+"_"+"COMPANYID") == 0 )
         {
            AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "Insert_CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX6ASACOMPANYID0F16( AV13Insert_CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"") == 0 )
         {
            AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "Insert_CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXASA1000F16( AV13Insert_CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel11"+"_"+"EMPLOYEEBALANCE") == 0 )
         {
            A146EmployeeVactionDays = (short)(Math.Round(NumberUtil.Val( GetPar( "EmployeeVactionDays"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( (decimal)(A146EmployeeVactionDays), 4, 0));
            Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
            AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX11ASAEMPLOYEEBALANCE0F16( A146EmployeeVactionDays, Gx_BScreen, A106EmployeeId, Gx_date) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel35"+"_"+"") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXASA1000F16( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A100CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A102ProjectId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_project") == 0 )
         {
            gxnrGridlevel_project_newrow_invoke( ) ;
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7EmployeeId", StringUtil.LTrimStr( (decimal)(AV7EmployeeId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmployeeId), "ZZZZZZZZZ9"), context));
            }
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
         Form.Meta.addItem("description", "Employee", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmployeeFirstName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_project_newrow_invoke( )
      {
         nRC_GXsfl_55 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_55"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_55_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_55_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_55_idx = GetPar( "sGXsfl_55_idx");
         edtProjectId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtProjectId_Internalname, "Horizontalalignment", edtProjectId_Horizontalalignment, !bGXsfl_55_Refreshing);
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_project_newrow( ) ;
         /* End function gxnrGridlevel_project_newrow_invoke */
      }

      public employee( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employee( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_EmployeeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmployeeId = aP1_EmployeeId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynCompanyId = new GXCombobox();
         chkEmployeeIsManager = new GXCheckbox();
         chkEmployeeIsActive = new GXCheckbox();
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
            return "employee_Execute" ;
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
         if ( dynCompanyId.ItemCount > 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCompanyId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0));
            AssignProp("", false, dynCompanyId_Internalname, "Values", dynCompanyId.ToJavascriptSource(), true);
         }
         A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
         AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
         A112EmployeeIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A112EmployeeIsActive));
         AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeFirstName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeFirstName_Internalname, "First Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeFirstName_Internalname, StringUtil.RTrim( A107EmployeeFirstName), StringUtil.RTrim( context.localUtil.Format( A107EmployeeFirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeFirstName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeFirstName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeLastName_Internalname, "Last Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeLastName_Internalname, StringUtil.RTrim( A108EmployeeLastName), StringUtil.RTrim( context.localUtil.Format( A108EmployeeLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeEmail_Internalname, A109EmployeeEmail, StringUtil.RTrim( context.localUtil.Format( A109EmployeeEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A109EmployeeEmail, "", "", "", edtEmployeeEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeEmail_Enabled, 1, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeVactionDays_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeVactionDays_Internalname, "Vaction Days", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeVactionDays_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A146EmployeeVactionDays), 4, 0, ".", "")), StringUtil.LTrim( ((edtEmployeeVactionDays_Enabled!=0) ? context.localUtil.Format( (decimal)(A146EmployeeVactionDays), "ZZZ9") : context.localUtil.Format( (decimal)(A146EmployeeVactionDays), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeVactionDays_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeVactionDays_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynCompanyId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynCompanyId_Internalname, "Location", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynCompanyId, dynCompanyId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0)), 1, dynCompanyId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynCompanyId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "", true, 0, "HLP_Employee.htm");
         dynCompanyId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0));
         AssignProp("", false, dynCompanyId_Internalname, "Values", (string)(dynCompanyId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEmployeeIsManager_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEmployeeIsManager_Internalname, "Is Manager", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEmployeeIsManager_Internalname, StringUtil.BoolToStr( A110EmployeeIsManager), "", "Is Manager", 1, chkEmployeeIsManager.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEmployeeIsActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEmployeeIsActive_Internalname, "Is Active", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEmployeeIsActive_Internalname, StringUtil.BoolToStr( A112EmployeeIsActive), "", "Is Active", 1, chkEmployeeIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_project_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_project( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
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
         ucCombo_projectid.SetProperty("Caption", Combo_projectid_Caption);
         ucCombo_projectid.SetProperty("Cls", Combo_projectid_Cls);
         ucCombo_projectid.SetProperty("IsGridItem", Combo_projectid_Isgriditem);
         ucCombo_projectid.SetProperty("EmptyItem", Combo_projectid_Emptyitem);
         ucCombo_projectid.SetProperty("DropDownOptionsData", AV15ProjectId_Data);
         ucCombo_projectid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_projectid_Internalname, "COMBO_PROJECTIDContainer");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEmployeeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")), StringUtil.LTrim( ((edtEmployeeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeId_Visible, edtEmployeeId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Employee.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGAMUserGUID_Internalname, A111GAMUserGUID, StringUtil.RTrim( context.localUtil.Format( A111GAMUserGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGAMUserGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtGAMUserGUID_Visible, edtGAMUserGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Employee.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeBalance_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A147EmployeeBalance), 4, 0, ".", "")), StringUtil.LTrim( ((edtEmployeeBalance_Enabled!=0) ? context.localUtil.Format( (decimal)(A147EmployeeBalance), "ZZZ9") : context.localUtil.Format( (decimal)(A147EmployeeBalance), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeBalance_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeBalance_Visible, edtEmployeeBalance_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Employee.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeName_Internalname, StringUtil.RTrim( A148EmployeeName), StringUtil.RTrim( context.localUtil.Format( A148EmployeeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeName_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeName_Visible, edtEmployeeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_project( )
      {
         /*  Grid Control  */
         StartGridControl55( ) ;
         nGXsfl_55_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount28 = 1;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_28 = 1;
               ScanStart0F28( ) ;
               while ( RcdFound28 != 0 )
               {
                  init_level_properties28( ) ;
                  getByPrimaryKey0F28( ) ;
                  AddRow0F28( ) ;
                  ScanNext0F28( ) ;
               }
               ScanEnd0F28( ) ;
               nBlankRcdCount28 = 1;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0F28( ) ;
            standaloneModal0F28( ) ;
            sMode28 = Gx_mode;
            while ( nGXsfl_55_idx < nRC_GXsfl_55 )
            {
               bGXsfl_55_Refreshing = true;
               ReadRow0F28( ) ;
               edtProjectId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROJECTID_"+sGXsfl_55_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_55_Refreshing);
               edtProjectId_Horizontalalignment = cgiGet( "PROJECTID_"+sGXsfl_55_idx+"Horizontalalignment");
               AssignProp("", false, edtProjectId_Internalname, "Horizontalalignment", edtProjectId_Horizontalalignment, !bGXsfl_55_Refreshing);
               if ( ( nRcdExists_28 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0F28( ) ;
               }
               SendRow0F28( ) ;
               bGXsfl_55_Refreshing = false;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount28 = 1;
            nRcdExists_28 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0F28( ) ;
               while ( RcdFound28 != 0 )
               {
                  sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5528( ) ;
                  init_level_properties28( ) ;
                  standaloneNotModal0F28( ) ;
                  getByPrimaryKey0F28( ) ;
                  standaloneModal0F28( ) ;
                  AddRow0F28( ) ;
                  ScanNext0F28( ) ;
               }
               ScanEnd0F28( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode28 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5528( ) ;
            InitAll0F28( ) ;
            init_level_properties28( ) ;
            nRcdExists_28 = 0;
            nIsMod_28 = 0;
            nRcdDeleted_28 = 0;
            nBlankRcdCount28 = (short)(nBlankRcdUsr28+nBlankRcdCount28);
            fRowAdded = 0;
            while ( nBlankRcdCount28 > 0 )
            {
               standaloneNotModal0F28( ) ;
               standaloneModal0F28( ) ;
               AddRow0F28( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProjectId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount28 = (short)(nBlankRcdCount28-1);
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_projectContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_project", Gridlevel_projectContainer, subGridlevel_project_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_projectContainerData", Gridlevel_projectContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_projectContainerData"+"V", Gridlevel_projectContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_projectContainerData"+"V"+"\" value='"+Gridlevel_projectContainer.GridValuesHidden()+"'/>") ;
         }
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID_DATA"), AV15ProjectId_Data);
               /* Read saved values. */
               Z106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               Z148EmployeeName = cgiGet( "Z148EmployeeName");
               Z111GAMUserGUID = cgiGet( "Z111GAMUserGUID");
               Z147EmployeeBalance = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z147EmployeeBalance"), ".", ","), 18, MidpointRounding.ToEven));
               Z107EmployeeFirstName = cgiGet( "Z107EmployeeFirstName");
               Z108EmployeeLastName = cgiGet( "Z108EmployeeLastName");
               Z109EmployeeEmail = cgiGet( "Z109EmployeeEmail");
               Z110EmployeeIsManager = StringUtil.StrToBool( cgiGet( "Z110EmployeeIsManager"));
               Z112EmployeeIsActive = StringUtil.StrToBool( cgiGet( "Z112EmployeeIsActive"));
               Z146EmployeeVactionDays = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z146EmployeeVactionDays"), ".", ","), 18, MidpointRounding.ToEven));
               Z100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_55 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_55"), ".", ","), 18, MidpointRounding.ToEven));
               N100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_COMPANYID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               AV24Password = cgiGet( "vPASSWORD");
               A101CompanyName = cgiGet( "COMPANYNAME");
               AV32Pgmname = cgiGet( "vPGMNAME");
               A103ProjectName = cgiGet( "PROJECTNAME");
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_projectid_Objectcall = cgiGet( "COMBO_PROJECTID_Objectcall");
               Combo_projectid_Class = cgiGet( "COMBO_PROJECTID_Class");
               Combo_projectid_Icontype = cgiGet( "COMBO_PROJECTID_Icontype");
               Combo_projectid_Icon = cgiGet( "COMBO_PROJECTID_Icon");
               Combo_projectid_Caption = cgiGet( "COMBO_PROJECTID_Caption");
               Combo_projectid_Tooltip = cgiGet( "COMBO_PROJECTID_Tooltip");
               Combo_projectid_Cls = cgiGet( "COMBO_PROJECTID_Cls");
               Combo_projectid_Selectedvalue_set = cgiGet( "COMBO_PROJECTID_Selectedvalue_set");
               Combo_projectid_Selectedvalue_get = cgiGet( "COMBO_PROJECTID_Selectedvalue_get");
               Combo_projectid_Selectedtext_set = cgiGet( "COMBO_PROJECTID_Selectedtext_set");
               Combo_projectid_Selectedtext_get = cgiGet( "COMBO_PROJECTID_Selectedtext_get");
               Combo_projectid_Gamoauthtoken = cgiGet( "COMBO_PROJECTID_Gamoauthtoken");
               Combo_projectid_Ddointernalname = cgiGet( "COMBO_PROJECTID_Ddointernalname");
               Combo_projectid_Titlecontrolalign = cgiGet( "COMBO_PROJECTID_Titlecontrolalign");
               Combo_projectid_Dropdownoptionstype = cgiGet( "COMBO_PROJECTID_Dropdownoptionstype");
               Combo_projectid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Enabled"));
               Combo_projectid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Visible"));
               Combo_projectid_Titlecontrolidtoreplace = cgiGet( "COMBO_PROJECTID_Titlecontrolidtoreplace");
               Combo_projectid_Datalisttype = cgiGet( "COMBO_PROJECTID_Datalisttype");
               Combo_projectid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Allowmultipleselection"));
               Combo_projectid_Datalistfixedvalues = cgiGet( "COMBO_PROJECTID_Datalistfixedvalues");
               Combo_projectid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Isgriditem"));
               Combo_projectid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Hasdescription"));
               Combo_projectid_Datalistproc = cgiGet( "COMBO_PROJECTID_Datalistproc");
               Combo_projectid_Datalistprocparametersprefix = cgiGet( "COMBO_PROJECTID_Datalistprocparametersprefix");
               Combo_projectid_Remoteservicesparameters = cgiGet( "COMBO_PROJECTID_Remoteservicesparameters");
               Combo_projectid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROJECTID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_projectid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeonlyselectedoption"));
               Combo_projectid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeselectalloption"));
               Combo_projectid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Emptyitem"));
               Combo_projectid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeaddnewoption"));
               Combo_projectid_Htmltemplate = cgiGet( "COMBO_PROJECTID_Htmltemplate");
               Combo_projectid_Multiplevaluestype = cgiGet( "COMBO_PROJECTID_Multiplevaluestype");
               Combo_projectid_Loadingdata = cgiGet( "COMBO_PROJECTID_Loadingdata");
               Combo_projectid_Noresultsfound = cgiGet( "COMBO_PROJECTID_Noresultsfound");
               Combo_projectid_Emptyitemtext = cgiGet( "COMBO_PROJECTID_Emptyitemtext");
               Combo_projectid_Onlyselectedvalues = cgiGet( "COMBO_PROJECTID_Onlyselectedvalues");
               Combo_projectid_Selectalltext = cgiGet( "COMBO_PROJECTID_Selectalltext");
               Combo_projectid_Multiplevaluesseparator = cgiGet( "COMBO_PROJECTID_Multiplevaluesseparator");
               Combo_projectid_Addnewoptiontext = cgiGet( "COMBO_PROJECTID_Addnewoptiontext");
               Combo_projectid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROJECTID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
               AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
               A108EmployeeLastName = cgiGet( edtEmployeeLastName_Internalname);
               AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
               A109EmployeeEmail = cgiGet( edtEmployeeEmail_Internalname);
               AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEEVACTIONDAYS");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeVactionDays_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A146EmployeeVactionDays = 0;
                  AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( (decimal)(A146EmployeeVactionDays), 4, 0));
               }
               else
               {
                  A146EmployeeVactionDays = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( (decimal)(A146EmployeeVactionDays), 4, 0));
               }
               dynCompanyId.Name = dynCompanyId_Internalname;
               dynCompanyId.CurrentValue = cgiGet( dynCompanyId_Internalname);
               A100CompanyId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynCompanyId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               A110EmployeeIsManager = StringUtil.StrToBool( cgiGet( chkEmployeeIsManager_Internalname));
               AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
               A112EmployeeIsActive = StringUtil.StrToBool( cgiGet( chkEmployeeIsActive_Internalname));
               AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
               A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               A111GAMUserGUID = cgiGet( edtGAMUserGUID_Internalname);
               AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEEBALANCE");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeBalance_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A147EmployeeBalance = 0;
                  AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
               }
               else
               {
                  A147EmployeeBalance = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
               }
               A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
               AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Employee");
               A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               forbiddenHiddens.Add("EmployeeId", context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A106EmployeeId != Z106EmployeeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("employee:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode16 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode16;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound16 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "EMPLOYEEID");
                        AnyError = 1;
                        GX_FocusControl = edtEmployeeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            /* Execute user event: After Trn */
            E120F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0F16( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0F16( ) ;
         }
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F16( ) ;
            }
            else
            {
               CheckExtendedTable0F16( ) ;
               CloseExtendedTableCursors0F16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode16 = Gx_mode;
            CONFIRM_0F28( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode16;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0F28( )
      {
         nGXsfl_55_idx = 0;
         while ( nGXsfl_55_idx < nRC_GXsfl_55 )
         {
            ReadRow0F28( ) ;
            if ( ( nRcdExists_28 != 0 ) || ( nIsMod_28 != 0 ) )
            {
               GetKey0F28( ) ;
               if ( ( nRcdExists_28 == 0 ) && ( nRcdDeleted_28 == 0 ) )
               {
                  if ( RcdFound28 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0F28( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0F28( ) ;
                        CloseExtendedTableCursors0F28( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROJECTID_" + sGXsfl_55_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProjectId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound28 != 0 )
                  {
                     if ( nRcdDeleted_28 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0F28( ) ;
                        Load0F28( ) ;
                        BeforeValidate0F28( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0F28( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_28 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0F28( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0F28( ) ;
                              CloseExtendedTableCursors0F28( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_28 == 0 )
                     {
                        GXCCtl = "PROJECTID_" + sGXsfl_55_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProjectId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProjectId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z102ProjectId_"+sGXsfl_55_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102ProjectId), 10, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_28_"+sGXsfl_55_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_28), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_28_"+sGXsfl_55_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_28), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_28_"+sGXsfl_55_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_28), 4, 0, ".", ""))) ;
            if ( nIsMod_28 != 0 )
            {
               ChangePostValue( "PROJECTID_"+sGXsfl_55_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROJECTID_"+sGXsfl_55_idx+"Horizontalalignment", StringUtil.RTrim( edtProjectId_Horizontalalignment)) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void E110F2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         Combo_projectid_Titlecontrolidtoreplace = edtProjectId_Internalname;
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "TitleControlIdToReplace", Combo_projectid_Titlecontrolidtoreplace);
         edtProjectId_Horizontalalignment = "Left";
         AssignProp("", false, edtProjectId_Internalname, "Horizontalalignment", edtProjectId_Horizontalalignment, !bGXsfl_55_Refreshing);
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            while ( AV33GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CompanyId") == 0 )
               {
                  AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
               }
               AV33GXV1 = (int)(AV33GXV1+1);
               AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            }
         }
         edtEmployeeId_Visible = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), true);
         edtGAMUserGUID_Visible = 0;
         AssignProp("", false, edtGAMUserGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtGAMUserGUID_Visible), 5, 0), true);
         edtEmployeeBalance_Visible = 0;
         AssignProp("", false, edtEmployeeBalance_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Visible), 5, 0), true);
         edtEmployeeName_Visible = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), true);
      }

      protected void E120F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("employeeww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV15ProjectId_Data;
         new employeeloaddvcombo(context ).execute(  "ProjectId",  Gx_mode,  AV7EmployeeId, out  AV17ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV15ProjectId_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z148EmployeeName = T000F6_A148EmployeeName[0];
               Z111GAMUserGUID = T000F6_A111GAMUserGUID[0];
               Z147EmployeeBalance = T000F6_A147EmployeeBalance[0];
               Z107EmployeeFirstName = T000F6_A107EmployeeFirstName[0];
               Z108EmployeeLastName = T000F6_A108EmployeeLastName[0];
               Z109EmployeeEmail = T000F6_A109EmployeeEmail[0];
               Z110EmployeeIsManager = T000F6_A110EmployeeIsManager[0];
               Z112EmployeeIsActive = T000F6_A112EmployeeIsActive[0];
               Z146EmployeeVactionDays = T000F6_A146EmployeeVactionDays[0];
               Z100CompanyId = T000F6_A100CompanyId[0];
            }
            else
            {
               Z148EmployeeName = A148EmployeeName;
               Z111GAMUserGUID = A111GAMUserGUID;
               Z147EmployeeBalance = A147EmployeeBalance;
               Z107EmployeeFirstName = A107EmployeeFirstName;
               Z108EmployeeLastName = A108EmployeeLastName;
               Z109EmployeeEmail = A109EmployeeEmail;
               Z110EmployeeIsManager = A110EmployeeIsManager;
               Z112EmployeeIsActive = A112EmployeeIsActive;
               Z146EmployeeVactionDays = A146EmployeeVactionDays;
               Z100CompanyId = A100CompanyId;
            }
         }
         if ( GX_JID == -27 )
         {
            Z106EmployeeId = A106EmployeeId;
            Z148EmployeeName = A148EmployeeName;
            Z111GAMUserGUID = A111GAMUserGUID;
            Z147EmployeeBalance = A147EmployeeBalance;
            Z107EmployeeFirstName = A107EmployeeFirstName;
            Z108EmployeeLastName = A108EmployeeLastName;
            Z109EmployeeEmail = A109EmployeeEmail;
            Z110EmployeeIsManager = A110EmployeeIsManager;
            Z112EmployeeIsActive = A112EmployeeIsActive;
            Z146EmployeeVactionDays = A146EmployeeVactionDays;
            Z100CompanyId = A100CompanyId;
            Z101CompanyName = A101CompanyName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtEmployeeEmail_Enabled = 0;
            AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         }
         else
         {
            edtEmployeeEmail_Enabled = 1;
            AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         }
         AV32Pgmname = "Employee";
         AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            dynCompanyId.Enabled = 0;
            AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         }
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EmployeeId) )
         {
            A106EmployeeId = AV7EmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            dynCompanyId.Enabled = 0;
            AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         }
         else
         {
            GXt_boolean2 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean2) ;
            if ( GXt_boolean2 )
            {
               dynCompanyId.Enabled = 0;
               AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
            }
            else
            {
               dynCompanyId.Enabled = 1;
               AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
            }
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            chkEmployeeIsActive.Enabled = 0;
            AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         }
         else
         {
            chkEmployeeIsActive.Enabled = 1;
            AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            chkEmployeeIsActive.Enabled = 0;
            AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            A100CompanyId = AV13Insert_CompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         else
         {
            GXt_boolean2 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean2) ;
            if ( GXt_boolean2 )
            {
               GXt_int3 = A100CompanyId;
               new getloggedinusercompanyid(context ).execute( out  GXt_int3) ;
               A100CompanyId = GXt_int3;
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtEmployeeEmail_Enabled = 0;
            AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (false==A112EmployeeIsActive) && ( Gx_BScreen == 0 ) )
         {
            A112EmployeeIsActive = false;
            AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         }
         if ( IsIns( )  && (0==A146EmployeeVactionDays) && ( Gx_BScreen == 0 ) )
         {
            A146EmployeeVactionDays = 21;
            AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( (decimal)(A146EmployeeVactionDays), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000F7 */
            pr_default.execute(5, new Object[] {A100CompanyId});
            A101CompanyName = T000F7_A101CompanyName[0];
            pr_default.close(5);
         }
      }

      protected void Load0F16( )
      {
         /* Using cursor T000F8 */
         pr_default.execute(6, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound16 = 1;
            A148EmployeeName = T000F8_A148EmployeeName[0];
            AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
            A111GAMUserGUID = T000F8_A111GAMUserGUID[0];
            AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
            A147EmployeeBalance = T000F8_A147EmployeeBalance[0];
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
            A107EmployeeFirstName = T000F8_A107EmployeeFirstName[0];
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A108EmployeeLastName = T000F8_A108EmployeeLastName[0];
            AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
            A109EmployeeEmail = T000F8_A109EmployeeEmail[0];
            AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
            A101CompanyName = T000F8_A101CompanyName[0];
            A110EmployeeIsManager = T000F8_A110EmployeeIsManager[0];
            AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
            A112EmployeeIsActive = T000F8_A112EmployeeIsActive[0];
            AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
            A146EmployeeVactionDays = T000F8_A146EmployeeVactionDays[0];
            AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( (decimal)(A146EmployeeVactionDays), 4, 0));
            A100CompanyId = T000F8_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            ZM0F16( -27) ;
         }
         pr_default.close(6);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
         A148EmployeeName = A107EmployeeFirstName + " " + A108EmployeeLastName;
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         if ( IsIns( )  && (0==A147EmployeeBalance) && ( Gx_BScreen == 0 ) )
         {
            A147EmployeeBalance = A146EmployeeVactionDays;
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
         }
         else
         {
            if ( ( DateTimeUtil.Month( DateTimeUtil.Now( context)) == 1 ) && ( DateTimeUtil.Day( DateTimeUtil.Now( context)) == 1 ) && IsIns( )  )
            {
               A147EmployeeBalance = A146EmployeeVactionDays;
               AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  GXt_int4 = A147EmployeeBalance;
                  new getemployeeapprovedvacationdays(context ).execute(  A106EmployeeId,  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 1, 1),  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 12, 31), out  GXt_int4) ;
                  A147EmployeeBalance = (short)(A146EmployeeVactionDays-GXt_int4);
                  AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
               }
            }
         }
      }

      protected void CheckExtendedTable0F16( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000F9 */
         pr_default.execute(7, new Object[] {A109EmployeeEmail, A106EmployeeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Employee Email"}), 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         nIsDirty_16 = 1;
         A148EmployeeName = A107EmployeeFirstName + " " + A108EmployeeLastName;
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A107EmployeeFirstName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee First Name", "", "", "", "", "", "", "", ""), 1, "EMPLOYEEFIRSTNAME");
            AnyError = 1;
            GX_FocusControl = edtEmployeeFirstName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A108EmployeeLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Last Name", "", "", "", "", "", "", "", ""), 1, "EMPLOYEELASTNAME");
            AnyError = 1;
            GX_FocusControl = edtEmployeeLastName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A109EmployeeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Employee Email does not match the specified pattern", "OutOfRange", 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Email", "", "", "", "", "", "", "", ""), 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Work hours/minutes are required",  "error",  "#"+edtEmployeeEmail_Internalname,  "true",  ""), 0, "EMPLOYEEEMAIL");
         }
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A101CompanyName = T000F7_A101CompanyName[0];
         pr_default.close(5);
         if ( (0==A100CompanyId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Company Id", "", "", "", "", "", "", "", ""), 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  && (0==A147EmployeeBalance) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_16 = 1;
            A147EmployeeBalance = A146EmployeeVactionDays;
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
         }
         else
         {
            if ( ( DateTimeUtil.Month( DateTimeUtil.Now( context)) == 1 ) && ( DateTimeUtil.Day( DateTimeUtil.Now( context)) == 1 ) && IsIns( )  )
            {
               nIsDirty_16 = 1;
               A147EmployeeBalance = A146EmployeeVactionDays;
               AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  nIsDirty_16 = 1;
                  GXt_int4 = A147EmployeeBalance;
                  new getemployeeapprovedvacationdays(context ).execute(  A106EmployeeId,  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 1, 1),  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 12, 31), out  GXt_int4) ;
                  A147EmployeeBalance = (short)(A146EmployeeVactionDays-GXt_int4);
                  AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors0F16( )
      {
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_29( long A100CompanyId )
      {
         /* Using cursor T000F10 */
         pr_default.execute(8, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A101CompanyName = T000F10_A101CompanyName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A101CompanyName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0F16( )
      {
         /* Using cursor T000F11 */
         pr_default.execute(9, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0F16( 27) ;
            RcdFound16 = 1;
            A106EmployeeId = T000F6_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            A148EmployeeName = T000F6_A148EmployeeName[0];
            AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
            A111GAMUserGUID = T000F6_A111GAMUserGUID[0];
            AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
            A147EmployeeBalance = T000F6_A147EmployeeBalance[0];
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
            A107EmployeeFirstName = T000F6_A107EmployeeFirstName[0];
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A108EmployeeLastName = T000F6_A108EmployeeLastName[0];
            AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
            A109EmployeeEmail = T000F6_A109EmployeeEmail[0];
            AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
            A110EmployeeIsManager = T000F6_A110EmployeeIsManager[0];
            AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
            A112EmployeeIsActive = T000F6_A112EmployeeIsActive[0];
            AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
            A146EmployeeVactionDays = T000F6_A146EmployeeVactionDays[0];
            AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( (decimal)(A146EmployeeVactionDays), 4, 0));
            A100CompanyId = T000F6_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            Z106EmployeeId = A106EmployeeId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0F16( ) ;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F16( ) ;
         if ( RcdFound16 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound16 = 0;
         /* Using cursor T000F12 */
         pr_default.execute(10, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000F12_A106EmployeeId[0] < A106EmployeeId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000F12_A106EmployeeId[0] > A106EmployeeId ) ) )
            {
               A106EmployeeId = T000F12_A106EmployeeId[0];
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound16 = 0;
         /* Using cursor T000F13 */
         pr_default.execute(11, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000F13_A106EmployeeId[0] > A106EmployeeId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000F13_A106EmployeeId[0] < A106EmployeeId ) ) )
            {
               A106EmployeeId = T000F13_A106EmployeeId[0];
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmployeeFirstName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F16( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A106EmployeeId != Z106EmployeeId )
               {
                  A106EmployeeId = Z106EmployeeId;
                  AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPLOYEEID");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmployeeFirstName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0F16( ) ;
                  GX_FocusControl = edtEmployeeFirstName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A106EmployeeId != Z106EmployeeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEmployeeFirstName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F16( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPLOYEEID");
                     AnyError = 1;
                     GX_FocusControl = edtEmployeeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEmployeeFirstName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F16( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A106EmployeeId != Z106EmployeeId )
         {
            A106EmployeeId = Z106EmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmployeeFirstName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F5 */
            pr_default.execute(3, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z148EmployeeName, T000F5_A148EmployeeName[0]) != 0 ) || ( StringUtil.StrCmp(Z111GAMUserGUID, T000F5_A111GAMUserGUID[0]) != 0 ) || ( Z147EmployeeBalance != T000F5_A147EmployeeBalance[0] ) || ( StringUtil.StrCmp(Z107EmployeeFirstName, T000F5_A107EmployeeFirstName[0]) != 0 ) || ( StringUtil.StrCmp(Z108EmployeeLastName, T000F5_A108EmployeeLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z109EmployeeEmail, T000F5_A109EmployeeEmail[0]) != 0 ) || ( Z110EmployeeIsManager != T000F5_A110EmployeeIsManager[0] ) || ( Z112EmployeeIsActive != T000F5_A112EmployeeIsActive[0] ) || ( Z146EmployeeVactionDays != T000F5_A146EmployeeVactionDays[0] ) || ( Z100CompanyId != T000F5_A100CompanyId[0] ) )
            {
               if ( StringUtil.StrCmp(Z148EmployeeName, T000F5_A148EmployeeName[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeName");
                  GXUtil.WriteLogRaw("Old: ",Z148EmployeeName);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A148EmployeeName[0]);
               }
               if ( StringUtil.StrCmp(Z111GAMUserGUID, T000F5_A111GAMUserGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"GAMUserGUID");
                  GXUtil.WriteLogRaw("Old: ",Z111GAMUserGUID);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A111GAMUserGUID[0]);
               }
               if ( Z147EmployeeBalance != T000F5_A147EmployeeBalance[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeBalance");
                  GXUtil.WriteLogRaw("Old: ",Z147EmployeeBalance);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A147EmployeeBalance[0]);
               }
               if ( StringUtil.StrCmp(Z107EmployeeFirstName, T000F5_A107EmployeeFirstName[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeFirstName");
                  GXUtil.WriteLogRaw("Old: ",Z107EmployeeFirstName);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A107EmployeeFirstName[0]);
               }
               if ( StringUtil.StrCmp(Z108EmployeeLastName, T000F5_A108EmployeeLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeLastName");
                  GXUtil.WriteLogRaw("Old: ",Z108EmployeeLastName);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A108EmployeeLastName[0]);
               }
               if ( StringUtil.StrCmp(Z109EmployeeEmail, T000F5_A109EmployeeEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeEmail");
                  GXUtil.WriteLogRaw("Old: ",Z109EmployeeEmail);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A109EmployeeEmail[0]);
               }
               if ( Z110EmployeeIsManager != T000F5_A110EmployeeIsManager[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeIsManager");
                  GXUtil.WriteLogRaw("Old: ",Z110EmployeeIsManager);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A110EmployeeIsManager[0]);
               }
               if ( Z112EmployeeIsActive != T000F5_A112EmployeeIsActive[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeIsActive");
                  GXUtil.WriteLogRaw("Old: ",Z112EmployeeIsActive);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A112EmployeeIsActive[0]);
               }
               if ( Z146EmployeeVactionDays != T000F5_A146EmployeeVactionDays[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeVactionDays");
                  GXUtil.WriteLogRaw("Old: ",Z146EmployeeVactionDays);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A146EmployeeVactionDays[0]);
               }
               if ( Z100CompanyId != T000F5_A100CompanyId[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"CompanyId");
                  GXUtil.WriteLogRaw("Old: ",Z100CompanyId);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A100CompanyId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Employee"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         if ( ! IsAuthorized("employee_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F14 */
                     pr_default.execute(12, new Object[] {A148EmployeeName, A111GAMUserGUID, A147EmployeeBalance, A107EmployeeFirstName, A108EmployeeLastName, A109EmployeeEmail, A110EmployeeIsManager, A112EmployeeIsActive, A146EmployeeVactionDays, A100CompanyId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000F15 */
                     pr_default.execute(13);
                     A106EmployeeId = T000F15_A106EmployeeId[0];
                     AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        new assignemployeerole(context ).execute(  A106EmployeeId) ;
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0F0( ) ;
                           }
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
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         if ( ! IsAuthorized("employee_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F16 */
                     pr_default.execute(14, new Object[] {A148EmployeeName, A111GAMUserGUID, A147EmployeeBalance, A107EmployeeFirstName, A108EmployeeLastName, A109EmployeeEmail, A110EmployeeIsManager, A112EmployeeIsActive, A146EmployeeVactionDays, A100CompanyId, A106EmployeeId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        new assignemployeerole(context ).execute(  A106EmployeeId) ;
                        new employeestatuscheck(context ).execute(  A106EmployeeId) ;
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
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
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("employee_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0F28( ) ;
                  while ( RcdFound28 != 0 )
                  {
                     getByPrimaryKey0F28( ) ;
                     Delete0F28( ) ;
                     ScanNext0F28( ) ;
                  }
                  ScanEnd0F28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F17 */
                     pr_default.execute(15, new Object[] {A106EmployeeId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        new deleteemployeeaccount(context ).execute(  A109EmployeeEmail) ;
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
         }
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000F18 */
            pr_default.execute(16, new Object[] {A100CompanyId});
            A101CompanyName = T000F18_A101CompanyName[0];
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000F19 */
            pr_default.execute(17, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Project"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000F20 */
            pr_default.execute(18, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Support Request"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000F21 */
            pr_default.execute(19, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LeaveRequest"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000F22 */
            pr_default.execute(20, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WorkHourLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void ProcessNestedLevel0F28( )
      {
         nGXsfl_55_idx = 0;
         while ( nGXsfl_55_idx < nRC_GXsfl_55 )
         {
            ReadRow0F28( ) ;
            if ( ( nRcdExists_28 != 0 ) || ( nIsMod_28 != 0 ) )
            {
               standaloneNotModal0F28( ) ;
               GetKey0F28( ) ;
               if ( ( nRcdExists_28 == 0 ) && ( nRcdDeleted_28 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0F28( ) ;
               }
               else
               {
                  if ( RcdFound28 != 0 )
                  {
                     if ( ( nRcdDeleted_28 != 0 ) && ( nRcdExists_28 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0F28( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_28 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0F28( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_28 == 0 )
                     {
                        GXCCtl = "PROJECTID_" + sGXsfl_55_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProjectId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProjectId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z102ProjectId_"+sGXsfl_55_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102ProjectId), 10, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_28_"+sGXsfl_55_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_28), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_28_"+sGXsfl_55_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_28), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_28_"+sGXsfl_55_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_28), 4, 0, ".", ""))) ;
            if ( nIsMod_28 != 0 )
            {
               ChangePostValue( "PROJECTID_"+sGXsfl_55_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROJECTID_"+sGXsfl_55_idx+"Horizontalalignment", StringUtil.RTrim( edtProjectId_Horizontalalignment)) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0F28( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_28 = 0;
         nIsMod_28 = 0;
         nRcdDeleted_28 = 0;
      }

      protected void ProcessLevel0F16( )
      {
         /* Save parent mode. */
         sMode16 = Gx_mode;
         ProcessNestedLevel0F28( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("employee",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("employee",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F16( )
      {
         /* Scan By routine */
         /* Using cursor T000F23 */
         pr_default.execute(21);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound16 = 1;
            A106EmployeeId = T000F23_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound16 = 1;
            A106EmployeeId = T000F23_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
      }

      protected void ScanEnd0F16( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
         new createemployeeaccount(context ).execute(  A109EmployeeEmail,  A107EmployeeFirstName,  A108EmployeeLastName, out  A111GAMUserGUID, out  AV24Password) ;
         AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
         AssignAttri("", false, "AV24Password", AV24Password);
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
         edtEmployeeFirstName_Enabled = 0;
         AssignProp("", false, edtEmployeeFirstName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Enabled), 5, 0), true);
         edtEmployeeLastName_Enabled = 0;
         AssignProp("", false, edtEmployeeLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeLastName_Enabled), 5, 0), true);
         edtEmployeeEmail_Enabled = 0;
         AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         edtEmployeeVactionDays_Enabled = 0;
         AssignProp("", false, edtEmployeeVactionDays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeVactionDays_Enabled), 5, 0), true);
         dynCompanyId.Enabled = 0;
         AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         chkEmployeeIsManager.Enabled = 0;
         AssignProp("", false, chkEmployeeIsManager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsManager.Enabled), 5, 0), true);
         chkEmployeeIsActive.Enabled = 0;
         AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         edtGAMUserGUID_Enabled = 0;
         AssignProp("", false, edtGAMUserGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGAMUserGUID_Enabled), 5, 0), true);
         edtEmployeeBalance_Enabled = 0;
         AssignProp("", false, edtEmployeeBalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Enabled), 5, 0), true);
         edtEmployeeName_Enabled = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Enabled), 5, 0), true);
      }

      protected void ZM0F28( short GX_JID )
      {
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -30 )
         {
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
            Z103ProjectName = A103ProjectName;
         }
      }

      protected void standaloneNotModal0F28( )
      {
      }

      protected void standaloneModal0F28( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProjectId_Enabled = 0;
            AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         }
         else
         {
            edtProjectId_Enabled = 1;
            AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         }
      }

      protected void Load0F28( )
      {
         /* Using cursor T000F24 */
         pr_default.execute(22, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound28 = 1;
            A103ProjectName = T000F24_A103ProjectName[0];
            ZM0F28( -30) ;
         }
         pr_default.close(22);
         OnLoadActions0F28( ) ;
      }

      protected void OnLoadActions0F28( )
      {
      }

      protected void CheckExtendedTable0F28( )
      {
         nIsDirty_28 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0F28( ) ;
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROJECTID_" + sGXsfl_55_idx;
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A103ProjectName = T000F4_A103ProjectName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0F28( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0F28( )
      {
      }

      protected void gxLoad_31( long A102ProjectId )
      {
         /* Using cursor T000F25 */
         pr_default.execute(23, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GXCCtl = "PROJECTID_" + sGXsfl_55_idx;
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A103ProjectName = T000F25_A103ProjectName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A103ProjectName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void GetKey0F28( )
      {
         /* Using cursor T000F26 */
         pr_default.execute(24, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(24);
      }

      protected void getByPrimaryKey0F28( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F28( 30) ;
            RcdFound28 = 1;
            InitializeNonKey0F28( ) ;
            A102ProjectId = T000F3_A102ProjectId[0];
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F28( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0F28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0F28( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0F28( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0F28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeProject"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EmployeeProject"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F28( )
      {
         if ( ! IsAuthorized("employee_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F28( 0) ;
            CheckOptimisticConcurrency0F28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F27 */
                     pr_default.execute(25, new Object[] {A106EmployeeId, A102ProjectId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                     if ( (pr_default.getStatus(25) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0F28( ) ;
            }
            EndLevel0F28( ) ;
         }
         CloseExtendedTableCursors0F28( ) ;
      }

      protected void Update0F28( )
      {
         if ( ! IsAuthorized("employee_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F28( ) ;
         }
         if ( ( nIsMod_28 != 0 ) || ( nIsDirty_28 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0F28( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0F28( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0F28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table EmployeeProject */
                        DeferredUpdate0F28( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0F28( ) ;
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
               EndLevel0F28( ) ;
            }
         }
         CloseExtendedTableCursors0F28( ) ;
      }

      protected void DeferredUpdate0F28( )
      {
      }

      protected void Delete0F28( )
      {
         if ( ! IsAuthorized("employee_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0F28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F28( ) ;
            AfterConfirm0F28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F28 */
                  pr_default.execute(26, new Object[] {A106EmployeeId, A102ProjectId});
                  pr_default.close(26);
                  pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F28( )
      {
         standaloneModal0F28( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000F29 */
            pr_default.execute(27, new Object[] {A102ProjectId});
            A103ProjectName = T000F29_A103ProjectName[0];
            pr_default.close(27);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000F30 */
            pr_default.execute(28, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Project"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T000F31 */
            pr_default.execute(29, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WorkHourLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
         }
      }

      protected void EndLevel0F28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F28( )
      {
         /* Scan By routine */
         /* Using cursor T000F32 */
         pr_default.execute(30, new Object[] {A106EmployeeId});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound28 = 1;
            A102ProjectId = T000F32_A102ProjectId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F28( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound28 = 1;
            A102ProjectId = T000F32_A102ProjectId[0];
         }
      }

      protected void ScanEnd0F28( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm0F28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F28( )
      {
         edtProjectId_Enabled = 0;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_55_Refreshing);
      }

      protected void send_integrity_lvl_hashes0F28( )
      {
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void SubsflControlProps_5528( )
      {
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_55_idx;
      }

      protected void SubsflControlProps_fel_5528( )
      {
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_55_fel_idx;
      }

      protected void AddRow0F28( )
      {
         nGXsfl_55_idx = (int)(nGXsfl_55_idx+1);
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_5528( ) ;
         SendRow0F28( ) ;
      }

      protected void SendRow0F28( )
      {
         Gridlevel_projectRow = GXWebRow.GetNew(context);
         if ( subGridlevel_project_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_project_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
            {
               subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
            }
         }
         else if ( subGridlevel_project_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_project_Backstyle = 0;
            subGridlevel_project_Backcolor = subGridlevel_project_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
            {
               subGridlevel_project_Linesclass = subGridlevel_project_Class+"Uniform";
            }
         }
         else if ( subGridlevel_project_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_project_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
            {
               subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
            }
            subGridlevel_project_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_project_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_project_Backstyle = 1;
            if ( ((int)((nGXsfl_55_idx) % (2))) == 0 )
            {
               subGridlevel_project_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
               {
                  subGridlevel_project_Linesclass = subGridlevel_project_Class+"Even";
               }
            }
            else
            {
               subGridlevel_project_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
               {
                  subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_28_" + sGXsfl_55_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_55_idx + "',55)\"";
         ROClassString = "Attribute";
         Gridlevel_projectRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProjectId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)55,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)edtProjectId_Horizontalalignment,(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_projectRow);
         send_integrity_lvl_hashes0F28( ) ;
         GXCCtl = "Z102ProjectId_" + sGXsfl_55_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102ProjectId), 10, 0, ".", "")));
         GXCCtl = "nRcdDeleted_28_" + sGXsfl_55_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_28), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_28_" + sGXsfl_55_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_28), 4, 0, ".", "")));
         GXCCtl = "nIsMod_28_" + sGXsfl_55_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_28), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_55_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_55_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vEMPLOYEEID_" + sGXsfl_55_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROJECTID_"+sGXsfl_55_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROJECTID_"+sGXsfl_55_idx+"Horizontalalignment", StringUtil.RTrim( edtProjectId_Horizontalalignment));
         ajax_sending_grid_row(null);
         Gridlevel_projectContainer.AddRow(Gridlevel_projectRow);
      }

      protected void ReadRow0F28( )
      {
         nGXsfl_55_idx = (int)(nGXsfl_55_idx+1);
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_5528( ) ;
         edtProjectId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROJECTID_"+sGXsfl_55_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProjectId_Horizontalalignment = cgiGet( "PROJECTID_"+sGXsfl_55_idx+"Horizontalalignment");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
         {
            GXCCtl = "PROJECTID_" + sGXsfl_55_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            wbErr = true;
            A102ProjectId = 0;
         }
         else
         {
            A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "Z102ProjectId_" + sGXsfl_55_idx;
         Z102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_28_" + sGXsfl_55_idx;
         nRcdDeleted_28 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_28_" + sGXsfl_55_idx;
         nRcdExists_28 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_28_" + sGXsfl_55_idx;
         nIsMod_28 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProjectId_Enabled = edtProjectId_Enabled;
      }

      protected void ConfirmValues0F0( )
      {
         nGXsfl_55_idx = 0;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_5528( ) ;
         while ( nGXsfl_55_idx < nRC_GXsfl_55 )
         {
            nGXsfl_55_idx = (int)(nGXsfl_55_idx+1);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_5528( ) ;
            ChangePostValue( "Z102ProjectId_"+sGXsfl_55_idx, cgiGet( "ZT_"+"Z102ProjectId_"+sGXsfl_55_idx)) ;
            DeletePostValue( "ZT_"+"Z102ProjectId_"+sGXsfl_55_idx) ;
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmployeeId,10,0))}, new string[] {"Gx_mode","EmployeeId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Employee");
         forbiddenHiddens.Add("EmployeeId", context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("employee:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z148EmployeeName", StringUtil.RTrim( Z148EmployeeName));
         GxWebStd.gx_hidden_field( context, "Z111GAMUserGUID", Z111GAMUserGUID);
         GxWebStd.gx_hidden_field( context, "Z147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147EmployeeBalance), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z107EmployeeFirstName", StringUtil.RTrim( Z107EmployeeFirstName));
         GxWebStd.gx_hidden_field( context, "Z108EmployeeLastName", StringUtil.RTrim( Z108EmployeeLastName));
         GxWebStd.gx_hidden_field( context, "Z109EmployeeEmail", Z109EmployeeEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z110EmployeeIsManager", Z110EmployeeIsManager);
         GxWebStd.gx_boolean_hidden_field( context, "Z112EmployeeIsActive", Z112EmployeeIsActive);
         GxWebStd.gx_hidden_field( context, "Z146EmployeeVactionDays", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z146EmployeeVactionDays), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_55", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_55_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID_DATA", AV15ProjectId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID_DATA", AV15ProjectId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPASSWORD", StringUtil.RTrim( AV24Password));
         GxWebStd.gx_hidden_field( context, "COMPANYNAME", StringUtil.RTrim( A101CompanyName));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "PROJECTNAME", StringUtil.RTrim( A103ProjectName));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Objectcall", StringUtil.RTrim( Combo_projectid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Cls", StringUtil.RTrim( Combo_projectid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Enabled", StringUtil.BoolToStr( Combo_projectid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_projectid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Isgriditem", StringUtil.BoolToStr( Combo_projectid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Emptyitem", StringUtil.BoolToStr( Combo_projectid_Emptyitem));
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
         return formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmployeeId,10,0))}, new string[] {"Gx_mode","EmployeeId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Employee" ;
      }

      public override string GetPgmdesc( )
      {
         return "Employee" ;
      }

      protected void InitializeNonKey0F16( )
      {
         A100CompanyId = 0;
         AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         A148EmployeeName = "";
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         A111GAMUserGUID = "";
         AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
         AV24Password = "";
         AssignAttri("", false, "AV24Password", AV24Password);
         A147EmployeeBalance = 0;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
         A107EmployeeFirstName = "";
         AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
         A108EmployeeLastName = "";
         AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
         A109EmployeeEmail = "";
         AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
         A101CompanyName = "";
         AssignAttri("", false, "A101CompanyName", A101CompanyName);
         A110EmployeeIsManager = false;
         AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
         A112EmployeeIsActive = false;
         AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         A146EmployeeVactionDays = 21;
         AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( (decimal)(A146EmployeeVactionDays), 4, 0));
         Z148EmployeeName = "";
         Z111GAMUserGUID = "";
         Z147EmployeeBalance = 0;
         Z107EmployeeFirstName = "";
         Z108EmployeeLastName = "";
         Z109EmployeeEmail = "";
         Z110EmployeeIsManager = false;
         Z112EmployeeIsActive = false;
         Z146EmployeeVactionDays = 0;
         Z100CompanyId = 0;
      }

      protected void InitAll0F16( )
      {
         A106EmployeeId = 0;
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A112EmployeeIsActive = i112EmployeeIsActive;
         AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         A146EmployeeVactionDays = i146EmployeeVactionDays;
         AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( (decimal)(A146EmployeeVactionDays), 4, 0));
      }

      protected void InitializeNonKey0F28( )
      {
         A103ProjectName = "";
         AssignAttri("", false, "A103ProjectName", A103ProjectName);
      }

      protected void InitAll0F28( )
      {
         A102ProjectId = 0;
         InitializeNonKey0F28( ) ;
      }

      protected void StandaloneModalInsert0F28( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20245191552664", true, true);
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
         context.AddJavascriptSource("employee.js", "?20245191552666", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties28( )
      {
         edtProjectId_Enabled = defedtProjectId_Enabled;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_55_Refreshing);
      }

      protected void StartGridControl55( )
      {
         Gridlevel_projectContainer.AddObjectProperty("GridName", "Gridlevel_project");
         Gridlevel_projectContainer.AddObjectProperty("Header", subGridlevel_project_Header);
         Gridlevel_projectContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_projectContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_projectContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_projectColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_projectColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))));
         Gridlevel_projectColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectId_Enabled), 5, 0, ".", "")));
         Gridlevel_projectColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtProjectId_Horizontalalignment));
         Gridlevel_projectContainer.AddColumnProperties(Gridlevel_projectColumn);
         Gridlevel_projectContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Selectedindex), 4, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowselection), 1, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowhovering), 1, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME";
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME";
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL";
         edtEmployeeVactionDays_Internalname = "EMPLOYEEVACTIONDAYS";
         dynCompanyId_Internalname = "COMPANYID";
         chkEmployeeIsManager_Internalname = "EMPLOYEEISMANAGER";
         chkEmployeeIsActive_Internalname = "EMPLOYEEISACTIVE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtProjectId_Internalname = "PROJECTID";
         divTableleaflevel_project_Internalname = "TABLELEAFLEVEL_PROJECT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_projectid_Internalname = "COMBO_PROJECTID";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtGAMUserGUID_Internalname = "GAMUSERGUID";
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_project_Internalname = "GRIDLEVEL_PROJECT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_project_Allowcollapsing = 0;
         subGridlevel_project_Allowselection = 0;
         subGridlevel_project_Header = "";
         Combo_projectid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Employee";
         edtProjectId_Jsonclick = "";
         subGridlevel_project_Class = "WorkWith";
         subGridlevel_project_Backcolorstyle = 0;
         Combo_projectid_Titlecontrolidtoreplace = "";
         edtProjectId_Enabled = 1;
         edtEmployeeName_Jsonclick = "";
         edtEmployeeName_Enabled = 1;
         edtEmployeeName_Visible = 1;
         edtEmployeeBalance_Jsonclick = "";
         edtEmployeeBalance_Enabled = 1;
         edtEmployeeBalance_Visible = 1;
         edtGAMUserGUID_Jsonclick = "";
         edtGAMUserGUID_Enabled = 1;
         edtGAMUserGUID_Visible = 1;
         edtEmployeeId_Jsonclick = "";
         edtEmployeeId_Enabled = 0;
         edtEmployeeId_Visible = 1;
         Combo_projectid_Emptyitem = Convert.ToBoolean( 0);
         Combo_projectid_Isgriditem = Convert.ToBoolean( -1);
         Combo_projectid_Cls = "ExtendedCombo";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkEmployeeIsActive.Enabled = 1;
         chkEmployeeIsManager.Enabled = 1;
         dynCompanyId_Jsonclick = "";
         dynCompanyId.Enabled = 1;
         edtEmployeeVactionDays_Jsonclick = "";
         edtEmployeeVactionDays_Enabled = 1;
         edtEmployeeEmail_Jsonclick = "";
         edtEmployeeEmail_Enabled = 1;
         edtEmployeeLastName_Jsonclick = "";
         edtEmployeeLastName_Enabled = 1;
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeFirstName_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         divLayoutmaintable_Class = "Table";
         edtProjectId_Horizontalalignment = "end";
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

      protected void GXDLACOMPANYID0F1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACOMPANYID_data0F1( ) ;
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

      protected void GXACOMPANYID_html0F1( )
      {
         long gxdynajaxvalue;
         GXDLACOMPANYID_data0F1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynCompanyId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynCompanyId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLACOMPANYID_data0F1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000F33 */
         pr_default.execute(31);
         while ( (pr_default.getStatus(31) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000F33_A100CompanyId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000F33_A101CompanyName[0]));
            pr_default.readNext(31);
         }
         pr_default.close(31);
      }

      protected void GX6ASACOMPANYID0F16( long AV13Insert_CompanyId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            A100CompanyId = AV13Insert_CompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         else
         {
            GXt_boolean2 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean2) ;
            if ( GXt_boolean2 )
            {
               GXt_int3 = A100CompanyId;
               new getloggedinusercompanyid(context ).execute( out  GXt_int3) ;
               A100CompanyId = GXt_int3;
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GXASA1000F16( long AV13Insert_CompanyId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            dynCompanyId.Enabled = 0;
            AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         }
         else
         {
            GXt_boolean2 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean2) ;
            if ( GXt_boolean2 )
            {
               dynCompanyId.Enabled = 0;
               AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
            }
            else
            {
               dynCompanyId.Enabled = 1;
               AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX11ASAEMPLOYEEBALANCE0F16( short A146EmployeeVactionDays ,
                                                 short Gx_BScreen ,
                                                 long A106EmployeeId ,
                                                 DateTime Gx_date )
      {
         if ( IsIns( )  && (0==A147EmployeeBalance) && ( Gx_BScreen == 0 ) )
         {
            A147EmployeeBalance = A146EmployeeVactionDays;
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
         }
         else
         {
            if ( ( DateTimeUtil.Month( DateTimeUtil.Now( context)) == 1 ) && ( DateTimeUtil.Day( DateTimeUtil.Now( context)) == 1 ) && IsIns( )  )
            {
               A147EmployeeBalance = A146EmployeeVactionDays;
               AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  GXt_int4 = A147EmployeeBalance;
                  new getemployeeapprovedvacationdays(context ).execute(  A106EmployeeId,  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 1, 1),  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 12, 31), out  GXt_int4) ;
                  A147EmployeeBalance = (short)(A146EmployeeVactionDays-GXt_int4);
                  AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
               }
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A147EmployeeBalance), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GXASA1000F16( )
      {
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            dynCompanyId.Enabled = 0;
            AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_20_0F16( string A109EmployeeEmail ,
                                 string A107EmployeeFirstName ,
                                 string A108EmployeeLastName )
      {
         new createemployeeaccount(context ).execute(  A109EmployeeEmail,  A107EmployeeFirstName,  A108EmployeeLastName, out  A111GAMUserGUID, out  AV24Password) ;
         AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
         AssignAttri("", false, "AV24Password", AV24Password);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A111GAMUserGUID)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( AV24Password))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_21_0F16( long A106EmployeeId )
      {
         new assignemployeerole(context ).execute(  A106EmployeeId) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_22_0F16( string A109EmployeeEmail )
      {
         new deleteemployeeaccount(context ).execute(  A109EmployeeEmail) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_23_0F16( long A106EmployeeId )
      {
         new employeestatuscheck(context ).execute(  A106EmployeeId) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_project_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5528( ) ;
         while ( nGXsfl_55_idx <= nRC_GXsfl_55 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0F28( ) ;
            standaloneModal0F28( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0F28( ) ;
            nGXsfl_55_idx = (int)(nGXsfl_55_idx+1);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_5528( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_projectContainer)) ;
         /* End function gxnrGridlevel_project_newrow */
      }

      protected void init_web_controls( )
      {
         dynCompanyId.Name = "COMPANYID";
         dynCompanyId.WebTags = "";
         dynCompanyId.removeAllItems();
         /* Using cursor T000F34 */
         pr_default.execute(32);
         while ( (pr_default.getStatus(32) != 101) )
         {
            dynCompanyId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000F34_A100CompanyId[0]), 10, 0)), T000F34_A101CompanyName[0], 0);
            pr_default.readNext(32);
         }
         pr_default.close(32);
         if ( dynCompanyId.ItemCount > 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         chkEmployeeIsManager.Name = "EMPLOYEEISMANAGER";
         chkEmployeeIsManager.WebTags = "";
         chkEmployeeIsManager.Caption = "";
         AssignProp("", false, chkEmployeeIsManager_Internalname, "TitleCaption", chkEmployeeIsManager.Caption, true);
         chkEmployeeIsManager.CheckedValue = "false";
         A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
         AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
         chkEmployeeIsActive.Name = "EMPLOYEEISACTIVE";
         chkEmployeeIsActive.WebTags = "";
         chkEmployeeIsActive.Caption = "";
         AssignProp("", false, chkEmployeeIsActive_Internalname, "TitleCaption", chkEmployeeIsActive.Caption, true);
         chkEmployeeIsActive.CheckedValue = "false";
         if ( IsIns( ) && (false==A112EmployeeIsActive) )
         {
            A112EmployeeIsActive = false;
            AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         }
         /* End function init_web_controls */
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

      public void Valid_Employeeemail( )
      {
         A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000F35 */
         pr_default.execute(33, new Object[] {A109EmployeeEmail, A106EmployeeId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Employee Email"}), 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
         }
         pr_default.close(33);
         if ( ! ( GxRegex.IsMatch(A109EmployeeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Employee Email does not match the specified pattern", "OutOfRange", 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Email", "", "", "", "", "", "", "", ""), 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Work hours/minutes are required",  "error",  "#"+edtEmployeeEmail_Internalname,  "true",  ""), 0, "EMPLOYEEEMAIL");
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Employeevactiondays( )
      {
         A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         if ( IsIns( )  && (0==A147EmployeeBalance) && ( Gx_BScreen == 0 ) )
         {
            A147EmployeeBalance = A146EmployeeVactionDays;
         }
         else
         {
            if ( ( DateTimeUtil.Month( DateTimeUtil.Now( context)) == 1 ) && ( DateTimeUtil.Day( DateTimeUtil.Now( context)) == 1 ) && IsIns( )  )
            {
               A147EmployeeBalance = A146EmployeeVactionDays;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  GXt_int4 = A147EmployeeBalance;
                  new getemployeeapprovedvacationdays(context ).execute(  A106EmployeeId,  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 1, 1),  context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 12, 31), out  GXt_int4) ;
                  A147EmployeeBalance = (short)(A146EmployeeVactionDays-GXt_int4);
               }
            }
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147EmployeeBalance), 4, 0, ".", "")));
      }

      public void Valid_Companyid( )
      {
         A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000F18 */
         pr_default.execute(16, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
         }
         A101CompanyName = T000F18_A101CompanyName[0];
         pr_default.close(16);
         if ( (0==A100CompanyId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Company Id", "", "", "", "", "", "", "", ""), 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A101CompanyName", StringUtil.RTrim( A101CompanyName));
      }

      public void Valid_Projectid( )
      {
         A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000F29 */
         pr_default.execute(27, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
         }
         A103ProjectName = T000F29_A103ProjectName[0];
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A103ProjectName", StringUtil.RTrim( A103ProjectName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EmployeeId',fld:'vEMPLOYEEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E120F2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("VALID_EMPLOYEEFIRSTNAME","{handler:'Valid_Employeefirstname',iparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("VALID_EMPLOYEEFIRSTNAME",",oparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("VALID_EMPLOYEELASTNAME","{handler:'Valid_Employeelastname',iparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("VALID_EMPLOYEELASTNAME",",oparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("VALID_EMPLOYEEEMAIL","{handler:'Valid_Employeeemail',iparms:[{av:'A109EmployeeEmail',fld:'EMPLOYEEEMAIL',pic:''},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("VALID_EMPLOYEEEMAIL",",oparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("VALID_EMPLOYEEVACTIONDAYS","{handler:'Valid_Employeevactiondays',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A146EmployeeVactionDays',fld:'EMPLOYEEVACTIONDAYS',pic:'ZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:''},{av:'A147EmployeeBalance',fld:'EMPLOYEEBALANCE',pic:'ZZZ9'},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("VALID_EMPLOYEEVACTIONDAYS",",oparms:[{av:'A147EmployeeBalance',fld:'EMPLOYEEBALANCE',pic:'ZZZ9'},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("VALID_COMPANYID","{handler:'Valid_Companyid',iparms:[{av:'A101CompanyName',fld:'COMPANYNAME',pic:''},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("VALID_COMPANYID",",oparms:[{av:'A101CompanyName',fld:'COMPANYNAME',pic:''},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("VALID_EMPLOYEEID","{handler:'Valid_Employeeid',iparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("VALID_EMPLOYEEID",",oparms:[{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
         setEventMetadata("VALID_PROJECTID","{handler:'Valid_Projectid',iparms:[{av:'A102ProjectId',fld:'PROJECTID',pic:'ZZZZZZZZZ9'},{av:'A103ProjectName',fld:'PROJECTNAME',pic:''},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]");
         setEventMetadata("VALID_PROJECTID",",oparms:[{av:'A103ProjectName',fld:'PROJECTNAME',pic:''},{av:'dynCompanyId'},{av:'A100CompanyId',fld:'COMPANYID',pic:'ZZZZZZZZZ9'},{av:'A110EmployeeIsManager',fld:'EMPLOYEEISMANAGER',pic:''},{av:'A112EmployeeIsActive',fld:'EMPLOYEEISACTIVE',pic:''}]}");
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
         pr_default.close(27);
         pr_default.close(4);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z148EmployeeName = "";
         Z111GAMUserGUID = "";
         Z107EmployeeFirstName = "";
         Z108EmployeeLastName = "";
         Z109EmployeeEmail = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A109EmployeeEmail = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         Gx_date = DateTime.MinValue;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_projectid = new GXUserControl();
         Combo_projectid_Caption = "";
         AV15ProjectId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A111GAMUserGUID = "";
         A148EmployeeName = "";
         Gridlevel_projectContainer = new GXWebGrid( context);
         sMode28 = "";
         sStyleString = "";
         AV24Password = "";
         A101CompanyName = "";
         AV32Pgmname = "";
         A103ProjectName = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Combo_projectid_Objectcall = "";
         Combo_projectid_Class = "";
         Combo_projectid_Icontype = "";
         Combo_projectid_Icon = "";
         Combo_projectid_Tooltip = "";
         Combo_projectid_Selectedvalue_set = "";
         Combo_projectid_Selectedvalue_get = "";
         Combo_projectid_Selectedtext_set = "";
         Combo_projectid_Selectedtext_get = "";
         Combo_projectid_Gamoauthtoken = "";
         Combo_projectid_Ddointernalname = "";
         Combo_projectid_Titlecontrolalign = "";
         Combo_projectid_Dropdownoptionstype = "";
         Combo_projectid_Datalisttype = "";
         Combo_projectid_Datalistfixedvalues = "";
         Combo_projectid_Datalistproc = "";
         Combo_projectid_Datalistprocparametersprefix = "";
         Combo_projectid_Remoteservicesparameters = "";
         Combo_projectid_Htmltemplate = "";
         Combo_projectid_Multiplevaluestype = "";
         Combo_projectid_Loadingdata = "";
         Combo_projectid_Noresultsfound = "";
         Combo_projectid_Emptyitemtext = "";
         Combo_projectid_Onlyselectedvalues = "";
         Combo_projectid_Selectalltext = "";
         Combo_projectid_Multiplevaluesseparator = "";
         Combo_projectid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode16 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17ComboSelectedValue = "";
         Z101CompanyName = "";
         T000F7_A101CompanyName = new string[] {""} ;
         T000F8_A106EmployeeId = new long[1] ;
         T000F8_A148EmployeeName = new string[] {""} ;
         T000F8_A111GAMUserGUID = new string[] {""} ;
         T000F8_A147EmployeeBalance = new short[1] ;
         T000F8_A107EmployeeFirstName = new string[] {""} ;
         T000F8_A108EmployeeLastName = new string[] {""} ;
         T000F8_A109EmployeeEmail = new string[] {""} ;
         T000F8_A101CompanyName = new string[] {""} ;
         T000F8_A110EmployeeIsManager = new bool[] {false} ;
         T000F8_A112EmployeeIsActive = new bool[] {false} ;
         T000F8_A146EmployeeVactionDays = new short[1] ;
         T000F8_A100CompanyId = new long[1] ;
         T000F9_A109EmployeeEmail = new string[] {""} ;
         T000F10_A101CompanyName = new string[] {""} ;
         T000F11_A106EmployeeId = new long[1] ;
         T000F6_A106EmployeeId = new long[1] ;
         T000F6_A148EmployeeName = new string[] {""} ;
         T000F6_A111GAMUserGUID = new string[] {""} ;
         T000F6_A147EmployeeBalance = new short[1] ;
         T000F6_A107EmployeeFirstName = new string[] {""} ;
         T000F6_A108EmployeeLastName = new string[] {""} ;
         T000F6_A109EmployeeEmail = new string[] {""} ;
         T000F6_A110EmployeeIsManager = new bool[] {false} ;
         T000F6_A112EmployeeIsActive = new bool[] {false} ;
         T000F6_A146EmployeeVactionDays = new short[1] ;
         T000F6_A100CompanyId = new long[1] ;
         T000F12_A106EmployeeId = new long[1] ;
         T000F13_A106EmployeeId = new long[1] ;
         T000F5_A106EmployeeId = new long[1] ;
         T000F5_A148EmployeeName = new string[] {""} ;
         T000F5_A111GAMUserGUID = new string[] {""} ;
         T000F5_A147EmployeeBalance = new short[1] ;
         T000F5_A107EmployeeFirstName = new string[] {""} ;
         T000F5_A108EmployeeLastName = new string[] {""} ;
         T000F5_A109EmployeeEmail = new string[] {""} ;
         T000F5_A110EmployeeIsManager = new bool[] {false} ;
         T000F5_A112EmployeeIsActive = new bool[] {false} ;
         T000F5_A146EmployeeVactionDays = new short[1] ;
         T000F5_A100CompanyId = new long[1] ;
         T000F15_A106EmployeeId = new long[1] ;
         T000F18_A101CompanyName = new string[] {""} ;
         T000F19_A102ProjectId = new long[1] ;
         T000F20_A172SupportRequestId = new long[1] ;
         T000F21_A127LeaveRequestId = new long[1] ;
         T000F22_A118WorkHourLogId = new long[1] ;
         T000F23_A106EmployeeId = new long[1] ;
         Z103ProjectName = "";
         T000F24_A106EmployeeId = new long[1] ;
         T000F24_A103ProjectName = new string[] {""} ;
         T000F24_A102ProjectId = new long[1] ;
         T000F4_A103ProjectName = new string[] {""} ;
         T000F25_A103ProjectName = new string[] {""} ;
         T000F26_A106EmployeeId = new long[1] ;
         T000F26_A102ProjectId = new long[1] ;
         T000F3_A106EmployeeId = new long[1] ;
         T000F3_A102ProjectId = new long[1] ;
         T000F2_A106EmployeeId = new long[1] ;
         T000F2_A102ProjectId = new long[1] ;
         T000F29_A103ProjectName = new string[] {""} ;
         T000F30_A102ProjectId = new long[1] ;
         T000F31_A118WorkHourLogId = new long[1] ;
         T000F32_A106EmployeeId = new long[1] ;
         T000F32_A102ProjectId = new long[1] ;
         Gridlevel_projectRow = new GXWebRow();
         subGridlevel_project_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_projectColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000F33_A100CompanyId = new long[1] ;
         T000F33_A101CompanyName = new string[] {""} ;
         T000F34_A100CompanyId = new long[1] ;
         T000F34_A101CompanyName = new string[] {""} ;
         T000F35_A109EmployeeEmail = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.employee__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employee__default(),
            new Object[][] {
                new Object[] {
               T000F2_A106EmployeeId, T000F2_A102ProjectId
               }
               , new Object[] {
               T000F3_A106EmployeeId, T000F3_A102ProjectId
               }
               , new Object[] {
               T000F4_A103ProjectName
               }
               , new Object[] {
               T000F5_A106EmployeeId, T000F5_A148EmployeeName, T000F5_A111GAMUserGUID, T000F5_A147EmployeeBalance, T000F5_A107EmployeeFirstName, T000F5_A108EmployeeLastName, T000F5_A109EmployeeEmail, T000F5_A110EmployeeIsManager, T000F5_A112EmployeeIsActive, T000F5_A146EmployeeVactionDays,
               T000F5_A100CompanyId
               }
               , new Object[] {
               T000F6_A106EmployeeId, T000F6_A148EmployeeName, T000F6_A111GAMUserGUID, T000F6_A147EmployeeBalance, T000F6_A107EmployeeFirstName, T000F6_A108EmployeeLastName, T000F6_A109EmployeeEmail, T000F6_A110EmployeeIsManager, T000F6_A112EmployeeIsActive, T000F6_A146EmployeeVactionDays,
               T000F6_A100CompanyId
               }
               , new Object[] {
               T000F7_A101CompanyName
               }
               , new Object[] {
               T000F8_A106EmployeeId, T000F8_A148EmployeeName, T000F8_A111GAMUserGUID, T000F8_A147EmployeeBalance, T000F8_A107EmployeeFirstName, T000F8_A108EmployeeLastName, T000F8_A109EmployeeEmail, T000F8_A101CompanyName, T000F8_A110EmployeeIsManager, T000F8_A112EmployeeIsActive,
               T000F8_A146EmployeeVactionDays, T000F8_A100CompanyId
               }
               , new Object[] {
               T000F9_A109EmployeeEmail
               }
               , new Object[] {
               T000F10_A101CompanyName
               }
               , new Object[] {
               T000F11_A106EmployeeId
               }
               , new Object[] {
               T000F12_A106EmployeeId
               }
               , new Object[] {
               T000F13_A106EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               T000F15_A106EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F18_A101CompanyName
               }
               , new Object[] {
               T000F19_A102ProjectId
               }
               , new Object[] {
               T000F20_A172SupportRequestId
               }
               , new Object[] {
               T000F21_A127LeaveRequestId
               }
               , new Object[] {
               T000F22_A118WorkHourLogId
               }
               , new Object[] {
               T000F23_A106EmployeeId
               }
               , new Object[] {
               T000F24_A106EmployeeId, T000F24_A103ProjectName, T000F24_A102ProjectId
               }
               , new Object[] {
               T000F25_A103ProjectName
               }
               , new Object[] {
               T000F26_A106EmployeeId, T000F26_A102ProjectId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F29_A103ProjectName
               }
               , new Object[] {
               T000F30_A102ProjectId
               }
               , new Object[] {
               T000F31_A118WorkHourLogId
               }
               , new Object[] {
               T000F32_A106EmployeeId, T000F32_A102ProjectId
               }
               , new Object[] {
               T000F33_A100CompanyId, T000F33_A101CompanyName
               }
               , new Object[] {
               T000F34_A100CompanyId, T000F34_A101CompanyName
               }
               , new Object[] {
               T000F35_A109EmployeeEmail
               }
            }
         );
         AV32Pgmname = "Employee";
         Gx_date = DateTimeUtil.Today( context);
         Z146EmployeeVactionDays = 21;
         i146EmployeeVactionDays = 21;
         A146EmployeeVactionDays = 21;
         Z112EmployeeIsActive = false;
         A112EmployeeIsActive = false;
         i112EmployeeIsActive = false;
         Z147EmployeeBalance = 0;
         A147EmployeeBalance = 0;
         Z112EmployeeIsActive = false;
         A112EmployeeIsActive = false;
         i112EmployeeIsActive = false;
      }

      private short Z147EmployeeBalance ;
      private short Z146EmployeeVactionDays ;
      private short nRcdDeleted_28 ;
      private short nRcdExists_28 ;
      private short nIsMod_28 ;
      private short GxWebError ;
      private short A146EmployeeVactionDays ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A147EmployeeBalance ;
      private short nBlankRcdCount28 ;
      private short RcdFound28 ;
      private short nBlankRcdUsr28 ;
      private short RcdFound16 ;
      private short GX_JID ;
      private short nIsDirty_16 ;
      private short nIsDirty_28 ;
      private short subGridlevel_project_Backcolorstyle ;
      private short subGridlevel_project_Backstyle ;
      private short gxajaxcallmode ;
      private short i146EmployeeVactionDays ;
      private short subGridlevel_project_Allowselection ;
      private short subGridlevel_project_Allowhovering ;
      private short subGridlevel_project_Allowcollapsing ;
      private short subGridlevel_project_Collapsed ;
      private short GXt_int4 ;
      private int nRC_GXsfl_55 ;
      private int nGXsfl_55_idx=1 ;
      private int trnEnded ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtEmployeeLastName_Enabled ;
      private int edtEmployeeEmail_Enabled ;
      private int edtEmployeeVactionDays_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeId_Visible ;
      private int edtGAMUserGUID_Visible ;
      private int edtGAMUserGUID_Enabled ;
      private int edtEmployeeBalance_Enabled ;
      private int edtEmployeeBalance_Visible ;
      private int edtEmployeeName_Visible ;
      private int edtEmployeeName_Enabled ;
      private int edtProjectId_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Combo_projectid_Datalistupdateminimumcharacters ;
      private int Combo_projectid_Gxcontroltype ;
      private int AV33GXV1 ;
      private int subGridlevel_project_Backcolor ;
      private int subGridlevel_project_Allbackcolor ;
      private int defedtProjectId_Enabled ;
      private int idxLst ;
      private int subGridlevel_project_Selectedindex ;
      private int subGridlevel_project_Selectioncolor ;
      private int subGridlevel_project_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7EmployeeId ;
      private long Z106EmployeeId ;
      private long Z100CompanyId ;
      private long N100CompanyId ;
      private long Z102ProjectId ;
      private long A106EmployeeId ;
      private long AV13Insert_CompanyId ;
      private long A100CompanyId ;
      private long A102ProjectId ;
      private long AV7EmployeeId ;
      private long GRIDLEVEL_PROJECT_nFirstRecordOnPage ;
      private long GXt_int3 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z148EmployeeName ;
      private string Z107EmployeeFirstName ;
      private string Z108EmployeeLastName ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmployeeFirstName_Internalname ;
      private string sGXsfl_55_idx="0001" ;
      private string edtProjectId_Horizontalalignment ;
      private string edtProjectId_Internalname ;
      private string dynCompanyId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtEmployeeLastName_Internalname ;
      private string edtEmployeeLastName_Jsonclick ;
      private string edtEmployeeEmail_Internalname ;
      private string edtEmployeeEmail_Jsonclick ;
      private string edtEmployeeVactionDays_Internalname ;
      private string edtEmployeeVactionDays_Jsonclick ;
      private string dynCompanyId_Jsonclick ;
      private string chkEmployeeIsManager_Internalname ;
      private string chkEmployeeIsActive_Internalname ;
      private string divTableleaflevel_project_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_projectid_Caption ;
      private string Combo_projectid_Cls ;
      private string Combo_projectid_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtEmployeeId_Jsonclick ;
      private string edtGAMUserGUID_Internalname ;
      private string edtGAMUserGUID_Jsonclick ;
      private string edtEmployeeBalance_Internalname ;
      private string edtEmployeeBalance_Jsonclick ;
      private string edtEmployeeName_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Jsonclick ;
      private string sMode28 ;
      private string sStyleString ;
      private string subGridlevel_project_Internalname ;
      private string AV24Password ;
      private string A101CompanyName ;
      private string AV32Pgmname ;
      private string A103ProjectName ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Combo_projectid_Objectcall ;
      private string Combo_projectid_Class ;
      private string Combo_projectid_Icontype ;
      private string Combo_projectid_Icon ;
      private string Combo_projectid_Tooltip ;
      private string Combo_projectid_Selectedvalue_set ;
      private string Combo_projectid_Selectedvalue_get ;
      private string Combo_projectid_Selectedtext_set ;
      private string Combo_projectid_Selectedtext_get ;
      private string Combo_projectid_Gamoauthtoken ;
      private string Combo_projectid_Ddointernalname ;
      private string Combo_projectid_Titlecontrolalign ;
      private string Combo_projectid_Dropdownoptionstype ;
      private string Combo_projectid_Titlecontrolidtoreplace ;
      private string Combo_projectid_Datalisttype ;
      private string Combo_projectid_Datalistfixedvalues ;
      private string Combo_projectid_Datalistproc ;
      private string Combo_projectid_Datalistprocparametersprefix ;
      private string Combo_projectid_Remoteservicesparameters ;
      private string Combo_projectid_Htmltemplate ;
      private string Combo_projectid_Multiplevaluestype ;
      private string Combo_projectid_Loadingdata ;
      private string Combo_projectid_Noresultsfound ;
      private string Combo_projectid_Emptyitemtext ;
      private string Combo_projectid_Onlyselectedvalues ;
      private string Combo_projectid_Selectalltext ;
      private string Combo_projectid_Multiplevaluesseparator ;
      private string Combo_projectid_Addnewoptiontext ;
      private string hsh ;
      private string sMode16 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z101CompanyName ;
      private string Z103ProjectName ;
      private string sGXsfl_55_fel_idx="0001" ;
      private string subGridlevel_project_Class ;
      private string subGridlevel_project_Linesclass ;
      private string ROClassString ;
      private string edtProjectId_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_project_Header ;
      private string gxwrpcisep ;
      private DateTime Gx_date ;
      private bool Z110EmployeeIsManager ;
      private bool Z112EmployeeIsActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_55_Refreshing=false ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_projectid_Isgriditem ;
      private bool Combo_projectid_Emptyitem ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Combo_projectid_Enabled ;
      private bool Combo_projectid_Visible ;
      private bool Combo_projectid_Allowmultipleselection ;
      private bool Combo_projectid_Hasdescription ;
      private bool Combo_projectid_Includeonlyselectedoption ;
      private bool Combo_projectid_Includeselectalloption ;
      private bool Combo_projectid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i112EmployeeIsActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool GXt_boolean2 ;
      private string Z111GAMUserGUID ;
      private string Z109EmployeeEmail ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private string AV17ComboSelectedValue ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_projectContainer ;
      private GXWebRow Gridlevel_projectRow ;
      private GXWebColumn Gridlevel_projectColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_projectid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynCompanyId ;
      private GXCheckbox chkEmployeeIsManager ;
      private GXCheckbox chkEmployeeIsActive ;
      private IDataStoreProvider pr_default ;
      private string[] T000F7_A101CompanyName ;
      private long[] T000F8_A106EmployeeId ;
      private string[] T000F8_A148EmployeeName ;
      private string[] T000F8_A111GAMUserGUID ;
      private short[] T000F8_A147EmployeeBalance ;
      private string[] T000F8_A107EmployeeFirstName ;
      private string[] T000F8_A108EmployeeLastName ;
      private string[] T000F8_A109EmployeeEmail ;
      private string[] T000F8_A101CompanyName ;
      private bool[] T000F8_A110EmployeeIsManager ;
      private bool[] T000F8_A112EmployeeIsActive ;
      private short[] T000F8_A146EmployeeVactionDays ;
      private long[] T000F8_A100CompanyId ;
      private string[] T000F9_A109EmployeeEmail ;
      private string[] T000F10_A101CompanyName ;
      private long[] T000F11_A106EmployeeId ;
      private long[] T000F6_A106EmployeeId ;
      private string[] T000F6_A148EmployeeName ;
      private string[] T000F6_A111GAMUserGUID ;
      private short[] T000F6_A147EmployeeBalance ;
      private string[] T000F6_A107EmployeeFirstName ;
      private string[] T000F6_A108EmployeeLastName ;
      private string[] T000F6_A109EmployeeEmail ;
      private bool[] T000F6_A110EmployeeIsManager ;
      private bool[] T000F6_A112EmployeeIsActive ;
      private short[] T000F6_A146EmployeeVactionDays ;
      private long[] T000F6_A100CompanyId ;
      private long[] T000F12_A106EmployeeId ;
      private long[] T000F13_A106EmployeeId ;
      private long[] T000F5_A106EmployeeId ;
      private string[] T000F5_A148EmployeeName ;
      private string[] T000F5_A111GAMUserGUID ;
      private short[] T000F5_A147EmployeeBalance ;
      private string[] T000F5_A107EmployeeFirstName ;
      private string[] T000F5_A108EmployeeLastName ;
      private string[] T000F5_A109EmployeeEmail ;
      private bool[] T000F5_A110EmployeeIsManager ;
      private bool[] T000F5_A112EmployeeIsActive ;
      private short[] T000F5_A146EmployeeVactionDays ;
      private long[] T000F5_A100CompanyId ;
      private long[] T000F15_A106EmployeeId ;
      private string[] T000F18_A101CompanyName ;
      private long[] T000F19_A102ProjectId ;
      private long[] T000F20_A172SupportRequestId ;
      private long[] T000F21_A127LeaveRequestId ;
      private long[] T000F22_A118WorkHourLogId ;
      private long[] T000F23_A106EmployeeId ;
      private long[] T000F24_A106EmployeeId ;
      private string[] T000F24_A103ProjectName ;
      private long[] T000F24_A102ProjectId ;
      private string[] T000F4_A103ProjectName ;
      private string[] T000F25_A103ProjectName ;
      private long[] T000F26_A106EmployeeId ;
      private long[] T000F26_A102ProjectId ;
      private long[] T000F3_A106EmployeeId ;
      private long[] T000F3_A102ProjectId ;
      private long[] T000F2_A106EmployeeId ;
      private long[] T000F2_A102ProjectId ;
      private string[] T000F29_A103ProjectName ;
      private long[] T000F30_A102ProjectId ;
      private long[] T000F31_A118WorkHourLogId ;
      private long[] T000F32_A106EmployeeId ;
      private long[] T000F32_A102ProjectId ;
      private long[] T000F33_A100CompanyId ;
      private string[] T000F33_A101CompanyName ;
      private long[] T000F34_A100CompanyId ;
      private string[] T000F34_A101CompanyName ;
      private string[] T000F35_A109EmployeeEmail ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15ProjectId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class employee__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class employee__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000F8;
        prmT000F8 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F9;
        prmT000F9 = new Object[] {
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F7;
        prmT000F7 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000F10;
        prmT000F10 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000F11;
        prmT000F11 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F6;
        prmT000F6 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F12;
        prmT000F12 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F13;
        prmT000F13 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F5;
        prmT000F5 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F14;
        prmT000F14 = new Object[] {
        new ParDef("EmployeeName",GXType.Char,100,0) ,
        new ParDef("GAMUserGUID",GXType.VarChar,100,60) ,
        new ParDef("EmployeeBalance",GXType.Int16,4,0) ,
        new ParDef("EmployeeFirstName",GXType.Char,100,0) ,
        new ParDef("EmployeeLastName",GXType.Char,100,0) ,
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeIsManager",GXType.Boolean,4,0) ,
        new ParDef("EmployeeIsActive",GXType.Boolean,4,0) ,
        new ParDef("EmployeeVactionDays",GXType.Int16,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000F15;
        prmT000F15 = new Object[] {
        };
        Object[] prmT000F16;
        prmT000F16 = new Object[] {
        new ParDef("EmployeeName",GXType.Char,100,0) ,
        new ParDef("GAMUserGUID",GXType.VarChar,100,60) ,
        new ParDef("EmployeeBalance",GXType.Int16,4,0) ,
        new ParDef("EmployeeFirstName",GXType.Char,100,0) ,
        new ParDef("EmployeeLastName",GXType.Char,100,0) ,
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeIsManager",GXType.Boolean,4,0) ,
        new ParDef("EmployeeIsActive",GXType.Boolean,4,0) ,
        new ParDef("EmployeeVactionDays",GXType.Int16,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F17;
        prmT000F17 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F19;
        prmT000F19 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F20;
        prmT000F20 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F21;
        prmT000F21 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F22;
        prmT000F22 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F23;
        prmT000F23 = new Object[] {
        };
        Object[] prmT000F24;
        prmT000F24 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F4;
        prmT000F4 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F25;
        prmT000F25 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F26;
        prmT000F26 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F3;
        prmT000F3 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F2;
        prmT000F2 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F27;
        prmT000F27 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F28;
        prmT000F28 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F30;
        prmT000F30 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F31;
        prmT000F31 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F32;
        prmT000F32 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F33;
        prmT000F33 = new Object[] {
        };
        Object[] prmT000F34;
        prmT000F34 = new Object[] {
        };
        Object[] prmT000F35;
        prmT000F35 = new Object[] {
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F18;
        prmT000F18 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000F29;
        prmT000F29 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000F2", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId  FOR UPDATE OF EmployeeProject NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F3", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F4", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F5", "SELECT EmployeeId, EmployeeName, GAMUserGUID, EmployeeBalance, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, CompanyId FROM Employee WHERE EmployeeId = :EmployeeId  FOR UPDATE OF Employee NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F6", "SELECT EmployeeId, EmployeeName, GAMUserGUID, EmployeeBalance, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, CompanyId FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F7", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F8", "SELECT TM1.EmployeeId, TM1.EmployeeName, TM1.GAMUserGUID, TM1.EmployeeBalance, TM1.EmployeeFirstName, TM1.EmployeeLastName, TM1.EmployeeEmail, T2.CompanyName, TM1.EmployeeIsManager, TM1.EmployeeIsActive, TM1.EmployeeVactionDays, TM1.CompanyId FROM (Employee TM1 INNER JOIN Company T2 ON T2.CompanyId = TM1.CompanyId) WHERE TM1.EmployeeId = :EmployeeId ORDER BY TM1.EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F9", "SELECT EmployeeEmail FROM Employee WHERE (EmployeeEmail = :EmployeeEmail) AND (Not ( EmployeeId = :EmployeeId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F10", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F11", "SELECT EmployeeId FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F12", "SELECT EmployeeId FROM Employee WHERE ( EmployeeId > :EmployeeId) ORDER BY EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F13", "SELECT EmployeeId FROM Employee WHERE ( EmployeeId < :EmployeeId) ORDER BY EmployeeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F14", "SAVEPOINT gxupdate;INSERT INTO Employee(EmployeeName, GAMUserGUID, EmployeeBalance, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, CompanyId) VALUES(:EmployeeName, :GAMUserGUID, :EmployeeBalance, :EmployeeFirstName, :EmployeeLastName, :EmployeeEmail, :EmployeeIsManager, :EmployeeIsActive, :EmployeeVactionDays, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000F14)
           ,new CursorDef("T000F15", "SELECT currval('EmployeeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F16", "SAVEPOINT gxupdate;UPDATE Employee SET EmployeeName=:EmployeeName, GAMUserGUID=:GAMUserGUID, EmployeeBalance=:EmployeeBalance, EmployeeFirstName=:EmployeeFirstName, EmployeeLastName=:EmployeeLastName, EmployeeEmail=:EmployeeEmail, EmployeeIsManager=:EmployeeIsManager, EmployeeIsActive=:EmployeeIsActive, EmployeeVactionDays=:EmployeeVactionDays, CompanyId=:CompanyId  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F16)
           ,new CursorDef("T000F17", "SAVEPOINT gxupdate;DELETE FROM Employee  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F17)
           ,new CursorDef("T000F18", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F19", "SELECT ProjectId FROM Project WHERE ProjectManagerId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F20", "SELECT SupportRequestId FROM SupportRequest WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F21", "SELECT LeaveRequestId FROM LeaveRequest WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F22", "SELECT WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F23", "SELECT EmployeeId FROM Employee ORDER BY EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F23,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F24", "SELECT T1.EmployeeId, T2.ProjectName, T1.ProjectId FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE T1.EmployeeId = :EmployeeId and T1.ProjectId = :ProjectId ORDER BY T1.EmployeeId, T1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F24,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F25", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F26", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F27", "SAVEPOINT gxupdate;INSERT INTO EmployeeProject(EmployeeId, ProjectId) VALUES(:EmployeeId, :ProjectId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000F27)
           ,new CursorDef("T000F28", "SAVEPOINT gxupdate;DELETE FROM EmployeeProject  WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F28)
           ,new CursorDef("T000F29", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F30", "SELECT ProjectId FROM Project WHERE ProjectManagerId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F31", "SELECT WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F32", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId, ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F32,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F33", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F33,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F34", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F34,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F35", "SELECT EmployeeEmail FROM Employee WHERE (EmployeeEmail = :EmployeeEmail) AND (Not ( EmployeeId = :EmployeeId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F35,1, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
