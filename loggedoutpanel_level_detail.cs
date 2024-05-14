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
   public class loggedoutpanel_level_detail : GXDataGridProcedure
   {
      public loggedoutpanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public loggedoutpanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtLoggedOutPanel_Level_DetailSdt aP1_GXM1LoggedOutPanel_Level_DetailSdt )
      {
         this.AV8gxid = aP0_gxid;
         this.AV11GXM1LoggedOutPanel_Level_DetailSdt = new SdtLoggedOutPanel_Level_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP1_GXM1LoggedOutPanel_Level_DetailSdt=this.AV11GXM1LoggedOutPanel_Level_DetailSdt;
      }

      public SdtLoggedOutPanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1LoggedOutPanel_Level_DetailSdt);
         return AV11GXM1LoggedOutPanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtLoggedOutPanel_Level_DetailSdt aP1_GXM1LoggedOutPanel_Level_DetailSdt )
      {
         loggedoutpanel_level_detail objloggedoutpanel_level_detail;
         objloggedoutpanel_level_detail = new loggedoutpanel_level_detail();
         objloggedoutpanel_level_detail.AV8gxid = aP0_gxid;
         objloggedoutpanel_level_detail.AV11GXM1LoggedOutPanel_Level_DetailSdt = new SdtLoggedOutPanel_Level_DetailSdt(context) ;
         objloggedoutpanel_level_detail.context.SetSubmitInitialConfig(context);
         objloggedoutpanel_level_detail.initialize();
         Submit( executePrivateCatch,objloggedoutpanel_level_detail);
         aP1_GXM1LoggedOutPanel_Level_DetailSdt=this.AV11GXM1LoggedOutPanel_Level_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loggedoutpanel_level_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV8gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            Gxwebsession.Set(Gxids, "true");
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
         AV11GXM1LoggedOutPanel_Level_DetailSdt = new SdtLoggedOutPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         /* GeneXus formulas. */
      }

      private int AV8gxid ;
      private string Gxids ;
      private SdtLoggedOutPanel_Level_DetailSdt aP1_GXM1LoggedOutPanel_Level_DetailSdt ;
      private IGxSession Gxwebsession ;
      private SdtLoggedOutPanel_Level_DetailSdt AV11GXM1LoggedOutPanel_Level_DetailSdt ;
   }

}
