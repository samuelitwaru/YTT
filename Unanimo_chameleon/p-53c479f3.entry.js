import{r as e,c as i,h as t,H as n}from"./p-7af91c05.js";import{C as s,h as c}from"./p-d031f0c4.js";const o="*,::after,::before{-webkit-box-sizing:border-box;box-sizing:border-box}:host{--ch-checkbox__container-size:min(1em, 20px);--ch-checkbox__option-checked-image:url(\"data:image/svg+xml, <svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 8 8'><path fill='currentColor' d='M6.564.75l-3.59 3.612-1.538-1.55L0 4.26l2.974 2.99L8 2.193z'/></svg>\");--ch-checkbox__option-indeterminate-image:url(\"data:image/svg+xml, <svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 8 8'><rect width='8' height='8'/></svg>\");--ch-checkbox__option-size:50%;--ch-checkbox__option-image-size:100%;display:inline-grid;grid-template-columns:-webkit-max-content 1fr;grid-template-columns:max-content 1fr;-ms-flex-align:center;align-items:center;outline:unset;-ms-touch-action:manipulation;touch-action:manipulation;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}:host(.ch-checkbox--actionable) :is(.input,.label){cursor:pointer}.container{display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center;-ms-flex-pack:center;justify-content:center;position:relative;inline-size:var(--ch-checkbox__container-size);block-size:var(--ch-checkbox__container-size)}.input{display:-ms-flexbox;display:flex;inline-size:100%;block-size:100%;-webkit-appearance:none;-moz-appearance:none;appearance:none;margin:0;padding:0;outline:unset;border:1px solid currentColor;border-radius:18.75%}.option{position:absolute;inline-size:var(--ch-checkbox__option-size);block-size:var(--ch-checkbox__option-size);background-color:currentColor;pointer-events:none}.option--checked{-webkit-mask:no-repeat center/var(--ch-checkbox__option-image-size) var(--ch-checkbox__option-checked-image)}.option--indeterminate{-webkit-mask:no-repeat center/var(--ch-checkbox__option-image-size) var(--ch-checkbox__option-indeterminate-image)}.option--not-displayed{opacity:0;visibility:hidden}";const a=o;const h="checkbox";const r=(e,i,t)=>{if(i){return t?`${s.DISABLED} ${s.INDETERMINATE}`:s.INDETERMINATE}const n=e?s.CHECKED:s.UNCHECKED;return t?`${s.DISABLED} ${n}`:n};const l=class{constructor(t){e(this,t);this.click=i(this,"click",7);this.input=i(this,"input",7);this.checked=undefined;this.accessibleName=undefined;this.caption=undefined;this.checkedValue=undefined;this.disabled=false;this.highlightable=false;this.indeterminate=false;this.readonly=false;this.unCheckedValue=undefined;this.value=undefined}click;input;valueChanged(){this.checked=this.value===this.checkedValue}componentWillLoad(){this.checked=this.value===this.checkedValue}#e=e=>e?this.checkedValue:this.unCheckedValue;#i=e=>{if(this.readonly||this.disabled){return}e.stopPropagation()};#t=e=>{e.stopPropagation();const i=e.target;const t=i.checked;const n=this.#e(t);this.checked=t;this.value=n;i.value=n;this.indeterminate=false;this.input.emit(e);if(this.highlightable){this.click.emit()}};render(){const e=r(this.checked,this.indeterminate,this.disabled);return t(n,{key:"d03f51b1aecfb534b6549462e77b30681fe7a497",class:{[c]:this.disabled,"ch-checkbox--actionable":!this.readonly&&!this.disabled||this.readonly&&this.highlightable}},t("div",{key:"2c249297640631ef02f40a46ee9eb25f611d4f05",class:{container:true,"container--checked":this.checked},part:`${s.CONTAINER} ${e}`},t("input",{key:"140e24bcf12da356cce76266d69105a7dd7a1296","aria-label":this.accessibleName?.trim()!==""&&this.accessibleName!==this.caption?this.accessibleName:null,id:this.caption?h:null,class:"input",part:`${s.INPUT} ${e}`,type:"checkbox",checked:this.checked,disabled:this.disabled||this.readonly,indeterminate:this.indeterminate,value:this.value,onClick:this.#i,onInput:this.#t}),t("div",{key:"eac121245ef52def359ec8ca4049c510341e7333",class:{option:true,"option--not-displayed":!this.checked&&!this.indeterminate,"option--checked":this.checked&&!this.indeterminate,"option--indeterminate":this.indeterminate},part:`${s.OPTION} ${e}`,"aria-hidden":"true"})),this.caption&&t("label",{key:"cc966e3335bab6330ea1bdaa33a0c4247ed20adc",class:"label",part:`${s.LABEL} ${e}`,htmlFor:h,onClick:this.#i},this.caption))}static get watchers(){return{value:["valueChanged"]}}};l.style=a;export{l as ch_checkbox};
//# sourceMappingURL=p-53c479f3.entry.js.map