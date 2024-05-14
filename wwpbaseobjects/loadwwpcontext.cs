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
   public class loadwwpcontext : GXProcedure
   {
      public loadwwpcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadwwpcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_Context )
      {
         this.AV8Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context) ;
         initialize();
         executePrivate();
         aP0_Context=this.AV8Context;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWPContext executeUdp( )
      {
         execute(out aP0_Context);
         return AV8Context ;
      }

      public void executeSubmit( out GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_Context )
      {
         loadwwpcontext objloadwwpcontext;
         objloadwwpcontext = new loadwwpcontext();
         objloadwwpcontext.AV8Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context) ;
         objloadwwpcontext.context.SetSubmitInitialConfig(context);
         objloadwwpcontext.initialize();
         Submit( executePrivateCatch,objloadwwpcontext);
         aP0_Context=this.AV8Context;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadwwpcontext)stateInfo).executePrivate();
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
         AV8Context.FromXml(AV9Session.Get("wwpcontext"), null, "", "");
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
         AV8Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private IGxSession AV9Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_Context ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8Context ;
   }

}
