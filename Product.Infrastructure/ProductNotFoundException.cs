using System;

namespace Product.Infrastructure
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int suppliedId) 
            : base($"Entity not found with id : {suppliedId}")
        {

        }
    }
}