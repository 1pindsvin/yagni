@echo off
Tools\nant-0.86-beta1\bin\NAnt.exe  -buildfile:OnTrack.build.xml deploy-vesterzone -D:build.properties=vesterzone.environment.properties
pause > nul