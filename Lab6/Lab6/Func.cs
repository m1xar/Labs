using System;

namespace Lab6
{
    public static class Func
    {
        public static Cell GenerateTree(string expression)
        {
            (string expLeft, char opr, string expRight) = Parse(expression);
            Cell root = new Cell(opr);

            if (expLeft.Length > 1)
            {
                root.LeftLeaf = GenerateTree(expLeft);
            }
            else
            {
                root.LeftLeaf = new Cell(expLeft[0]);
            }

            if (expRight.Length > 1)
            {
                root.RightLeaf = GenerateTree(expRight);
            }

            else
            {
                root.RightLeaf = new Cell(expRight[0]);
            }
            
            return root;
        }
        
        public static string String(Cell root, int level)
        {
            string result = "";
            if (root.LeftLeaf != null) 
            { 
                result += root.LeftLeaf + ", ";
                result += root.RightLeaf + "\n";
                result = result.Insert(0, $"Level number {level}: ");
            }
            level++;
            if (root.LeftLeaf != null)
            {
                result += String(root.LeftLeaf, level);
                result += String(root.RightLeaf, level);
            }
            return result;
        }
        
        private static bool IsOperator(char ch) => ch is '/' or '*' or '-' or '+';
        
        private static (string, char, string) Parse(string expression) 
        {
            int isInside = 0, operatorId = 0;
            char operatorValue = ' ';
            string Left = "",  Right = "";
            for(int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ')') isInside--;
                if (isInside > 0 && operatorId == 0) Left += expression[i];
                else if (isInside > 0 && i > operatorId) Right += expression[i];
                if (expression[i] == '(') isInside++;
                
                if (isInside != 0 || !IsOperator(expression[i])) continue;
                operatorValue = expression[i];
                operatorId = i;
                
                if (operatorId > 0 && Char.IsLetter(expression[operatorId - 1])) Left += expression[operatorId - 1];
                if (operatorId > 0 && Char.IsLetter(expression[operatorId + 1])) Right += expression[operatorId + 1];
            }
            
            return (Left, operatorValue, Right);
        }
    }
}