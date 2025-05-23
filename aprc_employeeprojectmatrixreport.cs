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
   public class aprc_employeeprojectmatrixreport : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_employeeprojectmatrixreport().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_employeeprojectmatrixreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_employeeprojectmatrixreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_ProjectIdCollection ,
                           GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                           GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                           GxSimpleCollection<long> aP5_UserEmployeeIdCollection ,
                           bool aP6_ShowLeave ,
                           out short aP7_OverallTotalHours ,
                           out GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP8_SDT_EmployeeProjectMatrixCollection )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV10ProjectIdCollection = aP2_ProjectIdCollection;
         this.AV12CompanyLocationIdCollection = aP3_CompanyLocationIdCollection;
         this.AV13EmployeeIdCollection = aP4_EmployeeIdCollection;
         this.AV39UserEmployeeIdCollection = aP5_UserEmployeeIdCollection;
         this.AV31ShowLeave = aP6_ShowLeave;
         this.AV34OverallTotalHours = 0 ;
         this.AV20SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP7_OverallTotalHours=this.AV34OverallTotalHours;
         aP8_SDT_EmployeeProjectMatrixCollection=this.AV20SDT_EmployeeProjectMatrixCollection;
      }

      public GXBaseCollection<SdtSDT_EmployeeProjectMatrix> executeUdp( DateTime aP0_FromDate ,
                                                                        DateTime aP1_ToDate ,
                                                                        GxSimpleCollection<long> aP2_ProjectIdCollection ,
                                                                        GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                                                                        GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                                                                        GxSimpleCollection<long> aP5_UserEmployeeIdCollection ,
                                                                        bool aP6_ShowLeave ,
                                                                        out short aP7_OverallTotalHours )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_ProjectIdCollection, aP3_CompanyLocationIdCollection, aP4_EmployeeIdCollection, aP5_UserEmployeeIdCollection, aP6_ShowLeave, out aP7_OverallTotalHours, out aP8_SDT_EmployeeProjectMatrixCollection);
         return AV20SDT_EmployeeProjectMatrixCollection ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_ProjectIdCollection ,
                                 GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                                 GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                                 GxSimpleCollection<long> aP5_UserEmployeeIdCollection ,
                                 bool aP6_ShowLeave ,
                                 out short aP7_OverallTotalHours ,
                                 out GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP8_SDT_EmployeeProjectMatrixCollection )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV10ProjectIdCollection = aP2_ProjectIdCollection;
         this.AV12CompanyLocationIdCollection = aP3_CompanyLocationIdCollection;
         this.AV13EmployeeIdCollection = aP4_EmployeeIdCollection;
         this.AV39UserEmployeeIdCollection = aP5_UserEmployeeIdCollection;
         this.AV31ShowLeave = aP6_ShowLeave;
         this.AV34OverallTotalHours = 0 ;
         this.AV20SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4") ;
         SubmitImpl();
         aP7_OverallTotalHours=this.AV34OverallTotalHours;
         aP8_SDT_EmployeeProjectMatrixCollection=this.AV20SDT_EmployeeProjectMatrixCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV10ProjectIdCollection.Count > 0 )
         {
            GXt_objcol_int1 = AV33ProjectEmployeeIdCollection;
            new getemployeeidsbyproject(context ).execute(  AV10ProjectIdCollection, out  GXt_objcol_int1) ;
            AV33ProjectEmployeeIdCollection = GXt_objcol_int1;
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV12CompanyLocationIdCollection ,
                                              A106EmployeeId ,
                                              AV13EmployeeIdCollection ,
                                              A102ProjectId ,
                                              AV10ProjectIdCollection ,
                                              AV12CompanyLocationIdCollection.Count ,
                                              AV13EmployeeIdCollection.Count ,
                                              AV10ProjectIdCollection.Count ,
                                              AV8FromDate ,
                                              AV9ToDate ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00CC2 */
         pr_default.execute(0, new Object[] {AV8FromDate, AV9ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00CC2_A100CompanyId[0];
            A119WorkHourLogDate = P00CC2_A119WorkHourLogDate[0];
            A102ProjectId = P00CC2_A102ProjectId[0];
            A106EmployeeId = P00CC2_A106EmployeeId[0];
            A157CompanyLocationId = P00CC2_A157CompanyLocationId[0];
            A105ProjectStatus = P00CC2_A105ProjectStatus[0];
            A104ProjectDescription = P00CC2_A104ProjectDescription[0];
            A103ProjectName = P00CC2_A103ProjectName[0];
            A105ProjectStatus = P00CC2_A105ProjectStatus[0];
            A104ProjectDescription = P00CC2_A104ProjectDescription[0];
            A103ProjectName = P00CC2_A103ProjectName[0];
            A100CompanyId = P00CC2_A100CompanyId[0];
            A157CompanyLocationId = P00CC2_A157CompanyLocationId[0];
            AV29SDTProject = new SdtSDTProject(context);
            AV29SDTProject.gxTpr_Id = A102ProjectId;
            AV29SDTProject.gxTpr_Projectname = A103ProjectName;
            AV29SDTProject.gxTpr_Projectstatus = A105ProjectStatus;
            AV29SDTProject.gxTpr_Projectdescription = A104ProjectDescription;
            AV30SDTProjectCollection.Add(AV29SDTProject, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV12CompanyLocationIdCollection ,
                                              AV12CompanyLocationIdCollection.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor P00CC3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A157CompanyLocationId = P00CC3_A157CompanyLocationId[0];
            AV35WorkDate = AV8FromDate;
            AV36DayCount = 0;
            AV37CompanyHolidayDateCollection = (GxSimpleCollection<DateTime>)(new GxSimpleCollection<DateTime>());
            /* Using cursor P00CC4 */
            pr_default.execute(2, new Object[] {A157CompanyLocationId, AV8FromDate, AV9ToDate});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A100CompanyId = P00CC4_A100CompanyId[0];
               A139HolidayIsActive = P00CC4_A139HolidayIsActive[0];
               A115HolidayStartDate = P00CC4_A115HolidayStartDate[0];
               A157CompanyLocationId = P00CC4_A157CompanyLocationId[0];
               A113HolidayId = P00CC4_A113HolidayId[0];
               A157CompanyLocationId = P00CC4_A157CompanyLocationId[0];
               AV37CompanyHolidayDateCollection.Add(A115HolidayStartDate, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            while ( DateTimeUtil.ResetTime ( AV35WorkDate ) <= DateTimeUtil.ResetTime ( AV9ToDate ) )
            {
               if ( DateTimeUtil.Dow( AV35WorkDate) == 7 )
               {
                  AV35WorkDate = DateTimeUtil.DAdd( AV35WorkDate, (2));
               }
               else if ( DateTimeUtil.Dow( AV35WorkDate) == 1 )
               {
                  AV35WorkDate = DateTimeUtil.DAdd( AV35WorkDate, (1));
               }
               else if ( ( DateTimeUtil.Dow( AV35WorkDate) == 2 ) && ( ( DateTimeUtil.DDiff( AV9ToDate , AV35WorkDate ) ) >= 5 ) )
               {
                  AV36DayCount = (short)(AV36DayCount+5);
                  AV35WorkDate = DateTimeUtil.DAdd( AV35WorkDate, (7));
               }
               else
               {
                  AV36DayCount = (short)(AV36DayCount+1);
                  AV35WorkDate = DateTimeUtil.DAdd( AV35WorkDate, (1));
               }
            }
            AV43CompanyWorkTimeKeyCollection.Add(A157CompanyLocationId, 0);
            AV44CompanyWorkTimeValueCollection.Add((AV36DayCount-AV37CompanyHolidayDateCollection.Count)*8*60, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV33ProjectEmployeeIdCollection ,
                                              AV13EmployeeIdCollection ,
                                              AV39UserEmployeeIdCollection ,
                                              A157CompanyLocationId ,
                                              AV12CompanyLocationIdCollection ,
                                              AV33ProjectEmployeeIdCollection.Count ,
                                              AV13EmployeeIdCollection.Count ,
                                              AV39UserEmployeeIdCollection.Count ,
                                              AV12CompanyLocationIdCollection.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00CC5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A100CompanyId = P00CC5_A100CompanyId[0];
            A106EmployeeId = P00CC5_A106EmployeeId[0];
            A157CompanyLocationId = P00CC5_A157CompanyLocationId[0];
            A148EmployeeName = P00CC5_A148EmployeeName[0];
            A157CompanyLocationId = P00CC5_A157CompanyLocationId[0];
            AV25SDT_EmployeeProjectMatrix = new SdtSDT_EmployeeProjectMatrix(context);
            AV25SDT_EmployeeProjectMatrix.gxTpr_Employeeid = A106EmployeeId;
            AV25SDT_EmployeeProjectMatrix.gxTpr_Employeename = A148EmployeeName;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 A102ProjectId ,
                                                 AV10ProjectIdCollection ,
                                                 AV10ProjectIdCollection.Count ,
                                                 A106EmployeeId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P00CC7 */
            pr_default.execute(4, new Object[] {AV8FromDate, AV9ToDate, A106EmployeeId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A102ProjectId = P00CC7_A102ProjectId[0];
               A103ProjectName = P00CC7_A103ProjectName[0];
               A40000GXC1 = P00CC7_A40000GXC1[0];
               n40000GXC1 = P00CC7_n40000GXC1[0];
               A40001GXC2 = P00CC7_A40001GXC2[0];
               n40001GXC2 = P00CC7_n40001GXC2[0];
               A103ProjectName = P00CC7_A103ProjectName[0];
               A40000GXC1 = P00CC7_A40000GXC1[0];
               n40000GXC1 = P00CC7_n40000GXC1[0];
               A40001GXC2 = P00CC7_A40001GXC2[0];
               n40001GXC2 = P00CC7_n40001GXC2[0];
               AV17TotalHours = A40000GXC1;
               AV18TotalMinutes = A40001GXC2;
               AV19Total = (long)(AV18TotalMinutes+AV17TotalHours*60);
               AV22ProjectItem = new SdtSDT_EmployeeProjectMatrix_ProjectsItem(context);
               AV22ProjectItem.gxTpr_Projectid = A102ProjectId;
               AV22ProjectItem.gxTpr_Projectname = A103ProjectName;
               AV22ProjectItem.gxTpr_Projecthours = AV19Total;
               AV25SDT_EmployeeProjectMatrix.gxTpr_Workhours = (long)(AV25SDT_EmployeeProjectMatrix.gxTpr_Workhours+AV19Total);
               if ( AV22ProjectItem.gxTpr_Projecthours > 0 )
               {
                  AV25SDT_EmployeeProjectMatrix.gxTpr_Projects.Add(AV22ProjectItem, 0);
               }
               pr_default.readNext(4);
            }
            pr_default.close(4);
            GXt_char2 = "";
            new formattime(context ).execute(  AV25SDT_EmployeeProjectMatrix.gxTpr_Workhours, out  GXt_char2) ;
            AV25SDT_EmployeeProjectMatrix.gxTpr_Formattedworkhours = GXt_char2;
            if ( AV31ShowLeave )
            {
               GXt_int3 = 0;
               new procgetemployeeleavetotal(context ).execute(  A106EmployeeId,  AV8FromDate,  AV9ToDate, out  GXt_int3) ;
               AV25SDT_EmployeeProjectMatrix.gxTpr_Leavehours = (long)(GXt_int3*8*60);
               GXt_char2 = "";
               new procformattime(context ).execute(  AV25SDT_EmployeeProjectMatrix.gxTpr_Leavehours, out  GXt_char2) ;
               AV25SDT_EmployeeProjectMatrix.gxTpr_Formattedleavehours = GXt_char2;
               AV25SDT_EmployeeProjectMatrix.gxTpr_Employeehours = (long)(AV25SDT_EmployeeProjectMatrix.gxTpr_Workhours+AV25SDT_EmployeeProjectMatrix.gxTpr_Leavehours);
               GXt_char2 = "";
               new formattime(context ).execute(  AV25SDT_EmployeeProjectMatrix.gxTpr_Employeehours, out  GXt_char2) ;
               AV25SDT_EmployeeProjectMatrix.gxTpr_Formattedemployeehours = GXt_char2;
               AV25SDT_EmployeeProjectMatrix.gxTpr_Expectedworkhours = (long)(AV44CompanyWorkTimeValueCollection.GetNumeric(AV43CompanyWorkTimeKeyCollection.IndexOf((short)(A157CompanyLocationId)))-AV25SDT_EmployeeProjectMatrix.gxTpr_Leavehours);
               AV25SDT_EmployeeProjectMatrix.gxTpr_Isoptimal = (bool)((AV25SDT_EmployeeProjectMatrix.gxTpr_Workhours>=AV25SDT_EmployeeProjectMatrix.gxTpr_Expectedworkhours));
            }
            if ( AV25SDT_EmployeeProjectMatrix.gxTpr_Workhours > 0 )
            {
               AV34OverallTotalHours = (short)(AV34OverallTotalHours+(AV25SDT_EmployeeProjectMatrix.gxTpr_Employeehours));
               AV20SDT_EmployeeProjectMatrixCollection.Add(AV25SDT_EmployeeProjectMatrix, 0);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
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
         AV20SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         AV33ProjectEmployeeIdCollection = new GxSimpleCollection<long>();
         GXt_objcol_int1 = new GxSimpleCollection<long>();
         A119WorkHourLogDate = DateTime.MinValue;
         P00CC2_A100CompanyId = new long[1] ;
         P00CC2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00CC2_A102ProjectId = new long[1] ;
         P00CC2_A106EmployeeId = new long[1] ;
         P00CC2_A157CompanyLocationId = new long[1] ;
         P00CC2_A105ProjectStatus = new string[] {""} ;
         P00CC2_A104ProjectDescription = new string[] {""} ;
         P00CC2_A103ProjectName = new string[] {""} ;
         A105ProjectStatus = "";
         A104ProjectDescription = "";
         A103ProjectName = "";
         AV29SDTProject = new SdtSDTProject(context);
         AV30SDTProjectCollection = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         P00CC3_A157CompanyLocationId = new long[1] ;
         AV35WorkDate = DateTime.MinValue;
         AV37CompanyHolidayDateCollection = new GxSimpleCollection<DateTime>();
         P00CC4_A100CompanyId = new long[1] ;
         P00CC4_A139HolidayIsActive = new bool[] {false} ;
         P00CC4_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00CC4_A157CompanyLocationId = new long[1] ;
         P00CC4_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         AV43CompanyWorkTimeKeyCollection = new GxSimpleCollection<short>();
         AV44CompanyWorkTimeValueCollection = new GxSimpleCollection<long>();
         P00CC5_A100CompanyId = new long[1] ;
         P00CC5_A106EmployeeId = new long[1] ;
         P00CC5_A157CompanyLocationId = new long[1] ;
         P00CC5_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV25SDT_EmployeeProjectMatrix = new SdtSDT_EmployeeProjectMatrix(context);
         P00CC7_A106EmployeeId = new long[1] ;
         P00CC7_A102ProjectId = new long[1] ;
         P00CC7_A103ProjectName = new string[] {""} ;
         P00CC7_A40000GXC1 = new short[1] ;
         P00CC7_n40000GXC1 = new bool[] {false} ;
         P00CC7_A40001GXC2 = new short[1] ;
         P00CC7_n40001GXC2 = new bool[] {false} ;
         AV22ProjectItem = new SdtSDT_EmployeeProjectMatrix_ProjectsItem(context);
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_employeeprojectmatrixreport__default(),
            new Object[][] {
                new Object[] {
               P00CC2_A100CompanyId, P00CC2_A119WorkHourLogDate, P00CC2_A102ProjectId, P00CC2_A106EmployeeId, P00CC2_A157CompanyLocationId, P00CC2_A105ProjectStatus, P00CC2_A104ProjectDescription, P00CC2_A103ProjectName
               }
               , new Object[] {
               P00CC3_A157CompanyLocationId
               }
               , new Object[] {
               P00CC4_A100CompanyId, P00CC4_A139HolidayIsActive, P00CC4_A115HolidayStartDate, P00CC4_A157CompanyLocationId, P00CC4_A113HolidayId
               }
               , new Object[] {
               P00CC5_A100CompanyId, P00CC5_A106EmployeeId, P00CC5_A157CompanyLocationId, P00CC5_A148EmployeeName
               }
               , new Object[] {
               P00CC7_A106EmployeeId, P00CC7_A102ProjectId, P00CC7_A103ProjectName, P00CC7_A40000GXC1, P00CC7_n40000GXC1, P00CC7_A40001GXC2, P00CC7_n40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34OverallTotalHours ;
      private short AV36DayCount ;
      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private int AV12CompanyLocationIdCollection_Count ;
      private int AV13EmployeeIdCollection_Count ;
      private int AV10ProjectIdCollection_Count ;
      private int AV33ProjectEmployeeIdCollection_Count ;
      private int AV39UserEmployeeIdCollection_Count ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private long AV17TotalHours ;
      private long AV18TotalMinutes ;
      private long AV19Total ;
      private long GXt_int3 ;
      private string A105ProjectStatus ;
      private string A103ProjectName ;
      private string A148EmployeeName ;
      private string GXt_char2 ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private DateTime A119WorkHourLogDate ;
      private DateTime AV35WorkDate ;
      private DateTime A115HolidayStartDate ;
      private bool AV31ShowLeave ;
      private bool A139HolidayIsActive ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private string A104ProjectDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV10ProjectIdCollection ;
      private GxSimpleCollection<long> AV12CompanyLocationIdCollection ;
      private GxSimpleCollection<long> AV13EmployeeIdCollection ;
      private GxSimpleCollection<long> AV39UserEmployeeIdCollection ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> AV20SDT_EmployeeProjectMatrixCollection ;
      private GxSimpleCollection<long> AV33ProjectEmployeeIdCollection ;
      private GxSimpleCollection<long> GXt_objcol_int1 ;
      private IDataStoreProvider pr_default ;
      private long[] P00CC2_A100CompanyId ;
      private DateTime[] P00CC2_A119WorkHourLogDate ;
      private long[] P00CC2_A102ProjectId ;
      private long[] P00CC2_A106EmployeeId ;
      private long[] P00CC2_A157CompanyLocationId ;
      private string[] P00CC2_A105ProjectStatus ;
      private string[] P00CC2_A104ProjectDescription ;
      private string[] P00CC2_A103ProjectName ;
      private SdtSDTProject AV29SDTProject ;
      private GXBaseCollection<SdtSDTProject> AV30SDTProjectCollection ;
      private long[] P00CC3_A157CompanyLocationId ;
      private GxSimpleCollection<DateTime> AV37CompanyHolidayDateCollection ;
      private long[] P00CC4_A100CompanyId ;
      private bool[] P00CC4_A139HolidayIsActive ;
      private DateTime[] P00CC4_A115HolidayStartDate ;
      private long[] P00CC4_A157CompanyLocationId ;
      private long[] P00CC4_A113HolidayId ;
      private GxSimpleCollection<short> AV43CompanyWorkTimeKeyCollection ;
      private GxSimpleCollection<long> AV44CompanyWorkTimeValueCollection ;
      private long[] P00CC5_A100CompanyId ;
      private long[] P00CC5_A106EmployeeId ;
      private long[] P00CC5_A157CompanyLocationId ;
      private string[] P00CC5_A148EmployeeName ;
      private SdtSDT_EmployeeProjectMatrix AV25SDT_EmployeeProjectMatrix ;
      private long[] P00CC7_A106EmployeeId ;
      private long[] P00CC7_A102ProjectId ;
      private string[] P00CC7_A103ProjectName ;
      private short[] P00CC7_A40000GXC1 ;
      private bool[] P00CC7_n40000GXC1 ;
      private short[] P00CC7_A40001GXC2 ;
      private bool[] P00CC7_n40001GXC2 ;
      private SdtSDT_EmployeeProjectMatrix_ProjectsItem AV22ProjectItem ;
      private short aP7_OverallTotalHours ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP8_SDT_EmployeeProjectMatrixCollection ;
   }

   public class aprc_employeeprojectmatrixreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CC2( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV12CompanyLocationIdCollection ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV13EmployeeIdCollection ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV10ProjectIdCollection ,
                                             int AV12CompanyLocationIdCollection_Count ,
                                             int AV13EmployeeIdCollection_Count ,
                                             int AV10ProjectIdCollection_Count ,
                                             DateTime AV8FromDate ,
                                             DateTime AV9ToDate ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[2];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS CompanyId, NULL AS WorkHourLogDate, ProjectId, NULL AS EmployeeId, NULL AS CompanyLocationId, ProjectStatus, ProjectDescription, ProjectName FROM ( SELECT T3.CompanyId, T1.WorkHourLogDate, T1.ProjectId, T1.EmployeeId, T4.CompanyLocationId, T2.ProjectStatus, T2.ProjectDescription, T2.ProjectName FROM (((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) INNER JOIN Company T4 ON T4.CompanyId = T3.CompanyId)";
         if ( AV12CompanyLocationIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12CompanyLocationIdCollection, "T4.CompanyLocationId IN (", ")")+")");
         }
         if ( AV13EmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV10ProjectIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV10ProjectIdCollection, "T1.ProjectId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV8FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV8FromDate)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV9ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV9ToDate)");
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

      protected Object[] conditional_P00CC3( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV12CompanyLocationIdCollection ,
                                             int AV12CompanyLocationIdCollection_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT CompanyLocationId FROM CompanyLocation";
         if ( AV12CompanyLocationIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12CompanyLocationIdCollection, "CompanyLocationId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationId";
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00CC5( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV33ProjectEmployeeIdCollection ,
                                             GxSimpleCollection<long> AV13EmployeeIdCollection ,
                                             GxSimpleCollection<long> AV39UserEmployeeIdCollection ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV12CompanyLocationIdCollection ,
                                             int AV33ProjectEmployeeIdCollection_Count ,
                                             int AV13EmployeeIdCollection_Count ,
                                             int AV39UserEmployeeIdCollection_Count ,
                                             int AV12CompanyLocationIdCollection_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId, T1.EmployeeName FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( AV33ProjectEmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33ProjectEmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV13EmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV39UserEmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV39UserEmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         if ( ! ( AV12CompanyLocationIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12CompanyLocationIdCollection, "T2.CompanyLocationId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
         GXv_Object8[0] = scmdbuf;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00CC7( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV10ProjectIdCollection ,
                                             int AV10ProjectIdCollection_Count ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[3];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T2.ProjectName, COALESCE( T3.GXC1, 0) AS GXC1, COALESCE( T3.GXC2, 0) AS GXC2 FROM ((EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, ProjectId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId and T1.ProjectId = ProjectId) AND (WorkHourLogDate >= :AV8FromDate and WorkHourLogDate <= :AV9ToDate) GROUP BY EmployeeId, ProjectId ) T3 ON T3.EmployeeId = T1.EmployeeId AND T3.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :EmployeeId)");
         if ( AV10ProjectIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV10ProjectIdCollection, "T1.ProjectId IN (", ")")+")");
         }
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
                     return conditional_P00CC2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (GxSimpleCollection<long>)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] );
               case 1 :
                     return conditional_P00CC3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
               case 3 :
                     return conditional_P00CC5(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (GxSimpleCollection<long>)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (GxSimpleCollection<long>)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
               case 4 :
                     return conditional_P00CC7(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] );
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
          Object[] prmP00CC4;
          prmP00CC4 = new Object[] {
          new ParDef("CompanyLocationId",GXType.Int64,10,0) ,
          new ParDef("AV8FromDate",GXType.Date,8,0) ,
          new ParDef("AV9ToDate",GXType.Date,8,0)
          };
          Object[] prmP00CC2;
          prmP00CC2 = new Object[] {
          new ParDef("AV8FromDate",GXType.Date,8,0) ,
          new ParDef("AV9ToDate",GXType.Date,8,0)
          };
          Object[] prmP00CC3;
          prmP00CC3 = new Object[] {
          };
          Object[] prmP00CC5;
          prmP00CC5 = new Object[] {
          };
          Object[] prmP00CC7;
          prmP00CC7 = new Object[] {
          new ParDef("AV8FromDate",GXType.Date,8,0) ,
          new ParDef("AV9ToDate",GXType.Date,8,0) ,
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CC4", "SELECT T1.CompanyId, T1.HolidayIsActive, T1.HolidayStartDate, T2.CompanyLocationId, T1.HolidayId FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T2.CompanyLocationId = :CompanyLocationId) AND (T1.HolidayStartDate >= :AV8FromDate and T1.HolidayStartDate <= :AV9ToDate) AND ((date_part('dow', CAST(T1.HolidayStartDate AS date)) + 1) <> 7) AND ((date_part('dow', CAST(T1.HolidayStartDate AS date)) + 1) <> 1) AND (T1.HolidayIsActive = TRUE) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CC5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CC7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC7,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
