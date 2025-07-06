using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodyConfig.DB
{
    public class UnitStatsModel
    {
        // Core combat stats (maintained)
        public float PhysicalPower { get; set; }
        public float SpellPower { get; set; }
        public float ResourcePower { get; set; }
        public float SiegePower { get; set; }
        public float PhysicalResistance { get; set; }
        public float SpellResistance { get; set; }
        public int SunResistance { get; set; }
        public int FireResistance { get; set; }
        public int HolyResistance { get; set; }
        public int CCReduction { get; set; }
        public float BloodEfficiency { get; set; }
        
        // Deprecated properties removed in v2.1.0:
        // - PhysicalCriticalStrikeChance, PhysicalCriticalStrikeDamage
        // - SpellCriticalStrikeChance, SpellCriticalStrikeDamage
        // - ResourceYieldModifier, ReducedResourceDurabilityLoss
        // - SilverResistance, SilverCoinResistance, GarlicResistance
        // - PassiveHealthRegen, HealthRecovery, DamageReduction
        // - HealingReceived, ShieldAbsorbModifier
    }
}
