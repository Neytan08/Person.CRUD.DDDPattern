namespace HahnSoftwareentwicklung.TechnicalSkills.API.Commands
{
    public record SelectPersonCommand(Guid PersonId, string Name, int Phone, string Address, string MaritalStatus);
}
