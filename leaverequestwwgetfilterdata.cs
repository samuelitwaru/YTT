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
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LEAVEREQUESTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LEAVEREQUESTREJECTIONREASON") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTREJECTIONREASONOPTIONS' */
            S141 ();
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
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV55FilterFullText = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTID") == 0 )
            {
               AV11TFLeaveRequestId = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFLeaveRequestId_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVETYPEID") == 0 )
            {
               AV13TFLeaveTypeId = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFLeaveTypeId_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV15TFLeaveTypeName = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV16TFLeaveTypeName_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDATE") == 0 )
            {
               AV17TFLeaveRequestDate = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Value, 1);
               AV18TFLeaveRequestDate_To = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Valueto, 1);
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
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV23TFLeaveRequestDuration = (short)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV24TFLeaveRequestDuration_To = (short)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
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
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEID") == 0 )
            {
               AV31TFEmployeeId = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV32TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFLeaveTypeName = AV33SearchTxt;
         AV16TFLeaveTypeName_Sel = "";
         AV58Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV59Leaverequestwwds_2_tfleaverequestid = AV11TFLeaveRequestId;
         AV60Leaverequestwwds_3_tfleaverequestid_to = AV12TFLeaveRequestId_To;
         AV61Leaverequestwwds_4_tfleavetypeid = AV13TFLeaveTypeId;
         AV62Leaverequestwwds_5_tfleavetypeid_to = AV14TFLeaveTypeId_To;
         AV63Leaverequestwwds_6_tfleavetypename = AV15TFLeaveTypeName;
         AV64Leaverequestwwds_7_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV65Leaverequestwwds_8_tfleaverequestdate = AV17TFLeaveRequestDate;
         AV66Leaverequestwwds_9_tfleaverequestdate_to = AV18TFLeaveRequestDate_To;
         AV67Leaverequestwwds_10_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV68Leaverequestwwds_11_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV69Leaverequestwwds_12_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV70Leaverequestwwds_13_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV71Leaverequestwwds_14_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV72Leaverequestwwds_15_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV73Leaverequestwwds_16_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV74Leaverequestwwds_17_tfleaverequestdescription = AV27TFLeaveRequestDescription;
         AV75Leaverequestwwds_18_tfleaverequestdescription_sel = AV28TFLeaveRequestDescription_Sel;
         AV76Leaverequestwwds_19_tfleaverequestrejectionreason = AV29TFLeaveRequestRejectionReason;
         AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV30TFLeaveRequestRejectionReason_Sel;
         AV78Leaverequestwwds_21_tfemployeeid = AV31TFEmployeeId;
         AV79Leaverequestwwds_22_tfemployeeid_to = AV32TFEmployeeId_To;
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV80Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV73Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                              AV58Leaverequestwwds_1_filterfulltext ,
                                              AV59Leaverequestwwds_2_tfleaverequestid ,
                                              AV60Leaverequestwwds_3_tfleaverequestid_to ,
                                              AV61Leaverequestwwds_4_tfleavetypeid ,
                                              AV62Leaverequestwwds_5_tfleavetypeid_to ,
                                              AV64Leaverequestwwds_7_tfleavetypename_sel ,
                                              AV63Leaverequestwwds_6_tfleavetypename ,
                                              AV65Leaverequestwwds_8_tfleaverequestdate ,
                                              AV66Leaverequestwwds_9_tfleaverequestdate_to ,
                                              AV67Leaverequestwwds_10_tfleaverequeststartdate ,
                                              AV68Leaverequestwwds_11_tfleaverequeststartdate_to ,
                                              AV69Leaverequestwwds_12_tfleaverequestenddate ,
                                              AV70Leaverequestwwds_13_tfleaverequestenddate_to ,
                                              AV71Leaverequestwwds_14_tfleaverequestduration ,
                                              AV72Leaverequestwwds_15_tfleaverequestduration_to ,
                                              AV73Leaverequestwwds_16_tfleaverequeststatus_sels.Count ,
                                              AV75Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                              AV74Leaverequestwwds_17_tfleaverequestdescription ,
                                              AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                              AV76Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                              AV78Leaverequestwwds_21_tfemployeeid ,
                                              AV79Leaverequestwwds_22_tfemployeeid_to ,
                                              A127LeaveRequestId ,
                                              A124LeaveTypeId ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A106EmployeeId ,
                                              A128LeaveRequestDate ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV80Udparg23 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_6_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV63Leaverequestwwds_6_tfleavetypename), 100, "%");
         lV74Leaverequestwwds_17_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestwwds_17_tfleaverequestdescription), "%", "");
         lV76Leaverequestwwds_19_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV76Leaverequestwwds_19_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008C2 */
         pr_default.execute(0, new Object[] {AV80Udparg23, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, AV59Leaverequestwwds_2_tfleaverequestid, AV60Leaverequestwwds_3_tfleaverequestid_to, AV61Leaverequestwwds_4_tfleavetypeid, AV62Leaverequestwwds_5_tfleavetypeid_to, lV63Leaverequestwwds_6_tfleavetypename, AV64Leaverequestwwds_7_tfleavetypename_sel, AV65Leaverequestwwds_8_tfleaverequestdate, AV66Leaverequestwwds_9_tfleaverequestdate_to, AV67Leaverequestwwds_10_tfleaverequeststartdate, AV68Leaverequestwwds_11_tfleaverequeststartdate_to, AV69Leaverequestwwds_12_tfleaverequestenddate, AV70Leaverequestwwds_13_tfleaverequestenddate_to, AV71Leaverequestwwds_14_tfleaverequestduration, AV72Leaverequestwwds_15_tfleaverequestduration_to, lV74Leaverequestwwds_17_tfleaverequestdescription, AV75Leaverequestwwds_18_tfleaverequestdescription_sel, lV76Leaverequestwwds_19_tfleaverequestrejectionreason, AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, AV78Leaverequestwwds_21_tfemployeeid, AV79Leaverequestwwds_22_tfemployeeid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8C2 = false;
            A124LeaveTypeId = P008C2_A124LeaveTypeId[0];
            A100CompanyId = P008C2_A100CompanyId[0];
            A106EmployeeId = P008C2_A106EmployeeId[0];
            A134LeaveRequestRejectionReason = P008C2_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P008C2_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008C2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008C2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C2_A129LeaveRequestStartDate[0];
            A128LeaveRequestDate = P008C2_A128LeaveRequestDate[0];
            A125LeaveTypeName = P008C2_A125LeaveTypeName[0];
            A127LeaveRequestId = P008C2_A127LeaveRequestId[0];
            A132LeaveRequestStatus = P008C2_A132LeaveRequestStatus[0];
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
         /* 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV27TFLeaveRequestDescription = AV33SearchTxt;
         AV28TFLeaveRequestDescription_Sel = "";
         AV58Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV59Leaverequestwwds_2_tfleaverequestid = AV11TFLeaveRequestId;
         AV60Leaverequestwwds_3_tfleaverequestid_to = AV12TFLeaveRequestId_To;
         AV61Leaverequestwwds_4_tfleavetypeid = AV13TFLeaveTypeId;
         AV62Leaverequestwwds_5_tfleavetypeid_to = AV14TFLeaveTypeId_To;
         AV63Leaverequestwwds_6_tfleavetypename = AV15TFLeaveTypeName;
         AV64Leaverequestwwds_7_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV65Leaverequestwwds_8_tfleaverequestdate = AV17TFLeaveRequestDate;
         AV66Leaverequestwwds_9_tfleaverequestdate_to = AV18TFLeaveRequestDate_To;
         AV67Leaverequestwwds_10_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV68Leaverequestwwds_11_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV69Leaverequestwwds_12_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV70Leaverequestwwds_13_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV71Leaverequestwwds_14_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV72Leaverequestwwds_15_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV73Leaverequestwwds_16_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV74Leaverequestwwds_17_tfleaverequestdescription = AV27TFLeaveRequestDescription;
         AV75Leaverequestwwds_18_tfleaverequestdescription_sel = AV28TFLeaveRequestDescription_Sel;
         AV76Leaverequestwwds_19_tfleaverequestrejectionreason = AV29TFLeaveRequestRejectionReason;
         AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV30TFLeaveRequestRejectionReason_Sel;
         AV78Leaverequestwwds_21_tfemployeeid = AV31TFEmployeeId;
         AV79Leaverequestwwds_22_tfemployeeid_to = AV32TFEmployeeId_To;
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV83Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV73Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                              AV58Leaverequestwwds_1_filterfulltext ,
                                              AV59Leaverequestwwds_2_tfleaverequestid ,
                                              AV60Leaverequestwwds_3_tfleaverequestid_to ,
                                              AV61Leaverequestwwds_4_tfleavetypeid ,
                                              AV62Leaverequestwwds_5_tfleavetypeid_to ,
                                              AV64Leaverequestwwds_7_tfleavetypename_sel ,
                                              AV63Leaverequestwwds_6_tfleavetypename ,
                                              AV65Leaverequestwwds_8_tfleaverequestdate ,
                                              AV66Leaverequestwwds_9_tfleaverequestdate_to ,
                                              AV67Leaverequestwwds_10_tfleaverequeststartdate ,
                                              AV68Leaverequestwwds_11_tfleaverequeststartdate_to ,
                                              AV69Leaverequestwwds_12_tfleaverequestenddate ,
                                              AV70Leaverequestwwds_13_tfleaverequestenddate_to ,
                                              AV71Leaverequestwwds_14_tfleaverequestduration ,
                                              AV72Leaverequestwwds_15_tfleaverequestduration_to ,
                                              AV73Leaverequestwwds_16_tfleaverequeststatus_sels.Count ,
                                              AV75Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                              AV74Leaverequestwwds_17_tfleaverequestdescription ,
                                              AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                              AV76Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                              AV78Leaverequestwwds_21_tfemployeeid ,
                                              AV79Leaverequestwwds_22_tfemployeeid_to ,
                                              A127LeaveRequestId ,
                                              A124LeaveTypeId ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A106EmployeeId ,
                                              A128LeaveRequestDate ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV83Udparg24 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_6_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV63Leaverequestwwds_6_tfleavetypename), 100, "%");
         lV74Leaverequestwwds_17_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestwwds_17_tfleaverequestdescription), "%", "");
         lV76Leaverequestwwds_19_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV76Leaverequestwwds_19_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008C3 */
         pr_default.execute(1, new Object[] {AV83Udparg24, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, AV59Leaverequestwwds_2_tfleaverequestid, AV60Leaverequestwwds_3_tfleaverequestid_to, AV61Leaverequestwwds_4_tfleavetypeid, AV62Leaverequestwwds_5_tfleavetypeid_to, lV63Leaverequestwwds_6_tfleavetypename, AV64Leaverequestwwds_7_tfleavetypename_sel, AV65Leaverequestwwds_8_tfleaverequestdate, AV66Leaverequestwwds_9_tfleaverequestdate_to, AV67Leaverequestwwds_10_tfleaverequeststartdate, AV68Leaverequestwwds_11_tfleaverequeststartdate_to, AV69Leaverequestwwds_12_tfleaverequestenddate, AV70Leaverequestwwds_13_tfleaverequestenddate_to, AV71Leaverequestwwds_14_tfleaverequestduration, AV72Leaverequestwwds_15_tfleaverequestduration_to, lV74Leaverequestwwds_17_tfleaverequestdescription, AV75Leaverequestwwds_18_tfleaverequestdescription_sel, lV76Leaverequestwwds_19_tfleaverequestrejectionreason, AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, AV78Leaverequestwwds_21_tfemployeeid, AV79Leaverequestwwds_22_tfemployeeid_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8C4 = false;
            A100CompanyId = P008C3_A100CompanyId[0];
            A133LeaveRequestDescription = P008C3_A133LeaveRequestDescription[0];
            A106EmployeeId = P008C3_A106EmployeeId[0];
            A134LeaveRequestRejectionReason = P008C3_A134LeaveRequestRejectionReason[0];
            A131LeaveRequestDuration = P008C3_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008C3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C3_A129LeaveRequestStartDate[0];
            A128LeaveRequestDate = P008C3_A128LeaveRequestDate[0];
            A125LeaveTypeName = P008C3_A125LeaveTypeName[0];
            A124LeaveTypeId = P008C3_A124LeaveTypeId[0];
            A127LeaveRequestId = P008C3_A127LeaveRequestId[0];
            A132LeaveRequestStatus = P008C3_A132LeaveRequestStatus[0];
            A100CompanyId = P008C3_A100CompanyId[0];
            A125LeaveTypeName = P008C3_A125LeaveTypeName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008C3_A133LeaveRequestDescription[0], A133LeaveRequestDescription) == 0 ) )
            {
               BRK8C4 = false;
               A127LeaveRequestId = P008C3_A127LeaveRequestId[0];
               AV43count = (long)(AV43count+1);
               BRK8C4 = true;
               pr_default.readNext(1);
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
         /* 'LOADLEAVEREQUESTREJECTIONREASONOPTIONS' Routine */
         returnInSub = false;
         AV29TFLeaveRequestRejectionReason = AV33SearchTxt;
         AV30TFLeaveRequestRejectionReason_Sel = "";
         AV58Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV59Leaverequestwwds_2_tfleaverequestid = AV11TFLeaveRequestId;
         AV60Leaverequestwwds_3_tfleaverequestid_to = AV12TFLeaveRequestId_To;
         AV61Leaverequestwwds_4_tfleavetypeid = AV13TFLeaveTypeId;
         AV62Leaverequestwwds_5_tfleavetypeid_to = AV14TFLeaveTypeId_To;
         AV63Leaverequestwwds_6_tfleavetypename = AV15TFLeaveTypeName;
         AV64Leaverequestwwds_7_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV65Leaverequestwwds_8_tfleaverequestdate = AV17TFLeaveRequestDate;
         AV66Leaverequestwwds_9_tfleaverequestdate_to = AV18TFLeaveRequestDate_To;
         AV67Leaverequestwwds_10_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV68Leaverequestwwds_11_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV69Leaverequestwwds_12_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV70Leaverequestwwds_13_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV71Leaverequestwwds_14_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV72Leaverequestwwds_15_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV73Leaverequestwwds_16_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV74Leaverequestwwds_17_tfleaverequestdescription = AV27TFLeaveRequestDescription;
         AV75Leaverequestwwds_18_tfleaverequestdescription_sel = AV28TFLeaveRequestDescription_Sel;
         AV76Leaverequestwwds_19_tfleaverequestrejectionreason = AV29TFLeaveRequestRejectionReason;
         AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV30TFLeaveRequestRejectionReason_Sel;
         AV78Leaverequestwwds_21_tfemployeeid = AV31TFEmployeeId;
         AV79Leaverequestwwds_22_tfemployeeid_to = AV32TFEmployeeId_To;
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV73Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                              AV58Leaverequestwwds_1_filterfulltext ,
                                              AV59Leaverequestwwds_2_tfleaverequestid ,
                                              AV60Leaverequestwwds_3_tfleaverequestid_to ,
                                              AV61Leaverequestwwds_4_tfleavetypeid ,
                                              AV62Leaverequestwwds_5_tfleavetypeid_to ,
                                              AV64Leaverequestwwds_7_tfleavetypename_sel ,
                                              AV63Leaverequestwwds_6_tfleavetypename ,
                                              AV65Leaverequestwwds_8_tfleaverequestdate ,
                                              AV66Leaverequestwwds_9_tfleaverequestdate_to ,
                                              AV67Leaverequestwwds_10_tfleaverequeststartdate ,
                                              AV68Leaverequestwwds_11_tfleaverequeststartdate_to ,
                                              AV69Leaverequestwwds_12_tfleaverequestenddate ,
                                              AV70Leaverequestwwds_13_tfleaverequestenddate_to ,
                                              AV71Leaverequestwwds_14_tfleaverequestduration ,
                                              AV72Leaverequestwwds_15_tfleaverequestduration_to ,
                                              AV73Leaverequestwwds_16_tfleaverequeststatus_sels.Count ,
                                              AV75Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                              AV74Leaverequestwwds_17_tfleaverequestdescription ,
                                              AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                              AV76Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                              AV78Leaverequestwwds_21_tfemployeeid ,
                                              AV79Leaverequestwwds_22_tfemployeeid_to ,
                                              A127LeaveRequestId ,
                                              A124LeaveTypeId ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A106EmployeeId ,
                                              A128LeaveRequestDate ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV86Udparg25 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV58Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext), "%", "");
         lV63Leaverequestwwds_6_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV63Leaverequestwwds_6_tfleavetypename), 100, "%");
         lV74Leaverequestwwds_17_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestwwds_17_tfleaverequestdescription), "%", "");
         lV76Leaverequestwwds_19_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV76Leaverequestwwds_19_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008C4 */
         pr_default.execute(2, new Object[] {AV86Udparg25, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, lV58Leaverequestwwds_1_filterfulltext, AV59Leaverequestwwds_2_tfleaverequestid, AV60Leaverequestwwds_3_tfleaverequestid_to, AV61Leaverequestwwds_4_tfleavetypeid, AV62Leaverequestwwds_5_tfleavetypeid_to, lV63Leaverequestwwds_6_tfleavetypename, AV64Leaverequestwwds_7_tfleavetypename_sel, AV65Leaverequestwwds_8_tfleaverequestdate, AV66Leaverequestwwds_9_tfleaverequestdate_to, AV67Leaverequestwwds_10_tfleaverequeststartdate, AV68Leaverequestwwds_11_tfleaverequeststartdate_to, AV69Leaverequestwwds_12_tfleaverequestenddate, AV70Leaverequestwwds_13_tfleaverequestenddate_to, AV71Leaverequestwwds_14_tfleaverequestduration, AV72Leaverequestwwds_15_tfleaverequestduration_to, lV74Leaverequestwwds_17_tfleaverequestdescription, AV75Leaverequestwwds_18_tfleaverequestdescription_sel, lV76Leaverequestwwds_19_tfleaverequestrejectionreason, AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, AV78Leaverequestwwds_21_tfemployeeid, AV79Leaverequestwwds_22_tfemployeeid_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8C6 = false;
            A100CompanyId = P008C4_A100CompanyId[0];
            A134LeaveRequestRejectionReason = P008C4_A134LeaveRequestRejectionReason[0];
            A106EmployeeId = P008C4_A106EmployeeId[0];
            A133LeaveRequestDescription = P008C4_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008C4_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008C4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C4_A129LeaveRequestStartDate[0];
            A128LeaveRequestDate = P008C4_A128LeaveRequestDate[0];
            A125LeaveTypeName = P008C4_A125LeaveTypeName[0];
            A124LeaveTypeId = P008C4_A124LeaveTypeId[0];
            A127LeaveRequestId = P008C4_A127LeaveRequestId[0];
            A132LeaveRequestStatus = P008C4_A132LeaveRequestStatus[0];
            A100CompanyId = P008C4_A100CompanyId[0];
            A125LeaveTypeName = P008C4_A125LeaveTypeName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008C4_A134LeaveRequestRejectionReason[0], A134LeaveRequestRejectionReason) == 0 ) )
            {
               BRK8C6 = false;
               A127LeaveRequestId = P008C4_A127LeaveRequestId[0];
               AV43count = (long)(AV43count+1);
               BRK8C6 = true;
               pr_default.readNext(2);
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
            if ( ! BRK8C6 )
            {
               BRK8C6 = true;
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
         AV17TFLeaveRequestDate = DateTime.MinValue;
         AV18TFLeaveRequestDate_To = DateTime.MinValue;
         AV19TFLeaveRequestStartDate = DateTime.MinValue;
         AV20TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV21TFLeaveRequestEndDate = DateTime.MinValue;
         AV22TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV25TFLeaveRequestStatus_SelsJson = "";
         AV26TFLeaveRequestStatus_Sels = new GxSimpleCollection<string>();
         AV27TFLeaveRequestDescription = "";
         AV28TFLeaveRequestDescription_Sel = "";
         AV29TFLeaveRequestRejectionReason = "";
         AV30TFLeaveRequestRejectionReason_Sel = "";
         AV58Leaverequestwwds_1_filterfulltext = "";
         AV63Leaverequestwwds_6_tfleavetypename = "";
         AV64Leaverequestwwds_7_tfleavetypename_sel = "";
         AV65Leaverequestwwds_8_tfleaverequestdate = DateTime.MinValue;
         AV66Leaverequestwwds_9_tfleaverequestdate_to = DateTime.MinValue;
         AV67Leaverequestwwds_10_tfleaverequeststartdate = DateTime.MinValue;
         AV68Leaverequestwwds_11_tfleaverequeststartdate_to = DateTime.MinValue;
         AV69Leaverequestwwds_12_tfleaverequestenddate = DateTime.MinValue;
         AV70Leaverequestwwds_13_tfleaverequestenddate_to = DateTime.MinValue;
         AV73Leaverequestwwds_16_tfleaverequeststatus_sels = new GxSimpleCollection<string>();
         AV74Leaverequestwwds_17_tfleaverequestdescription = "";
         AV75Leaverequestwwds_18_tfleaverequestdescription_sel = "";
         AV76Leaverequestwwds_19_tfleaverequestrejectionreason = "";
         AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel = "";
         scmdbuf = "";
         lV58Leaverequestwwds_1_filterfulltext = "";
         lV63Leaverequestwwds_6_tfleavetypename = "";
         lV74Leaverequestwwds_17_tfleaverequestdescription = "";
         lV76Leaverequestwwds_19_tfleaverequestrejectionreason = "";
         A132LeaveRequestStatus = "";
         A125LeaveTypeName = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P008C2_A124LeaveTypeId = new long[1] ;
         P008C2_A100CompanyId = new long[1] ;
         P008C2_A106EmployeeId = new long[1] ;
         P008C2_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008C2_A133LeaveRequestDescription = new string[] {""} ;
         P008C2_A131LeaveRequestDuration = new short[1] ;
         P008C2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P008C2_A125LeaveTypeName = new string[] {""} ;
         P008C2_A127LeaveRequestId = new long[1] ;
         P008C2_A132LeaveRequestStatus = new string[] {""} ;
         AV38Option = "";
         P008C3_A100CompanyId = new long[1] ;
         P008C3_A133LeaveRequestDescription = new string[] {""} ;
         P008C3_A106EmployeeId = new long[1] ;
         P008C3_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008C3_A131LeaveRequestDuration = new short[1] ;
         P008C3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C3_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P008C3_A125LeaveTypeName = new string[] {""} ;
         P008C3_A124LeaveTypeId = new long[1] ;
         P008C3_A127LeaveRequestId = new long[1] ;
         P008C3_A132LeaveRequestStatus = new string[] {""} ;
         P008C4_A100CompanyId = new long[1] ;
         P008C4_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008C4_A106EmployeeId = new long[1] ;
         P008C4_A133LeaveRequestDescription = new string[] {""} ;
         P008C4_A131LeaveRequestDuration = new short[1] ;
         P008C4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C4_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P008C4_A125LeaveTypeName = new string[] {""} ;
         P008C4_A124LeaveTypeId = new long[1] ;
         P008C4_A127LeaveRequestId = new long[1] ;
         P008C4_A132LeaveRequestStatus = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008C2_A124LeaveTypeId, P008C2_A100CompanyId, P008C2_A106EmployeeId, P008C2_A134LeaveRequestRejectionReason, P008C2_A133LeaveRequestDescription, P008C2_A131LeaveRequestDuration, P008C2_A130LeaveRequestEndDate, P008C2_A129LeaveRequestStartDate, P008C2_A128LeaveRequestDate, P008C2_A125LeaveTypeName,
               P008C2_A127LeaveRequestId, P008C2_A132LeaveRequestStatus
               }
               , new Object[] {
               P008C3_A100CompanyId, P008C3_A133LeaveRequestDescription, P008C3_A106EmployeeId, P008C3_A134LeaveRequestRejectionReason, P008C3_A131LeaveRequestDuration, P008C3_A130LeaveRequestEndDate, P008C3_A129LeaveRequestStartDate, P008C3_A128LeaveRequestDate, P008C3_A125LeaveTypeName, P008C3_A124LeaveTypeId,
               P008C3_A127LeaveRequestId, P008C3_A132LeaveRequestStatus
               }
               , new Object[] {
               P008C4_A100CompanyId, P008C4_A134LeaveRequestRejectionReason, P008C4_A106EmployeeId, P008C4_A133LeaveRequestDescription, P008C4_A131LeaveRequestDuration, P008C4_A130LeaveRequestEndDate, P008C4_A129LeaveRequestStartDate, P008C4_A128LeaveRequestDate, P008C4_A125LeaveTypeName, P008C4_A124LeaveTypeId,
               P008C4_A127LeaveRequestId, P008C4_A132LeaveRequestStatus
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short AV23TFLeaveRequestDuration ;
      private short AV24TFLeaveRequestDuration_To ;
      private short AV71Leaverequestwwds_14_tfleaverequestduration ;
      private short AV72Leaverequestwwds_15_tfleaverequestduration_to ;
      private short A131LeaveRequestDuration ;
      private int AV56GXV1 ;
      private int AV73Leaverequestwwds_16_tfleaverequeststatus_sels_Count ;
      private int AV37InsertIndex ;
      private long AV11TFLeaveRequestId ;
      private long AV12TFLeaveRequestId_To ;
      private long AV13TFLeaveTypeId ;
      private long AV14TFLeaveTypeId_To ;
      private long AV31TFEmployeeId ;
      private long AV32TFEmployeeId_To ;
      private long AV59Leaverequestwwds_2_tfleaverequestid ;
      private long AV60Leaverequestwwds_3_tfleaverequestid_to ;
      private long AV61Leaverequestwwds_4_tfleavetypeid ;
      private long AV62Leaverequestwwds_5_tfleavetypeid_to ;
      private long AV78Leaverequestwwds_21_tfemployeeid ;
      private long AV79Leaverequestwwds_22_tfemployeeid_to ;
      private long AV80Udparg23 ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long AV43count ;
      private long AV83Udparg24 ;
      private long AV86Udparg25 ;
      private string AV15TFLeaveTypeName ;
      private string AV16TFLeaveTypeName_Sel ;
      private string AV63Leaverequestwwds_6_tfleavetypename ;
      private string AV64Leaverequestwwds_7_tfleavetypename_sel ;
      private string scmdbuf ;
      private string lV63Leaverequestwwds_6_tfleavetypename ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private DateTime AV17TFLeaveRequestDate ;
      private DateTime AV18TFLeaveRequestDate_To ;
      private DateTime AV19TFLeaveRequestStartDate ;
      private DateTime AV20TFLeaveRequestStartDate_To ;
      private DateTime AV21TFLeaveRequestEndDate ;
      private DateTime AV22TFLeaveRequestEndDate_To ;
      private DateTime AV65Leaverequestwwds_8_tfleaverequestdate ;
      private DateTime AV66Leaverequestwwds_9_tfleaverequestdate_to ;
      private DateTime AV67Leaverequestwwds_10_tfleaverequeststartdate ;
      private DateTime AV68Leaverequestwwds_11_tfleaverequeststartdate_to ;
      private DateTime AV69Leaverequestwwds_12_tfleaverequestenddate ;
      private DateTime AV70Leaverequestwwds_13_tfleaverequestenddate_to ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK8C2 ;
      private bool BRK8C4 ;
      private bool BRK8C6 ;
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
      private string AV58Leaverequestwwds_1_filterfulltext ;
      private string AV74Leaverequestwwds_17_tfleaverequestdescription ;
      private string AV75Leaverequestwwds_18_tfleaverequestdescription_sel ;
      private string AV76Leaverequestwwds_19_tfleaverequestrejectionreason ;
      private string AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel ;
      private string lV58Leaverequestwwds_1_filterfulltext ;
      private string lV74Leaverequestwwds_17_tfleaverequestdescription ;
      private string lV76Leaverequestwwds_19_tfleaverequestrejectionreason ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string AV38Option ;
      private IGxSession AV44Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008C2_A124LeaveTypeId ;
      private long[] P008C2_A100CompanyId ;
      private long[] P008C2_A106EmployeeId ;
      private string[] P008C2_A134LeaveRequestRejectionReason ;
      private string[] P008C2_A133LeaveRequestDescription ;
      private short[] P008C2_A131LeaveRequestDuration ;
      private DateTime[] P008C2_A130LeaveRequestEndDate ;
      private DateTime[] P008C2_A129LeaveRequestStartDate ;
      private DateTime[] P008C2_A128LeaveRequestDate ;
      private string[] P008C2_A125LeaveTypeName ;
      private long[] P008C2_A127LeaveRequestId ;
      private string[] P008C2_A132LeaveRequestStatus ;
      private long[] P008C3_A100CompanyId ;
      private string[] P008C3_A133LeaveRequestDescription ;
      private long[] P008C3_A106EmployeeId ;
      private string[] P008C3_A134LeaveRequestRejectionReason ;
      private short[] P008C3_A131LeaveRequestDuration ;
      private DateTime[] P008C3_A130LeaveRequestEndDate ;
      private DateTime[] P008C3_A129LeaveRequestStartDate ;
      private DateTime[] P008C3_A128LeaveRequestDate ;
      private string[] P008C3_A125LeaveTypeName ;
      private long[] P008C3_A124LeaveTypeId ;
      private long[] P008C3_A127LeaveRequestId ;
      private string[] P008C3_A132LeaveRequestStatus ;
      private long[] P008C4_A100CompanyId ;
      private string[] P008C4_A134LeaveRequestRejectionReason ;
      private long[] P008C4_A106EmployeeId ;
      private string[] P008C4_A133LeaveRequestDescription ;
      private short[] P008C4_A131LeaveRequestDuration ;
      private DateTime[] P008C4_A130LeaveRequestEndDate ;
      private DateTime[] P008C4_A129LeaveRequestStartDate ;
      private DateTime[] P008C4_A128LeaveRequestDate ;
      private string[] P008C4_A125LeaveTypeName ;
      private long[] P008C4_A124LeaveTypeId ;
      private long[] P008C4_A127LeaveRequestId ;
      private string[] P008C4_A132LeaveRequestStatus ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV26TFLeaveRequestStatus_Sels ;
      private GxSimpleCollection<string> AV73Leaverequestwwds_16_tfleaverequeststatus_sels ;
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
                                             GxSimpleCollection<string> AV73Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                             string AV58Leaverequestwwds_1_filterfulltext ,
                                             long AV59Leaverequestwwds_2_tfleaverequestid ,
                                             long AV60Leaverequestwwds_3_tfleaverequestid_to ,
                                             long AV61Leaverequestwwds_4_tfleavetypeid ,
                                             long AV62Leaverequestwwds_5_tfleavetypeid_to ,
                                             string AV64Leaverequestwwds_7_tfleavetypename_sel ,
                                             string AV63Leaverequestwwds_6_tfleavetypename ,
                                             DateTime AV65Leaverequestwwds_8_tfleaverequestdate ,
                                             DateTime AV66Leaverequestwwds_9_tfleaverequestdate_to ,
                                             DateTime AV67Leaverequestwwds_10_tfleaverequeststartdate ,
                                             DateTime AV68Leaverequestwwds_11_tfleaverequeststartdate_to ,
                                             DateTime AV69Leaverequestwwds_12_tfleaverequestenddate ,
                                             DateTime AV70Leaverequestwwds_13_tfleaverequestenddate_to ,
                                             short AV71Leaverequestwwds_14_tfleaverequestduration ,
                                             short AV72Leaverequestwwds_15_tfleaverequestduration_to ,
                                             int AV73Leaverequestwwds_16_tfleaverequeststatus_sels_Count ,
                                             string AV75Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                             string AV74Leaverequestwwds_17_tfleaverequestdescription ,
                                             string AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                             string AV76Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                             long AV78Leaverequestwwds_21_tfemployeeid ,
                                             long AV79Leaverequestwwds_22_tfemployeeid_to ,
                                             long A127LeaveRequestId ,
                                             long A124LeaveTypeId ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             long A106EmployeeId ,
                                             DateTime A128LeaveRequestDate ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV80Udparg23 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[31];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDate, T2.LeaveTypeName, T1.LeaveRequestId, T1.LeaveRequestStatus FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV80Udparg23)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.LeaveRequestId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveTypeId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext))");
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
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV59Leaverequestwwds_2_tfleaverequestid) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestId >= :AV59Leaverequestwwds_2_tfleaverequestid)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV60Leaverequestwwds_3_tfleaverequestid_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestId <= :AV60Leaverequestwwds_3_tfleaverequestid_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV61Leaverequestwwds_4_tfleavetypeid) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId >= :AV61Leaverequestwwds_4_tfleavetypeid)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV62Leaverequestwwds_5_tfleavetypeid_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId <= :AV62Leaverequestwwds_5_tfleavetypeid_to)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_7_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestwwds_6_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV63Leaverequestwwds_6_tfleavetypename))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_7_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV64Leaverequestwwds_7_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV64Leaverequestwwds_7_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV64Leaverequestwwds_7_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestwwds_8_tfleaverequestdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDate >= :AV65Leaverequestwwds_8_tfleaverequestdate)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestwwds_9_tfleaverequestdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDate <= :AV66Leaverequestwwds_9_tfleaverequestdate_to)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestwwds_10_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV67Leaverequestwwds_10_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_11_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV68Leaverequestwwds_11_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_12_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV69Leaverequestwwds_12_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Leaverequestwwds_13_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV70Leaverequestwwds_13_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (0==AV71Leaverequestwwds_14_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV71Leaverequestwwds_14_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (0==AV72Leaverequestwwds_15_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV72Leaverequestwwds_15_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( AV73Leaverequestwwds_16_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV73Leaverequestwwds_16_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestwwds_18_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestwwds_17_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV74Leaverequestwwds_17_tfleaverequestdescription))");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestwwds_18_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV75Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV75Leaverequestwwds_18_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( StringUtil.StrCmp(AV75Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestwwds_19_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV76Leaverequestwwds_19_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( StringUtil.StrCmp(AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( ! (0==AV78Leaverequestwwds_21_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV78Leaverequestwwds_21_tfemployeeid)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ! (0==AV79Leaverequestwwds_22_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV79Leaverequestwwds_22_tfemployeeid_to)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008C3( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV73Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                             string AV58Leaverequestwwds_1_filterfulltext ,
                                             long AV59Leaverequestwwds_2_tfleaverequestid ,
                                             long AV60Leaverequestwwds_3_tfleaverequestid_to ,
                                             long AV61Leaverequestwwds_4_tfleavetypeid ,
                                             long AV62Leaverequestwwds_5_tfleavetypeid_to ,
                                             string AV64Leaverequestwwds_7_tfleavetypename_sel ,
                                             string AV63Leaverequestwwds_6_tfleavetypename ,
                                             DateTime AV65Leaverequestwwds_8_tfleaverequestdate ,
                                             DateTime AV66Leaverequestwwds_9_tfleaverequestdate_to ,
                                             DateTime AV67Leaverequestwwds_10_tfleaverequeststartdate ,
                                             DateTime AV68Leaverequestwwds_11_tfleaverequeststartdate_to ,
                                             DateTime AV69Leaverequestwwds_12_tfleaverequestenddate ,
                                             DateTime AV70Leaverequestwwds_13_tfleaverequestenddate_to ,
                                             short AV71Leaverequestwwds_14_tfleaverequestduration ,
                                             short AV72Leaverequestwwds_15_tfleaverequestduration_to ,
                                             int AV73Leaverequestwwds_16_tfleaverequeststatus_sels_Count ,
                                             string AV75Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                             string AV74Leaverequestwwds_17_tfleaverequestdescription ,
                                             string AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                             string AV76Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                             long AV78Leaverequestwwds_21_tfemployeeid ,
                                             long AV79Leaverequestwwds_22_tfemployeeid_to ,
                                             long A127LeaveRequestId ,
                                             long A124LeaveTypeId ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             long A106EmployeeId ,
                                             DateTime A128LeaveRequestDate ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV83Udparg24 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[31];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T1.LeaveRequestDescription, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDate, T2.LeaveTypeName, T1.LeaveTypeId, T1.LeaveRequestId, T1.LeaveRequestStatus FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV83Udparg24)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.LeaveRequestId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveTypeId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext))");
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
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV59Leaverequestwwds_2_tfleaverequestid) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestId >= :AV59Leaverequestwwds_2_tfleaverequestid)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV60Leaverequestwwds_3_tfleaverequestid_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestId <= :AV60Leaverequestwwds_3_tfleaverequestid_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV61Leaverequestwwds_4_tfleavetypeid) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId >= :AV61Leaverequestwwds_4_tfleavetypeid)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV62Leaverequestwwds_5_tfleavetypeid_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId <= :AV62Leaverequestwwds_5_tfleavetypeid_to)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_7_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestwwds_6_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV63Leaverequestwwds_6_tfleavetypename))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_7_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV64Leaverequestwwds_7_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV64Leaverequestwwds_7_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV64Leaverequestwwds_7_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestwwds_8_tfleaverequestdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDate >= :AV65Leaverequestwwds_8_tfleaverequestdate)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestwwds_9_tfleaverequestdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDate <= :AV66Leaverequestwwds_9_tfleaverequestdate_to)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestwwds_10_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV67Leaverequestwwds_10_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_11_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV68Leaverequestwwds_11_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_12_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV69Leaverequestwwds_12_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Leaverequestwwds_13_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV70Leaverequestwwds_13_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (0==AV71Leaverequestwwds_14_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV71Leaverequestwwds_14_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (0==AV72Leaverequestwwds_15_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV72Leaverequestwwds_15_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV73Leaverequestwwds_16_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV73Leaverequestwwds_16_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestwwds_18_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestwwds_17_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV74Leaverequestwwds_17_tfleaverequestdescription))");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestwwds_18_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV75Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV75Leaverequestwwds_18_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( StringUtil.StrCmp(AV75Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestwwds_19_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV76Leaverequestwwds_19_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( StringUtil.StrCmp(AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( ! (0==AV78Leaverequestwwds_21_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV78Leaverequestwwds_21_tfemployeeid)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ! (0==AV79Leaverequestwwds_22_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV79Leaverequestwwds_22_tfemployeeid_to)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008C4( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV73Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                             string AV58Leaverequestwwds_1_filterfulltext ,
                                             long AV59Leaverequestwwds_2_tfleaverequestid ,
                                             long AV60Leaverequestwwds_3_tfleaverequestid_to ,
                                             long AV61Leaverequestwwds_4_tfleavetypeid ,
                                             long AV62Leaverequestwwds_5_tfleavetypeid_to ,
                                             string AV64Leaverequestwwds_7_tfleavetypename_sel ,
                                             string AV63Leaverequestwwds_6_tfleavetypename ,
                                             DateTime AV65Leaverequestwwds_8_tfleaverequestdate ,
                                             DateTime AV66Leaverequestwwds_9_tfleaverequestdate_to ,
                                             DateTime AV67Leaverequestwwds_10_tfleaverequeststartdate ,
                                             DateTime AV68Leaverequestwwds_11_tfleaverequeststartdate_to ,
                                             DateTime AV69Leaverequestwwds_12_tfleaverequestenddate ,
                                             DateTime AV70Leaverequestwwds_13_tfleaverequestenddate_to ,
                                             short AV71Leaverequestwwds_14_tfleaverequestduration ,
                                             short AV72Leaverequestwwds_15_tfleaverequestduration_to ,
                                             int AV73Leaverequestwwds_16_tfleaverequeststatus_sels_Count ,
                                             string AV75Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                             string AV74Leaverequestwwds_17_tfleaverequestdescription ,
                                             string AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                             string AV76Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                             long AV78Leaverequestwwds_21_tfemployeeid ,
                                             long AV79Leaverequestwwds_22_tfemployeeid_to ,
                                             long A127LeaveRequestId ,
                                             long A124LeaveTypeId ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             long A106EmployeeId ,
                                             DateTime A128LeaveRequestDate ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV86Udparg25 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[31];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T1.LeaveRequestRejectionReason, T1.EmployeeId, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDate, T2.LeaveTypeName, T1.LeaveTypeId, T1.LeaveRequestId, T1.LeaveRequestStatus FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV86Udparg25)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.LeaveRequestId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveTypeId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV58Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV58Leaverequestwwds_1_filterfulltext))");
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
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
         }
         if ( ! (0==AV59Leaverequestwwds_2_tfleaverequestid) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestId >= :AV59Leaverequestwwds_2_tfleaverequestid)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV60Leaverequestwwds_3_tfleaverequestid_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestId <= :AV60Leaverequestwwds_3_tfleaverequestid_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV61Leaverequestwwds_4_tfleavetypeid) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId >= :AV61Leaverequestwwds_4_tfleavetypeid)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (0==AV62Leaverequestwwds_5_tfleavetypeid_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId <= :AV62Leaverequestwwds_5_tfleavetypeid_to)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_7_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestwwds_6_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV63Leaverequestwwds_6_tfleavetypename))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestwwds_7_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV64Leaverequestwwds_7_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV64Leaverequestwwds_7_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV64Leaverequestwwds_7_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestwwds_8_tfleaverequestdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDate >= :AV65Leaverequestwwds_8_tfleaverequestdate)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestwwds_9_tfleaverequestdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDate <= :AV66Leaverequestwwds_9_tfleaverequestdate_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestwwds_10_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV67Leaverequestwwds_10_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_11_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV68Leaverequestwwds_11_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_12_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV69Leaverequestwwds_12_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Leaverequestwwds_13_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV70Leaverequestwwds_13_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (0==AV71Leaverequestwwds_14_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV71Leaverequestwwds_14_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (0==AV72Leaverequestwwds_15_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV72Leaverequestwwds_15_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( AV73Leaverequestwwds_16_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV73Leaverequestwwds_16_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestwwds_18_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestwwds_17_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV74Leaverequestwwds_17_tfleaverequestdescription))");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestwwds_18_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV75Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV75Leaverequestwwds_18_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( StringUtil.StrCmp(AV75Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestwwds_19_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV76Leaverequestwwds_19_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( StringUtil.StrCmp(AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( ! (0==AV78Leaverequestwwds_21_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV78Leaverequestwwds_21_tfemployeeid)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ! (0==AV79Leaverequestwwds_22_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV79Leaverequestwwds_22_tfemployeeid_to)");
         }
         else
         {
            GXv_int5[30] = 1;
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
                     return conditional_P008C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] );
               case 1 :
                     return conditional_P008C3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] );
               case 2 :
                     return conditional_P008C4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] );
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
          Object[] prmP008C2;
          prmP008C2 = new Object[] {
          new ParDef("AV80Udparg23",GXType.Int64,10,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Leaverequestwwds_2_tfleaverequestid",GXType.Int64,10,0) ,
          new ParDef("AV60Leaverequestwwds_3_tfleaverequestid_to",GXType.Int64,10,0) ,
          new ParDef("AV61Leaverequestwwds_4_tfleavetypeid",GXType.Int64,10,0) ,
          new ParDef("AV62Leaverequestwwds_5_tfleavetypeid_to",GXType.Int64,10,0) ,
          new ParDef("lV63Leaverequestwwds_6_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV64Leaverequestwwds_7_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV65Leaverequestwwds_8_tfleaverequestdate",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestwwds_9_tfleaverequestdate_to",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestwwds_10_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV68Leaverequestwwds_11_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_12_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV70Leaverequestwwds_13_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV71Leaverequestwwds_14_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV72Leaverequestwwds_15_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV74Leaverequestwwds_17_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV75Leaverequestwwds_18_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV76Leaverequestwwds_19_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("AV78Leaverequestwwds_21_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV79Leaverequestwwds_22_tfemployeeid_to",GXType.Int64,10,0)
          };
          Object[] prmP008C3;
          prmP008C3 = new Object[] {
          new ParDef("AV83Udparg24",GXType.Int64,10,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Leaverequestwwds_2_tfleaverequestid",GXType.Int64,10,0) ,
          new ParDef("AV60Leaverequestwwds_3_tfleaverequestid_to",GXType.Int64,10,0) ,
          new ParDef("AV61Leaverequestwwds_4_tfleavetypeid",GXType.Int64,10,0) ,
          new ParDef("AV62Leaverequestwwds_5_tfleavetypeid_to",GXType.Int64,10,0) ,
          new ParDef("lV63Leaverequestwwds_6_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV64Leaverequestwwds_7_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV65Leaverequestwwds_8_tfleaverequestdate",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestwwds_9_tfleaverequestdate_to",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestwwds_10_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV68Leaverequestwwds_11_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_12_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV70Leaverequestwwds_13_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV71Leaverequestwwds_14_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV72Leaverequestwwds_15_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV74Leaverequestwwds_17_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV75Leaverequestwwds_18_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV76Leaverequestwwds_19_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("AV78Leaverequestwwds_21_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV79Leaverequestwwds_22_tfemployeeid_to",GXType.Int64,10,0)
          };
          Object[] prmP008C4;
          prmP008C4 = new Object[] {
          new ParDef("AV86Udparg25",GXType.Int64,10,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Leaverequestwwds_2_tfleaverequestid",GXType.Int64,10,0) ,
          new ParDef("AV60Leaverequestwwds_3_tfleaverequestid_to",GXType.Int64,10,0) ,
          new ParDef("AV61Leaverequestwwds_4_tfleavetypeid",GXType.Int64,10,0) ,
          new ParDef("AV62Leaverequestwwds_5_tfleavetypeid_to",GXType.Int64,10,0) ,
          new ParDef("lV63Leaverequestwwds_6_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV64Leaverequestwwds_7_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV65Leaverequestwwds_8_tfleaverequestdate",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestwwds_9_tfleaverequestdate_to",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestwwds_10_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV68Leaverequestwwds_11_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_12_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV70Leaverequestwwds_13_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV71Leaverequestwwds_14_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV72Leaverequestwwds_15_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV74Leaverequestwwds_17_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV75Leaverequestwwds_18_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV76Leaverequestwwds_19_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV77Leaverequestwwds_20_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("AV78Leaverequestwwds_21_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV79Leaverequestwwds_22_tfemployeeid_to",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                return;
       }
    }

 }

}
