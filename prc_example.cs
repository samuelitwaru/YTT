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
   public class prc_example : GXProcedure
   {
      public prc_example( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_example( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_response )
      {
         this.AV10response = "" ;
         initialize();
         ExecuteImpl();
         aP0_response=this.AV10response;
      }

      public string executeUdp( )
      {
         execute(out aP0_response);
         return AV10response ;
      }

      public void executeSubmit( out string aP0_response )
      {
         this.AV10response = "" ;
         SubmitImpl();
         aP0_response=this.AV10response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SDT_Example.gxTpr_Id = 1;
         AV8SDT_Example.gxTpr_Value = "hELLO World";
         AV10response = AV8SDT_Example.ToJSonString(false, true);
         new logtofile(context ).execute(  ">>>>>>>"+AV10response) ;
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
         AV10response = "";
         AV8SDT_Example = new SdtSDT_Example(context);
         /* GeneXus formulas. */
      }

      private string AV10response ;
      private SdtSDT_Example AV8SDT_Example ;
      private string aP0_response ;
   }

}
