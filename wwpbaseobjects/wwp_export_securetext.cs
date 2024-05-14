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
   public class wwp_export_securetext : GXProcedure
   {
      public wwp_export_securetext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_export_securetext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Text ,
                           out string aP1_SecureText )
      {
         this.AV8Text = aP0_Text;
         this.AV9SecureText = "" ;
         initialize();
         executePrivate();
         aP1_SecureText=this.AV9SecureText;
      }

      public string executeUdp( string aP0_Text )
      {
         execute(aP0_Text, out aP1_SecureText);
         return AV9SecureText ;
      }

      public void executeSubmit( string aP0_Text ,
                                 out string aP1_SecureText )
      {
         wwp_export_securetext objwwp_export_securetext;
         objwwp_export_securetext = new wwp_export_securetext();
         objwwp_export_securetext.AV8Text = aP0_Text;
         objwwp_export_securetext.AV9SecureText = "" ;
         objwwp_export_securetext.context.SetSubmitInitialConfig(context);
         objwwp_export_securetext.initialize();
         Submit( executePrivateCatch,objwwp_export_securetext);
         aP1_SecureText=this.AV9SecureText;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_export_securetext)stateInfo).executePrivate();
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
         AV9SecureText = AV8Text;
         if ( StringUtil.StrCmp(AV9SecureText, "<#Empty#>") == 0 )
         {
            AV9SecureText = "(Empty)";
         }
         if ( ( StringUtil.Len( AV9SecureText) > 0 ) && ( StringUtil.StartsWith( AV9SecureText, "=") || StringUtil.StartsWith( AV9SecureText, "+") || StringUtil.StartsWith( AV9SecureText, "-") || StringUtil.StartsWith( AV9SecureText, "@") ) )
         {
            AV9SecureText = "'" + AV9SecureText;
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
         AV9SecureText = "";
         /* GeneXus formulas. */
      }

      private string AV8Text ;
      private string AV9SecureText ;
      private string aP1_SecureText ;
   }

}
