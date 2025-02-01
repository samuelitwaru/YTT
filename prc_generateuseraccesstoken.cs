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
   public class prc_generateuseraccesstoken : GXProcedure
   {
      public prc_generateuseraccesstoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_generateuseraccesstoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV10clientId = AV11GAMApplication.gxTpr_Clientid;
         AV9baseUrl = AV11GAMApplication.gxTpr_Environment.gxTpr_Url;
         AV12username = "samuel.itwaru@example.ug";
         AV13password = "user123";
         new logtofile(context ).execute(  "uri "+AV9baseUrl) ;
         AV8httpclient.AddHeader("Content-Type", "application/x-www-form-urlencoded");
         AV8httpclient.AddVariable("client_id", AV10clientId);
         AV8httpclient.AddVariable("grant_type", "password");
         AV8httpclient.AddVariable("scope", "gam_user_data");
         AV8httpclient.AddVariable("username", AV12username);
         AV8httpclient.AddVariable("password", AV13password);
         AV14url = AV9baseUrl + "/oauth/access_token";
         AV8httpclient.Execute("POST", AV14url);
         AV15result = AV8httpclient.ToString();
         if ( AV8httpclient.StatusCode != 200 )
         {
            new logtofile(context ).execute(  "Error: "+AV8httpclient.ErrDescription) ;
         }
         else
         {
            new logtofile(context ).execute(  "API Result: "+AV15result) ;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV10clientId = "";
         AV9baseUrl = "";
         AV12username = "";
         AV13password = "";
         AV8httpclient = new GxHttpClient( context);
         AV14url = "";
         AV15result = "";
         /* GeneXus formulas. */
      }

      private string AV15result ;
      private string AV10clientId ;
      private string AV9baseUrl ;
      private string AV12username ;
      private string AV13password ;
      private string AV14url ;
      private GxHttpClient AV8httpclient ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV11GAMApplication ;
   }

}
