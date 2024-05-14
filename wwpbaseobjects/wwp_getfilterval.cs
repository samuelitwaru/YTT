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
   public class wwp_getfilterval : GXProcedure
   {
      public wwp_getfilterval( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getfilterval( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( bool aP0_IsEmpty ,
                           string aP1_FilterValue ,
                           out string aP2_FilterResult )
      {
         this.AV10IsEmpty = aP0_IsEmpty;
         this.AV9FilterValue = aP1_FilterValue;
         this.AV8FilterResult = "" ;
         initialize();
         executePrivate();
         aP2_FilterResult=this.AV8FilterResult;
      }

      public string executeUdp( bool aP0_IsEmpty ,
                                string aP1_FilterValue )
      {
         execute(aP0_IsEmpty, aP1_FilterValue, out aP2_FilterResult);
         return AV8FilterResult ;
      }

      public void executeSubmit( bool aP0_IsEmpty ,
                                 string aP1_FilterValue ,
                                 out string aP2_FilterResult )
      {
         wwp_getfilterval objwwp_getfilterval;
         objwwp_getfilterval = new wwp_getfilterval();
         objwwp_getfilterval.AV10IsEmpty = aP0_IsEmpty;
         objwwp_getfilterval.AV9FilterValue = aP1_FilterValue;
         objwwp_getfilterval.AV8FilterResult = "" ;
         objwwp_getfilterval.context.SetSubmitInitialConfig(context);
         objwwp_getfilterval.initialize();
         Submit( executePrivateCatch,objwwp_getfilterval);
         aP2_FilterResult=this.AV8FilterResult;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getfilterval)stateInfo).executePrivate();
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
         if ( ! AV10IsEmpty )
         {
            AV8FilterResult = StringUtil.StringReplace( StringUtil.StringReplace( AV9FilterValue, "\\", "\\\\"), "|", "\\|");
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
         AV8FilterResult = "";
         /* GeneXus formulas. */
      }

      private bool AV10IsEmpty ;
      private string AV9FilterValue ;
      private string AV8FilterResult ;
      private string aP2_FilterResult ;
   }

}
