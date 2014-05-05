using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foodstuff
{
    public class SelectedItem
    {
        public string Name { get; set; }
        public string Id { get; private set; }

        public SelectedItem(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
