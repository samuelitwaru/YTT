using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class exportexceltable : GXProcedure
   {
      public exportexceltable( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public exportexceltable( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate ,
                           ref GxSimpleCollection<long> aP2_ProjectId ,
                           ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP4_EmployeeId ,
                           ref GxSimpleCollection<long> aP5_ProjectIds ,
                           ref GXBaseCollection<SdtSDTEmployeeProjectHours> aP6_SDTEmployeeProjectHoursCollection ,
                           ref string aP7_TotalFormattedWorkTime ,
                           ref string aP8_TotalFormattedTime ,
                           out string aP9_Filename ,
                           out string aP10_ErrorMessage )
      {
         this.AV75FromDate = aP0_FromDate;
         this.AV76ToDate = aP1_ToDate;
         this.AV44ProjectId = aP2_ProjectId;
         this.AV46CompanyLocationId = aP3_CompanyLocationId;
         this.AV24EmployeeId = aP4_EmployeeId;
         this.AV85ProjectIds = aP5_ProjectIds;
         this.AV64SDTEmployeeProjectHoursCollection = aP6_SDTEmployeeProjectHoursCollection;
         this.AV89TotalFormattedWorkTime = aP7_TotalFormattedWorkTime;
         this.AV90TotalFormattedTime = aP8_TotalFormattedTime;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV75FromDate;
         aP1_ToDate=this.AV76ToDate;
         aP2_ProjectId=this.AV44ProjectId;
         aP3_CompanyLocationId=this.AV46CompanyLocationId;
         aP4_EmployeeId=this.AV24EmployeeId;
         aP5_ProjectIds=this.AV85ProjectIds;
         aP6_SDTEmployeeProjectHoursCollection=this.AV64SDTEmployeeProjectHoursCollection;
         aP7_TotalFormattedWorkTime=this.AV89TotalFormattedWorkTime;
         aP8_TotalFormattedTime=this.AV90TotalFormattedTime;
         aP9_Filename=this.AV12Filename;
         aP10_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FromDate ,
                                ref DateTime aP1_ToDate ,
                                ref GxSimpleCollection<long> aP2_ProjectId ,
                                ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP4_EmployeeId ,
                                ref GxSimpleCollection<long> aP5_ProjectIds ,
                                ref GXBaseCollection<SdtSDTEmployeeProjectHours> aP6_SDTEmployeeProjectHoursCollection ,
                                ref string aP7_TotalFormattedWorkTime ,
                                ref string aP8_TotalFormattedTime ,
                                out string aP9_Filename )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, ref aP2_ProjectId, ref aP3_CompanyLocationId, ref aP4_EmployeeId, ref aP5_ProjectIds, ref aP6_SDTEmployeeProjectHoursCollection, ref aP7_TotalFormattedWorkTime, ref aP8_TotalFormattedTime, out aP9_Filename, out aP10_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 ref GxSimpleCollection<long> aP2_ProjectId ,
                                 ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP4_EmployeeId ,
                                 ref GxSimpleCollection<long> aP5_ProjectIds ,
                                 ref GXBaseCollection<SdtSDTEmployeeProjectHours> aP6_SDTEmployeeProjectHoursCollection ,
                                 ref string aP7_TotalFormattedWorkTime ,
                                 ref string aP8_TotalFormattedTime ,
                                 out string aP9_Filename ,
                                 out string aP10_ErrorMessage )
      {
         exportexceltable objexportexceltable;
         objexportexceltable = new exportexceltable();
         objexportexceltable.AV75FromDate = aP0_FromDate;
         objexportexceltable.AV76ToDate = aP1_ToDate;
         objexportexceltable.AV44ProjectId = aP2_ProjectId;
         objexportexceltable.AV46CompanyLocationId = aP3_CompanyLocationId;
         objexportexceltable.AV24EmployeeId = aP4_EmployeeId;
         objexportexceltable.AV85ProjectIds = aP5_ProjectIds;
         objexportexceltable.AV64SDTEmployeeProjectHoursCollection = aP6_SDTEmployeeProjectHoursCollection;
         objexportexceltable.AV89TotalFormattedWorkTime = aP7_TotalFormattedWorkTime;
         objexportexceltable.AV90TotalFormattedTime = aP8_TotalFormattedTime;
         objexportexceltable.AV12Filename = "" ;
         objexportexceltable.AV13ErrorMessage = "" ;
         objexportexceltable.context.SetSubmitInitialConfig(context);
         objexportexceltable.initialize();
         Submit( executePrivateCatch,objexportexceltable);
         aP0_FromDate=this.AV75FromDate;
         aP1_ToDate=this.AV76ToDate;
         aP2_ProjectId=this.AV44ProjectId;
         aP3_CompanyLocationId=this.AV46CompanyLocationId;
         aP4_EmployeeId=this.AV24EmployeeId;
         aP5_ProjectIds=this.AV85ProjectIds;
         aP6_SDTEmployeeProjectHoursCollection=this.AV64SDTEmployeeProjectHoursCollection;
         aP7_TotalFormattedWorkTime=this.AV89TotalFormattedWorkTime;
         aP8_TotalFormattedTime=this.AV90TotalFormattedTime;
         aP9_Filename=this.AV12Filename;
         aP10_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportexceltable)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'GETSESSIONVARIABLES' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV88ShowLeaveTotal = BooleanUtil.Val( AV87WebSession.Get("ShowLeaveTotal"));
         GXt_objcol_SdtSDTProject1 = AV63SDTProjects;
         new getworkhourlogdurationbyproject(context ).execute( ref  AV75FromDate, ref  AV76ToDate, ref  AV44ProjectId, ref  AV46CompanyLocationId, ref  AV24EmployeeId, ref  AV85ProjectIds, out  GXt_objcol_SdtSDTProject1) ;
         AV63SDTProjects = GXt_objcol_SdtSDTProject1;
         AV50Columns.Add("Projects:", 0);
         AV91GXV1 = 1;
         while ( AV91GXV1 <= AV63SDTProjects.Count )
         {
            AV65SDTProject = ((SdtSDTProject)AV63SDTProjects.Item(AV91GXV1));
            AV50Columns.Add(StringUtil.Trim( AV65SDTProject.gxTpr_Projectname), 0);
            AV91GXV1 = (int)(AV91GXV1+1);
         }
         AV50Columns.Add("Total Work Hours", 0);
         if ( AV88ShowLeaveTotal )
         {
            AV50Columns.Add("Total Leave Hours", 0);
            AV50Columns.Add("Total", 0);
         }
         AV68ColumnString = AV50Columns.ToJSonString(false);
         AV68ColumnString = AV64SDTEmployeeProjectHoursCollection.ToJSonString(false);
         Gx_msg = AV68ColumnString;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 1;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV93GXV2 = 1;
         while ( AV93GXV2 <= AV64SDTEmployeeProjectHoursCollection.Count )
         {
            AV66SDTEmployeeProjectHours = ((SdtSDTEmployeeProjectHours)AV64SDTEmployeeProjectHoursCollection.Item(AV93GXV2));
            AV14CellRow = (int)(AV14CellRow+1);
            AV11ExcelDocument.get_Cells(AV14CellRow, 1, 1, 1).Text = StringUtil.Trim( AV66SDTEmployeeProjectHours.gxTpr_Employeename);
            AV94GXV3 = 1;
            while ( AV94GXV3 <= AV66SDTEmployeeProjectHours.gxTpr_Projecthours.Count )
            {
               AV67ProjectHoursItem = ((SdtSDTEmployeeProjectHours_ProjectHoursItem)AV66SDTEmployeeProjectHours.gxTpr_Projecthours.Item(AV94GXV3));
               AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf(StringUtil.Trim( AV67ProjectHoursItem.gxTpr_Projectname)), 1, 1).Text = AV67ProjectHoursItem.gxTpr_Projectformattedtime;
               AV94GXV3 = (int)(AV94GXV3+1);
            }
            AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf("Total Work Hours"), 1, 1).Text = AV66SDTEmployeeProjectHours.gxTpr_Totalformattedtime;
            if ( AV88ShowLeaveTotal )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf("Total Leave Hours"), 1, 1).Text = AV66SDTEmployeeProjectHours.gxTpr_Totalformattedleave;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf("Total"), 1, 1).Text = AV66SDTEmployeeProjectHours.gxTpr_Totalformattedtime;
            }
            AV93GXV2 = (int)(AV93GXV2+1);
         }
         AV14CellRow = (int)(AV14CellRow+1);
         AV38VisibleColumnCount = 0;
         AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Text = "Total";
         AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Bold = 1;
         AV95GXV4 = 1;
         while ( AV95GXV4 <= AV63SDTProjects.Count )
         {
            AV65SDTProject = ((SdtSDTProject)AV63SDTProjects.Item(AV95GXV4));
            AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf(StringUtil.Trim( AV65SDTProject.gxTpr_Projectname)), 1, 1).Text = AV65SDTProject.gxTpr_Projectformattedtime;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf(StringUtil.Trim( AV65SDTProject.gxTpr_Projectname)), 1, 1).Bold = 1;
            AV95GXV4 = (int)(AV95GXV4+1);
         }
         AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf("Total Work Hours"), 1, 1).Text = AV90TotalFormattedTime;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf("Total Work Hours"), 1, 1).Bold = 1;
         if ( AV88ShowLeaveTotal )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf("Total"), 1, 1).Text = AV90TotalFormattedTime;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV50Columns.IndexOf("Total"), 1, 1).Bold = 1;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S141 ();
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
         AV12Filename = "ReportExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( Gx_date)), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( Gx_date)), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( Gx_date)), 10, 0)) + ".xlsx";
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
         AV38VisibleColumnCount = 0;
         AV97GXV5 = 1;
         while ( AV97GXV5 <= AV50Columns.Count )
         {
            AV49Column = ((string)AV50Columns.Item(AV97GXV5));
            AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Text = AV49Column;
            AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Bold = 1;
            AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Color = 11;
            AV38VisibleColumnCount = (long)(AV38VisibleColumnCount+1);
            AV97GXV5 = (int)(AV97GXV5+1);
         }
      }

      protected void S141( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
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

      protected void S151( )
      {
         /* 'GETSESSIONVARIABLES' Routine */
         returnInSub = false;
         AV89TotalFormattedWorkTime = AV87WebSession.Get("TotalFormattedWorkTime");
         AV90TotalFormattedTime = AV87WebSession.Get("TotalFormattedTime");
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
         AV87WebSession = context.GetSession();
         AV63SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         GXt_objcol_SdtSDTProject1 = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         AV50Columns = new GxSimpleCollection<string>();
         AV65SDTProject = new SdtSDTProject(context);
         AV68ColumnString = "";
         Gx_msg = "";
         AV66SDTEmployeeProjectHours = new SdtSDTEmployeeProjectHours(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV67ProjectHoursItem = new SdtSDTEmployeeProjectHours_ProjectHoursItem(context);
         Gx_date = DateTime.MinValue;
         AV49Column = "";
         AV25Session = context.GetSession();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private int AV91GXV1 ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV93GXV2 ;
      private int AV94GXV3 ;
      private int AV95GXV4 ;
      private int AV97GXV5 ;
      private long AV38VisibleColumnCount ;
      private string AV89TotalFormattedWorkTime ;
      private string AV90TotalFormattedTime ;
      private string Gx_msg ;
      private DateTime AV75FromDate ;
      private DateTime AV76ToDate ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool AV88ShowLeaveTotal ;
      private string AV68ColumnString ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV49Column ;
      private GxSimpleCollection<long> AV44ProjectId ;
      private GxSimpleCollection<long> AV46CompanyLocationId ;
      private GxSimpleCollection<long> AV24EmployeeId ;
      private GxSimpleCollection<long> AV85ProjectIds ;
      private IGxSession AV87WebSession ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> aP2_ProjectId ;
      private GxSimpleCollection<long> aP3_CompanyLocationId ;
      private GxSimpleCollection<long> aP4_EmployeeId ;
      private GxSimpleCollection<long> aP5_ProjectIds ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> aP6_SDTEmployeeProjectHoursCollection ;
      private string aP7_TotalFormattedWorkTime ;
      private string aP8_TotalFormattedTime ;
      private string aP9_Filename ;
      private string aP10_ErrorMessage ;
      private IGxSession AV25Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GxSimpleCollection<string> AV50Columns ;
      private GXBaseCollection<SdtSDTProject> AV63SDTProjects ;
      private GXBaseCollection<SdtSDTProject> GXt_objcol_SdtSDTProject1 ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> AV64SDTEmployeeProjectHoursCollection ;
      private SdtSDTProject AV65SDTProject ;
      private SdtSDTEmployeeProjectHours AV66SDTEmployeeProjectHours ;
      private SdtSDTEmployeeProjectHours_ProjectHoursItem AV67ProjectHoursItem ;
   }

}
