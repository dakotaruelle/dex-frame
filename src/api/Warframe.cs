namespace Api.Controllers
{
  public class Warframe
  {
    public int Id { get; set; }
    public string UniqueName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Health { get; set; }
    public int Shield { get; set; }
    public int Armor { get; set; }
    public int Stamina { get; set; }
    public int Power { get; set; }
    public double Sprint { get; set; }
    public double SprintSpeed { get; set; }
    public int MasteryRequirement { get; set; }
    public string PassiveDescription { get; set; }
    public string ProductCategory { get; set; }
    public int BuildPrice { get; set; }
    public int BuildTime { get; set; }
    public int SkipBuildTimePrice { get; set; }
    public int BuildQuantity { get; set; }
    public bool ConsumeOnBuild { get; set; }
    public bool Tradable { get; set; }
    public bool Conclave { get; set; }
    public int Color { get; set; }
    public string FirstAppearance { get; set; }
    public string Sex { get; set; }
    public string WikiaUrl { get; set; }
    public string WikiaThumbnail { get; set; }
    public string ImageName { get; set; }
    public int ItemTypeId { get; set; }
    public int ItemCategoryId { get; set; }
    public int AuraId { get; set; }
  }
}
