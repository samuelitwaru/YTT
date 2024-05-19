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
   public class sendcontactusemail : GXProcedure
   {
      public sendcontactusemail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public sendcontactusemail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_supportsubject ,
                           string aP1_supportdescription )
      {
         this.AV2supportsubject = aP0_supportsubject;
         this.AV3supportdescription = aP1_supportdescription;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_supportsubject ,
                                 string aP1_supportdescription )
      {
         sendcontactusemail objsendcontactusemail;
         objsendcontactusemail = new sendcontactusemail();
         objsendcontactusemail.AV2supportsubject = aP0_supportsubject;
         objsendcontactusemail.AV3supportdescription = aP1_supportdescription;
         objsendcontactusemail.context.SetSubmitInitialConfig(context);
         objsendcontactusemail.initialize();
         Submit( executePrivateCatch,objsendcontactusemail);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sendcontactusemail)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2supportsubject,(string)AV3supportdescription} ;
         ClassLoader.Execute("asendcontactusemail","GeneXus.Programs","asendcontactusemail", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
      }

      private string AV2supportsubject ;
      private string AV3supportdescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
