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
   public class employeehasproject : GXProcedure
   {
      public employeehasproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeehasproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           long aP1_ProjectId ,
                           out bool aP2_HasProject )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV8ProjectId = aP1_ProjectId;
         this.AV10HasProject = false ;
         initialize();
         ExecuteImpl();
         aP2_HasProject=this.AV10HasProject;
      }

      public bool executeUdp( long aP0_EmployeeId ,
                              long aP1_ProjectId )
      {
         execute(aP0_EmployeeId, aP1_ProjectId, out aP2_HasProject);
         return AV10HasProject ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 long aP1_ProjectId ,
                                 out bool aP2_HasProject )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV8ProjectId = aP1_ProjectId;
         this.AV10HasProject = false ;
         SubmitImpl();
         aP2_HasProject=this.AV10HasProject;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10HasProject = false;
         /* Using cursor P00822 */
         pr_default.execute(0, new Object[] {AV9EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00822_A106EmployeeId[0];
            /* Using cursor P00823 */
            pr_default.execute(1, new Object[] {A106EmployeeId, AV8ProjectId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A102ProjectId = P00823_A102ProjectId[0];
               AV10HasProject = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00822_A106EmployeeId = new long[1] ;
         P00823_A106EmployeeId = new long[1] ;
         P00823_A102ProjectId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeehasproject__default(),
            new Object[][] {
                new Object[] {
               P00822_A106EmployeeId
               }
               , new Object[] {
               P00823_A106EmployeeId, P00823_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9EmployeeId ;
      private long AV8ProjectId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private bool AV10HasProject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00822_A106EmployeeId ;
      private long[] P00823_A106EmployeeId ;
      private long[] P00823_A102ProjectId ;
      private bool aP2_HasProject ;
   }

   public class employeehasproject__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00822;
          prmP00822 = new Object[] {
          new ParDef("AV9EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00823;
          prmP00823 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV8ProjectId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00822", "SELECT EmployeeId FROM Employee WHERE EmployeeId = :AV9EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00822,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00823", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId and ProjectId = :AV8ProjectId ORDER BY EmployeeId, ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00823,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
