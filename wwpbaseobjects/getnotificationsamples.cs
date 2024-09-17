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
namespace GeneXus.Programs.wwpbaseobjects {
   public class getnotificationsamples : GXProcedure
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

      public getnotificationsamples( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getnotificationsamples( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem>( context, "WWP_SDTNotificationsDataSampleItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem>( context, "WWP_SDTNotificationsDataSampleItem", "YTT_version4") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1wwp_sdtnotificationsdatasample = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem(context);
         Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdatasample, 0);
         AV5DateTime = DateTimeUtil.Now( context);
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationiconclass = "fas fa-layer-group NotificationFontIconSuccess";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationtitle = "Group Records & Totalizers";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdescription = "Group the records of a grid within a certain column and show totalizers of each group";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdatetime = AV5DateTime;
         Gxm1wwp_sdtnotificationsdatasample = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem(context);
         Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdatasample, 0);
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationiconclass = "fas fa-palette NotificationFontIconWarning";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationtitle = "Dark Designs";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdescription = "Option to select dark designs in the Design System Wizard";
         AV5DateTime = DateTimeUtil.TAdd( AV5DateTime, 3600*(-2));
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdatetime = AV5DateTime;
         Gxm1wwp_sdtnotificationsdatasample = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem(context);
         Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdatasample, 0);
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationiconclass = "fas fa-cog NotificationFontIconDanger";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationtitle = "100% Customizable";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdescription = "Customize and create your own design system";
         AV5DateTime = DateTimeUtil.TAdd( AV5DateTime, 3600*(-5));
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdatetime = AV5DateTime;
         Gxm1wwp_sdtnotificationsdatasample = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem(context);
         Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdatasample, 0);
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationiconclass = "far fa-star NotificationFontIconInfo";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationtitle = "Bookmarks";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdescription = "Bookmark pages and have their shortcuts in the Master Page";
         AV5DateTime = DateTimeUtil.TAdd( AV5DateTime, 3600*(-8));
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdatetime = AV5DateTime;
         Gxm1wwp_sdtnotificationsdatasample = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem(context);
         Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdatasample, 0);
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationiconclass = "fas fa-plus NotificationFontIconSuccess";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationtitle = "Add new";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdescription = "Add new record of a DVelop Combo while editing other record";
         AV5DateTime = DateTimeUtil.TAdd( AV5DateTime, 3600*(-36));
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdatetime = AV5DateTime;
         Gxm1wwp_sdtnotificationsdatasample = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem(context);
         Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdatasample, 0);
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationiconclass = "fas fa-caret-down NotificationFontIconInfoLight";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationtitle = "Expand record";
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdescription = "Expand record of a grid in order to visualize more information";
         AV5DateTime = DateTimeUtil.TAdd( AV5DateTime, 3600*(-65));
         Gxm1wwp_sdtnotificationsdatasample.gxTpr_Notificationdatetime = AV5DateTime;
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
         Gxm1wwp_sdtnotificationsdatasample = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem(context);
         AV5DateTime = (DateTime)(DateTime.MinValue);
         /* GeneXus formulas. */
      }

      private DateTime AV5DateTime ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem Gxm1wwp_sdtnotificationsdatasample ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> aP0_Gxm2rootcol ;
   }

}
