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
   public class adailyreminderua : GXWebProcedure
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

      public adailyreminderua( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public adailyreminderua( IGxContext context )
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
         AV17CurrentHour = (short)(DateTimeUtil.Hour( DateTimeUtil.Now( context)));
         new logtofile(context ).execute(  "Today: "+context.localUtil.DToC( Gx_date, 2, "/")+"("+DateTimeUtil.CDow( Gx_date, "eng")+")") ;
         new logtofile(context ).execute(  "Current Hour: "+StringUtil.Str( (decimal)(AV17CurrentHour), 4, 0)) ;
         AV18HasToLogOnLeave = false;
         if ( AV17CurrentHour >= 17 )
         {
            AV15CheckDate = Gx_date;
         }
         else
         {
            AV16DayOfWeek = DateTimeUtil.Dow( Gx_date);
            new logtofile(context ).execute(  "Day of Week: "+StringUtil.Str( (decimal)(AV16DayOfWeek), 4, 0)) ;
            new logtofile(context ).execute(  "Today: "+context.localUtil.DToC( Gx_date, 2, "/")+"("+DateTimeUtil.CDow( Gx_date, "eng")+")") ;
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
                  AV15CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
               }
            }
         }
         new logtofile(context ).execute(  "Today: "+DateTimeUtil.CDow( Gx_date, "eng")) ;
         new logtofile(context ).execute(  "Check Date: "+context.localUtil.DToC( AV15CheckDate, 2, "/")+" ("+DateTimeUtil.CDow( AV15CheckDate, "eng")+")") ;
         /* Using cursor P00AK2 */
         pr_default.execute(0, new Object[] {AV15CheckDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00AK2_A100CompanyId[0];
            A157CompanyLocationId = P00AK2_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00AK2_A159CompanyLocationCode[0];
            A115HolidayStartDate = P00AK2_A115HolidayStartDate[0];
            A114HolidayName = P00AK2_A114HolidayName[0];
            A113HolidayId = P00AK2_A113HolidayId[0];
            A157CompanyLocationId = P00AK2_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00AK2_A159CompanyLocationCode[0];
            new logtofile(context ).execute(  "It's a holiday: "+StringUtil.Trim( A114HolidayName)) ;
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
         /* Using cursor P00AK3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00AK3_A100CompanyId[0];
            A157CompanyLocationId = P00AK3_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00AK3_A159CompanyLocationCode[0];
            A112EmployeeIsActive = P00AK3_A112EmployeeIsActive[0];
            A148EmployeeName = P00AK3_A148EmployeeName[0];
            A106EmployeeId = P00AK3_A106EmployeeId[0];
            A157CompanyLocationId = P00AK3_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00AK3_A159CompanyLocationCode[0];
            new logtofile(context ).execute(  "Employee Name: "+StringUtil.Trim( A148EmployeeName)) ;
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
         Gx_date = DateTime.MinValue;
         AV15CheckDate = DateTime.MinValue;
         P00AK2_A100CompanyId = new long[1] ;
         P00AK2_A157CompanyLocationId = new long[1] ;
         P00AK2_A159CompanyLocationCode = new string[] {""} ;
         P00AK2_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AK2_A114HolidayName = new string[] {""} ;
         P00AK2_A113HolidayId = new long[1] ;
         A159CompanyLocationCode = "";
         A115HolidayStartDate = DateTime.MinValue;
         A114HolidayName = "";
         P00AK3_A100CompanyId = new long[1] ;
         P00AK3_A157CompanyLocationId = new long[1] ;
         P00AK3_A159CompanyLocationCode = new string[] {""} ;
         P00AK3_A112EmployeeIsActive = new bool[] {false} ;
         P00AK3_A148EmployeeName = new string[] {""} ;
         P00AK3_A106EmployeeId = new long[1] ;
         A148EmployeeName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adailyreminderua__default(),
            new Object[][] {
                new Object[] {
               P00AK2_A100CompanyId, P00AK2_A157CompanyLocationId, P00AK2_A159CompanyLocationCode, P00AK2_A115HolidayStartDate, P00AK2_A114HolidayName, P00AK2_A113HolidayId
               }
               , new Object[] {
               P00AK3_A100CompanyId, P00AK3_A157CompanyLocationId, P00AK3_A159CompanyLocationCode, P00AK3_A112EmployeeIsActive, P00AK3_A148EmployeeName, P00AK3_A106EmployeeId
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
      private short AV17CurrentHour ;
      private short AV16DayOfWeek ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A113HolidayId ;
      private long A106EmployeeId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A159CompanyLocationCode ;
      private string A114HolidayName ;
      private string A148EmployeeName ;
      private DateTime Gx_date ;
      private DateTime AV15CheckDate ;
      private DateTime A115HolidayStartDate ;
      private bool entryPointCalled ;
      private bool AV18HasToLogOnLeave ;
      private bool A112EmployeeIsActive ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AK2_A100CompanyId ;
      private long[] P00AK2_A157CompanyLocationId ;
      private string[] P00AK2_A159CompanyLocationCode ;
      private DateTime[] P00AK2_A115HolidayStartDate ;
      private string[] P00AK2_A114HolidayName ;
      private long[] P00AK2_A113HolidayId ;
      private long[] P00AK3_A100CompanyId ;
      private long[] P00AK3_A157CompanyLocationId ;
      private string[] P00AK3_A159CompanyLocationCode ;
      private bool[] P00AK3_A112EmployeeIsActive ;
      private string[] P00AK3_A148EmployeeName ;
      private long[] P00AK3_A106EmployeeId ;
   }

   public class adailyreminderua__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AK2;
          prmP00AK2 = new Object[] {
          new ParDef("AV15CheckDate",GXType.Date,8,0)
          };
          Object[] prmP00AK3;
          prmP00AK3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00AK2", "SELECT T1.CompanyId, T2.CompanyLocationId, T3.CompanyLocationCode, T1.HolidayStartDate, T1.HolidayName, T1.HolidayId FROM ((Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.HolidayStartDate = :AV15CheckDate) AND (T3.CompanyLocationCode = ( 'ukrainian')) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AK2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00AK3", "SELECT T1.CompanyId, T2.CompanyLocationId, T3.CompanyLocationCode, T1.EmployeeIsActive, T1.EmployeeName, T1.EmployeeId FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.EmployeeIsActive = TRUE) AND (T3.CompanyLocationCode = ( 'ukrainian')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AK3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
