using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_4
{
    internal class Book
    {
        private string name;
        private Chapter[] chapters;

        public Book() { }

        public Book(string name, int n)
        {
            this.name = name;
            this.chapters = new Chapter[n];
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name == null)
                    throw new ArgumentNullException();
                name = value;
            }
        }

        public Chapter this[int index]
        {
            get
            {
                if (index < 0 || index > chapters.Length - 1)
                    return null;
                return chapters[index];
            }

            set
            {
                if (index < 0 || index > chapters.Length - 1)
                    throw new AggregateException();
                chapters[index] = value;
            }
        }
        public Chapter this[string name]
        {
            get
            {
                foreach (Chapter chapter in chapters)
                    if (chapter.Name == name) return chapter;
                return null;
            }
        }
    }
}
