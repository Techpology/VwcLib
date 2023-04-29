using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vwcLib.Objects
{
    public class Tag
    {
        public string tagName { get; set; }
        public Dictionary<string, string> args { get; set; }
        public bool isSlt = false; //is Single line tag (/>)
        public bool isStr = false; //is Single line tag (/>)
        public string strVal = "";

        public Tag(string tagName)
        {
            this.tagName = tagName;
            this.args = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            if(isStr)
            {
                return strVal;
            }

            string str = "";
            if(args.Count != 0)
            {
                string[] argArr = args.Keys.ToArray();
                string[] argValArr = args.Values.ToArray();
                for (int i = 0; i < args.Count; i++)
                {
                    str += $"{argArr[i]}='{argValArr[i]}'";
                }
            }

            string tStr = "";
            foreach (Tag _t in children)
            {
                tStr += _t.ToString() + "\n";
            }
            return $"<{tagName} {str}{((isSlt) ? "/>":'>')}\n{((isSlt) ? "" : $"{tStr}</{tagName}>")}";
        }

        public List<Tag> children = new List<Tag>();
    }
}
