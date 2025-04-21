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
   public class aprc_sendsundayreminderemails : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprc_sendsundayreminderemails( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_sendsundayreminderemails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gx_date = context.localUtil.YMDToD( 2025, 4, 20);
         AV8FromDate = DateTimeUtil.DAdd( Gx_date, (-6));
         AV9ToDate = DateTimeUtil.DAdd( AV8FromDate, (6));
         new logtofile(context ).execute(  context.localUtil.DToC( AV8FromDate, 2, "/")+" - "+context.localUtil.DToC( AV9ToDate, 2, "/")) ;
         /* Using cursor P00CR2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00CR2_A100CompanyId[0];
            A148EmployeeName = P00CR2_A148EmployeeName[0];
            A157CompanyLocationId = P00CR2_A157CompanyLocationId[0];
            A106EmployeeId = P00CR2_A106EmployeeId[0];
            A109EmployeeEmail = P00CR2_A109EmployeeEmail[0];
            A112EmployeeIsActive = P00CR2_A112EmployeeIsActive[0];
            A157CompanyLocationId = P00CR2_A157CompanyLocationId[0];
            /* Using cursor P00CR3 */
            pr_default.execute(1, new Object[] {A106EmployeeId, A112EmployeeIsActive});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A102ProjectId = P00CR3_A102ProjectId[0];
               AV12CompanyLocationCollection.Clear();
               AV14EmployeeIdCollection.Clear();
               new logtofile(context ).execute(  StringUtil.Trim( A148EmployeeName)) ;
               AV17CompanyLocationIdCollection.Add(A157CompanyLocationId, 0);
               AV14EmployeeIdCollection.Add(A106EmployeeId, 0);
               AV16SDTEmployeeWeekReport = new SdtSDTEmployeeWeekReport(context);
               GXt_objcol_SdtSDTEmployeeWeekReport1 = AV15SDTEmployeeWeekReportCollection;
               new dpemployeeweekreport(context ).execute(  AV8FromDate,  AV9ToDate,  AV17CompanyLocationIdCollection,  AV14EmployeeIdCollection, out  GXt_objcol_SdtSDTEmployeeWeekReport1) ;
               AV15SDTEmployeeWeekReportCollection = GXt_objcol_SdtSDTEmployeeWeekReport1;
               if ( AV15SDTEmployeeWeekReportCollection.Count == 1 )
               {
                  AV16SDTEmployeeWeekReport = ((SdtSDTEmployeeWeekReport)AV15SDTEmployeeWeekReportCollection.Item(1));
                  new logtofile(context ).execute(  "			Expected : "+AV16SDTEmployeeWeekReport.gxTpr_Expected_formatted+" >> "+StringUtil.Str( AV16SDTEmployeeWeekReport.gxTpr_Expected, 10, 2)) ;
                  new logtofile(context ).execute(  "			Actual   : "+AV16SDTEmployeeWeekReport.gxTpr_Total_formatted+" >> "+StringUtil.Str( (decimal)(AV16SDTEmployeeWeekReport.gxTpr_Total), 10, 0)) ;
                  if ( (Convert.ToDecimal( AV16SDTEmployeeWeekReport.gxTpr_Total ) < AV16SDTEmployeeWeekReport.gxTpr_Expected ) )
                  {
                     new logtofile(context ).execute(  "				Sending Email...") ;
                     new logtofile(context ).execute(  AV16SDTEmployeeWeekReport.ToJSonString(false, true)) ;
                     AV19Body = new SdtEO_GenerateEmail(context).generate(AV16SDTEmployeeWeekReport.ToJSonString(false, true), context.localUtil.DToC( AV8FromDate, 2, "/"), context.localUtil.DToC( AV9ToDate, 2, "/"));
                     new logtofile(context ).execute(  AV19Body) ;
                     GXt_char2 = "";
                     new sendemail(context).executeSubmit(  "Weekly Time Tracker Reminder", ref  AV19Body, ref  GXt_char2) ;
                  }
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         Gx_date = DateTime.MinValue;
         AV8FromDate = DateTime.MinValue;
         AV9ToDate = DateTime.MinValue;
         P00CR2_A100CompanyId = new long[1] ;
         P00CR2_A148EmployeeName = new string[] {""} ;
         P00CR2_A157CompanyLocationId = new long[1] ;
         P00CR2_A106EmployeeId = new long[1] ;
         P00CR2_A109EmployeeEmail = new string[] {""} ;
         P00CR2_A112EmployeeIsActive = new bool[] {false} ;
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         P00CR3_A106EmployeeId = new long[1] ;
         P00CR3_A102ProjectId = new long[1] ;
         AV12CompanyLocationCollection = new GXBCCollection<SdtCompanyLocation>( context, "CompanyLocation", "YTT_version4");
         AV14EmployeeIdCollection = new GxSimpleCollection<long>();
         AV17CompanyLocationIdCollection = new GxSimpleCollection<long>();
         AV16SDTEmployeeWeekReport = new SdtSDTEmployeeWeekReport(context);
         AV15SDTEmployeeWeekReportCollection = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4");
         GXt_objcol_SdtSDTEmployeeWeekReport1 = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4");
         AV19Body = "";
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_sendsundayreminderemails__default(),
            new Object[][] {
                new Object[] {
               P00CR2_A100CompanyId, P00CR2_A148EmployeeName, P00CR2_A157CompanyLocationId, P00CR2_A106EmployeeId, P00CR2_A109EmployeeEmail, P00CR2_A112EmployeeIsActive
               }
               , new Object[] {
               P00CR3_A106EmployeeId, P00CR3_A102ProjectId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A148EmployeeName ;
      private string GXt_char2 ;
      private DateTime Gx_date ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private bool entryPointCalled ;
      private bool A112EmployeeIsActive ;
      private string AV19Body ;
      private string A109EmployeeEmail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00CR2_A100CompanyId ;
      private string[] P00CR2_A148EmployeeName ;
      private long[] P00CR2_A157CompanyLocationId ;
      private long[] P00CR2_A106EmployeeId ;
      private string[] P00CR2_A109EmployeeEmail ;
      private bool[] P00CR2_A112EmployeeIsActive ;
      private long[] P00CR3_A106EmployeeId ;
      private long[] P00CR3_A102ProjectId ;
      private GXBCCollection<SdtCompanyLocation> AV12CompanyLocationCollection ;
      private GxSimpleCollection<long> AV14EmployeeIdCollection ;
      private GxSimpleCollection<long> AV17CompanyLocationIdCollection ;
      private SdtSDTEmployeeWeekReport AV16SDTEmployeeWeekReport ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> AV15SDTEmployeeWeekReportCollection ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> GXt_objcol_SdtSDTEmployeeWeekReport1 ;
   }

   public class aprc_sendsundayreminderemails__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CR2;
          prmP00CR2 = new Object[] {
          };
          Object[] prmP00CR3;
          prmP00CR3 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("EmployeeIsActive",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CR2", "SELECT T1.CompanyId, T1.EmployeeName, T2.CompanyLocationId, T1.EmployeeId, T1.EmployeeEmail, T1.EmployeeIsActive FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T1.EmployeeEmail = ( 'samuel.itwaru@yukon.ug')) AND (T1.EmployeeIsActive = TRUE) ORDER BY T1.EmployeeEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CR2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CR3", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE (EmployeeId = :EmployeeId) AND (:EmployeeIsActive = TRUE) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CR3,1, GxCacheFrequency.OFF ,true,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
