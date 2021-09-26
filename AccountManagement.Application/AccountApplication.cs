using AccountManagement.Application.Constracts.Account;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace AccountManagement.Application
{
   public class AccountApplication : IAccountApplication
   {
      private readonly IAccountRepository _accountRepository;
      private readonly IFileUploader _fileUploader;
      private readonly IPasswordHasher _passwordHasher;

      public AccountApplication(IAccountRepository accountRepository , IPasswordHasher passwordHasher , IFileUploader fileUploader)
      {
         _accountRepository = accountRepository;
         _fileUploader = fileUploader;
         _passwordHasher = passwordHasher;
      }

      public GenerateResult Create(CreateAccount command)
      {
         if (_accountRepository.IsExists(x => x.Username == command.Username || x.Mobile == command.Mobile))
            return new GenerateResult().Failed("کاربری با همین نام کاربری یا موبایل قبلا ثبت نام کرده است");

         var pass = _passwordHasher.Hash(command.Password);
         var picPath = _fileUploader.Uploader(command.Picture, "ProfilePhotos", "ProfilePhotos");

         if (picPath == null)
         {
            picPath = "ProfilePhotos/User-Icon.png";
         }

         var acc = new Account(command.Fullname, command.Username, pass, command.Mobile, picPath, command.Role);

         _accountRepository.Create(acc);
         _accountRepository.Save();
         return new GenerateResult().Succedded();
      }

      public GenerateResult Edit(EditAccount command)
      {
         var acc = _accountRepository.Get(command.Id);

         if (acc == null)
            return new GenerateResult().Failed("کاربری با این مشخصه وجود ندارد");

         if (_accountRepository.IsExists(x=>(x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
            return new GenerateResult().Failed("کاربری با همین نام کاربری یا موبایل قبلا ثبت نام کرده است");

         var picPath = _fileUploader.Uploader(command.Picture, "ProfilePhotos", "ProfilePhotos");

         acc.Edit(command.Fullname, command.Username, command.Mobile, picPath, command.Role);
         _accountRepository.Save();
         return new GenerateResult().Succedded();
      }

      public GenerateResult ChangePassword(ChangePassword command)
      {
         var acc = _accountRepository.Get(command.Id);

         if (acc == null)
            return new GenerateResult().Failed("کاربری با چنین مشخصات یافت نشد");

         if (command.Password != command.RePassword)
            return new GenerateResult().Failed("در تکرار رمز عبور دقت کنید");

         var pass = _passwordHasher.Hash(command.Password);
         acc.ChangePassword(pass);
         _accountRepository.Save();
         return new GenerateResult().Succedded();
      }

      public GenerateResult ChangeUserName(ChangeUserName command)
      {
         var acc = _accountRepository.Get(command.Id);

         if (acc == null)
            return new GenerateResult().Failed("کاربری با چنین مشخصات یافت نشد");

         acc.ChangeUsername(command.UserName);
         _accountRepository.Save();
         return new GenerateResult().Succedded();
      }

      public EditAccount GetDetails(long id)
      {
         return _accountRepository.GetDetails(id);
      }

      public List<AccountVM> Search(AccountSearchModel command)
      {
         return _accountRepository.Search(command);
      }

      public GenerateResult Upgrade(UpgradeRole command)
      {
         var acc = _accountRepository.Get(command.Id);

         if (acc == null)
            return new GenerateResult().Failed("کاربری با چنین مشخصات یافت نشد");

         acc.Upgrade(command.Role);
         _accountRepository.Save();
         return new GenerateResult().Succedded();
      }

      public UpgradeRole GetRole(long id)
      {
         return _accountRepository.GetRole(id);
      }
   }
}