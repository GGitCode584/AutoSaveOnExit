# AutoSaveOnExit 🚀💾

[![SMAPI 4+](https://img.shields.io/badge/SMAPI-4.0%2B-blue.svg)](https://smapi.io)  
[![Stardew Valley 1.6+](https://img.shields.io/badge/SDV-1.6%2B-green.svg)](https://www.stardewvalley.net)  
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)  
[![Downloads](https://img.shields.io/github/downloads/GGitCode584/AutoSaveOnExit/total.svg)](https://github.com/GGitCode584/AutoSaveOnExit/releases)

**AutoSaveOnExit** guarda tu partida automáticamente al volver al menú principal. También podés guardar manualmente presionando la tecla `F5` (configurable). Ideal para quienes se olvidan de guardar antes de salir 😄

---

## ⚡ Instalación rápida

```bash
# 1. Cloná o descargá este repositorio
git clone https://github.com/GGitCode584/AutoSaveOnExit.git

# 2. Copiá la carpeta del mod en tu carpeta de mods de Stardew Valley
cp -r AutoSaveOnExit/publish/ ~/StardewValley/Mods/AutoSaveOnExit
```

---

## ⚙️ Configuración

Una vez que inicies el juego con el mod, se generará un archivo `config.json` dentro de su carpeta. Podés editarlo para personalizar el comportamiento.

| Clave                    | Tipo         | Valor por defecto | Descripción |
|-------------------------|--------------|-------------------|-------------|
| `EnableAutoSave`        | `bool`       | `true`            | Activa o desactiva completamente el mod. |
| `SaveKey`               | `string`     | `"F5"`            | Tecla para guardar manualmente y volver al menú. |
| `SaveDelay`             | `int`        | `500`             | Tiempo en milisegundos que espera antes de guardar y salir. |
| `ShowSaveMessage`       | `bool`       | `true`            | Muestra un HUD + sonido al guardar. |
| `IncludeTimeStampInLog` | `bool`       | `false`           | Agrega la hora exacta en los logs de SMAPI. |
| `SaveOnlyOnCertainDays` | `bool`       | `false`           | Limita el guardado solo a ciertos días del mes. |
| `AllowedDays`           | `list<int>`  | `[1, 7]`          | Días del mes en los que se permite guardar (1 a 28). Solo si lo anterior está activado. |

📝 También podés consultar el archivo `config.example.json` incluido para ver una versión comentada con ejemplos de uso.

---

## 🧠 Compatibilidad y versión del framework

Este mod está compilado contra `.NET Framework 4.8` (`net48`) porque las bibliotecas internas de Stardew Valley (como `StardewValley.dll` y `StardewModdingAPI.dll`) también están compiladas con ese framework. Usar una versión diferente como `.NET 6` causaría errores de compilación o ejecución, ya que las referencias no serían compatibles.

🛠️ Si SMAPI o el juego cambia en el futuro a un framework más moderno, este mod podrá migrar también. Por ahora, `net48` es la opción correcta para máxima compatibilidad con SDV 1.6 y SMAPI 4+.

---

## ✅ Casos de uso comunes

| ¿Qué quiero hacer? | Configuración sugerida |
|--------------------|------------------------|
| Que el juego se guarde y salga automáticamente al menú cada vez que vuelvo al título | Usá los valores por defecto |
| Guardar manualmente solo cuando yo quiera | `"EnableAutoSave": false`, luego presioná la tecla `F5` cuando quieras guardar |
| Solo guardar los domingos y el día 15 | `"SaveOnlyOnCertainDays": true`, `"AllowedDays": [7, 15]` |

---

## 🧑‍💻 Compilación para desarrolladores

Si querés compilar este mod desde el código fuente, tenés varias opciones según tu entorno. Asegurate de tener las dependencias necesarias (`.NET Framework 4.8` o soporte Mono) y luego elegí un método:

| Método              | Archivo           | Requisitos                                        | Plataforma         |
|---------------------|-------------------|---------------------------------------------------|---------------------|
| **Visual Studio**   | `build.bat`       | Visual Studio con MSBuild                         | Windows             |
| **CLI moderna**     | `build-dotnet.bat`| .NET SDK + referencias configuradas               | Windows / Codespaces|
| **Terminal Unix**   | `build.sh`        | dotnet CLI + permisos de ejecución (`chmod +x`)   | Linux / macOS       |

💡 También podés compilar directamente desde tu IDE favorito si abrís el proyecto `AutoSaveOnExit.csproj`.

---

## 📜 Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).

---

## 🙌 Créditos

Creado con amor por **Daniel**, con ayuda y revisión técnica de Copilot 💙  
Gracias a la comunidad de modders de Stardew Valley por inspirar y compartir.

---
```

---