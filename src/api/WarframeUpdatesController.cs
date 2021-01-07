using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Api.DataUpdates.Warframe;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
  [ApiController]
  [Route("warframeupdates")]
  public class WarframeUpdatesController : ControllerBase
  {
    private readonly IConfiguration configuration;

    public WarframeUpdatesController(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        using var httpClient = new HttpClient();
        var warframeStatModels = await httpClient.GetFromJsonAsync<List<WarframeStatModel>>("https://api.warframestat.us/warframes");
        var filteredWarframeStatModels = warframeStatModels.Where(warframeStatModel => warframeStatModel.ProductCategory == "Suits").ToList();

        using (var connection = new SqlConnection(configuration["FrameDexDbConnectionString"]))
        {
          var itemTypeId = await connection.QuerySingleAsync<int>(
          @"
            SELECT Id
            FROM dbo.ItemType
            WHERE Name = 'Warframe';
          ");

          var itemCategoryId = await connection.QuerySingleAsync<int>(
          @"
            SELECT Id
            FROM dbo.ItemCategory
            WHERE Name = 'Warframes';
          "
          );

          var warframes = filteredWarframeStatModels.Select(warframeStatModel =>
          {
            return new Warframe
            {
              Id = warframeStatModel.Id,
              UniqueName = warframeStatModel.UniqueName,
              Name = warframeStatModel.Name,
              Description = warframeStatModel.Description,
              Health = warframeStatModel.Health,
              Shield = warframeStatModel.Shield,
              Armor = warframeStatModel.Armor,
              Stamina = warframeStatModel.Stamina,
              Power = warframeStatModel.Power,
              Sprint = warframeStatModel.Sprint,
              SprintSpeed = warframeStatModel.SprintSpeed,
              MasteryRequirement = warframeStatModel.MasteryReq,
              PassiveDescription = warframeStatModel.PassiveDescription,
              ProductCategory = warframeStatModel.ProductCategory,
              BuildPrice = warframeStatModel.BuildPrice,
              BuildTime = warframeStatModel.BuildTime,
              SkipBuildTimePrice = warframeStatModel.SkipBuildTimePrice,
              BuildQuantity = warframeStatModel.BuildQuantity,
              ConsumeOnBuild = warframeStatModel.ConsumeOnBuild,
              Tradable = warframeStatModel.Tradable,
              Conclave = warframeStatModel.Conclave,
              Color = warframeStatModel.Color,
              FirstAppearance = warframeStatModel.Introduced,
              Sex = string.IsNullOrWhiteSpace(warframeStatModel.Sex) ? null : warframeStatModel.Sex,
              WikiaUrl = warframeStatModel.WikiaUrl,
              WikiaThumbnail = warframeStatModel.WikiaThumbnail,
              ImageName = warframeStatModel.ImageName,
              ItemTypeId = itemTypeId,
              ItemCategoryId = itemCategoryId,
              AuraId = 1 /*need to actually look this up*/
            };
          }).ToList();

          foreach (var warframe in warframes)
          {
            var existingWarframe = await connection.QueryFirstOrDefaultAsync<Warframe>(
              @"
                SELECT Id
                FROM dbo.Warframe
                WHERE UniqueName = @UniqueName
              ",
              new { UniqueName = warframe.UniqueName }
            );

            if (existingWarframe == null)
            {
              await connection.ExecuteAsync(
                @"
                  INSERT INTO dbo.Warframe (
                    [UniqueName], [Name], [Description], [Health], [Shield], [Armor], [Stamina], [Power],
                    [Sprint], [SprintSpeed], [MasteryRequirement], [PassiveDescription], [ProductCategory],
                    [BuildPrice], [BuildTime], [SkipBuildTimePrice], [BuildQuantity], [ConsumeOnBuild],
                    [Tradable], [Conclave], [Color], [FirstAppearance], [Sex], [WikiaUrl], [WikiaThumbnail],
                    [ImageName], [ItemTypeId], [ItemCategoryId], [AuraId]
                  )
                  
                  VALUES (
                    @UniqueName, @Name, @Description, @Health, @Shield, @Armor, @Stamina, @Power,
                    @Sprint, @SprintSpeed, @MasteryRequirement, @PassiveDescription, @ProductCategory,
                    @BuildPrice, @BuildTime, @SkipBuildTimePrice, @BuildQuantity, @ConsumeOnBuild,
                    @Tradable, @Conclave, @Color, @FirstAppearance, @Sex, @WikiaUrl, @WikiaThumbnail,
                    @ImageName, @ItemTypeId, @ItemCategoryId, @AuraId
                  )
                ",
                warframe
              );
            }
          }

          return Ok();
        }
      }
      catch (Exception)
      {
        return StatusCode(500);
      }
    }
  }
}
