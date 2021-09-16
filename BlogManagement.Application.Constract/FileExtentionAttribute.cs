using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace BlogManagement.Application.Constract
{
    public class FileExtentionAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _fileExtention;

        public FileExtentionAttribute(string[] fileExtention)
        {
            _fileExtention = fileExtention;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;

            var extention = Path.GetExtension(file.FileName);
            return _fileExtention.Contains(extention);

        }

        public void AddValidation(ClientModelValidationContext context)
        {
            //context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-fileExtention", ErrorMessage);
        }
    }
}
