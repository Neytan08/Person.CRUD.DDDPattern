namespace HahnSoftwareentwicklung.TechnicalSkills.API.Commands
{
    public record SelectPersonCommand(Guid personId, string Name, int Phone, string Address, string MaritalStatus);
}
