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
                           ref DateTime aP1_Date ,
                           out string aP2_Filename ,
                           out string aP3_ErrorMessage )
      {
         this.AV2CompanyLocationId = aP0_CompanyLocationId;
         this.AV3Date = aP1_Date;
         this.AV4Filename = "" ;
         this.AV5ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Date=this.AV3Date;
         aP2_Filename=this.AV4Filename;
         aP3_ErrorMessage=this.AV5ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                ref DateTime aP1_Date ,
                                out string aP2_Filename )
      {
         execute(aP0_CompanyLocationId, ref aP1_Date, out aP2_Filename, out aP3_ErrorMessage);
         return AV5ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 ref DateTime aP1_Date ,
                                 out string aP2_Filename ,
                                 out string aP3_ErrorMessage )
      {
         employeeleavereport objemployeeleavereport;
         objemployeeleavereport = new employeeleavereport();
         objemployeeleavereport.AV2CompanyLocationId = aP0_CompanyLocationId;
         objemployeeleavereport.AV3Date = aP1_Date;
         objemployeeleavereport.AV4Filename = "" ;
         objemployeeleavereport.AV5ErrorMessage = "" ;
         objemployeeleavereport.context.SetSubmitInitialConfig(context);
         objemployeeleavereport.initialize();
         Submit( executePrivateCatch,objemployeeleavereport);
         aP1_Date=this.AV3Date;
         aP2_Filename=this.AV4Filename;
         aP3_ErrorMessage=this.AV5ErrorMessage;
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
         args = new Object[] {(long)AV2CompanyLocationId,(DateTime)AV3Date,(string)AV4Filename,(string)AV5ErrorMessage} ;
         ClassLoader.Execute("aemployeeleavereport","GeneXus.Programs","aemployeeleavereport", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV3Date = (DateTime)(args[1]) ;
            AV4Filename = (string)(args[2]) ;
            AV5ErrorMessage = (string)(args[3]) ;
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
         AV4Filename = "";
         AV5ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private long AV2CompanyLocationId ;
      private string AV4Filename ;
      private DateTime AV3Date ;
      private string AV5ErrorMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP1_Date ;
      private Object[] args ;
      private string aP2_Filename ;
      private string aP3_ErrorMessage ;
   }

}
