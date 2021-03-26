namespace ClassLibrary
{
    public interface IShipResult
    {
        public string Name { get; set; }
        public decimal Length { get; set; }
        public string Driver { get; set; }
        public IShipResult SelectShip();
    }
}