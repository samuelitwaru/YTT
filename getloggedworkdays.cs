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
   public class getloggedworkdays : GXProcedure
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
            return "getloggedworkdays_Services_Execute" ;
         }

      }

      public getloggedworkdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getloggedworkdays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo aP0_CalendarInfo )
      {
         this.AV8CalendarInfo = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo(context) ;
         initialize();
         executePrivate();
         aP0_CalendarInfo=this.AV8CalendarInfo;
      }

      public GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo executeUdp( )
      {
         execute(out aP0_CalendarInfo);
         return AV8CalendarInfo ;
      }

      public void executeSubmit( out GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo aP0_CalendarInfo )
      {
         getloggedworkdays objgetloggedworkdays;
         objgetloggedworkdays = new getloggedworkdays();
         objgetloggedworkdays.AV8CalendarInfo = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo(context) ;
         objgetloggedworkdays.context.SetSubmitInitialConfig(context);
         objgetloggedworkdays.initialize();
         Submit( executePrivateCatch,objgetloggedworkdays);
         aP0_CalendarInfo=this.AV8CalendarInfo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getloggedworkdays)stateInfo).executePrivate();
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
         AV8CalendarInfo = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo(context);
         AV15Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor P005I2 */
         pr_default.execute(0, new Object[] {AV15Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P005I2_A106EmployeeId[0];
            A123WorkHourLogDescription = P005I2_A123WorkHourLogDescription[0];
            A119WorkHourLogDate = P005I2_A119WorkHourLogDate[0];
            A118WorkHourLogId = P005I2_A118WorkHourLogId[0];
            AV9CurrentDate = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry(context);
            AV9CurrentDate.gxTpr_Year = (short)(DateTimeUtil.Year( A119WorkHourLogDate));
            AV9CurrentDate.gxTpr_Month = (short)(DateTimeUtil.Month( A119WorkHourLogDate));
            AV9CurrentDate.gxTpr_Day = (short)(DateTimeUtil.Day( A119WorkHourLogDate));
            AV9CurrentDate.gxTpr_Status = 2;
            AV9CurrentDate.gxTpr_Color = "#007EFD";
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            AV9CurrentDate.gxTpr_Time = GXt_dtime1;
            AV9CurrentDate.gxTpr_Content = A123WorkHourLogDescription;
            AV8CalendarInfo.gxTpr_Events.Add(AV9CurrentDate, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV17Udparg2 = new getloggedinusercompanyid(context).executeUdp( );
         /* Using cursor P005I3 */
         pr_default.execute(1, new Object[] {Gx_date, AV17Udparg2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A139HolidayIsActive = P005I3_A139HolidayIsActive[0];
            A100CompanyId = P005I3_A100CompanyId[0];
            A115HolidayStartDate = P005I3_A115HolidayStartDate[0];
            A114HolidayName = P005I3_A114HolidayName[0];
            A113HolidayId = P005I3_A113HolidayId[0];
            AV9CurrentDate = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry(context);
            AV9CurrentDate.gxTpr_Year = (short)(DateTimeUtil.Year( A115HolidayStartDate));
            AV9CurrentDate.gxTpr_Month = (short)(DateTimeUtil.Month( A115HolidayStartDate));
            AV9CurrentDate.gxTpr_Day = (short)(DateTimeUtil.Day( A115HolidayStartDate));
            AV9CurrentDate.gxTpr_Status = 2;
            AV9CurrentDate.gxTpr_Color = "#ff668c";
            AV9CurrentDate.gxTpr_Content = A114HolidayName;
            AV8CalendarInfo.gxTpr_Events.Add(AV9CurrentDate, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV8CalendarInfo = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo(context);
         scmdbuf = "";
         P005I2_A106EmployeeId = new long[1] ;
         P005I2_A123WorkHourLogDescription = new string[] {""} ;
         P005I2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P005I2_A118WorkHourLogId = new long[1] ;
         A123WorkHourLogDescription = "";
         A119WorkHourLogDate = DateTime.MinValue;
         AV9CurrentDate = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         Gx_date = DateTime.MinValue;
         P005I3_A139HolidayIsActive = new bool[] {false} ;
         P005I3_A100CompanyId = new long[1] ;
         P005I3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P005I3_A114HolidayName = new string[] {""} ;
         P005I3_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         A114HolidayName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getloggedworkdays__default(),
            new Object[][] {
                new Object[] {
               P005I2_A106EmployeeId, P005I2_A123WorkHourLogDescription, P005I2_A119WorkHourLogDate, P005I2_A118WorkHourLogId
               }
               , new Object[] {
               P005I3_A139HolidayIsActive, P005I3_A100CompanyId, P005I3_A115HolidayStartDate, P005I3_A114HolidayName, P005I3_A113HolidayId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private long AV15Udparg1 ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private long AV17Udparg2 ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private string scmdbuf ;
      private string A114HolidayName ;
      private DateTime GXt_dtime1 ;
      private DateTime A119WorkHourLogDate ;
      private DateTime Gx_date ;
      private DateTime A115HolidayStartDate ;
      private bool A139HolidayIsActive ;
      private string A123WorkHourLogDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005I2_A106EmployeeId ;
      private string[] P005I2_A123WorkHourLogDescription ;
      private DateTime[] P005I2_A119WorkHourLogDate ;
      private long[] P005I2_A118WorkHourLogId ;
      private bool[] P005I3_A139HolidayIsActive ;
      private long[] P005I3_A100CompanyId ;
      private DateTime[] P005I3_A115HolidayStartDate ;
      private string[] P005I3_A114HolidayName ;
      private long[] P005I3_A113HolidayId ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo aP0_CalendarInfo ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo AV8CalendarInfo ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry AV9CurrentDate ;
   }

   public class getloggedworkdays__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005I2;
          prmP005I2 = new Object[] {
          new ParDef("AV15Udparg1",GXType.Int64,10,0)
          };
          Object[] prmP005I3;
          prmP005I3 = new Object[] {
          new ParDef("Gx_date",GXType.Date,8,0) ,
          new ParDef("AV17Udparg2",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005I2", "SELECT EmployeeId, WorkHourLogDescription, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :AV15Udparg1 ORDER BY WorkHourLogDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005I3", "SELECT HolidayIsActive, CompanyId, HolidayStartDate, HolidayName, HolidayId FROM Holiday WHERE (date_part('year', HolidayStartDate) = date_part('year', :Gx_date)) AND (HolidayIsActive = TRUE) AND (CompanyId = :AV17Udparg2) ORDER BY HolidayStartDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
