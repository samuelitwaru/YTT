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
   public class getemployeeidsbyprojectorcompany : GXProcedure
   {
      public getemployeeidsbyprojectorcompany( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeeidsbyprojectorcompany( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<long> aP0_ProjectIds ,
                           long aP1_CompanyId ,
                           out GxSimpleCollection<long> aP2_EmployeeIds )
      {
         this.AV9ProjectIds = aP0_ProjectIds;
         this.AV12CompanyId = aP1_CompanyId;
         this.AV8EmployeeIds = new GxSimpleCollection<long>() ;
         initialize();
         executePrivate();
         aP2_EmployeeIds=this.AV8EmployeeIds;
      }

      public GxSimpleCollection<long> executeUdp( GxSimpleCollection<long> aP0_ProjectIds ,
                                                  long aP1_CompanyId )
      {
         execute(aP0_ProjectIds, aP1_CompanyId, out aP2_EmployeeIds);
         return AV8EmployeeIds ;
      }

      public void executeSubmit( GxSimpleCollection<long> aP0_ProjectIds ,
                                 long aP1_CompanyId ,
                                 out GxSimpleCollection<long> aP2_EmployeeIds )
      {
         getemployeeidsbyprojectorcompany objgetemployeeidsbyprojectorcompany;
         objgetemployeeidsbyprojectorcompany = new getemployeeidsbyprojectorcompany();
         objgetemployeeidsbyprojectorcompany.AV9ProjectIds = aP0_ProjectIds;
         objgetemployeeidsbyprojectorcompany.AV12CompanyId = aP1_CompanyId;
         objgetemployeeidsbyprojectorcompany.AV8EmployeeIds = new GxSimpleCollection<long>() ;
         objgetemployeeidsbyprojectorcompany.context.SetSubmitInitialConfig(context);
         objgetemployeeidsbyprojectorcompany.initialize();
         Submit( executePrivateCatch,objgetemployeeidsbyprojectorcompany);
         aP2_EmployeeIds=this.AV8EmployeeIds;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getemployeeidsbyprojectorcompany)stateInfo).executePrivate();
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
                                              AV9ProjectIds } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor P00BK2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A102ProjectId = P00BK2_A102ProjectId[0];
            A106EmployeeId = P00BK2_A106EmployeeId[0];
            AV8EmployeeIds.Add(A106EmployeeId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00BK3 */
         pr_default.execute(1, new Object[] {AV12CompanyId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00BK3_A100CompanyId[0];
            A106EmployeeId = P00BK3_A106EmployeeId[0];
            AV8EmployeeIds.Add(A106EmployeeId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV8EmployeeIds = new GxSimpleCollection<long>();
         scmdbuf = "";
         P00BK2_A102ProjectId = new long[1] ;
         P00BK2_A106EmployeeId = new long[1] ;
         P00BK3_A100CompanyId = new long[1] ;
         P00BK3_A106EmployeeId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getemployeeidsbyprojectorcompany__default(),
            new Object[][] {
                new Object[] {
               P00BK2_A102ProjectId, P00BK2_A106EmployeeId
               }
               , new Object[] {
               P00BK3_A100CompanyId, P00BK3_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV12CompanyId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private string scmdbuf ;
      private GxSimpleCollection<long> AV9ProjectIds ;
      private GxSimpleCollection<long> AV8EmployeeIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BK2_A102ProjectId ;
      private long[] P00BK2_A106EmployeeId ;
      private long[] P00BK3_A100CompanyId ;
      private long[] P00BK3_A106EmployeeId ;
      private GxSimpleCollection<long> aP2_EmployeeIds ;
   }

   public class getemployeeidsbyprojectorcompany__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BK2( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV9ProjectIds )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT ProjectId, EmployeeId FROM EmployeeProject";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV9ProjectIds, "ProjectId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProjectId";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BK2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
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
          Object[] prmP00BK3;
          prmP00BK3 = new Object[] {
          new ParDef("AV12CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP00BK2;
          prmP00BK2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00BK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK3", "SELECT CompanyId, EmployeeId FROM Employee WHERE CompanyId = :AV12CompanyId ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK3,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
