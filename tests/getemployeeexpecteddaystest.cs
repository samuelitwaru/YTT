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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.tests {
   public class getemployeeexpecteddaystest : GXProcedure
   {
      public getemployeeexpecteddaystest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeeexpecteddaystest( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         getemployeeexpecteddaystest objgetemployeeexpecteddaystest;
         objgetemployeeexpecteddaystest = new getemployeeexpecteddaystest();
         objgetemployeeexpecteddaystest.context.SetSubmitInitialConfig(context);
         objgetemployeeexpecteddaystest.initialize();
         Submit( executePrivateCatch,objgetemployeeexpecteddaystest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getemployeeexpecteddaystest)stateInfo).executePrivate();
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
         AV10GXV2 = 1;
         GXt_objcol_SdtGetEmployeeExpectedDaysTestSDT1 = AV9GXV1;
         new GeneXus.Programs.tests.getemployeeexpecteddaystestdata(context ).execute( out  GXt_objcol_SdtGetEmployeeExpectedDaysTestSDT1) ;
         AV9GXV1 = GXt_objcol_SdtGetEmployeeExpectedDaysTestSDT1;
         while ( AV10GXV2 <= AV9GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT)AV9GXV1.Item(AV10GXV2));
            GXt_int2 = 0;
            GXt_int3 = AV8TestCaseData.gxTpr_Employeeid;
            GXt_date4 = AV8TestCaseData.gxTpr_Fromdate;
            GXt_date5 = AV8TestCaseData.gxTpr_Todate;
            GXt_int6 = AV8TestCaseData.gxTpr_Holidaycount;
            new getemployeeexpecteddays(context ).execute( ref  GXt_int3, ref  GXt_date4, ref  GXt_date5, out  GXt_int6) ;
            AV8TestCaseData.gxTpr_Employeeid = GXt_int3;
            AV8TestCaseData.gxTpr_Fromdate = GXt_date4;
            AV8TestCaseData.gxTpr_Todate = GXt_date5;
            AV8TestCaseData.gxTpr_Holidaycount = GXt_int6;
            AV8TestCaseData.gxTpr_Expectedworkdays = GXt_int2;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedemployeeid),  (decimal)(AV8TestCaseData.gxTpr_Employeeid),  StringUtil.Format( "%1.ExpectedEmployeeId: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgemployeeid, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  context.localUtil.Format( AV8TestCaseData.gxTpr_Expectedfromdate, "99/99/9999"),  context.localUtil.Format( AV8TestCaseData.gxTpr_Fromdate, "99/99/9999"),  StringUtil.Format( "%1.ExpectedFromDate: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgfromdate, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  context.localUtil.Format( AV8TestCaseData.gxTpr_Expectedtodate, "99/99/9999"),  context.localUtil.Format( AV8TestCaseData.gxTpr_Todate, "99/99/9999"),  StringUtil.Format( "%1.ExpectedToDate: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgtodate, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedholidaycount),  (decimal)(AV8TestCaseData.gxTpr_Holidaycount),  StringUtil.Format( "%1.ExpectedHolidayCount: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgholidaycount, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedleavedays),  (decimal)(AV8TestCaseData.gxTpr_Leavedays),  StringUtil.Format( "%1.ExpectedLeaveDays: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgleavedays, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedexpectedworkdays),  (decimal)(AV8TestCaseData.gxTpr_Expectedworkdays),  StringUtil.Format( "%1.ExpectedExpectedWorkDays: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgexpectedworkdays, "", "", "", "", "", "", "")) ;
            AV10GXV2 = (int)(AV10GXV2+1);
         }
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
         AV9GXV1 = new GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT>( context, "GetEmployeeExpectedDaysTestSDT", "YTT_version4");
         GXt_objcol_SdtGetEmployeeExpectedDaysTestSDT1 = new GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT>( context, "GetEmployeeExpectedDaysTestSDT", "YTT_version4");
         AV8TestCaseData = new GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT(context);
         GXt_date4 = DateTime.MinValue;
         GXt_date5 = DateTime.MinValue;
         /* GeneXus formulas. */
      }

      private int AV10GXV2 ;
      private long GXt_int2 ;
      private long GXt_int3 ;
      private long GXt_int6 ;
      private DateTime GXt_date4 ;
      private DateTime GXt_date5 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT> AV9GXV1 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT> GXt_objcol_SdtGetEmployeeExpectedDaysTestSDT1 ;
      private GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT AV8TestCaseData ;
   }

}
