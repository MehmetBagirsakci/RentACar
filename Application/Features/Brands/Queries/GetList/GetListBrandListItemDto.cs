using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandListItemDto
{
    //Veri kaynağındaki herşeyi kullanıcıya vermek istemiyoruz. Sadece kullanıcının görmesi gereken alanları ona gösteriyoruz.
    public Guid Id { get; set; }
    public string Name { get; set; }
}

