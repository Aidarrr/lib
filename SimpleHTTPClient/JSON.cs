using Newtonsoft.Json;

namespace lab2
{
    public class JSON : ISerializer
    {
        public T Deserialize<T>(string toSerialize)
        {
            return JsonConvert.DeserializeObject<T>(toSerialize);
        }

        public string Serialize<T>(T output)
        {
            return JsonConvert.SerializeObject(output);
        }
    }
}
