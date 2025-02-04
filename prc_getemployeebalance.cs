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
   public class prc_getemployeebalance : GXProcedure
   {
      public prc_getemployeebalance( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getemployeebalance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out decimal aP1_EmployeeBalance )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV10EmployeeBalance = 0 ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeBalance=this.AV10EmployeeBalance;
      }

      public decimal executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_EmployeeBalance);
         return AV10EmployeeBalance ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out decimal aP1_EmployeeBalance )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV10EmployeeBalance = 0 ;
         SubmitImpl();
         aP1_EmployeeBalance=this.AV10EmployeeBalance;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10EmployeeBalance = 0;
         AV13Year = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         /* Using cursor P00C62 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00C62_A106EmployeeId[0];
            AV15VacationSetDays = 0;
            /* Optimized group. */
            /* Using cursor P00C63 */
            pr_default.execute(1, new Object[] {A106EmployeeId, AV13Year});
            c187VacationSetDays = P00C63_A187VacationSetDays[0];
            pr_default.close(1);
            AV15VacationSetDays = (decimal)(AV15VacationSetDays+c187VacationSetDays);
            /* End optimized group. */
            GXt_decimal1 = AV14VacationDays;
            new getemployeeapprovedvacationdays(context ).execute(  A106EmployeeId,  context.localUtil.YMDToD( AV13Year, 1, 1),  context.localUtil.YMDToD( AV13Year, 12, 31), out  GXt_decimal1) ;
            AV14VacationDays = GXt_decimal1;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV10EmployeeBalance = (decimal)(AV15VacationSetDays-AV14VacationDays);
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
         P00C62_A106EmployeeId = new long[1] ;
         P00C63_A187VacationSetDays = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getemployeebalance__default(),
            new Object[][] {
                new Object[] {
               P00C62_A106EmployeeId
               }
               , new Object[] {
               P00C63_A187VacationSetDays
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13Year ;
      private long AV8EmployeeId ;
      private long A106EmployeeId ;
      private decimal AV10EmployeeBalance ;
      private decimal AV15VacationSetDays ;
      private decimal c187VacationSetDays ;
      private decimal AV14VacationDays ;
      private decimal GXt_decimal1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00C62_A106EmployeeId ;
      private decimal[] P00C63_A187VacationSetDays ;
      private decimal aP1_EmployeeBalance ;
   }

   public class prc_getemployeebalance__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00C62;
          prmP00C62 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00C63;
          prmP00C63 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV13Year",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C62", "SELECT EmployeeId FROM Employee WHERE EmployeeId = :AV8EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C62,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00C63", "SELECT SUM(VacationSetDays) FROM EmployeeVacationSet WHERE (EmployeeId = :EmployeeId) AND (date_part('year', VacationSetDate) = :AV13Year) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C63,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}
