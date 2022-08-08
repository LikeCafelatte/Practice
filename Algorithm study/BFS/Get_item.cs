using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY) {
        int answer = 0;
        node[,] nodes = new node[52, 52];
        for(int i = 0; i < rectangle.GetLength(0); i++){
            int x = rectangle[i, 0], y = rectangle[i, 1];
            if(nodes[x, y] == null)
                nodes[x, y] = new node(x, y);
            for(int j = 0; j < 4; j++){
                bool isDone = false;
                while(!isDone){
                    switch(j){
                        case 0:
                            x++;
                            if(nodes[x, y] == null)
                            nodes[x, y] = new node(x, y);
                            nodes[x - 1, y].linked[2] = nodes[x, y];
                            nodes[x, y].linked[0] = nodes[x - 1, y];
                            if(x == rectangle[i, 2]) isDone = true;
                            break;
                        case 1:
                            y++;
                            if(nodes[x, y] == null)
                            nodes[x, y] = new node(x, y);
                            nodes[x, y - 1].linked[3] = nodes[x, y];
                            nodes[x, y].linked[1] = nodes[x, y - 1];
                            if(y == rectangle[i, 3]) isDone = true;
                            break;
                        case 2:
                            x--;
                            if(nodes[x, y] == null)
                            nodes[x, y] = new node(x, y);
                            nodes[x + 1, y].linked[0] = nodes[x, y];
                            nodes[x, y].linked[2] = nodes[x + 1, y];
                            if(x == rectangle[i, 0]) isDone = true;
                            break;
                        case 3:
                            y--;
                            if(nodes[x, y] == null)
                            nodes[x, y] = new node(x, y);
                            nodes[x, y + 1].linked[1] = nodes[x, y];
                            nodes[x, y].linked[3] = nodes[x, y + 1];
                            if(y == rectangle[i, 1]) isDone = true;
                            break;
                    }
                }
            }
        }
        
        for(int i = 0; i < rectangle.GetLength(0); i++){
            int x = rectangle[i, 0], y = rectangle[i, 1];
            for(int j = 0; j < 4; j++){
                bool isDone = false;
                while(!isDone){
                    switch(j){
                        case 0:
                            x++;
                            if(x == rectangle[i, 2]) {isDone = true; break;}
                            nodes[x, y].linked[3] = null;
                            break;
                        case 1:
                            y++;
                            if(y == rectangle[i, 3]) {isDone = true; break;}
                            nodes[x, y].linked[0] = null;
                            break;
                        case 2:
                            x--;
                            if(x == rectangle[i, 0]) {isDone = true; break;}
                            nodes[x, y].linked[1] = null;
                            break;
                        case 3:
                            y--;
                            if(y == rectangle[i, 1]) {isDone = true; break;}
                            nodes[x, y].linked[2] = null;
                            break;
                    }
                }
            }
        }
        Queue<node> q = new Queue<node>();
        q.Enqueue(nodes[characterX, characterY]);
        while(q.Count > 0){
            node dq = q.Dequeue();
            if(dq.isChecked) continue;
            dq.isChecked = true;
            answer = dq.distance;
            if(dq.x == itemX && dq.y == itemY) break;
            for(int i = 0; i < 4; i++){
                if(dq.linked[i] == null) continue;
                node n = dq.linked[i];
                if(n.isChecked) continue;
                n.distance = dq.distance + 1;
                q.Enqueue(n);
            }
        }
        return answer;
    }
    
    public class node{
        public node[] linked = new node[4];
        public int x;
        public int y;
        public bool isChecked = false;
        public int distance = 0;
        
        public node(int x, int y){
            this.x = x;
            this.y = y;
        }
    }
}