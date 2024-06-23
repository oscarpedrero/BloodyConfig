using BloodyConfig.BloodyBoss;
using BloodyConfig.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace BloodyConfig
{
    public partial class vistaBloodyBoss : UserControl
    {

        public static BindingList<CharModel> Chars = new BindingList<CharModel>();

        private ConfigJefe ConfigJefeControl;
        private int currentIndex;

        private CharModel lastAddedItem;

        private string filePathImport;

        public vistaBloodyBoss()
        {
            InitializeComponent();
            listBosses.DataSource = Chars;
            listBosses.SelectedIndexChanged += SelectedBossIndexChanged;
            ConfigJefeControl = new ConfigJefe();
            ConfigJefeControl.Visible = false;
            aplicarFiltros(ConfigJefeControl);

            ConfigJefeControl.ModelSaved += BossSaved;
        }

        private void BossSaved(object sender, CharModel e)
        {
            // Actualiza el BindingList para reflejar los cambios
            int index = Chars.IndexOf(e);
            if (index >= 0)
            {
                Chars.ResetItem(index); // Refresca el elemento en la lista
            }

            listBosses.Refresh();
            listBosses.SelectedIndex = -1;
            currentIndex = -1;
            ConfigJefeControl.Visible = false;
            ConfigJefeControl.MarkSavedChanges();
            lastAddedItem = null;

            MessageBox.Show($"Boss {e.name} Saved Successfully");
        }

        private void SelectedBossIndexChanged(object sender, EventArgs e)
        {
            if (listBosses.SelectedIndex == currentIndex) return;

            if (listBosses.SelectedItem is CharModel selectedModel)
            {

                if (ConfigJefeControl.HasUnsavedChanges())
                {
                    var result = MessageBox.Show("You have unsaved changes. Do you want to discard them?", "Unsaved Changes", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        listBosses.SelectedIndex = currentIndex;
                        return;
                    }
                    else
                    {
                        // Elimina el último elemento agregado si hay cambios no guardados
                        if (lastAddedItem != null && lastAddedItem.name == "New Boss")
                        {
                            ConfigJefeControl.MarkSavedChanges();
                            listBosses.SelectedIndex = -1;
                            Chars.Remove(lastAddedItem);
                            listBosses.Refresh();
                            lastAddedItem = null;
                            ConfigJefeControl.Visible = false;
                        } else
                        {
                            lastAddedItem = null;
                        }
                    }
                }

                currentIndex = listBosses.SelectedIndex;
                ConfigJefeControl.LoadModel(selectedModel);
                ConfigJefeControl.EnabledEdit(true);
                ConfigJefeControl.Visible = true;
            }
            
        }

        private void filtroPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void aplicarFiltros(UserControl filtro)
        {
            filtro.Dock = DockStyle.Fill;
            panelConfigJefe.Controls.Clear();
            panelConfigJefe.Controls.Add(filtro);
            filtro.BringToFront();
        }

        private void anadiJefe_Click(object sender, EventArgs e)
        {

            // Verificar si hay cambios no guardados
            if (ConfigJefeControl.HasUnsavedChanges())
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to discard them?", "Unsaved Changes", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    // Elimina el último elemento agregado si hay cambios no guardados
                    if (lastAddedItem != null && lastAddedItem.name == "New Boss")
                    {
                        ConfigJefeControl.MarkSavedChanges();
                        Chars.Remove(lastAddedItem);
                        listBosses.SelectedIndex = -1;
                        listBosses.Refresh();
                        lastAddedItem = null;
                    } else
                    {
                        ConfigJefeControl.MarkSavedChanges();
                        lastAddedItem = null;
                    }
                }
            }

            var selectedModel = new CharModel();
            selectedModel.name = "New Boss";
            selectedModel.unitStats = new UnitStatsModel();
            Chars.Add(selectedModel);
            listBosses.SelectedItem = selectedModel;
            lastAddedItem = selectedModel;
            ConfigJefeControl.LoadModel(selectedModel);
            ConfigJefeControl.EnabledEdit(false);
            ConfigJefeControl.Visible = true;
            
        }

        private void ImportFileButton_Click(object sender, EventArgs e)
        {
            if (Chars.Count > 0)
            {
                var result = MessageBox.Show("If you import a file you will lose the configuration you currently have loaded. Do you want to continue?", "Import File", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
               
            }
            ConfigJefeControl.Visible = false;
            ImportFile();
        }

        private void ImportFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                openFileDialog.Title = "Select a JSON file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo seleccionado
                    string filePath = openFileDialog.FileName;
                    filePathImport = filePath;

                    Chars.Clear();

                    var charsImport = new List<CharModel>();
                    try
                    {
                        ResourceAccessor accessor = new ResourceAccessor();
                        charsImport = accessor.DeserializeJsonFile<List<CharModel>>(filePath)
                            .GroupBy(c => new { c.name, c.level })
                            .Select(g => g.First())
                            .OrderBy(c => c.name)
                            .ThenBy(c => c.level)
                            .ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error in import: {ex.Message}");
                    }

                    if (charsImport.Count <= 0)
                    {
                        MessageBox.Show($"No bosses for import");
                    }
                    else
                    {
                        foreach (CharModel boss in charsImport)
                        {
                            Chars.Add(boss);
                        }

                        listBosses.SelectedIndex = -1;
                        currentIndex = -1;
                    }

                }
            }
        }

        private void ExportFileButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.Title = "Save a JSON file";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo seleccionado para guardar
                    string filePath = saveFileDialog.FileName;

                    var bossExport = new List<CharModel>();

                    foreach(CharModel boss in Chars)
                    {
                        bossExport.Add(boss);
                    }
                    

                    // Serializar los datos a JSON y guardarlos en el archivo
                    string jsonData = System.Text.Json.JsonSerializer.Serialize(bossExport, new JsonSerializerOptions { WriteIndented = true });
                    System.IO.File.WriteAllText(filePath, jsonData);

                    MessageBox.Show("File saved successfully.");
                }
            }
        }
    }
}
