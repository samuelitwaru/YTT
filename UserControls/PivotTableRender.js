function PivotTable($) {
	 this.setSDTProjects = function(value) {
			this.SDTProjects = value;
		}

		this.getSDTProjects = function() {
			return this.SDTProjects;
		} 
	  
	 this.setSDTEmployeeProjectHoursCollection = function(value) {
			this.SDTEmployeeProjectHoursCollection = value;
		}

		this.getSDTEmployeeProjectHoursCollection = function() {
			return this.SDTEmployeeProjectHoursCollection;
		} 
	  
	 this.setProjectHours = function(value) {
			this.ProjectHours = value;
		}

		this.getProjectHours = function() {
			return this.ProjectHours;
		} 
	  
	  
	  
	  
	  

	var template = '<div id=\"print\" style=\"padding-top:1px;overflow:scroll; scrollbar-width:none; border-right: 1px solid #dddddd; border-left: 1px solid #dddddd\">	<table class=\"my-sticky-column-table gx-tab-spacing-fix-2 GridWithPaginationBar GridWithBorderColor WorkWith table-responsive\" style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>		<thead  style=\"border-collapse: collapse; position:sticky; top:0; z-index:10\">		<!-- border-collapse: collapse; position:sticky; top:0; z-index:10 -->			<tr>				<th class=\'text-center\' style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>Projects per employee:</th>				{{#SDTProjects}}				<th style=\'border: 1px solid #dddddd; border-collapse: collapse;padding: 5px; background:#f5f5f5;\' scope=\"col\" class=\'text-center\'><a id=\'Project-{{Id}}\' style=\'cursor:pointer\' class=\'project\' >{{ProjectName}}</a></th>				{{/SDTProjects}}				<th style=\'border: 1px solid #dddddd; border-collapse: collapse; padding:5px\' class=\'text-center\'>Total Work Hours</th>				{{#ShowLeaveTotal}}<th style=\"border: 1px solid #dddddd; border-collapse: collapse; padding:5px\" class=\"leave text-center\">Total Leave Hours</th><th style=\"border: 1px solid #dddddd; border-collapse: collapse; padding:5px\" class=\"leave text-center\">Total</th>{{/ShowLeaveTotal}}			</tr>		</thead>		<tbody style=\'max-height:100px\'>			{{#SDTEmployeeProjectHoursCollection}}			<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd text-center\">					<td style=\'border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5;\' class=\'text-center\'><a href=\'\'  data-event=\"Click\" >{{EmployeeName}}</a></td>								{{#SDTProjects}}				<td id=\'{{EmployeeId}}-{{Id}}\' style=\'border: 1px solid #dddddd; border-collapse: collapse;\' class=\"text-center\"></td>				{{/SDTProjects}}								<td class=\"text-center\" style=\'border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5;\'>					<span class=\"tag\" style=\'padding: 0.5rem; {{#IsWorkTimeOptimal}} background:#00a95c; color:white; border-radius:5px;{{/IsWorkTimeOptimal}}\'>{{TotalFormattedTime}}</span>				</td>				<!--<td style=\'border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5;\'>{{TotalTime}} {{ExpectedWorkTime}} {{IsWorkTimeOptimal}}</td>-->				{{#ShowLeaveTotal}}<td class=\"leave text-center\" style=\'border: 1px solid #dddddd;font-weight: bold; border-collapse: collapse;background:#f5f5f5;\'>{{TotalFormattedLeave}}</td>{{/ShowLeaveTotal}}				{{#ShowLeaveTotal}}<td class=\'leave\' style=\'border: 1px solid #dddddd;font-weight: bold; border-collapse: collapse;background:#f5f5f5;\'>{{FormattedTotal}}</td>{{/ShowLeaveTotal}}				<!--<td style=\'border: 1px solid #dddddd; border-collapse: collapse;\'><a href=\'\'  data-event=\"Click\" >Details</a></td>-->			</tr>			{{/SDTEmployeeProjectHoursCollection}}		</tbody>				<tfoot>			<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd\">				<td style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>Total</td>				{{#SDTProjects}}				<td class=\"project-total text-center\" id=\'{{Id}}\' style=\'border: 1px solid #dddddd; border-collapse: collapse;\' scope=\"col\">0</td>				{{/SDTProjects}}				<td id=\'totalWorkHours\' class=\'text-center\' style=\'border: 1px solid #dddddd; border-collapse: collapse;bold;background:#f5f5f5;\'>{{TotalFormattedWorkTime}}</td>				{{#ShowLeaveTotal}}<td class=\"leave text-center\" style=\'border: 1px solid #dddddd; border-collapse: collapse;\'></td>{{/ShowLeaveTotal}}				{{#ShowLeaveTotal}}<td class=\"leave text-center\" style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>{{TotalFormattedTime}}</td>{{/ShowLeaveTotal}}				<!--<td style=\'border: 1px solid #dddddd; border-collapse: collapse;\'></td>-->			</tr>		<tfoot>			</table></div><script type=\"text/javascript\">//    $(document).ready(function() {//	//		$(window).on(\'resize\', function() {//			// Your code here//			var newHeight = $(window).height();//			console.log(\"New height: \" + newHeight);//			$(\'#print\').css(\"height\", newHeight-100)//			// Perform actions based on the new height//		});//  });  </script>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnClick = 0; 
	var _iOnProjectClicked = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnClick = 0; 
			_iOnProjectClicked = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Click']")
				.on('click', this.onClickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='ProjectClicked']")
				.on('projectclicked', this.onProjectClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

					const UC = this;
					function formatMinutesToHHMM(minutes) {
						var hours = Math.floor(minutes / 60);
						var remainingMinutes = minutes % 60;
						// Adding leading zeros if necessary
						var formattedHours = hours < 10 ? '0' + hours : hours;
						var formattedMinutes = remainingMinutes < 10 ? '0' + remainingMinutes : remainingMinutes;	
						return formattedHours + ':' + formattedMinutes;
					}
				
					for (let i = 0; i < this.SDTEmployeeProjectHoursCollection.length; i++) {
						var employee = this.SDTEmployeeProjectHoursCollection[i]
						var employeeId = employee.EmployeeId
						var projects = employee.ProjectHours
						console.log(employee.ExpectedWorkTime)
						console.log(employee.TotalTime)
						
						
						if (projects) {
							for (let j=0; j < projects.length; j++) {
								var project = projects[j]
								var cell = document.getElementById(`${employeeId}-${project.ProjectId}`)
								cell.innerHTML = project.ProjectFormattedTime
								var totalCell = document.getElementById(`${project.ProjectId}`)
								totalCell.innerHTML = parseInt(totalCell.innerHTML) + project.ProjectTime
							}
						}
					}
					var totalCells = document.getElementsByClassName('project-total')
					var totalWorkHours = 0
					for (let i=0; i<totalCells.length;i++) {
						var cell = totalCells[i]
						var projectTime = parseInt(cell.innerHTML)
						totalWorkHours += projectTime
						cell.innerHTML = formatMinutesToHHMM(projectTime)
						document.getElementById('totalWorkHours').innerHTML = formatMinutesToHHMM(totalWorkHours)
						this.TotalFormattedWorkTime = formatMinutesToHHMM(totalWorkHours)
					}
					this.toggleLeave()
					
					var elements = document.getElementsByClassName('project')
					for (let i=0; i < elements.length; i++) {
						var element = elements[i]
						element.onclick = (event) => {
							var projectId = parseInt(event.target.id.replace('Project-',''))
							console.log(projectId)
							UC.CurrentProject = projectId
							UC.ProjectClicked()
						}
						console.log(element)
					}
				
			//		var newHeight = $(window).height();
			//		console.log("New height: " + newHeight);
			//		$('#print').css("height", newHeight-100)
				
		}
		this.Refresh = function(SDTProjects ,SDTEmployeeProjectHoursCollection ) {

					this.SDTProjects = SDTProjects
					this.SDTEmployeeProjectHoursCollection = SDTEmployeeProjectHoursCollection
					this.show()
					this.TotalFormattedWorkTime = this.TotalFormattedWorkTime
				
		}
		this.GetLS = function() {

					return window.localStorage.get('Hello')
				
		}
		this.toggleLeave = function() {

					var elements = document.getElementsByClassName("leave");
					
					for (var i = 0; i < elements.length; i++) {
						
						if (this.ShowLeaveTotal=='true') {
							console.log(typeof this.ShowLeaveTotal)
							elements[i].classList.remove("hidden");
						} else {
							elements[i].classList.add("hidden");
						}
					}
				
		}


		this.onClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.SDTProjectsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.SDTEmployeeProjectHoursCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.ProjectHoursCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
				 
				 
			}

			if (this.Click) {
				this.Click();
			}
		} 

		this.onProjectClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.SDTProjectsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.SDTEmployeeProjectHoursCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.ProjectHoursCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
				 
				 
			}

			if (this.ProjectClicked) {
				this.ProjectClicked();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}