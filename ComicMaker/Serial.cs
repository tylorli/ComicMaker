using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ComicMaker
{
    class Serial
    {
        public void save(string filename, DrawObject obj)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public void savelist(string filename, List<DrawObject> list)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(fs, list);
            fs.Close();
        }

        public void openfile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter iformatter = new BinaryFormatter();
            CC.graphicsList = (List<DrawObject>)iformatter.Deserialize(fs);
            fs.Close();
        }
    
    }
}
