﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Sello.Domain.Model;

namespace Sello.Tests.Integration
{
    [Category("Integration")]
    [Category("Smoke")]
    public class ProductsTests
    {
        private readonly SelloService _selloService = new SelloService();

        [Test]
        public async Task Products_ListAllProducts_ShouldReturnHttpOk()
        {
            // Arrange
            const string productsUrl = "products";

            // Act
            var response = await _selloService.GetResponseAsync(productsUrl);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var rawContent = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(rawContent);
            Assert.NotNull(products);
        }
    }
}