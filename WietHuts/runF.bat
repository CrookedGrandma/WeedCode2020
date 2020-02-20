@echo off
cd bin\Debug\netcoreapp3.1

echo Running F...
WietHuts.exe < ../../../inputs/f.txt
timeout /t 1
move ../../../output.txt ../../../outputs\F.txt