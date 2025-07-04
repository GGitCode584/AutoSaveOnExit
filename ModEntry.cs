using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace AutoSaveOnExit
{
    /// <summary>
    /// Punto de entrada del mod: carga la configuración y suscribe los eventos de SMAPI.
    /// </summary>
    public class ModEntry : Mod
    {
        private int ticksUntilSave;
        public ModConfig Config { get; private set; } = new ModConfig();

        public override void Entry(IModHelper helper)
        {
            // Carga config.json
            Config = helper.ReadConfig<ModConfig>();

            // Suscribe eventos
            helper.Events.Input.ButtonPressed      += OnButtonPressed;
            helper.Events.GameLoop.ReturnedToTitle += OnReturnedToTitle;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Config.EnableAutoSave || !Context.IsWorldReady)
                return;

            if (e.Button == Config.SaveKey)
                ScheduleSave("Guardado manual solicitado");
        }

        private void OnReturnedToTitle(object sender, ReturnedToTitleEventArgs e)
        {
            if (!Config.EnableAutoSave)
                return;

            if (Config.SaveOnlyOnCertainDays && !Config.AllowedDays.Contains(Game1.dayOfMonth))
                return;

            ScheduleSave("Salida al título detectada");
        }

        private void ScheduleSave(string reason)
        {
            var prefix = Config.IncludeTimeStampInLog
                ? $"[{DateTime.Now:HH:mm:ss}] "
                : string.Empty;

            Monitor.Log($"{prefix}{reason}, iniciando delay de {Config.SaveDelay} ms…", LogLevel.Info);
            ticksUntilSave = (int)Math.Ceiling(Config.SaveDelay / (1000f / 60f));
            Helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (ticksUntilSave-- > 0)
                return;

            // Desconecta el evento para no repetir
            Helper.Events.GameLoop.UpdateTicked -= OnUpdateTicked;

            // HUD + sonido (opcional)
            if (Config.ShowSaveMessage)
            {
                Game1.addHUDMessage(new HUDMessage("Guardando partida...", HUDMessage.error_type));
                Game1.playSound("save");
            }

            // 1) Invocar el guardado nativo
            Monitor.Log("✅ Iniciando guardado nativo…", LogLevel.Info);
            SaveGame.Save();

            // 2) Fundido a negro y, al terminar, salir al título
            Monitor.Log("⏳ Fundiendo pantalla para salir al título…", LogLevel.Debug);
            if (!Game1.fadeToBlack)
                Game1.fadeToBlack = true;

            Game1.afterFade += () =>
            {
                Monitor.Log("➡️ Saliendo al título", LogLevel.Info);
                Game1.exitToTitle();
            };
        }
    }
}
