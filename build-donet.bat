@echo off
setlocal

echo 🧹 Limpiando archivos antiguos...
if exist bin rd /s /q bin
if exist obj rd /s /q obj

echo 🛠️ Compilando AutoSaveOnExit con dotnet...
dotnet build AutoSaveOnExit.csproj -c Release

IF %ERRORLEVEL% NEQ 0 (
    echo ❌ Error de compilación.
    pause
    exit /b 1
)

echo ✅ ¡Compilación completada!
echo 📦 Los archivos compilados se encuentran en: bin\net48\
pause