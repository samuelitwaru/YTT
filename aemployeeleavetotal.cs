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
   public class aemployeeleavetotal : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aemployeeleavetotal().MainImpl(args); ;
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
          decimal aP3_Duration ;
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
            aP3_Duration=((decimal)(NumberUtil.Val( (string)(args[3]), ".")));
         }
         else
         {
            aP3_Duration=0;
         }
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, out aP3_Duration);
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

      public aemployeeleavetotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aemployeeleavetotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           out decimal aP3_Duration )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV14Duration = 0 ;
         initialize();
         ExecuteImpl();
         aP3_Duration=this.AV14Duration;
      }

      public decimal executeUdp( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, out aP3_Duration);
         return AV14Duration ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 out decimal aP3_Duration )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV14Duration = 0 ;
         SubmitImpl();
         aP3_Duration=this.AV14Duration;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00AU2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00AU2_A100CompanyId[0];
            A106EmployeeId = P00AU2_A106EmployeeId[0];
            A148EmployeeName = P00AU2_A148EmployeeName[0];
            A157CompanyLocationId = P00AU2_A157CompanyLocationId[0];
            A157CompanyLocationId = P00AU2_A157CompanyLocationId[0];
            AV22EmployeeName = StringUtil.Trim( A148EmployeeName);
            AV17CompanyLocationId = A157CompanyLocationId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV9Count = 0;
         AV14Duration = 0;
         /* Using cursor P00AU3 */
         pr_default.execute(1, new Object[] {AV10FromDate, AV11ToDate, AV17CompanyLocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00AU3_A100CompanyId[0];
            A139HolidayIsActive = P00AU3_A139HolidayIsActive[0];
            A157CompanyLocationId = P00AU3_A157CompanyLocationId[0];
            A115HolidayStartDate = P00AU3_A115HolidayStartDate[0];
            A113HolidayId = P00AU3_A113HolidayId[0];
            A157CompanyLocationId = P00AU3_A157CompanyLocationId[0];
            if ( ( DateTimeUtil.Dow( A115HolidayStartDate) > 1 ) && ( DateTimeUtil.Dow( A115HolidayStartDate) < 7 ) )
            {
               AV20HolidayDates.Add(A115HolidayStartDate, 0);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV14Duration = (decimal)(AV20HolidayDates.Count);
         /* Using cursor P00AU4 */
         pr_default.execute(2, new Object[] {AV8EmployeeId, AV11ToDate, AV10FromDate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A124LeaveTypeId = P00AU4_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P00AU4_A132LeaveRequestStatus[0];
            A145LeaveTypeLoggingWorkHours = P00AU4_A145LeaveTypeLoggingWorkHours[0];
            A130LeaveRequestEndDate = P00AU4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00AU4_A129LeaveRequestStartDate[0];
            A106EmployeeId = P00AU4_A106EmployeeId[0];
            A173LeaveRequestHalfDay = P00AU4_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P00AU4_n173LeaveRequestHalfDay[0];
            A127LeaveRequestId = P00AU4_A127LeaveRequestId[0];
            A145LeaveTypeLoggingWorkHours = P00AU4_A145LeaveTypeLoggingWorkHours[0];
            if ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10FromDate ) )
            {
               AV12LeaveStartDate = AV10FromDate;
            }
            else
            {
               AV12LeaveStartDate = A129LeaveRequestStartDate;
            }
            if ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV11ToDate ) )
            {
               AV13LeaveEndDate = AV11ToDate;
            }
            else
            {
               AV13LeaveEndDate = A130LeaveRequestEndDate;
            }
            AV29GXV1 = 1;
            while ( AV29GXV1 <= AV20HolidayDates.Count )
            {
               AV25HolidayDate = AV20HolidayDates.GetDatetime(AV29GXV1);
               if ( ( DateTimeUtil.ResetTime ( AV12LeaveStartDate ) <= DateTimeUtil.ResetTime ( AV25HolidayDate ) ) && ( DateTimeUtil.ResetTime ( AV25HolidayDate ) <= DateTimeUtil.ResetTime ( AV13LeaveEndDate ) ) )
               {
                  AV14Duration = (decimal)(AV14Duration-1);
               }
               AV29GXV1 = (int)(AV29GXV1+1);
            }
            AV23CurrentDate = AV12LeaveStartDate;
            while ( DateTimeUtil.ResetTime ( AV23CurrentDate ) <= DateTimeUtil.ResetTime ( AV13LeaveEndDate ) )
            {
               AV24IsCurrentDateHoliday = (AV20HolidayDates.IndexOf(AV23CurrentDate)>0);
               if ( ( DateTimeUtil.Dow( AV23CurrentDate) == 1 ) || ( DateTimeUtil.Dow( AV23CurrentDate) == 7 ) )
               {
                  AV23CurrentDate = DateTimeUtil.DAdd( AV23CurrentDate, (1));
               }
               else if ( DateTimeUtil.Dow( AV23CurrentDate) == 2 )
               {
                  if ( ( ( DateTimeUtil.DDiff( DateTimeUtil.DAdd( AV13LeaveEndDate, (1)) , AV23CurrentDate ) ) > 5 ) )
                  {
                     AV14Duration = (decimal)(AV14Duration+5);
                     new logtofile(context ).execute(  "			"+context.localUtil.DToC( AV23CurrentDate, 2, "/")+"adding 5") ;
                     AV23CurrentDate = DateTimeUtil.DAdd( AV23CurrentDate, (7));
                  }
                  else
                  {
                     AV14Duration = (decimal)(AV14Duration+(DateTimeUtil.DDiff(DateTimeUtil.DAdd( AV13LeaveEndDate, (1)),AV23CurrentDate)));
                     if (true) break;
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Yes") == 0 )
                  {
                     AV14Duration = (decimal)(AV14Duration+0.5m);
                  }
                  else
                  {
                     AV14Duration = (decimal)(AV14Duration+1);
                  }
                  AV23CurrentDate = DateTimeUtil.DAdd( AV23CurrentDate, (1));
               }
            }
            AV9Count = (short)(AV9Count+1);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV14Duration = (decimal)(AV14Duration*8*60);
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
         P00AU2_A100CompanyId = new long[1] ;
         P00AU2_A106EmployeeId = new long[1] ;
         P00AU2_A148EmployeeName = new string[] {""} ;
         P00AU2_A157CompanyLocationId = new long[1] ;
         A148EmployeeName = "";
         AV22EmployeeName = "";
         P00AU3_A100CompanyId = new long[1] ;
         P00AU3_A139HolidayIsActive = new bool[] {false} ;
         P00AU3_A157CompanyLocationId = new long[1] ;
         P00AU3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AU3_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         AV20HolidayDates = new GxSimpleCollection<DateTime>();
         P00AU4_A124LeaveTypeId = new long[1] ;
         P00AU4_A132LeaveRequestStatus = new string[] {""} ;
         P00AU4_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P00AU4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AU4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AU4_A106EmployeeId = new long[1] ;
         P00AU4_A173LeaveRequestHalfDay = new string[] {""} ;
         P00AU4_n173LeaveRequestHalfDay = new bool[] {false} ;
         P00AU4_A127LeaveRequestId = new long[1] ;
         A132LeaveRequestStatus = "";
         A145LeaveTypeLoggingWorkHours = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         AV12LeaveStartDate = DateTime.MinValue;
         AV13LeaveEndDate = DateTime.MinValue;
         AV25HolidayDate = DateTime.MinValue;
         AV23CurrentDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavetotal__default(),
            new Object[][] {
                new Object[] {
               P00AU2_A100CompanyId, P00AU2_A106EmployeeId, P00AU2_A148EmployeeName, P00AU2_A157CompanyLocationId
               }
               , new Object[] {
               P00AU3_A100CompanyId, P00AU3_A139HolidayIsActive, P00AU3_A157CompanyLocationId, P00AU3_A115HolidayStartDate, P00AU3_A113HolidayId
               }
               , new Object[] {
               P00AU4_A124LeaveTypeId, P00AU4_A132LeaveRequestStatus, P00AU4_A145LeaveTypeLoggingWorkHours, P00AU4_A130LeaveRequestEndDate, P00AU4_A129LeaveRequestStartDate, P00AU4_A106EmployeeId, P00AU4_A173LeaveRequestHalfDay, P00AU4_n173LeaveRequestHalfDay, P00AU4_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9Count ;
      private int AV29GXV1 ;
      private long AV8EmployeeId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long AV17CompanyLocationId ;
      private long A113HolidayId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private decimal AV14Duration ;
      private string A148EmployeeName ;
      private string AV22EmployeeName ;
      private string A132LeaveRequestStatus ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A173LeaveRequestHalfDay ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime AV12LeaveStartDate ;
      private DateTime AV13LeaveEndDate ;
      private DateTime AV25HolidayDate ;
      private DateTime AV23CurrentDate ;
      private bool A139HolidayIsActive ;
      private bool n173LeaveRequestHalfDay ;
      private bool AV24IsCurrentDateHoliday ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AU2_A100CompanyId ;
      private long[] P00AU2_A106EmployeeId ;
      private string[] P00AU2_A148EmployeeName ;
      private long[] P00AU2_A157CompanyLocationId ;
      private long[] P00AU3_A100CompanyId ;
      private bool[] P00AU3_A139HolidayIsActive ;
      private long[] P00AU3_A157CompanyLocationId ;
      private DateTime[] P00AU3_A115HolidayStartDate ;
      private long[] P00AU3_A113HolidayId ;
      private GxSimpleCollection<DateTime> AV20HolidayDates ;
      private long[] P00AU4_A124LeaveTypeId ;
      private string[] P00AU4_A132LeaveRequestStatus ;
      private string[] P00AU4_A145LeaveTypeLoggingWorkHours ;
      private DateTime[] P00AU4_A130LeaveRequestEndDate ;
      private DateTime[] P00AU4_A129LeaveRequestStartDate ;
      private long[] P00AU4_A106EmployeeId ;
      private string[] P00AU4_A173LeaveRequestHalfDay ;
      private bool[] P00AU4_n173LeaveRequestHalfDay ;
      private long[] P00AU4_A127LeaveRequestId ;
      private decimal aP3_Duration ;
   }

   public class aemployeeleavetotal__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00AU2;
          prmP00AU2 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00AU3;
          prmP00AU3 = new Object[] {
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV17CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP00AU4;
          prmP00AU4 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV10FromDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AU2", "SELECT T1.CompanyId, T1.EmployeeId, T1.EmployeeName, T2.CompanyLocationId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T1.EmployeeId = :AV8EmployeeId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AU3", "SELECT T1.CompanyId, T1.HolidayIsActive, T2.CompanyLocationId, T1.HolidayStartDate, T1.HolidayId FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T1.HolidayStartDate >= :AV10FromDate) AND (T1.HolidayStartDate <= :AV11ToDate) AND (T2.CompanyLocationId = :AV17CompanyLocationId) AND (T1.HolidayIsActive = TRUE) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AU4", "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T2.LeaveTypeLoggingWorkHours, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.EmployeeId, T1.LeaveRequestHalfDay, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV8EmployeeId) AND (T1.LeaveRequestStartDate <= :AV11ToDate) AND (T1.LeaveRequestEndDate >= :AV10FromDate) AND (T2.LeaveTypeLoggingWorkHours = ( 'No')) AND (T1.LeaveRequestStatus = ( 'Approved')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
