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
   public class getworkhourlogdurationbyproject : GXProcedure
   {
      public getworkhourlogdurationbyproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getworkhourlogdurationbyproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate ,
                           ref GxSimpleCollection<long> aP2_ProjectId ,
                           ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP4_EmployeeId ,
                           ref GxSimpleCollection<long> aP5_ProjectIds ,
                           out GXBaseCollection<SdtSDTProject> aP6_SDTProjects )
      {
         this.AV12FromDate = aP0_FromDate;
         this.AV11ToDate = aP1_ToDate;
         this.AV13ProjectId = aP2_ProjectId;
         this.AV8CompanyLocationId = aP3_CompanyLocationId;
         this.AV15EmployeeId = aP4_EmployeeId;
         this.AV23ProjectIds = aP5_ProjectIds;
         this.AV21SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV12FromDate;
         aP1_ToDate=this.AV11ToDate;
         aP2_ProjectId=this.AV13ProjectId;
         aP3_CompanyLocationId=this.AV8CompanyLocationId;
         aP4_EmployeeId=this.AV15EmployeeId;
         aP5_ProjectIds=this.AV23ProjectIds;
         aP6_SDTProjects=this.AV21SDTProjects;
      }

      public GXBaseCollection<SdtSDTProject> executeUdp( ref DateTime aP0_FromDate ,
                                                         ref DateTime aP1_ToDate ,
                                                         ref GxSimpleCollection<long> aP2_ProjectId ,
                                                         ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                                         ref GxSimpleCollection<long> aP4_EmployeeId ,
                                                         ref GxSimpleCollection<long> aP5_ProjectIds )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, ref aP2_ProjectId, ref aP3_CompanyLocationId, ref aP4_EmployeeId, ref aP5_ProjectIds, out aP6_SDTProjects);
         return AV21SDTProjects ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 ref GxSimpleCollection<long> aP2_ProjectId ,
                                 ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP4_EmployeeId ,
                                 ref GxSimpleCollection<long> aP5_ProjectIds ,
                                 out GXBaseCollection<SdtSDTProject> aP6_SDTProjects )
      {
         getworkhourlogdurationbyproject objgetworkhourlogdurationbyproject;
         objgetworkhourlogdurationbyproject = new getworkhourlogdurationbyproject();
         objgetworkhourlogdurationbyproject.AV12FromDate = aP0_FromDate;
         objgetworkhourlogdurationbyproject.AV11ToDate = aP1_ToDate;
         objgetworkhourlogdurationbyproject.AV13ProjectId = aP2_ProjectId;
         objgetworkhourlogdurationbyproject.AV8CompanyLocationId = aP3_CompanyLocationId;
         objgetworkhourlogdurationbyproject.AV15EmployeeId = aP4_EmployeeId;
         objgetworkhourlogdurationbyproject.AV23ProjectIds = aP5_ProjectIds;
         objgetworkhourlogdurationbyproject.AV21SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4") ;
         objgetworkhourlogdurationbyproject.context.SetSubmitInitialConfig(context);
         objgetworkhourlogdurationbyproject.initialize();
         Submit( executePrivateCatch,objgetworkhourlogdurationbyproject);
         aP0_FromDate=this.AV12FromDate;
         aP1_ToDate=this.AV11ToDate;
         aP2_ProjectId=this.AV13ProjectId;
         aP3_CompanyLocationId=this.AV8CompanyLocationId;
         aP4_EmployeeId=this.AV15EmployeeId;
         aP5_ProjectIds=this.AV23ProjectIds;
         aP6_SDTProjects=this.AV21SDTProjects;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getworkhourlogdurationbyproject)stateInfo).executePrivate();
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
         AV10total = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV8CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor P008V2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A157CompanyLocationId = P008V2_A157CompanyLocationId[0];
            /* Using cursor P008V3 */
            pr_default.execute(1, new Object[] {A157CompanyLocationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A100CompanyId = P008V3_A100CompanyId[0];
               /* Using cursor P008V4 */
               pr_default.execute(2, new Object[] {A100CompanyId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A106EmployeeId = P008V4_A106EmployeeId[0];
                  AV15EmployeeId.Add(A106EmployeeId, 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV16StringEmployeeId = AV15EmployeeId.ToJSonString(false);
         AV17IsEmployeeIdEmpty = ((AV15EmployeeId.Count==0) ? true : false);
         AV18IsCompanyLocationIdEmpty = ((AV8CompanyLocationId.Count==0) ? true : false);
         AV28Dsworkhourlogs_1_companylocationid = AV8CompanyLocationId;
         AV29Dsworkhourlogs_2_employeeid = AV15EmployeeId;
         AV28Dsworkhourlogs_1_companylocationid = AV8CompanyLocationId;
         AV29Dsworkhourlogs_2_employeeid = AV15EmployeeId;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV8CompanyLocationId ,
                                              A106EmployeeId ,
                                              AV15EmployeeId ,
                                              A102ProjectId ,
                                              AV13ProjectId ,
                                              AV23ProjectIds ,
                                              AV28Dsworkhourlogs_1_companylocationid ,
                                              AV29Dsworkhourlogs_2_employeeid ,
                                              AV8CompanyLocationId.Count ,
                                              AV15EmployeeId.Count ,
                                              AV13ProjectId.Count ,
                                              AV23ProjectIds.Count ,
                                              AV12FromDate ,
                                              AV11ToDate ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P008V6 */
         pr_default.execute(3, new Object[] {AV12FromDate, AV12FromDate, AV11ToDate, AV11ToDate, AV18IsCompanyLocationIdEmpty, AV17IsEmployeeIdEmpty, AV12FromDate, AV11ToDate});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A100CompanyId = P008V6_A100CompanyId[0];
            A119WorkHourLogDate = P008V6_A119WorkHourLogDate[0];
            A102ProjectId = P008V6_A102ProjectId[0];
            n102ProjectId = P008V6_n102ProjectId[0];
            A106EmployeeId = P008V6_A106EmployeeId[0];
            A157CompanyLocationId = P008V6_A157CompanyLocationId[0];
            A103ProjectName = P008V6_A103ProjectName[0];
            A40000GXC1 = P008V6_A40000GXC1[0];
            n40000GXC1 = P008V6_n40000GXC1[0];
            A40001GXC2 = P008V6_A40001GXC2[0];
            n40001GXC2 = P008V6_n40001GXC2[0];
            A103ProjectName = P008V6_A103ProjectName[0];
            A40000GXC1 = P008V6_A40000GXC1[0];
            n40000GXC1 = P008V6_n40000GXC1[0];
            A40001GXC2 = P008V6_A40001GXC2[0];
            n40001GXC2 = P008V6_n40001GXC2[0];
            A100CompanyId = P008V6_A100CompanyId[0];
            A157CompanyLocationId = P008V6_A157CompanyLocationId[0];
            AV10total = (long)(A40000GXC1*60+A40001GXC2);
            AV22SDTProject = new SdtSDTProject(context);
            AV22SDTProject.gxTpr_Projectname = A103ProjectName;
            AV22SDTProject.gxTpr_Projecttime = AV10total;
            GXt_char1 = "";
            new procformattime(context ).execute(  AV10total, out  GXt_char1) ;
            AV22SDTProject.gxTpr_Projectformattedtime = GXt_char1;
            AV21SDTProjects.Add(AV22SDTProject, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
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
         AV21SDTProjects = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         scmdbuf = "";
         P008V2_A157CompanyLocationId = new long[1] ;
         P008V3_A157CompanyLocationId = new long[1] ;
         P008V3_A100CompanyId = new long[1] ;
         P008V4_A100CompanyId = new long[1] ;
         P008V4_A106EmployeeId = new long[1] ;
         AV16StringEmployeeId = "";
         AV28Dsworkhourlogs_1_companylocationid = new GxSimpleCollection<long>();
         AV29Dsworkhourlogs_2_employeeid = new GxSimpleCollection<long>();
         A119WorkHourLogDate = DateTime.MinValue;
         P008V6_A100CompanyId = new long[1] ;
         P008V6_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P008V6_A102ProjectId = new long[1] ;
         P008V6_n102ProjectId = new bool[] {false} ;
         P008V6_A106EmployeeId = new long[1] ;
         P008V6_A157CompanyLocationId = new long[1] ;
         P008V6_A103ProjectName = new string[] {""} ;
         P008V6_A40000GXC1 = new short[1] ;
         P008V6_n40000GXC1 = new bool[] {false} ;
         P008V6_A40001GXC2 = new short[1] ;
         P008V6_n40001GXC2 = new bool[] {false} ;
         A103ProjectName = "";
         AV22SDTProject = new SdtSDTProject(context);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getworkhourlogdurationbyproject__default(),
            new Object[][] {
                new Object[] {
               P008V2_A157CompanyLocationId
               }
               , new Object[] {
               P008V3_A157CompanyLocationId, P008V3_A100CompanyId
               }
               , new Object[] {
               P008V4_A100CompanyId, P008V4_A106EmployeeId
               }
               , new Object[] {
               P008V6_A100CompanyId, P008V6_A119WorkHourLogDate, P008V6_A102ProjectId, P008V6_n102ProjectId, P008V6_A106EmployeeId, P008V6_A157CompanyLocationId, P008V6_A103ProjectName, P008V6_A40000GXC1, P008V6_n40000GXC1, P008V6_A40001GXC2,
               P008V6_n40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private int AV8CompanyLocationId_Count ;
      private int AV15EmployeeId_Count ;
      private int AV13ProjectId_Count ;
      private int AV23ProjectIds_Count ;
      private long AV10total ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private string scmdbuf ;
      private string A103ProjectName ;
      private string GXt_char1 ;
      private DateTime AV12FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool AV17IsEmployeeIdEmpty ;
      private bool AV18IsCompanyLocationIdEmpty ;
      private bool n102ProjectId ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private string AV16StringEmployeeId ;
      private GxSimpleCollection<long> AV13ProjectId ;
      private GxSimpleCollection<long> AV8CompanyLocationId ;
      private GxSimpleCollection<long> AV15EmployeeId ;
      private GxSimpleCollection<long> AV23ProjectIds ;
      private GxSimpleCollection<long> AV28Dsworkhourlogs_1_companylocationid ;
      private GxSimpleCollection<long> AV29Dsworkhourlogs_2_employeeid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> aP2_ProjectId ;
      private GxSimpleCollection<long> aP3_CompanyLocationId ;
      private GxSimpleCollection<long> aP4_EmployeeId ;
      private GxSimpleCollection<long> aP5_ProjectIds ;
      private IDataStoreProvider pr_default ;
      private long[] P008V2_A157CompanyLocationId ;
      private long[] P008V3_A157CompanyLocationId ;
      private long[] P008V3_A100CompanyId ;
      private long[] P008V4_A100CompanyId ;
      private long[] P008V4_A106EmployeeId ;
      private long[] P008V6_A100CompanyId ;
      private DateTime[] P008V6_A119WorkHourLogDate ;
      private long[] P008V6_A102ProjectId ;
      private bool[] P008V6_n102ProjectId ;
      private long[] P008V6_A106EmployeeId ;
      private long[] P008V6_A157CompanyLocationId ;
      private string[] P008V6_A103ProjectName ;
      private short[] P008V6_A40000GXC1 ;
      private bool[] P008V6_n40000GXC1 ;
      private short[] P008V6_A40001GXC2 ;
      private bool[] P008V6_n40001GXC2 ;
      private GXBaseCollection<SdtSDTProject> aP6_SDTProjects ;
      private GXBaseCollection<SdtSDTProject> AV21SDTProjects ;
      private SdtSDTProject AV22SDTProject ;
   }

   public class getworkhourlogdurationbyproject__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008V2( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV8CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CompanyLocationId FROM CompanyLocation";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8CompanyLocationId, "CompanyLocationId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationId";
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008V6( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV8CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV15EmployeeId ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV13ProjectId ,
                                             GxSimpleCollection<long> AV23ProjectIds ,
                                             GxSimpleCollection<long> AV28Dsworkhourlogs_1_companylocationid ,
                                             GxSimpleCollection<long> AV29Dsworkhourlogs_2_employeeid ,
                                             int AV8CompanyLocationId_Count ,
                                             int AV15EmployeeId_Count ,
                                             int AV13ProjectId_Count ,
                                             int AV23ProjectIds_Count ,
                                             DateTime AV12FromDate ,
                                             DateTime AV11ToDate ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[8];
         Object[] GXv_Object5 = new Object[2];
         string sRef1;
         sRef1 = (string)(new GxDbmsUtils( new GxPostgreSql()).ValueList(AV29Dsworkhourlogs_2_employeeid, "T6.EmployeeId"+" IN (", ")"));
         string sRef2;
         sRef2 = (string)(new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28Dsworkhourlogs_1_companylocationid, "T8.CompanyLocationId"+" IN (", ")"));
         scmdbuf = "SELECT DISTINCT NULL AS CompanyId, NULL AS WorkHourLogDate, ProjectId, NULL AS EmployeeId, NULL AS CompanyLocationId, ProjectName, GXC1, GXC2 FROM ( SELECT T4.CompanyId, T1.WorkHourLogDate, T1.ProjectId, T1.EmployeeId, T5.CompanyLocationId, T2.ProjectName, COALESCE( T3.GXC1, 0) AS GXC1, COALESCE( T3.GXC2, 0) AS GXC2 FROM ((((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) LEFT JOIN LATERAL (SELECT SUM(T6.WorkHourLogHour) AS GXC1, T6.ProjectId, T9.ProjectName, SUM(T6.WorkHourLogMinute) AS GXC2 FROM (((WorkHourLog T6 INNER JOIN Employee T7 ON T7.EmployeeId = T6.EmployeeId) INNER JOIN Company T8 ON T8.CompanyId = T7.CompanyId) INNER JOIN Project T9 ON T9.ProjectId = T6.ProjectId) WHERE (T1.ProjectId = T6.ProjectId and T2.ProjectName = ( T9.ProjectName)) AND (( (:AV12FromDate = DATE '00010101') or ( T6.WorkHourLogDate >= :AV12FromDate)) and ( (:AV11ToDate = DATE '00010101') or ( T6.WorkHourLogDate <= :AV11ToDate)) and ( :AV18IsCompanyLocationIdEmpty or ( ";
         scmdbuf += sRef2;
         scmdbuf += ")) and ( :AV17IsEmployeeIdEmpty or ( ";
         scmdbuf += sRef1;
         scmdbuf += "))) GROUP BY T6.ProjectId, T9.ProjectName ) T3 ON T3.ProjectId = T1.ProjectId AND T3.ProjectName = T2.ProjectName) INNER JOIN Employee T4 ON T4.EmployeeId = T1.EmployeeId) INNER JOIN Company T5 ON T5.CompanyId = T4.CompanyId)";
         if ( AV8CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8CompanyLocationId, "T5.CompanyLocationId IN (", ")")+")");
         }
         if ( AV15EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV15EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV13ProjectId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13ProjectId, "T1.ProjectId IN (", ")")+")");
         }
         if ( AV23ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV23ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV12FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV12FromDate)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV11ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV11ToDate)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ProjectName";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY ProjectName";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008V2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 3 :
                     return conditional_P008V6(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (GxSimpleCollection<long>)dynConstraints[5] , (GxSimpleCollection<long>)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (GxSimpleCollection<long>)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008V3;
          prmP008V3 = new Object[] {
          new ParDef("CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP008V4;
          prmP008V4 = new Object[] {
          new ParDef("CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP008V2;
          prmP008V2 = new Object[] {
          };
          Object[] prmP008V6;
          prmP008V6 = new Object[] {
          new ParDef("AV12FromDate",GXType.Date,8,0) ,
          new ParDef("AV12FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV18IsCompanyLocationIdEmpty",GXType.Boolean,4,0) ,
          new ParDef("AV17IsEmployeeIdEmpty",GXType.Boolean,4,0) ,
          new ParDef("AV12FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V3", "SELECT CompanyLocationId, CompanyId FROM Company WHERE CompanyLocationId = :CompanyLocationId ORDER BY CompanyLocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V4", "SELECT CompanyId, EmployeeId FROM Employee WHERE CompanyId = :CompanyId ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V6,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
