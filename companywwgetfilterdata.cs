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
   public class companywwgetfilterdata : GXProcedure
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
            return "companyww_Services_Execute" ;
         }

      }

      public companywwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public companywwgetfilterdata( IGxContext context )
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
         companywwgetfilterdata objcompanywwgetfilterdata;
         objcompanywwgetfilterdata = new companywwgetfilterdata();
         objcompanywwgetfilterdata.AV35DDOName = aP0_DDOName;
         objcompanywwgetfilterdata.AV36SearchTxtParms = aP1_SearchTxtParms;
         objcompanywwgetfilterdata.AV37SearchTxtTo = aP2_SearchTxtTo;
         objcompanywwgetfilterdata.AV38OptionsJson = "" ;
         objcompanywwgetfilterdata.AV39OptionsDescJson = "" ;
         objcompanywwgetfilterdata.AV40OptionIndexesJson = "" ;
         objcompanywwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcompanywwgetfilterdata.initialize();
         Submit( executePrivateCatch,objcompanywwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((companywwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_COMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMPANYNAMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("CompanyWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CompanyWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("CompanyWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME") == 0 )
            {
               AV13TFCompanyName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME_SEL") == 0 )
            {
               AV14TFCompanyName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFCompanyName = AV19SearchTxt;
         AV14TFCompanyName_Sel = "";
         AV44Companywwds_1_filterfulltext = AV41FilterFullText;
         AV45Companywwds_2_tfcompanyname = AV13TFCompanyName;
         AV46Companywwds_3_tfcompanyname_sel = AV14TFCompanyName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Companywwds_1_filterfulltext ,
                                              AV46Companywwds_3_tfcompanyname_sel ,
                                              AV45Companywwds_2_tfcompanyname ,
                                              A101CompanyName } ,
                                              new int[]{
                                              }
         });
         lV44Companywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Companywwds_1_filterfulltext), "%", "");
         lV45Companywwds_2_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV45Companywwds_2_tfcompanyname), 100, "%");
         /* Using cursor P00692 */
         pr_default.execute(0, new Object[] {lV44Companywwds_1_filterfulltext, lV45Companywwds_2_tfcompanyname, AV46Companywwds_3_tfcompanyname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK692 = false;
            A101CompanyName = P00692_A101CompanyName[0];
            A100CompanyId = P00692_A100CompanyId[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00692_A101CompanyName[0], A101CompanyName) == 0 ) )
            {
               BRK692 = false;
               A100CompanyId = P00692_A100CompanyId[0];
               AV29count = (long)(AV29count+1);
               BRK692 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A101CompanyName)) ? "<#Empty#>" : A101CompanyName);
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
            if ( ! BRK692 )
            {
               BRK692 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV13TFCompanyName = "";
         AV14TFCompanyName_Sel = "";
         AV44Companywwds_1_filterfulltext = "";
         AV45Companywwds_2_tfcompanyname = "";
         AV46Companywwds_3_tfcompanyname_sel = "";
         scmdbuf = "";
         lV44Companywwds_1_filterfulltext = "";
         lV45Companywwds_2_tfcompanyname = "";
         A101CompanyName = "";
         P00692_A101CompanyName = new string[] {""} ;
         P00692_A100CompanyId = new long[1] ;
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.companywwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00692_A101CompanyName, P00692_A100CompanyId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV42GXV1 ;
      private long A100CompanyId ;
      private long AV29count ;
      private string AV13TFCompanyName ;
      private string AV14TFCompanyName_Sel ;
      private string AV45Companywwds_2_tfcompanyname ;
      private string AV46Companywwds_3_tfcompanyname_sel ;
      private string scmdbuf ;
      private string lV45Companywwds_2_tfcompanyname ;
      private string A101CompanyName ;
      private bool returnInSub ;
      private bool BRK692 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV44Companywwds_1_filterfulltext ;
      private string lV44Companywwds_1_filterfulltext ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00692_A101CompanyName ;
      private long[] P00692_A100CompanyId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class companywwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00692( IGxContext context ,
                                             string AV44Companywwds_1_filterfulltext ,
                                             string AV46Companywwds_3_tfcompanyname_sel ,
                                             string AV45Companywwds_2_tfcompanyname ,
                                             string A101CompanyName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CompanyName, CompanyId FROM Company";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Companywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(CompanyName) like '%' || LOWER(:lV44Companywwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Companywwds_3_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Companywwds_2_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(CompanyName) like LOWER(:lV45Companywwds_2_tfcompanyname))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Companywwds_3_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV46Companywwds_3_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CompanyName = ( :AV46Companywwds_3_tfcompanyname_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV46Companywwds_3_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CompanyName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00692(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("lV44Companywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Companywwds_2_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV46Companywwds_3_tfcompanyname_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
