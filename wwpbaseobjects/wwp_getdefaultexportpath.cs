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
   public class wwp_getdefaultexportpath : GXProcedure
   {
      public wwp_getdefaultexportpath( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getdefaultexportpath( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_Path )
      {
         this.AV8Path = "" ;
         initialize();
         executePrivate();
         aP0_Path=this.AV8Path;
      }

      public string executeUdp( )
      {
         execute(out aP0_Path);
         return AV8Path ;
      }

      public void executeSubmit( out string aP0_Path )
      {
         wwp_getdefaultexportpath objwwp_getdefaultexportpath;
         objwwp_getdefaultexportpath = new wwp_getdefaultexportpath();
         objwwp_getdefaultexportpath.AV8Path = "" ;
         objwwp_getdefaultexportpath.context.SetSubmitInitialConfig(context);
         objwwp_getdefaultexportpath.initialize();
         Submit( executePrivateCatch,objwwp_getdefaultexportpath);
         aP0_Path=this.AV8Path;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getdefaultexportpath)stateInfo).executePrivate();
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
         AV11IsCSharp = false;
         /* User Code */
          AV11IsCSharp = true;
         if ( AV11IsCSharp )
         {
            AV8Path = "PrivateTempStorage" + AV9File.Separator;
            AV10Directory.Source = "PrivateTempStorage";
            if ( ! AV10Directory.Exists() )
            {
               AV10Directory.Create();
            }
         }
         else
         {
            AV8Path = AV9File.Separator + "WEB-INF" + AV9File.Separator;
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
         AV8Path = "";
         AV9File = new GxFile(context.GetPhysicalPath());
         AV10Directory = new GxDirectory(context.GetPhysicalPath());
         /* GeneXus formulas. */
      }

      private bool AV11IsCSharp ;
      private string AV8Path ;
      private string aP0_Path ;
      private GxFile AV9File ;
      private GxDirectory AV10Directory ;
   }

}
