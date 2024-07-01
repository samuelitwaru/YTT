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
   public class adeleteemployees : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new adeleteemployees().executeCmdLine(args); ;
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

      public adeleteemployees( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public adeleteemployees( IGxContext context )
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
         adeleteemployees objadeleteemployees;
         objadeleteemployees = new adeleteemployees();
         objadeleteemployees.context.SetSubmitInitialConfig(context);
         objadeleteemployees.initialize();
         Submit( executePrivateCatch,objadeleteemployees);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((adeleteemployees)stateInfo).executePrivate();
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
         /* Using cursor P00852 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A119WorkHourLogDate = P00852_A119WorkHourLogDate[0];
            A100CompanyId = P00852_A100CompanyId[0];
            A109EmployeeEmail = P00852_A109EmployeeEmail[0];
            A106EmployeeId = P00852_A106EmployeeId[0];
            A118WorkHourLogId = P00852_A118WorkHourLogId[0];
            A100CompanyId = P00852_A100CompanyId[0];
            A109EmployeeEmail = P00852_A109EmployeeEmail[0];
            new logtofile(context ).execute(  StringUtil.Trim( A109EmployeeEmail)) ;
            AV11EmployeeEmails.Add(StringUtil.Trim( A109EmployeeEmail), 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new logtofile(context ).execute(  AV11EmployeeEmails.ToJSonString(false)) ;
         this.cleanup();
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
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
         P00852_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00852_A100CompanyId = new long[1] ;
         P00852_A109EmployeeEmail = new string[] {""} ;
         P00852_A106EmployeeId = new long[1] ;
         P00852_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         A109EmployeeEmail = "";
         AV11EmployeeEmails = new GxSimpleCollection<string>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adeleteemployees__default(),
            new Object[][] {
                new Object[] {
               P00852_A119WorkHourLogDate, P00852_A100CompanyId, P00852_A109EmployeeEmail, P00852_A106EmployeeId, P00852_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string scmdbuf ;
      private DateTime A119WorkHourLogDate ;
      private string A109EmployeeEmail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00852_A119WorkHourLogDate ;
      private long[] P00852_A100CompanyId ;
      private string[] P00852_A109EmployeeEmail ;
      private long[] P00852_A106EmployeeId ;
      private long[] P00852_A118WorkHourLogId ;
      private GxSimpleCollection<string> AV11EmployeeEmails ;
   }

   public class adeleteemployees__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00852;
          prmP00852 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00852", "SELECT T1.WorkHourLogDate, T2.CompanyId, T2.EmployeeEmail, T1.EmployeeId, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) WHERE (T1.WorkHourLogDate > to_date( '2024-5-1', 'YYYY-MM-DD')) AND (T2.CompanyId = 1) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00852,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
