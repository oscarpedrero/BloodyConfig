using BloodyConfig.DB;
using System;
using System.Windows.Forms;

namespace BloodyConfig.BloodyBoss
{
    public partial class ModConfig : UserControl
    {
        private ModConfigurationModel _model;
        private bool _isLoading = false;

        public event EventHandler<ModConfigurationModel> ModelSaved;

        public ModConfig()
        {
            InitializeComponent();
            LoadDefaultConfiguration();
            SetupEventHandlers();
        }

        private void LoadDefaultConfiguration()
        {
            _model = new ModConfigurationModel();
            LoadModelToUI();
        }

        private void SetupEventHandlers()
        {
            // General Config events
            chkEnabled.CheckedChanged += OnConfigurationChanged;
            numBuffForWorldBoss.ValueChanged += OnConfigurationChanged;
            chkPlayersMultiplier.CheckedChanged += OnConfigurationChanged;
            chkClearDropTable.CheckedChanged += OnConfigurationChanged;
            chkMinionDamage.CheckedChanged += OnConfigurationChanged;
            chkRandomBoss.CheckedChanged += OnConfigurationChanged;
            chkBuffAfterKillingEnabled.CheckedChanged += OnConfigurationChanged;
            numBuffAfterKillingPrefabGUID.ValueChanged += OnConfigurationChanged;
            chkTeamBossEnable.CheckedChanged += OnConfigurationChanged;

            // Messages events
            txtSpawnMessage.TextChanged += OnConfigurationChanged;
            txtDespawnMessage.TextChanged += OnConfigurationChanged;
            txtKillMessage.TextChanged += OnConfigurationChanged;
            txtVBloodFinalConcat.TextChanged += OnConfigurationChanged;

            // Phase Messages events
            txtPhaseNormalTemplate.TextChanged += OnConfigurationChanged;
            txtPhaseHardTemplate.TextChanged += OnConfigurationChanged;
            txtPhaseEpicTemplate.TextChanged += OnConfigurationChanged;
            txtPhaseLegendaryTemplate.TextChanged += OnConfigurationChanged;
            txtPhaseNormalName.TextChanged += OnConfigurationChanged;
            txtPhaseHardName.TextChanged += OnConfigurationChanged;
            txtPhaseEpicName.TextChanged += OnConfigurationChanged;
            txtPhaseLegendaryName.TextChanged += OnConfigurationChanged;

            // Dynamic Scaling events
            chkEnableDynamicScaling.CheckedChanged += OnConfigurationChanged;
            numBaseHealthMultiplier.ValueChanged += OnConfigurationChanged;
            numHealthPerPlayer.ValueChanged += OnConfigurationChanged;
            numDamagePerPlayer.ValueChanged += OnConfigurationChanged;
            numMaxPlayersForScaling.ValueChanged += OnConfigurationChanged;

            // Progressive Difficulty events
            chkEnableProgressiveDifficulty.CheckedChanged += OnConfigurationChanged;
            numDifficultyIncrease.ValueChanged += OnConfigurationChanged;
            numMaxDifficultyMultiplier.ValueChanged += OnConfigurationChanged;
            chkResetDifficultyOnKill.CheckedChanged += OnConfigurationChanged;

            // Teleport events
            chkEnableTeleportCommand.CheckedChanged += OnConfigurationChanged;
            chkTeleportAdminOnly.CheckedChanged += OnConfigurationChanged;
            numTeleportCooldown.ValueChanged += OnConfigurationChanged;
            chkTeleportOnlyToActiveBosses.CheckedChanged += OnConfigurationChanged;
            chkTeleportRequireBossAlive.CheckedChanged += OnConfigurationChanged;
            txtTeleportCostItemGUID.TextChanged += OnConfigurationChanged;
            numTeleportCostAmount.ValueChanged += OnConfigurationChanged;

            // Phase Announcements events
            chkEnablePhaseAnnouncements.CheckedChanged += OnConfigurationChanged;
            chkAnnounceEveryPhase.CheckedChanged += OnConfigurationChanged;
            chkAnnounceMilestoneSpawns.CheckedChanged += OnConfigurationChanged;

            // Button events
            btnSave.Click += BtnSave_Click;
            btnImport.Click += BtnImport_Click;
            btnReset.Click += BtnReset_Click;

            // Enable/disable controls based on main checkboxes
            chkEnableDynamicScaling.CheckedChanged += (s, e) => UpdateDynamicScalingControls();
            chkEnableProgressiveDifficulty.CheckedChanged += (s, e) => UpdateProgressiveDifficultyControls();
            chkEnableTeleportCommand.CheckedChanged += (s, e) => UpdateTeleportControls();
            chkEnablePhaseAnnouncements.CheckedChanged += (s, e) => UpdatePhaseAnnouncementControls();
        }

