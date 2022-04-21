using Xunit;
using JsonSerializeris;
using System.Collections.Generic;
using Business;

namespace unitTest
{
    public class UnitTestGenerateRandomOrderList
    {
        [Fact]
        public void GenerateRandomOrderProductListMoreThenOneItemInList()
        {
            SerializeData serializeData = new SerializeData();
            List<OrderProduct> productsInOrder = serializeData.GenerateProductList();

            Assert.True(productsInOrder.Count > 0);

        }
    }
}
