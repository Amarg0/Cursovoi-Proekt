using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SentimentAnalysis
{
    class Stemmer
    {
        const string Vo = "аеиоуыэюя";
        const string PerfectiveGround = "((ив|ивши|ившись|ыв|ывши|ывшись)|((?<=[ая])(в|вши|вшись)))$";
        const string Reflexive = "(с[яь]$)";
        const string Adjective = "(ее|ие|ые|ое|ими|ыми|ей|ий|ый|ой|ем|им|ым|ом" +
                                 "|его|ого|еых|ую|юю|ая|яя|ою|ею)$";
        const string Participle = "((ивш|ывш|ующ)|((?<=[ая])(ем|нн|вш|ющ|щ)))$";

        const string Verb = "((ила|ыла|ена|ейте|уйте|ите|или|ыли|ей|уй|ил|ыл|им|" +
                            "ым|ены|ить|ыть|ишь|ую|ю)|((?<=[ая])(ла|на|ете|йте|ли" +
                            "|й|л|ем|н|ло|но|ет|ют|ны|ть|ешь|нно)))$";

        const string Noun = "(а|ев|ов|ие|ье|е|иями|ями|ами|еи|ии|и|ией|ей|ой|ий|й" +
                            "|и|иям|ям|ием|ем|ам|ом|о|у|ах|иях|ях|ы|ь|ию|ью|ю|ия|ья|я)$";

        const string Rvre = "^(.*?[аеиоуыэюя])(.*)$";
        const string Derivational = "[^аеиоуыэюя][аеиоумыэюя]+[^аеиоуыэюя]+[аеиоуыэюя].*(?<=о)сть?$";

        public Stemmer ()
        { }

        bool RegexReplace(ref string Original, string Regx, string Value)
        {
            string original = Original;
            Regex regex = new Regex(Regx);
            Original = regex.Replace(Original, Value);
            return (Original != original);
        }

        Match RegexMatch(string Original, string Regx)
        {
            Regex reg = new Regex(Regx);
            return reg.Match(Original);
        }

        MatchCollection RegexMatches(string Original, string Regx)
        {
            Regex reg = new Regex(Regx, RegexOptions.Multiline);
            return reg.Matches(Original);
        }

        public string Stem(string Word)
        {
            string word = Word.ToLower().Trim().Replace("ё", "е");
            string value = string.Empty;
            do 
            {
                MatchCollection matches = RegexMatches(word, Rvre);
                if (matches.Count < 1)
                {
                    Match OddMatch = RegexMatch(word, "[a-z][0-9]");
                    if (OddMatch.Success)
                        value = word;
                    break;
                }

                string rv = matches[0].Value;

            }
    }
}
