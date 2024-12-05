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
         ExecuteImpl();
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
         SubmitImpl();
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

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25TotalWorkTime = 0;
         AV35TotalTime = 0;
         AV28IsEmployeeIdEmpty = ((AV8EmployeeId.Count==0) ? true : false);
         AV29IsCompanyLocationIdEmpty = ((AV17CompanyLocationId.Count==0) ? true : false);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV17CompanyLocationId ,
                                              A106EmployeeId ,
                                              AV8EmployeeId ,
                                              A102ProjectId ,
                                              AV10ProjectId ,
                                              AV33ProjectIds ,
                                              AV17CompanyLocationId.Count ,
                                              AV8EmployeeId.Count ,
                                              AV10ProjectId.Count ,
                                              AV33ProjectIds.Count ,
                                              AV9FromDate ,
                                              AV16ToDate ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00842 */
         pr_default.execute(0, new Object[] {AV9FromDate, AV16ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00842_A100CompanyId[0];
            A119WorkHourLogDate = P00842_A119WorkHourLogDate[0];
            A102ProjectId = P00842_A102ProjectId[0];
            A106EmployeeId = P00842_A106EmployeeId[0];
            A157CompanyLocationId = P00842_A157CompanyLocationId[0];
            A105ProjectStatus = P00842_A105ProjectStatus[0];
            A104ProjectDescription = P00842_A104ProjectDescription[0];
            A103ProjectName = P00842_A103ProjectName[0];
            A105ProjectStatus = P00842_A105ProjectStatus[0];
            A104ProjectDescription = P00842_A104ProjectDescription[0];
            A103ProjectName = P00842_A103ProjectName[0];
            A100CompanyId = P00842_A100CompanyId[0];
            A157CompanyLocationId = P00842_A157CompanyLocationId[0];
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
         GXt_char1 = AV26TotalFormattedWorkTime;
         new procformattime(context ).execute(  AV25TotalWorkTime, out  GXt_char1) ;
         AV26TotalFormattedWorkTime = GXt_char1;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV17CompanyLocationId ,
                                              AV17CompanyLocationId.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor P00843 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A157CompanyLocationId = P00843_A157CompanyLocationId[0];
            AV38WorkDate = AV9FromDate;
            AV39DayCount = 0;
            AV40CompanyHolidayDateCollection = (GxSimpleCollection<DateTime>)(new GxSimpleCollection<DateTime>());
            /* Using cursor P00844 */
            pr_default.execute(2, new Object[] {A157CompanyLocationId, AV9FromDate, AV16ToDate});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A100CompanyId = P00844_A100CompanyId[0];
               A139HolidayIsActive = P00844_A139HolidayIsActive[0];
               A115HolidayStartDate = P00844_A115HolidayStartDate[0];
               A157CompanyLocationId = P00844_A157CompanyLocationId[0];
               A113HolidayId = P00844_A113HolidayId[0];
               A157CompanyLocationId = P00844_A157CompanyLocationId[0];
               AV40CompanyHolidayDateCollection.Add(A115HolidayStartDate, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            while ( DateTimeUtil.ResetTime ( AV38WorkDate ) <= DateTimeUtil.ResetTime ( AV16ToDate ) )
            {
               new logtofile(context ).execute(  "    "+context.localUtil.DToC( AV38WorkDate, 2, "/")+" = "+StringUtil.Str( (decimal)(DateTimeUtil.Dow( AV38WorkDate)), 10, 0)) ;
               if ( DateTimeUtil.Dow( AV38WorkDate) == 7 )
               {
                  AV38WorkDate = DateTimeUtil.DAdd( AV38WorkDate, (2));
               }
               else if ( DateTimeUtil.Dow( AV38WorkDate) == 1 )
               {
                  AV38WorkDate = DateTimeUtil.DAdd( AV38WorkDate, (1));
               }
               else if ( ( DateTimeUtil.Dow( AV38WorkDate) == 2 ) && ( ( DateTimeUtil.DDiff( AV16ToDate , AV38WorkDate ) ) >= 5 ) )
               {
                  AV39DayCount = (short)(AV39DayCount+5);
                  AV38WorkDate = DateTimeUtil.DAdd( AV38WorkDate, (7));
               }
               else
               {
                  AV39DayCount = (short)(AV39DayCount+1);
                  AV38WorkDate = DateTimeUtil.DAdd( AV38WorkDate, (1));
               }
            }
            AV36CompanyWorkTimeDictionary.set( A157CompanyLocationId,  (AV39DayCount-AV40CompanyHolidayDateCollection.Count)*8*60);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV15SDTProjects.Count > 0 )
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
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
            /* Using cursor P00845 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               A100CompanyId = P00845_A100CompanyId[0];
               A106EmployeeId = P00845_A106EmployeeId[0];
               A157CompanyLocationId = P00845_A157CompanyLocationId[0];
               A148EmployeeName = P00845_A148EmployeeName[0];
               A157CompanyLocationId = P00845_A157CompanyLocationId[0];
               if ( ( AV10ProjectId.Count == 0 ) || ( ( new employeehasanyproject(context).executeUdp(  A106EmployeeId,  AV10ProjectId) ) ) )
               {
                  AV11SDTEmployeeProjectHours = new SdtSDTEmployeeProjectHours(context);
                  AV11SDTEmployeeProjectHours.gxTpr_Employeeid = A106EmployeeId;
                  AV11SDTEmployeeProjectHours.gxTpr_Employeename = A148EmployeeName;
                  AV11SDTEmployeeProjectHours.gxTpr_Totaltime = 0;
                  GXt_int2 = 0;
                  new procgetemployeeleavetotal(context ).execute(  A106EmployeeId,  AV9FromDate,  AV16ToDate, out  GXt_int2) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Totalleave = (long)(GXt_int2*8*60);
                  GXt_char1 = "";
                  new procformattime(context ).execute(  AV11SDTEmployeeProjectHours.gxTpr_Totalleave, out  GXt_char1) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Totalformattedleave = GXt_char1;
                  AV11SDTEmployeeProjectHours.gxTpr_Expectedworktime = (long)(AV36CompanyWorkTimeDictionary.get(A157CompanyLocationId)-AV11SDTEmployeeProjectHours.gxTpr_Totalleave);
                  pr_default.dynParam(4, new Object[]{ new Object[]{
                                                       A102ProjectId ,
                                                       AV20ProjectIdCollection ,
                                                       A106EmployeeId } ,
                                                       new int[]{
                                                       TypeConstants.LONG, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00846 */
                  pr_default.execute(4, new Object[] {A106EmployeeId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A102ProjectId = P00846_A102ProjectId[0];
                     A103ProjectName = P00846_A103ProjectName[0];
                     A103ProjectName = P00846_A103ProjectName[0];
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
                     new logtofile(context ).execute(  "  --"+StringUtil.Str( (decimal)(AV23TotalHourLogs), 10, 0)) ;
                     AV11SDTEmployeeProjectHours.gxTpr_Totaltime = (long)(AV11SDTEmployeeProjectHours.gxTpr_Totaltime+AV23TotalHourLogs);
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
                  GXt_char1 = "";
                  new procformattime(context ).execute(  AV11SDTEmployeeProjectHours.gxTpr_Totaltime, out  GXt_char1) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Totalformattedtime = GXt_char1;
                  AV11SDTEmployeeProjectHours.gxTpr_Isworktimeoptimal = (bool)((AV11SDTEmployeeProjectHours.gxTpr_Totaltime>=AV11SDTEmployeeProjectHours.gxTpr_Expectedworktime));
                  AV11SDTEmployeeProjectHours.gxTpr_Total = (long)(AV11SDTEmployeeProjectHours.gxTpr_Totaltime+AV11SDTEmployeeProjectHours.gxTpr_Totalleave);
                  AV35TotalTime = (long)(AV35TotalTime+(AV11SDTEmployeeProjectHours.gxTpr_Total));
                  GXt_char1 = "";
                  new procformattime(context ).execute(  AV11SDTEmployeeProjectHours.gxTpr_Total, out  GXt_char1) ;
                  AV11SDTEmployeeProjectHours.gxTpr_Formattedtotal = GXt_char1;
                  if ( AV11SDTEmployeeProjectHours.gxTpr_Totaltime > 0 )
                  {
                     AV12SDTEmployeeProjectHoursCollection.Add(AV11SDTEmployeeProjectHours, 0);
                  }
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         GXt_char1 = AV34TotalFormattedTime;
         new procformattime(context ).execute(  AV35TotalTime, out  GXt_char1) ;
         AV34TotalFormattedTime = GXt_char1;
         cleanup();
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
         AV15SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         AV12SDTEmployeeProjectHoursCollection = new GXBaseCollection<SdtSDTEmployeeProjectHours>( context, "SDTEmployeeProjectHours", "YTT_version4");
         AV26TotalFormattedWorkTime = "";
         AV34TotalFormattedTime = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00842_A100CompanyId = new long[1] ;
         P00842_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00842_A102ProjectId = new long[1] ;
         P00842_A106EmployeeId = new long[1] ;
         P00842_A157CompanyLocationId = new long[1] ;
         P00842_A105ProjectStatus = new string[] {""} ;
         P00842_A104ProjectDescription = new string[] {""} ;
         P00842_A103ProjectName = new string[] {""} ;
         A105ProjectStatus = "";
         A104ProjectDescription = "";
         A103ProjectName = "";
         AV20ProjectIdCollection = new GxSimpleCollection<long>();
         AV13SDTProject = new SdtSDTProject(context);
         P00843_A157CompanyLocationId = new long[1] ;
         AV38WorkDate = DateTime.MinValue;
         AV40CompanyHolidayDateCollection = new GxSimpleCollection<DateTime>();
         P00844_A100CompanyId = new long[1] ;
         P00844_A139HolidayIsActive = new bool[] {false} ;
         P00844_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00844_A157CompanyLocationId = new long[1] ;
         P00844_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         AV36CompanyWorkTimeDictionary = new GeneXus.Core.genexus.common.SdtDictionary<double, double>();
         P00845_A100CompanyId = new long[1] ;
         P00845_A106EmployeeId = new long[1] ;
         P00845_A157CompanyLocationId = new long[1] ;
         P00845_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV11SDTEmployeeProjectHours = new SdtSDTEmployeeProjectHours(context);
         P00846_A106EmployeeId = new long[1] ;
         P00846_A102ProjectId = new long[1] ;
         P00846_A103ProjectName = new string[] {""} ;
         AV14SDTProjectHoursItem = new SdtSDTEmployeeProjectHours_ProjectHoursItem(context);
         AV24FormattedHours = "";
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeprojectmatrixreport__default(),
            new Object[][] {
                new Object[] {
               P00842_A100CompanyId, P00842_A119WorkHourLogDate, P00842_A102ProjectId, P00842_A106EmployeeId, P00842_A157CompanyLocationId, P00842_A105ProjectStatus, P00842_A104ProjectDescription, P00842_A103ProjectName
               }
               , new Object[] {
               P00843_A157CompanyLocationId
               }
               , new Object[] {
               P00844_A100CompanyId, P00844_A139HolidayIsActive, P00844_A115HolidayStartDate, P00844_A157CompanyLocationId, P00844_A113HolidayId
               }
               , new Object[] {
               P00845_A100CompanyId, P00845_A106EmployeeId, P00845_A157CompanyLocationId, P00845_A148EmployeeName
               }
               , new Object[] {
               P00846_A106EmployeeId, P00846_A102ProjectId, P00846_A103ProjectName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV39DayCount ;
      private int AV17CompanyLocationId_Count ;
      private int AV8EmployeeId_Count ;
      private int AV10ProjectId_Count ;
      private int AV33ProjectIds_Count ;
      private int AV32EmployeeIds_Count ;
      private long AV25TotalWorkTime ;
      private long AV35TotalTime ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private long GXt_int2 ;
      private long AV23TotalHourLogs ;
      private string AV26TotalFormattedWorkTime ;
      private string AV34TotalFormattedTime ;
      private string A105ProjectStatus ;
      private string A103ProjectName ;
      private string A148EmployeeName ;
      private string AV24FormattedHours ;
      private string GXt_char1 ;
      private DateTime AV9FromDate ;
      private DateTime AV16ToDate ;
      private DateTime A119WorkHourLogDate ;
      private DateTime AV38WorkDate ;
      private DateTime A115HolidayStartDate ;
      private bool AV28IsEmployeeIdEmpty ;
      private bool AV29IsCompanyLocationIdEmpty ;
      private bool A139HolidayIsActive ;
      private bool AV18HasProject ;
      private bool GXt_boolean3 ;
      private string A104ProjectDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> AV10ProjectId ;
      private GxSimpleCollection<long> aP2_ProjectId ;
      private GxSimpleCollection<long> AV17CompanyLocationId ;
      private GxSimpleCollection<long> aP3_CompanyLocationId ;
      private GxSimpleCollection<long> AV8EmployeeId ;
      private GxSimpleCollection<long> aP4_EmployeeId ;
      private GxSimpleCollection<long> AV32EmployeeIds ;
      private GxSimpleCollection<long> aP5_EmployeeIds ;
      private GxSimpleCollection<long> AV33ProjectIds ;
      private GxSimpleCollection<long> aP6_ProjectIds ;
      private GXBaseCollection<SdtSDTProject> AV15SDTProjects ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> AV12SDTEmployeeProjectHoursCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00842_A100CompanyId ;
      private DateTime[] P00842_A119WorkHourLogDate ;
      private long[] P00842_A102ProjectId ;
      private long[] P00842_A106EmployeeId ;
      private long[] P00842_A157CompanyLocationId ;
      private string[] P00842_A105ProjectStatus ;
      private string[] P00842_A104ProjectDescription ;
      private string[] P00842_A103ProjectName ;
      private GxSimpleCollection<long> AV20ProjectIdCollection ;
      private SdtSDTProject AV13SDTProject ;
      private long[] P00843_A157CompanyLocationId ;
      private GxSimpleCollection<DateTime> AV40CompanyHolidayDateCollection ;
      private long[] P00844_A100CompanyId ;
      private bool[] P00844_A139HolidayIsActive ;
      private DateTime[] P00844_A115HolidayStartDate ;
      private long[] P00844_A157CompanyLocationId ;
      private long[] P00844_A113HolidayId ;
      private GeneXus.Core.genexus.common.SdtDictionary<double, double> AV36CompanyWorkTimeDictionary ;
      private long[] P00845_A100CompanyId ;
      private long[] P00845_A106EmployeeId ;
      private long[] P00845_A157CompanyLocationId ;
      private string[] P00845_A148EmployeeName ;
      private SdtSDTEmployeeProjectHours AV11SDTEmployeeProjectHours ;
      private long[] P00846_A106EmployeeId ;
      private long[] P00846_A102ProjectId ;
      private string[] P00846_A103ProjectName ;
      private SdtSDTEmployeeProjectHours_ProjectHoursItem AV14SDTProjectHoursItem ;
      private GXBaseCollection<SdtSDTProject> aP7_SDTProjects ;
      private GXBaseCollection<SdtSDTEmployeeProjectHours> aP8_SDTEmployeeProjectHoursCollection ;
      private string aP9_TotalFormattedWorkTime ;
      private string aP10_TotalFormattedTime ;
   }

   public class employeeprojectmatrixreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00842( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV17CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV8EmployeeId ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV10ProjectId ,
                                             GxSimpleCollection<long> AV33ProjectIds ,
                                             int AV17CompanyLocationId_Count ,
                                             int AV8EmployeeId_Count ,
                                             int AV10ProjectId_Count ,
                                             int AV33ProjectIds_Count ,
                                             DateTime AV9FromDate ,
                                             DateTime AV16ToDate ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[2];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS CompanyId, NULL AS WorkHourLogDate, ProjectId, NULL AS EmployeeId, NULL AS CompanyLocationId, ProjectStatus, ProjectDescription, ProjectName FROM ( SELECT T3.CompanyId, T1.WorkHourLogDate, T1.ProjectId, T1.EmployeeId, T4.CompanyLocationId, T2.ProjectStatus, T2.ProjectDescription, T2.ProjectName FROM (((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) INNER JOIN Company T4 ON T4.CompanyId = T3.CompanyId)";
         if ( AV17CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV17CompanyLocationId, "T4.CompanyLocationId IN (", ")")+")");
         }
         if ( AV8EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV10ProjectId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV10ProjectId, "T1.ProjectId IN (", ")")+")");
         }
         if ( AV33ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV9FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV9FromDate)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV16ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV16ToDate)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ProjectName";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY ProjectName";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00843( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV17CompanyLocationId ,
                                             int AV17CompanyLocationId_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT CompanyLocationId FROM CompanyLocation";
         if ( AV17CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV17CompanyLocationId, "CompanyLocationId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationId";
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00845( IGxContext context ,
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
         Object[] GXv_Object8 = new Object[2];
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
         GXv_Object8[0] = scmdbuf;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00846( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV20ProjectIdCollection ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[1];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T2.ProjectName FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :EmployeeId)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV20ProjectIdCollection, "T1.ProjectId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00842(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (GxSimpleCollection<long>)dynConstraints[5] , (GxSimpleCollection<long>)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
               case 1 :
                     return conditional_P00843(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
               case 3 :
                     return conditional_P00845(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (GxSimpleCollection<long>)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (GxSimpleCollection<long>)dynConstraints[9] );
               case 4 :
                     return conditional_P00846(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00844;
          prmP00844 = new Object[] {
          new ParDef("CompanyLocationId",GXType.Int64,10,0) ,
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV16ToDate",GXType.Date,8,0)
          };
          Object[] prmP00842;
          prmP00842 = new Object[] {
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV16ToDate",GXType.Date,8,0)
          };
          Object[] prmP00843;
          prmP00843 = new Object[] {
          };
          Object[] prmP00845;
          prmP00845 = new Object[] {
          };
          Object[] prmP00846;
          prmP00846 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00842", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00842,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00843", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00843,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00844", "SELECT T1.CompanyId, T1.HolidayIsActive, T1.HolidayStartDate, T2.CompanyLocationId, T1.HolidayId FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T2.CompanyLocationId = :CompanyLocationId) AND (T1.HolidayStartDate >= :AV9FromDate and T1.HolidayStartDate <= :AV16ToDate) AND ((date_part('dow', CAST(T1.HolidayStartDate AS date)) + 1) <> 7) AND ((date_part('dow', CAST(T1.HolidayStartDate AS date)) + 1) <> 1) AND (T1.HolidayIsActive = TRUE) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00844,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00845", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00845,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00846", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00846,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
