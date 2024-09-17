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
   public class gethomesampledata : GXProcedure
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

      public gethomesampledata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gethomesampledata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "YTT_version4") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Beer";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(1200);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(2000);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(400);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(10);
         Gxm1homesampledata.gxTpr_Productstatus = 1;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Wine";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(890);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(100);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(3000);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(12);
         Gxm1homesampledata.gxTpr_Productstatus = 2;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Lollipop";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(200);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(3098);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(250);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(20);
         Gxm1homesampledata.gxTpr_Productstatus = 3;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Apple";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(48);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(879);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(235);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(42);
         Gxm1homesampledata.gxTpr_Productstatus = 1;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Cherries";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(232);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(6788);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(213);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(34);
         Gxm1homesampledata.gxTpr_Productstatus = 4;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Steak";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(345);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(370);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(230);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(0);
         Gxm1homesampledata.gxTpr_Productstatus = 1;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Cupcake";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(340);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(1200);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(230);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(10);
         Gxm1homesampledata.gxTpr_Productstatus = 4;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Strawberry";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(120);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(600);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(239);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(10);
         Gxm1homesampledata.gxTpr_Productstatus = 1;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Ice cream";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(70);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(1200);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(120);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(8);
         Gxm1homesampledata.gxTpr_Productstatus = 2;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Frapuccino";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(670);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(124);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(489);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(5);
         Gxm1homesampledata.gxTpr_Productstatus = 1;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Candy";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(1200);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(2000);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(400);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(10);
         Gxm1homesampledata.gxTpr_Productstatus = 1;
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         Gxm2rootcol.Add(Gxm1homesampledata, 0);
         Gxm1homesampledata.gxTpr_Productname = "Pizza";
         Gxm1homesampledata.gxTpr_Productprice = (decimal)(3400);
         Gxm1homesampledata.gxTpr_Productvolume = (decimal)(120);
         Gxm1homesampledata.gxTpr_Productweight = (decimal)(320);
         Gxm1homesampledata.gxTpr_Productdiscount = (decimal)(8);
         Gxm1homesampledata.gxTpr_Productstatus = 4;
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
         Gxm1homesampledata = new GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem Gxm1homesampledata ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> aP0_Gxm2rootcol ;
   }

}
