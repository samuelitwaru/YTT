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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFLeaveTypeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Leave Type") ;
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
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Leave Type") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFLeaveTypeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFLeaveRequestHalfDay_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Half Day") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFLeaveRequestHalfDay_Sel)) ? "(Empty)" : AV60TFLeaveRequestHalfDay_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFLeaveRequestHalfDay)) && (0==AV63TFLeaveRequestHalfDayOperator) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Half Day") ;
               AV14CellRow = GXt_int2;
               if ( AV63TFLeaveRequestHalfDayOperator == 0 )
               {
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59TFLeaveRequestHalfDay, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
               else if ( AV63TFLeaveRequestHalfDayOperator == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Morning";
               }
               else if ( AV63TFLeaveRequestHalfDayOperator == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Afternoon";
               }
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV47TFLeaveRequestDuration) && (Convert.ToDecimal(0)==AV48TFLeaveRequestDuration_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Duration") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV47TFLeaveRequestDuration);
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV48TFLeaveRequestDuration_To);
         }
         if ( ! ( ( AV51TFLeaveRequestStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Status") ;
            AV14CellRow = GXt_int2;
            AV58i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV51TFLeaveRequestStatus_Sels.Count )
            {
               AV50TFLeaveRequestStatus_Sel = AV51TFLeaveRequestStatus_Sels.GetString(AV64GXV1);
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
               AV64GXV1 = (int)(AV64GXV1+1);
            }
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFLeaveRequestStatus)) && (0==AV62TFLeaveRequestStatusOperator) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Status") ;
               AV14CellRow = GXt_int2;
               if ( AV62TFLeaveRequestStatusOperator == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Pending";
               }
               else if ( AV62TFLeaveRequestStatusOperator == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Approved";
               }
               else if ( AV62TFLeaveRequestStatusOperator == 3 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Rejected";
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFLeaveRequestDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Description") ;
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
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Description") ;
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
         AV65GXV2 = 1;
         while ( AV65GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV65GXV2));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV65GXV2 = (int)(AV65GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV67Leaverequestwwds_1_filterfulltext = AV19FilterFullText;
         AV68Leaverequestwwds_2_tfleavetypename = AV39TFLeaveTypeName;
         AV69Leaverequestwwds_3_tfleavetypename_sel = AV40TFLeaveTypeName_Sel;
         AV70Leaverequestwwds_4_tfleaverequeststartdate = AV43TFLeaveRequestStartDate;
         AV71Leaverequestwwds_5_tfleaverequeststartdate_to = AV44TFLeaveRequestStartDate_To;
         AV72Leaverequestwwds_6_tfleaverequestenddate = AV45TFLeaveRequestEndDate;
         AV73Leaverequestwwds_7_tfleaverequestenddate_to = AV46TFLeaveRequestEndDate_To;
         AV74Leaverequestwwds_8_tfleaverequesthalfday = AV59TFLeaveRequestHalfDay;
         AV75Leaverequestwwds_9_tfleaverequesthalfdayoperator = AV63TFLeaveRequestHalfDayOperator;
         AV76Leaverequestwwds_10_tfleaverequesthalfday_sel = AV60TFLeaveRequestHalfDay_Sel;
         AV77Leaverequestwwds_11_tfleaverequestduration = AV47TFLeaveRequestDuration;
         AV78Leaverequestwwds_12_tfleaverequestduration_to = AV48TFLeaveRequestDuration_To;
         AV79Leaverequestwwds_13_tfleaverequeststatus = AV61TFLeaveRequestStatus;
         AV80Leaverequestwwds_14_tfleaverequeststatusoperator = AV62TFLeaveRequestStatusOperator;
         AV81Leaverequestwwds_15_tfleaverequeststatus_sels = AV51TFLeaveRequestStatus_Sels;
         AV82Leaverequestwwds_16_tfleaverequestdescription = AV52TFLeaveRequestDescription;
         AV83Leaverequestwwds_17_tfleaverequestdescription_sel = AV53TFLeaveRequestDescription_Sel;
         AV84Leaverequestwwds_18_tfleaverequestrejectionreason = AV54TFLeaveRequestRejectionReason;
         AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel = AV55TFLeaveRequestRejectionReason_Sel;
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV86Udparg20 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg21 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV81Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                              AV67Leaverequestwwds_1_filterfulltext ,
                                              AV69Leaverequestwwds_3_tfleavetypename_sel ,
                                              AV68Leaverequestwwds_2_tfleavetypename ,
                                              AV70Leaverequestwwds_4_tfleaverequeststartdate ,
                                              AV71Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                              AV72Leaverequestwwds_6_tfleaverequestenddate ,
                                              AV73Leaverequestwwds_7_tfleaverequestenddate_to ,
                                              AV76Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                              AV74Leaverequestwwds_8_tfleaverequesthalfday ,
                                              AV75Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                              AV77Leaverequestwwds_11_tfleaverequestduration ,
                                              AV78Leaverequestwwds_12_tfleaverequestduration_to ,
                                              AV81Leaverequestwwds_15_tfleaverequeststatus_sels.Count ,
                                              AV80Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                              AV83Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                              AV82Leaverequestwwds_16_tfleaverequestdescription ,
                                              AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                              AV84Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A173LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A100CompanyId ,
                                              AV86Udparg20 ,
                                              AV87Udparg21 ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV67Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext), "%", "");
         lV67Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext), "%", "");
         lV67Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext), "%", "");
         lV67Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext), "%", "");
         lV67Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext), "%", "");
         lV67Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext), "%", "");
         lV67Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext), "%", "");
         lV67Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext), "%", "");
         lV68Leaverequestwwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV68Leaverequestwwds_2_tfleavetypename), 100, "%");
         lV74Leaverequestwwds_8_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV74Leaverequestwwds_8_tfleaverequesthalfday), 20, "%");
         lV82Leaverequestwwds_16_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV82Leaverequestwwds_16_tfleaverequestdescription), "%", "");
         lV84Leaverequestwwds_18_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV84Leaverequestwwds_18_tfleaverequestrejectionreason), "%", "");
         /* Using cursor P008E2 */
         pr_default.execute(0, new Object[] {AV87Udparg21, AV86Udparg20, lV67Leaverequestwwds_1_filterfulltext, lV67Leaverequestwwds_1_filterfulltext, lV67Leaverequestwwds_1_filterfulltext, lV67Leaverequestwwds_1_filterfulltext, lV67Leaverequestwwds_1_filterfulltext, lV67Leaverequestwwds_1_filterfulltext, lV67Leaverequestwwds_1_filterfulltext, lV67Leaverequestwwds_1_filterfulltext, lV68Leaverequestwwds_2_tfleavetypename, AV69Leaverequestwwds_3_tfleavetypename_sel, AV70Leaverequestwwds_4_tfleaverequeststartdate, AV71Leaverequestwwds_5_tfleaverequeststartdate_to, AV72Leaverequestwwds_6_tfleaverequestenddate, AV73Leaverequestwwds_7_tfleaverequestenddate_to, lV74Leaverequestwwds_8_tfleaverequesthalfday, AV76Leaverequestwwds_10_tfleaverequesthalfday_sel, AV77Leaverequestwwds_11_tfleaverequestduration, AV78Leaverequestwwds_12_tfleaverequestduration_to, lV82Leaverequestwwds_16_tfleaverequestdescription, AV83Leaverequestwwds_17_tfleaverequestdescription_sel, lV84Leaverequestwwds_18_tfleaverequestrejectionreason, AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P008E2_A124LeaveTypeId[0];
            A106EmployeeId = P008E2_A106EmployeeId[0];
            A100CompanyId = P008E2_A100CompanyId[0];
            A134LeaveRequestRejectionReason = P008E2_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = P008E2_A133LeaveRequestDescription[0];
            A131LeaveRequestDuration = P008E2_A131LeaveRequestDuration[0];
            A173LeaveRequestHalfDay = P008E2_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P008E2_n173LeaveRequestHalfDay[0];
            A130LeaveRequestEndDate = P008E2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008E2_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P008E2_A125LeaveTypeName[0];
            A132LeaveRequestStatus = P008E2_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P008E2_A127LeaveRequestId[0];
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
            AV88GXV3 = 1;
            while ( AV88GXV3 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV88GXV3));
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
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestStatus") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = gxdomainleaverequeststatusdomain.getDescription(context,A132LeaveRequestStatus);
                     if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                     }
                     else if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Approved") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                     }
                     else if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Rejected") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                     }
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
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV88GXV3 = (int)(AV88GXV3+1);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeName",  "",  "Leave Type",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestStartDate",  "",  "Start Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestEndDate",  "",  "End Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestHalfDay",  "",  "Half Day",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDuration",  "",  "Duration",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestStatus",  "",  "Status",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDescription",  "",  "Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestRejectionReason",  "",  "Rejection Reason",  true,  "") ;
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
         AV89GXV4 = 1;
         while ( AV89GXV4 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV89GXV4));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV39TFLeaveTypeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV40TFLeaveTypeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
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
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV63TFLeaveRequestHalfDayOperator = AV23GridStateFilterValue.gxTpr_Operator;
               if ( AV63TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV59TFLeaveRequestHalfDay = AV23GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV60TFLeaveRequestHalfDay_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV47TFLeaveRequestDuration = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV48TFLeaveRequestDuration_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS") == 0 )
            {
               AV62TFLeaveRequestStatusOperator = AV23GridStateFilterValue.gxTpr_Operator;
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
            AV89GXV4 = (int)(AV89GXV4+1);
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
         AV43TFLeaveRequestStartDate = DateTime.MinValue;
         AV44TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV45TFLeaveRequestEndDate = DateTime.MinValue;
         AV46TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV60TFLeaveRequestHalfDay_Sel = "";
         AV59TFLeaveRequestHalfDay = "";
         AV51TFLeaveRequestStatus_Sels = new GxSimpleCollection<string>();
         AV50TFLeaveRequestStatus_Sel = "";
         AV61TFLeaveRequestStatus = "";
         AV53TFLeaveRequestDescription_Sel = "";
         AV52TFLeaveRequestDescription = "";
         AV55TFLeaveRequestRejectionReason_Sel = "";
         AV54TFLeaveRequestRejectionReason = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV67Leaverequestwwds_1_filterfulltext = "";
         AV68Leaverequestwwds_2_tfleavetypename = "";
         AV69Leaverequestwwds_3_tfleavetypename_sel = "";
         AV70Leaverequestwwds_4_tfleaverequeststartdate = DateTime.MinValue;
         AV71Leaverequestwwds_5_tfleaverequeststartdate_to = DateTime.MinValue;
         AV72Leaverequestwwds_6_tfleaverequestenddate = DateTime.MinValue;
         AV73Leaverequestwwds_7_tfleaverequestenddate_to = DateTime.MinValue;
         AV74Leaverequestwwds_8_tfleaverequesthalfday = "";
         AV76Leaverequestwwds_10_tfleaverequesthalfday_sel = "";
         AV79Leaverequestwwds_13_tfleaverequeststatus = "";
         AV81Leaverequestwwds_15_tfleaverequeststatus_sels = new GxSimpleCollection<string>();
         AV82Leaverequestwwds_16_tfleaverequestdescription = "";
         AV83Leaverequestwwds_17_tfleaverequestdescription_sel = "";
         AV84Leaverequestwwds_18_tfleaverequestrejectionreason = "";
         AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel = "";
         scmdbuf = "";
         lV67Leaverequestwwds_1_filterfulltext = "";
         lV68Leaverequestwwds_2_tfleavetypename = "";
         lV74Leaverequestwwds_8_tfleaverequesthalfday = "";
         lV82Leaverequestwwds_16_tfleaverequestdescription = "";
         lV84Leaverequestwwds_18_tfleaverequestrejectionreason = "";
         A132LeaveRequestStatus = "";
         A125LeaveTypeName = "";
         A173LeaveRequestHalfDay = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P008E2_A124LeaveTypeId = new long[1] ;
         P008E2_A106EmployeeId = new long[1] ;
         P008E2_A100CompanyId = new long[1] ;
         P008E2_A134LeaveRequestRejectionReason = new string[] {""} ;
         P008E2_A133LeaveRequestDescription = new string[] {""} ;
         P008E2_A131LeaveRequestDuration = new decimal[1] ;
         P008E2_A173LeaveRequestHalfDay = new string[] {""} ;
         P008E2_n173LeaveRequestHalfDay = new bool[] {false} ;
         P008E2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008E2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008E2_A125LeaveTypeName = new string[] {""} ;
         P008E2_A132LeaveRequestStatus = new string[] {""} ;
         P008E2_A127LeaveRequestId = new long[1] ;
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
               P008E2_A124LeaveTypeId, P008E2_A106EmployeeId, P008E2_A100CompanyId, P008E2_A134LeaveRequestRejectionReason, P008E2_A133LeaveRequestDescription, P008E2_A131LeaveRequestDuration, P008E2_A173LeaveRequestHalfDay, P008E2_n173LeaveRequestHalfDay, P008E2_A130LeaveRequestEndDate, P008E2_A129LeaveRequestStartDate,
               P008E2_A125LeaveTypeName, P008E2_A132LeaveRequestStatus, P008E2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV63TFLeaveRequestHalfDayOperator ;
      private short AV62TFLeaveRequestStatusOperator ;
      private short GXt_int2 ;
      private short AV75Leaverequestwwds_9_tfleaverequesthalfdayoperator ;
      private short AV80Leaverequestwwds_14_tfleaverequeststatusoperator ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV64GXV1 ;
      private int AV65GXV2 ;
      private int AV81Leaverequestwwds_15_tfleaverequeststatus_sels_Count ;
      private int AV88GXV3 ;
      private int AV89GXV4 ;
      private long AV58i ;
      private long AV32VisibleColumnCount ;
      private long AV86Udparg20 ;
      private long AV87Udparg21 ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private decimal AV47TFLeaveRequestDuration ;
      private decimal AV48TFLeaveRequestDuration_To ;
      private decimal AV77Leaverequestwwds_11_tfleaverequestduration ;
      private decimal AV78Leaverequestwwds_12_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV40TFLeaveTypeName_Sel ;
      private string AV39TFLeaveTypeName ;
      private string AV60TFLeaveRequestHalfDay_Sel ;
      private string AV59TFLeaveRequestHalfDay ;
      private string AV50TFLeaveRequestStatus_Sel ;
      private string AV61TFLeaveRequestStatus ;
      private string AV68Leaverequestwwds_2_tfleavetypename ;
      private string AV69Leaverequestwwds_3_tfleavetypename_sel ;
      private string AV74Leaverequestwwds_8_tfleaverequesthalfday ;
      private string AV76Leaverequestwwds_10_tfleaverequesthalfday_sel ;
      private string AV79Leaverequestwwds_13_tfleaverequeststatus ;
      private string scmdbuf ;
      private string lV68Leaverequestwwds_2_tfleavetypename ;
      private string lV74Leaverequestwwds_8_tfleaverequesthalfday ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private string A173LeaveRequestHalfDay ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV43TFLeaveRequestStartDate ;
      private DateTime AV44TFLeaveRequestStartDate_To ;
      private DateTime AV45TFLeaveRequestEndDate ;
      private DateTime AV46TFLeaveRequestEndDate_To ;
      private DateTime AV70Leaverequestwwds_4_tfleaverequeststartdate ;
      private DateTime AV71Leaverequestwwds_5_tfleaverequeststartdate_to ;
      private DateTime AV72Leaverequestwwds_6_tfleaverequestenddate ;
      private DateTime AV73Leaverequestwwds_7_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n173LeaveRequestHalfDay ;
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
      private string AV67Leaverequestwwds_1_filterfulltext ;
      private string AV82Leaverequestwwds_16_tfleaverequestdescription ;
      private string AV83Leaverequestwwds_17_tfleaverequestdescription_sel ;
      private string AV84Leaverequestwwds_18_tfleaverequestrejectionreason ;
      private string AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel ;
      private string lV67Leaverequestwwds_1_filterfulltext ;
      private string lV82Leaverequestwwds_16_tfleaverequestdescription ;
      private string lV84Leaverequestwwds_18_tfleaverequestrejectionreason ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008E2_A124LeaveTypeId ;
      private long[] P008E2_A106EmployeeId ;
      private long[] P008E2_A100CompanyId ;
      private string[] P008E2_A134LeaveRequestRejectionReason ;
      private string[] P008E2_A133LeaveRequestDescription ;
      private decimal[] P008E2_A131LeaveRequestDuration ;
      private string[] P008E2_A173LeaveRequestHalfDay ;
      private bool[] P008E2_n173LeaveRequestHalfDay ;
      private DateTime[] P008E2_A130LeaveRequestEndDate ;
      private DateTime[] P008E2_A129LeaveRequestStartDate ;
      private string[] P008E2_A125LeaveTypeName ;
      private string[] P008E2_A132LeaveRequestStatus ;
      private long[] P008E2_A127LeaveRequestId ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GxSimpleCollection<string> AV51TFLeaveRequestStatus_Sels ;
      private GxSimpleCollection<string> AV81Leaverequestwwds_15_tfleaverequeststatus_sels ;
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
                                             GxSimpleCollection<string> AV81Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                             string AV67Leaverequestwwds_1_filterfulltext ,
                                             string AV69Leaverequestwwds_3_tfleavetypename_sel ,
                                             string AV68Leaverequestwwds_2_tfleavetypename ,
                                             DateTime AV70Leaverequestwwds_4_tfleaverequeststartdate ,
                                             DateTime AV71Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                             DateTime AV72Leaverequestwwds_6_tfleaverequestenddate ,
                                             DateTime AV73Leaverequestwwds_7_tfleaverequestenddate_to ,
                                             string AV76Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                             string AV74Leaverequestwwds_8_tfleaverequesthalfday ,
                                             short AV75Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                             decimal AV77Leaverequestwwds_11_tfleaverequestduration ,
                                             decimal AV78Leaverequestwwds_12_tfleaverequestduration_to ,
                                             int AV81Leaverequestwwds_15_tfleaverequeststatus_sels_Count ,
                                             short AV80Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                             string AV83Leaverequestwwds_17_tfleaverequestdescription_sel ,
                                             string AV82Leaverequestwwds_16_tfleaverequestdescription ,
                                             string AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel ,
                                             string AV84Leaverequestwwds_18_tfleaverequestrejectionreason ,
                                             string A125LeaveTypeName ,
                                             string A173LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             string A134LeaveRequestRejectionReason ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             long A100CompanyId ,
                                             long AV86Udparg20 ,
                                             long AV87Udparg21 ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[24];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T1.LeaveRequestStatus, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV87Udparg21)");
         AddWhere(sWhereString, "(T2.CompanyId = :AV86Udparg20)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.LeaveTypeName) like '%' || LOWER(:lV67Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestHalfDay) like '%' || LOWER(:lV67Leaverequestwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV67Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV67Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV67Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV67Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( LOWER(T1.LeaveRequestDescription) like '%' || LOWER(:lV67Leaverequestwwds_1_filterfulltext)) or ( LOWER(T1.LeaveRequestRejectionReason) like '%' || LOWER(:lV67Leaverequestwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
            GXv_int4[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestwwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestwwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.LeaveTypeName) like LOWER(:lV68Leaverequestwwds_2_tfleavetypename))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestwwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV69Leaverequestwwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV70Leaverequestwwds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV70Leaverequestwwds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Leaverequestwwds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV71Leaverequestwwds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV72Leaverequestwwds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV72Leaverequestwwds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Leaverequestwwds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV73Leaverequestwwds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestwwds_8_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestHalfDay) like LOWER(:lV74Leaverequestwwds_8_tfleaverequesthalfday))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV76Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV76Leaverequestwwds_10_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV75Leaverequestwwds_9_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV75Leaverequestwwds_9_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV77Leaverequestwwds_11_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV77Leaverequestwwds_11_tfleaverequestduration)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV78Leaverequestwwds_12_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV78Leaverequestwwds_12_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV81Leaverequestwwds_15_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV81Leaverequestwwds_15_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV80Leaverequestwwds_14_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV80Leaverequestwwds_14_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV80Leaverequestwwds_14_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Leaverequestwwds_17_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Leaverequestwwds_16_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestDescription) like LOWER(:lV82Leaverequestwwds_16_tfleaverequestdescription))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Leaverequestwwds_17_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV83Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV83Leaverequestwwds_17_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV83Leaverequestwwds_17_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Leaverequestwwds_18_tfleaverequestrejectionreason)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.LeaveRequestRejectionReason) like LOWER(:lV84Leaverequestwwds_18_tfleaverequestrejectionreason))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel))");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
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
            scmdbuf += " ORDER BY T1.LeaveRequestHalfDay";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestHalfDay DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStatus";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStatus DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDescription DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestRejectionReason";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestRejectionReason DESC";
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
                     return conditional_P008E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
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
          new ParDef("AV87Udparg21",GXType.Int64,10,0) ,
          new ParDef("AV86Udparg20",GXType.Int64,10,0) ,
          new ParDef("lV67Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Leaverequestwwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV69Leaverequestwwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV70Leaverequestwwds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV71Leaverequestwwds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV72Leaverequestwwds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV73Leaverequestwwds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV74Leaverequestwwds_8_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV76Leaverequestwwds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV77Leaverequestwwds_11_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV78Leaverequestwwds_12_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV82Leaverequestwwds_16_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV83Leaverequestwwds_17_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV84Leaverequestwwds_18_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
          new ParDef("AV85Leaverequestwwds_19_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
