namespace CascadeDropDown.Models
{
    public class Address
    {
        public Country Country { get; set; }=new Country();
        public State State { get; set; }=new State();
        public City City { get; set; } =new City();
    }
}
