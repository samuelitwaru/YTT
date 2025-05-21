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
   public class prc_employeeweekreport : GXProcedure
   {
      public prc_employeeweekreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_employeeweekreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_CompanyLocationId ,
                           GxSimpleCollection<long> aP3_EmployeeIds ,
                           GxSimpleCollection<long> aP4_ProjectIdCollection ,
                           out GXBaseCollection<SdtSDTEmployeeWeekReport> aP5_SDTEmployeeWeekReportCollection )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV10CompanyLocationId = aP2_CompanyLocationId;
         this.AV11EmployeeIds = aP3_EmployeeIds;
         this.AV27ProjectIdCollection = aP4_ProjectIdCollection;
         this.AV26SDTEmployeeWeekReportCollection = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP5_SDTEmployeeWeekReportCollection=this.AV26SDTEmployeeWeekReportCollection;
      }

      public GXBaseCollection<SdtSDTEmployeeWeekReport> executeUdp( DateTime aP0_FromDate ,
                                                                    DateTime aP1_ToDate ,
                                                                    GxSimpleCollection<long> aP2_CompanyLocationId ,
                                                                    GxSimpleCollection<long> aP3_EmployeeIds ,
                                                                    GxSimpleCollection<long> aP4_ProjectIdCollection )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_CompanyLocationId, aP3_EmployeeIds, aP4_ProjectIdCollection, out aP5_SDTEmployeeWeekReportCollection);
         return AV26SDTEmployeeWeekReportCollection ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_CompanyLocationId ,
                                 GxSimpleCollection<long> aP3_EmployeeIds ,
                                 GxSimpleCollection<long> aP4_ProjectIdCollection ,
                                 out GXBaseCollection<SdtSDTEmployeeWeekReport> aP5_SDTEmployeeWeekReportCollection )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV10CompanyLocationId = aP2_CompanyLocationId;
         this.AV11EmployeeIds = aP3_EmployeeIds;
         this.AV27ProjectIdCollection = aP4_ProjectIdCollection;
         this.AV26SDTEmployeeWeekReportCollection = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4") ;
         SubmitImpl();
         aP5_SDTEmployeeWeekReportCollection=this.AV26SDTEmployeeWeekReportCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new logtofile(context ).execute(  "doing Prc_EmployeeWeekReport") ;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV10CompanyLocationId ,
                                              A106EmployeeId ,
                                              AV11EmployeeIds ,
                                              AV10CompanyLocationId.Count ,
                                              AV11EmployeeIds.Count ,
                                              A112EmployeeIsActive } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00CT3 */
         pr_default.execute(0, new Object[] {AV8FromDate, AV8FromDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00CT3_A100CompanyId[0];
            A112EmployeeIsActive = P00CT3_A112EmployeeIsActive[0];
            A106EmployeeId = P00CT3_A106EmployeeId[0];
            A157CompanyLocationId = P00CT3_A157CompanyLocationId[0];
            A189EmployeeFTEHours = P00CT3_A189EmployeeFTEHours[0];
            A148EmployeeName = P00CT3_A148EmployeeName[0];
            A40000GXC1 = P00CT3_A40000GXC1[0];
            n40000GXC1 = P00CT3_n40000GXC1[0];
            A40001GXC2 = P00CT3_A40001GXC2[0];
            n40001GXC2 = P00CT3_n40001GXC2[0];
            A157CompanyLocationId = P00CT3_A157CompanyLocationId[0];
            A40000GXC1 = P00CT3_A40000GXC1[0];
            n40000GXC1 = P00CT3_n40000GXC1[0];
            A40001GXC2 = P00CT3_A40001GXC2[0];
            n40001GXC2 = P00CT3_n40001GXC2[0];
            AV12SDTEmployeeWeekReport = new SdtSDTEmployeeWeekReport(context);
            GXt_int1 = AV21Mon;
            new prc_getemployeeloggedhours(context ).execute(  A106EmployeeId,  AV8FromDate,  AV8FromDate,  AV27ProjectIdCollection, out  GXt_int1) ;
            AV21Mon = GXt_int1;
            GXt_int1 = AV22Tue;
            new prc_getemployeeloggedhours(context ).execute(  A106EmployeeId,  DateTimeUtil.DAdd( AV8FromDate, (1)),  DateTimeUtil.DAdd( AV8FromDate, (1)),  AV27ProjectIdCollection, out  GXt_int1) ;
            AV22Tue = GXt_int1;
            GXt_int1 = AV23Wed;
            new prc_getemployeeloggedhours(context ).execute(  A106EmployeeId,  DateTimeUtil.DAdd( AV8FromDate, (2)),  DateTimeUtil.DAdd( AV8FromDate, (2)),  AV27ProjectIdCollection, out  GXt_int1) ;
            AV23Wed = GXt_int1;
            GXt_int1 = AV24Thu;
            new prc_getemployeeloggedhours(context ).execute(  A106EmployeeId,  DateTimeUtil.DAdd( AV8FromDate, (3)),  DateTimeUtil.DAdd( AV8FromDate, (3)),  AV27ProjectIdCollection, out  GXt_int1) ;
            AV24Thu = GXt_int1;
            GXt_int1 = AV25Fri;
            new prc_getemployeeloggedhours(context ).execute(  A106EmployeeId,  DateTimeUtil.DAdd( AV8FromDate, (4)),  DateTimeUtil.DAdd( AV8FromDate, (4)),  AV27ProjectIdCollection, out  GXt_int1) ;
            AV25Fri = GXt_int1;
            GXt_int1 = (long)(Math.Round(AV29Sat, 18, MidpointRounding.ToEven));
            new prc_getemployeeloggedhours(context ).execute(  A106EmployeeId,  DateTimeUtil.DAdd( AV8FromDate, (5)),  DateTimeUtil.DAdd( AV8FromDate, (5)),  AV27ProjectIdCollection, out  GXt_int1) ;
            AV29Sat = (decimal)(GXt_int1);
            GXt_int1 = (long)(Math.Round(AV30Sun, 18, MidpointRounding.ToEven));
            new prc_getemployeeloggedhours(context ).execute(  A106EmployeeId,  DateTimeUtil.DAdd( AV8FromDate, (6)),  DateTimeUtil.DAdd( AV8FromDate, (6)),  AV27ProjectIdCollection, out  GXt_int1) ;
            AV30Sun = (decimal)(GXt_int1);
            GXt_decimal2 = AV31Blank;
            new employeeleavetotal(context ).execute(  A106EmployeeId,  AV8FromDate,  DateTimeUtil.DAdd( AV8FromDate, (4)), out  AV32Leave) ;
            AV31Blank = GXt_decimal2;
            AV33Total = (short)(A40000GXC1*60+A40001GXC2);
            AV34Expected = (decimal)((A189EmployeeFTEHours*60)-AV32Leave);
            AV12SDTEmployeeWeekReport.gxTpr_Employeename = StringUtil.Trim( A148EmployeeName);
            AV12SDTEmployeeWeekReport.gxTpr_Mon = AV21Mon;
            AV12SDTEmployeeWeekReport.gxTpr_Tue = AV22Tue;
            AV12SDTEmployeeWeekReport.gxTpr_Wed = AV23Wed;
            AV12SDTEmployeeWeekReport.gxTpr_Thu = AV24Thu;
            AV12SDTEmployeeWeekReport.gxTpr_Fri = AV25Fri;
            AV12SDTEmployeeWeekReport.gxTpr_Sat = (long)(Math.Round(AV29Sat, 18, MidpointRounding.ToEven));
            AV12SDTEmployeeWeekReport.gxTpr_Sun = (long)(Math.Round(AV30Sun, 18, MidpointRounding.ToEven));
            AV12SDTEmployeeWeekReport.gxTpr_Leave = (long)(Math.Round(AV32Leave, 18, MidpointRounding.ToEven));
            AV12SDTEmployeeWeekReport.gxTpr_Dailyexpected = (long)(Math.Round((A189EmployeeFTEHours*60)/ (decimal)(5), 18, MidpointRounding.ToEven));
            AV12SDTEmployeeWeekReport.gxTpr_Total = AV33Total;
            AV12SDTEmployeeWeekReport.gxTpr_Expected = AV34Expected;
            GXt_boolean3 = false;
            new isdateholiday(context ).execute(  AV8FromDate,  A106EmployeeId, out  AV14MonHolidayName, out  GXt_boolean3) ;
            AV12SDTEmployeeWeekReport.gxTpr_Mon_isholiday = GXt_boolean3;
            GXt_boolean3 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV8FromDate, (1)),  A106EmployeeId, out  AV15TueHolidayName, out  GXt_boolean3) ;
            AV12SDTEmployeeWeekReport.gxTpr_Tue_isholiday = GXt_boolean3;
            GXt_boolean3 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV8FromDate, (2)),  A106EmployeeId, out  AV16WedHolidayName, out  GXt_boolean3) ;
            AV12SDTEmployeeWeekReport.gxTpr_Wed_isholiday = GXt_boolean3;
            GXt_boolean3 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV8FromDate, (3)),  A106EmployeeId, out  AV17ThuHolidayName, out  GXt_boolean3) ;
            AV12SDTEmployeeWeekReport.gxTpr_Thu_isholiday = GXt_boolean3;
            GXt_boolean3 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV8FromDate, (4)),  A106EmployeeId, out  AV18FriHolidayName, out  GXt_boolean3) ;
            AV12SDTEmployeeWeekReport.gxTpr_Fri_isholiday = GXt_boolean3;
            GXt_boolean3 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV8FromDate, (5)),  A106EmployeeId, out  AV19SatHolidayName, out  GXt_boolean3) ;
            AV12SDTEmployeeWeekReport.gxTpr_Sat_isholiday = GXt_boolean3;
            GXt_boolean3 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV8FromDate, (6)),  A106EmployeeId, out  AV20SunHolidayName, out  GXt_boolean3) ;
            AV12SDTEmployeeWeekReport.gxTpr_Sun_isholiday = GXt_boolean3;
            GXt_char4 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char4) ;
            GXt_char5 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char5) ;
            GXt_char6 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char6) ;
            AV12SDTEmployeeWeekReport.gxTpr_Mon_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV14MonHolidayName)) ? GXt_char5+"<br /><small>"+AV14MonHolidayName+"</small>" : GXt_char6);
            GXt_char6 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char6) ;
            GXt_char5 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char5) ;
            GXt_char4 = "";
            new formattime(context ).execute(  AV22Tue, out  GXt_char4) ;
            AV12SDTEmployeeWeekReport.gxTpr_Tue_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV15TueHolidayName)) ? GXt_char5+"<br /><small>"+AV15TueHolidayName+"</small>" : GXt_char4);
            GXt_char6 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char6) ;
            GXt_char5 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char5) ;
            GXt_char4 = "";
            new formattime(context ).execute(  AV23Wed, out  GXt_char4) ;
            AV12SDTEmployeeWeekReport.gxTpr_Wed_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV16WedHolidayName)) ? GXt_char5+"<br /><small>"+AV16WedHolidayName+"</small>" : GXt_char4);
            GXt_char6 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char6) ;
            GXt_char5 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char5) ;
            GXt_char4 = "";
            new formattime(context ).execute(  AV24Thu, out  GXt_char4) ;
            AV12SDTEmployeeWeekReport.gxTpr_Thu_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV17ThuHolidayName)) ? GXt_char5+"<br /><small>"+AV17ThuHolidayName+"</small>" : GXt_char4);
            GXt_char6 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char6) ;
            GXt_char5 = "";
            new formattime(context ).execute(  AV21Mon, out  GXt_char5) ;
            GXt_char4 = "";
            new formattime(context ).execute(  AV25Fri, out  GXt_char4) ;
            AV12SDTEmployeeWeekReport.gxTpr_Fri_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV18FriHolidayName)) ? GXt_char5+"<br /><small>"+AV18FriHolidayName+"</small>" : GXt_char4);
            GXt_char6 = "";
            new formattime(context ).execute(  (long)(Math.Round(AV29Sat, 18, MidpointRounding.ToEven)), out  GXt_char6) ;
            AV12SDTEmployeeWeekReport.gxTpr_Sat_formatted = GXt_char6;
            GXt_char6 = "";
            new formattime(context ).execute(  (long)(Math.Round(AV30Sun, 18, MidpointRounding.ToEven)), out  GXt_char6) ;
            AV12SDTEmployeeWeekReport.gxTpr_Sun_formatted = GXt_char6;
            GXt_char6 = "";
            new formattime(context ).execute(  (long)(Math.Round(AV32Leave, 18, MidpointRounding.ToEven)), out  GXt_char6) ;
            AV12SDTEmployeeWeekReport.gxTpr_Leave_formatted = GXt_char6;
            GXt_char6 = "";
            new formattime(context ).execute(  AV33Total, out  GXt_char6) ;
            AV12SDTEmployeeWeekReport.gxTpr_Total_formatted = GXt_char6;
            GXt_char6 = "";
            new formattime(context ).execute(  (long)(Math.Round(AV34Expected, 18, MidpointRounding.ToEven)), out  GXt_char6) ;
            AV12SDTEmployeeWeekReport.gxTpr_Expected_formatted = GXt_char6;
            AV26SDTEmployeeWeekReportCollection.Add(AV12SDTEmployeeWeekReport, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV26SDTEmployeeWeekReportCollection = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4");
         P00CT3_A100CompanyId = new long[1] ;
         P00CT3_A112EmployeeIsActive = new bool[] {false} ;
         P00CT3_A106EmployeeId = new long[1] ;
         P00CT3_A157CompanyLocationId = new long[1] ;
         P00CT3_A189EmployeeFTEHours = new short[1] ;
         P00CT3_A148EmployeeName = new string[] {""} ;
         P00CT3_A40000GXC1 = new short[1] ;
         P00CT3_n40000GXC1 = new bool[] {false} ;
         P00CT3_A40001GXC2 = new short[1] ;
         P00CT3_n40001GXC2 = new bool[] {false} ;
         A148EmployeeName = "";
         AV12SDTEmployeeWeekReport = new SdtSDTEmployeeWeekReport(context);
         AV14MonHolidayName = "";
         AV15TueHolidayName = "";
         AV16WedHolidayName = "";
         AV17ThuHolidayName = "";
         AV18FriHolidayName = "";
         AV19SatHolidayName = "";
         AV20SunHolidayName = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char6 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_employeeweekreport__default(),
            new Object[][] {
                new Object[] {
               P00CT3_A100CompanyId, P00CT3_A112EmployeeIsActive, P00CT3_A106EmployeeId, P00CT3_A157CompanyLocationId, P00CT3_A189EmployeeFTEHours, P00CT3_A148EmployeeName, P00CT3_A40000GXC1, P00CT3_n40000GXC1, P00CT3_A40001GXC2, P00CT3_n40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A189EmployeeFTEHours ;
      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private short AV33Total ;
      private int AV10CompanyLocationId_Count ;
      private int AV11EmployeeIds_Count ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long AV21Mon ;
      private long AV22Tue ;
      private long AV23Wed ;
      private long AV24Thu ;
      private long AV25Fri ;
      private long GXt_int1 ;
      private decimal AV29Sat ;
      private decimal AV30Sun ;
      private decimal AV31Blank ;
      private decimal GXt_decimal2 ;
      private decimal AV32Leave ;
      private decimal AV34Expected ;
      private string A148EmployeeName ;
      private string AV14MonHolidayName ;
      private string AV15TueHolidayName ;
      private string AV16WedHolidayName ;
      private string AV17ThuHolidayName ;
      private string AV18FriHolidayName ;
      private string AV19SatHolidayName ;
      private string AV20SunHolidayName ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char6 ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private bool A112EmployeeIsActive ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool GXt_boolean3 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV10CompanyLocationId ;
      private GxSimpleCollection<long> AV11EmployeeIds ;
      private GxSimpleCollection<long> AV27ProjectIdCollection ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> AV26SDTEmployeeWeekReportCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00CT3_A100CompanyId ;
      private bool[] P00CT3_A112EmployeeIsActive ;
      private long[] P00CT3_A106EmployeeId ;
      private long[] P00CT3_A157CompanyLocationId ;
      private short[] P00CT3_A189EmployeeFTEHours ;
      private string[] P00CT3_A148EmployeeName ;
      private short[] P00CT3_A40000GXC1 ;
      private bool[] P00CT3_n40000GXC1 ;
      private short[] P00CT3_A40001GXC2 ;
      private bool[] P00CT3_n40001GXC2 ;
      private SdtSDTEmployeeWeekReport AV12SDTEmployeeWeekReport ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> aP5_SDTEmployeeWeekReportCollection ;
   }

   public class prc_employeeweekreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CT3( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV10CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV11EmployeeIds ,
                                             int AV10CompanyLocationId_Count ,
                                             int AV11EmployeeIds_Count ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[2];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeIsActive, T1.EmployeeId, T2.CompanyLocationId, T1.EmployeeFTEHours, T1.EmployeeName, COALESCE( T3.GXC1, 0) AS GXC1, COALESCE( T3.GXC2, 0) AS GXC2 FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate >= :AV8FromDate and WorkHourLogDate <= (CAST(:AV8FromDate AS date) + CAST (( 6) || ' DAY' AS INTERVAL))) GROUP BY EmployeeId ) T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         if ( AV10CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV10CompanyLocationId, "T2.CompanyLocationId IN (", ")")+")");
         }
         if ( AV11EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CT3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (bool)dynConstraints[6] );
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
          Object[] prmP00CT3;
          prmP00CT3 = new Object[] {
          new ParDef("AV8FromDate",GXType.Date,8,0) ,
          new ParDef("AV8FromDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CT3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
