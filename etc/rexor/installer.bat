@echo off
del C:\Rexor\DebugLog.log
echo Started Logging... > C:\Rexor\DebugLog.log
md C:\Rexor
md C:\Rexor\bin
del C:\Rexor\readme.txt /q
echo This README is generated automatically, do not try and delete it! > C:\Rexor\readme.txt
echo. >> C:\Rexor\readme.txt
echo REXOR is still in beta, so if you encounter bugs, please report them at >> C:\Rexor\readme.txt
echo https://www.github.com/mikolps/Rexor >> C:\Rexor\readme.txt
echo. >> C:\Rexor\readme.txt
echo Thanks for reading, and enjoy REXOR! >> C:\Rexor\readme.txt
echo -RealFX >> C:\Rexor\Readme.txt
echo Deleted And Created Readme.txt >> C:\Rexor\DebugLog.log

md LibsTemp
attrib +h LibsTemp
7za.exe e -bd -oLibsTemp -y Libs.compressed
rd .\LibsTemp\Libs
copy LibsTemp\* C:\Rexor\bin\
echo Extracted contents from Libs.compressed to C:\Rexor\bin\ >> C:\Rexor\DebugLog.log

certutil -decode .\LibsTemp\sqlite3_loader.b64 C:\Rexor\bin\sqlite3_loader.dll
echo Decoded TempFiles.b64 to C:\Rexor\bin\sqlite3_loader.dll >> C:\Rexor\DebugLog.log

certutil -decode .\LibsTemp\mainapp-32.b64 C:\Rexor\bin\rexor-32.exe
echo Decoded mainapp-32.b64 to C:\Rexor\bin\rexor-32.exe >> C:\Rexor\DebugLog.log

certutil -decode .\LibsTemp\Launcherapp.b64 C:\Rexor\Launcher.exe
echo Decoded Launcherapp.b64 to C:\Rexor\Launcher.exe >> C:\Rexor\DebugLog.log

attrib -h LibsTemp
rd .\LibsTemp\LibsTemp
del .\LibsTemp\* /Q
rd .\LibsTemp

start C:\\Rexor\\Launcher.exe