using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEvaluacion.Models;

[Table("Usuarios")]
public class User
{
    public int id { get; set; }
    public string? userName{get;set;}
    public string? userGroup {get;set;}
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? email {get;set;}
    public string? dateOfBirth{get;set;}
    public string? pass {get;set;}
}