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
   public class atest : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new atest().executeCmdLine(args); ;
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
         execute();
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

      public atest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atest( IGxContext context )
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
         atest objatest;
         objatest = new atest();
         objatest.context.SetSubmitInitialConfig(context);
         objatest.initialize();
         Submit( executePrivateCatch,objatest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((atest)stateInfo).executePrivate();
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
         AV8FromDate = context.localUtil.YMDToD( 2024, 1, 1);
         AV9ToDate = context.localUtil.YMDToD( 2024, 12, 31);
         /* Using cursor P00B92 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00B92_A100CompanyId[0];
            A106EmployeeId = P00B92_A106EmployeeId[0];
            A148EmployeeName = P00B92_A148EmployeeName[0];
            new getemployeeapprovedvacationdays(context ).execute(  A106EmployeeId,  AV8FromDate,  AV9ToDate, out  AV10Leave) ;
            new logtofile(context ).execute(  StringUtil.Trim( A148EmployeeName)+" >> "+StringUtil.Str( AV10Leave, 4, 1)) ;
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
         AV8FromDate = DateTime.MinValue;
         AV9ToDate = DateTime.MinValue;
         scmdbuf = "";
         P00B92_A100CompanyId = new long[1] ;
         P00B92_A106EmployeeId = new long[1] ;
         P00B92_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atest__default(),
            new Object[][] {
                new Object[] {
               P00B92_A100CompanyId, P00B92_A106EmployeeId, P00B92_A148EmployeeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A100CompanyId ;
      private long A106EmployeeId ;
      private decimal AV10Leave ;
      private string scmdbuf ;
      private string A148EmployeeName ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00B92_A100CompanyId ;
      private long[] P00B92_A106EmployeeId ;
      private string[] P00B92_A148EmployeeName ;
   }

   public class atest__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B92;
          prmP00B92 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00B92", "SELECT CompanyId, EmployeeId, EmployeeName FROM Employee WHERE CompanyId = 1 ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B92,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
