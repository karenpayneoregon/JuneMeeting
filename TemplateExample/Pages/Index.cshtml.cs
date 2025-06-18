using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TemplateExample.Data;
using TemplateExample.Models;

namespace TemplateExample.Pages;
public class IndexModel(Context context) : PageModel
{
    [BindProperty]
    public required List<Products> Products { get; set; }

    /// <summary>
    /// Handles GET requests for the Index page.
    /// </summary>
    /// <remarks>
    /// This method retrieves a list of products from the database, including their associated categories.
    /// The products are ordered by category name and then by product name.
    /// Additionally, the SQL query used for fetching the data is logged for debugging purposes.
    /// </remarks>
    public void OnGet()
    {
        Products = context.Products.Include(x => x.Category)
            .OrderBy( x => x.Category.CategoryName)
            .ThenBy(x => x.ProductName)
            .ToList();

        var sqlQuery = context.Products
            .Include(x => x.Category)
            .ToQueryString();

        Log.Information(sqlQuery);

        Log.Information("Done getting products");
    }
}
