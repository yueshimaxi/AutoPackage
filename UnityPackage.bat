@echo off
 

set UNITY_PATH="D:\Program Files\Unity2018.4.29f1\Editor\Unity.exe"
set UNITY_PROJECT_PATH="D:\Documents\UnityProjects\AutoPackDEMO"
set UNITY_METHOD_NAME="BuildTool.BuildPC"

%UNITY_PATH% -quit -batchmode -projectPath %UNITY_PROJECT_PATH% -executeMethod %UNITY_METHOD_NAME% -logfile "log.txt"

exit 0