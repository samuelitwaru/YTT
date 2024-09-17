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
namespace GeneXus.Programs.wwpbaseobjects {
   public class awwp_downloadreport : GXWebProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwp_downloadreport_Execute" ;
         }

      }

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
            gxfirstwebparm = GetFirstPar( "fileName");
            if ( ! entryPointCalled )
            {
               AV9fileName = gxfirstwebparm;
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public awwp_downloadreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awwp_downloadreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_fileName )
      {
         this.AV9fileName = "" ;
         initialize();
         ExecuteImpl();
         aP0_fileName=this.AV9fileName;
      }

      public string executeUdp( )
      {
         execute(out aP0_fileName);
         return AV9fileName ;
      }

      public void executeSubmit( out string aP0_fileName )
      {
         this.AV9fileName = "" ;
         SubmitImpl();
         aP0_fileName=this.AV9fileName;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9fileName = AV12webSession.Get("WWPExportFilePath");
         AV11name = AV12webSession.Get("WWPExportFileName");
         new logtofile(context ).execute(  "fileName: "+AV9fileName) ;
         new logtofile(context ).execute(  "name: "+AV11name) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9fileName)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11name)) )
         {
            AV12webSession.Remove("WWPExportFilePath");
            AV12webSession.Remove("WWPExportFileName");
            if ( ! context.isAjaxRequest( ) )
            {
               AV10httpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
            if ( ! context.isAjaxRequest( ) )
            {
               AV10httpResponse.AppendHeader("X-Frame-Options", "deny");
            }
            if ( ! context.isAjaxRequest( ) )
            {
               AV10httpResponse.AppendHeader("Type-Options", "nosniff");
            }
            if ( ! context.isAjaxRequest( ) )
            {
               AV10httpResponse.AppendHeader("Content-Disposition", "attachment;filename="+AV11name);
            }
            AV10httpResponse.AddFile(AV9fileName);
         }
         else
         {
            new logtofile(context ).execute(  "Not found") ;
            AV10httpResponse.AddString("Not found");
         }
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
         AV9fileName = "";
         AV12webSession = context.GetSession();
         AV11name = "";
         AV10httpResponse = new GxHttpResponse( context);
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private string AV9fileName ;
      private string AV11name ;
      private IGxSession AV12webSession ;
      private GxHttpResponse AV10httpResponse ;
      private string aP0_fileName ;
   }

}
