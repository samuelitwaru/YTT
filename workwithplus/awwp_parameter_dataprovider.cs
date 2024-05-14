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
namespace GeneXus.Programs.workwithplus {
   public class awwp_parameter_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new workwithplus.awwp_parameter_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_Gxm2rootcol = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>()  ;
         execute(out aP0_Gxm2rootcol);
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

      public awwp_parameter_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awwp_parameter_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>( context, "WWP_Parameter", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_Gxm2rootcol )
      {
         awwp_parameter_dataprovider objawwp_parameter_dataprovider;
         objawwp_parameter_dataprovider = new awwp_parameter_dataprovider();
         objawwp_parameter_dataprovider.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>( context, "WWP_Parameter", "YTT_version4") ;
         objawwp_parameter_dataprovider.context.SetSubmitInitialConfig(context);
         objawwp_parameter_dataprovider.initialize();
         Submit( executePrivateCatch,objawwp_parameter_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((awwp_parameter_dataprovider)stateInfo).executePrivate();
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
         Gxm1wwp_parameter = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         Gxm2rootcol.Add(Gxm1wwp_parameter, 0);
         Gxm1wwp_parameter.gxTpr_Wwpparameterkey = "AD_Application_Name";
         Gxm1wwp_parameter.gxTpr_Wwpparametercategory = "Application data";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdescription = "Application name";
         Gxm1wwp_parameter.gxTpr_Wwpparametervalue = "WorkWithPlus";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdisabledelete = true;
         Gxm1wwp_parameter = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         Gxm2rootcol.Add(Gxm1wwp_parameter, 0);
         Gxm1wwp_parameter.gxTpr_Wwpparameterkey = "AD_Application_Phone";
         Gxm1wwp_parameter.gxTpr_Wwpparametercategory = "Application data";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdescription = "Application phone";
         Gxm1wwp_parameter.gxTpr_Wwpparametervalue = "+1 550 8923";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdisabledelete = true;
         Gxm1wwp_parameter = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         Gxm2rootcol.Add(Gxm1wwp_parameter, 0);
         Gxm1wwp_parameter.gxTpr_Wwpparameterkey = "AD_Application_Mail";
         Gxm1wwp_parameter.gxTpr_Wwpparametercategory = "Application data";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdescription = "Application mail";
         Gxm1wwp_parameter.gxTpr_Wwpparametervalue = "info@mail.com";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdisabledelete = true;
         Gxm1wwp_parameter = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         Gxm2rootcol.Add(Gxm1wwp_parameter, 0);
         Gxm1wwp_parameter.gxTpr_Wwpparameterkey = "AD_Application_Website";
         Gxm1wwp_parameter.gxTpr_Wwpparametercategory = "Application data";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdescription = "Application website";
         Gxm1wwp_parameter.gxTpr_Wwpparametervalue = "http://www.web.com";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdisabledelete = true;
         Gxm1wwp_parameter = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         Gxm2rootcol.Add(Gxm1wwp_parameter, 0);
         Gxm1wwp_parameter.gxTpr_Wwpparameterkey = "AD_Application_Address";
         Gxm1wwp_parameter.gxTpr_Wwpparametercategory = "Application data";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdescription = "Application address";
         Gxm1wwp_parameter.gxTpr_Wwpparametervalue = "French Boulevard 2859";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdisabledelete = true;
         Gxm1wwp_parameter = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         Gxm2rootcol.Add(Gxm1wwp_parameter, 0);
         Gxm1wwp_parameter.gxTpr_Wwpparameterkey = "AD_Application_Neighbour";
         Gxm1wwp_parameter.gxTpr_Wwpparametercategory = "Application data";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdescription = "Application neighbour";
         Gxm1wwp_parameter.gxTpr_Wwpparametervalue = "Downtown";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdisabledelete = true;
         Gxm1wwp_parameter = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         Gxm2rootcol.Add(Gxm1wwp_parameter, 0);
         Gxm1wwp_parameter.gxTpr_Wwpparameterkey = "AD_Application_CityAndCountry";
         Gxm1wwp_parameter.gxTpr_Wwpparametercategory = "Application data";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdescription = "Application city and country";
         Gxm1wwp_parameter.gxTpr_Wwpparametervalue = "Paris, France";
         Gxm1wwp_parameter.gxTpr_Wwpparameterdisabledelete = true;
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
         Gxm1wwp_parameter = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_Gxm2rootcol ;
      private GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> Gxm2rootcol ;
      private GeneXus.Programs.workwithplus.SdtWWP_Parameter Gxm1wwp_parameter ;
   }

}
