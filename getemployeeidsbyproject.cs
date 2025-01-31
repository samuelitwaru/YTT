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
   public class getemployeeidsbyproject : GXProcedure
   {
      public getemployeeidsbyproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeeidsbyproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<long> aP0_ProjectIds ,
                           out GxSimpleCollection<long> aP1_EmployeeIds )
      {
         this.AV11ProjectIds = aP0_ProjectIds;
         this.AV10EmployeeIds = new GxSimpleCollection<long>() ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeIds=this.AV10EmployeeIds;
      }

      public GxSimpleCollection<long> executeUdp( GxSimpleCollection<long> aP0_ProjectIds )
      {
         execute(aP0_ProjectIds, out aP1_EmployeeIds);
         return AV10EmployeeIds ;
      }

      public void executeSubmit( GxSimpleCollection<long> aP0_ProjectIds ,
                                 out GxSimpleCollection<long> aP1_EmployeeIds )
      {
         this.AV11ProjectIds = aP0_ProjectIds;
         this.AV10EmployeeIds = new GxSimpleCollection<long>() ;
         SubmitImpl();
         aP1_EmployeeIds=this.AV10EmployeeIds;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV11ProjectIds ,
                                              A184EmployeeIsActiveInProject } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00982 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A184EmployeeIsActiveInProject = P00982_A184EmployeeIsActiveInProject[0];
            A102ProjectId = P00982_A102ProjectId[0];
            A106EmployeeId = P00982_A106EmployeeId[0];
            AV10EmployeeIds.Add(A106EmployeeId, 0);
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
         AV10EmployeeIds = new GxSimpleCollection<long>();
         P00982_A184EmployeeIsActiveInProject = new bool[] {false} ;
         P00982_A102ProjectId = new long[1] ;
         P00982_A106EmployeeId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getemployeeidsbyproject__default(),
            new Object[][] {
                new Object[] {
               P00982_A184EmployeeIsActiveInProject, P00982_A102ProjectId, P00982_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A102ProjectId ;
      private long A106EmployeeId ;
      private bool A184EmployeeIsActiveInProject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV11ProjectIds ;
      private GxSimpleCollection<long> AV10EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private bool[] P00982_A184EmployeeIsActiveInProject ;
      private long[] P00982_A102ProjectId ;
      private long[] P00982_A106EmployeeId ;
      private GxSimpleCollection<long> aP1_EmployeeIds ;
   }

   public class getemployeeidsbyproject__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00982( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV11ProjectIds ,
                                             bool A184EmployeeIsActiveInProject )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT EmployeeIsActiveInProject, ProjectId, EmployeeId FROM EmployeeProject";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11ProjectIds, "ProjectId IN (", ")")+")");
         AddWhere(sWhereString, "(EmployeeIsActiveInProject = TRUE)");
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
                     return conditional_P00982(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (bool)dynConstraints[2] );
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
          Object[] prmP00982;
          prmP00982 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00982", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00982,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
