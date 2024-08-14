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
   public class agetemployeeapprovedvacationdays : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new agetemployeeapprovedvacationdays().executeCmdLine(args); ;
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

      public agetemployeeapprovedvacationdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agetemployeeapprovedvacationdays( IGxContext context )
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
         agetemployeeapprovedvacationdays objagetemployeeapprovedvacationdays;
         objagetemployeeapprovedvacationdays = new agetemployeeapprovedvacationdays();
         objagetemployeeapprovedvacationdays.AV11EmployeeId = aP0_EmployeeId;
         objagetemployeeapprovedvacationdays.AV10DateFrom = aP1_DateFrom;
         objagetemployeeapprovedvacationdays.AV9DateTo = aP2_DateTo;
         objagetemployeeapprovedvacationdays.AV17Days = 0 ;
         objagetemployeeapprovedvacationdays.context.SetSubmitInitialConfig(context);
         objagetemployeeapprovedvacationdays.initialize();
         Submit( executePrivateCatch,objagetemployeeapprovedvacationdays);
         aP3_Days=this.AV17Days;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((agetemployeeapprovedvacationdays)stateInfo).executePrivate();
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
         /* Using cursor P00BP2 */
         pr_default.execute(0, new Object[] {AV11EmployeeId, AV10DateFrom, AV9DateTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00BP2_A124LeaveTypeId[0];
            A144LeaveTypeVacationLeave = P00BP2_A144LeaveTypeVacationLeave[0];
            A132LeaveRequestStatus = P00BP2_A132LeaveRequestStatus[0];
            A130LeaveRequestEndDate = P00BP2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00BP2_A129LeaveRequestStartDate[0];
            A106EmployeeId = P00BP2_A106EmployeeId[0];
            A173LeaveRequestHalfDay = P00BP2_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P00BP2_n173LeaveRequestHalfDay[0];
            A131LeaveRequestDuration = P00BP2_A131LeaveRequestDuration[0];
            A127LeaveRequestId = P00BP2_A127LeaveRequestId[0];
            A144LeaveTypeVacationLeave = P00BP2_A144LeaveTypeVacationLeave[0];
            if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10DateFrom ) ) && ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) <= DateTimeUtil.ResetTime ( AV9DateTo ) ) )
            {
               GXt_decimal1 = AV22ExceptDays;
               new getleaverequestdays(context ).execute(  AV10DateFrom,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay,  AV11EmployeeId, out  GXt_decimal1) ;
               AV22ExceptDays = GXt_decimal1;
               AV17Days = (decimal)(AV17Days+AV22ExceptDays);
            }
            else if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) >= DateTimeUtil.ResetTime ( AV10DateFrom ) ) && ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV9DateTo ) ) )
            {
               GXt_decimal1 = AV22ExceptDays;
               new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  AV9DateTo,  A173LeaveRequestHalfDay,  AV11EmployeeId, out  GXt_decimal1) ;
               AV22ExceptDays = GXt_decimal1;
               AV17Days = (decimal)(AV17Days+AV22ExceptDays);
            }
            else
            {
               AV17Days = (decimal)(AV17Days+A131LeaveRequestDuration);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P00BP2_A124LeaveTypeId = new long[1] ;
         P00BP2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P00BP2_A132LeaveRequestStatus = new string[] {""} ;
         P00BP2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BP2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BP2_A106EmployeeId = new long[1] ;
         P00BP2_A173LeaveRequestHalfDay = new string[] {""} ;
         P00BP2_n173LeaveRequestHalfDay = new bool[] {false} ;
         P00BP2_A131LeaveRequestDuration = new decimal[1] ;
         P00BP2_A127LeaveRequestId = new long[1] ;
         A144LeaveTypeVacationLeave = "";
         A132LeaveRequestStatus = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agetemployeeapprovedvacationdays__default(),
            new Object[][] {
                new Object[] {
               P00BP2_A124LeaveTypeId, P00BP2_A144LeaveTypeVacationLeave, P00BP2_A132LeaveRequestStatus, P00BP2_A130LeaveRequestEndDate, P00BP2_A129LeaveRequestStartDate, P00BP2_A106EmployeeId, P00BP2_A173LeaveRequestHalfDay, P00BP2_n173LeaveRequestHalfDay, P00BP2_A131LeaveRequestDuration, P00BP2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV11EmployeeId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private decimal AV17Days ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV22ExceptDays ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private string A144LeaveTypeVacationLeave ;
      private string A132LeaveRequestStatus ;
      private string A173LeaveRequestHalfDay ;
      private DateTime AV10DateFrom ;
      private DateTime AV9DateTo ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private bool n173LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BP2_A124LeaveTypeId ;
      private string[] P00BP2_A144LeaveTypeVacationLeave ;
      private string[] P00BP2_A132LeaveRequestStatus ;
      private DateTime[] P00BP2_A130LeaveRequestEndDate ;
      private DateTime[] P00BP2_A129LeaveRequestStartDate ;
      private long[] P00BP2_A106EmployeeId ;
      private string[] P00BP2_A173LeaveRequestHalfDay ;
      private bool[] P00BP2_n173LeaveRequestHalfDay ;
      private decimal[] P00BP2_A131LeaveRequestDuration ;
      private long[] P00BP2_A127LeaveRequestId ;
      private decimal aP3_Days ;
   }

   public class agetemployeeapprovedvacationdays__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00BP2;
          prmP00BP2 = new Object[] {
          new ParDef("AV11EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV10DateFrom",GXType.Date,8,0) ,
          new ParDef("AV9DateTo",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BP2", "SELECT T1.LeaveTypeId, T2.LeaveTypeVacationLeave, T1.LeaveRequestStatus, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.EmployeeId, T1.LeaveRequestHalfDay, T1.LeaveRequestDuration, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV11EmployeeId) AND (T1.LeaveRequestStartDate >= :AV10DateFrom and T1.LeaveRequestEndDate <= :AV9DateTo or T1.LeaveRequestStartDate < :AV10DateFrom and T1.LeaveRequestEndDate <= :AV9DateTo or T1.LeaveRequestStartDate >= :AV10DateFrom and T1.LeaveRequestEndDate > :AV9DateTo) AND (T1.LeaveRequestStatus = ( 'Approved')) AND (T2.LeaveTypeVacationLeave = ( 'Yes')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BP2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
