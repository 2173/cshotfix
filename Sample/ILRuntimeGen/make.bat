echo "���棬�������Ҫȷ���Ƿ�������ñ�������·������C:\Program Files (x86)\MSBuild\14.0\Bin"
cd %~dp0
"%MsBuildDir%/MsBuild" ILRuntimeGen.sln /t:rebuild /p:configuration=Debug
pause