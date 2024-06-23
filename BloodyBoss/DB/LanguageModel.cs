using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodyConfig.BloodyBoss.DB
{
    public class LanguageModel
    {
        public string name {  get; set; }
        public string valueNpc {  get; set; }
        public string valueItem {  get; set; }

        public override string ToString() => name;
    }
}
