import{r as t,c as e,g as s,h as i}from"./p-7af91c05.js";const n=":host{display:contents}";const r=n;const o=/%/g;const h=/^\d+(dip)?$/;const c=/^\d+(%)?$/;const d=class{constructor(s){t(this,s);this.intersectionUpdate=e(this,"intersectionUpdate",7);this.bottomMargin=undefined;this.leftMargin=undefined;this.rightMargin=undefined;this.root=undefined;this.threshold=undefined;this.topMargin=undefined}defaultThreshold=[0];observer;rootElement;rootMarginString="";get element(){return s(this)}intersectionUpdate;checkValidDipValue(t){return h.test(t)?this.convertDipToPxValue(t):"0px"}checkValidPercentValue(t){return c.test(t)?t:"0px"}convertDipToPxValue(t){const e=t.replace("dip","px");return e.split(" ").join("")}convertThresholdValueToNumber(t){if(c.test(t)){return Number(t.replace(o,""))/100}return 0}parseThreshold(t){if(!t){return[0]}const e=[];const s=t.split(",");s.forEach((t=>{const s=this.convertThresholdValueToNumber(t);if(s<=1){e.push(s)}}));return e}setIntersectionObserver(){const t={root:this.rootElement,rootMargin:this.rootMarginString,threshold:this.defaultThreshold};this.observer=new IntersectionObserver((t=>{this.intersectionUpdate.emit(t[0])}),t);const e=this.getChildElement();if(e){this.observer.observe(e)}}getChildElement(){let t=this.element.firstElementChild;while(t&&getComputedStyle(t).display==="contents"){t=t.firstElementChild}return t}setIntersectionObserverOptionsFromProperties(){if(this.root){this.rootElement=document.getElementById(this.root)}this.rootMarginString=[this.validatePosition(this.topMargin),this.validatePosition(this.leftMargin),this.validatePosition(this.bottomMargin),this.validatePosition(this.rightMargin)].join(" ");this.defaultThreshold=this.parseThreshold(this.threshold)}validatePosition(t){if(t&&t.endsWith("dip")){return this.checkValidDipValue(t)}return this.checkValidPercentValue(t)}componentDidLoad(){this.setIntersectionObserverOptionsFromProperties();this.setIntersectionObserver()}disconnectedCallback(){if(this.observer){this.observer.disconnect();this.observer=undefined}}render(){return i("slot",{key:"c1cc4ed4e7ef9537259ca9af42ce8e7549ed042e",name:"content"})}};d.style=r;export{d as ch_intersection_observer};
//# sourceMappingURL=p-d58714a3.entry.js.map