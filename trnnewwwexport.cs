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
   public class trnnewwwexport : GXProcedure
   {
      public trnnewwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trnnewwwexport( IGxContext context )
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
         AV12Filename = GXt_char1 + "TrnNewWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFTrnNewId) && (0==AV36TFTrnNewId_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "New Id") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFTrnNewId;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFTrnNewId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTrnNewName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "New Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTrnNewName_Sel)) ? "(Empty)" : AV38TFTrnNewName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTrnNewName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "New Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTrnNewName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV39TFTrnNewDate) && (DateTime.MinValue==AV40TFTrnNewDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "New Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV39TFTrnNewDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV40TFTrnNewDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("TrnNewWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("TrnNewWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV42GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV44Trnnewwwds_1_filterfulltext = AV19FilterFullText;
         AV45Trnnewwwds_2_tftrnnewid = AV35TFTrnNewId;
         AV46Trnnewwwds_3_tftrnnewid_to = AV36TFTrnNewId_To;
         AV47Trnnewwwds_4_tftrnnewname = AV37TFTrnNewName;
         AV48Trnnewwwds_5_tftrnnewname_sel = AV38TFTrnNewName_Sel;
         AV49Trnnewwwds_6_tftrnnewdate = AV39TFTrnNewDate;
         AV50Trnnewwwds_7_tftrnnewdate_to = AV40TFTrnNewDate_To;
         AV51Udparg8 = new getloggedinusercompanyid(context).executeUdp( );
         AV51Udparg8 = new getloggedinusercompanyid(context).executeUdp( );
         AV51Udparg8 = new getloggedinusercompanyid(context).executeUdp( );
         AV51Udparg8 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Trnnewwwds_1_filterfulltext ,
                                              AV45Trnnewwwds_2_tftrnnewid ,
                                              AV46Trnnewwwds_3_tftrnnewid_to ,
                                              AV48Trnnewwwds_5_tftrnnewname_sel ,
                                              AV47Trnnewwwds_4_tftrnnewname ,
                                              AV49Trnnewwwds_6_tftrnnewdate ,
                                              AV50Trnnewwwds_7_tftrnnewdate_to ,
                                              A180TrnNewId ,
                                              A181TrnNewName ,
                                              A182TrnNewDate ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV51Udparg8 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV44Trnnewwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trnnewwwds_1_filterfulltext), "%", "");
         lV44Trnnewwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trnnewwwds_1_filterfulltext), "%", "");
         lV47Trnnewwwds_4_tftrnnewname = StringUtil.PadR( StringUtil.RTrim( AV47Trnnewwwds_4_tftrnnewname), 100, "%");
         /* Using cursor P00BS2 */
         pr_default.execute(0, new Object[] {lV44Trnnewwwds_1_filterfulltext, lV44Trnnewwwds_1_filterfulltext, AV45Trnnewwwds_2_tftrnnewid, AV46Trnnewwwds_3_tftrnnewid_to, lV47Trnnewwwds_4_tftrnnewname, AV48Trnnewwwds_5_tftrnnewname_sel, AV49Trnnewwwds_6_tftrnnewdate, AV50Trnnewwwds_7_tftrnnewdate_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A182TrnNewDate = P00BS2_A182TrnNewDate[0];
            A181TrnNewName = P00BS2_A181TrnNewName[0];
            A180TrnNewId = P00BS2_A180TrnNewId[0];
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
            AV52GXV2 = 1;
            while ( AV52GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV52GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TrnNewId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A180TrnNewId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TrnNewName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A181TrnNewName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TrnNewDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A182TrnNewDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "TrnNewImage") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "";
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV52GXV2 = (int)(AV52GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "TrnNewWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TrnNewId",  "",  "New Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TrnNewName",  "",  "New Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TrnNewDate",  "",  "New Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "TrnNewImage",  "",  "New Image",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "TrnNewWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("TrnNewWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TrnNewWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("TrnNewWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV53GXV3 = 1;
         while ( AV53GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV53GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTRNNEWID") == 0 )
            {
               AV35TFTrnNewId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFTrnNewId_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTRNNEWNAME") == 0 )
            {
               AV37TFTrnNewName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTRNNEWNAME_SEL") == 0 )
            {
               AV38TFTrnNewName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTRNNEWDATE") == 0 )
            {
               AV39TFTrnNewDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV40TFTrnNewDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV53GXV3 = (int)(AV53GXV3+1);
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
         AV38TFTrnNewName_Sel = "";
         AV37TFTrnNewName = "";
         AV39TFTrnNewDate = DateTime.MinValue;
         AV40TFTrnNewDate_To = DateTime.MinValue;
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV44Trnnewwwds_1_filterfulltext = "";
         AV47Trnnewwwds_4_tftrnnewname = "";
         AV48Trnnewwwds_5_tftrnnewname_sel = "";
         AV49Trnnewwwds_6_tftrnnewdate = DateTime.MinValue;
         AV50Trnnewwwds_7_tftrnnewdate_to = DateTime.MinValue;
         lV44Trnnewwwds_1_filterfulltext = "";
         lV47Trnnewwwds_4_tftrnnewname = "";
         A181TrnNewName = "";
         A182TrnNewDate = DateTime.MinValue;
         P00BS2_A182TrnNewDate = new DateTime[] {DateTime.MinValue} ;
         P00BS2_A181TrnNewName = new string[] {""} ;
         P00BS2_A180TrnNewId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trnnewwwexport__default(),
            new Object[][] {
                new Object[] {
               P00BS2_A182TrnNewDate, P00BS2_A181TrnNewName, P00BS2_A180TrnNewId
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
      private int AV42GXV1 ;
      private int AV52GXV2 ;
      private int AV53GXV3 ;
      private long AV35TFTrnNewId ;
      private long AV36TFTrnNewId_To ;
      private long AV32VisibleColumnCount ;
      private long AV45Trnnewwwds_2_tftrnnewid ;
      private long AV46Trnnewwwds_3_tftrnnewid_to ;
      private long AV51Udparg8 ;
      private long A180TrnNewId ;
      private string AV38TFTrnNewName_Sel ;
      private string AV37TFTrnNewName ;
      private string AV47Trnnewwwds_4_tftrnnewname ;
      private string AV48Trnnewwwds_5_tftrnnewname_sel ;
      private string lV47Trnnewwwds_4_tftrnnewname ;
      private string A181TrnNewName ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV39TFTrnNewDate ;
      private DateTime AV40TFTrnNewDate_To ;
      private DateTime AV49Trnnewwwds_6_tftrnnewdate ;
      private DateTime AV50Trnnewwwds_7_tftrnnewdate_to ;
      private DateTime A182TrnNewDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV44Trnnewwwds_1_filterfulltext ;
      private string lV44Trnnewwwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00BS2_A182TrnNewDate ;
      private string[] P00BS2_A181TrnNewName ;
      private long[] P00BS2_A180TrnNewId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class trnnewwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BS2( IGxContext context ,
                                             string AV44Trnnewwwds_1_filterfulltext ,
                                             long AV45Trnnewwwds_2_tftrnnewid ,
                                             long AV46Trnnewwwds_3_tftrnnewid_to ,
                                             string AV48Trnnewwwds_5_tftrnnewname_sel ,
                                             string AV47Trnnewwwds_4_tftrnnewname ,
                                             DateTime AV49Trnnewwwds_6_tftrnnewdate ,
                                             DateTime AV50Trnnewwwds_7_tftrnnewdate_to ,
                                             long A180TrnNewId ,
                                             string A181TrnNewName ,
                                             DateTime A182TrnNewDate ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             long AV51Udparg8 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[8];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT TrnNewDate, TrnNewName, TrnNewId FROM TrnNew";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trnnewwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(TrnNewId,'9999999999'), 2) like '%' || :lV44Trnnewwwds_1_filterfulltext) or ( LOWER(TrnNewName) like '%' || LOWER(:lV44Trnnewwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV45Trnnewwwds_2_tftrnnewid) )
         {
            AddWhere(sWhereString, "(TrnNewId >= :AV45Trnnewwwds_2_tftrnnewid)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV46Trnnewwwds_3_tftrnnewid_to) )
         {
            AddWhere(sWhereString, "(TrnNewId <= :AV46Trnnewwwds_3_tftrnnewid_to)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trnnewwwds_5_tftrnnewname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trnnewwwds_4_tftrnnewname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(TrnNewName) like LOWER(:lV47Trnnewwwds_4_tftrnnewname))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trnnewwwds_5_tftrnnewname_sel)) && ! ( StringUtil.StrCmp(AV48Trnnewwwds_5_tftrnnewname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TrnNewName = ( :AV48Trnnewwwds_5_tftrnnewname_sel))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trnnewwwds_5_tftrnnewname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TrnNewName))=0))");
         }
         if ( ! (DateTime.MinValue==AV49Trnnewwwds_6_tftrnnewdate) )
         {
            AddWhere(sWhereString, "(TrnNewDate >= :AV49Trnnewwwds_6_tftrnnewdate)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV50Trnnewwwds_7_tftrnnewdate_to) )
         {
            AddWhere(sWhereString, "(TrnNewDate <= :AV50Trnnewwwds_7_tftrnnewdate_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY TrnNewName";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TrnNewName DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY TrnNewId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TrnNewId DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY TrnNewDate";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TrnNewDate DESC";
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
                     return conditional_P00BS2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] , (long)dynConstraints[13] );
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
          Object[] prmP00BS2;
          prmP00BS2 = new Object[] {
          new ParDef("lV44Trnnewwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trnnewwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV45Trnnewwwds_2_tftrnnewid",GXType.Int64,10,0) ,
          new ParDef("AV46Trnnewwwds_3_tftrnnewid_to",GXType.Int64,10,0) ,
          new ParDef("lV47Trnnewwwds_4_tftrnnewname",GXType.Char,100,0) ,
          new ParDef("AV48Trnnewwwds_5_tftrnnewname_sel",GXType.Char,100,0) ,
          new ParDef("AV49Trnnewwwds_6_tftrnnewdate",GXType.Date,8,0) ,
          new ParDef("AV50Trnnewwwds_7_tftrnnewdate_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BS2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}