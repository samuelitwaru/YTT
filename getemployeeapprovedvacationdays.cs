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
   public class getemployeeapprovedvacationdays : GXProcedure
   {
      public getemployeeapprovedvacationdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeeapprovedvacationdays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_DateFrom ,
                           DateTime aP2_DateTo ,
                           out decimal aP3_Days )
      {
         this.AV11EmployeeId = aP0_EmployeeId;
         this.AV10DateFrom = aP1_DateFrom;
         this.AV9DateTo = aP2_DateTo;
         this.AV17Days = 0 ;
         initialize();
         executePrivate();
         aP3_Days=this.AV17Days;
      }

      public decimal executeUdp( long aP0_EmployeeId ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo )
      {
         execute(aP0_EmployeeId, aP1_DateFrom, aP2_DateTo, out aP3_Days);
         return AV17Days ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo ,
                                 out decimal aP3_Days )
      {
         getemployeeapprovedvacationdays objgetemployeeapprovedvacationdays;
         objgetemployeeapprovedvacationdays = new getemployeeapprovedvacationdays();
         objgetemployeeapprovedvacationdays.AV11EmployeeId = aP0_EmployeeId;
         objgetemployeeapprovedvacationdays.AV10DateFrom = aP1_DateFrom;
         objgetemployeeapprovedvacationdays.AV9DateTo = aP2_DateTo;
         objgetemployeeapprovedvacationdays.AV17Days = 0 ;
         objgetemployeeapprovedvacationdays.context.SetSubmitInitialConfig(context);
         objgetemployeeapprovedvacationdays.initialize();
         Submit( executePrivateCatch,objgetemployeeapprovedvacationdays);
         aP3_Days=this.AV17Days;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getemployeeapprovedvacationdays)stateInfo).executePrivate();
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
         AV17Days = 0;
         /* Optimized group. */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11EmployeeId ,
                                              A106EmployeeId ,
                                              AV10DateFrom ,
                                              AV9DateTo } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P008F2 */
         pr_default.execute(0, new Object[] {AV10DateFrom, AV9DateTo, AV11EmployeeId});
         cV17Days = P008F2_AV17Days[0];
         pr_default.close(0);
         AV17Days = (decimal)(AV17Days+cV17Days*0.5m);
         /* End optimized group. */
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11EmployeeId ,
                                              A106EmployeeId ,
                                              A173LeaveRequestHalfDay ,
                                              A132LeaveRequestStatus ,
                                              A144LeaveTypeVacationLeave } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P008F3 */
         pr_default.execute(1, new Object[] {AV11EmployeeId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A124LeaveTypeId = P008F3_A124LeaveTypeId[0];
            A130LeaveRequestEndDate = P008F3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008F3_A129LeaveRequestStartDate[0];
            A106EmployeeId = P008F3_A106EmployeeId[0];
            A173LeaveRequestHalfDay = P008F3_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P008F3_n173LeaveRequestHalfDay[0];
            A144LeaveTypeVacationLeave = P008F3_A144LeaveTypeVacationLeave[0];
            A132LeaveRequestStatus = P008F3_A132LeaveRequestStatus[0];
            A100CompanyId = P008F3_A100CompanyId[0];
            A127LeaveRequestId = P008F3_A127LeaveRequestId[0];
            A144LeaveTypeVacationLeave = P008F3_A144LeaveTypeVacationLeave[0];
            A100CompanyId = P008F3_A100CompanyId[0];
            AV20CompanyId = A100CompanyId;
            AV13LeaveDayCount = 0;
            AV12LeaveDay = A129LeaveRequestStartDate;
            if ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10DateFrom ) )
            {
               AV21LeaveStartDate = AV9DateTo;
            }
            else
            {
               AV21LeaveStartDate = A129LeaveRequestStartDate;
            }
            if ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV9DateTo ) )
            {
               AV22LeaveEndDate = AV9DateTo;
            }
            else
            {
               AV22LeaveEndDate = A130LeaveRequestEndDate;
            }
            while ( DateTimeUtil.ResetTime ( AV21LeaveStartDate ) <= DateTimeUtil.ResetTime ( AV22LeaveEndDate ) )
            {
               if ( DateTimeUtil.Dow( AV21LeaveStartDate) == 7 )
               {
                  AV21LeaveStartDate = DateTimeUtil.DAdd( AV21LeaveStartDate, (2));
               }
               else
               {
                  AV13LeaveDayCount = (short)(AV13LeaveDayCount+1);
                  AV21LeaveStartDate = DateTimeUtil.DAdd( AV21LeaveStartDate, (1));
               }
            }
            AV17Days = (decimal)(AV17Days+AV13LeaveDayCount);
            /* Optimized group. */
            /* Using cursor P008F4 */
            pr_default.execute(2, new Object[] {AV20CompanyId, A129LeaveRequestStartDate, A130LeaveRequestEndDate});
            cV17Days = P008F4_AV17Days[0];
            pr_default.close(2);
            AV17Days = (decimal)(AV17Days-cV17Days*1);
            /* End optimized group. */
            pr_default.readNext(1);
         }
         pr_default.close(1);
         this.cleanup();
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
         scmdbuf = "";
         P008F2_AV17Days = new decimal[1] ;
         A173LeaveRequestHalfDay = "";
         A132LeaveRequestStatus = "";
         A144LeaveTypeVacationLeave = "";
         P008F3_A124LeaveTypeId = new long[1] ;
         P008F3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008F3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008F3_A106EmployeeId = new long[1] ;
         P008F3_A173LeaveRequestHalfDay = new string[] {""} ;
         P008F3_n173LeaveRequestHalfDay = new bool[] {false} ;
         P008F3_A144LeaveTypeVacationLeave = new string[] {""} ;
         P008F3_A132LeaveRequestStatus = new string[] {""} ;
         P008F3_A100CompanyId = new long[1] ;
         P008F3_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         AV12LeaveDay = DateTime.MinValue;
         AV21LeaveStartDate = DateTime.MinValue;
         AV22LeaveEndDate = DateTime.MinValue;
         P008F4_AV17Days = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getemployeeapprovedvacationdays__default(),
            new Object[][] {
                new Object[] {
               P008F2_AV17Days
               }
               , new Object[] {
               P008F3_A124LeaveTypeId, P008F3_A130LeaveRequestEndDate, P008F3_A129LeaveRequestStartDate, P008F3_A106EmployeeId, P008F3_A173LeaveRequestHalfDay, P008F3_n173LeaveRequestHalfDay, P008F3_A144LeaveTypeVacationLeave, P008F3_A132LeaveRequestStatus, P008F3_A100CompanyId, P008F3_A127LeaveRequestId
               }
               , new Object[] {
               P008F4_AV17Days
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13LeaveDayCount ;
      private long AV11EmployeeId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long A127LeaveRequestId ;
      private long AV20CompanyId ;
      private decimal AV17Days ;
      private decimal cV17Days ;
      private string scmdbuf ;
      private string A173LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private string A144LeaveTypeVacationLeave ;
      private DateTime AV10DateFrom ;
      private DateTime AV9DateTo ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime AV12LeaveDay ;
      private DateTime AV21LeaveStartDate ;
      private DateTime AV22LeaveEndDate ;
      private bool n173LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] P008F2_AV17Days ;
      private long[] P008F3_A124LeaveTypeId ;
      private DateTime[] P008F3_A130LeaveRequestEndDate ;
      private DateTime[] P008F3_A129LeaveRequestStartDate ;
      private long[] P008F3_A106EmployeeId ;
      private string[] P008F3_A173LeaveRequestHalfDay ;
      private bool[] P008F3_n173LeaveRequestHalfDay ;
      private string[] P008F3_A144LeaveTypeVacationLeave ;
      private string[] P008F3_A132LeaveRequestStatus ;
      private long[] P008F3_A100CompanyId ;
      private long[] P008F3_A127LeaveRequestId ;
      private decimal[] P008F4_AV17Days ;
      private decimal aP3_Days ;
   }

   public class getemployeeapprovedvacationdays__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008F2( IGxContext context ,
                                             long AV11EmployeeId ,
                                             long A106EmployeeId ,
                                             DateTime AV10DateFrom ,
                                             DateTime AV9DateTo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(Not T1.LeaveRequestHalfDay IS NULL)");
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV10DateFrom)");
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV9DateTo)");
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         AddWhere(sWhereString, "(T2.LeaveTypeVacationLeave = ( 'Yes'))");
         if ( ! (0==AV11EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV11EmployeeId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008F3( IGxContext context ,
                                             long AV11EmployeeId ,
                                             long A106EmployeeId ,
                                             string A173LeaveRequestHalfDay ,
                                             string A132LeaveRequestStatus ,
                                             string A144LeaveTypeVacationLeave )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.EmployeeId, T1.LeaveRequestHalfDay, T2.LeaveTypeVacationLeave, T1.LeaveRequestStatus, T2.CompanyId, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL)");
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         AddWhere(sWhereString, "(T2.LeaveTypeVacationLeave = ( 'Yes'))");
         if ( ! (0==AV11EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV11EmployeeId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestId";
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
                     return conditional_P008F2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] );
               case 1 :
                     return conditional_P008F3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] );
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
          Object[] prmP008F4;
          prmP008F4 = new Object[] {
          new ParDef("AV20CompanyId",GXType.Int64,10,0) ,
          new ParDef("LeaveRequestStartDate",GXType.Date,8,0) ,
          new ParDef("LeaveRequestEndDate",GXType.Date,8,0)
          };
          Object[] prmP008F2;
          prmP008F2 = new Object[] {
          new ParDef("AV10DateFrom",GXType.Date,8,0) ,
          new ParDef("AV9DateTo",GXType.Date,8,0) ,
          new ParDef("AV11EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP008F3;
          prmP008F3 = new Object[] {
          new ParDef("AV11EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008F4", "SELECT COUNT(*) FROM Holiday WHERE (CompanyId = :AV20CompanyId) AND (HolidayStartDate >= :LeaveRequestStartDate) AND (HolidayStartDate <= :LeaveRequestEndDate) AND ((date_part('dow', CAST(HolidayStartDate AS date)) + 1) <> 1) AND ((date_part('dow', CAST(HolidayStartDate AS date)) + 1) <> 7) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F4,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}
