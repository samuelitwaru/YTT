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
   public class reloadleaverequests : GXProcedure
   {
      public reloadleaverequests( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public reloadleaverequests( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate )
      {
         reloadleaverequests objreloadleaverequests;
         objreloadleaverequests = new reloadleaverequests();
         objreloadleaverequests.AV2FromDate = aP0_FromDate;
         objreloadleaverequests.AV3ToDate = aP1_ToDate;
         objreloadleaverequests.context.SetSubmitInitialConfig(context);
         objreloadleaverequests.initialize();
         Submit( executePrivateCatch,objreloadleaverequests);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloadleaverequests)stateInfo).executePrivate();
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
         args = new Object[] {(DateTime)AV2FromDate,(DateTime)AV3ToDate} ;
         ClassLoader.Execute("areloadleaverequests","GeneXus.Programs","areloadleaverequests", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
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
         /* GeneXus formulas. */
      }

      private DateTime AV2FromDate ;
      private DateTime AV3ToDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
