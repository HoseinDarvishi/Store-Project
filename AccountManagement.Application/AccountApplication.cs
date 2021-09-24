using AccountManagement.Application.Constracts.Account;
using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace AccountManagement.Application
{
   public class AccountApplication : IAccountApplication
   {
      private readonly IAccountRepository _accountRepository;

      public AccountApplication(IAccountRepository accountRepository)
      {
         _accountRepository = accountRepository;
      }

      public GenerateResult ChangePassword(ChangePassword command)
      {
         throw new NotImplementedException();
      }

      public GenerateResult ChangeUserName(ChangeUserName command)
      {
         throw new NotImplementedException();
      }

      public GenerateResult Create(CreateAccount command)
      {
         throw new NotImplementedException();
      }

      public EditAccount GetDetails(long id)
      {
         throw new NotImplementedException();
      }

      public List<AccountVM> Search(AccountSearchModel command)
      {
         throw new NotImplementedException();
      }

      public GenerateResult Upgrade(UpgradeRole command)
      {
         throw new NotImplementedException();
      }
   }
}
