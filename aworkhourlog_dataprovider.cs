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
   public class aworkhourlog_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new aworkhourlog_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<SdtWorkHourLog> aP0_Gxm1rootcol = new GXBCCollection<SdtWorkHourLog>()  ;
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

      public aworkhourlog_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aworkhourlog_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtWorkHourLog> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<SdtWorkHourLog>( context, "WorkHourLog", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBCCollection<SdtWorkHourLog> executeUdp( )
      {
         execute(out aP0_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtWorkHourLog> aP0_Gxm1rootcol )
      {
         aworkhourlog_dataprovider objaworkhourlog_dataprovider;
         objaworkhourlog_dataprovider = new aworkhourlog_dataprovider();
         objaworkhourlog_dataprovider.Gxm1rootcol = new GXBCCollection<SdtWorkHourLog>( context, "WorkHourLog", "YTT_version4") ;
         objaworkhourlog_dataprovider.context.SetSubmitInitialConfig(context);
         objaworkhourlog_dataprovider.initialize();
         Submit( executePrivateCatch,objaworkhourlog_dataprovider);
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aworkhourlog_dataprovider)stateInfo).executePrivate();
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

      private GXBCCollection<SdtWorkHourLog> aP0_Gxm1rootcol ;
      private GXBCCollection<SdtWorkHourLog> Gxm1rootcol ;
   }

}
