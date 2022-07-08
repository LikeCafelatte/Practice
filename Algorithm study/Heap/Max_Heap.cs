public class MaxHeap 
{
    private List<int> list = new List<int>();

    public void Add(int value)
    {
        // add at the end
        list.Add(value);

        // bubble up
        int i = list.Count - 1;
        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (list[parent] < list[i]) // MinHeap에선 반대
            {
                Swap(parent, i);
                i = parent;
            }
            else
            {
                break;
            }
        }
    }

    public int RemoveOne()
    {
        if (list.Count == 0)
            throw new InvalidOperationException();

        int root = list[0];
            
        // move last to first 
        // and remove last one
        list[0] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);

        // bubble down
        int i = 0;
        int last = list.Count - 1;
        while (i < last)
        {
            // get left child index
            int child = i*2 + 1;

            // use right child if it is bigger                
            if (child < last && 
                list[child] < list[child + 1]) // MinHeap에선 반대
                child = child + 1;

            // if parent is bigger or equal, stop
            if (child > last || 
               list[i] >= list[child]) // MinHeap에선 반대
               break;
                
            // swap parent/child
            Swap(i, child);
            i = child;                                    
        }

        return root;
    }

    private void Swap(int i, int j)
    {
        int t = list[i];
        list[i] = list[j];
        list[j] = t;
    }
}