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
   public class webuitest1 : GXProcedure
   {
      public webuitest1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webuitest1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.gxtest.SdtWebdriver aP0_driver )
      {
         this.AV8driver = aP0_driver;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Programs.gxtest.SdtWebdriver aP0_driver )
      {
         webuitest1 objwebuitest1;
         objwebuitest1 = new webuitest1();
         objwebuitest1.AV8driver = aP0_driver;
         objwebuitest1.context.SetSubmitInitialConfig(context);
         objwebuitest1.initialize();
         Submit( executePrivateCatch,objwebuitest1);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((webuitest1)stateInfo).executePrivate();
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
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.gxtest.SdtWebdriver AV8driver ;
   }

}
