﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Application.contract.Article
{
   public class EditArticle: CreateArticle
    {
        public long id { get; set; }
    }
}
