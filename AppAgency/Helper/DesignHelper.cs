using Domaine.Model;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;

namespace AppAgency.Helper
{
    public static class DesignHelper
    {


        public static void DesignedText(string text, ConsoleColor? color, ConsoleColor? backGrColor)
        {

            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException("Text is required");

            // couleur ecriture
            if (color.HasValue)
            {
                Console.ForegroundColor = color.Value;
            }

            if (backGrColor.HasValue)
            {
                Console.BackgroundColor = backGrColor.Value;
            }
            Console.WriteLine(text);
            Console.ResetColor();
        }



        private static bool IsValidColor(string color)
        {
            try
            {
                ColorTranslator.FromHtml(color);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ApplyStyle(StyleText style, string text)
        {
            string newText;
            switch (style)
            {
                case StyleText.TITLE:
                    int l = text.Length;
                    newText = new string(' ', l - 1);
                    newText += $"{text}\n";
                    newText += new string(' ', l - 1);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(newText);
                    Console.ResetColor();
                    break;
                case StyleText.INFO:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
                case StyleText.CONFIRMATION:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
                case StyleText.SUCCESS:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
                case StyleText.ERROR:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
                case StyleText.SUMMARY:
                    int ll = text.Length;
                    newText = new string(' ', ll - 1);
                    newText += $"{text}\n";
                    newText += new string(' ', ll - 1);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(newText);
                    Console.ResetColor();
                    break;
                default: break;

            }


        }

        public static void ShowList(IEnumerable<Object> items, string[] propertiesToDisplay,StyleDisplayData type)
        {
            if (items?.Any() != true)
            {
                ApplyStyle(StyleText.ERROR, "Rien a afficher");
                return;
            }

            if (propertiesToDisplay?.Any() != true)
            {
                ApplyStyle(StyleText.ERROR, "Aucune propriétés specifiés pour l'affichage");
                return;
            }

            var firstItem = items.First();
            var validProperties = new List<string>();
            var propertiyMapping = new Dictionary<string, Func<Object, object>>();

            foreach (var propertyName in propertiesToDisplay)
            {
                var property = firstItem.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    propertiyMapping[propertyName] = item =>
                    {

                        try
                        {
                            var value = property.GetValue(item);
                            return value?.ToString() ?? "N/A";
                        }
                        catch
                        {
                            return "Error";
                        }
                    };
                    validProperties.Add(propertyName);
                }
                else
                {
                    Console.WriteLine($"Propriété '{propertyName}' non trouvée");
                    return;
                }
            }
            if (type == StyleDisplayData.TABLE) {DisplayAsTable(items, propertiyMapping);
            }


        }

        private static void DisplayAsTable(IEnumerable<object> items, Dictionary<string, Func<object, object>> propertiyMapping)
        {
            
            if (!items.Any() || !propertiyMapping.Any()) { return; }

            // calcul largeur des colonne
            var columnWidths = propertiyMapping.ToDictionary(
                kvp => kvp.Key,
                kvp => Math.Max(kvp.Key.Length,
                items.Max(item =>
                {
                    var value = kvp.Value(item);
                    return value?.ToString()?.Length ?? 0;
                })
                )
            );

            // preparation affichage
            var separator = "+-" + string.Join("-+-", propertiyMapping.Keys.Select(key => new string('-', columnWidths[key])))+"-+";
            var header = "| " + string.Join(" | ", propertiyMapping.Keys.Select(key => key.PadRight(columnWidths[key]))) + " |";

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);

            foreach( var item in items)
            {
                var row = "| " + string.Join(" | ", propertiyMapping.Select(kpv =>
                {
                    var value = kpv.Value(item);
                    return (value?.ToString() ?? "N/A").PadRight(columnWidths[kpv.Key]);
                })) + " |";
                Console.WriteLine(row);
            }
            Console.WriteLine(separator);


        }
    }
}
[Flags]
public enum StyleText
{
    TITLE = 0,
    INFO = 1,
    CONFIRMATION = 2,
    ERROR,
    SUCCESS,
    SUMMARY
}
[Flags]
public enum StyleDisplayData
{
    TABLE,
    LIST
}