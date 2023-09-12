using ApplicationView.BusnessEntities.BE;

namespace ApplicationView.BusnessEntities.Dtos
{
    public class SaleWithLogitDto
    {
        public SaleBE Sale { get; set; }
        public LegitBE Legit { get; set; }
    }
}
