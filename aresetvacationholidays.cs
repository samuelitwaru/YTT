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
   public class aresetvacationholidays : GXWebProcedure
   {
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "resetvacationholidays_Execute" ;
         }

      }

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

      public aresetvacationholidays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aresetvacationholidays( IGxContext context )
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
         /* Using cursor P00AH2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A147EmployeeBalance = P00AH2_A147EmployeeBalance[0];
            A146EmployeeVactionDays = P00AH2_A146EmployeeVactionDays[0];
            A106EmployeeId = P00AH2_A106EmployeeId[0];
            AV8EmployeeBalance = A147EmployeeBalance;
            AV9EmployeeVactionDays = A146EmployeeVactionDays;
            A147EmployeeBalance = (decimal)(AV8EmployeeBalance+AV9EmployeeVactionDays);
            /* Using cursor P00AH3 */
            pr_default.execute(1, new Object[] {A147EmployeeBalance, A106EmployeeId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Employee");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("resetvacationholidays",pr_default);
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
         P00AH2_A147EmployeeBalance = new decimal[1] ;
         P00AH2_A146EmployeeVactionDays = new decimal[1] ;
         P00AH2_A106EmployeeId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aresetvacationholidays__default(),
            new Object[][] {
                new Object[] {
               P00AH2_A147EmployeeBalance, P00AH2_A146EmployeeVactionDays, P00AH2_A106EmployeeId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private long A106EmployeeId ;
      private decimal A147EmployeeBalance ;
      private decimal A146EmployeeVactionDays ;
      private decimal AV8EmployeeBalance ;
      private decimal AV9EmployeeVactionDays ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00AH2_A147EmployeeBalance ;
      private decimal[] P00AH2_A146EmployeeVactionDays ;
      private long[] P00AH2_A106EmployeeId ;
   }

   public class aresetvacationholidays__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AH2;
          prmP00AH2 = new Object[] {
          };
          Object[] prmP00AH3;
          prmP00AH3 = new Object[] {
          new ParDef("EmployeeBalance",GXType.Number,4,1) ,
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AH2", "SELECT EmployeeBalance, EmployeeVactionDays, EmployeeId FROM Employee ORDER BY EmployeeId  FOR UPDATE OF Employee",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AH3", "SAVEPOINT gxupdate;UPDATE Employee SET EmployeeBalance=:EmployeeBalance  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00AH3)
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
