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
   public class prc_employeeprojectmatrixreport : GXProcedure
   {
      public prc_employeeprojectmatrixreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_employeeprojectmatrixreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_ProjectIdCollection ,
                           GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                           GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                           bool aP5_ShowLeave ,
                           out long aP6_OverallTotalHours ,
                           out GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP7_SDT_EmployeeProjectMatrixCollection )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4ProjectIdCollection = aP2_ProjectIdCollection;
         this.AV5CompanyLocationIdCollection = aP3_CompanyLocationIdCollection;
         this.AV6EmployeeIdCollection = aP4_EmployeeIdCollection;
         this.AV7ShowLeave = aP5_ShowLeave;
         this.AV8OverallTotalHours = 0 ;
         this.AV9SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP6_OverallTotalHours=this.AV8OverallTotalHours;
         aP7_SDT_EmployeeProjectMatrixCollection=this.AV9SDT_EmployeeProjectMatrixCollection;
      }

      public GXBaseCollection<SdtSDT_EmployeeProjectMatrix> executeUdp( DateTime aP0_FromDate ,
                                                                        DateTime aP1_ToDate ,
                                                                        GxSimpleCollection<long> aP2_ProjectIdCollection ,
                                                                        GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                                                                        GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                                                                        bool aP5_ShowLeave ,
                                                                        out long aP6_OverallTotalHours )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_ProjectIdCollection, aP3_CompanyLocationIdCollection, aP4_EmployeeIdCollection, aP5_ShowLeave, out aP6_OverallTotalHours, out aP7_SDT_EmployeeProjectMatrixCollection);
         return AV9SDT_EmployeeProjectMatrixCollection ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_ProjectIdCollection ,
                                 GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                                 GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                                 bool aP5_ShowLeave ,
                                 out long aP6_OverallTotalHours ,
                                 out GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP7_SDT_EmployeeProjectMatrixCollection )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4ProjectIdCollection = aP2_ProjectIdCollection;
         this.AV5CompanyLocationIdCollection = aP3_CompanyLocationIdCollection;
         this.AV6EmployeeIdCollection = aP4_EmployeeIdCollection;
         this.AV7ShowLeave = aP5_ShowLeave;
         this.AV8OverallTotalHours = 0 ;
         this.AV9SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4") ;
         SubmitImpl();
         aP6_OverallTotalHours=this.AV8OverallTotalHours;
         aP7_SDT_EmployeeProjectMatrixCollection=this.AV9SDT_EmployeeProjectMatrixCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(DateTime)AV2FromDate,(DateTime)AV3ToDate,(GxSimpleCollection<long>)AV4ProjectIdCollection,(GxSimpleCollection<long>)AV5CompanyLocationIdCollection,(GxSimpleCollection<long>)AV6EmployeeIdCollection,(bool)AV7ShowLeave,(long)AV8OverallTotalHours,(GXBaseCollection<SdtSDT_EmployeeProjectMatrix>)AV9SDT_EmployeeProjectMatrixCollection} ;
         ClassLoader.Execute("aprc_employeeprojectmatrixreport","GeneXus.Programs","aprc_employeeprojectmatrixreport", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 8 ) )
         {
            AV8OverallTotalHours = (long)(args[6]) ;
            AV9SDT_EmployeeProjectMatrixCollection = (GXBaseCollection<SdtSDT_EmployeeProjectMatrix>)(args[7]) ;
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
      }

      public override void initialize( )
      {
         AV9SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         /* GeneXus formulas. */
      }

      private long AV8OverallTotalHours ;
      private DateTime AV2FromDate ;
      private DateTime AV3ToDate ;
      private bool AV7ShowLeave ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV4ProjectIdCollection ;
      private GxSimpleCollection<long> AV5CompanyLocationIdCollection ;
      private GxSimpleCollection<long> AV6EmployeeIdCollection ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> AV9SDT_EmployeeProjectMatrixCollection ;
      private Object[] args ;
      private long aP6_OverallTotalHours ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP7_SDT_EmployeeProjectMatrixCollection ;
   }

}
