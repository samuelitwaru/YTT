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
   public class aisdateholiday : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new aisdateholiday().executeCmdLine(args); ;
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
         DateTime aP0_Date = new DateTime()  ;
          long aP1_EmployeeId ;
         bool aP2_IsHoliday = new bool()  ;
         if ( 0 < args.Length )
         {
            aP0_Date=((DateTime)(context.localUtil.CToD( (string)(args[0]), 2)));
         }
         else
         {
            aP0_Date=DateTime.MinValue;
         }
         if ( 1 < args.Length )
         {
            aP1_EmployeeId=((long)(NumberUtil.Val( (string)(args[1]), ".")));
         }
         else
         {
            aP1_EmployeeId=0;
         }
         if ( 2 < args.Length )
         {
            aP2_IsHoliday=((bool)(BooleanUtil.Val( (string)(args[2]))));
         }
         else
         {
            aP2_IsHoliday=false;
         }
         execute(aP0_Date, aP1_EmployeeId, out aP2_IsHoliday);
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

      public aisdateholiday( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aisdateholiday( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Date ,
                           long aP1_EmployeeId ,
                           out bool aP2_IsHoliday )
      {
         this.AV8Date = aP0_Date;
         this.AV9EmployeeId = aP1_EmployeeId;
         this.AV11IsHoliday = false ;
         initialize();
         executePrivate();
         aP2_IsHoliday=this.AV11IsHoliday;
      }

      public bool executeUdp( DateTime aP0_Date ,
                              long aP1_EmployeeId )
      {
         execute(aP0_Date, aP1_EmployeeId, out aP2_IsHoliday);
         return AV11IsHoliday ;
      }

      public void executeSubmit( DateTime aP0_Date ,
                                 long aP1_EmployeeId ,
                                 out bool aP2_IsHoliday )
      {
         aisdateholiday objaisdateholiday;
         objaisdateholiday = new aisdateholiday();
         objaisdateholiday.AV8Date = aP0_Date;
         objaisdateholiday.AV9EmployeeId = aP1_EmployeeId;
         objaisdateholiday.AV11IsHoliday = false ;
         objaisdateholiday.context.SetSubmitInitialConfig(context);
         objaisdateholiday.initialize();
         Submit( executePrivateCatch,objaisdateholiday);
         aP2_IsHoliday=this.AV11IsHoliday;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aisdateholiday)stateInfo).executePrivate();
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
         AV11IsHoliday = false;
         /* Using cursor P00AY2 */
         pr_default.execute(0, new Object[] {AV9EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00AY2_A100CompanyId[0];
            A106EmployeeId = P00AY2_A106EmployeeId[0];
            A157CompanyLocationId = P00AY2_A157CompanyLocationId[0];
            A157CompanyLocationId = P00AY2_A157CompanyLocationId[0];
            AV10CompanyLocationId = A157CompanyLocationId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00AY3 */
         pr_default.execute(1, new Object[] {AV8Date, AV10CompanyLocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00AY3_A100CompanyId[0];
            A157CompanyLocationId = P00AY3_A157CompanyLocationId[0];
            A115HolidayStartDate = P00AY3_A115HolidayStartDate[0];
            A113HolidayId = P00AY3_A113HolidayId[0];
            A157CompanyLocationId = P00AY3_A157CompanyLocationId[0];
            AV11IsHoliday = true;
            pr_default.close(1);
            this.cleanup();
            if (true) return;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00AY4 */
         pr_default.execute(2, new Object[] {AV9EmployeeId, AV8Date});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A124LeaveTypeId = P00AY4_A124LeaveTypeId[0];
            A130LeaveRequestEndDate = P00AY4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00AY4_A129LeaveRequestStartDate[0];
            A145LeaveTypeLoggingWorkHours = P00AY4_A145LeaveTypeLoggingWorkHours[0];
            A132LeaveRequestStatus = P00AY4_A132LeaveRequestStatus[0];
            A106EmployeeId = P00AY4_A106EmployeeId[0];
            A127LeaveRequestId = P00AY4_A127LeaveRequestId[0];
            A145LeaveTypeLoggingWorkHours = P00AY4_A145LeaveTypeLoggingWorkHours[0];
            AV11IsHoliday = true;
            pr_default.close(2);
            this.cleanup();
            if (true) return;
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         P00AY2_A100CompanyId = new long[1] ;
         P00AY2_A106EmployeeId = new long[1] ;
         P00AY2_A157CompanyLocationId = new long[1] ;
         P00AY3_A100CompanyId = new long[1] ;
         P00AY3_A157CompanyLocationId = new long[1] ;
         P00AY3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AY3_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         P00AY4_A124LeaveTypeId = new long[1] ;
         P00AY4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AY4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AY4_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P00AY4_A132LeaveRequestStatus = new string[] {""} ;
         P00AY4_A106EmployeeId = new long[1] ;
         P00AY4_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A145LeaveTypeLoggingWorkHours = "";
         A132LeaveRequestStatus = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aisdateholiday__default(),
            new Object[][] {
                new Object[] {
               P00AY2_A100CompanyId, P00AY2_A106EmployeeId, P00AY2_A157CompanyLocationId
               }
               , new Object[] {
               P00AY3_A100CompanyId, P00AY3_A157CompanyLocationId, P00AY3_A115HolidayStartDate, P00AY3_A113HolidayId
               }
               , new Object[] {
               P00AY4_A124LeaveTypeId, P00AY4_A130LeaveRequestEndDate, P00AY4_A129LeaveRequestStartDate, P00AY4_A145LeaveTypeLoggingWorkHours, P00AY4_A132LeaveRequestStatus, P00AY4_A106EmployeeId, P00AY4_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9EmployeeId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long AV10CompanyLocationId ;
      private long A113HolidayId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private string scmdbuf ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A132LeaveRequestStatus ;
      private DateTime AV8Date ;
      private DateTime A115HolidayStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private bool AV11IsHoliday ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AY2_A100CompanyId ;
      private long[] P00AY2_A106EmployeeId ;
      private long[] P00AY2_A157CompanyLocationId ;
      private long[] P00AY3_A100CompanyId ;
      private long[] P00AY3_A157CompanyLocationId ;
      private DateTime[] P00AY3_A115HolidayStartDate ;
      private long[] P00AY3_A113HolidayId ;
      private long[] P00AY4_A124LeaveTypeId ;
      private DateTime[] P00AY4_A130LeaveRequestEndDate ;
      private DateTime[] P00AY4_A129LeaveRequestStartDate ;
      private string[] P00AY4_A145LeaveTypeLoggingWorkHours ;
      private string[] P00AY4_A132LeaveRequestStatus ;
      private long[] P00AY4_A106EmployeeId ;
      private long[] P00AY4_A127LeaveRequestId ;
      private bool aP2_IsHoliday ;
   }

   public class aisdateholiday__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AY2;
          prmP00AY2 = new Object[] {
          new ParDef("AV9EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00AY3;
          prmP00AY3 = new Object[] {
          new ParDef("AV8Date",GXType.Date,8,0) ,
          new ParDef("AV10CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP00AY4;
          prmP00AY4 = new Object[] {
          new ParDef("AV9EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV8Date",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AY2", "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T1.EmployeeId = :AV9EmployeeId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AY3", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.HolidayStartDate, T1.HolidayId FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T1.HolidayStartDate = :AV8Date) AND (T2.CompanyLocationId = :AV10CompanyLocationId) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AY4", "SELECT T1.LeaveTypeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeLoggingWorkHours, T1.LeaveRequestStatus, T1.EmployeeId, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV9EmployeeId) AND (T1.LeaveRequestStartDate <= :AV8Date) AND (T1.LeaveRequestEndDate >= :AV8Date) AND (T1.LeaveRequestStatus = ( 'Approved')) AND (T2.LeaveTypeLoggingWorkHours = ( 'No')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY4,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
