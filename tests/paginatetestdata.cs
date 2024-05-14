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
   public class paginatetestdata : GXProcedure
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

      public paginatetestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public paginatetestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT>( context, "PaginateTestSDT", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT> aP0_Gxm2rootcol )
      {
         paginatetestdata objpaginatetestdata;
         objpaginatetestdata = new paginatetestdata();
         objpaginatetestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT>( context, "PaginateTestSDT", "YTT_version4") ;
         objpaginatetestdata.context.SetSubmitInitialConfig(context);
         objpaginatetestdata.initialize();
         Submit( executePrivateCatch,objpaginatetestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((paginatetestdata)stateInfo).executePrivate();
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
         Gxm1paginatetestsdt = new GeneXus.Programs.tests.SdtPaginateTestSDT(context);
         Gxm2rootcol.Add(Gxm1paginatetestsdt, 0);
         Gxm1paginatetestsdt.gxTpr_Testcaseid = "1";
         Gxm3paginatetestsdt_expectedpages_to_show = new SdtSDTPage(context);
         Gxm1paginatetestsdt.gxTpr_Expectedpages_to_show.Add(Gxm3paginatetestsdt_expectedpages_to_show, 0);
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Page = 0;
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgpages_to_show = "";
         Gxm1paginatetestsdt.gxTpr_Expectedtotal_pages = 0;
         Gxm1paginatetestsdt.gxTpr_Msgtotal_pages = "";
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgcurrent_page = "";
         Gxm1paginatetestsdt = new GeneXus.Programs.tests.SdtPaginateTestSDT(context);
         Gxm2rootcol.Add(Gxm1paginatetestsdt, 0);
         Gxm1paginatetestsdt.gxTpr_Testcaseid = "2";
         Gxm3paginatetestsdt_expectedpages_to_show = new SdtSDTPage(context);
         Gxm1paginatetestsdt.gxTpr_Expectedpages_to_show.Add(Gxm3paginatetestsdt_expectedpages_to_show, 0);
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Page = 0;
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgpages_to_show = "";
         Gxm1paginatetestsdt.gxTpr_Expectedtotal_pages = 0;
         Gxm1paginatetestsdt.gxTpr_Msgtotal_pages = "";
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgcurrent_page = "";
         Gxm1paginatetestsdt = new GeneXus.Programs.tests.SdtPaginateTestSDT(context);
         Gxm2rootcol.Add(Gxm1paginatetestsdt, 0);
         Gxm1paginatetestsdt.gxTpr_Testcaseid = "3";
         Gxm3paginatetestsdt_expectedpages_to_show = new SdtSDTPage(context);
         Gxm1paginatetestsdt.gxTpr_Expectedpages_to_show.Add(Gxm3paginatetestsdt_expectedpages_to_show, 0);
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Page = 0;
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgpages_to_show = "";
         Gxm1paginatetestsdt.gxTpr_Expectedtotal_pages = 0;
         Gxm1paginatetestsdt.gxTpr_Msgtotal_pages = "";
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgcurrent_page = "";
         Gxm1paginatetestsdt = new GeneXus.Programs.tests.SdtPaginateTestSDT(context);
         Gxm2rootcol.Add(Gxm1paginatetestsdt, 0);
         Gxm1paginatetestsdt.gxTpr_Testcaseid = "4";
         Gxm3paginatetestsdt_expectedpages_to_show = new SdtSDTPage(context);
         Gxm1paginatetestsdt.gxTpr_Expectedpages_to_show.Add(Gxm3paginatetestsdt_expectedpages_to_show, 0);
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Page = 0;
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgpages_to_show = "";
         Gxm1paginatetestsdt.gxTpr_Expectedtotal_pages = 0;
         Gxm1paginatetestsdt.gxTpr_Msgtotal_pages = "";
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgcurrent_page = "";
         Gxm1paginatetestsdt = new GeneXus.Programs.tests.SdtPaginateTestSDT(context);
         Gxm2rootcol.Add(Gxm1paginatetestsdt, 0);
         Gxm1paginatetestsdt.gxTpr_Testcaseid = "5";
         Gxm3paginatetestsdt_expectedpages_to_show = new SdtSDTPage(context);
         Gxm1paginatetestsdt.gxTpr_Expectedpages_to_show.Add(Gxm3paginatetestsdt_expectedpages_to_show, 0);
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Page = 0;
         Gxm3paginatetestsdt_expectedpages_to_show.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgpages_to_show = "";
         Gxm1paginatetestsdt.gxTpr_Expectedtotal_pages = 0;
         Gxm1paginatetestsdt.gxTpr_Msgtotal_pages = "";
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Current_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Page = 0;
         Gxm1paginatetestsdt.gxTpr_Expectedcurrent_page.gxTpr_Iscurrent = false;
         Gxm1paginatetestsdt.gxTpr_Msgcurrent_page = "";
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
         Gxm1paginatetestsdt = new GeneXus.Programs.tests.SdtPaginateTestSDT(context);
         Gxm3paginatetestsdt_expectedpages_to_show = new SdtSDTPage(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.tests.SdtPaginateTestSDT Gxm1paginatetestsdt ;
      private SdtSDTPage Gxm3paginatetestsdt_expectedpages_to_show ;
   }

}
