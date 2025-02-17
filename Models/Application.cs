namespace NinjaDesk.Models;

public class Application
{
    public required string DisplayName { get; set; }
    public required string Icon { get; set; }
    public string Main { get; set; } = "index.html";
}