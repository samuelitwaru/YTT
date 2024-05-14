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
   public class getemployeeexpecteddaystestdata : GXProcedure
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

      public getemployeeexpecteddaystestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeeexpecteddaystestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT>( context, "GetEmployeeExpectedDaysTestSDT", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT> aP0_Gxm2rootcol )
      {
         getemployeeexpecteddaystestdata objgetemployeeexpecteddaystestdata;
         objgetemployeeexpecteddaystestdata = new getemployeeexpecteddaystestdata();
         objgetemployeeexpecteddaystestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT>( context, "GetEmployeeExpectedDaysTestSDT", "YTT_version4") ;
         objgetemployeeexpecteddaystestdata.context.SetSubmitInitialConfig(context);
         objgetemployeeexpecteddaystestdata.initialize();
         Submit( executePrivateCatch,objgetemployeeexpecteddaystestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getemployeeexpecteddaystestdata)stateInfo).executePrivate();
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
         Gxm1getemployeeexpecteddaystestsdt = new GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT(context);
         Gxm2rootcol.Add(Gxm1getemployeeexpecteddaystestsdt, 0);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Testcaseid = "1";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Employeeid = 338;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedemployeeid = 338;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgemployeeid = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Fromdate = context.localUtil.YMDToD( 2024, 1, 8);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedfromdate = context.localUtil.YMDToD( 2024, 1, 8);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgfromdate = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Todate = context.localUtil.YMDToD( 2024, 4, 27);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedtodate = context.localUtil.YMDToD( 2024, 4, 27);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgtodate = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedholidaycount = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgholidaycount = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedleavedays = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgleavedays = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedexpectedworkdays = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgexpectedworkdays = "";
         Gxm1getemployeeexpecteddaystestsdt = new GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT(context);
         Gxm2rootcol.Add(Gxm1getemployeeexpecteddaystestsdt, 0);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Testcaseid = "2";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Employeeid = 340;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedemployeeid = 340;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgemployeeid = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Fromdate = context.localUtil.YMDToD( 2024, 1, 8);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedfromdate = context.localUtil.YMDToD( 2024, 1, 8);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgfromdate = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Todate = context.localUtil.YMDToD( 2024, 4, 27);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedtodate = context.localUtil.YMDToD( 2024, 4, 27);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgtodate = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedholidaycount = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgholidaycount = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedleavedays = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgleavedays = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedexpectedworkdays = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgexpectedworkdays = "";
         Gxm1getemployeeexpecteddaystestsdt = new GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT(context);
         Gxm2rootcol.Add(Gxm1getemployeeexpecteddaystestsdt, 0);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Testcaseid = "3";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Employeeid = 368;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedemployeeid = 368;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgemployeeid = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Fromdate = context.localUtil.YMDToD( 2024, 1, 8);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedfromdate = context.localUtil.YMDToD( 2024, 1, 8);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgfromdate = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Todate = context.localUtil.YMDToD( 2024, 4, 27);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedtodate = context.localUtil.YMDToD( 2024, 4, 27);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgtodate = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedholidaycount = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgholidaycount = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedleavedays = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgleavedays = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedexpectedworkdays = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgexpectedworkdays = "";
         Gxm1getemployeeexpecteddaystestsdt = new GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT(context);
         Gxm2rootcol.Add(Gxm1getemployeeexpecteddaystestsdt, 0);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Testcaseid = "4";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Employeeid = 385;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedemployeeid = 385;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgemployeeid = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Fromdate = context.localUtil.YMDToD( 2024, 1, 8);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedfromdate = context.localUtil.YMDToD( 2024, 1, 8);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgfromdate = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Todate = context.localUtil.YMDToD( 2024, 4, 27);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedtodate = context.localUtil.YMDToD( 2024, 4, 27);
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgtodate = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedholidaycount = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgholidaycount = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedleavedays = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgleavedays = "";
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Expectedexpectedworkdays = 0;
         Gxm1getemployeeexpecteddaystestsdt.gxTpr_Msgexpectedworkdays = "";
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
         Gxm1getemployeeexpecteddaystestsdt = new GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.tests.SdtGetEmployeeExpectedDaysTestSDT Gxm1getemployeeexpecteddaystestsdt ;
   }

}
