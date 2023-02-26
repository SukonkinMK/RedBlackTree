namespace RedBlackTree;
public class Program
{
    private static void Main(string[] args)
    {
        RedBlackTree tree = new RedBlackTree();
        string input;
        while (true)
        {
            Console.Write("Введите значение узла дерева: ");
            input = Console.ReadLine();
            if(int.TryParse(input, out int result))
            {
                tree.add(result);
                Console.WriteLine("done");
            }
            else
            {
                if (input.Equals("exit"))
                {
                    return;
                }
            }
        }
    }
}