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
   public class dpemployeeweekreport : GXProcedure
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

      public dpemployeeweekreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpemployeeweekreport( IGxContext context )
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
                           out GXBaseCollection<SdtSDTEmployeeWeekReport> aP4_Gxm2rootcol )
      {
         this.AV13FromDate = aP0_FromDate;
         this.AV16ToDate = aP1_ToDate;
         this.AV14CompanyLocationId = aP2_CompanyLocationId;
         this.AV19EmployeeIds = aP3_EmployeeIds;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTEmployeeWeekReport> executeUdp( DateTime aP0_FromDate ,
                                                                    DateTime aP1_ToDate ,
                                                                    GxSimpleCollection<long> aP2_CompanyLocationId ,
                                                                    GxSimpleCollection<long> aP3_EmployeeIds )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_CompanyLocationId, aP3_EmployeeIds, out aP4_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_CompanyLocationId ,
                                 GxSimpleCollection<long> aP3_EmployeeIds ,
                                 out GXBaseCollection<SdtSDTEmployeeWeekReport> aP4_Gxm2rootcol )
      {
         this.AV13FromDate = aP0_FromDate;
         this.AV16ToDate = aP1_ToDate;
         this.AV14CompanyLocationId = aP2_CompanyLocationId;
         this.AV19EmployeeIds = aP3_EmployeeIds;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4") ;
         SubmitImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV14CompanyLocationId ,
                                              A106EmployeeId ,
                                              AV19EmployeeIds ,
                                              AV14CompanyLocationId.Count ,
                                              AV19EmployeeIds.Count ,
                                              A112EmployeeIsActive } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P001U10 */
         pr_default.execute(0, new Object[] {AV13FromDate, AV13FromDate, AV13FromDate, AV13FromDate, AV13FromDate, AV13FromDate, AV13FromDate, AV13FromDate, AV13FromDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P001U10_A100CompanyId[0];
            A112EmployeeIsActive = P001U10_A112EmployeeIsActive[0];
            A106EmployeeId = P001U10_A106EmployeeId[0];
            A157CompanyLocationId = P001U10_A157CompanyLocationId[0];
            A189EmployeeFTEHours = P001U10_A189EmployeeFTEHours[0];
            A148EmployeeName = P001U10_A148EmployeeName[0];
            A40000GXC1 = P001U10_A40000GXC1[0];
            n40000GXC1 = P001U10_n40000GXC1[0];
            A40001GXC2 = P001U10_A40001GXC2[0];
            n40001GXC2 = P001U10_n40001GXC2[0];
            A40002GXC3 = P001U10_A40002GXC3[0];
            n40002GXC3 = P001U10_n40002GXC3[0];
            A40003GXC4 = P001U10_A40003GXC4[0];
            n40003GXC4 = P001U10_n40003GXC4[0];
            A40004GXC5 = P001U10_A40004GXC5[0];
            n40004GXC5 = P001U10_n40004GXC5[0];
            A40005GXC6 = P001U10_A40005GXC6[0];
            n40005GXC6 = P001U10_n40005GXC6[0];
            A40006GXC7 = P001U10_A40006GXC7[0];
            n40006GXC7 = P001U10_n40006GXC7[0];
            A40007GXC8 = P001U10_A40007GXC8[0];
            n40007GXC8 = P001U10_n40007GXC8[0];
            A40008GXC9 = P001U10_A40008GXC9[0];
            n40008GXC9 = P001U10_n40008GXC9[0];
            A40009GXC10 = P001U10_A40009GXC10[0];
            n40009GXC10 = P001U10_n40009GXC10[0];
            A40010GXC11 = P001U10_A40010GXC11[0];
            n40010GXC11 = P001U10_n40010GXC11[0];
            A40011GXC12 = P001U10_A40011GXC12[0];
            n40011GXC12 = P001U10_n40011GXC12[0];
            A40012GXC13 = P001U10_A40012GXC13[0];
            n40012GXC13 = P001U10_n40012GXC13[0];
            A40013GXC14 = P001U10_A40013GXC14[0];
            n40013GXC14 = P001U10_n40013GXC14[0];
            A40014GXC15 = P001U10_A40014GXC15[0];
            n40014GXC15 = P001U10_n40014GXC15[0];
            A40015GXC16 = P001U10_A40015GXC16[0];
            n40015GXC16 = P001U10_n40015GXC16[0];
            A157CompanyLocationId = P001U10_A157CompanyLocationId[0];
            A40000GXC1 = P001U10_A40000GXC1[0];
            n40000GXC1 = P001U10_n40000GXC1[0];
            A40001GXC2 = P001U10_A40001GXC2[0];
            n40001GXC2 = P001U10_n40001GXC2[0];
            A40002GXC3 = P001U10_A40002GXC3[0];
            n40002GXC3 = P001U10_n40002GXC3[0];
            A40003GXC4 = P001U10_A40003GXC4[0];
            n40003GXC4 = P001U10_n40003GXC4[0];
            A40004GXC5 = P001U10_A40004GXC5[0];
            n40004GXC5 = P001U10_n40004GXC5[0];
            A40005GXC6 = P001U10_A40005GXC6[0];
            n40005GXC6 = P001U10_n40005GXC6[0];
            A40006GXC7 = P001U10_A40006GXC7[0];
            n40006GXC7 = P001U10_n40006GXC7[0];
            A40007GXC8 = P001U10_A40007GXC8[0];
            n40007GXC8 = P001U10_n40007GXC8[0];
            A40008GXC9 = P001U10_A40008GXC9[0];
            n40008GXC9 = P001U10_n40008GXC9[0];
            A40009GXC10 = P001U10_A40009GXC10[0];
            n40009GXC10 = P001U10_n40009GXC10[0];
            A40010GXC11 = P001U10_A40010GXC11[0];
            n40010GXC11 = P001U10_n40010GXC11[0];
            A40011GXC12 = P001U10_A40011GXC12[0];
            n40011GXC12 = P001U10_n40011GXC12[0];
            A40012GXC13 = P001U10_A40012GXC13[0];
            n40012GXC13 = P001U10_n40012GXC13[0];
            A40013GXC14 = P001U10_A40013GXC14[0];
            n40013GXC14 = P001U10_n40013GXC14[0];
            A40014GXC15 = P001U10_A40014GXC15[0];
            n40014GXC15 = P001U10_n40014GXC15[0];
            A40015GXC16 = P001U10_A40015GXC16[0];
            n40015GXC16 = P001U10_n40015GXC16[0];
            Gxm1sdtemployeeweekreport = new SdtSDTEmployeeWeekReport(context);
            Gxm2rootcol.Add(Gxm1sdtemployeeweekreport, 0);
            AV5Mon = (long)(A40000GXC1*60+A40001GXC2);
            AV6Tue = (long)(A40002GXC3*60+A40003GXC4);
            AV7Wed = (long)(A40004GXC5*60+A40005GXC6);
            AV8Thu = (long)(A40006GXC7*60+A40007GXC8);
            AV9Fri = (long)(A40008GXC9*60+A40009GXC10);
            AV10Sat = (long)(A40010GXC11*60+A40011GXC12);
            AV11Sun = (long)(A40012GXC13*60+A40013GXC14);
            GXt_decimal1 = (decimal)(AV17Blank);
            new employeeleavetotal(context ).execute(  A106EmployeeId,  AV13FromDate,  DateTimeUtil.DAdd( AV13FromDate, (4)), out  AV15Leave) ;
            AV17Blank = (short)(Math.Round(GXt_decimal1, 18, MidpointRounding.ToEven));
            AV12Total = (long)(A40014GXC15*60+A40015GXC16);
            AV18Expected = (decimal)((A189EmployeeFTEHours*60)-AV15Leave);
            Gxm1sdtemployeeweekreport.gxTpr_Employeename = StringUtil.Trim( A148EmployeeName);
            Gxm1sdtemployeeweekreport.gxTpr_Mon = AV5Mon;
            Gxm1sdtemployeeweekreport.gxTpr_Tue = AV6Tue;
            Gxm1sdtemployeeweekreport.gxTpr_Wed = AV7Wed;
            Gxm1sdtemployeeweekreport.gxTpr_Thu = AV8Thu;
            Gxm1sdtemployeeweekreport.gxTpr_Fri = AV9Fri;
            Gxm1sdtemployeeweekreport.gxTpr_Sat = AV10Sat;
            Gxm1sdtemployeeweekreport.gxTpr_Sun = AV11Sun;
            Gxm1sdtemployeeweekreport.gxTpr_Leave = (long)(Math.Round(AV15Leave, 18, MidpointRounding.ToEven));
            Gxm1sdtemployeeweekreport.gxTpr_Dailyexpected = (long)(Math.Round((A189EmployeeFTEHours*60)/ (decimal)(5), 18, MidpointRounding.ToEven));
            Gxm1sdtemployeeweekreport.gxTpr_Total = AV12Total;
            Gxm1sdtemployeeweekreport.gxTpr_Expected = AV18Expected;
            GXt_boolean2 = false;
            new isdateholiday(context ).execute(  AV13FromDate,  A106EmployeeId, out  AV22MonHolidayName, out  GXt_boolean2) ;
            Gxm1sdtemployeeweekreport.gxTpr_Mon_isholiday = GXt_boolean2;
            GXt_boolean2 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV13FromDate, (1)),  A106EmployeeId, out  AV23TueHolidayName, out  GXt_boolean2) ;
            Gxm1sdtemployeeweekreport.gxTpr_Tue_isholiday = GXt_boolean2;
            GXt_boolean2 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV13FromDate, (2)),  A106EmployeeId, out  AV24WedHolidayName, out  GXt_boolean2) ;
            Gxm1sdtemployeeweekreport.gxTpr_Wed_isholiday = GXt_boolean2;
            GXt_boolean2 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV13FromDate, (3)),  A106EmployeeId, out  AV25ThuHolidayName, out  GXt_boolean2) ;
            Gxm1sdtemployeeweekreport.gxTpr_Thu_isholiday = GXt_boolean2;
            GXt_boolean2 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV13FromDate, (4)),  A106EmployeeId, out  AV26FriHolidayName, out  GXt_boolean2) ;
            Gxm1sdtemployeeweekreport.gxTpr_Fri_isholiday = GXt_boolean2;
            GXt_boolean2 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV13FromDate, (5)),  A106EmployeeId, out  AV34SatHolidayName, out  GXt_boolean2) ;
            Gxm1sdtemployeeweekreport.gxTpr_Sat_isholiday = GXt_boolean2;
            GXt_boolean2 = false;
            new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV13FromDate, (6)),  A106EmployeeId, out  AV41SunHolidayName, out  GXt_boolean2) ;
            Gxm1sdtemployeeweekreport.gxTpr_Sun_isholiday = GXt_boolean2;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22MonHolidayName)) )
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV5Mon, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Mon_formatted = GXt_char3+"<br /><small>"+AV22MonHolidayName+"</small>";
            }
            else
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV5Mon, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Mon_formatted = GXt_char3;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TueHolidayName)) )
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV6Tue, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Tue_formatted = GXt_char3+"<br /><small>"+AV23TueHolidayName+"</small>";
            }
            else
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV6Tue, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Tue_formatted = GXt_char3;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24WedHolidayName)) )
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV7Wed, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Wed_formatted = GXt_char3+"<br /><small>"+AV24WedHolidayName+"</small>";
            }
            else
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV7Wed, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Wed_formatted = GXt_char3;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ThuHolidayName)) )
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV8Thu, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Thu_formatted = GXt_char3+"<br /><small>"+AV25ThuHolidayName+"</small>";
            }
            else
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV8Thu, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Thu_formatted = GXt_char3;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26FriHolidayName)) )
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV9Fri, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Fri_formatted = GXt_char3+"<br /><small>"+AV26FriHolidayName+"</small>";
            }
            else
            {
               GXt_char3 = "";
               new formattime(context ).execute(  AV9Fri, out  GXt_char3) ;
               Gxm1sdtemployeeweekreport.gxTpr_Fri_formatted = GXt_char3;
            }
            GXt_char3 = "";
            new formattime(context ).execute(  AV10Sat, out  GXt_char3) ;
            Gxm1sdtemployeeweekreport.gxTpr_Sat_formatted = GXt_char3;
            GXt_char3 = "";
            new formattime(context ).execute(  AV11Sun, out  GXt_char3) ;
            Gxm1sdtemployeeweekreport.gxTpr_Sun_formatted = GXt_char3;
            GXt_char3 = "";
            new formattime(context ).execute(  (long)(Math.Round(AV15Leave, 18, MidpointRounding.ToEven)), out  GXt_char3) ;
            Gxm1sdtemployeeweekreport.gxTpr_Leave_formatted = GXt_char3;
            GXt_char3 = "";
            new formattime(context ).execute(  AV12Total, out  GXt_char3) ;
            Gxm1sdtemployeeweekreport.gxTpr_Total_formatted = GXt_char3;
            GXt_char3 = "";
            new formattime(context ).execute(  (long)(Math.Round(AV18Expected, 18, MidpointRounding.ToEven)), out  GXt_char3) ;
            Gxm1sdtemployeeweekreport.gxTpr_Expected_formatted = GXt_char3;
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
         P001U10_A100CompanyId = new long[1] ;
         P001U10_A112EmployeeIsActive = new bool[] {false} ;
         P001U10_A106EmployeeId = new long[1] ;
         P001U10_A157CompanyLocationId = new long[1] ;
         P001U10_A189EmployeeFTEHours = new short[1] ;
         P001U10_A148EmployeeName = new string[] {""} ;
         P001U10_A40000GXC1 = new short[1] ;
         P001U10_n40000GXC1 = new bool[] {false} ;
         P001U10_A40001GXC2 = new short[1] ;
         P001U10_n40001GXC2 = new bool[] {false} ;
         P001U10_A40002GXC3 = new short[1] ;
         P001U10_n40002GXC3 = new bool[] {false} ;
         P001U10_A40003GXC4 = new short[1] ;
         P001U10_n40003GXC4 = new bool[] {false} ;
         P001U10_A40004GXC5 = new short[1] ;
         P001U10_n40004GXC5 = new bool[] {false} ;
         P001U10_A40005GXC6 = new short[1] ;
         P001U10_n40005GXC6 = new bool[] {false} ;
         P001U10_A40006GXC7 = new short[1] ;
         P001U10_n40006GXC7 = new bool[] {false} ;
         P001U10_A40007GXC8 = new short[1] ;
         P001U10_n40007GXC8 = new bool[] {false} ;
         P001U10_A40008GXC9 = new short[1] ;
         P001U10_n40008GXC9 = new bool[] {false} ;
         P001U10_A40009GXC10 = new short[1] ;
         P001U10_n40009GXC10 = new bool[] {false} ;
         P001U10_A40010GXC11 = new short[1] ;
         P001U10_n40010GXC11 = new bool[] {false} ;
         P001U10_A40011GXC12 = new short[1] ;
         P001U10_n40011GXC12 = new bool[] {false} ;
         P001U10_A40012GXC13 = new short[1] ;
         P001U10_n40012GXC13 = new bool[] {false} ;
         P001U10_A40013GXC14 = new short[1] ;
         P001U10_n40013GXC14 = new bool[] {false} ;
         P001U10_A40014GXC15 = new short[1] ;
         P001U10_n40014GXC15 = new bool[] {false} ;
         P001U10_A40015GXC16 = new short[1] ;
         P001U10_n40015GXC16 = new bool[] {false} ;
         A148EmployeeName = "";
         Gxm1sdtemployeeweekreport = new SdtSDTEmployeeWeekReport(context);
         AV22MonHolidayName = "";
         AV23TueHolidayName = "";
         AV24WedHolidayName = "";
         AV25ThuHolidayName = "";
         AV26FriHolidayName = "";
         AV34SatHolidayName = "";
         AV41SunHolidayName = "";
         GXt_char3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpemployeeweekreport__default(),
            new Object[][] {
                new Object[] {
               P001U10_A100CompanyId, P001U10_A112EmployeeIsActive, P001U10_A106EmployeeId, P001U10_A157CompanyLocationId, P001U10_A189EmployeeFTEHours, P001U10_A148EmployeeName, P001U10_A40000GXC1, P001U10_n40000GXC1, P001U10_A40001GXC2, P001U10_n40001GXC2,
               P001U10_A40002GXC3, P001U10_n40002GXC3, P001U10_A40003GXC4, P001U10_n40003GXC4, P001U10_A40004GXC5, P001U10_n40004GXC5, P001U10_A40005GXC6, P001U10_n40005GXC6, P001U10_A40006GXC7, P001U10_n40006GXC7,
               P001U10_A40007GXC8, P001U10_n40007GXC8, P001U10_A40008GXC9, P001U10_n40008GXC9, P001U10_A40009GXC10, P001U10_n40009GXC10, P001U10_A40010GXC11, P001U10_n40010GXC11, P001U10_A40011GXC12, P001U10_n40011GXC12,
               P001U10_A40012GXC13, P001U10_n40012GXC13, P001U10_A40013GXC14, P001U10_n40013GXC14, P001U10_A40014GXC15, P001U10_n40014GXC15, P001U10_A40015GXC16, P001U10_n40015GXC16
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A189EmployeeFTEHours ;
      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private short A40002GXC3 ;
      private short A40003GXC4 ;
      private short A40004GXC5 ;
      private short A40005GXC6 ;
      private short A40006GXC7 ;
      private short A40007GXC8 ;
      private short A40008GXC9 ;
      private short A40009GXC10 ;
      private short A40010GXC11 ;
      private short A40011GXC12 ;
      private short A40012GXC13 ;
      private short A40013GXC14 ;
      private short A40014GXC15 ;
      private short A40015GXC16 ;
      private short AV17Blank ;
      private int AV14CompanyLocationId_Count ;
      private int AV19EmployeeIds_Count ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long AV5Mon ;
      private long AV6Tue ;
      private long AV7Wed ;
      private long AV8Thu ;
      private long AV9Fri ;
      private long AV10Sat ;
      private long AV11Sun ;
      private long AV12Total ;
      private decimal GXt_decimal1 ;
      private decimal AV15Leave ;
      private decimal AV18Expected ;
      private string A148EmployeeName ;
      private string AV22MonHolidayName ;
      private string AV23TueHolidayName ;
      private string AV24WedHolidayName ;
      private string AV25ThuHolidayName ;
      private string AV26FriHolidayName ;
      private string AV34SatHolidayName ;
      private string AV41SunHolidayName ;
      private string GXt_char3 ;
      private DateTime AV13FromDate ;
      private DateTime AV16ToDate ;
      private bool A112EmployeeIsActive ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private bool n40003GXC4 ;
      private bool n40004GXC5 ;
      private bool n40005GXC6 ;
      private bool n40006GXC7 ;
      private bool n40007GXC8 ;
      private bool n40008GXC9 ;
      private bool n40009GXC10 ;
      private bool n40010GXC11 ;
      private bool n40011GXC12 ;
      private bool n40012GXC13 ;
      private bool n40013GXC14 ;
      private bool n40014GXC15 ;
      private bool n40015GXC16 ;
      private bool GXt_boolean2 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV14CompanyLocationId ;
      private GxSimpleCollection<long> AV19EmployeeIds ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private long[] P001U10_A100CompanyId ;
      private bool[] P001U10_A112EmployeeIsActive ;
      private long[] P001U10_A106EmployeeId ;
      private long[] P001U10_A157CompanyLocationId ;
      private short[] P001U10_A189EmployeeFTEHours ;
      private string[] P001U10_A148EmployeeName ;
      private short[] P001U10_A40000GXC1 ;
      private bool[] P001U10_n40000GXC1 ;
      private short[] P001U10_A40001GXC2 ;
      private bool[] P001U10_n40001GXC2 ;
      private short[] P001U10_A40002GXC3 ;
      private bool[] P001U10_n40002GXC3 ;
      private short[] P001U10_A40003GXC4 ;
      private bool[] P001U10_n40003GXC4 ;
      private short[] P001U10_A40004GXC5 ;
      private bool[] P001U10_n40004GXC5 ;
      private short[] P001U10_A40005GXC6 ;
      private bool[] P001U10_n40005GXC6 ;
      private short[] P001U10_A40006GXC7 ;
      private bool[] P001U10_n40006GXC7 ;
      private short[] P001U10_A40007GXC8 ;
      private bool[] P001U10_n40007GXC8 ;
      private short[] P001U10_A40008GXC9 ;
      private bool[] P001U10_n40008GXC9 ;
      private short[] P001U10_A40009GXC10 ;
      private bool[] P001U10_n40009GXC10 ;
      private short[] P001U10_A40010GXC11 ;
      private bool[] P001U10_n40010GXC11 ;
      private short[] P001U10_A40011GXC12 ;
      private bool[] P001U10_n40011GXC12 ;
      private short[] P001U10_A40012GXC13 ;
      private bool[] P001U10_n40012GXC13 ;
      private short[] P001U10_A40013GXC14 ;
      private bool[] P001U10_n40013GXC14 ;
      private short[] P001U10_A40014GXC15 ;
      private bool[] P001U10_n40014GXC15 ;
      private short[] P001U10_A40015GXC16 ;
      private bool[] P001U10_n40015GXC16 ;
      private SdtSDTEmployeeWeekReport Gxm1sdtemployeeweekreport ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> aP4_Gxm2rootcol ;
   }

   public class dpemployeeweekreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001U10( IGxContext context ,
                                              long A157CompanyLocationId ,
                                              GxSimpleCollection<long> AV14CompanyLocationId ,
                                              long A106EmployeeId ,
                                              GxSimpleCollection<long> AV19EmployeeIds ,
                                              int AV14CompanyLocationId_Count ,
                                              int AV19EmployeeIds_Count ,
                                              bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeIsActive, T1.EmployeeId, T2.CompanyLocationId, T1.EmployeeFTEHours, T1.EmployeeName, COALESCE( T3.GXC1, 0) AS GXC1, COALESCE( T3.GXC2, 0) AS GXC2, COALESCE( T4.GXC1, 0) AS GXC3, COALESCE( T4.GXC2, 0) AS GXC4, COALESCE( T5.GXC1, 0) AS GXC5, COALESCE( T5.GXC2, 0) AS GXC6, COALESCE( T6.GXC1, 0) AS GXC7, COALESCE( T6.GXC2, 0) AS GXC8, COALESCE( T7.GXC1, 0) AS GXC9, COALESCE( T7.GXC2, 0) AS GXC10, COALESCE( T8.GXC1, 0) AS GXC11, COALESCE( T8.GXC2, 0) AS GXC12, COALESCE( T9.GXC1, 0) AS GXC13, COALESCE( T9.GXC2, 0) AS GXC14, COALESCE( T10.GXC1, 0) AS GXC15, COALESCE( T10.GXC2, 0) AS GXC16 FROM (((((((((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate = :AV13FromDate) GROUP BY EmployeeId ) T3 ON T3.EmployeeId = T1.EmployeeId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate = (CAST(:AV13FromDate AS date) + CAST (( 1) || ' DAY' AS INTERVAL))) GROUP BY EmployeeId ) T4 ON T4.EmployeeId = T1.EmployeeId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate = (CAST(:AV13FromDate AS date) + CAST (( 2) || ' DAY' AS INTERVAL))) GROUP BY EmployeeId ) T5 ON T5.EmployeeId = T1.EmployeeId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate = (CAST(:AV13FromDate AS date) + CAST (( 3) || ' DAY' AS INTERVAL))) GROUP BY EmployeeId";
         scmdbuf += " ) T6 ON T6.EmployeeId = T1.EmployeeId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate = (CAST(:AV13FromDate AS date) + CAST (( 4) || ' DAY' AS INTERVAL))) GROUP BY EmployeeId ) T7 ON T7.EmployeeId = T1.EmployeeId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate = (CAST(:AV13FromDate AS date) + CAST (( 5) || ' DAY' AS INTERVAL))) GROUP BY EmployeeId ) T8 ON T8.EmployeeId = T1.EmployeeId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate = (CAST(:AV13FromDate AS date) + CAST (( 6) || ' DAY' AS INTERVAL))) GROUP BY EmployeeId ) T9 ON T9.EmployeeId = T1.EmployeeId) LEFT JOIN LATERAL (SELECT SUM(WorkHourLogHour) AS GXC1, EmployeeId, SUM(WorkHourLogMinute) AS GXC2 FROM WorkHourLog WHERE (T1.EmployeeId = EmployeeId) AND (WorkHourLogDate >= :AV13FromDate and WorkHourLogDate <= (CAST(:AV13FromDate AS date) + CAST (( 6) || ' DAY' AS INTERVAL))) GROUP BY EmployeeId ) T10 ON T10.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         if ( AV14CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV14CompanyLocationId, "T2.CompanyLocationId IN (", ")")+")");
         }
         if ( AV19EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
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
                     return conditional_P001U10(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (bool)dynConstraints[6] );
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
          Object[] prmP001U10;
          prmP001U10 = new Object[] {
          new ParDef("AV13FromDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0) ,
          new ParDef("AV13FromDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001U10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001U10,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[10])[0] = rslt.getShort(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((short[]) buf[12])[0] = rslt.getShort(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((short[]) buf[14])[0] = rslt.getShort(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((short[]) buf[16])[0] = rslt.getShort(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((short[]) buf[18])[0] = rslt.getShort(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((short[]) buf[20])[0] = rslt.getShort(14);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((short[]) buf[22])[0] = rslt.getShort(15);
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((short[]) buf[24])[0] = rslt.getShort(16);
                ((bool[]) buf[25])[0] = rslt.wasNull(16);
                ((short[]) buf[26])[0] = rslt.getShort(17);
                ((bool[]) buf[27])[0] = rslt.wasNull(17);
                ((short[]) buf[28])[0] = rslt.getShort(18);
                ((bool[]) buf[29])[0] = rslt.wasNull(18);
                ((short[]) buf[30])[0] = rslt.getShort(19);
                ((bool[]) buf[31])[0] = rslt.wasNull(19);
                ((short[]) buf[32])[0] = rslt.getShort(20);
                ((bool[]) buf[33])[0] = rslt.wasNull(20);
                ((short[]) buf[34])[0] = rslt.getShort(21);
                ((bool[]) buf[35])[0] = rslt.wasNull(21);
                ((short[]) buf[36])[0] = rslt.getShort(22);
                ((bool[]) buf[37])[0] = rslt.wasNull(22);
                return;
       }
    }

 }

}
