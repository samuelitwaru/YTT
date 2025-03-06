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
   public class prc_setemployeepassword : GXProcedure
   {
      public prc_setemployeepassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_setemployeepassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out string aP1_EmployeeAPIPassword )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9EmployeeAPIPassword = "" ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeAPIPassword=this.AV9EmployeeAPIPassword;
      }

      public string executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_EmployeeAPIPassword);
         return AV9EmployeeAPIPassword ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out string aP1_EmployeeAPIPassword )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9EmployeeAPIPassword = "" ;
         SubmitImpl();
         aP1_EmployeeAPIPassword=this.AV9EmployeeAPIPassword;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CG2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTCG2 = 0;
            A106EmployeeId = P00CG2_A106EmployeeId[0];
            A188EmployeeAPIPassword = P00CG2_A188EmployeeAPIPassword[0];
            AV11GUIDString = StringUtil.Trim( Guid.NewGuid( ).ToString());
            AV9EmployeeAPIPassword = AV11GUIDString;
            new logtofile(context ).execute(  AV9EmployeeAPIPassword) ;
            A188EmployeeAPIPassword = AV9EmployeeAPIPassword;
            GXTCG2 = 1;
            /* Using cursor P00CG3 */
            pr_default.execute(1, new Object[] {A188EmployeeAPIPassword, A106EmployeeId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Employee");
            if ( GXTCG2 == 1 )
            {
               context.CommitDataStores("prc_setemployeepassword",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_setemployeepassword",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9EmployeeAPIPassword = "";
         P00CG2_A106EmployeeId = new long[1] ;
         P00CG2_A188EmployeeAPIPassword = new string[] {""} ;
         A188EmployeeAPIPassword = "";
         AV11GUIDString = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_setemployeepassword__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_setemployeepassword__default(),
            new Object[][] {
                new Object[] {
               P00CG2_A106EmployeeId, P00CG2_A188EmployeeAPIPassword
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTCG2 ;
      private long AV8EmployeeId ;
      private long A106EmployeeId ;
      private string AV9EmployeeAPIPassword ;
      private string A188EmployeeAPIPassword ;
      private string AV11GUIDString ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00CG2_A106EmployeeId ;
      private string[] P00CG2_A188EmployeeAPIPassword ;
      private string aP1_EmployeeAPIPassword ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_setemployeepassword__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_setemployeepassword__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00CG2;
        prmP00CG2 = new Object[] {
        new ParDef("AV8EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmP00CG3;
        prmP00CG3 = new Object[] {
        new ParDef("EmployeeAPIPassword",GXType.VarChar,40,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00CG2", "SELECT EmployeeId, EmployeeAPIPassword FROM Employee WHERE EmployeeId = :AV8EmployeeId ORDER BY EmployeeId  FOR UPDATE OF Employee",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CG2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00CG3", "SAVEPOINT gxupdate;UPDATE Employee SET EmployeeAPIPassword=:EmployeeAPIPassword  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CG3)
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
              return;
     }
  }

}

}
