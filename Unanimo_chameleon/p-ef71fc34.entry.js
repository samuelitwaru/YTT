import{r as t,c as i,g as e,h as o,H as s}from"./p-7af91c05.js";import{C as n}from"./p-21f5cc53.js";class c{key;value;constructor(t){this.key=t.key;this.value=t.value}}class r{sessionStorageSupported;constructor(){this.sessionStorageSupported=typeof window.sessionStorage!=="undefined"&&window.sessionStorage!=null}add(t,i){if(this.sessionStorageSupported){sessionStorage.setItem(t,i)}}getAllItems(){const t=new Array;for(let i=0;i<sessionStorage.length;i++){const e=sessionStorage.key(i);const o=sessionStorage.getItem(e);t.push(new c({key:e,value:o}))}return t}getAllValues(){const t=new Array;for(let i=0;i<sessionStorage.length;i++){const e=sessionStorage.key(i);const o=sessionStorage.getItem(e);t.push(o)}return t}get(t){if(this.sessionStorageSupported){const i=sessionStorage.getItem(t);return i}return null}remove(t){if(this.sessionStorageSupported){sessionStorage.removeItem(t)}}clear(){if(this.sessionStorageSupported){sessionStorage.clear()}}}const a=':host{--title-font-family:"Source Sans Pro", sans-serif;--title-text-transform:lowercase;--title-font-weight:bold;--first-list-font-size:14px;--second-list-font-size:14px;--third-list-font-size:14px;--first-list-line-height:1.4em;--second-list-line-height:1.4em;--third-list-line-height:1.4em;--first-list-text-transform:capitalize;--second-list-text-transform:lowercase;--third-list-text-transform:capitalize;--first-list-text-vertical-padding:8px;--second-list-text-vertical-padding:6px;--third-list-text-vertical-padding:4px;--menu-background-color:var(--whiteSmoke);--text-color:var(--black);--item-hover-color:var(--lightGray);--item-active-color:var(--silverGray);--first-list-icon-color:var(--black);--first-list-arrow-color:var(--black);--second-list-arrow-color:var(--black);--footer-line-color:var(--black);--footer-font-size:14px;--indicator-color:var(--black);--scrollbar-track:var(--lightGray);--scrollbar-thumb:var(--darkGray);display:block;}:host #menu{background-color:var(--menu-background-color);font-family:var(--title-font-family);width:240px;position:fixed;height:100vh;inset-inline-start:0;top:0;z-index:5}:host #menu #title{text-transform:var(--title-text-transform);font-weight:var(--title-font-weight);color:var(--text-color);font-size:14px;letter-spacing:0.378px;padding:16px;margin:0;position:relative;z-index:20;width:240px;-webkit-box-sizing:border-box;box-sizing:border-box}:host #menu #title:before{content:"";position:absolute;width:2px;height:10px;background-color:var(--menu-background-color);inset-inline-start:0;height:100%;top:0}:host #menu #main{overflow-y:auto;position:fixed;width:240px;z-index:10}:host #menu .text{color:var(--text-color)}:host #menu #footer{position:fixed;bottom:0;inset-inline-start:0;width:240px;-webkit-box-sizing:border-box;box-sizing:border-box;z-index:20;font-size:var(--footer-font-size)}:host #menu #footer #custom-content{padding:32px 16px 8px 16px;position:relative}:host #menu #footer #custom-content:before{content:"";position:absolute;width:2px;height:10px;background-color:var(--menu-background-color);inset-inline-start:0;height:100%;top:0}:host #menu #footer #collapse-menu{cursor:pointer;height:50px;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;padding:0 16px;-webkit-transition:var(--menu-background-color) 0.25s;transition:var(--menu-background-color) 0.25s;border-top:1px solid var(--footer-line-color);-webkit-transition:background-color 0.25s;transition:background-color 0.25s;position:relative}:host #menu #footer #collapse-menu:hover{background-color:var(--item-hover-color)}:host #menu #footer #collapse-menu:hover:before{background-color:var(--item-hover-color)}:host #menu #footer #collapse-menu:active{background-color:var(--item-active-color)}:host #menu #footer #collapse-menu:active:before{background-color:var(--item-active-color)}:host #menu #footer #collapse-menu:before{content:"";position:absolute;width:2px;height:10px;background-color:var(--menu-background-color);inset-inline-start:0;height:100%;top:0;-webkit-transition:background-color 0.25s;transition:background-color 0.25s}:host #menu.collapsed #footer #custom-content{display:none}:host #menu.collapsed #footer #collapse-menu{padding:0 10px}:host #menu.collapsed,:host #menu.collapsed #title,:host #menu.collapsed #footer{inset-inline-start:-202px}:host #menu.collapsing,:host #menu.collapsing #title,:host #menu.collapsing #footer{inset-inline-start:-240px !important;-webkit-transition:left 0.6s;transition:left 0.6s;-webkit-transition-timing-function:cubic-bezier(0.25, 0.1, 0.25, 1);transition-timing-function:cubic-bezier(0.25, 0.1, 0.25, 1)}:host #menu.collapse-faster,:host #menu.collapse-faster #title,:host #menu.collapse-faster #footer{-webkit-transition:left 0.3s;transition:left 0.3s;-webkit-transition-timing-function:cubic-bezier(0.25, 0.1, 0.25, 1);transition-timing-function:cubic-bezier(0.25, 0.1, 0.25, 1)}:host #menu.collapsed #collapse-menu{-ms-flex-direction:row-reverse;flex-direction:row-reverse}:host #menu.collapsed #collapse-menu ch-icon{-webkit-transform:rotate(180deg);transform:rotate(180deg)}:host #menu.collapsed #collapse-menu .collapse-icon{-webkit-transform:rotate(180deg);transform:rotate(180deg)}:host #menu,:host #footer{color:var(--text-color)}:host .tooltip{position:fixed;inset-inline-start:50px;opacity:0;-webkit-transition:opacity 0.25s;transition:opacity 0.25s;background-color:var(--menu-background-color);color:var(--text-color);padding:4px 8px;border-radius:6px;z-index:0}:host .tooltip.visible{opacity:1}:host #indicator{width:2px;background-color:var(--indicator-color);position:fixed;inset-inline-start:0;height:0;-webkit-transition:top 0.4s, height 0.5s, opacity 0.35s;transition:top 0.4s, height 0.5s, opacity 0.35s;opacity:1}:host #indicator.speed-zero{-webkit-transition-duration:0s;transition-duration:0s}:host #indicator.hide{opacity:0}:host ::-webkit-scrollbar{width:6px}:host ::-webkit-scrollbar-track{background:var(--scrollbar-track);border-radius:3px}:host ::-webkit-scrollbar-thumb{background:var(--scrollbar-thumb);border-radius:3px}:host ::-webkit-scrollbar-thumb:hover{background:var(--scrollbar-thumb);cursor:pointer}:host .hidden-xs{visibility:hidden}:host .visible-xs{visibility:inherit}';const l=a;var h=undefined&&undefined.__decorate||function(t,i,e,o){var s=arguments.length,n=s<3?i:o===null?o=Object.getOwnPropertyDescriptor(i,e):o,c;if(typeof Reflect==="object"&&typeof Reflect.decorate==="function")n=Reflect.decorate(t,i,e,o);else for(var r=t.length-1;r>=0;r--)if(c=t[r])n=(s<3?c(n):s>3?c(i,e,n):c(i,e))||n;return s>3&&n&&Object.defineProperty(i,e,n),n};var d=undefined&&undefined.__metadata||function(t,i){if(typeof Reflect==="object"&&typeof Reflect.metadata==="function")return Reflect.metadata(t,i)};const u=class{constructor(e){t(this,e);this.itemClicked=i(this,"itemClicked",7);this.collapseBtnClicked=i(this,"collapseBtnClicked",7);this.menuTitle=undefined;this.singleListOpen=false;this.distanceToTop=0;this.collapsible=true;this.activeItemId="";this.activeItem="";this.isCollapsed=undefined;this.indicator=undefined}itemClicked;collapseBtnClicked;get el(){return e(this)}topHeightSpeed=300;speedDivisionValue=400;main;menu;title;footer;collapseButton;componentDidLoad(){if(window.matchMedia("(max-width: 767px)").matches){this.menu.classList.add("hidden-xs")}window.matchMedia("(max-width: 767px)").addEventListener("change",this.handleMatchMedia.bind(this));this.getSidebarState();const t=this.title.offsetHeight;const i=this.footer.offsetHeight;const e=t+i+"px";const o=this.el.querySelectorAll(".collapsable");const s=this.distanceToTop.toString()+"px";this.menu.style.top=s;this.main.style.height=`calc(100vh - ${e} - ${s})`;const n=this.el.querySelectorAll(".item");Array.from(n).forEach((function(t){const i=t.shadowRoot.querySelector(".main-container");t.style.maxHeight=i.offsetHeight+"px"}));const c=this.el.querySelectorAll(".item.uncollapsed");const r=Array.prototype.slice.call(c).reverse();r.forEach((function(t){const i=t.shadowRoot.querySelector(".main-container").offsetHeight;const e=t.querySelector(":scope > ch-sidebar-menu-list");if(e){const o=e.offsetHeight;t.style.maxHeight=i+o+"px"}}));this.indicator=document.createElement("DIV");this.indicator.setAttribute("id","indicator");this.main.appendChild(this.indicator);this.repositionIndicatorAfterMenuUncollapse();Array.from(n).forEach(function(i){i.addEventListener("click",function(e){e.stopPropagation();if(!this.menu.classList.contains("collapsed")){const e=i.getBoundingClientRect().y;const o=i.shadowRoot.querySelector(".main-container").offsetHeight;if(this.singleListOpen&&i.classList.contains("list-one__item")){let e=i;let s=t;while((e=e.previousElementSibling)!=null){const t=e.shadowRoot.querySelector(".main-container");s+=t.offsetHeight}this.indicator.style.top=s+"px";this.indicator.style.height=o+"px"}else{this.indicator.style.top=e+"px";this.indicator.style.height=o+"px"}}}.bind(this))}.bind(this));Array.from(n).forEach(function(t){t.addEventListener("click",function(i){i.stopPropagation();const e=document.querySelector(".item--active");if(e!==null){e.classList.remove("item--active")}t.classList.add("item--active");this.GetCurrentItemIndicatorPos();this.storeSidebarActiveItem(t);this.activeItem=t.id}.bind(this))}.bind(this));if(this.activeItemId!==""&&!this.activeItem){const t=this.el.querySelector("#"+this.activeItemId);t.classList.add("item--active");let i=t.parentElement;if(i.hasAttribute("slot")){i=i.parentElement;this.uncollapseList(i);i.classList.add("uncollapsed");let t=i.parentElement;if(t.hasAttribute("slot")){t=t.parentElement;this.uncollapseList(t);t.classList.add("uncollapsed")}}const e=t.getBoundingClientRect().y;const o=t.shadowRoot.querySelector(".main-container").offsetHeight;this.indicator.style.top=e+"px";this.indicator.style.height=o+"px"}Array.from(o).forEach(function(t){const i=t.shadowRoot.querySelector(".main-container");i.addEventListener("click",function(){if(t.classList.contains("list-one__item")&&this.menu.classList.contains("collapsed")){this.collapseButton.click()}else{this.toggleIcon(t);this.setTransitionSpeed(t);if(t.classList.contains("uncollapsed")){this.uncollapseList(t)}else{this.collapseList(t)}if(t.classList.contains("list-two__item")){const i=t.closest(".list-one__item");const e=t.querySelector(".list-three").offsetHeight;this.updateListItem1TransitionSpeed(i,e);this.updateListItem1MaxHeight(i)}}}.bind(this))}.bind(this));if(this.singleListOpen){const t=document.querySelectorAll(".list-one__item");Array.from(t).forEach(function(t){const i=t.shadowRoot.querySelector(".main-container");i.addEventListener("click",function(){if(!this.menu.classList.contains("collapsed")){const i=document.querySelector(".lastUl1Opened");if(i!==null&&!t.classList.contains("lastUl1Opened")){const t=i.shadowRoot.querySelector(".main-container");t.click()}if(t.classList.contains("uncollapsed")){t.classList.add("lastUl1Opened")}else{t.classList.remove("lastUl1Opened")}}}.bind(this))}.bind(this))}if(this.collapsible){this.collapseButton.addEventListener("click",function(){let t=0;if(this.menu.classList.contains("collapsed")){this.menu.classList.add("collapse-faster");t=300}else{this.menu.classList.remove("collapse-faster");t=600}this.menu.classList.add("collapsing");this.hideIndicator();setTimeout(function(){if(this.menu.classList.contains("collapsed")){this.uncollapseCollapsedLists();this.undoSwitchListOneOrder();this.menu.classList.remove("collapsed");setTimeout(function(){this.repositionIndicatorAfterMenuUncollapse()}.bind(this),50);this.isCollapsed=false;this.collapseMenuHandler();this.storeSidebarState()}else{this.collapseUncollapsedLists1();this.switchListOneOrder();this.menu.classList.add("collapsed");setTimeout(function(){this.repositionIndicatorAfterMenuCollapse()}.bind(this),50);this.isCollapsed=true;this.collapseMenuHandler();this.storeSidebarState()}this.menu.classList.remove("collapsing");setTimeout(function(){this.showIndicator()}.bind(this),400)}.bind(this),t)}.bind(this))}this.getSidebarCollapsedState();const a=document.createElement("DIV");a.classList.add("tooltip");a.style.zIndex="0";this.menu.appendChild(a);Array.from(n).forEach(function(t){const i=t.shadowRoot.querySelector(".main-container");i.addEventListener("mouseenter",function(){if(this.menu.classList.contains("collapsed")){a.classList.add("visible");a.innerHTML=t.childNodes[0].nodeValue;const i=t.getBoundingClientRect().y;a.style.top=i+"px"}}.bind(this));i.addEventListener("mouseleave",function(){if(this.menu.classList.contains("collapsed")){a.classList.remove("visible")}}.bind(this))}.bind(this));this.main.addEventListener("scroll",function(){this.GetCurrentItemIndicatorPos()}.bind(this));let l;document.addEventListener("scroll",function(){const t=document.documentElement;const i=(window.pageYOffset||t.scrollTop)-(t.clientTop||0);if(l===undefined){l=0}const o=Number(this.menu.style.top.split("px")[0]);if(o>0){if(o-(i-l)>0){const t=i-l;this.menu.style.top=o-t+"px";l=i;const s=this.distanceToTop-i;const n=s+"px";this.main.style.height=`calc(100vh - ${e} - ${n})`;this.GetCurrentItemIndicatorPos()}else{this.menu.style.top="0px";this.GetCurrentItemIndicatorPos()}}else if(o==0){if(i<=this.distanceToTop){this.menu.style.top=this.distanceToTop-i+"px";l=i;this.main.style.height=`calc(100vh - ${e} - ${i})`;this.GetCurrentItemIndicatorPos()}}}.bind(this))}handleMatchMedia(t){if(t.matches){this.menu.classList.add("hidden-xs")}else{this.menu.classList.remove("hidden-xs")}}closeSidebar(){const t=window.matchMedia("(max-width: 767px)");if(t.matches){this.menu.className="";this.menu.classList.add("hidden-xs")}}GetCurrentItemIndicatorPos(){let t=null;const i=document.querySelector(".item--active");if(i!==null){const e=i.getBoundingClientRect().y;this.indicator.classList.add("speed-zero");this.indicator.style.top=e+"px";if(t!==null){clearTimeout(t)}t=setTimeout(function(){this.indicator.classList.remove("speed-zero")}.bind(this),50)}}repositionIndicatorAfterMenuCollapse(){const t=this.el.querySelector(".item--active");if(t!==null){const i=t.closest(".list-one__item");if(i!==null){const t=i.shadowRoot.querySelector(".main-container");const e=t.getBoundingClientRect().y;const o=t.offsetHeight;this.indicator.style.top=e+"px";this.indicator.style.height=o+"px"}else{const i=t.getBoundingClientRect().y;const e=t.offsetHeight;this.indicator.style.top=i+"px";this.indicator.style.height=e+"px"}}}repositionIndicatorAfterMenuUncollapse(){const t=this.el.querySelector(".item--active");if(t!==null){const i=t.shadowRoot.querySelector(".main-container");const e=i.getBoundingClientRect().y;const o=i.offsetHeight;this.indicator.style.top=e+"px";this.indicator.style.height=o+"px"}}hideIndicator(){this.indicator.classList.add("hide")}showIndicator(){this.indicator.classList.remove("hide")}collapseUncollapsedLists1(){const t=document.querySelectorAll(".list-one__item.uncollapsed");Array.from(t).forEach((function(t){t.classList.add("speed-zero");t.setAttribute("data-uncollapsed-max-height",t.style.maxHeight);t.style.maxHeight=t.shadowRoot.querySelector(".main-container").offsetHeight+"px"}))}uncollapseCollapsedLists(){const t=document.querySelectorAll(".list-one__item.uncollapsed");Array.from(t).forEach((function(t){t.addEventListener("transitionend",i);function i(e){if(e.propertyName==="max-height"){t.classList.remove("speed-zero");t.removeEventListener("transitionend",i)}}const e=t.getAttribute("data-uncollapsed-max-height");t.style.maxHeight=e;t.removeAttribute("data-uncollapsed-max-height")}))}switchListOneOrder(){const t=document.querySelectorAll(".list-one__item");Array.from(t).forEach((function(t){t.classList.add("switch-order")}))}undoSwitchListOneOrder(){const t=document.querySelectorAll(".list-one__item");Array.from(t).forEach((function(t){t.classList.remove("switch-order")}))}updateListItem1TransitionSpeed(t,i){if(i>this.topHeightSpeed){i=this.topHeightSpeed}t.style.transitionDuration=i/this.speedDivisionValue+"s"}updateListItem1MaxHeight(t){const i=t.shadowRoot.querySelector(".main-container").clientHeight;const e=t.querySelectorAll(":scope > ch-sidebar-menu-list > ch-sidebar-menu-list-item");let o=i;Array.from(e).forEach((function(t){o+=parseInt(t.style.maxHeight.slice(0,-2))}));t.style.maxHeight=o+"px"}toggleIcon(t){if(t.classList.contains("uncollapsed")){t.classList.remove("uncollapsed")}else{t.classList.add("uncollapsed")}}setTransitionSpeed(t){let i=0;const e=t.querySelector("ch-sidebar-menu-list").clientHeight;if(e>this.topHeightSpeed){i=this.topHeightSpeed}else{i=e}t.style.transitionDuration=i/this.speedDivisionValue+"s"}collapseList(t){const i=t.shadowRoot.querySelector(".main-container").offsetHeight;t.style.maxHeight=i+"px";this.storeSidebarCollapsedItem(t)}uncollapseList(t){const i=t.shadowRoot.querySelector(".main-container").clientHeight;const e=t.querySelector("ch-sidebar-menu-list").clientHeight;t.style.maxHeight=i+e+"px";this.storeSidebarUncollapsedItem(t)}storeSidebarActiveItem(t){const i=new r;const e=i.get("active-item");if(e!=""&&e!=null){i.remove("active-item")}i.add("active-item",t.id)}storeSidebarUncollapsedItem(t){const i=new r;if(!t.classList.contains("list-three__item")){i.add(t.id,"uncollapsed")}}storeSidebarCollapsedItem(t){const i=new r;i.remove(t.id)}storeSidebarState(){const t=new r;const i=t.get("isCollapsed");if(i==="false"){t.add("isCollapsed","true")}else{t.add("isCollapsed","false")}}getSidebarState(){const t=new r;const i=t.getAllItems();for(let t=0;t<i.length;t++){let e;switch(true){case i[t].key==="active-item":{e=document.getElementById(i[t].value);if(e){e.classList.add("item--active");this.activeItem=e.id;this.main.scrollTop=100}break}case i[t].value==="uncollapsed":{e=document.getElementById(i[t].key);if(e){e.classList.add("uncollapsed")}break}}}}getSidebarCollapsedState(){const t=new r;const i=t.getAllItems();for(let t=0;t<i.length;t++){switch(true){case i[t].key==="isCollapsed":{if(i[t].value==="true"){this.collapseUncollapsedLists1();this.switchListOneOrder();this.menu.classList.add("collapsed");setTimeout(function(){this.repositionIndicatorAfterMenuCollapse()}.bind(this),50);this.isCollapsed=true;this.collapseMenuHandler()}else{this.isCollapsed=false}}}}}collapseMenuHandler(){this.collapseBtnClicked.emit({isCollapsed:this.isCollapsed})}render(){return o(s,{key:"44fb7abd5fd9df1c12bacde123eb68677a374a7b"},o("nav",{key:"81c74874754351013db0eb20eda3ecd961b0fcb6",id:"menu",part:"menu",ref:t=>this.menu=t},o("h1",{key:"183fcc58b3895e57b7ca4cd6bfd8bc109d944ec6",id:"title",ref:t=>this.title=t},this.menuTitle),o("main",{key:"a3c2ae0c39880a9082405459337ebc1a08566102",id:"main",ref:t=>this.main=t},o("slot",{key:"0264a98bf23b4ade236aca5cc1ac367d7698a02c"})),o("footer",{key:"3a37df8613574c865eb7bc97633f283a6fcc9ffb",id:"footer",ref:t=>this.footer=t},o("div",{key:"9f51214b9d43bab664bbf26cd321f207fffe7512",id:"custom-content"},o("slot",{key:"cdabb1d45249a44853c4c4c692751668b20b019f",name:"footer"})),this.collapsible&&o("div",{key:"02f7f1997cc2767a4d6b634632815da599cc9683",id:"collapse-menu",ref:t=>this.collapseButton=t},o("div",{key:"5fbf47eed2500be3ff2f54ff9f9d01bf64e60a75",part:"collapse-menu-icon",class:"collapse-icon"})))))}static get assetsDirs(){return["sidebar-menu-assets"]}};h([n({exclude:".sidebar__toggle-ico"}),d("design:type",Function),d("design:paramtypes",[]),d("design:returntype",void 0)],u.prototype,"closeSidebar",null);u.style=l;export{u as ch_sidebar_menu};
//# sourceMappingURL=p-ef71fc34.entry.js.map