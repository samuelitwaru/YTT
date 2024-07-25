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
   public class projectsformanager : GXProcedure
   {
      public projectsformanager( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public projectsformanager( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out GxSimpleCollection<long> aP1_projectIds )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9projectIds = new GxSimpleCollection<long>() ;
         initialize();
         executePrivate();
         aP1_projectIds=this.AV9projectIds;
      }

      public GxSimpleCollection<long> executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_projectIds);
         return AV9projectIds ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out GxSimpleCollection<long> aP1_projectIds )
      {
         projectsformanager objprojectsformanager;
         objprojectsformanager = new projectsformanager();
         objprojectsformanager.AV8EmployeeId = aP0_EmployeeId;
         objprojectsformanager.AV9projectIds = new GxSimpleCollection<long>() ;
         objprojectsformanager.context.SetSubmitInitialConfig(context);
         objprojectsformanager.initialize();
         Submit( executePrivateCatch,objprojectsformanager);
         aP1_projectIds=this.AV9projectIds;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((projectsformanager)stateInfo).executePrivate();
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
         /* Using cursor P00BJ2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A166ProjectManagerId = P00BJ2_A166ProjectManagerId[0];
            n166ProjectManagerId = P00BJ2_n166ProjectManagerId[0];
            A102ProjectId = P00BJ2_A102ProjectId[0];
            AV9projectIds.Add(A102ProjectId, 0);
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
         AV9projectIds = new GxSimpleCollection<long>();
         scmdbuf = "";
         P00BJ2_A166ProjectManagerId = new long[1] ;
         P00BJ2_n166ProjectManagerId = new bool[] {false} ;
         P00BJ2_A102ProjectId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.projectsformanager__default(),
            new Object[][] {
                new Object[] {
               P00BJ2_A166ProjectManagerId, P00BJ2_n166ProjectManagerId, P00BJ2_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8EmployeeId ;
      private long A166ProjectManagerId ;
      private long A102ProjectId ;
      private string scmdbuf ;
      private bool n166ProjectManagerId ;
      private GxSimpleCollection<long> AV9projectIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BJ2_A166ProjectManagerId ;
      private bool[] P00BJ2_n166ProjectManagerId ;
      private long[] P00BJ2_A102ProjectId ;
      private GxSimpleCollection<long> aP1_projectIds ;
   }

   public class projectsformanager__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BJ2;
          prmP00BJ2 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BJ2", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV8EmployeeId ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
