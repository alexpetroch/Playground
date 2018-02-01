using System;
using System.Collections.Generic;

namespace Playground.OOD
{
    #pragma warning disable CS0169, CS0649

    /*
    1. There are several file systems: FAT32, NTFS. Can be more
    2. Each file system can create file and directory
    3. NTFS has extended permission options
    4. File length is less in FAT 32
    5. Directory contains files         
    */


    public interface FileSystem
    {
        FSEntry Find(string path);
        FSDir CreateDir(FSDir parent, string name);
        FSFile CreateFile(FSDir parent, string name);
    }

    public class NTFSFileSystem : FileSystem
    {
        public FSDir CreateDir(FSDir parent, string name)
        {
            return new NTFSDir(name, parent);
        }

        public FSFile CreateFile(FSDir parent, string name)
        {
            return new NTFSFile(name, parent, null);
        }

        public FSEntry Find(string path)
        {
            return null;
        }
    }

    public class Fat32FileSystem : FileSystem
    {
        public FSDir CreateDir(FSDir parent, string name)
        {
            return new Fat32Dir(name, parent);
        }

        public FSFile CreateFile(FSDir parent, string name)
        {
            return new Fat32File(name, parent, null);
        }

        public FSEntry Find(string path)
        {
            return null;
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

    public class Fat32File : FSFile
    {
        public Fat32File(string name, FSDir parent, byte[] content) : base(name, parent, content)
        {
        }
    }

    public class NTFSFile : FSFile
    {
        public NTFSFile(string name, FSDir parent, byte[] content) : base(name, parent, content)
        {
        }
    }

    public class Fat32Dir : FSDir
    {
        public Fat32Dir(string name, FSDir parent) : base(name, parent)
        {
        }
    }

    public class NTFSDir : FSDir
    {
        public NTFSDir(string name, FSDir parent) : base(name, parent)
        {
        }
    }

}
