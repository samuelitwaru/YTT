function gxJSGantt()
{
	this.DateInputFormat;
	this.DateDisplayFormat;
	this.Data;
	this.Width;
	this.Height;
	this.Responsible;
	this.Duration;
	this.Complete;
	this.CaptionType;
	this.StartDate;
	this.EndDate;

	// Databinding for property Data
	this.SetData = function(data)
	{
		///UserCodeRegionStart:[SetData] (do not remove this comment.)
		this.Data=data;

		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Data
	this.GetData = function()
	{
		///UserCodeRegionStart:[GetData] (do not remove this comment.)
		return this.Data;

		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	this.show = function()
	{
		///UserCodeRegionStart:[show] (do not remove this comment.)
		var buffer='<div style="position:relative" class="gantt" id="'+this.ControlName+'"></div>';   //
		this.setHtml(buffer);
		
 
		g = new JSGantt.GanttChart('g',document.getElementById(this.ControlName), 'day');
	
		g.setShowRes(this.Responsible); // Show/Hide Responsible (0/1)
		g.setShowDur(this.Duration); // Show/Hide Duration (0/1)
		g.setShowComp(this.Complete); // Show/Hide % Complete(0/1)
		g.setCaptionType(this.CaptionType);  // Set to Show Caption (None,Caption,Resource,Duration,Complete)
		g.setShowStartDate(this.StartDate); // Show/Hide Start Date(0/1)
		g.setShowEndDate(this.EndDate); // Show/Hide End Date(0/1)
		g.setDateInputFormat(this.DateInputFormat)  // Set format of input dates ('mm/dd/yyyy', 'dd/mm/yyyy', 'yyyy-mm-dd')
		g.setDateDisplayFormat(this.DateDisplayFormat) // Set format to display dates ('mm/dd/yyyy', 'dd/mm/yyyy', 'yyyy-mm-dd')
		//g.setFormatArr(this.FormatArray) // Set format options (up to 4 : minute","hour","day","week","month","quarter")


		if( g ) {

    		// Parameters (pID, pName, pStart, pEnd, pColor, pLink, pMile, pRes, pComp, pGroup, pParent, pOpen, pDepend, pCaption)
    
			var myData = this.GetData();

			//Add all Items	
			var i = 0;
			for(i=0;myData[i]!=undefined;i++)
			{
					g.AddTaskItem(new JSGantt.TaskItem(myData[i].pID,myData[i].pName, myData[i].pStart,myData[i].pEnd,myData[i].pColor,myData[i].pLink,myData[i].pMile,myData[i].pRes,myData[i].pComp,myData[i].pGroup,myData[i].pParent,myData[i].pOpen,myData[i].pDepend,myData[i].pCaption));
				//(pID, pName, pStart, pEnd, pColor, pLink, pMile, pRes, pComp, pGroup, pParent, pOpen, pDepend, pCaption)
			}
		
 
		    g.Draw();	
    		g.DrawDependencies();

  		}

  			else

  		{

    		alert("not defined");

  		}
	
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	///UserCodeRegionEnd: (do not remove this comment.):
}
