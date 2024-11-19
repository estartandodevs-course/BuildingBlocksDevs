using EstartandoDevsCore.Data;
using FluentValidation.Results;

namespace EstartandoDevsCore.Messages;

public abstract class CommandHandler
{
    protected ValidationResult ValidationResult;

    protected CommandHandler()
    {
        ValidationResult = new ValidationResult();
    }

    protected async Task<ValidationResult> PersistirDados(IUnitOfWorks uow)
    {
        if (!await uow.Commit()) AdicionarErro("Não houve alteração nos dados!");

        return ValidationResult;
    }

    protected void AdicionarErro(string mensagem)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
    }
}