        private void OnConfigurationChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
            {
                SaveUIToModel();
            }
        }

        public void LoadModel(ModConfigurationModel model)
        {
            _model = model ?? new ModConfigurationModel();
            LoadModelToUI();
        }

        private void LoadModelToUI()
        {
            _isLoading = true;

            try
            {
                // General Config
                chkEnabled.Checked = _model.GeneralConfig.Enabled;
                numBuffForWorldBoss.Value = _model.GeneralConfig.BuffForWorldBoss;
                chkPlayersMultiplier.Checked = _model.GeneralConfig.PlayersMultiplier;
                chkClearDropTable.Checked = _model.GeneralConfig.ClearDropTable;
                chkMinionDamage.Checked = _model.GeneralConfig.MinionDamage;
                chkRandomBoss.Checked = _model.GeneralConfig.RandomBoss;
                chkBuffAfterKillingEnabled.Checked = _model.GeneralConfig.BuffAfterKillingEnabled;
                numBuffAfterKillingPrefabGUID.Value = _model.GeneralConfig.BuffAfterKillingPrefabGUID;
                chkTeamBossEnable.Checked = _model.GeneralConfig.TeamBossEnable;

                // Messages
                txtSpawnMessage.Text = _model.GeneralConfig.SpawnMessageBossTemplate;
                txtDespawnMessage.Text = _model.GeneralConfig.DespawnMessageBossTemplate;
                txtKillMessage.Text = _model.GeneralConfig.KillMessageBossTemplate;
                txtVBloodFinalConcat.Text = _model.GeneralConfig.VBloodFinalConcat;

                // Phase Messages
                txtPhaseNormalTemplate.Text = _model.GeneralConfig.PhaseNormalTemplate;
                txtPhaseHardTemplate.Text = _model.GeneralConfig.PhaseHardTemplate;
                txtPhaseEpicTemplate.Text = _model.GeneralConfig.PhaseEpicTemplate;
                txtPhaseLegendaryTemplate.Text = _model.GeneralConfig.PhaseLegendaryTemplate;
                txtPhaseNormalName.Text = _model.GeneralConfig.PhaseNormalName;
                txtPhaseHardName.Text = _model.GeneralConfig.PhaseHardName;
                txtPhaseEpicName.Text = _model.GeneralConfig.PhaseEpicName;
                txtPhaseLegendaryName.Text = _model.GeneralConfig.PhaseLegendaryName;

                // Dynamic Scaling
                chkEnableDynamicScaling.Checked = _model.AdvancedConfig.EnableDynamicScaling;
                numBaseHealthMultiplier.Value = (decimal)_model.AdvancedConfig.BaseHealthMultiplier;
                numHealthPerPlayer.Value = (decimal)_model.AdvancedConfig.HealthPerPlayer;
                numDamagePerPlayer.Value = (decimal)_model.AdvancedConfig.DamagePerPlayer;
                numMaxPlayersForScaling.Value = _model.AdvancedConfig.MaxPlayersForScaling;

                // Progressive Difficulty
                chkEnableProgressiveDifficulty.Checked = _model.AdvancedConfig.EnableProgressiveDifficulty;
                numDifficultyIncrease.Value = (decimal)_model.AdvancedConfig.DifficultyIncrease;
                numMaxDifficultyMultiplier.Value = (decimal)_model.AdvancedConfig.MaxDifficultyMultiplier;
                chkResetDifficultyOnKill.Checked = _model.AdvancedConfig.ResetDifficultyOnKill;

                // Teleport
                chkEnableTeleportCommand.Checked = _model.AdvancedConfig.EnableTeleportCommand;
                chkTeleportAdminOnly.Checked = _model.AdvancedConfig.TeleportAdminOnly;
                numTeleportCooldown.Value = (decimal)_model.AdvancedConfig.TeleportCooldown;
                chkTeleportOnlyToActiveBosses.Checked = _model.AdvancedConfig.TeleportOnlyToActiveBosses;
                chkTeleportRequireBossAlive.Checked = _model.AdvancedConfig.TeleportRequireBossAlive;
                txtTeleportCostItemGUID.Text = _model.AdvancedConfig.TeleportCostItemGUID;
                numTeleportCostAmount.Value = _model.AdvancedConfig.TeleportCostAmount;

                // Phase Announcements
                chkEnablePhaseAnnouncements.Checked = _model.AdvancedConfig.EnablePhaseAnnouncements;
                chkAnnounceEveryPhase.Checked = _model.AdvancedConfig.AnnounceEveryPhase;
                chkAnnounceMilestoneSpawns.Checked = _model.AdvancedConfig.AnnounceMilestoneSpawns;

                UpdateAllControlStates();
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void SaveUIToModel()
        {
            if (_model == null) return;

            // General Config
            _model.GeneralConfig.Enabled = chkEnabled.Checked;
            _model.GeneralConfig.BuffForWorldBoss = (int)numBuffForWorldBoss.Value;
            _model.GeneralConfig.PlayersMultiplier = chkPlayersMultiplier.Checked;
            _model.GeneralConfig.ClearDropTable = chkClearDropTable.Checked;
            _model.GeneralConfig.MinionDamage = chkMinionDamage.Checked;
            _model.GeneralConfig.RandomBoss = chkRandomBoss.Checked;
            _model.GeneralConfig.BuffAfterKillingEnabled = chkBuffAfterKillingEnabled.Checked;
            _model.GeneralConfig.BuffAfterKillingPrefabGUID = (int)numBuffAfterKillingPrefabGUID.Value;
            _model.GeneralConfig.TeamBossEnable = chkTeamBossEnable.Checked;

            // Messages
            _model.GeneralConfig.SpawnMessageBossTemplate = txtSpawnMessage.Text;
            _model.GeneralConfig.DespawnMessageBossTemplate = txtDespawnMessage.Text;
            _model.GeneralConfig.KillMessageBossTemplate = txtKillMessage.Text;
            _model.GeneralConfig.VBloodFinalConcat = txtVBloodFinalConcat.Text;

            // Phase Messages
            _model.GeneralConfig.PhaseNormalTemplate = txtPhaseNormalTemplate.Text;
            _model.GeneralConfig.PhaseHardTemplate = txtPhaseHardTemplate.Text;
            _model.GeneralConfig.PhaseEpicTemplate = txtPhaseEpicTemplate.Text;
            _model.GeneralConfig.PhaseLegendaryTemplate = txtPhaseLegendaryTemplate.Text;
            _model.GeneralConfig.PhaseNormalName = txtPhaseNormalName.Text;
            _model.GeneralConfig.PhaseHardName = txtPhaseHardName.Text;
            _model.GeneralConfig.PhaseEpicName = txtPhaseEpicName.Text;
            _model.GeneralConfig.PhaseLegendaryName = txtPhaseLegendaryName.Text;

            // Dynamic Scaling
            _model.AdvancedConfig.EnableDynamicScaling = chkEnableDynamicScaling.Checked;
            _model.AdvancedConfig.BaseHealthMultiplier = (float)numBaseHealthMultiplier.Value;
            _model.AdvancedConfig.HealthPerPlayer = (float)numHealthPerPlayer.Value;
            _model.AdvancedConfig.DamagePerPlayer = (float)numDamagePerPlayer.Value;
            _model.AdvancedConfig.MaxPlayersForScaling = (int)numMaxPlayersForScaling.Value;

            // Progressive Difficulty
            _model.AdvancedConfig.EnableProgressiveDifficulty = chkEnableProgressiveDifficulty.Checked;
            _model.AdvancedConfig.DifficultyIncrease = (float)numDifficultyIncrease.Value;
            _model.AdvancedConfig.MaxDifficultyMultiplier = (float)numMaxDifficultyMultiplier.Value;
            _model.AdvancedConfig.ResetDifficultyOnKill = chkResetDifficultyOnKill.Checked;

            // Teleport
            _model.AdvancedConfig.EnableTeleportCommand = chkEnableTeleportCommand.Checked;
            _model.AdvancedConfig.TeleportAdminOnly = chkTeleportAdminOnly.Checked;
            _model.AdvancedConfig.TeleportCooldown = (float)numTeleportCooldown.Value;
            _model.AdvancedConfig.TeleportOnlyToActiveBosses = chkTeleportOnlyToActiveBosses.Checked;
            _model.AdvancedConfig.TeleportRequireBossAlive = chkTeleportRequireBossAlive.Checked;
            _model.AdvancedConfig.TeleportCostItemGUID = txtTeleportCostItemGUID.Text;
            _model.AdvancedConfig.TeleportCostAmount = (int)numTeleportCostAmount.Value;

            // Phase Announcements
            _model.AdvancedConfig.EnablePhaseAnnouncements = chkEnablePhaseAnnouncements.Checked;
            _model.AdvancedConfig.AnnounceEveryPhase = chkAnnounceEveryPhase.Checked;
            _model.AdvancedConfig.AnnounceMilestoneSpawns = chkAnnounceMilestoneSpawns.Checked;
        }

        private void UpdateAllControlStates()
        {
            UpdateDynamicScalingControls();
            UpdateProgressiveDifficultyControls();
            UpdateTeleportControls();
            UpdatePhaseAnnouncementControls();
        }

        private void UpdateDynamicScalingControls()
        {
            bool enabled = chkEnableDynamicScaling.Checked;
            numBaseHealthMultiplier.Enabled = enabled;
            numHealthPerPlayer.Enabled = enabled;
            numDamagePerPlayer.Enabled = enabled;
            numMaxPlayersForScaling.Enabled = enabled;
        }

        private void UpdateProgressiveDifficultyControls()
        {
            bool enabled = chkEnableProgressiveDifficulty.Checked;
            numDifficultyIncrease.Enabled = enabled;
            numMaxDifficultyMultiplier.Enabled = enabled;
            chkResetDifficultyOnKill.Enabled = enabled;
        }

        private void UpdateTeleportControls()
        {
            bool enabled = chkEnableTeleportCommand.Checked;
            chkTeleportAdminOnly.Enabled = enabled;
            numTeleportCooldown.Enabled = enabled;
            chkTeleportOnlyToActiveBosses.Enabled = enabled;
            chkTeleportRequireBossAlive.Enabled = enabled;
            txtTeleportCostItemGUID.Enabled = enabled;
            numTeleportCostAmount.Enabled = enabled;
        }

        private void UpdatePhaseAnnouncementControls()
        {
            bool enabled = chkEnablePhaseAnnouncements.Checked;
            chkAnnounceEveryPhase.Enabled = enabled;
            chkAnnounceMilestoneSpawns.Enabled = enabled;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveUIToModel();
            ExportConfigToFile();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            ImportConfigFromFile();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset all advanced settings to default values?", 
                "Reset Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                LoadDefaultConfiguration();
                MessageBox.Show("Advanced configuration has been reset to default values.", "Reset Complete", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public ModConfigurationModel GetCurrentConfiguration()
        {
            SaveUIToModel();
            return _model;
        }

        public bool HasUnsavedChanges()
        {
            return true; // For simplicity, assume there are always potential changes
        }

        public void MarkSavedChanges()
        {
            // Implementation for marking changes as saved
        }

        private void ExportConfigToFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Configuration files (*.cfg)|*.cfg|All files (*.*)|*.*";
                saveFileDialog.Title = "Export BloodyBoss Configuration";
                saveFileDialog.FileName = "BloodyBoss.cfg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string configContent = GenerateConfigFileContent();
                        System.IO.File.WriteAllText(saveFileDialog.FileName, configContent);
                        MessageBox.Show($"Configuration exported successfully to:\n{saveFileDialog.FileName}", 
                            "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting configuration:\n{ex.Message}", 
                            "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ImportConfigFromFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Configuration files (*.cfg)|*.cfg|All files (*.*)|*.*";
                openFileDialog.Title = "Import BloodyBoss Configuration";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string configContent = System.IO.File.ReadAllText(openFileDialog.FileName);
                        ParseConfigFileContent(configContent);
                        LoadModelToUI();
                        MessageBox.Show($"Configuration imported successfully from:\n{openFileDialog.FileName}", 
                            "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing configuration:\n{ex.Message}", 
                            "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GenerateConfigFileContent()
        {
            var config = new System.Text.StringBuilder();
            
            config.AppendLine("# BloodyBoss Configuration File v2.1.0");
            config.AppendLine("# Generated by BloodyConfig Tool");
            config.AppendLine($"# Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            config.AppendLine();
            
            // General Configuration
            config.AppendLine("[General]");
            config.AppendLine($"Enabled = {_model.GeneralConfig.Enabled}");
            config.AppendLine($"BuffForWorldBoss = {_model.GeneralConfig.BuffForWorldBoss}");
            config.AppendLine($"PlayersMultiplier = {_model.GeneralConfig.PlayersMultiplier}");
            config.AppendLine($"ClearDropTable = {_model.GeneralConfig.ClearDropTable}");
            config.AppendLine($"MinionDamage = {_model.GeneralConfig.MinionDamage}");
            config.AppendLine($"RandomBoss = {_model.GeneralConfig.RandomBoss}");
            config.AppendLine($"BuffAfterKillingEnabled = {_model.GeneralConfig.BuffAfterKillingEnabled}");
            config.AppendLine($"BuffAfterKillingPrefabGUID = {_model.GeneralConfig.BuffAfterKillingPrefabGUID}");
            config.AppendLine($"TeamBossEnable = {_model.GeneralConfig.TeamBossEnable}");
            config.AppendLine();

            // Messages
            config.AppendLine("[Messages]");
            config.AppendLine($"SpawnMessageBossTemplate = \"{_model.GeneralConfig.SpawnMessageBossTemplate}\"");
            config.AppendLine($"DespawnMessageBossTemplate = \"{_model.GeneralConfig.DespawnMessageBossTemplate}\"");
            config.AppendLine($"KillMessageBossTemplate = \"{_model.GeneralConfig.KillMessageBossTemplate}\"");
            config.AppendLine($"VBloodFinalConcat = \"{_model.GeneralConfig.VBloodFinalConcat}\"");
            config.AppendLine();

            // Phase Messages
            config.AppendLine("[PhaseMessages]");
            config.AppendLine($"PhaseNormalTemplate = \"{_model.GeneralConfig.PhaseNormalTemplate}\"");
            config.AppendLine($"PhaseHardTemplate = \"{_model.GeneralConfig.PhaseHardTemplate}\"");
            config.AppendLine($"PhaseEpicTemplate = \"{_model.GeneralConfig.PhaseEpicTemplate}\"");
            config.AppendLine($"PhaseLegendaryTemplate = \"{_model.GeneralConfig.PhaseLegendaryTemplate}\"");
            config.AppendLine($"PhaseNormalName = \"{_model.GeneralConfig.PhaseNormalName}\"");
            config.AppendLine($"PhaseHardName = \"{_model.GeneralConfig.PhaseHardName}\"");
            config.AppendLine($"PhaseEpicName = \"{_model.GeneralConfig.PhaseEpicName}\"");
            config.AppendLine($"PhaseLegendaryName = \"{_model.GeneralConfig.PhaseLegendaryName}\"");
            config.AppendLine();

            // Dynamic Scaling
            config.AppendLine("[DynamicScaling]");
            config.AppendLine($"EnableDynamicScaling = {_model.AdvancedConfig.EnableDynamicScaling}");
            config.AppendLine($"BaseHealthMultiplier = {_model.AdvancedConfig.BaseHealthMultiplier:F2}");
            config.AppendLine($"HealthPerPlayer = {_model.AdvancedConfig.HealthPerPlayer:F2}");
            config.AppendLine($"DamagePerPlayer = {_model.AdvancedConfig.DamagePerPlayer:F2}");
            config.AppendLine($"MaxPlayersForScaling = {_model.AdvancedConfig.MaxPlayersForScaling}");
            config.AppendLine();

            // Progressive Difficulty
            config.AppendLine("[ProgressiveDifficulty]");
            config.AppendLine($"EnableProgressiveDifficulty = {_model.AdvancedConfig.EnableProgressiveDifficulty}");
            config.AppendLine($"DifficultyIncrease = {_model.AdvancedConfig.DifficultyIncrease:F2}");
            config.AppendLine($"MaxDifficultyMultiplier = {_model.AdvancedConfig.MaxDifficultyMultiplier:F2}");
            config.AppendLine($"ResetDifficultyOnKill = {_model.AdvancedConfig.ResetDifficultyOnKill}");
            config.AppendLine();

            // Teleport
            config.AppendLine("[Teleport]");
            config.AppendLine($"EnableTeleportCommand = {_model.AdvancedConfig.EnableTeleportCommand}");
            config.AppendLine($"TeleportAdminOnly = {_model.AdvancedConfig.TeleportAdminOnly}");
            config.AppendLine($"TeleportCooldown = {_model.AdvancedConfig.TeleportCooldown:F1}");
            config.AppendLine($"TeleportOnlyToActiveBosses = {_model.AdvancedConfig.TeleportOnlyToActiveBosses}");
            config.AppendLine($"TeleportRequireBossAlive = {_model.AdvancedConfig.TeleportRequireBossAlive}");
            config.AppendLine($"TeleportCostItemGUID = \"{_model.AdvancedConfig.TeleportCostItemGUID}\"");
            config.AppendLine($"TeleportCostAmount = {_model.AdvancedConfig.TeleportCostAmount}");
            config.AppendLine();

            // Phase Announcements
            config.AppendLine("[PhaseAnnouncements]");
            config.AppendLine($"EnablePhaseAnnouncements = {_model.AdvancedConfig.EnablePhaseAnnouncements}");
            config.AppendLine($"AnnounceEveryPhase = {_model.AdvancedConfig.AnnounceEveryPhase}");
            config.AppendLine($"AnnounceMilestoneSpawns = {_model.AdvancedConfig.AnnounceMilestoneSpawns}");

            return config.ToString();
        }

        private void ParseConfigFileContent(string content)
        {
            _model = new ModConfigurationModel(); // Reset to defaults
            string currentSection = "";
            
            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                
                // Skip comments and empty lines
                if (trimmedLine.StartsWith("#") || string.IsNullOrEmpty(trimmedLine))
                    continue;
                
                // Section headers
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    continue;
                }
                
                // Parse key-value pairs
                var parts = trimmedLine.Split(new[] { '=' }, 2);
                if (parts.Length != 2)
                    continue;
                
                var key = parts[0].Trim();
                var value = parts[1].Trim().Trim('"');
                
                try
                {
                    SetConfigValue(currentSection, key, value);
                }
                catch (Exception ex)
                {
                    // Continue parsing even if one value fails
                    System.Diagnostics.Debug.WriteLine($"Error parsing {currentSection}.{key}: {ex.Message}");
                }
            }
        }

        private void SetConfigValue(string section, string key, string value)
        {
            switch (section.ToLower())
            {
                case "general":
                    SetGeneralConfigValue(key, value);
                    break;
                case "messages":
                    SetMessagesConfigValue(key, value);
                    break;
                case "phasemessages":
                    SetPhaseMessagesConfigValue(key, value);
                    break;
                case "dynamicscaling":
                    SetDynamicScalingConfigValue(key, value);
                    break;
                case "progressivedifficulty":
                    SetProgressiveDifficultyConfigValue(key, value);
                    break;
                case "teleport":
                    SetTeleportConfigValue(key, value);
                    break;
                case "phaseannouncements":
                    SetPhaseAnnouncementsConfigValue(key, value);
                    break;
            }
        }

        private void SetGeneralConfigValue(string key, string value)
        {
            switch (key)
            {
                case "Enabled": _model.GeneralConfig.Enabled = bool.Parse(value); break;
                case "BuffForWorldBoss": _model.GeneralConfig.BuffForWorldBoss = int.Parse(value); break;
                case "PlayersMultiplier": _model.GeneralConfig.PlayersMultiplier = bool.Parse(value); break;
                case "ClearDropTable": _model.GeneralConfig.ClearDropTable = bool.Parse(value); break;
                case "MinionDamage": _model.GeneralConfig.MinionDamage = bool.Parse(value); break;
                case "RandomBoss": _model.GeneralConfig.RandomBoss = bool.Parse(value); break;
                case "BuffAfterKillingEnabled": _model.GeneralConfig.BuffAfterKillingEnabled = bool.Parse(value); break;
                case "BuffAfterKillingPrefabGUID": _model.GeneralConfig.BuffAfterKillingPrefabGUID = int.Parse(value); break;
                case "TeamBossEnable": _model.GeneralConfig.TeamBossEnable = bool.Parse(value); break;
            }
        }

        private void SetMessagesConfigValue(string key, string value)
        {
            switch (key)
            {
                case "SpawnMessageBossTemplate": _model.GeneralConfig.SpawnMessageBossTemplate = value; break;
                case "DespawnMessageBossTemplate": _model.GeneralConfig.DespawnMessageBossTemplate = value; break;
                case "KillMessageBossTemplate": _model.GeneralConfig.KillMessageBossTemplate = value; break;
                case "VBloodFinalConcat": _model.GeneralConfig.VBloodFinalConcat = value; break;
            }
        }

        private void SetPhaseMessagesConfigValue(string key, string value)
        {
            switch (key)
            {
                case "PhaseNormalTemplate": _model.GeneralConfig.PhaseNormalTemplate = value; break;
                case "PhaseHardTemplate": _model.GeneralConfig.PhaseHardTemplate = value; break;
                case "PhaseEpicTemplate": _model.GeneralConfig.PhaseEpicTemplate = value; break;
                case "PhaseLegendaryTemplate": _model.GeneralConfig.PhaseLegendaryTemplate = value; break;
                case "PhaseNormalName": _model.GeneralConfig.PhaseNormalName = value; break;
                case "PhaseHardName": _model.GeneralConfig.PhaseHardName = value; break;
                case "PhaseEpicName": _model.GeneralConfig.PhaseEpicName = value; break;
                case "PhaseLegendaryName": _model.GeneralConfig.PhaseLegendaryName = value; break;
            }
        }

        private void SetDynamicScalingConfigValue(string key, string value)
        {
            switch (key)
            {
                case "EnableDynamicScaling": _model.AdvancedConfig.EnableDynamicScaling = bool.Parse(value); break;
                case "BaseHealthMultiplier": _model.AdvancedConfig.BaseHealthMultiplier = float.Parse(value); break;
                case "HealthPerPlayer": _model.AdvancedConfig.HealthPerPlayer = float.Parse(value); break;
                case "DamagePerPlayer": _model.AdvancedConfig.DamagePerPlayer = float.Parse(value); break;
                case "MaxPlayersForScaling": _model.AdvancedConfig.MaxPlayersForScaling = int.Parse(value); break;
            }
        }

        private void SetProgressiveDifficultyConfigValue(string key, string value)
        {
            switch (key)
            {
                case "EnableProgressiveDifficulty": _model.AdvancedConfig.EnableProgressiveDifficulty = bool.Parse(value); break;
                case "DifficultyIncrease": _model.AdvancedConfig.DifficultyIncrease = float.Parse(value); break;
                case "MaxDifficultyMultiplier": _model.AdvancedConfig.MaxDifficultyMultiplier = float.Parse(value); break;
                case "ResetDifficultyOnKill": _model.AdvancedConfig.ResetDifficultyOnKill = bool.Parse(value); break;
            }
        }

        private void SetTeleportConfigValue(string key, string value)
        {
            switch (key)
            {
                case "EnableTeleportCommand": _model.AdvancedConfig.EnableTeleportCommand = bool.Parse(value); break;
                case "TeleportAdminOnly": _model.AdvancedConfig.TeleportAdminOnly = bool.Parse(value); break;
                case "TeleportCooldown": _model.AdvancedConfig.TeleportCooldown = float.Parse(value); break;
                case "TeleportOnlyToActiveBosses": _model.AdvancedConfig.TeleportOnlyToActiveBosses = bool.Parse(value); break;
                case "TeleportRequireBossAlive": _model.AdvancedConfig.TeleportRequireBossAlive = bool.Parse(value); break;
                case "TeleportCostItemGUID": _model.AdvancedConfig.TeleportCostItemGUID = value; break;
                case "TeleportCostAmount": _model.AdvancedConfig.TeleportCostAmount = int.Parse(value); break;
            }
        }

        private void SetPhaseAnnouncementsConfigValue(string key, string value)
        {
            switch (key)
            {
                case "EnablePhaseAnnouncements": _model.AdvancedConfig.EnablePhaseAnnouncements = bool.Parse(value); break;
                case "AnnounceEveryPhase": _model.AdvancedConfig.AnnounceEveryPhase = bool.Parse(value); break;
                case "AnnounceMilestoneSpawns": _model.AdvancedConfig.AnnounceMilestoneSpawns = bool.Parse(value); break;
            }
        }
    }
}