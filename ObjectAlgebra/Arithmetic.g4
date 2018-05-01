grammar Arithmetic;
 
options {
    language=CSharp;
}

expression
    : atom
    | expression (PLUS | MINUS) expression
    ;

atom
    : LPAREN expression RPAREN
    | NUMBER
    ;

LPAREN: '(';
RPAREN: ')';
PLUS: '+';
MINUS: '-';
NUMBER: ('0' .. '9') + ('.' ('0' .. '9') +)?;

WS: [ \n\t\r]+ -> skip;