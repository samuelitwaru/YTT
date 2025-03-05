using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class api_timetracker : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel ApiIntegratedSecurityLevel( string permissionMethod )
      {
         if ( StringUtil.StrCmp(permissionMethod, "gxep_api_icsleaveapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         return GAMSecurityLevel.SecurityLow ;
      }

      protected override string ApiExecutePermissionPrefix( string permissionMethod )
      {
         return "" ;
      }

      public api_timetracker( )
      {
         context = new GxContext(  );
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public api_timetracker( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.Method);
         }
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      protected void E11012( )
      {
         /* Api_icsleaveapi_After Routine */
         returnInSub = false;
         new logtofile(context ).execute(  AV15result) ;
         AV15result = AV12ICSLeaveExport;
      }

      public void gxep_api_icsleaveapi( out string aP0_result )
      {
         initialize();
         /* API_ICSLeaveAPI Constructor */
         new prc_icsleaveapi(context ).execute( out  AV12ICSLeaveExport) ;
         /* Execute user event: Api_icsleaveapi.After */
         E11012 ();
         if ( returnInSub )
         {
            aP0_result=this.AV15result;
            return;
         }
         aP0_result=this.AV15result;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV15result = "";
         AV12ICSLeaveExport = "";
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected bool returnInSub ;
      protected string AV15result ;
      protected string AV12ICSLeaveExport ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected string aP0_result ;
   }

}
