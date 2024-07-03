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
   public class acreateemployeeaccounts : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new acreateemployeeaccounts().executeCmdLine(args); ;
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

      public acreateemployeeaccounts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public acreateemployeeaccounts( IGxContext context )
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
         acreateemployeeaccounts objacreateemployeeaccounts;
         objacreateemployeeaccounts = new acreateemployeeaccounts();
         objacreateemployeeaccounts.context.SetSubmitInitialConfig(context);
         objacreateemployeeaccounts.initialize();
         Submit( executePrivateCatch,objacreateemployeeaccounts);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acreateemployeeaccounts)stateInfo).executePrivate();
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
         new creategamroles(context ).execute( ) ;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV10EmployeeIds } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor P00B02 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00B02_A106EmployeeId[0];
            A109EmployeeEmail = P00B02_A109EmployeeEmail[0];
            A107EmployeeFirstName = P00B02_A107EmployeeFirstName[0];
            A108EmployeeLastName = P00B02_A108EmployeeLastName[0];
            A148EmployeeName = P00B02_A148EmployeeName[0];
            new createemployeeaccount1(context ).execute(  StringUtil.Trim( A109EmployeeEmail),  StringUtil.Trim( A107EmployeeFirstName),  StringUtil.Trim( A108EmployeeLastName),  "IsEmployee", out  AV8GAMUserGUID) ;
            new logtofile(context ).execute(  StringUtil.Trim( A148EmployeeName)+">>>"+AV8GAMUserGUID) ;
            AV11Employee.Load(A106EmployeeId);
            AV11Employee.gxTpr_Gamuserguid = AV8GAMUserGUID;
            AV11Employee.Save();
            context.CommitDataStores("createemployeeaccounts",pr_default);
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
         AV10EmployeeIds = new GxSimpleCollection<short>();
         P00B02_A106EmployeeId = new long[1] ;
         P00B02_A109EmployeeEmail = new string[] {""} ;
         P00B02_A107EmployeeFirstName = new string[] {""} ;
         P00B02_A108EmployeeLastName = new string[] {""} ;
         P00B02_A148EmployeeName = new string[] {""} ;
         A109EmployeeEmail = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A148EmployeeName = "";
         AV8GAMUserGUID = "";
         AV11Employee = new SdtEmployee(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.acreateemployeeaccounts__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acreateemployeeaccounts__default(),
            new Object[][] {
                new Object[] {
               P00B02_A106EmployeeId, P00B02_A109EmployeeEmail, P00B02_A107EmployeeFirstName, P00B02_A108EmployeeLastName, P00B02_A148EmployeeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private string scmdbuf ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string A148EmployeeName ;
      private string A109EmployeeEmail ;
      private string AV8GAMUserGUID ;
      private GxSimpleCollection<short> AV10EmployeeIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00B02_A106EmployeeId ;
      private string[] P00B02_A109EmployeeEmail ;
      private string[] P00B02_A107EmployeeFirstName ;
      private string[] P00B02_A108EmployeeLastName ;
      private string[] P00B02_A148EmployeeName ;
      private IDataStoreProvider pr_gam ;
      private SdtEmployee AV11Employee ;
   }

   public class acreateemployeeaccounts__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class acreateemployeeaccounts__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00B02( IGxContext context ,
                                           long A106EmployeeId ,
                                           GxSimpleCollection<short> AV10EmployeeIds )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       Object[] GXv_Object1 = new Object[2];
       scmdbuf = "SELECT EmployeeId, EmployeeEmail, EmployeeFirstName, EmployeeLastName, EmployeeName FROM Employee";
       AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV10EmployeeIds, "EmployeeId IN (", ")")+")");
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY EmployeeId";
       GXv_Object1[0] = scmdbuf;
       return GXv_Object1 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_P00B02(context, (long)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

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
        Object[] prmP00B02;
        prmP00B02 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P00B02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B02,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 128);
              return;
     }
  }

}

}
