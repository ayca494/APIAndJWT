using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
namespace APIAndJWT.Extentions
{
    public static class ModelStateExtensions //static olmak zorunda 
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors).Select(x => x.ErrorMessage).ToList();
        }

    }
}
