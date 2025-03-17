using Microsoft.AspNetCore.Identity;

namespace WebAPI.Model
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır!"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description ="Lütfen en az bir büyük harf giriniz"
            };
        }
        public override IdentityError PasswordRequiresLower() 
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az bir küçük harf giriniz"
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Lütfen en az bir sembol giriniz"
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = "Bu email adresi ile kayıtlı hesap bulunmaktadır."
            };
        }
    }
}
