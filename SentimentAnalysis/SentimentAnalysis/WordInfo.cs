using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SentimentAnalysis
{
    [Serializable]
    public class WordInfo
    {
        [XmlElement("Word")]
        public string Word { get; set; }
        [XmlElement("GoodChance")]
        public decimal GoodChance { get; set; }
        [XmlElement("BadChance")]
        public decimal BadChance { get; set; }

        public WordInfo(string word, decimal goodChance, decimal badChance)
        {
            Word = word;
            GoodChance = goodChance;
            BadChance = badChance;
        }
        public WordInfo()
        { }
    }

    [XmlRoot("WordsList")]
    [XmlInclude(typeof (WordInfo))]
    public class WordsCollection
    {
        [XmlArray("WordsCollection"),XmlArrayItem("Word")]
        public List<WordInfo> WordInfos { get; set; }

        public WordsCollection()
        {
            WordInfos = new List<WordInfo>();
        }

        public void Add(WordInfo word)
        {
            WordInfos.Add(word);
        }
    }
}
