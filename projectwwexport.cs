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
   public class projectwwexport : GXProcedure
   {
      public projectwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public projectwwexport( IGxContext context )
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
         projectwwexport objprojectwwexport;
         objprojectwwexport = new projectwwexport();
         objprojectwwexport.AV12Filename = "" ;
         objprojectwwexport.AV13ErrorMessage = "" ;
         objprojectwwexport.context.SetSubmitInitialConfig(context);
         objprojectwwexport.initialize();
         Submit( executePrivateCatch,objprojectwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((projectwwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "ProjectWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProjectName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
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
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFProjectName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProjectDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Description") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProjectDescription_Sel)) ? "(Empty)" : AV40TFProjectDescription_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFProjectDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Description") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFProjectDescription, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProjectManagerName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Manager Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProjectManagerName_Sel)) ? "(Empty)" : AV48TFProjectManagerName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProjectManagerName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Manager Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFProjectManagerName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV43TFProjectStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Status") ;
            AV14CellRow = GXt_int2;
            AV44i = 1;
            AV49GXV1 = 1;
            while ( AV49GXV1 <= AV43TFProjectStatus_Sels.Count )
            {
               AV42TFProjectStatus_Sel = AV43TFProjectStatus_Sels.GetString(AV49GXV1);
               if ( AV44i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+gxdomainstatus.getDescription(context,AV42TFProjectStatus_Sel);
               AV44i = (long)(AV44i+1);
               AV49GXV1 = (int)(AV49GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("ProjectWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("ProjectWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV50GXV2 = 1;
         while ( AV50GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV50GXV2));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV50GXV2 = (int)(AV50GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Projectwwds_1_filterfulltext = AV19FilterFullText;
         AV53Projectwwds_2_tfprojectname = AV37TFProjectName;
         AV54Projectwwds_3_tfprojectname_sel = AV38TFProjectName_Sel;
         AV55Projectwwds_4_tfprojectdescription = AV39TFProjectDescription;
         AV56Projectwwds_5_tfprojectdescription_sel = AV40TFProjectDescription_Sel;
         AV57Projectwwds_6_tfprojectmanagername = AV47TFProjectManagerName;
         AV58Projectwwds_7_tfprojectmanagername_sel = AV48TFProjectManagerName_Sel;
         AV59Projectwwds_8_tfprojectstatus_sels = AV43TFProjectStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A105ProjectStatus ,
                                              AV59Projectwwds_8_tfprojectstatus_sels ,
                                              AV52Projectwwds_1_filterfulltext ,
                                              AV54Projectwwds_3_tfprojectname_sel ,
                                              AV53Projectwwds_2_tfprojectname ,
                                              AV56Projectwwds_5_tfprojectdescription_sel ,
                                              AV55Projectwwds_4_tfprojectdescription ,
                                              AV58Projectwwds_7_tfprojectmanagername_sel ,
                                              AV57Projectwwds_6_tfprojectmanagername ,
                                              AV59Projectwwds_8_tfprojectstatus_sels.Count ,
                                              A103ProjectName ,
                                              A104ProjectDescription ,
                                              A167ProjectManagerName ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Projectwwds_1_filterfulltext), "%", "");
         lV52Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Projectwwds_1_filterfulltext), "%", "");
         lV52Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Projectwwds_1_filterfulltext), "%", "");
         lV52Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Projectwwds_1_filterfulltext), "%", "");
         lV52Projectwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Projectwwds_1_filterfulltext), "%", "");
         lV53Projectwwds_2_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV53Projectwwds_2_tfprojectname), 100, "%");
         lV55Projectwwds_4_tfprojectdescription = StringUtil.Concat( StringUtil.RTrim( AV55Projectwwds_4_tfprojectdescription), "%", "");
         lV57Projectwwds_6_tfprojectmanagername = StringUtil.PadR( StringUtil.RTrim( AV57Projectwwds_6_tfprojectmanagername), 100, "%");
         /* Using cursor P007G2 */
         pr_default.execute(0, new Object[] {lV52Projectwwds_1_filterfulltext, lV52Projectwwds_1_filterfulltext, lV52Projectwwds_1_filterfulltext, lV52Projectwwds_1_filterfulltext, lV52Projectwwds_1_filterfulltext, lV53Projectwwds_2_tfprojectname, AV54Projectwwds_3_tfprojectname_sel, lV55Projectwwds_4_tfprojectdescription, AV56Projectwwds_5_tfprojectdescription_sel, lV57Projectwwds_6_tfprojectmanagername, AV58Projectwwds_7_tfprojectmanagername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A166ProjectManagerId = P007G2_A166ProjectManagerId[0];
            n166ProjectManagerId = P007G2_n166ProjectManagerId[0];
            A167ProjectManagerName = P007G2_A167ProjectManagerName[0];
            A104ProjectDescription = P007G2_A104ProjectDescription[0];
            A103ProjectName = P007G2_A103ProjectName[0];
            A105ProjectStatus = P007G2_A105ProjectStatus[0];
            A102ProjectId = P007G2_A102ProjectId[0];
            A167ProjectManagerName = P007G2_A167ProjectManagerName[0];
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
            AV60GXV3 = 1;
            while ( AV60GXV3 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV60GXV3));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProjectName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A103ProjectName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProjectDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A104ProjectDescription, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProjectManagerName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A167ProjectManagerName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProjectStatus") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = gxdomainstatus.getDescription(context,A105ProjectStatus);
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV60GXV3 = (int)(AV60GXV3+1);
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
         AV20Session.Set("WWPExportFileName", "ProjectWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProjectName",  "",  "Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProjectDescription",  "",  "Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProjectManagerName",  "",  "Manager Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProjectStatus",  "",  "Status",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProjectWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("ProjectWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProjectWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("ProjectWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV61GXV4 = 1;
         while ( AV61GXV4 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV61GXV4));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV37TFProjectName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV38TFProjectName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTDESCRIPTION") == 0 )
            {
               AV39TFProjectDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTDESCRIPTION_SEL") == 0 )
            {
               AV40TFProjectDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTMANAGERNAME") == 0 )
            {
               AV47TFProjectManagerName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTMANAGERNAME_SEL") == 0 )
            {
               AV48TFProjectManagerName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTSTATUS_SEL") == 0 )
            {
               AV41TFProjectStatus_SelsJson = AV23GridStateFilterValue.gxTpr_Value;
               AV43TFProjectStatus_Sels.FromJSonString(AV41TFProjectStatus_SelsJson, null);
            }
            AV61GXV4 = (int)(AV61GXV4+1);
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
         AV38TFProjectName_Sel = "";
         AV37TFProjectName = "";
         AV40TFProjectDescription_Sel = "";
         AV39TFProjectDescription = "";
         AV48TFProjectManagerName_Sel = "";
         AV47TFProjectManagerName = "";
         AV43TFProjectStatus_Sels = new GxSimpleCollection<string>();
         AV42TFProjectStatus_Sel = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV52Projectwwds_1_filterfulltext = "";
         AV53Projectwwds_2_tfprojectname = "";
         AV54Projectwwds_3_tfprojectname_sel = "";
         AV55Projectwwds_4_tfprojectdescription = "";
         AV56Projectwwds_5_tfprojectdescription_sel = "";
         AV57Projectwwds_6_tfprojectmanagername = "";
         AV58Projectwwds_7_tfprojectmanagername_sel = "";
         AV59Projectwwds_8_tfprojectstatus_sels = new GxSimpleCollection<string>();
         scmdbuf = "";
         lV52Projectwwds_1_filterfulltext = "";
         lV53Projectwwds_2_tfprojectname = "";
         lV55Projectwwds_4_tfprojectdescription = "";
         lV57Projectwwds_6_tfprojectmanagername = "";
         A105ProjectStatus = "";
         A103ProjectName = "";
         A104ProjectDescription = "";
         A167ProjectManagerName = "";
         P007G2_A166ProjectManagerId = new long[1] ;
         P007G2_n166ProjectManagerId = new bool[] {false} ;
         P007G2_A167ProjectManagerName = new string[] {""} ;
         P007G2_A104ProjectDescription = new string[] {""} ;
         P007G2_A103ProjectName = new string[] {""} ;
         P007G2_A105ProjectStatus = new string[] {""} ;
         P007G2_A102ProjectId = new long[1] ;
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41TFProjectStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.projectwwexport__default(),
            new Object[][] {
                new Object[] {
               P007G2_A166ProjectManagerId, P007G2_n166ProjectManagerId, P007G2_A167ProjectManagerName, P007G2_A104ProjectDescription, P007G2_A103ProjectName, P007G2_A105ProjectStatus, P007G2_A102ProjectId
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
      private int AV49GXV1 ;
      private int AV50GXV2 ;
      private int AV59Projectwwds_8_tfprojectstatus_sels_Count ;
      private int AV60GXV3 ;
      private int AV61GXV4 ;
      private long AV44i ;
      private long AV32VisibleColumnCount ;
      private long A166ProjectManagerId ;
      private long A102ProjectId ;
      private string AV38TFProjectName_Sel ;
      private string AV37TFProjectName ;
      private string AV48TFProjectManagerName_Sel ;
      private string AV47TFProjectManagerName ;
      private string AV42TFProjectStatus_Sel ;
      private string AV53Projectwwds_2_tfprojectname ;
      private string AV54Projectwwds_3_tfprojectname_sel ;
      private string AV57Projectwwds_6_tfprojectmanagername ;
      private string AV58Projectwwds_7_tfprojectmanagername_sel ;
      private string scmdbuf ;
      private string lV53Projectwwds_2_tfprojectname ;
      private string lV57Projectwwds_6_tfprojectmanagername ;
      private string A105ProjectStatus ;
      private string A103ProjectName ;
      private string A167ProjectManagerName ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n166ProjectManagerId ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV41TFProjectStatus_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV40TFProjectDescription_Sel ;
      private string AV39TFProjectDescription ;
      private string AV52Projectwwds_1_filterfulltext ;
      private string AV55Projectwwds_4_tfprojectdescription ;
      private string AV56Projectwwds_5_tfprojectdescription_sel ;
      private string lV52Projectwwds_1_filterfulltext ;
      private string lV55Projectwwds_4_tfprojectdescription ;
      private string A104ProjectDescription ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P007G2_A166ProjectManagerId ;
      private bool[] P007G2_n166ProjectManagerId ;
      private string[] P007G2_A167ProjectManagerName ;
      private string[] P007G2_A104ProjectDescription ;
      private string[] P007G2_A103ProjectName ;
      private string[] P007G2_A105ProjectStatus ;
      private long[] P007G2_A102ProjectId ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GxSimpleCollection<string> AV43TFProjectStatus_Sels ;
      private GxSimpleCollection<string> AV59Projectwwds_8_tfprojectstatus_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
   }

   public class projectwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007G2( IGxContext context ,
                                             string A105ProjectStatus ,
                                             GxSimpleCollection<string> AV59Projectwwds_8_tfprojectstatus_sels ,
                                             string AV52Projectwwds_1_filterfulltext ,
                                             string AV54Projectwwds_3_tfprojectname_sel ,
                                             string AV53Projectwwds_2_tfprojectname ,
                                             string AV56Projectwwds_5_tfprojectdescription_sel ,
                                             string AV55Projectwwds_4_tfprojectdescription ,
                                             string AV58Projectwwds_7_tfprojectmanagername_sel ,
                                             string AV57Projectwwds_6_tfprojectmanagername ,
                                             int AV59Projectwwds_8_tfprojectstatus_sels_Count ,
                                             string A103ProjectName ,
                                             string A104ProjectDescription ,
                                             string A167ProjectManagerName ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ProjectManagerId AS ProjectManagerId, T2.EmployeeName AS ProjectManagerName, T1.ProjectDescription, T1.ProjectName, T1.ProjectStatus, T1.ProjectId FROM (Project T1 LEFT JOIN Employee T2 ON T2.EmployeeId = T1.ProjectManagerId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Projectwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.ProjectName) like '%' || LOWER(:lV52Projectwwds_1_filterfulltext)) or ( LOWER(T1.ProjectDescription) like '%' || LOWER(:lV52Projectwwds_1_filterfulltext)) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV52Projectwwds_1_filterfulltext)) or ( 'active' like '%' || LOWER(:lV52Projectwwds_1_filterfulltext) and T1.ProjectStatus = ( 'Active')) or ( 'inactive' like '%' || LOWER(:lV52Projectwwds_1_filterfulltext) and T1.ProjectStatus = ( 'Inactive')))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Projectwwds_3_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Projectwwds_2_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.ProjectName) like LOWER(:lV53Projectwwds_2_tfprojectname))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Projectwwds_3_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV54Projectwwds_3_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProjectName = ( :AV54Projectwwds_3_tfprojectname_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV54Projectwwds_3_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Projectwwds_5_tfprojectdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Projectwwds_4_tfprojectdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.ProjectDescription) like LOWER(:lV55Projectwwds_4_tfprojectdescription))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Projectwwds_5_tfprojectdescription_sel)) && ! ( StringUtil.StrCmp(AV56Projectwwds_5_tfprojectdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProjectDescription = ( :AV56Projectwwds_5_tfprojectdescription_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV56Projectwwds_5_tfprojectdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProjectDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Projectwwds_7_tfprojectmanagername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Projectwwds_6_tfprojectmanagername)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeName) like LOWER(:lV57Projectwwds_6_tfprojectmanagername))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Projectwwds_7_tfprojectmanagername_sel)) && ! ( StringUtil.StrCmp(AV58Projectwwds_7_tfprojectmanagername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV58Projectwwds_7_tfprojectmanagername_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV58Projectwwds_7_tfprojectmanagername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( AV59Projectwwds_8_tfprojectstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV59Projectwwds_8_tfprojectstatus_sels, "T1.ProjectStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProjectName";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProjectName DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProjectDescription";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProjectDescription DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.EmployeeName";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.EmployeeName DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProjectStatus";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProjectStatus DESC";
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
                     return conditional_P007G2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP007G2;
          prmP007G2 = new Object[] {
          new ParDef("lV52Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Projectwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Projectwwds_2_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV54Projectwwds_3_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV55Projectwwds_4_tfprojectdescription",GXType.VarChar,200,0) ,
          new ParDef("AV56Projectwwds_5_tfprojectdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV57Projectwwds_6_tfprojectmanagername",GXType.Char,100,0) ,
          new ParDef("AV58Projectwwds_7_tfprojectmanagername_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 100);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
