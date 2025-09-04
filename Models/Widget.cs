// namespace MyCatalogApi.webapi.Models;
// public class Widget
// {
//     public string Id { get; set; } = string.Empty;
//     public string CategoryId { get; set; } = string.Empty;
//     public string Name { get; set; } = string.Empty;
//     public string Description { get; set; } = string.Empty;
//     public string Code { get; set; } = string.Empty;
//     public string OutputImage { get; set; } = string.Empty;
//     public string CodeCopyText { get; set; } = string.Empty;
//     public bool IsFavorite { get; set; } = false;
//     public Category? Category { get; set; }
// }

namespace MyCatalogApi.webapi.Models;

public class Widget
{
    public string Id { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string OutputImage { get; set; } = string.Empty;
    public string CodeCopyText { get; set; } = string.Empty;
    public bool IsFavorite { get; set; } = false;

    public Category? Category { get; set; }
}
