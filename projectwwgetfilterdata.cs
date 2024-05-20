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
   public class projectwwgetfilterdata : GXProcedure
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
            return "projectww_Services_Execute" ;
         }

      }

      public projectwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public projectwwgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         projectwwgetfilterdata objprojectwwgetfilterdata;
         objprojectwwgetfilterdata = new projectwwgetfilterdata();
         objprojectwwgetfilterdata.AV35DDOName = aP0_DDOName;
         objprojectwwgetfilterdata.AV36SearchTxtParms = aP1_SearchTxtParms;
         objprojectwwgetfilterdata.AV37SearchTxtTo = aP2_SearchTxtTo;
         objprojectwwgetfilterdata.AV38OptionsJson = "" ;
         objprojectwwgetfilterdata.AV39OptionsDescJson = "" ;
         objprojectwwgetfilterdata.AV40OptionIndexesJson = "" ;
         objprojectwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objprojectwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objprojectwwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((projectwwgetfilterdata)stateInfo).executePrivate();
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
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22MaxItems = 10;
         AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
         AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PROJECTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROJECTNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PROJECTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROJECTDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PROJECTMANAGERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROJECTMANAGERNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("ProjectWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProjectWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ProjectWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV13TFProjectName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV14TFProjectName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTDESCRIPTION") == 0 )
            {
               AV15TFProjectDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTDESCRIPTION_SEL") == 0 )
            {
               AV16TFProjectDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTMANAGERNAME") == 0 )
            {
               AV44TFProjectManagerName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTMANAGERNAME_SEL") == 0 )
            {
               AV45TFProjectManagerName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTSTATUS_SEL") == 0 )
            {
               AV17TFProjectStatus_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV18TFProjectStatus_Sels.FromJSonString(AV17TFProjectStatus_SelsJson, null);
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROJECTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFProjectName = AV19SearchTxt;
         AV14TFProjectName_Sel = "";
         AV48Projectwwds_1_filterfulltext = AV41FilterFullText;
         AV49Projectwwds_2_tfprojectname = AV13TFProjectName;
         AV50Projectwwds_3_tfprojectname_sel = AV14TFProjectName_Sel;
         AV51Projectwwds_4_tfprojectdescription = AV15TFProjectDescription;
         AV52Projectwwds_5_tfprojectdescription_sel = AV16TFProjectDescription_Sel;
         AV53Projectwwds_6_tfprojectmanagername = AV44TFProjectManagerName;
         AV54Projectwwds_7_tfprojectmanagername_sel = AV45TFProjectManagerName_Sel;
         AV55Projectwwds_8_tfprojectstatus_sels = AV18TFProjectStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A105ProjectStatus ,
                                              AV55Projectwwds_8_tfprojectstatus_sels ,
                                              AV48Projectwwds_1_filterfulltext ,
                                              AV50Projectwwds_3_tfprojectname_sel ,
                                              AV49Projectwwds_2_tfprojectname ,
                                              AV52Projectwwds_5_tfprojectdescription_sel ,
                                              AV51Projectwwds_4_tfprojectdescription ,
                                              AV54Projectwwds_7_tfprojectmanagername_sel ,
                                              AV53Projectwwds_6_tfprojectmanagername ,
                                              AV55Projectwwds_8_tfprojectstatus_sels.Count ,
                                              A103ProjectName ,
                                              A104ProjectDescription ,
                                              A167ProjectManagerName } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV49Projectwwds_2_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV49Projectwwds_2_tfprojectname), 100, "%");
         lV51Projectwwds_4_tfprojectdescription = StringUtil.Concat( StringUtil.RTrim( AV51Projectwwds_4_tfprojectdescription), "%", "");
         lV53Projectwwds_6_tfprojectmanagername = StringUtil.PadR( StringUtil.RTrim( AV53Projectwwds_6_tfprojectmanagername), 128, "%");
         /* Using cursor P007D2 */
         pr_default.execute(0, new Object[] {lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV49Projectwwds_2_tfprojectname, AV50Projectwwds_3_tfprojectname_sel, lV51Projectwwds_4_tfprojectdescription, AV52Projectwwds_5_tfprojectdescription_sel, lV53Projectwwds_6_tfprojectmanagername, AV54Projectwwds_7_tfprojectmanagername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7D2 = false;
            A166ProjectManagerId = P007D2_A166ProjectManagerId[0];
            n166ProjectManagerId = P007D2_n166ProjectManagerId[0];
            A103ProjectName = P007D2_A103ProjectName[0];
            A167ProjectManagerName = P007D2_A167ProjectManagerName[0];
            A104ProjectDescription = P007D2_A104ProjectDescription[0];
            A105ProjectStatus = P007D2_A105ProjectStatus[0];
            A102ProjectId = P007D2_A102ProjectId[0];
            A167ProjectManagerName = P007D2_A167ProjectManagerName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007D2_A103ProjectName[0], A103ProjectName) == 0 ) )
            {
               BRK7D2 = false;
               A102ProjectId = P007D2_A102ProjectId[0];
               AV29count = (long)(AV29count+1);
               BRK7D2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) ? "<#Empty#>" : A103ProjectName);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK7D2 )
            {
               BRK7D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROJECTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFProjectDescription = AV19SearchTxt;
         AV16TFProjectDescription_Sel = "";
         AV48Projectwwds_1_filterfulltext = AV41FilterFullText;
         AV49Projectwwds_2_tfprojectname = AV13TFProjectName;
         AV50Projectwwds_3_tfprojectname_sel = AV14TFProjectName_Sel;
         AV51Projectwwds_4_tfprojectdescription = AV15TFProjectDescription;
         AV52Projectwwds_5_tfprojectdescription_sel = AV16TFProjectDescription_Sel;
         AV53Projectwwds_6_tfprojectmanagername = AV44TFProjectManagerName;
         AV54Projectwwds_7_tfprojectmanagername_sel = AV45TFProjectManagerName_Sel;
         AV55Projectwwds_8_tfprojectstatus_sels = AV18TFProjectStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A105ProjectStatus ,
                                              AV55Projectwwds_8_tfprojectstatus_sels ,
                                              AV48Projectwwds_1_filterfulltext ,
                                              AV50Projectwwds_3_tfprojectname_sel ,
                                              AV49Projectwwds_2_tfprojectname ,
                                              AV52Projectwwds_5_tfprojectdescription_sel ,
                                              AV51Projectwwds_4_tfprojectdescription ,
                                              AV54Projectwwds_7_tfprojectmanagername_sel ,
                                              AV53Projectwwds_6_tfprojectmanagername ,
                                              AV55Projectwwds_8_tfprojectstatus_sels.Count ,
                                              A103ProjectName ,
                                              A104ProjectDescription ,
                                              A167ProjectManagerName } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV49Projectwwds_2_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV49Projectwwds_2_tfprojectname), 100, "%");
         lV51Projectwwds_4_tfprojectdescription = StringUtil.Concat( StringUtil.RTrim( AV51Projectwwds_4_tfprojectdescription), "%", "");
         lV53Projectwwds_6_tfprojectmanagername = StringUtil.PadR( StringUtil.RTrim( AV53Projectwwds_6_tfprojectmanagername), 128, "%");
         /* Using cursor P007D3 */
         pr_default.execute(1, new Object[] {lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV49Projectwwds_2_tfprojectname, AV50Projectwwds_3_tfprojectname_sel, lV51Projectwwds_4_tfprojectdescription, AV52Projectwwds_5_tfprojectdescription_sel, lV53Projectwwds_6_tfprojectmanagername, AV54Projectwwds_7_tfprojectmanagername_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7D4 = false;
            A166ProjectManagerId = P007D3_A166ProjectManagerId[0];
            n166ProjectManagerId = P007D3_n166ProjectManagerId[0];
            A104ProjectDescription = P007D3_A104ProjectDescription[0];
            A167ProjectManagerName = P007D3_A167ProjectManagerName[0];
            A103ProjectName = P007D3_A103ProjectName[0];
            A105ProjectStatus = P007D3_A105ProjectStatus[0];
            A102ProjectId = P007D3_A102ProjectId[0];
            A167ProjectManagerName = P007D3_A167ProjectManagerName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007D3_A104ProjectDescription[0], A104ProjectDescription) == 0 ) )
            {
               BRK7D4 = false;
               A102ProjectId = P007D3_A102ProjectId[0];
               AV29count = (long)(AV29count+1);
               BRK7D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A104ProjectDescription)) ? "<#Empty#>" : A104ProjectDescription);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK7D4 )
            {
               BRK7D4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROJECTMANAGERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV44TFProjectManagerName = AV19SearchTxt;
         AV45TFProjectManagerName_Sel = "";
         AV48Projectwwds_1_filterfulltext = AV41FilterFullText;
         AV49Projectwwds_2_tfprojectname = AV13TFProjectName;
         AV50Projectwwds_3_tfprojectname_sel = AV14TFProjectName_Sel;
         AV51Projectwwds_4_tfprojectdescription = AV15TFProjectDescription;
         AV52Projectwwds_5_tfprojectdescription_sel = AV16TFProjectDescription_Sel;
         AV53Projectwwds_6_tfprojectmanagername = AV44TFProjectManagerName;
         AV54Projectwwds_7_tfprojectmanagername_sel = AV45TFProjectManagerName_Sel;
         AV55Projectwwds_8_tfprojectstatus_sels = AV18TFProjectStatus_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A105ProjectStatus ,
                                              AV55Projectwwds_8_tfprojectstatus_sels ,
                                              AV48Projectwwds_1_filterfulltext ,
                                              AV50Projectwwds_3_tfprojectname_sel ,
                                              AV49Projectwwds_2_tfprojectname ,
                                              AV52Projectwwds_5_tfprojectdescription_sel ,
                                              AV51Projectwwds_4_tfprojectdescription ,
                                              AV54Projectwwds_7_tfprojectmanagername_sel ,
                                              AV53Projectwwds_6_tfprojectmanagername ,
                                              AV55Projectwwds_8_tfprojectstatus_sels.Count ,
                                              A103ProjectName ,
                                              A104ProjectDescription ,
                                              A167ProjectManagerName } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV48Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Projectwwds_1_filterfulltext), "%", "");
         lV49Projectwwds_2_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV49Projectwwds_2_tfprojectname), 100, "%");
         lV51Projectwwds_4_tfprojectdescription = StringUtil.Concat( StringUtil.RTrim( AV51Projectwwds_4_tfprojectdescription), "%", "");
         lV53Projectwwds_6_tfprojectmanagername = StringUtil.PadR( StringUtil.RTrim( AV53Projectwwds_6_tfprojectmanagername), 128, "%");
         /* Using cursor P007D4 */
         pr_default.execute(2, new Object[] {lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV48Projectwwds_1_filterfulltext, lV49Projectwwds_2_tfprojectname, AV50Projectwwds_3_tfprojectname_sel, lV51Projectwwds_4_tfprojectdescription, AV52Projectwwds_5_tfprojectdescription_sel, lV53Projectwwds_6_tfprojectmanagername, AV54Projectwwds_7_tfprojectmanagername_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7D6 = false;
            A166ProjectManagerId = P007D4_A166ProjectManagerId[0];
            n166ProjectManagerId = P007D4_n166ProjectManagerId[0];
            A167ProjectManagerName = P007D4_A167ProjectManagerName[0];
            A104ProjectDescription = P007D4_A104ProjectDescription[0];
            A103ProjectName = P007D4_A103ProjectName[0];
            A105ProjectStatus = P007D4_A105ProjectStatus[0];
            A102ProjectId = P007D4_A102ProjectId[0];
            A167ProjectManagerName = P007D4_A167ProjectManagerName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007D4_A167ProjectManagerName[0], A167ProjectManagerName) == 0 ) )
            {
               BRK7D6 = false;
               A166ProjectManagerId = P007D4_A166ProjectManagerId[0];
               n166ProjectManagerId = P007D4_n166ProjectManagerId[0];
               A102ProjectId = P007D4_A102ProjectId[0];
               AV29count = (long)(AV29count+1);
               BRK7D6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A167ProjectManagerName)) ? "<#Empty#>" : A167ProjectManagerName);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK7D6 )
            {
               BRK7D6 = true;
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV13TFProjectName = "";
         AV14TFProjectName_Sel = "";
         AV15TFProjectDescription = "";
         AV16TFProjectDescription_Sel = "";
         AV44TFProjectManagerName = "";
         AV45TFProjectManagerName_Sel = "";
         AV17TFProjectStatus_SelsJson = "";
         AV18TFProjectStatus_Sels = new GxSimpleCollection<string>();
         AV48Projectwwds_1_filterfulltext = "";
         AV49Projectwwds_2_tfprojectname = "";
         AV50Projectwwds_3_tfprojectname_sel = "";
         AV51Projectwwds_4_tfprojectdescription = "";
         AV52Projectwwds_5_tfprojectdescription_sel = "";
         AV53Projectwwds_6_tfprojectmanagername = "";
         AV54Projectwwds_7_tfprojectmanagername_sel = "";
         AV55Projectwwds_8_tfprojectstatus_sels = new GxSimpleCollection<string>();
         scmdbuf = "";
         lV48Projectwwds_1_filterfulltext = "";
         lV49Projectwwds_2_tfprojectname = "";
         lV51Projectwwds_4_tfprojectdescription = "";
         lV53Projectwwds_6_tfprojectmanagername = "";
         A105ProjectStatus = "";
         A103ProjectName = "";
         A104ProjectDescription = "";
         A167ProjectManagerName = "";
         P007D2_A166ProjectManagerId = new long[1] ;
         P007D2_n166ProjectManagerId = new bool[] {false} ;
         P007D2_A103ProjectName = new string[] {""} ;
         P007D2_A167ProjectManagerName = new string[] {""} ;
         P007D2_A104ProjectDescription = new string[] {""} ;
         P007D2_A105ProjectStatus = new string[] {""} ;
         P007D2_A102ProjectId = new long[1] ;
         AV24Option = "";
         P007D3_A166ProjectManagerId = new long[1] ;
         P007D3_n166ProjectManagerId = new bool[] {false} ;
         P007D3_A104ProjectDescription = new string[] {""} ;
         P007D3_A167ProjectManagerName = new string[] {""} ;
         P007D3_A103ProjectName = new string[] {""} ;
         P007D3_A105ProjectStatus = new string[] {""} ;
         P007D3_A102ProjectId = new long[1] ;
         P007D4_A166ProjectManagerId = new long[1] ;
         P007D4_n166ProjectManagerId = new bool[] {false} ;
         P007D4_A167ProjectManagerName = new string[] {""} ;
         P007D4_A104ProjectDescription = new string[] {""} ;
         P007D4_A103ProjectName = new string[] {""} ;
         P007D4_A105ProjectStatus = new string[] {""} ;
         P007D4_A102ProjectId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.projectwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007D2_A166ProjectManagerId, P007D2_n166ProjectManagerId, P007D2_A103ProjectName, P007D2_A167ProjectManagerName, P007D2_A104ProjectDescription, P007D2_A105ProjectStatus, P007D2_A102ProjectId
               }
               , new Object[] {
               P007D3_A166ProjectManagerId, P007D3_n166ProjectManagerId, P007D3_A104ProjectDescription, P007D3_A167ProjectManagerName, P007D3_A103ProjectName, P007D3_A105ProjectStatus, P007D3_A102ProjectId
               }
               , new Object[] {
               P007D4_A166ProjectManagerId, P007D4_n166ProjectManagerId, P007D4_A167ProjectManagerName, P007D4_A104ProjectDescription, P007D4_A103ProjectName, P007D4_A105ProjectStatus, P007D4_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV46GXV1 ;
      private int AV55Projectwwds_8_tfprojectstatus_sels_Count ;
      private long A166ProjectManagerId ;
      private long A102ProjectId ;
      private long AV29count ;
      private string AV13TFProjectName ;
      private string AV14TFProjectName_Sel ;
      private string AV44TFProjectManagerName ;
      private string AV45TFProjectManagerName_Sel ;
      private string AV49Projectwwds_2_tfprojectname ;
      private string AV50Projectwwds_3_tfprojectname_sel ;
      private string AV53Projectwwds_6_tfprojectmanagername ;
      private string AV54Projectwwds_7_tfprojectmanagername_sel ;
      private string scmdbuf ;
      private string lV49Projectwwds_2_tfprojectname ;
      private string lV53Projectwwds_6_tfprojectmanagername ;
      private string A105ProjectStatus ;
      private string A103ProjectName ;
      private string A167ProjectManagerName ;
      private bool returnInSub ;
      private bool BRK7D2 ;
      private bool n166ProjectManagerId ;
      private bool BRK7D4 ;
      private bool BRK7D6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV17TFProjectStatus_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV15TFProjectDescription ;
      private string AV16TFProjectDescription_Sel ;
      private string AV48Projectwwds_1_filterfulltext ;
      private string AV51Projectwwds_4_tfprojectdescription ;
      private string AV52Projectwwds_5_tfprojectdescription_sel ;
      private string lV48Projectwwds_1_filterfulltext ;
      private string lV51Projectwwds_4_tfprojectdescription ;
      private string A104ProjectDescription ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P007D2_A166ProjectManagerId ;
      private bool[] P007D2_n166ProjectManagerId ;
      private string[] P007D2_A103ProjectName ;
      private string[] P007D2_A167ProjectManagerName ;
      private string[] P007D2_A104ProjectDescription ;
      private string[] P007D2_A105ProjectStatus ;
      private long[] P007D2_A102ProjectId ;
      private long[] P007D3_A166ProjectManagerId ;
      private bool[] P007D3_n166ProjectManagerId ;
      private string[] P007D3_A104ProjectDescription ;
      private string[] P007D3_A167ProjectManagerName ;
      private string[] P007D3_A103ProjectName ;
      private string[] P007D3_A105ProjectStatus ;
      private long[] P007D3_A102ProjectId ;
      private long[] P007D4_A166ProjectManagerId ;
      private bool[] P007D4_n166ProjectManagerId ;
      private string[] P007D4_A167ProjectManagerName ;
      private string[] P007D4_A104ProjectDescription ;
      private string[] P007D4_A103ProjectName ;
      private string[] P007D4_A105ProjectStatus ;
      private long[] P007D4_A102ProjectId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV18TFProjectStatus_Sels ;
      private GxSimpleCollection<string> AV55Projectwwds_8_tfprojectstatus_sels ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class projectwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007D2( IGxContext context ,
                                             string A105ProjectStatus ,
                                             GxSimpleCollection<string> AV55Projectwwds_8_tfprojectstatus_sels ,
                                             string AV48Projectwwds_1_filterfulltext ,
                                             string AV50Projectwwds_3_tfprojectname_sel ,
                                             string AV49Projectwwds_2_tfprojectname ,
                                             string AV52Projectwwds_5_tfprojectdescription_sel ,
                                             string AV51Projectwwds_4_tfprojectdescription ,
                                             string AV54Projectwwds_7_tfprojectmanagername_sel ,
                                             string AV53Projectwwds_6_tfprojectmanagername ,
                                             int AV55Projectwwds_8_tfprojectstatus_sels_Count ,
                                             string A103ProjectName ,
                                             string A104ProjectDescription ,
                                             string A167ProjectManagerName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ProjectManagerId AS ProjectManagerId, T1.ProjectName, T2.EmployeeName AS ProjectManagerName, T1.ProjectDescription, T1.ProjectStatus, T1.ProjectId FROM (Project T1 LEFT JOIN Employee T2 ON T2.EmployeeId = T1.ProjectManagerId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Projectwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.ProjectName) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( LOWER(T1.ProjectDescription) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( 'active' like '%' || LOWER(:lV48Projectwwds_1_filterfulltext) and T1.ProjectStatus = ( 'Active')) or ( 'inactive' like '%' || LOWER(:lV48Projectwwds_1_filterfulltext) and T1.ProjectStatus = ( 'Inactive')))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Projectwwds_3_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Projectwwds_2_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.ProjectName) like LOWER(:lV49Projectwwds_2_tfprojectname))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Projectwwds_3_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV50Projectwwds_3_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProjectName = ( :AV50Projectwwds_3_tfprojectname_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Projectwwds_3_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Projectwwds_5_tfprojectdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Projectwwds_4_tfprojectdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.ProjectDescription) like LOWER(:lV51Projectwwds_4_tfprojectdescription))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Projectwwds_5_tfprojectdescription_sel)) && ! ( StringUtil.StrCmp(AV52Projectwwds_5_tfprojectdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProjectDescription = ( :AV52Projectwwds_5_tfprojectdescription_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV52Projectwwds_5_tfprojectdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProjectDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Projectwwds_7_tfprojectmanagername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Projectwwds_6_tfprojectmanagername)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeName) like LOWER(:lV53Projectwwds_6_tfprojectmanagername))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Projectwwds_7_tfprojectmanagername_sel)) && ! ( StringUtil.StrCmp(AV54Projectwwds_7_tfprojectmanagername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV54Projectwwds_7_tfprojectmanagername_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV54Projectwwds_7_tfprojectmanagername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( AV55Projectwwds_8_tfprojectstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Projectwwds_8_tfprojectstatus_sels, "T1.ProjectStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProjectName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007D3( IGxContext context ,
                                             string A105ProjectStatus ,
                                             GxSimpleCollection<string> AV55Projectwwds_8_tfprojectstatus_sels ,
                                             string AV48Projectwwds_1_filterfulltext ,
                                             string AV50Projectwwds_3_tfprojectname_sel ,
                                             string AV49Projectwwds_2_tfprojectname ,
                                             string AV52Projectwwds_5_tfprojectdescription_sel ,
                                             string AV51Projectwwds_4_tfprojectdescription ,
                                             string AV54Projectwwds_7_tfprojectmanagername_sel ,
                                             string AV53Projectwwds_6_tfprojectmanagername ,
                                             int AV55Projectwwds_8_tfprojectstatus_sels_Count ,
                                             string A103ProjectName ,
                                             string A104ProjectDescription ,
                                             string A167ProjectManagerName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ProjectManagerId AS ProjectManagerId, T1.ProjectDescription, T2.EmployeeName AS ProjectManagerName, T1.ProjectName, T1.ProjectStatus, T1.ProjectId FROM (Project T1 LEFT JOIN Employee T2 ON T2.EmployeeId = T1.ProjectManagerId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Projectwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.ProjectName) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( LOWER(T1.ProjectDescription) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( 'active' like '%' || LOWER(:lV48Projectwwds_1_filterfulltext) and T1.ProjectStatus = ( 'Active')) or ( 'inactive' like '%' || LOWER(:lV48Projectwwds_1_filterfulltext) and T1.ProjectStatus = ( 'Inactive')))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Projectwwds_3_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Projectwwds_2_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.ProjectName) like LOWER(:lV49Projectwwds_2_tfprojectname))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Projectwwds_3_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV50Projectwwds_3_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProjectName = ( :AV50Projectwwds_3_tfprojectname_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Projectwwds_3_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Projectwwds_5_tfprojectdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Projectwwds_4_tfprojectdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.ProjectDescription) like LOWER(:lV51Projectwwds_4_tfprojectdescription))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Projectwwds_5_tfprojectdescription_sel)) && ! ( StringUtil.StrCmp(AV52Projectwwds_5_tfprojectdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProjectDescription = ( :AV52Projectwwds_5_tfprojectdescription_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV52Projectwwds_5_tfprojectdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProjectDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Projectwwds_7_tfprojectmanagername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Projectwwds_6_tfprojectmanagername)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeName) like LOWER(:lV53Projectwwds_6_tfprojectmanagername))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Projectwwds_7_tfprojectmanagername_sel)) && ! ( StringUtil.StrCmp(AV54Projectwwds_7_tfprojectmanagername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV54Projectwwds_7_tfprojectmanagername_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV54Projectwwds_7_tfprojectmanagername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( AV55Projectwwds_8_tfprojectstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Projectwwds_8_tfprojectstatus_sels, "T1.ProjectStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProjectDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007D4( IGxContext context ,
                                             string A105ProjectStatus ,
                                             GxSimpleCollection<string> AV55Projectwwds_8_tfprojectstatus_sels ,
                                             string AV48Projectwwds_1_filterfulltext ,
                                             string AV50Projectwwds_3_tfprojectname_sel ,
                                             string AV49Projectwwds_2_tfprojectname ,
                                             string AV52Projectwwds_5_tfprojectdescription_sel ,
                                             string AV51Projectwwds_4_tfprojectdescription ,
                                             string AV54Projectwwds_7_tfprojectmanagername_sel ,
                                             string AV53Projectwwds_6_tfprojectmanagername ,
                                             int AV55Projectwwds_8_tfprojectstatus_sels_Count ,
                                             string A103ProjectName ,
                                             string A104ProjectDescription ,
                                             string A167ProjectManagerName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[11];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ProjectManagerId AS ProjectManagerId, T2.EmployeeName AS ProjectManagerName, T1.ProjectDescription, T1.ProjectName, T1.ProjectStatus, T1.ProjectId FROM (Project T1 LEFT JOIN Employee T2 ON T2.EmployeeId = T1.ProjectManagerId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Projectwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.ProjectName) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( LOWER(T1.ProjectDescription) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV48Projectwwds_1_filterfulltext)) or ( 'active' like '%' || LOWER(:lV48Projectwwds_1_filterfulltext) and T1.ProjectStatus = ( 'Active')) or ( 'inactive' like '%' || LOWER(:lV48Projectwwds_1_filterfulltext) and T1.ProjectStatus = ( 'Inactive')))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Projectwwds_3_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Projectwwds_2_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.ProjectName) like LOWER(:lV49Projectwwds_2_tfprojectname))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Projectwwds_3_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV50Projectwwds_3_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProjectName = ( :AV50Projectwwds_3_tfprojectname_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Projectwwds_3_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Projectwwds_5_tfprojectdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Projectwwds_4_tfprojectdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.ProjectDescription) like LOWER(:lV51Projectwwds_4_tfprojectdescription))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Projectwwds_5_tfprojectdescription_sel)) && ! ( StringUtil.StrCmp(AV52Projectwwds_5_tfprojectdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProjectDescription = ( :AV52Projectwwds_5_tfprojectdescription_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV52Projectwwds_5_tfprojectdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProjectDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Projectwwds_7_tfprojectmanagername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Projectwwds_6_tfprojectmanagername)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeName) like LOWER(:lV53Projectwwds_6_tfprojectmanagername))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Projectwwds_7_tfprojectmanagername_sel)) && ! ( StringUtil.StrCmp(AV54Projectwwds_7_tfprojectmanagername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV54Projectwwds_7_tfprojectmanagername_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV54Projectwwds_7_tfprojectmanagername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( AV55Projectwwds_8_tfprojectstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Projectwwds_8_tfprojectstatus_sels, "T1.ProjectStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeName";
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
                     return conditional_P007D2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P007D3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P007D4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP007D2;
          prmP007D2 = new Object[] {
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Projectwwds_2_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV50Projectwwds_3_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV51Projectwwds_4_tfprojectdescription",GXType.VarChar,200,0) ,
          new ParDef("AV52Projectwwds_5_tfprojectdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Projectwwds_6_tfprojectmanagername",GXType.Char,128,0) ,
          new ParDef("AV54Projectwwds_7_tfprojectmanagername_sel",GXType.Char,128,0)
          };
          Object[] prmP007D3;
          prmP007D3 = new Object[] {
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Projectwwds_2_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV50Projectwwds_3_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV51Projectwwds_4_tfprojectdescription",GXType.VarChar,200,0) ,
          new ParDef("AV52Projectwwds_5_tfprojectdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Projectwwds_6_tfprojectmanagername",GXType.Char,128,0) ,
          new ParDef("AV54Projectwwds_7_tfprojectmanagername_sel",GXType.Char,128,0)
          };
          Object[] prmP007D4;
          prmP007D4 = new Object[] {
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Projectwwds_2_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV50Projectwwds_3_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV51Projectwwds_4_tfprojectdescription",GXType.VarChar,200,0) ,
          new ParDef("AV52Projectwwds_5_tfprojectdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Projectwwds_6_tfprojectmanagername",GXType.Char,128,0) ,
          new ParDef("AV54Projectwwds_7_tfprojectmanagername_sel",GXType.Char,128,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007D3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007D4,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 100);
                ((string[]) buf[3])[0] = rslt.getString(3, 128);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 128);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 128);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
