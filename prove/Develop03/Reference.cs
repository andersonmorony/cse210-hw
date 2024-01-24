using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03
{
    public class Reference
    {
        private string _author;
        private int _chapter;
        private int _startVerse;
        private int _endVerse;

        public Reference()
        {
            _author = "Anonymous";
        }

        public Reference(string author)
        {
            _author = author;
        }
        public Reference(string author, int chapter, int startVerse)
        {
            _author = author;
            _chapter = chapter;
            _startVerse = startVerse;
        }
        public Reference(string author, int chapter, int startVerse, int endVerse)
        {
            _author = author;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public string GetReferenceAsText()
        {

            if (_chapter is 0)
            {
                return _author;
            }

            if (_endVerse is 0)
            {
                return $"{_author} {_chapter}:{_startVerse}";
            }

            return $"{_author} {_chapter}:{_startVerse}-{_endVerse}";
            
        }
    }
}
