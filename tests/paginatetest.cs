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
   public class paginatetest : GXProcedure
   {
      public paginatetest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public paginatetest( IGxContext context )
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
         paginatetest objpaginatetest;
         objpaginatetest = new paginatetest();
         objpaginatetest.context.SetSubmitInitialConfig(context);
         objpaginatetest.initialize();
         Submit( executePrivateCatch,objpaginatetest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((paginatetest)stateInfo).executePrivate();
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
         GXt_objcol_SdtPaginateTestSDT1 = AV9GXV1;
         new GeneXus.Programs.tests.paginatetestdata(context ).execute( out  GXt_objcol_SdtPaginateTestSDT1) ;
         AV9GXV1 = GXt_objcol_SdtPaginateTestSDT1;
         while ( AV10GXV2 <= AV9GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.tests.SdtPaginateTestSDT)AV9GXV1.Item(AV10GXV2));
            GXt_objcol_SdtSDTPage2 = AV8TestCaseData.gxTpr_Pages_to_show;
            GXt_int3 = AV8TestCaseData.gxTpr_Total_pages;
            GXt_SdtSDTPage4 = AV8TestCaseData.gxTpr_Current_page;
            new paginate(context ).execute( out  GXt_objcol_SdtSDTPage2, out  GXt_int3, ref  GXt_SdtSDTPage4) ;
            AV8TestCaseData.gxTpr_Pages_to_show = GXt_objcol_SdtSDTPage2;
            AV8TestCaseData.gxTpr_Total_pages = GXt_int3;
            AV8TestCaseData.gxTpr_Current_page = GXt_SdtSDTPage4;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedpages_to_show.ToJSonString(false),  AV8TestCaseData.gxTpr_Pages_to_show.ToJSonString(false),  StringUtil.Format( "%1.Expectedpages_to_show: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgpages_to_show, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertnumericequals(context ).execute(  (decimal)(AV8TestCaseData.gxTpr_Expectedtotal_pages),  (decimal)(AV8TestCaseData.gxTpr_Total_pages),  StringUtil.Format( "%1.Expectedtotal_pages: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgtotal_pages, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedcurrent_page.ToJSonString(false, true),  AV8TestCaseData.gxTpr_Current_page.ToJSonString(false, true),  StringUtil.Format( "%1.Expectedcurrent_page: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgcurrent_page, "", "", "", "", "", "", "")) ;
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
         AV9GXV1 = new GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT>( context, "PaginateTestSDT", "YTT_version4");
         GXt_objcol_SdtPaginateTestSDT1 = new GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT>( context, "PaginateTestSDT", "YTT_version4");
         AV8TestCaseData = new GeneXus.Programs.tests.SdtPaginateTestSDT(context);
         GXt_objcol_SdtSDTPage2 = new GXBaseCollection<SdtSDTPage>( context, "SDTPage", "YTT_version4");
         GXt_SdtSDTPage4 = new SdtSDTPage(context);
         /* GeneXus formulas. */
      }

      private short GXt_int3 ;
      private int AV10GXV2 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT> AV9GXV1 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtPaginateTestSDT> GXt_objcol_SdtPaginateTestSDT1 ;
      private GXBaseCollection<SdtSDTPage> GXt_objcol_SdtSDTPage2 ;
      private GeneXus.Programs.tests.SdtPaginateTestSDT AV8TestCaseData ;
      private SdtSDTPage GXt_SdtSDTPage4 ;
   }

}
