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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class ainsertrolepermissions : GXWebProcedure
   {
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "insertrolepermissions_Execute" ;
         }

      }

      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public ainsertrolepermissions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ainsertrolepermissions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         ainsertrolepermissions objainsertrolepermissions;
         objainsertrolepermissions = new ainsertrolepermissions();
         objainsertrolepermissions.context.SetSubmitInitialConfig(context);
         objainsertrolepermissions.initialize();
         Submit( executePrivateCatch,objainsertrolepermissions);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ainsertrolepermissions)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("file.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV24ManagerPerms = "downloadapp_Execute,employee_dataprovider_Execute,employee_Delete,employee_Execute,Employee,employee_FullControl,employeehasprojectcopy1_Execute,employee_Insert,employeeprojectmatrixcopy1_Execute,employeeprojectmatrix_Execute,employee_Services_Execute,employee_Update,employeeview_Execute,employeeww_Execute,Employee,employeeww_Services_Execute,gamchangeyourpassword_Execute,holiday_Delete,holiday_Execute,Holiday,holiday_FullControl,holiday_Insert,holiday_Update,holidayview_Execute,holidayww_Execute,Holiday,holidayww_Services_Execute,leavecalendar_Execute,leavecalendarview_Execute,leaverequest_dataprovider_Execute,leaverequest_Delete,leaverequest_Execute,leaverequest_FullControl,leaverequest_Insert,leaverequest_Services_Delete,leaverequest_Services_Execute,leaverequest_Services_FullControl,leaverequest_Services_Insert,leaverequest_Services_Update,leaverequests_Execute,leaverequestsgridpaneldata_Execute,leaverequestsgridpanelgeneral_Execute,leaverequestsgridpanelprompt_Execute,leaverequestsgridpanelview_Execute,leaverequests_Services_Execute,leaverequest_Update,leaverequestview_Execute,leaverequestwebpanel_Execute,leaverequestww_Execute,leaverequestww_Services_Execute,leavetype_dataprovider_Execute,leavetype_Delete,leavetype_Execute,leavetype_FullControl,leavetype_Insert,leavetype_Services_Delete,leavetype_Services_Execute,leavetype_Services_FullControl,leavetype_Services_Insert,leavetype_Services_Update,leavetype_Update,leavetypeview_Execute,leavetypeww_Execute,leavetypeww_Services_Execute,logworkhours_Execute,project_dataprovider_Execute,project_Delete,project_Execute,Project,project_FullControl,project_Insert,projectsincompanytest_Execute,project_Update,projectview_Execute,projectww_Execute,Project,projectww_Services_Execute,reports_Execute,Reports,schedulerdetailsform_Execute,workhourloglist_Execute,workhourloglist_Services_Execute";
            AV25GManagerPerms = "company_dataprovider_Execute,company_Delete,company_Execute,Company,company_FullControl,company_Insert,companylocation_dataprovider_Execute,companylocation_Delete,companylocation_Execute,companylocation_FullControl,companylocation_Insert,companylocation_Update,companylocationview_Execute,companylocationww_Execute,companylocationww_Services_Execute,company_Update,companyview_Execute,companyww_Execute,Company,companyww_Services_Execute,employee_dataprovider_Execute,employee_Delete,employee_Execute,Employee,employee_FullControl,employeehasprojectcopy1_Execute,employee_Insert,employeelist_Execute,Employee,employeelist_Services_Execute,employeeprojectmatrixcopy1_Execute,employeeprojectmatrix_Execute,employee_Services_Execute,employee_Update,employeeview_Execute,employeeww_Execute,Employee,employeeww_Services_Execute,gamchangeyourpassword_Execute,leavecalendar_Execute,leavecalendarview_Execute,project_dataprovider_Execute,project_Delete,project_Execute,Project,project_FullControl,project_Insert,projectsincompanytest_Execute,project_Update,projectview_Execute,projectww_Execute,Project,projectww_Services_Execute,reportdetail4_Execute,reports_Execute,Reports,schedulerdetailsform_Execute,workhourloglist_Execute,workhourloglist_Services_Execute";
            AV26EmployeePerms = "downloadapp_Execute,gamchangeyourpassword_Execute,leaverequest_dataprovider_Execute,leaverequest_Delete,leaverequest_Execute,leaverequest_FullControl,leaverequest_Insert,leaverequest_Services_Delete,leaverequest_Services_Execute,leaverequest_Services_FullControl,leaverequest_Services_Insert,leaverequest_Services_Update,leaverequests_Execute,leaverequestsgridpaneldata_Execute,leaverequestsgridpanelgeneral_Execute,leaverequestsgridpanelprompt_Execute,leaverequestsgridpanelview_Execute,leaverequests_Services_Execute,leaverequest_Update,leaverequestview_Execute,leaverequestww_Execute,leaverequestww_Services_Execute,leavetype_Services_Execute,logworkhours_Execute";
            AV27PManagerPerms = "downloadapp_Execute,employeeww_Execute,Employee,leaverequest_dataprovider_Execute,leaverequest_Delete,leaverequest_Execute,leaverequest_FullControl,leaverequest_Insert,leaverequest_Services_Delete,leaverequest_Services_Execute,leaverequest_Services_FullControl,leaverequest_Services_Insert,leaverequest_Services_Update,leaverequests_Execute,leaverequestsgridpaneldata_Execute,leaverequestsgridpanelgeneral_Execute,leaverequestsgridpanelprompt_Execute,leaverequestsgridpanelview_Execute,leaverequests_Services_Execute,leaverequest_Update,leaverequestview_Execute,leaverequestwebpanel_Execute,leaverequestww_Execute,leaverequestww_Services_Execute,reports_Execute,Reports,workhourloglist_Execute,workhourloglist_Services_Execute";
            AV12Perms = (GxSimpleCollection<string>)(GxRegex.Split(AV27PManagerPerms,","));
            AV8GAMRole = AV18GAMRepository.getrolebyexternalid("Is"+"Project Manager", out  AV10GAMErrorCollection);
            AV14GAMUser = AV18GAMRepository.getuserbyguid("d98b92be-faa8-4a2d-9e9a-001735938053", out  AV10GAMErrorCollection);
            AV15GAMPermissionFilter.gxTpr_Applicationid = 2;
            AV16GAMPermissions = AV14GAMUser.getallpermissions(AV15GAMPermissionFilter, out  AV10GAMErrorCollection);
            AV28GXV1 = 1;
            while ( AV28GXV1 <= AV16GAMPermissions.Count )
            {
               AV13GAMPermission = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV16GAMPermissions.Item(AV28GXV1));
               AV21Name = StringUtil.Trim( AV13GAMPermission.gxTpr_Name);
               if ( (AV12Perms.IndexOf(StringUtil.RTrim( AV21Name))>0) )
               {
                  AV22isok = AV8GAMRole.addpermission(AV13GAMPermission, out  AV10GAMErrorCollection);
                  if ( AV22isok )
                  {
                     HAC0( false, 43) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(AV13GAMPermission.gxTpr_Name, 94, Gx_line+11, 228, Gx_line+26, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(AV13GAMPermission.gxTpr_Guid, 400, Gx_line+11, 506, Gx_line+26, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+43);
                     context.CommitDataStores("insertrolepermissions",pr_default);
                  }
               }
               AV28GXV1 = (int)(AV28GXV1+1);
            }
            AV9PermString = AV12Perms.ToJSonString(false);
            AV20Count = (short)(AV16GAMPermissions.Count);
            HAC0( false, 83) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(AV13GAMPermission.gxTpr_Name, 61, Gx_line+11, 255, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(AV9PermString, 33, Gx_line+33, 400, Gx_line+66, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(AV14GAMUser.gxTpr_Guid, 511, Gx_line+44, 639, Gx_line+59, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(AV8GAMRole.gxTpr_Guid, 444, Gx_line+11, 561, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20Count), "ZZZ9")), 422, Gx_line+56, 471, Gx_line+71, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+83);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAC0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void HAC0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV24ManagerPerms = "";
         AV25GManagerPerms = "";
         AV26EmployeePerms = "";
         AV27PManagerPerms = "";
         AV12Perms = new GxSimpleCollection<string>();
         AV8GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV10GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV18GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV14GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV15GAMPermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV16GAMPermissions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV13GAMPermission = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV21Name = "";
         AV9PermString = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.ainsertrolepermissions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ainsertrolepermissions__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV20Count ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV28GXV1 ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV21Name ;
      private bool entryPointCalled ;
      private bool AV22isok ;
      private string AV24ManagerPerms ;
      private string AV25GManagerPerms ;
      private string AV26EmployeePerms ;
      private string AV27PManagerPerms ;
      private string AV9PermString ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV18GAMRepository ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV12Perms ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV16GAMPermissions ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV8GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV14GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV13GAMPermission ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV15GAMPermissionFilter ;
   }

   public class ainsertrolepermissions__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class ainsertrolepermissions__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
