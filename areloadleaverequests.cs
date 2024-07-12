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
   public class areloadleaverequests : GXWebProcedure
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
            executePrivate();
         }
         cleanup();
      }

      public areloadleaverequests( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areloadleaverequests( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         areloadleaverequests objareloadleaverequests;
         objareloadleaverequests = new areloadleaverequests();
         objareloadleaverequests.context.SetSubmitInitialConfig(context);
         objareloadleaverequests.initialize();
         Submit( executePrivateCatch,objareloadleaverequests);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((areloadleaverequests)stateInfo).executePrivate();
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
         new logtofile(context ).execute(  "Starting...") ;
         /* Using cursor P00BA2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00BA2_A124LeaveTypeId[0];
            A100CompanyId = P00BA2_A100CompanyId[0];
            A127LeaveRequestId = P00BA2_A127LeaveRequestId[0];
            A129LeaveRequestStartDate = P00BA2_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00BA2_A130LeaveRequestEndDate[0];
            A173LeaveRequestHalfDay = P00BA2_A173LeaveRequestHalfDay[0];
            n173LeaveRequestHalfDay = P00BA2_n173LeaveRequestHalfDay[0];
            A100CompanyId = P00BA2_A100CompanyId[0];
            AV8LeaveRequest.Load(A127LeaveRequestId);
            GXt_decimal1 = 0;
            new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A173LeaveRequestHalfDay, out  GXt_decimal1) ;
            AV8LeaveRequest.gxTpr_Leaverequestduration = GXt_decimal1;
            if ( AV8LeaveRequest.Update() )
            {
               new logtofile(context ).execute(  "Commiting...") ;
               context.CommitDataStores("reloadleaverequests",pr_default);
            }
            else
            {
               new logtofile(context ).execute(  AV8LeaveRequest.GetMessages().ToJSonString(false)) ;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P00BA2_A124LeaveTypeId = new long[1] ;
         P00BA2_A100CompanyId = new long[1] ;
         P00BA2_A127LeaveRequestId = new long[1] ;
         P00BA2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BA2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BA2_A173LeaveRequestHalfDay = new string[] {""} ;
         P00BA2_n173LeaveRequestHalfDay = new bool[] {false} ;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         AV8LeaveRequest = new SdtLeaveRequest(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.areloadleaverequests__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areloadleaverequests__default(),
            new Object[][] {
                new Object[] {
               P00BA2_A124LeaveTypeId, P00BA2_A100CompanyId, P00BA2_A127LeaveRequestId, P00BA2_A129LeaveRequestStartDate, P00BA2_A130LeaveRequestEndDate, P00BA2_A173LeaveRequestHalfDay, P00BA2_n173LeaveRequestHalfDay
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long A127LeaveRequestId ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A173LeaveRequestHalfDay ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool entryPointCalled ;
      private bool n173LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BA2_A124LeaveTypeId ;
      private long[] P00BA2_A100CompanyId ;
      private long[] P00BA2_A127LeaveRequestId ;
      private DateTime[] P00BA2_A129LeaveRequestStartDate ;
      private DateTime[] P00BA2_A130LeaveRequestEndDate ;
      private string[] P00BA2_A173LeaveRequestHalfDay ;
      private bool[] P00BA2_n173LeaveRequestHalfDay ;
      private IDataStoreProvider pr_gam ;
      private SdtLeaveRequest AV8LeaveRequest ;
   }

   public class areloadleaverequests__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class areloadleaverequests__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00BA2;
        prmP00BA2 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P00BA2", "SELECT T1.LeaveTypeId, T2.CompanyId, T1.LeaveRequestId, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T1.LeaveRequestHalfDay FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE T2.CompanyId = 1 ORDER BY T1.LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA2,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
     }
  }

}

}
