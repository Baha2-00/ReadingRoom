namespace ReadingRoom.Models.Entity
{
    public class UserContentcs
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }  
        public virtual Content Content { get; set; }    
    }
}
