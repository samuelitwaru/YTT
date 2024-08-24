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
   public class sdsendleaverequestmail : GXProcedure
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

      public sdsendleaverequestmail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdsendleaverequestmail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( [GxJsonFormat("yyyy-MM-dd")] DateTime aP0_LeaveRequestStartDate ,
                           [GxJsonFormat("yyyy-MM-dd")] DateTime aP1_LeaveRequestEndDate ,
                           string aP2_LeaveRequestDescription ,
                           string aP3_LeaveTypeName ,
                           string aP4_LeaveRequestHalfDay ,
                           string aP5_EmployeeName ,
                           long aP6_EmployeeId )
      {
         this.AV16LeaveRequestStartDate = aP0_LeaveRequestStartDate;
         this.AV17LeaveRequestEndDate = aP1_LeaveRequestEndDate;
         this.AV18LeaveRequestDescription = aP2_LeaveRequestDescription;
         this.AV19LeaveTypeName = aP3_LeaveTypeName;
         this.AV25LeaveRequestHalfDay = aP4_LeaveRequestHalfDay;
         this.AV20EmployeeName = aP5_EmployeeName;
         this.AV22EmployeeId = aP6_EmployeeId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_LeaveRequestStartDate ,
                                 DateTime aP1_LeaveRequestEndDate ,
                                 string aP2_LeaveRequestDescription ,
                                 string aP3_LeaveTypeName ,
                                 string aP4_LeaveRequestHalfDay ,
                                 string aP5_EmployeeName ,
                                 long aP6_EmployeeId )
      {
         sdsendleaverequestmail objsdsendleaverequestmail;
         objsdsendleaverequestmail = new sdsendleaverequestmail();
         objsdsendleaverequestmail.AV16LeaveRequestStartDate = aP0_LeaveRequestStartDate;
         objsdsendleaverequestmail.AV17LeaveRequestEndDate = aP1_LeaveRequestEndDate;
         objsdsendleaverequestmail.AV18LeaveRequestDescription = aP2_LeaveRequestDescription;
         objsdsendleaverequestmail.AV19LeaveTypeName = aP3_LeaveTypeName;
         objsdsendleaverequestmail.AV25LeaveRequestHalfDay = aP4_LeaveRequestHalfDay;
         objsdsendleaverequestmail.AV20EmployeeName = aP5_EmployeeName;
         objsdsendleaverequestmail.AV22EmployeeId = aP6_EmployeeId;
         objsdsendleaverequestmail.context.SetSubmitInitialConfig(context);
         objsdsendleaverequestmail.initialize();
         Submit( executePrivateCatch,objsdsendleaverequestmail);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sdsendleaverequestmail)stateInfo).executePrivate();
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
         new getloggedinuser(context ).execute( out  AV8GAMUser, out  AV9Employee) ;
         /* Using cursor P007J2 */
         pr_default.execute(0, new Object[] {AV22EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P007J2_A106EmployeeId[0];
            A102ProjectId = P007J2_A102ProjectId[0];
            AV23ProjectIds.Add(A102ProjectId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV23ProjectIds ,
                                              A177ProjectManagerIsActive } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P007J3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A166ProjectManagerId = P007J3_A166ProjectManagerId[0];
            n166ProjectManagerId = P007J3_n166ProjectManagerId[0];
            A177ProjectManagerIsActive = P007J3_A177ProjectManagerIsActive[0];
            A102ProjectId = P007J3_A102ProjectId[0];
            A176ProjectManagerEmail = P007J3_A176ProjectManagerEmail[0];
            A177ProjectManagerIsActive = P007J3_A177ProjectManagerIsActive[0];
            A176ProjectManagerEmail = P007J3_A176ProjectManagerEmail[0];
            AV24emails.Add(A176ProjectManagerEmail, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P007J4 */
         pr_default.execute(2, new Object[] {AV9Employee.gxTpr_Companyid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A112EmployeeIsActive = P007J4_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P007J4_A110EmployeeIsManager[0];
            A100CompanyId = P007J4_A100CompanyId[0];
            A109EmployeeEmail = P007J4_A109EmployeeEmail[0];
            A106EmployeeId = P007J4_A106EmployeeId[0];
            AV24emails.Add(A109EmployeeEmail, 0);
            AV12ManagerEmail = A109EmployeeEmail;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV15Subject = "New Leave Request";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25LeaveRequestHalfDay)) )
         {
            AV25LeaveRequestHalfDay = "(" + AV25LeaveRequestHalfDay + ")";
         }
         AV13Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>New Leave Request </h2></div><div style=\"padding:20px;line-height:1.5\">" + "<p>Dear Manager, </p>" + "<p>This is to inform you that <b>" + AV20EmployeeName + "</b> would like to request leave for the following period: </p>" + "<p>Leave Type: <b>" + StringUtil.Upper( AV19LeaveTypeName) + " " + AV25LeaveRequestHalfDay + "</b></p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV16LeaveRequestStartDate, 2, "/") + "</b></p>" + "<p>End Date: <b>" + context.localUtil.DToC( AV17LeaveRequestEndDate, 2, "/") + "</b></p>" + "<p>Reason for Leave: <b>" + AV18LeaveRequestDescription + "</b></p>" + "<p>Best Regards,</p>" + "<p>The Yukon Time Tracker Team</p>";
         new sendbulkmail(context ).execute(  AV24emails, ref  AV15Subject, ref  AV13Body) ;
         AV14NotificationText = "New: " + StringUtil.Trim( AV9Employee.gxTpr_Employeefirstname) + " " + StringUtil.Trim( AV9Employee.gxTpr_Employeelastname) + " has submitted a leave request.";
         new sdsendpushnotifications(context ).execute(  "Leave Request",  AV14NotificationText,  0) ;
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
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9Employee = new SdtEmployee(context);
         scmdbuf = "";
         P007J2_A106EmployeeId = new long[1] ;
         P007J2_A102ProjectId = new long[1] ;
         AV23ProjectIds = new GxSimpleCollection<long>();
         P007J3_A166ProjectManagerId = new long[1] ;
         P007J3_n166ProjectManagerId = new bool[] {false} ;
         P007J3_A177ProjectManagerIsActive = new bool[] {false} ;
         P007J3_A102ProjectId = new long[1] ;
         P007J3_A176ProjectManagerEmail = new string[] {""} ;
         A176ProjectManagerEmail = "";
         AV24emails = new GxSimpleCollection<string>();
         P007J4_A112EmployeeIsActive = new bool[] {false} ;
         P007J4_A110EmployeeIsManager = new bool[] {false} ;
         P007J4_A100CompanyId = new long[1] ;
         P007J4_A109EmployeeEmail = new string[] {""} ;
         P007J4_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         AV12ManagerEmail = "";
         AV15Subject = "";
         AV13Body = "";
         AV14NotificationText = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdsendleaverequestmail__default(),
            new Object[][] {
                new Object[] {
               P007J2_A106EmployeeId, P007J2_A102ProjectId
               }
               , new Object[] {
               P007J3_A166ProjectManagerId, P007J3_n166ProjectManagerId, P007J3_A177ProjectManagerIsActive, P007J3_A102ProjectId, P007J3_A176ProjectManagerEmail
               }
               , new Object[] {
               P007J4_A112EmployeeIsActive, P007J4_A110EmployeeIsManager, P007J4_A100CompanyId, P007J4_A109EmployeeEmail, P007J4_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV22EmployeeId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A166ProjectManagerId ;
      private long A100CompanyId ;
      private string AV19LeaveTypeName ;
      private string AV25LeaveRequestHalfDay ;
      private string AV20EmployeeName ;
      private string scmdbuf ;
      private DateTime AV16LeaveRequestStartDate ;
      private DateTime AV17LeaveRequestEndDate ;
      private bool A177ProjectManagerIsActive ;
      private bool n166ProjectManagerId ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private string AV13Body ;
      private string AV18LeaveRequestDescription ;
      private string A176ProjectManagerEmail ;
      private string A109EmployeeEmail ;
      private string AV12ManagerEmail ;
      private string AV15Subject ;
      private string AV14NotificationText ;
      private GxSimpleCollection<long> AV23ProjectIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P007J2_A106EmployeeId ;
      private long[] P007J2_A102ProjectId ;
      private long[] P007J3_A166ProjectManagerId ;
      private bool[] P007J3_n166ProjectManagerId ;
      private bool[] P007J3_A177ProjectManagerIsActive ;
      private long[] P007J3_A102ProjectId ;
      private string[] P007J3_A176ProjectManagerEmail ;
      private bool[] P007J4_A112EmployeeIsActive ;
      private bool[] P007J4_A110EmployeeIsManager ;
      private long[] P007J4_A100CompanyId ;
      private string[] P007J4_A109EmployeeEmail ;
      private long[] P007J4_A106EmployeeId ;
      private GxSimpleCollection<string> AV24emails ;
      private SdtEmployee AV9Employee ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
   }

   public class sdsendleaverequestmail__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007J3( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV23ProjectIds ,
                                             bool A177ProjectManagerIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT T1.ProjectManagerId AS ProjectManagerId, T2.EmployeeIsActive AS ProjectManagerIsActive, T1.ProjectId, T2.EmployeeEmail AS ProjectManagerEmail FROM (Project T1 LEFT JOIN Employee T2 ON T2.EmployeeId = T1.ProjectManagerId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV23ProjectIds, "T1.ProjectId IN (", ")")+")");
         AddWhere(sWhereString, "(T2.EmployeeIsActive = TRUE)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProjectId";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P007J3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (bool)dynConstraints[2] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007J2;
          prmP007J2 = new Object[] {
          new ParDef("AV22EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP007J4;
          prmP007J4 = new Object[] {
          new ParDef("AV9Employee__Companyid",GXType.Int64,10,0)
          };
          Object[] prmP007J3;
          prmP007J3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P007J2", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :AV22EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007J4", "SELECT EmployeeIsActive, EmployeeIsManager, CompanyId, EmployeeEmail, EmployeeId FROM Employee WHERE (CompanyId = :AV9Employee__Companyid) AND (EmployeeIsManager = TRUE) AND (EmployeeIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J4,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
