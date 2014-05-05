using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security;
using System.Xml;

namespace Foodstuff
{
    public class Fooditem : IComparable<Fooditem>
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }

        public Fooditem()
        {
            this.Id = Guid.NewGuid().ToString("N").ToUpper();
            this.Name = string.Empty;
            this.Ingredients = new List<Ingredient>();
            this.Instructions = string.Empty;
        }

        private Fooditem(string id, string name, List<Ingredient> ingredients, string instructions)
        {
            this.Id = id;
            this.Name = name;
            this.Ingredients = new List<Ingredient>(ingredients);
            this.Instructions = instructions;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(Fooditem other)
        {
            if (other == null) return 1;
            return this.Name.CompareTo(other.Name);
        }

        public string ToXml()
        {
            using (StringWriter ret = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(ret))
                {
                    writer.WriteStartElement("foodItem");
                    writer.WriteElementString("id", this.Id);
                    writer.WriteElementString("name", SecurityElement.Escape(this.Name));
                    writer.WriteStartElement("ingredients");
                    foreach (Ingredient ingredient in this.Ingredients)
                    {
                        writer.WriteRaw(ingredient.ToXml());
                    }
                    writer.WriteEndElement();
                    writer.WriteElementString("instructions", SecurityElement.Escape(this.Instructions));
                    writer.WriteEndElement();
                }
                return ret.ToString();
            }
        }

        public static Fooditem FromXml(XmlNode node)
        {
            if (node.Name.ToLower() != "fooditem" || node["id"] == null || node["name"] == null || string.IsNullOrWhiteSpace(node["id"].InnerText) || string.IsNullOrWhiteSpace(node["name"].InnerText))
            {
                return null;
            }
            List<Ingredient> ingredients = new List<Ingredient>();
            if (node["ingredients"] != null)
            {
                foreach (XmlNode innerNode in node["ingredients"])
                {
                    ingredients.Add(Ingredient.FromXml(innerNode));
                }
            }
            return new Fooditem(node["id"].InnerText, node["name"].InnerText, ingredients, (node["instructions"] != null ? node["instructions"].InnerText : string.Empty));
        }
    }
}
