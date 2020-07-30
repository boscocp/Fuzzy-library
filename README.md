# Fuzzy-library
This is a personal training of Artificial Intelligence for games. This C# library was made to be used by me in classroom to teach Artificial Intelligence. Students can use it in unity for game development.

The FLC.txt contains an example of a Fuzzy Control Language:

VAR_INPUT
    life
    damage
    time
END
VAR_OUTPUT
    amountOfEnemies
END

FUZZIFY life
    poor = 0,15,25,32
    good = 27,32,40
    excellent = 29,43,50,51
END

FUZZIFY damage
    minor = 0,15,25,32
    half = 27,32,40
    big = 29,43,50,51
END

FUZZIFY time
    few = 0,15,25,32
    median = 27,32,40
    much = 29,43,50,51
END

DEFUZZIFY amountOfEnemies
    cheap = 0,15,25,32
    average = 27,32,40
    generous = 29,43,50,51
END

RULEBLOCK
    RULE 1 = IF life IS excellent AND damage IS minor AND time IS few THEN amountOfEnemies IS generous
    RULE 2 = IF life IS good AND damage IS half AND time IS median THEN amountOfEnemies IS average
END

