using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class employeehasanyproject : GXProcedure
   {
      public employeehasanyproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeehasanyproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_EmployeeId ,
                           GxSimpleCollection<long> aP1_ProjectId ,
                           out bool aP2_HasProject )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV12ProjectId = aP1_ProjectId;
         this.AV10HasProject = false ;
         initialize();
         executePrivate();
         aP2_HasProject=this.AV10HasProject;
      }

      public bool executeUdp( long aP0_EmployeeId ,
                              GxSimpleCollection<long> aP1_ProjectId )
      {
         execute(aP0_EmployeeId, aP1_ProjectId, out aP2_HasProject);
         return AV10HasProject ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 GxSimpleCollection<long> aP1_ProjectId ,
                                 out bool aP2_HasProject )
      {
         employeehasanyproject objemployeehasanyproject;
         objemployeehasanyproject = new employeehasanyproject();
         objemployeehasanyproject.AV9EmployeeId = aP0_EmployeeId;
         objemployeehasanyproject.AV12ProjectId = aP1_ProjectId;
         objemployeehasanyproject.AV10HasProject = false ;
         objemployeehasanyproject.context.SetSubmitInitialConfig(context);
         objemployeehasanyproject.initialize();
         Submit( executePrivateCatch,objemployeehasanyproject);
         aP2_HasProject=this.AV10HasProject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((employeehasanyproject)stateInfo).executePrivate();
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
         AV8Employee.Load(AV9EmployeeId);
         AV10HasProject = false;
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV8Employee.gxTpr_Project.Count )
         {
            AV11Project = ((SdtEmployee_Project)AV8Employee.gxTpr_Project.Item(AV13GXV1));
            if ( (AV12ProjectId.IndexOf(AV11Project.gxTpr_Projectid)>0) )
            {
               AV10HasProject = true;
            }
            AV13GXV1 = (int)(AV13GXV1+1);
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
         AV11Project = new SdtEmployee_Project(context);
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private long AV9EmployeeId ;
      private bool AV10HasProject ;
      private GxSimpleCollection<long> AV12ProjectId ;
      private bool aP2_HasProject ;
      private SdtEmployee AV8Employee ;
      private SdtEmployee_Project AV11Project ;
   }

}
