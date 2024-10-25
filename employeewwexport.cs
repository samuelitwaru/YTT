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
   public class employeewwexport : GXProcedure
   {
      public employeewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeewwexport( IGxContext context )
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
         AV12Filename = GXt_char1 + "EmployeeWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFEmployeeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFEmployeeName_Sel)) ? "(Empty)" : AV57TFEmployeeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFEmployeeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFEmployeeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEmployeeEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Email") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEmployeeEmail_Sel)) ? "(Empty)" : AV42TFEmployeeEmail_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEmployeeEmail)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Email") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFEmployeeEmail, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV47TFEmployeeIsManager_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is HR Manager") ;
            AV14CellRow = GXt_int2;
            if ( AV47TFEmployeeIsManager_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV47TFEmployeeIsManager_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Unchecked";
            }
         }
         if ( ! ( (0==AV50TFEmployeeIsActive_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is Active") ;
            AV14CellRow = GXt_int2;
            if ( AV50TFEmployeeIsActive_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV50TFEmployeeIsActive_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Unchecked";
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV51TFEmployeeVactionDays) && (Convert.ToDecimal(0)==AV52TFEmployeeVactionDays_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Vacation Days") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV51TFEmployeeVactionDays);
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV52TFEmployeeVactionDays_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV53TFEmployeeBalance) && (Convert.ToDecimal(0)==AV54TFEmployeeBalance_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Balance") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV53TFEmployeeBalance);
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV54TFEmployeeBalance_To);
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("EmployeeWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("EmployeeWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV60GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV62Employeewwds_1_filterfulltext = AV19FilterFullText;
         AV63Employeewwds_2_tfemployeename = AV56TFEmployeeName;
         AV64Employeewwds_3_tfemployeename_sel = AV57TFEmployeeName_Sel;
         AV65Employeewwds_4_tfemployeeemail = AV41TFEmployeeEmail;
         AV66Employeewwds_5_tfemployeeemail_sel = AV42TFEmployeeEmail_Sel;
         AV67Employeewwds_6_tfemployeeismanager_sel = AV47TFEmployeeIsManager_Sel;
         AV68Employeewwds_7_tfemployeeisactive_sel = AV50TFEmployeeIsActive_Sel;
         AV69Employeewwds_8_tfemployeevactiondays = AV51TFEmployeeVactionDays;
         AV70Employeewwds_9_tfemployeevactiondays_to = AV52TFEmployeeVactionDays_To;
         AV71Employeewwds_10_tfemployeebalance = AV53TFEmployeeBalance;
         AV72Employeewwds_11_tfemployeebalance_to = AV54TFEmployeeBalance_To;
         AV73Udparg12 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV58EmployeeIds ,
                                              AV62Employeewwds_1_filterfulltext ,
                                              AV64Employeewwds_3_tfemployeename_sel ,
                                              AV63Employeewwds_2_tfemployeename ,
                                              AV66Employeewwds_5_tfemployeeemail_sel ,
                                              AV65Employeewwds_4_tfemployeeemail ,
                                              AV67Employeewwds_6_tfemployeeismanager_sel ,
                                              AV68Employeewwds_7_tfemployeeisactive_sel ,
                                              AV69Employeewwds_8_tfemployeevactiondays ,
                                              AV70Employeewwds_9_tfemployeevactiondays_to ,
                                              AV71Employeewwds_10_tfemployeebalance ,
                                              AV72Employeewwds_11_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A146EmployeeVactionDays ,
                                              A147EmployeeBalance ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A100CompanyId ,
                                              AV73Udparg12 ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Employeewwds_1_filterfulltext), "%", "");
         lV62Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Employeewwds_1_filterfulltext), "%", "");
         lV62Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Employeewwds_1_filterfulltext), "%", "");
         lV62Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Employeewwds_1_filterfulltext), "%", "");
         lV63Employeewwds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV63Employeewwds_2_tfemployeename), 100, "%");
         lV65Employeewwds_4_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV65Employeewwds_4_tfemployeeemail), "%", "");
         /* Using cursor P006T2 */
         pr_default.execute(0, new Object[] {lV62Employeewwds_1_filterfulltext, lV62Employeewwds_1_filterfulltext, lV62Employeewwds_1_filterfulltext, lV62Employeewwds_1_filterfulltext, lV63Employeewwds_2_tfemployeename, AV64Employeewwds_3_tfemployeename_sel, lV65Employeewwds_4_tfemployeeemail, AV66Employeewwds_5_tfemployeeemail_sel, AV69Employeewwds_8_tfemployeevactiondays, AV70Employeewwds_9_tfemployeevactiondays_to, AV71Employeewwds_10_tfemployeebalance, AV72Employeewwds_11_tfemployeebalance_to, AV73Udparg12});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P006T2_A106EmployeeId[0];
            A100CompanyId = P006T2_A100CompanyId[0];
            A147EmployeeBalance = P006T2_A147EmployeeBalance[0];
            A146EmployeeVactionDays = P006T2_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P006T2_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P006T2_A110EmployeeIsManager[0];
            A109EmployeeEmail = P006T2_A109EmployeeEmail[0];
            A148EmployeeName = P006T2_A148EmployeeName[0];
            A107EmployeeFirstName = P006T2_A107EmployeeFirstName[0];
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
            AV74GXV2 = 1;
            while ( AV74GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV74GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeName") == 0 )
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
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeIsManager") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A110EmployeeIsManager);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeIsActive") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A112EmployeeIsActive);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeVactionDays") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A146EmployeeVactionDays);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeBalance") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A147EmployeeBalance);
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV74GXV2 = (int)(AV74GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "EmployeeWWExport.xlsx");
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
         new logtofile(context ).execute(  "+++"+AV12Filename) ;
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeIsManager",  "",  "Is HR Manager",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeIsActive",  "",  "Is Active",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeVactionDays",  "",  "Vacation Days",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeBalance",  "",  "Balance",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "EmployeeWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("EmployeeWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EmployeeWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("EmployeeWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV75GXV3 = 1;
         while ( AV75GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV75GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV56TFEmployeeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV57TFEmployeeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV41TFEmployeeEmail = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV42TFEmployeeEmail_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV47TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV50TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEVACTIONDAYS") == 0 )
            {
               AV51TFEmployeeVactionDays = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV52TFEmployeeVactionDays_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEBALANCE") == 0 )
            {
               AV53TFEmployeeBalance = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV54TFEmployeeBalance_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV75GXV3 = (int)(AV75GXV3+1);
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
         AV57TFEmployeeName_Sel = "";
         AV56TFEmployeeName = "";
         AV42TFEmployeeEmail_Sel = "";
         AV41TFEmployeeEmail = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV62Employeewwds_1_filterfulltext = "";
         AV63Employeewwds_2_tfemployeename = "";
         AV64Employeewwds_3_tfemployeename_sel = "";
         AV65Employeewwds_4_tfemployeeemail = "";
         AV66Employeewwds_5_tfemployeeemail_sel = "";
         lV62Employeewwds_1_filterfulltext = "";
         lV63Employeewwds_2_tfemployeename = "";
         lV65Employeewwds_4_tfemployeeemail = "";
         AV58EmployeeIds = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         P006T2_A106EmployeeId = new long[1] ;
         P006T2_A100CompanyId = new long[1] ;
         P006T2_A147EmployeeBalance = new decimal[1] ;
         P006T2_A146EmployeeVactionDays = new decimal[1] ;
         P006T2_A112EmployeeIsActive = new bool[] {false} ;
         P006T2_A110EmployeeIsManager = new bool[] {false} ;
         P006T2_A109EmployeeEmail = new string[] {""} ;
         P006T2_A148EmployeeName = new string[] {""} ;
         P006T2_A107EmployeeFirstName = new string[] {""} ;
         A107EmployeeFirstName = "";
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeewwexport__default(),
            new Object[][] {
                new Object[] {
               P006T2_A106EmployeeId, P006T2_A100CompanyId, P006T2_A147EmployeeBalance, P006T2_A146EmployeeVactionDays, P006T2_A112EmployeeIsActive, P006T2_A110EmployeeIsManager, P006T2_A109EmployeeEmail, P006T2_A148EmployeeName, P006T2_A107EmployeeFirstName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV47TFEmployeeIsManager_Sel ;
      private short AV50TFEmployeeIsActive_Sel ;
      private short GXt_int2 ;
      private short AV67Employeewwds_6_tfemployeeismanager_sel ;
      private short AV68Employeewwds_7_tfemployeeisactive_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV60GXV1 ;
      private int AV74GXV2 ;
      private int AV75GXV3 ;
      private long AV32VisibleColumnCount ;
      private long AV73Udparg12 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private decimal AV51TFEmployeeVactionDays ;
      private decimal AV52TFEmployeeVactionDays_To ;
      private decimal AV53TFEmployeeBalance ;
      private decimal AV54TFEmployeeBalance_To ;
      private decimal AV69Employeewwds_8_tfemployeevactiondays ;
      private decimal AV70Employeewwds_9_tfemployeevactiondays_to ;
      private decimal AV71Employeewwds_10_tfemployeebalance ;
      private decimal AV72Employeewwds_11_tfemployeebalance_to ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private string AV57TFEmployeeName_Sel ;
      private string AV56TFEmployeeName ;
      private string AV63Employeewwds_2_tfemployeename ;
      private string AV64Employeewwds_3_tfemployeename_sel ;
      private string lV63Employeewwds_2_tfemployeename ;
      private string A148EmployeeName ;
      private string A107EmployeeFirstName ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV42TFEmployeeEmail_Sel ;
      private string AV41TFEmployeeEmail ;
      private string AV62Employeewwds_1_filterfulltext ;
      private string AV65Employeewwds_4_tfemployeeemail ;
      private string AV66Employeewwds_5_tfemployeeemail_sel ;
      private string lV62Employeewwds_1_filterfulltext ;
      private string lV65Employeewwds_4_tfemployeeemail ;
      private string A109EmployeeEmail ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private GxSimpleCollection<long> AV58EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private long[] P006T2_A106EmployeeId ;
      private long[] P006T2_A100CompanyId ;
      private decimal[] P006T2_A147EmployeeBalance ;
      private decimal[] P006T2_A146EmployeeVactionDays ;
      private bool[] P006T2_A112EmployeeIsActive ;
      private bool[] P006T2_A110EmployeeIsManager ;
      private string[] P006T2_A109EmployeeEmail ;
      private string[] P006T2_A148EmployeeName ;
      private string[] P006T2_A107EmployeeFirstName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class employeewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006T2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV58EmployeeIds ,
                                             string AV62Employeewwds_1_filterfulltext ,
                                             string AV64Employeewwds_3_tfemployeename_sel ,
                                             string AV63Employeewwds_2_tfemployeename ,
                                             string AV66Employeewwds_5_tfemployeeemail_sel ,
                                             string AV65Employeewwds_4_tfemployeeemail ,
                                             short AV67Employeewwds_6_tfemployeeismanager_sel ,
                                             short AV68Employeewwds_7_tfemployeeisactive_sel ,
                                             decimal AV69Employeewwds_8_tfemployeevactiondays ,
                                             decimal AV70Employeewwds_9_tfemployeevactiondays_to ,
                                             decimal AV71Employeewwds_10_tfemployeebalance ,
                                             decimal AV72Employeewwds_11_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             decimal A146EmployeeVactionDays ,
                                             decimal A147EmployeeBalance ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             long A100CompanyId ,
                                             long AV73Udparg12 ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT EmployeeId, CompanyId, EmployeeBalance, EmployeeVactionDays, EmployeeIsActive, EmployeeIsManager, EmployeeEmail, EmployeeName, EmployeeFirstName FROM Employee";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(EmployeeName) like '%' || LOWER(:lV62Employeewwds_1_filterfulltext)) or ( LOWER(EmployeeEmail) like '%' || LOWER(:lV62Employeewwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(EmployeeVactionDays,'90.9'), 2) like '%' || :lV62Employeewwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(EmployeeBalance,'90.9'), 2) like '%' || :lV62Employeewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeewwds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Employeewwds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(EmployeeName like :lV63Employeewwds_2_tfemployeename)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeewwds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV64Employeewwds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmployeeName = ( :AV64Employeewwds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV64Employeewwds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Employeewwds_5_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Employeewwds_4_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(EmployeeEmail like :lV65Employeewwds_4_tfemployeeemail)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Employeewwds_5_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV66Employeewwds_5_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmployeeEmail = ( :AV66Employeewwds_5_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV66Employeewwds_5_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EmployeeEmail))=0))");
         }
         if ( AV67Employeewwds_6_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(EmployeeIsManager = TRUE)");
         }
         if ( AV67Employeewwds_6_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(EmployeeIsManager = FALSE)");
         }
         if ( AV68Employeewwds_7_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(EmployeeIsActive = TRUE)");
         }
         if ( AV68Employeewwds_7_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV69Employeewwds_8_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(EmployeeVactionDays >= :AV69Employeewwds_8_tfemployeevactiondays)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV70Employeewwds_9_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(EmployeeVactionDays <= :AV70Employeewwds_9_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Employeewwds_10_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(EmployeeBalance >= :AV71Employeewwds_10_tfemployeebalance)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV72Employeewwds_11_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(EmployeeBalance <= :AV72Employeewwds_11_tfemployeebalance_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(CompanyId = :AV73Udparg12)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV58EmployeeIds, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY EmployeeFirstName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeEmail";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeEmail DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeIsManager";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeIsManager DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeIsActive";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeIsActive DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeVactionDays";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeVactionDays DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeBalance";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeBalance DESC";
         }
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
               case 0 :
                     return conditional_P006T2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] );
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
          Object[] prmP006T2;
          prmP006T2 = new Object[] {
          new ParDef("lV62Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Employeewwds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV64Employeewwds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV65Employeewwds_4_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV66Employeewwds_5_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV69Employeewwds_8_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV70Employeewwds_9_tfemployeevactiondays_to",GXType.Number,4,1) ,
          new ParDef("AV71Employeewwds_10_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV72Employeewwds_11_tfemployeebalance_to",GXType.Number,4,1) ,
          new ParDef("AV73Udparg12",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                return;
       }
    }

 }

}
