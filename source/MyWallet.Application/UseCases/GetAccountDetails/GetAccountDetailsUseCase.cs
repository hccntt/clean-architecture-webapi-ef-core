namespace MyWallet.Application.UseCases.GetAccountDetails {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.Repositories;
    using MyWallet.Domain.Accounts;

    public sealed class GetAccountDetailsUseCase : IGetAccountDetailsUseCase {
        private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;

        public GetAccountDetailsUseCase (IAccountReadOnlyRepository accountReadOnlyRepository) {
            _accountReadOnlyRepository = accountReadOnlyRepository;
        }

        public async Task<AccountOutput> Execute (Guid accountId) {
            Account account = await _accountReadOnlyRepository.Get (accountId);

            if (account == null)
                throw new AccountNotFoundException ($"The account {accountId} does not exists or is not processed yet.");

            AccountOutput output = new AccountOutput (account);
            return output;
        }
    }
}