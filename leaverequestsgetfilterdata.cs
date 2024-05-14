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
   public class leaverequestsgetfilterdata : GXProcedure
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
            return "leaverequests_Services_Execute" ;
         }

      }

      public leaverequestsgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestsgetfilterdata( IGxContext context )
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
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV48OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         leaverequestsgetfilterdata objleaverequestsgetfilterdata;
         objleaverequestsgetfilterdata = new leaverequestsgetfilterdata();
         objleaverequestsgetfilterdata.AV43DDOName = aP0_DDOName;
         objleaverequestsgetfilterdata.AV44SearchTxtParms = aP1_SearchTxtParms;
         objleaverequestsgetfilterdata.AV45SearchTxtTo = aP2_SearchTxtTo;
         objleaverequestsgetfilterdata.AV46OptionsJson = "" ;
         objleaverequestsgetfilterdata.AV47OptionsDescJson = "" ;
         objleaverequestsgetfilterdata.AV48OptionIndexesJson = "" ;
         objleaverequestsgetfilterdata.context.SetSubmitInitialConfig(context);
         objleaverequestsgetfilterdata.initialize();
         Submit( executePrivateCatch,objleaverequestsgetfilterdata);
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leaverequestsgetfilterdata)stateInfo).executePrivate();
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
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30MaxItems = 10;
         AV29PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
         AV28SkipItems = (short)(AV29PageIndex*AV30MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_LEAVEREQUESTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_LEAVEREQUESTREJECTIONREASON") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTREJECTIONREASONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV46OptionsJson = AV33Options.ToJSonString(false);
         AV47OptionsDescJson = AV35OptionsDesc.ToJSonString(false);
         AV48OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("LeaveRequestsGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LeaveRequestsGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("LeaveRequestsGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV49FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV11TFLeaveTypeName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV12TFLeaveTypeName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV15TFLeaveRequestStartDate = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 1);
               AV16TFLeaveRequestStartDate_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV17TFLeaveRequestEndDate = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 1);
               AV18TFLeaveRequestEndDate_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV19TFLeaveRequestDuration = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFLeaveRequestDuration_To = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS_SEL") == 0 )
            {
               AV21TFLeaveRequestStatus_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV22TFLeaveRequestStatus_Sels.FromJSonString(AV21TFLeaveRequestStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV23TFLeaveRequestDescription = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV24TFLeaveRequestDescription_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON") == 0 )
            {
               AV25TFLeaveRequestRejectionReason = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON_SEL") == 0 )
            {
               AV26TFLeaveRequestRejectionReason_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFLeaveTypeName = AV27SearchTxt;
         AV12TFLeaveTypeName_Sel = "";
         AV52Leaverequestsds_1_filterfulltext = AV49FilterFullText;
         AV53Leaverequestsds_2_tfleavetypename = AV11TFLeaveTypeName;
         AV54Leaverequestsds_3_tfleavetypename_sel = AV12TFLeaveTypeName_Sel;
         AV55Leaverequestsds_4_tfleaverequeststartdate = AV15TFLeaveRequestStartDate;
         AV56Leaverequestsds_5_tfleaverequeststartdate_to = AV16TFLeaveRequestStartDate_To;
         AV57Leaverequestsds_6_tfleaverequestenddate = AV17TFLeaveRequestEndDate;
         AV58Leaverequestsds_7_tfleaverequestenddate_to = AV18TFLeaveRequestEndDate_To;
         AV59Leaverequestsds_8_tfleaverequestduration = AV19TFLeaveRequestDuration;
         AV60Leaverequestsds_9_tfleaverequestduration_to = AV20TFLeaveRequestDuration_To;
         AV61Leaverequestsds_10_tfleaverequeststatus_sels = AV22TFLeaveRequestStatus_Sels;
         AV62Leaverequestsds_11_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV63Leaverequestsds_12_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV64Leaverequestsds_13_tfleaverequestrejectionreason = AV25TFLeaveRequestRejectionReason;
         AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel = AV26TFLeaveRequestRejectionReason_Sel;
         AV66Udparg15 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV61Leaverequestsds_10_tfleaverequeststatus_sels ,
                                              AV52Leaverequestsds_1_filterfulltext ,
                                              AV54Leaverequestsds_3_tfleavetypename_sel ,
                                              AV53Leaverequestsds_2_tfleavetypename ,
                                              AV55Leaverequestsds_4_tfleaverequeststartdate ,
                                              AV56Leaverequestsds_5_tfleaverequeststartdate_to ,
                                              AV57Leaverequestsds_6_tfleaverequestenddate ,
                                              AV58Leaverequestsds_7_tfleaverequestenddate_to ,
                                              AV59Leaverequestsds_8_tfleaverequestduration ,
                                              AV60Leaverequestsds_9_tfleaverequestduration_to ,
                                              AV61Leaverequestsds_10_tfleaverequeststatus_sels.Count ,
                                              AV63Leaverequestsds_12_tfleaverequestdescription_sel ,
                                              AV62Leaverequestsds_11_tfleaverequestdescription ,
                                              AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel ,
                                              AV64Leaverequestsds_13_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A106EmployeeId ,
                                              AV66Udparg15 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV53Leaverequestsds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leaverequestsds_2_tfleavetypename), 100, "%");
         lV62Leaverequestsds_11_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestsds_11_tfleaverequestdescription), "%", "");
         lV64Leaverequestsds_13_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV64Leaverequestsds_13_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008D2 */
         pr_default.execute(0, new Object[] {AV66Udparg15, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV53Leaverequestsds_2_tfleavetypename, AV54Leaverequestsds_3_tfleavetypename_sel, AV55Leaverequestsds_4_tfleaverequeststartdate, AV56Leaverequestsds_5_tfleaverequeststartdate_to, AV57Leaverequestsds_6_tfleaverequestenddate, AV58Leaverequestsds_7_tfleaverequestenddate_to, AV59Leaverequestsds_8_tfleaverequestduration, AV60Leaverequestsds_9_tfleaverequestduration_to, lV62Leaverequestsds_11_tfleaverequestdescription, AV63Leaverequestsds_12_tfleaverequestdescription_sel, lV64Leaverequestsds_13_tfleaverequestrejectionreason, AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8D2 = false;
            A124LeaveTypeId = P008D2_A124LeaveTypeId[0];
            A106EmployeeId = P008D2_A106EmployeeId[0];
            A134LeaveRequestRejectionReason = P008D2_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P008D2_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008D2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008D2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008D2_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P008D2_A125LeaveTypeName[0];
            A132LeaveRequestStatus = P008D2_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P008D2_A127LeaveRequestId[0];
            A125LeaveTypeName = P008D2_A125LeaveTypeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P008D2_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRK8D2 = false;
               A127LeaveRequestId = P008D2_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK8D2 = true;
               pr_default.readNext(0);
            }
            AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
            AV31InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV32Option, "<#Empty#>") != 0 ) && ( AV31InsertIndex <= AV33Options.Count ) && ( ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) || ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV31InsertIndex = (int)(AV31InsertIndex+1);
            }
            AV33Options.Add(AV32Option, AV31InsertIndex);
            AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            if ( AV33Options.Count == AV28SkipItems + 11 )
            {
               AV33Options.RemoveItem(AV33Options.Count);
               AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
            }
            if ( ! BRK8D2 )
            {
               BRK8D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV28SkipItems > 0 )
         {
            AV33Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV28SkipItems = (short)(AV28SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV23TFLeaveRequestDescription = AV27SearchTxt;
         AV24TFLeaveRequestDescription_Sel = "";
         AV52Leaverequestsds_1_filterfulltext = AV49FilterFullText;
         AV53Leaverequestsds_2_tfleavetypename = AV11TFLeaveTypeName;
         AV54Leaverequestsds_3_tfleavetypename_sel = AV12TFLeaveTypeName_Sel;
         AV55Leaverequestsds_4_tfleaverequeststartdate = AV15TFLeaveRequestStartDate;
         AV56Leaverequestsds_5_tfleaverequeststartdate_to = AV16TFLeaveRequestStartDate_To;
         AV57Leaverequestsds_6_tfleaverequestenddate = AV17TFLeaveRequestEndDate;
         AV58Leaverequestsds_7_tfleaverequestenddate_to = AV18TFLeaveRequestEndDate_To;
         AV59Leaverequestsds_8_tfleaverequestduration = AV19TFLeaveRequestDuration;
         AV60Leaverequestsds_9_tfleaverequestduration_to = AV20TFLeaveRequestDuration_To;
         AV61Leaverequestsds_10_tfleaverequeststatus_sels = AV22TFLeaveRequestStatus_Sels;
         AV62Leaverequestsds_11_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV63Leaverequestsds_12_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV64Leaverequestsds_13_tfleaverequestrejectionreason = AV25TFLeaveRequestRejectionReason;
         AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel = AV26TFLeaveRequestRejectionReason_Sel;
         AV66Udparg15 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV61Leaverequestsds_10_tfleaverequeststatus_sels ,
                                              AV52Leaverequestsds_1_filterfulltext ,
                                              AV54Leaverequestsds_3_tfleavetypename_sel ,
                                              AV53Leaverequestsds_2_tfleavetypename ,
                                              AV55Leaverequestsds_4_tfleaverequeststartdate ,
                                              AV56Leaverequestsds_5_tfleaverequeststartdate_to ,
                                              AV57Leaverequestsds_6_tfleaverequestenddate ,
                                              AV58Leaverequestsds_7_tfleaverequestenddate_to ,
                                              AV59Leaverequestsds_8_tfleaverequestduration ,
                                              AV60Leaverequestsds_9_tfleaverequestduration_to ,
                                              AV61Leaverequestsds_10_tfleaverequeststatus_sels.Count ,
                                              AV63Leaverequestsds_12_tfleaverequestdescription_sel ,
                                              AV62Leaverequestsds_11_tfleaverequestdescription ,
                                              AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel ,
                                              AV64Leaverequestsds_13_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A106EmployeeId ,
                                              AV66Udparg15 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV53Leaverequestsds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leaverequestsds_2_tfleavetypename), 100, "%");
         lV62Leaverequestsds_11_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestsds_11_tfleaverequestdescription), "%", "");
         lV64Leaverequestsds_13_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV64Leaverequestsds_13_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008D3 */
         pr_default.execute(1, new Object[] {AV66Udparg15, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV53Leaverequestsds_2_tfleavetypename, AV54Leaverequestsds_3_tfleavetypename_sel, AV55Leaverequestsds_4_tfleaverequeststartdate, AV56Leaverequestsds_5_tfleaverequeststartdate_to, AV57Leaverequestsds_6_tfleaverequestenddate, AV58Leaverequestsds_7_tfleaverequestenddate_to, AV59Leaverequestsds_8_tfleaverequestduration, AV60Leaverequestsds_9_tfleaverequestduration_to, lV62Leaverequestsds_11_tfleaverequestdescription, AV63Leaverequestsds_12_tfleaverequestdescription_sel, lV64Leaverequestsds_13_tfleaverequestrejectionreason, AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8D4 = false;
            A124LeaveTypeId = P008D3_A124LeaveTypeId[0];
            A106EmployeeId = P008D3_A106EmployeeId[0];
            A133LeaveRequestDescription = P008D3_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = P008D3_A134LeaveRequestRejectionReason[0];
            A131LeaveRequestDuration = P008D3_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008D3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008D3_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P008D3_A125LeaveTypeName[0];
            A132LeaveRequestStatus = P008D3_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P008D3_A127LeaveRequestId[0];
            A125LeaveTypeName = P008D3_A125LeaveTypeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008D3_A133LeaveRequestDescription[0], A133LeaveRequestDescription) == 0 ) )
            {
               BRK8D4 = false;
               A127LeaveRequestId = P008D3_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK8D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A133LeaveRequestDescription)) ? "<#Empty#>" : A133LeaveRequestDescription);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK8D4 )
            {
               BRK8D4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADLEAVEREQUESTREJECTIONREASONOPTIONS' Routine */
         returnInSub = false;
         AV25TFLeaveRequestRejectionReason = AV27SearchTxt;
         AV26TFLeaveRequestRejectionReason_Sel = "";
         AV52Leaverequestsds_1_filterfulltext = AV49FilterFullText;
         AV53Leaverequestsds_2_tfleavetypename = AV11TFLeaveTypeName;
         AV54Leaverequestsds_3_tfleavetypename_sel = AV12TFLeaveTypeName_Sel;
         AV55Leaverequestsds_4_tfleaverequeststartdate = AV15TFLeaveRequestStartDate;
         AV56Leaverequestsds_5_tfleaverequeststartdate_to = AV16TFLeaveRequestStartDate_To;
         AV57Leaverequestsds_6_tfleaverequestenddate = AV17TFLeaveRequestEndDate;
         AV58Leaverequestsds_7_tfleaverequestenddate_to = AV18TFLeaveRequestEndDate_To;
         AV59Leaverequestsds_8_tfleaverequestduration = AV19TFLeaveRequestDuration;
         AV60Leaverequestsds_9_tfleaverequestduration_to = AV20TFLeaveRequestDuration_To;
         AV61Leaverequestsds_10_tfleaverequeststatus_sels = AV22TFLeaveRequestStatus_Sels;
         AV62Leaverequestsds_11_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV63Leaverequestsds_12_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV64Leaverequestsds_13_tfleaverequestrejectionreason = AV25TFLeaveRequestRejectionReason;
         AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel = AV26TFLeaveRequestRejectionReason_Sel;
         AV66Udparg15 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV61Leaverequestsds_10_tfleaverequeststatus_sels ,
                                              AV52Leaverequestsds_1_filterfulltext ,
                                              AV54Leaverequestsds_3_tfleavetypename_sel ,
                                              AV53Leaverequestsds_2_tfleavetypename ,
                                              AV55Leaverequestsds_4_tfleaverequeststartdate ,
                                              AV56Leaverequestsds_5_tfleaverequeststartdate_to ,
                                              AV57Leaverequestsds_6_tfleaverequestenddate ,
                                              AV58Leaverequestsds_7_tfleaverequestenddate_to ,
                                              AV59Leaverequestsds_8_tfleaverequestduration ,
                                              AV60Leaverequestsds_9_tfleaverequestduration_to ,
                                              AV61Leaverequestsds_10_tfleaverequeststatus_sels.Count ,
                                              AV63Leaverequestsds_12_tfleaverequestdescription_sel ,
                                              AV62Leaverequestsds_11_tfleaverequestdescription ,
                                              AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel ,
                                              AV64Leaverequestsds_13_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A106EmployeeId ,
                                              AV66Udparg15 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV52Leaverequestsds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext), "%", "");
         lV53Leaverequestsds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leaverequestsds_2_tfleavetypename), 100, "%");
         lV62Leaverequestsds_11_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestsds_11_tfleaverequestdescription), "%", "");
         lV64Leaverequestsds_13_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV64Leaverequestsds_13_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008D4 */
         pr_default.execute(2, new Object[] {AV66Udparg15, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV52Leaverequestsds_1_filterfulltext, lV53Leaverequestsds_2_tfleavetypename, AV54Leaverequestsds_3_tfleavetypename_sel, AV55Leaverequestsds_4_tfleaverequeststartdate, AV56Leaverequestsds_5_tfleaverequeststartdate_to, AV57Leaverequestsds_6_tfleaverequestenddate, AV58Leaverequestsds_7_tfleaverequestenddate_to, AV59Leaverequestsds_8_tfleaverequestduration, AV60Leaverequestsds_9_tfleaverequestduration_to, lV62Leaverequestsds_11_tfleaverequestdescription, AV63Leaverequestsds_12_tfleaverequestdescription_sel, lV64Leaverequestsds_13_tfleaverequestrejectionreason, AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8D6 = false;
            A124LeaveTypeId = P008D4_A124LeaveTypeId[0];
            A106EmployeeId = P008D4_A106EmployeeId[0];
            A134LeaveRequestRejectionReason = P008D4_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P008D4_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008D4_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008D4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008D4_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P008D4_A125LeaveTypeName[0];
            A132LeaveRequestStatus = P008D4_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P008D4_A127LeaveRequestId[0];
            A125LeaveTypeName = P008D4_A125LeaveTypeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008D4_A134LeaveRequestRejectionReason[0], A134LeaveRequestRejectionReason) == 0 ) )
            {
               BRK8D6 = false;
               A127LeaveRequestId = P008D4_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK8D6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A134LeaveRequestRejectionReason)) ? "<#Empty#>" : A134LeaveRequestRejectionReason);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK8D6 )
            {
               BRK8D6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV46OptionsJson = "";
         AV47OptionsDescJson = "";
         AV48OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV35OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV27SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49FilterFullText = "";
         AV11TFLeaveTypeName = "";
         AV12TFLeaveTypeName_Sel = "";
         AV15TFLeaveRequestStartDate = DateTime.MinValue;
         AV16TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV17TFLeaveRequestEndDate = DateTime.MinValue;
         AV18TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV21TFLeaveRequestStatus_SelsJson = "";
         AV22TFLeaveRequestStatus_Sels = new GxSimpleCollection<string>();
         AV23TFLeaveRequestDescription = "";
         AV24TFLeaveRequestDescription_Sel = "";
         AV25TFLeaveRequestRejectionReason = "";
         AV26TFLeaveRequestRejectionReason_Sel = "";
         AV52Leaverequestsds_1_filterfulltext = "";
         AV53Leaverequestsds_2_tfleavetypename = "";
         AV54Leaverequestsds_3_tfleavetypename_sel = "";
         AV55Leaverequestsds_4_tfleaverequeststartdate = DateTime.MinValue;
         AV56Leaverequestsds_5_tfleaverequeststartdate_to = DateTime.MinValue;
         AV57Leaverequestsds_6_tfleaverequestenddate = DateTime.MinValue;
         AV58Leaverequestsds_7_tfleaverequestenddate_to = DateTime.MinValue;
         AV61Leaverequestsds_10_tfleaverequeststatus_sels = new GxSimpleCollection<string>();
         AV62Leaverequestsds_11_tfleaverequestdescription = "";
         AV63Leaverequestsds_12_tfleaverequestdescription_sel = "";
         AV64Leaverequestsds_13_tfleaverequestrejectionreason = "";
         AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel = "";
         scmdbuf = "";
         lV52Leaverequestsds_1_filterfulltext = "";
         lV53Leaverequestsds_2_tfleavetypename = "";
         lV62Leaverequestsds_11_tfleaverequestdescription = "";
         lV64Leaverequestsds_13_tfleaverequestrejectionreason = "";
         A132LeaveRequestStatus = "";
         A125LeaveTypeName = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P008D2_A124LeaveTypeId = new long[1] ;
         P008D2_A106EmployeeId = new long[1] ;
         P008D2_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008D2_A133LeaveRequestDescription = new string[] {""} ;
         P008D2_A131LeaveRequestDuration = new short[1] ;
         P008D2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008D2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008D2_A125LeaveTypeName = new string[] {""} ;
         P008D2_A132LeaveRequestStatus = new string[] {""} ;
         P008D2_A127LeaveRequestId = new long[1] ;
         AV32Option = "";
         P008D3_A124LeaveTypeId = new long[1] ;
         P008D3_A106EmployeeId = new long[1] ;
         P008D3_A133LeaveRequestDescription = new string[] {""} ;
         P008D3_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008D3_A131LeaveRequestDuration = new short[1] ;
         P008D3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008D3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008D3_A125LeaveTypeName = new string[] {""} ;
         P008D3_A132LeaveRequestStatus = new string[] {""} ;
         P008D3_A127LeaveRequestId = new long[1] ;
         P008D4_A124LeaveTypeId = new long[1] ;
         P008D4_A106EmployeeId = new long[1] ;
         P008D4_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008D4_A133LeaveRequestDescription = new string[] {""} ;
         P008D4_A131LeaveRequestDuration = new short[1] ;
         P008D4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008D4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008D4_A125LeaveTypeName = new string[] {""} ;
         P008D4_A132LeaveRequestStatus = new string[] {""} ;
         P008D4_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestsgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008D2_A124LeaveTypeId, P008D2_A106EmployeeId, P008D2_A134LeaveRequestRejectionReason, P008D2_A133LeaveRequestDescription, P008D2_A131LeaveRequestDuration, P008D2_A130LeaveRequestEndDate, P008D2_A129LeaveRequestStartDate, P008D2_A125LeaveTypeName, P008D2_A132LeaveRequestStatus, P008D2_A127LeaveRequestId
               }
               , new Object[] {
               P008D3_A124LeaveTypeId, P008D3_A106EmployeeId, P008D3_A133LeaveRequestDescription, P008D3_A134LeaveRequestRejectionReason, P008D3_A131LeaveRequestDuration, P008D3_A130LeaveRequestEndDate, P008D3_A129LeaveRequestStartDate, P008D3_A125LeaveTypeName, P008D3_A132LeaveRequestStatus, P008D3_A127LeaveRequestId
               }
               , new Object[] {
               P008D4_A124LeaveTypeId, P008D4_A106EmployeeId, P008D4_A134LeaveRequestRejectionReason, P008D4_A133LeaveRequestDescription, P008D4_A131LeaveRequestDuration, P008D4_A130LeaveRequestEndDate, P008D4_A129LeaveRequestStartDate, P008D4_A125LeaveTypeName, P008D4_A132LeaveRequestStatus, P008D4_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private short AV19TFLeaveRequestDuration ;
      private short AV20TFLeaveRequestDuration_To ;
      private short AV59Leaverequestsds_8_tfleaverequestduration ;
      private short AV60Leaverequestsds_9_tfleaverequestduration_to ;
      private short A131LeaveRequestDuration ;
      private int AV50GXV1 ;
      private int AV61Leaverequestsds_10_tfleaverequeststatus_sels_Count ;
      private int AV31InsertIndex ;
      private long AV66Udparg15 ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV37count ;
      private string AV11TFLeaveTypeName ;
      private string AV12TFLeaveTypeName_Sel ;
      private string AV53Leaverequestsds_2_tfleavetypename ;
      private string AV54Leaverequestsds_3_tfleavetypename_sel ;
      private string scmdbuf ;
      private string lV53Leaverequestsds_2_tfleavetypename ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private DateTime AV15TFLeaveRequestStartDate ;
      private DateTime AV16TFLeaveRequestStartDate_To ;
      private DateTime AV17TFLeaveRequestEndDate ;
      private DateTime AV18TFLeaveRequestEndDate_To ;
      private DateTime AV55Leaverequestsds_4_tfleaverequeststartdate ;
      private DateTime AV56Leaverequestsds_5_tfleaverequeststartdate_to ;
      private DateTime AV57Leaverequestsds_6_tfleaverequestenddate ;
      private DateTime AV58Leaverequestsds_7_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK8D2 ;
      private bool BRK8D4 ;
      private bool BRK8D6 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV21TFLeaveRequestStatus_SelsJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV49FilterFullText ;
      private string AV23TFLeaveRequestDescription ;
      private string AV24TFLeaveRequestDescription_Sel ;
      private string AV25TFLeaveRequestRejectionReason ;
      private string AV26TFLeaveRequestRejectionReason_Sel ;
      private string AV52Leaverequestsds_1_filterfulltext ;
      private string AV62Leaverequestsds_11_tfleaverequestdescription ;
      private string AV63Leaverequestsds_12_tfleaverequestdescription_sel ;
      private string AV64Leaverequestsds_13_tfleaverequestrejectionreason ;
      private string AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel ;
      private string lV52Leaverequestsds_1_filterfulltext ;
      private string lV62Leaverequestsds_11_tfleaverequestdescription ;
      private string lV64Leaverequestsds_13_tfleaverequestrejectionreason ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string AV32Option ;
      private IGxSession AV38Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008D2_A124LeaveTypeId ;
      private long[] P008D2_A106EmployeeId ;
      private string[] P008D2_A134LeaveRequestRejectionReason ;
      private string[] P008D2_A133LeaveRequestDescription ;
      private short[] P008D2_A131LeaveRequestDuration ;
      private DateTime[] P008D2_A130LeaveRequestEndDate ;
      private DateTime[] P008D2_A129LeaveRequestStartDate ;
      private string[] P008D2_A125LeaveTypeName ;
      private string[] P008D2_A132LeaveRequestStatus ;
      private long[] P008D2_A127LeaveRequestId ;
      private long[] P008D3_A124LeaveTypeId ;
      private long[] P008D3_A106EmployeeId ;
      private string[] P008D3_A133LeaveRequestDescription ;
      private string[] P008D3_A134LeaveRequestRejectionReason ;
      private short[] P008D3_A131LeaveRequestDuration ;
      private DateTime[] P008D3_A130LeaveRequestEndDate ;
      private DateTime[] P008D3_A129LeaveRequestStartDate ;
      private string[] P008D3_A125LeaveTypeName ;
      private string[] P008D3_A132LeaveRequestStatus ;
      private long[] P008D3_A127LeaveRequestId ;
      private long[] P008D4_A124LeaveTypeId ;
      private long[] P008D4_A106EmployeeId ;
      private string[] P008D4_A134LeaveRequestRejectionReason ;
      private string[] P008D4_A133LeaveRequestDescription ;
      private short[] P008D4_A131LeaveRequestDuration ;
      private DateTime[] P008D4_A130LeaveRequestEndDate ;
      private DateTime[] P008D4_A129LeaveRequestStartDate ;
      private string[] P008D4_A125LeaveTypeName ;
      private string[] P008D4_A132LeaveRequestStatus ;
      private long[] P008D4_A127LeaveRequestId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV22TFLeaveRequestStatus_Sels ;
      private GxSimpleCollection<string> AV61Leaverequestsds_10_tfleaverequeststatus_sels ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
   }

   public class leaverequestsgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008D2( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV61Leaverequestsds_10_tfleaverequeststatus_sels ,
                                             string AV52Leaverequestsds_1_filterfulltext ,
                                             string AV54Leaverequestsds_3_tfleavetypename_sel ,
                                             string AV53Leaverequestsds_2_tfleavetypename ,
                                             DateTime AV55Leaverequestsds_4_tfleaverequeststartdate ,
                                             DateTime AV56Leaverequestsds_5_tfleaverequeststartdate_to ,
                                             DateTime AV57Leaverequestsds_6_tfleaverequestenddate ,
                                             DateTime AV58Leaverequestsds_7_tfleaverequestenddate_to ,
                                             short AV59Leaverequestsds_8_tfleaverequestduration ,
                                             short AV60Leaverequestsds_9_tfleaverequestduration_to ,
                                             int AV61Leaverequestsds_10_tfleaverequeststatus_sels_Count ,
                                             string AV63Leaverequestsds_12_tfleaverequestdescription_sel ,
                                             string AV62Leaverequestsds_11_tfleaverequestdescription ,
                                             string AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel ,
                                             string AV64Leaverequestsds_13_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A106EmployeeId ,
                                             long AV66Udparg15 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV66Udparg15)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV52Leaverequestsds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestsds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestsds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV53Leaverequestsds_2_tfleavetypename))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestsds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leaverequestsds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV54Leaverequestsds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leaverequestsds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV55Leaverequestsds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV55Leaverequestsds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestsds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV56Leaverequestsds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestsds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV57Leaverequestsds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestsds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV58Leaverequestsds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV59Leaverequestsds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV59Leaverequestsds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV60Leaverequestsds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV60Leaverequestsds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV61Leaverequestsds_10_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV61Leaverequestsds_10_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestsds_12_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestsds_11_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV62Leaverequestsds_11_tfleaverequestdescription))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestsds_12_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestsds_12_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV63Leaverequestsds_12_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestsds_12_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestsds_13_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV64Leaverequestsds_13_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008D3( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV61Leaverequestsds_10_tfleaverequeststatus_sels ,
                                             string AV52Leaverequestsds_1_filterfulltext ,
                                             string AV54Leaverequestsds_3_tfleavetypename_sel ,
                                             string AV53Leaverequestsds_2_tfleavetypename ,
                                             DateTime AV55Leaverequestsds_4_tfleaverequeststartdate ,
                                             DateTime AV56Leaverequestsds_5_tfleaverequeststartdate_to ,
                                             DateTime AV57Leaverequestsds_6_tfleaverequestenddate ,
                                             DateTime AV58Leaverequestsds_7_tfleaverequestenddate_to ,
                                             short AV59Leaverequestsds_8_tfleaverequestduration ,
                                             short AV60Leaverequestsds_9_tfleaverequestduration_to ,
                                             int AV61Leaverequestsds_10_tfleaverequeststatus_sels_Count ,
                                             string AV63Leaverequestsds_12_tfleaverequestdescription_sel ,
                                             string AV62Leaverequestsds_11_tfleaverequestdescription ,
                                             string AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel ,
                                             string AV64Leaverequestsds_13_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A106EmployeeId ,
                                             long AV66Udparg15 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestDescription, T1.LeaveRequestRejectionReason, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV66Udparg15)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV52Leaverequestsds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestsds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestsds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV53Leaverequestsds_2_tfleavetypename))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestsds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leaverequestsds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV54Leaverequestsds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leaverequestsds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV55Leaverequestsds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV55Leaverequestsds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestsds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV56Leaverequestsds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestsds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV57Leaverequestsds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestsds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV58Leaverequestsds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV59Leaverequestsds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV59Leaverequestsds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV60Leaverequestsds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV60Leaverequestsds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV61Leaverequestsds_10_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV61Leaverequestsds_10_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestsds_12_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestsds_11_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV62Leaverequestsds_11_tfleaverequestdescription))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestsds_12_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestsds_12_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV63Leaverequestsds_12_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestsds_12_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestsds_13_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV64Leaverequestsds_13_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008D4( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV61Leaverequestsds_10_tfleaverequeststatus_sels ,
                                             string AV52Leaverequestsds_1_filterfulltext ,
                                             string AV54Leaverequestsds_3_tfleavetypename_sel ,
                                             string AV53Leaverequestsds_2_tfleavetypename ,
                                             DateTime AV55Leaverequestsds_4_tfleaverequeststartdate ,
                                             DateTime AV56Leaverequestsds_5_tfleaverequeststartdate_to ,
                                             DateTime AV57Leaverequestsds_6_tfleaverequestenddate ,
                                             DateTime AV58Leaverequestsds_7_tfleaverequestenddate_to ,
                                             short AV59Leaverequestsds_8_tfleaverequestduration ,
                                             short AV60Leaverequestsds_9_tfleaverequestduration_to ,
                                             int AV61Leaverequestsds_10_tfleaverequeststatus_sels_Count ,
                                             string AV63Leaverequestsds_12_tfleaverequestdescription_sel ,
                                             string AV62Leaverequestsds_11_tfleaverequestdescription ,
                                             string AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel ,
                                             string AV64Leaverequestsds_13_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A106EmployeeId ,
                                             long AV66Udparg15 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV66Udparg15)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leaverequestsds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV52Leaverequestsds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV52Leaverequestsds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestsds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestsds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV53Leaverequestsds_2_tfleavetypename))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestsds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leaverequestsds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV54Leaverequestsds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leaverequestsds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV55Leaverequestsds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV55Leaverequestsds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestsds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV56Leaverequestsds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestsds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV57Leaverequestsds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestsds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV58Leaverequestsds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (0==AV59Leaverequestsds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV59Leaverequestsds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (0==AV60Leaverequestsds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV60Leaverequestsds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV61Leaverequestsds_10_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV61Leaverequestsds_10_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestsds_12_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestsds_11_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV62Leaverequestsds_11_tfleaverequestdescription))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestsds_12_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestsds_12_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV63Leaverequestsds_12_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestsds_12_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestsds_13_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV64Leaverequestsds_13_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestRejectionReason";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008D2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
               case 1 :
                     return conditional_P008D3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
               case 2 :
                     return conditional_P008D4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008D2;
          prmP008D2 = new Object[] {
          new ParDef("AV66Udparg15",GXType.Int64,10,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestsds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leaverequestsds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestsds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV56Leaverequestsds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestsds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestsds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestsds_8_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV60Leaverequestsds_9_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV62Leaverequestsds_11_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Leaverequestsds_12_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Leaverequestsds_13_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
          };
          Object[] prmP008D3;
          prmP008D3 = new Object[] {
          new ParDef("AV66Udparg15",GXType.Int64,10,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestsds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leaverequestsds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestsds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV56Leaverequestsds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestsds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestsds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestsds_8_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV60Leaverequestsds_9_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV62Leaverequestsds_11_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Leaverequestsds_12_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Leaverequestsds_13_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
          };
          Object[] prmP008D4;
          prmP008D4 = new Object[] {
          new ParDef("AV66Udparg15",GXType.Int64,10,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestsds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestsds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leaverequestsds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestsds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV56Leaverequestsds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestsds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestsds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestsds_8_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV60Leaverequestsds_9_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV62Leaverequestsds_11_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Leaverequestsds_12_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Leaverequestsds_13_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV65Leaverequestsds_14_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008D3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008D4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
