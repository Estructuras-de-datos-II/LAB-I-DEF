using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio_1_EDII.Models;


namespace Laboratorio_1_EDII.Data
{
    public sealed class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public List<Movies> Movie { get; set; }
        public int LastId = 0;
        public int Orders=5;
        public BTree<Models.Movies> arbolB;
        
        private Singleton()
        {
                Movie = new List<Movies>();
            arbolB = new BTree<Movies>(Orders);
               
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
