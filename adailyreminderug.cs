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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class adailyreminderug : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public adailyreminderug( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public adailyreminderug( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14CurrentHour = (short)(DateTimeUtil.Hour( DateTimeUtil.Now( context)));
         if ( AV14CurrentHour >= 17 )
         {
            AV15CheckDate = Gx_date;
         }
         else
         {
            AV16DayOfWeek = DateTimeUtil.Dow( Gx_date);
            AV16DayOfWeek = 2;
            if ( AV16DayOfWeek == 7 )
            {
               AV15CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
            }
            else
            {
               if ( AV16DayOfWeek == 1 )
               {
                  AV15CheckDate = DateTimeUtil.DAdd( Gx_date, (-2));
               }
               else
               {
                  if ( AV16DayOfWeek == 2 )
                  {
                     AV15CheckDate = DateTimeUtil.DAdd( Gx_date, (-3));
                  }
                  else
                  {
                     AV15CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
                  }
               }
            }
         }
         /* Using cursor P00AJ2 */
         pr_default.execute(0, new Object[] {AV15CheckDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00AJ2_A100CompanyId[0];
            A157CompanyLocationId = P00AJ2_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00AJ2_A159CompanyLocationCode[0];
            A115HolidayStartDate = P00AJ2_A115HolidayStartDate[0];
            A113HolidayId = P00AJ2_A113HolidayId[0];
            A157CompanyLocationId = P00AJ2_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00AJ2_A159CompanyLocationCode[0];
            context.nUserReturn = 1;
            if ( context.WillRedirect( ) )
            {
               context.Redirect( context.wjLoc );
               context.wjLoc = "";
            }
            pr_default.close(0);
            cleanup();
            if (true) return;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00AJ3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00AJ3_A100CompanyId[0];
            A157CompanyLocationId = P00AJ3_A157CompanyLocationId[0];
            A106EmployeeId = P00AJ3_A106EmployeeId[0];
            A159CompanyLocationCode = P00AJ3_A159CompanyLocationCode[0];
            A112EmployeeIsActive = P00AJ3_A112EmployeeIsActive[0];
            A107EmployeeFirstName = P00AJ3_A107EmployeeFirstName[0];
            A109EmployeeEmail = P00AJ3_A109EmployeeEmail[0];
            A157CompanyLocationId = P00AJ3_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00AJ3_A159CompanyLocationCode[0];
            AV23GXLvl36 = 0;
            /* Using cursor P00AJ4 */
            pr_default.execute(2, new Object[] {A106EmployeeId, AV15CheckDate});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A124LeaveTypeId = P00AJ4_A124LeaveTypeId[0];
               A130LeaveRequestEndDate = P00AJ4_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = P00AJ4_A129LeaveRequestStartDate[0];
               A132LeaveRequestStatus = P00AJ4_A132LeaveRequestStatus[0];
               A145LeaveTypeLoggingWorkHours = P00AJ4_A145LeaveTypeLoggingWorkHours[0];
               A173LeaveRequestHalfDay = P00AJ4_A173LeaveRequestHalfDay[0];
               n173LeaveRequestHalfDay = P00AJ4_n173LeaveRequestHalfDay[0];
               A127LeaveRequestId = P00AJ4_A127LeaveRequestId[0];
               A145LeaveTypeLoggingWorkHours = P00AJ4_A145LeaveTypeLoggingWorkHours[0];
               AV23GXLvl36 = 1;
               AV19HasNoLeave = false;
               AV18HasToLogOnLeave = false;
               if ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 )
               {
                  AV18HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Morning") == 0 )
               {
                  AV18HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Afternoon") == 0 )
               {
                  AV18HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else
               {
                  AV18HasToLogOnLeave = false;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( AV23GXLvl36 == 0 )
            {
               AV19HasNoLeave = true;
            }
            AV24GXLvl62 = 0;
            /* Using cursor P00AJ5 */
            pr_default.execute(3, new Object[] {AV15CheckDate, A106EmployeeId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A119WorkHourLogDate = P00AJ5_A119WorkHourLogDate[0];
               A118WorkHourLogId = P00AJ5_A118WorkHourLogId[0];
               AV24GXLvl62 = 1;
               AV17HasLoggedHours = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV24GXLvl62 == 0 )
            {
               AV17HasLoggedHours = false;
            }
            if ( ! AV17HasLoggedHours )
            {
               if ( ( AV19HasNoLeave ) || ( AV18HasToLogOnLeave ) )
               {
                  AV10name = A107EmployeeFirstName;
                  AV9email = A109EmployeeEmail;
                  AV12Subject = "Daily Time Tracker Reminder";
                  AV8Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#333;color:#fff;text-align:center;padding:20px 0\"><h2>Time Tracker Reminder</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + StringUtil.Trim( AV10name) + ",</p><p>Check your Time Tracker hours for today and fill them.</p><p>We think you forgot to fill them in.</p><a href=\" " + AV13HttpRequest.BaseURL + "logworkhours.aspx\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Fill now</a></div></div>";
                  new sendemail(context ).execute(  AV9email, ref  AV12Subject, ref  AV8Body) ;
                  new sdsendpushnotifications(context ).execute(  "Time Tracker Reminder",  "Check your time tracker hours, you may have missed a log.",  A106EmployeeId) ;
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV15CheckDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         P00AJ2_A100CompanyId = new long[1] ;
         P00AJ2_A157CompanyLocationId = new long[1] ;
         P00AJ2_A159CompanyLocationCode = new string[] {""} ;
         P00AJ2_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AJ2_A113HolidayId = new long[1] ;
         A159CompanyLocationCode = "";
         A115HolidayStartDate = DateTime.MinValue;
         P00AJ3_A100CompanyId = new long[1] ;
         P00AJ3_A157CompanyLocationId = new long[1] ;
         P00AJ3_A106EmployeeId = new long[1] ;
         P00AJ3_A159CompanyLocationCode = new string[] {""} ;
         P00AJ3_A112EmployeeIsActive = new bool[] {false} ;
         P00AJ3_A107EmployeeFirstName = new string[] {""} ;
         P00AJ3_A109EmployeeEmail = new string[] {""} ;
         A107EmployeeFirstName = "";
         A109EmployeeEmail = "";
         P00AJ4_A124LeaveTypeId = new long[1] ;
         P00AJ4_A106EmployeeId = new long[1] ;
         P00AJ4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AJ4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AJ4_A132LeaveRequestStatus = new string[] {""} ;
         P00AJ4_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P00AJ4_A173LeaveRequestHalfDay = new string[] {""} ;
         P00AJ4_n173LeaveRequestHalfDay = new bool[] {false} ;
         P00AJ4_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A145LeaveTypeLoggingWorkHours = "";
         A173LeaveRequestHalfDay = "";
         P00AJ5_A106EmployeeId = new long[1] ;
         P00AJ5_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AJ5_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         AV10name = "";
         AV9email = "";
         AV12Subject = "";
         AV8Body = "";
         AV13HttpRequest = new GxHttpRequest( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adailyreminderug__default(),
            new Object[][] {
                new Object[] {
               P00AJ2_A100CompanyId, P00AJ2_A157CompanyLocationId, P00AJ2_A159CompanyLocationCode, P00AJ2_A115HolidayStartDate, P00AJ2_A113HolidayId
               }
               , new Object[] {
               P00AJ3_A100CompanyId, P00AJ3_A157CompanyLocationId, P00AJ3_A106EmployeeId, P00AJ3_A159CompanyLocationCode, P00AJ3_A112EmployeeIsActive, P00AJ3_A107EmployeeFirstName, P00AJ3_A109EmployeeEmail
               }
               , new Object[] {
               P00AJ4_A124LeaveTypeId, P00AJ4_A106EmployeeId, P00AJ4_A130LeaveRequestEndDate, P00AJ4_A129LeaveRequestStartDate, P00AJ4_A132LeaveRequestStatus, P00AJ4_A145LeaveTypeLoggingWorkHours, P00AJ4_A173LeaveRequestHalfDay, P00AJ4_n173LeaveRequestHalfDay, P00AJ4_A127LeaveRequestId
               }
               , new Object[] {
               P00AJ5_A106EmployeeId, P00AJ5_A119WorkHourLogDate, P00AJ5_A118WorkHourLogId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14CurrentHour ;
      private short AV16DayOfWeek ;
      private short AV23GXLvl36 ;
      private short AV24GXLvl62 ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A113HolidayId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long A118WorkHourLogId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A159CompanyLocationCode ;
      private string A107EmployeeFirstName ;
      private string A132LeaveRequestStatus ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A173LeaveRequestHalfDay ;
      private string AV10name ;
      private DateTime AV15CheckDate ;
      private DateTime Gx_date ;
      private DateTime A115HolidayStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool A112EmployeeIsActive ;
      private bool n173LeaveRequestHalfDay ;
      private bool AV19HasNoLeave ;
      private bool AV18HasToLogOnLeave ;
      private bool AV17HasLoggedHours ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV9email ;
      private string AV12Subject ;
      private GxHttpRequest AV13HttpRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AJ2_A100CompanyId ;
      private long[] P00AJ2_A157CompanyLocationId ;
      private string[] P00AJ2_A159CompanyLocationCode ;
      private DateTime[] P00AJ2_A115HolidayStartDate ;
      private long[] P00AJ2_A113HolidayId ;
      private long[] P00AJ3_A100CompanyId ;
      private long[] P00AJ3_A157CompanyLocationId ;
      private long[] P00AJ3_A106EmployeeId ;
      private string[] P00AJ3_A159CompanyLocationCode ;
      private bool[] P00AJ3_A112EmployeeIsActive ;
      private string[] P00AJ3_A107EmployeeFirstName ;
      private string[] P00AJ3_A109EmployeeEmail ;
      private long[] P00AJ4_A124LeaveTypeId ;
      private long[] P00AJ4_A106EmployeeId ;
      private DateTime[] P00AJ4_A130LeaveRequestEndDate ;
      private DateTime[] P00AJ4_A129LeaveRequestStartDate ;
      private string[] P00AJ4_A132LeaveRequestStatus ;
      private string[] P00AJ4_A145LeaveTypeLoggingWorkHours ;
      private string[] P00AJ4_A173LeaveRequestHalfDay ;
      private bool[] P00AJ4_n173LeaveRequestHalfDay ;
      private long[] P00AJ4_A127LeaveRequestId ;
      private long[] P00AJ5_A106EmployeeId ;
      private DateTime[] P00AJ5_A119WorkHourLogDate ;
      private long[] P00AJ5_A118WorkHourLogId ;
   }

   public class adailyreminderug__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AJ2;
          prmP00AJ2 = new Object[] {
          new ParDef("AV15CheckDate",GXType.Date,8,0)
          };
          Object[] prmP00AJ3;
          prmP00AJ3 = new Object[] {
          };
          Object[] prmP00AJ4;
          prmP00AJ4 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV15CheckDate",GXType.Date,8,0)
          };
          Object[] prmP00AJ5;
          prmP00AJ5 = new Object[] {
          new ParDef("AV15CheckDate",GXType.Date,8,0) ,
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AJ2", "SELECT T1.CompanyId, T2.CompanyLocationId, T3.CompanyLocationCode, T1.HolidayStartDate, T1.HolidayId FROM ((Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.HolidayStartDate = :AV15CheckDate) AND (T3.CompanyLocationCode = ( 'ug')) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AJ3", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId, T3.CompanyLocationCode, T1.EmployeeIsActive, T1.EmployeeFirstName, T1.EmployeeEmail FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.EmployeeIsActive = TRUE) AND (T3.CompanyLocationCode = ( 'ug')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AJ4", "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestStatus, T2.LeaveTypeLoggingWorkHours, T1.LeaveRequestHalfDay, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :EmployeeId) AND (T1.LeaveRequestStartDate <= :AV15CheckDate) AND (T1.LeaveRequestEndDate >= :AV15CheckDate) AND (T1.LeaveRequestStatus = ( 'Approved')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AJ5", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE (WorkHourLogDate = :AV15CheckDate) AND (EmployeeId = :EmployeeId) ORDER BY WorkHourLogDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
