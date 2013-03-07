@echo off
Tools\nant-0.86-beta1\bin\NAnt.exe -buildfile:OnTrack.build.xml insertSqlData -D:build.properties=local.environment.properties
pause > nul