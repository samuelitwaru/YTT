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
   public class employeeconversion : GXProcedure
   {
      public employeeconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public employeeconversion( IGxContext context )
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
         /* Using cursor EMPLOYEECO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A178EmployeeVacationDaysSetDate = EMPLOYEECO2_A178EmployeeVacationDaysSetDate[0];
            A148EmployeeName = EMPLOYEECO2_A148EmployeeName[0];
            A146EmployeeVactionDays = EMPLOYEECO2_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = EMPLOYEECO2_A112EmployeeIsActive[0];
            A111GAMUserGUID = EMPLOYEECO2_A111GAMUserGUID[0];
            A110EmployeeIsManager = EMPLOYEECO2_A110EmployeeIsManager[0];
            A100CompanyId = EMPLOYEECO2_A100CompanyId[0];
            A109EmployeeEmail = EMPLOYEECO2_A109EmployeeEmail[0];
            A108EmployeeLastName = EMPLOYEECO2_A108EmployeeLastName[0];
            A107EmployeeFirstName = EMPLOYEECO2_A107EmployeeFirstName[0];
            A106EmployeeId = EMPLOYEECO2_A106EmployeeId[0];
            GXt_decimal1 = A147EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal1) ;
            A147EmployeeBalance = GXt_decimal1;
            /*
               INSERT RECORD ON TABLE GXA0016

            */
            AV2EmployeeId = A106EmployeeId;
            AV3EmployeeFirstName = A107EmployeeFirstName;
            AV4EmployeeLastName = A108EmployeeLastName;
            AV5EmployeeEmail = A109EmployeeEmail;
            AV6CompanyId = A100CompanyId;
            AV7EmployeeIsManager = A110EmployeeIsManager;
            AV8GAMUserGUID = A111GAMUserGUID;
            AV9EmployeeIsActive = A112EmployeeIsActive;
            AV10EmployeeVactionDays = A146EmployeeVactionDays;
            if ( (Convert.ToDecimal(0)==A147EmployeeBalance) )
            {
               AV11EmployeeBalance = 0;
            }
            else
            {
               AV11EmployeeBalance = A147EmployeeBalance;
            }
            AV12EmployeeName = A148EmployeeName;
            AV13EmployeeVacationDaysSetDate = A178EmployeeVacationDaysSetDate;
            /* Using cursor EMPLOYEECO3 */
            pr_default.execute(1, new Object[] {AV2EmployeeId, AV3EmployeeFirstName, AV4EmployeeLastName, AV5EmployeeEmail, AV6CompanyId, AV7EmployeeIsManager, AV8GAMUserGUID, AV9EmployeeIsActive, AV10EmployeeVactionDays, AV11EmployeeBalance, AV12EmployeeName, AV13EmployeeVacationDaysSetDate});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0016");
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
         EMPLOYEECO2_A178EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         EMPLOYEECO2_A148EmployeeName = new string[] {""} ;
         EMPLOYEECO2_A146EmployeeVactionDays = new decimal[1] ;
         EMPLOYEECO2_A112EmployeeIsActive = new bool[] {false} ;
         EMPLOYEECO2_A111GAMUserGUID = new string[] {""} ;
         EMPLOYEECO2_A110EmployeeIsManager = new bool[] {false} ;
         EMPLOYEECO2_A100CompanyId = new long[1] ;
         EMPLOYEECO2_A109EmployeeEmail = new string[] {""} ;
         EMPLOYEECO2_A108EmployeeLastName = new string[] {""} ;
         EMPLOYEECO2_A107EmployeeFirstName = new string[] {""} ;
         EMPLOYEECO2_A106EmployeeId = new long[1] ;
         A178EmployeeVacationDaysSetDate = DateTime.MinValue;
         A148EmployeeName = "";
         A111GAMUserGUID = "";
         A109EmployeeEmail = "";
         A108EmployeeLastName = "";
         A107EmployeeFirstName = "";
         AV3EmployeeFirstName = "";
         AV4EmployeeLastName = "";
         AV5EmployeeEmail = "";
         AV8GAMUserGUID = "";
         AV12EmployeeName = "";
         AV13EmployeeVacationDaysSetDate = DateTime.MinValue;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeconversion__default(),
            new Object[][] {
                new Object[] {
               EMPLOYEECO2_A178EmployeeVacationDaysSetDate, EMPLOYEECO2_A148EmployeeName, EMPLOYEECO2_A146EmployeeVactionDays, EMPLOYEECO2_A112EmployeeIsActive, EMPLOYEECO2_A111GAMUserGUID, EMPLOYEECO2_A110EmployeeIsManager, EMPLOYEECO2_A100CompanyId, EMPLOYEECO2_A109EmployeeEmail, EMPLOYEECO2_A108EmployeeLastName, EMPLOYEECO2_A107EmployeeFirstName,
               EMPLOYEECO2_A106EmployeeId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0016 ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long AV2EmployeeId ;
      private long AV6CompanyId ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private decimal GXt_decimal1 ;
      private decimal AV10EmployeeVactionDays ;
      private decimal AV11EmployeeBalance ;
      private string A148EmployeeName ;
      private string A108EmployeeLastName ;
      private string A107EmployeeFirstName ;
      private string AV3EmployeeFirstName ;
      private string AV4EmployeeLastName ;
      private string AV12EmployeeName ;
      private string Gx_emsg ;
      private DateTime A178EmployeeVacationDaysSetDate ;
      private DateTime AV13EmployeeVacationDaysSetDate ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private bool AV7EmployeeIsManager ;
      private bool AV9EmployeeIsActive ;
      private string A111GAMUserGUID ;
      private string A109EmployeeEmail ;
      private string AV5EmployeeEmail ;
      private string AV8GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] EMPLOYEECO2_A178EmployeeVacationDaysSetDate ;
      private string[] EMPLOYEECO2_A148EmployeeName ;
      private decimal[] EMPLOYEECO2_A146EmployeeVactionDays ;
      private bool[] EMPLOYEECO2_A112EmployeeIsActive ;
      private string[] EMPLOYEECO2_A111GAMUserGUID ;
      private bool[] EMPLOYEECO2_A110EmployeeIsManager ;
      private long[] EMPLOYEECO2_A100CompanyId ;
      private string[] EMPLOYEECO2_A109EmployeeEmail ;
      private string[] EMPLOYEECO2_A108EmployeeLastName ;
      private string[] EMPLOYEECO2_A107EmployeeFirstName ;
      private long[] EMPLOYEECO2_A106EmployeeId ;
   }

   public class employeeconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmEMPLOYEECO2;
          prmEMPLOYEECO2 = new Object[] {
          };
          Object[] prmEMPLOYEECO3;
          prmEMPLOYEECO3 = new Object[] {
          new ParDef("AV2EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV3EmployeeFirstName",GXType.Char,100,0) ,
          new ParDef("AV4EmployeeLastName",GXType.Char,100,0) ,
          new ParDef("AV5EmployeeEmail",GXType.VarChar,100,0) ,
          new ParDef("AV6CompanyId",GXType.Int64,10,0) ,
          new ParDef("AV7EmployeeIsManager",GXType.Boolean,4,0) ,
          new ParDef("AV8GAMUserGUID",GXType.VarChar,100,60) ,
          new ParDef("AV9EmployeeIsActive",GXType.Boolean,4,0) ,
          new ParDef("AV10EmployeeVactionDays",GXType.Number,4,1) ,
          new ParDef("AV11EmployeeBalance",GXType.Number,4,1) ,
          new ParDef("AV12EmployeeName",GXType.Char,100,0) ,
          new ParDef("AV13EmployeeVacationDaysSetDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("EMPLOYEECO2", "SELECT EmployeeVacationDaysSetDate, EmployeeName, EmployeeVactionDays, EmployeeIsActive, GAMUserGUID, EmployeeIsManager, CompanyId, EmployeeEmail, EmployeeLastName, EmployeeFirstName, EmployeeId FROM Employee ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmEMPLOYEECO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("EMPLOYEECO3", "INSERT INTO GXA0016(EmployeeId, EmployeeFirstName, EmployeeLastName, EmployeeEmail, CompanyId, EmployeeIsManager, GAMUserGUID, EmployeeIsActive, EmployeeVactionDays, EmployeeBalance, EmployeeName, EmployeeVacationDaysSetDate) VALUES(:AV2EmployeeId, :AV3EmployeeFirstName, :AV4EmployeeLastName, :AV5EmployeeEmail, :AV6CompanyId, :AV7EmployeeIsManager, :AV8GAMUserGUID, :AV9EmployeeIsActive, :AV10EmployeeVactionDays, :AV11EmployeeBalance, :AV12EmployeeName, :AV13EmployeeVacationDaysSetDate)", GxErrorMask.GX_NOMASK,prmEMPLOYEECO3)
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
