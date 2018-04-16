using Fishy.DAL.Infrastucture;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishy.DAL.Models
{
    public class Product:Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
