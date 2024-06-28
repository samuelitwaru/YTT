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
   public class leaverequest : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LEAVETYPEID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLALEAVETYPEID0J21( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"EMPLOYEEID") == 0 )
         {
            AV17EmployeeCompany = (short)(Math.Round(NumberUtil.Val( GetPar( "EmployeeCompany"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17EmployeeCompany", StringUtil.LTrimStr( (decimal)(AV17EmployeeCompany), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAEMPLOYEEID0J21( AV17EmployeeCompany) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"LEAVEREQUESTDURATION") == 0 )
         {
            A129LeaveRequestStartDate = context.localUtil.ParseDateParm( GetPar( "LeaveRequestStartDate"));
            AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
            A130LeaveRequestEndDate = context.localUtil.ParseDateParm( GetPar( "LeaveRequestEndDate"));
            AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
            A173LeaveRequestHalfDay = GetPar( "LeaveRequestHalfDay");
            n173LeaveRequestHalfDay = false;
            AssignAttri("", false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX13ASALEAVEREQUESTDURATION0J21( A129LeaveRequestStartDate, A130LeaveRequestEndDate, A173LeaveRequestHalfDay) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel14"+"_"+"vCHECKEMPLOYEEONLEAVE") == 0 )
         {
            AV10checking = StringUtil.StrToBool( GetPar( "checking"));
            AssignAttri("", false, "AV10checking", AV10checking);
            A129LeaveRequestStartDate = context.localUtil.ParseDateParm( GetPar( "LeaveRequestStartDate"));
            AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX14ASACHECKEMPLOYEEONLEAVE0J21( AV10checking, A129LeaveRequestStartDate, A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_35") == 0 )
         {
            A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveTypeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_35( A124LeaveTypeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_36") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_36( A106EmployeeId) ;
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
               AV26LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV26LeaveRequestId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26LeaveRequestId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Leave Request", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynLeaveTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public leaverequest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequest( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_LeaveRequestId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV26LeaveRequestId = aP1_LeaveRequestId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynLeaveTypeId = new GXCombobox();
         dynEmployeeId = new GXCombobox();
         radLeaveRequestHalfDay = new GXRadio();
         cmbLeaveRequestStatus = new GXCombobox();
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
            return "leaverequest_Execute" ;
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
         if ( dynLeaveTypeId.ItemCount > 0 )
         {
            A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( dynLeaveTypeId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLeaveTypeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0));
            AssignProp("", false, dynLeaveTypeId_Internalname, "Values", dynLeaveTypeId.ToJavascriptSource(), true);
         }
         if ( dynEmployeeId.ItemCount > 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( dynEmployeeId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEmployeeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AssignProp("", false, dynEmployeeId_Internalname, "Values", dynEmployeeId.ToJavascriptSource(), true);
         }
         A173LeaveRequestHalfDay = StringUtil.RTrim( A173LeaveRequestHalfDay);
         n173LeaveRequestHalfDay = false;
         AssignAttri("", false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
         if ( cmbLeaveRequestStatus.ItemCount > 0 )
         {
            A132LeaveRequestStatus = cmbLeaveRequestStatus.getValidValue(A132LeaveRequestStatus);
            AssignAttri("", false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbLeaveRequestStatus.CurrentValue = StringUtil.RTrim( A132LeaveRequestStatus);
            AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Values", cmbLeaveRequestStatus.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_div_start( context, divNewtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3 hidden-xs hidden-sm", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleft_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "start", "top", "", "", "div");
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
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock_Internalname, lblTextblock_Caption, "", "", lblTextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "TextBlock AttributeSizeLarge", 0, "", 1, 1, 0, 0, "HLP_LeaveRequest.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynLeaveTypeId, dynLeaveTypeId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0)), 1, dynLeaveTypeId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynLeaveTypeId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_LeaveRequest.htm");
         dynLeaveTypeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0));
         AssignProp("", false, dynLeaveTypeId_Internalname, "Values", (string)(dynLeaveTypeId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynEmployeeId, dynEmployeeId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0)), 1, dynEmployeeId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynEmployeeId.Visible, dynEmployeeId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_LeaveRequest.htm");
         dynEmployeeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
         AssignProp("", false, dynEmployeeId_Internalname, "Values", (string)(dynEmployeeId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestStartDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveRequestStartDate_Internalname, "Start Date", " AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLeaveRequestStartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLeaveRequestStartDate_Internalname, context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"), context.localUtil.Format( A129LeaveRequestStartDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestStartDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtLeaveRequestStartDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequest.htm");
         GxWebStd.gx_bitmap( context, edtLeaveRequestStartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLeaveRequestStartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequest.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestEndDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveRequestEndDate_Internalname, "End Date", " AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLeaveRequestEndDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLeaveRequestEndDate_Internalname, context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"), context.localUtil.Format( A130LeaveRequestEndDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestEndDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtLeaveRequestEndDate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequest.htm");
         GxWebStd.gx_bitmap( context, edtLeaveRequestEndDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLeaveRequestEndDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequest.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_radio_ctrl( context, radLeaveRequestHalfDay, radLeaveRequestHalfDay_Internalname, StringUtil.RTrim( A173LeaveRequestHalfDay), "", 1, radLeaveRequestHalfDay.Enabled, 0, 0, StyleString, ClassString, "", "", 5, radLeaveRequestHalfDay_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELEAVEREQUESTHALFDAY.CLICK."+"'", TempTags+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "HLP_LeaveRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequestduration_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavLeaverequestduration_Internalname, "Leave Duration", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavLeaverequestduration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV35LeaveRequestDuration, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequestduration_Enabled!=0) ? context.localUtil.Format( AV35LeaveRequestDuration, "Z9.9") : context.localUtil.Format( AV35LeaveRequestDuration, "Z9.9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequestduration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequestduration_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveRequestDescription_Internalname, "Leave Description", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtLeaveRequestDescription_Internalname, A133LeaveRequestDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", 0, 1, edtLeaveRequestDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LeaveRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3 hidden-xs hidden-sm", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableright_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLeaveRequestId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")), StringUtil.LTrim( ((edtLeaveRequestId_Enabled!=0) ? context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestId_Jsonclick, 0, "Attribute", "", "", "", "", edtLeaveRequestId_Visible, edtLeaveRequestId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LeaveRequest.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLeaveRequestDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLeaveRequestDate_Internalname, context.localUtil.Format(A128LeaveRequestDate, "99/99/99"), context.localUtil.Format( A128LeaveRequestDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestDate_Jsonclick, 0, "Attribute", "", "", "", "", edtLeaveRequestDate_Visible, edtLeaveRequestDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequest.htm");
         GxWebStd.gx_bitmap( context, edtLeaveRequestDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtLeaveRequestDate_Visible==0)||(edtLeaveRequestDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequest.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLeaveRequestDuration_Internalname, StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")), StringUtil.LTrim( ((edtLeaveRequestDuration_Enabled!=0) ? context.localUtil.Format( A131LeaveRequestDuration, "Z9.9") : context.localUtil.Format( A131LeaveRequestDuration, "Z9.9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestDuration_Jsonclick, 0, "Attribute", "", "", "", "", edtLeaveRequestDuration_Visible, edtLeaveRequestDuration_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequest.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbLeaveRequestStatus, cmbLeaveRequestStatus_Internalname, StringUtil.RTrim( A132LeaveRequestStatus), 1, cmbLeaveRequestStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbLeaveRequestStatus.Visible, cmbLeaveRequestStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_LeaveRequest.htm");
         cmbLeaveRequestStatus.CurrentValue = StringUtil.RTrim( A132LeaveRequestStatus);
         AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Values", (string)(cmbLeaveRequestStatus.ToJavascriptSource()), true);
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtLeaveRequestRejectionReason_Internalname, A134LeaveRequestRejectionReason, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", 0, edtLeaveRequestRejectionReason_Visible, edtLeaveRequestRejectionReason_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LeaveRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z127LeaveRequestId"), ".", ","), 18, MidpointRounding.ToEven));
               Z131LeaveRequestDuration = context.localUtil.CToN( cgiGet( "Z131LeaveRequestDuration"), ".", ",");
               Z130LeaveRequestEndDate = context.localUtil.CToD( cgiGet( "Z130LeaveRequestEndDate"), 0);
               Z128LeaveRequestDate = context.localUtil.CToD( cgiGet( "Z128LeaveRequestDate"), 0);
               Z129LeaveRequestStartDate = context.localUtil.CToD( cgiGet( "Z129LeaveRequestStartDate"), 0);
               Z173LeaveRequestHalfDay = cgiGet( "Z173LeaveRequestHalfDay");
               n173LeaveRequestHalfDay = (String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveRequestHalfDay)) ? true : false);
               Z132LeaveRequestStatus = cgiGet( "Z132LeaveRequestStatus");
               Z133LeaveRequestDescription = cgiGet( "Z133LeaveRequestDescription");
               Z134LeaveRequestRejectionReason = cgiGet( "Z134LeaveRequestRejectionReason");
               Z124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z124LeaveTypeId"), ".", ","), 18, MidpointRounding.ToEven));
               Z106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N124LeaveTypeId"), ".", ","), 18, MidpointRounding.ToEven));
               N106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               N130LeaveRequestEndDate = context.localUtil.CToD( cgiGet( "N130LeaveRequestEndDate"), 0);
               AV26LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vLEAVEREQUESTID"), ".", ","), 18, MidpointRounding.ToEven));
               AV24Insert_LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_LEAVETYPEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV23Insert_EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_EMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV18EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV10checking = StringUtil.StrToBool( cgiGet( "vCHECKING"));
               AV33CheckEmployeeOnLeave = StringUtil.StrToBool( cgiGet( "vCHECKEMPLOYEEONLEAVE"));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               AV17EmployeeCompany = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPLOYEECOMPANY"), ".", ","), 18, MidpointRounding.ToEven));
               A144LeaveTypeVacationLeave = cgiGet( "LEAVETYPEVACATIONLEAVE");
               A125LeaveTypeName = cgiGet( "LEAVETYPENAME");
               A148EmployeeName = cgiGet( "EMPLOYEENAME");
               A147EmployeeBalance = (short)(Math.Round(context.localUtil.CToN( cgiGet( "EMPLOYEEBALANCE"), ".", ","), 18, MidpointRounding.ToEven));
               AV40Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               dynLeaveTypeId.CurrentValue = cgiGet( dynLeaveTypeId_Internalname);
               A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynLeaveTypeId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
               dynEmployeeId.CurrentValue = cgiGet( dynEmployeeId_Internalname);
               A106EmployeeId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynEmployeeId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               if ( context.localUtil.VCDate( cgiGet( edtLeaveRequestStartDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Start Date"}), 1, "LEAVEREQUESTSTARTDATE");
                  AnyError = 1;
                  GX_FocusControl = edtLeaveRequestStartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A129LeaveRequestStartDate = DateTime.MinValue;
                  AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
               }
               else
               {
                  A129LeaveRequestStartDate = context.localUtil.CToD( cgiGet( edtLeaveRequestStartDate_Internalname), 1);
                  AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtLeaveRequestEndDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request End Date"}), 1, "LEAVEREQUESTENDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtLeaveRequestEndDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A130LeaveRequestEndDate = DateTime.MinValue;
                  AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
               }
               else
               {
                  A130LeaveRequestEndDate = context.localUtil.CToD( cgiGet( edtLeaveRequestEndDate_Internalname), 1);
                  AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
               }
               A173LeaveRequestHalfDay = cgiGet( radLeaveRequestHalfDay_Internalname);
               n173LeaveRequestHalfDay = false;
               AssignAttri("", false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
               n173LeaveRequestHalfDay = (String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveRequestHalfDay)) ? true : false);
               AV35LeaveRequestDuration = context.localUtil.CToN( cgiGet( edtavLeaverequestduration_Internalname), ".", ",");
               AssignAttri("", false, "AV35LeaveRequestDuration", StringUtil.LTrimStr( AV35LeaveRequestDuration, 4, 1));
               A133LeaveRequestDescription = cgiGet( edtLeaveRequestDescription_Internalname);
               AssignAttri("", false, "A133LeaveRequestDescription", A133LeaveRequestDescription);
               A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
               if ( context.localUtil.VCDate( cgiGet( edtLeaveRequestDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Date"}), 1, "LEAVEREQUESTDATE");
                  AnyError = 1;
                  GX_FocusControl = edtLeaveRequestDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A128LeaveRequestDate = DateTime.MinValue;
                  AssignAttri("", false, "A128LeaveRequestDate", context.localUtil.Format(A128LeaveRequestDate, "99/99/99"));
               }
               else
               {
                  A128LeaveRequestDate = context.localUtil.CToD( cgiGet( edtLeaveRequestDate_Internalname), 1);
                  AssignAttri("", false, "A128LeaveRequestDate", context.localUtil.Format(A128LeaveRequestDate, "99/99/99"));
               }
               A131LeaveRequestDuration = context.localUtil.CToN( cgiGet( edtLeaveRequestDuration_Internalname), ".", ",");
               AssignAttri("", false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
               cmbLeaveRequestStatus.CurrentValue = cgiGet( cmbLeaveRequestStatus_Internalname);
               A132LeaveRequestStatus = cgiGet( cmbLeaveRequestStatus_Internalname);
               AssignAttri("", false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
               A134LeaveRequestRejectionReason = cgiGet( edtLeaveRequestRejectionReason_Internalname);
               AssignAttri("", false, "A134LeaveRequestRejectionReason", A134LeaveRequestRejectionReason);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"LeaveRequest");
               A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
               forbiddenHiddens.Add("LeaveRequestId", context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A127LeaveRequestId != Z127LeaveRequestId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("leaverequest:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A127LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
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
                     sMode21 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode21;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound21 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LEAVEREQUESTID");
                        AnyError = 1;
                        GX_FocusControl = edtLeaveRequestId_Internalname;
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
                           E110J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUESTENDDATE.CONTROLVALUECHANGED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E130J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E140J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "EMPLOYEEID.CONTROLVALUECHANGED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E150J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUESTHALFDAY.CLICK") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E160J2 ();
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
            E120J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0J21( ) ;
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
            DisableAttributes0J21( ) ;
         }
         AssignProp("", false, edtavLeaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequestduration_Enabled), 5, 0), true);
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J21( ) ;
            }
            else
            {
               CheckExtendedTable0J21( ) ;
               CloseExtendedTableCursors0J21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0J0( )
      {
      }

      protected void E110J2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_decimal1 = AV35LeaveRequestDuration;
            new getleaverequestduration(context ).execute(  AV26LeaveRequestId, out  GXt_decimal1) ;
            AV35LeaveRequestDuration = GXt_decimal1;
            AssignAttri("", false, "AV35LeaveRequestDuration", StringUtil.LTrimStr( AV35LeaveRequestDuration, 4, 1));
         }
         GXt_int2 = AV17EmployeeCompany;
         new getloggedinusercompanyid(context ).execute( out  GXt_int2) ;
         AV17EmployeeCompany = (short)(GXt_int2);
         AssignAttri("", false, "AV17EmployeeCompany", StringUtil.LTrimStr( (decimal)(AV17EmployeeCompany), 4, 0));
         GXt_int2 = AV18EmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int2) ;
         AV18EmployeeId = GXt_int2;
         AssignAttri("", false, "AV18EmployeeId", StringUtil.LTrimStr( (decimal)(AV18EmployeeId), 10, 0));
         AV10checking = AV9GAMUser.checkrole("Manager");
         AssignAttri("", false, "AV10checking", AV10checking);
         GXt_int3 = AV20EmployyeeAvailableVacationDays;
         new getemployeevactiondaysleft(context ).execute(  AV18EmployeeId, out  GXt_int3) ;
         AV20EmployyeeAvailableVacationDays = GXt_int3;
         AssignAttri("", false, "AV20EmployyeeAvailableVacationDays", StringUtil.LTrimStr( (decimal)(AV20EmployyeeAvailableVacationDays), 4, 0));
         lblTextblock_Caption = "Vacation Days: "+StringUtil.Str( (decimal)(AV20EmployyeeAvailableVacationDays), 4, 0);
         AssignProp("", false, lblTextblock_Internalname, "Caption", lblTextblock_Caption, true);
         lblTextblock_Fontbold = 1;
         AssignProp("", false, lblTextblock_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock_Fontbold), 1, 0), true);
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV32WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29TrnContext.FromXml(AV31WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV29TrnContext.gxTpr_Transactionname, AV40Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV41GXV1 = 1;
            AssignAttri("", false, "AV41GXV1", StringUtil.LTrimStr( (decimal)(AV41GXV1), 8, 0));
            while ( AV41GXV1 <= AV29TrnContext.gxTpr_Attributes.Count )
            {
               AV30TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV29TrnContext.gxTpr_Attributes.Item(AV41GXV1));
               if ( StringUtil.StrCmp(AV30TrnContextAtt.gxTpr_Attributename, "LeaveTypeId") == 0 )
               {
                  AV24Insert_LeaveTypeId = (long)(Math.Round(NumberUtil.Val( AV30TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24Insert_LeaveTypeId", StringUtil.LTrimStr( (decimal)(AV24Insert_LeaveTypeId), 10, 0));
               }
               else if ( StringUtil.StrCmp(AV30TrnContextAtt.gxTpr_Attributename, "EmployeeId") == 0 )
               {
                  AV23Insert_EmployeeId = (long)(Math.Round(NumberUtil.Val( AV30TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV23Insert_EmployeeId", StringUtil.LTrimStr( (decimal)(AV23Insert_EmployeeId), 10, 0));
               }
               AV41GXV1 = (int)(AV41GXV1+1);
               AssignAttri("", false, "AV41GXV1", StringUtil.LTrimStr( (decimal)(AV41GXV1), 8, 0));
            }
         }
         edtLeaveRequestId_Visible = 0;
         AssignProp("", false, edtLeaveRequestId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestId_Visible), 5, 0), true);
         edtLeaveRequestDate_Visible = 0;
         AssignProp("", false, edtLeaveRequestDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDate_Visible), 5, 0), true);
         edtLeaveRequestDuration_Visible = 0;
         AssignProp("", false, edtLeaveRequestDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Visible), 5, 0), true);
         cmbLeaveRequestStatus.Visible = 0;
         AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbLeaveRequestStatus.Visible), 5, 0), true);
         edtLeaveRequestRejectionReason_Visible = 0;
         AssignProp("", false, edtLeaveRequestRejectionReason_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestRejectionReason_Visible), 5, 0), true);
      }

      protected void E120J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 ) )
         {
            new sdsendleaverequestmail(context).executeSubmit(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A133LeaveRequestDescription,  A125LeaveTypeName,  A148EmployeeName,  A106EmployeeId) ;
            AV37Mesage = "Leave Request successful";
            CallWebObject(formatLink("leaverequestww.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV37Mesage))}, new string[] {"Mesage"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) && ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 ) )
         {
            new sendleaveupdatetmail(context).executeSubmit(  A127LeaveRequestId) ;
            AV37Mesage = "Leave Request update successful";
            CallWebObject(formatLink("leaverequestww.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV37Mesage))}, new string[] {"Mesage"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV29TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("leaverequestww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
         dynEmployeeId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
         AssignProp("", false, dynEmployeeId_Internalname, "Values", dynEmployeeId.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         dynEmployeeId.Visible = 0;
         AssignProp("", false, dynEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Visible), 5, 0), true);
         divEmployeeid_cell_Class = "Invisible";
         AssignProp("", false, divEmployeeid_cell_Internalname, "Class", divEmployeeid_cell_Class, true);
      }

      protected void E130J2( )
      {
         /* LeaveRequestEndDate_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_decimal1 = AV35LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay, out  GXt_decimal1) ;
         AV35LeaveRequestDuration = GXt_decimal1;
         AssignAttri("", false, "AV35LeaveRequestDuration", StringUtil.LTrimStr( AV35LeaveRequestDuration, 4, 1));
         /*  Sending Event outputs  */
      }

      protected void E140J2( )
      {
         /* LeaveRequestStartDate_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_decimal1 = AV35LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay, out  GXt_decimal1) ;
         AV35LeaveRequestDuration = GXt_decimal1;
         AssignAttri("", false, "AV35LeaveRequestDuration", StringUtil.LTrimStr( AV35LeaveRequestDuration, 4, 1));
         /*  Sending Event outputs  */
      }

      protected void E150J2( )
      {
         /* EmployeeId_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_int3 = AV20EmployyeeAvailableVacationDays;
         new getemployeevactiondaysleft(context ).execute(  A106EmployeeId, out  GXt_int3) ;
         AV20EmployyeeAvailableVacationDays = GXt_int3;
         AssignAttri("", false, "AV20EmployyeeAvailableVacationDays", StringUtil.LTrimStr( (decimal)(AV20EmployyeeAvailableVacationDays), 4, 0));
         lblTextblock_Caption = "Vacation Days: "+StringUtil.Str( (decimal)(AV20EmployyeeAvailableVacationDays), 4, 0);
         AssignProp("", false, lblTextblock_Internalname, "Caption", lblTextblock_Caption, true);
         lblTextblock_Fontbold = 1;
         AssignProp("", false, lblTextblock_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock_Fontbold), 1, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E160J2( )
      {
         /* LeaveRequestHalfDay_Click Routine */
         returnInSub = false;
         GXt_decimal1 = AV35LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay, out  GXt_decimal1) ;
         AV35LeaveRequestDuration = GXt_decimal1;
         AssignAttri("", false, "AV35LeaveRequestDuration", StringUtil.LTrimStr( AV35LeaveRequestDuration, 4, 1));
         /*  Sending Event outputs  */
      }

      protected void ZM0J21( short GX_JID )
      {
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z131LeaveRequestDuration = T000J3_A131LeaveRequestDuration[0];
               Z130LeaveRequestEndDate = T000J3_A130LeaveRequestEndDate[0];
               Z128LeaveRequestDate = T000J3_A128LeaveRequestDate[0];
               Z129LeaveRequestStartDate = T000J3_A129LeaveRequestStartDate[0];
               Z173LeaveRequestHalfDay = T000J3_A173LeaveRequestHalfDay[0];
               Z132LeaveRequestStatus = T000J3_A132LeaveRequestStatus[0];
               Z133LeaveRequestDescription = T000J3_A133LeaveRequestDescription[0];
               Z134LeaveRequestRejectionReason = T000J3_A134LeaveRequestRejectionReason[0];
               Z124LeaveTypeId = T000J3_A124LeaveTypeId[0];
               Z106EmployeeId = T000J3_A106EmployeeId[0];
            }
            else
            {
               Z131LeaveRequestDuration = A131LeaveRequestDuration;
               Z130LeaveRequestEndDate = A130LeaveRequestEndDate;
               Z128LeaveRequestDate = A128LeaveRequestDate;
               Z129LeaveRequestStartDate = A129LeaveRequestStartDate;
               Z173LeaveRequestHalfDay = A173LeaveRequestHalfDay;
               Z132LeaveRequestStatus = A132LeaveRequestStatus;
               Z133LeaveRequestDescription = A133LeaveRequestDescription;
               Z134LeaveRequestRejectionReason = A134LeaveRequestRejectionReason;
               Z124LeaveTypeId = A124LeaveTypeId;
               Z106EmployeeId = A106EmployeeId;
            }
         }
         if ( GX_JID == -34 )
         {
            Z127LeaveRequestId = A127LeaveRequestId;
            Z131LeaveRequestDuration = A131LeaveRequestDuration;
            Z130LeaveRequestEndDate = A130LeaveRequestEndDate;
            Z128LeaveRequestDate = A128LeaveRequestDate;
            Z129LeaveRequestStartDate = A129LeaveRequestStartDate;
            Z173LeaveRequestHalfDay = A173LeaveRequestHalfDay;
            Z132LeaveRequestStatus = A132LeaveRequestStatus;
            Z133LeaveRequestDescription = A133LeaveRequestDescription;
            Z134LeaveRequestRejectionReason = A134LeaveRequestRejectionReason;
            Z124LeaveTypeId = A124LeaveTypeId;
            Z106EmployeeId = A106EmployeeId;
            Z125LeaveTypeName = A125LeaveTypeName;
            Z144LeaveTypeVacationLeave = A144LeaveTypeVacationLeave;
            Z148EmployeeName = A148EmployeeName;
            Z147EmployeeBalance = A147EmployeeBalance;
         }
      }

      protected void standaloneNotModal( )
      {
         GXALEAVETYPEID_html0J21( ) ;
         edtLeaveRequestDuration_Enabled = 0;
         AssignProp("", false, edtLeaveRequestDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Enabled), 5, 0), true);
         edtLeaveRequestId_Enabled = 0;
         AssignProp("", false, edtLeaveRequestId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestId_Enabled), 5, 0), true);
         AV40Pgmname = "LeaveRequest";
         AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtLeaveRequestDuration_Enabled = 0;
         AssignProp("", false, edtLeaveRequestDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Enabled), 5, 0), true);
         edtLeaveRequestId_Enabled = 0;
         AssignProp("", false, edtLeaveRequestId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV26LeaveRequestId) )
         {
            A127LeaveRequestId = AV26LeaveRequestId;
            AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
         }
         dynEmployeeId.Visible = ((AV10checking) ? 1 : 0);
         AssignProp("", false, dynEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Visible), 5, 0), true);
         if ( ! ( ( AV10checking ) ) )
         {
            divEmployeeid_cell_Class = "Invisible";
            AssignProp("", false, divEmployeeid_cell_Internalname, "Class", divEmployeeid_cell_Class, true);
         }
         else
         {
            if ( AV10checking )
            {
               divEmployeeid_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
               AssignProp("", false, divEmployeeid_cell_Internalname, "Class", divEmployeeid_cell_Class, true);
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_LeaveTypeId) )
         {
            dynLeaveTypeId.Enabled = 0;
            AssignProp("", false, dynLeaveTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLeaveTypeId.Enabled), 5, 0), true);
         }
         else
         {
            dynLeaveTypeId.Enabled = 1;
            AssignProp("", false, dynLeaveTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLeaveTypeId.Enabled), 5, 0), true);
         }
         GXAEMPLOYEEID_html0J21( AV17EmployeeCompany) ;
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            dynEmployeeId.Enabled = 0;
            AssignProp("", false, dynEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_EmployeeId) )
         {
            dynEmployeeId.Enabled = 0;
            AssignProp("", false, dynEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Enabled), 5, 0), true);
         }
         else
         {
            if ( IsUpd( )  )
            {
               dynEmployeeId.Enabled = 0;
               AssignProp("", false, dynEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Enabled), 5, 0), true);
            }
            else
            {
               dynEmployeeId.Enabled = 1;
               AssignProp("", false, dynEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Enabled), 5, 0), true);
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_LeaveTypeId) )
         {
            A124LeaveTypeId = AV24Insert_LeaveTypeId;
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
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
         A128LeaveRequestDate = Gx_date;
         AssignAttri("", false, "A128LeaveRequestDate", context.localUtil.Format(A128LeaveRequestDate, "99/99/99"));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_EmployeeId) )
         {
            A106EmployeeId = AV23Insert_EmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A106EmployeeId) && ( Gx_BScreen == 0 ) )
            {
               A106EmployeeId = AV18EmployeeId;
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            }
         }
         if ( IsIns( )  && (DateTime.MinValue==A129LeaveRequestStartDate) && ( Gx_BScreen == 0 ) )
         {
            A129LeaveRequestStartDate = Gx_date;
            AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000J4 */
            pr_default.execute(2, new Object[] {A124LeaveTypeId});
            A125LeaveTypeName = T000J4_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = T000J4_A144LeaveTypeVacationLeave[0];
            pr_default.close(2);
            /* Using cursor T000J5 */
            pr_default.execute(3, new Object[] {A106EmployeeId});
            A148EmployeeName = T000J5_A148EmployeeName[0];
            A147EmployeeBalance = T000J5_A147EmployeeBalance[0];
            pr_default.close(3);
            if ( ! AV10checking )
            {
               GXt_boolean4 = AV33CheckEmployeeOnLeave;
               new checkemployeeonleave(context ).execute(  A129LeaveRequestStartDate,  A106EmployeeId, out  GXt_boolean4) ;
               AV33CheckEmployeeOnLeave = GXt_boolean4;
               AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
            }
            else
            {
               if ( AV10checking )
               {
                  AV33CheckEmployeeOnLeave = false;
                  AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
               }
            }
         }
      }

      protected void Load0J21( )
      {
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound21 = 1;
            A131LeaveRequestDuration = T000J6_A131LeaveRequestDuration[0];
            AssignAttri("", false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
            A130LeaveRequestEndDate = T000J6_A130LeaveRequestEndDate[0];
            AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
            A125LeaveTypeName = T000J6_A125LeaveTypeName[0];
            A128LeaveRequestDate = T000J6_A128LeaveRequestDate[0];
            AssignAttri("", false, "A128LeaveRequestDate", context.localUtil.Format(A128LeaveRequestDate, "99/99/99"));
            A129LeaveRequestStartDate = T000J6_A129LeaveRequestStartDate[0];
            AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
            A173LeaveRequestHalfDay = T000J6_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = T000J6_n173LeaveRequestHalfDay[0];
            AssignAttri("", false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
            A132LeaveRequestStatus = T000J6_A132LeaveRequestStatus[0];
            AssignAttri("", false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
            A133LeaveRequestDescription = T000J6_A133LeaveRequestDescription[0];
            AssignAttri("", false, "A133LeaveRequestDescription", A133LeaveRequestDescription);
            A134LeaveRequestRejectionReason = T000J6_A134LeaveRequestRejectionReason[0];
            AssignAttri("", false, "A134LeaveRequestRejectionReason", A134LeaveRequestRejectionReason);
            A148EmployeeName = T000J6_A148EmployeeName[0];
            A147EmployeeBalance = T000J6_A147EmployeeBalance[0];
            A144LeaveTypeVacationLeave = T000J6_A144LeaveTypeVacationLeave[0];
            A124LeaveTypeId = T000J6_A124LeaveTypeId[0];
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
            A106EmployeeId = T000J6_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            ZM0J21( -34) ;
         }
         pr_default.close(4);
         OnLoadActions0J21( ) ;
      }

      protected void OnLoadActions0J21( )
      {
         if ( ! AV10checking )
         {
            GXt_boolean4 = AV33CheckEmployeeOnLeave;
            new checkemployeeonleave(context ).execute(  A129LeaveRequestStartDate,  A106EmployeeId, out  GXt_boolean4) ;
            AV33CheckEmployeeOnLeave = GXt_boolean4;
            AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
         }
         else
         {
            if ( AV10checking )
            {
               AV33CheckEmployeeOnLeave = false;
               AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
            }
         }
         if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "") != 0 )
         {
            edtLeaveRequestEndDate_Enabled = 0;
            AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
         }
         else
         {
            edtLeaveRequestEndDate_Enabled = 1;
            AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (DateTime.MinValue==A130LeaveRequestEndDate) && ( Gx_BScreen == 0 ) )
         {
            A130LeaveRequestEndDate = Gx_date;
            AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
         }
         else
         {
            if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "") != 0 )
            {
               A130LeaveRequestEndDate = A129LeaveRequestStartDate;
               AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
            }
         }
         GXt_decimal1 = A131LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay, out  GXt_decimal1) ;
         A131LeaveRequestDuration = GXt_decimal1;
         AssignAttri("", false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
      }

      protected void CheckExtendedTable0J21( )
      {
         nIsDirty_21 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! AV10checking )
         {
            GXt_boolean4 = AV33CheckEmployeeOnLeave;
            new checkemployeeonleave(context ).execute(  A129LeaveRequestStartDate,  A106EmployeeId, out  GXt_boolean4) ;
            AV33CheckEmployeeOnLeave = GXt_boolean4;
            AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
         }
         else
         {
            if ( AV10checking )
            {
               AV33CheckEmployeeOnLeave = false;
               AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
            }
         }
         if ( ! (DateTime.MinValue==A129LeaveRequestStartDate) && AV33CheckEmployeeOnLeave )
         {
            GX_msglist.addItem("You are already on leave", 1, "LEAVEREQUESTSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestStartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'LeaveType'.", "ForeignKeyNotFound", 1, "LEAVETYPEID");
            AnyError = 1;
            GX_FocusControl = dynLeaveTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A125LeaveTypeName = T000J4_A125LeaveTypeName[0];
         A144LeaveTypeVacationLeave = T000J4_A144LeaveTypeVacationLeave[0];
         pr_default.close(2);
         if ( (DateTime.MinValue==A129LeaveRequestStartDate) )
         {
            GX_msglist.addItem("Start date is required", 1, "LEAVEREQUESTSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestStartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! new checkleaverequesttimevalide(context).executeUdp(  A129LeaveRequestStartDate,  A173LeaveRequestHalfDay) && IsIns( )  )
         {
            GX_msglist.addItem("Request not permitted for this time", 1, "LEAVEREQUESTSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestStartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "") != 0 )
         {
            edtLeaveRequestEndDate_Enabled = 0;
            AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
         }
         else
         {
            edtLeaveRequestEndDate_Enabled = 1;
            AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 ) || ( StringUtil.StrCmp(A132LeaveRequestStatus, "Approved") == 0 ) || ( StringUtil.StrCmp(A132LeaveRequestStatus, "Rejected") == 0 ) ) )
         {
            GX_msglist.addItem("Field Leave Request Status is out of range", "OutOfRange", 1, "LEAVEREQUESTSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbLeaveRequestStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A133LeaveRequestDescription)) )
         {
            GX_msglist.addItem("Leave Description is Required", 1, "LEAVEREQUESTDESCRIPTION");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000J5 */
         pr_default.execute(3, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = dynEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A148EmployeeName = T000J5_A148EmployeeName[0];
         A147EmployeeBalance = T000J5_A147EmployeeBalance[0];
         pr_default.close(3);
         if ( IsIns( )  && (DateTime.MinValue==A130LeaveRequestEndDate) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_21 = 1;
            A130LeaveRequestEndDate = Gx_date;
            AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
         }
         else
         {
            if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "") != 0 )
            {
               nIsDirty_21 = 1;
               A130LeaveRequestEndDate = A129LeaveRequestStartDate;
               AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
            }
         }
         if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( Gx_date ) ) && IsIns( )  )
         {
            GX_msglist.addItem("Invalid Leave start date", 1, "LEAVEREQUESTSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestStartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_21 = 1;
         GXt_decimal1 = A131LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay, out  GXt_decimal1) ;
         A131LeaveRequestDuration = GXt_decimal1;
         AssignAttri("", false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
         if ( ! (DateTime.MinValue==A130LeaveRequestEndDate) && ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) < DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) ) )
         {
            GX_msglist.addItem("Invalid Leave end date", 1, "LEAVEREQUESTSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestStartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A130LeaveRequestEndDate) )
         {
            GX_msglist.addItem("End date is required", 1, "LEAVEREQUESTENDDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestEndDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! (Convert.ToDecimal(0)==A131LeaveRequestDuration) && ( A131LeaveRequestDuration > Convert.ToDecimal( new getemployeevactiondaysleft(context).executeUdp(  A106EmployeeId) )) && ( StringUtil.StrCmp(A144LeaveTypeVacationLeave, "Yes") == 0 ) )
         {
            GX_msglist.addItem("Vacation days exceeded.", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = dynEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A131LeaveRequestDuration <= Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Invalid Leave Duration", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0J21( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_35( long A124LeaveTypeId )
      {
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'LeaveType'.", "ForeignKeyNotFound", 1, "LEAVETYPEID");
            AnyError = 1;
            GX_FocusControl = dynLeaveTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A125LeaveTypeName = T000J7_A125LeaveTypeName[0];
         A144LeaveTypeVacationLeave = T000J7_A144LeaveTypeVacationLeave[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A125LeaveTypeName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A144LeaveTypeVacationLeave))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_36( long A106EmployeeId )
      {
         /* Using cursor T000J8 */
         pr_default.execute(6, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = dynEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A148EmployeeName = T000J8_A148EmployeeName[0];
         A147EmployeeBalance = T000J8_A147EmployeeBalance[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A148EmployeeName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A147EmployeeBalance), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0J21( )
      {
         /* Using cursor T000J9 */
         pr_default.execute(7, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J21( 34) ;
            RcdFound21 = 1;
            A127LeaveRequestId = T000J3_A127LeaveRequestId[0];
            AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
            A131LeaveRequestDuration = T000J3_A131LeaveRequestDuration[0];
            AssignAttri("", false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
            A130LeaveRequestEndDate = T000J3_A130LeaveRequestEndDate[0];
            AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
            A128LeaveRequestDate = T000J3_A128LeaveRequestDate[0];
            AssignAttri("", false, "A128LeaveRequestDate", context.localUtil.Format(A128LeaveRequestDate, "99/99/99"));
            A129LeaveRequestStartDate = T000J3_A129LeaveRequestStartDate[0];
            AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
            A173LeaveRequestHalfDay = T000J3_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = T000J3_n173LeaveRequestHalfDay[0];
            AssignAttri("", false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
            A132LeaveRequestStatus = T000J3_A132LeaveRequestStatus[0];
            AssignAttri("", false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
            A133LeaveRequestDescription = T000J3_A133LeaveRequestDescription[0];
            AssignAttri("", false, "A133LeaveRequestDescription", A133LeaveRequestDescription);
            A134LeaveRequestRejectionReason = T000J3_A134LeaveRequestRejectionReason[0];
            AssignAttri("", false, "A134LeaveRequestRejectionReason", A134LeaveRequestRejectionReason);
            A124LeaveTypeId = T000J3_A124LeaveTypeId[0];
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
            A106EmployeeId = T000J3_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            Z127LeaveRequestId = A127LeaveRequestId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0J21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0J21( ) ;
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0J21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J21( ) ;
         if ( RcdFound21 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound21 = 0;
         /* Using cursor T000J10 */
         pr_default.execute(8, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A127LeaveRequestId[0] < A127LeaveRequestId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A127LeaveRequestId[0] > A127LeaveRequestId ) ) )
            {
               A127LeaveRequestId = T000J10_A127LeaveRequestId[0];
               AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound21 = 0;
         /* Using cursor T000J11 */
         pr_default.execute(9, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000J11_A127LeaveRequestId[0] > A127LeaveRequestId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000J11_A127LeaveRequestId[0] < A127LeaveRequestId ) ) )
            {
               A127LeaveRequestId = T000J11_A127LeaveRequestId[0];
               AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynLeaveTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J21( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A127LeaveRequestId != Z127LeaveRequestId )
               {
                  A127LeaveRequestId = Z127LeaveRequestId;
                  AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LEAVEREQUESTID");
                  AnyError = 1;
                  GX_FocusControl = edtLeaveRequestId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynLeaveTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0J21( ) ;
                  GX_FocusControl = dynLeaveTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A127LeaveRequestId != Z127LeaveRequestId )
               {
                  /* Insert record */
                  GX_FocusControl = dynLeaveTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J21( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LEAVEREQUESTID");
                     AnyError = 1;
                     GX_FocusControl = edtLeaveRequestId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynLeaveTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J21( ) ;
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
         if ( A127LeaveRequestId != Z127LeaveRequestId )
         {
            A127LeaveRequestId = Z127LeaveRequestId;
            AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LEAVEREQUESTID");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynLeaveTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0J21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A127LeaveRequestId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveRequest"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z131LeaveRequestDuration != T000J2_A131LeaveRequestDuration[0] ) || ( DateTimeUtil.ResetTime ( Z130LeaveRequestEndDate ) != DateTimeUtil.ResetTime ( T000J2_A130LeaveRequestEndDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z128LeaveRequestDate ) != DateTimeUtil.ResetTime ( T000J2_A128LeaveRequestDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z129LeaveRequestStartDate ) != DateTimeUtil.ResetTime ( T000J2_A129LeaveRequestStartDate[0] ) ) || ( StringUtil.StrCmp(Z173LeaveRequestHalfDay, T000J2_A173LeaveRequestHalfDay[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z132LeaveRequestStatus, T000J2_A132LeaveRequestStatus[0]) != 0 ) || ( StringUtil.StrCmp(Z133LeaveRequestDescription, T000J2_A133LeaveRequestDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z134LeaveRequestRejectionReason, T000J2_A134LeaveRequestRejectionReason[0]) != 0 ) || ( Z124LeaveTypeId != T000J2_A124LeaveTypeId[0] ) || ( Z106EmployeeId != T000J2_A106EmployeeId[0] ) )
            {
               if ( Z131LeaveRequestDuration != T000J2_A131LeaveRequestDuration[0] )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveRequestDuration");
                  GXUtil.WriteLogRaw("Old: ",Z131LeaveRequestDuration);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A131LeaveRequestDuration[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z130LeaveRequestEndDate ) != DateTimeUtil.ResetTime ( T000J2_A130LeaveRequestEndDate[0] ) )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveRequestEndDate");
                  GXUtil.WriteLogRaw("Old: ",Z130LeaveRequestEndDate);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A130LeaveRequestEndDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z128LeaveRequestDate ) != DateTimeUtil.ResetTime ( T000J2_A128LeaveRequestDate[0] ) )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveRequestDate");
                  GXUtil.WriteLogRaw("Old: ",Z128LeaveRequestDate);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A128LeaveRequestDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z129LeaveRequestStartDate ) != DateTimeUtil.ResetTime ( T000J2_A129LeaveRequestStartDate[0] ) )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveRequestStartDate");
                  GXUtil.WriteLogRaw("Old: ",Z129LeaveRequestStartDate);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A129LeaveRequestStartDate[0]);
               }
               if ( StringUtil.StrCmp(Z173LeaveRequestHalfDay, T000J2_A173LeaveRequestHalfDay[0]) != 0 )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveRequestHalfDay");
                  GXUtil.WriteLogRaw("Old: ",Z173LeaveRequestHalfDay);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A173LeaveRequestHalfDay[0]);
               }
               if ( StringUtil.StrCmp(Z132LeaveRequestStatus, T000J2_A132LeaveRequestStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveRequestStatus");
                  GXUtil.WriteLogRaw("Old: ",Z132LeaveRequestStatus);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A132LeaveRequestStatus[0]);
               }
               if ( StringUtil.StrCmp(Z133LeaveRequestDescription, T000J2_A133LeaveRequestDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveRequestDescription");
                  GXUtil.WriteLogRaw("Old: ",Z133LeaveRequestDescription);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A133LeaveRequestDescription[0]);
               }
               if ( StringUtil.StrCmp(Z134LeaveRequestRejectionReason, T000J2_A134LeaveRequestRejectionReason[0]) != 0 )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveRequestRejectionReason");
                  GXUtil.WriteLogRaw("Old: ",Z134LeaveRequestRejectionReason);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A134LeaveRequestRejectionReason[0]);
               }
               if ( Z124LeaveTypeId != T000J2_A124LeaveTypeId[0] )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"LeaveTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z124LeaveTypeId);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A124LeaveTypeId[0]);
               }
               if ( Z106EmployeeId != T000J2_A106EmployeeId[0] )
               {
                  GXUtil.WriteLog("leaverequest:[seudo value changed for attri]"+"EmployeeId");
                  GXUtil.WriteLogRaw("Old: ",Z106EmployeeId);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A106EmployeeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LeaveRequest"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J21( )
      {
         if ( ! IsAuthorized("leaverequest_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J21( 0) ;
            CheckOptimisticConcurrency0J21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J12 */
                     pr_default.execute(10, new Object[] {A131LeaveRequestDuration, A130LeaveRequestEndDate, A128LeaveRequestDate, A129LeaveRequestStartDate, n173LeaveRequestHalfDay, A173LeaveRequestHalfDay, A132LeaveRequestStatus, A133LeaveRequestDescription, A134LeaveRequestRejectionReason, A124LeaveTypeId, A106EmployeeId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000J13 */
                     pr_default.execute(11);
                     A127LeaveRequestId = T000J13_A127LeaveRequestId[0];
                     AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveRequest");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0J0( ) ;
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
               Load0J21( ) ;
            }
            EndLevel0J21( ) ;
         }
         CloseExtendedTableCursors0J21( ) ;
      }

      protected void Update0J21( )
      {
         if ( ! IsAuthorized("leaverequest_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J14 */
                     pr_default.execute(12, new Object[] {A131LeaveRequestDuration, A130LeaveRequestEndDate, A128LeaveRequestDate, A129LeaveRequestStartDate, n173LeaveRequestHalfDay, A173LeaveRequestHalfDay, A132LeaveRequestStatus, A133LeaveRequestDescription, A134LeaveRequestRejectionReason, A124LeaveTypeId, A106EmployeeId, A127LeaveRequestId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveRequest");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveRequest"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J21( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel0J21( ) ;
         }
         CloseExtendedTableCursors0J21( ) ;
      }

      protected void DeferredUpdate0J21( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("leaverequest_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J21( ) ;
            AfterConfirm0J21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J15 */
                  pr_default.execute(13, new Object[] {A127LeaveRequestId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("LeaveRequest");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J21( ) ;
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J21( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( ! new checkleaverequesttimevalide(context).executeUdp(  A129LeaveRequestStartDate,  A173LeaveRequestHalfDay) && IsIns( )  )
            {
               GX_msglist.addItem("Request not permitted for this time", 1, "LEAVEREQUESTSTARTDATE");
               AnyError = 1;
               GX_FocusControl = edtLeaveRequestStartDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( Gx_date ) ) && IsIns( )  )
            {
               GX_msglist.addItem("Invalid Leave start date", 1, "LEAVEREQUESTSTARTDATE");
               AnyError = 1;
               GX_FocusControl = edtLeaveRequestStartDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            /* Using cursor T000J16 */
            pr_default.execute(14, new Object[] {A124LeaveTypeId});
            A125LeaveTypeName = T000J16_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = T000J16_A144LeaveTypeVacationLeave[0];
            pr_default.close(14);
            if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "") != 0 )
            {
               edtLeaveRequestEndDate_Enabled = 0;
               AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
            }
            else
            {
               edtLeaveRequestEndDate_Enabled = 1;
               AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
            }
            /* Using cursor T000J17 */
            pr_default.execute(15, new Object[] {A106EmployeeId});
            A148EmployeeName = T000J17_A148EmployeeName[0];
            A147EmployeeBalance = T000J17_A147EmployeeBalance[0];
            pr_default.close(15);
            if ( ! AV10checking )
            {
               GXt_boolean4 = AV33CheckEmployeeOnLeave;
               new checkemployeeonleave(context ).execute(  A129LeaveRequestStartDate,  A106EmployeeId, out  GXt_boolean4) ;
               AV33CheckEmployeeOnLeave = GXt_boolean4;
               AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
            }
            else
            {
               if ( AV10checking )
               {
                  AV33CheckEmployeeOnLeave = false;
                  AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
               }
            }
         }
      }

      protected void EndLevel0J21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("leaverequest",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("leaverequest",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J21( )
      {
         /* Scan By routine */
         /* Using cursor T000J18 */
         pr_default.execute(16);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound21 = 1;
            A127LeaveRequestId = T000J18_A127LeaveRequestId[0];
            AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J21( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound21 = 1;
            A127LeaveRequestId = T000J18_A127LeaveRequestId[0];
            AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
         }
      }

      protected void ScanEnd0J21( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0J21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J21( )
      {
         dynLeaveTypeId.Enabled = 0;
         AssignProp("", false, dynLeaveTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLeaveTypeId.Enabled), 5, 0), true);
         dynEmployeeId.Enabled = 0;
         AssignProp("", false, dynEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmployeeId.Enabled), 5, 0), true);
         edtLeaveRequestStartDate_Enabled = 0;
         AssignProp("", false, edtLeaveRequestStartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestStartDate_Enabled), 5, 0), true);
         edtLeaveRequestEndDate_Enabled = 0;
         AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
         radLeaveRequestHalfDay.Enabled = 0;
         AssignProp("", false, radLeaveRequestHalfDay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveRequestHalfDay.Enabled), 5, 0), true);
         edtavLeaverequestduration_Enabled = 0;
         AssignProp("", false, edtavLeaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequestduration_Enabled), 5, 0), true);
         edtLeaveRequestDescription_Enabled = 0;
         AssignProp("", false, edtLeaveRequestDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDescription_Enabled), 5, 0), true);
         edtLeaveRequestId_Enabled = 0;
         AssignProp("", false, edtLeaveRequestId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestId_Enabled), 5, 0), true);
         edtLeaveRequestDate_Enabled = 0;
         AssignProp("", false, edtLeaveRequestDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDate_Enabled), 5, 0), true);
         edtLeaveRequestDuration_Enabled = 0;
         AssignProp("", false, edtLeaveRequestDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Enabled), 5, 0), true);
         cmbLeaveRequestStatus.Enabled = 0;
         AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLeaveRequestStatus.Enabled), 5, 0), true);
         edtLeaveRequestRejectionReason_Enabled = 0;
         AssignProp("", false, edtLeaveRequestRejectionReason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestRejectionReason_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0J21( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0J0( )
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leaverequest.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV26LeaveRequestId,10,0))}, new string[] {"Gx_mode","LeaveRequestId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"LeaveRequest");
         forbiddenHiddens.Add("LeaveRequestId", context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("leaverequest:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z127LeaveRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z131LeaveRequestDuration", StringUtil.LTrim( StringUtil.NToC( Z131LeaveRequestDuration, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z130LeaveRequestEndDate", context.localUtil.DToC( Z130LeaveRequestEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z128LeaveRequestDate", context.localUtil.DToC( Z128LeaveRequestDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z129LeaveRequestStartDate", context.localUtil.DToC( Z129LeaveRequestStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z173LeaveRequestHalfDay", StringUtil.RTrim( Z173LeaveRequestHalfDay));
         GxWebStd.gx_hidden_field( context, "Z132LeaveRequestStatus", StringUtil.RTrim( Z132LeaveRequestStatus));
         GxWebStd.gx_hidden_field( context, "Z133LeaveRequestDescription", Z133LeaveRequestDescription);
         GxWebStd.gx_hidden_field( context, "Z134LeaveRequestRejectionReason", Z134LeaveRequestRejectionReason);
         GxWebStd.gx_hidden_field( context, "Z124LeaveTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z124LeaveTypeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N124LeaveTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N130LeaveRequestEndDate", context.localUtil.DToC( A130LeaveRequestEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV29TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV29TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV29TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26LeaveRequestId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_LEAVETYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_LeaveTypeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Insert_EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKING", AV10checking);
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKEMPLOYEEONLEAVE", AV33CheckEmployeeOnLeave);
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEECOMPANY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17EmployeeCompany), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LEAVETYPEVACATIONLEAVE", StringUtil.RTrim( A144LeaveTypeVacationLeave));
         GxWebStd.gx_hidden_field( context, "LEAVETYPENAME", StringUtil.RTrim( A125LeaveTypeName));
         GxWebStd.gx_hidden_field( context, "EMPLOYEENAME", StringUtil.RTrim( A148EmployeeName));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEBALANCE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147EmployeeBalance), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
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
         return formatLink("leaverequest.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV26LeaveRequestId,10,0))}, new string[] {"Gx_mode","LeaveRequestId"})  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveRequest" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Request" ;
      }

      protected void InitializeNonKey0J21( )
      {
         A124LeaveTypeId = 0;
         AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
         A131LeaveRequestDuration = 0;
         AssignAttri("", false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
         AV33CheckEmployeeOnLeave = false;
         AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
         A125LeaveTypeName = "";
         AssignAttri("", false, "A125LeaveTypeName", A125LeaveTypeName);
         A128LeaveRequestDate = DateTime.MinValue;
         AssignAttri("", false, "A128LeaveRequestDate", context.localUtil.Format(A128LeaveRequestDate, "99/99/99"));
         A173LeaveRequestHalfDay = "";
         n173LeaveRequestHalfDay = false;
         AssignAttri("", false, "A173LeaveRequestHalfDay", A173LeaveRequestHalfDay);
         n173LeaveRequestHalfDay = (String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveRequestHalfDay)) ? true : false);
         A132LeaveRequestStatus = "";
         AssignAttri("", false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
         A133LeaveRequestDescription = "";
         AssignAttri("", false, "A133LeaveRequestDescription", A133LeaveRequestDescription);
         A134LeaveRequestRejectionReason = "";
         AssignAttri("", false, "A134LeaveRequestRejectionReason", A134LeaveRequestRejectionReason);
         A148EmployeeName = "";
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         A147EmployeeBalance = 0;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( (decimal)(A147EmployeeBalance), 4, 0));
         A144LeaveTypeVacationLeave = "";
         AssignAttri("", false, "A144LeaveTypeVacationLeave", A144LeaveTypeVacationLeave);
         A106EmployeeId = AV18EmployeeId;
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         A130LeaveRequestEndDate = Gx_date;
         AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
         A129LeaveRequestStartDate = Gx_date;
         AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
         Z131LeaveRequestDuration = 0;
         Z130LeaveRequestEndDate = DateTime.MinValue;
         Z128LeaveRequestDate = DateTime.MinValue;
         Z129LeaveRequestStartDate = DateTime.MinValue;
         Z173LeaveRequestHalfDay = "";
         Z132LeaveRequestStatus = "";
         Z133LeaveRequestDescription = "";
         Z134LeaveRequestRejectionReason = "";
         Z124LeaveTypeId = 0;
         Z106EmployeeId = 0;
      }

      protected void InitAll0J21( )
      {
         A127LeaveRequestId = 0;
         AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
         InitializeNonKey0J21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A106EmployeeId = i106EmployeeId;
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         A129LeaveRequestStartDate = i129LeaveRequestStartDate;
         AssignAttri("", false, "A129LeaveRequestStartDate", context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20246282111754", true, true);
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
         context.AddJavascriptSource("leaverequest.js", "?20246282111756", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divTableleft_Internalname = "TABLELEFT";
         lblTextblock_Internalname = "TEXTBLOCK";
         dynLeaveTypeId_Internalname = "LEAVETYPEID";
         dynEmployeeId_Internalname = "EMPLOYEEID";
         divEmployeeid_cell_Internalname = "EMPLOYEEID_CELL";
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE";
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE";
         radLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY";
         edtavLeaverequestduration_Internalname = "vLEAVEREQUESTDURATION";
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablecontent_Internalname = "TABLECONTENT";
         divTableright_Internalname = "TABLERIGHT";
         divNewtable_Internalname = "NEWTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID";
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE";
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION";
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS";
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Leave Request";
         edtLeaveRequestRejectionReason_Enabled = 1;
         edtLeaveRequestRejectionReason_Visible = 1;
         cmbLeaveRequestStatus_Jsonclick = "";
         cmbLeaveRequestStatus.Visible = 1;
         cmbLeaveRequestStatus.Enabled = 1;
         edtLeaveRequestDuration_Jsonclick = "";
         edtLeaveRequestDuration_Enabled = 0;
         edtLeaveRequestDuration_Visible = 1;
         edtLeaveRequestDate_Jsonclick = "";
         edtLeaveRequestDate_Enabled = 1;
         edtLeaveRequestDate_Visible = 1;
         edtLeaveRequestId_Jsonclick = "";
         edtLeaveRequestId_Enabled = 0;
         edtLeaveRequestId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtLeaveRequestDescription_Enabled = 1;
         edtavLeaverequestduration_Jsonclick = "";
         edtavLeaverequestduration_Enabled = 0;
         radLeaveRequestHalfDay_Jsonclick = "";
         radLeaveRequestHalfDay.Enabled = 1;
         edtLeaveRequestEndDate_Jsonclick = "";
         edtLeaveRequestEndDate_Enabled = 1;
         edtLeaveRequestStartDate_Jsonclick = "";
         edtLeaveRequestStartDate_Enabled = 1;
         dynEmployeeId_Jsonclick = "";
         dynEmployeeId.Enabled = 1;
         dynEmployeeId.Visible = 1;
         divEmployeeid_cell_Class = "col-xs-12 col-sm-6";
         dynLeaveTypeId_Jsonclick = "";
         dynLeaveTypeId.Enabled = 1;
         lblTextblock_Fontbold = 0;
         lblTextblock_Caption = "";
         divLayoutmaintable_Class = "Table";
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

      protected void GXDLALEAVETYPEID0J21( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALEAVETYPEID_data0J21( ) ;
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

      protected void GXALEAVETYPEID_html0J21( )
      {
         long gxdynajaxvalue;
         GXDLALEAVETYPEID_data0J21( ) ;
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
      }

      protected void GXDLALEAVETYPEID_data0J21( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000J19 */
         pr_default.execute(17);
         while ( (pr_default.getStatus(17) != 101) )
         {
            if ( T000J19_A100CompanyId[0] == new getloggedinusercompanyid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000J19_A124LeaveTypeId[0]), 10, 0, ".", "")));
               gxdynajaxctrldescr.Add(StringUtil.RTrim( T000J19_A125LeaveTypeName[0]));
            }
            pr_default.readNext(17);
         }
         pr_default.close(17);
      }

      protected string rest_LEAVETYPEID( GeneXus.Utils.GxStringCollection colParms )
      {
         string jsonString;
         GXDLALEAVETYPEID_data0J21( ) ;
         jsonString = GXUtil.StringCollectionsToJson( gxdynajaxctrlcodr, gxdynajaxctrldescr);
         /* End function rest_LEAVETYPEID */
         return jsonString ;
      }

      protected void GXDLAEMPLOYEEID0J21( short AV17EmployeeCompany )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAEMPLOYEEID_data0J21( AV17EmployeeCompany) ;
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

      protected void GXAEMPLOYEEID_html0J21( short AV17EmployeeCompany )
      {
         long gxdynajaxvalue;
         GXDLAEMPLOYEEID_data0J21( AV17EmployeeCompany) ;
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
      }

      protected void GXDLAEMPLOYEEID_data0J21( short AV17EmployeeCompany )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000J20 */
         pr_default.execute(18, new Object[] {AV17EmployeeCompany});
         while ( (pr_default.getStatus(18) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000J20_A106EmployeeId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000J20_A148EmployeeName[0]));
            pr_default.readNext(18);
         }
         pr_default.close(18);
      }

      protected string rest_EMPLOYEEID( GeneXus.Utils.GxStringCollection colParms )
      {
         string jsonString;
         gxdynajaxindex = 1;
         AV17EmployeeCompany = (short)(Math.Round(NumberUtil.Val( ((string)colParms.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
         gxdynajaxindex = (int)(gxdynajaxindex+1);
         GXDLAEMPLOYEEID_data0J21( AV17EmployeeCompany) ;
         jsonString = GXUtil.StringCollectionsToJson( gxdynajaxctrlcodr, gxdynajaxctrldescr);
         /* End function rest_EMPLOYEEID */
         return jsonString ;
      }

      protected void GX13ASALEAVEREQUESTDURATION0J21( DateTime A129LeaveRequestStartDate ,
                                                      DateTime A130LeaveRequestEndDate ,
                                                      string A173LeaveRequestHalfDay )
      {
         GXt_decimal1 = A131LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay, out  GXt_decimal1) ;
         A131LeaveRequestDuration = GXt_decimal1;
         AssignAttri("", false, "A131LeaveRequestDuration", StringUtil.LTrimStr( A131LeaveRequestDuration, 4, 1));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX14ASACHECKEMPLOYEEONLEAVE0J21( bool AV10checking ,
                                                      DateTime A129LeaveRequestStartDate ,
                                                      long A106EmployeeId )
      {
         if ( ! AV10checking )
         {
            GXt_boolean4 = AV33CheckEmployeeOnLeave;
            new checkemployeeonleave(context ).execute(  A129LeaveRequestStartDate,  A106EmployeeId, out  GXt_boolean4) ;
            AV33CheckEmployeeOnLeave = GXt_boolean4;
            AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
         }
         else
         {
            if ( AV10checking )
            {
               AV33CheckEmployeeOnLeave = false;
               AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV33CheckEmployeeOnLeave))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
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
            A132LeaveRequestStatus = cmbLeaveRequestStatus.getValidValue(A132LeaveRequestStatus);
            AssignAttri("", false, "A132LeaveRequestStatus", A132LeaveRequestStatus);
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

      public void Valid_Leavetypeid( )
      {
         A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( dynLeaveTypeId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A106EmployeeId = (long)(Math.Round(NumberUtil.Val( dynEmployeeId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000J21 */
         pr_default.execute(19, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'LeaveType'.", "ForeignKeyNotFound", 1, "LEAVETYPEID");
            AnyError = 1;
            GX_FocusControl = dynLeaveTypeId_Internalname;
         }
         A125LeaveTypeName = T000J21_A125LeaveTypeName[0];
         A144LeaveTypeVacationLeave = T000J21_A144LeaveTypeVacationLeave[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A125LeaveTypeName", StringUtil.RTrim( A125LeaveTypeName));
         AssignAttri("", false, "A144LeaveTypeVacationLeave", StringUtil.RTrim( A144LeaveTypeVacationLeave));
      }

      public void Valid_Employeeid( )
      {
         A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( dynLeaveTypeId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A106EmployeeId = (long)(Math.Round(NumberUtil.Val( dynEmployeeId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000J22 */
         pr_default.execute(20, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = dynEmployeeId_Internalname;
         }
         A148EmployeeName = T000J22_A148EmployeeName[0];
         A147EmployeeBalance = T000J22_A147EmployeeBalance[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A148EmployeeName", StringUtil.RTrim( A148EmployeeName));
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147EmployeeBalance), 4, 0, ".", "")));
      }

      public void Valid_Leaverequeststartdate( )
      {
         A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( dynLeaveTypeId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A106EmployeeId = (long)(Math.Round(NumberUtil.Val( dynEmployeeId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         if ( ! AV10checking )
         {
            GXt_boolean4 = AV33CheckEmployeeOnLeave;
            new checkemployeeonleave(context ).execute(  A129LeaveRequestStartDate,  A106EmployeeId, out  GXt_boolean4) ;
            AV33CheckEmployeeOnLeave = GXt_boolean4;
         }
         else
         {
            if ( AV10checking )
            {
               AV33CheckEmployeeOnLeave = false;
            }
         }
         if ( (DateTime.MinValue==A129LeaveRequestStartDate) )
         {
            GX_msglist.addItem("Start date is required", 1, "LEAVEREQUESTSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestStartDate_Internalname;
         }
         if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( Gx_date ) ) && IsIns( )  )
         {
            GX_msglist.addItem("Invalid Leave start date", 1, "LEAVEREQUESTSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestStartDate_Internalname;
         }
         if ( ! (DateTime.MinValue==A129LeaveRequestStartDate) && AV33CheckEmployeeOnLeave )
         {
            GX_msglist.addItem("You are already on leave", 1, "LEAVEREQUESTSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestStartDate_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "AV33CheckEmployeeOnLeave", AV33CheckEmployeeOnLeave);
      }

      public void Valid_Leaverequesthalfday( )
      {
         n173LeaveRequestHalfDay = false;
         A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( dynLeaveTypeId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A106EmployeeId = (long)(Math.Round(NumberUtil.Val( dynEmployeeId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         if ( IsIns( )  && (DateTime.MinValue==A130LeaveRequestEndDate) && ( Gx_BScreen == 0 ) )
         {
            A130LeaveRequestEndDate = Gx_date;
         }
         else
         {
            if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "") != 0 )
            {
               A130LeaveRequestEndDate = A129LeaveRequestStartDate;
            }
         }
         if ( (DateTime.MinValue==A130LeaveRequestEndDate) )
         {
            GX_msglist.addItem("End date is required", 1, "LEAVEREQUESTHALFDAY");
            AnyError = 1;
         }
         if ( ! (DateTime.MinValue==A130LeaveRequestEndDate) && ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) < DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) ) )
         {
            GX_msglist.addItem("Invalid Leave end date", 1, "LEAVEREQUESTHALFDAY");
            AnyError = 1;
         }
         GXt_decimal1 = A131LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay, out  GXt_decimal1) ;
         A131LeaveRequestDuration = GXt_decimal1;
         if ( ! (Convert.ToDecimal(0)==A131LeaveRequestDuration) && ( A131LeaveRequestDuration > Convert.ToDecimal( new getemployeevactiondaysleft(context).executeUdp(  A106EmployeeId) )) && ( StringUtil.StrCmp(A144LeaveTypeVacationLeave, "Yes") == 0 ) )
         {
            GX_msglist.addItem("Vacation days exceeded.", 1, "LEAVEREQUESTHALFDAY");
            AnyError = 1;
         }
         if ( ( A131LeaveRequestDuration <= Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Invalid Leave Duration", 1, "LEAVEREQUESTHALFDAY");
            AnyError = 1;
         }
         if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "") != 0 )
         {
            edtLeaveRequestEndDate_Enabled = 0;
         }
         else
         {
            edtLeaveRequestEndDate_Enabled = 1;
         }
         if ( ! new checkleaverequesttimevalide(context).executeUdp(  A129LeaveRequestStartDate,  A173LeaveRequestHalfDay) && IsIns( )  )
         {
            GX_msglist.addItem("Request not permitted for this time", 1, "LEAVEREQUESTHALFDAY");
            AnyError = 1;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A130LeaveRequestEndDate", context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"));
         AssignAttri("", false, "A131LeaveRequestDuration", StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")));
         AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Enabled), 5, 0), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV26LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV29TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV26LeaveRequestId',fld:'vLEAVEREQUESTID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A127LeaveRequestId',fld:'LEAVEREQUESTID',pic:'ZZZZZZZZZ9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E120J2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'cmbLeaveRequestStatus'},{av:'A132LeaveRequestStatus',fld:'LEAVEREQUESTSTATUS',pic:''},{av:'A129LeaveRequestStartDate',fld:'LEAVEREQUESTSTARTDATE',pic:''},{av:'A130LeaveRequestEndDate',fld:'LEAVEREQUESTENDDATE',pic:''},{av:'A133LeaveRequestDescription',fld:'LEAVEREQUESTDESCRIPTION',pic:''},{av:'A125LeaveTypeName',fld:'LEAVETYPENAME',pic:''},{av:'A148EmployeeName',fld:'EMPLOYEENAME',pic:''},{av:'dynEmployeeId'},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'A127LeaveRequestId',fld:'LEAVEREQUESTID',pic:'ZZZZZZZZZ9'},{av:'AV29TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynEmployeeId'},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'A148EmployeeName',fld:'EMPLOYEENAME',pic:''},{av:'A125LeaveTypeName',fld:'LEAVETYPENAME',pic:''},{av:'A133LeaveRequestDescription',fld:'LEAVEREQUESTDESCRIPTION',pic:''},{av:'A130LeaveRequestEndDate',fld:'LEAVEREQUESTENDDATE',pic:''},{av:'A129LeaveRequestStartDate',fld:'LEAVEREQUESTSTARTDATE',pic:''},{av:'A127LeaveRequestId',fld:'LEAVEREQUESTID',pic:'ZZZZZZZZZ9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("LEAVEREQUESTENDDATE.CONTROLVALUECHANGED","{handler:'E130J2',iparms:[{av:'A129LeaveRequestStartDate',fld:'LEAVEREQUESTSTARTDATE',pic:''},{av:'A130LeaveRequestEndDate',fld:'LEAVEREQUESTENDDATE',pic:''},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("LEAVEREQUESTENDDATE.CONTROLVALUECHANGED",",oparms:[{av:'AV35LeaveRequestDuration',fld:'vLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED","{handler:'E140J2',iparms:[{av:'A129LeaveRequestStartDate',fld:'LEAVEREQUESTSTARTDATE',pic:''},{av:'A130LeaveRequestEndDate',fld:'LEAVEREQUESTENDDATE',pic:''},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED",",oparms:[{av:'AV35LeaveRequestDuration',fld:'vLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("EMPLOYEEID.CONTROLVALUECHANGED","{handler:'E150J2',iparms:[{av:'dynEmployeeId'},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("EMPLOYEEID.CONTROLVALUECHANGED",",oparms:[{av:'AV20EmployyeeAvailableVacationDays',fld:'vEMPLOYYEEAVAILABLEVACATIONDAYS',pic:'ZZZ9'},{av:'lblTextblock_Caption',ctrl:'TEXTBLOCK',prop:'Caption'},{av:'lblTextblock_Fontbold',ctrl:'TEXTBLOCK',prop:'Fontbold'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("LEAVEREQUESTHALFDAY.CLICK","{handler:'E160J2',iparms:[{av:'A129LeaveRequestStartDate',fld:'LEAVEREQUESTSTARTDATE',pic:''},{av:'A130LeaveRequestEndDate',fld:'LEAVEREQUESTENDDATE',pic:''},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("LEAVEREQUESTHALFDAY.CLICK",",oparms:[{av:'AV35LeaveRequestDuration',fld:'vLEAVEREQUESTDURATION',pic:'Z9.9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_LEAVETYPEID","{handler:'Valid_Leavetypeid',iparms:[{av:'AV17EmployeeCompany',fld:'vEMPLOYEECOMPANY',pic:'ZZZ9'},{av:'dynEmployeeId'},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'A125LeaveTypeName',fld:'LEAVETYPENAME',pic:''},{av:'A144LeaveTypeVacationLeave',fld:'LEAVETYPEVACATIONLEAVE',pic:''},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_LEAVETYPEID",",oparms:[{av:'A125LeaveTypeName',fld:'LEAVETYPENAME',pic:''},{av:'A144LeaveTypeVacationLeave',fld:'LEAVETYPEVACATIONLEAVE',pic:''},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_EMPLOYEEID","{handler:'Valid_Employeeid',iparms:[{av:'AV17EmployeeCompany',fld:'vEMPLOYEECOMPANY',pic:'ZZZ9'},{av:'dynEmployeeId'},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'A148EmployeeName',fld:'EMPLOYEENAME',pic:''},{av:'A147EmployeeBalance',fld:'EMPLOYEEBALANCE',pic:'ZZZ9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_EMPLOYEEID",",oparms:[{av:'A148EmployeeName',fld:'EMPLOYEENAME',pic:''},{av:'A147EmployeeBalance',fld:'EMPLOYEEBALANCE',pic:'ZZZ9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_LEAVEREQUESTSTARTDATE","{handler:'Valid_Leaverequeststartdate',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A129LeaveRequestStartDate',fld:'LEAVEREQUESTSTARTDATE',pic:''},{av:'AV10checking',fld:'vCHECKING',pic:''},{av:'Gx_date',fld:'vTODAY',pic:''},{av:'AV33CheckEmployeeOnLeave',fld:'vCHECKEMPLOYEEONLEAVE',pic:''},{av:'AV17EmployeeCompany',fld:'vEMPLOYEECOMPANY',pic:'ZZZ9'},{av:'dynEmployeeId'},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_LEAVEREQUESTSTARTDATE",",oparms:[{av:'AV33CheckEmployeeOnLeave',fld:'vCHECKEMPLOYEEONLEAVE',pic:''},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_LEAVEREQUESTENDDATE","{handler:'Valid_Leaverequestenddate',iparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_LEAVEREQUESTENDDATE",",oparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_LEAVEREQUESTHALFDAY","{handler:'Valid_Leaverequesthalfday',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:''},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'A129LeaveRequestStartDate',fld:'LEAVEREQUESTSTARTDATE',pic:''},{av:'A130LeaveRequestEndDate',fld:'LEAVEREQUESTENDDATE',pic:''},{av:'A131LeaveRequestDuration',fld:'LEAVEREQUESTDURATION',pic:'Z9.9'},{av:'A144LeaveTypeVacationLeave',fld:'LEAVETYPEVACATIONLEAVE',pic:''},{av:'AV17EmployeeCompany',fld:'vEMPLOYEECOMPANY',pic:'ZZZ9'},{av:'dynEmployeeId'},{av:'A106EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZZZZZ9'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_LEAVEREQUESTHALFDAY",",oparms:[{av:'A130LeaveRequestEndDate',fld:'LEAVEREQUESTENDDATE',pic:''},{av:'A131LeaveRequestDuration',fld:'LEAVEREQUESTDURATION',pic:'Z9.9'},{av:'edtLeaveRequestEndDate_Enabled',ctrl:'LEAVEREQUESTENDDATE',prop:'Enabled'},{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_LEAVEREQUESTDESCRIPTION","{handler:'Valid_Leaverequestdescription',iparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_LEAVEREQUESTDESCRIPTION",",oparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_LEAVEREQUESTID","{handler:'Valid_Leaverequestid',iparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_LEAVEREQUESTID",",oparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_LEAVEREQUESTDURATION","{handler:'Valid_Leaverequestduration',iparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_LEAVEREQUESTDURATION",",oparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
         setEventMetadata("VALID_LEAVEREQUESTSTATUS","{handler:'Valid_Leaverequeststatus',iparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]");
         setEventMetadata("VALID_LEAVEREQUESTSTATUS",",oparms:[{av:'dynLeaveTypeId'},{av:'A124LeaveTypeId',fld:'LEAVETYPEID',pic:'ZZZZZZZZZ9'},{av:'radLeaveRequestHalfDay'},{av:'A173LeaveRequestHalfDay',fld:'LEAVEREQUESTHALFDAY',pic:''}]}");
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
         pr_default.close(19);
         pr_default.close(14);
         pr_default.close(20);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z130LeaveRequestEndDate = DateTime.MinValue;
         Z128LeaveRequestDate = DateTime.MinValue;
         Z129LeaveRequestStartDate = DateTime.MinValue;
         Z173LeaveRequestHalfDay = "";
         Z132LeaveRequestStatus = "";
         Z133LeaveRequestDescription = "";
         Z134LeaveRequestRejectionReason = "";
         N130LeaveRequestEndDate = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A132LeaveRequestStatus = "";
         ClassString = "";
         StyleString = "";
         lblTextblock_Jsonclick = "";
         TempTags = "";
         A133LeaveRequestDescription = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A134LeaveRequestRejectionReason = "";
         Gx_date = DateTime.MinValue;
         A144LeaveTypeVacationLeave = "";
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         AV40Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode21 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV32WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV31WebSession = context.GetSession();
         AV30TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV37Mesage = "";
         Z125LeaveTypeName = "";
         Z144LeaveTypeVacationLeave = "";
         Z148EmployeeName = "";
         T000J4_A125LeaveTypeName = new string[] {""} ;
         T000J4_A144LeaveTypeVacationLeave = new string[] {""} ;
         T000J5_A148EmployeeName = new string[] {""} ;
         T000J5_A147EmployeeBalance = new short[1] ;
         T000J6_A127LeaveRequestId = new long[1] ;
         T000J6_A131LeaveRequestDuration = new decimal[1] ;
         T000J6_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         T000J6_A125LeaveTypeName = new string[] {""} ;
         T000J6_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         T000J6_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         T000J6_A173LeaveRequestHalfDay = new string[] {""} ;
         T000J6_n173LeaveRequestHalfDay = new bool[] {false} ;
         T000J6_A132LeaveRequestStatus = new string[] {""} ;
         T000J6_A133LeaveRequestDescription = new string[] {""} ;
         T000J6_A134LeaveRequestRejectionReason = new string[] {""} ;
         T000J6_A148EmployeeName = new string[] {""} ;
         T000J6_A147EmployeeBalance = new short[1] ;
         T000J6_A144LeaveTypeVacationLeave = new string[] {""} ;
         T000J6_A124LeaveTypeId = new long[1] ;
         T000J6_A106EmployeeId = new long[1] ;
         T000J7_A125LeaveTypeName = new string[] {""} ;
         T000J7_A144LeaveTypeVacationLeave = new string[] {""} ;
         T000J8_A148EmployeeName = new string[] {""} ;
         T000J8_A147EmployeeBalance = new short[1] ;
         T000J9_A127LeaveRequestId = new long[1] ;
         T000J3_A127LeaveRequestId = new long[1] ;
         T000J3_A131LeaveRequestDuration = new decimal[1] ;
         T000J3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         T000J3_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         T000J3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         T000J3_A173LeaveRequestHalfDay = new string[] {""} ;
         T000J3_n173LeaveRequestHalfDay = new bool[] {false} ;
         T000J3_A132LeaveRequestStatus = new string[] {""} ;
         T000J3_A133LeaveRequestDescription = new string[] {""} ;
         T000J3_A134LeaveRequestRejectionReason = new string[] {""} ;
         T000J3_A124LeaveTypeId = new long[1] ;
         T000J3_A106EmployeeId = new long[1] ;
         T000J10_A127LeaveRequestId = new long[1] ;
         T000J11_A127LeaveRequestId = new long[1] ;
         T000J2_A127LeaveRequestId = new long[1] ;
         T000J2_A131LeaveRequestDuration = new decimal[1] ;
         T000J2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         T000J2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         T000J2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         T000J2_A173LeaveRequestHalfDay = new string[] {""} ;
         T000J2_n173LeaveRequestHalfDay = new bool[] {false} ;
         T000J2_A132LeaveRequestStatus = new string[] {""} ;
         T000J2_A133LeaveRequestDescription = new string[] {""} ;
         T000J2_A134LeaveRequestRejectionReason = new string[] {""} ;
         T000J2_A124LeaveTypeId = new long[1] ;
         T000J2_A106EmployeeId = new long[1] ;
         T000J13_A127LeaveRequestId = new long[1] ;
         T000J16_A125LeaveTypeName = new string[] {""} ;
         T000J16_A144LeaveTypeVacationLeave = new string[] {""} ;
         T000J17_A148EmployeeName = new string[] {""} ;
         T000J17_A147EmployeeBalance = new short[1] ;
         T000J18_A127LeaveRequestId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i129LeaveRequestStartDate = DateTime.MinValue;
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000J19_A124LeaveTypeId = new long[1] ;
         T000J19_A125LeaveTypeName = new string[] {""} ;
         T000J19_A100CompanyId = new long[1] ;
         T000J20_A106EmployeeId = new long[1] ;
         T000J20_A148EmployeeName = new string[] {""} ;
         T000J20_A100CompanyId = new long[1] ;
         T000J21_A125LeaveTypeName = new string[] {""} ;
         T000J21_A144LeaveTypeVacationLeave = new string[] {""} ;
         T000J22_A148EmployeeName = new string[] {""} ;
         T000J22_A147EmployeeBalance = new short[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leaverequest__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequest__default(),
            new Object[][] {
                new Object[] {
               T000J2_A127LeaveRequestId, T000J2_A131LeaveRequestDuration, T000J2_A130LeaveRequestEndDate, T000J2_A128LeaveRequestDate, T000J2_A129LeaveRequestStartDate, T000J2_A173LeaveRequestHalfDay, T000J2_n173LeaveRequestHalfDay, T000J2_A132LeaveRequestStatus, T000J2_A133LeaveRequestDescription, T000J2_A134LeaveRequestRejectionReason,
               T000J2_A124LeaveTypeId, T000J2_A106EmployeeId
               }
               , new Object[] {
               T000J3_A127LeaveRequestId, T000J3_A131LeaveRequestDuration, T000J3_A130LeaveRequestEndDate, T000J3_A128LeaveRequestDate, T000J3_A129LeaveRequestStartDate, T000J3_A173LeaveRequestHalfDay, T000J3_n173LeaveRequestHalfDay, T000J3_A132LeaveRequestStatus, T000J3_A133LeaveRequestDescription, T000J3_A134LeaveRequestRejectionReason,
               T000J3_A124LeaveTypeId, T000J3_A106EmployeeId
               }
               , new Object[] {
               T000J4_A125LeaveTypeName, T000J4_A144LeaveTypeVacationLeave
               }
               , new Object[] {
               T000J5_A148EmployeeName, T000J5_A147EmployeeBalance
               }
               , new Object[] {
               T000J6_A127LeaveRequestId, T000J6_A131LeaveRequestDuration, T000J6_A130LeaveRequestEndDate, T000J6_A125LeaveTypeName, T000J6_A128LeaveRequestDate, T000J6_A129LeaveRequestStartDate, T000J6_A173LeaveRequestHalfDay, T000J6_n173LeaveRequestHalfDay, T000J6_A132LeaveRequestStatus, T000J6_A133LeaveRequestDescription,
               T000J6_A134LeaveRequestRejectionReason, T000J6_A148EmployeeName, T000J6_A147EmployeeBalance, T000J6_A144LeaveTypeVacationLeave, T000J6_A124LeaveTypeId, T000J6_A106EmployeeId
               }
               , new Object[] {
               T000J7_A125LeaveTypeName, T000J7_A144LeaveTypeVacationLeave
               }
               , new Object[] {
               T000J8_A148EmployeeName, T000J8_A147EmployeeBalance
               }
               , new Object[] {
               T000J9_A127LeaveRequestId
               }
               , new Object[] {
               T000J10_A127LeaveRequestId
               }
               , new Object[] {
               T000J11_A127LeaveRequestId
               }
               , new Object[] {
               }
               , new Object[] {
               T000J13_A127LeaveRequestId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J16_A125LeaveTypeName, T000J16_A144LeaveTypeVacationLeave
               }
               , new Object[] {
               T000J17_A148EmployeeName, T000J17_A147EmployeeBalance
               }
               , new Object[] {
               T000J18_A127LeaveRequestId
               }
               , new Object[] {
               T000J19_A124LeaveTypeId, T000J19_A125LeaveTypeName, T000J19_A100CompanyId
               }
               , new Object[] {
               T000J20_A106EmployeeId, T000J20_A148EmployeeName, T000J20_A100CompanyId
               }
               , new Object[] {
               T000J21_A125LeaveTypeName, T000J21_A144LeaveTypeVacationLeave
               }
               , new Object[] {
               T000J22_A148EmployeeName, T000J22_A147EmployeeBalance
               }
            }
         );
         AV40Pgmname = "LeaveRequest";
         Z106EmployeeId = 0;
         N106EmployeeId = 0;
         i106EmployeeId = 0;
         A106EmployeeId = 0;
         Z130LeaveRequestEndDate = DateTime.MinValue;
         N130LeaveRequestEndDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         Z129LeaveRequestStartDate = DateTime.MinValue;
         i129LeaveRequestStartDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short AV17EmployeeCompany ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short lblTextblock_Fontbold ;
      private short Gx_BScreen ;
      private short A147EmployeeBalance ;
      private short RcdFound21 ;
      private short AV20EmployyeeAvailableVacationDays ;
      private short GXt_int3 ;
      private short GX_JID ;
      private short Z147EmployeeBalance ;
      private short nIsDirty_21 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtLeaveRequestStartDate_Enabled ;
      private int edtLeaveRequestEndDate_Enabled ;
      private int edtavLeaverequestduration_Enabled ;
      private int edtLeaveRequestDescription_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtLeaveRequestId_Enabled ;
      private int edtLeaveRequestId_Visible ;
      private int edtLeaveRequestDate_Visible ;
      private int edtLeaveRequestDate_Enabled ;
      private int edtLeaveRequestDuration_Enabled ;
      private int edtLeaveRequestDuration_Visible ;
      private int edtLeaveRequestRejectionReason_Visible ;
      private int edtLeaveRequestRejectionReason_Enabled ;
      private int AV41GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private long wcpOAV26LeaveRequestId ;
      private long Z127LeaveRequestId ;
      private long Z124LeaveTypeId ;
      private long Z106EmployeeId ;
      private long N124LeaveTypeId ;
      private long N106EmployeeId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long AV26LeaveRequestId ;
      private long A127LeaveRequestId ;
      private long AV24Insert_LeaveTypeId ;
      private long AV23Insert_EmployeeId ;
      private long AV18EmployeeId ;
      private long GXt_int2 ;
      private long i106EmployeeId ;
      private decimal Z131LeaveRequestDuration ;
      private decimal AV35LeaveRequestDuration ;
      private decimal A131LeaveRequestDuration ;
      private decimal GXt_decimal1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z173LeaveRequestHalfDay ;
      private string Z132LeaveRequestStatus ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A173LeaveRequestHalfDay ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynLeaveTypeId_Internalname ;
      private string dynEmployeeId_Internalname ;
      private string A132LeaveRequestStatus ;
      private string cmbLeaveRequestStatus_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divNewtable_Internalname ;
      private string divTableleft_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string lblTextblock_Internalname ;
      private string lblTextblock_Caption ;
      private string lblTextblock_Jsonclick ;
      private string TempTags ;
      private string dynLeaveTypeId_Jsonclick ;
      private string divEmployeeid_cell_Internalname ;
      private string divEmployeeid_cell_Class ;
      private string dynEmployeeId_Jsonclick ;
      private string edtLeaveRequestStartDate_Internalname ;
      private string edtLeaveRequestStartDate_Jsonclick ;
      private string edtLeaveRequestEndDate_Internalname ;
      private string edtLeaveRequestEndDate_Jsonclick ;
      private string radLeaveRequestHalfDay_Internalname ;
      private string radLeaveRequestHalfDay_Jsonclick ;
      private string edtavLeaverequestduration_Internalname ;
      private string edtavLeaverequestduration_Jsonclick ;
      private string edtLeaveRequestDescription_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divTableright_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtLeaveRequestId_Internalname ;
      private string edtLeaveRequestId_Jsonclick ;
      private string edtLeaveRequestDate_Internalname ;
      private string edtLeaveRequestDate_Jsonclick ;
      private string edtLeaveRequestDuration_Internalname ;
      private string edtLeaveRequestDuration_Jsonclick ;
      private string cmbLeaveRequestStatus_Jsonclick ;
      private string edtLeaveRequestRejectionReason_Internalname ;
      private string A144LeaveTypeVacationLeave ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string AV40Pgmname ;
      private string hsh ;
      private string sMode21 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV37Mesage ;
      private string Z125LeaveTypeName ;
      private string Z144LeaveTypeVacationLeave ;
      private string Z148EmployeeName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private DateTime Z130LeaveRequestEndDate ;
      private DateTime Z128LeaveRequestDate ;
      private DateTime Z129LeaveRequestStartDate ;
      private DateTime N130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A128LeaveRequestDate ;
      private DateTime Gx_date ;
      private DateTime i129LeaveRequestStartDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n173LeaveRequestHalfDay ;
      private bool AV10checking ;
      private bool wbErr ;
      private bool AV33CheckEmployeeOnLeave ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private bool GXt_boolean4 ;
      private bool ZV33CheckEmployeeOnLeave ;
      private string Z133LeaveRequestDescription ;
      private string Z134LeaveRequestRejectionReason ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private IGxSession AV31WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLeaveTypeId ;
      private GXCombobox dynEmployeeId ;
      private GXRadio radLeaveRequestHalfDay ;
      private GXCombobox cmbLeaveRequestStatus ;
      private IDataStoreProvider pr_default ;
      private string[] T000J4_A125LeaveTypeName ;
      private string[] T000J4_A144LeaveTypeVacationLeave ;
      private string[] T000J5_A148EmployeeName ;
      private short[] T000J5_A147EmployeeBalance ;
      private long[] T000J6_A127LeaveRequestId ;
      private decimal[] T000J6_A131LeaveRequestDuration ;
      private DateTime[] T000J6_A130LeaveRequestEndDate ;
      private string[] T000J6_A125LeaveTypeName ;
      private DateTime[] T000J6_A128LeaveRequestDate ;
      private DateTime[] T000J6_A129LeaveRequestStartDate ;
      private string[] T000J6_A173LeaveRequestHalfDay ;
      private bool[] T000J6_n173LeaveRequestHalfDay ;
      private string[] T000J6_A132LeaveRequestStatus ;
      private string[] T000J6_A133LeaveRequestDescription ;
      private string[] T000J6_A134LeaveRequestRejectionReason ;
      private string[] T000J6_A148EmployeeName ;
      private short[] T000J6_A147EmployeeBalance ;
      private string[] T000J6_A144LeaveTypeVacationLeave ;
      private long[] T000J6_A124LeaveTypeId ;
      private long[] T000J6_A106EmployeeId ;
      private string[] T000J7_A125LeaveTypeName ;
      private string[] T000J7_A144LeaveTypeVacationLeave ;
      private string[] T000J8_A148EmployeeName ;
      private short[] T000J8_A147EmployeeBalance ;
      private long[] T000J9_A127LeaveRequestId ;
      private long[] T000J3_A127LeaveRequestId ;
      private decimal[] T000J3_A131LeaveRequestDuration ;
      private DateTime[] T000J3_A130LeaveRequestEndDate ;
      private DateTime[] T000J3_A128LeaveRequestDate ;
      private DateTime[] T000J3_A129LeaveRequestStartDate ;
      private string[] T000J3_A173LeaveRequestHalfDay ;
      private bool[] T000J3_n173LeaveRequestHalfDay ;
      private string[] T000J3_A132LeaveRequestStatus ;
      private string[] T000J3_A133LeaveRequestDescription ;
      private string[] T000J3_A134LeaveRequestRejectionReason ;
      private long[] T000J3_A124LeaveTypeId ;
      private long[] T000J3_A106EmployeeId ;
      private long[] T000J10_A127LeaveRequestId ;
      private long[] T000J11_A127LeaveRequestId ;
      private long[] T000J2_A127LeaveRequestId ;
      private decimal[] T000J2_A131LeaveRequestDuration ;
      private DateTime[] T000J2_A130LeaveRequestEndDate ;
      private DateTime[] T000J2_A128LeaveRequestDate ;
      private DateTime[] T000J2_A129LeaveRequestStartDate ;
      private string[] T000J2_A173LeaveRequestHalfDay ;
      private bool[] T000J2_n173LeaveRequestHalfDay ;
      private string[] T000J2_A132LeaveRequestStatus ;
      private string[] T000J2_A133LeaveRequestDescription ;
      private string[] T000J2_A134LeaveRequestRejectionReason ;
      private long[] T000J2_A124LeaveTypeId ;
      private long[] T000J2_A106EmployeeId ;
      private long[] T000J13_A127LeaveRequestId ;
      private string[] T000J16_A125LeaveTypeName ;
      private string[] T000J16_A144LeaveTypeVacationLeave ;
      private string[] T000J17_A148EmployeeName ;
      private short[] T000J17_A147EmployeeBalance ;
      private long[] T000J18_A127LeaveRequestId ;
      private long[] T000J19_A124LeaveTypeId ;
      private string[] T000J19_A125LeaveTypeName ;
      private long[] T000J19_A100CompanyId ;
      private long[] T000J20_A106EmployeeId ;
      private string[] T000J20_A148EmployeeName ;
      private long[] T000J20_A100CompanyId ;
      private string[] T000J21_A125LeaveTypeName ;
      private string[] T000J21_A144LeaveTypeVacationLeave ;
      private string[] T000J22_A148EmployeeName ;
      private short[] T000J22_A147EmployeeBalance ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV29TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV30TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV32WWPContext ;
   }

   public class leaverequest__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leaverequest__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000J6;
        prmT000J6 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000J4;
        prmT000J4 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000J5;
        prmT000J5 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000J7;
        prmT000J7 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000J8;
        prmT000J8 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000J9;
        prmT000J9 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000J3;
        prmT000J3 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000J10;
        prmT000J10 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000J11;
        prmT000J11 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000J2;
        prmT000J2 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000J12;
        prmT000J12 = new Object[] {
        new ParDef("LeaveRequestDuration",GXType.Number,4,1) ,
        new ParDef("LeaveRequestEndDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestStartDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestHalfDay",GXType.Char,20,0){Nullable=true} ,
        new ParDef("LeaveRequestStatus",GXType.Char,20,0) ,
        new ParDef("LeaveRequestDescription",GXType.VarChar,200,0) ,
        new ParDef("LeaveRequestRejectionReason",GXType.VarChar,200,0) ,
        new ParDef("LeaveTypeId",GXType.Int64,10,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000J13;
        prmT000J13 = new Object[] {
        };
        Object[] prmT000J14;
        prmT000J14 = new Object[] {
        new ParDef("LeaveRequestDuration",GXType.Number,4,1) ,
        new ParDef("LeaveRequestEndDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestStartDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestHalfDay",GXType.Char,20,0){Nullable=true} ,
        new ParDef("LeaveRequestStatus",GXType.Char,20,0) ,
        new ParDef("LeaveRequestDescription",GXType.VarChar,200,0) ,
        new ParDef("LeaveRequestRejectionReason",GXType.VarChar,200,0) ,
        new ParDef("LeaveTypeId",GXType.Int64,10,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000J15;
        prmT000J15 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000J16;
        prmT000J16 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000J17;
        prmT000J17 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000J18;
        prmT000J18 = new Object[] {
        };
        Object[] prmT000J19;
        prmT000J19 = new Object[] {
        };
        Object[] prmT000J20;
        prmT000J20 = new Object[] {
        new ParDef("AV17EmployeeCompany",GXType.Int16,4,0)
        };
        Object[] prmT000J21;
        prmT000J21 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000J22;
        prmT000J22 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000J2", "SELECT LeaveRequestId, LeaveRequestDuration, LeaveRequestEndDate, LeaveRequestDate, LeaveRequestStartDate, LeaveRequestHalfDay, LeaveRequestStatus, LeaveRequestDescription, LeaveRequestRejectionReason, LeaveTypeId, EmployeeId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId  FOR UPDATE OF LeaveRequest NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J3", "SELECT LeaveRequestId, LeaveRequestDuration, LeaveRequestEndDate, LeaveRequestDate, LeaveRequestStartDate, LeaveRequestHalfDay, LeaveRequestStatus, LeaveRequestDescription, LeaveRequestRejectionReason, LeaveTypeId, EmployeeId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J4", "SELECT LeaveTypeName, LeaveTypeVacationLeave FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J5", "SELECT EmployeeName, EmployeeBalance FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J6", "SELECT TM1.LeaveRequestId, TM1.LeaveRequestDuration, TM1.LeaveRequestEndDate, T2.LeaveTypeName, TM1.LeaveRequestDate, TM1.LeaveRequestStartDate, TM1.LeaveRequestHalfDay, TM1.LeaveRequestStatus, TM1.LeaveRequestDescription, TM1.LeaveRequestRejectionReason, T3.EmployeeName, T3.EmployeeBalance, T2.LeaveTypeVacationLeave, TM1.LeaveTypeId, TM1.EmployeeId FROM ((LeaveRequest TM1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = TM1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = TM1.EmployeeId) WHERE TM1.LeaveRequestId = :LeaveRequestId ORDER BY TM1.LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J7", "SELECT LeaveTypeName, LeaveTypeVacationLeave FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J8", "SELECT EmployeeName, EmployeeBalance FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J9", "SELECT LeaveRequestId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J10", "SELECT LeaveRequestId FROM LeaveRequest WHERE ( LeaveRequestId > :LeaveRequestId) ORDER BY LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J11", "SELECT LeaveRequestId FROM LeaveRequest WHERE ( LeaveRequestId < :LeaveRequestId) ORDER BY LeaveRequestId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J12", "SAVEPOINT gxupdate;INSERT INTO LeaveRequest(LeaveRequestDuration, LeaveRequestEndDate, LeaveRequestDate, LeaveRequestStartDate, LeaveRequestHalfDay, LeaveRequestStatus, LeaveRequestDescription, LeaveRequestRejectionReason, LeaveTypeId, EmployeeId) VALUES(:LeaveRequestDuration, :LeaveRequestEndDate, :LeaveRequestDate, :LeaveRequestStartDate, :LeaveRequestHalfDay, :LeaveRequestStatus, :LeaveRequestDescription, :LeaveRequestRejectionReason, :LeaveTypeId, :EmployeeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000J12)
           ,new CursorDef("T000J13", "SELECT currval('LeaveRequestId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J14", "SAVEPOINT gxupdate;UPDATE LeaveRequest SET LeaveRequestDuration=:LeaveRequestDuration, LeaveRequestEndDate=:LeaveRequestEndDate, LeaveRequestDate=:LeaveRequestDate, LeaveRequestStartDate=:LeaveRequestStartDate, LeaveRequestHalfDay=:LeaveRequestHalfDay, LeaveRequestStatus=:LeaveRequestStatus, LeaveRequestDescription=:LeaveRequestDescription, LeaveRequestRejectionReason=:LeaveRequestRejectionReason, LeaveTypeId=:LeaveTypeId, EmployeeId=:EmployeeId  WHERE LeaveRequestId = :LeaveRequestId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000J14)
           ,new CursorDef("T000J15", "SAVEPOINT gxupdate;DELETE FROM LeaveRequest  WHERE LeaveRequestId = :LeaveRequestId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000J15)
           ,new CursorDef("T000J16", "SELECT LeaveTypeName, LeaveTypeVacationLeave FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J17", "SELECT EmployeeName, EmployeeBalance FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J18", "SELECT LeaveRequestId FROM LeaveRequest ORDER BY LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J19", "SELECT LeaveTypeId, LeaveTypeName, CompanyId FROM LeaveType ORDER BY LeaveTypeName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J19,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J20", "SELECT EmployeeId, EmployeeName, CompanyId FROM Employee WHERE :AV17EmployeeCompany = CompanyId ORDER BY EmployeeName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J20,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J21", "SELECT LeaveTypeName, LeaveTypeVacationLeave FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J22", "SELECT EmployeeName, EmployeeBalance FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J22,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 128);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((string[]) buf[13])[0] = rslt.getString(13, 20);
              ((long[]) buf[14])[0] = rslt.getLong(14);
              ((long[]) buf[15])[0] = rslt.getLong(15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 128);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
