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
   public class aemployeeleavedetailsreport : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aemployeeleavedetailsreport().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

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

      public aemployeeleavedetailsreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aemployeeleavedetailsreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                           long aP3_CompanyLocationId ,
                           out GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection )
      {
         this.AV10FromDate = aP0_FromDate;
         this.AV11ToDate = aP1_ToDate;
         this.AV26EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV25CompanyLocationId = aP3_CompanyLocationId;
         this.AV19SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP4_SDTEmployeeLeaveDetailsCollection=this.AV19SDTEmployeeLeaveDetailsCollection;
      }

      public GXBaseCollection<SdtSDTEmployeeLeaveDetails> executeUdp( DateTime aP0_FromDate ,
                                                                      DateTime aP1_ToDate ,
                                                                      GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                                                      long aP3_CompanyLocationId )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_EmployeeIdCollection, aP3_CompanyLocationId, out aP4_SDTEmployeeLeaveDetailsCollection);
         return AV19SDTEmployeeLeaveDetailsCollection ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                 long aP3_CompanyLocationId ,
                                 out GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection )
      {
         this.AV10FromDate = aP0_FromDate;
         this.AV11ToDate = aP1_ToDate;
         this.AV26EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV25CompanyLocationId = aP3_CompanyLocationId;
         this.AV19SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4") ;
         SubmitImpl();
         aP4_SDTEmployeeLeaveDetailsCollection=this.AV19SDTEmployeeLeaveDetailsCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV26EmployeeIdCollection ,
                                              AV25CompanyLocationId ,
                                              A157CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00BQ2 */
         pr_default.execute(0, new Object[] {AV25CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00BQ2_A100CompanyId[0];
            A106EmployeeId = P00BQ2_A106EmployeeId[0];
            A157CompanyLocationId = P00BQ2_A157CompanyLocationId[0];
            A147EmployeeBalance = P00BQ2_A147EmployeeBalance[0];
            A148EmployeeName = P00BQ2_A148EmployeeName[0];
            A157CompanyLocationId = P00BQ2_A157CompanyLocationId[0];
            AV8EmployeeId = A106EmployeeId;
            AV18SDTEmployeeLeaveDetails = new SdtSDTEmployeeLeaveDetails(context);
            AV18SDTEmployeeLeaveDetails.gxTpr_Employeeid = A106EmployeeId;
            AV18SDTEmployeeLeaveDetails.gxTpr_Employeename = StringUtil.Trim( A148EmployeeName);
            AV18SDTEmployeeLeaveDetails.gxTpr_Employeebalance = A147EmployeeBalance;
            AV22LeaveRequestCount = 0;
            AV28GXLvl11 = 0;
            /* Using cursor P00BQ3 */
            pr_default.execute(1, new Object[] {AV11ToDate, AV10FromDate, AV8EmployeeId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106EmployeeId = P00BQ3_A106EmployeeId[0];
               A130LeaveRequestEndDate = P00BQ3_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = P00BQ3_A129LeaveRequestStartDate[0];
               A127LeaveRequestId = P00BQ3_A127LeaveRequestId[0];
               A124LeaveTypeId = P00BQ3_A124LeaveTypeId[0];
               A173LeaveRequestHalfDay = P00BQ3_A173LeaveRequestHalfDay[0];
               n173LeaveRequestHalfDay = P00BQ3_n173LeaveRequestHalfDay[0];
               A131LeaveRequestDuration = P00BQ3_A131LeaveRequestDuration[0];
               AV28GXLvl11 = 1;
               AV22LeaveRequestCount = (short)(AV22LeaveRequestCount+1);
               AV21LeaveRequestItem = new SdtSDTEmployeeLeaveDetails_LeaveRequestItem(context);
               AV21LeaveRequestItem.gxTpr_Leaverequestid = A127LeaveRequestId;
               AV21LeaveRequestItem.gxTpr_Leaverequeststartdate = A129LeaveRequestStartDate;
               AV21LeaveRequestItem.gxTpr_Leavetypeid = A124LeaveTypeId;
               GXt_char1 = "";
               new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "DD/MM/YYYY", out  GXt_char1) ;
               AV21LeaveRequestItem.gxTpr_Leaverequeststartdatestring = GXt_char1;
               if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10FromDate ) ) || ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV11ToDate ) ) )
               {
                  AV14LeaveRequestStartDate = A129LeaveRequestStartDate;
                  AV17LeaveRequestEndDate = A130LeaveRequestEndDate;
                  if ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10FromDate ) )
                  {
                     AV14LeaveRequestStartDate = AV10FromDate;
                  }
                  if ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV11ToDate ) )
                  {
                     AV17LeaveRequestEndDate = AV11ToDate;
                  }
                  GXt_decimal2 = AV13LeaveRequestDuration;
                  new prc_getleaverequestdays(context ).execute(  AV14LeaveRequestStartDate,  AV17LeaveRequestEndDate,  A173LeaveRequestHalfDay,  AV8EmployeeId, out  GXt_decimal2) ;
                  AV13LeaveRequestDuration = GXt_decimal2;
                  AV21LeaveRequestItem.gxTpr_Leaverequestduration = AV13LeaveRequestDuration;
               }
               else
               {
                  AV13LeaveRequestDuration = A131LeaveRequestDuration;
                  AV21LeaveRequestItem.gxTpr_Leaverequestduration = A131LeaveRequestDuration;
               }
               if ( AV22LeaveRequestCount == 1 )
               {
                  AV18SDTEmployeeLeaveDetails.gxTpr_Firstleaverequestid = A127LeaveRequestId;
                  AV18SDTEmployeeLeaveDetails.gxTpr_Firstleaverequeststartdate = A129LeaveRequestStartDate;
                  AV18SDTEmployeeLeaveDetails.gxTpr_Firstleaverequestduration = AV13LeaveRequestDuration;
                  AV18SDTEmployeeLeaveDetails.gxTpr_Firstleavetypeid = A124LeaveTypeId;
                  GXt_char1 = "";
                  new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "DD/MM/YYYY", out  GXt_char1) ;
                  AV18SDTEmployeeLeaveDetails.gxTpr_Firstleaverequeststartdatestring = GXt_char1;
               }
               else
               {
                  AV18SDTEmployeeLeaveDetails.gxTpr_Leaverequest.Add(AV21LeaveRequestItem, 0);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV28GXLvl11 == 0 )
            {
               AV22LeaveRequestCount = 1;
            }
            AV18SDTEmployeeLeaveDetails.gxTpr_Leaverequestcount = AV22LeaveRequestCount;
            if ( ! (0==AV18SDTEmployeeLeaveDetails.gxTpr_Firstleaverequestid) )
            {
               AV19SDTEmployeeLeaveDetailsCollection.Add(AV18SDTEmployeeLeaveDetails, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV19SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4");
         P00BQ2_A100CompanyId = new long[1] ;
         P00BQ2_A106EmployeeId = new long[1] ;
         P00BQ2_A157CompanyLocationId = new long[1] ;
         P00BQ2_A147EmployeeBalance = new decimal[1] ;
         P00BQ2_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV18SDTEmployeeLeaveDetails = new SdtSDTEmployeeLeaveDetails(context);
         P00BQ3_A106EmployeeId = new long[1] ;
         P00BQ3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BQ3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BQ3_A127LeaveRequestId = new long[1] ;
         P00BQ3_A124LeaveTypeId = new long[1] ;
         P00BQ3_A173LeaveRequestHalfDay = new string[] {""} ;
         P00BQ3_n173LeaveRequestHalfDay = new bool[] {false} ;
         P00BQ3_A131LeaveRequestDuration = new decimal[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A173LeaveRequestHalfDay = "";
         AV21LeaveRequestItem = new SdtSDTEmployeeLeaveDetails_LeaveRequestItem(context);
         AV14LeaveRequestStartDate = DateTime.MinValue;
         AV17LeaveRequestEndDate = DateTime.MinValue;
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavedetailsreport__default(),
            new Object[][] {
                new Object[] {
               P00BQ2_A100CompanyId, P00BQ2_A106EmployeeId, P00BQ2_A157CompanyLocationId, P00BQ2_A147EmployeeBalance, P00BQ2_A148EmployeeName
               }
               , new Object[] {
               P00BQ3_A106EmployeeId, P00BQ3_A130LeaveRequestEndDate, P00BQ3_A129LeaveRequestStartDate, P00BQ3_A127LeaveRequestId, P00BQ3_A124LeaveTypeId, P00BQ3_A173LeaveRequestHalfDay, P00BQ3_n173LeaveRequestHalfDay, P00BQ3_A131LeaveRequestDuration
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22LeaveRequestCount ;
      private short AV28GXLvl11 ;
      private long AV25CompanyLocationId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long AV8EmployeeId ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private decimal A147EmployeeBalance ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV13LeaveRequestDuration ;
      private decimal GXt_decimal2 ;
      private string A148EmployeeName ;
      private string A173LeaveRequestHalfDay ;
      private string GXt_char1 ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime AV14LeaveRequestStartDate ;
      private DateTime AV17LeaveRequestEndDate ;
      private bool n173LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV26EmployeeIdCollection ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> AV19SDTEmployeeLeaveDetailsCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00BQ2_A100CompanyId ;
      private long[] P00BQ2_A106EmployeeId ;
      private long[] P00BQ2_A157CompanyLocationId ;
      private decimal[] P00BQ2_A147EmployeeBalance ;
      private string[] P00BQ2_A148EmployeeName ;
      private SdtSDTEmployeeLeaveDetails AV18SDTEmployeeLeaveDetails ;
      private long[] P00BQ3_A106EmployeeId ;
      private DateTime[] P00BQ3_A130LeaveRequestEndDate ;
      private DateTime[] P00BQ3_A129LeaveRequestStartDate ;
      private long[] P00BQ3_A127LeaveRequestId ;
      private long[] P00BQ3_A124LeaveTypeId ;
      private string[] P00BQ3_A173LeaveRequestHalfDay ;
      private bool[] P00BQ3_n173LeaveRequestHalfDay ;
      private decimal[] P00BQ3_A131LeaveRequestDuration ;
      private SdtSDTEmployeeLeaveDetails_LeaveRequestItem AV21LeaveRequestItem ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection ;
   }

   public class aemployeeleavedetailsreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BQ2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV26EmployeeIdCollection ,
                                             long AV25CompanyLocationId ,
                                             long A157CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId, T1.EmployeeBalance, T1.EmployeeName FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV26EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         if ( ! (0==AV25CompanyLocationId) )
         {
            AddWhere(sWhereString, "(T2.CompanyLocationId = :AV25CompanyLocationId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BQ2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00BQ3;
          prmP00BQ3 = new Object[] {
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00BQ2;
          prmP00BQ2 = new Object[] {
          new ParDef("AV25CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BQ3", "SELECT EmployeeId, LeaveRequestEndDate, LeaveRequestStartDate, LeaveRequestId, LeaveTypeId, LeaveRequestHalfDay, LeaveRequestDuration FROM LeaveRequest WHERE (( LeaveRequestStartDate < :AV11ToDate and LeaveRequestEndDate > :AV10FromDate)) AND (EmployeeId = :AV8EmployeeId) ORDER BY LeaveRequestStartDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ3,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                return;
       }
    }

 }

}
