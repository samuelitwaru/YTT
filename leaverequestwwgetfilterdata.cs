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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class leaverequestwwgetfilterdata : GXProcedure
   {
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
            return "leaverequestww_Services_Execute" ;
         }

      }

      public leaverequestwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestwwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV54OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         leaverequestwwgetfilterdata objleaverequestwwgetfilterdata;
         objleaverequestwwgetfilterdata = new leaverequestwwgetfilterdata();
         objleaverequestwwgetfilterdata.AV49DDOName = aP0_DDOName;
         objleaverequestwwgetfilterdata.AV50SearchTxtParms = aP1_SearchTxtParms;
         objleaverequestwwgetfilterdata.AV51SearchTxtTo = aP2_SearchTxtTo;
         objleaverequestwwgetfilterdata.AV52OptionsJson = "" ;
         objleaverequestwwgetfilterdata.AV53OptionsDescJson = "" ;
         objleaverequestwwgetfilterdata.AV54OptionIndexesJson = "" ;
         objleaverequestwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objleaverequestwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objleaverequestwwgetfilterdata);
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leaverequestwwgetfilterdata)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV39Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36MaxItems = 10;
         AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV33SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
         AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LEAVEREQUESTHALFDAY") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTHALFDAYOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LEAVEREQUESTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LEAVEREQUESTREJECTIONREASON") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTREJECTIONREASONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV52OptionsJson = AV39Options.ToJSonString(false);
         AV53OptionsDescJson = AV41OptionsDesc.ToJSonString(false);
         AV54OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get("LeaveRequestWWGridState"), "") == 0 )
         {
            AV46GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LeaveRequestWWGridState"), null, "", "");
         }
         else
         {
            AV46GridState.FromXml(AV44Session.Get("LeaveRequestWWGridState"), null, "", "");
         }
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV55FilterFullText = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV15TFLeaveTypeName = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV16TFLeaveTypeName_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV19TFLeaveRequestStartDate = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Value, 1);
               AV20TFLeaveRequestStartDate_To = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV21TFLeaveRequestEndDate = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Value, 1);
               AV22TFLeaveRequestEndDate_To = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV60TFLeaveRequestHalfDayOperator = AV47GridStateFilterValue.gxTpr_Operator;
               if ( AV60TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV56TFLeaveRequestHalfDay = AV47GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV57TFLeaveRequestHalfDay_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV23TFLeaveRequestDuration = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, ".");
               AV24TFLeaveRequestDuration_To = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS") == 0 )
            {
               AV59TFLeaveRequestStatusOperator = AV47GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS_SEL") == 0 )
            {
               AV25TFLeaveRequestStatus_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV26TFLeaveRequestStatus_Sels.FromJSonString(AV25TFLeaveRequestStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV27TFLeaveRequestDescription = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV28TFLeaveRequestDescription_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON") == 0 )
            {
               AV29TFLeaveRequestRejectionReason = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON_SEL") == 0 )
            {
               AV30TFLeaveRequestRejectionReason_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFLeaveTypeName = AV33SearchTxt;
         AV16TFLeaveTypeName_Sel = "";
         AV63Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV64Leaverequestwwds_2_tfleavetypename = AV15TFLeaveTypeName;
         AV65Leaverequestwwds_3_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV66Leaverequestwwds_4_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV67Leaverequestwwds_5_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV68Leaverequestwwds_6_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV69Leaverequestwwds_7_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV70Leaverequestwwds_8_tfleaverequesthalfday = AV56TFLeaveRequestHalfDay;
         AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator = AV60TFLeaveRequestHalfDayOperator;
         AV72Leaverequestwwds_10_tfleaverequesthalfday_sel = AV57TFLeaveRequestHalfDay_Sel;
         AV73Leaverequestwwds_11_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV74Leaverequestwwds_12_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV75Leaverequestwwds_13_tfleaverequeststatus = AV58TFLeaveRequestStatus;
         AV76Leaverequestwwds_14_tfleaverequeststatusoperator = AV59TFLeaveRequestStatusOperator;
         AV77Leaverequestwwds_15_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV78Leaverequestwwds_16_tfleaverequestdescription = AV27TFLeaveRequestDescription;
         AV79Leaverequestwwds_17_tfleaverequestdescription_sel = AV28TFLeaveRequestDescription_Sel;
         AV80Leaverequestwwds_18_tfleaverequestrejectionreason = AV29TFLeaveRequestRejectionReason;
         AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel = AV30TFLeaveRequestRejectionReason_Sel;
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV82Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg21 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV77Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                              AV63Leaverequestwwds_1_filterfulltext ,
                                              AV65Leaverequestwwds_3_tfleavetypename_sel ,
                                              AV64Leaverequestwwds_2_tfleavetypename ,
                                              AV66Leaverequestwwds_4_tfleaverequeststartdate ,
                                              AV67Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                              AV68Leaverequestwwds_6_tfleaverequestenddate ,
                                              AV69Leaverequestwwds_7_tfleaverequestenddate_to ,
                                              AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                              AV70Leaverequestwwds_8_tfleaverequesthalfday ,
                                              AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                              AV73Leaverequestwwds_11_tfleaverequestduration ,
                                              AV74Leaverequestwwds_12_tfleaverequestduration_to ,
                                              AV77Leaverequestwwds_15_tfleaverequeststatus_sels.Count ,
                                              AV76Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                              AV79Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                              AV78Leaverequestwwds_16_tfleaverequestdescription ,
                                              AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                              AV80Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV82Udparg20 ,
                                              A106EmployeeId ,
                                              AV83Udparg21 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV64Leaverequestwwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV64Leaverequestwwds_2_tfleavetypename), 100, "%");
         lV70Leaverequestwwds_8_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV70Leaverequestwwds_8_tfleaverequesthalfday), 20, "%");
         lV78Leaverequestwwds_16_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV78Leaverequestwwds_16_tfleaverequestdescription), "%", "");
         lV80Leaverequestwwds_18_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV80Leaverequestwwds_18_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008C2 */
         pr_default.execute(0, new Object[] {AV82Udparg20, AV83Udparg21, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV64Leaverequestwwds_2_tfleavetypename, AV65Leaverequestwwds_3_tfleavetypename_sel, AV66Leaverequestwwds_4_tfleaverequeststartdate, AV67Leaverequestwwds_5_tfleaverequeststartdate_to, AV68Leaverequestwwds_6_tfleaverequestenddate, AV69Leaverequestwwds_7_tfleaverequestenddate_to, lV70Leaverequestwwds_8_tfleaverequesthalfday, AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, AV73Leaverequestwwds_11_tfleaverequestduration, AV74Leaverequestwwds_12_tfleaverequestduration_to, lV78Leaverequestwwds_16_tfleaverequestdescription, AV79Leaverequestwwds_17_tfleaverequestdescription_sel, lV80Leaverequestwwds_18_tfleaverequestrejectionreason, AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8C2 = false;
            A124LeaveTypeId = P008C2_A124LeaveTypeId[0];
            A106EmployeeId = P008C2_A106EmployeeId[0];
            A100CompanyId = P008C2_A100CompanyId[0];
            A134LeaveRequestRejectionReason = P008C2_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P008C2_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008C2_A131LeaveRequestDuration[0];
            A173LeaveRequestHalfDay = P008C2_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P008C2_n173LeaveRequestHalfDay[0];
            A130LeaveRequestEndDate = P008C2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C2_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P008C2_A125LeaveTypeName[0];
            A132LeaveRequestStatus = P008C2_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P008C2_A127LeaveRequestId[0];
            A100CompanyId = P008C2_A100CompanyId[0];
            A125LeaveTypeName = P008C2_A125LeaveTypeName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P008C2_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRK8C2 = false;
               A127LeaveRequestId = P008C2_A127LeaveRequestId[0];
               AV43count = (long)(AV43count+1);
               BRK8C2 = true;
               pr_default.readNext(0);
            }
            AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
            AV37InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV38Option, "<#Empty#>") != 0 ) && ( AV37InsertIndex <= AV39Options.Count ) && ( ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), AV38Option) < 0 ) || ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV37InsertIndex = (int)(AV37InsertIndex+1);
            }
            AV39Options.Add(AV38Option, AV37InsertIndex);
            AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), AV37InsertIndex);
            if ( AV39Options.Count == AV34SkipItems + 11 )
            {
               AV39Options.RemoveItem(AV39Options.Count);
               AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
            }
            if ( ! BRK8C2 )
            {
               BRK8C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV34SkipItems > 0 )
         {
            AV39Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV34SkipItems = (short)(AV34SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADLEAVEREQUESTHALFDAYOPTIONS' Routine */
         returnInSub = false;
         AV56TFLeaveRequestHalfDay = AV33SearchTxt;
         AV60TFLeaveRequestHalfDayOperator = 0;
         AV57TFLeaveRequestHalfDay_Sel = "";
         AV63Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV64Leaverequestwwds_2_tfleavetypename = AV15TFLeaveTypeName;
         AV65Leaverequestwwds_3_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV66Leaverequestwwds_4_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV67Leaverequestwwds_5_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV68Leaverequestwwds_6_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV69Leaverequestwwds_7_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV70Leaverequestwwds_8_tfleaverequesthalfday = AV56TFLeaveRequestHalfDay;
         AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator = AV60TFLeaveRequestHalfDayOperator;
         AV72Leaverequestwwds_10_tfleaverequesthalfday_sel = AV57TFLeaveRequestHalfDay_Sel;
         AV73Leaverequestwwds_11_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV74Leaverequestwwds_12_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV75Leaverequestwwds_13_tfleaverequeststatus = AV58TFLeaveRequestStatus;
         AV76Leaverequestwwds_14_tfleaverequeststatusoperator = AV59TFLeaveRequestStatusOperator;
         AV77Leaverequestwwds_15_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV78Leaverequestwwds_16_tfleaverequestdescription = AV27TFLeaveRequestDescription;
         AV79Leaverequestwwds_17_tfleaverequestdescription_sel = AV28TFLeaveRequestDescription_Sel;
         AV80Leaverequestwwds_18_tfleaverequestrejectionreason = AV29TFLeaveRequestRejectionReason;
         AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel = AV30TFLeaveRequestRejectionReason_Sel;
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg22 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg21 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV77Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                              AV63Leaverequestwwds_1_filterfulltext ,
                                              AV65Leaverequestwwds_3_tfleavetypename_sel ,
                                              AV64Leaverequestwwds_2_tfleavetypename ,
                                              AV66Leaverequestwwds_4_tfleaverequeststartdate ,
                                              AV67Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                              AV68Leaverequestwwds_6_tfleaverequestenddate ,
                                              AV69Leaverequestwwds_7_tfleaverequestenddate_to ,
                                              AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                              AV70Leaverequestwwds_8_tfleaverequesthalfday ,
                                              AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                              AV73Leaverequestwwds_11_tfleaverequestduration ,
                                              AV74Leaverequestwwds_12_tfleaverequestduration_to ,
                                              AV77Leaverequestwwds_15_tfleaverequeststatus_sels.Count ,
                                              AV76Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                              AV79Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                              AV78Leaverequestwwds_16_tfleaverequestdescription ,
                                              AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                              AV80Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV86Udparg22 ,
                                              A106EmployeeId ,
                                              AV83Udparg21 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV64Leaverequestwwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV64Leaverequestwwds_2_tfleavetypename), 100, "%");
         lV70Leaverequestwwds_8_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV70Leaverequestwwds_8_tfleaverequesthalfday), 20, "%");
         lV78Leaverequestwwds_16_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV78Leaverequestwwds_16_tfleaverequestdescription), "%", "");
         lV80Leaverequestwwds_18_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV80Leaverequestwwds_18_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008C3 */
         pr_default.execute(1, new Object[] {AV86Udparg22, AV83Udparg21, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV64Leaverequestwwds_2_tfleavetypename, AV65Leaverequestwwds_3_tfleavetypename_sel, AV66Leaverequestwwds_4_tfleaverequeststartdate, AV67Leaverequestwwds_5_tfleaverequeststartdate_to, AV68Leaverequestwwds_6_tfleaverequestenddate, AV69Leaverequestwwds_7_tfleaverequestenddate_to, lV70Leaverequestwwds_8_tfleaverequesthalfday, AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, AV73Leaverequestwwds_11_tfleaverequestduration, AV74Leaverequestwwds_12_tfleaverequestduration_to, lV78Leaverequestwwds_16_tfleaverequestdescription, AV79Leaverequestwwds_17_tfleaverequestdescription_sel, lV80Leaverequestwwds_18_tfleaverequestrejectionreason, AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8C4 = false;
            A124LeaveTypeId = P008C3_A124LeaveTypeId[0];
            A100CompanyId = P008C3_A100CompanyId[0];
            A106EmployeeId = P008C3_A106EmployeeId[0];
            A173LeaveRequestHalfDay = P008C3_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P008C3_n173LeaveRequestHalfDay[0];
            A134LeaveRequestRejectionReason = P008C3_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P008C3_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008C3_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008C3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C3_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P008C3_A125LeaveTypeName[0];
            A132LeaveRequestStatus = P008C3_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P008C3_A127LeaveRequestId[0];
            A100CompanyId = P008C3_A100CompanyId[0];
            A125LeaveTypeName = P008C3_A125LeaveTypeName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008C3_A173LeaveRequestHalfDay[0], A173LeaveRequestHalfDay) == 0 ) )
            {
               BRK8C4 = false;
               A127LeaveRequestId = P008C3_A127LeaveRequestId[0];
               AV43count = (long)(AV43count+1);
               BRK8C4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV34SkipItems) )
            {
               AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveRequestHalfDay)) ? "<#Empty#>" : A173LeaveRequestHalfDay);
               AV39Options.Add(AV38Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV39Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV34SkipItems = (short)(AV34SkipItems-1);
            }
            if ( ! BRK8C4 )
            {
               BRK8C4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV27TFLeaveRequestDescription = AV33SearchTxt;
         AV28TFLeaveRequestDescription_Sel = "";
         AV63Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV64Leaverequestwwds_2_tfleavetypename = AV15TFLeaveTypeName;
         AV65Leaverequestwwds_3_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV66Leaverequestwwds_4_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV67Leaverequestwwds_5_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV68Leaverequestwwds_6_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV69Leaverequestwwds_7_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV70Leaverequestwwds_8_tfleaverequesthalfday = AV56TFLeaveRequestHalfDay;
         AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator = AV60TFLeaveRequestHalfDayOperator;
         AV72Leaverequestwwds_10_tfleaverequesthalfday_sel = AV57TFLeaveRequestHalfDay_Sel;
         AV73Leaverequestwwds_11_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV74Leaverequestwwds_12_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV75Leaverequestwwds_13_tfleaverequeststatus = AV58TFLeaveRequestStatus;
         AV76Leaverequestwwds_14_tfleaverequeststatusoperator = AV59TFLeaveRequestStatusOperator;
         AV77Leaverequestwwds_15_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV78Leaverequestwwds_16_tfleaverequestdescription = AV27TFLeaveRequestDescription;
         AV79Leaverequestwwds_17_tfleaverequestdescription_sel = AV28TFLeaveRequestDescription_Sel;
         AV80Leaverequestwwds_18_tfleaverequestrejectionreason = AV29TFLeaveRequestRejectionReason;
         AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel = AV30TFLeaveRequestRejectionReason_Sel;
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV89Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg21 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV77Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                              AV63Leaverequestwwds_1_filterfulltext ,
                                              AV65Leaverequestwwds_3_tfleavetypename_sel ,
                                              AV64Leaverequestwwds_2_tfleavetypename ,
                                              AV66Leaverequestwwds_4_tfleaverequeststartdate ,
                                              AV67Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                              AV68Leaverequestwwds_6_tfleaverequestenddate ,
                                              AV69Leaverequestwwds_7_tfleaverequestenddate_to ,
                                              AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                              AV70Leaverequestwwds_8_tfleaverequesthalfday ,
                                              AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                              AV73Leaverequestwwds_11_tfleaverequestduration ,
                                              AV74Leaverequestwwds_12_tfleaverequestduration_to ,
                                              AV77Leaverequestwwds_15_tfleaverequeststatus_sels.Count ,
                                              AV76Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                              AV79Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                              AV78Leaverequestwwds_16_tfleaverequestdescription ,
                                              AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                              AV80Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV89Udparg23 ,
                                              A106EmployeeId ,
                                              AV83Udparg21 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV64Leaverequestwwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV64Leaverequestwwds_2_tfleavetypename), 100, "%");
         lV70Leaverequestwwds_8_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV70Leaverequestwwds_8_tfleaverequesthalfday), 20, "%");
         lV78Leaverequestwwds_16_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV78Leaverequestwwds_16_tfleaverequestdescription), "%", "");
         lV80Leaverequestwwds_18_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV80Leaverequestwwds_18_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008C4 */
         pr_default.execute(2, new Object[] {AV89Udparg23, AV83Udparg21, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV64Leaverequestwwds_2_tfleavetypename, AV65Leaverequestwwds_3_tfleavetypename_sel, AV66Leaverequestwwds_4_tfleaverequeststartdate, AV67Leaverequestwwds_5_tfleaverequeststartdate_to, AV68Leaverequestwwds_6_tfleaverequestenddate, AV69Leaverequestwwds_7_tfleaverequestenddate_to, lV70Leaverequestwwds_8_tfleaverequesthalfday, AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, AV73Leaverequestwwds_11_tfleaverequestduration, AV74Leaverequestwwds_12_tfleaverequestduration_to, lV78Leaverequestwwds_16_tfleaverequestdescription, AV79Leaverequestwwds_17_tfleaverequestdescription_sel, lV80Leaverequestwwds_18_tfleaverequestrejectionreason, AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8C6 = false;
            A124LeaveTypeId = P008C4_A124LeaveTypeId[0];
            A100CompanyId = P008C4_A100CompanyId[0];
            A106EmployeeId = P008C4_A106EmployeeId[0];
            A133LeaveRequestDescription = P008C4_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = P008C4_A134LeaveRequestRejectionReason[0];
            A131LeaveRequestDuration = P008C4_A131LeaveRequestDuration[0];
            A173LeaveRequestHalfDay = P008C4_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P008C4_n173LeaveRequestHalfDay[0];
            A130LeaveRequestEndDate = P008C4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C4_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P008C4_A125LeaveTypeName[0];
            A132LeaveRequestStatus = P008C4_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P008C4_A127LeaveRequestId[0];
            A100CompanyId = P008C4_A100CompanyId[0];
            A125LeaveTypeName = P008C4_A125LeaveTypeName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008C4_A133LeaveRequestDescription[0], A133LeaveRequestDescription) == 0 ) )
            {
               BRK8C6 = false;
               A127LeaveRequestId = P008C4_A127LeaveRequestId[0];
               AV43count = (long)(AV43count+1);
               BRK8C6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV34SkipItems) )
            {
               AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A133LeaveRequestDescription)) ? "<#Empty#>" : A133LeaveRequestDescription);
               AV39Options.Add(AV38Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV39Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV34SkipItems = (short)(AV34SkipItems-1);
            }
            if ( ! BRK8C6 )
            {
               BRK8C6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADLEAVEREQUESTREJECTIONREASONOPTIONS' Routine */
         returnInSub = false;
         AV29TFLeaveRequestRejectionReason = AV33SearchTxt;
         AV30TFLeaveRequestRejectionReason_Sel = "";
         AV63Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV64Leaverequestwwds_2_tfleavetypename = AV15TFLeaveTypeName;
         AV65Leaverequestwwds_3_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV66Leaverequestwwds_4_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV67Leaverequestwwds_5_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV68Leaverequestwwds_6_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV69Leaverequestwwds_7_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV70Leaverequestwwds_8_tfleaverequesthalfday = AV56TFLeaveRequestHalfDay;
         AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator = AV60TFLeaveRequestHalfDayOperator;
         AV72Leaverequestwwds_10_tfleaverequesthalfday_sel = AV57TFLeaveRequestHalfDay_Sel;
         AV73Leaverequestwwds_11_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV74Leaverequestwwds_12_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV75Leaverequestwwds_13_tfleaverequeststatus = AV58TFLeaveRequestStatus;
         AV76Leaverequestwwds_14_tfleaverequeststatusoperator = AV59TFLeaveRequestStatusOperator;
         AV77Leaverequestwwds_15_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV78Leaverequestwwds_16_tfleaverequestdescription = AV27TFLeaveRequestDescription;
         AV79Leaverequestwwds_17_tfleaverequestdescription_sel = AV28TFLeaveRequestDescription_Sel;
         AV80Leaverequestwwds_18_tfleaverequestrejectionreason = AV29TFLeaveRequestRejectionReason;
         AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel = AV30TFLeaveRequestRejectionReason_Sel;
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV92Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg21 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV77Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                              AV63Leaverequestwwds_1_filterfulltext ,
                                              AV65Leaverequestwwds_3_tfleavetypename_sel ,
                                              AV64Leaverequestwwds_2_tfleavetypename ,
                                              AV66Leaverequestwwds_4_tfleaverequeststartdate ,
                                              AV67Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                              AV68Leaverequestwwds_6_tfleaverequestenddate ,
                                              AV69Leaverequestwwds_7_tfleaverequestenddate_to ,
                                              AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                              AV70Leaverequestwwds_8_tfleaverequesthalfday ,
                                              AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                              AV73Leaverequestwwds_11_tfleaverequestduration ,
                                              AV74Leaverequestwwds_12_tfleaverequestduration_to ,
                                              AV77Leaverequestwwds_15_tfleaverequeststatus_sels.Count ,
                                              AV76Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                              AV79Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                              AV78Leaverequestwwds_16_tfleaverequestdescription ,
                                              AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                              AV80Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV92Udparg24 ,
                                              A106EmployeeId ,
                                              AV83Udparg21 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext), "%", "");
         lV64Leaverequestwwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV64Leaverequestwwds_2_tfleavetypename), 100, "%");
         lV70Leaverequestwwds_8_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV70Leaverequestwwds_8_tfleaverequesthalfday), 20, "%");
         lV78Leaverequestwwds_16_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV78Leaverequestwwds_16_tfleaverequestdescription), "%", "");
         lV80Leaverequestwwds_18_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV80Leaverequestwwds_18_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008C5 */
         pr_default.execute(3, new Object[] {AV92Udparg24, AV83Udparg21, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV63Leaverequestwwds_1_filterfulltext, lV64Leaverequestwwds_2_tfleavetypename, AV65Leaverequestwwds_3_tfleavetypename_sel, AV66Leaverequestwwds_4_tfleaverequeststartdate, AV67Leaverequestwwds_5_tfleaverequeststartdate_to, AV68Leaverequestwwds_6_tfleaverequestenddate, AV69Leaverequestwwds_7_tfleaverequestenddate_to, lV70Leaverequestwwds_8_tfleaverequesthalfday, AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, AV73Leaverequestwwds_11_tfleaverequestduration, AV74Leaverequestwwds_12_tfleaverequestduration_to, lV78Leaverequestwwds_16_tfleaverequestdescription, AV79Leaverequestwwds_17_tfleaverequestdescription_sel, lV80Leaverequestwwds_18_tfleaverequestrejectionreason, AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK8C8 = false;
            A124LeaveTypeId = P008C5_A124LeaveTypeId[0];
            A100CompanyId = P008C5_A100CompanyId[0];
            A106EmployeeId = P008C5_A106EmployeeId[0];
            A134LeaveRequestRejectionReason = P008C5_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P008C5_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008C5_A131LeaveRequestDuration[0];
            A173LeaveRequestHalfDay = P008C5_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P008C5_n173LeaveRequestHalfDay[0];
            A130LeaveRequestEndDate = P008C5_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C5_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P008C5_A125LeaveTypeName[0];
            A132LeaveRequestStatus = P008C5_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P008C5_A127LeaveRequestId[0];
            A100CompanyId = P008C5_A100CompanyId[0];
            A125LeaveTypeName = P008C5_A125LeaveTypeName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P008C5_A134LeaveRequestRejectionReason[0], A134LeaveRequestRejectionReason) == 0 ) )
            {
               BRK8C8 = false;
               A127LeaveRequestId = P008C5_A127LeaveRequestId[0];
               AV43count = (long)(AV43count+1);
               BRK8C8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV34SkipItems) )
            {
               AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A134LeaveRequestRejectionReason)) ? "<#Empty#>" : A134LeaveRequestRejectionReason);
               AV39Options.Add(AV38Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV39Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV34SkipItems = (short)(AV34SkipItems-1);
            }
            if ( ! BRK8C8 )
            {
               BRK8C8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV52OptionsJson = "";
         AV53OptionsDescJson = "";
         AV54OptionIndexesJson = "";
         AV39Options = new GxSimpleCollection<string>();
         AV41OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV33SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Session = context.GetSession();
         AV46GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV47GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55FilterFullText = "";
         AV15TFLeaveTypeName = "";
         AV16TFLeaveTypeName_Sel = "";
         AV19TFLeaveRequestStartDate = DateTime.MinValue;
         AV20TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV21TFLeaveRequestEndDate = DateTime.MinValue;
         AV22TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV56TFLeaveRequestHalfDay = "";
         AV57TFLeaveRequestHalfDay_Sel = "";
         AV25TFLeaveRequestStatus_SelsJson = "";
         AV26TFLeaveRequestStatus_Sels = new GxSimpleCollection<string>();
         AV27TFLeaveRequestDescription = "";
         AV28TFLeaveRequestDescription_Sel = "";
         AV29TFLeaveRequestRejectionReason = "";
         AV30TFLeaveRequestRejectionReason_Sel = "";
         AV63Leaverequestwwds_1_filterfulltext = "";
         AV64Leaverequestwwds_2_tfleavetypename = "";
         AV65Leaverequestwwds_3_tfleavetypename_sel = "";
         AV66Leaverequestwwds_4_tfleaverequeststartdate = DateTime.MinValue;
         AV67Leaverequestwwds_5_tfleaverequeststartdate_to = DateTime.MinValue;
         AV68Leaverequestwwds_6_tfleaverequestenddate = DateTime.MinValue;
         AV69Leaverequestwwds_7_tfleaverequestenddate_to = DateTime.MinValue;
         AV70Leaverequestwwds_8_tfleaverequesthalfday = "";
         AV72Leaverequestwwds_10_tfleaverequesthalfday_sel = "";
         AV75Leaverequestwwds_13_tfleaverequeststatus = "";
         AV58TFLeaveRequestStatus = "";
         AV77Leaverequestwwds_15_tfleaverequeststatus_sels = new GxSimpleCollection<string>();
         AV78Leaverequestwwds_16_tfleaverequestdescription = "";
         AV79Leaverequestwwds_17_tfleaverequestdescription_sel = "";
         AV80Leaverequestwwds_18_tfleaverequestrejectionreason = "";
         AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel = "";
         scmdbuf = "";
         lV63Leaverequestwwds_1_filterfulltext = "";
         lV64Leaverequestwwds_2_tfleavetypename = "";
         lV70Leaverequestwwds_8_tfleaverequesthalfday = "";
         lV78Leaverequestwwds_16_tfleaverequestdescription = "";
         lV80Leaverequestwwds_18_tfleaverequestrejectionreason = "";
         A132LeaveRequestStatus = "";
         A125LeaveTypeName = "";
         A173LeaveRequestHalfDay = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P008C2_A124LeaveTypeId = new long[1] ;
         P008C2_A106EmployeeId = new long[1] ;
         P008C2_A100CompanyId = new long[1] ;
         P008C2_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008C2_A133LeaveRequestDescription = new string[] {""} ;
         P008C2_A131LeaveRequestDuration = new decimal[1] ;
         P008C2_A173LeaveRequestHalfDay = new string[] {""} ;
         P008C2_n173LeaveRequestHalfDay = new bool[] {false} ;
         P008C2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C2_A125LeaveTypeName = new string[] {""} ;
         P008C2_A132LeaveRequestStatus = new string[] {""} ;
         P008C2_A127LeaveRequestId = new long[1] ;
         AV38Option = "";
         P008C3_A124LeaveTypeId = new long[1] ;
         P008C3_A100CompanyId = new long[1] ;
         P008C3_A106EmployeeId = new long[1] ;
         P008C3_A173LeaveRequestHalfDay = new string[] {""} ;
         P008C3_n173LeaveRequestHalfDay = new bool[] {false} ;
         P008C3_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008C3_A133LeaveRequestDescription = new string[] {""} ;
         P008C3_A131LeaveRequestDuration = new decimal[1] ;
         P008C3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C3_A125LeaveTypeName = new string[] {""} ;
         P008C3_A132LeaveRequestStatus = new string[] {""} ;
         P008C3_A127LeaveRequestId = new long[1] ;
         P008C4_A124LeaveTypeId = new long[1] ;
         P008C4_A100CompanyId = new long[1] ;
         P008C4_A106EmployeeId = new long[1] ;
         P008C4_A133LeaveRequestDescription = new string[] {""} ;
         P008C4_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008C4_A131LeaveRequestDuration = new decimal[1] ;
         P008C4_A173LeaveRequestHalfDay = new string[] {""} ;
         P008C4_n173LeaveRequestHalfDay = new bool[] {false} ;
         P008C4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C4_A125LeaveTypeName = new string[] {""} ;
         P008C4_A132LeaveRequestStatus = new string[] {""} ;
         P008C4_A127LeaveRequestId = new long[1] ;
         P008C5_A124LeaveTypeId = new long[1] ;
         P008C5_A100CompanyId = new long[1] ;
         P008C5_A106EmployeeId = new long[1] ;
         P008C5_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008C5_A133LeaveRequestDescription = new string[] {""} ;
         P008C5_A131LeaveRequestDuration = new decimal[1] ;
         P008C5_A173LeaveRequestHalfDay = new string[] {""} ;
         P008C5_n173LeaveRequestHalfDay = new bool[] {false} ;
         P008C5_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C5_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C5_A125LeaveTypeName = new string[] {""} ;
         P008C5_A132LeaveRequestStatus = new string[] {""} ;
         P008C5_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008C2_A124LeaveTypeId, P008C2_A106EmployeeId, P008C2_A100CompanyId, P008C2_A134LeaveRequestRejectionReason, P008C2_A133LeaveRequestDescription, P008C2_A131LeaveRequestDuration, P008C2_A173LeaveRequestHalfDay, P008C2_n173LeaveRequestHalfDay, P008C2_A130LeaveRequestEndDate, P008C2_A129LeaveRequestStartDate,
               P008C2_A125LeaveTypeName, P008C2_A132LeaveRequestStatus, P008C2_A127LeaveRequestId
               }
               , new Object[] {
               P008C3_A124LeaveTypeId, P008C3_A100CompanyId, P008C3_A106EmployeeId, P008C3_A173LeaveRequestHalfDay, P008C3_n173LeaveRequestHalfDay, P008C3_A134LeaveRequestRejectionReason, P008C3_A133LeaveRequestDescription, P008C3_A131LeaveRequestDuration, P008C3_A130LeaveRequestEndDate, P008C3_A129LeaveRequestStartDate,
               P008C3_A125LeaveTypeName, P008C3_A132LeaveRequestStatus, P008C3_A127LeaveRequestId
               }
               , new Object[] {
               P008C4_A124LeaveTypeId, P008C4_A100CompanyId, P008C4_A106EmployeeId, P008C4_A133LeaveRequestDescription, P008C4_A134LeaveRequestRejectionReason, P008C4_A131LeaveRequestDuration, P008C4_A173LeaveRequestHalfDay, P008C4_n173LeaveRequestHalfDay, P008C4_A130LeaveRequestEndDate, P008C4_A129LeaveRequestStartDate,
               P008C4_A125LeaveTypeName, P008C4_A132LeaveRequestStatus, P008C4_A127LeaveRequestId
               }
               , new Object[] {
               P008C5_A124LeaveTypeId, P008C5_A100CompanyId, P008C5_A106EmployeeId, P008C5_A134LeaveRequestRejectionReason, P008C5_A133LeaveRequestDescription, P008C5_A131LeaveRequestDuration, P008C5_A173LeaveRequestHalfDay, P008C5_n173LeaveRequestHalfDay, P008C5_A130LeaveRequestEndDate, P008C5_A129LeaveRequestStartDate,
               P008C5_A125LeaveTypeName, P008C5_A132LeaveRequestStatus, P008C5_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short AV60TFLeaveRequestHalfDayOperator ;
      private short AV59TFLeaveRequestStatusOperator ;
      private short AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ;
      private short AV76Leaverequestwwds_14_tfleaverequeststatusoperator ;
      private int AV61GXV1 ;
      private int AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count ;
      private int AV37InsertIndex ;
      private long AV82Udparg20 ;
      private long AV83Udparg21 ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV43count ;
      private long AV86Udparg22 ;
      private long AV89Udparg23 ;
      private long AV92Udparg24 ;
      private decimal AV23TFLeaveRequestDuration ;
      private decimal AV24TFLeaveRequestDuration_To ;
      private decimal AV73Leaverequestwwds_11_tfleaverequestduration ;
      private decimal AV74Leaverequestwwds_12_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV15TFLeaveTypeName ;
      private string AV16TFLeaveTypeName_Sel ;
      private string AV56TFLeaveRequestHalfDay ;
      private string AV57TFLeaveRequestHalfDay_Sel ;
      private string AV64Leaverequestwwds_2_tfleavetypename ;
      private string AV65Leaverequestwwds_3_tfleavetypename_sel ;
      private string AV70Leaverequestwwds_8_tfleaverequesthalfday ;
      private string AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ;
      private string AV75Leaverequestwwds_13_tfleaverequeststatus ;
      private string AV58TFLeaveRequestStatus ;
      private string scmdbuf ;
      private string lV64Leaverequestwwds_2_tfleavetypename ;
      private string lV70Leaverequestwwds_8_tfleaverequesthalfday ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private string A173LeaveRequestHalfDay ;
      private DateTime AV19TFLeaveRequestStartDate ;
      private DateTime AV20TFLeaveRequestStartDate_To ;
      private DateTime AV21TFLeaveRequestEndDate ;
      private DateTime AV22TFLeaveRequestEndDate_To ;
      private DateTime AV66Leaverequestwwds_4_tfleaverequeststartdate ;
      private DateTime AV67Leaverequestwwds_5_tfleaverequeststartdate_to ;
      private DateTime AV68Leaverequestwwds_6_tfleaverequestenddate ;
      private DateTime AV69Leaverequestwwds_7_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK8C2 ;
      private bool n173LeaveRequestHalfDay ;
      private bool BRK8C4 ;
      private bool BRK8C6 ;
      private bool BRK8C8 ;
      private string AV52OptionsJson ;
      private string AV53OptionsDescJson ;
      private string AV54OptionIndexesJson ;
      private string AV25TFLeaveRequestStatus_SelsJson ;
      private string AV49DDOName ;
      private string AV50SearchTxtParms ;
      private string AV51SearchTxtTo ;
      private string AV33SearchTxt ;
      private string AV55FilterFullText ;
      private string AV27TFLeaveRequestDescription ;
      private string AV28TFLeaveRequestDescription_Sel ;
      private string AV29TFLeaveRequestRejectionReason ;
      private string AV30TFLeaveRequestRejectionReason_Sel ;
      private string AV63Leaverequestwwds_1_filterfulltext ;
      private string AV78Leaverequestwwds_16_tfleaverequestdescription ;
      private string AV79Leaverequestwwds_17_tfleaverequestdescription_sel ;
      private string AV80Leaverequestwwds_18_tfleaverequestrejectionreason ;
      private string AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ;
      private string lV63Leaverequestwwds_1_filterfulltext ;
      private string lV78Leaverequestwwds_16_tfleaverequestdescription ;
      private string lV80Leaverequestwwds_18_tfleaverequestrejectionreason ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string AV38Option ;
      private IGxSession AV44Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008C2_A124LeaveTypeId ;
      private long[] P008C2_A106EmployeeId ;
      private long[] P008C2_A100CompanyId ;
      private string[] P008C2_A134LeaveRequestRejectionReason ;
      private string[] P008C2_A133LeaveRequestDescription ;
      private decimal[] P008C2_A131LeaveRequestDuration ;
      private string[] P008C2_A173LeaveRequestHalfDay ;
      private bool[] P008C2_n173LeaveRequestHalfDay ;
      private DateTime[] P008C2_A130LeaveRequestEndDate ;
      private DateTime[] P008C2_A129LeaveRequestStartDate ;
      private string[] P008C2_A125LeaveTypeName ;
      private string[] P008C2_A132LeaveRequestStatus ;
      private long[] P008C2_A127LeaveRequestId ;
      private long[] P008C3_A124LeaveTypeId ;
      private long[] P008C3_A100CompanyId ;
      private long[] P008C3_A106EmployeeId ;
      private string[] P008C3_A173LeaveRequestHalfDay ;
      private bool[] P008C3_n173LeaveRequestHalfDay ;
      private string[] P008C3_A134LeaveRequestRejectionReason ;
      private string[] P008C3_A133LeaveRequestDescription ;
      private decimal[] P008C3_A131LeaveRequestDuration ;
      private DateTime[] P008C3_A130LeaveRequestEndDate ;
      private DateTime[] P008C3_A129LeaveRequestStartDate ;
      private string[] P008C3_A125LeaveTypeName ;
      private string[] P008C3_A132LeaveRequestStatus ;
      private long[] P008C3_A127LeaveRequestId ;
      private long[] P008C4_A124LeaveTypeId ;
      private long[] P008C4_A100CompanyId ;
      private long[] P008C4_A106EmployeeId ;
      private string[] P008C4_A133LeaveRequestDescription ;
      private string[] P008C4_A134LeaveRequestRejectionReason ;
      private decimal[] P008C4_A131LeaveRequestDuration ;
      private string[] P008C4_A173LeaveRequestHalfDay ;
      private bool[] P008C4_n173LeaveRequestHalfDay ;
      private DateTime[] P008C4_A130LeaveRequestEndDate ;
      private DateTime[] P008C4_A129LeaveRequestStartDate ;
      private string[] P008C4_A125LeaveTypeName ;
      private string[] P008C4_A132LeaveRequestStatus ;
      private long[] P008C4_A127LeaveRequestId ;
      private long[] P008C5_A124LeaveTypeId ;
      private long[] P008C5_A100CompanyId ;
      private long[] P008C5_A106EmployeeId ;
      private string[] P008C5_A134LeaveRequestRejectionReason ;
      private string[] P008C5_A133LeaveRequestDescription ;
      private decimal[] P008C5_A131LeaveRequestDuration ;
      private string[] P008C5_A173LeaveRequestHalfDay ;
      private bool[] P008C5_n173LeaveRequestHalfDay ;
      private DateTime[] P008C5_A130LeaveRequestEndDate ;
      private DateTime[] P008C5_A129LeaveRequestStartDate ;
      private string[] P008C5_A125LeaveTypeName ;
      private string[] P008C5_A132LeaveRequestStatus ;
      private long[] P008C5_A127LeaveRequestId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV26TFLeaveRequestStatus_Sels ;
      private GxSimpleCollection<string> AV77Leaverequestwwds_15_tfleaverequeststatus_sels ;
      private GxSimpleCollection<string> AV39Options ;
      private GxSimpleCollection<string> AV41OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV46GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV47GridStateFilterValue ;
   }

   public class leaverequestwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008C2( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV77Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                             string AV63Leaverequestwwds_1_filterfulltext ,
                                             string AV65Leaverequestwwds_3_tfleavetypename_sel ,
                                             string AV64Leaverequestwwds_2_tfleavetypename ,
                                             DateTime AV66Leaverequestwwds_4_tfleaverequeststartdate ,
                                             DateTime AV67Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                             DateTime AV68Leaverequestwwds_6_tfleaverequestenddate ,
                                             DateTime AV69Leaverequestwwds_7_tfleaverequestenddate_to ,
                                             string AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                             string AV70Leaverequestwwds_8_tfleaverequesthalfday ,
                                             short AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                             decimal AV73Leaverequestwwds_11_tfleaverequestduration ,
                                             decimal AV74Leaverequestwwds_12_tfleaverequestduration_to ,
                                             int AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count ,
                                             short AV76Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                             string AV79Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                             string AV78Leaverequestwwds_16_tfleaverequestdescription ,
                                             string AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                             string AV80Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV82Udparg20 ,
                                             long A106EmployeeId ,
                                             long AV83Udparg21 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[24];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV82Udparg20)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV83Udparg21)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV63Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV64Leaverequestwwds_2_tfleavetypename))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV65Leaverequestwwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestwwds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV66Leaverequestwwds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestwwds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV67Leaverequestwwds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV68Leaverequestwwds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV69Leaverequestwwds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Leaverequestwwds_8_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV70Leaverequestwwds_8_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV72Leaverequestwwds_10_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestwwds_11_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV73Leaverequestwwds_11_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Leaverequestwwds_12_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV74Leaverequestwwds_12_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Leaverequestwwds_15_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_17_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Leaverequestwwds_16_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV78Leaverequestwwds_16_tfleaverequestdescription))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_17_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV79Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV79Leaverequestwwds_17_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV79Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestwwds_18_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV80Leaverequestwwds_18_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008C3( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV77Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                             string AV63Leaverequestwwds_1_filterfulltext ,
                                             string AV65Leaverequestwwds_3_tfleavetypename_sel ,
                                             string AV64Leaverequestwwds_2_tfleavetypename ,
                                             DateTime AV66Leaverequestwwds_4_tfleaverequeststartdate ,
                                             DateTime AV67Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                             DateTime AV68Leaverequestwwds_6_tfleaverequestenddate ,
                                             DateTime AV69Leaverequestwwds_7_tfleaverequestenddate_to ,
                                             string AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                             string AV70Leaverequestwwds_8_tfleaverequesthalfday ,
                                             short AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                             decimal AV73Leaverequestwwds_11_tfleaverequestduration ,
                                             decimal AV74Leaverequestwwds_12_tfleaverequestduration_to ,
                                             int AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count ,
                                             short AV76Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                             string AV79Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                             string AV78Leaverequestwwds_16_tfleaverequestdescription ,
                                             string AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                             string AV80Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV86Udparg22 ,
                                             long A106EmployeeId ,
                                             long AV83Udparg21 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T1.EmployeeId, T1.LeaveRequestHalfDay, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV86Udparg22)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV83Udparg21)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV63Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV64Leaverequestwwds_2_tfleavetypename))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV65Leaverequestwwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestwwds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV66Leaverequestwwds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestwwds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV67Leaverequestwwds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV68Leaverequestwwds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV69Leaverequestwwds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Leaverequestwwds_8_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV70Leaverequestwwds_8_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV72Leaverequestwwds_10_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestwwds_11_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV73Leaverequestwwds_11_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Leaverequestwwds_12_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV74Leaverequestwwds_12_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Leaverequestwwds_15_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_17_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Leaverequestwwds_16_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV78Leaverequestwwds_16_tfleaverequestdescription))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_17_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV79Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV79Leaverequestwwds_17_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV79Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestwwds_18_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV80Leaverequestwwds_18_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestHalfDay";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008C4( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV77Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                             string AV63Leaverequestwwds_1_filterfulltext ,
                                             string AV65Leaverequestwwds_3_tfleavetypename_sel ,
                                             string AV64Leaverequestwwds_2_tfleavetypename ,
                                             DateTime AV66Leaverequestwwds_4_tfleaverequeststartdate ,
                                             DateTime AV67Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                             DateTime AV68Leaverequestwwds_6_tfleaverequestenddate ,
                                             DateTime AV69Leaverequestwwds_7_tfleaverequestenddate_to ,
                                             string AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                             string AV70Leaverequestwwds_8_tfleaverequesthalfday ,
                                             short AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                             decimal AV73Leaverequestwwds_11_tfleaverequestduration ,
                                             decimal AV74Leaverequestwwds_12_tfleaverequestduration_to ,
                                             int AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count ,
                                             short AV76Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                             string AV79Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                             string AV78Leaverequestwwds_16_tfleaverequestdescription ,
                                             string AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                             string AV80Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV89Udparg23 ,
                                             long A106EmployeeId ,
                                             long AV83Udparg21 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[24];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T1.EmployeeId, T1.LeaveRequestDescription, T1.LeaveRequestRejectionReason, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV89Udparg23)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV83Udparg21)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV63Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV64Leaverequestwwds_2_tfleavetypename))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV65Leaverequestwwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestwwds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV66Leaverequestwwds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestwwds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV67Leaverequestwwds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV68Leaverequestwwds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV69Leaverequestwwds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Leaverequestwwds_8_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV70Leaverequestwwds_8_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV72Leaverequestwwds_10_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestwwds_11_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV73Leaverequestwwds_11_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Leaverequestwwds_12_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV74Leaverequestwwds_12_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Leaverequestwwds_15_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_17_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Leaverequestwwds_16_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV78Leaverequestwwds_16_tfleaverequestdescription))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_17_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV79Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV79Leaverequestwwds_17_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV79Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestwwds_18_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV80Leaverequestwwds_18_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P008C5( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV77Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                             string AV63Leaverequestwwds_1_filterfulltext ,
                                             string AV65Leaverequestwwds_3_tfleavetypename_sel ,
                                             string AV64Leaverequestwwds_2_tfleavetypename ,
                                             DateTime AV66Leaverequestwwds_4_tfleaverequeststartdate ,
                                             DateTime AV67Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                             DateTime AV68Leaverequestwwds_6_tfleaverequestenddate ,
                                             DateTime AV69Leaverequestwwds_7_tfleaverequestenddate_to ,
                                             string AV72Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                             string AV70Leaverequestwwds_8_tfleaverequesthalfday ,
                                             short AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                             decimal AV73Leaverequestwwds_11_tfleaverequestduration ,
                                             decimal AV74Leaverequestwwds_12_tfleaverequestduration_to ,
                                             int AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count ,
                                             short AV76Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                             string AV79Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                             string AV78Leaverequestwwds_16_tfleaverequestdescription ,
                                             string AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                             string AV80Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV92Udparg24 ,
                                             long A106EmployeeId ,
                                             long AV83Udparg21 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[24];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV92Udparg24)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV83Udparg21)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV63Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV63Leaverequestwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV64Leaverequestwwds_2_tfleavetypename))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV65Leaverequestwwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestwwds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV66Leaverequestwwds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestwwds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV67Leaverequestwwds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV68Leaverequestwwds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV69Leaverequestwwds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Leaverequestwwds_8_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV70Leaverequestwwds_8_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV72Leaverequestwwds_10_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV72Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV71Leaverequestwwds_9_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestwwds_11_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV73Leaverequestwwds_11_tfleaverequestduration)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Leaverequestwwds_12_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV74Leaverequestwwds_12_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV77Leaverequestwwds_15_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Leaverequestwwds_15_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV76Leaverequestwwds_14_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_17_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Leaverequestwwds_16_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV78Leaverequestwwds_16_tfleaverequestdescription))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_17_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV79Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV79Leaverequestwwds_17_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV79Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestwwds_18_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV80Leaverequestwwds_18_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( StringUtil.StrCmp(AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestRejectionReason";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] );
               case 1 :
                     return conditional_P008C3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] );
               case 2 :
                     return conditional_P008C4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] );
               case 3 :
                     return conditional_P008C5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008C2;
          prmP008C2 = new Object[] {
          new ParDef("AV82Udparg20",GXType.Int64,10,0) ,
          new ParDef("AV83Udparg21",GXType.Int64,10,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Leaverequestwwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV65Leaverequestwwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV66Leaverequestwwds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestwwds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV68Leaverequestwwds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV70Leaverequestwwds_8_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV72Leaverequestwwds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV73Leaverequestwwds_11_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV74Leaverequestwwds_12_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV78Leaverequestwwds_16_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV79Leaverequestwwds_17_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV80Leaverequestwwds_18_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
          };
          Object[] prmP008C3;
          prmP008C3 = new Object[] {
          new ParDef("AV86Udparg22",GXType.Int64,10,0) ,
          new ParDef("AV83Udparg21",GXType.Int64,10,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Leaverequestwwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV65Leaverequestwwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV66Leaverequestwwds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestwwds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV68Leaverequestwwds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV70Leaverequestwwds_8_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV72Leaverequestwwds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV73Leaverequestwwds_11_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV74Leaverequestwwds_12_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV78Leaverequestwwds_16_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV79Leaverequestwwds_17_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV80Leaverequestwwds_18_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
          };
          Object[] prmP008C4;
          prmP008C4 = new Object[] {
          new ParDef("AV89Udparg23",GXType.Int64,10,0) ,
          new ParDef("AV83Udparg21",GXType.Int64,10,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Leaverequestwwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV65Leaverequestwwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV66Leaverequestwwds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestwwds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV68Leaverequestwwds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV70Leaverequestwwds_8_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV72Leaverequestwwds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV73Leaverequestwwds_11_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV74Leaverequestwwds_12_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV78Leaverequestwwds_16_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV79Leaverequestwwds_17_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV80Leaverequestwwds_18_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
          };
          Object[] prmP008C5;
          prmP008C5 = new Object[] {
          new ParDef("AV92Udparg24",GXType.Int64,10,0) ,
          new ParDef("AV83Udparg21",GXType.Int64,10,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Leaverequestwwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV65Leaverequestwwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV66Leaverequestwwds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestwwds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV68Leaverequestwwds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV70Leaverequestwwds_8_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV72Leaverequestwwds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV73Leaverequestwwds_11_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV74Leaverequestwwds_12_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV78Leaverequestwwds_16_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV79Leaverequestwwds_17_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV80Leaverequestwwds_18_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV81Leaverequestwwds_19_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008C5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C5,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
