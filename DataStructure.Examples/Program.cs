using DataStructure.Examples;

var str = "{<>}()[]";
var wrongStr = "<{])";
var str1 = "((({})))";

Console.WriteLine(BracketsTask.CheckBalanceOfBrackets(str));
Console.WriteLine(BracketsTask.CheckBalanceOfBrackets(wrongStr));
Console.WriteLine(BracketsTask.CheckBalanceOfBrackets(str1));