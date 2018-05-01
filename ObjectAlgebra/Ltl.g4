grammar Ltl;
 
options {
    language=CSharp;
}

ltl: conjunction (DISJUNCTION conjunction)*;

conjunction: binary (CONJUNCTION binary)*;

binary: unary (UNTIL unary)*;

unary: (NEXT | FINALLY)* negation;

negation: NEGATION* proposition;

proposition
    : PROPOSITION
    | VARIABLE
    | LPAREN ltl RPAREN
    ;


LPAREN: '(';
RPAREN: ')';
NEGATION: '!';
NEXT: 'X';
FINALLY: 'F';
UNTIL: 'U';
CONJUNCTION: '&&';
DISJUNCTION: '||';

PROPOSITION: 'TRUE'|'FALSE';

VARIABLE: [a-z];

WS: [ \n\t\r]+ -> skip;
