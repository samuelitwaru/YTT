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
   public class dpemployees : GXProcedure
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

      public dpemployees( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpemployees( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<long> aP0_EmployeeIds ,
                           out GXBaseCollection<SdtSDTEmployee> aP1_Gxm2rootcol )
      {
         this.AV5EmployeeIds = aP0_EmployeeIds;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployee>( context, "SDTEmployee", "YTT_version4") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTEmployee> executeUdp( GxSimpleCollection<long> aP0_EmployeeIds )
      {
         execute(aP0_EmployeeIds, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GxSimpleCollection<long> aP0_EmployeeIds ,
                                 out GXBaseCollection<SdtSDTEmployee> aP1_Gxm2rootcol )
      {
         dpemployees objdpemployees;
         objdpemployees = new dpemployees();
         objdpemployees.AV5EmployeeIds = aP0_EmployeeIds;
         objdpemployees.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployee>( context, "SDTEmployee", "YTT_version4") ;
         objdpemployees.context.SetSubmitInitialConfig(context);
         objdpemployees.initialize();
         Submit( executePrivateCatch,objdpemployees);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpemployees)stateInfo).executePrivate();
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
         /* Using cursor P001W2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P001W2_A106EmployeeId[0];
            A107EmployeeFirstName = P001W2_A107EmployeeFirstName[0];
            A108EmployeeLastName = P001W2_A108EmployeeLastName[0];
            A148EmployeeName = P001W2_A148EmployeeName[0];
            A109EmployeeEmail = P001W2_A109EmployeeEmail[0];
            A100CompanyId = P001W2_A100CompanyId[0];
            A101CompanyName = P001W2_A101CompanyName[0];
            A110EmployeeIsManager = P001W2_A110EmployeeIsManager[0];
            A111GAMUserGUID = P001W2_A111GAMUserGUID[0];
            A112EmployeeIsActive = P001W2_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = P001W2_A146EmployeeVactionDays[0];
            A147EmployeeBalance = P001W2_A147EmployeeBalance[0];
            A101CompanyName = P001W2_A101CompanyName[0];
            Gxm1sdtemployee = new SdtSDTEmployee(context);
            Gxm2rootcol.Add(Gxm1sdtemployee, 0);
            Gxm1sdtemployee.gxTpr_Employeeid = A106EmployeeId;
            Gxm1sdtemployee.gxTpr_Employeefirstname = A107EmployeeFirstName;
            Gxm1sdtemployee.gxTpr_Employeelastname = A108EmployeeLastName;
            Gxm1sdtemployee.gxTpr_Employeename = A148EmployeeName;
            Gxm1sdtemployee.gxTpr_Employeeemail = A109EmployeeEmail;
            Gxm1sdtemployee.gxTpr_Companyid = A100CompanyId;
            Gxm1sdtemployee.gxTpr_Companyname = A101CompanyName;
            Gxm1sdtemployee.gxTpr_Employeeismanager = A110EmployeeIsManager;
            Gxm1sdtemployee.gxTpr_Gamuserguid = A111GAMUserGUID;
            Gxm1sdtemployee.gxTpr_Employeeisactive = A112EmployeeIsActive;
            Gxm1sdtemployee.gxTpr_Employeevactiondays = A146EmployeeVactionDays;
            Gxm1sdtemployee.gxTpr_Employeebalance = A147EmployeeBalance;
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
         P001W2_A106EmployeeId = new long[1] ;
         P001W2_A107EmployeeFirstName = new string[] {""} ;
         P001W2_A108EmployeeLastName = new string[] {""} ;
         P001W2_A148EmployeeName = new string[] {""} ;
         P001W2_A109EmployeeEmail = new string[] {""} ;
         P001W2_A100CompanyId = new long[1] ;
         P001W2_A101CompanyName = new string[] {""} ;
         P001W2_A110EmployeeIsManager = new bool[] {false} ;
         P001W2_A111GAMUserGUID = new string[] {""} ;
         P001W2_A112EmployeeIsActive = new bool[] {false} ;
         P001W2_A146EmployeeVactionDays = new decimal[1] ;
         P001W2_A147EmployeeBalance = new decimal[1] ;
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         A111GAMUserGUID = "";
         Gxm1sdtemployee = new SdtSDTEmployee(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpemployees__default(),
            new Object[][] {
                new Object[] {
               P001W2_A106EmployeeId, P001W2_A107EmployeeFirstName, P001W2_A108EmployeeLastName, P001W2_A148EmployeeName, P001W2_A109EmployeeEmail, P001W2_A100CompanyId, P001W2_A101CompanyName, P001W2_A110EmployeeIsManager, P001W2_A111GAMUserGUID, P001W2_A112EmployeeIsActive,
               P001W2_A146EmployeeVactionDays, P001W2_A147EmployeeBalance
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private long A100CompanyId ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private string scmdbuf ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string A148EmployeeName ;
      private string A101CompanyName ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private GxSimpleCollection<long> AV5EmployeeIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P001W2_A106EmployeeId ;
      private string[] P001W2_A107EmployeeFirstName ;
      private string[] P001W2_A108EmployeeLastName ;
      private string[] P001W2_A148EmployeeName ;
      private string[] P001W2_A109EmployeeEmail ;
      private long[] P001W2_A100CompanyId ;
      private string[] P001W2_A101CompanyName ;
      private bool[] P001W2_A110EmployeeIsManager ;
      private string[] P001W2_A111GAMUserGUID ;
      private bool[] P001W2_A112EmployeeIsActive ;
      private decimal[] P001W2_A146EmployeeVactionDays ;
      private decimal[] P001W2_A147EmployeeBalance ;
      private GXBaseCollection<SdtSDTEmployee> aP1_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTEmployee> Gxm2rootcol ;
      private SdtSDTEmployee Gxm1sdtemployee ;
   }

   public class dpemployees__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001W2;
          prmP001W2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P001W2", "SELECT T1.EmployeeId, T1.EmployeeFirstName, T1.EmployeeLastName, T1.EmployeeName, T1.EmployeeEmail, T1.CompanyId, T2.CompanyName, T1.EmployeeIsManager, T1.GAMUserGUID, T1.EmployeeIsActive, T1.EmployeeVactionDays, T1.EmployeeBalance FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                return;
       }
    }

 }

}
