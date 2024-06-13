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
   public class employeeleavereport : GXProcedure
   {
      public employeeleavereport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public employeeleavereport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId ,
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV2CompanyLocationId = aP0_CompanyLocationId;
         this.AV3Filename = "" ;
         this.AV4ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Filename=this.AV3Filename;
         aP2_ErrorMessage=this.AV4ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                out string aP1_Filename )
      {
         execute(aP0_CompanyLocationId, out aP1_Filename, out aP2_ErrorMessage);
         return AV4ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         employeeleavereport objemployeeleavereport;
         objemployeeleavereport = new employeeleavereport();
         objemployeeleavereport.AV2CompanyLocationId = aP0_CompanyLocationId;
         objemployeeleavereport.AV3Filename = "" ;
         objemployeeleavereport.AV4ErrorMessage = "" ;
         objemployeeleavereport.context.SetSubmitInitialConfig(context);
         objemployeeleavereport.initialize();
         Submit( executePrivateCatch,objemployeeleavereport);
         aP1_Filename=this.AV3Filename;
         aP2_ErrorMessage=this.AV4ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((employeeleavereport)stateInfo).executePrivate();
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
         args = new Object[] {(long)AV2CompanyLocationId,(string)AV3Filename,(string)AV4ErrorMessage} ;
         ClassLoader.Execute("aemployeeleavereport","GeneXus.Programs","aemployeeleavereport", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV3Filename = (string)(args[1]) ;
            AV4ErrorMessage = (string)(args[2]) ;
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV3Filename = "";
         AV4ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private long AV2CompanyLocationId ;
      private string AV3Filename ;
      private string AV4ErrorMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
   }

}
