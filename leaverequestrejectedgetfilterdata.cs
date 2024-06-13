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
   public class leaverequestrejectedgetfilterdata : GXProcedure
   {
      public leaverequestrejectedgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestrejectedgetfilterdata( IGxContext context )
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
         leaverequestrejectedgetfilterdata objleaverequestrejectedgetfilterdata;
         objleaverequestrejectedgetfilterdata = new leaverequestrejectedgetfilterdata();
         objleaverequestrejectedgetfilterdata.AV43DDOName = aP0_DDOName;
         objleaverequestrejectedgetfilterdata.AV44SearchTxtParms = aP1_SearchTxtParms;
         objleaverequestrejectedgetfilterdata.AV45SearchTxtTo = aP2_SearchTxtTo;
         objleaverequestrejectedgetfilterdata.AV46OptionsJson = "" ;
         objleaverequestrejectedgetfilterdata.AV47OptionsDescJson = "" ;
         objleaverequestrejectedgetfilterdata.AV48OptionIndexesJson = "" ;
         objleaverequestrejectedgetfilterdata.context.SetSubmitInitialConfig(context);
         objleaverequestrejectedgetfilterdata.initialize();
         Submit( executePrivateCatch,objleaverequestrejectedgetfilterdata);
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leaverequestrejectedgetfilterdata)stateInfo).executePrivate();
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
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S151 ();
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
         if ( StringUtil.StrCmp(AV38Session.Get("LeaveRequestRejectedGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LeaveRequestRejectedGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("LeaveRequestRejectedGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV49FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV13TFLeaveTypeName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV14TFLeaveTypeName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV17TFLeaveRequestStartDate = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 1);
               AV18TFLeaveRequestStartDate_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV19TFLeaveRequestEndDate = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 1);
               AV20TFLeaveRequestEndDate_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV21TFLeaveRequestDuration = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV22TFLeaveRequestDuration_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
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
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV11TFEmployeeName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV12TFEmployeeName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFLeaveTypeName = AV27SearchTxt;
         AV14TFLeaveTypeName_Sel = "";
         AV53Leaverequestrejectedds_1_filterfulltext = AV49FilterFullText;
         AV54Leaverequestrejectedds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV55Leaverequestrejectedds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV56Leaverequestrejectedds_4_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV58Leaverequestrejectedds_6_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV59Leaverequestrejectedds_7_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV60Leaverequestrejectedds_8_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV61Leaverequestrejectedds_9_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV62Leaverequestrejectedds_10_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = AV25TFLeaveRequestRejectionReason;
         AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel = AV26TFLeaveRequestRejectionReason_Sel;
         AV66Leaverequestrejectedds_14_tfemployeename = AV11TFEmployeeName;
         AV67Leaverequestrejectedds_15_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV68Udparg16 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV53Leaverequestrejectedds_1_filterfulltext ,
                                              AV55Leaverequestrejectedds_3_tfleavetypename_sel ,
                                              AV54Leaverequestrejectedds_2_tfleavetypename ,
                                              AV56Leaverequestrejectedds_4_tfleaverequeststartdate ,
                                              AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ,
                                              AV58Leaverequestrejectedds_6_tfleaverequestenddate ,
                                              AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ,
                                              AV60Leaverequestrejectedds_8_tfleaverequestduration ,
                                              AV61Leaverequestrejectedds_9_tfleaverequestduration_to ,
                                              AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ,
                                              AV62Leaverequestrejectedds_10_tfleaverequestdescription ,
                                              AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ,
                                              AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ,
                                              AV67Leaverequestrejectedds_15_tfemployeename_sel ,
                                              AV66Leaverequestrejectedds_14_tfemployeename ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A148EmployeeName ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV68Udparg16 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV54Leaverequestrejectedds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV54Leaverequestrejectedds_2_tfleavetypename), 100, "%");
         lV62Leaverequestrejectedds_10_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestrejectedds_10_tfleaverequestdescription), "%", "");
         lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason), "%", "");
         lV66Leaverequestrejectedds_14_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV66Leaverequestrejectedds_14_tfemployeename), 128, "%");
         /* Using cursor P00712 */
         pr_default.execute(0, new Object[] {lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV54Leaverequestrejectedds_2_tfleavetypename, AV55Leaverequestrejectedds_3_tfleavetypename_sel, AV56Leaverequestrejectedds_4_tfleaverequeststartdate, AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to, AV58Leaverequestrejectedds_6_tfleaverequestenddate, AV59Leaverequestrejectedds_7_tfleaverequestenddate_to, AV60Leaverequestrejectedds_8_tfleaverequestduration, AV61Leaverequestrejectedds_9_tfleaverequestduration_to, lV62Leaverequestrejectedds_10_tfleaverequestdescription, AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason, AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, lV66Leaverequestrejectedds_14_tfemployeename, AV67Leaverequestrejectedds_15_tfemployeename_sel, AV68Udparg16});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK712 = false;
            A124LeaveTypeId = P00712_A124LeaveTypeId[0];
            A100CompanyId = P00712_A100CompanyId[0];
            A106EmployeeId = P00712_A106EmployeeId[0];
            A132LeaveRequestStatus = P00712_A132LeaveRequestStatus[0];
            A148EmployeeName = P00712_A148EmployeeName[0];
            A134LeaveRequestRejectionReason = P00712_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P00712_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P00712_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00712_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00712_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P00712_A125LeaveTypeName[0];
            A127LeaveRequestId = P00712_A127LeaveRequestId[0];
            A100CompanyId = P00712_A100CompanyId[0];
            A125LeaveTypeName = P00712_A125LeaveTypeName[0];
            A148EmployeeName = P00712_A148EmployeeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00712_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRK712 = false;
               A127LeaveRequestId = P00712_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK712 = true;
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
            if ( ! BRK712 )
            {
               BRK712 = true;
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
         AV53Leaverequestrejectedds_1_filterfulltext = AV49FilterFullText;
         AV54Leaverequestrejectedds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV55Leaverequestrejectedds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV56Leaverequestrejectedds_4_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV58Leaverequestrejectedds_6_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV59Leaverequestrejectedds_7_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV60Leaverequestrejectedds_8_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV61Leaverequestrejectedds_9_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV62Leaverequestrejectedds_10_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = AV25TFLeaveRequestRejectionReason;
         AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel = AV26TFLeaveRequestRejectionReason_Sel;
         AV66Leaverequestrejectedds_14_tfemployeename = AV11TFEmployeeName;
         AV67Leaverequestrejectedds_15_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV68Udparg16 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV53Leaverequestrejectedds_1_filterfulltext ,
                                              AV55Leaverequestrejectedds_3_tfleavetypename_sel ,
                                              AV54Leaverequestrejectedds_2_tfleavetypename ,
                                              AV56Leaverequestrejectedds_4_tfleaverequeststartdate ,
                                              AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ,
                                              AV58Leaverequestrejectedds_6_tfleaverequestenddate ,
                                              AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ,
                                              AV60Leaverequestrejectedds_8_tfleaverequestduration ,
                                              AV61Leaverequestrejectedds_9_tfleaverequestduration_to ,
                                              AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ,
                                              AV62Leaverequestrejectedds_10_tfleaverequestdescription ,
                                              AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ,
                                              AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ,
                                              AV67Leaverequestrejectedds_15_tfemployeename_sel ,
                                              AV66Leaverequestrejectedds_14_tfemployeename ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A148EmployeeName ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV68Udparg16 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV54Leaverequestrejectedds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV54Leaverequestrejectedds_2_tfleavetypename), 100, "%");
         lV62Leaverequestrejectedds_10_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestrejectedds_10_tfleaverequestdescription), "%", "");
         lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason), "%", "");
         lV66Leaverequestrejectedds_14_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV66Leaverequestrejectedds_14_tfemployeename), 128, "%");
         /* Using cursor P00713 */
         pr_default.execute(1, new Object[] {lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV54Leaverequestrejectedds_2_tfleavetypename, AV55Leaverequestrejectedds_3_tfleavetypename_sel, AV56Leaverequestrejectedds_4_tfleaverequeststartdate, AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to, AV58Leaverequestrejectedds_6_tfleaverequestenddate, AV59Leaverequestrejectedds_7_tfleaverequestenddate_to, AV60Leaverequestrejectedds_8_tfleaverequestduration, AV61Leaverequestrejectedds_9_tfleaverequestduration_to, lV62Leaverequestrejectedds_10_tfleaverequestdescription, AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason, AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, lV66Leaverequestrejectedds_14_tfemployeename, AV67Leaverequestrejectedds_15_tfemployeename_sel, AV68Udparg16});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK714 = false;
            A124LeaveTypeId = P00713_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P00713_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = P00713_A133LeaveRequestDescription[0];
            A100CompanyId = P00713_A100CompanyId[0];
            A106EmployeeId = P00713_A106EmployeeId[0];
            A148EmployeeName = P00713_A148EmployeeName[0];
            A134LeaveRequestRejectionReason = P00713_A134LeaveRequestRejectionReason[0];
            A131LeaveRequestDuration = P00713_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00713_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00713_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P00713_A125LeaveTypeName[0];
            A127LeaveRequestId = P00713_A127LeaveRequestId[0];
            A100CompanyId = P00713_A100CompanyId[0];
            A125LeaveTypeName = P00713_A125LeaveTypeName[0];
            A148EmployeeName = P00713_A148EmployeeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00713_A133LeaveRequestDescription[0], A133LeaveRequestDescription) == 0 ) )
            {
               BRK714 = false;
               A127LeaveRequestId = P00713_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK714 = true;
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
            if ( ! BRK714 )
            {
               BRK714 = true;
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
         AV53Leaverequestrejectedds_1_filterfulltext = AV49FilterFullText;
         AV54Leaverequestrejectedds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV55Leaverequestrejectedds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV56Leaverequestrejectedds_4_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV58Leaverequestrejectedds_6_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV59Leaverequestrejectedds_7_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV60Leaverequestrejectedds_8_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV61Leaverequestrejectedds_9_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV62Leaverequestrejectedds_10_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = AV25TFLeaveRequestRejectionReason;
         AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel = AV26TFLeaveRequestRejectionReason_Sel;
         AV66Leaverequestrejectedds_14_tfemployeename = AV11TFEmployeeName;
         AV67Leaverequestrejectedds_15_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV68Udparg16 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV53Leaverequestrejectedds_1_filterfulltext ,
                                              AV55Leaverequestrejectedds_3_tfleavetypename_sel ,
                                              AV54Leaverequestrejectedds_2_tfleavetypename ,
                                              AV56Leaverequestrejectedds_4_tfleaverequeststartdate ,
                                              AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ,
                                              AV58Leaverequestrejectedds_6_tfleaverequestenddate ,
                                              AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ,
                                              AV60Leaverequestrejectedds_8_tfleaverequestduration ,
                                              AV61Leaverequestrejectedds_9_tfleaverequestduration_to ,
                                              AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ,
                                              AV62Leaverequestrejectedds_10_tfleaverequestdescription ,
                                              AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ,
                                              AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ,
                                              AV67Leaverequestrejectedds_15_tfemployeename_sel ,
                                              AV66Leaverequestrejectedds_14_tfemployeename ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A148EmployeeName ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV68Udparg16 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV54Leaverequestrejectedds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV54Leaverequestrejectedds_2_tfleavetypename), 100, "%");
         lV62Leaverequestrejectedds_10_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestrejectedds_10_tfleaverequestdescription), "%", "");
         lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason), "%", "");
         lV66Leaverequestrejectedds_14_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV66Leaverequestrejectedds_14_tfemployeename), 128, "%");
         /* Using cursor P00714 */
         pr_default.execute(2, new Object[] {lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV54Leaverequestrejectedds_2_tfleavetypename, AV55Leaverequestrejectedds_3_tfleavetypename_sel, AV56Leaverequestrejectedds_4_tfleaverequeststartdate, AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to, AV58Leaverequestrejectedds_6_tfleaverequestenddate, AV59Leaverequestrejectedds_7_tfleaverequestenddate_to, AV60Leaverequestrejectedds_8_tfleaverequestduration, AV61Leaverequestrejectedds_9_tfleaverequestduration_to, lV62Leaverequestrejectedds_10_tfleaverequestdescription, AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason, AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, lV66Leaverequestrejectedds_14_tfemployeename, AV67Leaverequestrejectedds_15_tfemployeename_sel, AV68Udparg16});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK716 = false;
            A124LeaveTypeId = P00714_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P00714_A132LeaveRequestStatus[0];
            A134LeaveRequestRejectionReason = P00714_A134LeaveRequestRejectionReason[0];
            A100CompanyId = P00714_A100CompanyId[0];
            A106EmployeeId = P00714_A106EmployeeId[0];
            A148EmployeeName = P00714_A148EmployeeName[0];
            A133LeaveRequestDescription = P00714_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P00714_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00714_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00714_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P00714_A125LeaveTypeName[0];
            A127LeaveRequestId = P00714_A127LeaveRequestId[0];
            A100CompanyId = P00714_A100CompanyId[0];
            A125LeaveTypeName = P00714_A125LeaveTypeName[0];
            A148EmployeeName = P00714_A148EmployeeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00714_A134LeaveRequestRejectionReason[0], A134LeaveRequestRejectionReason) == 0 ) )
            {
               BRK716 = false;
               A127LeaveRequestId = P00714_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK716 = true;
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
            if ( ! BRK716 )
            {
               BRK716 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFEmployeeName = AV27SearchTxt;
         AV12TFEmployeeName_Sel = "";
         AV53Leaverequestrejectedds_1_filterfulltext = AV49FilterFullText;
         AV54Leaverequestrejectedds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV55Leaverequestrejectedds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV56Leaverequestrejectedds_4_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV58Leaverequestrejectedds_6_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV59Leaverequestrejectedds_7_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV60Leaverequestrejectedds_8_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV61Leaverequestrejectedds_9_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV62Leaverequestrejectedds_10_tfleaverequestdescription = AV23TFLeaveRequestDescription;
         AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel = AV24TFLeaveRequestDescription_Sel;
         AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = AV25TFLeaveRequestRejectionReason;
         AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel = AV26TFLeaveRequestRejectionReason_Sel;
         AV66Leaverequestrejectedds_14_tfemployeename = AV11TFEmployeeName;
         AV67Leaverequestrejectedds_15_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV68Udparg16 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV53Leaverequestrejectedds_1_filterfulltext ,
                                              AV55Leaverequestrejectedds_3_tfleavetypename_sel ,
                                              AV54Leaverequestrejectedds_2_tfleavetypename ,
                                              AV56Leaverequestrejectedds_4_tfleaverequeststartdate ,
                                              AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ,
                                              AV58Leaverequestrejectedds_6_tfleaverequestenddate ,
                                              AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ,
                                              AV60Leaverequestrejectedds_8_tfleaverequestduration ,
                                              AV61Leaverequestrejectedds_9_tfleaverequestduration_to ,
                                              AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ,
                                              AV62Leaverequestrejectedds_10_tfleaverequestdescription ,
                                              AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ,
                                              AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ,
                                              AV67Leaverequestrejectedds_15_tfemployeename_sel ,
                                              AV66Leaverequestrejectedds_14_tfemployeename ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A148EmployeeName ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV68Udparg16 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV53Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV54Leaverequestrejectedds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV54Leaverequestrejectedds_2_tfleavetypename), 100, "%");
         lV62Leaverequestrejectedds_10_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestrejectedds_10_tfleaverequestdescription), "%", "");
         lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason), "%", "");
         lV66Leaverequestrejectedds_14_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV66Leaverequestrejectedds_14_tfemployeename), 128, "%");
         /* Using cursor P00715 */
         pr_default.execute(3, new Object[] {lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV53Leaverequestrejectedds_1_filterfulltext, lV54Leaverequestrejectedds_2_tfleavetypename, AV55Leaverequestrejectedds_3_tfleavetypename_sel, AV56Leaverequestrejectedds_4_tfleaverequeststartdate, AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to, AV58Leaverequestrejectedds_6_tfleaverequestenddate, AV59Leaverequestrejectedds_7_tfleaverequestenddate_to, AV60Leaverequestrejectedds_8_tfleaverequestduration, AV61Leaverequestrejectedds_9_tfleaverequestduration_to, lV62Leaverequestrejectedds_10_tfleaverequestdescription, AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason, AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, lV66Leaverequestrejectedds_14_tfemployeename, AV67Leaverequestrejectedds_15_tfemployeename_sel, AV68Udparg16});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK718 = false;
            A124LeaveTypeId = P00715_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P00715_A132LeaveRequestStatus[0];
            A148EmployeeName = P00715_A148EmployeeName[0];
            A100CompanyId = P00715_A100CompanyId[0];
            A106EmployeeId = P00715_A106EmployeeId[0];
            A134LeaveRequestRejectionReason = P00715_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P00715_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P00715_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00715_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00715_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P00715_A125LeaveTypeName[0];
            A127LeaveRequestId = P00715_A127LeaveRequestId[0];
            A100CompanyId = P00715_A100CompanyId[0];
            A125LeaveTypeName = P00715_A125LeaveTypeName[0];
            A148EmployeeName = P00715_A148EmployeeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00715_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK718 = false;
               A106EmployeeId = P00715_A106EmployeeId[0];
               A127LeaveRequestId = P00715_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK718 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
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
            if ( ! BRK718 )
            {
               BRK718 = true;
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
         AV13TFLeaveTypeName = "";
         AV14TFLeaveTypeName_Sel = "";
         AV17TFLeaveRequestStartDate = DateTime.MinValue;
         AV18TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV19TFLeaveRequestEndDate = DateTime.MinValue;
         AV20TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV23TFLeaveRequestDescription = "";
         AV24TFLeaveRequestDescription_Sel = "";
         AV25TFLeaveRequestRejectionReason = "";
         AV26TFLeaveRequestRejectionReason_Sel = "";
         AV11TFEmployeeName = "";
         AV12TFEmployeeName_Sel = "";
         AV53Leaverequestrejectedds_1_filterfulltext = "";
         AV54Leaverequestrejectedds_2_tfleavetypename = "";
         AV55Leaverequestrejectedds_3_tfleavetypename_sel = "";
         AV56Leaverequestrejectedds_4_tfleaverequeststartdate = DateTime.MinValue;
         AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to = DateTime.MinValue;
         AV58Leaverequestrejectedds_6_tfleaverequestenddate = DateTime.MinValue;
         AV59Leaverequestrejectedds_7_tfleaverequestenddate_to = DateTime.MinValue;
         AV62Leaverequestrejectedds_10_tfleaverequestdescription = "";
         AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel = "";
         AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = "";
         AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel = "";
         AV66Leaverequestrejectedds_14_tfemployeename = "";
         AV67Leaverequestrejectedds_15_tfemployeename_sel = "";
         scmdbuf = "";
         lV53Leaverequestrejectedds_1_filterfulltext = "";
         lV54Leaverequestrejectedds_2_tfleavetypename = "";
         lV62Leaverequestrejectedds_10_tfleaverequestdescription = "";
         lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason = "";
         lV66Leaverequestrejectedds_14_tfemployeename = "";
         AV50EmployeeIds = new GxSimpleCollection<long>();
         A125LeaveTypeName = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A148EmployeeName = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P00712_A124LeaveTypeId = new long[1] ;
         P00712_A100CompanyId = new long[1] ;
         P00712_A106EmployeeId = new long[1] ;
         P00712_A132LeaveRequestStatus = new string[] {""} ;
         P00712_A148EmployeeName = new string[] {""} ;
         P00712_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00712_A133LeaveRequestDescription = new string[] {""} ;
         P00712_A131LeaveRequestDuration = new decimal[1] ;
         P00712_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00712_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00712_A125LeaveTypeName = new string[] {""} ;
         P00712_A127LeaveRequestId = new long[1] ;
         AV32Option = "";
         P00713_A124LeaveTypeId = new long[1] ;
         P00713_A132LeaveRequestStatus = new string[] {""} ;
         P00713_A133LeaveRequestDescription = new string[] {""} ;
         P00713_A100CompanyId = new long[1] ;
         P00713_A106EmployeeId = new long[1] ;
         P00713_A148EmployeeName = new string[] {""} ;
         P00713_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00713_A131LeaveRequestDuration = new decimal[1] ;
         P00713_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00713_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00713_A125LeaveTypeName = new string[] {""} ;
         P00713_A127LeaveRequestId = new long[1] ;
         P00714_A124LeaveTypeId = new long[1] ;
         P00714_A132LeaveRequestStatus = new string[] {""} ;
         P00714_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00714_A100CompanyId = new long[1] ;
         P00714_A106EmployeeId = new long[1] ;
         P00714_A148EmployeeName = new string[] {""} ;
         P00714_A133LeaveRequestDescription = new string[] {""} ;
         P00714_A131LeaveRequestDuration = new decimal[1] ;
         P00714_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00714_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00714_A125LeaveTypeName = new string[] {""} ;
         P00714_A127LeaveRequestId = new long[1] ;
         P00715_A124LeaveTypeId = new long[1] ;
         P00715_A132LeaveRequestStatus = new string[] {""} ;
         P00715_A148EmployeeName = new string[] {""} ;
         P00715_A100CompanyId = new long[1] ;
         P00715_A106EmployeeId = new long[1] ;
         P00715_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00715_A133LeaveRequestDescription = new string[] {""} ;
         P00715_A131LeaveRequestDuration = new decimal[1] ;
         P00715_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00715_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00715_A125LeaveTypeName = new string[] {""} ;
         P00715_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestrejectedgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00712_A124LeaveTypeId, P00712_A100CompanyId, P00712_A106EmployeeId, P00712_A132LeaveRequestStatus, P00712_A148EmployeeName, P00712_A134LeaveRequestRejectionReason, P00712_A133LeaveRequestDescription, P00712_A131LeaveRequestDuration, P00712_A130LeaveRequestEndDate, P00712_A129LeaveRequestStartDate,
               P00712_A125LeaveTypeName, P00712_A127LeaveRequestId
               }
               , new Object[] {
               P00713_A124LeaveTypeId, P00713_A132LeaveRequestStatus, P00713_A133LeaveRequestDescription, P00713_A100CompanyId, P00713_A106EmployeeId, P00713_A148EmployeeName, P00713_A134LeaveRequestRejectionReason, P00713_A131LeaveRequestDuration, P00713_A130LeaveRequestEndDate, P00713_A129LeaveRequestStartDate,
               P00713_A125LeaveTypeName, P00713_A127LeaveRequestId
               }
               , new Object[] {
               P00714_A124LeaveTypeId, P00714_A132LeaveRequestStatus, P00714_A134LeaveRequestRejectionReason, P00714_A100CompanyId, P00714_A106EmployeeId, P00714_A148EmployeeName, P00714_A133LeaveRequestDescription, P00714_A131LeaveRequestDuration, P00714_A130LeaveRequestEndDate, P00714_A129LeaveRequestStartDate,
               P00714_A125LeaveTypeName, P00714_A127LeaveRequestId
               }
               , new Object[] {
               P00715_A124LeaveTypeId, P00715_A132LeaveRequestStatus, P00715_A148EmployeeName, P00715_A100CompanyId, P00715_A106EmployeeId, P00715_A134LeaveRequestRejectionReason, P00715_A133LeaveRequestDescription, P00715_A131LeaveRequestDuration, P00715_A130LeaveRequestEndDate, P00715_A129LeaveRequestStartDate,
               P00715_A125LeaveTypeName, P00715_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private int AV51GXV1 ;
      private int AV31InsertIndex ;
      private long AV68Udparg16 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV37count ;
      private decimal AV21TFLeaveRequestDuration ;
      private decimal AV22TFLeaveRequestDuration_To ;
      private decimal AV60Leaverequestrejectedds_8_tfleaverequestduration ;
      private decimal AV61Leaverequestrejectedds_9_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV13TFLeaveTypeName ;
      private string AV14TFLeaveTypeName_Sel ;
      private string AV11TFEmployeeName ;
      private string AV12TFEmployeeName_Sel ;
      private string AV54Leaverequestrejectedds_2_tfleavetypename ;
      private string AV55Leaverequestrejectedds_3_tfleavetypename_sel ;
      private string AV66Leaverequestrejectedds_14_tfemployeename ;
      private string AV67Leaverequestrejectedds_15_tfemployeename_sel ;
      private string scmdbuf ;
      private string lV54Leaverequestrejectedds_2_tfleavetypename ;
      private string lV66Leaverequestrejectedds_14_tfemployeename ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string A132LeaveRequestStatus ;
      private DateTime AV17TFLeaveRequestStartDate ;
      private DateTime AV18TFLeaveRequestStartDate_To ;
      private DateTime AV19TFLeaveRequestEndDate ;
      private DateTime AV20TFLeaveRequestEndDate_To ;
      private DateTime AV56Leaverequestrejectedds_4_tfleaverequeststartdate ;
      private DateTime AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ;
      private DateTime AV58Leaverequestrejectedds_6_tfleaverequestenddate ;
      private DateTime AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK712 ;
      private bool BRK714 ;
      private bool BRK716 ;
      private bool BRK718 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV49FilterFullText ;
      private string AV23TFLeaveRequestDescription ;
      private string AV24TFLeaveRequestDescription_Sel ;
      private string AV25TFLeaveRequestRejectionReason ;
      private string AV26TFLeaveRequestRejectionReason_Sel ;
      private string AV53Leaverequestrejectedds_1_filterfulltext ;
      private string AV62Leaverequestrejectedds_10_tfleaverequestdescription ;
      private string AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ;
      private string AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ;
      private string AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ;
      private string lV53Leaverequestrejectedds_1_filterfulltext ;
      private string lV62Leaverequestrejectedds_10_tfleaverequestdescription ;
      private string lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string AV32Option ;
      private GxSimpleCollection<long> AV50EmployeeIds ;
      private IGxSession AV38Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00712_A124LeaveTypeId ;
      private long[] P00712_A100CompanyId ;
      private long[] P00712_A106EmployeeId ;
      private string[] P00712_A132LeaveRequestStatus ;
      private string[] P00712_A148EmployeeName ;
      private string[] P00712_A134LeaveRequestRejectionReason ;
      private string[] P00712_A133LeaveRequestDescription ;
      private decimal[] P00712_A131LeaveRequestDuration ;
      private DateTime[] P00712_A130LeaveRequestEndDate ;
      private DateTime[] P00712_A129LeaveRequestStartDate ;
      private string[] P00712_A125LeaveTypeName ;
      private long[] P00712_A127LeaveRequestId ;
      private long[] P00713_A124LeaveTypeId ;
      private string[] P00713_A132LeaveRequestStatus ;
      private string[] P00713_A133LeaveRequestDescription ;
      private long[] P00713_A100CompanyId ;
      private long[] P00713_A106EmployeeId ;
      private string[] P00713_A148EmployeeName ;
      private string[] P00713_A134LeaveRequestRejectionReason ;
      private decimal[] P00713_A131LeaveRequestDuration ;
      private DateTime[] P00713_A130LeaveRequestEndDate ;
      private DateTime[] P00713_A129LeaveRequestStartDate ;
      private string[] P00713_A125LeaveTypeName ;
      private long[] P00713_A127LeaveRequestId ;
      private long[] P00714_A124LeaveTypeId ;
      private string[] P00714_A132LeaveRequestStatus ;
      private string[] P00714_A134LeaveRequestRejectionReason ;
      private long[] P00714_A100CompanyId ;
      private long[] P00714_A106EmployeeId ;
      private string[] P00714_A148EmployeeName ;
      private string[] P00714_A133LeaveRequestDescription ;
      private decimal[] P00714_A131LeaveRequestDuration ;
      private DateTime[] P00714_A130LeaveRequestEndDate ;
      private DateTime[] P00714_A129LeaveRequestStartDate ;
      private string[] P00714_A125LeaveTypeName ;
      private long[] P00714_A127LeaveRequestId ;
      private long[] P00715_A124LeaveTypeId ;
      private string[] P00715_A132LeaveRequestStatus ;
      private string[] P00715_A148EmployeeName ;
      private long[] P00715_A100CompanyId ;
      private long[] P00715_A106EmployeeId ;
      private string[] P00715_A134LeaveRequestRejectionReason ;
      private string[] P00715_A133LeaveRequestDescription ;
      private decimal[] P00715_A131LeaveRequestDuration ;
      private DateTime[] P00715_A130LeaveRequestEndDate ;
      private DateTime[] P00715_A129LeaveRequestStartDate ;
      private string[] P00715_A125LeaveTypeName ;
      private long[] P00715_A127LeaveRequestId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
   }

   public class leaverequestrejectedgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00712( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV53Leaverequestrejectedds_1_filterfulltext ,
                                             string AV55Leaverequestrejectedds_3_tfleavetypename_sel ,
                                             string AV54Leaverequestrejectedds_2_tfleavetypename ,
                                             DateTime AV56Leaverequestrejectedds_4_tfleaverequeststartdate ,
                                             DateTime AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ,
                                             DateTime AV58Leaverequestrejectedds_6_tfleaverequestenddate ,
                                             DateTime AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ,
                                             decimal AV60Leaverequestrejectedds_8_tfleaverequestduration ,
                                             decimal AV61Leaverequestrejectedds_9_tfleaverequestduration_to ,
                                             string AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ,
                                             string AV62Leaverequestrejectedds_10_tfleaverequestdescription ,
                                             string AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ,
                                             string AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ,
                                             string AV67Leaverequestrejectedds_15_tfemployeename_sel ,
                                             string AV66Leaverequestrejectedds_14_tfemployeename ,
                                             string A125LeaveTypeName ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             string A148EmployeeName ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV68Udparg16 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T1.EmployeeId, T1.LeaveRequestStatus, T3.EmployeeName, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV53Leaverequestrejectedds_1_filterfulltext) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( LOWER(T3.EmployeeName) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestrejectedds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestrejectedds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV54Leaverequestrejectedds_2_tfleavetypename))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestrejectedds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV55Leaverequestrejectedds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV55Leaverequestrejectedds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Leaverequestrejectedds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestrejectedds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV56Leaverequestrejectedds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestrejectedds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV58Leaverequestrejectedds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Leaverequestrejectedds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV59Leaverequestrejectedds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV60Leaverequestrejectedds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV60Leaverequestrejectedds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Leaverequestrejectedds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV61Leaverequestrejectedds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_10_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV62Leaverequestrejectedds_10_tfleaverequestdescription))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_15_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestrejectedds_14_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV66Leaverequestrejectedds_14_tfemployeename))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_15_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestrejectedds_15_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV67Leaverequestrejectedds_15_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestrejectedds_15_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV68Udparg16)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00713( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV53Leaverequestrejectedds_1_filterfulltext ,
                                             string AV55Leaverequestrejectedds_3_tfleavetypename_sel ,
                                             string AV54Leaverequestrejectedds_2_tfleavetypename ,
                                             DateTime AV56Leaverequestrejectedds_4_tfleaverequeststartdate ,
                                             DateTime AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ,
                                             DateTime AV58Leaverequestrejectedds_6_tfleaverequestenddate ,
                                             DateTime AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ,
                                             decimal AV60Leaverequestrejectedds_8_tfleaverequestduration ,
                                             decimal AV61Leaverequestrejectedds_9_tfleaverequestduration_to ,
                                             string AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ,
                                             string AV62Leaverequestrejectedds_10_tfleaverequestdescription ,
                                             string AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ,
                                             string AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ,
                                             string AV67Leaverequestrejectedds_15_tfemployeename_sel ,
                                             string AV66Leaverequestrejectedds_14_tfemployeename ,
                                             string A125LeaveTypeName ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             string A148EmployeeName ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV68Udparg16 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.LeaveRequestDescription, T2.CompanyId, T1.EmployeeId, T3.EmployeeName, T1.LeaveRequestRejectionReason, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV53Leaverequestrejectedds_1_filterfulltext) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( LOWER(T3.EmployeeName) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestrejectedds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestrejectedds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV54Leaverequestrejectedds_2_tfleavetypename))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestrejectedds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV55Leaverequestrejectedds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV55Leaverequestrejectedds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Leaverequestrejectedds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestrejectedds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV56Leaverequestrejectedds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestrejectedds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV58Leaverequestrejectedds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Leaverequestrejectedds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV59Leaverequestrejectedds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV60Leaverequestrejectedds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV60Leaverequestrejectedds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Leaverequestrejectedds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV61Leaverequestrejectedds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_10_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV62Leaverequestrejectedds_10_tfleaverequestdescription))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_15_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestrejectedds_14_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV66Leaverequestrejectedds_14_tfemployeename))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_15_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestrejectedds_15_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV67Leaverequestrejectedds_15_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestrejectedds_15_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV68Udparg16)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00714( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV53Leaverequestrejectedds_1_filterfulltext ,
                                             string AV55Leaverequestrejectedds_3_tfleavetypename_sel ,
                                             string AV54Leaverequestrejectedds_2_tfleavetypename ,
                                             DateTime AV56Leaverequestrejectedds_4_tfleaverequeststartdate ,
                                             DateTime AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ,
                                             DateTime AV58Leaverequestrejectedds_6_tfleaverequestenddate ,
                                             DateTime AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ,
                                             decimal AV60Leaverequestrejectedds_8_tfleaverequestduration ,
                                             decimal AV61Leaverequestrejectedds_9_tfleaverequestduration_to ,
                                             string AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ,
                                             string AV62Leaverequestrejectedds_10_tfleaverequestdescription ,
                                             string AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ,
                                             string AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ,
                                             string AV67Leaverequestrejectedds_15_tfemployeename_sel ,
                                             string AV66Leaverequestrejectedds_14_tfemployeename ,
                                             string A125LeaveTypeName ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             string A148EmployeeName ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV68Udparg16 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.LeaveRequestRejectionReason, T2.CompanyId, T1.EmployeeId, T3.EmployeeName, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV53Leaverequestrejectedds_1_filterfulltext) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( LOWER(T3.EmployeeName) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestrejectedds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestrejectedds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV54Leaverequestrejectedds_2_tfleavetypename))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestrejectedds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV55Leaverequestrejectedds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV55Leaverequestrejectedds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Leaverequestrejectedds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestrejectedds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV56Leaverequestrejectedds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestrejectedds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV58Leaverequestrejectedds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Leaverequestrejectedds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV59Leaverequestrejectedds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV60Leaverequestrejectedds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV60Leaverequestrejectedds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Leaverequestrejectedds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV61Leaverequestrejectedds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_10_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV62Leaverequestrejectedds_10_tfleaverequestdescription))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_15_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestrejectedds_14_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV66Leaverequestrejectedds_14_tfemployeename))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_15_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestrejectedds_15_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV67Leaverequestrejectedds_15_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestrejectedds_15_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV68Udparg16)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestRejectionReason";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00715( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV53Leaverequestrejectedds_1_filterfulltext ,
                                             string AV55Leaverequestrejectedds_3_tfleavetypename_sel ,
                                             string AV54Leaverequestrejectedds_2_tfleavetypename ,
                                             DateTime AV56Leaverequestrejectedds_4_tfleaverequeststartdate ,
                                             DateTime AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to ,
                                             DateTime AV58Leaverequestrejectedds_6_tfleaverequestenddate ,
                                             DateTime AV59Leaverequestrejectedds_7_tfleaverequestenddate_to ,
                                             decimal AV60Leaverequestrejectedds_8_tfleaverequestduration ,
                                             decimal AV61Leaverequestrejectedds_9_tfleaverequestduration_to ,
                                             string AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel ,
                                             string AV62Leaverequestrejectedds_10_tfleaverequestdescription ,
                                             string AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel ,
                                             string AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason ,
                                             string AV67Leaverequestrejectedds_15_tfemployeename_sel ,
                                             string AV66Leaverequestrejectedds_14_tfemployeename ,
                                             string A125LeaveTypeName ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             string A148EmployeeName ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV68Udparg16 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[20];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T3.EmployeeName, T2.CompanyId, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leaverequestrejectedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV53Leaverequestrejectedds_1_filterfulltext) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)) or ( LOWER(T3.EmployeeName) like '%' || LOWER(:lV53Leaverequestrejectedds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestrejectedds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestrejectedds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV54Leaverequestrejectedds_2_tfleavetypename))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestrejectedds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV55Leaverequestrejectedds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV55Leaverequestrejectedds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Leaverequestrejectedds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV56Leaverequestrejectedds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV56Leaverequestrejectedds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestrejectedds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV58Leaverequestrejectedds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Leaverequestrejectedds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV59Leaverequestrejectedds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV60Leaverequestrejectedds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV60Leaverequestrejectedds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Leaverequestrejectedds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV61Leaverequestrejectedds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_10_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV62Leaverequestrejectedds_10_tfleaverequestdescription))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestrejectedds_12_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_15_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestrejectedds_14_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV66Leaverequestrejectedds_14_tfemployeename))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_15_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestrejectedds_15_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV67Leaverequestrejectedds_15_tfemployeename_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestrejectedds_15_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV68Udparg16)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.EmployeeName";
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
                     return conditional_P00712(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P00713(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] );
               case 2 :
                     return conditional_P00714(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] );
               case 3 :
                     return conditional_P00715(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP00712;
          prmP00712 = new Object[] {
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Leaverequestrejectedds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestrejectedds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV56Leaverequestrejectedds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestrejectedds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestrejectedds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV60Leaverequestrejectedds_8_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV61Leaverequestrejectedds_9_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV62Leaverequestrejectedds_10_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("lV66Leaverequestrejectedds_14_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV67Leaverequestrejectedds_15_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("AV68Udparg16",GXType.Int64,10,0)
          };
          Object[] prmP00713;
          prmP00713 = new Object[] {
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Leaverequestrejectedds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestrejectedds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV56Leaverequestrejectedds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestrejectedds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestrejectedds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV60Leaverequestrejectedds_8_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV61Leaverequestrejectedds_9_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV62Leaverequestrejectedds_10_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("lV66Leaverequestrejectedds_14_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV67Leaverequestrejectedds_15_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("AV68Udparg16",GXType.Int64,10,0)
          };
          Object[] prmP00714;
          prmP00714 = new Object[] {
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Leaverequestrejectedds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestrejectedds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV56Leaverequestrejectedds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestrejectedds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestrejectedds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV60Leaverequestrejectedds_8_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV61Leaverequestrejectedds_9_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV62Leaverequestrejectedds_10_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("lV66Leaverequestrejectedds_14_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV67Leaverequestrejectedds_15_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("AV68Udparg16",GXType.Int64,10,0)
          };
          Object[] prmP00715;
          prmP00715 = new Object[] {
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Leaverequestrejectedds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV55Leaverequestrejectedds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV56Leaverequestrejectedds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV57Leaverequestrejectedds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestrejectedds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestrejectedds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV60Leaverequestrejectedds_8_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV61Leaverequestrejectedds_9_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV62Leaverequestrejectedds_10_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Leaverequestrejectedds_11_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Leaverequestrejectedds_12_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV65Leaverequestrejectedds_13_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("lV66Leaverequestrejectedds_14_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV67Leaverequestrejectedds_15_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("AV68Udparg16",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00713", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00713,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00714", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00714,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00715", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00715,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 128);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 128);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 128);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
