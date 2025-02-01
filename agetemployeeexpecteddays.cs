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
   public class agetemployeeexpecteddays : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new agetemployeeexpecteddays().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          long aP0_EmployeeId ;
         DateTime aP1_FromDate = new DateTime()  ;
         DateTime aP2_ToDate = new DateTime()  ;
          decimal aP3_ExpectedWorkDays ;
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
            aP1_FromDate=((DateTime)(context.localUtil.CToD( (string)(args[1]), 2)));
         }
         else
         {
            aP1_FromDate=DateTime.MinValue;
         }
         if ( 2 < args.Length )
         {
            aP2_ToDate=((DateTime)(context.localUtil.CToD( (string)(args[2]), 2)));
         }
         else
         {
            aP2_ToDate=DateTime.MinValue;
         }
         if ( 3 < args.Length )
         {
            aP3_ExpectedWorkDays=((decimal)(NumberUtil.Val( (string)(args[3]), ".")));
         }
         else
         {
            aP3_ExpectedWorkDays=0;
         }
         execute(ref aP0_EmployeeId, ref aP1_FromDate, ref aP2_ToDate, out aP3_ExpectedWorkDays);
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

      public agetemployeeexpecteddays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agetemployeeexpecteddays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_EmployeeId ,
                           ref DateTime aP1_FromDate ,
                           ref DateTime aP2_ToDate ,
                           out decimal aP3_ExpectedWorkDays )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV20ExpectedWorkDays = 0 ;
         initialize();
         ExecuteImpl();
         aP0_EmployeeId=this.AV8EmployeeId;
         aP1_FromDate=this.AV9FromDate;
         aP2_ToDate=this.AV10ToDate;
         aP3_ExpectedWorkDays=this.AV20ExpectedWorkDays;
      }

      public decimal executeUdp( ref long aP0_EmployeeId ,
                                 ref DateTime aP1_FromDate ,
                                 ref DateTime aP2_ToDate )
      {
         execute(ref aP0_EmployeeId, ref aP1_FromDate, ref aP2_ToDate, out aP3_ExpectedWorkDays);
         return AV20ExpectedWorkDays ;
      }

      public void executeSubmit( ref long aP0_EmployeeId ,
                                 ref DateTime aP1_FromDate ,
                                 ref DateTime aP2_ToDate ,
                                 out decimal aP3_ExpectedWorkDays )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV20ExpectedWorkDays = 0 ;
         SubmitImpl();
         aP0_EmployeeId=this.AV8EmployeeId;
         aP1_FromDate=this.AV9FromDate;
         aP2_ToDate=this.AV10ToDate;
         aP3_ExpectedWorkDays=this.AV20ExpectedWorkDays;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9FromDate = context.localUtil.YMDToD( 2024, 11, 1);
         AV10ToDate = context.localUtil.YMDToD( 2024, 11, 30);
         AV8EmployeeId = 89;
         /* Using cursor P00A22 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00A22_A106EmployeeId[0];
            A100CompanyId = P00A22_A100CompanyId[0];
            AV14CompanyId = A100CompanyId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV24LeaveDayCount = 0;
         /* Using cursor P00A23 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A130LeaveRequestEndDate = P00A23_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00A23_A129LeaveRequestStartDate[0];
            A173LeaveRequestHalfDay = P00A23_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P00A23_n173LeaveRequestHalfDay[0];
            A127LeaveRequestId = P00A23_A127LeaveRequestId[0];
            GXt_decimal1 = AV24LeaveDayCount;
            new getleaverequestdays(context ).execute(  AV9FromDate,  AV10ToDate,  A173LeaveRequestHalfDay,  AV8EmployeeId, out  GXt_decimal1) ;
            AV24LeaveDayCount = (decimal)(AV24LeaveDayCount+(GXt_decimal1));
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 A113HolidayId ,
                                                 AV27HolidayIdCollection ,
                                                 A115HolidayStartDate ,
                                                 AV9FromDate ,
                                                 AV10ToDate ,
                                                 A129LeaveRequestStartDate ,
                                                 A130LeaveRequestEndDate ,
                                                 A139HolidayIsActive ,
                                                 AV14CompanyId ,
                                                 A100CompanyId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P00A24 */
            pr_default.execute(2, new Object[] {AV14CompanyId, AV9FromDate, AV10ToDate, A129LeaveRequestStartDate, A130LeaveRequestEndDate});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A115HolidayStartDate = P00A24_A115HolidayStartDate[0];
               A139HolidayIsActive = P00A24_A139HolidayIsActive[0];
               A100CompanyId = P00A24_A100CompanyId[0];
               A113HolidayId = P00A24_A113HolidayId[0];
               AV27HolidayIdCollection.Add(A113HolidayId, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
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
         P00A22_A106EmployeeId = new long[1] ;
         P00A22_A100CompanyId = new long[1] ;
         P00A23_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00A23_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00A23_A173LeaveRequestHalfDay = new string[] {""} ;
         P00A23_n173LeaveRequestHalfDay = new bool[] {false} ;
         P00A23_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         AV27HolidayIdCollection = new GxSimpleCollection<long>();
         A115HolidayStartDate = DateTime.MinValue;
         P00A24_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00A24_A139HolidayIsActive = new bool[] {false} ;
         P00A24_A100CompanyId = new long[1] ;
         P00A24_A113HolidayId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agetemployeeexpecteddays__default(),
            new Object[][] {
                new Object[] {
               P00A22_A106EmployeeId, P00A22_A100CompanyId
               }
               , new Object[] {
               P00A23_A130LeaveRequestEndDate, P00A23_A129LeaveRequestStartDate, P00A23_A173LeaveRequestHalfDay, P00A23_n173LeaveRequestHalfDay, P00A23_A127LeaveRequestId
               }
               , new Object[] {
               P00A24_A115HolidayStartDate, P00A24_A139HolidayIsActive, P00A24_A100CompanyId, P00A24_A113HolidayId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8EmployeeId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long AV14CompanyId ;
      private long A127LeaveRequestId ;
      private long A113HolidayId ;
      private decimal AV20ExpectedWorkDays ;
      private decimal AV24LeaveDayCount ;
      private decimal GXt_decimal1 ;
      private string A173LeaveRequestHalfDay ;
      private DateTime AV9FromDate ;
      private DateTime AV10ToDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A115HolidayStartDate ;
      private bool n173LeaveRequestHalfDay ;
      private bool A139HolidayIsActive ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_EmployeeId ;
      private DateTime aP1_FromDate ;
      private DateTime aP2_ToDate ;
      private IDataStoreProvider pr_default ;
      private long[] P00A22_A106EmployeeId ;
      private long[] P00A22_A100CompanyId ;
      private DateTime[] P00A23_A130LeaveRequestEndDate ;
      private DateTime[] P00A23_A129LeaveRequestStartDate ;
      private string[] P00A23_A173LeaveRequestHalfDay ;
      private bool[] P00A23_n173LeaveRequestHalfDay ;
      private long[] P00A23_A127LeaveRequestId ;
      private GxSimpleCollection<long> AV27HolidayIdCollection ;
      private DateTime[] P00A24_A115HolidayStartDate ;
      private bool[] P00A24_A139HolidayIsActive ;
      private long[] P00A24_A100CompanyId ;
      private long[] P00A24_A113HolidayId ;
      private decimal aP3_ExpectedWorkDays ;
   }

   public class agetemployeeexpecteddays__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A24( IGxContext context ,
                                             long A113HolidayId ,
                                             GxSimpleCollection<long> AV27HolidayIdCollection ,
                                             DateTime A115HolidayStartDate ,
                                             DateTime AV9FromDate ,
                                             DateTime AV10ToDate ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             bool A139HolidayIsActive ,
                                             long AV14CompanyId ,
                                             long A100CompanyId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT HolidayStartDate, HolidayIsActive, CompanyId, HolidayId FROM Holiday";
         AddWhere(sWhereString, "(CompanyId = :AV14CompanyId)");
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV27HolidayIdCollection, "HolidayId IN (", ")")+")");
         AddWhere(sWhereString, "(HolidayStartDate >= :AV9FromDate)");
         AddWhere(sWhereString, "(HolidayStartDate <= :AV10ToDate)");
         AddWhere(sWhereString, "(HolidayStartDate < :LeaveRequestStartDate or HolidayStartDate > :LeaveRequestEndDate)");
         AddWhere(sWhereString, "(HolidayIsActive = TRUE)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyId";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00A24(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (bool)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] );
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
          Object[] prmP00A22;
          prmP00A22 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00A23;
          prmP00A23 = new Object[] {
          };
          Object[] prmP00A24;
          prmP00A24 = new Object[] {
          new ParDef("AV14CompanyId",GXType.Int64,10,0) ,
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV10ToDate",GXType.Date,8,0) ,
          new ParDef("LeaveRequestStartDate",GXType.Date,8,0) ,
          new ParDef("LeaveRequestEndDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A22", "SELECT EmployeeId, CompanyId FROM Employee WHERE EmployeeId = :AV8EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A22,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A23", "SELECT LeaveRequestEndDate, LeaveRequestStartDate, LeaveRequestHalfDay, LeaveRequestId FROM LeaveRequest ORDER BY LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A23,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A24", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A24,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
             case 2 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
