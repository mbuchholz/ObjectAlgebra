grammar Arithmetic;
 
options {
    language=CSharp;
}

expression: atom ((PLUS | MINUS) atom)*;
atom: number | LPAREN expression RPAREN;
number: NUMBER;

LPAREN: '(';
RPAREN: ')';
PLUS: '+';
MINUS: '-';
NUMBER: ('0' .. '9') + ('.' ('0' .. '9') +)?;

WS: [ \n\t\r]+ -> skip;