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
   public class getloggedinemployeeid : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public getloggedinemployeeid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getloggedinemployeeid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out long aP0_EmployeeId )
      {
         this.AV12EmployeeId = 0 ;
         initialize();
         executePrivate();
         aP0_EmployeeId=this.AV12EmployeeId;
      }

      public long executeUdp( )
      {
         execute(out aP0_EmployeeId);
         return AV12EmployeeId ;
      }

      public void executeSubmit( out long aP0_EmployeeId )
      {
         getloggedinemployeeid objgetloggedinemployeeid;
         objgetloggedinemployeeid = new getloggedinemployeeid();
         objgetloggedinemployeeid.AV12EmployeeId = 0 ;
         objgetloggedinemployeeid.context.SetSubmitInitialConfig(context);
         objgetloggedinemployeeid.initialize();
         Submit( executePrivateCatch,objgetloggedinemployeeid);
         aP0_EmployeeId=this.AV12EmployeeId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getloggedinemployeeid)stateInfo).executePrivate();
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
         new getloggedinuser(context ).execute( out  AV11GAMUser, out  AV8Employee) ;
         AV12EmployeeId = AV8Employee.gxTpr_Employeeid;
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
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Employee = new SdtEmployee(context);
         /* GeneXus formulas. */
      }

      private long AV12EmployeeId ;
      private long aP0_EmployeeId ;
      private SdtEmployee AV8Employee ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
   }

}
