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
   public class dpdateformat : GXProcedure
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

      public dpdateformat( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpdateformat( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP0_Gxm2wwpdaterangepickeroptions )
      {
         this.Gxm2wwpdaterangepickeroptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context) ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2wwpdaterangepickeroptions=this.Gxm2wwpdaterangepickeroptions;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions executeUdp( )
      {
         execute(out aP0_Gxm2wwpdaterangepickeroptions);
         return Gxm2wwpdaterangepickeroptions ;
      }

      public void executeSubmit( out GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP0_Gxm2wwpdaterangepickeroptions )
      {
         this.Gxm2wwpdaterangepickeroptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context) ;
         SubmitImpl();
         aP0_Gxm2wwpdaterangepickeroptions=this.Gxm2wwpdaterangepickeroptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_int1 = AV8EmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV8EmployeeId = GXt_int1;
         GXt_objcol_SdtSDTEmployeeLeaveDay2 = AV12Leavedays;
         new getleavedays(context ).execute(  AV8EmployeeId, out  AV9EmployeeLeaveDays) ;
         AV12Leavedays = GXt_objcol_SdtSDTEmployeeLeaveDay2;
         /* Using cursor P00102 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00102_A106EmployeeId[0];
            A119WorkHourLogDate = P00102_A119WorkHourLogDate[0];
            A118WorkHourLogId = P00102_A118WorkHourLogId[0];
            Gxm1wwpdaterangepickeroptions_formatteddays = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions_FormattedDaysItem(context);
            Gxm2wwpdaterangepickeroptions.gxTpr_Formatteddays.Add(Gxm1wwpdaterangepickeroptions_formatteddays, 0);
            GXt_char3 = AV5blank;
            new workhourlogdateduration(context ).execute(  A119WorkHourLogDate, out  AV6ToolTip) ;
            AV5blank = GXt_char3;
            GXt_dtime4 = DateTimeUtil.ResetTime( A119WorkHourLogDate ) ;
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Date = GXt_dtime4;
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Class = "daterangepicker-badge daterangepicker-badge-success";
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Tooltip = AV6ToolTip;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV15Udparg3 = new getloggedinusercompanyid(context).executeUdp( );
         /* Using cursor P00103 */
         pr_default.execute(1, new Object[] {AV15Udparg3});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00103_A100CompanyId[0];
            A139HolidayIsActive = P00103_A139HolidayIsActive[0];
            A115HolidayStartDate = P00103_A115HolidayStartDate[0];
            A114HolidayName = P00103_A114HolidayName[0];
            A113HolidayId = P00103_A113HolidayId[0];
            Gxm1wwpdaterangepickeroptions_formatteddays = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions_FormattedDaysItem(context);
            Gxm2wwpdaterangepickeroptions.gxTpr_Formatteddays.Add(Gxm1wwpdaterangepickeroptions_formatteddays, 0);
            GXt_dtime4 = DateTimeUtil.ResetTime( A115HolidayStartDate ) ;
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Date = GXt_dtime4;
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Class = "daterangepicker-badge daterangepicker-badge-warning";
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Tooltip = StringUtil.Trim( A114HolidayName);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV9EmployeeLeaveDays.Count )
         {
            AV7day = ((SdtSDTEmployeeLeaveDay)AV9EmployeeLeaveDays.Item(AV16GXV1));
            Gxm1wwpdaterangepickeroptions_formatteddays = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions_FormattedDaysItem(context);
            Gxm2wwpdaterangepickeroptions.gxTpr_Formatteddays.Add(Gxm1wwpdaterangepickeroptions_formatteddays, 0);
            GXt_dtime4 = DateTimeUtil.ResetTime( AV7day.gxTpr_Date ) ;
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Date = GXt_dtime4;
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Class = "daterangepicker-badge daterangepicker-badge-info";
            Gxm1wwpdaterangepickeroptions_formatteddays.gxTpr_Tooltip = AV7day.gxTpr_Leavetype;
            AV16GXV1 = (int)(AV16GXV1+1);
         }
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
         AV12Leavedays = new GXBaseCollection<SdtSDTEmployeeLeaveDay>( context, "SDTEmployeeLeaveDay", "YTT_version4");
         GXt_objcol_SdtSDTEmployeeLeaveDay2 = new GXBaseCollection<SdtSDTEmployeeLeaveDay>( context, "SDTEmployeeLeaveDay", "YTT_version4");
         AV9EmployeeLeaveDays = new GXBaseCollection<SdtSDTEmployeeLeaveDay>( context, "SDTEmployeeLeaveDay", "YTT_version4");
         P00102_A106EmployeeId = new long[1] ;
         P00102_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00102_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         Gxm1wwpdaterangepickeroptions_formatteddays = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions_FormattedDaysItem(context);
         AV5blank = "";
         GXt_char3 = "";
         AV6ToolTip = "";
         P00103_A100CompanyId = new long[1] ;
         P00103_A139HolidayIsActive = new bool[] {false} ;
         P00103_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00103_A114HolidayName = new string[] {""} ;
         P00103_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         A114HolidayName = "";
         AV7day = new SdtSDTEmployeeLeaveDay(context);
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpdateformat__default(),
            new Object[][] {
                new Object[] {
               P00102_A106EmployeeId, P00102_A119WorkHourLogDate, P00102_A118WorkHourLogId
               }
               , new Object[] {
               P00103_A100CompanyId, P00103_A139HolidayIsActive, P00103_A115HolidayStartDate, P00103_A114HolidayName, P00103_A113HolidayId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV16GXV1 ;
      private long AV8EmployeeId ;
      private long GXt_int1 ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private long AV15Udparg3 ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private string GXt_char3 ;
      private string A114HolidayName ;
      private DateTime GXt_dtime4 ;
      private DateTime A119WorkHourLogDate ;
      private DateTime A115HolidayStartDate ;
      private bool A139HolidayIsActive ;
      private string AV5blank ;
      private string AV6ToolTip ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions Gxm2wwpdaterangepickeroptions ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDay> AV12Leavedays ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDay> GXt_objcol_SdtSDTEmployeeLeaveDay2 ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDay> AV9EmployeeLeaveDays ;
      private IDataStoreProvider pr_default ;
      private long[] P00102_A106EmployeeId ;
      private DateTime[] P00102_A119WorkHourLogDate ;
      private long[] P00102_A118WorkHourLogId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions_FormattedDaysItem Gxm1wwpdaterangepickeroptions_formatteddays ;
      private long[] P00103_A100CompanyId ;
      private bool[] P00103_A139HolidayIsActive ;
      private DateTime[] P00103_A115HolidayStartDate ;
      private string[] P00103_A114HolidayName ;
      private long[] P00103_A113HolidayId ;
      private SdtSDTEmployeeLeaveDay AV7day ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP0_Gxm2wwpdaterangepickeroptions ;
   }

   public class dpdateformat__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00102;
          prmP00102 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00103;
          prmP00103 = new Object[] {
          new ParDef("AV15Udparg3",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00102", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :AV8EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00102,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00103", "SELECT CompanyId, HolidayIsActive, HolidayStartDate, HolidayName, HolidayId FROM Holiday WHERE (CompanyId = :AV15Udparg3) AND (HolidayIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00103,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
