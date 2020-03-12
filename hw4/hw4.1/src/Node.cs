namespace src
{
    public class Node
    {
        private string data;
        public string Data
        {
            get 
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        private Node rightNode;
        public Node RightNode
        {
            get 
            {
                return rightNode;
            }
            set
            {
                rightNode = value;
            }
        }

        private Node leftNode;
        public Node LeftNode
         {
            get 
            {
                return leftNode;
            }
            set
            {
                leftNode = value;
            }
        }

        public Node() { }
    }
}