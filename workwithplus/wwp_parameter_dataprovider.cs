using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameter_dataprovider : GXProcedure
   {
      public wwp_parameter_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public wwp_parameter_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>( context, "WWP_Parameter", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_ReturnValue )
      {
         wwp_parameter_dataprovider objwwp_parameter_dataprovider;
         objwwp_parameter_dataprovider = new wwp_parameter_dataprovider();
         objwwp_parameter_dataprovider.AV2ReturnValue = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>( context, "WWP_Parameter", "YTT_version4") ;
         objwwp_parameter_dataprovider.context.SetSubmitInitialConfig(context);
         objwwp_parameter_dataprovider.initialize();
         Submit( executePrivateCatch,objwwp_parameter_dataprovider);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_parameter_dataprovider)stateInfo).executePrivate();
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
         args = new Object[] {(GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>)AV2ReturnValue} ;
         ClassLoader.Execute("workwithplus-awwp_parameter_dataprovider","GeneXus.Programs","workwithplus.awwp_parameter_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>)(args[0]) ;
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV2ReturnValue = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>( context, "WWP_Parameter", "YTT_version4");
         /* GeneXus formulas. */
      }

      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_ReturnValue ;
      private GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> AV2ReturnValue ;
   }

}
