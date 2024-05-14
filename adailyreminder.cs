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
   public class adailyreminder : GXWebProcedure
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

      public adailyreminder( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public adailyreminder( IGxContext context )
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
         adailyreminder objadailyreminder;
         objadailyreminder = new adailyreminder();
         objadailyreminder.context.SetSubmitInitialConfig(context);
         objadailyreminder.initialize();
         Submit( executePrivateCatch,objadailyreminder);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((adailyreminder)stateInfo).executePrivate();
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
         /* Using cursor P005Y2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P005Y2_A106EmployeeId[0];
            A112EmployeeIsActive = P005Y2_A112EmployeeIsActive[0];
            A107EmployeeFirstName = P005Y2_A107EmployeeFirstName[0];
            A109EmployeeEmail = P005Y2_A109EmployeeEmail[0];
            AV15GXLvl3 = 0;
            /* Using cursor P005Y3 */
            pr_default.execute(1, new Object[] {Gx_date, A106EmployeeId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A119WorkHourLogDate = P005Y3_A119WorkHourLogDate[0];
               A118WorkHourLogId = P005Y3_A118WorkHourLogId[0];
               AV15GXLvl3 = 1;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV15GXLvl3 == 0 )
            {
               AV10name = A107EmployeeFirstName;
               AV9email = A109EmployeeEmail;
               AV12Subject = "Daily Time Tracker Reminder";
               AV8Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#333;color:#fff;text-align:center;padding:20px 0\"><h2>Time Tracker Reminder</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV10name + ",</p><p>Check your Time Tracker hours for today and fill them</p><p>We think you forgot to fill them in</p><a href=\" " + AV13HttpRequest.BaseURL + "logworkhours.aspx\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Fill now</a><p>Empower customer’s success!</p><p>Yukon Software</p></div></div>";
               new sendemail(context ).execute(  AV9email, ref  AV12Subject, ref  AV8Body) ;
               new sdsendpushnotifications(context ).execute(  "Time Tracker Reminder",  "Check your time tracker hours, you may have missed a log",  A106EmployeeId) ;
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
         scmdbuf = "";
         P005Y2_A106EmployeeId = new long[1] ;
         P005Y2_A112EmployeeIsActive = new bool[] {false} ;
         P005Y2_A107EmployeeFirstName = new string[] {""} ;
         P005Y2_A109EmployeeEmail = new string[] {""} ;
         A107EmployeeFirstName = "";
         A109EmployeeEmail = "";
         Gx_date = DateTime.MinValue;
         P005Y3_A106EmployeeId = new long[1] ;
         P005Y3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P005Y3_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         AV10name = "";
         AV9email = "";
         AV12Subject = "";
         AV8Body = "";
         AV13HttpRequest = new GxHttpRequest( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adailyreminder__default(),
            new Object[][] {
                new Object[] {
               P005Y2_A106EmployeeId, P005Y2_A112EmployeeIsActive, P005Y2_A107EmployeeFirstName, P005Y2_A109EmployeeEmail
               }
               , new Object[] {
               P005Y3_A106EmployeeId, P005Y3_A119WorkHourLogDate, P005Y3_A118WorkHourLogId
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
      private short AV15GXLvl3 ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A107EmployeeFirstName ;
      private string AV10name ;
      private DateTime Gx_date ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool A112EmployeeIsActive ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV9email ;
      private string AV12Subject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005Y2_A106EmployeeId ;
      private bool[] P005Y2_A112EmployeeIsActive ;
      private string[] P005Y2_A107EmployeeFirstName ;
      private string[] P005Y2_A109EmployeeEmail ;
      private long[] P005Y3_A106EmployeeId ;
      private DateTime[] P005Y3_A119WorkHourLogDate ;
      private long[] P005Y3_A118WorkHourLogId ;
      private GxHttpRequest AV13HttpRequest ;
   }

   public class adailyreminder__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005Y2;
          prmP005Y2 = new Object[] {
          };
          Object[] prmP005Y3;
          prmP005Y3 = new Object[] {
          new ParDef("Gx_date",GXType.Date,8,0) ,
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Y2", "SELECT EmployeeId, EmployeeIsActive, EmployeeFirstName, EmployeeEmail FROM Employee WHERE EmployeeIsActive = TRUE ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005Y3", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE (WorkHourLogDate = :Gx_date) AND (EmployeeId = :EmployeeId) ORDER BY WorkHourLogDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y3,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
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
