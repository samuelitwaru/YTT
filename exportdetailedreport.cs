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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportdetailedreport : GXProcedure
   {
      public exportdetailedreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public exportdetailedreport( IGxContext context )
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
         this.AV65FromDate = aP0_FromDate;
         this.AV66ToDate = aP1_ToDate;
         this.AV44ProjectId = aP2_ProjectId;
         this.AV46CompanyLocationId = aP3_CompanyLocationId;
         this.AV24EmployeeId = aP4_EmployeeId;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV65FromDate;
         aP1_ToDate=this.AV66ToDate;
         aP2_ProjectId=this.AV44ProjectId;
         aP3_CompanyLocationId=this.AV46CompanyLocationId;
         aP4_EmployeeId=this.AV24EmployeeId;
         aP5_Filename=this.AV12Filename;
         aP6_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FromDate ,
                                ref DateTime aP1_ToDate ,
                                ref GxSimpleCollection<long> aP2_ProjectId ,
                                ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP4_EmployeeId ,
                                out string aP5_Filename )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, ref aP2_ProjectId, ref aP3_CompanyLocationId, ref aP4_EmployeeId, out aP5_Filename, out aP6_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 ref GxSimpleCollection<long> aP2_ProjectId ,
                                 ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP4_EmployeeId ,
                                 out string aP5_Filename ,
                                 out string aP6_ErrorMessage )
      {
         exportdetailedreport objexportdetailedreport;
         objexportdetailedreport = new exportdetailedreport();
         objexportdetailedreport.AV65FromDate = aP0_FromDate;
         objexportdetailedreport.AV66ToDate = aP1_ToDate;
         objexportdetailedreport.AV44ProjectId = aP2_ProjectId;
         objexportdetailedreport.AV46CompanyLocationId = aP3_CompanyLocationId;
         objexportdetailedreport.AV24EmployeeId = aP4_EmployeeId;
         objexportdetailedreport.AV12Filename = "" ;
         objexportdetailedreport.AV13ErrorMessage = "" ;
         objexportdetailedreport.context.SetSubmitInitialConfig(context);
         objexportdetailedreport.initialize();
         Submit( executePrivateCatch,objexportdetailedreport);
         aP0_FromDate=this.AV65FromDate;
         aP1_ToDate=this.AV66ToDate;
         aP2_ProjectId=this.AV44ProjectId;
         aP3_CompanyLocationId=this.AV46CompanyLocationId;
         aP4_EmployeeId=this.AV24EmployeeId;
         aP5_Filename=this.AV12Filename;
         aP6_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportdetailedreport)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'GETSESSIONVARIABLES' */
         S171 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Using cursor P009O2 */
         pr_default.execute(0, new Object[] {AV73OneProjectId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A102ProjectId = P009O2_A102ProjectId[0];
            A103ProjectName = P009O2_A103ProjectName[0];
            AV11ExcelDocument.get_Cells(1, 1, 1, 1).Text = "Timeline Report ("+StringUtil.Trim( A103ProjectName)+")";
            AV11ExcelDocument.get_Cells(1, 1, 1, 1).Bold = 1;
            AV11ExcelDocument.get_Cells(1, 1, 1, 1).Color = 11;
            AV11ExcelDocument.get_Cells(1, 1, 1, 1).Size = 14;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFOOT' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S161 ();
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
         new formatdatetime(context ).execute(  AV65FromDate,  "YYYY-MM-DD", out  GXt_char1) ;
         GXt_char2 = AV12Filename;
         new formatdatetime(context ).execute(  AV66ToDate,  "YYYY-MM-DD", out  GXt_char2) ;
         AV12Filename = "HoursReport-" + GXt_char1 + "_" + GXt_char2 + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV14CellRow = 2;
         AV15FirstColumn = 1;
         AV48Columns.Add("Date", 0);
         AV48Columns.Add("Employee Name", 0);
         AV48Columns.Add("Project", 0);
         AV48Columns.Add("Duration", 0);
         AV48Columns.Add("Description", 0);
         AV38VisibleColumnCount = 0;
         AV77GXV1 = 1;
         while ( AV77GXV1 <= AV48Columns.Count )
         {
            AV47Column = ((string)AV48Columns.Item(AV77GXV1));
            AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Text = AV47Column;
            AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Bold = 1;
            AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Color = 11;
            AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Color = 13;
            AV38VisibleColumnCount = (long)(AV38VisibleColumnCount+1);
            AV77GXV1 = (int)(AV77GXV1+1);
         }
      }

      protected void S141( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV14CellRow = (int)(AV14CellRow+2);
         AV15FirstColumn = 1;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV46CompanyLocationId ,
                                              A106EmployeeId ,
                                              AV24EmployeeId ,
                                              AV73OneProjectId ,
                                              AV46CompanyLocationId.Count ,
                                              AV24EmployeeId.Count ,
                                              AV65FromDate ,
                                              AV66ToDate ,
                                              A102ProjectId ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         /* Using cursor P009O3 */
         pr_default.execute(1, new Object[] {AV73OneProjectId, AV65FromDate, AV66ToDate});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK9O3 = false;
            A100CompanyId = P009O3_A100CompanyId[0];
            A148EmployeeName = P009O3_A148EmployeeName[0];
            A103ProjectName = P009O3_A103ProjectName[0];
            A120WorkHourLogDuration = P009O3_A120WorkHourLogDuration[0];
            A123WorkHourLogDescription = P009O3_A123WorkHourLogDescription[0];
            A122WorkHourLogMinute = P009O3_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P009O3_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P009O3_A119WorkHourLogDate[0];
            A106EmployeeId = P009O3_A106EmployeeId[0];
            A157CompanyLocationId = P009O3_A157CompanyLocationId[0];
            A102ProjectId = P009O3_A102ProjectId[0];
            A118WorkHourLogId = P009O3_A118WorkHourLogId[0];
            A100CompanyId = P009O3_A100CompanyId[0];
            A148EmployeeName = P009O3_A148EmployeeName[0];
            A157CompanyLocationId = P009O3_A157CompanyLocationId[0];
            A103ProjectName = P009O3_A103ProjectName[0];
            AV67TotalWorkTime = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P009O3_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK9O3 = false;
               A103ProjectName = P009O3_A103ProjectName[0];
               A120WorkHourLogDuration = P009O3_A120WorkHourLogDuration[0];
               A123WorkHourLogDescription = P009O3_A123WorkHourLogDescription[0];
               A122WorkHourLogMinute = P009O3_A122WorkHourLogMinute[0];
               A121WorkHourLogHour = P009O3_A121WorkHourLogHour[0];
               A119WorkHourLogDate = P009O3_A119WorkHourLogDate[0];
               A106EmployeeId = P009O3_A106EmployeeId[0];
               A102ProjectId = P009O3_A102ProjectId[0];
               A118WorkHourLogId = P009O3_A118WorkHourLogId[0];
               A103ProjectName = P009O3_A103ProjectName[0];
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = context.localUtil.DToC( A119WorkHourLogDate, 1, "/");
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( A148EmployeeName);
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( A103ProjectName);
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( A120WorkHourLogDuration);
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( A123WorkHourLogDescription);
               AV67TotalWorkTime = (long)(AV67TotalWorkTime+((A121WorkHourLogHour*60)+A122WorkHourLogMinute));
               AV14CellRow = (int)(AV14CellRow+1);
               BRK9O3 = true;
               pr_default.readNext(1);
            }
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Total";
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Size = 13;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
            GXt_char2 = "";
            new procformattime(context ).execute(  AV67TotalWorkTime, out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Size = 13;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
            AV14CellRow = (int)(AV14CellRow+2);
            if ( ! BRK9O3 )
            {
               BRK9O3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         AV11ExcelDocument.AutoFit = 1;
      }

      protected void S151( )
      {
         /* 'WRITEFOOT' Routine */
         returnInSub = false;
         /* Using cursor P009O5 */
         pr_default.execute(2, new Object[] {AV65FromDate, AV66ToDate, AV73OneProjectId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = P009O5_A40000GXC1[0];
            n40000GXC1 = P009O5_n40000GXC1[0];
            A40001GXC2 = P009O5_A40001GXC2[0];
            n40001GXC2 = P009O5_n40001GXC2[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            A40001GXC2 = 0;
            n40001GXC2 = false;
         }
         pr_default.close(2);
         AV14CellRow = (int)(AV14CellRow+1);
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Text = "Start Date";
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Size = 13;
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Text = context.localUtil.DToC( AV65FromDate, 1, "/");
         AV11ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Size = 13;
         AV14CellRow = (int)(AV14CellRow+1);
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Text = "End Date";
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Size = 13;
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Text = context.localUtil.DToC( AV66ToDate, 1, "/");
         AV11ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Size = 13;
         AV14CellRow = (int)(AV14CellRow+1);
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Text = "Hours Total";
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Size = 13;
         AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Bold = 1;
         AV74TotalMinutes = (long)(A40000GXC1*60+A40001GXC2);
         GXt_char2 = "";
         new procformattime(context ).execute(  AV74TotalMinutes, out  GXt_char2) ;
         AV11ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Text = GXt_char2;
         AV11ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Bold = 1;
      }

      protected void S161( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.AutoFit = 1;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV25Session.Set("WWPExportFilePath", AV12Filename);
         AV25Session.Set("WWPExportFileName", AV12Filename);
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S171( )
      {
         /* 'GETSESSIONVARIABLES' Routine */
         returnInSub = false;
         AV46CompanyLocationId.FromJSonString(AV69WebSession.Get("CompanyLocationId"), null);
         AV24EmployeeId.FromJSonString(AV69WebSession.Get("EmployeeId"), null);
         AV44ProjectId.FromJSonString(AV69WebSession.Get("ProjectId"), null);
         AV73OneProjectId = (long)(Math.Round(NumberUtil.Val( AV69WebSession.Get("OneProjectId"), "."), 18, MidpointRounding.ToEven));
         AV65FromDate = context.localUtil.CToD( AV69WebSession.Get("FromDate"), 1);
         AV66ToDate = context.localUtil.CToD( AV69WebSession.Get("ToDate"), 1);
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
         AV13ErrorMessage = "";
         scmdbuf = "";
         P009O2_A102ProjectId = new long[1] ;
         P009O2_A103ProjectName = new string[] {""} ;
         A103ProjectName = "";
         AV11ExcelDocument = new ExcelDocumentI();
         GXt_char1 = "";
         AV48Columns = new GxSimpleCollection<string>();
         AV47Column = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P009O3_A100CompanyId = new long[1] ;
         P009O3_A148EmployeeName = new string[] {""} ;
         P009O3_A103ProjectName = new string[] {""} ;
         P009O3_A120WorkHourLogDuration = new string[] {""} ;
         P009O3_A123WorkHourLogDescription = new string[] {""} ;
         P009O3_A122WorkHourLogMinute = new short[1] ;
         P009O3_A121WorkHourLogHour = new short[1] ;
         P009O3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P009O3_A106EmployeeId = new long[1] ;
         P009O3_A157CompanyLocationId = new long[1] ;
         P009O3_A102ProjectId = new long[1] ;
         P009O3_A118WorkHourLogId = new long[1] ;
         A148EmployeeName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         P009O5_A40000GXC1 = new short[1] ;
         P009O5_n40000GXC1 = new bool[] {false} ;
         P009O5_A40001GXC2 = new short[1] ;
         P009O5_n40001GXC2 = new bool[] {false} ;
         GXt_char2 = "";
         AV25Session = context.GetSession();
         AV69WebSession = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportdetailedreport__default(),
            new Object[][] {
                new Object[] {
               P009O2_A102ProjectId, P009O2_A103ProjectName
               }
               , new Object[] {
               P009O3_A100CompanyId, P009O3_A148EmployeeName, P009O3_A103ProjectName, P009O3_A120WorkHourLogDuration, P009O3_A123WorkHourLogDescription, P009O3_A122WorkHourLogMinute, P009O3_A121WorkHourLogHour, P009O3_A119WorkHourLogDate, P009O3_A106EmployeeId, P009O3_A157CompanyLocationId,
               P009O3_A102ProjectId, P009O3_A118WorkHourLogId
               }
               , new Object[] {
               P009O5_A40000GXC1, P009O5_n40000GXC1, P009O5_A40001GXC2, P009O5_n40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV77GXV1 ;
      private int AV46CompanyLocationId_Count ;
      private int AV24EmployeeId_Count ;
      private long AV73OneProjectId ;
      private long A102ProjectId ;
      private long AV38VisibleColumnCount ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A118WorkHourLogId ;
      private long AV67TotalWorkTime ;
      private long AV74TotalMinutes ;
      private string scmdbuf ;
      private string A103ProjectName ;
      private string GXt_char1 ;
      private string A148EmployeeName ;
      private string GXt_char2 ;
      private DateTime AV65FromDate ;
      private DateTime AV66ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool BRK9O3 ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private string A123WorkHourLogDescription ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV47Column ;
      private string A120WorkHourLogDuration ;
      private GxSimpleCollection<long> AV44ProjectId ;
      private GxSimpleCollection<long> AV46CompanyLocationId ;
      private GxSimpleCollection<long> AV24EmployeeId ;
      private IGxSession AV69WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> aP2_ProjectId ;
      private GxSimpleCollection<long> aP3_CompanyLocationId ;
      private GxSimpleCollection<long> aP4_EmployeeId ;
      private IDataStoreProvider pr_default ;
      private long[] P009O2_A102ProjectId ;
      private string[] P009O2_A103ProjectName ;
      private long[] P009O3_A100CompanyId ;
      private string[] P009O3_A148EmployeeName ;
      private string[] P009O3_A103ProjectName ;
      private string[] P009O3_A120WorkHourLogDuration ;
      private string[] P009O3_A123WorkHourLogDescription ;
      private short[] P009O3_A122WorkHourLogMinute ;
      private short[] P009O3_A121WorkHourLogHour ;
      private DateTime[] P009O3_A119WorkHourLogDate ;
      private long[] P009O3_A106EmployeeId ;
      private long[] P009O3_A157CompanyLocationId ;
      private long[] P009O3_A102ProjectId ;
      private long[] P009O3_A118WorkHourLogId ;
      private short[] P009O5_A40000GXC1 ;
      private bool[] P009O5_n40000GXC1 ;
      private short[] P009O5_A40001GXC2 ;
      private bool[] P009O5_n40001GXC2 ;
      private string aP5_Filename ;
      private string aP6_ErrorMessage ;
      private IGxSession AV25Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GxSimpleCollection<string> AV48Columns ;
   }

   public class exportdetailedreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009O3( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV46CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV24EmployeeId ,
                                             long AV73OneProjectId ,
                                             int AV46CompanyLocationId_Count ,
                                             int AV24EmployeeId_Count ,
                                             DateTime AV65FromDate ,
                                             DateTime AV66ToDate ,
                                             long A102ProjectId ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T2.EmployeeName, T4.ProjectName, T1.WorkHourLogDuration, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T1.EmployeeId, T3.CompanyLocationId, T1.ProjectId, T1.WorkHourLogId FROM (((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Project T4 ON T4.ProjectId = T1.ProjectId)";
         if ( ! (0==AV73OneProjectId) )
         {
            AddWhere(sWhereString, "(T1.ProjectId = :AV73OneProjectId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV46CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV46CompanyLocationId, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV24EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV24EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV65FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV65FromDate)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV66ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV66ToDate)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeName, T1.WorkHourLogDate";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P009O3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (DateTime)dynConstraints[10] );
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
          Object[] prmP009O2;
          prmP009O2 = new Object[] {
          new ParDef("AV73OneProjectId",GXType.Int64,10,0)
          };
          Object[] prmP009O5;
          prmP009O5 = new Object[] {
          new ParDef("AV65FromDate",GXType.Date,8,0) ,
          new ParDef("AV66ToDate",GXType.Date,8,0) ,
          new ParDef("AV73OneProjectId",GXType.Int64,10,0)
          };
          Object[] prmP009O3;
          prmP009O3 = new Object[] {
          new ParDef("AV73OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV65FromDate",GXType.Date,8,0) ,
          new ParDef("AV66ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009O2", "SELECT ProjectId, ProjectName FROM Project WHERE ProjectId = :AV73OneProjectId ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009O5", "SELECT COALESCE( T1.GXC1, 0) AS GXC1, COALESCE( T1.GXC2, 0) AS GXC2 FROM (SELECT SUM(WorkHourLogHour) AS GXC1, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (WorkHourLogDate >= :AV65FromDate) AND (WorkHourLogDate <= :AV66ToDate) AND (ProjectId = :AV73OneProjectId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O5,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 128);
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
