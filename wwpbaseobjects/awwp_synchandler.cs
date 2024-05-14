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
   public class awwp_synchandler : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new wwpbaseobjects.awwp_synchandler().executeCmdLine(args); ;
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
         string aP0_GAMEvents = new string(' ',0)  ;
         string aP1_inJson = new string(' ',0)  ;
         string aP2_outJson = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_GAMEvents=((string)(args[0]));
         }
         else
         {
            aP0_GAMEvents="";
         }
         if ( 1 < args.Length )
         {
            aP1_inJson=((string)(args[1]));
         }
         else
         {
            aP1_inJson="";
         }
         if ( 2 < args.Length )
         {
            aP2_outJson=((string)(args[2]));
         }
         else
         {
            aP2_outJson="";
         }
         execute(aP0_GAMEvents, aP1_inJson, out aP2_outJson);
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

      public awwp_synchandler( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awwp_synchandler( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_GAMEvents ,
                           string aP1_inJson ,
                           out string aP2_outJson )
      {
         this.AV8GAMEvents = aP0_GAMEvents;
         this.AV13inJson = aP1_inJson;
         this.AV15outJson = "" ;
         initialize();
         executePrivate();
         aP2_outJson=this.AV15outJson;
      }

      public string executeUdp( string aP0_GAMEvents ,
                                string aP1_inJson )
      {
         execute(aP0_GAMEvents, aP1_inJson, out aP2_outJson);
         return AV15outJson ;
      }

      public void executeSubmit( string aP0_GAMEvents ,
                                 string aP1_inJson ,
                                 out string aP2_outJson )
      {
         awwp_synchandler objawwp_synchandler;
         objawwp_synchandler = new awwp_synchandler();
         objawwp_synchandler.AV8GAMEvents = aP0_GAMEvents;
         objawwp_synchandler.AV13inJson = aP1_inJson;
         objawwp_synchandler.AV15outJson = "" ;
         objawwp_synchandler.context.SetSubmitInitialConfig(context);
         objawwp_synchandler.initialize();
         Submit( executePrivateCatch,objawwp_synchandler);
         aP2_outJson=this.AV15outJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((awwp_synchandler)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  StringUtil.Format( "GAMEvents: %1 - %2, inJson: %3", AV8GAMEvents, GeneXus.Programs.genexussecuritycommon.gxdomaingamevents.getDescription(context,AV8GAMEvents), AV13inJson, "", "", "", "", "", ""),  AV16Pgmname) ;
         if ( StringUtil.StrCmp(AV8GAMEvents, "user-insert") == 0 )
         {
            AV10GAMUser.fromjsonstring( AV13inJson);
            GXt_objcol_SdtMessages_Message1 = AV14Messages;
            new GeneXus.Programs.wwpbaseobjects.wwp_usersync(context ).execute(  "INS",  AV10GAMUser, out  GXt_objcol_SdtMessages_Message1) ;
            AV14Messages = GXt_objcol_SdtMessages_Message1;
         }
         else if ( StringUtil.StrCmp(AV8GAMEvents, "user-update") == 0 )
         {
            AV10GAMUser.fromjsonstring( AV13inJson);
            GXt_objcol_SdtMessages_Message1 = AV14Messages;
            new GeneXus.Programs.wwpbaseobjects.wwp_usersync(context ).execute(  "UPD",  AV10GAMUser, out  GXt_objcol_SdtMessages_Message1) ;
            AV14Messages = GXt_objcol_SdtMessages_Message1;
         }
         else if ( StringUtil.StrCmp(AV8GAMEvents, "user-delete") == 0 )
         {
            AV10GAMUser.fromjsonstring( AV13inJson);
            GXt_objcol_SdtMessages_Message1 = AV14Messages;
            new GeneXus.Programs.wwpbaseobjects.wwp_usersync(context ).execute(  "DLT",  AV10GAMUser, out  GXt_objcol_SdtMessages_Message1) ;
            AV14Messages = GXt_objcol_SdtMessages_Message1;
         }
         else
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  StringUtil.Format( "GAMEvents: %1 - %2, inJson: %3, Not Implemented", AV8GAMEvents, GeneXus.Programs.genexussecuritycommon.gxdomaingamevents.getDescription(context,AV8GAMEvents), AV13inJson, "", "", "", "", "", ""),  AV16Pgmname) ;
         }
         AV15outJson = AV14Messages.ToJSonString(false);
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  StringUtil.Format( "GAMEvents: %1 - %2, outJson: %3", AV8GAMEvents, GeneXus.Programs.genexussecuritycommon.gxdomaingamevents.getDescription(context,AV8GAMEvents), AV15outJson, "", "", "", "", "", ""),  AV16Pgmname) ;
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
         AV15outJson = "";
         AV16Pgmname = "";
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV14Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Pgmname = "WWPBaseObjects.AWWP_SyncHandler";
         /* GeneXus formulas. */
         AV16Pgmname = "WWPBaseObjects.AWWP_SyncHandler";
      }

      private string AV8GAMEvents ;
      private string AV16Pgmname ;
      private string AV13inJson ;
      private string AV15outJson ;
      private string aP2_outJson ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV14Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
   }

}
