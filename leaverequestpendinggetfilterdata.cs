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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_LEAVEREQUESTHALFDAY") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTHALFDAYOPTIONS' */
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
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV11TFEmployeeName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV12TFEmployeeName_Sel = AV39GridStateFilterValue.gxTpr_Value;
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
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV52TFLeaveRequestHalfDayOperator = AV39GridStateFilterValue.gxTpr_Operator;
               if ( AV52TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV50TFLeaveRequestHalfDay = AV39GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV51TFLeaveRequestHalfDay_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV21TFLeaveRequestDuration = NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, ".");
               AV22TFLeaveRequestDuration_To = NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFEmployeeName = AV25SearchTxt;
         AV12TFEmployeeName_Sel = "";
         AV55Leaverequestpendingds_1_filterfulltext = AV47FilterFullText;
         AV56Leaverequestpendingds_2_tfemployeename = AV11TFEmployeeName;
         AV57Leaverequestpendingds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV58Leaverequestpendingds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV59Leaverequestpendingds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV60Leaverequestpendingds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV61Leaverequestpendingds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV62Leaverequestpendingds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV63Leaverequestpendingds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV64Leaverequestpendingds_10_tfleaverequesthalfday = AV50TFLeaveRequestHalfDay;
         AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator = AV52TFLeaveRequestHalfDayOperator;
         AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel = AV51TFLeaveRequestHalfDay_Sel;
         AV67Leaverequestpendingds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV68Leaverequestpendingds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV69Udparg15 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV55Leaverequestpendingds_1_filterfulltext ,
                                              AV57Leaverequestpendingds_3_tfemployeename_sel ,
                                              AV56Leaverequestpendingds_2_tfemployeename ,
                                              AV59Leaverequestpendingds_5_tfleavetypename_sel ,
                                              AV58Leaverequestpendingds_4_tfleavetypename ,
                                              AV60Leaverequestpendingds_6_tfleaverequeststartdate ,
                                              AV61Leaverequestpendingds_7_tfleaverequeststartdate_to ,
                                              AV62Leaverequestpendingds_8_tfleaverequestenddate ,
                                              AV63Leaverequestpendingds_9_tfleaverequestenddate_to ,
                                              AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel ,
                                              AV64Leaverequestpendingds_10_tfleaverequesthalfday ,
                                              AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator ,
                                              AV67Leaverequestpendingds_13_tfleaverequestduration ,
                                              AV68Leaverequestpendingds_14_tfleaverequestduration_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV69Udparg15 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV56Leaverequestpendingds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV56Leaverequestpendingds_2_tfemployeename), 128, "%");
         lV58Leaverequestpendingds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV58Leaverequestpendingds_4_tfleavetypename), 100, "%");
         lV64Leaverequestpendingds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV64Leaverequestpendingds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P006V2 */
         pr_default.execute(0, new Object[] {lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV56Leaverequestpendingds_2_tfemployeename, AV57Leaverequestpendingds_3_tfemployeename_sel, lV58Leaverequestpendingds_4_tfleavetypename, AV59Leaverequestpendingds_5_tfleavetypename_sel, AV60Leaverequestpendingds_6_tfleaverequeststartdate, AV61Leaverequestpendingds_7_tfleaverequeststartdate_to, AV62Leaverequestpendingds_8_tfleaverequestenddate, AV63Leaverequestpendingds_9_tfleaverequestenddate_to, lV64Leaverequestpendingds_10_tfleaverequesthalfday, AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, AV67Leaverequestpendingds_13_tfleaverequestduration, AV68Leaverequestpendingds_14_tfleaverequestduration_to, AV69Udparg15});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6V2 = false;
            A124LeaveTypeId = P006V2_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P006V2_A132LeaveRequestStatus[0];
            A148EmployeeName = P006V2_A148EmployeeName[0];
            A106EmployeeId = P006V2_A106EmployeeId[0];
            A100CompanyId = P006V2_A100CompanyId[0];
            A131LeaveRequestDuration = P006V2_A131LeaveRequestDuration[0];
            A173LeaveRequestHalfDay = P006V2_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P006V2_n173LeaveRequestHalfDay[0];
            A130LeaveRequestEndDate = P006V2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006V2_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006V2_A125LeaveTypeName[0];
            A127LeaveRequestId = P006V2_A127LeaveRequestId[0];
            A100CompanyId = P006V2_A100CompanyId[0];
            A125LeaveTypeName = P006V2_A125LeaveTypeName[0];
            A148EmployeeName = P006V2_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006V2_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK6V2 = false;
               A106EmployeeId = P006V2_A106EmployeeId[0];
               A127LeaveRequestId = P006V2_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6V2 = true;
               pr_default.readNext(0);
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
            if ( ! BRK6V2 )
            {
               BRK6V2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFLeaveTypeName = AV25SearchTxt;
         AV14TFLeaveTypeName_Sel = "";
         AV55Leaverequestpendingds_1_filterfulltext = AV47FilterFullText;
         AV56Leaverequestpendingds_2_tfemployeename = AV11TFEmployeeName;
         AV57Leaverequestpendingds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV58Leaverequestpendingds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV59Leaverequestpendingds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV60Leaverequestpendingds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV61Leaverequestpendingds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV62Leaverequestpendingds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV63Leaverequestpendingds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV64Leaverequestpendingds_10_tfleaverequesthalfday = AV50TFLeaveRequestHalfDay;
         AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator = AV52TFLeaveRequestHalfDayOperator;
         AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel = AV51TFLeaveRequestHalfDay_Sel;
         AV67Leaverequestpendingds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV68Leaverequestpendingds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV69Udparg15 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV55Leaverequestpendingds_1_filterfulltext ,
                                              AV57Leaverequestpendingds_3_tfemployeename_sel ,
                                              AV56Leaverequestpendingds_2_tfemployeename ,
                                              AV59Leaverequestpendingds_5_tfleavetypename_sel ,
                                              AV58Leaverequestpendingds_4_tfleavetypename ,
                                              AV60Leaverequestpendingds_6_tfleaverequeststartdate ,
                                              AV61Leaverequestpendingds_7_tfleaverequeststartdate_to ,
                                              AV62Leaverequestpendingds_8_tfleaverequestenddate ,
                                              AV63Leaverequestpendingds_9_tfleaverequestenddate_to ,
                                              AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel ,
                                              AV64Leaverequestpendingds_10_tfleaverequesthalfday ,
                                              AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator ,
                                              AV67Leaverequestpendingds_13_tfleaverequestduration ,
                                              AV68Leaverequestpendingds_14_tfleaverequestduration_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV69Udparg15 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV56Leaverequestpendingds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV56Leaverequestpendingds_2_tfemployeename), 128, "%");
         lV58Leaverequestpendingds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV58Leaverequestpendingds_4_tfleavetypename), 100, "%");
         lV64Leaverequestpendingds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV64Leaverequestpendingds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P006V3 */
         pr_default.execute(1, new Object[] {lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV56Leaverequestpendingds_2_tfemployeename, AV57Leaverequestpendingds_3_tfemployeename_sel, lV58Leaverequestpendingds_4_tfleavetypename, AV59Leaverequestpendingds_5_tfleavetypename_sel, AV60Leaverequestpendingds_6_tfleaverequeststartdate, AV61Leaverequestpendingds_7_tfleaverequeststartdate_to, AV62Leaverequestpendingds_8_tfleaverequestenddate, AV63Leaverequestpendingds_9_tfleaverequestenddate_to, lV64Leaverequestpendingds_10_tfleaverequesthalfday, AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, AV67Leaverequestpendingds_13_tfleaverequestduration, AV68Leaverequestpendingds_14_tfleaverequestduration_to, AV69Udparg15});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6V4 = false;
            A124LeaveTypeId = P006V3_A124LeaveTypeId[0];
            A106EmployeeId = P006V3_A106EmployeeId[0];
            A100CompanyId = P006V3_A100CompanyId[0];
            A132LeaveRequestStatus = P006V3_A132LeaveRequestStatus[0];
            A131LeaveRequestDuration = P006V3_A131LeaveRequestDuration[0];
            A173LeaveRequestHalfDay = P006V3_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P006V3_n173LeaveRequestHalfDay[0];
            A130LeaveRequestEndDate = P006V3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006V3_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006V3_A125LeaveTypeName[0];
            A148EmployeeName = P006V3_A148EmployeeName[0];
            A127LeaveRequestId = P006V3_A127LeaveRequestId[0];
            A100CompanyId = P006V3_A100CompanyId[0];
            A125LeaveTypeName = P006V3_A125LeaveTypeName[0];
            A148EmployeeName = P006V3_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P006V3_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRK6V4 = false;
               A127LeaveRequestId = P006V3_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6V4 = true;
               pr_default.readNext(1);
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
            if ( ! BRK6V4 )
            {
               BRK6V4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV26SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV34OptionIndexes.RemoveItem(1);
            AV26SkipItems = (short)(AV26SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADLEAVEREQUESTHALFDAYOPTIONS' Routine */
         returnInSub = false;
         AV50TFLeaveRequestHalfDay = AV25SearchTxt;
         AV52TFLeaveRequestHalfDayOperator = 0;
         AV51TFLeaveRequestHalfDay_Sel = "";
         AV55Leaverequestpendingds_1_filterfulltext = AV47FilterFullText;
         AV56Leaverequestpendingds_2_tfemployeename = AV11TFEmployeeName;
         AV57Leaverequestpendingds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV58Leaverequestpendingds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV59Leaverequestpendingds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV60Leaverequestpendingds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV61Leaverequestpendingds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV62Leaverequestpendingds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV63Leaverequestpendingds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV64Leaverequestpendingds_10_tfleaverequesthalfday = AV50TFLeaveRequestHalfDay;
         AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator = AV52TFLeaveRequestHalfDayOperator;
         AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel = AV51TFLeaveRequestHalfDay_Sel;
         AV67Leaverequestpendingds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV68Leaverequestpendingds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV69Udparg15 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV55Leaverequestpendingds_1_filterfulltext ,
                                              AV57Leaverequestpendingds_3_tfemployeename_sel ,
                                              AV56Leaverequestpendingds_2_tfemployeename ,
                                              AV59Leaverequestpendingds_5_tfleavetypename_sel ,
                                              AV58Leaverequestpendingds_4_tfleavetypename ,
                                              AV60Leaverequestpendingds_6_tfleaverequeststartdate ,
                                              AV61Leaverequestpendingds_7_tfleaverequeststartdate_to ,
                                              AV62Leaverequestpendingds_8_tfleaverequestenddate ,
                                              AV63Leaverequestpendingds_9_tfleaverequestenddate_to ,
                                              AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel ,
                                              AV64Leaverequestpendingds_10_tfleaverequesthalfday ,
                                              AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator ,
                                              AV67Leaverequestpendingds_13_tfleaverequestduration ,
                                              AV68Leaverequestpendingds_14_tfleaverequestduration_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV69Udparg15 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext), "%", "");
         lV56Leaverequestpendingds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV56Leaverequestpendingds_2_tfemployeename), 128, "%");
         lV58Leaverequestpendingds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV58Leaverequestpendingds_4_tfleavetypename), 100, "%");
         lV64Leaverequestpendingds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV64Leaverequestpendingds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P006V4 */
         pr_default.execute(2, new Object[] {lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_1_filterfulltext, lV56Leaverequestpendingds_2_tfemployeename, AV57Leaverequestpendingds_3_tfemployeename_sel, lV58Leaverequestpendingds_4_tfleavetypename, AV59Leaverequestpendingds_5_tfleavetypename_sel, AV60Leaverequestpendingds_6_tfleaverequeststartdate, AV61Leaverequestpendingds_7_tfleaverequeststartdate_to, AV62Leaverequestpendingds_8_tfleaverequestenddate, AV63Leaverequestpendingds_9_tfleaverequestenddate_to, lV64Leaverequestpendingds_10_tfleaverequesthalfday, AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, AV67Leaverequestpendingds_13_tfleaverequestduration, AV68Leaverequestpendingds_14_tfleaverequestduration_to, AV69Udparg15});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6V6 = false;
            A124LeaveTypeId = P006V4_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P006V4_A132LeaveRequestStatus[0];
            A173LeaveRequestHalfDay = P006V4_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P006V4_n173LeaveRequestHalfDay[0];
            A106EmployeeId = P006V4_A106EmployeeId[0];
            A100CompanyId = P006V4_A100CompanyId[0];
            A131LeaveRequestDuration = P006V4_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006V4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006V4_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006V4_A125LeaveTypeName[0];
            A148EmployeeName = P006V4_A148EmployeeName[0];
            A127LeaveRequestId = P006V4_A127LeaveRequestId[0];
            A100CompanyId = P006V4_A100CompanyId[0];
            A125LeaveTypeName = P006V4_A125LeaveTypeName[0];
            A148EmployeeName = P006V4_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006V4_A173LeaveRequestHalfDay[0], A173LeaveRequestHalfDay) == 0 ) )
            {
               BRK6V6 = false;
               A127LeaveRequestId = P006V4_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6V6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveRequestHalfDay)) ? "<#Empty#>" : A173LeaveRequestHalfDay);
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
         AV11TFEmployeeName = "";
         AV12TFEmployeeName_Sel = "";
         AV13TFLeaveTypeName = "";
         AV14TFLeaveTypeName_Sel = "";
         AV17TFLeaveRequestStartDate = DateTime.MinValue;
         AV18TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV19TFLeaveRequestEndDate = DateTime.MinValue;
         AV20TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV50TFLeaveRequestHalfDay = "";
         AV51TFLeaveRequestHalfDay_Sel = "";
         AV55Leaverequestpendingds_1_filterfulltext = "";
         AV56Leaverequestpendingds_2_tfemployeename = "";
         AV57Leaverequestpendingds_3_tfemployeename_sel = "";
         AV58Leaverequestpendingds_4_tfleavetypename = "";
         AV59Leaverequestpendingds_5_tfleavetypename_sel = "";
         AV60Leaverequestpendingds_6_tfleaverequeststartdate = DateTime.MinValue;
         AV61Leaverequestpendingds_7_tfleaverequeststartdate_to = DateTime.MinValue;
         AV62Leaverequestpendingds_8_tfleaverequestenddate = DateTime.MinValue;
         AV63Leaverequestpendingds_9_tfleaverequestenddate_to = DateTime.MinValue;
         AV64Leaverequestpendingds_10_tfleaverequesthalfday = "";
         AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel = "";
         scmdbuf = "";
         lV55Leaverequestpendingds_1_filterfulltext = "";
         lV56Leaverequestpendingds_2_tfemployeename = "";
         lV58Leaverequestpendingds_4_tfleavetypename = "";
         lV64Leaverequestpendingds_10_tfleaverequesthalfday = "";
         AV48EmployeeIds = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         A125LeaveTypeName = "";
         A173LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P006V2_A124LeaveTypeId = new long[1] ;
         P006V2_A132LeaveRequestStatus = new string[] {""} ;
         P006V2_A148EmployeeName = new string[] {""} ;
         P006V2_A106EmployeeId = new long[1] ;
         P006V2_A100CompanyId = new long[1] ;
         P006V2_A131LeaveRequestDuration = new decimal[1] ;
         P006V2_A173LeaveRequestHalfDay = new string[] {""} ;
         P006V2_n173LeaveRequestHalfDay = new bool[] {false} ;
         P006V2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006V2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006V2_A125LeaveTypeName = new string[] {""} ;
         P006V2_A127LeaveRequestId = new long[1] ;
         AV30Option = "";
         P006V3_A124LeaveTypeId = new long[1] ;
         P006V3_A106EmployeeId = new long[1] ;
         P006V3_A100CompanyId = new long[1] ;
         P006V3_A132LeaveRequestStatus = new string[] {""} ;
         P006V3_A131LeaveRequestDuration = new decimal[1] ;
         P006V3_A173LeaveRequestHalfDay = new string[] {""} ;
         P006V3_n173LeaveRequestHalfDay = new bool[] {false} ;
         P006V3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006V3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006V3_A125LeaveTypeName = new string[] {""} ;
         P006V3_A148EmployeeName = new string[] {""} ;
         P006V3_A127LeaveRequestId = new long[1] ;
         P006V4_A124LeaveTypeId = new long[1] ;
         P006V4_A132LeaveRequestStatus = new string[] {""} ;
         P006V4_A173LeaveRequestHalfDay = new string[] {""} ;
         P006V4_n173LeaveRequestHalfDay = new bool[] {false} ;
         P006V4_A106EmployeeId = new long[1] ;
         P006V4_A100CompanyId = new long[1] ;
         P006V4_A131LeaveRequestDuration = new decimal[1] ;
         P006V4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006V4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006V4_A125LeaveTypeName = new string[] {""} ;
         P006V4_A148EmployeeName = new string[] {""} ;
         P006V4_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestpendinggetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006V2_A124LeaveTypeId, P006V2_A132LeaveRequestStatus, P006V2_A148EmployeeName, P006V2_A106EmployeeId, P006V2_A100CompanyId, P006V2_A131LeaveRequestDuration, P006V2_A173LeaveRequestHalfDay, P006V2_n173LeaveRequestHalfDay, P006V2_A130LeaveRequestEndDate, P006V2_A129LeaveRequestStartDate,
               P006V2_A125LeaveTypeName, P006V2_A127LeaveRequestId
               }
               , new Object[] {
               P006V3_A124LeaveTypeId, P006V3_A106EmployeeId, P006V3_A100CompanyId, P006V3_A132LeaveRequestStatus, P006V3_A131LeaveRequestDuration, P006V3_A173LeaveRequestHalfDay, P006V3_n173LeaveRequestHalfDay, P006V3_A130LeaveRequestEndDate, P006V3_A129LeaveRequestStartDate, P006V3_A125LeaveTypeName,
               P006V3_A148EmployeeName, P006V3_A127LeaveRequestId
               }
               , new Object[] {
               P006V4_A124LeaveTypeId, P006V4_A132LeaveRequestStatus, P006V4_A173LeaveRequestHalfDay, P006V4_n173LeaveRequestHalfDay, P006V4_A106EmployeeId, P006V4_A100CompanyId, P006V4_A131LeaveRequestDuration, P006V4_A130LeaveRequestEndDate, P006V4_A129LeaveRequestStartDate, P006V4_A125LeaveTypeName,
               P006V4_A148EmployeeName, P006V4_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV52TFLeaveRequestHalfDayOperator ;
      private short AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator ;
      private int AV53GXV1 ;
      private int AV29InsertIndex ;
      private long AV69Udparg15 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV35count ;
      private decimal AV21TFLeaveRequestDuration ;
      private decimal AV22TFLeaveRequestDuration_To ;
      private decimal AV67Leaverequestpendingds_13_tfleaverequestduration ;
      private decimal AV68Leaverequestpendingds_14_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV11TFEmployeeName ;
      private string AV12TFEmployeeName_Sel ;
      private string AV13TFLeaveTypeName ;
      private string AV14TFLeaveTypeName_Sel ;
      private string AV50TFLeaveRequestHalfDay ;
      private string AV51TFLeaveRequestHalfDay_Sel ;
      private string AV56Leaverequestpendingds_2_tfemployeename ;
      private string AV57Leaverequestpendingds_3_tfemployeename_sel ;
      private string AV58Leaverequestpendingds_4_tfleavetypename ;
      private string AV59Leaverequestpendingds_5_tfleavetypename_sel ;
      private string AV64Leaverequestpendingds_10_tfleaverequesthalfday ;
      private string AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel ;
      private string scmdbuf ;
      private string lV56Leaverequestpendingds_2_tfemployeename ;
      private string lV58Leaverequestpendingds_4_tfleavetypename ;
      private string lV64Leaverequestpendingds_10_tfleaverequesthalfday ;
      private string A148EmployeeName ;
      private string A125LeaveTypeName ;
      private string A173LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private DateTime AV17TFLeaveRequestStartDate ;
      private DateTime AV18TFLeaveRequestStartDate_To ;
      private DateTime AV19TFLeaveRequestEndDate ;
      private DateTime AV20TFLeaveRequestEndDate_To ;
      private DateTime AV60Leaverequestpendingds_6_tfleaverequeststartdate ;
      private DateTime AV61Leaverequestpendingds_7_tfleaverequeststartdate_to ;
      private DateTime AV62Leaverequestpendingds_8_tfleaverequestenddate ;
      private DateTime AV63Leaverequestpendingds_9_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK6V2 ;
      private bool n173LeaveRequestHalfDay ;
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
      private string AV55Leaverequestpendingds_1_filterfulltext ;
      private string lV55Leaverequestpendingds_1_filterfulltext ;
      private string AV30Option ;
      private GxSimpleCollection<long> AV48EmployeeIds ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P006V2_A124LeaveTypeId ;
      private string[] P006V2_A132LeaveRequestStatus ;
      private string[] P006V2_A148EmployeeName ;
      private long[] P006V2_A106EmployeeId ;
      private long[] P006V2_A100CompanyId ;
      private decimal[] P006V2_A131LeaveRequestDuration ;
      private string[] P006V2_A173LeaveRequestHalfDay ;
      private bool[] P006V2_n173LeaveRequestHalfDay ;
      private DateTime[] P006V2_A130LeaveRequestEndDate ;
      private DateTime[] P006V2_A129LeaveRequestStartDate ;
      private string[] P006V2_A125LeaveTypeName ;
      private long[] P006V2_A127LeaveRequestId ;
      private long[] P006V3_A124LeaveTypeId ;
      private long[] P006V3_A106EmployeeId ;
      private long[] P006V3_A100CompanyId ;
      private string[] P006V3_A132LeaveRequestStatus ;
      private decimal[] P006V3_A131LeaveRequestDuration ;
      private string[] P006V3_A173LeaveRequestHalfDay ;
      private bool[] P006V3_n173LeaveRequestHalfDay ;
      private DateTime[] P006V3_A130LeaveRequestEndDate ;
      private DateTime[] P006V3_A129LeaveRequestStartDate ;
      private string[] P006V3_A125LeaveTypeName ;
      private string[] P006V3_A148EmployeeName ;
      private long[] P006V3_A127LeaveRequestId ;
      private long[] P006V4_A124LeaveTypeId ;
      private string[] P006V4_A132LeaveRequestStatus ;
      private string[] P006V4_A173LeaveRequestHalfDay ;
      private bool[] P006V4_n173LeaveRequestHalfDay ;
      private long[] P006V4_A106EmployeeId ;
      private long[] P006V4_A100CompanyId ;
      private decimal[] P006V4_A131LeaveRequestDuration ;
      private DateTime[] P006V4_A130LeaveRequestEndDate ;
      private DateTime[] P006V4_A129LeaveRequestStartDate ;
      private string[] P006V4_A125LeaveTypeName ;
      private string[] P006V4_A148EmployeeName ;
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
                                             string AV55Leaverequestpendingds_1_filterfulltext ,
                                             string AV57Leaverequestpendingds_3_tfemployeename_sel ,
                                             string AV56Leaverequestpendingds_2_tfemployeename ,
                                             string AV59Leaverequestpendingds_5_tfleavetypename_sel ,
                                             string AV58Leaverequestpendingds_4_tfleavetypename ,
                                             DateTime AV60Leaverequestpendingds_6_tfleaverequeststartdate ,
                                             DateTime AV61Leaverequestpendingds_7_tfleaverequeststartdate_to ,
                                             DateTime AV62Leaverequestpendingds_8_tfleaverequestenddate ,
                                             DateTime AV63Leaverequestpendingds_9_tfleaverequestenddate_to ,
                                             string AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel ,
                                             string AV64Leaverequestpendingds_10_tfleaverequesthalfday ,
                                             short AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV67Leaverequestpendingds_13_tfleaverequestduration ,
                                             decimal AV68Leaverequestpendingds_14_tfleaverequestduration_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV69Udparg15 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T3.EmployeeName, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T3.EmployeeName) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV55Leaverequestpendingds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestpendingds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Leaverequestpendingds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV56Leaverequestpendingds_2_tfemployeename))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestpendingds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV57Leaverequestpendingds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV57Leaverequestpendingds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV57Leaverequestpendingds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestpendingds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestpendingds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV58Leaverequestpendingds_4_tfleavetypename))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestpendingds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV59Leaverequestpendingds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV59Leaverequestpendingds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Leaverequestpendingds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV60Leaverequestpendingds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV60Leaverequestpendingds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV61Leaverequestpendingds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV61Leaverequestpendingds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Leaverequestpendingds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV62Leaverequestpendingds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestpendingds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV63Leaverequestpendingds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV64Leaverequestpendingds_10_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV67Leaverequestpendingds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV67Leaverequestpendingds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV68Leaverequestpendingds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV68Leaverequestpendingds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV69Udparg15)");
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
         scmdbuf += " ORDER BY T3.EmployeeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006V3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV48EmployeeIds ,
                                             string AV55Leaverequestpendingds_1_filterfulltext ,
                                             string AV57Leaverequestpendingds_3_tfemployeename_sel ,
                                             string AV56Leaverequestpendingds_2_tfemployeename ,
                                             string AV59Leaverequestpendingds_5_tfleavetypename_sel ,
                                             string AV58Leaverequestpendingds_4_tfleavetypename ,
                                             DateTime AV60Leaverequestpendingds_6_tfleaverequeststartdate ,
                                             DateTime AV61Leaverequestpendingds_7_tfleaverequeststartdate_to ,
                                             DateTime AV62Leaverequestpendingds_8_tfleaverequestenddate ,
                                             DateTime AV63Leaverequestpendingds_9_tfleaverequestenddate_to ,
                                             string AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel ,
                                             string AV64Leaverequestpendingds_10_tfleaverequesthalfday ,
                                             short AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV67Leaverequestpendingds_13_tfleaverequestduration ,
                                             decimal AV68Leaverequestpendingds_14_tfleaverequestduration_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV69Udparg15 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestStatus, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T3.EmployeeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T3.EmployeeName) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV55Leaverequestpendingds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestpendingds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Leaverequestpendingds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV56Leaverequestpendingds_2_tfemployeename))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestpendingds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV57Leaverequestpendingds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV57Leaverequestpendingds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV57Leaverequestpendingds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestpendingds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestpendingds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV58Leaverequestpendingds_4_tfleavetypename))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestpendingds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV59Leaverequestpendingds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV59Leaverequestpendingds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Leaverequestpendingds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV60Leaverequestpendingds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV60Leaverequestpendingds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV61Leaverequestpendingds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV61Leaverequestpendingds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Leaverequestpendingds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV62Leaverequestpendingds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestpendingds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV63Leaverequestpendingds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV64Leaverequestpendingds_10_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV67Leaverequestpendingds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV67Leaverequestpendingds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV68Leaverequestpendingds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV68Leaverequestpendingds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV69Udparg15)");
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
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006V4( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV48EmployeeIds ,
                                             string AV55Leaverequestpendingds_1_filterfulltext ,
                                             string AV57Leaverequestpendingds_3_tfemployeename_sel ,
                                             string AV56Leaverequestpendingds_2_tfemployeename ,
                                             string AV59Leaverequestpendingds_5_tfleavetypename_sel ,
                                             string AV58Leaverequestpendingds_4_tfleavetypename ,
                                             DateTime AV60Leaverequestpendingds_6_tfleaverequeststartdate ,
                                             DateTime AV61Leaverequestpendingds_7_tfleaverequeststartdate_to ,
                                             DateTime AV62Leaverequestpendingds_8_tfleaverequestenddate ,
                                             DateTime AV63Leaverequestpendingds_9_tfleaverequestenddate_to ,
                                             string AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel ,
                                             string AV64Leaverequestpendingds_10_tfleaverequesthalfday ,
                                             short AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV67Leaverequestpendingds_13_tfleaverequestduration ,
                                             decimal AV68Leaverequestpendingds_14_tfleaverequestduration_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV69Udparg15 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.LeaveRequestHalfDay, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T3.EmployeeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestpendingds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T3.EmployeeName) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV55Leaverequestpendingds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV55Leaverequestpendingds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestpendingds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Leaverequestpendingds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV56Leaverequestpendingds_2_tfemployeename))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestpendingds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV57Leaverequestpendingds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV57Leaverequestpendingds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV57Leaverequestpendingds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestpendingds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestpendingds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV58Leaverequestpendingds_4_tfleavetypename))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestpendingds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV59Leaverequestpendingds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV59Leaverequestpendingds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Leaverequestpendingds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV60Leaverequestpendingds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV60Leaverequestpendingds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV61Leaverequestpendingds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV61Leaverequestpendingds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Leaverequestpendingds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV62Leaverequestpendingds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestpendingds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV63Leaverequestpendingds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV64Leaverequestpendingds_10_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV65Leaverequestpendingds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV67Leaverequestpendingds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV67Leaverequestpendingds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV68Leaverequestpendingds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV68Leaverequestpendingds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV69Udparg15)");
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
         scmdbuf += " ORDER BY T1.LeaveRequestHalfDay";
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
                     return conditional_P006V2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] );
               case 1 :
                     return conditional_P006V3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] );
               case 2 :
                     return conditional_P006V4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] );
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
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestpendingds_2_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV57Leaverequestpendingds_3_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV58Leaverequestpendingds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV59Leaverequestpendingds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestpendingds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV61Leaverequestpendingds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV62Leaverequestpendingds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV63Leaverequestpendingds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV64Leaverequestpendingds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV67Leaverequestpendingds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV68Leaverequestpendingds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV69Udparg15",GXType.Int64,10,0)
          };
          Object[] prmP006V3;
          prmP006V3 = new Object[] {
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestpendingds_2_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV57Leaverequestpendingds_3_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV58Leaverequestpendingds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV59Leaverequestpendingds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestpendingds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV61Leaverequestpendingds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV62Leaverequestpendingds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV63Leaverequestpendingds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV64Leaverequestpendingds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV67Leaverequestpendingds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV68Leaverequestpendingds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV69Udparg15",GXType.Int64,10,0)
          };
          Object[] prmP006V4;
          prmP006V4 = new Object[] {
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestpendingds_2_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV57Leaverequestpendingds_3_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV58Leaverequestpendingds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV59Leaverequestpendingds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestpendingds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV61Leaverequestpendingds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV62Leaverequestpendingds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV63Leaverequestpendingds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV64Leaverequestpendingds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV66Leaverequestpendingds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV67Leaverequestpendingds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV68Leaverequestpendingds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV69Udparg15",GXType.Int64,10,0)
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 128);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 128);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 128);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
