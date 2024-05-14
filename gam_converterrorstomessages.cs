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
   public class gam_converterrorstomessages : GXProcedure
   {
      public gam_converterrorstomessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gam_converterrorstomessages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages )
      {
         this.AV9GAMErrorCollection = aP0_GAMErrorCollection;
         this.AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP1_Messages=this.AV11Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection )
      {
         execute(aP0_GAMErrorCollection, out aP1_Messages);
         return AV11Messages ;
      }

      public void executeSubmit( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages )
      {
         gam_converterrorstomessages objgam_converterrorstomessages;
         objgam_converterrorstomessages = new gam_converterrorstomessages();
         objgam_converterrorstomessages.AV9GAMErrorCollection = aP0_GAMErrorCollection;
         objgam_converterrorstomessages.AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objgam_converterrorstomessages.context.SetSubmitInitialConfig(context);
         objgam_converterrorstomessages.initialize();
         Submit( executePrivateCatch,objgam_converterrorstomessages);
         aP1_Messages=this.AV11Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gam_converterrorstomessages)stateInfo).executePrivate();
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
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV9GAMErrorCollection.Count )
         {
            AV8GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(AV12GXV1));
            AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV10Message.gxTpr_Type = 1;
            AV10Message.gxTpr_Description = AV8GAMError.gxTpr_Message;
            AV10Message.gxTpr_Id = StringUtil.Format( "GAM%2", StringUtil.LTrimStr( (decimal)(AV8GAMError.gxTpr_Code), 12, 0), "", "", "", "", "", "", "", "");
            AV11Messages.Add(AV10Message, 0);
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV8GAMError ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
   }

}
