using System;

namespace BloodyConfig.DB
{
    /// <summary>
    /// Complete model for BloodyBoss v2.1.0 mod configuration
    /// </summary>
    public class ModConfigurationModel
    {
        public GeneralConfigModel GeneralConfig { get; set; } = new GeneralConfigModel();
        public AdvancedConfigModel AdvancedConfig { get; set; } = new AdvancedConfigModel();

        // Version information
        public string ModVersion { get; set; } = "2.1.0";
        public DateTime LastModified { get; set; } = DateTime.Now;

        public override string ToString() => $"BloodyBoss Configuration v{ModVersion}";
    }
}