using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public class ArticleStatus
    {
        public int ArticleID;

        public byte status;

        public string naam = "Ruilwinkel";

        public ArticleStatus() { }

        public ArticleStatus(int ArticleID, byte status)
        {
            this.ArticleID = ArticleID;
            this.status = status;
        }
    }
}