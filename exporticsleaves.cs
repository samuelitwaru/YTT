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
   public class exporticsleaves : GXProcedure
   {
      public exporticsleaves( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public exporticsleaves( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           long aP2_CompanyLocationId ,
                           GxSimpleCollection<long> aP3_EmployeeIds ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4CompanyLocationId = aP2_CompanyLocationId;
         this.AV5EmployeeIds = aP3_EmployeeIds;
         this.AV6Filename = "" ;
         this.AV7ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP4_Filename=this.AV6Filename;
         aP5_ErrorMessage=this.AV7ErrorMessage;
      }

      public string executeUdp( DateTime aP0_FromDate ,
                                DateTime aP1_ToDate ,
                                long aP2_CompanyLocationId ,
                                GxSimpleCollection<long> aP3_EmployeeIds ,
                                out string aP4_Filename )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_CompanyLocationId, aP3_EmployeeIds, out aP4_Filename, out aP5_ErrorMessage);
         return AV7ErrorMessage ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 long aP2_CompanyLocationId ,
                                 GxSimpleCollection<long> aP3_EmployeeIds ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         exporticsleaves objexporticsleaves;
         objexporticsleaves = new exporticsleaves();
         objexporticsleaves.AV2FromDate = aP0_FromDate;
         objexporticsleaves.AV3ToDate = aP1_ToDate;
         objexporticsleaves.AV4CompanyLocationId = aP2_CompanyLocationId;
         objexporticsleaves.AV5EmployeeIds = aP3_EmployeeIds;
         objexporticsleaves.AV6Filename = "" ;
         objexporticsleaves.AV7ErrorMessage = "" ;
         objexporticsleaves.context.SetSubmitInitialConfig(context);
         objexporticsleaves.initialize();
         Submit( executePrivateCatch,objexporticsleaves);
         aP4_Filename=this.AV6Filename;
         aP5_ErrorMessage=this.AV7ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exporticsleaves)stateInfo).executePrivate();
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
         args = new Object[] {(DateTime)AV2FromDate,(DateTime)AV3ToDate,(long)AV4CompanyLocationId,(GxSimpleCollection<long>)AV5EmployeeIds,(string)AV6Filename,(string)AV7ErrorMessage} ;
         ClassLoader.Execute("aexporticsleaves","GeneXus.Programs","aexporticsleaves", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
            AV6Filename = (string)(args[4]) ;
            AV7ErrorMessage = (string)(args[5]) ;
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
         AV6Filename = "";
         AV7ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private long AV4CompanyLocationId ;
      private DateTime AV2FromDate ;
      private DateTime AV3ToDate ;
      private string AV6Filename ;
      private string AV7ErrorMessage ;
      private GxSimpleCollection<long> AV5EmployeeIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
   }

}
