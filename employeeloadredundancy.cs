using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class employeeloadredundancy : GXProcedure
   {
      public employeeloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public employeeloadredundancy( IGxContext context )
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
         employeeloadredundancy objemployeeloadredundancy;
         objemployeeloadredundancy = new employeeloadredundancy();
         objemployeeloadredundancy.context.SetSubmitInitialConfig(context);
         objemployeeloadredundancy.initialize();
         Submit( executePrivateCatch,objemployeeloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((employeeloadredundancy)stateInfo).executePrivate();
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
         /* Optimized UPDATE. */
         cmdBuffer=" LOCK TABLE Employee IN EXCLUSIVE MODE "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKLOCKERR | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor EMPLOYEELO2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Employee");
         /* End optimized UPDATE. */
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
         cmdBuffer = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeloadredundancy__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string cmdBuffer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
   }

   public class employeeloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmEMPLOYEELO2;
          prmEMPLOYEELO2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("EMPLOYEELO2", "UPDATE Employee SET EmployeeBalance=EmployeeVactionDays - 2 ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmEMPLOYEELO2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
