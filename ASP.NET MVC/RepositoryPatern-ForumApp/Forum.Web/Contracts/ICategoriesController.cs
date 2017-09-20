using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Forum.Web.Contracts
{
    public interface ICategoriesController
    {
        ActionResult Index();

        ActionResult Details(int? id);

        ActionResult Create();

        ActionResult Create([Bind(Include = "Id,Name,ParentCategoryId")] Category category);

        ActionResult Edit(int? id);

        ActionResult Edit([Bind(Include = "Id,Name,ParentCategoryId")] Category category);

        ActionResult Delete(int? id);

        ActionResult DeleteConfirmed(int id);
    }
}
