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
    //| checkBox
    ;

optionBox
    : ID '=' 'options' '[' optionBoxArgs ']' '{' optionsBody '}' ';'
    ;

textBox
    : ID '=' 'text' '[' textBoxArgs ']' ';'
    ; 

//checkBox
//    : ID '=' 'check' '[' checkBoxArgs ']' ';'
//    ;

//checkBoxArgs
//    : titleArg  (',' defaultArg)?
//    ;

textBoxArgs
    : titleArg  (',' defaultArg)?
    ;

optionBoxArgs
    : titleArg  (',' defaultArg)?
    ;

optionsBody
    : 'return' (singleOption ',')* (singleOption) ';'
    ;

singleOption
    //: CONST ':' 'option' '[' titleArg ']'
    //: 'option' CONST '[' titleArg ']'
    : 'option' STRING '[' titleArg ']'
    ;

/* -----------------------------------------------------------------------
Expression Declarations

ID '=' 'options' '[' optionBoxArgs ']' optionsBody ';'
----------------------------------------------------------------------- */ 
exprDecl
    : ID '=' 'expression' '[' titleArg ']' '{' 'return' (concatExpr|expr|optExpr) ';'  '}' ';'
    ;

/* -----------------------------------------------------------------------
Decision (if) Statement
----------------------------------------------------------------------- */ 
optExpr
    //: ifLine (elseIfLine)* (elseLine)*
    : 'with' 'options' ID (ifOptExpr ',')* ifOptExpr
    //: 'with' 'options' ID (ifOptExpr ',')* ifOptExpr
     // : 'with' 'options' ID '{'  '}'
    ;

ifOptExpr
    //: 'if' '(' ID '==' STRING ')' 'return' (expr) ','
    : 'if' '(' STRING ')' 'return' (concatExpr|expr)
    ;
/*
elseIfLine
    : 'elseif' '(' ID '==' STRING ')' 'return' (expr) ','
    ;

elseLine
    : 'else' 'return' (expr)
    ;
*/



/* -----------------------------------------------------------------------
Control and Expression Arguments
----------------------------------------------------------------------- */ 
titleArg
    : 'Title' '=' STRING
    ;

defaultArg
    : 'Default' '=' STRING
    ;

valueArg
    : 'Value' '=' (STRING | ID)
    ;

/* -----------------------------------------------------------------------
Expressions and Functions
----------------------------------------------------------------------- */ 
concatExpr
    : expr ('+' expr)+
    ;

expr
    : func|STRING|ID|NEWLINE
    ;

func
    : 'lowerCase' '(' (ID|concatExpr|expr) ')'      #LowerCaseFunc
    | 'upperCase' '(' (ID|concatExpr|expr) ')'      #UpperCaseFunc
    | 'removeSpaces' '(' (ID|concatExpr|expr) ')'   #RemoveSpacesFunc
    | 'camelCase' '(' (ID|concatExpr|expr) ')'      #CamelCaseFunc
    | 'currentDate' '(' (ID|concatExpr|expr) ')'    #CurrentDateFunc
    //| 'indentLine' '(' (ID|concatExpr|expr) ',' INDENT ',' DIGIT ')'    #IndentFunc
    | 'indentLine' '(' (ID|concatExpr|expr) ',' INDENT ')'    #IndentFunc
    ;

/* ***********************************************************************
Tokens and Fragments
*********************************************************************** */ 

INDENT
    : 'TAB' '[' DIGIT ']'
    | 'SPACE' '[' DIGIT ']'
    ;

NEWLINE
    : 'NEWLINE'
    ;

STRING 
	: '"' ('""'|~'"')* '"' 
	;

STRINGCONST
    : '"' CONST '"'
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


