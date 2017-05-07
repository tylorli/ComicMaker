using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using ComicMaker;
using System.Drawing;

namespace Client
{
    class Serial
    {
        private string filename;
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        public Serial(string filename)
        {
            this.filename = filename;
        }

        public void doit()
        {
            FileStream fs = new FileStream(this.filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter iformatter = new BinaryFormatter();
            DrawObject g = (DrawObject)iformatter.Deserialize(fs);
            CommenList.list.Add(g);
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
            CommenList.list = (List<DrawObject>)iformatter.Deserialize(fs);
            fs.Close();
        }

        public void TextSerial()
        {
            FileStream fs = new FileStream(this.filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter iformatter = new BinaryFormatter();
            SerialText g = (SerialText)iformatter.Deserialize(fs);
            DrawText dt = new DrawText(g.X, g.Y, g.Width, g.Height, g.ID);

            //dt.DrawRichText = "123";
           // DrawRectangle dt = new DrawRectangle(g.X, g.Y, g.Width, g.Height, g.PenColor, g.ID);

            CommenList.list.Add(dt);
            fs.Close();
        }
    }
}
