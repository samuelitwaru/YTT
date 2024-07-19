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
   public class employeehoursreport : GXProcedure
   {
      public employeehoursreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeehoursreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate ,
                           ref GxSimpleCollection<long> aP2_ProjectId ,
                           ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP4_EmployeeId ,
                           out string aP5_Filename ,
                           out string aP6_ErrorMessage )
      {
         this.AV10FromDate = aP0_FromDate;
         this.AV11ToDate = aP1_ToDate;
         this.AV17ProjectId = aP2_ProjectId;
         this.AV13CompanyLocationId = aP3_CompanyLocationId;
         this.AV14EmployeeId = aP4_EmployeeId;
         this.AV28Filename = "" ;
         this.AV27ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV10FromDate;
         aP1_ToDate=this.AV11ToDate;
         aP2_ProjectId=this.AV17ProjectId;
         aP3_CompanyLocationId=this.AV13CompanyLocationId;
         aP4_EmployeeId=this.AV14EmployeeId;
         aP5_Filename=this.AV28Filename;
         aP6_ErrorMessage=this.AV27ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FromDate ,
                                ref DateTime aP1_ToDate ,
                                ref GxSimpleCollection<long> aP2_ProjectId ,
                                ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP4_EmployeeId ,
                                out string aP5_Filename )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, ref aP2_ProjectId, ref aP3_CompanyLocationId, ref aP4_EmployeeId, out aP5_Filename, out aP6_ErrorMessage);
         return AV27ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 ref GxSimpleCollection<long> aP2_ProjectId ,
                                 ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP4_EmployeeId ,
                                 out string aP5_Filename ,
                                 out string aP6_ErrorMessage )
      {
         employeehoursreport objemployeehoursreport;
         objemployeehoursreport = new employeehoursreport();
         objemployeehoursreport.AV10FromDate = aP0_FromDate;
         objemployeehoursreport.AV11ToDate = aP1_ToDate;
         objemployeehoursreport.AV17ProjectId = aP2_ProjectId;
         objemployeehoursreport.AV13CompanyLocationId = aP3_CompanyLocationId;
         objemployeehoursreport.AV14EmployeeId = aP4_EmployeeId;
         objemployeehoursreport.AV28Filename = "" ;
         objemployeehoursreport.AV27ErrorMessage = "" ;
         objemployeehoursreport.context.SetSubmitInitialConfig(context);
         objemployeehoursreport.initialize();
         Submit( executePrivateCatch,objemployeehoursreport);
         aP0_FromDate=this.AV10FromDate;
         aP1_ToDate=this.AV11ToDate;
         aP2_ProjectId=this.AV17ProjectId;
         aP3_CompanyLocationId=this.AV13CompanyLocationId;
         aP4_EmployeeId=this.AV14EmployeeId;
         aP5_Filename=this.AV28Filename;
         aP6_ErrorMessage=this.AV27ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((employeehoursreport)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'GETSESSIONVARIABLES' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV31headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV31headerCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV31headerCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV31headerCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV32leftAlign = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV32leftAlign.gxTpr_Alignment.gxTpr_Horizontal = 1;
         AV34footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV34footCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV34footCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV34footCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 1;
         /* Using cursor P00AZ2 */
         pr_default.execute(0, new Object[] {AV8OneProjectId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A102ProjectId = P00AZ2_A102ProjectId[0];
            A103ProjectName = P00AZ2_A103ProjectName[0];
            AV20excelcellrange = AV12excelSpreadsheet.cell(1, 1);
            AV20excelcellrange.gxTpr_Valuetext = "Timeline Report ("+StringUtil.Trim( A103ProjectName)+")";
            AV21excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
            AV21excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
            AV21excelCellStyle.gxTpr_Font.gxTpr_Size = 14;
            AV21excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
            AV20excelcellrange.setcellstyle( AV21excelCellStyle);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFOOT' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S151 ();
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
         GXt_char1 = AV28Filename;
         new formatdatetime(context ).execute(  AV10FromDate,  "YYYY-MM-DD", out  GXt_char1) ;
         GXt_char2 = AV28Filename;
         new formatdatetime(context ).execute(  AV11ToDate,  "YYYY-MM-DD", out  GXt_char2) ;
         AV28Filename = "HoursReport-" + GXt_char1 + "_" + GXt_char2 + ".xlsx";
         AV33File.Source = AV28Filename;
         AV33File.Delete();
         AV12excelSpreadsheet.open( AV28Filename);
      }

      protected void S121( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV24CellRow = 2;
         AV25FirstColumn = 1;
         AV22Columns.Add("Date", 0);
         AV22Columns.Add("Employee Name", 0);
         AV22Columns.Add("Project", 0);
         AV22Columns.Add("Duration", 0);
         AV22Columns.Add("Description", 0);
         AV29VisibleColumnCount = 0;
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV22Columns.Count )
         {
            AV23Column = AV22Columns.GetString(AV36GXV1);
            AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, AV25FirstColumn+AV29VisibleColumnCount);
            AV20excelcellrange.setcellstyle( AV31headerCellStyle);
            AV20excelcellrange.gxTpr_Valuetext = AV23Column;
            AV29VisibleColumnCount = (short)(AV29VisibleColumnCount+1);
            AV36GXV1 = (int)(AV36GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV24CellRow = (short)(AV24CellRow+2);
         AV25FirstColumn = 1;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV13CompanyLocationId ,
                                              A106EmployeeId ,
                                              AV14EmployeeId ,
                                              AV8OneProjectId ,
                                              AV13CompanyLocationId.Count ,
                                              AV14EmployeeId.Count ,
                                              AV10FromDate ,
                                              AV11ToDate ,
                                              A102ProjectId ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AZ3 */
         pr_default.execute(1, new Object[] {AV8OneProjectId, AV10FromDate, AV11ToDate});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAZ3 = false;
            A100CompanyId = P00AZ3_A100CompanyId[0];
            A148EmployeeName = P00AZ3_A148EmployeeName[0];
            A103ProjectName = P00AZ3_A103ProjectName[0];
            A120WorkHourLogDuration = P00AZ3_A120WorkHourLogDuration[0];
            A123WorkHourLogDescription = P00AZ3_A123WorkHourLogDescription[0];
            A122WorkHourLogMinute = P00AZ3_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00AZ3_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P00AZ3_A119WorkHourLogDate[0];
            A106EmployeeId = P00AZ3_A106EmployeeId[0];
            A157CompanyLocationId = P00AZ3_A157CompanyLocationId[0];
            A102ProjectId = P00AZ3_A102ProjectId[0];
            A118WorkHourLogId = P00AZ3_A118WorkHourLogId[0];
            A100CompanyId = P00AZ3_A100CompanyId[0];
            A148EmployeeName = P00AZ3_A148EmployeeName[0];
            A157CompanyLocationId = P00AZ3_A157CompanyLocationId[0];
            A103ProjectName = P00AZ3_A103ProjectName[0];
            AV15TotalWorkTime = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AZ3_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRKAZ3 = false;
               A103ProjectName = P00AZ3_A103ProjectName[0];
               A120WorkHourLogDuration = P00AZ3_A120WorkHourLogDuration[0];
               A123WorkHourLogDescription = P00AZ3_A123WorkHourLogDescription[0];
               A122WorkHourLogMinute = P00AZ3_A122WorkHourLogMinute[0];
               A121WorkHourLogHour = P00AZ3_A121WorkHourLogHour[0];
               A119WorkHourLogDate = P00AZ3_A119WorkHourLogDate[0];
               A106EmployeeId = P00AZ3_A106EmployeeId[0];
               A102ProjectId = P00AZ3_A102ProjectId[0];
               A118WorkHourLogId = P00AZ3_A118WorkHourLogId[0];
               A103ProjectName = P00AZ3_A103ProjectName[0];
               AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, AV25FirstColumn+0);
               AV20excelcellrange.setcellstyle( AV32leftAlign);
               GXt_dtime3 = DateTimeUtil.ResetTime( A119WorkHourLogDate ) ;
               AV20excelcellrange.gxTpr_Valuedate = GXt_dtime3;
               AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, AV25FirstColumn+1);
               AV20excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A148EmployeeName);
               AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, AV25FirstColumn+2);
               AV20excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A103ProjectName);
               AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, AV25FirstColumn+3);
               AV20excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A120WorkHourLogDuration);
               AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, AV25FirstColumn+4);
               AV20excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A123WorkHourLogDescription);
               AV15TotalWorkTime = (decimal)(AV15TotalWorkTime+((A121WorkHourLogHour*60)+A122WorkHourLogMinute));
               AV24CellRow = (short)(AV24CellRow+1);
               BRKAZ3 = true;
               pr_default.readNext(1);
            }
            AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, AV25FirstColumn);
            AV20excelcellrange.gxTpr_Valuetext = "Total";
            AV21excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
            AV21excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
            AV21excelCellStyle.gxTpr_Font.gxTpr_Size = 13;
            AV20excelcellrange.setcellstyle( AV21excelCellStyle);
            AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, AV25FirstColumn+1);
            GXt_char2 = "";
            new procformattime(context ).execute(  (long)(Math.Round(AV15TotalWorkTime, 18, MidpointRounding.ToEven)), out  GXt_char2) ;
            AV20excelcellrange.gxTpr_Valuetext = GXt_char2;
            AV20excelcellrange.setcellstyle( AV21excelCellStyle);
            AV24CellRow = (short)(AV24CellRow+2);
            if ( ! BRKAZ3 )
            {
               BRKAZ3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'WRITEFOOT' Routine */
         returnInSub = false;
         /* Using cursor P00AZ5 */
         pr_default.execute(2, new Object[] {AV10FromDate, AV11ToDate, AV8OneProjectId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = P00AZ5_A40000GXC1[0];
            n40000GXC1 = P00AZ5_n40000GXC1[0];
            A40001GXC2 = P00AZ5_A40001GXC2[0];
            n40001GXC2 = P00AZ5_n40001GXC2[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            A40001GXC2 = 0;
            n40001GXC2 = false;
         }
         pr_default.close(2);
         AV24CellRow = (short)(AV24CellRow+1);
         AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, 1);
         AV20excelcellrange.gxTpr_Valuetext = "Start Date";
         AV20excelcellrange.setcellstyle( AV34footCellStyle);
         AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, 2);
         AV20excelcellrange.setcellstyle( AV34footCellStyle);
         GXt_dtime3 = DateTimeUtil.ResetTime( AV10FromDate ) ;
         AV20excelcellrange.gxTpr_Valuedate = GXt_dtime3;
         AV24CellRow = (short)(AV24CellRow+1);
         AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, 1);
         AV20excelcellrange.gxTpr_Valuetext = "End Date";
         AV20excelcellrange.setcellstyle( AV34footCellStyle);
         AV20excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, 2);
         AV20excelcellrange.setcellstyle( AV34footCellStyle);
         GXt_dtime3 = DateTimeUtil.ResetTime( AV11ToDate ) ;
         AV20excelcellrange.gxTpr_Valuedate = GXt_dtime3;
         AV24CellRow = (short)(AV24CellRow+1);
         AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, 1);
         AV20excelcellrange.gxTpr_Valuetext = "Hours Total";
         AV20excelcellrange.setcellstyle( AV34footCellStyle);
         AV26TotalMinutes = (int)(A40000GXC1*60+A40001GXC2);
         AV20excelcellrange = AV12excelSpreadsheet.cell(AV24CellRow, 2);
         GXt_char2 = "";
         new procformattime(context ).execute(  AV26TotalMinutes, out  GXt_char2) ;
         AV20excelcellrange.gxTpr_Valuetext = GXt_char2;
         AV20excelcellrange.setcellstyle( AV34footCellStyle);
      }

      protected void S151( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV12excelSpreadsheet.gxTpr_Autofit = true;
         AV19boolean = AV12excelSpreadsheet.save();
         if ( AV19boolean )
         {
            AV12excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV12excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV12excelSpreadsheet.gxTpr_Errdescription);
         }
         AV18Session.Set("WWPExportFilePath", AV28Filename);
         AV18Session.Set("WWPExportFileName", AV28Filename);
         AV28Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S161( )
      {
         /* 'GETSESSIONVARIABLES' Routine */
         returnInSub = false;
         AV13CompanyLocationId.FromJSonString(AV16WebSession.Get("CompanyLocationId"), null);
         AV14EmployeeId.FromJSonString(AV16WebSession.Get("EmployeeId"), null);
         AV17ProjectId.FromJSonString(AV16WebSession.Get("ProjectId"), null);
         AV8OneProjectId = (long)(Math.Round(NumberUtil.Val( AV16WebSession.Get("OneProjectId"), "."), 18, MidpointRounding.ToEven));
         AV10FromDate = context.localUtil.CToD( AV16WebSession.Get("FromDate"), 2);
         AV11ToDate = context.localUtil.CToD( AV16WebSession.Get("ToDate"), 2);
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
         AV28Filename = "";
         AV27ErrorMessage = "";
         AV31headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV32leftAlign = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV34footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         scmdbuf = "";
         P00AZ2_A102ProjectId = new long[1] ;
         P00AZ2_A103ProjectName = new string[] {""} ;
         A103ProjectName = "";
         AV20excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV12excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         AV21excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         GXt_char1 = "";
         AV33File = new GxFile(context.GetPhysicalPath());
         AV22Columns = new GxSimpleCollection<string>();
         AV23Column = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00AZ3_A100CompanyId = new long[1] ;
         P00AZ3_A148EmployeeName = new string[] {""} ;
         P00AZ3_A103ProjectName = new string[] {""} ;
         P00AZ3_A120WorkHourLogDuration = new string[] {""} ;
         P00AZ3_A123WorkHourLogDescription = new string[] {""} ;
         P00AZ3_A122WorkHourLogMinute = new short[1] ;
         P00AZ3_A121WorkHourLogHour = new short[1] ;
         P00AZ3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AZ3_A106EmployeeId = new long[1] ;
         P00AZ3_A157CompanyLocationId = new long[1] ;
         P00AZ3_A102ProjectId = new long[1] ;
         P00AZ3_A118WorkHourLogId = new long[1] ;
         A148EmployeeName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         P00AZ5_A40000GXC1 = new short[1] ;
         P00AZ5_n40000GXC1 = new bool[] {false} ;
         P00AZ5_A40001GXC2 = new short[1] ;
         P00AZ5_n40001GXC2 = new bool[] {false} ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_char2 = "";
         AV18Session = context.GetSession();
         AV16WebSession = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeehoursreport__default(),
            new Object[][] {
                new Object[] {
               P00AZ2_A102ProjectId, P00AZ2_A103ProjectName
               }
               , new Object[] {
               P00AZ3_A100CompanyId, P00AZ3_A148EmployeeName, P00AZ3_A103ProjectName, P00AZ3_A120WorkHourLogDuration, P00AZ3_A123WorkHourLogDescription, P00AZ3_A122WorkHourLogMinute, P00AZ3_A121WorkHourLogHour, P00AZ3_A119WorkHourLogDate, P00AZ3_A106EmployeeId, P00AZ3_A157CompanyLocationId,
               P00AZ3_A102ProjectId, P00AZ3_A118WorkHourLogId
               }
               , new Object[] {
               P00AZ5_A40000GXC1, P00AZ5_n40000GXC1, P00AZ5_A40001GXC2, P00AZ5_n40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24CellRow ;
      private short AV25FirstColumn ;
      private short AV29VisibleColumnCount ;
      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private int AV36GXV1 ;
      private int AV13CompanyLocationId_Count ;
      private int AV14EmployeeId_Count ;
      private int AV26TotalMinutes ;
      private long AV8OneProjectId ;
      private long A102ProjectId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A118WorkHourLogId ;
      private decimal AV15TotalWorkTime ;
      private string scmdbuf ;
      private string A103ProjectName ;
      private string GXt_char1 ;
      private string AV23Column ;
      private string A148EmployeeName ;
      private string GXt_char2 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool BRKAZ3 ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool AV19boolean ;
      private string A123WorkHourLogDescription ;
      private string AV28Filename ;
      private string AV27ErrorMessage ;
      private string A120WorkHourLogDuration ;
      private GxSimpleCollection<long> AV17ProjectId ;
      private GxSimpleCollection<long> AV13CompanyLocationId ;
      private GxSimpleCollection<long> AV14EmployeeId ;
      private IGxSession AV16WebSession ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV12excelSpreadsheet ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> aP2_ProjectId ;
      private GxSimpleCollection<long> aP3_CompanyLocationId ;
      private GxSimpleCollection<long> aP4_EmployeeId ;
      private IDataStoreProvider pr_default ;
      private long[] P00AZ2_A102ProjectId ;
      private string[] P00AZ2_A103ProjectName ;
      private long[] P00AZ3_A100CompanyId ;
      private string[] P00AZ3_A148EmployeeName ;
      private string[] P00AZ3_A103ProjectName ;
      private string[] P00AZ3_A120WorkHourLogDuration ;
      private string[] P00AZ3_A123WorkHourLogDescription ;
      private short[] P00AZ3_A122WorkHourLogMinute ;
      private short[] P00AZ3_A121WorkHourLogHour ;
      private DateTime[] P00AZ3_A119WorkHourLogDate ;
      private long[] P00AZ3_A106EmployeeId ;
      private long[] P00AZ3_A157CompanyLocationId ;
      private long[] P00AZ3_A102ProjectId ;
      private long[] P00AZ3_A118WorkHourLogId ;
      private short[] P00AZ5_A40000GXC1 ;
      private bool[] P00AZ5_n40000GXC1 ;
      private short[] P00AZ5_A40001GXC2 ;
      private bool[] P00AZ5_n40001GXC2 ;
      private string aP5_Filename ;
      private string aP6_ErrorMessage ;
      private IGxSession AV18Session ;
      private GxSimpleCollection<string> AV22Columns ;
      private GxFile AV33File ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV20excelcellrange ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV31headerCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV32leftAlign ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV34footCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV21excelCellStyle ;
   }

   public class employeehoursreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AZ3( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV13CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV14EmployeeId ,
                                             long AV8OneProjectId ,
                                             int AV13CompanyLocationId_Count ,
                                             int AV14EmployeeId_Count ,
                                             DateTime AV10FromDate ,
                                             DateTime AV11ToDate ,
                                             long A102ProjectId ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T2.EmployeeName, T4.ProjectName, T1.WorkHourLogDuration, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T1.EmployeeId, T3.CompanyLocationId, T1.ProjectId, T1.WorkHourLogId FROM (((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Project T4 ON T4.ProjectId = T1.ProjectId)";
         if ( ! (0==AV8OneProjectId) )
         {
            AddWhere(sWhereString, "(T1.ProjectId = :AV8OneProjectId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( AV13CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13CompanyLocationId, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV14EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV14EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV10FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV10FromDate)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV11ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV11ToDate)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeName, T1.WorkHourLogDate";
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
               case 1 :
                     return conditional_P00AZ3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (DateTime)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AZ2;
          prmP00AZ2 = new Object[] {
          new ParDef("AV8OneProjectId",GXType.Int64,10,0)
          };
          Object[] prmP00AZ5;
          prmP00AZ5 = new Object[] {
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV8OneProjectId",GXType.Int64,10,0)
          };
          Object[] prmP00AZ3;
          prmP00AZ3 = new Object[] {
          new ParDef("AV8OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AZ2", "SELECT ProjectId, ProjectName FROM Project WHERE ProjectId = :AV8OneProjectId ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00AZ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AZ5", "SELECT COALESCE( T1.GXC1, 0) AS GXC1, COALESCE( T1.GXC2, 0) AS GXC2 FROM (SELECT SUM(WorkHourLogHour) AS GXC1, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (WorkHourLogDate >= :AV10FromDate) AND (WorkHourLogDate <= :AV11ToDate) AND (ProjectId = :AV8OneProjectId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ5,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
