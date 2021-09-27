﻿using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace AccountManagement.Application.Constracts.Account
{
   public interface IAccountApplication
   {
      GenerateResult Create(CreateAccount command);
      GenerateResult Edit(EditAccount command);
      GenerateResult ChangePassword(ChangePassword command);
      GenerateResult ChangeUserName(ChangeUserName command);
      List<AccountVM> Search(AccountSearchModel command);
      EditAccount GetDetails(long id);
   }
}
