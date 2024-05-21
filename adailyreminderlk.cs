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
   public class adailyreminderlk : GXWebProcedure
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
            executePrivate();
         }
         cleanup();
      }

      public adailyreminderlk( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public adailyreminderlk( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         adailyreminderlk objadailyreminderlk;
         objadailyreminderlk = new adailyreminderlk();
         objadailyreminderlk.context.SetSubmitInitialConfig(context);
         objadailyreminderlk.initialize();
         Submit( executePrivateCatch,objadailyreminderlk);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((adailyreminderlk)stateInfo).executePrivate();
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
         AV16CurrentHour = (short)(DateTimeUtil.Hour( DateTimeUtil.Now( context)));
         if ( AV16CurrentHour >= 15 )
         {
            AV14CheckDate = Gx_date;
         }
         else
         {
            AV14CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
            AV17DayOfWeek = DateTimeUtil.Dow( AV14CheckDate);
            if ( AV17DayOfWeek == 7 )
            {
               AV14CheckDate = DateTimeUtil.DAdd( AV14CheckDate, (-1));
            }
            else
            {
               if ( AV17DayOfWeek == 1 )
               {
                  AV14CheckDate = DateTimeUtil.DAdd( AV14CheckDate, (-2));
               }
            }
         }
         /* Using cursor P00AL2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00AL2_A100CompanyId[0];
            A157CompanyLocationId = P00AL2_A157CompanyLocationId[0];
            A106EmployeeId = P00AL2_A106EmployeeId[0];
            A159CompanyLocationCode = P00AL2_A159CompanyLocationCode[0];
            A112EmployeeIsActive = P00AL2_A112EmployeeIsActive[0];
            A107EmployeeFirstName = P00AL2_A107EmployeeFirstName[0];
            A109EmployeeEmail = P00AL2_A109EmployeeEmail[0];
            A157CompanyLocationId = P00AL2_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00AL2_A159CompanyLocationCode[0];
            AV15HasLoggedHours = false;
            /* Using cursor P00AL3 */
            pr_default.execute(1, new Object[] {AV14CheckDate, A106EmployeeId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A119WorkHourLogDate = P00AL3_A119WorkHourLogDate[0];
               A118WorkHourLogId = P00AL3_A118WorkHourLogId[0];
               AV15HasLoggedHours = true;
               context.nUserReturn = 1;
               if ( context.WillRedirect( ) )
               {
                  context.Redirect( context.wjLoc );
                  context.wjLoc = "";
               }
               pr_default.close(1);
               this.cleanup();
               if (true) return;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( ! AV15HasLoggedHours )
            {
               AV10name = A107EmployeeFirstName;
               AV9email = A109EmployeeEmail;
               AV12Subject = "Daily Time Tracker Reminder" + StringUtil.Str( (decimal)(AV16CurrentHour), 4, 0);
               AV8Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#333;color:#fff;text-align:center;padding:20px 0\"><h2>Time Tracker Reminder</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + StringUtil.Trim( AV10name) + ",</p><p>Check your Time Tracker hours for today and fill them.</p><p>We think you forgot to fill them in.</p><a href=\" " + AV13HttpRequest.BaseURL + "logworkhours.aspx\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Fill now</a></div></div>";
               new sendemail(context ).execute(  AV9email, ref  AV12Subject, ref  AV8Body) ;
               new sdsendpushnotifications(context ).execute(  "Time Tracker Reminder",  "Check your time tracker hours, you may have missed a log.",  A106EmployeeId) ;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV14CheckDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         scmdbuf = "";
         P00AL2_A100CompanyId = new long[1] ;
         P00AL2_A157CompanyLocationId = new long[1] ;
         P00AL2_A106EmployeeId = new long[1] ;
         P00AL2_A159CompanyLocationCode = new string[] {""} ;
         P00AL2_A112EmployeeIsActive = new bool[] {false} ;
         P00AL2_A107EmployeeFirstName = new string[] {""} ;
         P00AL2_A109EmployeeEmail = new string[] {""} ;
         A159CompanyLocationCode = "";
         A107EmployeeFirstName = "";
         A109EmployeeEmail = "";
         P00AL3_A106EmployeeId = new long[1] ;
         P00AL3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AL3_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         AV10name = "";
         AV9email = "";
         AV12Subject = "";
         AV8Body = "";
         AV13HttpRequest = new GxHttpRequest( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adailyreminderlk__default(),
            new Object[][] {
                new Object[] {
               P00AL2_A100CompanyId, P00AL2_A157CompanyLocationId, P00AL2_A106EmployeeId, P00AL2_A159CompanyLocationCode, P00AL2_A112EmployeeIsActive, P00AL2_A107EmployeeFirstName, P00AL2_A109EmployeeEmail
               }
               , new Object[] {
               P00AL3_A106EmployeeId, P00AL3_A119WorkHourLogDate, P00AL3_A118WorkHourLogId
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
      private short AV16CurrentHour ;
      private short AV17DayOfWeek ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A159CompanyLocationCode ;
      private string A107EmployeeFirstName ;
      private string AV10name ;
      private DateTime AV14CheckDate ;
      private DateTime Gx_date ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool A112EmployeeIsActive ;
      private bool AV15HasLoggedHours ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV9email ;
      private string AV12Subject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AL2_A100CompanyId ;
      private long[] P00AL2_A157CompanyLocationId ;
      private long[] P00AL2_A106EmployeeId ;
      private string[] P00AL2_A159CompanyLocationCode ;
      private bool[] P00AL2_A112EmployeeIsActive ;
      private string[] P00AL2_A107EmployeeFirstName ;
      private string[] P00AL2_A109EmployeeEmail ;
      private long[] P00AL3_A106EmployeeId ;
      private DateTime[] P00AL3_A119WorkHourLogDate ;
      private long[] P00AL3_A118WorkHourLogId ;
      private GxHttpRequest AV13HttpRequest ;
   }

   public class adailyreminderlk__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00AL2;
          prmP00AL2 = new Object[] {
          };
          Object[] prmP00AL3;
          prmP00AL3 = new Object[] {
          new ParDef("AV14CheckDate",GXType.Date,8,0) ,
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AL2", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId, T3.CompanyLocationCode, T1.EmployeeIsActive, T1.EmployeeFirstName, T1.EmployeeEmail FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.EmployeeIsActive = TRUE) AND (T3.CompanyLocationCode = ( 'lk')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AL3", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE (WorkHourLogDate = :AV14CheckDate) AND (EmployeeId = :EmployeeId) ORDER BY WorkHourLogDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AL3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
