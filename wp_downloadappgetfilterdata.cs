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
   public class wp_downloadappgetfilterdata : GXProcedure
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
            return "wp_downloadapp_Services_Execute" ;
         }

      }

      public wp_downloadappgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_downloadappgetfilterdata( IGxContext context )
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
         this.AV53DDOName = aP0_DDOName;
         this.AV54SearchTxtParms = aP1_SearchTxtParms;
         this.AV55SearchTxtTo = aP2_SearchTxtTo;
         this.AV56OptionsJson = "" ;
         this.AV57OptionsDescJson = "" ;
         this.AV58OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV56OptionsJson;
         aP4_OptionsDescJson=this.AV57OptionsDescJson;
         aP5_OptionIndexesJson=this.AV58OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV58OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV53DDOName = aP0_DDOName;
         this.AV54SearchTxtParms = aP1_SearchTxtParms;
         this.AV55SearchTxtTo = aP2_SearchTxtTo;
         this.AV56OptionsJson = "" ;
         this.AV57OptionsDescJson = "" ;
         this.AV58OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV56OptionsJson;
         aP4_OptionsDescJson=this.AV57OptionsDescJson;
         aP5_OptionIndexesJson=this.AV58OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV43Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV45OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV46OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40MaxItems = 10;
         AV39PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV54SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV54SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV37SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV54SearchTxtParms)) ? "" : StringUtil.Substring( AV54SearchTxtParms, 3, -1));
         AV38SkipItems = (short)(AV39PageIndex*AV40MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_EMPLOYEEFIRSTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEEFIRSTNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_EMPLOYEELASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEELASTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_EMPLOYEEEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEEEMAILOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_COMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMPANYNAMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_GAMUSERGUID") == 0 )
         {
            /* Execute user subroutine: 'LOADGAMUSERGUIDOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_EMPLOYEEAPIPASSWORD") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEEAPIPASSWORDOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV56OptionsJson = AV43Options.ToJSonString(false);
         AV57OptionsDescJson = AV45OptionsDesc.ToJSonString(false);
         AV58OptionIndexesJson = AV46OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV48Session.Get("WP_DownloadAppGridState"), "") == 0 )
         {
            AV50GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WP_DownloadAppGridState"), null, "", "");
         }
         else
         {
            AV50GridState.FromXml(AV48Session.Get("WP_DownloadAppGridState"), null, "", "");
         }
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV50GridState.gxTpr_Filtervalues.Count )
         {
            AV51GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV50GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV59FilterFullText = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEID") == 0 )
            {
               AV11TFEmployeeId = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME") == 0 )
            {
               AV13TFEmployeeFirstName = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME_SEL") == 0 )
            {
               AV14TFEmployeeFirstName_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEELASTNAME") == 0 )
            {
               AV15TFEmployeeLastName = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEELASTNAME_SEL") == 0 )
            {
               AV16TFEmployeeLastName_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV17TFEmployeeName = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV18TFEmployeeName_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV19TFEmployeeEmail = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV20TFEmployeeEmail_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCOMPANYID") == 0 )
            {
               AV21TFCompanyId = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV22TFCompanyId_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME") == 0 )
            {
               AV23TFCompanyName = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME_SEL") == 0 )
            {
               AV24TFCompanyName_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV25TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFGAMUSERGUID") == 0 )
            {
               AV26TFGAMUserGUID = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFGAMUSERGUID_SEL") == 0 )
            {
               AV27TFGAMUserGUID_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV28TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEVACTIONDAYS") == 0 )
            {
               AV29TFEmployeeVactionDays = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV30TFEmployeeVactionDays_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEVACATIONDAYSSETDATE") == 0 )
            {
               AV31TFEmployeeVacationDaysSetDate = context.localUtil.CToD( AV51GridStateFilterValue.gxTpr_Value, 2);
               AV32TFEmployeeVacationDaysSetDate_To = context.localUtil.CToD( AV51GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEAPIPASSWORD") == 0 )
            {
               AV33TFEmployeeAPIPassword = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEAPIPASSWORD_SEL") == 0 )
            {
               AV34TFEmployeeAPIPassword_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEBALANCE") == 0 )
            {
               AV35TFEmployeeBalance = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV36TFEmployeeBalance_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPLOYEEFIRSTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFEmployeeFirstName = AV37SearchTxt;
         AV14TFEmployeeFirstName_Sel = "";
         AV62Wp_downloadappds_1_filterfulltext = AV59FilterFullText;
         AV63Wp_downloadappds_2_tfemployeeid = AV11TFEmployeeId;
         AV64Wp_downloadappds_3_tfemployeeid_to = AV12TFEmployeeId_To;
         AV65Wp_downloadappds_4_tfemployeefirstname = AV13TFEmployeeFirstName;
         AV66Wp_downloadappds_5_tfemployeefirstname_sel = AV14TFEmployeeFirstName_Sel;
         AV67Wp_downloadappds_6_tfemployeelastname = AV15TFEmployeeLastName;
         AV68Wp_downloadappds_7_tfemployeelastname_sel = AV16TFEmployeeLastName_Sel;
         AV69Wp_downloadappds_8_tfemployeename = AV17TFEmployeeName;
         AV70Wp_downloadappds_9_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV71Wp_downloadappds_10_tfemployeeemail = AV19TFEmployeeEmail;
         AV72Wp_downloadappds_11_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV73Wp_downloadappds_12_tfcompanyid = AV21TFCompanyId;
         AV74Wp_downloadappds_13_tfcompanyid_to = AV22TFCompanyId_To;
         AV75Wp_downloadappds_14_tfcompanyname = AV23TFCompanyName;
         AV76Wp_downloadappds_15_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV77Wp_downloadappds_16_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV78Wp_downloadappds_17_tfgamuserguid = AV26TFGAMUserGUID;
         AV79Wp_downloadappds_18_tfgamuserguid_sel = AV27TFGAMUserGUID_Sel;
         AV80Wp_downloadappds_19_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV81Wp_downloadappds_20_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV82Wp_downloadappds_21_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         AV83Wp_downloadappds_22_tfemployeevacationdayssetdate = AV31TFEmployeeVacationDaysSetDate;
         AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to = AV32TFEmployeeVacationDaysSetDate_To;
         AV85Wp_downloadappds_24_tfemployeeapipassword = AV33TFEmployeeAPIPassword;
         AV86Wp_downloadappds_25_tfemployeeapipassword_sel = AV34TFEmployeeAPIPassword_Sel;
         AV87Wp_downloadappds_26_tfemployeebalance = AV35TFEmployeeBalance;
         AV88Wp_downloadappds_27_tfemployeebalance_to = AV36TFEmployeeBalance_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV62Wp_downloadappds_1_filterfulltext ,
                                              AV63Wp_downloadappds_2_tfemployeeid ,
                                              AV64Wp_downloadappds_3_tfemployeeid_to ,
                                              AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                              AV65Wp_downloadappds_4_tfemployeefirstname ,
                                              AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                              AV67Wp_downloadappds_6_tfemployeelastname ,
                                              AV70Wp_downloadappds_9_tfemployeename_sel ,
                                              AV69Wp_downloadappds_8_tfemployeename ,
                                              AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                              AV71Wp_downloadappds_10_tfemployeeemail ,
                                              AV73Wp_downloadappds_12_tfcompanyid ,
                                              AV74Wp_downloadappds_13_tfcompanyid_to ,
                                              AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                              AV75Wp_downloadappds_14_tfcompanyname ,
                                              AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                              AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                              AV78Wp_downloadappds_17_tfgamuserguid ,
                                              AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                              AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                              AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                              AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                              AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                              AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                              AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                              AV87Wp_downloadappds_26_tfemployeebalance ,
                                              AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A108EmployeeLastName ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A100CompanyId ,
                                              A101CompanyName ,
                                              A111GAMUserGUID ,
                                              A146EmployeeVactionDays ,
                                              A188EmployeeAPIPassword ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A178EmployeeVacationDaysSetDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV65Wp_downloadappds_4_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname), 100, "%");
         lV67Wp_downloadappds_6_tfemployeelastname = StringUtil.PadR( StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname), 100, "%");
         lV69Wp_downloadappds_8_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename), 100, "%");
         lV71Wp_downloadappds_10_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail), "%", "");
         lV75Wp_downloadappds_14_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname), 100, "%");
         lV78Wp_downloadappds_17_tfgamuserguid = StringUtil.Concat( StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid), "%", "");
         lV85Wp_downloadappds_24_tfemployeeapipassword = StringUtil.Concat( StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword), "%", "");
         /* Using cursor P00CL2 */
         pr_default.execute(0, new Object[] {lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, AV63Wp_downloadappds_2_tfemployeeid, AV64Wp_downloadappds_3_tfemployeeid_to, lV65Wp_downloadappds_4_tfemployeefirstname, AV66Wp_downloadappds_5_tfemployeefirstname_sel, lV67Wp_downloadappds_6_tfemployeelastname, AV68Wp_downloadappds_7_tfemployeelastname_sel, lV69Wp_downloadappds_8_tfemployeename, AV70Wp_downloadappds_9_tfemployeename_sel, lV71Wp_downloadappds_10_tfemployeeemail, AV72Wp_downloadappds_11_tfemployeeemail_sel, AV73Wp_downloadappds_12_tfcompanyid, AV74Wp_downloadappds_13_tfcompanyid_to, lV75Wp_downloadappds_14_tfcompanyname, AV76Wp_downloadappds_15_tfcompanyname_sel, lV78Wp_downloadappds_17_tfgamuserguid, AV79Wp_downloadappds_18_tfgamuserguid_sel, AV81Wp_downloadappds_20_tfemployeevactiondays, AV82Wp_downloadappds_21_tfemployeevactiondays_to, AV83Wp_downloadappds_22_tfemployeevacationdayssetdate, AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to, lV85Wp_downloadappds_24_tfemployeeapipassword, AV86Wp_downloadappds_25_tfemployeeapipassword_sel, AV87Wp_downloadappds_26_tfemployeebalance, AV88Wp_downloadappds_27_tfemployeebalance_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCL2 = false;
            A107EmployeeFirstName = P00CL2_A107EmployeeFirstName[0];
            A147EmployeeBalance = P00CL2_A147EmployeeBalance[0];
            A188EmployeeAPIPassword = P00CL2_A188EmployeeAPIPassword[0];
            A178EmployeeVacationDaysSetDate = P00CL2_A178EmployeeVacationDaysSetDate[0];
            A146EmployeeVactionDays = P00CL2_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P00CL2_A112EmployeeIsActive[0];
            A111GAMUserGUID = P00CL2_A111GAMUserGUID[0];
            A110EmployeeIsManager = P00CL2_A110EmployeeIsManager[0];
            A101CompanyName = P00CL2_A101CompanyName[0];
            A100CompanyId = P00CL2_A100CompanyId[0];
            A109EmployeeEmail = P00CL2_A109EmployeeEmail[0];
            A148EmployeeName = P00CL2_A148EmployeeName[0];
            A108EmployeeLastName = P00CL2_A108EmployeeLastName[0];
            A106EmployeeId = P00CL2_A106EmployeeId[0];
            A101CompanyName = P00CL2_A101CompanyName[0];
            AV47count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CL2_A107EmployeeFirstName[0], A107EmployeeFirstName) == 0 ) )
            {
               BRKCL2 = false;
               A106EmployeeId = P00CL2_A106EmployeeId[0];
               AV47count = (long)(AV47count+1);
               BRKCL2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV38SkipItems) )
            {
               AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A107EmployeeFirstName)) ? "<#Empty#>" : A107EmployeeFirstName);
               AV43Options.Add(AV42Option, 0);
               AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV43Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV38SkipItems = (short)(AV38SkipItems-1);
            }
            if ( ! BRKCL2 )
            {
               BRKCL2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADEMPLOYEELASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFEmployeeLastName = AV37SearchTxt;
         AV16TFEmployeeLastName_Sel = "";
         AV62Wp_downloadappds_1_filterfulltext = AV59FilterFullText;
         AV63Wp_downloadappds_2_tfemployeeid = AV11TFEmployeeId;
         AV64Wp_downloadappds_3_tfemployeeid_to = AV12TFEmployeeId_To;
         AV65Wp_downloadappds_4_tfemployeefirstname = AV13TFEmployeeFirstName;
         AV66Wp_downloadappds_5_tfemployeefirstname_sel = AV14TFEmployeeFirstName_Sel;
         AV67Wp_downloadappds_6_tfemployeelastname = AV15TFEmployeeLastName;
         AV68Wp_downloadappds_7_tfemployeelastname_sel = AV16TFEmployeeLastName_Sel;
         AV69Wp_downloadappds_8_tfemployeename = AV17TFEmployeeName;
         AV70Wp_downloadappds_9_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV71Wp_downloadappds_10_tfemployeeemail = AV19TFEmployeeEmail;
         AV72Wp_downloadappds_11_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV73Wp_downloadappds_12_tfcompanyid = AV21TFCompanyId;
         AV74Wp_downloadappds_13_tfcompanyid_to = AV22TFCompanyId_To;
         AV75Wp_downloadappds_14_tfcompanyname = AV23TFCompanyName;
         AV76Wp_downloadappds_15_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV77Wp_downloadappds_16_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV78Wp_downloadappds_17_tfgamuserguid = AV26TFGAMUserGUID;
         AV79Wp_downloadappds_18_tfgamuserguid_sel = AV27TFGAMUserGUID_Sel;
         AV80Wp_downloadappds_19_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV81Wp_downloadappds_20_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV82Wp_downloadappds_21_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         AV83Wp_downloadappds_22_tfemployeevacationdayssetdate = AV31TFEmployeeVacationDaysSetDate;
         AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to = AV32TFEmployeeVacationDaysSetDate_To;
         AV85Wp_downloadappds_24_tfemployeeapipassword = AV33TFEmployeeAPIPassword;
         AV86Wp_downloadappds_25_tfemployeeapipassword_sel = AV34TFEmployeeAPIPassword_Sel;
         AV87Wp_downloadappds_26_tfemployeebalance = AV35TFEmployeeBalance;
         AV88Wp_downloadappds_27_tfemployeebalance_to = AV36TFEmployeeBalance_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV62Wp_downloadappds_1_filterfulltext ,
                                              AV63Wp_downloadappds_2_tfemployeeid ,
                                              AV64Wp_downloadappds_3_tfemployeeid_to ,
                                              AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                              AV65Wp_downloadappds_4_tfemployeefirstname ,
                                              AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                              AV67Wp_downloadappds_6_tfemployeelastname ,
                                              AV70Wp_downloadappds_9_tfemployeename_sel ,
                                              AV69Wp_downloadappds_8_tfemployeename ,
                                              AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                              AV71Wp_downloadappds_10_tfemployeeemail ,
                                              AV73Wp_downloadappds_12_tfcompanyid ,
                                              AV74Wp_downloadappds_13_tfcompanyid_to ,
                                              AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                              AV75Wp_downloadappds_14_tfcompanyname ,
                                              AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                              AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                              AV78Wp_downloadappds_17_tfgamuserguid ,
                                              AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                              AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                              AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                              AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                              AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                              AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                              AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                              AV87Wp_downloadappds_26_tfemployeebalance ,
                                              AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A108EmployeeLastName ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A100CompanyId ,
                                              A101CompanyName ,
                                              A111GAMUserGUID ,
                                              A146EmployeeVactionDays ,
                                              A188EmployeeAPIPassword ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A178EmployeeVacationDaysSetDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV65Wp_downloadappds_4_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname), 100, "%");
         lV67Wp_downloadappds_6_tfemployeelastname = StringUtil.PadR( StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname), 100, "%");
         lV69Wp_downloadappds_8_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename), 100, "%");
         lV71Wp_downloadappds_10_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail), "%", "");
         lV75Wp_downloadappds_14_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname), 100, "%");
         lV78Wp_downloadappds_17_tfgamuserguid = StringUtil.Concat( StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid), "%", "");
         lV85Wp_downloadappds_24_tfemployeeapipassword = StringUtil.Concat( StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword), "%", "");
         /* Using cursor P00CL3 */
         pr_default.execute(1, new Object[] {lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, AV63Wp_downloadappds_2_tfemployeeid, AV64Wp_downloadappds_3_tfemployeeid_to, lV65Wp_downloadappds_4_tfemployeefirstname, AV66Wp_downloadappds_5_tfemployeefirstname_sel, lV67Wp_downloadappds_6_tfemployeelastname, AV68Wp_downloadappds_7_tfemployeelastname_sel, lV69Wp_downloadappds_8_tfemployeename, AV70Wp_downloadappds_9_tfemployeename_sel, lV71Wp_downloadappds_10_tfemployeeemail, AV72Wp_downloadappds_11_tfemployeeemail_sel, AV73Wp_downloadappds_12_tfcompanyid, AV74Wp_downloadappds_13_tfcompanyid_to, lV75Wp_downloadappds_14_tfcompanyname, AV76Wp_downloadappds_15_tfcompanyname_sel, lV78Wp_downloadappds_17_tfgamuserguid, AV79Wp_downloadappds_18_tfgamuserguid_sel, AV81Wp_downloadappds_20_tfemployeevactiondays, AV82Wp_downloadappds_21_tfemployeevactiondays_to, AV83Wp_downloadappds_22_tfemployeevacationdayssetdate, AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to, lV85Wp_downloadappds_24_tfemployeeapipassword, AV86Wp_downloadappds_25_tfemployeeapipassword_sel, AV87Wp_downloadappds_26_tfemployeebalance, AV88Wp_downloadappds_27_tfemployeebalance_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKCL4 = false;
            A108EmployeeLastName = P00CL3_A108EmployeeLastName[0];
            A147EmployeeBalance = P00CL3_A147EmployeeBalance[0];
            A188EmployeeAPIPassword = P00CL3_A188EmployeeAPIPassword[0];
            A178EmployeeVacationDaysSetDate = P00CL3_A178EmployeeVacationDaysSetDate[0];
            A146EmployeeVactionDays = P00CL3_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P00CL3_A112EmployeeIsActive[0];
            A111GAMUserGUID = P00CL3_A111GAMUserGUID[0];
            A110EmployeeIsManager = P00CL3_A110EmployeeIsManager[0];
            A101CompanyName = P00CL3_A101CompanyName[0];
            A100CompanyId = P00CL3_A100CompanyId[0];
            A109EmployeeEmail = P00CL3_A109EmployeeEmail[0];
            A148EmployeeName = P00CL3_A148EmployeeName[0];
            A107EmployeeFirstName = P00CL3_A107EmployeeFirstName[0];
            A106EmployeeId = P00CL3_A106EmployeeId[0];
            A101CompanyName = P00CL3_A101CompanyName[0];
            AV47count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00CL3_A108EmployeeLastName[0], A108EmployeeLastName) == 0 ) )
            {
               BRKCL4 = false;
               A106EmployeeId = P00CL3_A106EmployeeId[0];
               AV47count = (long)(AV47count+1);
               BRKCL4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV38SkipItems) )
            {
               AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A108EmployeeLastName)) ? "<#Empty#>" : A108EmployeeLastName);
               AV43Options.Add(AV42Option, 0);
               AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV43Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV38SkipItems = (short)(AV38SkipItems-1);
            }
            if ( ! BRKCL4 )
            {
               BRKCL4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFEmployeeName = AV37SearchTxt;
         AV18TFEmployeeName_Sel = "";
         AV62Wp_downloadappds_1_filterfulltext = AV59FilterFullText;
         AV63Wp_downloadappds_2_tfemployeeid = AV11TFEmployeeId;
         AV64Wp_downloadappds_3_tfemployeeid_to = AV12TFEmployeeId_To;
         AV65Wp_downloadappds_4_tfemployeefirstname = AV13TFEmployeeFirstName;
         AV66Wp_downloadappds_5_tfemployeefirstname_sel = AV14TFEmployeeFirstName_Sel;
         AV67Wp_downloadappds_6_tfemployeelastname = AV15TFEmployeeLastName;
         AV68Wp_downloadappds_7_tfemployeelastname_sel = AV16TFEmployeeLastName_Sel;
         AV69Wp_downloadappds_8_tfemployeename = AV17TFEmployeeName;
         AV70Wp_downloadappds_9_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV71Wp_downloadappds_10_tfemployeeemail = AV19TFEmployeeEmail;
         AV72Wp_downloadappds_11_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV73Wp_downloadappds_12_tfcompanyid = AV21TFCompanyId;
         AV74Wp_downloadappds_13_tfcompanyid_to = AV22TFCompanyId_To;
         AV75Wp_downloadappds_14_tfcompanyname = AV23TFCompanyName;
         AV76Wp_downloadappds_15_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV77Wp_downloadappds_16_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV78Wp_downloadappds_17_tfgamuserguid = AV26TFGAMUserGUID;
         AV79Wp_downloadappds_18_tfgamuserguid_sel = AV27TFGAMUserGUID_Sel;
         AV80Wp_downloadappds_19_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV81Wp_downloadappds_20_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV82Wp_downloadappds_21_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         AV83Wp_downloadappds_22_tfemployeevacationdayssetdate = AV31TFEmployeeVacationDaysSetDate;
         AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to = AV32TFEmployeeVacationDaysSetDate_To;
         AV85Wp_downloadappds_24_tfemployeeapipassword = AV33TFEmployeeAPIPassword;
         AV86Wp_downloadappds_25_tfemployeeapipassword_sel = AV34TFEmployeeAPIPassword_Sel;
         AV87Wp_downloadappds_26_tfemployeebalance = AV35TFEmployeeBalance;
         AV88Wp_downloadappds_27_tfemployeebalance_to = AV36TFEmployeeBalance_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV62Wp_downloadappds_1_filterfulltext ,
                                              AV63Wp_downloadappds_2_tfemployeeid ,
                                              AV64Wp_downloadappds_3_tfemployeeid_to ,
                                              AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                              AV65Wp_downloadappds_4_tfemployeefirstname ,
                                              AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                              AV67Wp_downloadappds_6_tfemployeelastname ,
                                              AV70Wp_downloadappds_9_tfemployeename_sel ,
                                              AV69Wp_downloadappds_8_tfemployeename ,
                                              AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                              AV71Wp_downloadappds_10_tfemployeeemail ,
                                              AV73Wp_downloadappds_12_tfcompanyid ,
                                              AV74Wp_downloadappds_13_tfcompanyid_to ,
                                              AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                              AV75Wp_downloadappds_14_tfcompanyname ,
                                              AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                              AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                              AV78Wp_downloadappds_17_tfgamuserguid ,
                                              AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                              AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                              AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                              AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                              AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                              AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                              AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                              AV87Wp_downloadappds_26_tfemployeebalance ,
                                              AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A108EmployeeLastName ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A100CompanyId ,
                                              A101CompanyName ,
                                              A111GAMUserGUID ,
                                              A146EmployeeVactionDays ,
                                              A188EmployeeAPIPassword ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A178EmployeeVacationDaysSetDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV65Wp_downloadappds_4_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname), 100, "%");
         lV67Wp_downloadappds_6_tfemployeelastname = StringUtil.PadR( StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname), 100, "%");
         lV69Wp_downloadappds_8_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename), 100, "%");
         lV71Wp_downloadappds_10_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail), "%", "");
         lV75Wp_downloadappds_14_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname), 100, "%");
         lV78Wp_downloadappds_17_tfgamuserguid = StringUtil.Concat( StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid), "%", "");
         lV85Wp_downloadappds_24_tfemployeeapipassword = StringUtil.Concat( StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword), "%", "");
         /* Using cursor P00CL4 */
         pr_default.execute(2, new Object[] {lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, AV63Wp_downloadappds_2_tfemployeeid, AV64Wp_downloadappds_3_tfemployeeid_to, lV65Wp_downloadappds_4_tfemployeefirstname, AV66Wp_downloadappds_5_tfemployeefirstname_sel, lV67Wp_downloadappds_6_tfemployeelastname, AV68Wp_downloadappds_7_tfemployeelastname_sel, lV69Wp_downloadappds_8_tfemployeename, AV70Wp_downloadappds_9_tfemployeename_sel, lV71Wp_downloadappds_10_tfemployeeemail, AV72Wp_downloadappds_11_tfemployeeemail_sel, AV73Wp_downloadappds_12_tfcompanyid, AV74Wp_downloadappds_13_tfcompanyid_to, lV75Wp_downloadappds_14_tfcompanyname, AV76Wp_downloadappds_15_tfcompanyname_sel, lV78Wp_downloadappds_17_tfgamuserguid, AV79Wp_downloadappds_18_tfgamuserguid_sel, AV81Wp_downloadappds_20_tfemployeevactiondays, AV82Wp_downloadappds_21_tfemployeevactiondays_to, AV83Wp_downloadappds_22_tfemployeevacationdayssetdate, AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to, lV85Wp_downloadappds_24_tfemployeeapipassword, AV86Wp_downloadappds_25_tfemployeeapipassword_sel, AV87Wp_downloadappds_26_tfemployeebalance, AV88Wp_downloadappds_27_tfemployeebalance_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKCL6 = false;
            A148EmployeeName = P00CL4_A148EmployeeName[0];
            A147EmployeeBalance = P00CL4_A147EmployeeBalance[0];
            A188EmployeeAPIPassword = P00CL4_A188EmployeeAPIPassword[0];
            A178EmployeeVacationDaysSetDate = P00CL4_A178EmployeeVacationDaysSetDate[0];
            A146EmployeeVactionDays = P00CL4_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P00CL4_A112EmployeeIsActive[0];
            A111GAMUserGUID = P00CL4_A111GAMUserGUID[0];
            A110EmployeeIsManager = P00CL4_A110EmployeeIsManager[0];
            A101CompanyName = P00CL4_A101CompanyName[0];
            A100CompanyId = P00CL4_A100CompanyId[0];
            A109EmployeeEmail = P00CL4_A109EmployeeEmail[0];
            A108EmployeeLastName = P00CL4_A108EmployeeLastName[0];
            A107EmployeeFirstName = P00CL4_A107EmployeeFirstName[0];
            A106EmployeeId = P00CL4_A106EmployeeId[0];
            A101CompanyName = P00CL4_A101CompanyName[0];
            AV47count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00CL4_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRKCL6 = false;
               A106EmployeeId = P00CL4_A106EmployeeId[0];
               AV47count = (long)(AV47count+1);
               BRKCL6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV38SkipItems) )
            {
               AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
               AV43Options.Add(AV42Option, 0);
               AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV43Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV38SkipItems = (short)(AV38SkipItems-1);
            }
            if ( ! BRKCL6 )
            {
               BRKCL6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADEMPLOYEEEMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFEmployeeEmail = AV37SearchTxt;
         AV20TFEmployeeEmail_Sel = "";
         AV62Wp_downloadappds_1_filterfulltext = AV59FilterFullText;
         AV63Wp_downloadappds_2_tfemployeeid = AV11TFEmployeeId;
         AV64Wp_downloadappds_3_tfemployeeid_to = AV12TFEmployeeId_To;
         AV65Wp_downloadappds_4_tfemployeefirstname = AV13TFEmployeeFirstName;
         AV66Wp_downloadappds_5_tfemployeefirstname_sel = AV14TFEmployeeFirstName_Sel;
         AV67Wp_downloadappds_6_tfemployeelastname = AV15TFEmployeeLastName;
         AV68Wp_downloadappds_7_tfemployeelastname_sel = AV16TFEmployeeLastName_Sel;
         AV69Wp_downloadappds_8_tfemployeename = AV17TFEmployeeName;
         AV70Wp_downloadappds_9_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV71Wp_downloadappds_10_tfemployeeemail = AV19TFEmployeeEmail;
         AV72Wp_downloadappds_11_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV73Wp_downloadappds_12_tfcompanyid = AV21TFCompanyId;
         AV74Wp_downloadappds_13_tfcompanyid_to = AV22TFCompanyId_To;
         AV75Wp_downloadappds_14_tfcompanyname = AV23TFCompanyName;
         AV76Wp_downloadappds_15_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV77Wp_downloadappds_16_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV78Wp_downloadappds_17_tfgamuserguid = AV26TFGAMUserGUID;
         AV79Wp_downloadappds_18_tfgamuserguid_sel = AV27TFGAMUserGUID_Sel;
         AV80Wp_downloadappds_19_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV81Wp_downloadappds_20_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV82Wp_downloadappds_21_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         AV83Wp_downloadappds_22_tfemployeevacationdayssetdate = AV31TFEmployeeVacationDaysSetDate;
         AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to = AV32TFEmployeeVacationDaysSetDate_To;
         AV85Wp_downloadappds_24_tfemployeeapipassword = AV33TFEmployeeAPIPassword;
         AV86Wp_downloadappds_25_tfemployeeapipassword_sel = AV34TFEmployeeAPIPassword_Sel;
         AV87Wp_downloadappds_26_tfemployeebalance = AV35TFEmployeeBalance;
         AV88Wp_downloadappds_27_tfemployeebalance_to = AV36TFEmployeeBalance_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV62Wp_downloadappds_1_filterfulltext ,
                                              AV63Wp_downloadappds_2_tfemployeeid ,
                                              AV64Wp_downloadappds_3_tfemployeeid_to ,
                                              AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                              AV65Wp_downloadappds_4_tfemployeefirstname ,
                                              AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                              AV67Wp_downloadappds_6_tfemployeelastname ,
                                              AV70Wp_downloadappds_9_tfemployeename_sel ,
                                              AV69Wp_downloadappds_8_tfemployeename ,
                                              AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                              AV71Wp_downloadappds_10_tfemployeeemail ,
                                              AV73Wp_downloadappds_12_tfcompanyid ,
                                              AV74Wp_downloadappds_13_tfcompanyid_to ,
                                              AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                              AV75Wp_downloadappds_14_tfcompanyname ,
                                              AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                              AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                              AV78Wp_downloadappds_17_tfgamuserguid ,
                                              AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                              AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                              AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                              AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                              AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                              AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                              AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                              AV87Wp_downloadappds_26_tfemployeebalance ,
                                              AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A108EmployeeLastName ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A100CompanyId ,
                                              A101CompanyName ,
                                              A111GAMUserGUID ,
                                              A146EmployeeVactionDays ,
                                              A188EmployeeAPIPassword ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A178EmployeeVacationDaysSetDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV65Wp_downloadappds_4_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname), 100, "%");
         lV67Wp_downloadappds_6_tfemployeelastname = StringUtil.PadR( StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname), 100, "%");
         lV69Wp_downloadappds_8_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename), 100, "%");
         lV71Wp_downloadappds_10_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail), "%", "");
         lV75Wp_downloadappds_14_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname), 100, "%");
         lV78Wp_downloadappds_17_tfgamuserguid = StringUtil.Concat( StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid), "%", "");
         lV85Wp_downloadappds_24_tfemployeeapipassword = StringUtil.Concat( StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword), "%", "");
         /* Using cursor P00CL5 */
         pr_default.execute(3, new Object[] {lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, AV63Wp_downloadappds_2_tfemployeeid, AV64Wp_downloadappds_3_tfemployeeid_to, lV65Wp_downloadappds_4_tfemployeefirstname, AV66Wp_downloadappds_5_tfemployeefirstname_sel, lV67Wp_downloadappds_6_tfemployeelastname, AV68Wp_downloadappds_7_tfemployeelastname_sel, lV69Wp_downloadappds_8_tfemployeename, AV70Wp_downloadappds_9_tfemployeename_sel, lV71Wp_downloadappds_10_tfemployeeemail, AV72Wp_downloadappds_11_tfemployeeemail_sel, AV73Wp_downloadappds_12_tfcompanyid, AV74Wp_downloadappds_13_tfcompanyid_to, lV75Wp_downloadappds_14_tfcompanyname, AV76Wp_downloadappds_15_tfcompanyname_sel, lV78Wp_downloadappds_17_tfgamuserguid, AV79Wp_downloadappds_18_tfgamuserguid_sel, AV81Wp_downloadappds_20_tfemployeevactiondays, AV82Wp_downloadappds_21_tfemployeevactiondays_to, AV83Wp_downloadappds_22_tfemployeevacationdayssetdate, AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to, lV85Wp_downloadappds_24_tfemployeeapipassword, AV86Wp_downloadappds_25_tfemployeeapipassword_sel, AV87Wp_downloadappds_26_tfemployeebalance, AV88Wp_downloadappds_27_tfemployeebalance_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKCL8 = false;
            A109EmployeeEmail = P00CL5_A109EmployeeEmail[0];
            A147EmployeeBalance = P00CL5_A147EmployeeBalance[0];
            A188EmployeeAPIPassword = P00CL5_A188EmployeeAPIPassword[0];
            A178EmployeeVacationDaysSetDate = P00CL5_A178EmployeeVacationDaysSetDate[0];
            A146EmployeeVactionDays = P00CL5_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P00CL5_A112EmployeeIsActive[0];
            A111GAMUserGUID = P00CL5_A111GAMUserGUID[0];
            A110EmployeeIsManager = P00CL5_A110EmployeeIsManager[0];
            A101CompanyName = P00CL5_A101CompanyName[0];
            A100CompanyId = P00CL5_A100CompanyId[0];
            A148EmployeeName = P00CL5_A148EmployeeName[0];
            A108EmployeeLastName = P00CL5_A108EmployeeLastName[0];
            A107EmployeeFirstName = P00CL5_A107EmployeeFirstName[0];
            A106EmployeeId = P00CL5_A106EmployeeId[0];
            A101CompanyName = P00CL5_A101CompanyName[0];
            AV47count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00CL5_A109EmployeeEmail[0], A109EmployeeEmail) == 0 ) )
            {
               BRKCL8 = false;
               A106EmployeeId = P00CL5_A106EmployeeId[0];
               AV47count = (long)(AV47count+1);
               BRKCL8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV38SkipItems) )
            {
               AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) ? "<#Empty#>" : A109EmployeeEmail);
               AV43Options.Add(AV42Option, 0);
               AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV43Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV38SkipItems = (short)(AV38SkipItems-1);
            }
            if ( ! BRKCL8 )
            {
               BRKCL8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV23TFCompanyName = AV37SearchTxt;
         AV24TFCompanyName_Sel = "";
         AV62Wp_downloadappds_1_filterfulltext = AV59FilterFullText;
         AV63Wp_downloadappds_2_tfemployeeid = AV11TFEmployeeId;
         AV64Wp_downloadappds_3_tfemployeeid_to = AV12TFEmployeeId_To;
         AV65Wp_downloadappds_4_tfemployeefirstname = AV13TFEmployeeFirstName;
         AV66Wp_downloadappds_5_tfemployeefirstname_sel = AV14TFEmployeeFirstName_Sel;
         AV67Wp_downloadappds_6_tfemployeelastname = AV15TFEmployeeLastName;
         AV68Wp_downloadappds_7_tfemployeelastname_sel = AV16TFEmployeeLastName_Sel;
         AV69Wp_downloadappds_8_tfemployeename = AV17TFEmployeeName;
         AV70Wp_downloadappds_9_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV71Wp_downloadappds_10_tfemployeeemail = AV19TFEmployeeEmail;
         AV72Wp_downloadappds_11_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV73Wp_downloadappds_12_tfcompanyid = AV21TFCompanyId;
         AV74Wp_downloadappds_13_tfcompanyid_to = AV22TFCompanyId_To;
         AV75Wp_downloadappds_14_tfcompanyname = AV23TFCompanyName;
         AV76Wp_downloadappds_15_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV77Wp_downloadappds_16_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV78Wp_downloadappds_17_tfgamuserguid = AV26TFGAMUserGUID;
         AV79Wp_downloadappds_18_tfgamuserguid_sel = AV27TFGAMUserGUID_Sel;
         AV80Wp_downloadappds_19_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV81Wp_downloadappds_20_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV82Wp_downloadappds_21_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         AV83Wp_downloadappds_22_tfemployeevacationdayssetdate = AV31TFEmployeeVacationDaysSetDate;
         AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to = AV32TFEmployeeVacationDaysSetDate_To;
         AV85Wp_downloadappds_24_tfemployeeapipassword = AV33TFEmployeeAPIPassword;
         AV86Wp_downloadappds_25_tfemployeeapipassword_sel = AV34TFEmployeeAPIPassword_Sel;
         AV87Wp_downloadappds_26_tfemployeebalance = AV35TFEmployeeBalance;
         AV88Wp_downloadappds_27_tfemployeebalance_to = AV36TFEmployeeBalance_To;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV62Wp_downloadappds_1_filterfulltext ,
                                              AV63Wp_downloadappds_2_tfemployeeid ,
                                              AV64Wp_downloadappds_3_tfemployeeid_to ,
                                              AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                              AV65Wp_downloadappds_4_tfemployeefirstname ,
                                              AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                              AV67Wp_downloadappds_6_tfemployeelastname ,
                                              AV70Wp_downloadappds_9_tfemployeename_sel ,
                                              AV69Wp_downloadappds_8_tfemployeename ,
                                              AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                              AV71Wp_downloadappds_10_tfemployeeemail ,
                                              AV73Wp_downloadappds_12_tfcompanyid ,
                                              AV74Wp_downloadappds_13_tfcompanyid_to ,
                                              AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                              AV75Wp_downloadappds_14_tfcompanyname ,
                                              AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                              AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                              AV78Wp_downloadappds_17_tfgamuserguid ,
                                              AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                              AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                              AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                              AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                              AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                              AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                              AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                              AV87Wp_downloadappds_26_tfemployeebalance ,
                                              AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A108EmployeeLastName ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A100CompanyId ,
                                              A101CompanyName ,
                                              A111GAMUserGUID ,
                                              A146EmployeeVactionDays ,
                                              A188EmployeeAPIPassword ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A178EmployeeVacationDaysSetDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV65Wp_downloadappds_4_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname), 100, "%");
         lV67Wp_downloadappds_6_tfemployeelastname = StringUtil.PadR( StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname), 100, "%");
         lV69Wp_downloadappds_8_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename), 100, "%");
         lV71Wp_downloadappds_10_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail), "%", "");
         lV75Wp_downloadappds_14_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname), 100, "%");
         lV78Wp_downloadappds_17_tfgamuserguid = StringUtil.Concat( StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid), "%", "");
         lV85Wp_downloadappds_24_tfemployeeapipassword = StringUtil.Concat( StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword), "%", "");
         /* Using cursor P00CL6 */
         pr_default.execute(4, new Object[] {lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, AV63Wp_downloadappds_2_tfemployeeid, AV64Wp_downloadappds_3_tfemployeeid_to, lV65Wp_downloadappds_4_tfemployeefirstname, AV66Wp_downloadappds_5_tfemployeefirstname_sel, lV67Wp_downloadappds_6_tfemployeelastname, AV68Wp_downloadappds_7_tfemployeelastname_sel, lV69Wp_downloadappds_8_tfemployeename, AV70Wp_downloadappds_9_tfemployeename_sel, lV71Wp_downloadappds_10_tfemployeeemail, AV72Wp_downloadappds_11_tfemployeeemail_sel, AV73Wp_downloadappds_12_tfcompanyid, AV74Wp_downloadappds_13_tfcompanyid_to, lV75Wp_downloadappds_14_tfcompanyname, AV76Wp_downloadappds_15_tfcompanyname_sel, lV78Wp_downloadappds_17_tfgamuserguid, AV79Wp_downloadappds_18_tfgamuserguid_sel, AV81Wp_downloadappds_20_tfemployeevactiondays, AV82Wp_downloadappds_21_tfemployeevactiondays_to, AV83Wp_downloadappds_22_tfemployeevacationdayssetdate, AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to, lV85Wp_downloadappds_24_tfemployeeapipassword, AV86Wp_downloadappds_25_tfemployeeapipassword_sel, AV87Wp_downloadappds_26_tfemployeebalance, AV88Wp_downloadappds_27_tfemployeebalance_to});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKCL10 = false;
            A100CompanyId = P00CL6_A100CompanyId[0];
            A147EmployeeBalance = P00CL6_A147EmployeeBalance[0];
            A188EmployeeAPIPassword = P00CL6_A188EmployeeAPIPassword[0];
            A178EmployeeVacationDaysSetDate = P00CL6_A178EmployeeVacationDaysSetDate[0];
            A146EmployeeVactionDays = P00CL6_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P00CL6_A112EmployeeIsActive[0];
            A111GAMUserGUID = P00CL6_A111GAMUserGUID[0];
            A110EmployeeIsManager = P00CL6_A110EmployeeIsManager[0];
            A101CompanyName = P00CL6_A101CompanyName[0];
            A109EmployeeEmail = P00CL6_A109EmployeeEmail[0];
            A148EmployeeName = P00CL6_A148EmployeeName[0];
            A108EmployeeLastName = P00CL6_A108EmployeeLastName[0];
            A107EmployeeFirstName = P00CL6_A107EmployeeFirstName[0];
            A106EmployeeId = P00CL6_A106EmployeeId[0];
            A101CompanyName = P00CL6_A101CompanyName[0];
            AV47count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P00CL6_A100CompanyId[0] == A100CompanyId ) )
            {
               BRKCL10 = false;
               A106EmployeeId = P00CL6_A106EmployeeId[0];
               AV47count = (long)(AV47count+1);
               BRKCL10 = true;
               pr_default.readNext(4);
            }
            AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A101CompanyName)) ? "<#Empty#>" : A101CompanyName);
            AV41InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV42Option, "<#Empty#>") != 0 ) && ( AV41InsertIndex <= AV43Options.Count ) && ( ( StringUtil.StrCmp(((string)AV43Options.Item(AV41InsertIndex)), AV42Option) < 0 ) || ( StringUtil.StrCmp(((string)AV43Options.Item(AV41InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV41InsertIndex = (int)(AV41InsertIndex+1);
            }
            AV43Options.Add(AV42Option, AV41InsertIndex);
            AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), AV41InsertIndex);
            if ( AV43Options.Count == AV38SkipItems + 11 )
            {
               AV43Options.RemoveItem(AV43Options.Count);
               AV46OptionIndexes.RemoveItem(AV46OptionIndexes.Count);
            }
            if ( ! BRKCL10 )
            {
               BRKCL10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
         while ( AV38SkipItems > 0 )
         {
            AV43Options.RemoveItem(1);
            AV46OptionIndexes.RemoveItem(1);
            AV38SkipItems = (short)(AV38SkipItems-1);
         }
      }

      protected void S171( )
      {
         /* 'LOADGAMUSERGUIDOPTIONS' Routine */
         returnInSub = false;
         AV26TFGAMUserGUID = AV37SearchTxt;
         AV27TFGAMUserGUID_Sel = "";
         AV62Wp_downloadappds_1_filterfulltext = AV59FilterFullText;
         AV63Wp_downloadappds_2_tfemployeeid = AV11TFEmployeeId;
         AV64Wp_downloadappds_3_tfemployeeid_to = AV12TFEmployeeId_To;
         AV65Wp_downloadappds_4_tfemployeefirstname = AV13TFEmployeeFirstName;
         AV66Wp_downloadappds_5_tfemployeefirstname_sel = AV14TFEmployeeFirstName_Sel;
         AV67Wp_downloadappds_6_tfemployeelastname = AV15TFEmployeeLastName;
         AV68Wp_downloadappds_7_tfemployeelastname_sel = AV16TFEmployeeLastName_Sel;
         AV69Wp_downloadappds_8_tfemployeename = AV17TFEmployeeName;
         AV70Wp_downloadappds_9_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV71Wp_downloadappds_10_tfemployeeemail = AV19TFEmployeeEmail;
         AV72Wp_downloadappds_11_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV73Wp_downloadappds_12_tfcompanyid = AV21TFCompanyId;
         AV74Wp_downloadappds_13_tfcompanyid_to = AV22TFCompanyId_To;
         AV75Wp_downloadappds_14_tfcompanyname = AV23TFCompanyName;
         AV76Wp_downloadappds_15_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV77Wp_downloadappds_16_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV78Wp_downloadappds_17_tfgamuserguid = AV26TFGAMUserGUID;
         AV79Wp_downloadappds_18_tfgamuserguid_sel = AV27TFGAMUserGUID_Sel;
         AV80Wp_downloadappds_19_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV81Wp_downloadappds_20_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV82Wp_downloadappds_21_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         AV83Wp_downloadappds_22_tfemployeevacationdayssetdate = AV31TFEmployeeVacationDaysSetDate;
         AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to = AV32TFEmployeeVacationDaysSetDate_To;
         AV85Wp_downloadappds_24_tfemployeeapipassword = AV33TFEmployeeAPIPassword;
         AV86Wp_downloadappds_25_tfemployeeapipassword_sel = AV34TFEmployeeAPIPassword_Sel;
         AV87Wp_downloadappds_26_tfemployeebalance = AV35TFEmployeeBalance;
         AV88Wp_downloadappds_27_tfemployeebalance_to = AV36TFEmployeeBalance_To;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV62Wp_downloadappds_1_filterfulltext ,
                                              AV63Wp_downloadappds_2_tfemployeeid ,
                                              AV64Wp_downloadappds_3_tfemployeeid_to ,
                                              AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                              AV65Wp_downloadappds_4_tfemployeefirstname ,
                                              AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                              AV67Wp_downloadappds_6_tfemployeelastname ,
                                              AV70Wp_downloadappds_9_tfemployeename_sel ,
                                              AV69Wp_downloadappds_8_tfemployeename ,
                                              AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                              AV71Wp_downloadappds_10_tfemployeeemail ,
                                              AV73Wp_downloadappds_12_tfcompanyid ,
                                              AV74Wp_downloadappds_13_tfcompanyid_to ,
                                              AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                              AV75Wp_downloadappds_14_tfcompanyname ,
                                              AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                              AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                              AV78Wp_downloadappds_17_tfgamuserguid ,
                                              AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                              AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                              AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                              AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                              AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                              AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                              AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                              AV87Wp_downloadappds_26_tfemployeebalance ,
                                              AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A108EmployeeLastName ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A100CompanyId ,
                                              A101CompanyName ,
                                              A111GAMUserGUID ,
                                              A146EmployeeVactionDays ,
                                              A188EmployeeAPIPassword ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A178EmployeeVacationDaysSetDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV65Wp_downloadappds_4_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname), 100, "%");
         lV67Wp_downloadappds_6_tfemployeelastname = StringUtil.PadR( StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname), 100, "%");
         lV69Wp_downloadappds_8_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename), 100, "%");
         lV71Wp_downloadappds_10_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail), "%", "");
         lV75Wp_downloadappds_14_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname), 100, "%");
         lV78Wp_downloadappds_17_tfgamuserguid = StringUtil.Concat( StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid), "%", "");
         lV85Wp_downloadappds_24_tfemployeeapipassword = StringUtil.Concat( StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword), "%", "");
         /* Using cursor P00CL7 */
         pr_default.execute(5, new Object[] {lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, AV63Wp_downloadappds_2_tfemployeeid, AV64Wp_downloadappds_3_tfemployeeid_to, lV65Wp_downloadappds_4_tfemployeefirstname, AV66Wp_downloadappds_5_tfemployeefirstname_sel, lV67Wp_downloadappds_6_tfemployeelastname, AV68Wp_downloadappds_7_tfemployeelastname_sel, lV69Wp_downloadappds_8_tfemployeename, AV70Wp_downloadappds_9_tfemployeename_sel, lV71Wp_downloadappds_10_tfemployeeemail, AV72Wp_downloadappds_11_tfemployeeemail_sel, AV73Wp_downloadappds_12_tfcompanyid, AV74Wp_downloadappds_13_tfcompanyid_to, lV75Wp_downloadappds_14_tfcompanyname, AV76Wp_downloadappds_15_tfcompanyname_sel, lV78Wp_downloadappds_17_tfgamuserguid, AV79Wp_downloadappds_18_tfgamuserguid_sel, AV81Wp_downloadappds_20_tfemployeevactiondays, AV82Wp_downloadappds_21_tfemployeevactiondays_to, AV83Wp_downloadappds_22_tfemployeevacationdayssetdate, AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to, lV85Wp_downloadappds_24_tfemployeeapipassword, AV86Wp_downloadappds_25_tfemployeeapipassword_sel, AV87Wp_downloadappds_26_tfemployeebalance, AV88Wp_downloadappds_27_tfemployeebalance_to});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKCL12 = false;
            A111GAMUserGUID = P00CL7_A111GAMUserGUID[0];
            A147EmployeeBalance = P00CL7_A147EmployeeBalance[0];
            A188EmployeeAPIPassword = P00CL7_A188EmployeeAPIPassword[0];
            A178EmployeeVacationDaysSetDate = P00CL7_A178EmployeeVacationDaysSetDate[0];
            A146EmployeeVactionDays = P00CL7_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P00CL7_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P00CL7_A110EmployeeIsManager[0];
            A101CompanyName = P00CL7_A101CompanyName[0];
            A100CompanyId = P00CL7_A100CompanyId[0];
            A109EmployeeEmail = P00CL7_A109EmployeeEmail[0];
            A148EmployeeName = P00CL7_A148EmployeeName[0];
            A108EmployeeLastName = P00CL7_A108EmployeeLastName[0];
            A107EmployeeFirstName = P00CL7_A107EmployeeFirstName[0];
            A106EmployeeId = P00CL7_A106EmployeeId[0];
            A101CompanyName = P00CL7_A101CompanyName[0];
            AV47count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00CL7_A111GAMUserGUID[0], A111GAMUserGUID) == 0 ) )
            {
               BRKCL12 = false;
               A106EmployeeId = P00CL7_A106EmployeeId[0];
               AV47count = (long)(AV47count+1);
               BRKCL12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV38SkipItems) )
            {
               AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A111GAMUserGUID)) ? "<#Empty#>" : A111GAMUserGUID);
               AV43Options.Add(AV42Option, 0);
               AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV43Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV38SkipItems = (short)(AV38SkipItems-1);
            }
            if ( ! BRKCL12 )
            {
               BRKCL12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADEMPLOYEEAPIPASSWORDOPTIONS' Routine */
         returnInSub = false;
         AV33TFEmployeeAPIPassword = AV37SearchTxt;
         AV34TFEmployeeAPIPassword_Sel = "";
         AV62Wp_downloadappds_1_filterfulltext = AV59FilterFullText;
         AV63Wp_downloadappds_2_tfemployeeid = AV11TFEmployeeId;
         AV64Wp_downloadappds_3_tfemployeeid_to = AV12TFEmployeeId_To;
         AV65Wp_downloadappds_4_tfemployeefirstname = AV13TFEmployeeFirstName;
         AV66Wp_downloadappds_5_tfemployeefirstname_sel = AV14TFEmployeeFirstName_Sel;
         AV67Wp_downloadappds_6_tfemployeelastname = AV15TFEmployeeLastName;
         AV68Wp_downloadappds_7_tfemployeelastname_sel = AV16TFEmployeeLastName_Sel;
         AV69Wp_downloadappds_8_tfemployeename = AV17TFEmployeeName;
         AV70Wp_downloadappds_9_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV71Wp_downloadappds_10_tfemployeeemail = AV19TFEmployeeEmail;
         AV72Wp_downloadappds_11_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV73Wp_downloadappds_12_tfcompanyid = AV21TFCompanyId;
         AV74Wp_downloadappds_13_tfcompanyid_to = AV22TFCompanyId_To;
         AV75Wp_downloadappds_14_tfcompanyname = AV23TFCompanyName;
         AV76Wp_downloadappds_15_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV77Wp_downloadappds_16_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV78Wp_downloadappds_17_tfgamuserguid = AV26TFGAMUserGUID;
         AV79Wp_downloadappds_18_tfgamuserguid_sel = AV27TFGAMUserGUID_Sel;
         AV80Wp_downloadappds_19_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV81Wp_downloadappds_20_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV82Wp_downloadappds_21_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         AV83Wp_downloadappds_22_tfemployeevacationdayssetdate = AV31TFEmployeeVacationDaysSetDate;
         AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to = AV32TFEmployeeVacationDaysSetDate_To;
         AV85Wp_downloadappds_24_tfemployeeapipassword = AV33TFEmployeeAPIPassword;
         AV86Wp_downloadappds_25_tfemployeeapipassword_sel = AV34TFEmployeeAPIPassword_Sel;
         AV87Wp_downloadappds_26_tfemployeebalance = AV35TFEmployeeBalance;
         AV88Wp_downloadappds_27_tfemployeebalance_to = AV36TFEmployeeBalance_To;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV62Wp_downloadappds_1_filterfulltext ,
                                              AV63Wp_downloadappds_2_tfemployeeid ,
                                              AV64Wp_downloadappds_3_tfemployeeid_to ,
                                              AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                              AV65Wp_downloadappds_4_tfemployeefirstname ,
                                              AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                              AV67Wp_downloadappds_6_tfemployeelastname ,
                                              AV70Wp_downloadappds_9_tfemployeename_sel ,
                                              AV69Wp_downloadappds_8_tfemployeename ,
                                              AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                              AV71Wp_downloadappds_10_tfemployeeemail ,
                                              AV73Wp_downloadappds_12_tfcompanyid ,
                                              AV74Wp_downloadappds_13_tfcompanyid_to ,
                                              AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                              AV75Wp_downloadappds_14_tfcompanyname ,
                                              AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                              AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                              AV78Wp_downloadappds_17_tfgamuserguid ,
                                              AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                              AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                              AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                              AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                              AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                              AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                              AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                              AV87Wp_downloadappds_26_tfemployeebalance ,
                                              AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A108EmployeeLastName ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A100CompanyId ,
                                              A101CompanyName ,
                                              A111GAMUserGUID ,
                                              A146EmployeeVactionDays ,
                                              A188EmployeeAPIPassword ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A178EmployeeVacationDaysSetDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV62Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext), "%", "");
         lV65Wp_downloadappds_4_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname), 100, "%");
         lV67Wp_downloadappds_6_tfemployeelastname = StringUtil.PadR( StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname), 100, "%");
         lV69Wp_downloadappds_8_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename), 100, "%");
         lV71Wp_downloadappds_10_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail), "%", "");
         lV75Wp_downloadappds_14_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname), 100, "%");
         lV78Wp_downloadappds_17_tfgamuserguid = StringUtil.Concat( StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid), "%", "");
         lV85Wp_downloadappds_24_tfemployeeapipassword = StringUtil.Concat( StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword), "%", "");
         /* Using cursor P00CL8 */
         pr_default.execute(6, new Object[] {lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, lV62Wp_downloadappds_1_filterfulltext, AV63Wp_downloadappds_2_tfemployeeid, AV64Wp_downloadappds_3_tfemployeeid_to, lV65Wp_downloadappds_4_tfemployeefirstname, AV66Wp_downloadappds_5_tfemployeefirstname_sel, lV67Wp_downloadappds_6_tfemployeelastname, AV68Wp_downloadappds_7_tfemployeelastname_sel, lV69Wp_downloadappds_8_tfemployeename, AV70Wp_downloadappds_9_tfemployeename_sel, lV71Wp_downloadappds_10_tfemployeeemail, AV72Wp_downloadappds_11_tfemployeeemail_sel, AV73Wp_downloadappds_12_tfcompanyid, AV74Wp_downloadappds_13_tfcompanyid_to, lV75Wp_downloadappds_14_tfcompanyname, AV76Wp_downloadappds_15_tfcompanyname_sel, lV78Wp_downloadappds_17_tfgamuserguid, AV79Wp_downloadappds_18_tfgamuserguid_sel, AV81Wp_downloadappds_20_tfemployeevactiondays, AV82Wp_downloadappds_21_tfemployeevactiondays_to, AV83Wp_downloadappds_22_tfemployeevacationdayssetdate, AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to, lV85Wp_downloadappds_24_tfemployeeapipassword, AV86Wp_downloadappds_25_tfemployeeapipassword_sel, AV87Wp_downloadappds_26_tfemployeebalance, AV88Wp_downloadappds_27_tfemployeebalance_to});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKCL14 = false;
            A188EmployeeAPIPassword = P00CL8_A188EmployeeAPIPassword[0];
            A147EmployeeBalance = P00CL8_A147EmployeeBalance[0];
            A178EmployeeVacationDaysSetDate = P00CL8_A178EmployeeVacationDaysSetDate[0];
            A146EmployeeVactionDays = P00CL8_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P00CL8_A112EmployeeIsActive[0];
            A111GAMUserGUID = P00CL8_A111GAMUserGUID[0];
            A110EmployeeIsManager = P00CL8_A110EmployeeIsManager[0];
            A101CompanyName = P00CL8_A101CompanyName[0];
            A100CompanyId = P00CL8_A100CompanyId[0];
            A109EmployeeEmail = P00CL8_A109EmployeeEmail[0];
            A148EmployeeName = P00CL8_A148EmployeeName[0];
            A108EmployeeLastName = P00CL8_A108EmployeeLastName[0];
            A107EmployeeFirstName = P00CL8_A107EmployeeFirstName[0];
            A106EmployeeId = P00CL8_A106EmployeeId[0];
            A101CompanyName = P00CL8_A101CompanyName[0];
            AV47count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P00CL8_A188EmployeeAPIPassword[0], A188EmployeeAPIPassword) == 0 ) )
            {
               BRKCL14 = false;
               A106EmployeeId = P00CL8_A106EmployeeId[0];
               AV47count = (long)(AV47count+1);
               BRKCL14 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV38SkipItems) )
            {
               AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A188EmployeeAPIPassword)) ? "<#Empty#>" : A188EmployeeAPIPassword);
               AV43Options.Add(AV42Option, 0);
               AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV43Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV38SkipItems = (short)(AV38SkipItems-1);
            }
            if ( ! BRKCL14 )
            {
               BRKCL14 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV56OptionsJson = "";
         AV57OptionsDescJson = "";
         AV58OptionIndexesJson = "";
         AV43Options = new GxSimpleCollection<string>();
         AV45OptionsDesc = new GxSimpleCollection<string>();
         AV46OptionIndexes = new GxSimpleCollection<string>();
         AV37SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV48Session = context.GetSession();
         AV50GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV51GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59FilterFullText = "";
         AV13TFEmployeeFirstName = "";
         AV14TFEmployeeFirstName_Sel = "";
         AV15TFEmployeeLastName = "";
         AV16TFEmployeeLastName_Sel = "";
         AV17TFEmployeeName = "";
         AV18TFEmployeeName_Sel = "";
         AV19TFEmployeeEmail = "";
         AV20TFEmployeeEmail_Sel = "";
         AV23TFCompanyName = "";
         AV24TFCompanyName_Sel = "";
         AV26TFGAMUserGUID = "";
         AV27TFGAMUserGUID_Sel = "";
         AV31TFEmployeeVacationDaysSetDate = DateTime.MinValue;
         AV32TFEmployeeVacationDaysSetDate_To = DateTime.MinValue;
         AV33TFEmployeeAPIPassword = "";
         AV34TFEmployeeAPIPassword_Sel = "";
         AV62Wp_downloadappds_1_filterfulltext = "";
         AV65Wp_downloadappds_4_tfemployeefirstname = "";
         AV66Wp_downloadappds_5_tfemployeefirstname_sel = "";
         AV67Wp_downloadappds_6_tfemployeelastname = "";
         AV68Wp_downloadappds_7_tfemployeelastname_sel = "";
         AV69Wp_downloadappds_8_tfemployeename = "";
         AV70Wp_downloadappds_9_tfemployeename_sel = "";
         AV71Wp_downloadappds_10_tfemployeeemail = "";
         AV72Wp_downloadappds_11_tfemployeeemail_sel = "";
         AV75Wp_downloadappds_14_tfcompanyname = "";
         AV76Wp_downloadappds_15_tfcompanyname_sel = "";
         AV78Wp_downloadappds_17_tfgamuserguid = "";
         AV79Wp_downloadappds_18_tfgamuserguid_sel = "";
         AV83Wp_downloadappds_22_tfemployeevacationdayssetdate = DateTime.MinValue;
         AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to = DateTime.MinValue;
         AV85Wp_downloadappds_24_tfemployeeapipassword = "";
         AV86Wp_downloadappds_25_tfemployeeapipassword_sel = "";
         lV62Wp_downloadappds_1_filterfulltext = "";
         lV65Wp_downloadappds_4_tfemployeefirstname = "";
         lV67Wp_downloadappds_6_tfemployeelastname = "";
         lV69Wp_downloadappds_8_tfemployeename = "";
         lV71Wp_downloadappds_10_tfemployeeemail = "";
         lV75Wp_downloadappds_14_tfcompanyname = "";
         lV78Wp_downloadappds_17_tfgamuserguid = "";
         lV85Wp_downloadappds_24_tfemployeeapipassword = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         A111GAMUserGUID = "";
         A188EmployeeAPIPassword = "";
         A178EmployeeVacationDaysSetDate = DateTime.MinValue;
         P00CL2_A107EmployeeFirstName = new string[] {""} ;
         P00CL2_A147EmployeeBalance = new decimal[1] ;
         P00CL2_A188EmployeeAPIPassword = new string[] {""} ;
         P00CL2_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00CL2_A146EmployeeVactionDays = new decimal[1] ;
         P00CL2_A112EmployeeIsActive = new bool[] {false} ;
         P00CL2_A111GAMUserGUID = new string[] {""} ;
         P00CL2_A110EmployeeIsManager = new bool[] {false} ;
         P00CL2_A101CompanyName = new string[] {""} ;
         P00CL2_A100CompanyId = new long[1] ;
         P00CL2_A109EmployeeEmail = new string[] {""} ;
         P00CL2_A148EmployeeName = new string[] {""} ;
         P00CL2_A108EmployeeLastName = new string[] {""} ;
         P00CL2_A106EmployeeId = new long[1] ;
         AV42Option = "";
         P00CL3_A108EmployeeLastName = new string[] {""} ;
         P00CL3_A147EmployeeBalance = new decimal[1] ;
         P00CL3_A188EmployeeAPIPassword = new string[] {""} ;
         P00CL3_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00CL3_A146EmployeeVactionDays = new decimal[1] ;
         P00CL3_A112EmployeeIsActive = new bool[] {false} ;
         P00CL3_A111GAMUserGUID = new string[] {""} ;
         P00CL3_A110EmployeeIsManager = new bool[] {false} ;
         P00CL3_A101CompanyName = new string[] {""} ;
         P00CL3_A100CompanyId = new long[1] ;
         P00CL3_A109EmployeeEmail = new string[] {""} ;
         P00CL3_A148EmployeeName = new string[] {""} ;
         P00CL3_A107EmployeeFirstName = new string[] {""} ;
         P00CL3_A106EmployeeId = new long[1] ;
         P00CL4_A148EmployeeName = new string[] {""} ;
         P00CL4_A147EmployeeBalance = new decimal[1] ;
         P00CL4_A188EmployeeAPIPassword = new string[] {""} ;
         P00CL4_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00CL4_A146EmployeeVactionDays = new decimal[1] ;
         P00CL4_A112EmployeeIsActive = new bool[] {false} ;
         P00CL4_A111GAMUserGUID = new string[] {""} ;
         P00CL4_A110EmployeeIsManager = new bool[] {false} ;
         P00CL4_A101CompanyName = new string[] {""} ;
         P00CL4_A100CompanyId = new long[1] ;
         P00CL4_A109EmployeeEmail = new string[] {""} ;
         P00CL4_A108EmployeeLastName = new string[] {""} ;
         P00CL4_A107EmployeeFirstName = new string[] {""} ;
         P00CL4_A106EmployeeId = new long[1] ;
         P00CL5_A109EmployeeEmail = new string[] {""} ;
         P00CL5_A147EmployeeBalance = new decimal[1] ;
         P00CL5_A188EmployeeAPIPassword = new string[] {""} ;
         P00CL5_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00CL5_A146EmployeeVactionDays = new decimal[1] ;
         P00CL5_A112EmployeeIsActive = new bool[] {false} ;
         P00CL5_A111GAMUserGUID = new string[] {""} ;
         P00CL5_A110EmployeeIsManager = new bool[] {false} ;
         P00CL5_A101CompanyName = new string[] {""} ;
         P00CL5_A100CompanyId = new long[1] ;
         P00CL5_A148EmployeeName = new string[] {""} ;
         P00CL5_A108EmployeeLastName = new string[] {""} ;
         P00CL5_A107EmployeeFirstName = new string[] {""} ;
         P00CL5_A106EmployeeId = new long[1] ;
         P00CL6_A100CompanyId = new long[1] ;
         P00CL6_A147EmployeeBalance = new decimal[1] ;
         P00CL6_A188EmployeeAPIPassword = new string[] {""} ;
         P00CL6_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00CL6_A146EmployeeVactionDays = new decimal[1] ;
         P00CL6_A112EmployeeIsActive = new bool[] {false} ;
         P00CL6_A111GAMUserGUID = new string[] {""} ;
         P00CL6_A110EmployeeIsManager = new bool[] {false} ;
         P00CL6_A101CompanyName = new string[] {""} ;
         P00CL6_A109EmployeeEmail = new string[] {""} ;
         P00CL6_A148EmployeeName = new string[] {""} ;
         P00CL6_A108EmployeeLastName = new string[] {""} ;
         P00CL6_A107EmployeeFirstName = new string[] {""} ;
         P00CL6_A106EmployeeId = new long[1] ;
         P00CL7_A111GAMUserGUID = new string[] {""} ;
         P00CL7_A147EmployeeBalance = new decimal[1] ;
         P00CL7_A188EmployeeAPIPassword = new string[] {""} ;
         P00CL7_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00CL7_A146EmployeeVactionDays = new decimal[1] ;
         P00CL7_A112EmployeeIsActive = new bool[] {false} ;
         P00CL7_A110EmployeeIsManager = new bool[] {false} ;
         P00CL7_A101CompanyName = new string[] {""} ;
         P00CL7_A100CompanyId = new long[1] ;
         P00CL7_A109EmployeeEmail = new string[] {""} ;
         P00CL7_A148EmployeeName = new string[] {""} ;
         P00CL7_A108EmployeeLastName = new string[] {""} ;
         P00CL7_A107EmployeeFirstName = new string[] {""} ;
         P00CL7_A106EmployeeId = new long[1] ;
         P00CL8_A188EmployeeAPIPassword = new string[] {""} ;
         P00CL8_A147EmployeeBalance = new decimal[1] ;
         P00CL8_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00CL8_A146EmployeeVactionDays = new decimal[1] ;
         P00CL8_A112EmployeeIsActive = new bool[] {false} ;
         P00CL8_A111GAMUserGUID = new string[] {""} ;
         P00CL8_A110EmployeeIsManager = new bool[] {false} ;
         P00CL8_A101CompanyName = new string[] {""} ;
         P00CL8_A100CompanyId = new long[1] ;
         P00CL8_A109EmployeeEmail = new string[] {""} ;
         P00CL8_A148EmployeeName = new string[] {""} ;
         P00CL8_A108EmployeeLastName = new string[] {""} ;
         P00CL8_A107EmployeeFirstName = new string[] {""} ;
         P00CL8_A106EmployeeId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_downloadappgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CL2_A107EmployeeFirstName, P00CL2_A147EmployeeBalance, P00CL2_A188EmployeeAPIPassword, P00CL2_A178EmployeeVacationDaysSetDate, P00CL2_A146EmployeeVactionDays, P00CL2_A112EmployeeIsActive, P00CL2_A111GAMUserGUID, P00CL2_A110EmployeeIsManager, P00CL2_A101CompanyName, P00CL2_A100CompanyId,
               P00CL2_A109EmployeeEmail, P00CL2_A148EmployeeName, P00CL2_A108EmployeeLastName, P00CL2_A106EmployeeId
               }
               , new Object[] {
               P00CL3_A108EmployeeLastName, P00CL3_A147EmployeeBalance, P00CL3_A188EmployeeAPIPassword, P00CL3_A178EmployeeVacationDaysSetDate, P00CL3_A146EmployeeVactionDays, P00CL3_A112EmployeeIsActive, P00CL3_A111GAMUserGUID, P00CL3_A110EmployeeIsManager, P00CL3_A101CompanyName, P00CL3_A100CompanyId,
               P00CL3_A109EmployeeEmail, P00CL3_A148EmployeeName, P00CL3_A107EmployeeFirstName, P00CL3_A106EmployeeId
               }
               , new Object[] {
               P00CL4_A148EmployeeName, P00CL4_A147EmployeeBalance, P00CL4_A188EmployeeAPIPassword, P00CL4_A178EmployeeVacationDaysSetDate, P00CL4_A146EmployeeVactionDays, P00CL4_A112EmployeeIsActive, P00CL4_A111GAMUserGUID, P00CL4_A110EmployeeIsManager, P00CL4_A101CompanyName, P00CL4_A100CompanyId,
               P00CL4_A109EmployeeEmail, P00CL4_A108EmployeeLastName, P00CL4_A107EmployeeFirstName, P00CL4_A106EmployeeId
               }
               , new Object[] {
               P00CL5_A109EmployeeEmail, P00CL5_A147EmployeeBalance, P00CL5_A188EmployeeAPIPassword, P00CL5_A178EmployeeVacationDaysSetDate, P00CL5_A146EmployeeVactionDays, P00CL5_A112EmployeeIsActive, P00CL5_A111GAMUserGUID, P00CL5_A110EmployeeIsManager, P00CL5_A101CompanyName, P00CL5_A100CompanyId,
               P00CL5_A148EmployeeName, P00CL5_A108EmployeeLastName, P00CL5_A107EmployeeFirstName, P00CL5_A106EmployeeId
               }
               , new Object[] {
               P00CL6_A100CompanyId, P00CL6_A147EmployeeBalance, P00CL6_A188EmployeeAPIPassword, P00CL6_A178EmployeeVacationDaysSetDate, P00CL6_A146EmployeeVactionDays, P00CL6_A112EmployeeIsActive, P00CL6_A111GAMUserGUID, P00CL6_A110EmployeeIsManager, P00CL6_A101CompanyName, P00CL6_A109EmployeeEmail,
               P00CL6_A148EmployeeName, P00CL6_A108EmployeeLastName, P00CL6_A107EmployeeFirstName, P00CL6_A106EmployeeId
               }
               , new Object[] {
               P00CL7_A111GAMUserGUID, P00CL7_A147EmployeeBalance, P00CL7_A188EmployeeAPIPassword, P00CL7_A178EmployeeVacationDaysSetDate, P00CL7_A146EmployeeVactionDays, P00CL7_A112EmployeeIsActive, P00CL7_A110EmployeeIsManager, P00CL7_A101CompanyName, P00CL7_A100CompanyId, P00CL7_A109EmployeeEmail,
               P00CL7_A148EmployeeName, P00CL7_A108EmployeeLastName, P00CL7_A107EmployeeFirstName, P00CL7_A106EmployeeId
               }
               , new Object[] {
               P00CL8_A188EmployeeAPIPassword, P00CL8_A147EmployeeBalance, P00CL8_A178EmployeeVacationDaysSetDate, P00CL8_A146EmployeeVactionDays, P00CL8_A112EmployeeIsActive, P00CL8_A111GAMUserGUID, P00CL8_A110EmployeeIsManager, P00CL8_A101CompanyName, P00CL8_A100CompanyId, P00CL8_A109EmployeeEmail,
               P00CL8_A148EmployeeName, P00CL8_A108EmployeeLastName, P00CL8_A107EmployeeFirstName, P00CL8_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV40MaxItems ;
      private short AV39PageIndex ;
      private short AV38SkipItems ;
      private short AV25TFEmployeeIsManager_Sel ;
      private short AV28TFEmployeeIsActive_Sel ;
      private short AV77Wp_downloadappds_16_tfemployeeismanager_sel ;
      private short AV80Wp_downloadappds_19_tfemployeeisactive_sel ;
      private int AV60GXV1 ;
      private int AV41InsertIndex ;
      private long AV11TFEmployeeId ;
      private long AV12TFEmployeeId_To ;
      private long AV21TFCompanyId ;
      private long AV22TFCompanyId_To ;
      private long AV63Wp_downloadappds_2_tfemployeeid ;
      private long AV64Wp_downloadappds_3_tfemployeeid_to ;
      private long AV73Wp_downloadappds_12_tfcompanyid ;
      private long AV74Wp_downloadappds_13_tfcompanyid_to ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long AV47count ;
      private decimal AV29TFEmployeeVactionDays ;
      private decimal AV30TFEmployeeVactionDays_To ;
      private decimal AV35TFEmployeeBalance ;
      private decimal AV36TFEmployeeBalance_To ;
      private decimal AV81Wp_downloadappds_20_tfemployeevactiondays ;
      private decimal AV82Wp_downloadappds_21_tfemployeevactiondays_to ;
      private decimal AV87Wp_downloadappds_26_tfemployeebalance ;
      private decimal AV88Wp_downloadappds_27_tfemployeebalance_to ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private string AV13TFEmployeeFirstName ;
      private string AV14TFEmployeeFirstName_Sel ;
      private string AV15TFEmployeeLastName ;
      private string AV16TFEmployeeLastName_Sel ;
      private string AV17TFEmployeeName ;
      private string AV18TFEmployeeName_Sel ;
      private string AV23TFCompanyName ;
      private string AV24TFCompanyName_Sel ;
      private string AV65Wp_downloadappds_4_tfemployeefirstname ;
      private string AV66Wp_downloadappds_5_tfemployeefirstname_sel ;
      private string AV67Wp_downloadappds_6_tfemployeelastname ;
      private string AV68Wp_downloadappds_7_tfemployeelastname_sel ;
      private string AV69Wp_downloadappds_8_tfemployeename ;
      private string AV70Wp_downloadappds_9_tfemployeename_sel ;
      private string AV75Wp_downloadappds_14_tfcompanyname ;
      private string AV76Wp_downloadappds_15_tfcompanyname_sel ;
      private string lV65Wp_downloadappds_4_tfemployeefirstname ;
      private string lV67Wp_downloadappds_6_tfemployeelastname ;
      private string lV69Wp_downloadappds_8_tfemployeename ;
      private string lV75Wp_downloadappds_14_tfcompanyname ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string A148EmployeeName ;
      private string A101CompanyName ;
      private DateTime AV31TFEmployeeVacationDaysSetDate ;
      private DateTime AV32TFEmployeeVacationDaysSetDate_To ;
      private DateTime AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ;
      private DateTime AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ;
      private DateTime A178EmployeeVacationDaysSetDate ;
      private bool returnInSub ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool BRKCL2 ;
      private bool BRKCL4 ;
      private bool BRKCL6 ;
      private bool BRKCL8 ;
      private bool BRKCL10 ;
      private bool BRKCL12 ;
      private bool BRKCL14 ;
      private string AV56OptionsJson ;
      private string AV57OptionsDescJson ;
      private string AV58OptionIndexesJson ;
      private string AV53DDOName ;
      private string AV54SearchTxtParms ;
      private string AV55SearchTxtTo ;
      private string AV37SearchTxt ;
      private string AV59FilterFullText ;
      private string AV19TFEmployeeEmail ;
      private string AV20TFEmployeeEmail_Sel ;
      private string AV26TFGAMUserGUID ;
      private string AV27TFGAMUserGUID_Sel ;
      private string AV33TFEmployeeAPIPassword ;
      private string AV34TFEmployeeAPIPassword_Sel ;
      private string AV62Wp_downloadappds_1_filterfulltext ;
      private string AV71Wp_downloadappds_10_tfemployeeemail ;
      private string AV72Wp_downloadappds_11_tfemployeeemail_sel ;
      private string AV78Wp_downloadappds_17_tfgamuserguid ;
      private string AV79Wp_downloadappds_18_tfgamuserguid_sel ;
      private string AV85Wp_downloadappds_24_tfemployeeapipassword ;
      private string AV86Wp_downloadappds_25_tfemployeeapipassword_sel ;
      private string lV62Wp_downloadappds_1_filterfulltext ;
      private string lV71Wp_downloadappds_10_tfemployeeemail ;
      private string lV78Wp_downloadappds_17_tfgamuserguid ;
      private string lV85Wp_downloadappds_24_tfemployeeapipassword ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private string A188EmployeeAPIPassword ;
      private string AV42Option ;
      private IGxSession AV48Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV43Options ;
      private GxSimpleCollection<string> AV45OptionsDesc ;
      private GxSimpleCollection<string> AV46OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV50GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV51GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00CL2_A107EmployeeFirstName ;
      private decimal[] P00CL2_A147EmployeeBalance ;
      private string[] P00CL2_A188EmployeeAPIPassword ;
      private DateTime[] P00CL2_A178EmployeeVacationDaysSetDate ;
      private decimal[] P00CL2_A146EmployeeVactionDays ;
      private bool[] P00CL2_A112EmployeeIsActive ;
      private string[] P00CL2_A111GAMUserGUID ;
      private bool[] P00CL2_A110EmployeeIsManager ;
      private string[] P00CL2_A101CompanyName ;
      private long[] P00CL2_A100CompanyId ;
      private string[] P00CL2_A109EmployeeEmail ;
      private string[] P00CL2_A148EmployeeName ;
      private string[] P00CL2_A108EmployeeLastName ;
      private long[] P00CL2_A106EmployeeId ;
      private string[] P00CL3_A108EmployeeLastName ;
      private decimal[] P00CL3_A147EmployeeBalance ;
      private string[] P00CL3_A188EmployeeAPIPassword ;
      private DateTime[] P00CL3_A178EmployeeVacationDaysSetDate ;
      private decimal[] P00CL3_A146EmployeeVactionDays ;
      private bool[] P00CL3_A112EmployeeIsActive ;
      private string[] P00CL3_A111GAMUserGUID ;
      private bool[] P00CL3_A110EmployeeIsManager ;
      private string[] P00CL3_A101CompanyName ;
      private long[] P00CL3_A100CompanyId ;
      private string[] P00CL3_A109EmployeeEmail ;
      private string[] P00CL3_A148EmployeeName ;
      private string[] P00CL3_A107EmployeeFirstName ;
      private long[] P00CL3_A106EmployeeId ;
      private string[] P00CL4_A148EmployeeName ;
      private decimal[] P00CL4_A147EmployeeBalance ;
      private string[] P00CL4_A188EmployeeAPIPassword ;
      private DateTime[] P00CL4_A178EmployeeVacationDaysSetDate ;
      private decimal[] P00CL4_A146EmployeeVactionDays ;
      private bool[] P00CL4_A112EmployeeIsActive ;
      private string[] P00CL4_A111GAMUserGUID ;
      private bool[] P00CL4_A110EmployeeIsManager ;
      private string[] P00CL4_A101CompanyName ;
      private long[] P00CL4_A100CompanyId ;
      private string[] P00CL4_A109EmployeeEmail ;
      private string[] P00CL4_A108EmployeeLastName ;
      private string[] P00CL4_A107EmployeeFirstName ;
      private long[] P00CL4_A106EmployeeId ;
      private string[] P00CL5_A109EmployeeEmail ;
      private decimal[] P00CL5_A147EmployeeBalance ;
      private string[] P00CL5_A188EmployeeAPIPassword ;
      private DateTime[] P00CL5_A178EmployeeVacationDaysSetDate ;
      private decimal[] P00CL5_A146EmployeeVactionDays ;
      private bool[] P00CL5_A112EmployeeIsActive ;
      private string[] P00CL5_A111GAMUserGUID ;
      private bool[] P00CL5_A110EmployeeIsManager ;
      private string[] P00CL5_A101CompanyName ;
      private long[] P00CL5_A100CompanyId ;
      private string[] P00CL5_A148EmployeeName ;
      private string[] P00CL5_A108EmployeeLastName ;
      private string[] P00CL5_A107EmployeeFirstName ;
      private long[] P00CL5_A106EmployeeId ;
      private long[] P00CL6_A100CompanyId ;
      private decimal[] P00CL6_A147EmployeeBalance ;
      private string[] P00CL6_A188EmployeeAPIPassword ;
      private DateTime[] P00CL6_A178EmployeeVacationDaysSetDate ;
      private decimal[] P00CL6_A146EmployeeVactionDays ;
      private bool[] P00CL6_A112EmployeeIsActive ;
      private string[] P00CL6_A111GAMUserGUID ;
      private bool[] P00CL6_A110EmployeeIsManager ;
      private string[] P00CL6_A101CompanyName ;
      private string[] P00CL6_A109EmployeeEmail ;
      private string[] P00CL6_A148EmployeeName ;
      private string[] P00CL6_A108EmployeeLastName ;
      private string[] P00CL6_A107EmployeeFirstName ;
      private long[] P00CL6_A106EmployeeId ;
      private string[] P00CL7_A111GAMUserGUID ;
      private decimal[] P00CL7_A147EmployeeBalance ;
      private string[] P00CL7_A188EmployeeAPIPassword ;
      private DateTime[] P00CL7_A178EmployeeVacationDaysSetDate ;
      private decimal[] P00CL7_A146EmployeeVactionDays ;
      private bool[] P00CL7_A112EmployeeIsActive ;
      private bool[] P00CL7_A110EmployeeIsManager ;
      private string[] P00CL7_A101CompanyName ;
      private long[] P00CL7_A100CompanyId ;
      private string[] P00CL7_A109EmployeeEmail ;
      private string[] P00CL7_A148EmployeeName ;
      private string[] P00CL7_A108EmployeeLastName ;
      private string[] P00CL7_A107EmployeeFirstName ;
      private long[] P00CL7_A106EmployeeId ;
      private string[] P00CL8_A188EmployeeAPIPassword ;
      private decimal[] P00CL8_A147EmployeeBalance ;
      private DateTime[] P00CL8_A178EmployeeVacationDaysSetDate ;
      private decimal[] P00CL8_A146EmployeeVactionDays ;
      private bool[] P00CL8_A112EmployeeIsActive ;
      private string[] P00CL8_A111GAMUserGUID ;
      private bool[] P00CL8_A110EmployeeIsManager ;
      private string[] P00CL8_A101CompanyName ;
      private long[] P00CL8_A100CompanyId ;
      private string[] P00CL8_A109EmployeeEmail ;
      private string[] P00CL8_A148EmployeeName ;
      private string[] P00CL8_A108EmployeeLastName ;
      private string[] P00CL8_A107EmployeeFirstName ;
      private long[] P00CL8_A106EmployeeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_downloadappgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CL2( IGxContext context ,
                                             string AV62Wp_downloadappds_1_filterfulltext ,
                                             long AV63Wp_downloadappds_2_tfemployeeid ,
                                             long AV64Wp_downloadappds_3_tfemployeeid_to ,
                                             string AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                             string AV65Wp_downloadappds_4_tfemployeefirstname ,
                                             string AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                             string AV67Wp_downloadappds_6_tfemployeelastname ,
                                             string AV70Wp_downloadappds_9_tfemployeename_sel ,
                                             string AV69Wp_downloadappds_8_tfemployeename ,
                                             string AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                             string AV71Wp_downloadappds_10_tfemployeeemail ,
                                             long AV73Wp_downloadappds_12_tfcompanyid ,
                                             long AV74Wp_downloadappds_13_tfcompanyid_to ,
                                             string AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                             string AV75Wp_downloadappds_14_tfcompanyname ,
                                             short AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                             string AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                             string AV78Wp_downloadappds_17_tfgamuserguid ,
                                             short AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                             decimal AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                             decimal AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                             DateTime AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                             DateTime AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                             string AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                             string AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                             decimal AV87Wp_downloadappds_26_tfemployeebalance ,
                                             decimal AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             string A108EmployeeLastName ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             long A100CompanyId ,
                                             string A101CompanyName ,
                                             string A111GAMUserGUID ,
                                             decimal A146EmployeeVactionDays ,
                                             string A188EmployeeAPIPassword ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             DateTime A178EmployeeVacationDaysSetDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[35];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeFirstName, T1.EmployeeBalance, T1.EmployeeAPIPassword, T1.EmployeeVacationDaysSetDate, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeLastName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeFirstName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeLastName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.CompanyId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T2.CompanyName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.GAMUserGUID) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeAPIPassword) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
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
         if ( ! (0==AV63Wp_downloadappds_2_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV63Wp_downloadappds_2_tfemployeeid)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV64Wp_downloadappds_3_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV64Wp_downloadappds_3_tfemployeeid_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName like :lV65Wp_downloadappds_4_tfemployeefirstname)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName = ( :AV66Wp_downloadappds_5_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName like :lV67Wp_downloadappds_6_tfemployeelastname)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName = ( :AV68Wp_downloadappds_7_tfemployeelastname_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV69Wp_downloadappds_8_tfemployeename)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV70Wp_downloadappds_9_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV71Wp_downloadappds_10_tfemployeeemail)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV72Wp_downloadappds_11_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( ! (0==AV73Wp_downloadappds_12_tfcompanyid) )
         {
            AddWhere(sWhereString, "(T1.CompanyId >= :AV73Wp_downloadappds_12_tfcompanyid)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (0==AV74Wp_downloadappds_13_tfcompanyid_to) )
         {
            AddWhere(sWhereString, "(T1.CompanyId <= :AV74Wp_downloadappds_13_tfcompanyid_to)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV75Wp_downloadappds_14_tfcompanyname)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV76Wp_downloadappds_15_tfcompanyname_sel))");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid)) ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID like :lV78Wp_downloadappds_17_tfgamuserguid)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ! ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID = ( :AV79Wp_downloadappds_18_tfgamuserguid_sel))");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.GAMUserGUID))=0))");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Wp_downloadappds_20_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV81Wp_downloadappds_20_tfemployeevactiondays)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wp_downloadappds_21_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV82Wp_downloadappds_21_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wp_downloadappds_22_tfemployeevacationdayssetdate) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate >= :AV83Wp_downloadappds_22_tfemployeevacationdayssetdate)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate <= :AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword like :lV85Wp_downloadappds_24_tfemployeeapipassword)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ! ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword = ( :AV86Wp_downloadappds_25_tfemployeeapipassword_sel))");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeAPIPassword))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wp_downloadappds_26_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV87Wp_downloadappds_26_tfemployeebalance)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wp_downloadappds_27_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV88Wp_downloadappds_27_tfemployeebalance_to)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeFirstName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00CL3( IGxContext context ,
                                             string AV62Wp_downloadappds_1_filterfulltext ,
                                             long AV63Wp_downloadappds_2_tfemployeeid ,
                                             long AV64Wp_downloadappds_3_tfemployeeid_to ,
                                             string AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                             string AV65Wp_downloadappds_4_tfemployeefirstname ,
                                             string AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                             string AV67Wp_downloadappds_6_tfemployeelastname ,
                                             string AV70Wp_downloadappds_9_tfemployeename_sel ,
                                             string AV69Wp_downloadappds_8_tfemployeename ,
                                             string AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                             string AV71Wp_downloadappds_10_tfemployeeemail ,
                                             long AV73Wp_downloadappds_12_tfcompanyid ,
                                             long AV74Wp_downloadappds_13_tfcompanyid_to ,
                                             string AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                             string AV75Wp_downloadappds_14_tfcompanyname ,
                                             short AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                             string AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                             string AV78Wp_downloadappds_17_tfgamuserguid ,
                                             short AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                             decimal AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                             decimal AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                             DateTime AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                             DateTime AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                             string AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                             string AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                             decimal AV87Wp_downloadappds_26_tfemployeebalance ,
                                             decimal AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             string A108EmployeeLastName ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             long A100CompanyId ,
                                             string A101CompanyName ,
                                             string A111GAMUserGUID ,
                                             decimal A146EmployeeVactionDays ,
                                             string A188EmployeeAPIPassword ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             DateTime A178EmployeeVacationDaysSetDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[35];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeLastName, T1.EmployeeBalance, T1.EmployeeAPIPassword, T1.EmployeeVacationDaysSetDate, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeFirstName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeFirstName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeLastName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.CompanyId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T2.CompanyName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.GAMUserGUID) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeAPIPassword) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
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
         if ( ! (0==AV63Wp_downloadappds_2_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV63Wp_downloadappds_2_tfemployeeid)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV64Wp_downloadappds_3_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV64Wp_downloadappds_3_tfemployeeid_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName like :lV65Wp_downloadappds_4_tfemployeefirstname)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName = ( :AV66Wp_downloadappds_5_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName like :lV67Wp_downloadappds_6_tfemployeelastname)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName = ( :AV68Wp_downloadappds_7_tfemployeelastname_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV69Wp_downloadappds_8_tfemployeename)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV70Wp_downloadappds_9_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV71Wp_downloadappds_10_tfemployeeemail)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV72Wp_downloadappds_11_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( ! (0==AV73Wp_downloadappds_12_tfcompanyid) )
         {
            AddWhere(sWhereString, "(T1.CompanyId >= :AV73Wp_downloadappds_12_tfcompanyid)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (0==AV74Wp_downloadappds_13_tfcompanyid_to) )
         {
            AddWhere(sWhereString, "(T1.CompanyId <= :AV74Wp_downloadappds_13_tfcompanyid_to)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV75Wp_downloadappds_14_tfcompanyname)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV76Wp_downloadappds_15_tfcompanyname_sel))");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid)) ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID like :lV78Wp_downloadappds_17_tfgamuserguid)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ! ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID = ( :AV79Wp_downloadappds_18_tfgamuserguid_sel))");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.GAMUserGUID))=0))");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Wp_downloadappds_20_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV81Wp_downloadappds_20_tfemployeevactiondays)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wp_downloadappds_21_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV82Wp_downloadappds_21_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wp_downloadappds_22_tfemployeevacationdayssetdate) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate >= :AV83Wp_downloadappds_22_tfemployeevacationdayssetdate)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate <= :AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword like :lV85Wp_downloadappds_24_tfemployeeapipassword)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ! ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword = ( :AV86Wp_downloadappds_25_tfemployeeapipassword_sel))");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeAPIPassword))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wp_downloadappds_26_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV87Wp_downloadappds_26_tfemployeebalance)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wp_downloadappds_27_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV88Wp_downloadappds_27_tfemployeebalance_to)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeLastName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00CL4( IGxContext context ,
                                             string AV62Wp_downloadappds_1_filterfulltext ,
                                             long AV63Wp_downloadappds_2_tfemployeeid ,
                                             long AV64Wp_downloadappds_3_tfemployeeid_to ,
                                             string AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                             string AV65Wp_downloadappds_4_tfemployeefirstname ,
                                             string AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                             string AV67Wp_downloadappds_6_tfemployeelastname ,
                                             string AV70Wp_downloadappds_9_tfemployeename_sel ,
                                             string AV69Wp_downloadappds_8_tfemployeename ,
                                             string AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                             string AV71Wp_downloadappds_10_tfemployeeemail ,
                                             long AV73Wp_downloadappds_12_tfcompanyid ,
                                             long AV74Wp_downloadappds_13_tfcompanyid_to ,
                                             string AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                             string AV75Wp_downloadappds_14_tfcompanyname ,
                                             short AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                             string AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                             string AV78Wp_downloadappds_17_tfgamuserguid ,
                                             short AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                             decimal AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                             decimal AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                             DateTime AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                             DateTime AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                             string AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                             string AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                             decimal AV87Wp_downloadappds_26_tfemployeebalance ,
                                             decimal AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             string A108EmployeeLastName ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             long A100CompanyId ,
                                             string A101CompanyName ,
                                             string A111GAMUserGUID ,
                                             decimal A146EmployeeVactionDays ,
                                             string A188EmployeeAPIPassword ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             DateTime A178EmployeeVacationDaysSetDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[35];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeName, T1.EmployeeBalance, T1.EmployeeAPIPassword, T1.EmployeeVacationDaysSetDate, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeEmail, T1.EmployeeLastName, T1.EmployeeFirstName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeFirstName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeLastName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.CompanyId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T2.CompanyName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.GAMUserGUID) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeAPIPassword) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
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
         if ( ! (0==AV63Wp_downloadappds_2_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV63Wp_downloadappds_2_tfemployeeid)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV64Wp_downloadappds_3_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV64Wp_downloadappds_3_tfemployeeid_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName like :lV65Wp_downloadappds_4_tfemployeefirstname)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName = ( :AV66Wp_downloadappds_5_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName like :lV67Wp_downloadappds_6_tfemployeelastname)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName = ( :AV68Wp_downloadappds_7_tfemployeelastname_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV69Wp_downloadappds_8_tfemployeename)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV70Wp_downloadappds_9_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV71Wp_downloadappds_10_tfemployeeemail)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV72Wp_downloadappds_11_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( ! (0==AV73Wp_downloadappds_12_tfcompanyid) )
         {
            AddWhere(sWhereString, "(T1.CompanyId >= :AV73Wp_downloadappds_12_tfcompanyid)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (0==AV74Wp_downloadappds_13_tfcompanyid_to) )
         {
            AddWhere(sWhereString, "(T1.CompanyId <= :AV74Wp_downloadappds_13_tfcompanyid_to)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV75Wp_downloadappds_14_tfcompanyname)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV76Wp_downloadappds_15_tfcompanyname_sel))");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid)) ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID like :lV78Wp_downloadappds_17_tfgamuserguid)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ! ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID = ( :AV79Wp_downloadappds_18_tfgamuserguid_sel))");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.GAMUserGUID))=0))");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Wp_downloadappds_20_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV81Wp_downloadappds_20_tfemployeevactiondays)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wp_downloadappds_21_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV82Wp_downloadappds_21_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wp_downloadappds_22_tfemployeevacationdayssetdate) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate >= :AV83Wp_downloadappds_22_tfemployeevacationdayssetdate)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate <= :AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword like :lV85Wp_downloadappds_24_tfemployeeapipassword)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ! ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword = ( :AV86Wp_downloadappds_25_tfemployeeapipassword_sel))");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeAPIPassword))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wp_downloadappds_26_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV87Wp_downloadappds_26_tfemployeebalance)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wp_downloadappds_27_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV88Wp_downloadappds_27_tfemployeebalance_to)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00CL5( IGxContext context ,
                                             string AV62Wp_downloadappds_1_filterfulltext ,
                                             long AV63Wp_downloadappds_2_tfemployeeid ,
                                             long AV64Wp_downloadappds_3_tfemployeeid_to ,
                                             string AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                             string AV65Wp_downloadappds_4_tfemployeefirstname ,
                                             string AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                             string AV67Wp_downloadappds_6_tfemployeelastname ,
                                             string AV70Wp_downloadappds_9_tfemployeename_sel ,
                                             string AV69Wp_downloadappds_8_tfemployeename ,
                                             string AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                             string AV71Wp_downloadappds_10_tfemployeeemail ,
                                             long AV73Wp_downloadappds_12_tfcompanyid ,
                                             long AV74Wp_downloadappds_13_tfcompanyid_to ,
                                             string AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                             string AV75Wp_downloadappds_14_tfcompanyname ,
                                             short AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                             string AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                             string AV78Wp_downloadappds_17_tfgamuserguid ,
                                             short AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                             decimal AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                             decimal AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                             DateTime AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                             DateTime AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                             string AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                             string AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                             decimal AV87Wp_downloadappds_26_tfemployeebalance ,
                                             decimal AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             string A108EmployeeLastName ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             long A100CompanyId ,
                                             string A101CompanyName ,
                                             string A111GAMUserGUID ,
                                             decimal A146EmployeeVactionDays ,
                                             string A188EmployeeAPIPassword ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             DateTime A178EmployeeVacationDaysSetDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[35];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeEmail, T1.EmployeeBalance, T1.EmployeeAPIPassword, T1.EmployeeVacationDaysSetDate, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeName, T1.EmployeeLastName, T1.EmployeeFirstName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeFirstName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeLastName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.CompanyId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T2.CompanyName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.GAMUserGUID) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeAPIPassword) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
         }
         if ( ! (0==AV63Wp_downloadappds_2_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV63Wp_downloadappds_2_tfemployeeid)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (0==AV64Wp_downloadappds_3_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV64Wp_downloadappds_3_tfemployeeid_to)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName like :lV65Wp_downloadappds_4_tfemployeefirstname)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName = ( :AV66Wp_downloadappds_5_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName like :lV67Wp_downloadappds_6_tfemployeelastname)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName = ( :AV68Wp_downloadappds_7_tfemployeelastname_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV69Wp_downloadappds_8_tfemployeename)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV70Wp_downloadappds_9_tfemployeename_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV71Wp_downloadappds_10_tfemployeeemail)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV72Wp_downloadappds_11_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( ! (0==AV73Wp_downloadappds_12_tfcompanyid) )
         {
            AddWhere(sWhereString, "(T1.CompanyId >= :AV73Wp_downloadappds_12_tfcompanyid)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (0==AV74Wp_downloadappds_13_tfcompanyid_to) )
         {
            AddWhere(sWhereString, "(T1.CompanyId <= :AV74Wp_downloadappds_13_tfcompanyid_to)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV75Wp_downloadappds_14_tfcompanyname)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV76Wp_downloadappds_15_tfcompanyname_sel))");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid)) ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID like :lV78Wp_downloadappds_17_tfgamuserguid)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ! ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID = ( :AV79Wp_downloadappds_18_tfgamuserguid_sel))");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.GAMUserGUID))=0))");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Wp_downloadappds_20_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV81Wp_downloadappds_20_tfemployeevactiondays)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wp_downloadappds_21_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV82Wp_downloadappds_21_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wp_downloadappds_22_tfemployeevacationdayssetdate) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate >= :AV83Wp_downloadappds_22_tfemployeevacationdayssetdate)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate <= :AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword like :lV85Wp_downloadappds_24_tfemployeeapipassword)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ! ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword = ( :AV86Wp_downloadappds_25_tfemployeeapipassword_sel))");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeAPIPassword))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wp_downloadappds_26_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV87Wp_downloadappds_26_tfemployeebalance)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wp_downloadappds_27_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV88Wp_downloadappds_27_tfemployeebalance_to)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeEmail";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00CL6( IGxContext context ,
                                             string AV62Wp_downloadappds_1_filterfulltext ,
                                             long AV63Wp_downloadappds_2_tfemployeeid ,
                                             long AV64Wp_downloadappds_3_tfemployeeid_to ,
                                             string AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                             string AV65Wp_downloadappds_4_tfemployeefirstname ,
                                             string AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                             string AV67Wp_downloadappds_6_tfemployeelastname ,
                                             string AV70Wp_downloadappds_9_tfemployeename_sel ,
                                             string AV69Wp_downloadappds_8_tfemployeename ,
                                             string AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                             string AV71Wp_downloadappds_10_tfemployeeemail ,
                                             long AV73Wp_downloadappds_12_tfcompanyid ,
                                             long AV74Wp_downloadappds_13_tfcompanyid_to ,
                                             string AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                             string AV75Wp_downloadappds_14_tfcompanyname ,
                                             short AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                             string AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                             string AV78Wp_downloadappds_17_tfgamuserguid ,
                                             short AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                             decimal AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                             decimal AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                             DateTime AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                             DateTime AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                             string AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                             string AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                             decimal AV87Wp_downloadappds_26_tfemployeebalance ,
                                             decimal AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             string A108EmployeeLastName ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             long A100CompanyId ,
                                             string A101CompanyName ,
                                             string A111GAMUserGUID ,
                                             decimal A146EmployeeVactionDays ,
                                             string A188EmployeeAPIPassword ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             DateTime A178EmployeeVacationDaysSetDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[35];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeBalance, T1.EmployeeAPIPassword, T1.EmployeeVacationDaysSetDate, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeLastName, T1.EmployeeFirstName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeFirstName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeLastName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.CompanyId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T2.CompanyName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.GAMUserGUID) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeAPIPassword) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
            GXv_int9[9] = 1;
            GXv_int9[10] = 1;
         }
         if ( ! (0==AV63Wp_downloadappds_2_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV63Wp_downloadappds_2_tfemployeeid)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (0==AV64Wp_downloadappds_3_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV64Wp_downloadappds_3_tfemployeeid_to)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName like :lV65Wp_downloadappds_4_tfemployeefirstname)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName = ( :AV66Wp_downloadappds_5_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName like :lV67Wp_downloadappds_6_tfemployeelastname)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName = ( :AV68Wp_downloadappds_7_tfemployeelastname_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV69Wp_downloadappds_8_tfemployeename)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV70Wp_downloadappds_9_tfemployeename_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV71Wp_downloadappds_10_tfemployeeemail)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV72Wp_downloadappds_11_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( ! (0==AV73Wp_downloadappds_12_tfcompanyid) )
         {
            AddWhere(sWhereString, "(T1.CompanyId >= :AV73Wp_downloadappds_12_tfcompanyid)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! (0==AV74Wp_downloadappds_13_tfcompanyid_to) )
         {
            AddWhere(sWhereString, "(T1.CompanyId <= :AV74Wp_downloadappds_13_tfcompanyid_to)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV75Wp_downloadappds_14_tfcompanyname)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV76Wp_downloadappds_15_tfcompanyname_sel))");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid)) ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID like :lV78Wp_downloadappds_17_tfgamuserguid)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ! ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID = ( :AV79Wp_downloadappds_18_tfgamuserguid_sel))");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.GAMUserGUID))=0))");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Wp_downloadappds_20_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV81Wp_downloadappds_20_tfemployeevactiondays)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wp_downloadappds_21_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV82Wp_downloadappds_21_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wp_downloadappds_22_tfemployeevacationdayssetdate) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate >= :AV83Wp_downloadappds_22_tfemployeevacationdayssetdate)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate <= :AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword like :lV85Wp_downloadappds_24_tfemployeeapipassword)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ! ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword = ( :AV86Wp_downloadappds_25_tfemployeeapipassword_sel))");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeAPIPassword))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wp_downloadappds_26_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV87Wp_downloadappds_26_tfemployeebalance)");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wp_downloadappds_27_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV88Wp_downloadappds_27_tfemployeebalance_to)");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CompanyId";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00CL7( IGxContext context ,
                                             string AV62Wp_downloadappds_1_filterfulltext ,
                                             long AV63Wp_downloadappds_2_tfemployeeid ,
                                             long AV64Wp_downloadappds_3_tfemployeeid_to ,
                                             string AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                             string AV65Wp_downloadappds_4_tfemployeefirstname ,
                                             string AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                             string AV67Wp_downloadappds_6_tfemployeelastname ,
                                             string AV70Wp_downloadappds_9_tfemployeename_sel ,
                                             string AV69Wp_downloadappds_8_tfemployeename ,
                                             string AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                             string AV71Wp_downloadappds_10_tfemployeeemail ,
                                             long AV73Wp_downloadappds_12_tfcompanyid ,
                                             long AV74Wp_downloadappds_13_tfcompanyid_to ,
                                             string AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                             string AV75Wp_downloadappds_14_tfcompanyname ,
                                             short AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                             string AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                             string AV78Wp_downloadappds_17_tfgamuserguid ,
                                             short AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                             decimal AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                             decimal AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                             DateTime AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                             DateTime AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                             string AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                             string AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                             decimal AV87Wp_downloadappds_26_tfemployeebalance ,
                                             decimal AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             string A108EmployeeLastName ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             long A100CompanyId ,
                                             string A101CompanyName ,
                                             string A111GAMUserGUID ,
                                             decimal A146EmployeeVactionDays ,
                                             string A188EmployeeAPIPassword ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             DateTime A178EmployeeVacationDaysSetDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[35];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.GAMUserGUID, T1.EmployeeBalance, T1.EmployeeAPIPassword, T1.EmployeeVacationDaysSetDate, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeLastName, T1.EmployeeFirstName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeFirstName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeLastName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.CompanyId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T2.CompanyName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.GAMUserGUID) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeAPIPassword) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
            GXv_int11[8] = 1;
            GXv_int11[9] = 1;
            GXv_int11[10] = 1;
         }
         if ( ! (0==AV63Wp_downloadappds_2_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV63Wp_downloadappds_2_tfemployeeid)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! (0==AV64Wp_downloadappds_3_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV64Wp_downloadappds_3_tfemployeeid_to)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName like :lV65Wp_downloadappds_4_tfemployeefirstname)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName = ( :AV66Wp_downloadappds_5_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName like :lV67Wp_downloadappds_6_tfemployeelastname)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName = ( :AV68Wp_downloadappds_7_tfemployeelastname_sel))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV69Wp_downloadappds_8_tfemployeename)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV70Wp_downloadappds_9_tfemployeename_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV71Wp_downloadappds_10_tfemployeeemail)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV72Wp_downloadappds_11_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( ! (0==AV73Wp_downloadappds_12_tfcompanyid) )
         {
            AddWhere(sWhereString, "(T1.CompanyId >= :AV73Wp_downloadappds_12_tfcompanyid)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! (0==AV74Wp_downloadappds_13_tfcompanyid_to) )
         {
            AddWhere(sWhereString, "(T1.CompanyId <= :AV74Wp_downloadappds_13_tfcompanyid_to)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV75Wp_downloadappds_14_tfcompanyname)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV76Wp_downloadappds_15_tfcompanyname_sel))");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid)) ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID like :lV78Wp_downloadappds_17_tfgamuserguid)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ! ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID = ( :AV79Wp_downloadappds_18_tfgamuserguid_sel))");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.GAMUserGUID))=0))");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Wp_downloadappds_20_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV81Wp_downloadappds_20_tfemployeevactiondays)");
         }
         else
         {
            GXv_int11[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wp_downloadappds_21_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV82Wp_downloadappds_21_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int11[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wp_downloadappds_22_tfemployeevacationdayssetdate) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate >= :AV83Wp_downloadappds_22_tfemployeevacationdayssetdate)");
         }
         else
         {
            GXv_int11[29] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate <= :AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to)");
         }
         else
         {
            GXv_int11[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword like :lV85Wp_downloadappds_24_tfemployeeapipassword)");
         }
         else
         {
            GXv_int11[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ! ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword = ( :AV86Wp_downloadappds_25_tfemployeeapipassword_sel))");
         }
         else
         {
            GXv_int11[32] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeAPIPassword))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wp_downloadappds_26_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV87Wp_downloadappds_26_tfemployeebalance)");
         }
         else
         {
            GXv_int11[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wp_downloadappds_27_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV88Wp_downloadappds_27_tfemployeebalance_to)");
         }
         else
         {
            GXv_int11[34] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.GAMUserGUID";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00CL8( IGxContext context ,
                                             string AV62Wp_downloadappds_1_filterfulltext ,
                                             long AV63Wp_downloadappds_2_tfemployeeid ,
                                             long AV64Wp_downloadappds_3_tfemployeeid_to ,
                                             string AV66Wp_downloadappds_5_tfemployeefirstname_sel ,
                                             string AV65Wp_downloadappds_4_tfemployeefirstname ,
                                             string AV68Wp_downloadappds_7_tfemployeelastname_sel ,
                                             string AV67Wp_downloadappds_6_tfemployeelastname ,
                                             string AV70Wp_downloadappds_9_tfemployeename_sel ,
                                             string AV69Wp_downloadappds_8_tfemployeename ,
                                             string AV72Wp_downloadappds_11_tfemployeeemail_sel ,
                                             string AV71Wp_downloadappds_10_tfemployeeemail ,
                                             long AV73Wp_downloadappds_12_tfcompanyid ,
                                             long AV74Wp_downloadappds_13_tfcompanyid_to ,
                                             string AV76Wp_downloadappds_15_tfcompanyname_sel ,
                                             string AV75Wp_downloadappds_14_tfcompanyname ,
                                             short AV77Wp_downloadappds_16_tfemployeeismanager_sel ,
                                             string AV79Wp_downloadappds_18_tfgamuserguid_sel ,
                                             string AV78Wp_downloadappds_17_tfgamuserguid ,
                                             short AV80Wp_downloadappds_19_tfemployeeisactive_sel ,
                                             decimal AV81Wp_downloadappds_20_tfemployeevactiondays ,
                                             decimal AV82Wp_downloadappds_21_tfemployeevactiondays_to ,
                                             DateTime AV83Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                             DateTime AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                             string AV86Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                             string AV85Wp_downloadappds_24_tfemployeeapipassword ,
                                             decimal AV87Wp_downloadappds_26_tfemployeebalance ,
                                             decimal AV88Wp_downloadappds_27_tfemployeebalance_to ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             string A108EmployeeLastName ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             long A100CompanyId ,
                                             string A101CompanyName ,
                                             string A111GAMUserGUID ,
                                             decimal A146EmployeeVactionDays ,
                                             string A188EmployeeAPIPassword ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             DateTime A178EmployeeVacationDaysSetDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[35];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeAPIPassword, T1.EmployeeBalance, T1.EmployeeVacationDaysSetDate, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeLastName, T1.EmployeeFirstName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_downloadappds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeFirstName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeLastName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.CompanyId,'9999999999'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T2.CompanyName) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.GAMUserGUID) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeAPIPassword) like '%' || LOWER(:lV62Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'90.9'), 2) like '%' || :lV62Wp_downloadappds_1_filterfulltext))");
         }
         else
         {
            GXv_int13[0] = 1;
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
            GXv_int13[8] = 1;
            GXv_int13[9] = 1;
            GXv_int13[10] = 1;
         }
         if ( ! (0==AV63Wp_downloadappds_2_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV63Wp_downloadappds_2_tfemployeeid)");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! (0==AV64Wp_downloadappds_3_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV64Wp_downloadappds_3_tfemployeeid_to)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_downloadappds_4_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName like :lV65Wp_downloadappds_4_tfemployeefirstname)");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_downloadappds_5_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName = ( :AV66Wp_downloadappds_5_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( StringUtil.StrCmp(AV66Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wp_downloadappds_6_tfemployeelastname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName like :lV67Wp_downloadappds_6_tfemployeelastname)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_7_tfemployeelastname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName = ( :AV68Wp_downloadappds_7_tfemployeelastname_sel))");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_downloadappds_8_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV69Wp_downloadappds_8_tfemployeename)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_9_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV70Wp_downloadappds_9_tfemployeename_sel))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_downloadappds_10_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV71Wp_downloadappds_10_tfemployeeemail)");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_11_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV72Wp_downloadappds_11_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( ! (0==AV73Wp_downloadappds_12_tfcompanyid) )
         {
            AddWhere(sWhereString, "(T1.CompanyId >= :AV73Wp_downloadappds_12_tfcompanyid)");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( ! (0==AV74Wp_downloadappds_13_tfcompanyid_to) )
         {
            AddWhere(sWhereString, "(T1.CompanyId <= :AV74Wp_downloadappds_13_tfcompanyid_to)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wp_downloadappds_14_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV75Wp_downloadappds_14_tfcompanyname)");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wp_downloadappds_15_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV76Wp_downloadappds_15_tfcompanyname_sel))");
         }
         else
         {
            GXv_int13[24] = 1;
         }
         if ( StringUtil.StrCmp(AV76Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV77Wp_downloadappds_16_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_17_tfgamuserguid)) ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID like :lV78Wp_downloadappds_17_tfgamuserguid)");
         }
         else
         {
            GXv_int13[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wp_downloadappds_18_tfgamuserguid_sel)) && ! ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID = ( :AV79Wp_downloadappds_18_tfgamuserguid_sel))");
         }
         else
         {
            GXv_int13[26] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.GAMUserGUID))=0))");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV80Wp_downloadappds_19_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Wp_downloadappds_20_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV81Wp_downloadappds_20_tfemployeevactiondays)");
         }
         else
         {
            GXv_int13[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Wp_downloadappds_21_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV82Wp_downloadappds_21_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int13[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wp_downloadappds_22_tfemployeevacationdayssetdate) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate >= :AV83Wp_downloadappds_22_tfemployeevacationdayssetdate)");
         }
         else
         {
            GXv_int13[29] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate <= :AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to)");
         }
         else
         {
            GXv_int13[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wp_downloadappds_24_tfemployeeapipassword)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword like :lV85Wp_downloadappds_24_tfemployeeapipassword)");
         }
         else
         {
            GXv_int13[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wp_downloadappds_25_tfemployeeapipassword_sel)) && ! ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword = ( :AV86Wp_downloadappds_25_tfemployeeapipassword_sel))");
         }
         else
         {
            GXv_int13[32] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeAPIPassword))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wp_downloadappds_26_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV87Wp_downloadappds_26_tfemployeebalance)");
         }
         else
         {
            GXv_int13[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wp_downloadappds_27_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV88Wp_downloadappds_27_tfemployeebalance_to)");
         }
         else
         {
            GXv_int13[34] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeAPIPassword";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CL2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (bool)dynConstraints[38] , (bool)dynConstraints[39] , (DateTime)dynConstraints[40] );
               case 1 :
                     return conditional_P00CL3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (bool)dynConstraints[38] , (bool)dynConstraints[39] , (DateTime)dynConstraints[40] );
               case 2 :
                     return conditional_P00CL4(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (bool)dynConstraints[38] , (bool)dynConstraints[39] , (DateTime)dynConstraints[40] );
               case 3 :
                     return conditional_P00CL5(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (bool)dynConstraints[38] , (bool)dynConstraints[39] , (DateTime)dynConstraints[40] );
               case 4 :
                     return conditional_P00CL6(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (bool)dynConstraints[38] , (bool)dynConstraints[39] , (DateTime)dynConstraints[40] );
               case 5 :
                     return conditional_P00CL7(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (bool)dynConstraints[38] , (bool)dynConstraints[39] , (DateTime)dynConstraints[40] );
               case 6 :
                     return conditional_P00CL8(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (bool)dynConstraints[38] , (bool)dynConstraints[39] , (DateTime)dynConstraints[40] );
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
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CL2;
          prmP00CL2 = new Object[] {
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_downloadappds_2_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV64Wp_downloadappds_3_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV65Wp_downloadappds_4_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV66Wp_downloadappds_5_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV67Wp_downloadappds_6_tfemployeelastname",GXType.Char,100,0) ,
          new ParDef("AV68Wp_downloadappds_7_tfemployeelastname_sel",GXType.Char,100,0) ,
          new ParDef("lV69Wp_downloadappds_8_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV70Wp_downloadappds_9_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV71Wp_downloadappds_10_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Wp_downloadappds_11_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV73Wp_downloadappds_12_tfcompanyid",GXType.Int64,10,0) ,
          new ParDef("AV74Wp_downloadappds_13_tfcompanyid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Wp_downloadappds_14_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV76Wp_downloadappds_15_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV78Wp_downloadappds_17_tfgamuserguid",GXType.VarChar,100,60) ,
          new ParDef("AV79Wp_downloadappds_18_tfgamuserguid_sel",GXType.VarChar,100,60) ,
          new ParDef("AV81Wp_downloadappds_20_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV82Wp_downloadappds_21_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV83Wp_downloadappds_22_tfemployeevacationdayssetdate",GXType.Date,8,0) ,
          new ParDef("AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to",GXType.Date,8,0) ,
          new ParDef("lV85Wp_downloadappds_24_tfemployeeapipassword",GXType.VarChar,40,0) ,
          new ParDef("AV86Wp_downloadappds_25_tfemployeeapipassword_sel",GXType.VarChar,40,0) ,
          new ParDef("AV87Wp_downloadappds_26_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV88Wp_downloadappds_27_tfemployeebalance_to",GXType.Number,4,1)
          };
          Object[] prmP00CL3;
          prmP00CL3 = new Object[] {
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_downloadappds_2_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV64Wp_downloadappds_3_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV65Wp_downloadappds_4_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV66Wp_downloadappds_5_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV67Wp_downloadappds_6_tfemployeelastname",GXType.Char,100,0) ,
          new ParDef("AV68Wp_downloadappds_7_tfemployeelastname_sel",GXType.Char,100,0) ,
          new ParDef("lV69Wp_downloadappds_8_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV70Wp_downloadappds_9_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV71Wp_downloadappds_10_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Wp_downloadappds_11_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV73Wp_downloadappds_12_tfcompanyid",GXType.Int64,10,0) ,
          new ParDef("AV74Wp_downloadappds_13_tfcompanyid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Wp_downloadappds_14_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV76Wp_downloadappds_15_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV78Wp_downloadappds_17_tfgamuserguid",GXType.VarChar,100,60) ,
          new ParDef("AV79Wp_downloadappds_18_tfgamuserguid_sel",GXType.VarChar,100,60) ,
          new ParDef("AV81Wp_downloadappds_20_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV82Wp_downloadappds_21_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV83Wp_downloadappds_22_tfemployeevacationdayssetdate",GXType.Date,8,0) ,
          new ParDef("AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to",GXType.Date,8,0) ,
          new ParDef("lV85Wp_downloadappds_24_tfemployeeapipassword",GXType.VarChar,40,0) ,
          new ParDef("AV86Wp_downloadappds_25_tfemployeeapipassword_sel",GXType.VarChar,40,0) ,
          new ParDef("AV87Wp_downloadappds_26_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV88Wp_downloadappds_27_tfemployeebalance_to",GXType.Number,4,1)
          };
          Object[] prmP00CL4;
          prmP00CL4 = new Object[] {
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_downloadappds_2_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV64Wp_downloadappds_3_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV65Wp_downloadappds_4_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV66Wp_downloadappds_5_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV67Wp_downloadappds_6_tfemployeelastname",GXType.Char,100,0) ,
          new ParDef("AV68Wp_downloadappds_7_tfemployeelastname_sel",GXType.Char,100,0) ,
          new ParDef("lV69Wp_downloadappds_8_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV70Wp_downloadappds_9_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV71Wp_downloadappds_10_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Wp_downloadappds_11_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV73Wp_downloadappds_12_tfcompanyid",GXType.Int64,10,0) ,
          new ParDef("AV74Wp_downloadappds_13_tfcompanyid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Wp_downloadappds_14_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV76Wp_downloadappds_15_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV78Wp_downloadappds_17_tfgamuserguid",GXType.VarChar,100,60) ,
          new ParDef("AV79Wp_downloadappds_18_tfgamuserguid_sel",GXType.VarChar,100,60) ,
          new ParDef("AV81Wp_downloadappds_20_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV82Wp_downloadappds_21_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV83Wp_downloadappds_22_tfemployeevacationdayssetdate",GXType.Date,8,0) ,
          new ParDef("AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to",GXType.Date,8,0) ,
          new ParDef("lV85Wp_downloadappds_24_tfemployeeapipassword",GXType.VarChar,40,0) ,
          new ParDef("AV86Wp_downloadappds_25_tfemployeeapipassword_sel",GXType.VarChar,40,0) ,
          new ParDef("AV87Wp_downloadappds_26_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV88Wp_downloadappds_27_tfemployeebalance_to",GXType.Number,4,1)
          };
          Object[] prmP00CL5;
          prmP00CL5 = new Object[] {
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_downloadappds_2_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV64Wp_downloadappds_3_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV65Wp_downloadappds_4_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV66Wp_downloadappds_5_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV67Wp_downloadappds_6_tfemployeelastname",GXType.Char,100,0) ,
          new ParDef("AV68Wp_downloadappds_7_tfemployeelastname_sel",GXType.Char,100,0) ,
          new ParDef("lV69Wp_downloadappds_8_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV70Wp_downloadappds_9_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV71Wp_downloadappds_10_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Wp_downloadappds_11_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV73Wp_downloadappds_12_tfcompanyid",GXType.Int64,10,0) ,
          new ParDef("AV74Wp_downloadappds_13_tfcompanyid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Wp_downloadappds_14_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV76Wp_downloadappds_15_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV78Wp_downloadappds_17_tfgamuserguid",GXType.VarChar,100,60) ,
          new ParDef("AV79Wp_downloadappds_18_tfgamuserguid_sel",GXType.VarChar,100,60) ,
          new ParDef("AV81Wp_downloadappds_20_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV82Wp_downloadappds_21_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV83Wp_downloadappds_22_tfemployeevacationdayssetdate",GXType.Date,8,0) ,
          new ParDef("AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to",GXType.Date,8,0) ,
          new ParDef("lV85Wp_downloadappds_24_tfemployeeapipassword",GXType.VarChar,40,0) ,
          new ParDef("AV86Wp_downloadappds_25_tfemployeeapipassword_sel",GXType.VarChar,40,0) ,
          new ParDef("AV87Wp_downloadappds_26_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV88Wp_downloadappds_27_tfemployeebalance_to",GXType.Number,4,1)
          };
          Object[] prmP00CL6;
          prmP00CL6 = new Object[] {
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_downloadappds_2_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV64Wp_downloadappds_3_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV65Wp_downloadappds_4_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV66Wp_downloadappds_5_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV67Wp_downloadappds_6_tfemployeelastname",GXType.Char,100,0) ,
          new ParDef("AV68Wp_downloadappds_7_tfemployeelastname_sel",GXType.Char,100,0) ,
          new ParDef("lV69Wp_downloadappds_8_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV70Wp_downloadappds_9_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV71Wp_downloadappds_10_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Wp_downloadappds_11_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV73Wp_downloadappds_12_tfcompanyid",GXType.Int64,10,0) ,
          new ParDef("AV74Wp_downloadappds_13_tfcompanyid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Wp_downloadappds_14_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV76Wp_downloadappds_15_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV78Wp_downloadappds_17_tfgamuserguid",GXType.VarChar,100,60) ,
          new ParDef("AV79Wp_downloadappds_18_tfgamuserguid_sel",GXType.VarChar,100,60) ,
          new ParDef("AV81Wp_downloadappds_20_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV82Wp_downloadappds_21_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV83Wp_downloadappds_22_tfemployeevacationdayssetdate",GXType.Date,8,0) ,
          new ParDef("AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to",GXType.Date,8,0) ,
          new ParDef("lV85Wp_downloadappds_24_tfemployeeapipassword",GXType.VarChar,40,0) ,
          new ParDef("AV86Wp_downloadappds_25_tfemployeeapipassword_sel",GXType.VarChar,40,0) ,
          new ParDef("AV87Wp_downloadappds_26_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV88Wp_downloadappds_27_tfemployeebalance_to",GXType.Number,4,1)
          };
          Object[] prmP00CL7;
          prmP00CL7 = new Object[] {
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_downloadappds_2_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV64Wp_downloadappds_3_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV65Wp_downloadappds_4_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV66Wp_downloadappds_5_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV67Wp_downloadappds_6_tfemployeelastname",GXType.Char,100,0) ,
          new ParDef("AV68Wp_downloadappds_7_tfemployeelastname_sel",GXType.Char,100,0) ,
          new ParDef("lV69Wp_downloadappds_8_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV70Wp_downloadappds_9_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV71Wp_downloadappds_10_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Wp_downloadappds_11_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV73Wp_downloadappds_12_tfcompanyid",GXType.Int64,10,0) ,
          new ParDef("AV74Wp_downloadappds_13_tfcompanyid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Wp_downloadappds_14_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV76Wp_downloadappds_15_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV78Wp_downloadappds_17_tfgamuserguid",GXType.VarChar,100,60) ,
          new ParDef("AV79Wp_downloadappds_18_tfgamuserguid_sel",GXType.VarChar,100,60) ,
          new ParDef("AV81Wp_downloadappds_20_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV82Wp_downloadappds_21_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV83Wp_downloadappds_22_tfemployeevacationdayssetdate",GXType.Date,8,0) ,
          new ParDef("AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to",GXType.Date,8,0) ,
          new ParDef("lV85Wp_downloadappds_24_tfemployeeapipassword",GXType.VarChar,40,0) ,
          new ParDef("AV86Wp_downloadappds_25_tfemployeeapipassword_sel",GXType.VarChar,40,0) ,
          new ParDef("AV87Wp_downloadappds_26_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV88Wp_downloadappds_27_tfemployeebalance_to",GXType.Number,4,1)
          };
          Object[] prmP00CL8;
          prmP00CL8 = new Object[] {
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_downloadappds_2_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV64Wp_downloadappds_3_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV65Wp_downloadappds_4_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV66Wp_downloadappds_5_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV67Wp_downloadappds_6_tfemployeelastname",GXType.Char,100,0) ,
          new ParDef("AV68Wp_downloadappds_7_tfemployeelastname_sel",GXType.Char,100,0) ,
          new ParDef("lV69Wp_downloadappds_8_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV70Wp_downloadappds_9_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV71Wp_downloadappds_10_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Wp_downloadappds_11_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV73Wp_downloadappds_12_tfcompanyid",GXType.Int64,10,0) ,
          new ParDef("AV74Wp_downloadappds_13_tfcompanyid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Wp_downloadappds_14_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV76Wp_downloadappds_15_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV78Wp_downloadappds_17_tfgamuserguid",GXType.VarChar,100,60) ,
          new ParDef("AV79Wp_downloadappds_18_tfgamuserguid_sel",GXType.VarChar,100,60) ,
          new ParDef("AV81Wp_downloadappds_20_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV82Wp_downloadappds_21_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV83Wp_downloadappds_22_tfemployeevacationdayssetdate",GXType.Date,8,0) ,
          new ParDef("AV84Wp_downloadappds_23_tfemployeevacationdayssetdate_to",GXType.Date,8,0) ,
          new ParDef("lV85Wp_downloadappds_24_tfemployeeapipassword",GXType.VarChar,40,0) ,
          new ParDef("AV86Wp_downloadappds_25_tfemployeeapipassword_sel",GXType.VarChar,40,0) ,
          new ParDef("AV87Wp_downloadappds_26_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV88Wp_downloadappds_27_tfemployeebalance_to",GXType.Number,4,1)
          };
          def= new CursorDef[] {
              new CursorDef("P00CL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CL8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL8,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
       }
    }

 }

}
