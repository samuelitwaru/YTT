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
   public class getemployeeexpecteddays : GXProcedure
   {
      public getemployeeexpecteddays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeeexpecteddays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_EmployeeId ,
                           ref DateTime aP1_FromDate ,
                           ref DateTime aP2_ToDate ,
                           out long aP3_ExpectedWorkDays )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV20ExpectedWorkDays = 0 ;
         initialize();
         ExecuteImpl();
         aP0_EmployeeId=this.AV8EmployeeId;
         aP1_FromDate=this.AV9FromDate;
         aP2_ToDate=this.AV10ToDate;
         aP3_ExpectedWorkDays=this.AV20ExpectedWorkDays;
      }

      public long executeUdp( ref long aP0_EmployeeId ,
                              ref DateTime aP1_FromDate ,
                              ref DateTime aP2_ToDate )
      {
         execute(ref aP0_EmployeeId, ref aP1_FromDate, ref aP2_ToDate, out aP3_ExpectedWorkDays);
         return AV20ExpectedWorkDays ;
      }

      public void executeSubmit( ref long aP0_EmployeeId ,
                                 ref DateTime aP1_FromDate ,
                                 ref DateTime aP2_ToDate ,
                                 out long aP3_ExpectedWorkDays )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV20ExpectedWorkDays = 0 ;
         SubmitImpl();
         aP0_EmployeeId=this.AV8EmployeeId;
         aP1_FromDate=this.AV9FromDate;
         aP2_ToDate=this.AV10ToDate;
         aP3_ExpectedWorkDays=this.AV20ExpectedWorkDays;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00A22 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00A22_A106EmployeeId[0];
            A100CompanyId = P00A22_A100CompanyId[0];
            AV14CompanyId = A100CompanyId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00A24 */
         pr_default.execute(1, new Object[] {AV9FromDate, AV10ToDate, AV14CompanyId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = P00A24_A40000GXC1[0];
            n40000GXC1 = P00A24_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(1);
         AV13HolidayCount = A40000GXC1;
         GXt_int1 = AV21LeaveDays;
         new procgetemployeeleavetotal(context ).execute(  AV8EmployeeId,  AV9FromDate,  AV10ToDate, out  GXt_int1) ;
         AV21LeaveDays = GXt_int1;
         GXt_int2 = (short)(AV18TotalWorkDays);
         new countweekdays(context ).execute( ref  AV9FromDate, ref  AV10ToDate, out  GXt_int2) ;
         AV18TotalWorkDays = GXt_int2;
         AV20ExpectedWorkDays = (long)(AV18TotalWorkDays-AV13HolidayCount-AV21LeaveDays);
         if ( AV20ExpectedWorkDays < 0 )
         {
            AV20ExpectedWorkDays = 0;
         }
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

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         P00A22_A106EmployeeId = new long[1] ;
         P00A22_A100CompanyId = new long[1] ;
         P00A24_A40000GXC1 = new int[1] ;
         P00A24_n40000GXC1 = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getemployeeexpecteddays__default(),
            new Object[][] {
                new Object[] {
               P00A22_A106EmployeeId, P00A22_A100CompanyId
               }
               , new Object[] {
               P00A24_A40000GXC1, P00A24_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private int A40000GXC1 ;
      private long AV8EmployeeId ;
      private long AV20ExpectedWorkDays ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long AV14CompanyId ;
      private long AV13HolidayCount ;
      private long AV21LeaveDays ;
      private long GXt_int1 ;
      private long AV18TotalWorkDays ;
      private DateTime AV9FromDate ;
      private DateTime AV10ToDate ;
      private bool n40000GXC1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_EmployeeId ;
      private DateTime aP1_FromDate ;
      private DateTime aP2_ToDate ;
      private IDataStoreProvider pr_default ;
      private long[] P00A22_A106EmployeeId ;
      private long[] P00A22_A100CompanyId ;
      private int[] P00A24_A40000GXC1 ;
      private bool[] P00A24_n40000GXC1 ;
      private long aP3_ExpectedWorkDays ;
   }

   public class getemployeeexpecteddays__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00A22;
          prmP00A22 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00A24;
          prmP00A24 = new Object[] {
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV10ToDate",GXType.Date,8,0) ,
          new ParDef("AV14CompanyId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A22", "SELECT EmployeeId, CompanyId FROM Employee WHERE EmployeeId = :AV8EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A22,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A24", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM Holiday WHERE (HolidayStartDate >= :AV9FromDate) AND (HolidayStartDate <= :AV10ToDate) AND (CompanyId = :AV14CompanyId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A24,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
