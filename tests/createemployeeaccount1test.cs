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
   public class createemployeeaccount1test : GXProcedure
   {
      public createemployeeaccount1test( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public createemployeeaccount1test( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         createemployeeaccount1test objcreateemployeeaccount1test;
         objcreateemployeeaccount1test = new createemployeeaccount1test();
         objcreateemployeeaccount1test.context.SetSubmitInitialConfig(context);
         objcreateemployeeaccount1test.initialize();
         Submit( executePrivateCatch,objcreateemployeeaccount1test);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createemployeeaccount1test)stateInfo).executePrivate();
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
         AV10GXV2 = 1;
         GXt_objcol_SdtCreateEmployeeAccount1TestSDT1 = AV9GXV1;
         new GeneXus.Programs.tests.createemployeeaccount1testdata(context ).execute( out  GXt_objcol_SdtCreateEmployeeAccount1TestSDT1) ;
         AV9GXV1 = GXt_objcol_SdtCreateEmployeeAccount1TestSDT1;
         while ( AV10GXV2 <= AV9GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT)AV9GXV1.Item(AV10GXV2));
            GXt_char2 = "";
            new createemployeeaccount1(context ).execute(  AV8TestCaseData.gxTpr_Employeeemail,  AV8TestCaseData.gxTpr_Employeefirstname,  AV8TestCaseData.gxTpr_Employeelastname,  AV8TestCaseData.gxTpr_Rolesstring, out  GXt_char2) ;
            AV8TestCaseData.gxTpr_Gamuserguid = GXt_char2;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedgamuserguid,  AV8TestCaseData.gxTpr_Gamuserguid,  StringUtil.Format( "%1.ExpectedGAMUserGUID: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msggamuserguid, "", "", "", "", "", "", "")) ;
            AV10GXV2 = (int)(AV10GXV2+1);
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
         AV9GXV1 = new GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT>( context, "CreateEmployeeAccount1TestSDT", "YTT_version4");
         GXt_objcol_SdtCreateEmployeeAccount1TestSDT1 = new GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT>( context, "CreateEmployeeAccount1TestSDT", "YTT_version4");
         AV8TestCaseData = new GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT(context);
         GXt_char2 = "";
         /* GeneXus formulas. */
      }

      private int AV10GXV2 ;
      private string GXt_char2 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT> AV9GXV1 ;
      private GXBaseCollection<GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT> GXt_objcol_SdtCreateEmployeeAccount1TestSDT1 ;
      private GeneXus.Programs.tests.SdtCreateEmployeeAccount1TestSDT AV8TestCaseData ;
   }

}
