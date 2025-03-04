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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_example : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "HttpResponse");
            if ( ! entryPointCalled )
            {
               AV12HttpResponse = gxfirstwebparm;
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprc_example( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_example( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GxHttpResponse aP0_HttpResponse )
      {
         this.AV12HttpResponse = new GxHttpResponse( context) ;
         initialize();
         ExecuteImpl();
         aP0_HttpResponse=this.AV12HttpResponse;
      }

      public GxHttpResponse executeUdp( )
      {
         execute(out aP0_HttpResponse);
         return AV12HttpResponse ;
      }

      public void executeSubmit( out GxHttpResponse aP0_HttpResponse )
      {
         this.AV12HttpResponse = new GxHttpResponse( context) ;
         SubmitImpl();
         aP0_HttpResponse=this.AV12HttpResponse;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12HttpResponse.AddString("Hello World");
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV12HttpResponse = new GxHttpResponse( context);
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private GxHttpResponse AV12HttpResponse ;
      private GxHttpResponse aP0_HttpResponse ;
   }

}
