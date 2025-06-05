using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using UnityEngine;
using SDG.Unturned;
using Logger = Rocket.Core.Logging.Logger;
using Rocket.Unturned;

namespace StunEffects
{
    public class Controller : RocketPlugin<Configuration>
    {
        public string Version = "1.1.0";

        public Controller Instance;
        public Configuration Config;

        public List<UnturnedPlayer> TunnelVisionCooldownList;

        protected override void Load()
        {
            Instance = this;
            Config = Instance.Configuration.Instance;

            TunnelVisionCooldownList = new List<UnturnedPlayer>();

            DamageTool.damagePlayerRequested += PlayerDamageHandler;

            Logger.Log($"StunEffects {Version} has been successfully loaded. Created by Spinkles.");
        }

        protected override void Unload()
        {
            DamageTool.damagePlayerRequested -= PlayerDamageHandler;

            if (Config.Debug) Logger.Log($"StunEffects {Version} has been unloaded.");
        }

        private void PlayerDamageHandler(ref DamagePlayerParameters param, ref bool ShouldAllow)
        {
            UnturnedPlayer player = UnturnedPlayer.FromPlayer(param.player);
            int health = player.Health - (Int32)param.damage;

            TunnelVision(player, param.limb, health);

            Logger.Log($"{player.CharacterName}'s health: {health}");
        }

        public async void TunnelVision(UnturnedPlayer player, ELimb limb, int health)
        {
            if (health <= 0)
            {
                if (Config.Debug) Logger.Log($"{player.CharacterName} died");
                EffectManager.askEffectClearByID(Config.EffectID, player.CSteamID);
                return;
            }
            if (health <= Config.HealthThreashold)
            {
                switch (limb)
                {
                    case ELimb.SKULL:
                        if (Config.ToggleBodyPartPlayEffect.Head)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.SPINE:
                        if (Config.ToggleBodyPartPlayEffect.Torso)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.RIGHT_LEG:
                        if (Config.ToggleBodyPartPlayEffect.Legs)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.RIGHT_FOOT:
                        if (Config.ToggleBodyPartPlayEffect.Legs)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.LEFT_LEG:
                        if (Config.ToggleBodyPartPlayEffect.Legs)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.LEFT_FOOT:
                        if (Config.ToggleBodyPartPlayEffect.Legs)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.RIGHT_ARM:
                        if (Config.ToggleBodyPartPlayEffect.Arms)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.RIGHT_HAND:
                        if (Config.ToggleBodyPartPlayEffect.Arms)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.LEFT_ARM:
                        if (Config.ToggleBodyPartPlayEffect.Arms)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;

                    case ELimb.LEFT_HAND:
                        if (Config.ToggleBodyPartPlayEffect.Arms)
                        {
                            if (!TunnelVisionCooldownList.Contains(player))
                            {
                                EffectManager.sendUIEffect(Config.EffectID, 495, player.CSteamID, true);
                                TunnelVisionCooldown(player);
                            }
                        }
                        return;
                }
            }
        }

        public async void TunnelVisionCooldown(UnturnedPlayer player)
        {
            TunnelVisionCooldownList.Add(player);

            await Task.Delay(TimeSpan.FromSeconds(13));

            TunnelVisionCooldownList.Remove(player);
        }
    }
}
