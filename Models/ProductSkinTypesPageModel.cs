using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Medii_de_Programare_Gradinaru_Alexandra.Data;


namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Models
{
    public class ProductSkinTypesPageModel:PageModel
    {
        public List<AssignedSkinTypeData> AssignedSkinTypeDataList;
        public void PopulateAssignedSkinTypeData(Proiect_Medii_de_Programare_Gradinaru_AlexandraContext context, Product product)
        {
            var allSkinTypes = context.SkinType;
            var productSkinTypes = new HashSet<int>(product.ProductSkinTypes.Select(c => c.ProductID));
            AssignedSkinTypeDataList = new List<AssignedSkinTypeData>();
            foreach (var skin in allSkinTypes)
            {
                AssignedSkinTypeDataList.Add(new AssignedSkinTypeData
                {
                    SkinTypeID = skin.ID,
                    Name = skin.SkinTypeName,
                    Assigned = productSkinTypes.Contains(skin.ID)
            });
                

            }
        }
        public void UpdateProductSkinTypes(Proiect_Medii_de_Programare_Gradinaru_AlexandraContext context, string[] selectedSkinTypes, Product productToUpdate)
        {
            if(selectedSkinTypes == null)
            {
                productToUpdate.ProductSkinTypes = new List<ProductSkinType>();
                return;
            }
            var selectedSkinTypesHS = new HashSet<string>(selectedSkinTypes);
            var productSkinTypes = new HashSet<int>(productToUpdate.ProductSkinTypes.Select(c => c.SkinType.ID));
            foreach(var skin in context.SkinType)
            {
                if (selectedSkinTypesHS.Contains(skin.ID.ToString()))
                {
                    if (!productSkinTypes.Contains(skin.ID))
                    {
                        productToUpdate.ProductSkinTypes.Add(new ProductSkinType
                        {
                            ProductID = productToUpdate.ID,
                            SkinTypeID = skin.ID
                        });
                        
                    }
                }
                else
                {
                    if (productSkinTypes.Contains(skin.ID))
                    {
                        ProductSkinType courseToRemove = productToUpdate.ProductSkinTypes.SingleOrDefault(i => i.SkinTypeID == skin.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
