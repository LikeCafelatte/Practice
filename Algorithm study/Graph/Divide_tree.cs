using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int n, int[,] wires) {
        int answer = n + 1;
        node[] tree = Enumerable.Range(0, n + 1).Select(id => new node(id)).ToArray();
        
        for(int i = 0; i < wires.GetLength(0); i++){
            tree[wires[i, 0]].children.Add(tree[wires[i, 1]]);
            tree[wires[i, 1]].children.Add(tree[wires[i, 0]]);
        }
        tree[1].GetChildren_count(tree[0]);
        foreach(node temp in tree){
            if(answer > Math.Abs(n - 2 * temp.children_count))
                answer = Math.Abs(n - 2 * temp.children_count);
        }
        return answer;
    }
    public class node{
        public node parent;
        public List<node> children = new List<node>();
        public int id;
        public int children_count;
        
        public node(int id){
            this.id = id;
        }
        
        public int GetChildren_count(node parent){
            children_count = 1;
            foreach(node n in children){
                if(n.Equals(parent)) continue;
                children_count += n.GetChildren_count(this);
            }
            return children_count;
        }
    }
}
