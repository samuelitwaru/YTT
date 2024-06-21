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
   public class assignprojectmanagerrole : GXProcedure
   {
      public assignprojectmanagerrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assignprojectmanagerrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           long aP1_ProjectId )
      {
         this.AV19EmployeeId = aP0_EmployeeId;
         this.AV20ProjectId = aP1_ProjectId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 long aP1_ProjectId )
      {
         assignprojectmanagerrole objassignprojectmanagerrole;
         objassignprojectmanagerrole = new assignprojectmanagerrole();
         objassignprojectmanagerrole.AV19EmployeeId = aP0_EmployeeId;
         objassignprojectmanagerrole.AV20ProjectId = aP1_ProjectId;
         objassignprojectmanagerrole.context.SetSubmitInitialConfig(context);
         objassignprojectmanagerrole.initialize();
         Submit( executePrivateCatch,objassignprojectmanagerrole);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((assignprojectmanagerrole)stateInfo).executePrivate();
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
         AV14Project.Load(AV20ProjectId);
         AV11GAMRole = AV12GAMRepository.getrolebyexternalid("IsProject Manager", out  AV10GAMErrorCollection);
         if ( ! (0==AV14Project.gxTpr_Projectmanagerid) )
         {
            AV15CurrentEmployee.Load(AV14Project.gxTpr_Projectmanagerid);
            AV21GXLvl9 = 0;
            /* Using cursor P00972 */
            pr_default.execute(0, new Object[] {AV15CurrentEmployee.gxTpr_Employeeid, AV20ProjectId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A166ProjectManagerId = P00972_A166ProjectManagerId[0];
               n166ProjectManagerId = P00972_n166ProjectManagerId[0];
               A102ProjectId = P00972_A102ProjectId[0];
               AV21GXLvl9 = 1;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV21GXLvl9 == 0 )
            {
               AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV15CurrentEmployee.gxTpr_Employeeemail, out  AV10GAMErrorCollection);
               AV9GAMUser.deleterole( AV11GAMRole, out  AV10GAMErrorCollection);
            }
         }
         AV8Employee.Load(AV19EmployeeId);
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV8Employee.gxTpr_Employeeemail, out  AV10GAMErrorCollection);
         AV9GAMUser.addrolebyid( AV11GAMRole.gxTpr_Id, out  AV10GAMErrorCollection);
         context.CommitDataStores("assignprojectmanagerrole",pr_default);
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
         AV14Project = new SdtProject(context);
         AV11GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV10GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV15CurrentEmployee = new SdtEmployee(context);
         scmdbuf = "";
         P00972_A166ProjectManagerId = new long[1] ;
         P00972_n166ProjectManagerId = new bool[] {false} ;
         P00972_A102ProjectId = new long[1] ;
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Employee = new SdtEmployee(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.assignprojectmanagerrole__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assignprojectmanagerrole__default(),
            new Object[][] {
                new Object[] {
               P00972_A166ProjectManagerId, P00972_n166ProjectManagerId, P00972_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21GXLvl9 ;
      private long AV19EmployeeId ;
      private long AV20ProjectId ;
      private long A166ProjectManagerId ;
      private long A102ProjectId ;
      private string scmdbuf ;
      private bool n166ProjectManagerId ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV12GAMRepository ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00972_A166ProjectManagerId ;
      private bool[] P00972_n166ProjectManagerId ;
      private long[] P00972_A102ProjectId ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
      private SdtEmployee AV15CurrentEmployee ;
      private SdtEmployee AV8Employee ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV11GAMRole ;
      private SdtProject AV14Project ;
   }

   public class assignprojectmanagerrole__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class assignprojectmanagerrole__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00972;
        prmP00972 = new Object[] {
        new ParDef("AV15Curr_1Employeeid",GXType.Int64,10,0) ,
        new ParDef("AV20ProjectId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00972", "SELECT ProjectManagerId, ProjectId FROM Project WHERE (ProjectManagerId = :AV15Curr_1Employeeid) AND (ProjectId <> :AV20ProjectId) ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00972,100, GxCacheFrequency.OFF ,false,false )
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
