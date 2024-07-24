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
   public class aexporticsleaves : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new aexporticsleaves().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
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

      public aexporticsleaves( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aexporticsleaves( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           long aP2_CompanyLocationId ,
                           GxSimpleCollection<long> aP3_EmployeeIds ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV16FromDate = aP0_FromDate;
         this.AV15ToDate = aP1_ToDate;
         this.AV17CompanyLocationId = aP2_CompanyLocationId;
         this.AV11EmployeeIds = aP3_EmployeeIds;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP4_Filename=this.AV12Filename;
         aP5_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( DateTime aP0_FromDate ,
                                DateTime aP1_ToDate ,
                                long aP2_CompanyLocationId ,
                                GxSimpleCollection<long> aP3_EmployeeIds ,
                                out string aP4_Filename )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_CompanyLocationId, aP3_EmployeeIds, out aP4_Filename, out aP5_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 long aP2_CompanyLocationId ,
                                 GxSimpleCollection<long> aP3_EmployeeIds ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         aexporticsleaves objaexporticsleaves;
         objaexporticsleaves = new aexporticsleaves();
         objaexporticsleaves.AV16FromDate = aP0_FromDate;
         objaexporticsleaves.AV15ToDate = aP1_ToDate;
         objaexporticsleaves.AV17CompanyLocationId = aP2_CompanyLocationId;
         objaexporticsleaves.AV11EmployeeIds = aP3_EmployeeIds;
         objaexporticsleaves.AV12Filename = "" ;
         objaexporticsleaves.AV13ErrorMessage = "" ;
         objaexporticsleaves.context.SetSubmitInitialConfig(context);
         objaexporticsleaves.initialize();
         Submit( executePrivateCatch,objaexporticsleaves);
         aP4_Filename=this.AV12Filename;
         aP5_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aexporticsleaves)stateInfo).executePrivate();
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
         AV12Filename = "LeaveRequests.ics";
         AV8File.Source = AV12Filename;
         AV8File.Delete();
         AV8File.Open("");
         AV9Lines.Add("BEGIN:VCALENDAR", 0);
         AV9Lines.Add("PRODID:-//Yukon Software//APiCalConverter//EN", 0);
         AV9Lines.Add("VERSION:2.0", 0);
         AV9Lines.Add("CALSCALE:GREGORIAN", 0);
         AV9Lines.Add("X-WR-TIMEZONE:Europe/Bucharest", 0);
         AV9Lines.Add("X-WR-CALNAME:Absence", 0);
         AV9Lines.Add("X-WR-CALDESC:", 0);
         AV9Lines.Add("METHOD:PUBLISH", 0);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV11EmployeeIds ,
                                              AV17CompanyLocationId ,
                                              AV11EmployeeIds.Count ,
                                              A157CompanyLocationId ,
                                              A129LeaveRequestStartDate ,
                                              AV15ToDate ,
                                              A130LeaveRequestEndDate ,
                                              AV16FromDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00BI2 */
         pr_default.execute(0, new Object[] {AV15ToDate, AV16FromDate, AV17CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00BI2_A124LeaveTypeId[0];
            A100CompanyId = P00BI2_A100CompanyId[0];
            A106EmployeeId = P00BI2_A106EmployeeId[0];
            A130LeaveRequestEndDate = P00BI2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00BI2_A129LeaveRequestStartDate[0];
            A157CompanyLocationId = P00BI2_A157CompanyLocationId[0];
            A128LeaveRequestDate = P00BI2_A128LeaveRequestDate[0];
            A125LeaveTypeName = P00BI2_A125LeaveTypeName[0];
            A148EmployeeName = P00BI2_A148EmployeeName[0];
            A109EmployeeEmail = P00BI2_A109EmployeeEmail[0];
            A127LeaveRequestId = P00BI2_A127LeaveRequestId[0];
            A100CompanyId = P00BI2_A100CompanyId[0];
            A125LeaveTypeName = P00BI2_A125LeaveTypeName[0];
            A157CompanyLocationId = P00BI2_A157CompanyLocationId[0];
            A148EmployeeName = P00BI2_A148EmployeeName[0];
            A109EmployeeEmail = P00BI2_A109EmployeeEmail[0];
            AV9Lines.Add("BEGIN:VEVENT", 0);
            AV9Lines.Add("DTSTAMP:"+new formatdatetime(context).executeUdp(  A128LeaveRequestDate,  "YYYYMMDD")+"T000000Z", 0);
            AV9Lines.Add("DTSTART;VALUE=DATE:"+new formatdatetime(context).executeUdp(  A129LeaveRequestStartDate,  "YYYYMMDD"), 0);
            AV9Lines.Add("DTEND;VALUE=DATE:"+new formatdatetime(context).executeUdp(  A130LeaveRequestEndDate,  "YYYYMMDD"), 0);
            AV9Lines.Add("SUMMARY:"+StringUtil.Trim( A148EmployeeName)+" | "+StringUtil.Trim( A125LeaveTypeName), 0);
            AV9Lines.Add("UID:"+StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0))+StringUtil.Trim( A109EmployeeEmail), 0);
            AV9Lines.Add("SEQUENCE:0", 0);
            AV9Lines.Add("X-CONFLUENCE-SUBCALENDAR-TYPE:subscription", 0);
            AV9Lines.Add("CATEGORIES:subscription", 0);
            AV9Lines.Add("TRANSP:TRANSPARENT", 0);
            AV9Lines.Add("STATUS:CONFIRMED", 0);
            AV9Lines.Add("END:VEVENT", 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9Lines.Add("END:VCALENDAR", 0);
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV9Lines.Count )
         {
            AV10OneLine = ((string)AV9Lines.Item(AV19GXV1));
            AV8File.WriteLine(AV10OneLine);
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         AV8File.Close();
         AV14Session.Set("WWPExportFilePath", AV12Filename);
         AV14Session.Set("WWPExportFileName", AV12Filename);
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV8File = new GxFile(context.GetPhysicalPath());
         AV9Lines = new GxSimpleCollection<string>();
         scmdbuf = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P00BI2_A124LeaveTypeId = new long[1] ;
         P00BI2_A100CompanyId = new long[1] ;
         P00BI2_A106EmployeeId = new long[1] ;
         P00BI2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BI2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BI2_A157CompanyLocationId = new long[1] ;
         P00BI2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00BI2_A125LeaveTypeName = new string[] {""} ;
         P00BI2_A148EmployeeName = new string[] {""} ;
         P00BI2_A109EmployeeEmail = new string[] {""} ;
         P00BI2_A127LeaveRequestId = new long[1] ;
         A128LeaveRequestDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         AV10OneLine = "";
         AV14Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aexporticsleaves__default(),
            new Object[][] {
                new Object[] {
               P00BI2_A124LeaveTypeId, P00BI2_A100CompanyId, P00BI2_A106EmployeeId, P00BI2_A130LeaveRequestEndDate, P00BI2_A129LeaveRequestStartDate, P00BI2_A157CompanyLocationId, P00BI2_A128LeaveRequestDate, P00BI2_A125LeaveTypeName, P00BI2_A148EmployeeName, P00BI2_A109EmployeeEmail,
               P00BI2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV11EmployeeIds_Count ;
      private int AV19GXV1 ;
      private long AV17CompanyLocationId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long A127LeaveRequestId ;
      private string scmdbuf ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private DateTime AV16FromDate ;
      private DateTime AV15ToDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A128LeaveRequestDate ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string A109EmployeeEmail ;
      private string AV10OneLine ;
      private GxSimpleCollection<long> AV11EmployeeIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BI2_A124LeaveTypeId ;
      private long[] P00BI2_A100CompanyId ;
      private long[] P00BI2_A106EmployeeId ;
      private DateTime[] P00BI2_A130LeaveRequestEndDate ;
      private DateTime[] P00BI2_A129LeaveRequestStartDate ;
      private long[] P00BI2_A157CompanyLocationId ;
      private DateTime[] P00BI2_A128LeaveRequestDate ;
      private string[] P00BI2_A125LeaveTypeName ;
      private string[] P00BI2_A148EmployeeName ;
      private string[] P00BI2_A109EmployeeEmail ;
      private long[] P00BI2_A127LeaveRequestId ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private IGxSession AV14Session ;
      private GxSimpleCollection<string> AV9Lines ;
      private GxFile AV8File ;
   }

   public class aexporticsleaves__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BI2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV11EmployeeIds ,
                                             long AV17CompanyLocationId ,
                                             int AV11EmployeeIds_Count ,
                                             long A157CompanyLocationId ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime AV15ToDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             DateTime AV16FromDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T1.EmployeeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T3.CompanyLocationId, T1.LeaveRequestDate, T2.LeaveTypeName, T4.EmployeeName, T4.EmployeeEmail, T1.LeaveRequestId FROM (((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Employee T4 ON T4.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV15ToDate)");
         AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV16FromDate)");
         if ( ! (0==AV17CompanyLocationId) )
         {
            AddWhere(sWhereString, "(T3.CompanyLocationId = :AV17CompanyLocationId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV11EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestId";
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
                     return conditional_P00BI2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (int)dynConstraints[3] , (long)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
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
          Object[] prmP00BI2;
          prmP00BI2 = new Object[] {
          new ParDef("AV15ToDate",GXType.Date,8,0) ,
          new ParDef("AV16FromDate",GXType.Date,8,0) ,
          new ParDef("AV17CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BI2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
