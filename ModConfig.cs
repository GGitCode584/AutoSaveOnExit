using StardewModdingAPI;
using System.Collections.Generic;

namespace AutoSaveOnExit
{
    /// <summary>
    /// Configuración personalizable para el mod AutoSaveOnExit.
    /// </summary>
    public class ModConfig
    {
        /// <summary>Activa o desactiva por completo la funcionalidad del mod.</summary>
        public bool EnableAutoSave { get; set; } = true;

        /// <summary>Tecla asignada para guardar manualmente y regresar al menú.</summary>
        public SButton SaveKey { get; set; } = SButton.F5;

        /// <summary>Retraso en milisegundos antes de guardar y salir al título.</summary>
        public int SaveDelay { get; set; } = 500;

        /// <summary>Mostrar un mensaje en pantalla y sonido al guardar.</summary>
        public bool ShowSaveMessage { get; set; } = true;

        /// <summary>Incluir la hora en los mensajes de log para facilitar el seguimiento.</summary>
        public bool IncludeTimeStampInLog { get; set; } = false;

        /// <summary>Limitar el auto-guardado a días específicos del mes (1 a 28).</summary>
        public bool SaveOnlyOnCertainDays { get; set; } = false;

        /// <summary>Días del mes permitidos para guardar (solo aplica si SaveOnlyOnCertainDays es true).</summary>
        public IList<int> AllowedDays { get; set; } = new List<int> { 1, 7 };
    }
}