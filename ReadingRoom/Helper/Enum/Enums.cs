namespace ReadingRoom.Helper.Enum
{
    public class Enums
    {
        public enum PersonType
        {
            none = 100,
            Admin =1,
            Employee=2,
            Client=3
        }
        public enum ContentType
        {
            none = 100,
            Book = 1,
            Magazine = 2,
            Manga = 3,
            Comic = 4,
            Poetry = 5
        }
        public enum DepartmentNameEN
        {
            none = 100,
            Sales = 1,
            Marketing = 2,
            CustomerService = 3,
        }
        public enum DepartmentNameAR
        {
            none = 100,
            المبيعات = 1,
            التسويق = 2,
            خدمةالعملاء = 3,
        }
        public enum SubscriptionType
        {
            none = 100,
            Standard = 1,
            Premium = 2,
            Ultimate = 3,
        }
    }
}
