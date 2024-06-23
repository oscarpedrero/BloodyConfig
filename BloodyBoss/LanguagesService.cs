using BloodyConfig.BloodyBoss.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodyConfig.BloodyBoss
{
    public class LanguagesService
    {
        public static List<LanguageModel> GetLanguages()
        {
            List<LanguageModel> languages = new List<LanguageModel>();

            var language = new LanguageModel();
            language.name = "Brazilian";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "English";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "French";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "German";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Hungarian";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Italian";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Japanese";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Koreana";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Latam";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Polish";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Russian";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "SChinese";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Spanish";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "TChinese";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Thai";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Turkish";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            language = new LanguageModel();
            language.name = "Vietnamese";
            language.valueNpc = language.name + "Bosses";
            language.valueItem = language.name + "Items";
            languages.Add(language);

            return languages.OrderBy(x => x.name).ToList();
        }
    }
}
