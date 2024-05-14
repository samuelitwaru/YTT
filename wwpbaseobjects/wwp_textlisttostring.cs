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
   public class wwp_textlisttostring : GXProcedure
   {
      public wwp_textlisttostring( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_textlisttostring( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GxSimpleCollection<string> aP0_SelectedTextCol ,
                           bool aP1_HasMultipleDscs ,
                           out string aP2_ListString )
      {
         this.AV10SelectedTextCol = aP0_SelectedTextCol;
         this.AV8HasMultipleDscs = aP1_HasMultipleDscs;
         this.AV9ListString = "" ;
         initialize();
         executePrivate();
         aP0_SelectedTextCol=this.AV10SelectedTextCol;
         aP2_ListString=this.AV9ListString;
      }

      public string executeUdp( ref GxSimpleCollection<string> aP0_SelectedTextCol ,
                                bool aP1_HasMultipleDscs )
      {
         execute(ref aP0_SelectedTextCol, aP1_HasMultipleDscs, out aP2_ListString);
         return AV9ListString ;
      }

      public void executeSubmit( ref GxSimpleCollection<string> aP0_SelectedTextCol ,
                                 bool aP1_HasMultipleDscs ,
                                 out string aP2_ListString )
      {
         wwp_textlisttostring objwwp_textlisttostring;
         objwwp_textlisttostring = new wwp_textlisttostring();
         objwwp_textlisttostring.AV10SelectedTextCol = aP0_SelectedTextCol;
         objwwp_textlisttostring.AV8HasMultipleDscs = aP1_HasMultipleDscs;
         objwwp_textlisttostring.AV9ListString = "" ;
         objwwp_textlisttostring.context.SetSubmitInitialConfig(context);
         objwwp_textlisttostring.initialize();
         Submit( executePrivateCatch,objwwp_textlisttostring);
         aP0_SelectedTextCol=this.AV10SelectedTextCol;
         aP2_ListString=this.AV9ListString;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_textlisttostring)stateInfo).executePrivate();
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
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV10SelectedTextCol.Count )
         {
            AV12SelectedText = ((string)AV10SelectedTextCol.Item(AV13GXV1));
            AV9ListString += (String.IsNullOrEmpty(StringUtil.RTrim( AV9ListString)) ? "" : ", ");
            if ( AV8HasMultipleDscs )
            {
               AV11MultipleStr.FromJSonString(AV12SelectedText, null);
               if ( AV11MultipleStr.Count > 0 )
               {
                  AV9ListString += StringUtil.Trim( ((string)AV11MultipleStr.Item(1)));
               }
            }
            else
            {
               AV9ListString += StringUtil.Trim( AV12SelectedText);
            }
            AV13GXV1 = (int)(AV13GXV1+1);
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
         AV9ListString = "";
         AV12SelectedText = "";
         AV11MultipleStr = new GxSimpleCollection<string>();
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private bool AV8HasMultipleDscs ;
      private string AV9ListString ;
      private string AV12SelectedText ;
      private GxSimpleCollection<string> aP0_SelectedTextCol ;
      private string aP2_ListString ;
      private GxSimpleCollection<string> AV10SelectedTextCol ;
      private GxSimpleCollection<string> AV11MultipleStr ;
   }

}
