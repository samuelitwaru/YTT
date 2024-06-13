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
   public class jsganttprovider : GXProcedure
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

      public jsganttprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public jsganttprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtjsGanttTask> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtjsGanttTask>( context, "jsGanttTask", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtjsGanttTask> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtjsGanttTask> aP0_Gxm2rootcol )
      {
         jsganttprovider objjsganttprovider;
         objjsganttprovider = new jsganttprovider();
         objjsganttprovider.Gxm2rootcol = new GXBaseCollection<SdtjsGanttTask>( context, "jsGanttTask", "YTT_version4") ;
         objjsganttprovider.context.SetSubmitInitialConfig(context);
         objjsganttprovider.initialize();
         Submit( executePrivateCatch,objjsganttprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((jsganttprovider)stateInfo).executePrivate();
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
         Gxm1jsgantttask = new SdtjsGanttTask(context);
         Gxm2rootcol.Add(Gxm1jsgantttask, 0);
         Gxm1jsgantttask.gxTpr_Pid = 1;
         Gxm1jsgantttask.gxTpr_Pname = "Definir a API do Gráfico";
         Gxm1jsgantttask.gxTpr_Pstart = "";
         Gxm1jsgantttask.gxTpr_Pend = "";
         Gxm1jsgantttask.gxTpr_Pcolor = "ff0000";
         Gxm1jsgantttask.gxTpr_Plink = "http://www.gxtechnical.com/cp";
         Gxm1jsgantttask.gxTpr_Pmile = 0;
         Gxm1jsgantttask.gxTpr_Pres = "Fabrício";
         Gxm1jsgantttask.gxTpr_Pcomp = 0;
         Gxm1jsgantttask.gxTpr_Pgroup = 1;
         Gxm1jsgantttask.gxTpr_Pparent = 0;
         Gxm1jsgantttask.gxTpr_Popen = 0;
         Gxm1jsgantttask.gxTpr_Pdepend = "";
         Gxm1jsgantttask.gxTpr_Pcaption = "Task for cp2";
         Gxm1jsgantttask = new SdtjsGanttTask(context);
         Gxm2rootcol.Add(Gxm1jsgantttask, 0);
         Gxm1jsgantttask.gxTpr_Pid = 11;
         Gxm1jsgantttask.gxTpr_Pname = "Construir Objeto";
         Gxm1jsgantttask.gxTpr_Pstart = "03/03/2024";
         Gxm1jsgantttask.gxTpr_Pend = "18/04/2024";
         Gxm1jsgantttask.gxTpr_Pcolor = "00ffff";
         Gxm1jsgantttask.gxTpr_Plink = "http://www.pmsevolution.com";
         Gxm1jsgantttask.gxTpr_Pmile = 0;
         Gxm1jsgantttask.gxTpr_Pres = "Vinícius";
         Gxm1jsgantttask.gxTpr_Pcomp = 50;
         Gxm1jsgantttask.gxTpr_Pgroup = 0;
         Gxm1jsgantttask.gxTpr_Pparent = 1;
         Gxm1jsgantttask.gxTpr_Popen = 0;
         Gxm1jsgantttask.gxTpr_Pdepend = "";
         Gxm1jsgantttask.gxTpr_Pcaption = "";
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
         Gxm1jsgantttask = new SdtjsGanttTask(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtjsGanttTask> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtjsGanttTask> Gxm2rootcol ;
      private SdtjsGanttTask Gxm1jsgantttask ;
   }

}
