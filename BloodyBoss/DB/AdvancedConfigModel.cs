using System;

namespace BloodyConfig.DB
{
    /// <summary>
    /// Model for BloodyBoss v2.1.0 advanced configuration options
    /// </summary>
    public class AdvancedConfigModel
    {
        // Dynamic Scaling Configuration
        public bool EnableDynamicScaling { get; set; } = false;
        public float BaseHealthMultiplier { get; set; } = 1.0f;
        public float HealthPerPlayer { get; set; } = 0.25f;
        public float DamagePerPlayer { get; set; } = 0.15f;
        public int MaxPlayersForScaling { get; set; } = 10;

        // Progressive Difficulty Configuration
        public bool EnableProgressiveDifficulty { get; set; } = false;
        public float DifficultyIncrease { get; set; } = 0.1f;
        public float MaxDifficultyMultiplier { get; set; } = 2.0f;
        public bool ResetDifficultyOnKill { get; set; } = true;

        // Teleport Configuration
        public bool EnableTeleportCommand { get; set; } = true;
        public bool TeleportAdminOnly { get; set; } = true;
        public float TeleportCooldown { get; set; } = 60.0f;
        public bool TeleportOnlyToActiveBosses { get; set; } = true;
        public bool TeleportRequireBossAlive { get; set; } = true;
        public string TeleportCostItemGUID { get; set; } = "0";
        public int TeleportCostAmount { get; set; } = 1;

        // Phase Announcement Configuration
        public bool EnablePhaseAnnouncements { get; set; } = true;
        public bool AnnounceEveryPhase { get; set; } = false;
        public bool AnnounceMilestoneSpawns { get; set; } = true;

        // Phase Message Templates
        public string PhaseNormalTemplate { get; set; } = "⚔️ #bossname# [#phasename#] - Phase #phase# | #players# players | Damage x#damage#";
        public string PhaseHardTemplate { get; set; } = "⚔️ #bossname# [#phasename#] - Phase #phase# | #players# players | Damage x#damage#";
        public string PhaseEpicTemplate { get; set; } = "⚔️ #bossname# [#phasename#] - Phase #phase# | #players# players | Damage x#damage##consecutive_info#";
        public string PhaseLegendaryTemplate { get; set; } = "⚔️ #bossname# [#phasename#] - Phase #phase# | #players# players | Damage x#damage##consecutive_info#";
        public string PhaseVeteranSuffix { get; set; } = " Veteran";
        public string PhaseEnragedSuffix { get; set; } = " Enraged";
        public string PhaseEpicPrefix { get; set; } = "⚡ EPIC ENCOUNTER! ";
        public string PhaseLegendaryPrefix { get; set; } = "💀 LEGENDARY THREAT! ";

        // Phase Names (translatable)
        public string PhaseNormalName { get; set; } = "Normal";
        public string PhaseHardName { get; set; } = "Hard";
        public string PhaseEpicName { get; set; } = "Epic";
        public string PhaseLegendaryName { get; set; } = "Legendary";

        // Additional Message Templates
        public string ConsecutiveInfoTemplate { get; set; } = " | Consecutive: #consecutive#";

        public override string ToString() => "Advanced Configuration v2.1.0";
    }
}