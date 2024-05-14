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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class employeeprojectmatrixreport : GXProcedure
   {
      public employeeprojectmatrixreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeeprojectmatrixreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate ,
                           ref GxSimpleCollection<long> aP2_ProjectId ,
                           ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP4_EmployeeId ,
                           ref GxSimpleCollection<long> aP5_EmployeeIds ,
                           ref GxSimpleCollection<long> aP6_ProjectIds ,
                           out GXBaseCollection<SdtSDTProject> aP7_SDTProjects ,
                           out GXBaseCollection<SdtSDTEmployeeProjectHours> aP8_SDTEmployeeProjectHoursCollection ,
                           out string aP9_TotalFormattedWorkTime ,
                           out string aP10_TotalFormattedTime )
      {
         this.AV9FromDate = aP0_FromDate;
         this.AV16ToDate = aP1_ToDate;
         this.AV10ProjectId = aP2_ProjectId;
         this.AV17CompanyLocationId = aP3_CompanyLocationId;
         this.AV8EmployeeId = aP4_EmployeeId;
         this.AV32EmployeeIds = aP5_EmployeeIds;
         this.AV33ProjectIds = aP6_ProjectIds;
         this.AV15SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4") ;
         this.AV12SDTEmployeeProjectHoursCollection = new GXBaseCollection<SdtSDTEmployeeProjectHours>( context, "SDTEmployeeProjectHours", "YTT_version4") ;
         this.AV26TotalFormattedWorkTime = "" ;
         this.AV34TotalFormattedTime = "" ;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV9FromDate;
         aP1_ToDate=this.AV16ToDate;
         aP2_ProjectId=this.AV10ProjectId;
         aP3_CompanyLocationId=this.AV17CompanyLocationId;
         aP4_EmployeeId=this.AV8EmployeeId;
         aP5_EmployeeIds=this.AV32EmployeeIds;
         aP6_ProjectIds=this.AV33ProjectIds;
         aP7_SDTProjects=this.AV15SDTProjects;
         aP8_SDTEmployeeProjectHoursCollection=this.AV12SDTEmployeeProjectHoursCollection;
         aP9_TotalFormattedWorkTime=this.AV26TotalFormattedWorkTime;
         aP10_TotalFormattedTime=this.AV34TotalFormattedTime;
      }

      public string executeUdp( ref DateTime aP0_FromDate ,
                                ref DateTime aP1_ToDate ,
                                ref GxSimpleCollection<long> aP2_ProjectId ,
                                ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP4_EmployeeId ,
                                ref GxSimpleCollection<long> aP5_EmployeeIds ,
                                ref GxSimpleCollection<long> aP6_ProjectIds ,
                                out GXBaseCollection<SdtSDTProject> aP7_SDTProjects ,
                                out GXBaseCollection<SdtSDTEmployeeProjectHours> aP8_SDTEmployeeProjectHoursCollection ,
                                out string aP9_TotalFormattedWorkTime )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, ref aP2_ProjectId, ref aP3_CompanyLocationId, ref aP4_EmployeeId, ref aP5_EmployeeIds, ref aP6_ProjectIds, out aP7_SDTProjects, out aP8_SDTEmployeeProjectHoursCollection, out aP9_TotalFormattedWorkTime, out aP10_TotalFormattedTime);
         return AV34TotalFormattedTime ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 ref GxSimpleCollection<long> aP2_ProjectId ,
                                 ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP4_EmployeeId ,
                                 ref GxSimpleCollection<long> aP5_EmployeeIds ,
                                 ref GxSimpleCollection<long> aP6_ProjectIds ,
                                 out GXBaseCollection<SdtSDTProject> aP7_SDTProjects ,
                                 out GXBaseCollection<SdtSDTEmployeeProjectHours> aP8_SDTEmployeeProjectHoursCollection ,
                                 out string aP9_TotalFormattedWorkTime ,
                                 out string aP10_TotalFormattedTime )
      {
         employeeprojectmatrixreport objemployeeprojectmatrixreport;
         objemployeeprojectmatrixreport = new employeeprojectmatrixreport();
         objemployeeprojectmatrixreport.AV9FromDate = aP0_FromDate;
         objemployeeprojectmatrixreport.AV16ToDate = aP1_ToDate;
         objemployeeprojectmatrixreport.AV10ProjectId = aP2_ProjectId;
         objemployeeprojectmatrixreport.AV17CompanyLocationId = aP3_CompanyLocationId;
         objemployeeprojectmatrixreport.AV8EmployeeId = aP4_EmployeeId;
         objemployeeprojectmatrixreport.AV32EmployeeIds = aP5_EmployeeIds;
         objemployeeprojectmatrixreport.AV33ProjectIds = aP6_ProjectIds;
         objemployeeprojectmatrixreport.AV15SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4") ;
         objemployeeprojectmatrixreport.AV12SDTEmployeeProjectHoursCollection = new GXBaseCollection<SdtSDTEmployeeProjectHours>( context, "SDTEmployeeProjectHours", "YTT_version4") ;
         objemployeeprojectmatrixreport.AV26TotalFormattedWorkTime = "" ;
         objemployeeprojectmatrixreport.AV34TotalFormattedTime = "" ;
         objemployeeprojectmatrixreport.context.SetSubmitInitialConfig(context);
         objemployeeprojectmatrixreport.initialize();
         Submit( executePrivateCatch,objemployeeprojectmatrixreport);
         aP0_FromDate=this.AV9FromDate;
         aP1_ToDate=this.AV16ToDate;
         aP2_ProjectId=this.AV10ProjectId;
         aP3_CompanyLocationId=this.AV17CompanyLocationId;
         aP4_EmployeeId=this.AV8EmployeeId;
         aP5_EmployeeIds=this.AV32EmployeeIds;
         aP6_ProjectIds=this.AV33ProjectIds;
         aP7_SDTProjects=this.AV15SDTProjects;
         aP8_SDTEmployeeProjectHoursCollection=this.AV12SDTEmployeeProjectHoursCollection;
         aP9_TotalFormattedWorkTime=this.AV26TotalFormattedWorkTime;
         aP10_TotalFormattedTime=this.AV34TotalFormattedTime;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((employeeprojectmatrixreport)stateInfo).executePrivate();
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
         AV25TotalWorkTime = 0;
         AV35TotalTime = 0;
         AV28IsEmployeeIdEmpty = ((AV8EmployeeId.Count==0) ? true : false);
         AV29IsCompanyLocationIdEmpty = ((AV17CompanyLocationId.Count==0) ? true : false);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV8EmployeeId ,
                                              A102ProjectId ,
                                              AV10ProjectId ,
                                              AV33ProjectIds ,
                                              AV8EmployeeId.Count ,
                                              AV10ProjectId.Count ,
                                              AV33ProjectIds.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00842 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A166ProjectManagerId = P00842_A166ProjectManagerId[0];
            n166ProjectManagerId = P00842_n166ProjectManagerId[0];
            A106EmployeeId = P00842_A106EmployeeId[0];
            A102ProjectId = P00842_A102ProjectId[0];
            A105ProjectStatus = P00842_A105ProjectStatus[0];
            A104ProjectDescription = P00842_A104ProjectDescription[0];
            A103ProjectName = P00842_A103ProjectName[0];
            AV20ProjectIdCollection.Add(A102ProjectId, 0);
            AV13SDTProject = new SdtSDTProject(context);
            AV13SDTProject.gxTpr_Id = A102ProjectId;
            AV13SDTProject.gxTpr_Projectname = A103ProjectName;
            AV13SDTProject.gxTpr_Projectstatus = A105ProjectStatus;
            AV13SDTProject.gxTpr_Projectdescription = A104ProjectDescription;
            AV15SDTProjects.Add(AV13SDTProject, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV15SDTProjects.Count > 0 )
         {
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A106EmployeeId ,
                                                 AV8EmployeeId ,
                                                 A157CompanyLocationId ,
                                                 AV17CompanyLocationId ,
                                                 AV32EmployeeIds ,
                                                 AV8EmployeeId.Count ,
                                                 AV17CompanyLocationId.Count ,
                                                 AV32EmployeeIds.Count ,
                                                 AV10ProjectId.Count ,
                                                 AV10ProjectId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor P00843 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A100CompanyId = P00843_A100CompanyId[0];
               A106EmployeeId = P00843_A106EmployeeId[0];
               A157CompanyLocationId = P00843_A157CompanyLocationId[0];
               A148EmployeeName = P00843_A148EmployeeName[0];
               A157CompanyLocationId = P00843_A157CompanyLocationId[0];
               if ( ( AV10ProjectId.Count == 0 ) || ( ( new employeehasanyproject(context).executeUdp(  A106EmployeeId,  AV10ProjectId) ) ) )
               {
                  AV11SDTEmployeeProjectHours = new SdtSDTEmployeeProjectHours(context);
                  AV11SDTEmployeeProjectHours.gxTpr_Employeeid = A106EmployeeId;
                  AV11SDTEmployeeProjectHours.gxTpr_Employeename = A148EmployeeName;
                  AV11SDTEmployeeProjectHours.gxTpr_Totaltime = 0;
                  GXt_int1 = 0;
                  new procgetemployeeleavetotal(context ).execute(  A106EmployeeId,  AV9FromDate,  AV16ToDate, out  GXt_int1) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Totalleave = (long)(GXt_int1*8*60);
                  GXt_char2 = "";
                  new procformattime(context ).execute(  AV11SDTEmployeeProjectHours.gxTpr_Totalleave, out  GXt_char2) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Totalformattedleave = GXt_char2;
                  GXt_int1 = 0;
                  new getemployeeexpecteddays(context ).execute( ref  A106EmployeeId, ref  AV9FromDate, ref  AV16ToDate, out  GXt_int1) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Expectedworktime = (long)(GXt_int1*8*60);
                  pr_default.dynParam(2, new Object[]{ new Object[]{
                                                       A102ProjectId ,
                                                       AV20ProjectIdCollection ,
                                                       A106EmployeeId } ,
                                                       new int[]{
                                                       TypeConstants.LONG, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00844 */
                  pr_default.execute(2, new Object[] {A106EmployeeId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A102ProjectId = P00844_A102ProjectId[0];
                     A103ProjectName = P00844_A103ProjectName[0];
                     A103ProjectName = P00844_A103ProjectName[0];
                     AV14SDTProjectHoursItem = new SdtSDTEmployeeProjectHours_ProjectHoursItem(context);
                     AV14SDTProjectHoursItem.gxTpr_Projectid = A102ProjectId;
                     AV14SDTProjectHoursItem.gxTpr_Projecttime = 0;
                     AV14SDTProjectHoursItem.gxTpr_Projectname = A103ProjectName;
                     GXt_boolean3 = AV18HasProject;
                     new employeehasproject(context ).execute(  A106EmployeeId,  A102ProjectId, out  GXt_boolean3) ;
                     AV18HasProject = GXt_boolean3;
                     if ( AV18HasProject )
                     {
                        new getemployeehourlogtotal(context ).execute(  A106EmployeeId,  A102ProjectId,  AV9FromDate,  AV16ToDate, out  AV23TotalHourLogs, out  AV24FormattedHours) ;
                        AV14SDTProjectHoursItem.gxTpr_Projecttime = AV23TotalHourLogs;
                        AV14SDTProjectHoursItem.gxTpr_Projectformattedtime = AV24FormattedHours;
                     }
                     AV11SDTEmployeeProjectHours.gxTpr_Projecthours.Add(AV14SDTProjectHoursItem, 0);
                     AV11SDTEmployeeProjectHours.gxTpr_Totaltime = (long)(AV11SDTEmployeeProjectHours.gxTpr_Totaltime+AV23TotalHourLogs);
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
                  GXt_char2 = "";
                  new procformattime(context ).execute(  AV11SDTEmployeeProjectHours.gxTpr_Totaltime, out  GXt_char2) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Totalformattedtime = GXt_char2;
                  AV11SDTEmployeeProjectHours.gxTpr_Isworktimeoptimal = (bool)((AV11SDTEmployeeProjectHours.gxTpr_Totaltime>=AV11SDTEmployeeProjectHours.gxTpr_Expectedworktime));
                  AV11SDTEmployeeProjectHours.gxTpr_Total = (long)(AV11SDTEmployeeProjectHours.gxTpr_Totaltime+AV11SDTEmployeeProjectHours.gxTpr_Totalleave);
                  AV35TotalTime = (long)(AV35TotalTime+(AV11SDTEmployeeProjectHours.gxTpr_Total));
                  GXt_char2 = "";
                  new procformattime(context ).execute(  AV11SDTEmployeeProjectHours.gxTpr_Total, out  GXt_char2) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Formattedtotal = GXt_char2;
                  if ( AV11SDTEmployeeProjectHours.gxTpr_Totaltime > 0 )
                  {
                     AV12SDTEmployeeProjectHoursCollection.Add(AV11SDTEmployeeProjectHours, 0);
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         GXt_char2 = AV34TotalFormattedTime;
         new procformattime(context ).execute(  AV35TotalTime, out  GXt_char2) ;
         AV34TotalFormattedTime = GXt_char2;
         GXt_char2 = AV26TotalFormattedWorkTime;
         new procformattime(context ).execute(  AV25TotalWorkTime, out  GXt_char2) ;
         AV26TotalFormattedWorkTime = GXt_char2;
         this.cleanup();
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
         AV15SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         AV12SDTEmployeeProjectHoursCollection = new GXBaseCollection<SdtSDTEmployeeProjectHours>( context, "SDTEmployeeProjectHours", "YTT_version4");
         AV26TotalFormattedWorkTime = "";
         AV34TotalFormattedTime = "";
         scmdbuf = "";
         P00842_A166ProjectManagerId = new long[1] ;
         P00842_n166ProjectManagerId = new bool[] {false} ;
         P00842_A106EmployeeId = new long[1] ;
         P00842_A102ProjectId = new long[1] ;
         P00842_A105ProjectStatus = new string[] {""} ;
         P00842_A104ProjectDescription = new string[] {""} ;
         P00842_A103ProjectName = new string[] {""} ;
         A105ProjectStatus = "";
         A104ProjectDescription = "";
         A103ProjectName = "";
         AV20ProjectIdCollection = new GxSimpleCollection<long>();
         AV13SDTProject = new SdtSDTProject(context);
         P00843_A100CompanyId = new long[1] ;
         P00843_A106EmployeeId = new long[1] ;
         P00843_A157CompanyLocationId = new long[1] ;
         P00843_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV11SDTEmployeeProjectHours = new SdtSDTEmployeeProjectHours(context);
         P00844_A106EmployeeId = new long[1] ;
         P00844_A102ProjectId = new long[1] ;
         P00844_A103ProjectName = new string[] {""} ;
         AV14SDTProjectHoursItem = new SdtSDTEmployeeProjectHours_ProjectHoursItem(context);
         AV24FormattedHours = "";
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeprojectmatrixreport__default(),
            new Object[][] {
                new Object[] {
               P00842_A166ProjectManagerId, P00842_n166ProjectManagerId, P00842_A106EmployeeId, P00842_A102ProjectId, P00842_A105ProjectStatus, P00842_A104ProjectDescription, P00842_A103ProjectName
               }
               , new Object[] {
               P00843_A100CompanyId, P00843_A106EmployeeId, P00843_A157CompanyLocationId, P00843_A148EmployeeName
               }
               , new Object[] {
               P00844_A106EmployeeId, P00844_A102ProjectId, P00844_A103ProjectName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8EmployeeId_Count ;
      private int AV10ProjectId_Count ;
      private int AV33ProjectIds_Count ;
      private int AV17CompanyLocationId_Count ;
      private int AV32EmployeeIds_Count ;
      private long AV25TotalWorkTime ;
      private long AV35TotalTime ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A166ProjectManagerId ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long GXt_int1 ;
      private long AV23TotalHourLogs ;
      private string AV26TotalFormattedWorkTime ;
      private string AV34TotalFormattedTime ;
      private string scmdbuf ;
      private string A105ProjectStatus ;
      private string A103ProjectName ;
      private string A148EmployeeName ;
      private string AV24FormattedHours ;
      private string GXt_char2 ;
      private DateTime AV9FromDate ;
      private DateTime AV16ToDate ;
      private bool AV28IsEmployeeIdEmpty ;
      private bool AV29IsCompanyLocationIdEmpty ;
      private bool n166ProjectManagerId ;
      private bool AV18HasProject ;
      private bool GXt_boolean3 ;
      private string A104ProjectDescription ;
      private GxSimpleCollection<long> AV10ProjectId ;
      private GxSimpleCollection<long> AV17CompanyLocationId ;
      private GxSimpleCollection<long> AV8EmployeeId ;
      private GxSimpleCollection<long> AV32EmployeeIds ;
      private GxSimpleCollection<long> AV33ProjectIds ;
      private GxSimpleCollection<long> AV20ProjectIdCollection ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> aP2_ProjectId ;
      private GxSimpleCollection<long> aP3_CompanyLocationId ;
      private GxSimpleCollection<long> aP4_EmployeeId ;
      private GxSimpleCollection<long> aP5_EmployeeIds ;
      private GxSimpleCollection<long> aP6_ProjectIds ;
      private IDataStoreProvider pr_default ;
      private long[] P00842_A166ProjectManagerId ;
      private bool[] P00842_n166ProjectManagerId ;
      private long[] P00842_A106EmployeeId ;
      private long[] P00842_A102ProjectId ;
      private string[] P00842_A105ProjectStatus ;
      private string[] P00842_A104ProjectDescription ;
      private string[] P00842_A103ProjectName ;
      private long[] P00843_A100CompanyId ;
      private long[] P00843_A106EmployeeId ;
      private long[] P00843_A157CompanyLocationId ;
      private string[] P00843_A148EmployeeName ;
      private long[] P00844_A106EmployeeId ;
      private long[] P00844_A102ProjectId ;
      private string[] P00844_A103ProjectName ;
      private GXBaseCollection<SdtSDTProject> aP7_SDTProjects ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> aP8_SDTEmployeeProjectHoursCollection ;
      private string aP9_TotalFormattedWorkTime ;
      private string aP10_TotalFormattedTime ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> AV12SDTEmployeeProjectHoursCollection ;
      private GXBaseCollection<SdtSDTProject> AV15SDTProjects ;
      private SdtSDTEmployeeProjectHours AV11SDTEmployeeProjectHours ;
      private SdtSDTEmployeeProjectHours_ProjectHoursItem AV14SDTProjectHoursItem ;
      private SdtSDTProject AV13SDTProject ;
   }

   public class employeeprojectmatrixreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00842( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV8EmployeeId ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV10ProjectId ,
                                             GxSimpleCollection<long> AV33ProjectIds ,
                                             int AV8EmployeeId_Count ,
                                             int AV10ProjectId_Count ,
                                             int AV33ProjectIds_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ProjectManagerId, T2.EmployeeId, T1.ProjectId, T1.ProjectStatus, T1.ProjectDescription, T1.ProjectName FROM (Project T1 LEFT JOIN EmployeeProject T2 ON T2.EmployeeId = T1.ProjectManagerId AND T2.ProjectId = T1.ProjectId)";
         if ( AV8EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8EmployeeId, "T2.EmployeeId IN (", ")")+")");
         }
         if ( AV10ProjectId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV10ProjectId, "T1.ProjectId IN (", ")")+")");
         }
         if ( AV33ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProjectName";
         GXv_Object4[0] = scmdbuf;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00843( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV8EmployeeId ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV17CompanyLocationId ,
                                             GxSimpleCollection<long> AV32EmployeeIds ,
                                             int AV8EmployeeId_Count ,
                                             int AV17CompanyLocationId_Count ,
                                             int AV32EmployeeIds_Count ,
                                             int AV10ProjectId_Count ,
                                             GxSimpleCollection<long> AV10ProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId, T1.EmployeeName FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! ( AV8EmployeeId_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( ! ( AV17CompanyLocationId_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV17CompanyLocationId, "T2.CompanyLocationId IN (", ")")+")");
         }
         if ( AV32EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV32EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00844( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV20ProjectIdCollection ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[1];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T2.ProjectName FROM (EmployeeProject T1 LEFT JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :EmployeeId)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV20ProjectIdCollection, "T1.ProjectId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00842(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (GxSimpleCollection<long>)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
               case 1 :
                     return conditional_P00843(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (GxSimpleCollection<long>)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (GxSimpleCollection<long>)dynConstraints[9] );
               case 2 :
                     return conditional_P00844(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00842;
          prmP00842 = new Object[] {
          };
          Object[] prmP00843;
          prmP00843 = new Object[] {
          };
          Object[] prmP00844;
          prmP00844 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00842", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00842,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00843", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00843,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00844", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00844,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
