using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.DAL.Models
{
    public class LoA
    {
        public List<SelectListItem> LevelDropDown { get; set; }
        public int SelectedLevel { get; set; }
    }
}