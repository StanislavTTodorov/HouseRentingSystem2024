namespace HouseRentingSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Category 
        {
            public const int NameMaxLength = 50;
        }

        public static class House
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int AddressMaxLength = 150;
            public const int AddressMinLength = 30;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 50;

            public const int ImageUrlMaxLength = 2048;

            public const string PricePerMonthMaxLength = "2000";
            public const string PricePerMonthMinLength = "0";
        }

        public static class Agent
        {
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 7;
        }
    }
}
