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
   public class aleaverequest_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new aleaverequest_dataprovider().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         GXBCCollection<SdtLeaveRequest> aP0_Gxm1rootcol = new GXBCCollection<SdtLeaveRequest>()  ;
         execute(out aP0_Gxm1rootcol);
         return GX.GXRuntime.ExitCode ;
      }

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

      public aleaverequest_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aleaverequest_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtLeaveRequest> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<SdtLeaveRequest>( context, "LeaveRequest", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBCCollection<SdtLeaveRequest> executeUdp( )
      {
         execute(out aP0_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtLeaveRequest> aP0_Gxm1rootcol )
      {
         aleaverequest_dataprovider objaleaverequest_dataprovider;
         objaleaverequest_dataprovider = new aleaverequest_dataprovider();
         objaleaverequest_dataprovider.Gxm1rootcol = new GXBCCollection<SdtLeaveRequest>( context, "LeaveRequest", "YTT_version4") ;
         objaleaverequest_dataprovider.context.SetSubmitInitialConfig(context);
         objaleaverequest_dataprovider.initialize();
         Submit( executePrivateCatch,objaleaverequest_dataprovider);
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aleaverequest_dataprovider)stateInfo).executePrivate();
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

      private GXBCCollection<SdtLeaveRequest> aP0_Gxm1rootcol ;
      private GXBCCollection<SdtLeaveRequest> Gxm1rootcol ;
   }

}
