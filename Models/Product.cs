using Newtonsoft.Json;

namespace CosmosDbCRUD.Models;

public class Product
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("stock")]
    public string Stock { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }

}