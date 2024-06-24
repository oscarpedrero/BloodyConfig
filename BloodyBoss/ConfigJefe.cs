using BloodyConfig.BloodyBoss.DB;
using BloodyConfig.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BloodyConfig.BloodyBoss
{
    public partial class ConfigJefe : UserControl
    {
        public static BindingList<ItemModel> ItemsList = new BindingList<ItemModel>();

        private ItemConfig ConfigItem;

        private int currentIndex;

        private ItemModel lastAddedItem;
        private CharModel charSelected;
        private CharModel currentModel = null;

        private bool changesSaved = true;

        public event EventHandler<CharModel> ModelSaved;

        private List<LanguageModel> languages = LanguagesService.GetLanguages();

        public ConfigJefe()
        {
            InitializeComponent();

            itemsList.DataSource = ItemsList;

            LoadChars(languages[0].valueNpc);
            languagesBox.DataSource = languages;

            charactesCombo.Text = "Select Character";

            name.TextChanged += TextBox_Changed;
            hourSpawn.KeyPress += NumericTextBox_KeyPress;
            minuteSpawn.KeyPress += NumericTextBox_KeyPress;
            locationX.KeyPress += NumericTextBox_KeyPress;
            locationY.KeyPress += NumericTextBox_KeyPress;
            locationZ.KeyPress += NumericTextBox_KeyPress;
            level.KeyPress += NumericTextBox_KeyPress;
            lifetime.KeyPress += NumericTextBox_KeyPress;
            multiplier.KeyPress += NumericTextBox_KeyPress;

            PhysicalCriticalStrikeChance.KeyPress += FloatTextBox_KeyPress;
            SpellCriticalStrikeChance.KeyPress += FloatTextBox_KeyPress;
            PhysicalPower.KeyPress += FloatTextBox_KeyPress;
            ResourcePower.KeyPress += FloatTextBox_KeyPress;
            ResourceYieldModifier.KeyPress += FloatTextBox_KeyPress;
            PhysicalResistance.KeyPress += FloatTextBox_KeyPress;
            SunResistance.KeyPress += NumericTextBox_KeyPress;
            HolyResistance.KeyPress += NumericTextBox_KeyPress;
            SilverCoinResistance.KeyPress += NumericTextBox_KeyPress;
            PassiveHealthRegen.KeyPress += FloatTextBox_KeyPress;
            HealthRecovery.KeyPress += FloatTextBox_KeyPress;
            HealingReceived.KeyPress += FloatTextBox_KeyPress;
            BloodEfficiency.KeyPress += FloatTextBox_KeyPress;
            PhysicalCriticalStrikeDamage.KeyPress += FloatTextBox_KeyPress;
            SpellCriticalStrikeDamage.KeyPress += FloatTextBox_KeyPress;
            SpellPower.KeyPress += FloatTextBox_KeyPress;
            SiegePower.KeyPress += FloatTextBox_KeyPress;
            ReducedResourceDurabilityLoss.KeyPress += FloatTextBox_KeyPress;
            SpellResistance.KeyPress += FloatTextBox_KeyPress;
            FireResistance.KeyPress += NumericTextBox_KeyPress;
            SilverResistance.KeyPress += NumericTextBox_KeyPress;
            GarlicResistance.KeyPress += NumericTextBox_KeyPress;
            CCReduction.KeyPress += NumericTextBox_KeyPress;
            DamageReduction.KeyPress += FloatTextBox_KeyPress;
            ShieldAbsorbModifier.KeyPress += FloatTextBox_KeyPress;

            languagesBox.SelectedIndexChanged += new System.EventHandler(SelectedLanguageChanged);
            ConfigItem = new ItemConfig();
            ConfigItem.Visible = false;
            aplicarFiltros(ConfigItem);
            ConfigItem.ModelSaved += ItemSaved;
            itemsList.SelectedIndexChanged += SelectedItemIndexChanged;

        }

        private void ItemSaved(object sender, ItemModel e)
        {
            // Actualiza el BindingList para reflejar los cambios
            int index = ItemsList.IndexOf(e);
            if (index >= 0)
            {
                ItemsList.ResetItem(index); // Refresca el elemento en la lista
            }

            itemsList.Refresh();
            itemsList.SelectedIndex = -1;
            currentIndex = -1;
            ConfigItem.Visible = false;
            ConfigItem.MarkSavedChanges();
            lastAddedItem = null;

            MessageBox.Show($"Item {e.name} Saved Successfully");
        }

        private void aplicarFiltros(UserControl filtro)
        {
            filtro.Dock = DockStyle.Fill;
            panelItem.Controls.Clear();
            panelItem.Controls.Add(filtro);
            filtro.BringToFront();
        }

        private void TextBox_Changed(object sender, EventArgs e)
        {
            changesSaved = false;
        }

        public void LoadModel(CharModel selectedModel)
        {

            currentModel = selectedModel;

            if (selectedModel.name == "New Boss")
            {
                name.Text = selectedModel.name;

                ClearAlltextBox();

            }
            else
            {
                name.Text = selectedModel.name;
                prefabGUID.Text = selectedModel.PrefabGUID.ToString();
                assetName.Text = selectedModel.AssetName;

                level.Text = selectedModel.level.ToString();
                lifetime.Text = selectedModel.Lifetime.ToString();
                multiplier.Text = selectedModel.multiplier.ToString();

                if(selectedModel.Hour != string.Empty)
                {
                    string[] stringHourSpawn = selectedModel.Hour.Split(':');
                    hourSpawn.Text = stringHourSpawn[0];
                    minuteSpawn.Text = stringHourSpawn[1];
                } else
                {
                    hourSpawn.Text = "00";
                    minuteSpawn.Text = "00";
                }

                locationX.Text = selectedModel.x.ToString();
                locationY.Text = selectedModel.y.ToString();
                locationZ.Text = selectedModel.z.ToString();

                PhysicalCriticalStrikeChance.Text = selectedModel.unitStats.PhysicalCriticalStrikeChance.ToString();
                SpellCriticalStrikeChance.Text = selectedModel.unitStats.SpellCriticalStrikeChance.ToString();
                PhysicalPower.Text = selectedModel.unitStats.PhysicalPower.ToString();
                ResourcePower.Text = selectedModel.unitStats.ResourcePower.ToString();
                ResourceYieldModifier.Text = selectedModel.unitStats.ResourceYieldModifier.ToString();
                PhysicalResistance.Text = selectedModel.unitStats.PhysicalResistance.ToString();
                SunResistance.Text = selectedModel.unitStats.SunResistance.ToString();
                HolyResistance.Text = selectedModel.unitStats.HolyResistance.ToString();
                SilverCoinResistance.Text = selectedModel.unitStats.SilverCoinResistance.ToString();
                PassiveHealthRegen.Text = selectedModel.unitStats.PassiveHealthRegen.ToString();
                HealthRecovery.Text = selectedModel.unitStats.HealthRecovery.ToString();
                HealingReceived.Text = selectedModel.unitStats.HealingReceived.ToString();
                BloodEfficiency.Text = selectedModel.unitStats.BloodEfficiency.ToString();
                PhysicalCriticalStrikeDamage.Text = selectedModel.unitStats.PhysicalCriticalStrikeDamage.ToString();
                SpellCriticalStrikeDamage.Text = selectedModel.unitStats.SpellCriticalStrikeDamage.ToString();
                SpellPower.Text = selectedModel.unitStats.SpellPower.ToString();
                SiegePower.Text = selectedModel.unitStats.SiegePower.ToString();
                ReducedResourceDurabilityLoss.Text = selectedModel.unitStats.ReducedResourceDurabilityLoss.ToString();
                SpellResistance.Text = selectedModel.unitStats.SpellResistance.ToString();
                FireResistance.Text = selectedModel.unitStats.FireResistance.ToString();
                SilverResistance.Text = selectedModel.unitStats.SilverResistance.ToString();
                GarlicResistance.Text = selectedModel.unitStats.GarlicResistance.ToString();
                CCReduction.Text = selectedModel.unitStats.CCReduction.ToString();
                DamageReduction.Text = selectedModel.unitStats.DamageReduction.ToString();
                ShieldAbsorbModifier.Text = selectedModel.unitStats.ShieldAbsorbModifier.ToString();

                var items = selectedModel.items;
                ItemsList.Clear();
                foreach ( ItemModel item in items)
                {
                    ItemsList.Add(item);
                }

                itemsList.SelectedIndex = -1;
                currentIndex = -1;

                

            }

            changesSaved = false;

        }

        private void SelectedLanguageChanged(object sender, EventArgs e)
        {
            // Obtén el ComboBox que disparó el evento
            ComboBox comboBox = (ComboBox)sender;

            // Obtén el modelo seleccionado
            LanguageModel selectedModel = (LanguageModel)comboBox.SelectedItem;

            charactesCombo.SelectedIndexChanged -= SelectedBossChanged;
            LoadChars(selectedModel.valueNpc);
        }

        private void LoadChars(string language)
        {

            ResourceAccessor accessor = new ResourceAccessor();
            charactesCombo.DataSource = accessor.DeserializeJsonResource<List<CharModel>>(language)
                .GroupBy(c => new { c.name, c.level })
                .Select(g => g.First())
                .OrderBy(c => c.name)
                .ThenBy(c => c.level)
                .ToList();

            if (currentModel == null || currentModel.name == "New Boss")
            {
                charactesCombo.Text = "Select Character";

            } else
            {
                charactesCombo.Text = currentModel.name;
            }

            charactesCombo.SelectedIndexChanged += SelectedBossChanged;

        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            changesSaved = false;
        }

        private void FloatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, teclas de control, un signo negativo y un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Solo permitir un signo negativo al inicio del texto
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.Length > 0))
            {
                e.Handled = true;
            }

            changesSaved = false;
        }

        private void SelectedBossChanged(object sender, EventArgs e)
        {
            
            // Obtén el ComboBox que disparó el evento
            ComboBox comboBox = (ComboBox)sender;

            // Obtén el modelo seleccionado
            CharModel selectedModel = (CharModel)comboBox.SelectedItem;

            charSelected = selectedModel;

            name.Text = selectedModel.name;
            prefabGUID.Text = selectedModel.PrefabGUID.ToString();
            assetName.Text = selectedModel.AssetName;

            level.Text = selectedModel.level.ToString();
            lifetime.Text = selectedModel.Lifetime.ToString();
            multiplier.Text = "1";

            hourSpawn.Text = "00";
            minuteSpawn.Text = "00";

            locationX.Text = selectedModel.x.ToString();
            locationY.Text = selectedModel.y.ToString();
            locationZ.Text = selectedModel.z.ToString();

            PhysicalCriticalStrikeChance.Text = selectedModel.unitStats.PhysicalCriticalStrikeChance.ToString();
            SpellCriticalStrikeChance.Text = selectedModel.unitStats.SpellCriticalStrikeChance.ToString();
            PhysicalPower.Text = selectedModel.unitStats.PhysicalPower.ToString();
            ResourcePower.Text = selectedModel.unitStats.ResourcePower.ToString();
            ResourceYieldModifier.Text = selectedModel.unitStats.ResourceYieldModifier.ToString();
            PhysicalResistance.Text = selectedModel.unitStats.PhysicalResistance.ToString();
            SunResistance.Text = selectedModel.unitStats.SunResistance.ToString();
            HolyResistance.Text = selectedModel.unitStats.HolyResistance.ToString();
            SilverCoinResistance.Text = selectedModel.unitStats.SilverCoinResistance.ToString();
            PassiveHealthRegen.Text = selectedModel.unitStats.PassiveHealthRegen.ToString();
            HealthRecovery.Text = selectedModel.unitStats.HealthRecovery.ToString();
            HealingReceived.Text = selectedModel.unitStats.HealingReceived.ToString();
            BloodEfficiency.Text = selectedModel.unitStats.BloodEfficiency.ToString();
            PhysicalCriticalStrikeDamage.Text = selectedModel.unitStats.PhysicalCriticalStrikeDamage.ToString();
            SpellCriticalStrikeDamage.Text = selectedModel.unitStats.SpellCriticalStrikeDamage.ToString();
            SpellPower.Text = selectedModel.unitStats.SpellPower.ToString();
            SiegePower.Text = selectedModel.unitStats.SiegePower.ToString();
            ReducedResourceDurabilityLoss.Text = selectedModel.unitStats.ReducedResourceDurabilityLoss.ToString();
            SpellResistance.Text = selectedModel.unitStats.SpellResistance.ToString();
            FireResistance.Text = selectedModel.unitStats.FireResistance.ToString();
            SilverResistance.Text = selectedModel.unitStats.SilverResistance.ToString();
            GarlicResistance.Text = selectedModel.unitStats.GarlicResistance.ToString();
            CCReduction.Text = selectedModel.unitStats.CCReduction.ToString();
            DamageReduction.Text = selectedModel.unitStats.DamageReduction.ToString();
            ShieldAbsorbModifier.Text = selectedModel.unitStats.ShieldAbsorbModifier.ToString();

            EnabledEdit(true);

        }

        public void saveBoss_Click(object sender, EventArgs e)
        {
            if (currentModel != null)
            {
                currentModel.name = name.Text;
                
                currentModel.level = int.Parse(level.Text);
                currentModel.Lifetime = int.Parse(lifetime.Text);
                currentModel.multiplier = int.Parse(multiplier.Text);

                var newHourSpawn = $"{hourSpawn.Text}:{minuteSpawn.Text}";
                currentModel.Hour = newHourSpawn;

                currentModel.x = float.Parse(locationX.Text);
                currentModel.y = float.Parse(locationY.Text);
                currentModel.z = float.Parse(locationZ.Text);

                currentModel.PrefabGUID = int.Parse(prefabGUID.Text);
                currentModel.AssetName = assetName.Text;
                currentModel.nameHash = name.Text.GetHashCode().ToString();

                currentModel.unitStats = new UnitStatsModel();
                currentModel.unitStats.PhysicalCriticalStrikeChance = float.Parse(PhysicalCriticalStrikeChance.Text);
                currentModel.unitStats.PhysicalCriticalStrikeDamage = float.Parse(PhysicalCriticalStrikeDamage.Text);
                currentModel.unitStats.SpellCriticalStrikeChance = float.Parse(SpellCriticalStrikeChance.Text);
                currentModel.unitStats.SpellCriticalStrikeDamage = float.Parse(SpellCriticalStrikeDamage.Text);
                currentModel.unitStats.PhysicalPower = float.Parse(PhysicalPower.Text);
                currentModel.unitStats.SpellPower = float.Parse(SpellPower.Text);
                currentModel.unitStats.ResourcePower = float.Parse(ResourcePower.Text);
                currentModel.unitStats.SiegePower = float.Parse(SiegePower.Text);
                currentModel.unitStats.ResourceYieldModifier = float.Parse(ResourceYieldModifier.Text);
                currentModel.unitStats.ReducedResourceDurabilityLoss = float.Parse(ReducedResourceDurabilityLoss.Text);
                currentModel.unitStats.PhysicalResistance = float.Parse(PhysicalResistance.Text);
                currentModel.unitStats.SpellResistance = float.Parse(SpellResistance.Text);
                currentModel.unitStats.SunResistance = int.Parse(SunResistance.Text);
                currentModel.unitStats.FireResistance = int.Parse(FireResistance.Text);
                currentModel.unitStats.HolyResistance = int.Parse(HolyResistance.Text);
                currentModel.unitStats.SilverResistance = int.Parse(SilverResistance.Text);
                currentModel.unitStats.SilverCoinResistance = int.Parse(SilverCoinResistance.Text);
                currentModel.unitStats.GarlicResistance = int.Parse(GarlicResistance.Text);
                currentModel.unitStats.PassiveHealthRegen = float.Parse(PassiveHealthRegen.Text);
                currentModel.unitStats.CCReduction = int.Parse(CCReduction.Text);
                currentModel.unitStats.HealthRecovery = float.Parse(HealthRecovery.Text);
                currentModel.unitStats.DamageReduction = float.Parse(DamageReduction.Text);
                currentModel.unitStats.HealingReceived = float.Parse(HealingReceived.Text);
                currentModel.unitStats.ShieldAbsorbModifier = float.Parse(ShieldAbsorbModifier.Text);
                currentModel.unitStats.BloodEfficiency = float.Parse(BloodEfficiency.Text);
                
                currentModel.items = new List<ItemModel>();

                foreach (ItemModel item in ItemsList)
                {
                    currentModel.items.Add(item);
                }

                changesSaved = true;
                ConfigItem.MarkSavedChanges();
                ConfigItem.Visible = false;
                ModelSaved?.Invoke(this, currentModel);

                currentModel = null;
            }

        }

        public void MarkUnsavedChanges()
        {
            changesSaved = false;
        }

        public void MarkSavedChanges()
        {
            changesSaved = true;
        }

        public bool HasUnsavedChanges()
        {
            return !changesSaved;
        }

        public void ClearAlltextBox()
        {
            string String = string.Empty;

            assetName.Text = String;
            prefabGUID.Text = String;
            level.Text = String;
            lifetime.Text = String;
            multiplier.Text = String;

            hourSpawn.Text = String;
            minuteSpawn.Text = String;

            locationX.Text = String;
            locationY.Text = String;
            locationZ.Text = String;

            PhysicalCriticalStrikeChance.Text = String;
            SpellCriticalStrikeChance.Text = String;
            PhysicalPower.Text = String;
            ResourcePower.Text = String;
            ResourceYieldModifier.Text = String;
            PhysicalResistance.Text = String;
            SunResistance.Text = String;
            HolyResistance.Text = String;
            SilverCoinResistance.Text = String;
            PassiveHealthRegen.Text = String;
            HealthRecovery.Text = String;
            HealingReceived.Text = String;
            BloodEfficiency.Text = String;
            PhysicalCriticalStrikeDamage.Text = String;
            SpellCriticalStrikeDamage.Text = String;
            SpellPower.Text = String;
            SiegePower.Text = String;
            ReducedResourceDurabilityLoss.Text = String;
            SpellResistance.Text = String;
            FireResistance.Text = String;
            SilverResistance.Text = String;
            GarlicResistance.Text = String;
            CCReduction.Text = String;
            DamageReduction.Text = String;
            ShieldAbsorbModifier.Text = String;
        }

        public void EnabledEdit(bool enabled)
        {
            name.Enabled = enabled;
            prefabGUID.Enabled = enabled;
            assetName.Enabled = enabled;
            level.Enabled = enabled;
            lifetime.Enabled = enabled;
            multiplier.Enabled = enabled;

            hourSpawn.Enabled = enabled;
            minuteSpawn.Enabled = enabled;

            locationX.Enabled = enabled;
            locationY.Enabled = enabled;
            locationZ.Enabled = enabled;

            PhysicalCriticalStrikeChance.Enabled = enabled;
            SpellCriticalStrikeChance.Enabled = enabled;
            PhysicalPower.Enabled = enabled;
            ResourcePower.Enabled = enabled;
            ResourceYieldModifier.Enabled = enabled;
            PhysicalResistance.Enabled = enabled;
            SunResistance.Enabled = enabled;
            HolyResistance.Enabled = enabled;
            SilverCoinResistance.Enabled = enabled;
            PassiveHealthRegen.Enabled = enabled;
            HealthRecovery.Enabled = enabled;
            HealingReceived.Enabled = enabled;
            BloodEfficiency.Enabled = enabled;
            PhysicalCriticalStrikeDamage.Enabled = enabled;
            SpellCriticalStrikeDamage.Enabled = enabled;
            SpellPower.Enabled = enabled;
            SiegePower.Enabled = enabled;
            ReducedResourceDurabilityLoss.Enabled = enabled;
            SpellResistance.Enabled = enabled;
            FireResistance.Enabled = enabled;
            SilverResistance.Enabled = enabled;
            GarlicResistance.Enabled = enabled;
            CCReduction.Enabled = enabled;
            DamageReduction.Enabled = enabled;
            ShieldAbsorbModifier.Enabled = enabled;

            languagesBox.Enabled = !enabled;
            charactesCombo.Enabled = !enabled;
        }

        private void AddItem_Click(object sender, EventArgs e)
        {

            // Verificar si hay cambios no guardados
            if (ConfigItem.HasUnsavedChanges())
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to discard them?", "Unsaved Changes", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    // Elimina el último elemento agregado si hay cambios no guardados
                    if (lastAddedItem != null && lastAddedItem.name == "New Item")
                    {
                        ConfigItem.MarkSavedChanges();
                        ItemsList.Remove(lastAddedItem);
                        itemsList.SelectedIndex = -1;
                        itemsList.Refresh();
                        lastAddedItem = null;
                    }
                    else
                    {
                        ConfigItem.MarkSavedChanges();
                        lastAddedItem = null;
                    }
                }
            }

            var selectedModel = new ItemModel();
            selectedModel.name = "New Item";
            ItemsList.Add(selectedModel);
            itemsList.SelectedItem = selectedModel;
            lastAddedItem = selectedModel;
            ConfigItem.LoadModel(selectedModel);
            ConfigItem.EnabledEdit(false);
            ConfigItem.Visible = true;

        }

        private void SelectedItemIndexChanged(object sender, EventArgs e)
        {
            if (itemsList.SelectedIndex == currentIndex) return;

            if (itemsList.SelectedItem is ItemModel selectedModel)
            {

                if (ConfigItem.HasUnsavedChanges())
                {
                    var result = MessageBox.Show("You have unsaved changes. Do you want to discard them?", "Unsaved Changes", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        itemsList.SelectedIndex = currentIndex;
                        return;
                    }
                    else
                    {
                        // Elimina el último elemento agregado si hay cambios no guardados
                        if (lastAddedItem != null && lastAddedItem.name == "New Item")
                        {
                            ConfigItem.MarkSavedChanges();
                            itemsList.SelectedIndex = -1;
                            ItemsList.Remove(lastAddedItem);
                            itemsList.Refresh();
                            lastAddedItem = null;
                            ConfigItem.Visible = false;
                        }
                        else
                        {
                            lastAddedItem = null;
                        }
                    }
                }

                currentIndex = itemsList.SelectedIndex;
                ConfigItem.LoadModel(selectedModel);
                ConfigItem.EnabledEdit(true);
                ConfigItem.Visible = true;
            }

        }

        private void eliminarItem_Click(object sender, EventArgs e)
        {
            if (itemsList.SelectedItem is ItemModel selectedModel)
            {
                var result = MessageBox.Show("Do you want to delete the selected Item?", "Delete Item", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    ConfigItem.MarkSavedChanges();
                    ItemsList.Remove(selectedModel);
                    itemsList.Refresh();
                    itemsList.SelectedIndex = -1;
                    currentIndex = -100;
                    ConfigItem.Visible = false;
                }
            }
        }
    }
}
