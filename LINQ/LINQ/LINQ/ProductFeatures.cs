using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class EProduct
    {
        public string Name { get; set; }

        public ICollection<Feature> Features { get; set; }

        public EProduct(string Name, ICollection<Feature> Features)
        {
            this.Name = Name;
            this.Features = Features;
        }
    }

    public class Feature
    {
        public int Id { get; set; }
        public Feature(int Id)
        {
            this.Id = Id;
        }
    }

    public static class EProductExtension
    {
        public static IEnumerable<EProduct> AnyFeature(IEnumerable<EProduct> products, IEnumerable<Feature> features)
        {
            return products.Where(prod => prod.Features.Any(x => features.Contains(x)));
        }

        public static IEnumerable<EProduct> AllFeatures(IEnumerable<EProduct> products, IEnumerable<Feature> features)
        {
            return products.Where(prod => features.All(x => prod.Features.Contains(x)));
        }

        public static IEnumerable<EProduct> NoFeature(IEnumerable<EProduct> products, IEnumerable<Feature> features)
        {
            return products.Where(prod => !prod.Features.Any(x => features.Contains(x)));
        }
    }

    public struct BProduct
    {
        public string Name;
        public int Quantity;

        public BProduct(string Name, int Quantity)
        {
            this.Name = Name;
            this.Quantity = Quantity;
        }
    }

    public class BProductExtension
    {
        public static IEnumerable<BProduct> BProductAccumulate(IEnumerable<BProduct> list1, IEnumerable<BProduct> list2)
        {
            return list1.Concat(list2).GroupBy(x => x.Name, p => p.Quantity, (name, totalQuantity) => new BProduct(name, totalQuantity.Sum()));
        }
    }
}