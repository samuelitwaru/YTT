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
   public class leaverequestloaddvcombo : GXProcedure
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
            return "leaverequest_Services_Execute" ;
         }

      }

      public leaverequestloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           long aP3_LeaveRequestId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20LeaveRequestId = aP3_LeaveRequestId;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                long aP3_LeaveRequestId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_LeaveRequestId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 long aP3_LeaveRequestId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         leaverequestloaddvcombo objleaverequestloaddvcombo;
         objleaverequestloaddvcombo = new leaverequestloaddvcombo();
         objleaverequestloaddvcombo.AV17ComboName = aP0_ComboName;
         objleaverequestloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objleaverequestloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objleaverequestloaddvcombo.AV20LeaveRequestId = aP3_LeaveRequestId;
         objleaverequestloaddvcombo.AV21SearchTxtParms = aP4_SearchTxtParms;
         objleaverequestloaddvcombo.AV22SelectedValue = "" ;
         objleaverequestloaddvcombo.AV23SelectedText = "" ;
         objleaverequestloaddvcombo.AV24Combo_DataJson = "" ;
         objleaverequestloaddvcombo.context.SetSubmitInitialConfig(context);
         objleaverequestloaddvcombo.initialize();
         Submit( executePrivateCatch,objleaverequestloaddvcombo);
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leaverequestloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "HolidayId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_HOLIDAYID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_HOLIDAYID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV29ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV28DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV32GXV1 = 1;
               while ( AV32GXV1 <= AV29ValuesCollection.Count )
               {
                  AV30ValueItem = ((string)AV29ValuesCollection.Item(AV32GXV1));
                  AV31HolidayId_Filter = (long)(Math.Round(NumberUtil.Val( AV30ValueItem, "."), 18, MidpointRounding.ToEven));
                  AV33GXLvl29 = 0;
                  /* Using cursor P00BB2 */
                  pr_default.execute(0, new Object[] {AV31HolidayId_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A113HolidayId = P00BB2_A113HolidayId[0];
                     A114HolidayName = P00BB2_A114HolidayName[0];
                     AV33GXLvl29 = 1;
                     AV28DscsCollection.Add(A114HolidayName, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV33GXLvl29 == 0 )
                  {
                     AV28DscsCollection.Add("", 0);
                  }
                  AV32GXV1 = (int)(AV32GXV1+1);
               }
               AV24Combo_DataJson = AV28DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom3 = AV12SkipItems;
               GXPagingTo3 = AV11MaxItems;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A114HolidayName } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P00BB3 */
               pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A114HolidayName = P00BB3_A114HolidayName[0];
                  A113HolidayId = P00BB3_A113HolidayId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A113HolidayId), 10, 0));
                  AV16Combo_DataItem.gxTpr_Title = A114HolidayName;
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
            }
         }
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
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         AV29ValuesCollection = new GxSimpleCollection<string>();
         AV28DscsCollection = new GxSimpleCollection<string>();
         AV30ValueItem = "";
         scmdbuf = "";
         P00BB2_A113HolidayId = new long[1] ;
         P00BB2_A114HolidayName = new string[] {""} ;
         A114HolidayName = "";
         lV14SearchTxt = "";
         P00BB3_A114HolidayName = new string[] {""} ;
         P00BB3_A113HolidayId = new long[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00BB2_A113HolidayId, P00BB2_A114HolidayName
               }
               , new Object[] {
               P00BB3_A114HolidayName, P00BB3_A113HolidayId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV33GXLvl29 ;
      private int AV11MaxItems ;
      private int AV32GXV1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private long AV20LeaveRequestId ;
      private long AV31HolidayId_Filter ;
      private long A113HolidayId ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string A114HolidayName ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string AV30ValueItem ;
      private string lV14SearchTxt ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BB2_A113HolidayId ;
      private string[] P00BB2_A114HolidayName ;
      private string[] P00BB3_A114HolidayName ;
      private long[] P00BB3_A113HolidayId ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GxSimpleCollection<string> AV29ValuesCollection ;
      private GxSimpleCollection<string> AV28DscsCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class leaverequestloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BB3( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A114HolidayName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " HolidayName, HolidayId";
         sFromString = " FROM Holiday";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(LOWER(HolidayName) like '%' || LOWER(:lV14SearchTxt))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY HolidayName, HolidayId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom3" + " LIMIT CASE WHEN " + ":GXPagingTo3" + " > 0 THEN " + ":GXPagingTo3" + " ELSE 1e9 END";
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
               case 1 :
                     return conditional_P00BB3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BB2;
          prmP00BB2 = new Object[] {
          new ParDef("AV31HolidayId_Filter",GXType.Int64,10,0)
          };
          Object[] prmP00BB3;
          prmP00BB3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BB2", "SELECT HolidayId, HolidayName FROM Holiday WHERE HolidayId = :AV31HolidayId_Filter ORDER BY HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BB3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
