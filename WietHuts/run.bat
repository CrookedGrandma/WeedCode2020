@echo off
cd bin\Debug\netcoreapp3.1

echo Running A...
WietHuts.exe < ../../../inputs/a.txt
timeout /t 1
move ../../../output.txt ../../../outputs\A.txt

echo Running B...
WietHuts.exe < ../../../inputs/b.txt
timeout /t 1
move ../../../output.txt ../../../outputs\B.txt

echo Running C...
WietHuts.exe < ../../../inputs/c.txt
timeout /t 1
move ../../../output.txt ../../../outputs\C.txt

echo Running D...
WietHuts.exe < ../../../inputs/d.txt
timeout /t 1
move ../../../output.txt ../../../outputs\D.txt

echo Running E...
WietHuts.exe < ../../../inputs/e.txt
timeout /t 1
move ../../../output.txt ../../../outputs\E.txt

echo Running F...
WietHuts.exe < ../../../inputs/f.txt
timeout /t 1
move ../../../output.txt ../../../outputs\F.txt