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
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3EmployeeBalance = 0 ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeBalance=this.AV3EmployeeBalance;
      }

      public decimal executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_EmployeeBalance);
         return AV3EmployeeBalance ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out decimal aP1_EmployeeBalance )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3EmployeeBalance = 0 ;
         SubmitImpl();
         aP1_EmployeeBalance=this.AV3EmployeeBalance;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2EmployeeId,(decimal)AV3EmployeeBalance} ;
         ClassLoader.Execute("aprc_getemployeebalance","GeneXus.Programs","aprc_getemployeebalance", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3EmployeeBalance = (decimal)(args[1]) ;
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
         /* GeneXus formulas. */
      }

      private long AV2EmployeeId ;
      private decimal AV3EmployeeBalance ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private decimal aP1_EmployeeBalance ;
   }

}
