using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    public class Recipe : DataProperties
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingradient> Ingredients { get; set;}
    }
}
