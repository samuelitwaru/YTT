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
   public class prc_getemployeeloggedhours : GXProcedure
   {
      public prc_getemployeeloggedhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getemployeeloggedhours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           GxSimpleCollection<long> aP3_ProjectIdCollection ,
                           out long aP4_TotalHours )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV11ProjectIdCollection = aP3_ProjectIdCollection;
         this.AV12TotalHours = 0 ;
         initialize();
         ExecuteImpl();
         aP4_TotalHours=this.AV12TotalHours;
      }

      public long executeUdp( long aP0_EmployeeId ,
                              DateTime aP1_FromDate ,
                              DateTime aP2_ToDate ,
                              GxSimpleCollection<long> aP3_ProjectIdCollection )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, aP3_ProjectIdCollection, out aP4_TotalHours);
         return AV12TotalHours ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 GxSimpleCollection<long> aP3_ProjectIdCollection ,
                                 out long aP4_TotalHours )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV11ProjectIdCollection = aP3_ProjectIdCollection;
         this.AV12TotalHours = 0 ;
         SubmitImpl();
         aP4_TotalHours=this.AV12TotalHours;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12TotalHours = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV11ProjectIdCollection ,
                                              AV11ProjectIdCollection.Count ,
                                              AV9FromDate ,
                                              AV10ToDate ,
                                              A119WorkHourLogDate ,
                                              AV8EmployeeId ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00CU2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId, AV9FromDate, AV10ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A119WorkHourLogDate = P00CU2_A119WorkHourLogDate[0];
            A102ProjectId = P00CU2_A102ProjectId[0];
            A106EmployeeId = P00CU2_A106EmployeeId[0];
            A122WorkHourLogMinute = P00CU2_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00CU2_A121WorkHourLogHour[0];
            A148EmployeeName = P00CU2_A148EmployeeName[0];
            A118WorkHourLogId = P00CU2_A118WorkHourLogId[0];
            A148EmployeeName = P00CU2_A148EmployeeName[0];
            AV12TotalHours = (long)(AV12TotalHours+((A121WorkHourLogHour*60)+A122WorkHourLogMinute));
            new logtofile(context ).execute(  "Employee: "+StringUtil.Trim( A148EmployeeName)+", "+StringUtil.Str( (decimal)(AV12TotalHours), 10, 0)) ;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         A119WorkHourLogDate = DateTime.MinValue;
         P00CU2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00CU2_A102ProjectId = new long[1] ;
         P00CU2_A106EmployeeId = new long[1] ;
         P00CU2_A122WorkHourLogMinute = new short[1] ;
         P00CU2_A121WorkHourLogHour = new short[1] ;
         P00CU2_A148EmployeeName = new string[] {""} ;
         P00CU2_A118WorkHourLogId = new long[1] ;
         A148EmployeeName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getemployeeloggedhours__default(),
            new Object[][] {
                new Object[] {
               P00CU2_A119WorkHourLogDate, P00CU2_A102ProjectId, P00CU2_A106EmployeeId, P00CU2_A122WorkHourLogMinute, P00CU2_A121WorkHourLogHour, P00CU2_A148EmployeeName, P00CU2_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private int AV11ProjectIdCollection_Count ;
      private long AV8EmployeeId ;
      private long AV12TotalHours ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string A148EmployeeName ;
      private DateTime AV9FromDate ;
      private DateTime AV10ToDate ;
      private DateTime A119WorkHourLogDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV11ProjectIdCollection ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00CU2_A119WorkHourLogDate ;
      private long[] P00CU2_A102ProjectId ;
      private long[] P00CU2_A106EmployeeId ;
      private short[] P00CU2_A122WorkHourLogMinute ;
      private short[] P00CU2_A121WorkHourLogHour ;
      private string[] P00CU2_A148EmployeeName ;
      private long[] P00CU2_A118WorkHourLogId ;
      private long aP4_TotalHours ;
   }

   public class prc_getemployeeloggedhours__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CU2( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV11ProjectIdCollection ,
                                             int AV11ProjectIdCollection_Count ,
                                             DateTime AV9FromDate ,
                                             DateTime AV10ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             long AV8EmployeeId ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.WorkHourLogDate, T1.ProjectId, T1.EmployeeId, T1.WorkHourLogMinute, T1.WorkHourLogHour, T2.EmployeeName, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV8EmployeeId)");
         if ( AV11ProjectIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11ProjectIdCollection, "T1.ProjectId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV9FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV9FromDate)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV10ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV10ToDate)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
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
                     return conditional_P00CU2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
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
          Object[] prmP00CU2;
          prmP00CU2 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV10ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CU2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
