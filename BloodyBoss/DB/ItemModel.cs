namespace BloodyConfig.DB
{
    public class ItemModel
    {
        public string name { get; set; }
        public int ItemID { get; set; }
        public int Stack { get; set; }
        public int Chance { get; set; } = 1;
        public string Color { get; set; } = "#daa520";

        public override string ToString() => name;
    }
}
