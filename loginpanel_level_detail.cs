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
   public class loginpanel_level_detail : GXDataGridProcedure
   {
      public loginpanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public loginpanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtLoginPanel_Level_DetailSdt aP1_GXM1LoginPanel_Level_DetailSdt )
      {
         this.AV18gxid = aP0_gxid;
         this.AV21GXM1LoginPanel_Level_DetailSdt = new SdtLoginPanel_Level_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP1_GXM1LoginPanel_Level_DetailSdt=this.AV21GXM1LoginPanel_Level_DetailSdt;
      }

      public SdtLoginPanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1LoginPanel_Level_DetailSdt);
         return AV21GXM1LoginPanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtLoginPanel_Level_DetailSdt aP1_GXM1LoginPanel_Level_DetailSdt )
      {
         loginpanel_level_detail objloginpanel_level_detail;
         objloginpanel_level_detail = new loginpanel_level_detail();
         objloginpanel_level_detail.AV18gxid = aP0_gxid;
         objloginpanel_level_detail.AV21GXM1LoginPanel_Level_DetailSdt = new SdtLoginPanel_Level_DetailSdt(context) ;
         objloginpanel_level_detail.context.SetSubmitInitialConfig(context);
         objloginpanel_level_detail.initialize();
         Submit( executePrivateCatch,objloginpanel_level_detail);
         aP1_GXM1LoginPanel_Level_DetailSdt=this.AV21GXM1LoginPanel_Level_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loginpanel_level_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV18gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            Gxwebsession.Set(Gxids, "true");
         }
         AV21GXM1LoginPanel_Level_DetailSdt.gxTpr_User = AV10User;
         AV21GXM1LoginPanel_Level_DetailSdt.gxTpr_Password = AV11Password;
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
         AV21GXM1LoginPanel_Level_DetailSdt = new SdtLoginPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV10User = "";
         AV11Password = "";
         /* GeneXus formulas. */
      }

      private int AV18gxid ;
      private string Gxids ;
      private string AV10User ;
      private string AV11Password ;
      private SdtLoginPanel_Level_DetailSdt aP1_GXM1LoginPanel_Level_DetailSdt ;
      private IGxSession Gxwebsession ;
      private SdtLoginPanel_Level_DetailSdt AV21GXM1LoginPanel_Level_DetailSdt ;
   }

}
