@Echo off
set carpeta=%cd%
cd C:\Windows\Microsoft.NET
for /f "delims=" %%A in ('dir /B /S csc.exe') do set "csc=%%A"
cd %carpeta%
%csc% Program.cs Calculadora.cs Numero.cs FormCalculadora.cs FormCalculadora.Designer.cs
call Program.exe