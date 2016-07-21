grammar QikTemplate;

/* ***********************************************************************
Complete Template
    - Control Placeholders (user input)
    - Derived Input (expression input derived from user input or system)
*********************************************************************** */ 
template		
    :	(ctrlDecl|exprDecl)+ 
    ;

/* -----------------------------------------------------------------------
Control Declarations
----------------------------------------------------------------------- */ 
ctrlDecl
    : optionBox
    | textBox
    | checkBox
    ;

optionBox
    : ID '=' 'options' '[' optionBoxArgs ']' optionsBody ';'
    ;

textBox
    : ID '=' 'text' '[' textBoxArgs ']' ';'
    ; 

checkBox
    : ID '=' 'check' '[' checkBoxArgs ']' ';'
    ;

checkBoxArgs
    : titleArg  (',' defaultArg)?
    ;

textBoxArgs
    : titleArg  (',' defaultArg)?
    ;

optionBoxArgs
    : titleArg  (',' defaultArg)?
    ;

optionsBody
    : '{' (singleOption ',')* (singleOption ';') '}'
    ;

singleOption
    : CONST ':' 'option' '[' titleArg ']'
    ;

/* -----------------------------------------------------------------------
Expression Declarations
----------------------------------------------------------------------- */ 
exprDecl
    : ID '=' 'expression' '{' 'return' (expr|STRING|ifStat) ';'  '}' ';'
    ;

/* -----------------------------------------------------------------------
Decision (if) Statement
----------------------------------------------------------------------- */ 
ifStat
    : ifLine (elseIfLine)* (elseLine)*
    ;

ifLine
    : 'if' '(' ID '==' STRING ')' 'return' (expr) ','
    ;

elseIfLine
    : 'elseif' '(' ID '==' STRING ')' 'return' (expr) ','
    ;

elseLine
    : 'else' 'return' (expr)
    ;




/* -----------------------------------------------------------------------
Control and Expression Arguments
----------------------------------------------------------------------- */ 
titleArg
    : 'Title' '=' STRING
    ;

defaultArg
    : 'Default' '=' (STRING | CONST)
    ;

valueArg
    : 'Value' '=' (STRING | ID)
    ;

/* -----------------------------------------------------------------------
Expressions and Functions
----------------------------------------------------------------------- */ 
expr
    : (func|STRING) ('+' (func|STRING))*
    ;

func
    : 'lowerCase' '(' (ID|STRING|func) ')'      #LowerCaseFunc
    | 'upperCase' '(' (ID|STRING|func) ')'      #UpperCaseFunc
    | 'removeSpaces' '(' (ID|STRING|func) ')'   #RemoveSpacesFunc
    ;


/* ***********************************************************************
Tokens and Fragments
*********************************************************************** */ 

STRING 
	: '"' ('""'|~'"')* '"' 
	;

CONST
    : LETTER (LETTER|DIGIT)*
    ;

ID  
    :   '@' LETTER (LETTER|DIGIT)*
    ;
fragment
LETTER
    : [a-zA-Z\u00FF_]
    ;

fragment
NUMBER
    : '-'? ('.' DIGIT+ | DIGIT+ ('.' DIGIT*)? )
    ;
    
fragment
DIGIT
    : [0-9]
    ;

/* ***********************************************************************
Hidden channels (Comments and White Space)
*********************************************************************** */ 

WS  :   [ \r\t\u000C\n]+ -> channel(HIDDEN)
    ;

COMMENT
    :   '/*' .*? '*/'    -> channel(HIDDEN) // match anything between /* and */
    ;
LINE_COMMENT
    : '//' ~[\r\n]* '\r'? '\n' -> channel(HIDDEN)
    ;


