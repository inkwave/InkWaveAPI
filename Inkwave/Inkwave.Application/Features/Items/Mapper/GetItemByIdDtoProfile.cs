using Inkwave.Application.Features.Items.Queries.GetItemById;

namespace Inkwave.Application.Features.Items.Mappers;
public class GetItemByIdDtoProfile : Profile
{
    public GetItemByIdDtoProfile()
    {
        var profile = new MappingProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
        Mapper mapper = new Mapper(configuration);
        CreateMap<Item, GetItemByIdDto>()
    .AfterMap((src, dest) =>
    {
        //  dest.Categorys = src.ItemCategorys.Select(ic => Mapper.Map<GetItemByIdCategoryDto>(ic.Category)).ToList();
        var cats = src.ItemCategorys.Select(x => x.Category).ToList();

        var MapCategorys = mapper.Map<GetItemByIdCategoryDto>(cats);
        //dest.Categorys = Mapper.Map<GetItemByIdCategoryDto>(cats);
    });


    }
}
