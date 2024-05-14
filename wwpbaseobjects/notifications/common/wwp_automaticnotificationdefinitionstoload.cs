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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_automaticnotificationdefinitionstoload : GXProcedure
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

      public wwp_automaticnotificationdefinitionstoload( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_automaticnotificationdefinitionstoload( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition>( context, "WWP_NotificationDefinition", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> executeUdp( )
      {
         execute(out aP0_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> aP0_Gxm1rootcol )
      {
         wwp_automaticnotificationdefinitionstoload objwwp_automaticnotificationdefinitionstoload;
         objwwp_automaticnotificationdefinitionstoload = new wwp_automaticnotificationdefinitionstoload();
         objwwp_automaticnotificationdefinitionstoload.Gxm1rootcol = new GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition>( context, "WWP_NotificationDefinition", "YTT_version4") ;
         objwwp_automaticnotificationdefinitionstoload.context.SetSubmitInitialConfig(context);
         objwwp_automaticnotificationdefinitionstoload.initialize();
         Submit( executePrivateCatch,objwwp_automaticnotificationdefinitionstoload);
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_automaticnotificationdefinitionstoload)stateInfo).executePrivate();
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
         /* GeneXus formulas. */
      }

      private GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> aP0_Gxm1rootcol ;
      private GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> Gxm1rootcol ;
   }

}
