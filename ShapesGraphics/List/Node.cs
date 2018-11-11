namespace ShapesGraphics.List
{
    public class Node<T> where T:class
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
