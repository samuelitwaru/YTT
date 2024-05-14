using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_gridstateaddfiltervalue : GXProcedure
   {
      public wwp_gridstateaddfiltervalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_gridstateaddfiltervalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                           string aP1_FilterName ,
                           string aP2_FilterDsc ,
                           bool aP3_AddFitler ,
                           short aP4_FilterOperator ,
                           string aP5_FilterValue ,
                           string aP6_FilterValueDsc ,
                           bool aP7_IsRange ,
                           string aP8_FilterValueTo ,
                           string aP9_FilterValueToDsc )
      {
         this.AV13GridState = aP0_GridState;
         this.AV8FilterName = aP1_FilterName;
         this.AV9FilterDsc = aP2_FilterDsc;
         this.AV12AddFitler = aP3_AddFitler;
         this.AV15FilterOperator = aP4_FilterOperator;
         this.AV11FilterValue = aP5_FilterValue;
         this.AV16FilterValueDsc = aP6_FilterValueDsc;
         this.AV18IsRange = aP7_IsRange;
         this.AV10FilterValueTo = aP8_FilterValueTo;
         this.AV17FilterValueToDsc = aP9_FilterValueToDsc;
         initialize();
         executePrivate();
         aP0_GridState=this.AV13GridState;
      }

      public void executeSubmit( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                                 string aP1_FilterName ,
                                 string aP2_FilterDsc ,
                                 bool aP3_AddFitler ,
                                 short aP4_FilterOperator ,
                                 string aP5_FilterValue ,
                                 string aP6_FilterValueDsc ,
                                 bool aP7_IsRange ,
                                 string aP8_FilterValueTo ,
                                 string aP9_FilterValueToDsc )
      {
         wwp_gridstateaddfiltervalue objwwp_gridstateaddfiltervalue;
         objwwp_gridstateaddfiltervalue = new wwp_gridstateaddfiltervalue();
         objwwp_gridstateaddfiltervalue.AV13GridState = aP0_GridState;
         objwwp_gridstateaddfiltervalue.AV8FilterName = aP1_FilterName;
         objwwp_gridstateaddfiltervalue.AV9FilterDsc = aP2_FilterDsc;
         objwwp_gridstateaddfiltervalue.AV12AddFitler = aP3_AddFitler;
         objwwp_gridstateaddfiltervalue.AV15FilterOperator = aP4_FilterOperator;
         objwwp_gridstateaddfiltervalue.AV11FilterValue = aP5_FilterValue;
         objwwp_gridstateaddfiltervalue.AV16FilterValueDsc = aP6_FilterValueDsc;
         objwwp_gridstateaddfiltervalue.AV18IsRange = aP7_IsRange;
         objwwp_gridstateaddfiltervalue.AV10FilterValueTo = aP8_FilterValueTo;
         objwwp_gridstateaddfiltervalue.AV17FilterValueToDsc = aP9_FilterValueToDsc;
         objwwp_gridstateaddfiltervalue.context.SetSubmitInitialConfig(context);
         objwwp_gridstateaddfiltervalue.initialize();
         Submit( executePrivateCatch,objwwp_gridstateaddfiltervalue);
         aP0_GridState=this.AV13GridState;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_gridstateaddfiltervalue)stateInfo).executePrivate();
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
         if ( AV12AddFitler )
         {
            AV14GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV14GridStateFilterValue.gxTpr_Name = AV8FilterName;
            AV14GridStateFilterValue.gxTpr_Dsc = AV9FilterDsc;
            AV14GridStateFilterValue.gxTpr_Operator = AV15FilterOperator;
            AV14GridStateFilterValue.gxTpr_Value = AV11FilterValue;
            AV14GridStateFilterValue.gxTpr_Valuedsc = AV16FilterValueDsc;
            AV14GridStateFilterValue.gxTpr_Valueto = AV10FilterValueTo;
            if ( AV18IsRange )
            {
               AV14GridStateFilterValue.gxTpr_Valuetodsc = AV17FilterValueToDsc;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterValueToDsc)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterValueDsc)) )
               {
                  AV14GridStateFilterValue.gxTpr_Valuedsc = StringUtil.Format( "from %1", AV16FilterValueDsc, "", "", "", "", "", "", "", "");
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterValueDsc)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterValueToDsc)) )
                  {
                     AV14GridStateFilterValue.gxTpr_Valuetodsc = StringUtil.Format( "up to %1", AV17FilterValueToDsc, "", "", "", "", "", "", "", "");
                  }
               }
            }
            AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         }
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
         AV14GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         /* GeneXus formulas. */
      }

      private short AV15FilterOperator ;
      private bool AV12AddFitler ;
      private bool AV18IsRange ;
      private string AV8FilterName ;
      private string AV9FilterDsc ;
      private string AV11FilterValue ;
      private string AV16FilterValueDsc ;
      private string AV10FilterValueTo ;
      private string AV17FilterValueToDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV13GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV14GridStateFilterValue ;
   }

}
