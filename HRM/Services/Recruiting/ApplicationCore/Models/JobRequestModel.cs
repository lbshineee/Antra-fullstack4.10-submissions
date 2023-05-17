using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter Title of the Job")]
    [StringLength(256)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Please enter Job Description")]
    [StringLength(5000)]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Please enter the Job Start Date")]
    // start date cannot be in the past
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Please enter the number of positions opened")]
    public int NumberOfPositions { get; set; }

}