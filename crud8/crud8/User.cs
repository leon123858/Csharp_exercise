namespace crud8;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Range(0, 120)]
    public int Age { get; set; }
}

public class CreateUserRequest
{
    public string Name { get; set; }
    
    public int Age { get; set; }
}