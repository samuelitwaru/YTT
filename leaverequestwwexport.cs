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
   public class leaverequestwwexport : GXProcedure
   {
      public leaverequestwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestwwexport( IGxContext context )
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
         leaverequestwwexport objleaverequestwwexport;
         objleaverequestwwexport = new leaverequestwwexport();
         objleaverequestwwexport.AV12Filename = "" ;
         objleaverequestwwexport.AV13ErrorMessage = "" ;
         objleaverequestwwexport.context.SetSubmitInitialConfig(context);
         objleaverequestwwexport.initialize();
         Submit( executePrivateCatch,objleaverequestwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leaverequestwwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "LeaveRequestWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFLeaveRequestId) && (0==AV36TFLeaveRequestId_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Id") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFLeaveRequestId;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFLeaveRequestId_To;
         }
         if ( ! ( (0==AV37TFLeaveTypeId) && (0==AV38TFLeaveTypeId_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Leave Type Id") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV37TFLeaveTypeId;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV38TFLeaveTypeId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFLeaveTypeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Leave Type Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFLeaveTypeName_Sel)) ? "(Empty)" : AV40TFLeaveTypeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFLeaveTypeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Leave Type Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFLeaveTypeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV41TFLeaveRequestDate) && (DateTime.MinValue==AV42TFLeaveRequestDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV41TFLeaveRequestDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV42TFLeaveRequestDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV43TFLeaveRequestStartDate) && (DateTime.MinValue==AV44TFLeaveRequestStartDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Start Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV43TFLeaveRequestStartDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV44TFLeaveRequestStartDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV45TFLeaveRequestEndDate) && (DateTime.MinValue==AV46TFLeaveRequestEndDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "End Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV45TFLeaveRequestEndDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV46TFLeaveRequestEndDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (0==AV47TFLeaveRequestDuration) && (0==AV48TFLeaveRequestDuration_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Duration") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFLeaveRequestDuration;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFLeaveRequestDuration_To;
         }
         if ( ! ( ( AV51TFLeaveRequestStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Status") ;
            AV14CellRow = GXt_int2;
            AV58i = 1;
            AV59GXV1 = 1;
            while ( AV59GXV1 <= AV51TFLeaveRequestStatus_Sels.Count )
            {
               AV50TFLeaveRequestStatus_Sel = AV51TFLeaveRequestStatus_Sels.GetString(AV59GXV1);
               if ( AV58i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+gxdomainleaverequeststatusdomain.getDescription(context,AV50TFLeaveRequestStatus_Sel);
               AV58i = (long)(AV58i+1);
               AV59GXV1 = (int)(AV59GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFLeaveRequestDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Description") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFLeaveRequestDescription_Sel)) ? "(Empty)" : AV53TFLeaveRequestDescription_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFLeaveRequestDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Description") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFLeaveRequestDescription, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFLeaveRequestRejectionReason_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Rejection Reason") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFLeaveRequestRejectionReason_Sel)) ? "(Empty)" : AV55TFLeaveRequestRejectionReason_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFLeaveRequestRejectionReason)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Rejection Reason") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFLeaveRequestRejectionReason, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV56TFEmployeeId) && (0==AV57TFEmployeeId_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Id") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV56TFEmployeeId;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV57TFEmployeeId_To;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveRequestWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("LeaveRequestWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV60GXV2 = 1;
         while ( AV60GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV60GXV2));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV60GXV2 = (int)(AV60GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV62Leaverequestwwds_1_filterfulltext = AV19FilterFullText;
         AV63Leaverequestwwds_2_tfleaverequestid = AV35TFLeaveRequestId;
         AV64Leaverequestwwds_3_tfleaverequestid_to = AV36TFLeaveRequestId_To;
         AV65Leaverequestwwds_4_tfleavetypeid = AV37TFLeaveTypeId;
         AV66Leaverequestwwds_5_tfleavetypeid_to = AV38TFLeaveTypeId_To;
         AV67Leaverequestwwds_6_tfleavetypename = AV39TFLeaveTypeName;
         AV68Leaverequestwwds_7_tfleavetypename_sel = AV40TFLeaveTypeName_Sel;
         AV69Leaverequestwwds_8_tfleaverequestdate = AV41TFLeaveRequestDate;
         AV70Leaverequestwwds_9_tfleaverequestdate_to = AV42TFLeaveRequestDate_To;
         AV71Leaverequestwwds_10_tfleaverequeststartdate = AV43TFLeaveRequestStartDate;
         AV72Leaverequestwwds_11_tfleaverequeststartdate_to = AV44TFLeaveRequestStartDate_To;
         AV73Leaverequestwwds_12_tfleaverequestenddate = AV45TFLeaveRequestEndDate;
         AV74Leaverequestwwds_13_tfleaverequestenddate_to = AV46TFLeaveRequestEndDate_To;
         AV75Leaverequestwwds_14_tfleaverequestduration = AV47TFLeaveRequestDuration;
         AV76Leaverequestwwds_15_tfleaverequestduration_to = AV48TFLeaveRequestDuration_To;
         AV77Leaverequestwwds_16_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV78Leaverequestwwds_17_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV79Leaverequestwwds_18_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV80Leaverequestwwds_19_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
         AV82Leaverequestwwds_21_tfemployeeid = AV56TFEmployeeId;
         AV83Leaverequestwwds_22_tfemployeeid_to = AV57TFEmployeeId_To;
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV77Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                              AV62Leaverequestwwds_1_filterfulltext ,
                                              AV63Leaverequestwwds_2_tfleaverequestid ,
                                              AV64Leaverequestwwds_3_tfleaverequestid_to ,
                                              AV65Leaverequestwwds_4_tfleavetypeid ,
                                              AV66Leaverequestwwds_5_tfleavetypeid_to ,
                                              AV68Leaverequestwwds_7_tfleavetypename_sel ,
                                              AV67Leaverequestwwds_6_tfleavetypename ,
                                              AV69Leaverequestwwds_8_tfleaverequestdate ,
                                              AV70Leaverequestwwds_9_tfleaverequestdate_to ,
                                              AV71Leaverequestwwds_10_tfleaverequeststartdate ,
                                              AV72Leaverequestwwds_11_tfleaverequeststartdate_to ,
                                              AV73Leaverequestwwds_12_tfleaverequestenddate ,
                                              AV74Leaverequestwwds_13_tfleaverequestenddate_to ,
                                              AV75Leaverequestwwds_14_tfleaverequestduration ,
                                              AV76Leaverequestwwds_15_tfleaverequestduration_to ,
                                              AV77Leaverequestwwds_16_tfleaverequeststatus_sels.Count ,
                                              AV79Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                              AV78Leaverequestwwds_17_tfleaverequestdescription ,
                                              AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                              AV80Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                              AV82Leaverequestwwds_21_tfemployeeid ,
                                              AV83Leaverequestwwds_22_tfemployeeid_to ,
                                              A127LeaveRequestId ,
                                              A124LeaveTypeId ,
                                              A125LeaveTypeName ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A106EmployeeId ,
                                              A128LeaveRequestDate ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A100CompanyId ,
                                              AV84Udparg23 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV62Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext), "%", "");
         lV67Leaverequestwwds_6_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV67Leaverequestwwds_6_tfleavetypename), 100, "%");
         lV78Leaverequestwwds_17_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV78Leaverequestwwds_17_tfleaverequestdescription), "%", "");
         lV80Leaverequestwwds_19_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV80Leaverequestwwds_19_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008E2 */
         pr_default.execute(0, new Object[] {AV84Udparg23, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, lV62Leaverequestwwds_1_filterfulltext, AV63Leaverequestwwds_2_tfleaverequestid, AV64Leaverequestwwds_3_tfleaverequestid_to, AV65Leaverequestwwds_4_tfleavetypeid, AV66Leaverequestwwds_5_tfleavetypeid_to, lV67Leaverequestwwds_6_tfleavetypename, AV68Leaverequestwwds_7_tfleavetypename_sel, AV69Leaverequestwwds_8_tfleaverequestdate, AV70Leaverequestwwds_9_tfleaverequestdate_to, AV71Leaverequestwwds_10_tfleaverequeststartdate, AV72Leaverequestwwds_11_tfleaverequeststartdate_to, AV73Leaverequestwwds_12_tfleaverequestenddate, AV74Leaverequestwwds_13_tfleaverequestenddate_to, AV75Leaverequestwwds_14_tfleaverequestduration, AV76Leaverequestwwds_15_tfleaverequestduration_to, lV78Leaverequestwwds_17_tfleaverequestdescription, AV79Leaverequestwwds_18_tfleaverequestdescription_sel, lV80Leaverequestwwds_19_tfleaverequestrejectionreason, AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel, AV82Leaverequestwwds_21_tfemployeeid, AV83Leaverequestwwds_22_tfemployeeid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P008E2_A100CompanyId[0];
            A106EmployeeId = P008E2_A106EmployeeId[0];
            A134LeaveRequestRejectionReason = P008E2_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P008E2_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008E2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008E2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008E2_A129LeaveRequestStartDate[0];
            A128LeaveRequestDate = P008E2_A128LeaveRequestDate[0];
            A125LeaveTypeName = P008E2_A125LeaveTypeName[0];
            A124LeaveTypeId = P008E2_A124LeaveTypeId[0];
            A127LeaveRequestId = P008E2_A127LeaveRequestId[0];
            A132LeaveRequestStatus = P008E2_A132LeaveRequestStatus[0];
            A100CompanyId = P008E2_A100CompanyId[0];
            A125LeaveTypeName = P008E2_A125LeaveTypeName[0];
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
            AV85GXV3 = 1;
            while ( AV85GXV3 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV85GXV3));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A127LeaveRequestId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveTypeId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A124LeaveTypeId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveTypeName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A125LeaveTypeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A128LeaveRequestDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
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
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A131LeaveRequestDuration;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestStatus") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = gxdomainleaverequeststatusdomain.getDescription(context,A132LeaveRequestStatus);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A133LeaveRequestDescription, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestRejectionReason") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A134LeaveRequestRejectionReason, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A106EmployeeId;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV85GXV3 = (int)(AV85GXV3+1);
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
         AV20Session.Set("WWPExportFileName", "LeaveRequestWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestId",  "",  "Request Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeId",  "",  "Leave Type Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeName",  "",  "Leave Type Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDate",  "",  "Request Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestStartDate",  "",  "Start Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestEndDate",  "",  "End Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDuration",  "",  "Request Duration",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestStatus",  "",  "Request Status",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDescription",  "",  "Request Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestRejectionReason",  "",  "Rejection Reason",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeId",  "",  "Employee Id",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "LeaveRequestWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveRequestWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LeaveRequestWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("LeaveRequestWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV86GXV4 = 1;
         while ( AV86GXV4 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV86GXV4));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTID") == 0 )
            {
               AV35TFLeaveRequestId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFLeaveRequestId_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPEID") == 0 )
            {
               AV37TFLeaveTypeId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFLeaveTypeId_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV39TFLeaveTypeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV40TFLeaveTypeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDATE") == 0 )
            {
               AV41TFLeaveRequestDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 1);
               AV42TFLeaveRequestDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV43TFLeaveRequestStartDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 1);
               AV44TFLeaveRequestStartDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV45TFLeaveRequestEndDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 1);
               AV46TFLeaveRequestEndDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV47TFLeaveRequestDuration = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFLeaveRequestDuration_To = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS_SEL") == 0 )
            {
               AV49TFLeaveRequestStatus_SelsJson = AV23GridStateFilterValue.gxTpr_Value;
               AV51TFLeaveRequestStatus_Sels.FromJSonString(AV49TFLeaveRequestStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV52TFLeaveRequestDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV53TFLeaveRequestDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON") == 0 )
            {
               AV54TFLeaveRequestRejectionReason = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON_SEL") == 0 )
            {
               AV55TFLeaveRequestRejectionReason_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEID") == 0 )
            {
               AV56TFEmployeeId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV57TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV86GXV4 = (int)(AV86GXV4+1);
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
         AV40TFLeaveTypeName_Sel = "";
         AV39TFLeaveTypeName = "";
         AV41TFLeaveRequestDate = DateTime.MinValue;
         AV42TFLeaveRequestDate_To = DateTime.MinValue;
         AV43TFLeaveRequestStartDate = DateTime.MinValue;
         AV44TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV45TFLeaveRequestEndDate = DateTime.MinValue;
         AV46TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV51TFLeaveRequestStatus_Sels = new GxSimpleCollection<string>();
         AV50TFLeaveRequestStatus_Sel = "";
         AV53TFLeaveRequestDescription_Sel = "";
         AV52TFLeaveRequestDescription = "";
         AV55TFLeaveRequestRejectionReason_Sel = "";
         AV54TFLeaveRequestRejectionReason = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV62Leaverequestwwds_1_filterfulltext = "";
         AV67Leaverequestwwds_6_tfleavetypename = "";
         AV68Leaverequestwwds_7_tfleavetypename_sel = "";
         AV69Leaverequestwwds_8_tfleaverequestdate = DateTime.MinValue;
         AV70Leaverequestwwds_9_tfleaverequestdate_to = DateTime.MinValue;
         AV71Leaverequestwwds_10_tfleaverequeststartdate = DateTime.MinValue;
         AV72Leaverequestwwds_11_tfleaverequeststartdate_to = DateTime.MinValue;
         AV73Leaverequestwwds_12_tfleaverequestenddate = DateTime.MinValue;
         AV74Leaverequestwwds_13_tfleaverequestenddate_to = DateTime.MinValue;
         AV77Leaverequestwwds_16_tfleaverequeststatus_sels = new GxSimpleCollection<string>();
         AV78Leaverequestwwds_17_tfleaverequestdescription = "";
         AV79Leaverequestwwds_18_tfleaverequestdescription_sel = "";
         AV80Leaverequestwwds_19_tfleaverequestrejectionreason = "";
         AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel = "";
         scmdbuf = "";
         lV62Leaverequestwwds_1_filterfulltext = "";
         lV67Leaverequestwwds_6_tfleavetypename = "";
         lV78Leaverequestwwds_17_tfleaverequestdescription = "";
         lV80Leaverequestwwds_19_tfleaverequestrejectionreason = "";
         A132LeaveRequestStatus = "";
         A125LeaveTypeName = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P008E2_A100CompanyId = new long[1] ;
         P008E2_A106EmployeeId = new long[1] ;
         P008E2_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008E2_A133LeaveRequestDescription = new string[] {""} ;
         P008E2_A131LeaveRequestDuration = new short[1] ;
         P008E2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008E2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008E2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P008E2_A125LeaveTypeName = new string[] {""} ;
         P008E2_A124LeaveTypeId = new long[1] ;
         P008E2_A127LeaveRequestId = new long[1] ;
         P008E2_A132LeaveRequestStatus = new string[] {""} ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49TFLeaveRequestStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestwwexport__default(),
            new Object[][] {
                new Object[] {
               P008E2_A100CompanyId, P008E2_A106EmployeeId, P008E2_A134LeaveRequestRejectionReason, P008E2_A133LeaveRequestDescription, P008E2_A131LeaveRequestDuration, P008E2_A130LeaveRequestEndDate, P008E2_A129LeaveRequestStartDate, P008E2_A128LeaveRequestDate, P008E2_A125LeaveTypeName, P008E2_A124LeaveTypeId,
               P008E2_A127LeaveRequestId, P008E2_A132LeaveRequestStatus
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV47TFLeaveRequestDuration ;
      private short AV48TFLeaveRequestDuration_To ;
      private short GXt_int2 ;
      private short AV75Leaverequestwwds_14_tfleaverequestduration ;
      private short AV76Leaverequestwwds_15_tfleaverequestduration_to ;
      private short A131LeaveRequestDuration ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV59GXV1 ;
      private int AV60GXV2 ;
      private int AV77Leaverequestwwds_16_tfleaverequeststatus_sels_Count ;
      private int AV85GXV3 ;
      private int AV86GXV4 ;
      private long AV35TFLeaveRequestId ;
      private long AV36TFLeaveRequestId_To ;
      private long AV37TFLeaveTypeId ;
      private long AV38TFLeaveTypeId_To ;
      private long AV58i ;
      private long AV56TFEmployeeId ;
      private long AV57TFEmployeeId_To ;
      private long AV32VisibleColumnCount ;
      private long AV63Leaverequestwwds_2_tfleaverequestid ;
      private long AV64Leaverequestwwds_3_tfleaverequestid_to ;
      private long AV65Leaverequestwwds_4_tfleavetypeid ;
      private long AV66Leaverequestwwds_5_tfleavetypeid_to ;
      private long AV82Leaverequestwwds_21_tfemployeeid ;
      private long AV83Leaverequestwwds_22_tfemployeeid_to ;
      private long AV84Udparg23 ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private string AV40TFLeaveTypeName_Sel ;
      private string AV39TFLeaveTypeName ;
      private string AV50TFLeaveRequestStatus_Sel ;
      private string AV67Leaverequestwwds_6_tfleavetypename ;
      private string AV68Leaverequestwwds_7_tfleavetypename_sel ;
      private string scmdbuf ;
      private string lV67Leaverequestwwds_6_tfleavetypename ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV41TFLeaveRequestDate ;
      private DateTime AV42TFLeaveRequestDate_To ;
      private DateTime AV43TFLeaveRequestStartDate ;
      private DateTime AV44TFLeaveRequestStartDate_To ;
      private DateTime AV45TFLeaveRequestEndDate ;
      private DateTime AV46TFLeaveRequestEndDate_To ;
      private DateTime AV69Leaverequestwwds_8_tfleaverequestdate ;
      private DateTime AV70Leaverequestwwds_9_tfleaverequestdate_to ;
      private DateTime AV71Leaverequestwwds_10_tfleaverequeststartdate ;
      private DateTime AV72Leaverequestwwds_11_tfleaverequeststartdate_to ;
      private DateTime AV73Leaverequestwwds_12_tfleaverequestenddate ;
      private DateTime AV74Leaverequestwwds_13_tfleaverequestenddate_to ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV49TFLeaveRequestStatus_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV53TFLeaveRequestDescription_Sel ;
      private string AV52TFLeaveRequestDescription ;
      private string AV55TFLeaveRequestRejectionReason_Sel ;
      private string AV54TFLeaveRequestRejectionReason ;
      private string AV62Leaverequestwwds_1_filterfulltext ;
      private string AV78Leaverequestwwds_17_tfleaverequestdescription ;
      private string AV79Leaverequestwwds_18_tfleaverequestdescription_sel ;
      private string AV80Leaverequestwwds_19_tfleaverequestrejectionreason ;
      private string AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel ;
      private string lV62Leaverequestwwds_1_filterfulltext ;
      private string lV78Leaverequestwwds_17_tfleaverequestdescription ;
      private string lV80Leaverequestwwds_19_tfleaverequestrejectionreason ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008E2_A100CompanyId ;
      private long[] P008E2_A106EmployeeId ;
      private string[] P008E2_A134LeaveRequestRejectionReason ;
      private string[] P008E2_A133LeaveRequestDescription ;
      private short[] P008E2_A131LeaveRequestDuration ;
      private DateTime[] P008E2_A130LeaveRequestEndDate ;
      private DateTime[] P008E2_A129LeaveRequestStartDate ;
      private DateTime[] P008E2_A128LeaveRequestDate ;
      private string[] P008E2_A125LeaveTypeName ;
      private long[] P008E2_A124LeaveTypeId ;
      private long[] P008E2_A127LeaveRequestId ;
      private string[] P008E2_A132LeaveRequestStatus ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GxSimpleCollection<string> AV51TFLeaveRequestStatus_Sels ;
      private GxSimpleCollection<string> AV77Leaverequestwwds_16_tfleaverequeststatus_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
   }

   public class leaverequestwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008E2( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV77Leaverequestwwds_16_tfleaverequeststatus_sels ,
                                             string AV62Leaverequestwwds_1_filterfulltext ,
                                             long AV63Leaverequestwwds_2_tfleaverequestid ,
                                             long AV64Leaverequestwwds_3_tfleaverequestid_to ,
                                             long AV65Leaverequestwwds_4_tfleavetypeid ,
                                             long AV66Leaverequestwwds_5_tfleavetypeid_to ,
                                             string AV68Leaverequestwwds_7_tfleavetypename_sel ,
                                             string AV67Leaverequestwwds_6_tfleavetypename ,
                                             DateTime AV69Leaverequestwwds_8_tfleaverequestdate ,
                                             DateTime AV70Leaverequestwwds_9_tfleaverequestdate_to ,
                                             DateTime AV71Leaverequestwwds_10_tfleaverequeststartdate ,
                                             DateTime AV72Leaverequestwwds_11_tfleaverequeststartdate_to ,
                                             DateTime AV73Leaverequestwwds_12_tfleaverequestenddate ,
                                             DateTime AV74Leaverequestwwds_13_tfleaverequestenddate_to ,
                                             short AV75Leaverequestwwds_14_tfleaverequestduration ,
                                             short AV76Leaverequestwwds_15_tfleaverequestduration_to ,
                                             int AV77Leaverequestwwds_16_tfleaverequeststatus_sels_Count ,
                                             string AV79Leaverequestwwds_18_tfleaverequestdescription_sel ,
                                             string AV78Leaverequestwwds_17_tfleaverequestdescription ,
                                             string AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel ,
                                             string AV80Leaverequestwwds_19_tfleaverequestrejectionreason ,
                                             long AV82Leaverequestwwds_21_tfemployeeid ,
                                             long AV83Leaverequestwwds_22_tfemployeeid_to ,
                                             long A127LeaveRequestId ,
                                             long A124LeaveTypeId ,
                                             string A125LeaveTypeName ,
                                             short A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             long A106EmployeeId ,
                                             DateTime A128LeaveRequestDate ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             long A100CompanyId ,
                                             long AV84Udparg23 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[31];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDate, T2.LeaveTypeName, T1.LeaveTypeId, T1.LeaveRequestId, T1.LeaveRequestStatus FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T2.CompanyId = :AV84Udparg23)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.LeaveRequestId,'9999999999'), 2) like '%' || :lV62Leaverequestwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveTypeId,'9999999999'), 2) like '%' || :lV62Leaverequestwwds_1_filterfulltext) or ( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV62Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'9999'), 2) like '%' || :lV62Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV62Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV62Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV62Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV62Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV62Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Leaverequestwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
            GXv_int4[9] = 1;
            GXv_int4[10] = 1;
         }
         if ( ! (0==AV63Leaverequestwwds_2_tfleaverequestid) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestId >= :AV63Leaverequestwwds_2_tfleaverequestid)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (0==AV64Leaverequestwwds_3_tfleaverequestid_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestId <= :AV64Leaverequestwwds_3_tfleaverequestid_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (0==AV65Leaverequestwwds_4_tfleavetypeid) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId >= :AV65Leaverequestwwds_4_tfleavetypeid)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (0==AV66Leaverequestwwds_5_tfleavetypeid_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId <= :AV66Leaverequestwwds_5_tfleavetypeid_to)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestwwds_7_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestwwds_6_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV67Leaverequestwwds_6_tfleavetypename))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestwwds_7_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV68Leaverequestwwds_7_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV68Leaverequestwwds_7_tfleavetypename_sel))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV68Leaverequestwwds_7_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_8_tfleaverequestdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDate >= :AV69Leaverequestwwds_8_tfleaverequestdate)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Leaverequestwwds_9_tfleaverequestdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDate <= :AV70Leaverequestwwds_9_tfleaverequestdate_to)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Leaverequestwwds_10_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV71Leaverequestwwds_10_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV72Leaverequestwwds_11_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV72Leaverequestwwds_11_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Leaverequestwwds_12_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV73Leaverequestwwds_12_tfleaverequestenddate)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Leaverequestwwds_13_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV74Leaverequestwwds_13_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (0==AV75Leaverequestwwds_14_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV75Leaverequestwwds_14_tfleaverequestduration)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (0==AV76Leaverequestwwds_15_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV76Leaverequestwwds_15_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( AV77Leaverequestwwds_16_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Leaverequestwwds_16_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_18_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Leaverequestwwds_17_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV78Leaverequestwwds_17_tfleaverequestdescription))");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestwwds_18_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV79Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV79Leaverequestwwds_18_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV79Leaverequestwwds_18_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestwwds_19_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV80Leaverequestwwds_19_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( StringUtil.StrCmp(AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
         }
         if ( ! (0==AV82Leaverequestwwds_21_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV82Leaverequestwwds_21_tfemployeeid)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! (0==AV83Leaverequestwwds_22_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV83Leaverequestwwds_22_tfemployeeid_to)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestId";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestId DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveTypeId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveTypeId DESC";
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
            scmdbuf += " ORDER BY T1.LeaveRequestDate";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDate DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStartDate";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStartDate DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestEndDate";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestEndDate DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStatus";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStatus DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDescription DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestRejectionReason";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestRejectionReason DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeId DESC";
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
                     return conditional_P008E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] );
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
          Object[] prmP008E2;
          prmP008E2 = new Object[] {
          new ParDef("AV84Udparg23",GXType.Int64,10,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Leaverequestwwds_2_tfleaverequestid",GXType.Int64,10,0) ,
          new ParDef("AV64Leaverequestwwds_3_tfleaverequestid_to",GXType.Int64,10,0) ,
          new ParDef("AV65Leaverequestwwds_4_tfleavetypeid",GXType.Int64,10,0) ,
          new ParDef("AV66Leaverequestwwds_5_tfleavetypeid_to",GXType.Int64,10,0) ,
          new ParDef("lV67Leaverequestwwds_6_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV68Leaverequestwwds_7_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV69Leaverequestwwds_8_tfleaverequestdate",GXType.Date,8,0) ,
          new ParDef("AV70Leaverequestwwds_9_tfleaverequestdate_to",GXType.Date,8,0) ,
          new ParDef("AV71Leaverequestwwds_10_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV72Leaverequestwwds_11_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV73Leaverequestwwds_12_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV74Leaverequestwwds_13_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("AV75Leaverequestwwds_14_tfleaverequestduration",GXType.Int16,4,0) ,
          new ParDef("AV76Leaverequestwwds_15_tfleaverequestduration_to",GXType.Int16,4,0) ,
          new ParDef("lV78Leaverequestwwds_17_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV79Leaverequestwwds_18_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV80Leaverequestwwds_19_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV81Leaverequestwwds_20_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
          new ParDef("AV82Leaverequestwwds_21_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV83Leaverequestwwds_22_tfemployeeid_to",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                return;
       }
    }

 }

}
