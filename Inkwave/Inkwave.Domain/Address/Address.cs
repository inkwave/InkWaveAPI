namespace Inkwave.Domain
{
    public class Address : BaseEntity
    {
        private Address() { }
        private Address(Guid userId, string name, string governorate, string street, string city, string district, string building, string zipCode, string apartment, string markingPlace)
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
        public string Name { get; set; } = string.Empty;
        public string Governorate { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Building { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;
        public string MarkingPlace { get; set; } = string.Empty;

        public bool IsDefault { get; set; }
        public static Address Create(Guid userId, string name, string governorate, string street, string city, string district, string building, string zipCode, string apartment, string markingPlace)
        {
            Address adress = new Address(userId, name, governorate, street, city, district, building, zipCode, apartment, markingPlace);
            return adress;
        }
        public Address Update(Guid userId, string name, string governorate, string street, string city, string district, string building, string zipCode, string apartment, string markingPlace)
        {
            if (userId != this.UserId)
                return this;
            this.Name = name;
            this.Governorate = governorate;
            this.Street = street;
            this.City = city;
            this.District = district;
            this.Building = building;
            this.Apartment = apartment;
            this.ZipCode = zipCode;
            this.MarkingPlace = markingPlace;
            return this;
        }
        public void SetDefaultAddres(List<Address> otherAddresses)
        {
            this.IsDefault = true;
            otherAddresses.ForEach(x => x.IsDefault = false);
        }

    }
}
