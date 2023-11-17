using Inkwave.Domain.Common;

namespace Inkwave.Domain
{
    public class Address : BaseEntity
    {
        private Address() { }
        private Address(Guid userId, string street, string city, string building, string apartment, string markingPlace)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Street = street;
            City = city;
            Building = building;
            Apartment = apartment;
            MarkingPlace = markingPlace;
        }
        public Guid UserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
        public string MarkingPlace { get; set; }
        public static Address Create(Guid userId, string street, string city, string building, string apartment, string markingPlace)
        {
            Address adress = new Address(userId, street, city, building, apartment, markingPlace);
            return adress;
        }
        public Address Update(Guid userId, string street, string city, string building, string apartment, string markingPlace)
        {
            if (userId != this.UserId)
                return this;
            this.Street = street;
            this.City = city;
            this.Building = building;
            this.Apartment = apartment;
            this.MarkingPlace = markingPlace;
            return this;
        }

    }
}
