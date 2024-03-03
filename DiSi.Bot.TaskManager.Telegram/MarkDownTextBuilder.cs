namespace DiSi.Bot.TaskManager.Telegram;

public class MarkDownTextBuilder
{
    private string _text = string.Empty;

    private string GetWrappedText(string text, string wrap)
        => wrap + text + wrap;

    public static MarkDownTextBuilder Create()
        => new();
    
    public MarkDownTextBuilder Line(int count = 1)
    {
        for(int i = 0; i < count; i++)
            _text += '\n';
        return this;
    }
    
    public MarkDownTextBuilder AddText(string text)
    {
        _text += text;
        return this;
    }

    public MarkDownTextBuilder AddBold(string text)
    {
        _text += MarkDownHelper.ToBold(text);
        return this;
    }
    
    public MarkDownTextBuilder AddItalic(string text)
    {
        _text += MarkDownHelper.ToItalic(text);
        return this;
    }
    
    public MarkDownTextBuilder AddUnderlined(string text)
    {
        _text += MarkDownHelper.ToUnderlined(text);
        return this;
    }
    
    public MarkDownTextBuilder AddStrikeThrough(string text)
    {
        _text += MarkDownHelper.ToStrikeThrough(text);
        return this;
    }
    
    public string GetText()
        => _text;
}

public static class MarkDownHelper
{
    private static string GetWrappedText(string text, string wrap)
        => wrap + text + wrap;

    public static string ToBold(string text)
        => GetWrappedText(text, "*");
    
    public static string ToItalic(string text)
        => GetWrappedText(text, "_");
    
    public static string ToUnderlined(string text)
        => GetWrappedText(text, "__");
    
    public static string ToStrikeThrough(string text)
        => GetWrappedText(text, "~");

    public static string CodeBlockWrap(string text)
        => GetWrappedText(text, "```");
    
    public static string CodeBlock(string text, string programmingLanguage = "")
        => GetWrappedText(programmingLanguage + '\n' + text + '\n', "```");
    
    public static string InlineLink(string url)
        => $"[inline URL]({url})";
    public static string UserMention(long userId)
        => $"[inline mention of a user](tg://user?id={userId})";
}