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
   public class workhourloglistexport : GXProcedure
   {
      public workhourloglistexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourloglistexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV52EmployeeId = aP0_EmployeeId;
         this.AV50FromDate = aP1_FromDate;
         this.AV51ToDate = aP2_ToDate;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP3_Filename=this.AV12Filename;
         aP4_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( long aP0_EmployeeId ,
                                DateTime aP1_FromDate ,
                                DateTime aP2_ToDate ,
                                out string aP3_Filename )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, out aP3_Filename, out aP4_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         workhourloglistexport objworkhourloglistexport;
         objworkhourloglistexport = new workhourloglistexport();
         objworkhourloglistexport.AV52EmployeeId = aP0_EmployeeId;
         objworkhourloglistexport.AV50FromDate = aP1_FromDate;
         objworkhourloglistexport.AV51ToDate = aP2_ToDate;
         objworkhourloglistexport.AV12Filename = "" ;
         objworkhourloglistexport.AV13ErrorMessage = "" ;
         objworkhourloglistexport.context.SetSubmitInitialConfig(context);
         objworkhourloglistexport.initialize();
         Submit( executePrivateCatch,objworkhourloglistexport);
         aP3_Filename=this.AV12Filename;
         aP4_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workhourloglistexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "WorkHourLogListExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProjectName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Project Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProjectName_Sel)) ? "(Empty)" : AV38TFProjectName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFProjectName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Project Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFProjectName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV39TFWorkHourLogDate) && (DateTime.MinValue==AV40TFWorkHourLogDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV39TFWorkHourLogDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV40TFWorkHourLogDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFWorkHourLogDuration_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Duration") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFWorkHourLogDuration_Sel)) ? "(Empty)" : AV42TFWorkHourLogDuration_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFWorkHourLogDuration)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Duration") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFWorkHourLogDuration, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWorkHourLogDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Description") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWorkHourLogDescription_Sel)) ? "(Empty)" : StringUtil.Substring( AV48TFWorkHourLogDescription_Sel, 1, 1000)), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFWorkHourLogDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Description") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV47TFWorkHourLogDescription, 1, 1000), out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("WorkHourLogListColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("WorkHourLogListColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV53GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Workhourloglistds_1_filterfulltext = AV19FilterFullText;
         AV56Workhourloglistds_2_tfemployeename = AV35TFEmployeeName;
         AV57Workhourloglistds_3_tfemployeename_sel = AV36TFEmployeeName_Sel;
         AV58Workhourloglistds_4_tfprojectname = AV37TFProjectName;
         AV59Workhourloglistds_5_tfprojectname_sel = AV38TFProjectName_Sel;
         AV60Workhourloglistds_6_tfworkhourlogdate = AV39TFWorkHourLogDate;
         AV61Workhourloglistds_7_tfworkhourlogdate_to = AV40TFWorkHourLogDate_To;
         AV62Workhourloglistds_8_tfworkhourlogduration = AV41TFWorkHourLogDuration;
         AV63Workhourloglistds_9_tfworkhourlogduration_sel = AV42TFWorkHourLogDuration_Sel;
         AV64Workhourloglistds_10_tfworkhourlogdescription = AV47TFWorkHourLogDescription;
         AV65Workhourloglistds_11_tfworkhourlogdescription_sel = AV48TFWorkHourLogDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Workhourloglistds_1_filterfulltext ,
                                              AV57Workhourloglistds_3_tfemployeename_sel ,
                                              AV56Workhourloglistds_2_tfemployeename ,
                                              AV59Workhourloglistds_5_tfprojectname_sel ,
                                              AV58Workhourloglistds_4_tfprojectname ,
                                              AV60Workhourloglistds_6_tfworkhourlogdate ,
                                              AV61Workhourloglistds_7_tfworkhourlogdate_to ,
                                              AV63Workhourloglistds_9_tfworkhourlogduration_sel ,
                                              AV62Workhourloglistds_8_tfworkhourlogduration ,
                                              AV65Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                              AV64Workhourloglistds_10_tfworkhourlogdescription ,
                                              AV52EmployeeId ,
                                              AV50FromDate ,
                                              AV51ToDate ,
                                              A148EmployeeName ,
                                              A103ProjectName ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A119WorkHourLogDate ,
                                              A106EmployeeId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Workhourloglistds_1_filterfulltext), "%", "");
         lV55Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Workhourloglistds_1_filterfulltext), "%", "");
         lV55Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Workhourloglistds_1_filterfulltext), "%", "");
         lV55Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Workhourloglistds_1_filterfulltext), "%", "");
         lV56Workhourloglistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV56Workhourloglistds_2_tfemployeename), 128, "%");
         lV58Workhourloglistds_4_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV58Workhourloglistds_4_tfprojectname), 100, "%");
         lV62Workhourloglistds_8_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV62Workhourloglistds_8_tfworkhourlogduration), "%", "");
         lV64Workhourloglistds_10_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV64Workhourloglistds_10_tfworkhourlogdescription), "%", "");
         /* Using cursor P00862 */
         pr_default.execute(0, new Object[] {lV55Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_1_filterfulltext, lV56Workhourloglistds_2_tfemployeename, AV57Workhourloglistds_3_tfemployeename_sel, lV58Workhourloglistds_4_tfprojectname, AV59Workhourloglistds_5_tfprojectname_sel, AV60Workhourloglistds_6_tfworkhourlogdate, AV61Workhourloglistds_7_tfworkhourlogdate_to, lV62Workhourloglistds_8_tfworkhourlogduration, AV63Workhourloglistds_9_tfworkhourlogduration_sel, lV64Workhourloglistds_10_tfworkhourlogdescription, AV65Workhourloglistds_11_tfworkhourlogdescription_sel, AV52EmployeeId, AV50FromDate, AV51ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A102ProjectId = P00862_A102ProjectId[0];
            A106EmployeeId = P00862_A106EmployeeId[0];
            A123WorkHourLogDescription = P00862_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P00862_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P00862_A119WorkHourLogDate[0];
            A103ProjectName = P00862_A103ProjectName[0];
            A148EmployeeName = P00862_A148EmployeeName[0];
            A118WorkHourLogId = P00862_A118WorkHourLogId[0];
            A103ProjectName = P00862_A103ProjectName[0];
            A148EmployeeName = P00862_A148EmployeeName[0];
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
            AV66GXV2 = 1;
            while ( AV66GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV66GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A148EmployeeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProjectName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A103ProjectName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A119WorkHourLogDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogDuration") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A120WorkHourLogDuration, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A123WorkHourLogDescription, 1, 1000), out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV66GXV2 = (int)(AV66GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "WorkHourLogListExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProjectName",  "",  "Project Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogDate",  "",  "Log Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogDuration",  "",  "Log Duration",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogDescription",  "",  "Log Description",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WorkHourLogListColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("WorkHourLogListGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkHourLogListGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("WorkHourLogListGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV67GXV3 = 1;
         while ( AV67GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV67GXV3));
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
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV37TFProjectName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV38TFProjectName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV39TFWorkHourLogDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 1);
               AV40TFWorkHourLogDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV41TFWorkHourLogDuration = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV42TFWorkHourLogDuration_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV47TFWorkHourLogDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV48TFWorkHourLogDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV67GXV3 = (int)(AV67GXV3+1);
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
         AV38TFProjectName_Sel = "";
         AV37TFProjectName = "";
         AV39TFWorkHourLogDate = DateTime.MinValue;
         AV40TFWorkHourLogDate_To = DateTime.MinValue;
         AV42TFWorkHourLogDuration_Sel = "";
         AV41TFWorkHourLogDuration = "";
         AV48TFWorkHourLogDescription_Sel = "";
         AV47TFWorkHourLogDescription = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV55Workhourloglistds_1_filterfulltext = "";
         AV56Workhourloglistds_2_tfemployeename = "";
         AV57Workhourloglistds_3_tfemployeename_sel = "";
         AV58Workhourloglistds_4_tfprojectname = "";
         AV59Workhourloglistds_5_tfprojectname_sel = "";
         AV60Workhourloglistds_6_tfworkhourlogdate = DateTime.MinValue;
         AV61Workhourloglistds_7_tfworkhourlogdate_to = DateTime.MinValue;
         AV62Workhourloglistds_8_tfworkhourlogduration = "";
         AV63Workhourloglistds_9_tfworkhourlogduration_sel = "";
         AV64Workhourloglistds_10_tfworkhourlogdescription = "";
         AV65Workhourloglistds_11_tfworkhourlogdescription_sel = "";
         scmdbuf = "";
         lV55Workhourloglistds_1_filterfulltext = "";
         lV56Workhourloglistds_2_tfemployeename = "";
         lV58Workhourloglistds_4_tfprojectname = "";
         lV62Workhourloglistds_8_tfworkhourlogduration = "";
         lV64Workhourloglistds_10_tfworkhourlogdescription = "";
         A148EmployeeName = "";
         A103ProjectName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00862_A102ProjectId = new long[1] ;
         P00862_A106EmployeeId = new long[1] ;
         P00862_A123WorkHourLogDescription = new string[] {""} ;
         P00862_A120WorkHourLogDuration = new string[] {""} ;
         P00862_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00862_A103ProjectName = new string[] {""} ;
         P00862_A148EmployeeName = new string[] {""} ;
         P00862_A118WorkHourLogId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourloglistexport__default(),
            new Object[][] {
                new Object[] {
               P00862_A102ProjectId, P00862_A106EmployeeId, P00862_A123WorkHourLogDescription, P00862_A120WorkHourLogDuration, P00862_A119WorkHourLogDate, P00862_A103ProjectName, P00862_A148EmployeeName, P00862_A118WorkHourLogId
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
      private int AV53GXV1 ;
      private int AV66GXV2 ;
      private int AV67GXV3 ;
      private long AV52EmployeeId ;
      private long AV32VisibleColumnCount ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private string AV36TFEmployeeName_Sel ;
      private string AV35TFEmployeeName ;
      private string AV38TFProjectName_Sel ;
      private string AV37TFProjectName ;
      private string AV56Workhourloglistds_2_tfemployeename ;
      private string AV57Workhourloglistds_3_tfemployeename_sel ;
      private string AV58Workhourloglistds_4_tfprojectname ;
      private string AV59Workhourloglistds_5_tfprojectname_sel ;
      private string scmdbuf ;
      private string lV56Workhourloglistds_2_tfemployeename ;
      private string lV58Workhourloglistds_4_tfprojectname ;
      private string A148EmployeeName ;
      private string A103ProjectName ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV50FromDate ;
      private DateTime AV51ToDate ;
      private DateTime AV39TFWorkHourLogDate ;
      private DateTime AV40TFWorkHourLogDate_To ;
      private DateTime AV60Workhourloglistds_6_tfworkhourlogdate ;
      private DateTime AV61Workhourloglistds_7_tfworkhourlogdate_to ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string A123WorkHourLogDescription ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV42TFWorkHourLogDuration_Sel ;
      private string AV41TFWorkHourLogDuration ;
      private string AV48TFWorkHourLogDescription_Sel ;
      private string AV47TFWorkHourLogDescription ;
      private string AV55Workhourloglistds_1_filterfulltext ;
      private string AV62Workhourloglistds_8_tfworkhourlogduration ;
      private string AV63Workhourloglistds_9_tfworkhourlogduration_sel ;
      private string AV64Workhourloglistds_10_tfworkhourlogdescription ;
      private string AV65Workhourloglistds_11_tfworkhourlogdescription_sel ;
      private string lV55Workhourloglistds_1_filterfulltext ;
      private string lV62Workhourloglistds_8_tfworkhourlogduration ;
      private string lV64Workhourloglistds_10_tfworkhourlogdescription ;
      private string A120WorkHourLogDuration ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00862_A102ProjectId ;
      private long[] P00862_A106EmployeeId ;
      private string[] P00862_A123WorkHourLogDescription ;
      private string[] P00862_A120WorkHourLogDuration ;
      private DateTime[] P00862_A119WorkHourLogDate ;
      private string[] P00862_A103ProjectName ;
      private string[] P00862_A148EmployeeName ;
      private long[] P00862_A118WorkHourLogId ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
   }

   public class workhourloglistexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00862( IGxContext context ,
                                             string AV55Workhourloglistds_1_filterfulltext ,
                                             string AV57Workhourloglistds_3_tfemployeename_sel ,
                                             string AV56Workhourloglistds_2_tfemployeename ,
                                             string AV59Workhourloglistds_5_tfprojectname_sel ,
                                             string AV58Workhourloglistds_4_tfprojectname ,
                                             DateTime AV60Workhourloglistds_6_tfworkhourlogdate ,
                                             DateTime AV61Workhourloglistds_7_tfworkhourlogdate_to ,
                                             string AV63Workhourloglistds_9_tfworkhourlogduration_sel ,
                                             string AV62Workhourloglistds_8_tfworkhourlogduration ,
                                             string AV65Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                             string AV64Workhourloglistds_10_tfworkhourlogdescription ,
                                             long AV52EmployeeId ,
                                             DateTime AV50FromDate ,
                                             DateTime AV51ToDate ,
                                             string A148EmployeeName ,
                                             string A103ProjectName ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             DateTime A119WorkHourLogDate ,
                                             long A106EmployeeId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[17];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.ProjectId, T1.EmployeeId, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogDate, T2.ProjectName, T3.EmployeeName, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workhourloglistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T3.EmployeeName) like '%' || LOWER(:lV55Workhourloglistds_1_filterfulltext)) or ( LOWER(T2.ProjectName) like '%' || LOWER(:lV55Workhourloglistds_1_filterfulltext)) or ( LOWER(T1.WorkHourLogDuration) like '%' || LOWER(:lV55Workhourloglistds_1_filterfulltext)) or ( LOWER(T1.WorkHourLogDescription) like '%' || LOWER(:lV55Workhourloglistds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Workhourloglistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.EmployeeName) like LOWER(:lV56Workhourloglistds_2_tfemployeename))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workhourloglistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV57Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV57Workhourloglistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV57Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Workhourloglistds_5_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_4_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.ProjectName) like LOWER(:lV58Workhourloglistds_4_tfprojectname))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Workhourloglistds_5_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV59Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV59Workhourloglistds_5_tfprojectname_sel))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( ! (DateTime.MinValue==AV60Workhourloglistds_6_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV60Workhourloglistds_6_tfworkhourlogdate)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV61Workhourloglistds_7_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV61Workhourloglistds_7_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Workhourloglistds_9_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_8_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDuration) like LOWER(:lV62Workhourloglistds_8_tfworkhourlogduration))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workhourloglistds_9_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV63Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV63Workhourloglistds_9_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV63Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Workhourloglistds_11_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_10_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDescription) like LOWER(:lV64Workhourloglistds_10_tfworkhourlogdescription))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workhourloglistds_11_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV65Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV65Workhourloglistds_11_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV65Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV52EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV52EmployeeId)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV50FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV50FromDate)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV51ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV51ToDate)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDate";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDate DESC";
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
            scmdbuf += " ORDER BY T2.ProjectName";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ProjectName DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDuration";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDuration DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDescription";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDescription DESC";
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
                     return conditional_P00862(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (long)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00862;
          prmP00862 = new Object[] {
          new ParDef("lV55Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Workhourloglistds_2_tfemployeename",GXType.Char,128,0) ,
          new ParDef("AV57Workhourloglistds_3_tfemployeename_sel",GXType.Char,128,0) ,
          new ParDef("lV58Workhourloglistds_4_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV59Workhourloglistds_5_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("AV60Workhourloglistds_6_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV61Workhourloglistds_7_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV62Workhourloglistds_8_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV63Workhourloglistds_9_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV64Workhourloglistds_10_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV65Workhourloglistds_11_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV52EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV50FromDate",GXType.Date,8,0) ,
          new ParDef("AV51ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00862", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00862,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 128);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
