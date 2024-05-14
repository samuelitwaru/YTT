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
   public class workhourlogloaddvcombo : GXProcedure
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
            return "workhourlog_Services_Execute" ;
         }

      }

      public workhourlogloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlogloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           long aP3_WorkHourLogId ,
                           long aP4_Cond_EmployeeId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20WorkHourLogId = aP3_WorkHourLogId;
         this.AV29Cond_EmployeeId = aP4_Cond_EmployeeId;
         this.AV21SearchTxtParms = aP5_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP6_SelectedValue=this.AV22SelectedValue;
         aP7_SelectedText=this.AV23SelectedText;
         aP8_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                long aP3_WorkHourLogId ,
                                long aP4_Cond_EmployeeId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_WorkHourLogId, aP4_Cond_EmployeeId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 long aP3_WorkHourLogId ,
                                 long aP4_Cond_EmployeeId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         workhourlogloaddvcombo objworkhourlogloaddvcombo;
         objworkhourlogloaddvcombo = new workhourlogloaddvcombo();
         objworkhourlogloaddvcombo.AV17ComboName = aP0_ComboName;
         objworkhourlogloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objworkhourlogloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objworkhourlogloaddvcombo.AV20WorkHourLogId = aP3_WorkHourLogId;
         objworkhourlogloaddvcombo.AV29Cond_EmployeeId = aP4_Cond_EmployeeId;
         objworkhourlogloaddvcombo.AV21SearchTxtParms = aP5_SearchTxtParms;
         objworkhourlogloaddvcombo.AV22SelectedValue = "" ;
         objworkhourlogloaddvcombo.AV23SelectedText = "" ;
         objworkhourlogloaddvcombo.AV24Combo_DataJson = "" ;
         objworkhourlogloaddvcombo.context.SetSubmitInitialConfig(context);
         objworkhourlogloaddvcombo.initialize();
         Submit( executePrivateCatch,objworkhourlogloaddvcombo);
         aP6_SelectedValue=this.AV22SelectedValue;
         aP7_SelectedText=this.AV23SelectedText;
         aP8_Combo_DataJson=this.AV24Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workhourlogloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "EmployeeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_EMPLOYEEID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ProjectId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROJECTID' */
            S121 ();
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
         /* 'LOADCOMBOITEMS_EMPLOYEEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A107EmployeeFirstName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006C2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A107EmployeeFirstName = P006C2_A107EmployeeFirstName[0];
               A106EmployeeId = P006C2_A106EmployeeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
               AV16Combo_DataItem.gxTpr_Title = A107EmployeeFirstName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P006C3 */
                  pr_default.execute(1, new Object[] {AV20WorkHourLogId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A118WorkHourLogId = P006C3_A118WorkHourLogId[0];
                     A106EmployeeId = P006C3_A106EmployeeId[0];
                     A107EmployeeFirstName = P006C3_A107EmployeeFirstName[0];
                     A107EmployeeFirstName = P006C3_A107EmployeeFirstName[0];
                     AV22SelectedValue = ((0==A106EmployeeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0)));
                     AV23SelectedText = A107EmployeeFirstName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28EmployeeId = (long)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P006C4 */
                  pr_default.execute(2, new Object[] {AV28EmployeeId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A106EmployeeId = P006C4_A106EmployeeId[0];
                     A107EmployeeFirstName = P006C4_A107EmployeeFirstName[0];
                     AV23SelectedText = A107EmployeeFirstName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_PROJECTID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom5 = AV12SkipItems;
            GXPagingTo5 = AV11MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A102ProjectId ,
                                                 AV29Cond_EmployeeId ,
                                                 A106EmployeeId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006C5 */
            pr_default.execute(3, new Object[] {AV29Cond_EmployeeId, lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A102ProjectId = P006C5_A102ProjectId[0];
               A106EmployeeId = P006C5_A106EmployeeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
               AV16Combo_DataItem.gxTpr_Title = StringUtil.Trim( context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9"));
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               /* Using cursor P006C6 */
               pr_default.execute(4, new Object[] {AV20WorkHourLogId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A118WorkHourLogId = P006C6_A118WorkHourLogId[0];
                  A102ProjectId = P006C6_A102ProjectId[0];
                  AV22SelectedValue = ((0==A102ProjectId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0)));
                  AV23SelectedText = AV22SelectedValue;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
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
         scmdbuf = "";
         lV14SearchTxt = "";
         A107EmployeeFirstName = "";
         P006C2_A107EmployeeFirstName = new string[] {""} ;
         P006C2_A106EmployeeId = new long[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006C3_A118WorkHourLogId = new long[1] ;
         P006C3_A106EmployeeId = new long[1] ;
         P006C3_A107EmployeeFirstName = new string[] {""} ;
         P006C4_A106EmployeeId = new long[1] ;
         P006C4_A107EmployeeFirstName = new string[] {""} ;
         P006C5_A102ProjectId = new long[1] ;
         P006C5_A106EmployeeId = new long[1] ;
         P006C6_A118WorkHourLogId = new long[1] ;
         P006C6_A102ProjectId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlogloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006C2_A107EmployeeFirstName, P006C2_A106EmployeeId
               }
               , new Object[] {
               P006C3_A118WorkHourLogId, P006C3_A106EmployeeId, P006C3_A107EmployeeFirstName
               }
               , new Object[] {
               P006C4_A106EmployeeId, P006C4_A107EmployeeFirstName
               }
               , new Object[] {
               P006C5_A102ProjectId, P006C5_A106EmployeeId
               }
               , new Object[] {
               P006C6_A118WorkHourLogId, P006C6_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private long AV20WorkHourLogId ;
      private long AV29Cond_EmployeeId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private long AV28EmployeeId ;
      private long A102ProjectId ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string A107EmployeeFirstName ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006C2_A107EmployeeFirstName ;
      private long[] P006C2_A106EmployeeId ;
      private long[] P006C3_A118WorkHourLogId ;
      private long[] P006C3_A106EmployeeId ;
      private string[] P006C3_A107EmployeeFirstName ;
      private long[] P006C4_A106EmployeeId ;
      private string[] P006C4_A107EmployeeFirstName ;
      private long[] P006C5_A102ProjectId ;
      private long[] P006C5_A106EmployeeId ;
      private long[] P006C6_A118WorkHourLogId ;
      private long[] P006C6_A102ProjectId ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class workhourlogloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006C2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A107EmployeeFirstName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " EmployeeFirstName, EmployeeId";
         sFromString = " FROM Employee";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(LOWER(EmployeeFirstName) like '%' || LOWER(:lV14SearchTxt))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY EmployeeFirstName, EmployeeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006C5( IGxContext context ,
                                             string AV14SearchTxt ,
                                             long A102ProjectId ,
                                             long AV29Cond_EmployeeId ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ProjectId, EmployeeId";
         sFromString = " FROM EmployeeProject";
         sOrderString = "";
         AddWhere(sWhereString, "(EmployeeId = :AV29Cond_EmployeeId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(SUBSTR(TO_CHAR(ProjectId,'9999999999'), 2) like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         sOrderString += " ORDER BY EmployeeId, ProjectId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P006C5(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006C3;
          prmP006C3 = new Object[] {
          new ParDef("AV20WorkHourLogId",GXType.Int64,10,0)
          };
          Object[] prmP006C4;
          prmP006C4 = new Object[] {
          new ParDef("AV28EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP006C6;
          prmP006C6 = new Object[] {
          new ParDef("AV20WorkHourLogId",GXType.Int64,10,0)
          };
          Object[] prmP006C2;
          prmP006C2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP006C5;
          prmP006C5 = new Object[] {
          new ParDef("AV29Cond_EmployeeId",GXType.Int64,10,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006C3", "SELECT T1.WorkHourLogId, T1.EmployeeId, T2.EmployeeFirstName FROM (WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) WHERE T1.WorkHourLogId = :AV20WorkHourLogId ORDER BY T1.WorkHourLogId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006C4", "SELECT EmployeeId, EmployeeFirstName FROM Employee WHERE EmployeeId = :AV28EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006C5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006C6", "SELECT WorkHourLogId, ProjectId FROM WorkHourLog WHERE WorkHourLogId = :AV20WorkHourLogId ORDER BY WorkHourLogId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C6,1, GxCacheFrequency.OFF ,false,true )
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
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
