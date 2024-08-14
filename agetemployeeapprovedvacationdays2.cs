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
   public class agetemployeeapprovedvacationdays2 : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new agetemployeeapprovedvacationdays2().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
          long aP0_EmployeeId ;
         DateTime aP1_DateFrom = new DateTime()  ;
         DateTime aP2_DateTo = new DateTime()  ;
          decimal aP3_Days ;
         if ( 0 < args.Length )
         {
            aP0_EmployeeId=((long)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_EmployeeId=0;
         }
         if ( 1 < args.Length )
         {
            aP1_DateFrom=((DateTime)(context.localUtil.CToD( (string)(args[1]), 2)));
         }
         else
         {
            aP1_DateFrom=DateTime.MinValue;
         }
         if ( 2 < args.Length )
         {
            aP2_DateTo=((DateTime)(context.localUtil.CToD( (string)(args[2]), 2)));
         }
         else
         {
            aP2_DateTo=DateTime.MinValue;
         }
         if ( 3 < args.Length )
         {
            aP3_Days=((decimal)(NumberUtil.Val( (string)(args[3]), ".")));
         }
         else
         {
            aP3_Days=0;
         }
         execute(aP0_EmployeeId, aP1_DateFrom, aP2_DateTo, out aP3_Days);
         return GX.GXRuntime.ExitCode ;
      }

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

      public agetemployeeapprovedvacationdays2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agetemployeeapprovedvacationdays2( IGxContext context )
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
         agetemployeeapprovedvacationdays2 objagetemployeeapprovedvacationdays2;
         objagetemployeeapprovedvacationdays2 = new agetemployeeapprovedvacationdays2();
         objagetemployeeapprovedvacationdays2.AV11EmployeeId = aP0_EmployeeId;
         objagetemployeeapprovedvacationdays2.AV10DateFrom = aP1_DateFrom;
         objagetemployeeapprovedvacationdays2.AV9DateTo = aP2_DateTo;
         objagetemployeeapprovedvacationdays2.AV17Days = 0 ;
         objagetemployeeapprovedvacationdays2.context.SetSubmitInitialConfig(context);
         objagetemployeeapprovedvacationdays2.initialize();
         Submit( executePrivateCatch,objagetemployeeapprovedvacationdays2);
         aP3_Days=this.AV17Days;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((agetemployeeapprovedvacationdays2)stateInfo).executePrivate();
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
         AV11EmployeeId = 282;
         AV10DateFrom = context.localUtil.YMDToD( 2024, 1, 1);
         AV9DateTo = context.localUtil.YMDToD( 2024, 12, 1);
         AV17Days = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11EmployeeId ,
                                              A106EmployeeId ,
                                              A173LeaveRequestHalfDay ,
                                              A129LeaveRequestStartDate ,
                                              AV10DateFrom ,
                                              AV9DateTo ,
                                              A132LeaveRequestStatus ,
                                              A144LeaveTypeVacationLeave } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P008F2 */
         pr_default.execute(0, new Object[] {AV10DateFrom, AV9DateTo, AV11EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P008F2_A124LeaveTypeId[0];
            A106EmployeeId = P008F2_A106EmployeeId[0];
            A129LeaveRequestStartDate = P008F2_A129LeaveRequestStartDate[0];
            A173LeaveRequestHalfDay = P008F2_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P008F2_n173LeaveRequestHalfDay[0];
            A144LeaveTypeVacationLeave = P008F2_A144LeaveTypeVacationLeave[0];
            A132LeaveRequestStatus = P008F2_A132LeaveRequestStatus[0];
            A131LeaveRequestDuration = P008F2_A131LeaveRequestDuration[0];
            A127LeaveRequestId = P008F2_A127LeaveRequestId[0];
            A144LeaveTypeVacationLeave = P008F2_A144LeaveTypeVacationLeave[0];
            new logtofile(context ).execute(  "Half day "+StringUtil.Str( A131LeaveRequestDuration, 4, 1)) ;
            AV17Days = (decimal)(AV17Days+0.5m);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
            A131LeaveRequestDuration = P008F3_A131LeaveRequestDuration[0];
            A127LeaveRequestId = P008F3_A127LeaveRequestId[0];
            A144LeaveTypeVacationLeave = P008F3_A144LeaveTypeVacationLeave[0];
            A100CompanyId = P008F3_A100CompanyId[0];
            AV20CompanyId = A100CompanyId;
            AV13LeaveDayCount = 0;
            AV12LeaveDay = A129LeaveRequestStartDate;
            new logtofile(context ).execute(  "Full day "+StringUtil.Str( A131LeaveRequestDuration, 4, 1)) ;
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
         new logtofile(context ).execute(  ">>>>>>>"+StringUtil.Str( AV17Days, 4, 1)) ;
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
         A173LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A144LeaveTypeVacationLeave = "";
         P008F2_A124LeaveTypeId = new long[1] ;
         P008F2_A106EmployeeId = new long[1] ;
         P008F2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008F2_A173LeaveRequestHalfDay = new string[] {""} ;
         P008F2_n173LeaveRequestHalfDay = new bool[] {false} ;
         P008F2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P008F2_A132LeaveRequestStatus = new string[] {""} ;
         P008F2_A131LeaveRequestDuration = new decimal[1] ;
         P008F2_A127LeaveRequestId = new long[1] ;
         P008F3_A124LeaveTypeId = new long[1] ;
         P008F3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008F3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008F3_A106EmployeeId = new long[1] ;
         P008F3_A173LeaveRequestHalfDay = new string[] {""} ;
         P008F3_n173LeaveRequestHalfDay = new bool[] {false} ;
         P008F3_A144LeaveTypeVacationLeave = new string[] {""} ;
         P008F3_A132LeaveRequestStatus = new string[] {""} ;
         P008F3_A100CompanyId = new long[1] ;
         P008F3_A131LeaveRequestDuration = new decimal[1] ;
         P008F3_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         AV12LeaveDay = DateTime.MinValue;
         AV21LeaveStartDate = DateTime.MinValue;
         AV22LeaveEndDate = DateTime.MinValue;
         P008F4_AV17Days = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agetemployeeapprovedvacationdays2__default(),
            new Object[][] {
                new Object[] {
               P008F2_A124LeaveTypeId, P008F2_A106EmployeeId, P008F2_A129LeaveRequestStartDate, P008F2_A173LeaveRequestHalfDay, P008F2_n173LeaveRequestHalfDay, P008F2_A144LeaveTypeVacationLeave, P008F2_A132LeaveRequestStatus, P008F2_A131LeaveRequestDuration, P008F2_A127LeaveRequestId
               }
               , new Object[] {
               P008F3_A124LeaveTypeId, P008F3_A130LeaveRequestEndDate, P008F3_A129LeaveRequestStartDate, P008F3_A106EmployeeId, P008F3_A173LeaveRequestHalfDay, P008F3_n173LeaveRequestHalfDay, P008F3_A144LeaveTypeVacationLeave, P008F3_A132LeaveRequestStatus, P008F3_A100CompanyId, P008F3_A131LeaveRequestDuration,
               P008F3_A127LeaveRequestId
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
      private long A127LeaveRequestId ;
      private long A100CompanyId ;
      private long AV20CompanyId ;
      private decimal AV17Days ;
      private decimal A131LeaveRequestDuration ;
      private decimal cV17Days ;
      private string scmdbuf ;
      private string A173LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private string A144LeaveTypeVacationLeave ;
      private DateTime AV10DateFrom ;
      private DateTime AV9DateTo ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime AV12LeaveDay ;
      private DateTime AV21LeaveStartDate ;
      private DateTime AV22LeaveEndDate ;
      private bool n173LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008F2_A124LeaveTypeId ;
      private long[] P008F2_A106EmployeeId ;
      private DateTime[] P008F2_A129LeaveRequestStartDate ;
      private string[] P008F2_A173LeaveRequestHalfDay ;
      private bool[] P008F2_n173LeaveRequestHalfDay ;
      private string[] P008F2_A144LeaveTypeVacationLeave ;
      private string[] P008F2_A132LeaveRequestStatus ;
      private decimal[] P008F2_A131LeaveRequestDuration ;
      private long[] P008F2_A127LeaveRequestId ;
      private long[] P008F3_A124LeaveTypeId ;
      private DateTime[] P008F3_A130LeaveRequestEndDate ;
      private DateTime[] P008F3_A129LeaveRequestStartDate ;
      private long[] P008F3_A106EmployeeId ;
      private string[] P008F3_A173LeaveRequestHalfDay ;
      private bool[] P008F3_n173LeaveRequestHalfDay ;
      private string[] P008F3_A144LeaveTypeVacationLeave ;
      private string[] P008F3_A132LeaveRequestStatus ;
      private long[] P008F3_A100CompanyId ;
      private decimal[] P008F3_A131LeaveRequestDuration ;
      private long[] P008F3_A127LeaveRequestId ;
      private decimal[] P008F4_AV17Days ;
      private decimal aP3_Days ;
   }

   public class agetemployeeapprovedvacationdays2__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008F2( IGxContext context ,
                                             long AV11EmployeeId ,
                                             long A106EmployeeId ,
                                             string A173LeaveRequestHalfDay ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime AV10DateFrom ,
                                             DateTime AV9DateTo ,
                                             string A132LeaveRequestStatus ,
                                             string A144LeaveTypeVacationLeave )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestStartDate, T1.LeaveRequestHalfDay, T2.LeaveTypeVacationLeave, T1.LeaveRequestStatus, T1.LeaveRequestDuration, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning') or T1.LeaveRequestHalfDay = ( 'Afternoon'))");
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
         scmdbuf += " ORDER BY T1.LeaveRequestId";
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
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.EmployeeId, T1.LeaveRequestHalfDay, T2.LeaveTypeVacationLeave, T1.LeaveRequestStatus, T2.CompanyId, T1.LeaveRequestDuration, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
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
                     return conditional_P008F2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
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
              new CursorDef("P008F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
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
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}
