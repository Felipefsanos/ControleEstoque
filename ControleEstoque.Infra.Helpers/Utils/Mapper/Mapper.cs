using Newtonsoft.Json;

namespace ControleEstoque.Infra.Helpers.Utils.Mapper
{
    public static class Mapper
    {
        public static Target MapTo<Target>(object source)
        {
            var sourceJson = JsonConvert.SerializeObject(source, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.All });

            return JsonConvert.DeserializeObject<Target>(sourceJson);
        }

    }
}
