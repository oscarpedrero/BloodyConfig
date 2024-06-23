using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodyConfig.DB
{
    public class UnitStatsModel
    {
        public float PhysicalCriticalStrikeChance { get; set; }
        public float PhysicalCriticalStrikeDamage { get; set; }
        public float SpellCriticalStrikeChance { get; set; }
        public float SpellCriticalStrikeDamage { get; set; }
        public float PhysicalPower { get; set; }
        public float SpellPower { get; set; }
        public float ResourcePower { get; set; }
        public float SiegePower { get; set; }
        public float ResourceYieldModifier { get; set; }
        public float ReducedResourceDurabilityLoss { get; set; }
        public float PhysicalResistance { get; set; }
        public float SpellResistance { get; set; }
        public int SunResistance { get; set; }
        public int FireResistance { get; set; }
        public int HolyResistance { get; set; }
        public int SilverResistance { get; set; }
        public int SilverCoinResistance { get; set; }
        public int GarlicResistance { get; set; }
        public float PassiveHealthRegen { get; set; }
        public int CCReduction { get; set; }
        public float HealthRecovery { get; set; }
        public float DamageReduction { get; set; }
        public float HealingReceived { get; set; }
        public float ShieldAbsorbModifier { get; set; }
        public float BloodEfficiency { get; set; }
    }
}
