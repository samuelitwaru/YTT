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
   public class leaverequestpendingexport : GXProcedure
   {
      public leaverequestpendingexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestpendingexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         leaverequestpendingexport objleaverequestpendingexport;
         objleaverequestpendingexport = new leaverequestpendingexport();
         objleaverequestpendingexport.AV12Filename = "" ;
         objleaverequestpendingexport.AV13ErrorMessage = "" ;
         objleaverequestpendingexport.context.SetSubmitInitialConfig(context);
         objleaverequestpendingexport.initialize();
         Submit( executePrivateCatch,objleaverequestpendingexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leaverequestpendingexport)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 1;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S201 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
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
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV12Filename = GXt_char1 + "LeaveRequestPendingExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Main filter") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEmployeeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEmployeeName_Sel)) ? "(Empty)" : AV36TFEmployeeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEmployeeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFEmployeeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFLeaveTypeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Type Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFLeaveTypeName_Sel)) ? "(Empty)" : AV38TFLeaveTypeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFLeaveTypeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Type Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFLeaveTypeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV41TFLeaveRequestStartDate) && (DateTime.MinValue==AV42TFLeaveRequestStartDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Start Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV41TFLeaveRequestStartDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV42TFLeaveRequestStartDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV43TFLeaveRequestEndDate) && (DateTime.MinValue==AV44TFLeaveRequestEndDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "End Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV43TFLeaveRequestEndDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV44TFLeaveRequestEndDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFLeaveRequestHalfDay_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Half Day") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFLeaveRequestHalfDay_Sel)) ? "(Empty)" : AV53TFLeaveRequestHalfDay_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFLeaveRequestHalfDay)) && (0==AV54TFLeaveRequestHalfDayOperator) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Half Day") ;
               AV14CellRow = GXt_int2;
               if ( AV54TFLeaveRequestHalfDayOperator == 0 )
               {
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFLeaveRequestHalfDay, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
               else if ( AV54TFLeaveRequestHalfDayOperator == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Morning";
               }
               else if ( AV54TFLeaveRequestHalfDayOperator == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Afternoon";
               }
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV45TFLeaveRequestDuration) && (Convert.ToDecimal(0)==AV46TFLeaveRequestDuration_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Duration") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV45TFLeaveRequestDuration);
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV46TFLeaveRequestDuration_To);
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveRequestPendingColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("LeaveRequestPendingColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV55GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV57Leaverequestpendingds_1_filterfulltext = AV19FilterFullText;
         AV58Leaverequestpendingds_2_tfemployeename = AV35TFEmployeeName;
         AV59Leaverequestpendingds_3_tfemployeename_sel = AV36TFEmployeeName_Sel;
         AV60Leaverequestpendingds_4_tfleavetypename = AV37TFLeaveTypeName;
         AV61Leaverequestpendingds_5_tfleavetypename_sel = AV38TFLeaveTypeName_Sel;
         AV62Leaverequestpendingds_6_tfleaverequeststartdate = AV41TFLeaveRequestStartDate;
         AV63Leaverequestpendingds_7_tfleaverequeststartdate_to = AV42TFLeaveRequestStartDate_To;
         AV64Leaverequestpendingds_8_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV65Leaverequestpendingds_9_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV66Leaverequestpendingds_10_tfleaverequesthalfday = AV52TFLeaveRequestHalfDay;
         AV67Leaverequestpendingds_11_tfleaverequesthalfdayoperator = AV54TFLeaveRequestHalfDayOperator;
         AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel = AV53TFLeaveRequestHalfDay_Sel;
         AV69Leaverequestpendingds_13_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV70Leaverequestpendingds_14_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV71Udparg15 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV57Leaverequestpendingds_1_filterfulltext ,
                                              AV59Leaverequestpendingds_3_tfemployeename_sel ,
                                              AV58Leaverequestpendingds_2_tfemployeename ,
                                              AV61Leaverequestpendingds_5_tfleavetypename_sel ,
                                              AV60Leaverequestpendingds_4_tfleavetypename ,
                                              AV62Leaverequestpendingds_6_tfleaverequeststartdate ,
                                              AV63Leaverequestpendingds_7_tfleaverequeststartdate_to ,
                                              AV64Leaverequestpendingds_8_tfleaverequestenddate ,
                                              AV65Leaverequestpendingds_9_tfleaverequestenddate_to ,
                                              AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel ,
                                              AV66Leaverequestpendingds_10_tfleaverequesthalfday ,
                                              AV67Leaverequestpendingds_11_tfleaverequesthalfdayoperator ,
                                              AV69Leaverequestpendingds_13_tfleaverequestduration ,
                                              AV70Leaverequestpendingds_14_tfleaverequestduration_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV71Udparg15 ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Leaverequestpendingds_1_filterfulltext), "%", "");
         lV57Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Leaverequestpendingds_1_filterfulltext), "%", "");
         lV57Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Leaverequestpendingds_1_filterfulltext), "%", "");
         lV57Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Leaverequestpendingds_1_filterfulltext), "%", "");
         lV58Leaverequestpendingds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV58Leaverequestpendingds_2_tfemployeename), 128, "%");
         lV60Leaverequestpendingds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV60Leaverequestpendingds_4_tfleavetypename), 100, "%");
         lV66Leaverequestpendingds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV66Leaverequestpendingds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P006U2 */
         pr_default.execute(0, new Object[] {lV57Leaverequestpendingds_1_filterfulltext, lV57Leaverequestpendingds_1_filterfulltext, lV57Leaverequestpendingds_1_filterfulltext, lV57Leaverequestpendingds_1_filterfulltext, lV58Leaverequestpendingds_2_tfemployeename, AV59Leaverequestpendingds_3_tfemployeename_sel, lV60Leaverequestpendingds_4_tfleavetypename, AV61Leaverequestpendingds_5_tfleavetypename_sel, AV62Leaverequestpendingds_6_tfleaverequeststartdate, AV63Leaverequestpendingds_7_tfleaverequeststartdate_to, AV64Leaverequestpendingds_8_tfleaverequestenddate, AV65Leaverequestpendingds_9_tfleaverequestenddate_to, lV66Leaverequestpendingds_10_tfleaverequesthalfday, AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel, AV69Leaverequestpendingds_13_tfleaverequestduration, AV70Leaverequestpendingds_14_tfleaverequestduration_to, AV71Udparg15});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P006U2_A124LeaveTypeId[0];
            A106EmployeeId = P006U2_A106EmployeeId[0];
            A100CompanyId = P006U2_A100CompanyId[0];
            A132LeaveRequestStatus = P006U2_A132LeaveRequestStatus[0];
            A131LeaveRequestDuration = P006U2_A131LeaveRequestDuration[0];
            A173LeaveRequestHalfDay = P006U2_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P006U2_n173LeaveRequestHalfDay[0];
            A130LeaveRequestEndDate = P006U2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006U2_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006U2_A125LeaveTypeName[0];
            A148EmployeeName = P006U2_A148EmployeeName[0];
            A127LeaveRequestId = P006U2_A127LeaveRequestId[0];
            A100CompanyId = P006U2_A100CompanyId[0];
            A125LeaveTypeName = P006U2_A125LeaveTypeName[0];
            A148EmployeeName = P006U2_A148EmployeeName[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV32VisibleColumnCount = 0;
            AV72GXV2 = 1;
            while ( AV72GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV72GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A148EmployeeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveTypeName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A125LeaveTypeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestStartDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A129LeaveRequestStartDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestEndDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A130LeaveRequestEndDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestHalfDay") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A173LeaveRequestHalfDay, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                     if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Morning") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 60, 141, 188);
                     }
                     else if ( StringUtil.StrCmp(A173LeaveRequestHalfDay, "Afternoon") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestDuration") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A131LeaveRequestDuration);
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV72GXV2 = (int)(AV72GXV2+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S182 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV20Session.Set("WWPExportFilePath", AV12Filename);
         AV20Session.Set("WWPExportFileName", "LeaveRequestPendingExport.xlsx");
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

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeName",  "",  "Employee Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeName",  "",  "Type Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestStartDate",  "",  "Start Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestEndDate",  "",  "End Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestHalfDay",  "",  "Half Day",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDuration",  "",  "Request Duration",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "LeaveRequestPendingColumnsSelector", out  GXt_char1) ;
         AV28UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28UserCustomValue)) ) )
         {
            AV25ColumnsSelectorAux.FromXml(AV28UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV25ColumnsSelectorAux, ref  AV24ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveRequestPendingGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LeaveRequestPendingGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("LeaveRequestPendingGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV73GXV3 = 1;
         while ( AV73GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV73GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV35TFEmployeeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV36TFEmployeeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV37TFLeaveTypeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV38TFLeaveTypeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV41TFLeaveRequestStartDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 1);
               AV42TFLeaveRequestStartDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV43TFLeaveRequestEndDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 1);
               AV44TFLeaveRequestEndDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV54TFLeaveRequestHalfDayOperator = AV23GridStateFilterValue.gxTpr_Operator;
               if ( AV54TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV52TFLeaveRequestHalfDay = AV23GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV53TFLeaveRequestHalfDay_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV45TFLeaveRequestDuration = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV46TFLeaveRequestDuration_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV73GXV3 = (int)(AV73GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
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
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV36TFEmployeeName_Sel = "";
         AV35TFEmployeeName = "";
         AV38TFLeaveTypeName_Sel = "";
         AV37TFLeaveTypeName = "";
         AV41TFLeaveRequestStartDate = DateTime.MinValue;
         AV42TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV43TFLeaveRequestEndDate = DateTime.MinValue;
         AV44TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV53TFLeaveRequestHalfDay_Sel = "";
         AV52TFLeaveRequestHalfDay = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV57Leaverequestpendingds_1_filterfulltext = "";
         AV58Leaverequestpendingds_2_tfemployeename = "";
         AV59Leaverequestpendingds_3_tfemployeename_sel = "";
         AV60Leaverequestpendingds_4_tfleavetypename = "";
         AV61Leaverequestpendingds_5_tfleavetypename_sel = "";
         AV62Leaverequestpendingds_6_tfleaverequeststartdate = DateTime.MinValue;
         AV63Leaverequestpendingds_7_tfleaverequeststartdate_to = DateTime.MinValue;
         AV64Leaverequestpendingds_8_tfleaverequestenddate = DateTime.MinValue;
         AV65Leaverequestpendingds_9_tfleaverequestenddate_to = DateTime.MinValue;
         AV66Leaverequestpendingds_10_tfleaverequesthalfday = "";
         AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel = "";
         scmdbuf = "";
         lV57Leaverequestpendingds_1_filterfulltext = "";
         lV58Leaverequestpendingds_2_tfemployeename = "";
         lV60Leaverequestpendingds_4_tfleavetypename = "";
         lV66Leaverequestpendingds_10_tfleaverequesthalfday = "";
         AV50EmployeeIds = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         A125LeaveTypeName = "";
         A173LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P006U2_A124LeaveTypeId = new long[1] ;
         P006U2_A106EmployeeId = new long[1] ;
         P006U2_A100CompanyId = new long[1] ;
         P006U2_A132LeaveRequestStatus = new string[] {""} ;
         P006U2_A131LeaveRequestDuration = new decimal[1] ;
         P006U2_A173LeaveRequestHalfDay = new string[] {""} ;
         P006U2_n173LeaveRequestHalfDay = new bool[] {false} ;
         P006U2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006U2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006U2_A125LeaveTypeName = new string[] {""} ;
         P006U2_A148EmployeeName = new string[] {""} ;
         P006U2_A127LeaveRequestId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestpendingexport__default(),
            new Object[][] {
                new Object[] {
               P006U2_A124LeaveTypeId, P006U2_A106EmployeeId, P006U2_A100CompanyId, P006U2_A132LeaveRequestStatus, P006U2_A131LeaveRequestDuration, P006U2_A173LeaveRequestHalfDay, P006U2_n173LeaveRequestHalfDay, P006U2_A130LeaveRequestEndDate, P006U2_A129LeaveRequestStartDate, P006U2_A125LeaveTypeName,
               P006U2_A148EmployeeName, P006U2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV54TFLeaveRequestHalfDayOperator ;
      private short GXt_int2 ;
      private short AV67Leaverequestpendingds_11_tfleaverequesthalfdayoperator ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV55GXV1 ;
      private int AV72GXV2 ;
      private int AV73GXV3 ;
      private long AV32VisibleColumnCount ;
      private long AV71Udparg15 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private decimal AV45TFLeaveRequestDuration ;
      private decimal AV46TFLeaveRequestDuration_To ;
      private decimal AV69Leaverequestpendingds_13_tfleaverequestduration ;
      private decimal AV70Leaverequestpendingds_14_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV36TFEmployeeName_Sel ;
      private string AV35TFEmployeeName ;
      private string AV38TFLeaveTypeName_Sel ;
      private string AV37TFLeaveTypeName ;
      private string AV53TFLeaveRequestHalfDay_Sel ;
      private string AV52TFLeaveRequestHalfDay ;
      private string AV58Leaverequestpendingds_2_tfemployeename ;
      private string AV59Leaverequestpendingds_3_tfemployeename_sel ;
      private string AV60Leaverequestpendingds_4_tfleavetypename ;
      private string AV61Leaverequestpendingds_5_tfleavetypename_sel ;
      private string AV66Leaverequestpendingds_10_tfleaverequesthalfday ;
      private string AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel ;
      private string scmdbuf ;
      private string lV58Leaverequestpendingds_2_tfemployeename ;
      private string lV60Leaverequestpendingds_4_tfleavetypename ;
      private string lV66Leaverequestpendingds_10_tfleaverequesthalfday ;
      private string A148EmployeeName ;
      private string A125LeaveTypeName ;
      private string A173LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV41TFLeaveRequestStartDate ;
      private DateTime AV42TFLeaveRequestStartDate_To ;
      private DateTime AV43TFLeaveRequestEndDate ;
      private DateTime AV44TFLeaveRequestEndDate_To ;
      private DateTime AV62Leaverequestpendingds_6_tfleaverequeststartdate ;
      private DateTime AV63Leaverequestpendingds_7_tfleaverequeststartdate_to ;
      private DateTime AV64Leaverequestpendingds_8_tfleaverequestenddate ;
      private DateTime AV65Leaverequestpendingds_9_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n173LeaveRequestHalfDay ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV57Leaverequestpendingds_1_filterfulltext ;
      private string lV57Leaverequestpendingds_1_filterfulltext ;
      private GxSimpleCollection<long> AV50EmployeeIds ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P006U2_A124LeaveTypeId ;
      private long[] P006U2_A106EmployeeId ;
      private long[] P006U2_A100CompanyId ;
      private string[] P006U2_A132LeaveRequestStatus ;
      private decimal[] P006U2_A131LeaveRequestDuration ;
      private string[] P006U2_A173LeaveRequestHalfDay ;
      private bool[] P006U2_n173LeaveRequestHalfDay ;
      private DateTime[] P006U2_A130LeaveRequestEndDate ;
      private DateTime[] P006U2_A129LeaveRequestStartDate ;
      private string[] P006U2_A125LeaveTypeName ;
      private string[] P006U2_A148EmployeeName ;
      private long[] P006U2_A127LeaveRequestId ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
   }

   public class leaverequestpendingexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006U2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV57Leaverequestpendingds_1_filterfulltext ,
                                             string AV59Leaverequestpendingds_3_tfemployeename_sel ,
                                             string AV58Leaverequestpendingds_2_tfemployeename ,
                                             string AV61Leaverequestpendingds_5_tfleavetypename_sel ,
                                             string AV60Leaverequestpendingds_4_tfleavetypename ,
                                             DateTime AV62Leaverequestpendingds_6_tfleaverequeststartdate ,
                                             DateTime AV63Leaverequestpendingds_7_tfleaverequeststartdate_to ,
                                             DateTime AV64Leaverequestpendingds_8_tfleaverequestenddate ,
                                             DateTime AV65Leaverequestpendingds_9_tfleaverequestenddate_to ,
                                             string AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel ,
                                             string AV66Leaverequestpendingds_10_tfleaverequesthalfday ,
                                             short AV67Leaverequestpendingds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV69Leaverequestpendingds_13_tfleaverequestduration ,
                                             decimal AV70Leaverequestpendingds_14_tfleaverequestduration_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV71Udparg15 ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[17];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestStatus, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T3.EmployeeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestpendingds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T3.EmployeeName) like '%' || LOWER(:lV57Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV57Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV57Leaverequestpendingds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV57Leaverequestpendingds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestpendingds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestpendingds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV58Leaverequestpendingds_2_tfemployeename))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestpendingds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV59Leaverequestpendingds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV59Leaverequestpendingds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Leaverequestpendingds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestpendingds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestpendingds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV60Leaverequestpendingds_4_tfleavetypename))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestpendingds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV61Leaverequestpendingds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV61Leaverequestpendingds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV61Leaverequestpendingds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV62Leaverequestpendingds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV62Leaverequestpendingds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestpendingds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV63Leaverequestpendingds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestpendingds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV64Leaverequestpendingds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestpendingds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV65Leaverequestpendingds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV66Leaverequestpendingds_10_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV67Leaverequestpendingds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV67Leaverequestpendingds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV69Leaverequestpendingds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV69Leaverequestpendingds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestpendingds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV70Leaverequestpendingds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV71Udparg15)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! new userhasrole(context).executeUdp(  "Manager") && new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestId DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.EmployeeName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.EmployeeName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.LeaveTypeName";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.LeaveTypeName DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStartDate";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStartDate DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestEndDate";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestEndDate DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestHalfDay";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestHalfDay DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration DESC";
         }
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
                     return conditional_P006U2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP006U2;
          prmP006U2 = new Object[] {
          new ParDef("lV57Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestpendingds_2_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV59Leaverequestpendingds_3_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV60Leaverequestpendingds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV61Leaverequestpendingds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV62Leaverequestpendingds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV63Leaverequestpendingds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV64Leaverequestpendingds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestpendingds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV66Leaverequestpendingds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV68Leaverequestpendingds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestpendingds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV70Leaverequestpendingds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV71Udparg15",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006U2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 128);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
