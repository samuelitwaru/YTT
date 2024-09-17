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
namespace GeneXus.Programs {
   public class paginate : GXProcedure
   {
      public paginate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public paginate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtSDTPage> aP0_pages_to_show ,
                           out short aP1_total_pages ,
                           ref SdtSDTPage aP2_current_page )
      {
         this.AV11pages_to_show = new GXBaseCollection<SdtSDTPage>( context, "SDTPage", "YTT_version4") ;
         this.AV10total_pages = 0 ;
         this.AV12current_page = aP2_current_page;
         initialize();
         ExecuteImpl();
         aP0_pages_to_show=this.AV11pages_to_show;
         aP1_total_pages=this.AV10total_pages;
         aP2_current_page=this.AV12current_page;
      }

      public SdtSDTPage executeUdp( out GXBaseCollection<SdtSDTPage> aP0_pages_to_show ,
                                    out short aP1_total_pages )
      {
         execute(out aP0_pages_to_show, out aP1_total_pages, ref aP2_current_page);
         return AV12current_page ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTPage> aP0_pages_to_show ,
                                 out short aP1_total_pages ,
                                 ref SdtSDTPage aP2_current_page )
      {
         this.AV11pages_to_show = new GXBaseCollection<SdtSDTPage>( context, "SDTPage", "YTT_version4") ;
         this.AV10total_pages = 0 ;
         this.AV12current_page = aP2_current_page;
         SubmitImpl();
         aP0_pages_to_show=this.AV11pages_to_show;
         aP1_total_pages=this.AV10total_pages;
         aP2_current_page=this.AV12current_page;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8rows = 20;
         AV9per_page = 5;
         AV12current_page = new SdtSDTPage(context);
         AV12current_page.gxTpr_Page = 1;
         AV12current_page.gxTpr_Iscurrent = true;
         AV10total_pages = (short)(AV8rows/ (decimal)(AV9per_page));
         AV14segments = 2;
         if ( ( AV12current_page.gxTpr_Page > AV10total_pages ) || ( AV12current_page.gxTpr_Page < 1 ) )
         {
            AV12current_page.gxTpr_Page = 1;
         }
         if ( AV14segments > AV10total_pages )
         {
            AV14segments = AV10total_pages;
         }
         AV13iteration = 1;
         AV11pages_to_show.Add(AV12current_page, 0);
         while ( ( AV11pages_to_show.Count < AV14segments ) && ( AV10total_pages >= AV14segments ) )
         {
            if ( AV12current_page.gxTpr_Page - AV13iteration > 0 )
            {
               AV15page1 = new SdtSDTPage(context);
               AV15page1.gxTpr_Page = (short)(AV12current_page.gxTpr_Page-AV13iteration);
               AV11pages_to_show.Add(AV15page1, 0);
            }
            if ( AV12current_page.gxTpr_Page + AV13iteration <= AV10total_pages )
            {
               AV15page1 = new SdtSDTPage(context);
               AV15page1.gxTpr_Page = (short)(AV12current_page.gxTpr_Page+AV13iteration);
               AV11pages_to_show.Add(AV15page1, 0);
            }
            AV13iteration = (short)(AV13iteration+1);
         }
         AV11pages_to_show.Sort("");
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
         AV11pages_to_show = new GXBaseCollection<SdtSDTPage>( context, "SDTPage", "YTT_version4");
         AV15page1 = new SdtSDTPage(context);
         /* GeneXus formulas. */
      }

      private short AV10total_pages ;
      private short AV8rows ;
      private short AV9per_page ;
      private short AV14segments ;
      private short AV13iteration ;
      private GXBaseCollection<SdtSDTPage> AV11pages_to_show ;
      private SdtSDTPage AV12current_page ;
      private SdtSDTPage aP2_current_page ;
      private SdtSDTPage AV15page1 ;
      private GXBaseCollection<SdtSDTPage> aP0_pages_to_show ;
      private short aP1_total_pages ;
   }

}
