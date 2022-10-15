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
            xmlDocument.Load("LPLA00001.xml");

            XmlNodeList allElements = xmlDocument.GetElementsByTagName("ListaPlac"); 
            Console.WriteLine(allElements.Count);

            for (int i = allElements.Count - 1; i >= 0; i--)
            {
                var node = allElements[i];
                var nodeWyplaty = node["Wyplaty"].ChildNodes;
               
                if (nodeWyplaty.Count == 0)
                {                    
                    allElements[i].ParentNode.RemoveChild(allElements[i]);
                }
            }
           
            xmlDocument.Save("LPLA00001-kopiaa.xml");

            Console.ReadLine();
        }

    }
}