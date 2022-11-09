using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace xmlcleaner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDocument = new XmlDocument();  
            xmlDocument.Load("L.xml");

            XmlNodeList allElements = xmlDocument.GetElementsByTagName("Li"); 
            Console.WriteLine(allElements.Count);

            for (int i = allElements.Count - 1; i >= 0; i--)
            {
                var node = allElements[i];
                var nodeWyplaty = node["Wy"].ChildNodes;
               
                if (nodeWyplaty.Count == 0)
                {                    
                    allElements[i].ParentNode.RemoveChild(allElements[i]);
                }
            }
           
            xmlDocument.Save("Lkopiaa.xml");

            Console.ReadLine();
        }

    }
}
