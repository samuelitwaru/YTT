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
   public class wp_downloadappexport : GXProcedure
   {
      public wp_downloadappexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_downloadappexport( IGxContext context )
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
         ExecuteImpl();
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
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV14CellRow = 1;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S201 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S161 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
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
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV12Filename = GXt_char1 + "WP_DownloadAppExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFEmployeeId) && (0==AV36TFEmployeeId_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Id") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFEmployeeId;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFEmployeeId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmployeeFirstName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "First Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmployeeFirstName_Sel)) ? "(Empty)" : AV38TFEmployeeFirstName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEmployeeFirstName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "First Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFEmployeeFirstName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFEmployeeLastName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Last Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFEmployeeLastName_Sel)) ? "(Empty)" : AV40TFEmployeeLastName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFEmployeeLastName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Last Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFEmployeeLastName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEmployeeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEmployeeName_Sel)) ? "(Empty)" : AV42TFEmployeeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEmployeeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFEmployeeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFEmployeeEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Email") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV44TFEmployeeEmail_Sel)) ? "(Empty)" : AV44TFEmployeeEmail_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFEmployeeEmail)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Email") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFEmployeeEmail, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV45TFCompanyId) && (0==AV46TFCompanyId_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Id") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV45TFCompanyId;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV46TFCompanyId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCompanyName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCompanyName_Sel)) ? "(Empty)" : AV48TFCompanyName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCompanyName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFCompanyName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV49TFEmployeeIsManager_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is Manager") ;
            AV14CellRow = GXt_int2;
            if ( AV49TFEmployeeIsManager_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV49TFEmployeeIsManager_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Unchecked";
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFGAMUserGUID_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "GUID") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFGAMUserGUID_Sel)) ? "(Empty)" : AV51TFGAMUserGUID_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFGAMUserGUID)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "GUID") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TFGAMUserGUID, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV52TFEmployeeIsActive_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is Active") ;
            AV14CellRow = GXt_int2;
            if ( AV52TFEmployeeIsActive_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV52TFEmployeeIsActive_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Unchecked";
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV53TFEmployeeVactionDays) && (Convert.ToDecimal(0)==AV54TFEmployeeVactionDays_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Vacation Days") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV53TFEmployeeVactionDays);
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV54TFEmployeeVactionDays_To);
         }
         if ( ! ( (DateTime.MinValue==AV55TFEmployeeVacationDaysSetDate) && (DateTime.MinValue==AV56TFEmployeeVacationDaysSetDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Set Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV55TFEmployeeVacationDaysSetDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV56TFEmployeeVacationDaysSetDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFEmployeeAPIPassword_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "APIPassword") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFEmployeeAPIPassword_Sel)) ? "(Empty)" : AV58TFEmployeeAPIPassword_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFEmployeeAPIPassword)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "APIPassword") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFEmployeeAPIPassword, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV59TFEmployeeBalance) && (Convert.ToDecimal(0)==AV60TFEmployeeBalance_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Balance") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV59TFEmployeeBalance);
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV60TFEmployeeBalance_To);
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("WP_DownloadAppColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("WP_DownloadAppColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV62GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV64Wp_downloadappds_1_filterfulltext = AV19FilterFullText;
         AV65Wp_downloadappds_2_tfemployeeid = AV35TFEmployeeId;
         AV66Wp_downloadappds_3_tfemployeeid_to = AV36TFEmployeeId_To;
         AV67Wp_downloadappds_4_tfemployeefirstname = AV37TFEmployeeFirstName;
         AV68Wp_downloadappds_5_tfemployeefirstname_sel = AV38TFEmployeeFirstName_Sel;
         AV69Wp_downloadappds_6_tfemployeelastname = AV39TFEmployeeLastName;
         AV70Wp_downloadappds_7_tfemployeelastname_sel = AV40TFEmployeeLastName_Sel;
         AV71Wp_downloadappds_8_tfemployeename = AV41TFEmployeeName;
         AV72Wp_downloadappds_9_tfemployeename_sel = AV42TFEmployeeName_Sel;
         AV73Wp_downloadappds_10_tfemployeeemail = AV43TFEmployeeEmail;
         AV74Wp_downloadappds_11_tfemployeeemail_sel = AV44TFEmployeeEmail_Sel;
         AV75Wp_downloadappds_12_tfcompanyid = AV45TFCompanyId;
         AV76Wp_downloadappds_13_tfcompanyid_to = AV46TFCompanyId_To;
         AV77Wp_downloadappds_14_tfcompanyname = AV47TFCompanyName;
         AV78Wp_downloadappds_15_tfcompanyname_sel = AV48TFCompanyName_Sel;
         AV79Wp_downloadappds_16_tfemployeeismanager_sel = AV49TFEmployeeIsManager_Sel;
         AV80Wp_downloadappds_17_tfgamuserguid = AV50TFGAMUserGUID;
         AV81Wp_downloadappds_18_tfgamuserguid_sel = AV51TFGAMUserGUID_Sel;
         AV82Wp_downloadappds_19_tfemployeeisactive_sel = AV52TFEmployeeIsActive_Sel;
         AV83Wp_downloadappds_20_tfemployeevactiondays = AV53TFEmployeeVactionDays;
         AV84Wp_downloadappds_21_tfemployeevactiondays_to = AV54TFEmployeeVactionDays_To;
         AV85Wp_downloadappds_22_tfemployeevacationdayssetdate = AV55TFEmployeeVacationDaysSetDate;
         AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to = AV56TFEmployeeVacationDaysSetDate_To;
         AV87Wp_downloadappds_24_tfemployeeapipassword = AV57TFEmployeeAPIPassword;
         AV88Wp_downloadappds_25_tfemployeeapipassword_sel = AV58TFEmployeeAPIPassword_Sel;
         AV89Wp_downloadappds_26_tfemployeebalance = AV59TFEmployeeBalance;
         AV90Wp_downloadappds_27_tfemployeebalance_to = AV60TFEmployeeBalance_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV64Wp_downloadappds_1_filterfulltext ,
                                              AV65Wp_downloadappds_2_tfemployeeid ,
                                              AV66Wp_downloadappds_3_tfemployeeid_to ,
                                              AV68Wp_downloadappds_5_tfemployeefirstname_sel ,
                                              AV67Wp_downloadappds_4_tfemployeefirstname ,
                                              AV70Wp_downloadappds_7_tfemployeelastname_sel ,
                                              AV69Wp_downloadappds_6_tfemployeelastname ,
                                              AV72Wp_downloadappds_9_tfemployeename_sel ,
                                              AV71Wp_downloadappds_8_tfemployeename ,
                                              AV74Wp_downloadappds_11_tfemployeeemail_sel ,
                                              AV73Wp_downloadappds_10_tfemployeeemail ,
                                              AV75Wp_downloadappds_12_tfcompanyid ,
                                              AV76Wp_downloadappds_13_tfcompanyid_to ,
                                              AV78Wp_downloadappds_15_tfcompanyname_sel ,
                                              AV77Wp_downloadappds_14_tfcompanyname ,
                                              AV79Wp_downloadappds_16_tfemployeeismanager_sel ,
                                              AV81Wp_downloadappds_18_tfgamuserguid_sel ,
                                              AV80Wp_downloadappds_17_tfgamuserguid ,
                                              AV82Wp_downloadappds_19_tfemployeeisactive_sel ,
                                              AV83Wp_downloadappds_20_tfemployeevactiondays ,
                                              AV84Wp_downloadappds_21_tfemployeevactiondays_to ,
                                              AV85Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                              AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                              AV88Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                              AV87Wp_downloadappds_24_tfemployeeapipassword ,
                                              AV89Wp_downloadappds_26_tfemployeebalance ,
                                              AV90Wp_downloadappds_27_tfemployeebalance_to ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A108EmployeeLastName ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A100CompanyId ,
                                              A101CompanyName ,
                                              A111GAMUserGUID ,
                                              A146EmployeeVactionDays ,
                                              A188EmployeeAPIPassword ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A178EmployeeVacationDaysSetDate ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV64Wp_downloadappds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext), "%", "");
         lV67Wp_downloadappds_4_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV67Wp_downloadappds_4_tfemployeefirstname), 100, "%");
         lV69Wp_downloadappds_6_tfemployeelastname = StringUtil.PadR( StringUtil.RTrim( AV69Wp_downloadappds_6_tfemployeelastname), 100, "%");
         lV71Wp_downloadappds_8_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV71Wp_downloadappds_8_tfemployeename), 100, "%");
         lV73Wp_downloadappds_10_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV73Wp_downloadappds_10_tfemployeeemail), "%", "");
         lV77Wp_downloadappds_14_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV77Wp_downloadappds_14_tfcompanyname), 100, "%");
         lV80Wp_downloadappds_17_tfgamuserguid = StringUtil.Concat( StringUtil.RTrim( AV80Wp_downloadappds_17_tfgamuserguid), "%", "");
         lV87Wp_downloadappds_24_tfemployeeapipassword = StringUtil.Concat( StringUtil.RTrim( AV87Wp_downloadappds_24_tfemployeeapipassword), "%", "");
         /* Using cursor P00CK2 */
         pr_default.execute(0, new Object[] {lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, lV64Wp_downloadappds_1_filterfulltext, AV65Wp_downloadappds_2_tfemployeeid, AV66Wp_downloadappds_3_tfemployeeid_to, lV67Wp_downloadappds_4_tfemployeefirstname, AV68Wp_downloadappds_5_tfemployeefirstname_sel, lV69Wp_downloadappds_6_tfemployeelastname, AV70Wp_downloadappds_7_tfemployeelastname_sel, lV71Wp_downloadappds_8_tfemployeename, AV72Wp_downloadappds_9_tfemployeename_sel, lV73Wp_downloadappds_10_tfemployeeemail, AV74Wp_downloadappds_11_tfemployeeemail_sel, AV75Wp_downloadappds_12_tfcompanyid, AV76Wp_downloadappds_13_tfcompanyid_to, lV77Wp_downloadappds_14_tfcompanyname, AV78Wp_downloadappds_15_tfcompanyname_sel, lV80Wp_downloadappds_17_tfgamuserguid, AV81Wp_downloadappds_18_tfgamuserguid_sel, AV83Wp_downloadappds_20_tfemployeevactiondays, AV84Wp_downloadappds_21_tfemployeevactiondays_to, AV85Wp_downloadappds_22_tfemployeevacationdayssetdate, AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to, lV87Wp_downloadappds_24_tfemployeeapipassword, AV88Wp_downloadappds_25_tfemployeeapipassword_sel, AV89Wp_downloadappds_26_tfemployeebalance, AV90Wp_downloadappds_27_tfemployeebalance_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A147EmployeeBalance = P00CK2_A147EmployeeBalance[0];
            A188EmployeeAPIPassword = P00CK2_A188EmployeeAPIPassword[0];
            A178EmployeeVacationDaysSetDate = P00CK2_A178EmployeeVacationDaysSetDate[0];
            A146EmployeeVactionDays = P00CK2_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P00CK2_A112EmployeeIsActive[0];
            A111GAMUserGUID = P00CK2_A111GAMUserGUID[0];
            A110EmployeeIsManager = P00CK2_A110EmployeeIsManager[0];
            A101CompanyName = P00CK2_A101CompanyName[0];
            A100CompanyId = P00CK2_A100CompanyId[0];
            A109EmployeeEmail = P00CK2_A109EmployeeEmail[0];
            A148EmployeeName = P00CK2_A148EmployeeName[0];
            A108EmployeeLastName = P00CK2_A108EmployeeLastName[0];
            A107EmployeeFirstName = P00CK2_A107EmployeeFirstName[0];
            A106EmployeeId = P00CK2_A106EmployeeId[0];
            A101CompanyName = P00CK2_A101CompanyName[0];
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
            AV91GXV2 = 1;
            while ( AV91GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV91GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A106EmployeeId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeFirstName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A107EmployeeFirstName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeLastName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A108EmployeeLastName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A148EmployeeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeEmail") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A109EmployeeEmail, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "CompanyId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A100CompanyId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "CompanyName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A101CompanyName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeIsManager") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A110EmployeeIsManager);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "GAMUserGUID") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A111GAMUserGUID, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeIsActive") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A112EmployeeIsActive);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeVactionDays") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A146EmployeeVactionDays);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeVacationDaysSetDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A178EmployeeVacationDaysSetDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeAPIPassword") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A188EmployeeAPIPassword, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeBalance") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A147EmployeeBalance);
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV91GXV2 = (int)(AV91GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "WP_DownloadAppExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeFirstName",  "",  "First Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeLastName",  "",  "Last Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeName",  "",  "Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "CompanyId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "CompanyName",  "",  "Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeIsManager",  "",  "Is Manager",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "GAMUserGUID",  "",  "GUID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeIsActive",  "",  "Is Active",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeVactionDays",  "",  "Vacation Days",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeVacationDaysSetDate",  "",  "Set Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeAPIPassword",  "",  "APIPassword",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeBalance",  "",  "Balance",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WP_DownloadAppColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("WP_DownloadAppGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WP_DownloadAppGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("WP_DownloadAppGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV92GXV3 = 1;
         while ( AV92GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV92GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEID") == 0 )
            {
               AV35TFEmployeeId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME") == 0 )
            {
               AV37TFEmployeeFirstName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME_SEL") == 0 )
            {
               AV38TFEmployeeFirstName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEELASTNAME") == 0 )
            {
               AV39TFEmployeeLastName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEELASTNAME_SEL") == 0 )
            {
               AV40TFEmployeeLastName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV41TFEmployeeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV42TFEmployeeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV43TFEmployeeEmail = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV44TFEmployeeEmail_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCOMPANYID") == 0 )
            {
               AV45TFCompanyId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV46TFCompanyId_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME") == 0 )
            {
               AV47TFCompanyName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME_SEL") == 0 )
            {
               AV48TFCompanyName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV49TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFGAMUSERGUID") == 0 )
            {
               AV50TFGAMUserGUID = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFGAMUSERGUID_SEL") == 0 )
            {
               AV51TFGAMUserGUID_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV52TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEVACTIONDAYS") == 0 )
            {
               AV53TFEmployeeVactionDays = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV54TFEmployeeVactionDays_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEVACATIONDAYSSETDATE") == 0 )
            {
               AV55TFEmployeeVacationDaysSetDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV56TFEmployeeVacationDaysSetDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEAPIPASSWORD") == 0 )
            {
               AV57TFEmployeeAPIPassword = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEAPIPASSWORD_SEL") == 0 )
            {
               AV58TFEmployeeAPIPassword_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEBALANCE") == 0 )
            {
               AV59TFEmployeeBalance = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV60TFEmployeeBalance_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV92GXV3 = (int)(AV92GXV3+1);
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
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV38TFEmployeeFirstName_Sel = "";
         AV37TFEmployeeFirstName = "";
         AV40TFEmployeeLastName_Sel = "";
         AV39TFEmployeeLastName = "";
         AV42TFEmployeeName_Sel = "";
         AV41TFEmployeeName = "";
         AV44TFEmployeeEmail_Sel = "";
         AV43TFEmployeeEmail = "";
         AV48TFCompanyName_Sel = "";
         AV47TFCompanyName = "";
         AV51TFGAMUserGUID_Sel = "";
         AV50TFGAMUserGUID = "";
         AV55TFEmployeeVacationDaysSetDate = DateTime.MinValue;
         AV56TFEmployeeVacationDaysSetDate_To = DateTime.MinValue;
         AV58TFEmployeeAPIPassword_Sel = "";
         AV57TFEmployeeAPIPassword = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV64Wp_downloadappds_1_filterfulltext = "";
         AV67Wp_downloadappds_4_tfemployeefirstname = "";
         AV68Wp_downloadappds_5_tfemployeefirstname_sel = "";
         AV69Wp_downloadappds_6_tfemployeelastname = "";
         AV70Wp_downloadappds_7_tfemployeelastname_sel = "";
         AV71Wp_downloadappds_8_tfemployeename = "";
         AV72Wp_downloadappds_9_tfemployeename_sel = "";
         AV73Wp_downloadappds_10_tfemployeeemail = "";
         AV74Wp_downloadappds_11_tfemployeeemail_sel = "";
         AV77Wp_downloadappds_14_tfcompanyname = "";
         AV78Wp_downloadappds_15_tfcompanyname_sel = "";
         AV80Wp_downloadappds_17_tfgamuserguid = "";
         AV81Wp_downloadappds_18_tfgamuserguid_sel = "";
         AV85Wp_downloadappds_22_tfemployeevacationdayssetdate = DateTime.MinValue;
         AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to = DateTime.MinValue;
         AV87Wp_downloadappds_24_tfemployeeapipassword = "";
         AV88Wp_downloadappds_25_tfemployeeapipassword_sel = "";
         lV64Wp_downloadappds_1_filterfulltext = "";
         lV67Wp_downloadappds_4_tfemployeefirstname = "";
         lV69Wp_downloadappds_6_tfemployeelastname = "";
         lV71Wp_downloadappds_8_tfemployeename = "";
         lV73Wp_downloadappds_10_tfemployeeemail = "";
         lV77Wp_downloadappds_14_tfcompanyname = "";
         lV80Wp_downloadappds_17_tfgamuserguid = "";
         lV87Wp_downloadappds_24_tfemployeeapipassword = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         A111GAMUserGUID = "";
         A188EmployeeAPIPassword = "";
         A178EmployeeVacationDaysSetDate = DateTime.MinValue;
         P00CK2_A147EmployeeBalance = new decimal[1] ;
         P00CK2_A188EmployeeAPIPassword = new string[] {""} ;
         P00CK2_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00CK2_A146EmployeeVactionDays = new decimal[1] ;
         P00CK2_A112EmployeeIsActive = new bool[] {false} ;
         P00CK2_A111GAMUserGUID = new string[] {""} ;
         P00CK2_A110EmployeeIsManager = new bool[] {false} ;
         P00CK2_A101CompanyName = new string[] {""} ;
         P00CK2_A100CompanyId = new long[1] ;
         P00CK2_A109EmployeeEmail = new string[] {""} ;
         P00CK2_A148EmployeeName = new string[] {""} ;
         P00CK2_A108EmployeeLastName = new string[] {""} ;
         P00CK2_A107EmployeeFirstName = new string[] {""} ;
         P00CK2_A106EmployeeId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_downloadappexport__default(),
            new Object[][] {
                new Object[] {
               P00CK2_A147EmployeeBalance, P00CK2_A188EmployeeAPIPassword, P00CK2_A178EmployeeVacationDaysSetDate, P00CK2_A146EmployeeVactionDays, P00CK2_A112EmployeeIsActive, P00CK2_A111GAMUserGUID, P00CK2_A110EmployeeIsManager, P00CK2_A101CompanyName, P00CK2_A100CompanyId, P00CK2_A109EmployeeEmail,
               P00CK2_A148EmployeeName, P00CK2_A108EmployeeLastName, P00CK2_A107EmployeeFirstName, P00CK2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV49TFEmployeeIsManager_Sel ;
      private short AV52TFEmployeeIsActive_Sel ;
      private short GXt_int2 ;
      private short AV79Wp_downloadappds_16_tfemployeeismanager_sel ;
      private short AV82Wp_downloadappds_19_tfemployeeisactive_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV62GXV1 ;
      private int AV91GXV2 ;
      private int AV92GXV3 ;
      private long AV35TFEmployeeId ;
      private long AV36TFEmployeeId_To ;
      private long AV45TFCompanyId ;
      private long AV46TFCompanyId_To ;
      private long AV32VisibleColumnCount ;
      private long AV65Wp_downloadappds_2_tfemployeeid ;
      private long AV66Wp_downloadappds_3_tfemployeeid_to ;
      private long AV75Wp_downloadappds_12_tfcompanyid ;
      private long AV76Wp_downloadappds_13_tfcompanyid_to ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private decimal AV53TFEmployeeVactionDays ;
      private decimal AV54TFEmployeeVactionDays_To ;
      private decimal AV59TFEmployeeBalance ;
      private decimal AV60TFEmployeeBalance_To ;
      private decimal AV83Wp_downloadappds_20_tfemployeevactiondays ;
      private decimal AV84Wp_downloadappds_21_tfemployeevactiondays_to ;
      private decimal AV89Wp_downloadappds_26_tfemployeebalance ;
      private decimal AV90Wp_downloadappds_27_tfemployeebalance_to ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private string AV38TFEmployeeFirstName_Sel ;
      private string AV37TFEmployeeFirstName ;
      private string AV40TFEmployeeLastName_Sel ;
      private string AV39TFEmployeeLastName ;
      private string AV42TFEmployeeName_Sel ;
      private string AV41TFEmployeeName ;
      private string AV48TFCompanyName_Sel ;
      private string AV47TFCompanyName ;
      private string AV67Wp_downloadappds_4_tfemployeefirstname ;
      private string AV68Wp_downloadappds_5_tfemployeefirstname_sel ;
      private string AV69Wp_downloadappds_6_tfemployeelastname ;
      private string AV70Wp_downloadappds_7_tfemployeelastname_sel ;
      private string AV71Wp_downloadappds_8_tfemployeename ;
      private string AV72Wp_downloadappds_9_tfemployeename_sel ;
      private string AV77Wp_downloadappds_14_tfcompanyname ;
      private string AV78Wp_downloadappds_15_tfcompanyname_sel ;
      private string lV67Wp_downloadappds_4_tfemployeefirstname ;
      private string lV69Wp_downloadappds_6_tfemployeelastname ;
      private string lV71Wp_downloadappds_8_tfemployeename ;
      private string lV77Wp_downloadappds_14_tfcompanyname ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string A148EmployeeName ;
      private string A101CompanyName ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV55TFEmployeeVacationDaysSetDate ;
      private DateTime AV56TFEmployeeVacationDaysSetDate_To ;
      private DateTime AV85Wp_downloadappds_22_tfemployeevacationdayssetdate ;
      private DateTime AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to ;
      private DateTime A178EmployeeVacationDaysSetDate ;
      private bool returnInSub ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV44TFEmployeeEmail_Sel ;
      private string AV43TFEmployeeEmail ;
      private string AV51TFGAMUserGUID_Sel ;
      private string AV50TFGAMUserGUID ;
      private string AV58TFEmployeeAPIPassword_Sel ;
      private string AV57TFEmployeeAPIPassword ;
      private string AV64Wp_downloadappds_1_filterfulltext ;
      private string AV73Wp_downloadappds_10_tfemployeeemail ;
      private string AV74Wp_downloadappds_11_tfemployeeemail_sel ;
      private string AV80Wp_downloadappds_17_tfgamuserguid ;
      private string AV81Wp_downloadappds_18_tfgamuserguid_sel ;
      private string AV87Wp_downloadappds_24_tfemployeeapipassword ;
      private string AV88Wp_downloadappds_25_tfemployeeapipassword_sel ;
      private string lV64Wp_downloadappds_1_filterfulltext ;
      private string lV73Wp_downloadappds_10_tfemployeeemail ;
      private string lV80Wp_downloadappds_17_tfgamuserguid ;
      private string lV87Wp_downloadappds_24_tfemployeeapipassword ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private string A188EmployeeAPIPassword ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00CK2_A147EmployeeBalance ;
      private string[] P00CK2_A188EmployeeAPIPassword ;
      private DateTime[] P00CK2_A178EmployeeVacationDaysSetDate ;
      private decimal[] P00CK2_A146EmployeeVactionDays ;
      private bool[] P00CK2_A112EmployeeIsActive ;
      private string[] P00CK2_A111GAMUserGUID ;
      private bool[] P00CK2_A110EmployeeIsManager ;
      private string[] P00CK2_A101CompanyName ;
      private long[] P00CK2_A100CompanyId ;
      private string[] P00CK2_A109EmployeeEmail ;
      private string[] P00CK2_A148EmployeeName ;
      private string[] P00CK2_A108EmployeeLastName ;
      private string[] P00CK2_A107EmployeeFirstName ;
      private long[] P00CK2_A106EmployeeId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wp_downloadappexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CK2( IGxContext context ,
                                             string AV64Wp_downloadappds_1_filterfulltext ,
                                             long AV65Wp_downloadappds_2_tfemployeeid ,
                                             long AV66Wp_downloadappds_3_tfemployeeid_to ,
                                             string AV68Wp_downloadappds_5_tfemployeefirstname_sel ,
                                             string AV67Wp_downloadappds_4_tfemployeefirstname ,
                                             string AV70Wp_downloadappds_7_tfemployeelastname_sel ,
                                             string AV69Wp_downloadappds_6_tfemployeelastname ,
                                             string AV72Wp_downloadappds_9_tfemployeename_sel ,
                                             string AV71Wp_downloadappds_8_tfemployeename ,
                                             string AV74Wp_downloadappds_11_tfemployeeemail_sel ,
                                             string AV73Wp_downloadappds_10_tfemployeeemail ,
                                             long AV75Wp_downloadappds_12_tfcompanyid ,
                                             long AV76Wp_downloadappds_13_tfcompanyid_to ,
                                             string AV78Wp_downloadappds_15_tfcompanyname_sel ,
                                             string AV77Wp_downloadappds_14_tfcompanyname ,
                                             short AV79Wp_downloadappds_16_tfemployeeismanager_sel ,
                                             string AV81Wp_downloadappds_18_tfgamuserguid_sel ,
                                             string AV80Wp_downloadappds_17_tfgamuserguid ,
                                             short AV82Wp_downloadappds_19_tfemployeeisactive_sel ,
                                             decimal AV83Wp_downloadappds_20_tfemployeevactiondays ,
                                             decimal AV84Wp_downloadappds_21_tfemployeevactiondays_to ,
                                             DateTime AV85Wp_downloadappds_22_tfemployeevacationdayssetdate ,
                                             DateTime AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to ,
                                             string AV88Wp_downloadappds_25_tfemployeeapipassword_sel ,
                                             string AV87Wp_downloadappds_24_tfemployeeapipassword ,
                                             decimal AV89Wp_downloadappds_26_tfemployeebalance ,
                                             decimal AV90Wp_downloadappds_27_tfemployeebalance_to ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             string A108EmployeeLastName ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             long A100CompanyId ,
                                             string A101CompanyName ,
                                             string A111GAMUserGUID ,
                                             decimal A146EmployeeVactionDays ,
                                             string A188EmployeeAPIPassword ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             DateTime A178EmployeeVacationDaysSetDate ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[35];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeBalance, T1.EmployeeAPIPassword, T1.EmployeeVacationDaysSetDate, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeLastName, T1.EmployeeFirstName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wp_downloadappds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV64Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeFirstName) like '%' || LOWER(:lV64Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeLastName) like '%' || LOWER(:lV64Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeName) like '%' || LOWER(:lV64Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.EmployeeEmail) like '%' || LOWER(:lV64Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.CompanyId,'9999999999'), 2) like '%' || :lV64Wp_downloadappds_1_filterfulltext) or ( LOWER(T2.CompanyName) like '%' || LOWER(:lV64Wp_downloadappds_1_filterfulltext)) or ( LOWER(T1.GAMUserGUID) like '%' || LOWER(:lV64Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV64Wp_downloadappds_1_filterfulltext) or ( LOWER(T1.EmployeeAPIPassword) like '%' || LOWER(:lV64Wp_downloadappds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeBalance,'90.9'), 2) like '%' || :lV64Wp_downloadappds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
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
         if ( ! (0==AV65Wp_downloadappds_2_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV65Wp_downloadappds_2_tfemployeeid)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (0==AV66Wp_downloadappds_3_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV66Wp_downloadappds_3_tfemployeeid_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_5_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wp_downloadappds_4_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName like :lV67Wp_downloadappds_4_tfemployeefirstname)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_downloadappds_5_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeFirstName = ( :AV68Wp_downloadappds_5_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68Wp_downloadappds_5_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_7_tfemployeelastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_downloadappds_6_tfemployeelastname)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName like :lV69Wp_downloadappds_6_tfemployeelastname)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_downloadappds_7_tfemployeelastname_sel)) && ! ( StringUtil.StrCmp(AV70Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeLastName = ( :AV70Wp_downloadappds_7_tfemployeelastname_sel))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wp_downloadappds_7_tfemployeelastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_9_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_downloadappds_8_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV71Wp_downloadappds_8_tfemployeename)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_downloadappds_9_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV72Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV72Wp_downloadappds_9_tfemployeename_sel))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( StringUtil.StrCmp(AV72Wp_downloadappds_9_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Wp_downloadappds_11_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wp_downloadappds_10_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV73Wp_downloadappds_10_tfemployeeemail)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wp_downloadappds_11_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV74Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV74Wp_downloadappds_11_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV74Wp_downloadappds_11_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( ! (0==AV75Wp_downloadappds_12_tfcompanyid) )
         {
            AddWhere(sWhereString, "(T1.CompanyId >= :AV75Wp_downloadappds_12_tfcompanyid)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (0==AV76Wp_downloadappds_13_tfcompanyid_to) )
         {
            AddWhere(sWhereString, "(T1.CompanyId <= :AV76Wp_downloadappds_13_tfcompanyid_to)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_15_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wp_downloadappds_14_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV77Wp_downloadappds_14_tfcompanyname)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wp_downloadappds_15_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV78Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV78Wp_downloadappds_15_tfcompanyname_sel))");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wp_downloadappds_15_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV79Wp_downloadappds_16_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV79Wp_downloadappds_16_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wp_downloadappds_18_tfgamuserguid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wp_downloadappds_17_tfgamuserguid)) ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID like :lV80Wp_downloadappds_17_tfgamuserguid)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wp_downloadappds_18_tfgamuserguid_sel)) && ! ( StringUtil.StrCmp(AV81Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.GAMUserGUID = ( :AV81Wp_downloadappds_18_tfgamuserguid_sel))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wp_downloadappds_18_tfgamuserguid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.GAMUserGUID))=0))");
         }
         if ( AV82Wp_downloadappds_19_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV82Wp_downloadappds_19_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV83Wp_downloadappds_20_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV83Wp_downloadappds_20_tfemployeevactiondays)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Wp_downloadappds_21_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV84Wp_downloadappds_21_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Wp_downloadappds_22_tfemployeevacationdayssetdate) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate >= :AV85Wp_downloadappds_22_tfemployeevacationdayssetdate)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVacationDaysSetDate <= :AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wp_downloadappds_25_tfemployeeapipassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wp_downloadappds_24_tfemployeeapipassword)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword like :lV87Wp_downloadappds_24_tfemployeeapipassword)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wp_downloadappds_25_tfemployeeapipassword_sel)) && ! ( StringUtil.StrCmp(AV88Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeAPIPassword = ( :AV88Wp_downloadappds_25_tfemployeeapipassword_sel))");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wp_downloadappds_25_tfemployeeapipassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeAPIPassword))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV89Wp_downloadappds_26_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance >= :AV89Wp_downloadappds_26_tfemployeebalance)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV90Wp_downloadappds_27_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeBalance <= :AV90Wp_downloadappds_27_tfemployeebalance_to)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeFirstName";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeFirstName DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeId DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeLastName";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeLastName DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeName";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeName DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeEmail";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeEmail DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CompanyId";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CompanyId DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.CompanyName";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.CompanyName DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeIsManager";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeIsManager DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.GAMUserGUID";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.GAMUserGUID DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeIsActive";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeIsActive DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeVactionDays";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeVactionDays DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeVacationDaysSetDate";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeVacationDaysSetDate DESC";
         }
         else if ( ( AV17OrderedBy == 13 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeAPIPassword";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeAPIPassword DESC";
         }
         else if ( ( AV17OrderedBy == 14 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeBalance";
         }
         else if ( ( AV17OrderedBy == 14 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeBalance DESC";
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
                     return conditional_P00CK2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (bool)dynConstraints[38] , (bool)dynConstraints[39] , (DateTime)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] );
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
          Object[] prmP00CK2;
          prmP00CK2 = new Object[] {
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Wp_downloadappds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Wp_downloadappds_2_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV66Wp_downloadappds_3_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV67Wp_downloadappds_4_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV68Wp_downloadappds_5_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV69Wp_downloadappds_6_tfemployeelastname",GXType.Char,100,0) ,
          new ParDef("AV70Wp_downloadappds_7_tfemployeelastname_sel",GXType.Char,100,0) ,
          new ParDef("lV71Wp_downloadappds_8_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV72Wp_downloadappds_9_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV73Wp_downloadappds_10_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV74Wp_downloadappds_11_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV75Wp_downloadappds_12_tfcompanyid",GXType.Int64,10,0) ,
          new ParDef("AV76Wp_downloadappds_13_tfcompanyid_to",GXType.Int64,10,0) ,
          new ParDef("lV77Wp_downloadappds_14_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV78Wp_downloadappds_15_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV80Wp_downloadappds_17_tfgamuserguid",GXType.VarChar,100,60) ,
          new ParDef("AV81Wp_downloadappds_18_tfgamuserguid_sel",GXType.VarChar,100,60) ,
          new ParDef("AV83Wp_downloadappds_20_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV84Wp_downloadappds_21_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV85Wp_downloadappds_22_tfemployeevacationdayssetdate",GXType.Date,8,0) ,
          new ParDef("AV86Wp_downloadappds_23_tfemployeevacationdayssetdate_to",GXType.Date,8,0) ,
          new ParDef("lV87Wp_downloadappds_24_tfemployeeapipassword",GXType.VarChar,40,0) ,
          new ParDef("AV88Wp_downloadappds_25_tfemployeeapipassword_sel",GXType.VarChar,40,0) ,
          new ParDef("AV89Wp_downloadappds_26_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV90Wp_downloadappds_27_tfemployeebalance_to",GXType.Number,4,1)
          };
          def= new CursorDef[] {
              new CursorDef("P00CK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
       }
    }

 }

}
