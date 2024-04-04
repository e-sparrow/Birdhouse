using System.Collections.Generic;
using Birdhouse.Features.Cases;
using Birdhouse.Features.Cases.Enums;
using Cyriller;
using Cyriller.Model;
using NUnit.Framework;
using UnityEngine;

namespace Birdhouse.Tests.Editor
{
    public class HtmlWebCaseTest
    {
        [Test]
        public void Test()
        {
            var values = new List<WordCasePair>()
            {
                new WordCasePair("Австралия", CasesEnum.Genitive),
                new WordCasePair("Австралия", CasesEnum.Dative),
                new WordCasePair("Австралия", CasesEnum.Accusative),
                new WordCasePair("Австралия", CasesEnum.Instrumental),
                new WordCasePair("Австралия", CasesEnum.Prepositional),
                new WordCasePair("Россия", CasesEnum.Genitive),
                new WordCasePair("Россия", CasesEnum.Dative),
                new WordCasePair("Россия", CasesEnum.Accusative),
                new WordCasePair("Россия", CasesEnum.Instrumental),
                new WordCasePair("Россия", CasesEnum.Prepositional),
                new WordCasePair("Александр", CasesEnum.Genitive),
                new WordCasePair("Александр", CasesEnum.Dative),
                new WordCasePair("Александр", CasesEnum.Accusative),
                new WordCasePair("Александр", CasesEnum.Instrumental),
                new WordCasePair("Александр", CasesEnum.Prepositional),
            };
            
            foreach (var value in values)
            {
                var result = GetValue(value);
                Debug.Log(result);

                string GetValue(WordCasePair pair)
                {
                    var declinedValue = pair.Word.As(pair.Case);
                    return declinedValue;
                }
            }
        }

        private readonly struct WordCasePair
        {
            public WordCasePair(string word, CasesEnum @case)
            {
                Word = word;
                Case = @case;
            }

            public string Word
            {
                get;
            }

            public CasesEnum Case
            {
                get;
            }
        }
    }
}