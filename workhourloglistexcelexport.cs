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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class workhourloglistexcelexport : GXProcedure
   {
      public workhourloglistexcelexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourloglistexcelexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV12Filename = "" ;
         this.AV17ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP3_Filename=this.AV12Filename;
         aP4_ErrorMessage=this.AV17ErrorMessage;
      }

      public string executeUdp( long aP0_EmployeeId ,
                                DateTime aP1_FromDate ,
                                DateTime aP2_ToDate ,
                                out string aP3_Filename )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, out aP3_Filename, out aP4_ErrorMessage);
         return AV17ErrorMessage ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         workhourloglistexcelexport objworkhourloglistexcelexport;
         objworkhourloglistexcelexport = new workhourloglistexcelexport();
         objworkhourloglistexcelexport.AV8EmployeeId = aP0_EmployeeId;
         objworkhourloglistexcelexport.AV9FromDate = aP1_FromDate;
         objworkhourloglistexcelexport.AV10ToDate = aP2_ToDate;
         objworkhourloglistexcelexport.AV12Filename = "" ;
         objworkhourloglistexcelexport.AV17ErrorMessage = "" ;
         objworkhourloglistexcelexport.context.SetSubmitInitialConfig(context);
         objworkhourloglistexcelexport.initialize();
         Submit( executePrivateCatch,objworkhourloglistexcelexport);
         aP3_Filename=this.AV12Filename;
         aP4_ErrorMessage=this.AV17ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workhourloglistexcelexport)stateInfo).executePrivate();
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
         AV33headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV33headerCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV33headerCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV33headerCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV33headerCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         GXt_char1 = AV12Filename;
         new formatdatetime(context ).execute(  AV9FromDate,  "YYYY-MM-DD", out  GXt_char1) ;
         GXt_char2 = AV12Filename;
         new formatdatetime(context ).execute(  AV10ToDate,  "YYYY-MM-DD", out  GXt_char2) ;
         AV12Filename = "ReportExport-" + GXt_char1 + "_" + GXt_char2 + ".xlsx";
         AV19File.Source = AV12Filename;
         AV19File.Delete();
         AV20excelSpreadsheet.open( AV12Filename);
      }

      protected void S121( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV28CellRow = 2;
         AV29FirstColumn = 1;
         AV35Columns.Add("Employee Name", 0);
         AV35Columns.Add("Project Name", 0);
         AV35Columns.Add("Log Date", 0);
         AV35Columns.Add("Log Description", 0);
         AV22VisibleColumnCount = 0;
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV35Columns.Count )
         {
            AV30Column = ((string)AV35Columns.Item(AV36GXV1));
            AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow, AV29FirstColumn+AV22VisibleColumnCount);
            AV21excelcellrange.gxTpr_Valuetext = AV30Column;
            AV21excelcellrange.setcellstyle( AV33headerCellStyle);
            AV22VisibleColumnCount = (short)(AV22VisibleColumnCount+1);
            AV36GXV1 = (int)(AV36GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV20excelSpreadsheet.gxTpr_Autofit = true;
         AV25boolean = AV20excelSpreadsheet.save();
         if ( AV25boolean )
         {
            AV20excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV20excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV20excelSpreadsheet.gxTpr_Errdescription);
         }
         AV18Session.Set("WWPExportFilePath", AV12Filename);
         AV18Session.Set("WWPExportFileName", AV12Filename);
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
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
         AV12Filename = "";
         AV17ErrorMessage = "";
         AV33headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         GXt_char1 = "";
         GXt_char2 = "";
         AV19File = new GxFile(context.GetPhysicalPath());
         AV20excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         AV35Columns = new GxSimpleCollection<string>();
         AV30Column = "";
         AV21excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV18Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private short AV28CellRow ;
      private short AV29FirstColumn ;
      private short AV22VisibleColumnCount ;
      private int AV36GXV1 ;
      private long AV8EmployeeId ;
      private string AV12Filename ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private DateTime AV9FromDate ;
      private DateTime AV10ToDate ;
      private bool returnInSub ;
      private bool AV25boolean ;
      private string AV17ErrorMessage ;
      private string AV30Column ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
      private IGxSession AV18Session ;
      private GxSimpleCollection<string> AV35Columns ;
      private GxFile AV19File ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV20excelSpreadsheet ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV21excelcellrange ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV33headerCellStyle ;
   }

}
