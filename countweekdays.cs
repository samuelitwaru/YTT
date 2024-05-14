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
   public class countweekdays : GXProcedure
   {
      public countweekdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public countweekdays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate ,
                           out short aP2_DayCount )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV10DayCount = 0 ;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV8FromDate;
         aP1_ToDate=this.AV9ToDate;
         aP2_DayCount=this.AV10DayCount;
      }

      public short executeUdp( ref DateTime aP0_FromDate ,
                               ref DateTime aP1_ToDate )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, out aP2_DayCount);
         return AV10DayCount ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 out short aP2_DayCount )
      {
         countweekdays objcountweekdays;
         objcountweekdays = new countweekdays();
         objcountweekdays.AV8FromDate = aP0_FromDate;
         objcountweekdays.AV9ToDate = aP1_ToDate;
         objcountweekdays.AV10DayCount = 0 ;
         objcountweekdays.context.SetSubmitInitialConfig(context);
         objcountweekdays.initialize();
         Submit( executePrivateCatch,objcountweekdays);
         aP0_FromDate=this.AV8FromDate;
         aP1_ToDate=this.AV9ToDate;
         aP2_DayCount=this.AV10DayCount;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((countweekdays)stateInfo).executePrivate();
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
         AV11StartDate = AV8FromDate;
         AV10DayCount = 0;
         while ( DateTimeUtil.ResetTime ( AV11StartDate ) <= DateTimeUtil.ResetTime ( AV9ToDate ) )
         {
            if ( ! ( ( DateTimeUtil.Dow( AV11StartDate) == 0 ) || ( DateTimeUtil.Dow( AV11StartDate) == 7 ) ) )
            {
               AV10DayCount = (short)(AV10DayCount+1);
            }
            AV11StartDate = DateTimeUtil.DAdd( AV11StartDate, (1));
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
         AV11StartDate = DateTime.MinValue;
         /* GeneXus formulas. */
      }

      private short AV10DayCount ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private DateTime AV11StartDate ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private short aP2_DayCount ;
   }

}
