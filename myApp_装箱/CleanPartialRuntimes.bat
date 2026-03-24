@echo off
REM 参数 %1 = 目标 bin 下的 runtimes 文件夹
set "TARGET=%~1"
set "PROJECT_DIR=%~2"

echo Cleaning XML files in "%BIN_DIR%"
if exist "%BIN_DIR%*.xml" del /q "%BIN_DIR%*.xml"

echo Cleaning obj folder in "%PROJECT_DIR%"
if exist "%PROJECT_DIR%obj" rd /s /q "%PROJECT_DIR%obj"


echo Cleaning runtimes in "%TARGET%"

:: 删除指定子文件夹
for %%d in (
linux osx browser-wasm linux-arm linux-arm64 linux-mips64
linux-musl-arm linux-musl-arm64 linux-musl-s390x linux-musl-x64
linux-ppc64le linux-s390x linux-x64 linux-x86 linux-armel  browser
android-arm android-arm64 android-x64 android-x86 linux-bionic-arm64
linux-bionic-x64
maccatalyst-arm64 maccatalyst-x64 osx-arm64 osx-x64 unix win-arm64 win-arm
) do (
    if exist "%TARGET%\%%d" (
        echo Deleting "%TARGET%\%%d"
        rd /s /q "%TARGET%\%%d"
    )
)