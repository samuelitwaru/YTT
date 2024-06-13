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
   public class leavetypewwgetfilterdata : GXProcedure
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
            return "leavetypeww_Services_Execute" ;
         }

      }

      public leavetypewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leavetypewwgetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         leavetypewwgetfilterdata objleavetypewwgetfilterdata;
         objleavetypewwgetfilterdata = new leavetypewwgetfilterdata();
         objleavetypewwgetfilterdata.AV33DDOName = aP0_DDOName;
         objleavetypewwgetfilterdata.AV34SearchTxtParms = aP1_SearchTxtParms;
         objleavetypewwgetfilterdata.AV35SearchTxtTo = aP2_SearchTxtTo;
         objleavetypewwgetfilterdata.AV36OptionsJson = "" ;
         objleavetypewwgetfilterdata.AV37OptionsDescJson = "" ;
         objleavetypewwgetfilterdata.AV38OptionIndexesJson = "" ;
         objleavetypewwgetfilterdata.context.SetSubmitInitialConfig(context);
         objleavetypewwgetfilterdata.initialize();
         Submit( executePrivateCatch,objleavetypewwgetfilterdata);
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leavetypewwgetfilterdata)stateInfo).executePrivate();
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
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_LEAVETYPECOLORPENDING") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPECOLORPENDINGOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_LEAVETYPECOLORAPPROVED") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPECOLORAPPROVEDOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("LeaveTypeWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LeaveTypeWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("LeaveTypeWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV13TFLeaveTypeName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV14TFLeaveTypeName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPEVACATIONLEAVE_SEL") == 0 )
            {
               AV40TFLeaveTypeVacationLeave_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV41TFLeaveTypeVacationLeave_Sels.FromJSonString(AV40TFLeaveTypeVacationLeave_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPELOGGINGWORKHOURS_SEL") == 0 )
            {
               AV42TFLeaveTypeLoggingWorkHours_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV43TFLeaveTypeLoggingWorkHours_Sels.FromJSonString(AV42TFLeaveTypeLoggingWorkHours_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPECOLORPENDING") == 0 )
            {
               AV46TFLeaveTypeColorPending = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPECOLORPENDING_SEL") == 0 )
            {
               AV47TFLeaveTypeColorPending_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPECOLORAPPROVED") == 0 )
            {
               AV48TFLeaveTypeColorApproved = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPECOLORAPPROVED_SEL") == 0 )
            {
               AV49TFLeaveTypeColorApproved_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFLeaveTypeName = AV17SearchTxt;
         AV14TFLeaveTypeName_Sel = "";
         AV52Leavetypewwds_1_filterfulltext = AV39FilterFullText;
         AV53Leavetypewwds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV54Leavetypewwds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV55Leavetypewwds_4_tfleavetypevacationleave_sels = AV41TFLeaveTypeVacationLeave_Sels;
         AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels = AV43TFLeaveTypeLoggingWorkHours_Sels;
         AV57Leavetypewwds_6_tfleavetypecolorpending = AV46TFLeaveTypeColorPending;
         AV58Leavetypewwds_7_tfleavetypecolorpending_sel = AV47TFLeaveTypeColorPending_Sel;
         AV59Leavetypewwds_8_tfleavetypecolorapproved = AV48TFLeaveTypeColorApproved;
         AV60Leavetypewwds_9_tfleavetypecolorapproved_sel = AV49TFLeaveTypeColorApproved_Sel;
         AV61Udparg10 = new getloggedinusercompanyid(context).executeUdp( );
         AV61Udparg10 = new getloggedinusercompanyid(context).executeUdp( );
         AV61Udparg10 = new getloggedinusercompanyid(context).executeUdp( );
         AV61Udparg10 = new getloggedinusercompanyid(context).executeUdp( );
         AV61Udparg10 = new getloggedinusercompanyid(context).executeUdp( );
         AV61Udparg10 = new getloggedinusercompanyid(context).executeUdp( );
         AV61Udparg10 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A144LeaveTypeVacationLeave ,
                                              AV55Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                              A145LeaveTypeLoggingWorkHours ,
                                              AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                              AV52Leavetypewwds_1_filterfulltext ,
                                              AV54Leavetypewwds_3_tfleavetypename_sel ,
                                              AV53Leavetypewwds_2_tfleavetypename ,
                                              AV55Leavetypewwds_4_tfleavetypevacationleave_sels.Count ,
                                              AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels.Count ,
                                              AV58Leavetypewwds_7_tfleavetypecolorpending_sel ,
                                              AV57Leavetypewwds_6_tfleavetypecolorpending ,
                                              AV60Leavetypewwds_9_tfleavetypecolorapproved_sel ,
                                              AV59Leavetypewwds_8_tfleavetypecolorapproved ,
                                              A125LeaveTypeName ,
                                              A174LeaveTypeColorPending ,
                                              A175LeaveTypeColorApproved ,
                                              A100CompanyId ,
                                              AV61Udparg10 } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV53Leavetypewwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leavetypewwds_2_tfleavetypename), 100, "%");
         lV57Leavetypewwds_6_tfleavetypecolorpending = StringUtil.PadR( StringUtil.RTrim( AV57Leavetypewwds_6_tfleavetypecolorpending), 20, "%");
         lV59Leavetypewwds_8_tfleavetypecolorapproved = StringUtil.PadR( StringUtil.RTrim( AV59Leavetypewwds_8_tfleavetypecolorapproved), 20, "%");
         /* Using cursor P005C2 */
         pr_default.execute(0, new Object[] {AV61Udparg10, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV53Leavetypewwds_2_tfleavetypename, AV54Leavetypewwds_3_tfleavetypename_sel, lV57Leavetypewwds_6_tfleavetypecolorpending, AV58Leavetypewwds_7_tfleavetypecolorpending_sel, lV59Leavetypewwds_8_tfleavetypecolorapproved, AV60Leavetypewwds_9_tfleavetypecolorapproved_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5C2 = false;
            A100CompanyId = P005C2_A100CompanyId[0];
            A125LeaveTypeName = P005C2_A125LeaveTypeName[0];
            A175LeaveTypeColorApproved = P005C2_A175LeaveTypeColorApproved[0];
            n175LeaveTypeColorApproved = P005C2_n175LeaveTypeColorApproved[0];
            A174LeaveTypeColorPending = P005C2_A174LeaveTypeColorPending[0];
            n174LeaveTypeColorPending = P005C2_n174LeaveTypeColorPending[0];
            A145LeaveTypeLoggingWorkHours = P005C2_A145LeaveTypeLoggingWorkHours[0];
            A144LeaveTypeVacationLeave = P005C2_A144LeaveTypeVacationLeave[0];
            A124LeaveTypeId = P005C2_A124LeaveTypeId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005C2_A125LeaveTypeName[0], A125LeaveTypeName) == 0 ) )
            {
               BRK5C2 = false;
               A124LeaveTypeId = P005C2_A124LeaveTypeId[0];
               AV27count = (long)(AV27count+1);
               BRK5C2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK5C2 )
            {
               BRK5C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLEAVETYPECOLORPENDINGOPTIONS' Routine */
         returnInSub = false;
         AV46TFLeaveTypeColorPending = AV17SearchTxt;
         AV47TFLeaveTypeColorPending_Sel = "";
         AV52Leavetypewwds_1_filterfulltext = AV39FilterFullText;
         AV53Leavetypewwds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV54Leavetypewwds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV55Leavetypewwds_4_tfleavetypevacationleave_sels = AV41TFLeaveTypeVacationLeave_Sels;
         AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels = AV43TFLeaveTypeLoggingWorkHours_Sels;
         AV57Leavetypewwds_6_tfleavetypecolorpending = AV46TFLeaveTypeColorPending;
         AV58Leavetypewwds_7_tfleavetypecolorpending_sel = AV47TFLeaveTypeColorPending_Sel;
         AV59Leavetypewwds_8_tfleavetypecolorapproved = AV48TFLeaveTypeColorApproved;
         AV60Leavetypewwds_9_tfleavetypecolorapproved_sel = AV49TFLeaveTypeColorApproved_Sel;
         AV64Udparg11 = new getloggedinusercompanyid(context).executeUdp( );
         AV64Udparg11 = new getloggedinusercompanyid(context).executeUdp( );
         AV64Udparg11 = new getloggedinusercompanyid(context).executeUdp( );
         AV64Udparg11 = new getloggedinusercompanyid(context).executeUdp( );
         AV64Udparg11 = new getloggedinusercompanyid(context).executeUdp( );
         AV64Udparg11 = new getloggedinusercompanyid(context).executeUdp( );
         AV64Udparg11 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A144LeaveTypeVacationLeave ,
                                              AV55Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                              A145LeaveTypeLoggingWorkHours ,
                                              AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                              AV52Leavetypewwds_1_filterfulltext ,
                                              AV54Leavetypewwds_3_tfleavetypename_sel ,
                                              AV53Leavetypewwds_2_tfleavetypename ,
                                              AV55Leavetypewwds_4_tfleavetypevacationleave_sels.Count ,
                                              AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels.Count ,
                                              AV58Leavetypewwds_7_tfleavetypecolorpending_sel ,
                                              AV57Leavetypewwds_6_tfleavetypecolorpending ,
                                              AV60Leavetypewwds_9_tfleavetypecolorapproved_sel ,
                                              AV59Leavetypewwds_8_tfleavetypecolorapproved ,
                                              A125LeaveTypeName ,
                                              A174LeaveTypeColorPending ,
                                              A175LeaveTypeColorApproved ,
                                              A100CompanyId ,
                                              AV64Udparg11 } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV53Leavetypewwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leavetypewwds_2_tfleavetypename), 100, "%");
         lV57Leavetypewwds_6_tfleavetypecolorpending = StringUtil.PadR( StringUtil.RTrim( AV57Leavetypewwds_6_tfleavetypecolorpending), 20, "%");
         lV59Leavetypewwds_8_tfleavetypecolorapproved = StringUtil.PadR( StringUtil.RTrim( AV59Leavetypewwds_8_tfleavetypecolorapproved), 20, "%");
         /* Using cursor P005C3 */
         pr_default.execute(1, new Object[] {AV64Udparg11, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV53Leavetypewwds_2_tfleavetypename, AV54Leavetypewwds_3_tfleavetypename_sel, lV57Leavetypewwds_6_tfleavetypecolorpending, AV58Leavetypewwds_7_tfleavetypecolorpending_sel, lV59Leavetypewwds_8_tfleavetypecolorapproved, AV60Leavetypewwds_9_tfleavetypecolorapproved_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5C4 = false;
            A100CompanyId = P005C3_A100CompanyId[0];
            A174LeaveTypeColorPending = P005C3_A174LeaveTypeColorPending[0];
            n174LeaveTypeColorPending = P005C3_n174LeaveTypeColorPending[0];
            A175LeaveTypeColorApproved = P005C3_A175LeaveTypeColorApproved[0];
            n175LeaveTypeColorApproved = P005C3_n175LeaveTypeColorApproved[0];
            A125LeaveTypeName = P005C3_A125LeaveTypeName[0];
            A145LeaveTypeLoggingWorkHours = P005C3_A145LeaveTypeLoggingWorkHours[0];
            A144LeaveTypeVacationLeave = P005C3_A144LeaveTypeVacationLeave[0];
            A124LeaveTypeId = P005C3_A124LeaveTypeId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005C3_A174LeaveTypeColorPending[0], A174LeaveTypeColorPending) == 0 ) )
            {
               BRK5C4 = false;
               A124LeaveTypeId = P005C3_A124LeaveTypeId[0];
               AV27count = (long)(AV27count+1);
               BRK5C4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A174LeaveTypeColorPending)) ? "<#Empty#>" : A174LeaveTypeColorPending);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK5C4 )
            {
               BRK5C4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADLEAVETYPECOLORAPPROVEDOPTIONS' Routine */
         returnInSub = false;
         AV48TFLeaveTypeColorApproved = AV17SearchTxt;
         AV49TFLeaveTypeColorApproved_Sel = "";
         AV52Leavetypewwds_1_filterfulltext = AV39FilterFullText;
         AV53Leavetypewwds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV54Leavetypewwds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV55Leavetypewwds_4_tfleavetypevacationleave_sels = AV41TFLeaveTypeVacationLeave_Sels;
         AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels = AV43TFLeaveTypeLoggingWorkHours_Sels;
         AV57Leavetypewwds_6_tfleavetypecolorpending = AV46TFLeaveTypeColorPending;
         AV58Leavetypewwds_7_tfleavetypecolorpending_sel = AV47TFLeaveTypeColorPending_Sel;
         AV59Leavetypewwds_8_tfleavetypecolorapproved = AV48TFLeaveTypeColorApproved;
         AV60Leavetypewwds_9_tfleavetypecolorapproved_sel = AV49TFLeaveTypeColorApproved_Sel;
         AV67Udparg12 = new getloggedinusercompanyid(context).executeUdp( );
         AV67Udparg12 = new getloggedinusercompanyid(context).executeUdp( );
         AV67Udparg12 = new getloggedinusercompanyid(context).executeUdp( );
         AV67Udparg12 = new getloggedinusercompanyid(context).executeUdp( );
         AV67Udparg12 = new getloggedinusercompanyid(context).executeUdp( );
         AV67Udparg12 = new getloggedinusercompanyid(context).executeUdp( );
         AV67Udparg12 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A144LeaveTypeVacationLeave ,
                                              AV55Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                              A145LeaveTypeLoggingWorkHours ,
                                              AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                              AV52Leavetypewwds_1_filterfulltext ,
                                              AV54Leavetypewwds_3_tfleavetypename_sel ,
                                              AV53Leavetypewwds_2_tfleavetypename ,
                                              AV55Leavetypewwds_4_tfleavetypevacationleave_sels.Count ,
                                              AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels.Count ,
                                              AV58Leavetypewwds_7_tfleavetypecolorpending_sel ,
                                              AV57Leavetypewwds_6_tfleavetypecolorpending ,
                                              AV60Leavetypewwds_9_tfleavetypecolorapproved_sel ,
                                              AV59Leavetypewwds_8_tfleavetypecolorapproved ,
                                              A125LeaveTypeName ,
                                              A174LeaveTypeColorPending ,
                                              A175LeaveTypeColorApproved ,
                                              A100CompanyId ,
                                              AV67Udparg12 } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV53Leavetypewwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leavetypewwds_2_tfleavetypename), 100, "%");
         lV57Leavetypewwds_6_tfleavetypecolorpending = StringUtil.PadR( StringUtil.RTrim( AV57Leavetypewwds_6_tfleavetypecolorpending), 20, "%");
         lV59Leavetypewwds_8_tfleavetypecolorapproved = StringUtil.PadR( StringUtil.RTrim( AV59Leavetypewwds_8_tfleavetypecolorapproved), 20, "%");
         /* Using cursor P005C4 */
         pr_default.execute(2, new Object[] {AV67Udparg12, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV53Leavetypewwds_2_tfleavetypename, AV54Leavetypewwds_3_tfleavetypename_sel, lV57Leavetypewwds_6_tfleavetypecolorpending, AV58Leavetypewwds_7_tfleavetypecolorpending_sel, lV59Leavetypewwds_8_tfleavetypecolorapproved, AV60Leavetypewwds_9_tfleavetypecolorapproved_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5C6 = false;
            A100CompanyId = P005C4_A100CompanyId[0];
            A175LeaveTypeColorApproved = P005C4_A175LeaveTypeColorApproved[0];
            n175LeaveTypeColorApproved = P005C4_n175LeaveTypeColorApproved[0];
            A174LeaveTypeColorPending = P005C4_A174LeaveTypeColorPending[0];
            n174LeaveTypeColorPending = P005C4_n174LeaveTypeColorPending[0];
            A125LeaveTypeName = P005C4_A125LeaveTypeName[0];
            A145LeaveTypeLoggingWorkHours = P005C4_A145LeaveTypeLoggingWorkHours[0];
            A144LeaveTypeVacationLeave = P005C4_A144LeaveTypeVacationLeave[0];
            A124LeaveTypeId = P005C4_A124LeaveTypeId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005C4_A175LeaveTypeColorApproved[0], A175LeaveTypeColorApproved) == 0 ) )
            {
               BRK5C6 = false;
               A124LeaveTypeId = P005C4_A124LeaveTypeId[0];
               AV27count = (long)(AV27count+1);
               BRK5C6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A175LeaveTypeColorApproved)) ? "<#Empty#>" : A175LeaveTypeColorApproved);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK5C6 )
            {
               BRK5C6 = true;
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV13TFLeaveTypeName = "";
         AV14TFLeaveTypeName_Sel = "";
         AV40TFLeaveTypeVacationLeave_SelsJson = "";
         AV41TFLeaveTypeVacationLeave_Sels = new GxSimpleCollection<string>();
         AV42TFLeaveTypeLoggingWorkHours_SelsJson = "";
         AV43TFLeaveTypeLoggingWorkHours_Sels = new GxSimpleCollection<string>();
         AV46TFLeaveTypeColorPending = "";
         AV47TFLeaveTypeColorPending_Sel = "";
         AV48TFLeaveTypeColorApproved = "";
         AV49TFLeaveTypeColorApproved_Sel = "";
         AV52Leavetypewwds_1_filterfulltext = "";
         AV53Leavetypewwds_2_tfleavetypename = "";
         AV54Leavetypewwds_3_tfleavetypename_sel = "";
         AV55Leavetypewwds_4_tfleavetypevacationleave_sels = new GxSimpleCollection<string>();
         AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels = new GxSimpleCollection<string>();
         AV57Leavetypewwds_6_tfleavetypecolorpending = "";
         AV58Leavetypewwds_7_tfleavetypecolorpending_sel = "";
         AV59Leavetypewwds_8_tfleavetypecolorapproved = "";
         AV60Leavetypewwds_9_tfleavetypecolorapproved_sel = "";
         scmdbuf = "";
         lV52Leavetypewwds_1_filterfulltext = "";
         lV53Leavetypewwds_2_tfleavetypename = "";
         lV57Leavetypewwds_6_tfleavetypecolorpending = "";
         lV59Leavetypewwds_8_tfleavetypecolorapproved = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         A125LeaveTypeName = "";
         A174LeaveTypeColorPending = "";
         A175LeaveTypeColorApproved = "";
         P005C2_A100CompanyId = new long[1] ;
         P005C2_A125LeaveTypeName = new string[] {""} ;
         P005C2_A175LeaveTypeColorApproved = new string[] {""} ;
         P005C2_n175LeaveTypeColorApproved = new bool[] {false} ;
         P005C2_A174LeaveTypeColorPending = new string[] {""} ;
         P005C2_n174LeaveTypeColorPending = new bool[] {false} ;
         P005C2_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P005C2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P005C2_A124LeaveTypeId = new long[1] ;
         AV22Option = "";
         P005C3_A100CompanyId = new long[1] ;
         P005C3_A174LeaveTypeColorPending = new string[] {""} ;
         P005C3_n174LeaveTypeColorPending = new bool[] {false} ;
         P005C3_A175LeaveTypeColorApproved = new string[] {""} ;
         P005C3_n175LeaveTypeColorApproved = new bool[] {false} ;
         P005C3_A125LeaveTypeName = new string[] {""} ;
         P005C3_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P005C3_A144LeaveTypeVacationLeave = new string[] {""} ;
         P005C3_A124LeaveTypeId = new long[1] ;
         P005C4_A100CompanyId = new long[1] ;
         P005C4_A175LeaveTypeColorApproved = new string[] {""} ;
         P005C4_n175LeaveTypeColorApproved = new bool[] {false} ;
         P005C4_A174LeaveTypeColorPending = new string[] {""} ;
         P005C4_n174LeaveTypeColorPending = new bool[] {false} ;
         P005C4_A125LeaveTypeName = new string[] {""} ;
         P005C4_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P005C4_A144LeaveTypeVacationLeave = new string[] {""} ;
         P005C4_A124LeaveTypeId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavetypewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005C2_A100CompanyId, P005C2_A125LeaveTypeName, P005C2_A175LeaveTypeColorApproved, P005C2_n175LeaveTypeColorApproved, P005C2_A174LeaveTypeColorPending, P005C2_n174LeaveTypeColorPending, P005C2_A145LeaveTypeLoggingWorkHours, P005C2_A144LeaveTypeVacationLeave, P005C2_A124LeaveTypeId
               }
               , new Object[] {
               P005C3_A100CompanyId, P005C3_A174LeaveTypeColorPending, P005C3_n174LeaveTypeColorPending, P005C3_A175LeaveTypeColorApproved, P005C3_n175LeaveTypeColorApproved, P005C3_A125LeaveTypeName, P005C3_A145LeaveTypeLoggingWorkHours, P005C3_A144LeaveTypeVacationLeave, P005C3_A124LeaveTypeId
               }
               , new Object[] {
               P005C4_A100CompanyId, P005C4_A175LeaveTypeColorApproved, P005C4_n175LeaveTypeColorApproved, P005C4_A174LeaveTypeColorPending, P005C4_n174LeaveTypeColorPending, P005C4_A125LeaveTypeName, P005C4_A145LeaveTypeLoggingWorkHours, P005C4_A144LeaveTypeVacationLeave, P005C4_A124LeaveTypeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV50GXV1 ;
      private int AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count ;
      private int AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count ;
      private long AV61Udparg10 ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long AV27count ;
      private long AV64Udparg11 ;
      private long AV67Udparg12 ;
      private string AV13TFLeaveTypeName ;
      private string AV14TFLeaveTypeName_Sel ;
      private string AV46TFLeaveTypeColorPending ;
      private string AV47TFLeaveTypeColorPending_Sel ;
      private string AV48TFLeaveTypeColorApproved ;
      private string AV49TFLeaveTypeColorApproved_Sel ;
      private string AV53Leavetypewwds_2_tfleavetypename ;
      private string AV54Leavetypewwds_3_tfleavetypename_sel ;
      private string AV57Leavetypewwds_6_tfleavetypecolorpending ;
      private string AV58Leavetypewwds_7_tfleavetypecolorpending_sel ;
      private string AV59Leavetypewwds_8_tfleavetypecolorapproved ;
      private string AV60Leavetypewwds_9_tfleavetypecolorapproved_sel ;
      private string scmdbuf ;
      private string lV53Leavetypewwds_2_tfleavetypename ;
      private string lV57Leavetypewwds_6_tfleavetypecolorpending ;
      private string lV59Leavetypewwds_8_tfleavetypecolorapproved ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A125LeaveTypeName ;
      private string A174LeaveTypeColorPending ;
      private string A175LeaveTypeColorApproved ;
      private bool returnInSub ;
      private bool BRK5C2 ;
      private bool n175LeaveTypeColorApproved ;
      private bool n174LeaveTypeColorPending ;
      private bool BRK5C4 ;
      private bool BRK5C6 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV40TFLeaveTypeVacationLeave_SelsJson ;
      private string AV42TFLeaveTypeLoggingWorkHours_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV52Leavetypewwds_1_filterfulltext ;
      private string lV52Leavetypewwds_1_filterfulltext ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005C2_A100CompanyId ;
      private string[] P005C2_A125LeaveTypeName ;
      private string[] P005C2_A175LeaveTypeColorApproved ;
      private bool[] P005C2_n175LeaveTypeColorApproved ;
      private string[] P005C2_A174LeaveTypeColorPending ;
      private bool[] P005C2_n174LeaveTypeColorPending ;
      private string[] P005C2_A145LeaveTypeLoggingWorkHours ;
      private string[] P005C2_A144LeaveTypeVacationLeave ;
      private long[] P005C2_A124LeaveTypeId ;
      private long[] P005C3_A100CompanyId ;
      private string[] P005C3_A174LeaveTypeColorPending ;
      private bool[] P005C3_n174LeaveTypeColorPending ;
      private string[] P005C3_A175LeaveTypeColorApproved ;
      private bool[] P005C3_n175LeaveTypeColorApproved ;
      private string[] P005C3_A125LeaveTypeName ;
      private string[] P005C3_A145LeaveTypeLoggingWorkHours ;
      private string[] P005C3_A144LeaveTypeVacationLeave ;
      private long[] P005C3_A124LeaveTypeId ;
      private long[] P005C4_A100CompanyId ;
      private string[] P005C4_A175LeaveTypeColorApproved ;
      private bool[] P005C4_n175LeaveTypeColorApproved ;
      private string[] P005C4_A174LeaveTypeColorPending ;
      private bool[] P005C4_n174LeaveTypeColorPending ;
      private string[] P005C4_A125LeaveTypeName ;
      private string[] P005C4_A145LeaveTypeLoggingWorkHours ;
      private string[] P005C4_A144LeaveTypeVacationLeave ;
      private long[] P005C4_A124LeaveTypeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV41TFLeaveTypeVacationLeave_Sels ;
      private GxSimpleCollection<string> AV43TFLeaveTypeLoggingWorkHours_Sels ;
      private GxSimpleCollection<string> AV55Leavetypewwds_4_tfleavetypevacationleave_sels ;
      private GxSimpleCollection<string> AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class leavetypewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005C2( IGxContext context ,
                                             string A144LeaveTypeVacationLeave ,
                                             GxSimpleCollection<string> AV55Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                             string A145LeaveTypeLoggingWorkHours ,
                                             GxSimpleCollection<string> AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                             string AV52Leavetypewwds_1_filterfulltext ,
                                             string AV54Leavetypewwds_3_tfleavetypename_sel ,
                                             string AV53Leavetypewwds_2_tfleavetypename ,
                                             int AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count ,
                                             int AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count ,
                                             string AV58Leavetypewwds_7_tfleavetypecolorpending_sel ,
                                             string AV57Leavetypewwds_6_tfleavetypecolorpending ,
                                             string AV60Leavetypewwds_9_tfleavetypecolorapproved_sel ,
                                             string AV59Leavetypewwds_8_tfleavetypecolorapproved ,
                                             string A125LeaveTypeName ,
                                             string A174LeaveTypeColorPending ,
                                             string A175LeaveTypeColorApproved ,
                                             long A100CompanyId ,
                                             long AV61Udparg10 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CompanyId, LeaveTypeName, LeaveTypeColorApproved, LeaveTypeColorPending, LeaveTypeLoggingWorkHours, LeaveTypeVacationLeave, LeaveTypeId FROM LeaveType";
         AddWhere(sWhereString, "(CompanyId = :AV61Udparg10)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(LeaveTypeName) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)) or ( 'no' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'No')) or ( 'yes' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'Yes')) or ( 'no' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'No')) or ( 'yes' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'Yes')) or ( LOWER(LeaveTypeColorPending) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)) or ( LOWER(LeaveTypeColorApproved) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)))");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leavetypewwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leavetypewwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeName) like LOWER(:lV53Leavetypewwds_2_tfleavetypename))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leavetypewwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeName = ( :AV54Leavetypewwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LeaveTypeName))=0))");
         }
         if ( AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Leavetypewwds_4_tfleavetypevacationleave_sels, "LeaveTypeVacationLeave IN (", ")")+")");
         }
         if ( AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels, "LeaveTypeLoggingWorkHours IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Leavetypewwds_7_tfleavetypecolorpending_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leavetypewwds_6_tfleavetypecolorpending)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeColorPending) like LOWER(:lV57Leavetypewwds_6_tfleavetypecolorpending))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leavetypewwds_7_tfleavetypecolorpending_sel)) && ! ( StringUtil.StrCmp(AV58Leavetypewwds_7_tfleavetypecolorpending_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeColorPending = ( :AV58Leavetypewwds_7_tfleavetypecolorpending_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV58Leavetypewwds_7_tfleavetypecolorpending_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LeaveTypeColorPending IS NULL or (char_length(trim(trailing ' ' from LeaveTypeColorPending))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leavetypewwds_9_tfleavetypecolorapproved_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leavetypewwds_8_tfleavetypecolorapproved)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeColorApproved) like LOWER(:lV59Leavetypewwds_8_tfleavetypecolorapproved))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leavetypewwds_9_tfleavetypecolorapproved_sel)) && ! ( StringUtil.StrCmp(AV60Leavetypewwds_9_tfleavetypecolorapproved_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeColorApproved = ( :AV60Leavetypewwds_9_tfleavetypecolorapproved_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leavetypewwds_9_tfleavetypecolorapproved_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LeaveTypeColorApproved IS NULL or (char_length(trim(trailing ' ' from LeaveTypeColorApproved))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LeaveTypeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005C3( IGxContext context ,
                                             string A144LeaveTypeVacationLeave ,
                                             GxSimpleCollection<string> AV55Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                             string A145LeaveTypeLoggingWorkHours ,
                                             GxSimpleCollection<string> AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                             string AV52Leavetypewwds_1_filterfulltext ,
                                             string AV54Leavetypewwds_3_tfleavetypename_sel ,
                                             string AV53Leavetypewwds_2_tfleavetypename ,
                                             int AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count ,
                                             int AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count ,
                                             string AV58Leavetypewwds_7_tfleavetypecolorpending_sel ,
                                             string AV57Leavetypewwds_6_tfleavetypecolorpending ,
                                             string AV60Leavetypewwds_9_tfleavetypecolorapproved_sel ,
                                             string AV59Leavetypewwds_8_tfleavetypecolorapproved ,
                                             string A125LeaveTypeName ,
                                             string A174LeaveTypeColorPending ,
                                             string A175LeaveTypeColorApproved ,
                                             long A100CompanyId ,
                                             long AV64Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CompanyId, LeaveTypeColorPending, LeaveTypeColorApproved, LeaveTypeName, LeaveTypeLoggingWorkHours, LeaveTypeVacationLeave, LeaveTypeId FROM LeaveType";
         AddWhere(sWhereString, "(CompanyId = :AV64Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(LeaveTypeName) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)) or ( 'no' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'No')) or ( 'yes' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'Yes')) or ( 'no' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'No')) or ( 'yes' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'Yes')) or ( LOWER(LeaveTypeColorPending) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)) or ( LOWER(LeaveTypeColorApproved) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)))");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leavetypewwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leavetypewwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeName) like LOWER(:lV53Leavetypewwds_2_tfleavetypename))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leavetypewwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeName = ( :AV54Leavetypewwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LeaveTypeName))=0))");
         }
         if ( AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Leavetypewwds_4_tfleavetypevacationleave_sels, "LeaveTypeVacationLeave IN (", ")")+")");
         }
         if ( AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels, "LeaveTypeLoggingWorkHours IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Leavetypewwds_7_tfleavetypecolorpending_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leavetypewwds_6_tfleavetypecolorpending)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeColorPending) like LOWER(:lV57Leavetypewwds_6_tfleavetypecolorpending))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leavetypewwds_7_tfleavetypecolorpending_sel)) && ! ( StringUtil.StrCmp(AV58Leavetypewwds_7_tfleavetypecolorpending_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeColorPending = ( :AV58Leavetypewwds_7_tfleavetypecolorpending_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV58Leavetypewwds_7_tfleavetypecolorpending_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LeaveTypeColorPending IS NULL or (char_length(trim(trailing ' ' from LeaveTypeColorPending))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leavetypewwds_9_tfleavetypecolorapproved_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leavetypewwds_8_tfleavetypecolorapproved)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeColorApproved) like LOWER(:lV59Leavetypewwds_8_tfleavetypecolorapproved))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leavetypewwds_9_tfleavetypecolorapproved_sel)) && ! ( StringUtil.StrCmp(AV60Leavetypewwds_9_tfleavetypecolorapproved_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeColorApproved = ( :AV60Leavetypewwds_9_tfleavetypecolorapproved_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leavetypewwds_9_tfleavetypecolorapproved_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LeaveTypeColorApproved IS NULL or (char_length(trim(trailing ' ' from LeaveTypeColorApproved))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LeaveTypeColorPending";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005C4( IGxContext context ,
                                             string A144LeaveTypeVacationLeave ,
                                             GxSimpleCollection<string> AV55Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                             string A145LeaveTypeLoggingWorkHours ,
                                             GxSimpleCollection<string> AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                             string AV52Leavetypewwds_1_filterfulltext ,
                                             string AV54Leavetypewwds_3_tfleavetypename_sel ,
                                             string AV53Leavetypewwds_2_tfleavetypename ,
                                             int AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count ,
                                             int AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count ,
                                             string AV58Leavetypewwds_7_tfleavetypecolorpending_sel ,
                                             string AV57Leavetypewwds_6_tfleavetypecolorpending ,
                                             string AV60Leavetypewwds_9_tfleavetypecolorapproved_sel ,
                                             string AV59Leavetypewwds_8_tfleavetypecolorapproved ,
                                             string A125LeaveTypeName ,
                                             string A174LeaveTypeColorPending ,
                                             string A175LeaveTypeColorApproved ,
                                             long A100CompanyId ,
                                             long AV67Udparg12 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT CompanyId, LeaveTypeColorApproved, LeaveTypeColorPending, LeaveTypeName, LeaveTypeLoggingWorkHours, LeaveTypeVacationLeave, LeaveTypeId FROM LeaveType";
         AddWhere(sWhereString, "(CompanyId = :AV67Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(LeaveTypeName) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)) or ( 'no' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'No')) or ( 'yes' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'Yes')) or ( 'no' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'No')) or ( 'yes' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'Yes')) or ( LOWER(LeaveTypeColorPending) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)) or ( LOWER(LeaveTypeColorApproved) like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext)))");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leavetypewwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leavetypewwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeName) like LOWER(:lV53Leavetypewwds_2_tfleavetypename))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leavetypewwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeName = ( :AV54Leavetypewwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LeaveTypeName))=0))");
         }
         if ( AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Leavetypewwds_4_tfleavetypevacationleave_sels, "LeaveTypeVacationLeave IN (", ")")+")");
         }
         if ( AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels, "LeaveTypeLoggingWorkHours IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Leavetypewwds_7_tfleavetypecolorpending_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leavetypewwds_6_tfleavetypecolorpending)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeColorPending) like LOWER(:lV57Leavetypewwds_6_tfleavetypecolorpending))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leavetypewwds_7_tfleavetypecolorpending_sel)) && ! ( StringUtil.StrCmp(AV58Leavetypewwds_7_tfleavetypecolorpending_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeColorPending = ( :AV58Leavetypewwds_7_tfleavetypecolorpending_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV58Leavetypewwds_7_tfleavetypecolorpending_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LeaveTypeColorPending IS NULL or (char_length(trim(trailing ' ' from LeaveTypeColorPending))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leavetypewwds_9_tfleavetypecolorapproved_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leavetypewwds_8_tfleavetypecolorapproved)) ) )
         {
            AddWhere(sWhereString, "(LOWER(LeaveTypeColorApproved) like LOWER(:lV59Leavetypewwds_8_tfleavetypecolorapproved))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leavetypewwds_9_tfleavetypecolorapproved_sel)) && ! ( StringUtil.StrCmp(AV60Leavetypewwds_9_tfleavetypecolorapproved_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeColorApproved = ( :AV60Leavetypewwds_9_tfleavetypecolorapproved_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leavetypewwds_9_tfleavetypecolorapproved_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LeaveTypeColorApproved IS NULL or (char_length(trim(trailing ' ' from LeaveTypeColorApproved))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LeaveTypeColorApproved";
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
                     return conditional_P005C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
               case 1 :
                     return conditional_P005C3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
               case 2 :
                     return conditional_P005C4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
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
          Object[] prmP005C2;
          prmP005C2 = new Object[] {
          new ParDef("AV61Udparg10",GXType.Int64,10,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leavetypewwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leavetypewwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV57Leavetypewwds_6_tfleavetypecolorpending",GXType.Char,20,0) ,
          new ParDef("AV58Leavetypewwds_7_tfleavetypecolorpending_sel",GXType.Char,20,0) ,
          new ParDef("lV59Leavetypewwds_8_tfleavetypecolorapproved",GXType.Char,20,0) ,
          new ParDef("AV60Leavetypewwds_9_tfleavetypecolorapproved_sel",GXType.Char,20,0)
          };
          Object[] prmP005C3;
          prmP005C3 = new Object[] {
          new ParDef("AV64Udparg11",GXType.Int64,10,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leavetypewwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leavetypewwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV57Leavetypewwds_6_tfleavetypecolorpending",GXType.Char,20,0) ,
          new ParDef("AV58Leavetypewwds_7_tfleavetypecolorpending_sel",GXType.Char,20,0) ,
          new ParDef("lV59Leavetypewwds_8_tfleavetypecolorapproved",GXType.Char,20,0) ,
          new ParDef("AV60Leavetypewwds_9_tfleavetypecolorapproved_sel",GXType.Char,20,0)
          };
          Object[] prmP005C4;
          prmP005C4 = new Object[] {
          new ParDef("AV67Udparg12",GXType.Int64,10,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leavetypewwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leavetypewwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV57Leavetypewwds_6_tfleavetypecolorpending",GXType.Char,20,0) ,
          new ParDef("AV58Leavetypewwds_7_tfleavetypecolorpending_sel",GXType.Char,20,0) ,
          new ParDef("lV59Leavetypewwds_8_tfleavetypecolorapproved",GXType.Char,20,0) ,
          new ParDef("AV60Leavetypewwds_9_tfleavetypecolorapproved_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 20);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 100);
                ((string[]) buf[6])[0] = rslt.getString(5, 20);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 100);
                ((string[]) buf[6])[0] = rslt.getString(5, 20);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
