System.register([],(function(e){"use strict";return{execute:function(){e("default",a);function a(e){var a=e.COMMENT(/\{/,/\}/,{contains:["self"]});return{name:"Parser3",subLanguage:"xml",relevance:0,contains:[e.COMMENT("^#","$"),e.COMMENT(/\^rem\{/,/\}/,{relevance:10,contains:[a]}),{className:"meta",begin:"^@(?:BASE|USE|CLASS|OPTIONS)$",relevance:10},{className:"title",begin:"@[\\w\\-]+\\[[\\w^;\\-]*\\](?:\\[[\\w^;\\-]*\\])?(?:.*)$"},{className:"variable",begin:/\$\{?[\w\-.:]+\}?/},{className:"keyword",begin:/\^[\w\-.:]+/},{className:"number",begin:"\\^#[0-9a-fA-F]+"},e.C_NUMBER_MODE]}}}}}));
//# sourceMappingURL=p-0dd98730.system.js.map