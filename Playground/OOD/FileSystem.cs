using System;
using System.Collections.Generic;

namespace Playground.OOD
{
    #pragma warning disable CS0169, CS0649

    /*
    1. There are several file systems: FAT32, NTFS. Can be more
    2. Each file system can create file and directory
    3. NTFS has extened permission options
    4. File length is less in FAT 32
    5. Directory contains files         
    */


    public class FileSystem
    {
        public FSEntry Find(string path)
        {
            return null;
        }

        public FSFile CreateFile(string path, byte[] content)
        {
            return new FSFile(path, null, content);
        }

        public FSDir CreateDir(string path)
        {
            return new FSDir(path, null);
        }
    }

    public class FSEntry
    {
        protected FSDir _parent;
        protected string _name;

        public FSEntry(string name, FSDir parent)
        {
            _parent = parent;
            _name = name;
            Created = DateTime.Now.ToUniversalTime();
            Updated = DateTime.Now.ToUniversalTime();
            Accessed = DateTime.Now.ToUniversalTime();
        }

        public DateTime Created;
        public DateTime Updated;
        public DateTime Accessed;
        
        public FSDir Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent = value;
            }
        }
        
        public void Delete()
        {
            _parent.DeleteEntry(this);
        }
    }

    public class FSFile : FSEntry
    {
        byte[] _content;
        public FSFile(string name, FSDir parent, byte[] content) : base (name, parent)
        {
            _content = content;
        }
    }

    public class FSDir : FSEntry
    {
        public List<FSEntry> Childs = new List<FSEntry>();
        public FSDir(string name, FSDir parent) : base (name, parent)
        {
            
        }

        internal void DeleteEntry(FSEntry fSEntry)
        {
            throw new NotImplementedException();
        }
    }   

}
