using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNBlogManager
{
    class BlogItem
    {
        private string title;
        private string link;
        private string creator;
        private string author;
        private string guid;
        private string pubDate;
        private string description;

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

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public string PubDate
        {
            get { return pubDate; }
            set { pubDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}