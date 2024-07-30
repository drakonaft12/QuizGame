#nullable enable
using Newtonsoft.Json;
using QuizGameCore;
using Quizs.QuizSource;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Uitls;
using UnityEngine;

public class XmlFileQuizSource : MonoBehaviour, IQuizSource
{
    [SerializeField] private TextAsset textAsset = null!;


    public IReadOnlyList<IQuiz> QuizList()
    {
        var raw = textAsset.EnsureNotNull().text;
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuizData>));
        TextReader reader = new StringReader(raw);
        var list = serializer.Deserialize(reader).EnsureNotNull() as List<QuizData>;
        return list.Select(q => q.Create()).ToList();
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
