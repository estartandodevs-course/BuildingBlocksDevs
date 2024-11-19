namespace EstartandoDevsCore.Data;

public interface IUnitOfWorks
{
    Task<bool> Commit();
}