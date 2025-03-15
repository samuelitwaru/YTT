using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class prc_exportprojectoverview : GXProcedure
   {
      public prc_exportprojectoverview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_exportprojectoverview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                           GxSimpleCollection<long> aP3_ProjectIdCollection ,
                           GxSimpleCollection<long> aP4_CompanyLocationIdCollection ,
                           bool aP5_ShowLeaveTotal ,
                           GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP6_SDT_EmployeeProjectMatrixCollection ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV15FromDate = aP0_FromDate;
         this.AV16ToDate = aP1_ToDate;
         this.AV40EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV38ProjectIdCollection = aP3_ProjectIdCollection;
         this.AV39CompanyLocationIdCollection = aP4_CompanyLocationIdCollection;
         this.AV20ShowLeaveTotal = aP5_ShowLeaveTotal;
         this.AV8SDT_EmployeeProjectMatrixCollection = aP6_SDT_EmployeeProjectMatrixCollection;
         this.AV21Filename = "" ;
         this.AV41ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP7_Filename=this.AV21Filename;
         aP8_ErrorMessage=this.AV41ErrorMessage;
      }

      public string executeUdp( DateTime aP0_FromDate ,
                                DateTime aP1_ToDate ,
                                GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                GxSimpleCollection<long> aP3_ProjectIdCollection ,
                                GxSimpleCollection<long> aP4_CompanyLocationIdCollection ,
                                bool aP5_ShowLeaveTotal ,
                                GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP6_SDT_EmployeeProjectMatrixCollection ,
                                out string aP7_Filename )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_EmployeeIdCollection, aP3_ProjectIdCollection, aP4_CompanyLocationIdCollection, aP5_ShowLeaveTotal, aP6_SDT_EmployeeProjectMatrixCollection, out aP7_Filename, out aP8_ErrorMessage);
         return AV41ErrorMessage ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                 GxSimpleCollection<long> aP3_ProjectIdCollection ,
                                 GxSimpleCollection<long> aP4_CompanyLocationIdCollection ,
                                 bool aP5_ShowLeaveTotal ,
                                 GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP6_SDT_EmployeeProjectMatrixCollection ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         this.AV15FromDate = aP0_FromDate;
         this.AV16ToDate = aP1_ToDate;
         this.AV40EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV38ProjectIdCollection = aP3_ProjectIdCollection;
         this.AV39CompanyLocationIdCollection = aP4_CompanyLocationIdCollection;
         this.AV20ShowLeaveTotal = aP5_ShowLeaveTotal;
         this.AV8SDT_EmployeeProjectMatrixCollection = aP6_SDT_EmployeeProjectMatrixCollection;
         this.AV21Filename = "" ;
         this.AV41ErrorMessage = "" ;
         SubmitImpl();
         aP7_Filename=this.AV21Filename;
         aP8_ErrorMessage=this.AV41ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV9headerCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV9headerCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV9headerCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV9headerCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV10bodyCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV10bodyCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV11footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV11footCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV11footCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV11footCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         if ( AV38ProjectIdCollection.Count > 0 )
         {
            GXt_objcol_int1 = AV42ProjectEmployeeIdCollection;
            new getemployeeidsbyproject(context ).execute(  AV38ProjectIdCollection, out  GXt_objcol_int1) ;
            AV42ProjectEmployeeIdCollection = GXt_objcol_int1;
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV8SDT_EmployeeProjectMatrixCollection.Count )
         {
            AV34SDT_EmployeeProjectMatrix = ((SdtSDT_EmployeeProjectMatrix)AV8SDT_EmployeeProjectMatrixCollection.Item(AV52GXV1));
            AV53GXV2 = 1;
            while ( AV53GXV2 <= AV34SDT_EmployeeProjectMatrix.gxTpr_Projects.Count )
            {
               AV51ProjectItem = ((SdtSDT_EmployeeProjectMatrix_ProjectsItem)AV34SDT_EmployeeProjectMatrix.gxTpr_Projects.Item(AV53GXV2));
               if ( ! (AV50ReturnedProjectIdCollection.IndexOf(AV51ProjectItem.gxTpr_Projectid)>0) )
               {
                  AV13SDTProject = new SdtSDTProject(context);
                  AV13SDTProject.gxTpr_Id = AV51ProjectItem.gxTpr_Projectid;
                  AV13SDTProject.gxTpr_Projectname = StringUtil.Trim( AV51ProjectItem.gxTpr_Projectname);
                  AV13SDTProject.gxTpr_Smallcaseprojectname = StringUtil.Trim( StringUtil.Lower( AV51ProjectItem.gxTpr_Projectname));
                  pr_default.dynParam(0, new Object[]{ new Object[]{
                                                       A157CompanyLocationId ,
                                                       AV39CompanyLocationIdCollection ,
                                                       A106EmployeeId ,
                                                       AV40EmployeeIdCollection ,
                                                       AV42ProjectEmployeeIdCollection ,
                                                       AV39CompanyLocationIdCollection.Count ,
                                                       AV40EmployeeIdCollection.Count ,
                                                       AV42ProjectEmployeeIdCollection.Count ,
                                                       A119WorkHourLogDate ,
                                                       AV15FromDate ,
                                                       AV16ToDate ,
                                                       A102ProjectId ,
                                                       AV51ProjectItem.gxTpr_Projectid } ,
                                                       new int[]{
                                                       TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00CD2 */
                  pr_default.execute(0, new Object[] {AV15FromDate, AV16ToDate, AV51ProjectItem.gxTpr_Projectid});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A100CompanyId = P00CD2_A100CompanyId[0];
                     A106EmployeeId = P00CD2_A106EmployeeId[0];
                     A157CompanyLocationId = P00CD2_A157CompanyLocationId[0];
                     A119WorkHourLogDate = P00CD2_A119WorkHourLogDate[0];
                     A102ProjectId = P00CD2_A102ProjectId[0];
                     A121WorkHourLogHour = P00CD2_A121WorkHourLogHour[0];
                     A122WorkHourLogMinute = P00CD2_A122WorkHourLogMinute[0];
                     A118WorkHourLogId = P00CD2_A118WorkHourLogId[0];
                     A100CompanyId = P00CD2_A100CompanyId[0];
                     A157CompanyLocationId = P00CD2_A157CompanyLocationId[0];
                     AV13SDTProject.gxTpr_Projecttime = (long)(AV13SDTProject.gxTpr_Projecttime+((A122WorkHourLogMinute+A121WorkHourLogHour*60)));
                     pr_default.readNext(0);
                  }
                  pr_default.close(0);
                  GXt_char2 = "";
                  new formattime(context ).execute(  AV13SDTProject.gxTpr_Projecttime, out  GXt_char2) ;
                  AV13SDTProject.gxTpr_Projectformattedtime = GXt_char2;
                  AV12SDTProjectCollection.Add(AV13SDTProject, 0);
                  AV50ReturnedProjectIdCollection.Add(AV51ProjectItem.gxTpr_Projectid, 0);
               }
               AV53GXV2 = (int)(AV53GXV2+1);
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         AV12SDTProjectCollection.Sort("SmallCaseProjectName");
         AV14Columns.Add("Projects:", 0);
         AV55GXV3 = 1;
         while ( AV55GXV3 <= AV12SDTProjectCollection.Count )
         {
            AV13SDTProject = ((SdtSDTProject)AV12SDTProjectCollection.Item(AV55GXV3));
            AV14Columns.Add(StringUtil.Trim( AV13SDTProject.gxTpr_Projectname), 0);
            AV55GXV3 = (int)(AV55GXV3+1);
         }
         AV14Columns.Add("Total Work Hours", 0);
         if ( AV20ShowLeaveTotal )
         {
            AV14Columns.Add("Total Leave Hours", 0);
            AV14Columns.Add("Total", 0);
         }
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV26excelcellrange = AV23excelSpreadsheet.cell(1, 1);
         AV26excelcellrange.gxTpr_Valuetext = "Project Overview";
         AV31excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV31excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV31excelCellStyle.gxTpr_Font.gxTpr_Size = 14;
         AV31excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV31excelCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV26excelcellrange.setcellstyle( AV31excelCellStyle);
         AV27CellRow = 2;
         AV28FirstColumn = 1;
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV36TotalWorkTime = 0;
         AV37TotalTime = 0;
         AV56GXV4 = 1;
         while ( AV56GXV4 <= AV8SDT_EmployeeProjectMatrixCollection.Count )
         {
            AV34SDT_EmployeeProjectMatrix = ((SdtSDT_EmployeeProjectMatrix)AV8SDT_EmployeeProjectMatrixCollection.Item(AV56GXV4));
            AV27CellRow = (short)(AV27CellRow+1);
            AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, 1);
            AV26excelcellrange.gxTpr_Valuetext = StringUtil.Trim( AV34SDT_EmployeeProjectMatrix.gxTpr_Employeename);
            AV26excelcellrange.setcellstyle( AV10bodyCellStyle);
            AV57GXV5 = 1;
            while ( AV57GXV5 <= AV34SDT_EmployeeProjectMatrix.gxTpr_Projects.Count )
            {
               AV35ProjectHoursItem = ((SdtSDT_EmployeeProjectMatrix_ProjectsItem)AV34SDT_EmployeeProjectMatrix.gxTpr_Projects.Item(AV57GXV5));
               AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV14Columns.IndexOf(StringUtil.Trim( AV35ProjectHoursItem.gxTpr_Projectname)));
               GXt_char2 = "";
               new formattime(context ).execute(  AV35ProjectHoursItem.gxTpr_Projecthours, out  GXt_char2) ;
               AV26excelcellrange.gxTpr_Valuetext = GXt_char2;
               AV26excelcellrange.setcellstyle( AV10bodyCellStyle);
               AV57GXV5 = (int)(AV57GXV5+1);
            }
            AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV14Columns.IndexOf("Total Work Hours"));
            AV26excelcellrange.gxTpr_Valuetext = AV34SDT_EmployeeProjectMatrix.gxTpr_Formattedworkhours;
            AV26excelcellrange.setcellstyle( AV10bodyCellStyle);
            AV36TotalWorkTime = (long)(AV36TotalWorkTime+(AV34SDT_EmployeeProjectMatrix.gxTpr_Workhours));
            AV37TotalTime = (long)(AV37TotalTime+(AV34SDT_EmployeeProjectMatrix.gxTpr_Employeehours));
            if ( AV20ShowLeaveTotal )
            {
               AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV14Columns.IndexOf("Total Leave Hours"));
               AV26excelcellrange.gxTpr_Valuetext = AV34SDT_EmployeeProjectMatrix.gxTpr_Formattedleavehours;
               AV26excelcellrange.setcellstyle( AV10bodyCellStyle);
               AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV14Columns.IndexOf("Total"));
               AV26excelcellrange.gxTpr_Valuetext = AV34SDT_EmployeeProjectMatrix.gxTpr_Formattedemployeehours;
               AV26excelcellrange.setcellstyle( AV10bodyCellStyle);
            }
            AV56GXV4 = (int)(AV56GXV4+1);
         }
         AV27CellRow = (short)(AV27CellRow+1);
         AV24VisibleColumnCount = 0;
         AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV28FirstColumn+AV24VisibleColumnCount);
         AV26excelcellrange.gxTpr_Valuetext = "Total";
         AV26excelcellrange.setcellstyle( AV11footCellStyle);
         AV58GXV6 = 1;
         while ( AV58GXV6 <= AV12SDTProjectCollection.Count )
         {
            AV13SDTProject = ((SdtSDTProject)AV12SDTProjectCollection.Item(AV58GXV6));
            AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV14Columns.IndexOf(StringUtil.Trim( AV13SDTProject.gxTpr_Projectname)));
            AV26excelcellrange.gxTpr_Valuetext = AV13SDTProject.gxTpr_Projectformattedtime;
            AV26excelcellrange.setcellstyle( AV11footCellStyle);
            AV58GXV6 = (int)(AV58GXV6+1);
         }
         AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV14Columns.IndexOf("Total Work Hours"));
         GXt_char2 = "";
         new formattime(context ).execute(  AV36TotalWorkTime, out  GXt_char2) ;
         AV26excelcellrange.gxTpr_Valuetext = GXt_char2;
         AV26excelcellrange.setcellstyle( AV31excelCellStyle);
         if ( AV20ShowLeaveTotal )
         {
            AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV14Columns.IndexOf("Total"));
            GXt_char2 = "";
            new formattime(context ).execute(  AV37TotalTime, out  GXt_char2) ;
            AV26excelcellrange.gxTpr_Valuetext = GXt_char2;
            AV26excelcellrange.setcellstyle( AV31excelCellStyle);
         }
         AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow+2, 1);
         GXt_char2 = "";
         new formatdatetime(context ).execute(  AV15FromDate,  "DD.MM.YYYY", out  GXt_char2) ;
         AV26excelcellrange.gxTpr_Valuetext = "Start Date "+GXt_char2;
         AV26excelcellrange.setcellstyle( AV11footCellStyle);
         AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow+3, 1);
         GXt_char2 = "";
         new formatdatetime(context ).execute(  AV16ToDate,  "DD.MM.YYYY", out  GXt_char2) ;
         AV26excelcellrange.gxTpr_Valuetext = "End Date "+GXt_char2;
         AV26excelcellrange.setcellstyle( AV11footCellStyle);
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
         GXt_char2 = AV21Filename;
         new formatdatetime(context ).execute(  AV15FromDate,  "YYYY-MM-DD", out  GXt_char2) ;
         GXt_char3 = AV21Filename;
         new formatdatetime(context ).execute(  AV16ToDate,  "YYYY-MM-DD", out  GXt_char3) ;
         AV21Filename = "HoursReport-" + GXt_char2 + "_" + GXt_char3 + ".xlsx";
         AV22File.Source = AV21Filename;
         AV22File.Delete();
         AV23excelSpreadsheet.open( AV21Filename);
      }

      protected void S121( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV24VisibleColumnCount = 0;
         AV59GXV7 = 1;
         while ( AV59GXV7 <= AV14Columns.Count )
         {
            AV25Column = ((string)AV14Columns.Item(AV59GXV7));
            AV26excelcellrange = AV23excelSpreadsheet.cell(AV27CellRow, AV28FirstColumn+AV24VisibleColumnCount);
            AV26excelcellrange.gxTpr_Valuetext = AV25Column;
            AV26excelcellrange.setcellstyle( AV9headerCellStyle);
            AV24VisibleColumnCount = (short)(AV24VisibleColumnCount+1);
            AV59GXV7 = (int)(AV59GXV7+1);
         }
      }

      protected void S131( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV23excelSpreadsheet.gxTpr_Autofit = true;
         AV29boolean = AV23excelSpreadsheet.save();
         if ( AV29boolean )
         {
            AV23excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV23excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV23excelSpreadsheet.gxTpr_Errdescription);
         }
         AV30Session.Set("WWPExportFilePath", AV21Filename);
         AV30Session.Set("WWPExportFileName", AV21Filename);
         AV21Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
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
         AV21Filename = "";
         AV41ErrorMessage = "";
         AV9headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV10bodyCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV11footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV42ProjectEmployeeIdCollection = new GxSimpleCollection<long>();
         GXt_objcol_int1 = new GxSimpleCollection<long>();
         AV34SDT_EmployeeProjectMatrix = new SdtSDT_EmployeeProjectMatrix(context);
         AV51ProjectItem = new SdtSDT_EmployeeProjectMatrix_ProjectsItem(context);
         AV50ReturnedProjectIdCollection = new GxSimpleCollection<long>();
         AV13SDTProject = new SdtSDTProject(context);
         A119WorkHourLogDate = DateTime.MinValue;
         P00CD2_A100CompanyId = new long[1] ;
         P00CD2_A106EmployeeId = new long[1] ;
         P00CD2_A157CompanyLocationId = new long[1] ;
         P00CD2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00CD2_A102ProjectId = new long[1] ;
         P00CD2_A121WorkHourLogHour = new short[1] ;
         P00CD2_A122WorkHourLogMinute = new short[1] ;
         P00CD2_A118WorkHourLogId = new long[1] ;
         AV12SDTProjectCollection = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         AV14Columns = new GxSimpleCollection<string>();
         AV26excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV23excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         AV31excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV35ProjectHoursItem = new SdtSDT_EmployeeProjectMatrix_ProjectsItem(context);
         GXt_char2 = "";
         GXt_char3 = "";
         AV22File = new GxFile(context.GetPhysicalPath());
         AV25Column = "";
         AV30Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_exportprojectoverview__default(),
            new Object[][] {
                new Object[] {
               P00CD2_A100CompanyId, P00CD2_A106EmployeeId, P00CD2_A157CompanyLocationId, P00CD2_A119WorkHourLogDate, P00CD2_A102ProjectId, P00CD2_A121WorkHourLogHour, P00CD2_A122WorkHourLogMinute, P00CD2_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short AV27CellRow ;
      private short AV28FirstColumn ;
      private short AV24VisibleColumnCount ;
      private int AV52GXV1 ;
      private int AV53GXV2 ;
      private int AV39CompanyLocationIdCollection_Count ;
      private int AV40EmployeeIdCollection_Count ;
      private int AV42ProjectEmployeeIdCollection_Count ;
      private int AV55GXV3 ;
      private int AV56GXV4 ;
      private int AV57GXV5 ;
      private int AV58GXV6 ;
      private int AV59GXV7 ;
      private long AV51ProjectItem_gxTpr_Projectid ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A100CompanyId ;
      private long A118WorkHourLogId ;
      private long AV36TotalWorkTime ;
      private long AV37TotalTime ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private DateTime AV15FromDate ;
      private DateTime AV16ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool AV20ShowLeaveTotal ;
      private bool returnInSub ;
      private bool AV29boolean ;
      private string AV21Filename ;
      private string AV41ErrorMessage ;
      private string AV25Column ;
      private IGxSession AV30Session ;
      private GxFile AV22File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV40EmployeeIdCollection ;
      private GxSimpleCollection<long> AV38ProjectIdCollection ;
      private GxSimpleCollection<long> AV39CompanyLocationIdCollection ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> AV8SDT_EmployeeProjectMatrixCollection ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV9headerCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV10bodyCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV11footCellStyle ;
      private GxSimpleCollection<long> AV42ProjectEmployeeIdCollection ;
      private GxSimpleCollection<long> GXt_objcol_int1 ;
      private SdtSDT_EmployeeProjectMatrix AV34SDT_EmployeeProjectMatrix ;
      private SdtSDT_EmployeeProjectMatrix_ProjectsItem AV51ProjectItem ;
      private GxSimpleCollection<long> AV50ReturnedProjectIdCollection ;
      private SdtSDTProject AV13SDTProject ;
      private IDataStoreProvider pr_default ;
      private long[] P00CD2_A100CompanyId ;
      private long[] P00CD2_A106EmployeeId ;
      private long[] P00CD2_A157CompanyLocationId ;
      private DateTime[] P00CD2_A119WorkHourLogDate ;
      private long[] P00CD2_A102ProjectId ;
      private short[] P00CD2_A121WorkHourLogHour ;
      private short[] P00CD2_A122WorkHourLogMinute ;
      private long[] P00CD2_A118WorkHourLogId ;
      private GXBaseCollection<SdtSDTProject> AV12SDTProjectCollection ;
      private GxSimpleCollection<string> AV14Columns ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV26excelcellrange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV23excelSpreadsheet ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV31excelCellStyle ;
      private SdtSDT_EmployeeProjectMatrix_ProjectsItem AV35ProjectHoursItem ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
   }

   public class prc_exportprojectoverview__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CD2( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV39CompanyLocationIdCollection ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV40EmployeeIdCollection ,
                                             GxSimpleCollection<long> AV42ProjectEmployeeIdCollection ,
                                             int AV39CompanyLocationIdCollection_Count ,
                                             int AV40EmployeeIdCollection_Count ,
                                             int AV42ProjectEmployeeIdCollection_Count ,
                                             DateTime A119WorkHourLogDate ,
                                             DateTime AV15FromDate ,
                                             DateTime AV16ToDate ,
                                             long A102ProjectId ,
                                             long AV51ProjectItem_gxTpr_Projectid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T1.EmployeeId, T3.CompanyLocationId, T1.WorkHourLogDate, T1.ProjectId, T1.WorkHourLogHour, T1.WorkHourLogMinute, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId)";
         AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV15FromDate and T1.WorkHourLogDate <= :AV16ToDate)");
         AddWhere(sWhereString, "(T1.ProjectId = :AV51ProjectItem__Projectid)");
         if ( AV39CompanyLocationIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV39CompanyLocationIdCollection, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV40EmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV40EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV42ProjectEmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV42ProjectEmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogId";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CD2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (GxSimpleCollection<long>)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CD2;
          prmP00CD2 = new Object[] {
          new ParDef("AV15FromDate",GXType.Date,8,0) ,
          new ParDef("AV16ToDate",GXType.Date,8,0) ,
          new ParDef("AV51ProjectItem__Projectid",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CD2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
