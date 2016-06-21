public class Teacher
{
    public int ID { get; set; }
    public String name { get; set; }
    public String abbreviation { get; set; }
    public String salutation { get; set; }
    public String email { get; set; }
    [JsonConstructor]
    public Teacher(int ID, String Name, String Abbreviation, 
    			   String Salutation, String email)
    {
    this.ID = ID;
    this.name = Name;
    this.abbreviation = Abbreviation;
    this.salutation = Salutation;
    this.email = email;
   }
}