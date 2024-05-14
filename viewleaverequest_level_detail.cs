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
   public class viewleaverequest_level_detail : GXDataGridProcedure
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

      public viewleaverequest_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public viewleaverequest_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId ,
                           int aP1_gxid ,
                           out SdtViewLeaveRequest_Level_DetailSdt aP2_GXM1ViewLeaveRequest_Level_DetailSdt )
      {
         this.A127LeaveRequestId = aP0_LeaveRequestId;
         this.AV29gxid = aP1_gxid;
         this.AV34GXM1ViewLeaveRequest_Level_DetailSdt = new SdtViewLeaveRequest_Level_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP2_GXM1ViewLeaveRequest_Level_DetailSdt=this.AV34GXM1ViewLeaveRequest_Level_DetailSdt;
      }

      public SdtViewLeaveRequest_Level_DetailSdt executeUdp( long aP0_LeaveRequestId ,
                                                             int aP1_gxid )
      {
         execute(aP0_LeaveRequestId, aP1_gxid, out aP2_GXM1ViewLeaveRequest_Level_DetailSdt);
         return AV34GXM1ViewLeaveRequest_Level_DetailSdt ;
      }

      public void executeSubmit( long aP0_LeaveRequestId ,
                                 int aP1_gxid ,
                                 out SdtViewLeaveRequest_Level_DetailSdt aP2_GXM1ViewLeaveRequest_Level_DetailSdt )
      {
         viewleaverequest_level_detail objviewleaverequest_level_detail;
         objviewleaverequest_level_detail = new viewleaverequest_level_detail();
         objviewleaverequest_level_detail.A127LeaveRequestId = aP0_LeaveRequestId;
         objviewleaverequest_level_detail.AV29gxid = aP1_gxid;
         objviewleaverequest_level_detail.AV34GXM1ViewLeaveRequest_Level_DetailSdt = new SdtViewLeaveRequest_Level_DetailSdt(context) ;
         objviewleaverequest_level_detail.context.SetSubmitInitialConfig(context);
         objviewleaverequest_level_detail.initialize();
         Submit( executePrivateCatch,objviewleaverequest_level_detail);
         aP2_GXM1ViewLeaveRequest_Level_DetailSdt=this.AV34GXM1ViewLeaveRequest_Level_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((viewleaverequest_level_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV29gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV20LeaveRequest = new SdtLeaveRequest(context);
            AV20LeaveRequest.Load(A127LeaveRequestId);
            AV20LeaveRequest.gxTpr_Leaverequestdate = Gx_date;
            AV26LeaveTypeId = AV20LeaveRequest.gxTpr_Leavetypeid;
            AV21LeaveRequestDate = AV20LeaveRequest.gxTpr_Leaverequestdate;
            AV25LeaveRequestStartDate = AV20LeaveRequest.gxTpr_Leaverequeststartdate;
            AV24LeaveRequestEndDate = AV20LeaveRequest.gxTpr_Leaverequestenddate;
            AV22LeaveRequestDescription = AV20LeaveRequest.gxTpr_Leaverequestdescription;
            AV23LeaveRequestDuration = AV20LeaveRequest.gxTpr_Leaverequestduration;
            AV28LeaveRejectionReason = AV20LeaveRequest.gxTpr_Leaverequestrejectionreason;
            Gxwebsession.Set(Gxids+"gxvar_Leaverequestdate", context.localUtil.DToC( AV21LeaveRequestDate, 1, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Leavetypeid", StringUtil.Str( (decimal)(AV26LeaveTypeId), 10, 0));
            Gxwebsession.Set(Gxids+"gxvar_Leaverequeststartdate", context.localUtil.DToC( AV25LeaveRequestStartDate, 1, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Leaverequestenddate", context.localUtil.DToC( AV24LeaveRequestEndDate, 1, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Leaverequestduration", StringUtil.Str( (decimal)(AV23LeaveRequestDuration), 4, 0));
            Gxwebsession.Set(Gxids+"gxvar_Leaverequestdescription", AV22LeaveRequestDescription);
            Gxwebsession.Set(Gxids+"gxvar_Leaverejectionreason", AV28LeaveRejectionReason);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV26LeaveTypeId = (long)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Leavetypeid"), "."), 18, MidpointRounding.ToEven));
            AV21LeaveRequestDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Leaverequestdate"), 1);
            AV25LeaveRequestStartDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Leaverequeststartdate"), 1);
            AV24LeaveRequestEndDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Leaverequestenddate"), 1);
            AV22LeaveRequestDescription = Gxwebsession.Get(Gxids+"gxvar_Leaverequestdescription");
            AV23LeaveRequestDuration = (short)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Leaverequestduration"), "."), 18, MidpointRounding.ToEven));
            AV28LeaveRejectionReason = Gxwebsession.Get(Gxids+"gxvar_Leaverejectionreason");
         }
         AV34GXM1ViewLeaveRequest_Level_DetailSdt.gxTpr_Leaverequestdate = AV21LeaveRequestDate;
         AV34GXM1ViewLeaveRequest_Level_DetailSdt.gxTpr_Leavetypeid = AV26LeaveTypeId;
         AV34GXM1ViewLeaveRequest_Level_DetailSdt.gxTpr_Leaverequeststartdate = AV25LeaveRequestStartDate;
         AV34GXM1ViewLeaveRequest_Level_DetailSdt.gxTpr_Leaverequestenddate = AV24LeaveRequestEndDate;
         AV34GXM1ViewLeaveRequest_Level_DetailSdt.gxTpr_Leaverequestduration = AV23LeaveRequestDuration;
         AV34GXM1ViewLeaveRequest_Level_DetailSdt.gxTpr_Leaverequestdescription = AV22LeaveRequestDescription;
         AV34GXM1ViewLeaveRequest_Level_DetailSdt.gxTpr_Leaverejectionreason = AV28LeaveRejectionReason;
         Gxval_leavetypeid = AV26LeaveTypeId;
         /* Execute user subroutine: Gxdesc_Leavetypeid */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV34GXM1ViewLeaveRequest_Level_DetailSdt.gxTpr_Gxdesc_leavetypeid = Gxdesc_leavetypeid;
         this.cleanup();
      }

      protected void S111( )
      {
         /* Gxdesc_Leavetypeid Routine */
         returnInSub = false;
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {Gxval_leavetypeid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00002_A124LeaveTypeId[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            Gxdesc_leavetypeid = A125LeaveTypeName;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         SetPaginationHeaders(((pr_default.getStatus(0) == 101) ? false : true));
         pr_default.close(0);
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
         AV34GXM1ViewLeaveRequest_Level_DetailSdt = new SdtViewLeaveRequest_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV20LeaveRequest = new SdtLeaveRequest(context);
         Gx_date = DateTime.MinValue;
         AV21LeaveRequestDate = DateTime.MinValue;
         AV25LeaveRequestStartDate = DateTime.MinValue;
         AV24LeaveRequestEndDate = DateTime.MinValue;
         AV22LeaveRequestDescription = "";
         AV28LeaveRejectionReason = "";
         Gxdesc_leavetypeid = "";
         scmdbuf = "";
         P00002_A124LeaveTypeId = new long[1] ;
         P00002_A125LeaveTypeName = new string[] {""} ;
         A125LeaveTypeName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.viewleaverequest_level_detail__default(),
            new Object[][] {
                new Object[] {
               P00002_A124LeaveTypeId, P00002_A125LeaveTypeName
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV23LeaveRequestDuration ;
      private int AV29gxid ;
      private long A127LeaveRequestId ;
      private long AV26LeaveTypeId ;
      private long Gxval_leavetypeid ;
      private long A124LeaveTypeId ;
      private string Gxids ;
      private string scmdbuf ;
      private string A125LeaveTypeName ;
      private DateTime Gx_date ;
      private DateTime AV21LeaveRequestDate ;
      private DateTime AV25LeaveRequestStartDate ;
      private DateTime AV24LeaveRequestEndDate ;
      private bool returnInSub ;
      private string AV22LeaveRequestDescription ;
      private string AV28LeaveRejectionReason ;
      private string Gxdesc_leavetypeid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A124LeaveTypeId ;
      private string[] P00002_A125LeaveTypeName ;
      private SdtViewLeaveRequest_Level_DetailSdt aP2_GXM1ViewLeaveRequest_Level_DetailSdt ;
      private IGxSession Gxwebsession ;
      private SdtLeaveRequest AV20LeaveRequest ;
      private SdtViewLeaveRequest_Level_DetailSdt AV34GXM1ViewLeaveRequest_Level_DetailSdt ;
   }

   public class viewleaverequest_level_detail__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00002;
          prmP00002 = new Object[] {
          new ParDef("Gxval_leavetypeid",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType WHERE LeaveTypeId = :Gxval_leavetypeid ORDER BY LeaveTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
