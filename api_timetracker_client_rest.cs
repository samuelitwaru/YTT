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
      public api_timetracker( )
      {
         context = new GxContext(  );
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
         initialize();
      }

      public api_timetracker( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         initialize();
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

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 8082;
         restLocation.BaseUrl = "YTT_version4NETPostgreSQL14/API_TimeTracker";
         gxProperties = new GxObjectProperties();
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_api_exporticsleaves( [GxJsonFormat("yyyy-MM-dd")] DateTime aP0_FromDate ,
                                            [GxJsonFormat("yyyy-MM-dd")] DateTime aP1_ToDate ,
                                            long aP2_EmployeeId ,
                                            out string aP3_Filename ,
                                            out string aP4_ErrorMessage )
      {
         restCliAPI_ExportICSLeaves = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/export-ics-leaves";
         restCliAPI_ExportICSLeaves.Location = restLocation;
         restCliAPI_ExportICSLeaves.HttpMethod = "POST";
         restCliAPI_ExportICSLeaves.AddBodyVar("FromDate", (DateTime)(aP0_FromDate));
         restCliAPI_ExportICSLeaves.AddBodyVar("ToDate", (DateTime)(aP1_ToDate));
         restCliAPI_ExportICSLeaves.AddBodyVar("EmployeeId", (long)(aP2_EmployeeId));
         restCliAPI_ExportICSLeaves.RestExecute();
         if ( restCliAPI_ExportICSLeaves.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAPI_ExportICSLeaves.ErrorCode;
            gxProperties.ErrorMessage = restCliAPI_ExportICSLeaves.ErrorMessage;
            gxProperties.StatusCode = restCliAPI_ExportICSLeaves.StatusCode;
            aP3_Filename = "";
            aP4_ErrorMessage = "";
         }
         else
         {
            aP3_Filename = restCliAPI_ExportICSLeaves.GetBodyString("Filename");
            aP4_ErrorMessage = restCliAPI_ExportICSLeaves.GetBodyString("ErrorMessage");
         }
         /* API_ExportICSLeaves Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxProperties = new GxObjectProperties();
         restCliAPI_ExportICSLeaves = new GXRestAPIClient();
         aP3_Filename = "";
         aP4_ErrorMessage = "";
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliAPI_ExportICSLeaves ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected string aP3_Filename ;
      protected string aP4_ErrorMessage ;
   }

}
