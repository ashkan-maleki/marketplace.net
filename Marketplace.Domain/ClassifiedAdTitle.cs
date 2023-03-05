using System.Text.RegularExpressions;
using Marketplace.Framework;

namespace Marketplace.Domain;

public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
{
    private ClassifiedAdTitle(string value)
    {
        if (value.Length > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                "Title cannot be longer than 100 characters");
        }

        _value = value;
    }

    public static ClassifiedAdTitle FromString(string title) => new(title);

    public static ClassifiedAdTitle FromHtml(string htmlTitle)
    {
        string supportedTagsReplaced = htmlTitle
            .Replace("<i>", "*")
            .Replace("</i>", "*")
            .Replace("<b>", "**")
            .Replace("</b>", "**");

        return new(Regex.Replace(
            supportedTagsReplaced, "<.*?>", string.Empty));
    }

    private readonly string _value;
}