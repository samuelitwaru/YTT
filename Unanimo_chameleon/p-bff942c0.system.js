System.register([],(function(e){"use strict";return{execute:function(){e("default",a);function a(e){var a="[A-Z_][A-Z0-9_.]*",n="%",s={$pattern:a,keyword:"IF DO WHILE ENDWHILE CALL ENDIF SUB ENDSUB GOTO REPEAT ENDREPEAT EQ LT GT NE GE LE OR XOR"},i={className:"meta",begin:"([O])([0-9]+)"},l=e.inherit(e.C_NUMBER_MODE,{begin:"([-+]?((\\.\\d+)|(\\d+)(\\.\\d*)?))|"+e.C_NUMBER_RE}),t=[e.C_LINE_COMMENT_MODE,e.C_BLOCK_COMMENT_MODE,e.COMMENT(/\(/,/\)/),l,e.inherit(e.APOS_STRING_MODE,{illegal:null}),e.inherit(e.QUOTE_STRING_MODE,{illegal:null}),{className:"name",begin:"([G])([0-9]+\\.?[0-9]?)"},{className:"name",begin:"([M])([0-9]+\\.?[0-9]?)"},{className:"attr",begin:"(VC|VS|#)",end:"(\\d+)"},{className:"attr",begin:"(VZOFX|VZOFY|VZOFZ)"},{className:"built_in",begin:"(ATAN|ABS|ACOS|ASIN|SIN|COS|EXP|FIX|FUP|ROUND|LN|TAN)(\\[)",contains:[l],end:"\\]"},{className:"symbol",variants:[{begin:"N",end:"\\d+",illegal:"\\W"}]}];return{name:"G-code (ISO 6983)",aliases:["nc"],case_insensitive:!0,keywords:s,contains:[{className:"meta",begin:n},i].concat(t)}}}}}));
//# sourceMappingURL=p-bff942c0.system.js.map