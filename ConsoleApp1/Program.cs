using ConsoleApp1;

const string variable = "21 + 3 / (32 * 567)";
ArrayList tokens = new ArrayList();
Stack opers = new Stack();
Queue simbols = new Queue();
char[] operators = new[] { '+', '-', '*', '/' };
char[] brackets = new[] { '(', ')' };
string buff = "";

// char? oper = null;
var priorities = new Dictionary<string, int>();
priorities["+"] = 1;
priorities["-"] = 1;
priorities["*"] = 2;
priorities["/"] = 2;


foreach (var s in variable)
{ 
    if (s == ' ')
    { 
        continue;
    }
    
    if (Char.IsDigit(s)) 
    {
        buff += s;
    }
    else
    {
        if (buff.Length > 0)
        {
            tokens.Add(buff);
            buff = "";
        }
        
        tokens.Add(s + "");
        
    }
}

if (buff.Length > 0)
{ 
    tokens.Add(buff);
}

//Console.WriteLine(tokens);
//tokens.RemoveAt(tokens.Count - 1);
//Console.WriteLine(tokens.GetElements()[0]);
//tokens.RemoveAt(0);

foreach (var el in tokens.GetElements())
{
    //Console.WriteLine(el);
    int number;
    bool isNumeric = int.TryParse(el, out number);
    if (isNumeric == true)
    { 
        simbols.Push(el); 
       //Console.WriteLine(simbols);
        
    }

    if (isNumeric == false)
    {
        if (el == "(")
        {
            opers.Push("(");
        }
        
        if (el == "*")
        {
            opers.Push("*");
            //Console.WriteLine(opers.GetElements()[1]);
        }
        
        if (el == "/")
        {
            opers.Push("/");
            //Console.WriteLine(opers.GetElements()[1]);
        }
        if (el == "+" || el == "-")
            
        {
            if (opers.Check("*") == "*" || opers.Check("/") == "/")
            {
                opers.Pull();
                
                //Console.WriteLine(opers.GetElements()[1]);
            }
            else
            {
                opers.Push(el);
                //Console.WriteLine(opers.GetElements()[1]);
            }
        }

        if (el == ")")
        {
            while (opers.Check("(") != "(")
            {
                simbols.Push(opers.Pull());
            }

            opers.Pull();
        }
    }    
   
}

while (!opers.IsEmpty())
{
    simbols.Push(opers.Pull());
}
