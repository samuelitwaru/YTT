using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class isdateholiday : GXProcedure
   {
      public isdateholiday( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public isdateholiday( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Date ,
                           long aP1_EmployeeId ,
                           out bool aP2_IsHoliday )
      {
         this.AV2Date = aP0_Date;
         this.AV3EmployeeId = aP1_EmployeeId;
         this.AV4IsHoliday = false ;
         initialize();
         executePrivate();
         aP2_IsHoliday=this.AV4IsHoliday;
      }

      public bool executeUdp( DateTime aP0_Date ,
                              long aP1_EmployeeId )
      {
         execute(aP0_Date, aP1_EmployeeId, out aP2_IsHoliday);
         return AV4IsHoliday ;
      }

      public void executeSubmit( DateTime aP0_Date ,
                                 long aP1_EmployeeId ,
                                 out bool aP2_IsHoliday )
      {
         isdateholiday objisdateholiday;
         objisdateholiday = new isdateholiday();
         objisdateholiday.AV2Date = aP0_Date;
         objisdateholiday.AV3EmployeeId = aP1_EmployeeId;
         objisdateholiday.AV4IsHoliday = false ;
         objisdateholiday.context.SetSubmitInitialConfig(context);
         objisdateholiday.initialize();
         Submit( executePrivateCatch,objisdateholiday);
         aP2_IsHoliday=this.AV4IsHoliday;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((isdateholiday)stateInfo).executePrivate();
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
         args = new Object[] {(DateTime)AV2Date,(long)AV3EmployeeId,(bool)AV4IsHoliday} ;
         ClassLoader.Execute("aisdateholiday","GeneXus.Programs","aisdateholiday", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4IsHoliday = (bool)(args[2]) ;
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
      }

      private long AV3EmployeeId ;
      private DateTime AV2Date ;
      private bool AV4IsHoliday ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private bool aP2_IsHoliday ;
   }

}
