# BloodyConfig

**BloodyConfig** is a comprehensive Windows Forms configuration tool designed to easily set up and manage the BloodyBoss mod for V Rising servers. This application provides an intuitive graphical interface for configuring all aspects of the BloodyBoss mod without manually editing configuration files.

## Features

### 🎮 Boss Configuration Management
- **Individual Boss Setup**: Configure custom world bosses with specific stats, rewards, and spawn conditions
- **Boss Library**: Import and export boss configurations as JSON files
- **Visual Boss Editor**: Easy-to-use interface for setting health, damage, level, and other boss properties
- **Item Rewards System**: Configure custom item drops and rewards for each boss

### ⚙️ Advanced Mod Configuration
The application now includes a comprehensive **Mod Config** section with the following configuration categories:

#### General Settings
- Enable/disable the mod
- Configure buff multipliers for world bosses
- Set player multipliers and damage settings
- Control minion damage and random boss features
- Team boss configurations

#### Message Templates
- Customize spawn, despawn, and kill messages
- Configure VBlood final concatenation messages
- Personalize all in-game notifications

#### Phase Messages
- Configure phase-specific message templates (Normal, Hard, Epic, Legendary)
- Customize phase names and announcements
- Template system for dynamic boss names

#### Dynamic Scaling
- Enable automatic boss scaling based on player count
- Configure base health multipliers
- Set health and damage scaling per player
- Maximum player limits for scaling

#### Progressive Difficulty
- Enable progressive difficulty increases
- Configure difficulty increment values
- Set maximum difficulty multipliers
- Reset options for difficulty on boss kills

#### Teleport System
- Enable teleport commands for players
- Admin-only teleport restrictions
- Cooldown system configuration
- Teleport cost items and amounts
- Boss-specific teleport restrictions

#### Phase Announcements
- Enable phase-based announcements
- Configure milestone spawn notifications
- Customizable announcement triggers

### 📁 Import/Export Functionality
- **Configuration Import**: Load existing .cfg files from your server
- **Configuration Export**: Generate .cfg files ready for server deployment
- **Boss Data Import/Export**: Share boss configurations as JSON files
- **Backup and Restore**: Easy backup of your configurations

### 🌍 Multi-Language Support
The application supports multiple languages including:
- English, Spanish, French, German, Italian
- Portuguese (Brazilian), Russian, Polish
- Chinese (Simplified & Traditional), Japanese, Korean
- Thai, Vietnamese, Turkish, Hungarian

## How to Use

1. **Launch the Application**: Run BloodyConfig.exe (requires .NET Framework 4.7.2 or Wine on Linux)

2. **Configure Mod Settings**: 
   - Navigate to the "Mod Config" tab
   - Configure general settings, messages, scaling, and other advanced features
   - Use "Export Config" to generate a .cfg file for your server

3. **Manage Bosses**:
   - Switch to the "Boss Config" tab
   - Add new bosses or import existing configurations
   - Configure individual boss properties, stats, and rewards
   - Export your boss configurations as JSON files

4. **Deploy to Server**:
   - Copy the generated .cfg file to your V Rising server's BepInEx/config/ directory
   - Copy boss configuration JSON files to the appropriate mod directory
   - Restart your server to apply changes

## Compatibility

- **V Rising**: Compatible with V Rising servers
- **BloodyBoss Mod**: Supports BloodyBoss mod v2.1.0 and later
- **Platform**: Windows (native) or Linux (via Wine)
- **Requirements**: .NET Framework 4.7.2

## Technical Details

BloodyConfig is built using:
- Windows Forms for the user interface
- .NET Framework 4.7.2
- JSON serialization for data management
- Comprehensive configuration parsing and generation

The tool generates configuration files in the exact format expected by the BloodyBoss mod, ensuring seamless integration with your V Rising server setup.

![BloodyConfig Interface](https://github.com/oscarpedrero/BloodyConfig/blob/master/Images/bloodyconfig.png?raw=true "BloodyConfig Interface")


