#!/bin/bash
set -e

echo "🧹 Limpiando archivos anteriores..."
rm -rf bin obj

echo "🛠️ Compilando AutoSaveOnExit con dotnet..."
dotnet build AutoSaveOnExit.csproj -c Release

echo "✅ ¡Compilación completada!"
echo "📦 Salida: bin/net48/"