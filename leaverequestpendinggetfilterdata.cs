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
   public class leaverequestpendinggetfilterdata : GXProcedure
   {
      public leaverequestpendinggetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestpendinggetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         leaverequestpendinggetfilterdata objleaverequestpendinggetfilterdata;
         objleaverequestpendinggetfilterdata = new leaverequestpendinggetfilterdata();
         objleaverequestpendinggetfilterdata.AV41DDOName = aP0_DDOName;
         objleaverequestpendinggetfilterdata.AV42SearchTxtParms = aP1_SearchTxtParms;
         objleaverequestpendinggetfilterdata.AV43SearchTxtTo = aP2_SearchTxtTo;
         objleaverequestpendinggetfilterdata.AV44OptionsJson = "" ;
         objleaverequestpendinggetfilterdata.AV45OptionsDescJson = "" ;
         objleaverequestpendinggetfilterdata.AV46OptionIndexesJson = "" ;
         objleaverequestpendinggetfilterdata.context.SetSubmitInitialConfig(context);
         objleaverequestpendinggetfilterdata.initialize();
         Submit( executePrivateCatch,objleaverequestpendinggetfilterdata);
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leaverequestpendinggetfilterdata)stateInfo).executePrivate();
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
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_LEAVEREQUESTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("LeaveRequestPendingGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LeaveRequestPendingGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("LeaveRequestPendingGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV13TFLeaveTypeName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV14TFLeaveTypeName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV17TFLeaveRequestStartDate = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 1);
               AV18TFLeaveRequestStartDate_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV19TFLeaveRequestEndDate = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 1);
               AV20TFLeaveRequestEndDate_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV21TFLeaveRequestDuration = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV22TFLeaveRequestDuration_To = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV23TFLeaveRequestDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV24TFLeaveRequestDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV11TFEmployeeName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV12TFEmployeeName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFLeaveTypeName = AV25SearchTxt;
         AV14TFLeaveTypeName_Sel = "";
         AV52Leaverequestpendingds_1_filterfulltext = AV47FilterFullText;
         AV53Leaverequestpendingds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV54Leaverequestpendingds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV55Leaverequestpendingds_4_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV56Leaverequestpendingds_5_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV57Leaverequestpendingds_6_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV58Leaverequestpendingds_7_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV59Leaverequestpendingds_8_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV60Leaverequestpendingds_9_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV61Leaverequestpendingds_10_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV62Leaverequestpendingds_11_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV63Leaverequestpendingds_12_tfemployeename = AV11TFEmployeeName;
         AV64Leaverequestpendingds_13_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV65Udparg14 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV52Leaverequestpendingds_1_filterfulltext ,
                                              AV54Leaverequestpendingds_3_tfleavetypename_sel ,
                                              AV53Leaverequestpendingds_2_tfleavetypename ,
                                              AV55Leaverequestpendingds_4_tfleaverequeststartdate ,
                                              AV56Leaverequestpendingds_5_tfleaverequeststartdate_to ,
                                              AV57Leaverequestpendingds_6_tfleaverequestenddate ,
                                              AV58Leaverequestpendingds_7_tfleaverequestenddate_to ,
                                              AV59Leaverequestpendingds_8_tfleaverequestduration ,
                                              AV60Leaverequestpendingds_9_tfleaverequestduration_to ,
                                              AV62Leaverequestpendingds_11_tfleaverequestdescription_sel ,
                                              AV61Leaverequestpendingds_10_tfleaverequestdescription ,
                                              AV64Leaverequestpendingds_13_tfemployeename_sel ,
                                              AV63Leaverequestpendingds_12_tfemployeename ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A148EmployeeName ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV65Udparg14 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV53Leaverequestpendingds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leaverequestpendingds_2_tfleavetypename), 100, "%");
         lV61Leaverequestpendingds_10_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV61Leaverequestpendingds_10_tfleaverequestdescription), "%", "");
         lV63Leaverequestpendingds_12_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV63Leaverequestpendingds_12_tfemployeename), 128, "%");
         /* Using cursor P006V2 */
         pr_default.execute(0, new Object[] {lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV53Leaverequestpendingds_2_tfleavetypename, AV54Leaverequestpendingds_3_tfleavetypename_sel, AV55Leaverequestpendingds_4_tfleaverequeststartdate, AV56Leaverequestpendingds_5_tfleaverequeststartdate_to, AV57Leaverequestpendingds_6_tfleaverequestenddate, AV58Leaverequestpendingds_7_tfleaverequestenddate_to, AV59Leaverequestpendingds_8_tfleaverequestduration, AV60Leaverequestpendingds_9_tfleaverequestduration_to, lV61Leaverequestpendingds_10_tfleaverequestdescription, AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, lV63Leaverequestpendingds_12_tfemployeename, AV64Leaverequestpendingds_13_tfemployeename_sel, AV65Udparg14});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6V2 = false;
            A124LeaveTypeId = P006V2_A124LeaveTypeId[0];
            A106EmployeeId = P006V2_A106EmployeeId[0];
            A100CompanyId = P006V2_A100CompanyId[0];
            A132LeaveRequestStatus = P006V2_A132LeaveRequestStatus[0];
            A148EmployeeName = P006V2_A148EmployeeName[0];
            A133LeaveRequestDescription = P006V2_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P006V2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006V2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006V2_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006V2_A125LeaveTypeName[0];
            A127LeaveRequestId = P006V2_A127LeaveRequestId[0];
            A100CompanyId = P006V2_A100CompanyId[0];
            A125LeaveTypeName = P006V2_A125LeaveTypeName[0];
            A148EmployeeName = P006V2_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P006V2_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRK6V2 = false;
               A127LeaveRequestId = P006V2_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6V2 = true;
               pr_default.readNext(0);
            }
            AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
            AV29InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV29InsertIndex = (int)(AV29InsertIndex+1);
            }
            AV31Options.Add(AV30Option, AV29InsertIndex);
            AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
            if ( AV31Options.Count == AV26SkipItems + 11 )
            {
               AV31Options.RemoveItem(AV31Options.Count);
               AV34OptionIndexes.RemoveItem(AV34OptionIndexes.Count);
            }
            if ( ! BRK6V2 )
            {
               BRK6V2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV26SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV34OptionIndexes.RemoveItem(1);
            AV26SkipItems = (short)(AV26SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV23TFLeaveRequestDescription = AV25SearchTxt;
         AV24TFLeaveRequestDescription_Sel = "";
         AV52Leaverequestpendingds_1_filterfulltext = AV47FilterFullText;
         AV53Leaverequestpendingds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV54Leaverequestpendingds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV55Leaverequestpendingds_4_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV56Leaverequestpendingds_5_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV57Leaverequestpendingds_6_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV58Leaverequestpendingds_7_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV59Leaverequestpendingds_8_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV60Leaverequestpendingds_9_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV61Leaverequestpendingds_10_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV62Leaverequestpendingds_11_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV63Leaverequestpendingds_12_tfemployeename = AV11TFEmployeeName;
         AV64Leaverequestpendingds_13_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV65Udparg14 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV52Leaverequestpendingds_1_filterfulltext ,
                                              AV54Leaverequestpendingds_3_tfleavetypename_sel ,
                                              AV53Leaverequestpendingds_2_tfleavetypename ,
                                              AV55Leaverequestpendingds_4_tfleaverequeststartdate ,
                                              AV56Leaverequestpendingds_5_tfleaverequeststartdate_to ,
                                              AV57Leaverequestpendingds_6_tfleaverequestenddate ,
                                              AV58Leaverequestpendingds_7_tfleaverequestenddate_to ,
                                              AV59Leaverequestpendingds_8_tfleaverequestduration ,
                                              AV60Leaverequestpendingds_9_tfleaverequestduration_to ,
                                              AV62Leaverequestpendingds_11_tfleaverequestdescription_sel ,
                                              AV61Leaverequestpendingds_10_tfleaverequestdescription ,
                                              AV64Leaverequestpendingds_13_tfemployeename_sel ,
                                              AV63Leaverequestpendingds_12_tfemployeename ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A148EmployeeName ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV65Udparg14 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV53Leaverequestpendingds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leaverequestpendingds_2_tfleavetypename), 100, "%");
         lV61Leaverequestpendingds_10_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV61Leaverequestpendingds_10_tfleaverequestdescription), "%", "");
         lV63Leaverequestpendingds_12_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV63Leaverequestpendingds_12_tfemployeename), 128, "%");
         /* Using cursor P006V3 */
         pr_default.execute(1, new Object[] {lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV53Leaverequestpendingds_2_tfleavetypename, AV54Leaverequestpendingds_3_tfleavetypename_sel, AV55Leaverequestpendingds_4_tfleaverequeststartdate, AV56Leaverequestpendingds_5_tfleaverequeststartdate_to, AV57Leaverequestpendingds_6_tfleaverequestenddate, AV58Leaverequestpendingds_7_tfleaverequestenddate_to, AV59Leaverequestpendingds_8_tfleaverequestduration, AV60Leaverequestpendingds_9_tfleaverequestduration_to, lV61Leaverequestpendingds_10_tfleaverequestdescription, AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, lV63Leaverequestpendingds_12_tfemployeename, AV64Leaverequestpendingds_13_tfemployeename_sel, AV65Udparg14});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6V4 = false;
            A124LeaveTypeId = P006V3_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P006V3_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = P006V3_A133LeaveRequestDescription[0];
            A106EmployeeId = P006V3_A106EmployeeId[0];
            A100CompanyId = P006V3_A100CompanyId[0];
            A148EmployeeName = P006V3_A148EmployeeName[0];
            A131LeaveRequestDuration = P006V3_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006V3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006V3_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006V3_A125LeaveTypeName[0];
            A127LeaveRequestId = P006V3_A127LeaveRequestId[0];
            A100CompanyId = P006V3_A100CompanyId[0];
            A125LeaveTypeName = P006V3_A125LeaveTypeName[0];
            A148EmployeeName = P006V3_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006V3_A133LeaveRequestDescription[0], A133LeaveRequestDescription) == 0 ) )
            {
               BRK6V4 = false;
               A127LeaveRequestId = P006V3_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6V4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A133LeaveRequestDescription)) ? "<#Empty#>" : A133LeaveRequestDescription);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK6V4 )
            {
               BRK6V4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFEmployeeName = AV25SearchTxt;
         AV12TFEmployeeName_Sel = "";
         AV52Leaverequestpendingds_1_filterfulltext = AV47FilterFullText;
         AV53Leaverequestpendingds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV54Leaverequestpendingds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV55Leaverequestpendingds_4_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV56Leaverequestpendingds_5_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV57Leaverequestpendingds_6_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV58Leaverequestpendingds_7_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV59Leaverequestpendingds_8_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV60Leaverequestpendingds_9_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV61Leaverequestpendingds_10_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV62Leaverequestpendingds_11_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV63Leaverequestpendingds_12_tfemployeename = AV11TFEmployeeName;
         AV64Leaverequestpendingds_13_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV65Udparg14 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV52Leaverequestpendingds_1_filterfulltext ,
                                              AV54Leaverequestpendingds_3_tfleavetypename_sel ,
                                              AV53Leaverequestpendingds_2_tfleavetypename ,
                                              AV55Leaverequestpendingds_4_tfleaverequeststartdate ,
                                              AV56Leaverequestpendingds_5_tfleaverequeststartdate_to ,
                                              AV57Leaverequestpendingds_6_tfleaverequestenddate ,
                                              AV58Leaverequestpendingds_7_tfleaverequestenddate_to ,
                                              AV59Leaverequestpendingds_8_tfleaverequestduration ,
                                              AV60Leaverequestpendingds_9_tfleaverequestduration_to ,
                                              AV62Leaverequestpendingds_11_tfleaverequestdescription_sel ,
                                              AV61Leaverequestpendingds_10_tfleaverequestdescription ,
                                              AV64Leaverequestpendingds_13_tfemployeename_sel ,
                                              AV63Leaverequestpendingds_12_tfemployeename ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A148EmployeeName ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV65Udparg14 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV52Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext), "%", "");
         lV53Leaverequestpendingds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leaverequestpendingds_2_tfleavetypename), 100, "%");
         lV61Leaverequestpendingds_10_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV61Leaverequestpendingds_10_tfleaverequestdescription), "%", "");
         lV63Leaverequestpendingds_12_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV63Leaverequestpendingds_12_tfemployeename), 128, "%");
         /* Using cursor P006V4 */
         pr_default.execute(2, new Object[] {lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV52Leaverequestpendingds_1_filterfulltext, lV53Leaverequestpendingds_2_tfleavetypename, AV54Leaverequestpendingds_3_tfleavetypename_sel, AV55Leaverequestpendingds_4_tfleaverequeststartdate, AV56Leaverequestpendingds_5_tfleaverequeststartdate_to, AV57Leaverequestpendingds_6_tfleaverequestenddate, AV58Leaverequestpendingds_7_tfleaverequestenddate_to, AV59Leaverequestpendingds_8_tfleaverequestduration, AV60Leaverequestpendingds_9_tfleaverequestduration_to, lV61Leaverequestpendingds_10_tfleaverequestdescription, AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, lV63Leaverequestpendingds_12_tfemployeename, AV64Leaverequestpendingds_13_tfemployeename_sel, AV65Udparg14});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6V6 = false;
            A124LeaveTypeId = P006V4_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P006V4_A132LeaveRequestStatus[0];
            A148EmployeeName = P006V4_A148EmployeeName[0];
            A106EmployeeId = P006V4_A106EmployeeId[0];
            A100CompanyId = P006V4_A100CompanyId[0];
            A133LeaveRequestDescription = P006V4_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P006V4_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006V4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006V4_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006V4_A125LeaveTypeName[0];
            A127LeaveRequestId = P006V4_A127LeaveRequestId[0];
            A100CompanyId = P006V4_A100CompanyId[0];
            A125LeaveTypeName = P006V4_A125LeaveTypeName[0];
            A148EmployeeName = P006V4_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006V4_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK6V6 = false;
               A106EmployeeId = P006V4_A106EmployeeId[0];
               A127LeaveRequestId = P006V4_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6V6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK6V6 )
            {
               BRK6V6 = true;
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV13TFLeaveTypeName = "";
         AV14TFLeaveTypeName_Sel = "";
         AV17TFLeaveRequestStartDate = DateTime.MinValue;
         AV18TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV19TFLeaveRequestEndDate = DateTime.MinValue;
         AV20TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV23TFLeaveRequestDescription = "";
         AV24TFLeaveRequestDescription_Sel = "";
         AV11TFEmployeeName = "";
         AV12TFEmployeeName_Sel = "";
         AV52Leaverequestpendingds_1_filterfulltext = "";
         AV53Leaverequestpendingds_2_tfleavetypename = "";
         AV54Leaverequestpendingds_3_tfleavetypename_sel = "";
         AV55Leaverequestpendingds_4_tfleaverequeststartdate = DateTime.MinValue;
         AV56Leaverequestpendingds_5_tfleaverequeststartdate_to = DateTime.MinValue;
         AV57Leaverequestpendingds_6_tfleaverequestenddate = DateTime.MinValue;
         AV58Leaverequestpendingds_7_tfleaverequestenddate_to = DateTime.MinValue;
         AV61Leaverequestpendingds_10_tfleaverequestdescription = "";
         AV62Leaverequestpendingds_11_tfleaverequestdescription_sel = "";
         AV63Leaverequestpendingds_12_tfemployeename = "";
         AV64Leaverequestpendingds_13_tfemployeename_sel = "";
         scmdbuf = "";
         lV52Leaverequestpendingds_1_filterfulltext = "";
         lV53Leaverequestpendingds_2_tfleavetypename = "";
         lV61Leaverequestpendingds_10_tfleaverequestdescription = "";
         lV63Leaverequestpendingds_12_tfemployeename = "";
         AV48EmployeeIds = new GxSimpleCollection<long>();
         A125LeaveTypeName = "";
         A133LeaveRequestDescription = "";
         A148EmployeeName = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P006V2_A124LeaveTypeId = new long[1] ;
         P006V2_A106EmployeeId = new long[1] ;
         P006V2_A100CompanyId = new long[1] ;
         P006V2_A132LeaveRequestStatus = new string[] {""} ;
         P006V2_A148EmployeeName = new string[] {""} ;
         P006V2_A133LeaveRequestDescription = new string[] {""} ;
         P006V2_A131LeaveRequestDuration = new short[1] ;
         P006V2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006V2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006V2_A125LeaveTypeName = new string[] {""} ;
         P006V2_A127LeaveRequestId = new long[1] ;
         AV30Option = "";
         P006V3_A124LeaveTypeId = new long[1] ;
         P006V3_A132LeaveRequestStatus = new string[] {""} ;
         P006V3_A133LeaveRequestDescription = new string[] {""} ;
         P006V3_A106EmployeeId = new long[1] ;
         P006V3_A100CompanyId = new long[1] ;
         P006V3_A148EmployeeName = new string[] {""} ;
         P006V3_A131LeaveRequestDuration = new short[1] ;
         P006V3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006V3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006V3_A125LeaveTypeName = new string[] {""} ;
         P006V3_A127LeaveRequestId = new long[1] ;
         P006V4_A124LeaveTypeId = new long[1] ;
         P006V4_A132LeaveRequestStatus = new string[] {""} ;
         P006V4_A148EmployeeName = new string[] {""} ;
         P006V4_A106EmployeeId = new long[1] ;
         P006V4_A100CompanyId = new long[1] ;
         P006V4_A133LeaveRequestDescription = new string[] {""} ;
         P006V4_A131LeaveRequestDuration = new short[1] ;
         P006V4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006V4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006V4_A125LeaveTypeName = new string[] {""} ;
         P006V4_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestpendinggetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006V2_A124LeaveTypeId, P006V2_A106EmployeeId, P006V2_A100CompanyId, P006V2_A132LeaveRequestStatus, P006V2_A148EmployeeName, P006V2_A133LeaveRequestDescription, P006V2_A131LeaveRequestDuration, P006V2_A130LeaveRequestEndDate, P006V2_A129LeaveRequestStartDate, P006V2_A125LeaveTypeName,
               P006V2_A127LeaveRequestId
               }
               , new Object[] {
               P006V3_A124LeaveTypeId, P006V3_A132LeaveRequestStatus, P006V3_A133LeaveRequestDescription, P006V3_A106EmployeeId, P006V3_A100CompanyId, P006V3_A148EmployeeName, P006V3_A131LeaveRequestDuration, P006V3_A130LeaveRequestEndDate, P006V3_A129LeaveRequestStartDate, P006V3_A125LeaveTypeName,
               P006V3_A127LeaveRequestId
               }
               , new Object[] {
               P006V4_A124LeaveTypeId, P006V4_A132LeaveRequestStatus, P006V4_A148EmployeeName, P006V4_A106EmployeeId, P006V4_A100CompanyId, P006V4_A133LeaveRequestDescription, P006V4_A131LeaveRequestDuration, P006V4_A130LeaveRequestEndDate, P006V4_A129LeaveRequestStartDate, P006V4_A125LeaveTypeName,
               P006V4_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV21TFLeaveRequestDuration ;
      private short AV22TFLeaveRequestDuration_To ;
      private short AV59Leaverequestpendingds_8_tfleaverequestduration ;
      private short AV60Leaverequestpendingds_9_tfleaverequestduration_to ;
      private short A131LeaveRequestDuration ;
      private int AV50GXV1 ;
      private int AV29InsertIndex ;
      private long AV65Udparg14 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV35count ;
      private string AV13TFLeaveTypeName ;
      private string AV14TFLeaveTypeName_Sel ;
      private string AV11TFEmployeeName ;
      private string AV12TFEmployeeName_Sel ;
      private string AV53Leaverequestpendingds_2_tfleavetypename ;
      private string AV54Leaverequestpendingds_3_tfleavetypename_sel ;
      private string AV63Leaverequestpendingds_12_tfemployeename ;
      private string AV64Leaverequestpendingds_13_tfemployeename_sel ;
      private string scmdbuf ;
      private string lV53Leaverequestpendingds_2_tfleavetypename ;
      private string lV63Leaverequestpendingds_12_tfemployeename ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string A132LeaveRequestStatus ;
      private DateTime AV17TFLeaveRequestStartDate ;
      private DateTime AV18TFLeaveRequestStartDate_To ;
      private DateTime AV19TFLeaveRequestEndDate ;
      private DateTime AV20TFLeaveRequestEndDate_To ;
      private DateTime AV55Leaverequestpendingds_4_tfleaverequeststartdate ;
      private DateTime AV56Leaverequestpendingds_5_tfleaverequeststartdate_to ;
      private DateTime AV57Leaverequestpendingds_6_tfleaverequestenddate ;
      private DateTime AV58Leaverequestpendingds_7_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK6V2 ;
      private bool BRK6V4 ;
      private bool BRK6V6 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV23TFLeaveRequestDescription ;
      private string AV24TFLeaveRequestDescription_Sel ;
      private string AV52Leaverequestpendingds_1_filterfulltext ;
      private string AV61Leaverequestpendingds_10_tfleaverequestdescription ;
      private string AV62Leaverequestpendingds_11_tfleaverequestdescription_sel ;
      private string lV52Leaverequestpendingds_1_filterfulltext ;
      private string lV61Leaverequestpendingds_10_tfleaverequestdescription ;
      private string A133LeaveRequestDescription ;
      private string AV30Option ;
      private GxSimpleCollection<long> AV48EmployeeIds ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P006V2_A124LeaveTypeId ;
      private long[] P006V2_A106EmployeeId ;
      private long[] P006V2_A100CompanyId ;
      private string[] P006V2_A132LeaveRequestStatus ;
      private string[] P006V2_A148EmployeeName ;
      private string[] P006V2_A133LeaveRequestDescription ;
      private short[] P006V2_A131LeaveRequestDuration ;
      private DateTime[] P006V2_A130LeaveRequestEndDate ;
      private DateTime[] P006V2_A129LeaveRequestStartDate ;
      private string[] P006V2_A125LeaveTypeName ;
      private long[] P006V2_A127LeaveRequestId ;
      private long[] P006V3_A124LeaveTypeId ;
      private string[] P006V3_A132LeaveRequestStatus ;
      private string[] P006V3_A133LeaveRequestDescription ;
      private long[] P006V3_A106EmployeeId ;
      private long[] P006V3_A100CompanyId ;
      private string[] P006V3_A148EmployeeName ;
      private short[] P006V3_A131LeaveRequestDuration ;
      private DateTime[] P006V3_A130LeaveRequestEndDate ;
      private DateTime[] P006V3_A129LeaveRequestStartDate ;
      private string[] P006V3_A125LeaveTypeName ;
      private long[] P006V3_A127LeaveRequestId ;
      private long[] P006V4_A124LeaveTypeId ;
      private string[] P006V4_A132LeaveRequestStatus ;
      private string[] P006V4_A148EmployeeName ;
      private long[] P006V4_A106EmployeeId ;
      private long[] P006V4_A100CompanyId ;
      private string[] P006V4_A133LeaveRequestDescription ;
      private short[] P006V4_A131LeaveRequestDuration ;
      private DateTime[] P006V4_A130LeaveRequestEndDate ;
      private DateTime[] P006V4_A129LeaveRequestStartDate ;
      private string[] P006V4_A125LeaveTypeName ;
      private long[] P006V4_A127LeaveRequestId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
   }

   public class leaverequestpendinggetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006V2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV48EmployeeIds ,
                                             string AV52Leaverequestpendingds_1_filterfulltext ,
                                             string AV54Leaverequestpendingds_3_tfleavetypename_sel ,
                                             string AV53Leaverequestpendingds_2_tfleavetypename ,
                                             DateTime AV55Leaverequestpendingds_4_tfleaverequeststartdate ,
                                             DateTime AV56Leaverequestpendingds_5_tfleaverequeststartdate_to ,
                                             DateTime AV57Leaverequestpendingds_6_tfleaverequestenddate ,
                                             DateTime AV58Leaverequestpendingds_7_tfleaverequestenddate_to ,
                                             short AV59Leaverequestpendingds_8_tfleaverequestduration ,
                                             short AV60Leaverequestpendingds_9_tfleaverequestduration_to ,
                                             string AV62Leaverequestpendingds_11_tfleaverequestdescription_sel ,
                                             string AV61Leaverequestpendingds_10_tfleaverequestdescription ,
                                             string AV64Leaverequestpendingds_13_tfemployeename_sel ,
                                             string AV63Leaverequestpendingds_12_tfemployeename ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A148EmployeeName ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV65Udparg14 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestStatus, T3.EmployeeName, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV52Leaverequestpendingds_1_filterfulltext) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T3.EmployeeName) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestpendingds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestpendingds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV53Leaverequestpendingds_2_tfleavetypename))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestpendingds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leaverequestpendingds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV54Leaverequestpendingds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leaverequestpendingds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV55Leaverequestpendingds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV55Leaverequestpendingds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestpendingds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV56Leaverequestpendingds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestpendingds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV57Leaverequestpendingds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestpendingds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV58Leaverequestpendingds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV59Leaverequestpendingds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV59Leaverequestpendingds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV60Leaverequestpendingds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV60Leaverequestpendingds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestpendingds_11_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestpendingds_10_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV61Leaverequestpendingds_10_tfleaverequestdescription))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestpendingds_11_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV62Leaverequestpendingds_11_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_13_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestpendingds_12_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV63Leaverequestpendingds_12_tfemployeename))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_13_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV64Leaverequestpendingds_13_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV64Leaverequestpendingds_13_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Leaverequestpendingds_13_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV65Udparg14)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV48EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006V3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV48EmployeeIds ,
                                             string AV52Leaverequestpendingds_1_filterfulltext ,
                                             string AV54Leaverequestpendingds_3_tfleavetypename_sel ,
                                             string AV53Leaverequestpendingds_2_tfleavetypename ,
                                             DateTime AV55Leaverequestpendingds_4_tfleaverequeststartdate ,
                                             DateTime AV56Leaverequestpendingds_5_tfleaverequeststartdate_to ,
                                             DateTime AV57Leaverequestpendingds_6_tfleaverequestenddate ,
                                             DateTime AV58Leaverequestpendingds_7_tfleaverequestenddate_to ,
                                             short AV59Leaverequestpendingds_8_tfleaverequestduration ,
                                             short AV60Leaverequestpendingds_9_tfleaverequestduration_to ,
                                             string AV62Leaverequestpendingds_11_tfleaverequestdescription_sel ,
                                             string AV61Leaverequestpendingds_10_tfleaverequestdescription ,
                                             string AV64Leaverequestpendingds_13_tfemployeename_sel ,
                                             string AV63Leaverequestpendingds_12_tfemployeename ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A148EmployeeName ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV65Udparg14 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.LeaveRequestDescription, T1.EmployeeId, T2.CompanyId, T3.EmployeeName, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV52Leaverequestpendingds_1_filterfulltext) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T3.EmployeeName) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestpendingds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestpendingds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV53Leaverequestpendingds_2_tfleavetypename))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestpendingds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leaverequestpendingds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV54Leaverequestpendingds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leaverequestpendingds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV55Leaverequestpendingds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV55Leaverequestpendingds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestpendingds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV56Leaverequestpendingds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestpendingds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV57Leaverequestpendingds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestpendingds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV58Leaverequestpendingds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV59Leaverequestpendingds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV59Leaverequestpendingds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV60Leaverequestpendingds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV60Leaverequestpendingds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestpendingds_11_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestpendingds_10_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV61Leaverequestpendingds_10_tfleaverequestdescription))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestpendingds_11_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV62Leaverequestpendingds_11_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_13_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestpendingds_12_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV63Leaverequestpendingds_12_tfemployeename))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_13_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV64Leaverequestpendingds_13_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV64Leaverequestpendingds_13_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Leaverequestpendingds_13_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV65Udparg14)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV48EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006V4( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV48EmployeeIds ,
                                             string AV52Leaverequestpendingds_1_filterfulltext ,
                                             string AV54Leaverequestpendingds_3_tfleavetypename_sel ,
                                             string AV53Leaverequestpendingds_2_tfleavetypename ,
                                             DateTime AV55Leaverequestpendingds_4_tfleaverequeststartdate ,
                                             DateTime AV56Leaverequestpendingds_5_tfleaverequeststartdate_to ,
                                             DateTime AV57Leaverequestpendingds_6_tfleaverequestenddate ,
                                             DateTime AV58Leaverequestpendingds_7_tfleaverequestenddate_to ,
                                             short AV59Leaverequestpendingds_8_tfleaverequestduration ,
                                             short AV60Leaverequestpendingds_9_tfleaverequestduration_to ,
                                             string AV62Leaverequestpendingds_11_tfleaverequestdescription_sel ,
                                             string AV61Leaverequestpendingds_10_tfleaverequestdescription ,
                                             string AV64Leaverequestpendingds_13_tfemployeename_sel ,
                                             string AV63Leaverequestpendingds_12_tfemployeename ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A148EmployeeName ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV65Udparg14 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T3.EmployeeName, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leaverequestpendingds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV52Leaverequestpendingds_1_filterfulltext) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T3.EmployeeName) like '%' || LOWER(:lV52Leaverequestpendingds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestpendingds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestpendingds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV53Leaverequestpendingds_2_tfleavetypename))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestpendingds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leaverequestpendingds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV54Leaverequestpendingds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leaverequestpendingds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV55Leaverequestpendingds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV55Leaverequestpendingds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestpendingds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV56Leaverequestpendingds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestpendingds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV57Leaverequestpendingds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestpendingds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV58Leaverequestpendingds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV59Leaverequestpendingds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV59Leaverequestpendingds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (0==AV60Leaverequestpendingds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV60Leaverequestpendingds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestpendingds_11_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestpendingds_10_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV61Leaverequestpendingds_10_tfleaverequestdescription))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestpendingds_11_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV62Leaverequestpendingds_11_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Leaverequestpendingds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_13_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestpendingds_12_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV63Leaverequestpendingds_12_tfemployeename))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_13_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV64Leaverequestpendingds_13_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV64Leaverequestpendingds_13_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Leaverequestpendingds_13_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV65Udparg14)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV48EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.EmployeeName";
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
                     return conditional_P006V2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] );
               case 1 :
                     return conditional_P006V3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] );
               case 2 :
                     return conditional_P006V4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] );
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
          Object[] prmP006V2;
          prmP006V2 = new Object[] {
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestpendingds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leaverequestpendingds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestpendingds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV56Leaverequestpendingds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestpendingds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestpendingds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestpendingds_8_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV60Leaverequestpendingds_9_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV61Leaverequestpendingds_10_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV62Leaverequestpendingds_11_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV63Leaverequestpendingds_12_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV64Leaverequestpendingds_13_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("AV65Udparg14",GXType.Int64,10,0)
          };
          Object[] prmP006V3;
          prmP006V3 = new Object[] {
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestpendingds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leaverequestpendingds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestpendingds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV56Leaverequestpendingds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestpendingds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestpendingds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestpendingds_8_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV60Leaverequestpendingds_9_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV61Leaverequestpendingds_10_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV62Leaverequestpendingds_11_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV63Leaverequestpendingds_12_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV64Leaverequestpendingds_13_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("AV65Udparg14",GXType.Int64,10,0)
          };
          Object[] prmP006V4;
          prmP006V4 = new Object[] {
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestpendingds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leaverequestpendingds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestpendingds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV56Leaverequestpendingds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestpendingds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestpendingds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestpendingds_8_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV60Leaverequestpendingds_9_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV61Leaverequestpendingds_10_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV62Leaverequestpendingds_11_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV63Leaverequestpendingds_12_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV64Leaverequestpendingds_13_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("AV65Udparg14",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006V4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 128);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 128);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 128);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
