function e(e){const t=["package","import","option","optional","required","repeated","group","oneof"],o=["double","float","int32","int64","uint32","uint64","sint32","sint64","fixed32","fixed64","sfixed32","sfixed64","bool","string","bytes"],s={match:[/(message|enum|service)\s+/,e.IDENT_RE],scope:{1:"keyword",2:"title.class"}};return{name:"Protocol Buffers",aliases:["proto"],keywords:{keyword:t,type:o,literal:["true","false"]},contains:[e.QUOTE_STRING_MODE,e.NUMBER_MODE,e.C_LINE_COMMENT_MODE,e.C_BLOCK_COMMENT_MODE,s,{className:"function",beginKeywords:"rpc",end:/[{;]/,excludeEnd:!0,keywords:"rpc returns"},{begin:/^\s*[A-Z_]+(?=\s*=[^\n]+;$)/}]}}export{e as default};
//# sourceMappingURL=p-4269c25d.js.map