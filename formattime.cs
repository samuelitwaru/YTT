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
   public class formattime : GXProcedure
   {
      public formattime( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public formattime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_TimeInMins ,
                           out string aP1_FormattedTime )
      {
         this.AV8TimeInMins = aP0_TimeInMins;
         this.AV9FormattedTime = "" ;
         initialize();
         executePrivate();
         aP1_FormattedTime=this.AV9FormattedTime;
      }

      public string executeUdp( long aP0_TimeInMins )
      {
         execute(aP0_TimeInMins, out aP1_FormattedTime);
         return AV9FormattedTime ;
      }

      public void executeSubmit( long aP0_TimeInMins ,
                                 out string aP1_FormattedTime )
      {
         formattime objformattime;
         objformattime = new formattime();
         objformattime.AV8TimeInMins = aP0_TimeInMins;
         objformattime.AV9FormattedTime = "" ;
         objformattime.context.SetSubmitInitialConfig(context);
         objformattime.initialize();
         Submit( executePrivateCatch,objformattime);
         aP1_FormattedTime=this.AV9FormattedTime;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((formattime)stateInfo).executePrivate();
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
         AV10Hours = (int)(AV8TimeInMins/ (decimal)(60));
         AV11Minutes = (short)(((int)((AV8TimeInMins) % (60))));
         if ( AV11Minutes < 10 )
         {
            AV9FormattedTime = StringUtil.Trim( StringUtil.Str( (decimal)(AV10Hours), 5, 0)) + ":0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Minutes), 4, 0));
         }
         else
         {
            AV9FormattedTime = StringUtil.Trim( StringUtil.Str( (decimal)(AV10Hours), 5, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Minutes), 4, 0));
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
         AV9FormattedTime = "";
         /* GeneXus formulas. */
      }

      private short AV11Minutes ;
      private int AV10Hours ;
      private long AV8TimeInMins ;
      private string AV9FormattedTime ;
      private string aP1_FormattedTime ;
   }

}