@echo off
path=%path%;%windir%Microsoft.NET\Framework\v3.5\;%programfiles%\Microsoft Visual Studio 9.0\SDK\v3.5\Bin;
::echo %path%
::cd examples\HelloWindowsForms
::cd z:\nant-0.86-beta1\examples\Solution\cs 
csc.exe z:\nant-0.86-beta1\examples\HelloWorld\HelloWorld.cs
pause
