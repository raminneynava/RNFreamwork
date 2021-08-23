using Application.Products.Dto;
using Application.Products.Interfaces;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{

    public class MenuItemTagHelper : TagHelper
    {
        private readonly IProductCategory _service;
        public MenuItemTagHelper(IProductCategory service)
        {
            _service = service;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.Content.AppendHtml(GetContent());
        }
        private TagBuilder GetContent()
        {
            var data = _service.GetMenuAsync();
            TagBuilder liMain = null;
            foreach (var item in data.Where(p => p.ParentCategoryId == null))
            {

                if (liMain == null)
                {
                    liMain = CreateLi(item.Title, "");
                }
                else
                {
                    liMain.InnerHtml.AppendHtml(CreateLi(item.Title, ""));
                }

                var ul = new TagBuilder("ul");
                ul.AddCssClass("row");
                var liAll = CreateLi($"همه دسته بندی های  {item.Title}", "#");
                liAll.AddCssClass("col-12");
                ul.InnerHtml.AppendHtml(liAll);

                TagBuilder liCol_1 = CreateLi();
                liCol_1.AddCssClass("col-3");
                TagBuilder liCol_2 = CreateLi();
                liCol_2.AddCssClass("col-3");
                TagBuilder liCol_3 = CreateLi();
                liCol_3.AddCssClass("col-3");
                TagBuilder liCol_4 = CreateLi();
                liCol_4.AddCssClass("col-3");

                int index = 0;
                foreach (var sub1 in data.Where(p => p.ParentCategoryId == item.Id))
                {
                    string link = $"/product?CatalogTypeId={sub1.Id}";

                    if (index < 13)
                    {
                        var a = new TagBuilder("a");
                        a.MergeAttribute("href", link);
                        a.InnerHtml.Append(sub1.Title);
                        liCol_1.InnerHtml.AppendHtml(a);

                        liCol_1.InnerHtml.AppendHtml(CreateSub(data, sub1, index, out index));
                        index++;
                    }
                    else if (index < 26)
                    {

                        var a = new TagBuilder("a");
                        a.MergeAttribute("href", link);
                        a.InnerHtml.Append(sub1.Title);
                        liCol_2.InnerHtml.AppendHtml(a);

                        liCol_2.InnerHtml.AppendHtml(CreateSub(data, sub1, index, out index));
                        index++;


                    }
                    else if (index < 39)
                    {
                        var a = new TagBuilder("a");
                        a.MergeAttribute("href", link);
                        a.InnerHtml.Append(sub1.Title);
                        liCol_3.InnerHtml.AppendHtml(a);

                        liCol_3.InnerHtml.AppendHtml(CreateSub(data, sub1, index, out index));
                        index++;


                    }
                    else
                    {
                        var a = new TagBuilder("a");
                        a.MergeAttribute("href", link);
                        a.InnerHtml.Append(sub1.Title);
                        liCol_4.InnerHtml.AppendHtml(a);

                        liCol_4.InnerHtml.AppendHtml(CreateSub(data, sub1, index, out index));
                        index++;
                    }
                }
                ul.InnerHtml.AppendHtml(liCol_1);
                ul.InnerHtml.AppendHtml(liCol_2);
                ul.InnerHtml.AppendHtml(liCol_3);
                ul.InnerHtml.AppendHtml(liCol_4);
                liMain.InnerHtml.AppendHtml(ul);
            }
            return liMain;
        }
        private TagBuilder CreateSub(List<MenuItemDto> data, MenuItemDto sub1, int count, out int IndexCount)
        {
            IndexCount = count;
            var ulsub2 = new TagBuilder("ul");
            foreach (var sub2 in data.Where(p => p.ParentCategoryId == sub1.Id))
            {
                ulsub2.InnerHtml.AppendHtml(CreateLi(sub2.Title, $"/product?CatalogTypeId={sub2.Id}"));
                IndexCount++;
            }
            return ulsub2;
        }

        private TagBuilder CreateLi(string Text, string Link)
        {
            var a = new TagBuilder("a");
            a.MergeAttribute("href", $"{Link}");
            a.MergeAttribute("title", Text);
            a.InnerHtml.Append(Text);
            var li = new TagBuilder("li");

            li.InnerHtml.AppendHtml(a);
            return li;
        }
        private TagBuilder CreateLi()
        {
            var li = new TagBuilder("li");
            return li;
        }
    }
}
