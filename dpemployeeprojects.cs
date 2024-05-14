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
   public class dpemployeeprojects : GXProcedure
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

      public dpemployeeprojects( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpemployeeprojects( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP0_Gxm2rootcol )
      {
         dpemployeeprojects objdpemployeeprojects;
         objdpemployeeprojects = new dpemployeeprojects();
         objdpemployeeprojects.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4") ;
         objdpemployeeprojects.context.SetSubmitInitialConfig(context);
         objdpemployeeprojects.initialize();
         Submit( executePrivateCatch,objdpemployeeprojects);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpemployeeprojects)stateInfo).executePrivate();
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
         AV9Udparg3 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor P00132 */
         pr_default.execute(0, new Object[] {AV9Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00132_A106EmployeeId[0];
            A105ProjectStatus = P00132_A105ProjectStatus[0];
            A102ProjectId = P00132_A102ProjectId[0];
            A103ProjectName = P00132_A103ProjectName[0];
            A104ProjectDescription = P00132_A104ProjectDescription[0];
            A105ProjectStatus = P00132_A105ProjectStatus[0];
            A103ProjectName = P00132_A103ProjectName[0];
            A104ProjectDescription = P00132_A104ProjectDescription[0];
            Gxm1sdtemployeeproject = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
            Gxm2rootcol.Add(Gxm1sdtemployeeproject, 0);
            Gxm1sdtemployeeproject.gxTpr_Projectid = A102ProjectId;
            Gxm1sdtemployeeproject.gxTpr_Projectname = A103ProjectName;
            Gxm1sdtemployeeproject.gxTpr_Projectdescription = A104ProjectDescription;
            Gxm1sdtemployeeproject.gxTpr_Projectstatus = A105ProjectStatus;
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
         P00132_A106EmployeeId = new long[1] ;
         P00132_A105ProjectStatus = new string[] {""} ;
         P00132_A102ProjectId = new long[1] ;
         P00132_A103ProjectName = new string[] {""} ;
         P00132_A104ProjectDescription = new string[] {""} ;
         A105ProjectStatus = "";
         A103ProjectName = "";
         A104ProjectDescription = "";
         Gxm1sdtemployeeproject = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpemployeeprojects__default(),
            new Object[][] {
                new Object[] {
               P00132_A106EmployeeId, P00132_A105ProjectStatus, P00132_A102ProjectId, P00132_A103ProjectName, P00132_A104ProjectDescription
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9Udparg3 ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private string scmdbuf ;
      private string A105ProjectStatus ;
      private string A103ProjectName ;
      private string A104ProjectDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00132_A106EmployeeId ;
      private string[] P00132_A105ProjectStatus ;
      private long[] P00132_A102ProjectId ;
      private string[] P00132_A103ProjectName ;
      private string[] P00132_A104ProjectDescription ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> Gxm2rootcol ;
      private SdtSDTEmployeeProject_SDTEmployeeProjectItem Gxm1sdtemployeeproject ;
   }

   public class dpemployeeprojects__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00132;
          prmP00132 = new Object[] {
          new ParDef("AV9Udparg3",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00132", "SELECT T1.EmployeeId, T2.ProjectStatus, T1.ProjectId, T2.ProjectName, T2.ProjectDescription FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE (T1.EmployeeId = :AV9Udparg3) AND (T2.ProjectStatus = ( 'Active')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00132,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
