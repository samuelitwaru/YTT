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
namespace GeneXus.Programs.tests {
   public class createemployeeaccount1testdata : GXProcedure
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
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public createemployeeaccount1testdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public createemployeeaccount1testdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT>( context, "CreateEmployeeAccount1TestSDT", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT> aP0_Gxm2rootcol )
      {
         createemployeeaccount1testdata objcreateemployeeaccount1testdata;
         objcreateemployeeaccount1testdata = new createemployeeaccount1testdata();
         objcreateemployeeaccount1testdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT>( context, "CreateEmployeeAccount1TestSDT", "YTT_version4") ;
         objcreateemployeeaccount1testdata.context.SetSubmitInitialConfig(context);
         objcreateemployeeaccount1testdata.initialize();
         Submit( executePrivateCatch,objcreateemployeeaccount1testdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createemployeeaccount1testdata)stateInfo).executePrivate();
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
         Gxm1createemployeeaccount1testsdt = new GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT(context);
         Gxm2rootcol.Add(Gxm1createemployeeaccount1testsdt, 0);
         Gxm1createemployeeaccount1testsdt.gxTpr_Testcaseid = "1";
         Gxm1createemployeeaccount1testsdt.gxTpr_Employeeemail = "aarkhelyuk@yukon.cv.ua";
         Gxm1createemployeeaccount1testsdt.gxTpr_Employeefirstname = "Alina";
         Gxm1createemployeeaccount1testsdt.gxTpr_Employeelastname = "Arkhelyuk";
         Gxm1createemployeeaccount1testsdt.gxTpr_Rolesstring = "IsEmployee";
         Gxm1createemployeeaccount1testsdt.gxTpr_Expectedgamuserguid = "a972b55f-b44c-47dd-bae0-659089ff33dc";
         Gxm1createemployeeaccount1testsdt.gxTpr_Msggamuserguid = "";
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
         Gxm1createemployeeaccount1testsdt = new GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT> Gxm2rootcol ;
      private GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT Gxm1createemployeeaccount1testsdt ;
   }

}
