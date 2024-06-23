using BloodyConfig.BloodyBoss.DB;
using BloodyConfig.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodyConfig.BloodyBoss
{
    public partial class ItemConfig : UserControl
    {

        private bool changesSaved = true;
        private ItemModel currentModel;
        private ItemModel itemSelected;

        public event EventHandler<ItemModel> ModelSaved;


        private List<LanguageModel> languages = LanguagesService.GetLanguages();

        public ItemConfig()
        {
            InitializeComponent();
        }

        private void ItemConfig_Load(object sender, EventArgs e)
        {
            languagesBox.SelectedIndexChanged += new System.EventHandler(SelectedLanguageChanged);
            name.TextChanged += TextBox_Changed;
            prefabGUID.KeyPress += NumericTextBox_KeyPress;
            stack.KeyPress += NumericTextBox_KeyPress;
            chance.KeyPress += NumericTextBox_KeyPress;

            LoadItem(languages[0].valueItem);
            languagesBox.DataSource = languages;
        }

        private void TextBox_Changed(object sender, EventArgs e)
        {
            changesSaved = false;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void SelectedLanguageChanged(object sender, EventArgs e)
        {
            // Obtén el ComboBox que disparó el evento
            ComboBox comboBox = (ComboBox)sender;

            // Obtén el modelo seleccionado
            LanguageModel selectedModel = (LanguageModel)comboBox.SelectedItem;

            itemBox.SelectedIndexChanged -= SelectedItemChanged;
            LoadItem(selectedModel.valueItem);
        }

        private void LoadItem(string language)
        {
            ResourceAccessor accessor = new ResourceAccessor();
            itemBox.DataSource = accessor.DeserializeJsonResource<List<ItemModel>>(language)
                .GroupBy(c => new { c.name })
                .Select(g => g.First())
                .OrderBy(c => c.name)
                .ToList();

            if (currentModel == null || currentModel.name == "New Item")
            {
                itemBox.Text = "Select Item";

            }
            else
            {
                itemBox.Text = currentModel.name;
            }

            itemBox.SelectedIndexChanged += SelectedItemChanged;
        }

        private void SelectedItemChanged(object sender, EventArgs e)
        {
            // Obtén el ComboBox que disparó el evento
            ComboBox comboBox = (ComboBox)sender;

            // Obtén el modelo seleccionado
            ItemModel selectedModel = (ItemModel)comboBox.SelectedItem;

            itemSelected = selectedModel;

            name.Text = selectedModel.name;
            prefabGUID.Text = selectedModel.ItemID.ToString();
            stack.Text = selectedModel.Stack.ToString();
            chance.Text = selectedModel.Chance.ToString();

            EnabledEdit(true);
        }

        public void LoadModel(ItemModel selectedModel)
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
                prefabGUID.Text = selectedModel.ItemID.ToString();
                chance.Text = selectedModel.Chance.ToString();
                stack.Text = selectedModel.Stack.ToString();
            }

            changesSaved = false;

        }

        public void ClearAlltextBox()
        {
            string String = string.Empty;

            name.Text = String;
            prefabGUID.Text = String;
            stack.Text = String;
            chance.Text = String;
        }



        public void EnabledEdit(bool enabled)
        {
            name.Enabled = enabled;
            prefabGUID.Enabled = enabled;
            chance.Enabled = enabled;
            stack.Enabled = enabled;

            languagesBox.Enabled = !enabled;
            itemBox.Enabled = !enabled;
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

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (currentModel != null)
            {
                currentModel.name = name.Text;

                currentModel.ItemID = int.Parse(prefabGUID.Text);
                currentModel.Stack = int.Parse(stack.Text);
                currentModel.Chance = int.Parse(chance.Text);
                ModelSaved?.Invoke(this, currentModel);

                currentModel = null;
            }

        }
    }
}
