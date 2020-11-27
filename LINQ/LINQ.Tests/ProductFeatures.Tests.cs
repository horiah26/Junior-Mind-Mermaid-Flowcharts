using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace LINQ.Tests
{
    public class ProductFeaturesTests
    {
        [Fact]
        public void AnyFeatureWorks()
        {
            var f1 = new Feature(1);
            var f2 = new Feature(2);
            var f3 = new Feature(3);
            var f4 = new Feature(4);
            var f5 = new Feature(5);
            var f6 = new Feature(6);

            var p1 = new EProduct("p1", new List<Feature>() { f1, f6, f3 });
            var p2 = new EProduct("p2", new List<Feature>() { f1, f2 });
            var p3 = new EProduct("p3", new List<Feature>() { f1, f3, f4 });
            var p4 = new EProduct("p4", new List<Feature>() { f2, f3, f5 });
            var p5 = new EProduct("p5", new List<Feature>() { f3, f4, f6 });

            List<EProduct> products = new List<EProduct> { p1, p2, p3, p4, p5 };
            List<Feature> features = new List<Feature> { f2, f5 };

            Assert.Collection(EProductExtension.AnyFeature(products, features),
                item => Assert.Equal(p2, item),
                item => Assert.Equal(p4, item));

        }

        [Fact]
        public void AllFeaturesWorks()
        {
            var f1 = new Feature(1);
            var f2 = new Feature(2);
            var f3 = new Feature(3);
            var f4 = new Feature(4);
            var f5 = new Feature(5);
            var f6 = new Feature(6);

            var p1 = new EProduct("p1", new List<Feature>() { f1, f6, f3 });
            var p2 = new EProduct("p2", new List<Feature>() { f1, f2 });
            var p3 = new EProduct("p3", new List<Feature>() { f1, f3, f4 });
            var p4 = new EProduct("p4", new List<Feature>() { f2, f3, f5 });
            var p5 = new EProduct("p5", new List<Feature>() { f3, f4, f6 });

            List<EProduct> products = new List<EProduct> { p1, p2, p3, p4, p5 };
            List<Feature> features = new List<Feature> { f1, f3 };

            Assert.Collection(EProductExtension.AllFeatures(products, features),
                item => Assert.Equal(p1, item),
                item => Assert.Equal(p3, item));

        }

        [Fact]
        public void NoFeatureWorks()
        {
            var f1 = new Feature(1);
            var f2 = new Feature(2);
            var f3 = new Feature(3);
            var f4 = new Feature(4);
            var f5 = new Feature(5);
            var f6 = new Feature(6);

            var p1 = new EProduct("p1", new List<Feature>() { f1, f6, f3 });
            var p2 = new EProduct("p2", new List<Feature>() { f1, f2 });
            var p3 = new EProduct("p3", new List<Feature>() { f1, f3, f4 });
            var p4 = new EProduct("p4", new List<Feature>() { f2, f3, f5 });
            var p5 = new EProduct("p5", new List<Feature>() { f3, f4, f6 });

            List<EProduct> products = new List<EProduct> { p1, p2, p3, p4, p5 };
            List<Feature> features = new List<Feature> { f2, f4 };

            Assert.Collection(EProductExtension.NoFeature(products, features),
                item => Assert.Equal(p1, item));
        }

        [Fact]
        public void ProductAccumulatorWorks()
        {
            var p1 = new BProduct("p1", 1);
            var p2 = new BProduct("p2", 3);
            var p3 = new BProduct("p1", 5);
            var p4 = new BProduct("p2", 7);
            var p5 = new BProduct("p3", 5);
            var p6 = new BProduct("p1", 2);

            List<BProduct> list1 = new List<BProduct> { p1, p2, p3 };
            List<BProduct> list2 = new List<BProduct> { p4, p5, p6 };

            var resultList = BProductExtension.BProductAccumulate(list1, list2);

            Assert.Collection(resultList,
                item => Assert.Equal("p1", item.Name),
                item => Assert.Equal("p2", item.Name),
                item => Assert.Equal("p3", item.Name));

            Assert.Collection(resultList,
                item => Assert.Equal(8, item.Quantity),
                item => Assert.Equal(10, item.Quantity),
                item => Assert.Equal(5, item.Quantity));
        }
    }
}
