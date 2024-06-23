using System.Collections.Generic;


namespace BloodyConfig.DB
{
    public class CharModel
    {
        public string name { get; set; } = string.Empty;
        public string nameHash { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public string Hour { get; set; } = "00:00";
        public string HourDespawn { get; set; } = string.Empty;
        public int PrefabGUID { get; set; }
        public int level { get; set; }
        public int multiplier { get; set; } = 1;
        public List<ItemModel> items { get; set; } = new List<ItemModel>();
        public bool bossSpawn { get; set; } = false;
        public float Lifetime { get; set; }
        public float x { get; set; } = 0;
        public float y { get; set; } = 0;
        public float z { get; set; } = 0;
        public UnitStatsModel unitStats { get; set; } = null;

        public override string ToString() => name + $"- Level {level}";

    }
}
