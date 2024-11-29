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
   public class employeevacationsetconversion : GXProcedure
   {
      public employeevacationsetconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public employeevacationsetconversion( IGxContext context )
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
         /* Using cursor EMPLOYEEVA2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A187VacationSetDays = EMPLOYEEVA2_A187VacationSetDays[0];
            A186VacationSetDate = EMPLOYEEVA2_A186VacationSetDate[0];
            A106EmployeeId = EMPLOYEEVA2_A106EmployeeId[0];
            A185VacationSetId = EMPLOYEEVA2_A185VacationSetId[0];
            /*
               INSERT RECORD ON TABLE GXA0033

            */
            AV2EmployeeId = A106EmployeeId;
            AV3VacationSetDate = A186VacationSetDate;
            AV4VacationSetDays = A187VacationSetDays;
            /* Using cursor EMPLOYEEVA3 */
            pr_default.execute(1, new Object[] {AV2EmployeeId, AV3VacationSetDate});
            if ( (pr_default.getStatus(1) != 101) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
               /* Using cursor EMPLOYEEVA4 */
               pr_default.execute(2, new Object[] {AV2EmployeeId, AV3VacationSetDate, AV4VacationSetDays});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("GXA0033");
            }
            /* End Insert */
            pr_default.close(1);
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
         EMPLOYEEVA2_A187VacationSetDays = new decimal[1] ;
         EMPLOYEEVA2_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         EMPLOYEEVA2_A106EmployeeId = new long[1] ;
         EMPLOYEEVA2_A185VacationSetId = new long[1] ;
         A186VacationSetDate = DateTime.MinValue;
         AV3VacationSetDate = DateTime.MinValue;
         EMPLOYEEVA3_AV2EmployeeId = new long[1] ;
         EMPLOYEEVA3_AV3VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeevacationsetconversion__default(),
            new Object[][] {
                new Object[] {
               EMPLOYEEVA2_A187VacationSetDays, EMPLOYEEVA2_A186VacationSetDate, EMPLOYEEVA2_A106EmployeeId, EMPLOYEEVA2_A185VacationSetId
               }
               , new Object[] {
               EMPLOYEEVA3_AV2EmployeeId, EMPLOYEEVA3_AV3VacationSetDate
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0033 ;
      private long A106EmployeeId ;
      private long A185VacationSetId ;
      private long AV2EmployeeId ;
      private decimal A187VacationSetDays ;
      private decimal AV4VacationSetDays ;
      private string Gx_emsg ;
      private DateTime A186VacationSetDate ;
      private DateTime AV3VacationSetDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] EMPLOYEEVA2_A187VacationSetDays ;
      private DateTime[] EMPLOYEEVA2_A186VacationSetDate ;
      private long[] EMPLOYEEVA2_A106EmployeeId ;
      private long[] EMPLOYEEVA2_A185VacationSetId ;
      private long[] EMPLOYEEVA3_AV2EmployeeId ;
      private DateTime[] EMPLOYEEVA3_AV3VacationSetDate ;
   }

   public class employeevacationsetconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmEMPLOYEEVA2;
          prmEMPLOYEEVA2 = new Object[] {
          };
          Object[] prmEMPLOYEEVA3;
          prmEMPLOYEEVA3 = new Object[] {
          new ParDef("AV2EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV3VacationSetDate",GXType.Date,8,0)
          };
          Object[] prmEMPLOYEEVA4;
          prmEMPLOYEEVA4 = new Object[] {
          new ParDef("AV2EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV3VacationSetDate",GXType.Date,8,0) ,
          new ParDef("AV4VacationSetDays",GXType.Number,4,1)
          };
          def= new CursorDef[] {
              new CursorDef("EMPLOYEEVA2", "SELECT VacationSetDays, VacationSetDate, EmployeeId, VacationSetId FROM EmployeeVacationSet ORDER BY EmployeeId, VacationSetId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmEMPLOYEEVA2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("EMPLOYEEVA3", "SELECT EmployeeId, VacationSetDate FROM GXA0033 WHERE EmployeeId = :AV2EmployeeId AND VacationSetDate = :AV3VacationSetDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmEMPLOYEEVA3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("EMPLOYEEVA4", "INSERT INTO GXA0033(EmployeeId, VacationSetDate, VacationSetDays) VALUES(:AV2EmployeeId, :AV3VacationSetDate, :AV4VacationSetDays)", GxErrorMask.GX_NOMASK,prmEMPLOYEEVA4)
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
       }
    }

 }

}
