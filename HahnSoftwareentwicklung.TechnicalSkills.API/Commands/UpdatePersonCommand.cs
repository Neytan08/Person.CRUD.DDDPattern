namespace HahnSoftwareentwicklung.TechnicalSkills.API.Commands
{
    public record UpdatePersonCommand(Guid personId, string Name, int Phone, string Address, string MaritalStatus);

}
