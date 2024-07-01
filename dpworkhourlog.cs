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
   public class dpworkhourlog : GXProcedure
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

      public dpworkhourlog( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpworkhourlog( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           GxSimpleCollection<long> aP3_ProjectIds ,
                           out GXBaseCollection<SdtSDTWorkHourLog_SDTWorkHourLogItem> aP4_Gxm2rootcol )
      {
         this.AV6EmployeeId = aP0_EmployeeId;
         this.AV7FromDate = aP1_FromDate;
         this.AV5ToDate = aP2_ToDate;
         this.AV9ProjectIds = aP3_ProjectIds;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTWorkHourLog_SDTWorkHourLogItem>( context, "SDTWorkHourLogItem", "YTT_version4") ;
         initialize();
         executePrivate();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTWorkHourLog_SDTWorkHourLogItem> executeUdp( long aP0_EmployeeId ,
                                                                                DateTime aP1_FromDate ,
                                                                                DateTime aP2_ToDate ,
                                                                                GxSimpleCollection<long> aP3_ProjectIds )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, aP3_ProjectIds, out aP4_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 GxSimpleCollection<long> aP3_ProjectIds ,
                                 out GXBaseCollection<SdtSDTWorkHourLog_SDTWorkHourLogItem> aP4_Gxm2rootcol )
      {
         dpworkhourlog objdpworkhourlog;
         objdpworkhourlog = new dpworkhourlog();
         objdpworkhourlog.AV6EmployeeId = aP0_EmployeeId;
         objdpworkhourlog.AV7FromDate = aP1_FromDate;
         objdpworkhourlog.AV5ToDate = aP2_ToDate;
         objdpworkhourlog.AV9ProjectIds = aP3_ProjectIds;
         objdpworkhourlog.Gxm2rootcol = new GXBaseCollection<SdtSDTWorkHourLog_SDTWorkHourLogItem>( context, "SDTWorkHourLogItem", "YTT_version4") ;
         objdpworkhourlog.context.SetSubmitInitialConfig(context);
         objdpworkhourlog.initialize();
         Submit( executePrivateCatch,objdpworkhourlog);
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpworkhourlog)stateInfo).executePrivate();
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV9ProjectIds ,
                                              AV9ProjectIds.Count ,
                                              A119WorkHourLogDate ,
                                              AV5ToDate ,
                                              AV7FromDate ,
                                              AV6EmployeeId ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P001P2 */
         pr_default.execute(0, new Object[] {AV6EmployeeId, AV5ToDate, AV7FromDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P001P2_A106EmployeeId[0];
            A119WorkHourLogDate = P001P2_A119WorkHourLogDate[0];
            A102ProjectId = P001P2_A102ProjectId[0];
            A118WorkHourLogId = P001P2_A118WorkHourLogId[0];
            A120WorkHourLogDuration = P001P2_A120WorkHourLogDuration[0];
            A121WorkHourLogHour = P001P2_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = P001P2_A122WorkHourLogMinute[0];
            A123WorkHourLogDescription = P001P2_A123WorkHourLogDescription[0];
            A148EmployeeName = P001P2_A148EmployeeName[0];
            A103ProjectName = P001P2_A103ProjectName[0];
            A148EmployeeName = P001P2_A148EmployeeName[0];
            A103ProjectName = P001P2_A103ProjectName[0];
            Gxm1sdtworkhourlog = new SdtSDTWorkHourLog_SDTWorkHourLogItem(context);
            Gxm2rootcol.Add(Gxm1sdtworkhourlog, 0);
            Gxm1sdtworkhourlog.gxTpr_Workhourlogid = A118WorkHourLogId;
            Gxm1sdtworkhourlog.gxTpr_Workhourlogdate = A119WorkHourLogDate;
            Gxm1sdtworkhourlog.gxTpr_Workhourlogduration = A120WorkHourLogDuration;
            Gxm1sdtworkhourlog.gxTpr_Workhourloghour = A121WorkHourLogHour;
            Gxm1sdtworkhourlog.gxTpr_Workhourlogminute = A122WorkHourLogMinute;
            Gxm1sdtworkhourlog.gxTpr_Workhourlogdescription = A123WorkHourLogDescription;
            Gxm1sdtworkhourlog.gxTpr_Employeeid = A106EmployeeId;
            Gxm1sdtworkhourlog.gxTpr_Employeename = A148EmployeeName;
            Gxm1sdtworkhourlog.gxTpr_Projectid = A102ProjectId;
            Gxm1sdtworkhourlog.gxTpr_Projectname = A103ProjectName;
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
         A119WorkHourLogDate = DateTime.MinValue;
         P001P2_A106EmployeeId = new long[1] ;
         P001P2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P001P2_A102ProjectId = new long[1] ;
         P001P2_A118WorkHourLogId = new long[1] ;
         P001P2_A120WorkHourLogDuration = new string[] {""} ;
         P001P2_A121WorkHourLogHour = new short[1] ;
         P001P2_A122WorkHourLogMinute = new short[1] ;
         P001P2_A123WorkHourLogDescription = new string[] {""} ;
         P001P2_A148EmployeeName = new string[] {""} ;
         P001P2_A103ProjectName = new string[] {""} ;
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A148EmployeeName = "";
         A103ProjectName = "";
         Gxm1sdtworkhourlog = new SdtSDTWorkHourLog_SDTWorkHourLogItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpworkhourlog__default(),
            new Object[][] {
                new Object[] {
               P001P2_A106EmployeeId, P001P2_A119WorkHourLogDate, P001P2_A102ProjectId, P001P2_A118WorkHourLogId, P001P2_A120WorkHourLogDuration, P001P2_A121WorkHourLogHour, P001P2_A122WorkHourLogMinute, P001P2_A123WorkHourLogDescription, P001P2_A148EmployeeName, P001P2_A103ProjectName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private int AV9ProjectIds_Count ;
      private long AV6EmployeeId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string scmdbuf ;
      private string A148EmployeeName ;
      private string A103ProjectName ;
      private DateTime AV7FromDate ;
      private DateTime AV5ToDate ;
      private DateTime A119WorkHourLogDate ;
      private string A123WorkHourLogDescription ;
      private string A120WorkHourLogDuration ;
      private GxSimpleCollection<long> AV9ProjectIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P001P2_A106EmployeeId ;
      private DateTime[] P001P2_A119WorkHourLogDate ;
      private long[] P001P2_A102ProjectId ;
      private long[] P001P2_A118WorkHourLogId ;
      private string[] P001P2_A120WorkHourLogDuration ;
      private short[] P001P2_A121WorkHourLogHour ;
      private short[] P001P2_A122WorkHourLogMinute ;
      private string[] P001P2_A123WorkHourLogDescription ;
      private string[] P001P2_A148EmployeeName ;
      private string[] P001P2_A103ProjectName ;
      private GXBaseCollection<SdtSDTWorkHourLog_SDTWorkHourLogItem> aP4_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTWorkHourLog_SDTWorkHourLogItem> Gxm2rootcol ;
      private SdtSDTWorkHourLog_SDTWorkHourLogItem Gxm1sdtworkhourlog ;
   }

   public class dpworkhourlog__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001P2( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV9ProjectIds ,
                                             int AV9ProjectIds_Count ,
                                             DateTime A119WorkHourLogDate ,
                                             DateTime AV5ToDate ,
                                             DateTime AV7FromDate ,
                                             long AV6EmployeeId ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.WorkHourLogDate, T1.ProjectId, T1.WorkHourLogId, T1.WorkHourLogDuration, T1.WorkHourLogHour, T1.WorkHourLogMinute, T1.WorkHourLogDescription, T2.EmployeeName, T3.ProjectName FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV6EmployeeId)");
         AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV5ToDate)");
         AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV7FromDate)");
         if ( AV9ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV9ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P001P2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP001P2;
          prmP001P2 = new Object[] {
          new ParDef("AV6EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV5ToDate",GXType.Date,8,0) ,
          new ParDef("AV7FromDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001P2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 128);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                return;
       }
    }

 }

}
