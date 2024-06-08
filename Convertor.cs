using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{



    class Stack
    {
        public int topC;
        public int topS;
        public int topI;
        public List<char> stackC;
        public List<string> stackS;
        public List<int> stackI;
        public Stack()
        {
            topC = -1;
            topS = -1;
            topI = -1;
            stackC = new List<char>();
            stackS = new List<string>();
            stackI = new List<int>();
        }
        public void AddInStack(char s)
        {
            topC++;
            stackC.Add(s);


        }
        public void AddInStack(string s)
        {
            topS++;
            stackS.Add(s);


        }
        public void AddInStackI(int x)
        {
            topI++;
            stackI.Add(x);
        }
        public char DeleteOfStackC()
        {
            char x;
            if (topC == -1)
                return '$';
            else
            {
                x = stackC[topC];
                stackC.RemoveAt(topC);
                topC--;
                return x;
            }
        }
        public int DeleteOfStackI()
        {
            int x;
            if (topI == -1)
                return 1;
            else
            {
                x = stackI[topI];
                stackI.RemoveAt(topI);
                topI--;
                return x;
            }
        }
        public string DeleteOfStackS()
        {
            string x;
            if (topS == -1)
                return "0";
            else
            {
                x = stackS[topS];
                stackS.RemoveAt(topS);
                topS--;
                return x;
            }
        }
    }
    class Program
    {

  static Dictionary<char, int> oper = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            oper.Add('*', 1);
            oper.Add('/', 1);
            oper.Add('+', 2);
            oper.Add('-', 2);
            oper.Add('(', 0);
            oper.Add(')', 8);
            while (true)
            {
                Console.WriteLine("please choose your command: ");
                Console.WriteLine("1: Covert InFix to PostFix ");
                Console.WriteLine("2: Covert InFix to PreFix ");
                Console.WriteLine("3: Covert PreFix to InFix ");
                Console.WriteLine("4: Covert PreFix to PostFix ");
                Console.WriteLine("5: Covert PostFix to PreFix ");
                Console.WriteLine("6: Covert PostFix to InFix ");
                Console.WriteLine("7: Calculate postfix ");
                Console.WriteLine("8: Quit");
                int key = Convert.ToInt32(Console.ReadLine());
                if (key == 8)
                    break;
                Console.WriteLine("Please Enter your expression:");
                string s = Console.ReadLine();
                 if (key == 1)
                    Console.WriteLine("PostFix: " + Infixtopostfix(s));
                else if (key == 2)
                    Console.WriteLine("PreFix: " + Infixtoprefix(s));
                else if (key == 3)
                    Console.WriteLine("InFix: " + Prefixtoinfix(s));
                else if (key == 4)
                    Console.WriteLine("PostFix: " + Prefixtopostfix(s));
                else if (key == 5)
                    Console.WriteLine("PreFix: " + Postfixtoprefix(s));
                else if (key == 6)
                    Console.WriteLine("InFix: " + Postfixtoinfix(s));
                 else if (key == 7)
                     Console.WriteLine("the nuber is: " + CalculatePostfix(s));

            }
        }
          public static string Infixtoprefix(string exp)
        {
            bool add = false;
            Stack p = new Stack();
            exp.ToCharArray();
            string x = "";
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];

                if (oper.ContainsKey(s))
                {
                    if (oper[s] == 8 && p.stackC.Count != 0)
                    {
                        char j = p.stackC[p.topC];
                        while (j != '(')
                        {
                            string w = p.DeleteOfStackS();
                            string z = p.DeleteOfStackS();
                            string y = p.DeleteOfStackC() + z + w;
                            p.AddInStack(y);
                            j = p.stackC[p.topC];
                        }
                        char m = p.DeleteOfStackC();
                        add = true;
                    }
                    else if (p.stackC.Count == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (oper[p.stackC[p.topC]] != 0 && oper[s] <= oper[p.stackC[p.topC]])
                    {

                        p.AddInStack(s);
                        add = true;
                    }
                    else if (oper[p.stackC[p.topC]] == 0 || oper[s] == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else
                    {
                        string w = p.DeleteOfStackS();
                        string z = p.DeleteOfStackS();
                        string y = p.DeleteOfStackC() + z + w;
                        p.AddInStack(y);

                    }
                    if (add)
                        add = false;
                    else
                        i--;

                }
                else
                {
                    string t = "";
                    t += exp[i];
                    p.AddInStack(t);
                }
            }
            string f = p.DeleteOfStackS();
            string g = p.DeleteOfStackS();
            x = p.DeleteOfStackC() + g + f;

            return x;
        }
        public static string Infixtopostfix(string exp)
        {
            bool add = false;
            Stack p = new Stack();
            exp.ToCharArray();
            string x = "";
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];

                if (oper.ContainsKey(s))
                {
                    if (oper[s] == 8 && p.stackC.Count != 0)
                    {
                        char j = p.stackC[p.topC];
                        while (j != '(')
                        {
                            string w = p.DeleteOfStackS();
                            string z = p.DeleteOfStackS();
                            string y = z + w + p.DeleteOfStackC();
                            p.AddInStack(y);
                            j = p.stackC[p.topC];
                        }
                        char m = p.DeleteOfStackC();
                        add = true;
                    }
                    else if (p.stackC.Count == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (oper[p.stackC[p.topC]] != 0 && oper[s] <= oper[p.stackC[p.topC]])
                    {

                        p.AddInStack(s);
                        add = true;
                    }
                    else if (oper[p.stackC[p.topC]] == 0 || oper[s] == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else
                    {
                        string w = p.DeleteOfStackS();
                        string z = p.DeleteOfStackS();
                        string y = z + w + p.DeleteOfStackC();
                        p.AddInStack(y);

                    }
                    if (add)
                        add = false;
                    else
                        i--;

                }
                else
                {
                    string t = "";
                    t += exp[i];
                    p.AddInStack(t);
                }
            }
            string f = p.DeleteOfStackS();
            string g = p.DeleteOfStackS();
            x = g + f + p.DeleteOfStackC();

            return x;
        }
        public static string Postfixtoinfix(string exp)
        {
            string infix;
            Stack p = new Stack();
            exp.ToCharArray();
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];
                if (!oper.ContainsKey(s))
                {
                    string t = "";
                    t += s;
                    p.AddInStack(t);
                }
                else
                {
                    string w = p.DeleteOfStackS();
                    string z = p.DeleteOfStackS();
                    string y = "(" + z + s + w + ")";
                    p.AddInStack(y);
                }
            }
            infix = p.DeleteOfStackS();
            return infix;

        }
        public static string Prefixtoinfix(string exp)
        {
            exp.ToCharArray();
            Stack p = new Stack();
            string infix;
            for (int i = exp.Length - 1; i >= 0; i--)
            {
                char s = exp[i];
                if (!oper.ContainsKey(s))
                {
                    string t = "";
                    t += s;
                    p.AddInStack(t);
                }
                else
                {
                    string w = p.DeleteOfStackS();
                    string z = p.DeleteOfStackS();
                    string y = "(" + w + s + z + ")";
                    p.AddInStack(y);
                }
            }
            infix = p.DeleteOfStackS();
            return infix;
        }
        public static string Postfixtoprefix(string exp)
        {
            string pre = Postfixtoinfix(exp);
            pre = Infixtoprefix(pre);
            return pre;
        }
        public static string Prefixtopostfix(string exp)
        {
            string post = Prefixtoinfix(exp);
            post = Infixtopostfix(post);
            return post;
        }
        public static int CalculatePostfix(string exp)
        {
            int sum = 0;
            Stack p = new Stack();
            exp.ToCharArray();
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];

                if (!oper.ContainsKey(s))
                {
                    int t = 0;
                    t += Convert.ToInt32(s.ToString());
                    p.AddInStackI(t);
                }
                else
                {
                    int w = p.DeleteOfStackI();
                    int z = p.DeleteOfStackI();
                    int y = 0;
                    if (s == '+')
                        y = z + w;
                    else if (s == '-')
                        y = z - w;
                    else if (s == '*')
                        y = z * w;
                    else if (s == '/')
                        y = z / w;
                    p.AddInStackI(y);
                }

            }
            sum = p.DeleteOfStackI();
            return sum;
        }
    
    }
}
