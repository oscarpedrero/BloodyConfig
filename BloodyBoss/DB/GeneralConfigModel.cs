using System;

namespace BloodyConfig.DB
{
    /// <summary>
    /// Model for BloodyBoss v2.1.0 general configuration options
    /// </summary>
    public class GeneralConfigModel
    {
        // Main Configuration
        public bool Enabled { get; set; } = true;
        public int BuffForWorldBoss { get; set; } = 1163490655;
        public string SpawnMessageBossTemplate { get; set; } = "A Boss #worldbossname# has been summon you got #time# minutes to defeat it!.";
        public string DespawnMessageBossTemplate { get; set; } = "You failed to kill the Boss #worldbossname# in time.";
        public string KillMessageBossTemplate { get; set; } = "The #vblood# boss has been defeated by the following brave warriors:";
        public string VBloodFinalConcat { get; set; } = " & ";
        public bool PlayersMultiplier { get; set; } = false;
        public bool ClearDropTable { get; set; } = false;
        public bool MinionDamage { get; set; } = true;
        public bool RandomBoss { get; set; } = false;
        public bool BuffAfterKillingEnabled { get; set; } = true;
        public int BuffAfterKillingPrefabGUID { get; set; } = -2061047741;
        public bool TeamBossEnable { get; set; } = false;

        // Phase Message Templates
        public string PhaseNormalTemplate { get; set; } = "Normal phase activated for #worldbossname#";
        public string PhaseHardTemplate { get; set; } = "Hard phase activated for #worldbossname#";
        public string PhaseEpicTemplate { get; set; } = "Epic phase activated for #worldbossname#";
        public string PhaseLegendaryTemplate { get; set; } = "Legendary phase activated for #worldbossname#";

        // Phase Names
        public string PhaseNormalName { get; set; } = "Normal";
        public string PhaseHardName { get; set; } = "Hard";
        public string PhaseEpicName { get; set; } = "Epic";
        public string PhaseLegendaryName { get; set; } = "Legendary";

        public override string ToString() => "General Configuration v2.1.0";
    }
}