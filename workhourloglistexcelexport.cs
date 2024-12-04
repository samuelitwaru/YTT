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
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourloglistexcelexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           GxSimpleCollection<long> aP3_ProjectIds ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV36ProjectIds = aP3_ProjectIds;
         this.AV12Filename = "" ;
         this.AV17ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP4_Filename=this.AV12Filename;
         aP5_ErrorMessage=this.AV17ErrorMessage;
      }

      public string executeUdp( long aP0_EmployeeId ,
                                DateTime aP1_FromDate ,
                                DateTime aP2_ToDate ,
                                GxSimpleCollection<long> aP3_ProjectIds ,
                                out string aP4_Filename )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, aP3_ProjectIds, out aP4_Filename, out aP5_ErrorMessage);
         return AV17ErrorMessage ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 GxSimpleCollection<long> aP3_ProjectIds ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV36ProjectIds = aP3_ProjectIds;
         this.AV12Filename = "" ;
         this.AV17ErrorMessage = "" ;
         SubmitImpl();
         aP4_Filename=this.AV12Filename;
         aP5_ErrorMessage=this.AV17ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV33headerCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV33headerCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV33headerCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV33headerCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 1;
         AV52footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV52footCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV52footCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV52footCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV21excelcellrange = AV20excelSpreadsheet.cell(1, 1);
         AV21excelcellrange.gxTpr_Valuetext = "Work Hour Log Details";
         AV53excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV53excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV53excelCellStyle.gxTpr_Font.gxTpr_Size = 14;
         AV53excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV53excelCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV21excelcellrange.setcellstyle( AV53excelCellStyle);
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEROWS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow+2, 1);
         GXt_char1 = "";
         new formatdatetime(context ).execute(  AV9FromDate,  "DD.MM.YYYY", out  GXt_char1) ;
         AV21excelcellrange.gxTpr_Valuetext = "Start Date "+GXt_char1;
         AV21excelcellrange.setcellstyle( AV52footCellStyle);
         AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow+3, 1);
         GXt_char1 = "";
         new formatdatetime(context ).execute(  AV10ToDate,  "DD.MM.YYYY", out  GXt_char1) ;
         AV21excelcellrange.gxTpr_Valuetext = "End Date "+GXt_char1;
         AV21excelcellrange.setcellstyle( AV52footCellStyle);
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S141 ();
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
         AV28CellRow = 3;
         AV29FirstColumn = 1;
         AV35Columns.Add("Employee Name", 0);
         AV35Columns.Add("Project Name", 0);
         AV35Columns.Add("Log Date", 0);
         AV35Columns.Add("Log Description", 0);
         AV22VisibleColumnCount = 0;
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV35Columns.Count )
         {
            AV30Column = ((string)AV35Columns.Item(AV54GXV1));
            AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow, AV29FirstColumn+AV22VisibleColumnCount);
            AV21excelcellrange.gxTpr_Valuetext = AV30Column;
            AV21excelcellrange.setcellstyle( AV33headerCellStyle);
            AV22VisibleColumnCount = (short)(AV22VisibleColumnCount+1);
            AV54GXV1 = (int)(AV54GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'WRITEROWS' Routine */
         returnInSub = false;
         AV28CellRow = 4;
         AV55Cellcol = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV36ProjectIds ,
                                              AV36ProjectIds.Count ,
                                              AV46FilterFullText ,
                                              A106EmployeeId ,
                                              AV8EmployeeId ,
                                              AV9FromDate ,
                                              A119WorkHourLogDate ,
                                              AV10ToDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00BH2 */
         pr_default.execute(0, new Object[] {AV9FromDate, AV46FilterFullText, AV8EmployeeId, AV10ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00BH2_A106EmployeeId[0];
            A103ProjectName = P00BH2_A103ProjectName[0];
            A102ProjectId = P00BH2_A102ProjectId[0];
            A119WorkHourLogDate = P00BH2_A119WorkHourLogDate[0];
            A148EmployeeName = P00BH2_A148EmployeeName[0];
            A120WorkHourLogDuration = P00BH2_A120WorkHourLogDuration[0];
            A123WorkHourLogDescription = P00BH2_A123WorkHourLogDescription[0];
            A118WorkHourLogId = P00BH2_A118WorkHourLogId[0];
            A148EmployeeName = P00BH2_A148EmployeeName[0];
            A103ProjectName = P00BH2_A103ProjectName[0];
            AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow, 1);
            AV21excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A148EmployeeName);
            AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow, 2);
            AV21excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A103ProjectName);
            AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow, 3);
            GXt_dtime3 = DateTimeUtil.ResetTime( A119WorkHourLogDate ) ;
            AV21excelcellrange.gxTpr_Valuedate = GXt_dtime3;
            AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow, 4);
            AV21excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A120WorkHourLogDuration);
            AV21excelcellrange = AV20excelSpreadsheet.cell(AV28CellRow, 5);
            AV21excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A123WorkHourLogDescription);
            AV28CellRow = (short)(AV28CellRow+1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S141( )
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

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18Session.Get("WorkHourLogListGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkHourLogListGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV18Session.Get("WorkHourLogListGridState"), null, "", "");
         }
         AV43OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV45OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV57GXV2 = 1;
         while ( AV57GXV2 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV57GXV2));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV38TFEmployeeName = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV47TFEmployeeName_Sel = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV39TFProjectName = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV48TFProjectName_Sel = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV40TFWorkHourLogDate = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Value, 2);
               AV51TFWorkHourLogDate_To = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV41TFWorkHourLogDuration = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV49TFWorkHourLogDuration_Sel = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV42TFWorkHourLogDescription = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV50TFWorkHourLogDescription_Sel = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV57GXV2 = (int)(AV57GXV2+1);
         }
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
         AV17ErrorMessage = "";
         AV33headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV52footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV21excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV20excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         AV53excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         GXt_char1 = "";
         GXt_char2 = "";
         AV19File = new GxFile(context.GetPhysicalPath());
         AV35Columns = new GxSimpleCollection<string>();
         AV30Column = "";
         AV46FilterFullText = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00BH2_A106EmployeeId = new long[1] ;
         P00BH2_A103ProjectName = new string[] {""} ;
         P00BH2_A102ProjectId = new long[1] ;
         P00BH2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00BH2_A148EmployeeName = new string[] {""} ;
         P00BH2_A120WorkHourLogDuration = new string[] {""} ;
         P00BH2_A123WorkHourLogDescription = new string[] {""} ;
         P00BH2_A118WorkHourLogId = new long[1] ;
         A103ProjectName = "";
         A148EmployeeName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV18Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38TFEmployeeName = "";
         AV39TFProjectName = "";
         AV40TFWorkHourLogDate = DateTime.MinValue;
         AV41TFWorkHourLogDuration = "";
         AV42TFWorkHourLogDescription = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourloglistexcelexport__default(),
            new Object[][] {
                new Object[] {
               P00BH2_A106EmployeeId, P00BH2_A103ProjectName, P00BH2_A102ProjectId, P00BH2_A119WorkHourLogDate, P00BH2_A148EmployeeName, P00BH2_A120WorkHourLogDuration, P00BH2_A123WorkHourLogDescription, P00BH2_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28CellRow ;
      private short AV29FirstColumn ;
      private short AV22VisibleColumnCount ;
      private short AV55Cellcol ;
      private short AV43OrderedBy ;
      private short AV47TFEmployeeName_Sel ;
      private short AV48TFProjectName_Sel ;
      private short AV51TFWorkHourLogDate_To ;
      private short AV49TFWorkHourLogDuration_Sel ;
      private short AV50TFWorkHourLogDescription_Sel ;
      private int AV54GXV1 ;
      private int AV36ProjectIds_Count ;
      private int AV57GXV2 ;
      private long AV8EmployeeId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string AV12Filename ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private string A103ProjectName ;
      private string A148EmployeeName ;
      private string AV38TFEmployeeName ;
      private string AV39TFProjectName ;
      private DateTime GXt_dtime3 ;
      private DateTime AV9FromDate ;
      private DateTime AV10ToDate ;
      private DateTime A119WorkHourLogDate ;
      private DateTime AV40TFWorkHourLogDate ;
      private bool returnInSub ;
      private bool AV25boolean ;
      private bool AV45OrderedDsc ;
      private string A123WorkHourLogDescription ;
      private string AV42TFWorkHourLogDescription ;
      private string AV17ErrorMessage ;
      private string AV30Column ;
      private string AV46FilterFullText ;
      private string A120WorkHourLogDuration ;
      private string AV41TFWorkHourLogDuration ;
      private IGxSession AV18Session ;
      private GxFile AV19File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV36ProjectIds ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV33headerCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV52footCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV21excelcellrange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV20excelSpreadsheet ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV53excelCellStyle ;
      private GxSimpleCollection<string> AV35Columns ;
      private IDataStoreProvider pr_default ;
      private long[] P00BH2_A106EmployeeId ;
      private string[] P00BH2_A103ProjectName ;
      private long[] P00BH2_A102ProjectId ;
      private DateTime[] P00BH2_A119WorkHourLogDate ;
      private string[] P00BH2_A148EmployeeName ;
      private string[] P00BH2_A120WorkHourLogDuration ;
      private string[] P00BH2_A123WorkHourLogDescription ;
      private long[] P00BH2_A118WorkHourLogId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
   }

   public class workhourloglistexcelexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BH2( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV36ProjectIds ,
                                             int AV36ProjectIds_Count ,
                                             string AV46FilterFullText ,
                                             long A106EmployeeId ,
                                             long AV8EmployeeId ,
                                             DateTime AV9FromDate ,
                                             DateTime A119WorkHourLogDate ,
                                             DateTime AV10ToDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T3.ProjectName, T1.ProjectId, T1.WorkHourLogDate, T2.EmployeeName, T1.WorkHourLogDuration, T1.WorkHourLogDescription, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV9FromDate)");
         AddWhere(sWhereString, "(POSITION(RTRIM(LOWER(:AV46FilterFullText)) IN LOWER(T3.ProjectName)) >= 1)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV8EmployeeId)");
         AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV10ToDate)");
         if ( AV36ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV36ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDate, T3.ProjectName";
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
                     return conditional_P00BH2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
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
          Object[] prmP00BH2;
          prmP00BH2 = new Object[] {
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV46FilterFullText",GXType.VarChar,40,0) ,
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV10ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
