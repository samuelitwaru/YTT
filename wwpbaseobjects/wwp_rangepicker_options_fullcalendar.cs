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
   public class wwp_rangepicker_options_fullcalendar : GXProcedure
   {
      public wwp_rangepicker_options_fullcalendar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_rangepicker_options_fullcalendar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context) ;
         initialize();
         executePrivate();
         aP0_PickerOptions=this.AV8PickerOptions;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions executeUdp( )
      {
         execute(out aP0_PickerOptions);
         return AV8PickerOptions ;
      }

      public void executeSubmit( out GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         wwp_rangepicker_options_fullcalendar objwwp_rangepicker_options_fullcalendar;
         objwwp_rangepicker_options_fullcalendar = new wwp_rangepicker_options_fullcalendar();
         objwwp_rangepicker_options_fullcalendar.AV8PickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context) ;
         objwwp_rangepicker_options_fullcalendar.context.SetSubmitInitialConfig(context);
         objwwp_rangepicker_options_fullcalendar.initialize();
         Submit( executePrivateCatch,objwwp_rangepicker_options_fullcalendar);
         aP0_PickerOptions=this.AV8PickerOptions;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_rangepicker_options_fullcalendar)stateInfo).executePrivate();
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
         AV8PickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_past( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_yesterday( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_today( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_tomorrow( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_inthefuture( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_lastweek( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_lastmonth( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_lastyear( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_thisweek( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_thismonth( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_thisyear( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_nextweek( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_nextmonth( ref  AV8PickerOptions) ;
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
         AV8PickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP0_PickerOptions ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV8PickerOptions ;
   }

}
