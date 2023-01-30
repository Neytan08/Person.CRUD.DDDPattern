namespace HahnSoftwareentwicklung.TechnicalSkills.API.Commands
{
    public record CreatePersonCommand(Guid personId, string Name, int Phone, string Address, string MaritalStatus);

}
