#nullable enable
using Newtonsoft.Json;
using QuizGameCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Uitls;
using Unity.VisualScripting;
using UnityEngine;


namespace Quizs.QuizSource
{
    public class JsonFileQuizSource : MonoBehaviour, IQuizSource
    {
        [SerializeField] private TextAsset textAsset = null!;
        private List<QuizData> _list = null!;


        public IReadOnlyList<IQuiz> QuizList()
        {
            _list = new List<QuizData>();
            var raw = textAsset.EnsureNotNull().text;
            var list = JsonConvert.DeserializeObject<List<QuizData>>(raw).EnsureNotNull();
            _list.AddRange(list);
            return list.Select(q => q.Create()).ToList();
        }

        [ContextMenu("Xml")]
        private void SerialiseFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizData>));
            FileStream file = new FileStream(Application.dataPath + "/Resources/quizTable.xml", FileMode.Create);
            serializer.Serialize(file, _list);
            file.Close();
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class QuizData
        {
            public string? Question;
            public string? CorrectAnswer;
            public string[]? WrongAnswers;


            public IQuiz Create()
            {
                return new Quiz(
                    Question.EnsureNotNull(),
                    CorrectAnswer.EnsureNotNull(),
                    WrongAnswers.EnsureNotNull()
                );
            }
        }
    }
}