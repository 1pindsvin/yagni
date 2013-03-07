@echo off
Tools\nant-0.86-beta1\bin\NAnt.exe -buildfile:OnTrack.build.xml deploy-local-as-remote-web -D:build.properties=local-as-remoteweb.environment.properties
::deploy-local-as-remote-web
pause > nul