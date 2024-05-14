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
namespace GeneXus.Programs.workwithplus.ai {
   public class wwp_aiprocessusercustomredirection : GXProcedure
   {
      public wwp_aiprocessusercustomredirection( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_aiprocessusercustomredirection( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ListName ,
                           string aP1_UserQuery ,
                           ref string aP2_Link ,
                           out string aP3_ErrorMessage )
      {
         this.AV10ListName = aP0_ListName;
         this.AV11UserQuery = aP1_UserQuery;
         this.AV9Link = aP2_Link;
         this.AV8ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP2_Link=this.AV9Link;
         aP3_ErrorMessage=this.AV8ErrorMessage;
      }

      public string executeUdp( string aP0_ListName ,
                                string aP1_UserQuery ,
                                ref string aP2_Link )
      {
         execute(aP0_ListName, aP1_UserQuery, ref aP2_Link, out aP3_ErrorMessage);
         return AV8ErrorMessage ;
      }

      public void executeSubmit( string aP0_ListName ,
                                 string aP1_UserQuery ,
                                 ref string aP2_Link ,
                                 out string aP3_ErrorMessage )
      {
         wwp_aiprocessusercustomredirection objwwp_aiprocessusercustomredirection;
         objwwp_aiprocessusercustomredirection = new wwp_aiprocessusercustomredirection();
         objwwp_aiprocessusercustomredirection.AV10ListName = aP0_ListName;
         objwwp_aiprocessusercustomredirection.AV11UserQuery = aP1_UserQuery;
         objwwp_aiprocessusercustomredirection.AV9Link = aP2_Link;
         objwwp_aiprocessusercustomredirection.AV8ErrorMessage = "" ;
         objwwp_aiprocessusercustomredirection.context.SetSubmitInitialConfig(context);
         objwwp_aiprocessusercustomredirection.initialize();
         Submit( executePrivateCatch,objwwp_aiprocessusercustomredirection);
         aP2_Link=this.AV9Link;
         aP3_ErrorMessage=this.AV8ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_aiprocessusercustomredirection)stateInfo).executePrivate();
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
         AV8ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private string AV11UserQuery ;
      private string AV10ListName ;
      private string AV9Link ;
      private string AV8ErrorMessage ;
      private string aP2_Link ;
      private string aP3_ErrorMessage ;
   }

}
