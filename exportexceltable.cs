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
   public class exportexceltable : GXProcedure
   {
      public exportexceltable( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public exportexceltable( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate ,
                           ref GxSimpleCollection<long> aP2_ProjectId ,
                           ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP4_EmployeeId ,
                           ref GxSimpleCollection<long> aP5_ProjectIds ,
                           ref GXBaseCollection<SdtSDTEmployeeProjectHours> aP6_SDTEmployeeProjectHoursCollection ,
                           ref string aP7_TotalFormattedWorkTime ,
                           ref string aP8_TotalFormattedTime ,
                           out string aP9_Filename ,
                           out string aP10_ErrorMessage )
      {
         this.AV75FromDate = aP0_FromDate;
         this.AV76ToDate = aP1_ToDate;
         this.AV44ProjectId = aP2_ProjectId;
         this.AV46CompanyLocationId = aP3_CompanyLocationId;
         this.AV24EmployeeId = aP4_EmployeeId;
         this.AV85ProjectIds = aP5_ProjectIds;
         this.AV64SDTEmployeeProjectHoursCollection = aP6_SDTEmployeeProjectHoursCollection;
         this.AV89TotalFormattedWorkTime = aP7_TotalFormattedWorkTime;
         this.AV90TotalFormattedTime = aP8_TotalFormattedTime;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_FromDate=this.AV75FromDate;
         aP1_ToDate=this.AV76ToDate;
         aP2_ProjectId=this.AV44ProjectId;
         aP3_CompanyLocationId=this.AV46CompanyLocationId;
         aP4_EmployeeId=this.AV24EmployeeId;
         aP5_ProjectIds=this.AV85ProjectIds;
         aP6_SDTEmployeeProjectHoursCollection=this.AV64SDTEmployeeProjectHoursCollection;
         aP7_TotalFormattedWorkTime=this.AV89TotalFormattedWorkTime;
         aP8_TotalFormattedTime=this.AV90TotalFormattedTime;
         aP9_Filename=this.AV12Filename;
         aP10_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FromDate ,
                                ref DateTime aP1_ToDate ,
                                ref GxSimpleCollection<long> aP2_ProjectId ,
                                ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP4_EmployeeId ,
                                ref GxSimpleCollection<long> aP5_ProjectIds ,
                                ref GXBaseCollection<SdtSDTEmployeeProjectHours> aP6_SDTEmployeeProjectHoursCollection ,
                                ref string aP7_TotalFormattedWorkTime ,
                                ref string aP8_TotalFormattedTime ,
                                out string aP9_Filename )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, ref aP2_ProjectId, ref aP3_CompanyLocationId, ref aP4_EmployeeId, ref aP5_ProjectIds, ref aP6_SDTEmployeeProjectHoursCollection, ref aP7_TotalFormattedWorkTime, ref aP8_TotalFormattedTime, out aP9_Filename, out aP10_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 ref GxSimpleCollection<long> aP2_ProjectId ,
                                 ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP4_EmployeeId ,
                                 ref GxSimpleCollection<long> aP5_ProjectIds ,
                                 ref GXBaseCollection<SdtSDTEmployeeProjectHours> aP6_SDTEmployeeProjectHoursCollection ,
                                 ref string aP7_TotalFormattedWorkTime ,
                                 ref string aP8_TotalFormattedTime ,
                                 out string aP9_Filename ,
                                 out string aP10_ErrorMessage )
      {
         this.AV75FromDate = aP0_FromDate;
         this.AV76ToDate = aP1_ToDate;
         this.AV44ProjectId = aP2_ProjectId;
         this.AV46CompanyLocationId = aP3_CompanyLocationId;
         this.AV24EmployeeId = aP4_EmployeeId;
         this.AV85ProjectIds = aP5_ProjectIds;
         this.AV64SDTEmployeeProjectHoursCollection = aP6_SDTEmployeeProjectHoursCollection;
         this.AV89TotalFormattedWorkTime = aP7_TotalFormattedWorkTime;
         this.AV90TotalFormattedTime = aP8_TotalFormattedTime;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP0_FromDate=this.AV75FromDate;
         aP1_ToDate=this.AV76ToDate;
         aP2_ProjectId=this.AV44ProjectId;
         aP3_CompanyLocationId=this.AV46CompanyLocationId;
         aP4_EmployeeId=this.AV24EmployeeId;
         aP5_ProjectIds=this.AV85ProjectIds;
         aP6_SDTEmployeeProjectHoursCollection=this.AV64SDTEmployeeProjectHoursCollection;
         aP7_TotalFormattedWorkTime=this.AV89TotalFormattedWorkTime;
         aP8_TotalFormattedTime=this.AV90TotalFormattedTime;
         aP9_Filename=this.AV12Filename;
         aP10_ErrorMessage=this.AV13ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV95headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV95headerCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV95headerCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV95headerCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV95headerCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV98bodyCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV98bodyCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV96footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV96footCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV96footCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV96footCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         /* Execute user subroutine: 'GETSESSIONVARIABLES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV88ShowLeaveTotal = BooleanUtil.Val( AV87WebSession.Get("ShowLeaveTotal"));
         GXt_objcol_SdtSDTProject1 = AV63SDTProjects;
         new getworkhourlogdurationbyproject(context ).execute( ref  AV75FromDate, ref  AV76ToDate, ref  AV44ProjectId, ref  AV46CompanyLocationId, ref  AV24EmployeeId, ref  AV85ProjectIds, out  GXt_objcol_SdtSDTProject1) ;
         AV63SDTProjects = GXt_objcol_SdtSDTProject1;
         AV50Columns.Add("Projects:", 0);
         AV99GXV1 = 1;
         while ( AV99GXV1 <= AV63SDTProjects.Count )
         {
            AV65SDTProject = ((SdtSDTProject)AV63SDTProjects.Item(AV99GXV1));
            AV50Columns.Add(StringUtil.Trim( AV65SDTProject.gxTpr_Projectname), 0);
            AV99GXV1 = (int)(AV99GXV1+1);
         }
         AV50Columns.Add("Total Work Hours", 0);
         if ( AV88ShowLeaveTotal )
         {
            AV50Columns.Add("Total Leave Hours", 0);
            AV50Columns.Add("Total", 0);
         }
         AV68ColumnString = AV50Columns.ToJSonString(false);
         AV68ColumnString = AV64SDTEmployeeProjectHoursCollection.ToJSonString(false);
         Gx_msg = AV68ColumnString;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV92excelcellrange = AV91excelSpreadsheet.cell(1, 1);
         AV92excelcellrange.gxTpr_Valuetext = "Project Overview";
         AV93excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV93excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV93excelCellStyle.gxTpr_Font.gxTpr_Size = 14;
         AV93excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV93excelCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV92excelcellrange.setcellstyle( AV93excelCellStyle);
         AV14CellRow = 2;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV101GXV2 = 1;
         while ( AV101GXV2 <= AV64SDTEmployeeProjectHoursCollection.Count )
         {
            AV66SDTEmployeeProjectHours = ((SdtSDTEmployeeProjectHours)AV64SDTEmployeeProjectHoursCollection.Item(AV101GXV2));
            AV14CellRow = (int)(AV14CellRow+1);
            AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, 1);
            AV92excelcellrange.gxTpr_Valuetext = StringUtil.Trim( AV66SDTEmployeeProjectHours.gxTpr_Employeename);
            AV92excelcellrange.setcellstyle( AV98bodyCellStyle);
            AV102GXV3 = 1;
            while ( AV102GXV3 <= AV66SDTEmployeeProjectHours.gxTpr_Projecthours.Count )
            {
               AV67ProjectHoursItem = ((SdtSDTEmployeeProjectHours_ProjectHoursItem)AV66SDTEmployeeProjectHours.gxTpr_Projecthours.Item(AV102GXV3));
               AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, AV50Columns.IndexOf(StringUtil.Trim( AV67ProjectHoursItem.gxTpr_Projectname)));
               AV92excelcellrange.gxTpr_Valuetext = AV67ProjectHoursItem.gxTpr_Projectformattedtime;
               AV92excelcellrange.setcellstyle( AV98bodyCellStyle);
               AV102GXV3 = (int)(AV102GXV3+1);
            }
            AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, AV50Columns.IndexOf("Total Work Hours"));
            AV92excelcellrange.gxTpr_Valuetext = AV66SDTEmployeeProjectHours.gxTpr_Totalformattedtime;
            AV92excelcellrange.setcellstyle( AV98bodyCellStyle);
            if ( AV88ShowLeaveTotal )
            {
               AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, AV50Columns.IndexOf("Total Leave Hours"));
               AV92excelcellrange.gxTpr_Valuetext = AV66SDTEmployeeProjectHours.gxTpr_Totalformattedleave;
               AV92excelcellrange.setcellstyle( AV98bodyCellStyle);
               AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, AV50Columns.IndexOf("Total"));
               AV92excelcellrange.gxTpr_Valuetext = AV66SDTEmployeeProjectHours.gxTpr_Totalformattedtime;
               AV92excelcellrange.setcellstyle( AV98bodyCellStyle);
            }
            AV101GXV2 = (int)(AV101GXV2+1);
         }
         AV14CellRow = (int)(AV14CellRow+1);
         AV38VisibleColumnCount = 0;
         AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount));
         AV92excelcellrange.gxTpr_Valuetext = "Total";
         AV92excelcellrange.setcellstyle( AV96footCellStyle);
         AV103GXV4 = 1;
         while ( AV103GXV4 <= AV63SDTProjects.Count )
         {
            AV65SDTProject = ((SdtSDTProject)AV63SDTProjects.Item(AV103GXV4));
            AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, AV50Columns.IndexOf(StringUtil.Trim( AV65SDTProject.gxTpr_Projectname)));
            AV92excelcellrange.gxTpr_Valuetext = AV65SDTProject.gxTpr_Projectformattedtime;
            AV92excelcellrange.setcellstyle( AV96footCellStyle);
            AV103GXV4 = (int)(AV103GXV4+1);
         }
         AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, AV50Columns.IndexOf("Total Work Hours"));
         AV92excelcellrange.gxTpr_Valuetext = AV90TotalFormattedTime;
         AV92excelcellrange.setcellstyle( AV93excelCellStyle);
         if ( AV88ShowLeaveTotal )
         {
            AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, AV50Columns.IndexOf("Total"));
            AV92excelcellrange.gxTpr_Valuetext = AV90TotalFormattedTime;
            AV92excelcellrange.setcellstyle( AV93excelCellStyle);
         }
         AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow+2, 1);
         GXt_char2 = "";
         new formatdatetime(context ).execute(  AV75FromDate,  "DD.MM.YYYY", out  GXt_char2) ;
         AV92excelcellrange.gxTpr_Valuetext = "Start Date "+GXt_char2;
         AV92excelcellrange.setcellstyle( AV96footCellStyle);
         AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow+3, 1);
         GXt_char2 = "";
         new formatdatetime(context ).execute(  AV76ToDate,  "DD.MM.YYYY", out  GXt_char2) ;
         AV92excelcellrange.gxTpr_Valuetext = "End Date "+GXt_char2;
         AV92excelcellrange.setcellstyle( AV96footCellStyle);
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         GXt_char2 = AV12Filename;
         new formatdatetime(context ).execute(  AV75FromDate,  "YYYY-MM-DD", out  GXt_char2) ;
         GXt_char3 = AV12Filename;
         new formatdatetime(context ).execute(  AV76ToDate,  "YYYY-MM-DD", out  GXt_char3) ;
         AV12Filename = "ReportExport-" + GXt_char2 + "_" + GXt_char3 + ".xlsx";
         AV97File.Source = AV12Filename;
         AV97File.Delete();
         AV91excelSpreadsheet.open( AV12Filename);
      }

      protected void S121( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV38VisibleColumnCount = 0;
         AV104GXV5 = 1;
         while ( AV104GXV5 <= AV50Columns.Count )
         {
            AV49Column = ((string)AV50Columns.Item(AV104GXV5));
            AV92excelcellrange = AV91excelSpreadsheet.cell(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount));
            AV92excelcellrange.gxTpr_Valuetext = AV49Column;
            AV92excelcellrange.setcellstyle( AV95headerCellStyle);
            AV38VisibleColumnCount = (long)(AV38VisibleColumnCount+1);
            AV104GXV5 = (int)(AV104GXV5+1);
         }
      }

      protected void S131( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV91excelSpreadsheet.gxTpr_Autofit = true;
         AV94boolean = AV91excelSpreadsheet.save();
         if ( AV94boolean )
         {
            AV91excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV91excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV91excelSpreadsheet.gxTpr_Errdescription);
         }
         AV25Session.Set("WWPExportFilePath", AV12Filename);
         AV25Session.Set("WWPExportFileName", AV12Filename);
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S141( )
      {
         /* 'GETSESSIONVARIABLES' Routine */
         returnInSub = false;
         AV89TotalFormattedWorkTime = AV87WebSession.Get("TotalFormattedWorkTime");
         AV90TotalFormattedTime = AV87WebSession.Get("TotalFormattedTime");
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV95headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV98bodyCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV96footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV87WebSession = context.GetSession();
         AV63SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         GXt_objcol_SdtSDTProject1 = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         AV50Columns = new GxSimpleCollection<string>();
         AV65SDTProject = new SdtSDTProject(context);
         AV68ColumnString = "";
         Gx_msg = "";
         AV92excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV91excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         AV93excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV66SDTEmployeeProjectHours = new SdtSDTEmployeeProjectHours(context);
         AV67ProjectHoursItem = new SdtSDTEmployeeProjectHours_ProjectHoursItem(context);
         GXt_char2 = "";
         GXt_char3 = "";
         AV97File = new GxFile(context.GetPhysicalPath());
         AV49Column = "";
         AV25Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private int AV99GXV1 ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV101GXV2 ;
      private int AV102GXV3 ;
      private int AV103GXV4 ;
      private int AV104GXV5 ;
      private long AV38VisibleColumnCount ;
      private string AV89TotalFormattedWorkTime ;
      private string AV90TotalFormattedTime ;
      private string Gx_msg ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private DateTime AV75FromDate ;
      private DateTime AV76ToDate ;
      private bool returnInSub ;
      private bool AV88ShowLeaveTotal ;
      private bool AV94boolean ;
      private string AV68ColumnString ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV49Column ;
      private IGxSession AV87WebSession ;
      private IGxSession AV25Session ;
      private GxFile AV97File ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> AV44ProjectId ;
      private GxSimpleCollection<long> aP2_ProjectId ;
      private GxSimpleCollection<long> AV46CompanyLocationId ;
      private GxSimpleCollection<long> aP3_CompanyLocationId ;
      private GxSimpleCollection<long> AV24EmployeeId ;
      private GxSimpleCollection<long> aP4_EmployeeId ;
      private GxSimpleCollection<long> AV85ProjectIds ;
      private GxSimpleCollection<long> aP5_ProjectIds ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> AV64SDTEmployeeProjectHoursCollection ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> aP6_SDTEmployeeProjectHoursCollection ;
      private string aP7_TotalFormattedWorkTime ;
      private string aP8_TotalFormattedTime ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV95headerCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV98bodyCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV96footCellStyle ;
      private GXBaseCollection<SdtSDTProject> AV63SDTProjects ;
      private GXBaseCollection<SdtSDTProject> GXt_objcol_SdtSDTProject1 ;
      private GxSimpleCollection<string> AV50Columns ;
      private SdtSDTProject AV65SDTProject ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV92excelcellrange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV91excelSpreadsheet ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV93excelCellStyle ;
      private SdtSDTEmployeeProjectHours AV66SDTEmployeeProjectHours ;
      private SdtSDTEmployeeProjectHours_ProjectHoursItem AV67ProjectHoursItem ;
      private string aP9_Filename ;
      private string aP10_ErrorMessage ;
   }

}
