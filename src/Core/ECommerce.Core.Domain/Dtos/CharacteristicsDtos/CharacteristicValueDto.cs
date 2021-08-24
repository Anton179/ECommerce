namespace ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos
{
    public class CharacteristicValueDto
    {
        public CharacteristicDto Characteristic { get; set; }
        public string ValueStr { get; set; }
        public double ValueNum { get; set; }
    }
}
