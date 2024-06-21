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
   public class projectloaddvcombo : GXProcedure
   {
      public projectloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public projectloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           long aP2_ProjectId ,
                           out string aP3_SelectedValue ,
                           out string aP4_SelectedText ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ProjectId = aP2_ProjectId;
         this.AV16SelectedValue = "" ;
         this.AV17SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         executePrivate();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_SelectedText=this.AV17SelectedText;
         aP5_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    long aP2_ProjectId ,
                                                                                                    out string aP3_SelectedValue ,
                                                                                                    out string aP4_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ProjectId, out aP3_SelectedValue, out aP4_SelectedText, out aP5_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 long aP2_ProjectId ,
                                 out string aP3_SelectedValue ,
                                 out string aP4_SelectedText ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         projectloaddvcombo objprojectloaddvcombo;
         objprojectloaddvcombo = new projectloaddvcombo();
         objprojectloaddvcombo.AV13ComboName = aP0_ComboName;
         objprojectloaddvcombo.AV14TrnMode = aP1_TrnMode;
         objprojectloaddvcombo.AV15ProjectId = aP2_ProjectId;
         objprojectloaddvcombo.AV16SelectedValue = "" ;
         objprojectloaddvcombo.AV17SelectedText = "" ;
         objprojectloaddvcombo.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         objprojectloaddvcombo.context.SetSubmitInitialConfig(context);
         objprojectloaddvcombo.initialize();
         Submit( executePrivateCatch,objprojectloaddvcombo);
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_SelectedText=this.AV17SelectedText;
         aP5_Combo_Data=this.AV11Combo_Data;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((projectloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV13ComboName, "ProjectManagerId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROJECTMANAGERID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_PROJECTMANAGERID' Routine */
         returnInSub = false;
         /* Using cursor P00B22 */
         pr_default.execute(0, new Object[] {AV15ProjectId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A102ProjectId = P00B22_A102ProjectId[0];
            A106EmployeeId = P00B22_A106EmployeeId[0];
            AV22EmployeeIds.Add(A106EmployeeId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV26GXV2 = 1;
         GXt_objcol_SdtSDTEmployee1 = AV25GXV1;
         new dpemployeesbyproject(context ).execute(  AV22EmployeeIds, out  GXt_objcol_SdtSDTEmployee1) ;
         AV25GXV1 = GXt_objcol_SdtSDTEmployee1;
         while ( AV26GXV2 <= AV25GXV1.Count )
         {
            AV20ProjectManagerId_DPItem = ((SdtSDTEmployee)AV25GXV1.Item(AV26GXV2));
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ProjectManagerId_DPItem.gxTpr_Employeeid), 10, 0));
            AV12Combo_DataItem.gxTpr_Title = AV20ProjectManagerId_DPItem.gxTpr_Employeename;
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV26GXV2 = (int)(AV26GXV2+1);
         }
         AV11Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P00B23 */
            pr_default.execute(1, new Object[] {AV15ProjectId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A102ProjectId = P00B23_A102ProjectId[0];
               A166ProjectManagerId = P00B23_A166ProjectManagerId[0];
               n166ProjectManagerId = P00B23_n166ProjectManagerId[0];
               AV16SelectedValue = ((0==A166ProjectManagerId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A166ProjectManagerId), 10, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( StringUtil.StrCmp(AV14TrnMode, "GET_DSC") == 0 )
            {
               AV28GXV3 = 1;
               while ( AV28GXV3 <= AV11Combo_Data.Count )
               {
                  AV12Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV11Combo_Data.Item(AV28GXV3));
                  if ( StringUtil.StrCmp(AV12Combo_DataItem.gxTpr_Id, AV16SelectedValue) == 0 )
                  {
                     AV17SelectedText = AV12Combo_DataItem.gxTpr_Title;
                     if (true) break;
                  }
                  AV28GXV3 = (int)(AV28GXV3+1);
               }
            }
         }
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
         AV16SelectedValue = "";
         AV17SelectedText = "";
         AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         P00B22_A102ProjectId = new long[1] ;
         P00B22_A106EmployeeId = new long[1] ;
         AV22EmployeeIds = new GxSimpleCollection<long>();
         AV25GXV1 = new GXBaseCollection<SdtSDTEmployee>( context, "SDTEmployee", "YTT_version4");
         GXt_objcol_SdtSDTEmployee1 = new GXBaseCollection<SdtSDTEmployee>( context, "SDTEmployee", "YTT_version4");
         AV20ProjectManagerId_DPItem = new SdtSDTEmployee(context);
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00B23_A102ProjectId = new long[1] ;
         P00B23_A166ProjectManagerId = new long[1] ;
         P00B23_n166ProjectManagerId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.projectloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00B22_A102ProjectId, P00B22_A106EmployeeId
               }
               , new Object[] {
               P00B23_A102ProjectId, P00B23_A166ProjectManagerId, P00B23_n166ProjectManagerId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV26GXV2 ;
      private int AV28GXV3 ;
      private long AV15ProjectId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A166ProjectManagerId ;
      private string AV14TrnMode ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool n166ProjectManagerId ;
      private string AV13ComboName ;
      private string AV16SelectedValue ;
      private string AV17SelectedText ;
      private GxSimpleCollection<long> AV22EmployeeIds ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00B22_A102ProjectId ;
      private long[] P00B22_A106EmployeeId ;
      private long[] P00B23_A102ProjectId ;
      private long[] P00B23_A166ProjectManagerId ;
      private bool[] P00B23_n166ProjectManagerId ;
      private string aP3_SelectedValue ;
      private string aP4_SelectedText ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GXBaseCollection<SdtSDTEmployee> AV25GXV1 ;
      private GXBaseCollection<SdtSDTEmployee> GXt_objcol_SdtSDTEmployee1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private SdtSDTEmployee AV20ProjectManagerId_DPItem ;
   }

   public class projectloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B22;
          prmP00B22 = new Object[] {
          new ParDef("AV15ProjectId",GXType.Int64,10,0)
          };
          Object[] prmP00B23;
          prmP00B23 = new Object[] {
          new ParDef("AV15ProjectId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B22", "SELECT ProjectId, EmployeeId FROM EmployeeProject WHERE ProjectId = :AV15ProjectId ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B22,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B23", "SELECT ProjectId, ProjectManagerId FROM Project WHERE ProjectId = :AV15ProjectId ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B23,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
