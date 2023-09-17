using TestAssessmentAPI.Model.Domain;

namespace TestAssessmentAPI.Model
{
    public class FormatModelsInMLA
    {
        public static string FormatInMLA(List<Book> books)
        {
            string result = string.Empty;

            var enumeratedModels = books.Select((model, index) => $"{index + 1}. {model.AuthorLastName}, " +
                $"{model.AuthorFirstName}. {model.Title}, {model.Publisher}, {model.Price:C}");
            string mlaFormattedList = string.Join(Environment.NewLine, enumeratedModels);

            return $"{Environment.NewLine}{Environment.NewLine}{mlaFormattedList}";
        }
    }
}
