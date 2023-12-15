using System.ComponentModel.DataAnnotations;

namespace ExampleProject.Data
{
    public class CompanyData
    {

            [Key]
            public int Id { get; set; }
            public string CompanyName { get; set; }
            public string Email { get; set; }
            public string WesternNumber { get; set; }
            public string GstNumber { get; set; }
        }

}
