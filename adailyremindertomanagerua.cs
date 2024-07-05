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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class adailyremindertomanagerua : GXWebProcedure
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

      public adailyremindertomanagerua( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public adailyremindertomanagerua( IGxContext context )
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
         adailyremindertomanagerua objadailyremindertomanagerua;
         objadailyremindertomanagerua = new adailyremindertomanagerua();
         objadailyremindertomanagerua.context.SetSubmitInitialConfig(context);
         objadailyremindertomanagerua.initialize();
         Submit( executePrivateCatch,objadailyremindertomanagerua);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((adailyremindertomanagerua)stateInfo).executePrivate();
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
         AV26DayOfWeek = DateTimeUtil.Dow( Gx_date);
         if ( AV26DayOfWeek == 7 )
         {
            AV23CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
         }
         else
         {
            if ( AV26DayOfWeek == 1 )
            {
               AV23CheckDate = DateTimeUtil.DAdd( Gx_date, (-2));
            }
            else
            {
               AV23CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
            }
         }
         AV27AffectedEmployees = new GXBaseCollection<SdtEmployeeListSDT_EmployeeListSDTItem>( context, "EmployeeListSDTItem", "YTT_version4");
         /* Using cursor P00B82 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00B82_A100CompanyId[0];
            A157CompanyLocationId = P00B82_A157CompanyLocationId[0];
            A106EmployeeId = P00B82_A106EmployeeId[0];
            A159CompanyLocationCode = P00B82_A159CompanyLocationCode[0];
            A112EmployeeIsActive = P00B82_A112EmployeeIsActive[0];
            A107EmployeeFirstName = P00B82_A107EmployeeFirstName[0];
            A108EmployeeLastName = P00B82_A108EmployeeLastName[0];
            A157CompanyLocationId = P00B82_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00B82_A159CompanyLocationCode[0];
            AV36GXLvl21 = 0;
            /* Using cursor P00B83 */
            pr_default.execute(1, new Object[] {AV23CheckDate, A106EmployeeId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A119WorkHourLogDate = P00B83_A119WorkHourLogDate[0];
               A118WorkHourLogId = P00B83_A118WorkHourLogId[0];
               AV36GXLvl21 = 1;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV36GXLvl21 == 0 )
            {
               AV24AffectedEmployee = new SdtEmployeeListSDT_EmployeeListSDTItem(context);
               AV24AffectedEmployee.gxTpr_Firstname = A107EmployeeFirstName;
               AV24AffectedEmployee.gxTpr_Lastname = A108EmployeeLastName;
               AV27AffectedEmployees.Add(AV24AffectedEmployee, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00B84 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A100CompanyId = P00B84_A100CompanyId[0];
            A157CompanyLocationId = P00B84_A157CompanyLocationId[0];
            A110EmployeeIsManager = P00B84_A110EmployeeIsManager[0];
            A159CompanyLocationCode = P00B84_A159CompanyLocationCode[0];
            A112EmployeeIsActive = P00B84_A112EmployeeIsActive[0];
            A107EmployeeFirstName = P00B84_A107EmployeeFirstName[0];
            A109EmployeeEmail = P00B84_A109EmployeeEmail[0];
            A106EmployeeId = P00B84_A106EmployeeId[0];
            A157CompanyLocationId = P00B84_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00B84_A159CompanyLocationCode[0];
            AV14name = A107EmployeeFirstName;
            AV10email = A109EmployeeEmail;
            AV17Subject = "Time Tracker Reminder";
            AV29BodyStart = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\">" + "<div style=\"background-color:#333;color:#fff;text-align:center;padding:20px 0\"><h2>Time Tracker Reminder</h2></div>" + "<div style=\"padding:20px;line-height:1.5\">" + "<p>Dear " + StringUtil.Trim( AV14name) + ",</p>" + "<p>This is a reminder that some employees did not fill in their logs for yesterday. Please ensure all their working hours are accurately recorded.</p>" + "<p>The affected employees are:</p>" + "<ol style=\"list-style-type: decimal;\">";
            AV30BodyEnd = "</ol>" + "<p>We appreciate your attention to this matter.</p>" + "<a href=\"" + AV22HttpRequest.BaseURL + "login.aspx\" style=\"display: block; padding: 10px 20px; width: 150px; margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">View Details</a>" + "</div></div>";
            AV8Body = AV29BodyStart;
            AV38GXV1 = 1;
            while ( AV38GXV1 <= AV27AffectedEmployees.Count )
            {
               AV32AffectedEmployeeItem = ((SdtEmployeeListSDT_EmployeeListSDTItem)AV27AffectedEmployees.Item(AV38GXV1));
               AV8Body += "<li>" + AV32AffectedEmployeeItem.gxTpr_Firstname + " " + AV32AffectedEmployeeItem.gxTpr_Lastname + "</li>";
               AV38GXV1 = (int)(AV38GXV1+1);
            }
            AV8Body += AV30BodyEnd;
            new sendemail(context ).execute(  AV10email, ref  AV17Subject, ref  AV8Body) ;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
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
         Gx_date = DateTime.MinValue;
         AV23CheckDate = DateTime.MinValue;
         AV27AffectedEmployees = new GXBaseCollection<SdtEmployeeListSDT_EmployeeListSDTItem>( context, "EmployeeListSDTItem", "YTT_version4");
         scmdbuf = "";
         P00B82_A100CompanyId = new long[1] ;
         P00B82_A157CompanyLocationId = new long[1] ;
         P00B82_A106EmployeeId = new long[1] ;
         P00B82_A159CompanyLocationCode = new string[] {""} ;
         P00B82_A112EmployeeIsActive = new bool[] {false} ;
         P00B82_A107EmployeeFirstName = new string[] {""} ;
         P00B82_A108EmployeeLastName = new string[] {""} ;
         A159CompanyLocationCode = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         P00B83_A106EmployeeId = new long[1] ;
         P00B83_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00B83_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         AV24AffectedEmployee = new SdtEmployeeListSDT_EmployeeListSDTItem(context);
         P00B84_A100CompanyId = new long[1] ;
         P00B84_A157CompanyLocationId = new long[1] ;
         P00B84_A110EmployeeIsManager = new bool[] {false} ;
         P00B84_A159CompanyLocationCode = new string[] {""} ;
         P00B84_A112EmployeeIsActive = new bool[] {false} ;
         P00B84_A107EmployeeFirstName = new string[] {""} ;
         P00B84_A109EmployeeEmail = new string[] {""} ;
         P00B84_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         AV14name = "";
         AV10email = "";
         AV17Subject = "";
         AV29BodyStart = "";
         AV30BodyEnd = "";
         AV22HttpRequest = new GxHttpRequest( context);
         AV8Body = "";
         AV32AffectedEmployeeItem = new SdtEmployeeListSDT_EmployeeListSDTItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adailyremindertomanagerua__default(),
            new Object[][] {
                new Object[] {
               P00B82_A100CompanyId, P00B82_A157CompanyLocationId, P00B82_A106EmployeeId, P00B82_A159CompanyLocationCode, P00B82_A112EmployeeIsActive, P00B82_A107EmployeeFirstName, P00B82_A108EmployeeLastName
               }
               , new Object[] {
               P00B83_A106EmployeeId, P00B83_A119WorkHourLogDate, P00B83_A118WorkHourLogId
               }
               , new Object[] {
               P00B84_A100CompanyId, P00B84_A157CompanyLocationId, P00B84_A110EmployeeIsManager, P00B84_A159CompanyLocationCode, P00B84_A112EmployeeIsActive, P00B84_A107EmployeeFirstName, P00B84_A109EmployeeEmail, P00B84_A106EmployeeId
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
      private short AV26DayOfWeek ;
      private short AV36GXLvl21 ;
      private int AV38GXV1 ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A159CompanyLocationCode ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string AV14name ;
      private DateTime Gx_date ;
      private DateTime AV23CheckDate ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private string AV29BodyStart ;
      private string AV30BodyEnd ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV10email ;
      private string AV17Subject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00B82_A100CompanyId ;
      private long[] P00B82_A157CompanyLocationId ;
      private long[] P00B82_A106EmployeeId ;
      private string[] P00B82_A159CompanyLocationCode ;
      private bool[] P00B82_A112EmployeeIsActive ;
      private string[] P00B82_A107EmployeeFirstName ;
      private string[] P00B82_A108EmployeeLastName ;
      private long[] P00B83_A106EmployeeId ;
      private DateTime[] P00B83_A119WorkHourLogDate ;
      private long[] P00B83_A118WorkHourLogId ;
      private long[] P00B84_A100CompanyId ;
      private long[] P00B84_A157CompanyLocationId ;
      private bool[] P00B84_A110EmployeeIsManager ;
      private string[] P00B84_A159CompanyLocationCode ;
      private bool[] P00B84_A112EmployeeIsActive ;
      private string[] P00B84_A107EmployeeFirstName ;
      private string[] P00B84_A109EmployeeEmail ;
      private long[] P00B84_A106EmployeeId ;
      private GxHttpRequest AV22HttpRequest ;
      private GXBaseCollection<SdtEmployeeListSDT_EmployeeListSDTItem> AV27AffectedEmployees ;
      private SdtEmployeeListSDT_EmployeeListSDTItem AV24AffectedEmployee ;
      private SdtEmployeeListSDT_EmployeeListSDTItem AV32AffectedEmployeeItem ;
   }

   public class adailyremindertomanagerua__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B82;
          prmP00B82 = new Object[] {
          };
          Object[] prmP00B83;
          prmP00B83 = new Object[] {
          new ParDef("AV23CheckDate",GXType.Date,8,0) ,
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00B84;
          prmP00B84 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00B82", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId, T3.CompanyLocationCode, T1.EmployeeIsActive, T1.EmployeeFirstName, T1.EmployeeLastName FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.EmployeeIsActive = TRUE) AND (T3.CompanyLocationCode = ( 'ukrainian')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B82,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B83", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE (WorkHourLogDate = :AV23CheckDate) AND (EmployeeId = :EmployeeId) ORDER BY WorkHourLogDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B83,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B84", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeIsManager, T3.CompanyLocationCode, T1.EmployeeIsActive, T1.EmployeeFirstName, T1.EmployeeEmail, T1.EmployeeId FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.EmployeeIsActive = TRUE) AND (T3.CompanyLocationCode = ( 'ukrainian')) AND (T1.EmployeeIsManager = TRUE) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B84,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
