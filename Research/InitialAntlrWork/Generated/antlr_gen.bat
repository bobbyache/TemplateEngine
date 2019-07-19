REM java -jar antlr-4.5-complete.jar -Dlanguage=CSharp "CSV.g4" -visitor
REM java -jar antlr-4.5-complete.jar -Dlanguage=CSharp "JSON.g4" -visitor

REM generate for all *.g4 files.
for %%x in (*.g4) do call java -jar antlr-4.5-complete.jar -Dlanguage=CSharp %%x -visitor


