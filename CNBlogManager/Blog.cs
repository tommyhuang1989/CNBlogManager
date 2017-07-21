using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNBlogManager
{
    class Blog
    {
        private string title;
        private string link;
        private string description;
        private string language;
        private string lastBuildDate;
        private string pubDate;
        private string ttl;
        private List<BlogItem> items;


        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public string LastBuildDate
        {
            get { return lastBuildDate; }
            set { lastBuildDate = value; }
        }

        public string PubDate
        {
            get { return pubDate; }
            set { pubDate = value; }
        }

        public string Ttl
        {
            get { return ttl; }
            set { ttl = value; }
        }

        public List<BlogItem> Items
        {
            get { return items; }
            set { items = value; }
        }



    }
}
