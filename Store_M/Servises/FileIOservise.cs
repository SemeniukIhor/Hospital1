using Newtonsoft.Json;
using Store_M.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_M.Servises
{
    class FileIOservise
    {
        private readonly string PATH;
       public FileIOservise(string path)
        {
            PATH = path;
        }
        public BindingList<MedModel> Load()
        {
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<MedModel>();
            }
            using (var rider = File.OpenText(PATH))
            {
                var fileText = rider.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<MedModel>>(fileText);
            }
        }
        public void SaveData(object medData)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(medData);
                writer.Write(output);
            }

        }
    }
}
