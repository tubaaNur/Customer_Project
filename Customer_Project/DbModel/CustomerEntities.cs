


namespace Customer_Project.DbModel
{
    public class CustomerEntities
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime Birthday { get; set; } 
        public char Nation { get; set; }
        public char Number { get; set; }
        public Boolean Is_active { get; set; }
        public DateTime Created_date { get; set; }
        public int Created_by_user_id { get; set; }
        public DateTime Update_date { get; set; }
        public int Update_by_user_id { get; set; }
    }
}
