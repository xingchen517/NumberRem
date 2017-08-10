using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace App1
{
    public class ImaginationModel
    {
        public Item[] Items { get; set; }

        private static readonly string configFile = "App1.ImaginationFile.xml";
        private ImaginationModel()
        {

        }
        private static Lazy<ImaginationModel> _instance = new Lazy<ImaginationModel>(()=> {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var names = assembly.GetManifestResourceNames();
                XmlSerializer serializer = new XmlSerializer(typeof(ImaginationModel));
                using (var sr = assembly.GetManifestResourceStream(configFile))
                {
                    return (ImaginationModel)serializer.Deserialize(sr);
                    
                }
            }
            catch
            {
                return new ImaginationModel();
            }

        });

        public static ImaginationModel Instance => _instance.Value;

        public static string GetImages(string code,bool isEven=false)
        {
            var sb = new StringBuilder();
            if(!string.IsNullOrEmpty(code))
            {
                if(!isEven)
                {
                    for(int i=0;i<code.Length;i++)
                    {
                        char cr = code[i];        
                        var item = Instance.Items.FirstOrDefault(it => it.Key == cr.ToString());
                        if(null!=item)
                        {
                            sb.Append(item.Value.ToString()+" ");
                        }                    
                    }
                }
                else
                {
                    for (int i = 1; i < code.Length; i+=2)
                    {                        
                        var item = Instance.Items.FirstOrDefault(it => it.Key == code.Substring(i-1,2));
                        if (null != item)
                        {
                            sb.Append(item.Value.ToString() + " ");
                        }
                    }
                }

            }
            return sb.ToString();
        }
    }
}
