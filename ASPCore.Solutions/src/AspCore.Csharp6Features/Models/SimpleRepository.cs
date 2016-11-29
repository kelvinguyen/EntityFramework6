using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Csharp6Features.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, VSProduct> products = new Dictionary<string, VSProduct>();
        public static SimpleRepository SharedRpository => sharedRepository;

        public SimpleRepository()
        {
            var initialItems = new [] 
            {
                new VSProduct { Name="Kayak",Price=275M},
                new VSProduct { Name="LifeJacket",Price=48.9M},
                new VSProduct { Name="Soccer Ball",Price=19.5M},
                new VSProduct { Name="Corner Flag",Price=34.95M},
            };
            foreach (var p in initialItems)
            {
                AddProduct(p);
            }
        }
        public IEnumerable<VSProduct> Products => products.Values;
        public void AddProduct(VSProduct p) => products.Add(p.Name, p);
    }
}
