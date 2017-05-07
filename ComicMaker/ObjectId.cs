using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicMaker
{
    class ObjectId
    {
        public static void AddObjtoListBox()
        {
            CC.listbox.Items.Clear();
            string s;
            int x = 0, y = 0, z = 0;
            for (int i = 0; i < CC.graphicsList.Count; i++)
            {
                s = CC.graphicsList[i].ToString().Split('.')[1];
                switch (s)
                {
                    case ("DrawImage"):
                        x++;
                        CC.listbox.Items.Add("图片对象" + CC.graphicsList[i].ID);
                        break;
                    case ("DrawCurve"):
                        y++;
                        CC.listbox.Items.Add("曲线对象" + CC.graphicsList[i].ID);
                        break;
                    case ("DrawText"):
                        z++;
                        CC.listbox.Items.Add("文字对象" + CC.graphicsList[i].ID);
                        break;
                }
            }
        }

        public static void SelectObjInListBox()
        {
            string s = CC.listbox.SelectedItem.ToString().Split('.')[1];

        }

    }
}
