using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] grid) {
        List<int> answer = new List<int>();
        Node[,] map = new Node[grid.Length, grid[0].ToCharArray().Length];
        Queue<Node> q_node = new Queue<Node>();
        int length_x = grid.Length, length_y = grid[0].ToCharArray().Length;
        for(int i = 0; i < grid.Length; i++){
            char[] temp_array = grid[i].ToCharArray();
            for(int j = 0; j < temp_array.Length; j++){
                map[i, j] = new Node(temp_array[j], i, j);
                q_node.Enqueue(map[i, j]);
            }
        }
        Node.map = map;

        Queue<KeyValuePair<Node, int>> q = new Queue<KeyValuePair<Node, int>> ();
        q.Enqueue(new KeyValuePair<Node, int> (map[0, 0], 0));
        int count = 0;
        while(q.Count > 0){
            var dq = q.Dequeue();
            int direction = dq.Key.GoThrough(dq.Value);
            if(direction == -1){
                if(count > 0){
                    answer.Add(count);
                    count = 0;
                    while(q_node.Count > 0){
                        var dq_node = q_node.Dequeue();
                        if(dq_node.isRemain() == -1){
                            continue;
                        }
                        q.Enqueue(new KeyValuePair<Node, int>(dq_node, dq_node.isRemain()));
                        q_node.Enqueue(dq_node);
                        break;
                    }
                }
                continue;
            }
            count++;
            int dx = 0, dy = 0;
            switch(direction){
                case 0:
                    dx = 1; dy = 0;
                    break;
                case 1:
                    dx = 0; dy = 1;
                    break;
                case 2:
                    dx = length_x - 1; dy = 0;
                    break;
                case 3:
                    dx = 0; dy = length_y - 1;
                    break;
            }
            q.Enqueue(new KeyValuePair<Node, int> (map[(dq.Key.x + dx)%length_x, (dq.Key.y + dy)%length_y], direction));
        }
        return answer.OrderBy(n => n).ToArray();
    }

    public class Node{
        public char node;
        public bool[] come_in = new bool[4];
        public int x;
        public int y;
        public static Node[,] map;

        public Node(char node, int x, int y){
            this.node = node;
            this.x = x;
            this.y = y;
        }

        public int isRemain(){
            for(int i = 0; i < 4; i++){
                if(!come_in[i]) return i;
            }
            return -1;
        }

        public int GoThrough(int come){
            if(come_in[come]) return -1;

            come_in[come] = true;

            switch(node){
                case 'S':
                    return come;
                    break;
                case 'L':
                    return (come + 3) % 4;
                    break;
                case 'R':
                    return (come + 1) % 4;
                    break;
            }

            return -2;
        }
    }
}