using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TheLair.Nest.Infra;

public class FileRepository<T> where T : class, new()
{
    private readonly string FileName;

    public FileRepository(string fileName)
    {
        FileName = fileName;
    }

    public async Task<T> Load()
    {
        try
        {
            string content = await File.ReadAllTextAsync(FileName);

            T instance = JsonConvert.DeserializeObject<T>(content) ?? new T();

            return (instance);
        }
        catch (Exception)
        {
            return (new T());
        }
    }

    public async Task Save(T instance)
    {
        string data = JsonConvert.SerializeObject(instance);

        await File.WriteAllTextAsync(FileName, data);
    }
}