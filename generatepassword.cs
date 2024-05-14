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
   public class generatepassword : GXProcedure
   {
      public generatepassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generatepassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_Password )
      {
         this.AV8Password = "" ;
         initialize();
         executePrivate();
         aP0_Password=this.AV8Password;
      }

      public string executeUdp( )
      {
         execute(out aP0_Password);
         return AV8Password ;
      }

      public void executeSubmit( out string aP0_Password )
      {
         generatepassword objgeneratepassword;
         objgeneratepassword = new generatepassword();
         objgeneratepassword.AV8Password = "" ;
         objgeneratepassword.context.SetSubmitInitialConfig(context);
         objgeneratepassword.initialize();
         Submit( executePrivateCatch,objgeneratepassword);
         aP0_Password=this.AV8Password;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((generatepassword)stateInfo).executePrivate();
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
         AV9httpClient.Host = "www.passwordrandom.com";
         AV9httpClient.Port = 443;
         AV9httpClient.Secure = 1;
         AV9httpClient.AddHeader("Content-type", "application/json");
         AV9httpClient.Execute("GET", "query?command=password");
         if ( AV9httpClient.StatusCode == 200 )
         {
            AV8Password = AV9httpClient.ToString();
         }
         else
         {
            AV8Password = "";
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
         AV8Password = "";
         AV9httpClient = new GxHttpClient( context);
         /* GeneXus formulas. */
      }

      private string AV8Password ;
      private string aP0_Password ;
      private GxHttpClient AV9httpClient ;
   }

}
