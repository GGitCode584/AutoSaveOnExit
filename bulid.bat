@echo off
setlocal

echo 🧹 Limpiando archivos antiguos...
if exist bin rd /s /q bin
if exist obj rd /s /q obj

echo 🛠️ Compilando AutoSaveOnExit...
msbuild AutoSaveOnExit.csproj /p:Configuration=Release > nul

IF %ERRORLEVEL% NEQ 0 (
    echo ❌ Error de compilación.
    pause
    exit /b 1
)

echo ✅ ¡Compilación completada!
echo 📦 El mod se encuentra en: publish\
pause