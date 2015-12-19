using System;
using System.IO;
using System.Xml.Serialization;

namespace SentimentAnalysis
{
    class XmlLoader
    {
        public static void SerializeCollection(WordsCollection wordsCollection)
        {
            XmlSerializer xml = new XmlSerializer(typeof (WordsCollection), 
                new Type[] {typeof (WordInfo)});
            FileStream file = new FileStream(Environment.CurrentDirectory.ToString(),FileMode.Create);
            xml.Serialize(file,wordsCollection);
            file.Close();
        }

        public static WordsCollection DeserializeCollection(WordsCollection wordsCollection)
        {
            wordsCollection = new WordsCollection();
            XmlSerializer xml = new XmlSerializer(typeof(WordsCollection));
            FileStream file = new FileStream(Environment.CurrentDirectory.ToString(),FileMode.Open);
            wordsCollection = (WordsCollection) xml.Deserialize(file);
            file.Close();
            return wordsCollection;
        }
    }
}
