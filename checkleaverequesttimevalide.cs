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
   public class checkleaverequesttimevalide : GXProcedure
   {
      public checkleaverequesttimevalide( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public checkleaverequesttimevalide( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_LeaveRequestStartDate ,
                           string aP1_LeaveRequestHalfDay ,
                           out bool aP2_IsValid )
      {
         this.AV9LeaveRequestStartDate = aP0_LeaveRequestStartDate;
         this.AV11LeaveRequestHalfDay = aP1_LeaveRequestHalfDay;
         this.AV8IsValid = false ;
         initialize();
         executePrivate();
         aP2_IsValid=this.AV8IsValid;
      }

      public bool executeUdp( DateTime aP0_LeaveRequestStartDate ,
                              string aP1_LeaveRequestHalfDay )
      {
         execute(aP0_LeaveRequestStartDate, aP1_LeaveRequestHalfDay, out aP2_IsValid);
         return AV8IsValid ;
      }

      public void executeSubmit( DateTime aP0_LeaveRequestStartDate ,
                                 string aP1_LeaveRequestHalfDay ,
                                 out bool aP2_IsValid )
      {
         checkleaverequesttimevalide objcheckleaverequesttimevalide;
         objcheckleaverequesttimevalide = new checkleaverequesttimevalide();
         objcheckleaverequesttimevalide.AV9LeaveRequestStartDate = aP0_LeaveRequestStartDate;
         objcheckleaverequesttimevalide.AV11LeaveRequestHalfDay = aP1_LeaveRequestHalfDay;
         objcheckleaverequesttimevalide.AV8IsValid = false ;
         objcheckleaverequesttimevalide.context.SetSubmitInitialConfig(context);
         objcheckleaverequesttimevalide.initialize();
         Submit( executePrivateCatch,objcheckleaverequesttimevalide);
         aP2_IsValid=this.AV8IsValid;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((checkleaverequesttimevalide)stateInfo).executePrivate();
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
         AV10systemTime = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         AV8IsValid = true;
         if ( ( DateTimeUtil.ResetTime ( AV9LeaveRequestStartDate ) == DateTimeUtil.ResetTime ( Gx_date ) ) && ( DateTimeUtil.Hour( AV10systemTime) > 9 ) && ( StringUtil.StrCmp(AV11LeaveRequestHalfDay, "Morning") == 0 ) )
         {
            AV8IsValid = false;
         }
         if ( ( DateTimeUtil.ResetTime ( AV9LeaveRequestStartDate ) == DateTimeUtil.ResetTime ( Gx_date ) ) && ( DateTimeUtil.Hour( AV10systemTime) > 14 ) && ( StringUtil.StrCmp(AV11LeaveRequestHalfDay, "Afternoon") == 0 ) )
         {
            AV8IsValid = false;
         }
         if ( ( DateTimeUtil.ResetTime ( AV9LeaveRequestStartDate ) == DateTimeUtil.ResetTime ( Gx_date ) ) && ( DateTimeUtil.Hour( AV10systemTime) > 9 ) && ( StringUtil.StrCmp(AV11LeaveRequestHalfDay, "") == 0 ) )
         {
            AV8IsValid = false;
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
         AV10systemTime = (DateTime)(DateTime.MinValue);
         Gx_date = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private string AV11LeaveRequestHalfDay ;
      private DateTime AV10systemTime ;
      private DateTime AV9LeaveRequestStartDate ;
      private DateTime Gx_date ;
      private bool AV8IsValid ;
      private bool aP2_IsValid ;
   }

}
