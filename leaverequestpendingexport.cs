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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFLeaveRequestDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Description") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFLeaveRequestDescription_Sel)) ? "(Empty)" : AV48TFLeaveRequestDescription_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFLeaveRequestDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Description") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFLeaveRequestDescription, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
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
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV52GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV54Leaverequestpendingds_1_filterfulltext = AV19FilterFullText;
         AV55Leaverequestpendingds_2_tfleavetypename = AV37TFLeaveTypeName;
         AV56Leaverequestpendingds_3_tfleavetypename_sel = AV38TFLeaveTypeName_Sel;
         AV57Leaverequestpendingds_4_tfleaverequeststartdate = AV41TFLeaveRequestStartDate;
         AV58Leaverequestpendingds_5_tfleaverequeststartdate_to = AV42TFLeaveRequestStartDate_To;
         AV59Leaverequestpendingds_6_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV60Leaverequestpendingds_7_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV61Leaverequestpendingds_8_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV62Leaverequestpendingds_9_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV63Leaverequestpendingds_10_tfleaverequestdescription = AV47TFLeaveRequestDescription;
         AV64Leaverequestpendingds_11_tfleaverequestdescription_sel = AV48TFLeaveRequestDescription_Sel;
         AV65Leaverequestpendingds_12_tfemployeename = AV35TFEmployeeName;
         AV66Leaverequestpendingds_13_tfemployeename_sel = AV36TFEmployeeName_Sel;
         AV67Udparg14 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV54Leaverequestpendingds_1_filterfulltext ,
                                              AV56Leaverequestpendingds_3_tfleavetypename_sel ,
                                              AV55Leaverequestpendingds_2_tfleavetypename ,
                                              AV57Leaverequestpendingds_4_tfleaverequeststartdate ,
                                              AV58Leaverequestpendingds_5_tfleaverequeststartdate_to ,
                                              AV59Leaverequestpendingds_6_tfleaverequestenddate ,
                                              AV60Leaverequestpendingds_7_tfleaverequestenddate_to ,
                                              AV61Leaverequestpendingds_8_tfleaverequestduration ,
                                              AV62Leaverequestpendingds_9_tfleaverequestduration_to ,
                                              AV64Leaverequestpendingds_11_tfleaverequestdescription_sel ,
                                              AV63Leaverequestpendingds_10_tfleaverequestdescription ,
                                              AV66Leaverequestpendingds_13_tfemployeename_sel ,
                                              AV65Leaverequestpendingds_12_tfemployeename ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A148EmployeeName ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV67Udparg14 ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Leaverequestpendingds_1_filterfulltext), "%", "");
         lV54Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Leaverequestpendingds_1_filterfulltext), "%", "");
         lV54Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Leaverequestpendingds_1_filterfulltext), "%", "");
         lV54Leaverequestpendingds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Leaverequestpendingds_1_filterfulltext), "%", "");
         lV55Leaverequestpendingds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV55Leaverequestpendingds_2_tfleavetypename), 100, "%");
         lV63Leaverequestpendingds_10_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV63Leaverequestpendingds_10_tfleaverequestdescription), "%", "");
         lV65Leaverequestpendingds_12_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV65Leaverequestpendingds_12_tfemployeename), 128, "%");
         /* Using cursor P006U2 */
         pr_default.execute(0, new Object[] {lV54Leaverequestpendingds_1_filterfulltext, lV54Leaverequestpendingds_1_filterfulltext, lV54Leaverequestpendingds_1_filterfulltext, lV54Leaverequestpendingds_1_filterfulltext, lV55Leaverequestpendingds_2_tfleavetypename, AV56Leaverequestpendingds_3_tfleavetypename_sel, AV57Leaverequestpendingds_4_tfleaverequeststartdate, AV58Leaverequestpendingds_5_tfleaverequeststartdate_to, AV59Leaverequestpendingds_6_tfleaverequestenddate, AV60Leaverequestpendingds_7_tfleaverequestenddate_to, AV61Leaverequestpendingds_8_tfleaverequestduration, AV62Leaverequestpendingds_9_tfleaverequestduration_to, lV63Leaverequestpendingds_10_tfleaverequestdescription, AV64Leaverequestpendingds_11_tfleaverequestdescription_sel, lV65Leaverequestpendingds_12_tfemployeename, AV66Leaverequestpendingds_13_tfemployeename_sel, AV67Udparg14});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P006U2_A124LeaveTypeId[0];
            A106EmployeeId = P006U2_A106EmployeeId[0];
            A100CompanyId = P006U2_A100CompanyId[0];
            A132LeaveRequestStatus = P006U2_A132LeaveRequestStatus[0];
            A148EmployeeName = P006U2_A148EmployeeName[0];
            A133LeaveRequestDescription = P006U2_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P006U2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006U2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006U2_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006U2_A125LeaveTypeName[0];
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
            AV68GXV2 = 1;
            while ( AV68GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV68GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveTypeName") == 0 )
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
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestDuration") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A131LeaveRequestDuration);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A133LeaveRequestDescription, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A148EmployeeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV68GXV2 = (int)(AV68GXV2+1);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeName",  "",  "Type Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestStartDate",  "",  "Start Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestEndDate",  "",  "End Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDuration",  "",  "Request Duration",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDescription",  "",  "Request Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeName",  "",  "Employee Name",  true,  "") ;
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
         AV69GXV3 = 1;
         while ( AV69GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV69GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
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
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV45TFLeaveRequestDuration = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV46TFLeaveRequestDuration_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV47TFLeaveRequestDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV48TFLeaveRequestDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV35TFEmployeeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV36TFEmployeeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV69GXV3 = (int)(AV69GXV3+1);
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
         AV38TFLeaveTypeName_Sel = "";
         AV37TFLeaveTypeName = "";
         AV41TFLeaveRequestStartDate = DateTime.MinValue;
         AV42TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV43TFLeaveRequestEndDate = DateTime.MinValue;
         AV44TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV48TFLeaveRequestDescription_Sel = "";
         AV47TFLeaveRequestDescription = "";
         AV36TFEmployeeName_Sel = "";
         AV35TFEmployeeName = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV54Leaverequestpendingds_1_filterfulltext = "";
         AV55Leaverequestpendingds_2_tfleavetypename = "";
         AV56Leaverequestpendingds_3_tfleavetypename_sel = "";
         AV57Leaverequestpendingds_4_tfleaverequeststartdate = DateTime.MinValue;
         AV58Leaverequestpendingds_5_tfleaverequeststartdate_to = DateTime.MinValue;
         AV59Leaverequestpendingds_6_tfleaverequestenddate = DateTime.MinValue;
         AV60Leaverequestpendingds_7_tfleaverequestenddate_to = DateTime.MinValue;
         AV63Leaverequestpendingds_10_tfleaverequestdescription = "";
         AV64Leaverequestpendingds_11_tfleaverequestdescription_sel = "";
         AV65Leaverequestpendingds_12_tfemployeename = "";
         AV66Leaverequestpendingds_13_tfemployeename_sel = "";
         scmdbuf = "";
         lV54Leaverequestpendingds_1_filterfulltext = "";
         lV55Leaverequestpendingds_2_tfleavetypename = "";
         lV63Leaverequestpendingds_10_tfleaverequestdescription = "";
         lV65Leaverequestpendingds_12_tfemployeename = "";
         AV50EmployeeIds = new GxSimpleCollection<long>();
         A125LeaveTypeName = "";
         A133LeaveRequestDescription = "";
         A148EmployeeName = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P006U2_A124LeaveTypeId = new long[1] ;
         P006U2_A106EmployeeId = new long[1] ;
         P006U2_A100CompanyId = new long[1] ;
         P006U2_A132LeaveRequestStatus = new string[] {""} ;
         P006U2_A148EmployeeName = new string[] {""} ;
         P006U2_A133LeaveRequestDescription = new string[] {""} ;
         P006U2_A131LeaveRequestDuration = new decimal[1] ;
         P006U2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006U2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006U2_A125LeaveTypeName = new string[] {""} ;
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
               P006U2_A124LeaveTypeId, P006U2_A106EmployeeId, P006U2_A100CompanyId, P006U2_A132LeaveRequestStatus, P006U2_A148EmployeeName, P006U2_A133LeaveRequestDescription, P006U2_A131LeaveRequestDuration, P006U2_A130LeaveRequestEndDate, P006U2_A129LeaveRequestStartDate, P006U2_A125LeaveTypeName,
               P006U2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV52GXV1 ;
      private int AV68GXV2 ;
      private int AV69GXV3 ;
      private long AV32VisibleColumnCount ;
      private long AV67Udparg14 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private decimal AV45TFLeaveRequestDuration ;
      private decimal AV46TFLeaveRequestDuration_To ;
      private decimal AV61Leaverequestpendingds_8_tfleaverequestduration ;
      private decimal AV62Leaverequestpendingds_9_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV38TFLeaveTypeName_Sel ;
      private string AV37TFLeaveTypeName ;
      private string AV36TFEmployeeName_Sel ;
      private string AV35TFEmployeeName ;
      private string AV55Leaverequestpendingds_2_tfleavetypename ;
      private string AV56Leaverequestpendingds_3_tfleavetypename_sel ;
      private string AV65Leaverequestpendingds_12_tfemployeename ;
      private string AV66Leaverequestpendingds_13_tfemployeename_sel ;
      private string scmdbuf ;
      private string lV55Leaverequestpendingds_2_tfleavetypename ;
      private string lV65Leaverequestpendingds_12_tfemployeename ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string A132LeaveRequestStatus ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV41TFLeaveRequestStartDate ;
      private DateTime AV42TFLeaveRequestStartDate_To ;
      private DateTime AV43TFLeaveRequestEndDate ;
      private DateTime AV44TFLeaveRequestEndDate_To ;
      private DateTime AV57Leaverequestpendingds_4_tfleaverequeststartdate ;
      private DateTime AV58Leaverequestpendingds_5_tfleaverequeststartdate_to ;
      private DateTime AV59Leaverequestpendingds_6_tfleaverequestenddate ;
      private DateTime AV60Leaverequestpendingds_7_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV48TFLeaveRequestDescription_Sel ;
      private string AV47TFLeaveRequestDescription ;
      private string AV54Leaverequestpendingds_1_filterfulltext ;
      private string AV63Leaverequestpendingds_10_tfleaverequestdescription ;
      private string AV64Leaverequestpendingds_11_tfleaverequestdescription_sel ;
      private string lV54Leaverequestpendingds_1_filterfulltext ;
      private string lV63Leaverequestpendingds_10_tfleaverequestdescription ;
      private string A133LeaveRequestDescription ;
      private GxSimpleCollection<long> AV50EmployeeIds ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P006U2_A124LeaveTypeId ;
      private long[] P006U2_A106EmployeeId ;
      private long[] P006U2_A100CompanyId ;
      private string[] P006U2_A132LeaveRequestStatus ;
      private string[] P006U2_A148EmployeeName ;
      private string[] P006U2_A133LeaveRequestDescription ;
      private decimal[] P006U2_A131LeaveRequestDuration ;
      private DateTime[] P006U2_A130LeaveRequestEndDate ;
      private DateTime[] P006U2_A129LeaveRequestStartDate ;
      private string[] P006U2_A125LeaveTypeName ;
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
                                             string AV54Leaverequestpendingds_1_filterfulltext ,
                                             string AV56Leaverequestpendingds_3_tfleavetypename_sel ,
                                             string AV55Leaverequestpendingds_2_tfleavetypename ,
                                             DateTime AV57Leaverequestpendingds_4_tfleaverequeststartdate ,
                                             DateTime AV58Leaverequestpendingds_5_tfleaverequeststartdate_to ,
                                             DateTime AV59Leaverequestpendingds_6_tfleaverequestenddate ,
                                             DateTime AV60Leaverequestpendingds_7_tfleaverequestenddate_to ,
                                             decimal AV61Leaverequestpendingds_8_tfleaverequestduration ,
                                             decimal AV62Leaverequestpendingds_9_tfleaverequestduration_to ,
                                             string AV64Leaverequestpendingds_11_tfleaverequestdescription_sel ,
                                             string AV63Leaverequestpendingds_10_tfleaverequestdescription ,
                                             string AV66Leaverequestpendingds_13_tfemployeename_sel ,
                                             string AV65Leaverequestpendingds_12_tfemployeename ,
                                             string A125LeaveTypeName ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A148EmployeeName ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV67Udparg14 ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[17];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestStatus, T3.EmployeeName, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leaverequestpendingds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV54Leaverequestpendingds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV54Leaverequestpendingds_1_filterfulltext) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV54Leaverequestpendingds_1_filterfulltext)) or ( LOWER(T3.EmployeeName) like '%' || LOWER(:lV54Leaverequestpendingds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Leaverequestpendingds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Leaverequestpendingds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV55Leaverequestpendingds_2_tfleavetypename))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Leaverequestpendingds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV56Leaverequestpendingds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV56Leaverequestpendingds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Leaverequestpendingds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV57Leaverequestpendingds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV57Leaverequestpendingds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Leaverequestpendingds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV58Leaverequestpendingds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Leaverequestpendingds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV59Leaverequestpendingds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Leaverequestpendingds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV60Leaverequestpendingds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Leaverequestpendingds_8_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV61Leaverequestpendingds_8_tfleaverequestduration)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV62Leaverequestpendingds_9_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV62Leaverequestpendingds_9_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_11_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestpendingds_10_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV63Leaverequestpendingds_10_tfleaverequestdescription))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestpendingds_11_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV64Leaverequestpendingds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV64Leaverequestpendingds_11_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV64Leaverequestpendingds_11_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_13_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestpendingds_12_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV65Leaverequestpendingds_12_tfemployeename))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestpendingds_13_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV66Leaverequestpendingds_13_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV66Leaverequestpendingds_13_tfemployeename_sel))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV66Leaverequestpendingds_13_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV67Udparg14)");
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
            scmdbuf += " ORDER BY T2.LeaveTypeName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.LeaveTypeName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStartDate";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStartDate DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestEndDate";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestEndDate DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDescription DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.EmployeeName";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.EmployeeName DESC";
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
                     return conditional_P006U2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] );
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
          new ParDef("lV54Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Leaverequestpendingds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Leaverequestpendingds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV56Leaverequestpendingds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV57Leaverequestpendingds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV58Leaverequestpendingds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV59Leaverequestpendingds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV60Leaverequestpendingds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV61Leaverequestpendingds_8_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV62Leaverequestpendingds_9_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV63Leaverequestpendingds_10_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV64Leaverequestpendingds_11_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV65Leaverequestpendingds_12_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV66Leaverequestpendingds_13_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("AV67Udparg14",GXType.Int64,10,0)
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
                ((string[]) buf[4])[0] = rslt.getString(5, 128);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
