using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class leaverequestconversion : GXProcedure
   {
      public leaverequestconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public leaverequestconversion( IGxContext context )
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
         leaverequestconversion objleaverequestconversion;
         objleaverequestconversion = new leaverequestconversion();
         objleaverequestconversion.context.SetSubmitInitialConfig(context);
         objleaverequestconversion.initialize();
         Submit( executePrivateCatch,objleaverequestconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((leaverequestconversion)stateInfo).executePrivate();
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
         /* Using cursor LEAVEREQUE2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = LEAVEREQUE2_A106EmployeeId[0];
            A134LeaveRequestRejectionReason = LEAVEREQUE2_A134LeaveRequestRejectionReason[0];
            A133LeaveRequestDescription = LEAVEREQUE2_A133LeaveRequestDescription[0];
            A132LeaveRequestStatus = LEAVEREQUE2_A132LeaveRequestStatus[0];
            A131LeaveRequestDuration = LEAVEREQUE2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = LEAVEREQUE2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = LEAVEREQUE2_A129LeaveRequestStartDate[0];
            A128LeaveRequestDate = LEAVEREQUE2_A128LeaveRequestDate[0];
            A124LeaveTypeId = LEAVEREQUE2_A124LeaveTypeId[0];
            A127LeaveRequestId = LEAVEREQUE2_A127LeaveRequestId[0];
            /*
               INSERT RECORD ON TABLE GXA0021

            */
            AV2LeaveRequestId = A127LeaveRequestId;
            AV3LeaveTypeId = A124LeaveTypeId;
            AV4LeaveRequestDate = A128LeaveRequestDate;
            AV5LeaveRequestStartDate = A129LeaveRequestStartDate;
            AV6LeaveRequestEndDate = A130LeaveRequestEndDate;
            AV7LeaveRequestDuration = (decimal)(A131LeaveRequestDuration);
            AV8LeaveRequestStatus = A132LeaveRequestStatus;
            AV9LeaveRequestDescription = A133LeaveRequestDescription;
            AV10LeaveRequestRejectionReason = A134LeaveRequestRejectionReason;
            AV11EmployeeId = A106EmployeeId;
            AV12LeaveRequestHalfDay = "";
            nV12LeaveRequestHalfDay = false;
            nV12LeaveRequestHalfDay = true;
            /* Using cursor LEAVEREQUE3 */
            pr_default.execute(1, new Object[] {AV2LeaveRequestId, AV3LeaveTypeId, AV4LeaveRequestDate, AV5LeaveRequestStartDate, AV6LeaveRequestEndDate, AV7LeaveRequestDuration, AV8LeaveRequestStatus, AV9LeaveRequestDescription, AV10LeaveRequestRejectionReason, AV11EmployeeId, nV12LeaveRequestHalfDay, AV12LeaveRequestHalfDay});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0021");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         scmdbuf = "";
         LEAVEREQUE2_A106EmployeeId = new long[1] ;
         LEAVEREQUE2_A134LeaveRequestRejectionReason = new string[] {""} ;
         LEAVEREQUE2_A133LeaveRequestDescription = new string[] {""} ;
         LEAVEREQUE2_A132LeaveRequestStatus = new string[] {""} ;
         LEAVEREQUE2_A131LeaveRequestDuration = new short[1] ;
         LEAVEREQUE2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         LEAVEREQUE2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         LEAVEREQUE2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         LEAVEREQUE2_A124LeaveTypeId = new long[1] ;
         LEAVEREQUE2_A127LeaveRequestId = new long[1] ;
         A134LeaveRequestRejectionReason = "";
         A133LeaveRequestDescription = "";
         A132LeaveRequestStatus = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A128LeaveRequestDate = DateTime.MinValue;
         AV4LeaveRequestDate = DateTime.MinValue;
         AV5LeaveRequestStartDate = DateTime.MinValue;
         AV6LeaveRequestEndDate = DateTime.MinValue;
         AV8LeaveRequestStatus = "";
         AV9LeaveRequestDescription = "";
         AV10LeaveRequestRejectionReason = "";
         AV12LeaveRequestHalfDay = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestconversion__default(),
            new Object[][] {
                new Object[] {
               LEAVEREQUE2_A106EmployeeId, LEAVEREQUE2_A134LeaveRequestRejectionReason, LEAVEREQUE2_A133LeaveRequestDescription, LEAVEREQUE2_A132LeaveRequestStatus, LEAVEREQUE2_A131LeaveRequestDuration, LEAVEREQUE2_A130LeaveRequestEndDate, LEAVEREQUE2_A129LeaveRequestStartDate, LEAVEREQUE2_A128LeaveRequestDate, LEAVEREQUE2_A124LeaveTypeId, LEAVEREQUE2_A127LeaveRequestId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A131LeaveRequestDuration ;
      private int GIGXA0021 ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV2LeaveRequestId ;
      private long AV3LeaveTypeId ;
      private long AV11EmployeeId ;
      private decimal AV7LeaveRequestDuration ;
      private string scmdbuf ;
      private string A132LeaveRequestStatus ;
      private string AV8LeaveRequestStatus ;
      private string AV12LeaveRequestHalfDay ;
      private string Gx_emsg ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A128LeaveRequestDate ;
      private DateTime AV4LeaveRequestDate ;
      private DateTime AV5LeaveRequestStartDate ;
      private DateTime AV6LeaveRequestEndDate ;
      private bool nV12LeaveRequestHalfDay ;
      private string A134LeaveRequestRejectionReason ;
      private string A133LeaveRequestDescription ;
      private string AV9LeaveRequestDescription ;
      private string AV10LeaveRequestRejectionReason ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] LEAVEREQUE2_A106EmployeeId ;
      private string[] LEAVEREQUE2_A134LeaveRequestRejectionReason ;
      private string[] LEAVEREQUE2_A133LeaveRequestDescription ;
      private string[] LEAVEREQUE2_A132LeaveRequestStatus ;
      private short[] LEAVEREQUE2_A131LeaveRequestDuration ;
      private DateTime[] LEAVEREQUE2_A130LeaveRequestEndDate ;
      private DateTime[] LEAVEREQUE2_A129LeaveRequestStartDate ;
      private DateTime[] LEAVEREQUE2_A128LeaveRequestDate ;
      private long[] LEAVEREQUE2_A124LeaveTypeId ;
      private long[] LEAVEREQUE2_A127LeaveRequestId ;
   }

   public class leaverequestconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmLEAVEREQUE2;
          prmLEAVEREQUE2 = new Object[] {
          };
          Object[] prmLEAVEREQUE3;
          prmLEAVEREQUE3 = new Object[] {
          new ParDef("AV2LeaveRequestId",GXType.Int64,10,0) ,
          new ParDef("AV3LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV4LeaveRequestDate",GXType.Date,8,0) ,
          new ParDef("AV5LeaveRequestStartDate",GXType.Date,8,0) ,
          new ParDef("AV6LeaveRequestEndDate",GXType.Date,8,0) ,
          new ParDef("AV7LeaveRequestDuration",GXType.Number,4,1) ,
          new ParDef("AV8LeaveRequestStatus",GXType.Char,20,0) ,
          new ParDef("AV9LeaveRequestDescription",GXType.VarChar,200,0) ,
          new ParDef("AV10LeaveRequestRejectionReason",GXType.VarChar,200,0) ,
          new ParDef("AV11EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV12LeaveRequestHalfDay",GXType.Char,20,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("LEAVEREQUE2", "SELECT EmployeeId, LeaveRequestRejectionReason, LeaveRequestDescription, LeaveRequestStatus, LeaveRequestDuration, LeaveRequestEndDate, LeaveRequestStartDate, LeaveRequestDate, LeaveTypeId, LeaveRequestId FROM LeaveRequest ORDER BY LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLEAVEREQUE2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LEAVEREQUE3", "INSERT INTO GXA0021(LeaveRequestId, LeaveTypeId, LeaveRequestDate, LeaveRequestStartDate, LeaveRequestEndDate, LeaveRequestDuration, LeaveRequestStatus, LeaveRequestDescription, LeaveRequestRejectionReason, EmployeeId, LeaveRequestHalfDay) VALUES(:AV2LeaveRequestId, :AV3LeaveTypeId, :AV4LeaveRequestDate, :AV5LeaveRequestStartDate, :AV6LeaveRequestEndDate, :AV7LeaveRequestDuration, :AV8LeaveRequestStatus, :AV9LeaveRequestDescription, :AV10LeaveRequestRejectionReason, :AV11EmployeeId, :AV12LeaveRequestHalfDay)", GxErrorMask.GX_NOMASK,prmLEAVEREQUE3)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
