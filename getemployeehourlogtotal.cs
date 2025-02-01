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
   public class getemployeehourlogtotal : GXProcedure
   {
      public getemployeehourlogtotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeehourlogtotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           long aP1_ProjectId ,
                           DateTime aP2_DateFrom ,
                           DateTime aP3_DateTo ,
                           out long aP4_TotalHourLogs ,
                           out string aP5_FormattedHours )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9ProjectId = aP1_ProjectId;
         this.AV10DateFrom = aP2_DateFrom;
         this.AV11DateTo = aP3_DateTo;
         this.AV12TotalHourLogs = 0 ;
         this.AV16FormattedHours = "" ;
         initialize();
         ExecuteImpl();
         aP4_TotalHourLogs=this.AV12TotalHourLogs;
         aP5_FormattedHours=this.AV16FormattedHours;
      }

      public string executeUdp( long aP0_EmployeeId ,
                                long aP1_ProjectId ,
                                DateTime aP2_DateFrom ,
                                DateTime aP3_DateTo ,
                                out long aP4_TotalHourLogs )
      {
         execute(aP0_EmployeeId, aP1_ProjectId, aP2_DateFrom, aP3_DateTo, out aP4_TotalHourLogs, out aP5_FormattedHours);
         return AV16FormattedHours ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 long aP1_ProjectId ,
                                 DateTime aP2_DateFrom ,
                                 DateTime aP3_DateTo ,
                                 out long aP4_TotalHourLogs ,
                                 out string aP5_FormattedHours )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9ProjectId = aP1_ProjectId;
         this.AV10DateFrom = aP2_DateFrom;
         this.AV11DateTo = aP3_DateTo;
         this.AV12TotalHourLogs = 0 ;
         this.AV16FormattedHours = "" ;
         SubmitImpl();
         aP4_TotalHourLogs=this.AV12TotalHourLogs;
         aP5_FormattedHours=this.AV16FormattedHours;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12TotalHourLogs = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10DateFrom ,
                                              AV11DateTo ,
                                              A119WorkHourLogDate ,
                                              AV8EmployeeId ,
                                              AV9ProjectId ,
                                              A106EmployeeId ,
                                              A102ProjectId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00613 */
         pr_default.execute(0, new Object[] {AV8EmployeeId, AV9ProjectId, AV10DateFrom, AV11DateTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A118WorkHourLogId = P00613_A118WorkHourLogId[0];
            A119WorkHourLogDate = P00613_A119WorkHourLogDate[0];
            A102ProjectId = P00613_A102ProjectId[0];
            n102ProjectId = P00613_n102ProjectId[0];
            A106EmployeeId = P00613_A106EmployeeId[0];
            n106EmployeeId = P00613_n106EmployeeId[0];
            A40000GXC1 = P00613_A40000GXC1[0];
            n40000GXC1 = P00613_n40000GXC1[0];
            A40001GXC2 = P00613_A40001GXC2[0];
            n40001GXC2 = P00613_n40001GXC2[0];
            A40000GXC1 = P00613_A40000GXC1[0];
            n40000GXC1 = P00613_n40000GXC1[0];
            A40001GXC2 = P00613_A40001GXC2[0];
            n40001GXC2 = P00613_n40001GXC2[0];
            AV12TotalHourLogs = (long)(AV12TotalHourLogs+(A40000GXC1*60+A40001GXC2));
            pr_default.readNext(0);
         }
         pr_default.close(0);
         GXt_char1 = AV16FormattedHours;
         new procformattime(context ).execute(  AV12TotalHourLogs, out  GXt_char1) ;
         AV16FormattedHours = GXt_char1;
         cleanup();
         if (true) return;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV9ProjectId ,
                                              AV8EmployeeId ,
                                              AV10DateFrom ,
                                              AV11DateTo ,
                                              A102ProjectId ,
                                              A106EmployeeId ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00614 */
         pr_default.execute(1, new Object[] {AV9ProjectId, AV8EmployeeId, AV10DateFrom, AV11DateTo});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A119WorkHourLogDate = P00614_A119WorkHourLogDate[0];
            A106EmployeeId = P00614_A106EmployeeId[0];
            n106EmployeeId = P00614_n106EmployeeId[0];
            A102ProjectId = P00614_A102ProjectId[0];
            n102ProjectId = P00614_n102ProjectId[0];
            A122WorkHourLogMinute = P00614_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00614_A121WorkHourLogHour[0];
            A118WorkHourLogId = P00614_A118WorkHourLogId[0];
            AV12TotalHourLogs = (long)(AV12TotalHourLogs+((A121WorkHourLogHour*60)+A122WorkHourLogMinute));
            AV14Hours = (short)(AV12TotalHourLogs/ (decimal)(60));
            AV15Minutes = (short)(((int)((AV12TotalHourLogs) % (60))));
            if ( AV15Minutes < 10 )
            {
               AV16FormattedHours = StringUtil.Str( (decimal)(AV14Hours), 4, 0) + ":0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Minutes), 4, 0));
            }
            else
            {
               AV16FormattedHours = StringUtil.Str( (decimal)(AV14Hours), 4, 0) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Minutes), 4, 0));
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         cleanup();
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
         AV16FormattedHours = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00613_A118WorkHourLogId = new long[1] ;
         P00613_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00613_A102ProjectId = new long[1] ;
         P00613_n102ProjectId = new bool[] {false} ;
         P00613_A106EmployeeId = new long[1] ;
         P00613_n106EmployeeId = new bool[] {false} ;
         P00613_A40000GXC1 = new short[1] ;
         P00613_n40000GXC1 = new bool[] {false} ;
         P00613_A40001GXC2 = new short[1] ;
         P00613_n40001GXC2 = new bool[] {false} ;
         GXt_char1 = "";
         P00614_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00614_A106EmployeeId = new long[1] ;
         P00614_n106EmployeeId = new bool[] {false} ;
         P00614_A102ProjectId = new long[1] ;
         P00614_n102ProjectId = new bool[] {false} ;
         P00614_A122WorkHourLogMinute = new short[1] ;
         P00614_A121WorkHourLogHour = new short[1] ;
         P00614_A118WorkHourLogId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getemployeehourlogtotal__default(),
            new Object[][] {
                new Object[] {
               P00613_A118WorkHourLogId, P00613_A119WorkHourLogDate, P00613_A102ProjectId, P00613_n102ProjectId, P00613_A106EmployeeId, P00613_n106EmployeeId, P00613_A40000GXC1, P00613_n40000GXC1, P00613_A40001GXC2, P00613_n40001GXC2
               }
               , new Object[] {
               P00614_A119WorkHourLogDate, P00614_A106EmployeeId, P00614_A102ProjectId, P00614_A122WorkHourLogMinute, P00614_A121WorkHourLogHour, P00614_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private short AV14Hours ;
      private short AV15Minutes ;
      private long AV8EmployeeId ;
      private long AV9ProjectId ;
      private long AV12TotalHourLogs ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private string AV16FormattedHours ;
      private string GXt_char1 ;
      private DateTime AV10DateFrom ;
      private DateTime AV11DateTo ;
      private DateTime A119WorkHourLogDate ;
      private bool n102ProjectId ;
      private bool n106EmployeeId ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00613_A118WorkHourLogId ;
      private DateTime[] P00613_A119WorkHourLogDate ;
      private long[] P00613_A102ProjectId ;
      private bool[] P00613_n102ProjectId ;
      private long[] P00613_A106EmployeeId ;
      private bool[] P00613_n106EmployeeId ;
      private short[] P00613_A40000GXC1 ;
      private bool[] P00613_n40000GXC1 ;
      private short[] P00613_A40001GXC2 ;
      private bool[] P00613_n40001GXC2 ;
      private DateTime[] P00614_A119WorkHourLogDate ;
      private long[] P00614_A106EmployeeId ;
      private bool[] P00614_n106EmployeeId ;
      private long[] P00614_A102ProjectId ;
      private bool[] P00614_n102ProjectId ;
      private short[] P00614_A122WorkHourLogMinute ;
      private short[] P00614_A121WorkHourLogHour ;
      private long[] P00614_A118WorkHourLogId ;
      private long aP4_TotalHourLogs ;
      private string aP5_FormattedHours ;
   }

   public class getemployeehourlogtotal__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00613( IGxContext context ,
                                             DateTime AV10DateFrom ,
                                             DateTime AV11DateTo ,
                                             DateTime A119WorkHourLogDate ,
                                             long AV8EmployeeId ,
                                             long AV9ProjectId ,
                                             long A106EmployeeId ,
                                             long A102ProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.WorkHourLogId, T1.WorkHourLogDate, T1.ProjectId, T1.EmployeeId, COALESCE( T2.GXC1, 0) AS GXC1, COALESCE( T2.GXC2, 0) AS GXC2 FROM (WorkHourLog T1 LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, WorkHourLogId, ProjectId, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE T1.WorkHourLogId = WorkHourLogId and T1.ProjectId = ProjectId and T1.EmployeeId = EmployeeId GROUP BY WorkHourLogId, ProjectId, EmployeeId ) T2 ON T2.WorkHourLogId = T1.WorkHourLogId AND T2.ProjectId = T1.ProjectId AND T2.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV8EmployeeId and T1.ProjectId = :AV9ProjectId)");
         if ( ! (DateTime.MinValue==AV10DateFrom) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV10DateFrom)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV11DateTo) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV11DateTo)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId, T1.ProjectId";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00614( IGxContext context ,
                                             long AV9ProjectId ,
                                             long AV8EmployeeId ,
                                             DateTime AV10DateFrom ,
                                             DateTime AV11DateTo ,
                                             long A102ProjectId ,
                                             long A106EmployeeId ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT WorkHourLogDate, EmployeeId, ProjectId, WorkHourLogMinute, WorkHourLogHour, WorkHourLogId FROM WorkHourLog";
         if ( AV9ProjectId != 0 )
         {
            AddWhere(sWhereString, "(ProjectId = :AV9ProjectId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV8EmployeeId) )
         {
            AddWhere(sWhereString, "(EmployeeId = :AV8EmployeeId)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV10DateFrom) )
         {
            AddWhere(sWhereString, "(WorkHourLogDate >= :AV10DateFrom)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV11DateTo) )
         {
            AddWhere(sWhereString, "(WorkHourLogDate <= :AV11DateTo)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WorkHourLogId";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00613(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] );
               case 1 :
                     return conditional_P00614(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
          Object[] prmP00613;
          prmP00613 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV9ProjectId",GXType.Int64,10,0) ,
          new ParDef("AV10DateFrom",GXType.Date,8,0) ,
          new ParDef("AV11DateTo",GXType.Date,8,0)
          };
          Object[] prmP00614;
          prmP00614 = new Object[] {
          new ParDef("AV9ProjectId",GXType.Int64,10,0) ,
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV10DateFrom",GXType.Date,8,0) ,
          new ParDef("AV11DateTo",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00613", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00613,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00614", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00614,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
