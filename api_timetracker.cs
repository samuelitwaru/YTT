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
         if ( StringUtil.StrCmp(permissionMethod, "gxep_api_exporticsleaves") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
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

      public void gxep_api_exporticsleaves( [GxJsonFormat("yyyy-MM-dd")] DateTime aP0_FromDate ,
                                            [GxJsonFormat("yyyy-MM-dd")] DateTime aP1_ToDate ,
                                            long aP2_EmployeeId ,
                                            out string aP3_Filename ,
                                            out string aP4_ErrorMessage )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV9EmployeeId = aP2_EmployeeId;
         initialize();
         /* API_ExportICSLeaves Constructor */
         new prc_exporticsleaves(context ).execute(  AV6FromDate,  AV7ToDate,  AV9EmployeeId, out  AV10Filename, out  AV11ErrorMessage) ;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV11ErrorMessage;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV10Filename = "";
         AV11ErrorMessage = "";
         /* GeneXus formulas. */
      }

      protected long AV9EmployeeId ;
      protected string Gx_restmethod ;
      protected DateTime AV6FromDate ;
      protected DateTime AV7ToDate ;
      protected string AV11ErrorMessage ;
      protected string AV10Filename ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected string aP3_Filename ;
      protected string aP4_ErrorMessage ;
   }

}
