using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public class SortedArticles
    {
        public List<int> articles;

        public SortedArticles() { }

        public SortedArticles(List<int> articles)
        {
            this.articles = articles;
        }
    }
}