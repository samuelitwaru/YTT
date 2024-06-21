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
   public class assignprojectmanager : GXProcedure
   {
      public assignprojectmanager( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assignprojectmanager( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProjectManagerIdVariable ,
                           long aP1_ProjectId )
      {
         this.AV14ProjectManagerIdVariable = aP0_ProjectManagerIdVariable;
         this.AV11ProjectId = aP1_ProjectId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_ProjectManagerIdVariable ,
                                 long aP1_ProjectId )
      {
         assignprojectmanager objassignprojectmanager;
         objassignprojectmanager = new assignprojectmanager();
         objassignprojectmanager.AV14ProjectManagerIdVariable = aP0_ProjectManagerIdVariable;
         objassignprojectmanager.AV11ProjectId = aP1_ProjectId;
         objassignprojectmanager.context.SetSubmitInitialConfig(context);
         objassignprojectmanager.initialize();
         Submit( executePrivateCatch,objassignprojectmanager);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((assignprojectmanager)stateInfo).executePrivate();
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
         AV8Employee.Load(AV14ProjectManagerIdVariable);
         AV13EmployeeProject.gxTpr_Projectid = AV11ProjectId;
         AV8Employee.gxTpr_Project.Add(AV13EmployeeProject, 0);
         if ( AV8Employee.Update() )
         {
            AV10Project.Load(AV11ProjectId);
            AV10Project.gxTpr_Projectmanagerid = AV14ProjectManagerIdVariable;
            if ( AV10Project.Update() )
            {
               new assignprojectmanagerrole(context ).execute(  AV14ProjectManagerIdVariable,  AV11ProjectId) ;
               context.CommitDataStores("assignprojectmanager",pr_default);
            }
         }
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
         AV8Employee = new SdtEmployee(context);
         AV13EmployeeProject = new SdtEmployee_Project(context);
         AV10Project = new SdtProject(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.assignprojectmanager__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assignprojectmanager__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private long AV14ProjectManagerIdVariable ;
      private long AV11ProjectId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private SdtEmployee AV8Employee ;
      private SdtEmployee_Project AV13EmployeeProject ;
      private SdtProject AV10Project ;
   }

   public class assignprojectmanager__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class assignprojectmanager__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
