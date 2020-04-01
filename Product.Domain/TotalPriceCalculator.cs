using Product.DAL;

namespace Product.Domain
{
    public sealed class TotalPriceCalculator
    {
        private readonly ProductEntity _entity;

        public TotalPriceCalculator(ProductEntity entity)
        {
            _entity = entity;
        }

        public decimal TotalPrice
        {
            get
            {
                return _entity.Quantity * _entity.UnitPrice;
            }
        }
    }
}