namespace DataStructure.Examples;

public static class BracketsTask
{
    public static bool CheckBalanceOfBrackets(string str)
    {
        var openBrackets = new char[] { '(', '{', '[', '<'};
        var closeBrackets = new char[] { ')', '}', ']', '>' };
        var sequence = new NodeStack<char>();
        foreach (var ch in str)
        {
            if (openBrackets.Contains(ch))
            {
                sequence.Push(ch);
            }
            else if (closeBrackets.Contains(ch))
            {
                if (sequence.IsEmpty) return false;
                if (Array.IndexOf(closeBrackets, ch) == Array.IndexOf(openBrackets, sequence.Peek()))
                {
                    sequence.Pop();
                }
                else
                {
                    return false;
                }
            }
        }
        return sequence.IsEmpty;
    }
}