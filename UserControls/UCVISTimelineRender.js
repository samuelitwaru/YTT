function UCVISTimeline($) {
	  
	  
	  
	  
	  
	  
	 this.setleaveTypes = function(value) {
			this.leaveTypes = value;
		}

		this.getleaveTypes = function() {
			return this.leaveTypes;
		} 

	var template = '<div style=\"display:no\">	{{startDate}} --	{{endDate}}	{{item}}</div><div id=\"visualization\" style=\"margin: 5px\">	</div><div id=\"key\" style=\"display:flex; margin-top: 10px\">	<div style=\"display:flex;\">		<div style=\"background: #dddddd; height:10px; width:10px; margin: 4px\"></div> <label>Pending</label>	</div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnClick = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnClick = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Click']")
				.on('click', this.onClickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Init2(); 
	}

	this.Scripts = [];

		this.Init2 = function() {

					const UC = this;
					
					var events = JSON.parse(this.events)
					
					
					var eventGroups = JSON.parse(this.groups)
					console.log(this.leaveTypes)
					var leavetypes = []
					var now = moment().minutes(0).seconds(0).milliseconds(0);
					var groupCount = 3;
					var itemCount = 20;
					
					// create a data set with groups
					var names = ['John', 'Alston', 'Lee', 'Grant'];
					var groups = new vis.DataSet();
			//		for (var g = 0; g < groupCount; g++) {
			//			groups.add({id: g, content: names[g]});
			//		}
					
					for (var i = 0; i < eventGroups.length; i++) {
						var eventGroup = eventGroups[i]
						groups.add(eventGroup)
					}
					
					// create a dataset with items
					var items = new vis.DataSet();
			//		for (var i = 0; i < itemCount; i++) {
			//			var start = now.clone().add(Math.random() * 200, 'hours');
			//			var group = Math.floor(Math.random() * groupCount);
			//			items.add({
			//			id: i,
			//			group: group,
			//			content: 'item ' + i +
			//				' <span style="color:#97B0F8;">(' + names[group] + ')</span>',
			//			start: start,
			//			type: 'box'
			//			});
			//		}
					
					for (var i = 0; i < events.length; i++) {
						var event = events[i]
						console.log(event)
						items.add(event)
						console.log(event)
					}
				
					console.log(items)
					
					
					// create visualization
					var container = document.getElementById('visualization');
					var options = {
						groupOrder: 'content',  // groupOrder can be a property name or a sorting function
						orientation: {
							axis: 'both'
						},
						start: this.startDate,
						end: this.stopDate,
						zoomable:false,
					};
				
					
					var timeline = new vis.Timeline(container);
					timeline.setOptions(options);
					timeline.setGroups(groups);
					timeline.setItems(items);
				
					timeline.on('rangechange', function (properties) {
						console.log('rangechange', properties);
						styleEvents()
					});
				
					timeline.on('click', function (properties) {
						console.log('click', properties.item);
						console.log(timeline.itemSet.items)
						UC.item = properties.item
						UC.Click()
					});
				
					function styleEventBG(className, color){
						var elements = document.getElementsByClassName(className)
						for (let i=0; i < elements.length; i++) {
							var element = elements[i]
							element.style.background = color
						}
					}
					function styleEvents(){
						for (var i = 0; i < events.length; i++) {
							var event = events[i]
							console.log(event.className + ' : ' + `${event.id}` + ' : ' + event.color)
							styleEventBG(`${event.id}`, event.color)
							styleEventBG(event.className, event.color)
						}
					}
					
					var keyDiv = document.getElementById('key')
					for (var i=0; i < leavetypes.length; i++) {
						var type = leavetypes[i]
						var element = document.createElement('div')
						element.innerHTML = `
						<div style="display:flex;">
						<div style="background: ${type.LeaveTypeColorApproved}; height:10px; width:10px; margin: 4px; margin-left: 10px"></div> <label>${type.LeaveTypeName}</label>
						</div>
						`
						keyDiv.appendChild(element);
					}
				
					styleEvents();
					
				
		}
		this.Refresh = function(events ,groups ) {

					this.events = events
					this.groups = groups
					this.show()
				
		}


		this.onClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 this.leaveTypesCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
			}

			if (this.Click) {
				this.Click();
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