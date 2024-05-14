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
namespace GeneXus.Programs {
   public class companylocation_dataprovider : GXProcedure
   {
      public companylocation_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public companylocation_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtCompanyLocation> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtCompanyLocation>( context, "CompanyLocation", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtCompanyLocation> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtCompanyLocation> aP0_ReturnValue )
      {
         companylocation_dataprovider objcompanylocation_dataprovider;
         objcompanylocation_dataprovider = new companylocation_dataprovider();
         objcompanylocation_dataprovider.AV2ReturnValue = new GXBCCollection<SdtCompanyLocation>( context, "CompanyLocation", "YTT_version4") ;
         objcompanylocation_dataprovider.context.SetSubmitInitialConfig(context);
         objcompanylocation_dataprovider.initialize();
         Submit( executePrivateCatch,objcompanylocation_dataprovider);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((companylocation_dataprovider)stateInfo).executePrivate();
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
         args = new Object[] {(GXBCCollection<SdtCompanyLocation>)AV2ReturnValue} ;
         ClassLoader.Execute("acompanylocation_dataprovider","GeneXus.Programs","acompanylocation_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtCompanyLocation>)(args[0]) ;
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
         AV2ReturnValue = new GXBCCollection<SdtCompanyLocation>( context, "CompanyLocation", "YTT_version4");
         /* GeneXus formulas. */
      }

      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<SdtCompanyLocation> aP0_ReturnValue ;
      private GXBCCollection<SdtCompanyLocation> AV2ReturnValue ;
   }

}
