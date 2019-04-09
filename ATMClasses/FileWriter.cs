using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Interface;


namespace ATMClasses
{
    public class FileWriter
    {
        public FileWriter(IAirSpace airSpace)
        {
            airSpace.SplitCreated += onSplitCreated;
        }

        public void onSplitCreated(object source, SplitEvent conditions)
        {
            String[] s = stringCreator(conditions.Conditiontracks);
            String path = @".\ConditionDetecter.txt";

            using (StreamWriter writer = File.AppendText(path))
            {
                foreach (var line in s)
                {
                    writer.WriteLine(line);
                }
            }
        }

       

        public string[] stringCreator(List<ConditionDetecter> c)
        {
            String[] l = new string[c.Count];

            for (int i = 0; i < c.Count; i++)
            {
                l[i] = "Fligts are in Danger: ";

                for (int j = 0; j < c[i].detectingFligts.Count; j++)
                {
                    l[i] += c[i].detectingFligts[j]._tag + ", ";
                }

                l[i] += c[i].detectTime + ":" + c[i].detectTime.Millisecond;
            }

            return l;
        }
    
        //private object fileWriter;

        //public void Update(ConditionDetecter conditionDetecter)
        //{
        //    StreamWriter _fileWriter = new StreamWriter(@"C: \Users\Brug\Desktop\AirTrafficGruppe5\ATMClasses\bin\Debug\logfile.txt");
            
        //    _fileWriter.WriteLine(conditionDetecter);

        //    _fileWriter.Flush();
        //}

    }
}
